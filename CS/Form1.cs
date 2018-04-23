using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace SchedulerAppointmentChildObjects {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'carsDBDataSet.CarScheduling' table. You can move, or remove it, as needed.
            this.carSchedulingTableAdapter.Fill(this.carsDBDataSet.CarScheduling);

            this.carSchedulingTableAdapter.Adapter.RowUpdated +=
                new System.Data.OleDb.OleDbRowUpdatedEventHandler(Adapter_RowUpdated);

            schedulerControl1.Start = schedulerStorage1.Appointments[0].Start;
        }

        private void AppointmentsModified(object sender, PersistentObjectsEventArgs e) {
            this.carSchedulingTableAdapter.Update(this.carsDBDataSet);
            this.carsDBDataSet.AcceptChanges();
        }

        void Adapter_RowUpdated(object sender, System.Data.OleDb.OleDbRowUpdatedEventArgs e) {
            if (e.Status == UpdateStatus.Continue && e.StatementType == StatementType.Insert) {
                int id = 0;
                using (OleDbCommand cmd = new OleDbCommand("SELECT @@IDENTITY", this.carSchedulingTableAdapter.Connection)) {
                    id = (int)cmd.ExecuteScalar();
                }
                e.Row["ID"] = id;
            }
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e) {
            Appointment apt = e.Appointment;
            CustomAppointmentForm customForm = new CustomAppointmentForm(schedulerControl1, apt);

            customForm.LookAndFeel.ParentLookAndFeel = schedulerControl1.LookAndFeel;

            e.DialogResult = customForm.ShowDialog();
            schedulerControl1.Refresh();
            e.Handled = true;
        }
    }
}