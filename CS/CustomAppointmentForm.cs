using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.UI;

namespace SchedulerAppointmentChildObjects {
    public partial class CustomAppointmentForm : DevExpress.XtraEditors.XtraForm {
        SchedulerControl control;
        Appointment apt;
        int suspendUpdateCount;

        // The CustomAppointmentFormController class is inherited from
        // the AppointmentFormController to add custom properties.
        // See its declaration below.
        CustomAppointmentFormController controller;

        protected AppointmentStorage Appointments {
            get { return control.Storage.Appointments; }
        }

        protected bool IsUpdateSuspended { 
            get { return suspendUpdateCount > 0; } 
        }

        public CustomAppointmentForm(SchedulerControl control, Appointment apt) {
            this.controller = new CustomAppointmentFormController(control, apt);
            this.apt = apt;
            this.control = control;
            
            // Required for Windows Form Designer support
            SuspendUpdate();
            InitializeComponent();
            ResumeUpdate();
            UpdateForm();
            
            // TODO: Add any constructor code after InitializeComponent call
            dgvInvoices.AutoGenerateColumns = false;
            dgvPets.AutoGenerateColumns = false;

            
            carsDBDataSet.Pets.TableNewRow += new System.Data.DataTableNewRowEventHandler(Pets_TableNewRow);
        }

        void Pets_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e) {
            // Update Pets related ID for existing appointment
            e.Row["OwnerID"] = controller.AppointmentId;
        }

        #region dgvInvoices events
        private void dgvInvoices_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e) {
            int freeId = 0;

            for (int i = 0; i < dgvInvoices.Rows.Count; i++) {
                int currentId = Convert.ToInt32(dgvInvoices.Rows[i].Cells["ColumnId"].Value);

                if (currentId > freeId)
                    freeId = currentId;
            }

            e.Row.Cells["ColumnId"].Value = ++freeId;
        }
        #endregion

        #region Form control events
        private void dtStart_EditValueChanged(object sender, System.EventArgs e) {
            if (!IsUpdateSuspended)
                controller.DisplayStart = dtStart.DateTime.Date + timeStart.Time.TimeOfDay;
            UpdateIntervalControls();
        }

        private void timeStart_EditValueChanged(object sender, System.EventArgs e) {
            if (!IsUpdateSuspended)
                controller.DisplayStart = dtStart.DateTime.Date + timeStart.Time.TimeOfDay;
            UpdateIntervalControls();
        }
        private void timeEnd_EditValueChanged(object sender, System.EventArgs e) {
            if (IsUpdateSuspended) return;
            if (IsIntervalValid())
                controller.DisplayEnd = dtEnd.DateTime.Date + timeEnd.Time.TimeOfDay;
            else
                timeEnd.EditValue = new DateTime(controller.DisplayEnd.TimeOfDay.Ticks);

        }
        private void dtEnd_EditValueChanged(object sender, System.EventArgs e) {
            if (IsUpdateSuspended) return;
            if (IsIntervalValid())
                controller.DisplayEnd = dtEnd.DateTime.Date + timeEnd.Time.TimeOfDay;
            else
                dtEnd.EditValue = controller.DisplayEnd.Date;
        }
        bool IsIntervalValid() {
            DateTime start = dtStart.DateTime + timeStart.Time.TimeOfDay;
            DateTime end = dtEnd.DateTime + timeEnd.Time.TimeOfDay;
            return end >= start;
        }
        #endregion

        #region Updating Form
        protected void SuspendUpdate() {
            suspendUpdateCount++;
        }
        protected void ResumeUpdate() {
            if (suspendUpdateCount > 0)
                suspendUpdateCount--;
        }

        void UpdateForm() {
            SuspendUpdate();
            try {
                txSubject.Text = controller.Subject;
                edStatus.AppointmentStatus = Appointments.Statuses.GetById(controller.StatusKey);
                edLabel.AppointmentLabel = Appointments.Labels.GetById(controller.LabelKey);

                dtStart.DateTime = controller.DisplayStart.Date;
                dtEnd.DateTime = controller.DisplayEnd.Date;

                timeStart.Time = new DateTime(controller.DisplayStart.TimeOfDay.Ticks);
                timeEnd.Time = new DateTime(controller.DisplayEnd.TimeOfDay.Ticks);

                edStatus.Storage = control.Storage;
                edLabel.Storage = control.Storage;

                txPrice.Text = controller.Price.ToString();

                // Updating DataGridView with invoices
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = controller.Invoices;
                
                dgvInvoices.DataSource = bindingSource;

                // Updating DataGridView with pets
                petsTableAdapter.FillBy(carsDBDataSet.Pets, controller.AppointmentId);
            }
            finally {
                ResumeUpdate();
            }
            UpdateIntervalControls();
        }

        protected virtual void UpdateIntervalControls() {
            if (IsUpdateSuspended)
                return;

            SuspendUpdate();
            
            try {
                dtStart.EditValue = controller.DisplayStart.Date;
                dtEnd.EditValue = controller.DisplayEnd.Date;
                timeStart.EditValue = new DateTime(controller.DisplayStart.TimeOfDay.Ticks);
                timeEnd.EditValue = new DateTime(controller.DisplayEnd.TimeOfDay.Ticks);

                timeStart.Visible = !controller.AllDay;
                timeEnd.Visible = !controller.AllDay;
                timeStart.Enabled = !controller.AllDay;
                timeEnd.Enabled = !controller.AllDay;
            }
            finally {
                ResumeUpdate();
            }
        }

        void UpdateAppointmentStatus() {
            IAppointmentStatus currentStatus = edStatus.AppointmentStatus;
            IAppointmentStatus newStatus = controller.UpdateStatus(currentStatus);
            
            if (newStatus != currentStatus)
                edStatus.AppointmentStatus = newStatus;
        }

        #endregion

        #region Save changes
        private void btnOK_Click(object sender, System.EventArgs e) {
            // Required to check the appointment for conflicts.
            if (!controller.IsConflictResolved())
                return;

            controller.Subject = txSubject.Text;
            controller.SetStatus(edStatus.AppointmentStatus);
            controller.SetLabel(edLabel.AppointmentLabel);
            controller.DisplayStart = this.dtStart.DateTime.Date + this.timeStart.Time.TimeOfDay;
            controller.DisplayEnd = this.dtEnd.DateTime.Date + this.timeEnd.Time.TimeOfDay;
            controller.Price = Convert.ToDecimal(txPrice.Text);

            // Save Invoices
            controller.Invoices = (List<Invoice>)((BindingSource)dgvInvoices.DataSource).DataSource;

            // Save all changes of the editing appointment.
            bool isNewApt = controller.IsNewAppointment;
            controller.ApplyChanges();

            // Update Pets related ID for newly created appointment and save Pets
            if (isNewApt) {
                for (int i = 0; i < carsDBDataSet.Pets.Rows.Count; i++) {
                    carsDBDataSet.Pets.Rows[i]["OwnerID"] = controller.AppointmentId;
                }
            }
            petsTableAdapter.Update(carsDBDataSet.Pets);
        }
        #endregion

        #region CustomAppointmentFormController
        public class CustomAppointmentFormController : AppointmentFormController {
            public decimal Price {
                get {
                    object val = EditedAppointmentCopy.CustomFields["Field1"];

                    if (val == null || val == DBNull.Value)
                        return 0;
                    else
                        return (decimal)val;
                }
                set { 
                    EditedAppointmentCopy.CustomFields["Field1"] = value; 
                }
            }

            decimal SourcePrice { get { return (decimal)SourceAppointment.CustomFields["Field1"]; } set { SourceAppointment.CustomFields["Field1"] = value; } }

            public List<Invoice> Invoices {
                get {
                    object val = EditedAppointmentCopy.CustomFields["InvoicesXML"];

                    if (val == null || val == DBNull.Value)
                        return new List<Invoice>();
                    else {
                        List<Invoice> result;
                        XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Invoice>));

                        using (StringReader stringReader = new StringReader(val.ToString())) {
                            result = (List<Invoice>)xmlFormat.Deserialize(stringReader);
                        }

                        return result;
                    }
                }
                set {
                    string invoicesXML;
                    XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Invoice>));

                    using (StringWriter stringWriter = new StringWriter()) {
                        xmlFormat.Serialize(stringWriter, value);

                        invoicesXML = stringWriter.ToString();
                    }

                    EditedAppointmentCopy.CustomFields["InvoicesXML"] = invoicesXML;
                }
            }

            private List<Invoice> SourceInvoices {
                get {
                    object val = SourceAppointment.CustomFields["InvoicesXML"];

                    List<Invoice> result;
                    XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Invoice>));

                    using (StringReader stringReader = new StringReader(val.ToString())) {
                        result = (List<Invoice>)xmlFormat.Deserialize(stringReader);
                    }

                    return result;
                }
                set {
                    string invoicesXML;
                    XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Invoice>));

                    using (StringWriter stringWriter = new StringWriter()) {
                        xmlFormat.Serialize(stringWriter, value);

                        invoicesXML = stringWriter.ToString();
                    }

                    SourceAppointment.CustomFields["InvoicesXML"] = invoicesXML;
                }
            }

            public int AppointmentId {
                get {
                    return Convert.ToInt32(SourceAppointment.GetValue(this.Control.Storage, "ID"));
                }
            }

            public CustomAppointmentFormController(SchedulerControl control, Appointment apt)
                : base(control, apt) {
            }

            public override bool IsAppointmentChanged() {
                if (base.IsAppointmentChanged())
                    return true;
                return SourcePrice != Price;
            }

            protected override void ApplyCustomFieldsValues() {
                SourcePrice = Price;
                SourceInvoices = Invoices;
            }
        }
        #endregion
    }
}
