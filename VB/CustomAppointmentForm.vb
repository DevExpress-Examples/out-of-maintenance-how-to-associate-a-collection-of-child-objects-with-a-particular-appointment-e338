Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Windows.Forms
Imports System.Xml.Serialization
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.UI

Namespace SchedulerAppointmentChildObjects
	Partial Public Class CustomAppointmentForm
		Inherits DevExpress.XtraEditors.XtraForm
		Private control As SchedulerControl
		Private apt As Appointment
		Private suspendUpdateCount As Integer

		' The CustomAppointmentFormController class is inherited from
		' the AppointmentFormController to add custom properties.
		' See its declaration below.
		Private controller As CustomAppointmentFormController

		Protected ReadOnly Property Appointments() As AppointmentStorage
			Get
				Return control.Storage.Appointments
			End Get
		End Property

		Protected ReadOnly Property IsUpdateSuspended() As Boolean
			Get
				Return suspendUpdateCount > 0
			End Get
		End Property

		Public Sub New(ByVal control As SchedulerControl, ByVal apt As Appointment)
			Me.controller = New CustomAppointmentFormController(control, apt)
			Me.apt = apt
			Me.control = control

			' Required for Windows Form Designer support
			SuspendUpdate()
			InitializeComponent()
			ResumeUpdate()
			UpdateForm()

			' TODO: Add any constructor code after InitializeComponent call
			dgvInvoices.AutoGenerateColumns = False
			dgvPets.AutoGenerateColumns = False


			AddHandler carsDBDataSet.Pets.TableNewRow, AddressOf Pets_TableNewRow
		End Sub

		Private Sub Pets_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs)
			' Update Pets related ID for existing appointment
			e.Row("OwnerID") = controller.AppointmentId
		End Sub

		#Region "dgvInvoices events"
		Private Sub dgvInvoices_DefaultValuesNeeded(ByVal sender As Object, ByVal e As DataGridViewRowEventArgs) Handles dgvInvoices.DefaultValuesNeeded
			Dim freeId As Integer = 0

			For i As Integer = 0 To dgvInvoices.Rows.Count - 1
				Dim currentId As Integer = Convert.ToInt32(dgvInvoices.Rows(i).Cells("ColumnId").Value)

				If currentId > freeId Then
					freeId = currentId
				End If
			Next i

			freeId += 1
			e.Row.Cells("ColumnId").Value = freeId
		End Sub
		#End Region

		#Region "Form control events"
		Private Sub dtStart_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtStart.EditValueChanged
			If (Not IsUpdateSuspended) Then
				controller.DisplayStart = dtStart.DateTime.Date + timeStart.Time.TimeOfDay
			End If
			UpdateIntervalControls()
		End Sub

		Private Sub timeStart_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles timeStart.EditValueChanged
			If (Not IsUpdateSuspended) Then
				controller.DisplayStart = dtStart.DateTime.Date + timeStart.Time.TimeOfDay
			End If
			UpdateIntervalControls()
		End Sub
		Private Sub timeEnd_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles timeEnd.EditValueChanged
			If IsUpdateSuspended Then
				Return
			End If
			If IsIntervalValid() Then
				controller.DisplayEnd = dtEnd.DateTime.Date + timeEnd.Time.TimeOfDay
			Else
				timeEnd.EditValue = New DateTime(controller.DisplayEnd.TimeOfDay.Ticks)
			End If

		End Sub
		Private Sub dtEnd_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtEnd.EditValueChanged
			If IsUpdateSuspended Then
				Return
			End If
			If IsIntervalValid() Then
				controller.DisplayEnd = dtEnd.DateTime.Date + timeEnd.Time.TimeOfDay
			Else
				dtEnd.EditValue = controller.DisplayEnd.Date
			End If
		End Sub
		Private Function IsIntervalValid() As Boolean
			Dim start As DateTime = dtStart.DateTime + timeStart.Time.TimeOfDay
			Dim [end] As DateTime = dtEnd.DateTime + timeEnd.Time.TimeOfDay
			Return [end] >= start
		End Function
		#End Region

		#Region "Updating Form"
		Protected Sub SuspendUpdate()
			suspendUpdateCount += 1
		End Sub
		Protected Sub ResumeUpdate()
			If suspendUpdateCount > 0 Then
				suspendUpdateCount -= 1
			End If
		End Sub

		Private Sub UpdateForm()
			SuspendUpdate()
			Try
				txSubject.Text = controller.Subject
				edStatus.Status = Appointments.Statuses(controller.StatusId)
				edLabel.Label = Appointments.Labels(controller.LabelId)

				dtStart.DateTime = controller.DisplayStart.Date
				dtEnd.DateTime = controller.DisplayEnd.Date

				timeStart.Time = New DateTime(controller.DisplayStart.TimeOfDay.Ticks)
				timeEnd.Time = New DateTime(controller.DisplayEnd.TimeOfDay.Ticks)

				edStatus.Storage = control.Storage
				edLabel.Storage = control.Storage

				txPrice.Text = controller.Price.ToString()

				' Updating DataGridView with invoices
				Dim bindingSource As New BindingSource()
				bindingSource.DataSource = controller.Invoices

				dgvInvoices.DataSource = bindingSource

				' Updating DataGridView with pets
				petsTableAdapter.FillBy(carsDBDataSet.Pets, controller.AppointmentId)
			Finally
				ResumeUpdate()
			End Try
			UpdateIntervalControls()
		End Sub

		Protected Overridable Sub UpdateIntervalControls()
			If IsUpdateSuspended Then
				Return
			End If

			SuspendUpdate()

			Try
				dtStart.EditValue = controller.DisplayStart.Date
				dtEnd.EditValue = controller.DisplayEnd.Date
				timeStart.EditValue = New DateTime(controller.DisplayStart.TimeOfDay.Ticks)
				timeEnd.EditValue = New DateTime(controller.DisplayEnd.TimeOfDay.Ticks)

				timeStart.Visible = Not controller.AllDay
				timeEnd.Visible = Not controller.AllDay
				timeStart.Enabled = Not controller.AllDay
				timeEnd.Enabled = Not controller.AllDay
			Finally
				ResumeUpdate()
			End Try
		End Sub

		Private Sub UpdateAppointmentStatus()
			Dim currentStatus As AppointmentStatus = edStatus.Status
			Dim newStatus As AppointmentStatus = controller.UpdateAppointmentStatus(currentStatus)

			If newStatus IsNot currentStatus Then
				edStatus.Status = newStatus
			End If
		End Sub

		#End Region

		#Region "Save changes"
		Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
			' Required to check the appointment for conflicts.
			If (Not controller.IsConflictResolved()) Then
				Return
			End If

			controller.Subject = txSubject.Text
			controller.SetStatus(edStatus.Status)
			controller.SetLabel(edLabel.Label)
			controller.DisplayStart = Me.dtStart.DateTime.Date + Me.timeStart.Time.TimeOfDay
			controller.DisplayEnd = Me.dtEnd.DateTime.Date + Me.timeEnd.Time.TimeOfDay
			controller.Price = Convert.ToDecimal(txPrice.Text)

			' Save Invoices
			controller.Invoices = CType((CType(dgvInvoices.DataSource, BindingSource)).DataSource, List(Of Invoice))

			' Save all changes of the editing appointment.
			Dim isNewApt As Boolean = controller.IsNewAppointment
			controller.ApplyChanges()

			' Update Pets related ID for newly created appointment and save Pets
			If isNewApt Then
				For i As Integer = 0 To carsDBDataSet.Pets.Rows.Count - 1
					carsDBDataSet.Pets.Rows(i)("OwnerID") = controller.AppointmentId
				Next i
			End If
			petsTableAdapter.Update(carsDBDataSet.Pets)
		End Sub
		#End Region

		#Region "CustomAppointmentFormController"
		Public Class CustomAppointmentFormController
			Inherits AppointmentFormController
			Public Property Price() As Decimal
				Get
					Dim val As Object = EditedAppointmentCopy.CustomFields("Field1")

					If val Is Nothing OrElse val Is DBNull.Value Then
						Return 0
					Else
						Return CDec(val)
					End If
				End Get
				Set(ByVal value As Decimal)
					EditedAppointmentCopy.CustomFields("Field1") = value
				End Set
			End Property

			Private Property SourcePrice() As Decimal
				Get
					Return CDec(SourceAppointment.CustomFields("Field1"))
				End Get
				Set(ByVal value As Decimal)
					SourceAppointment.CustomFields("Field1") = value
				End Set
			End Property

			Public Property Invoices() As List(Of Invoice)
				Get
					Dim val As Object = EditedAppointmentCopy.CustomFields("InvoicesXML")

					If val Is Nothing OrElse val Is DBNull.Value Then
						Return New List(Of Invoice)()
					Else
						Dim result As List(Of Invoice)
						Dim xmlFormat As New XmlSerializer(GetType(List(Of Invoice)))

						Using stringReader As New StringReader(val.ToString())
							result = CType(xmlFormat.Deserialize(stringReader), List(Of Invoice))
						End Using

						Return result
					End If
				End Get
				Set(ByVal value As List(Of Invoice))
					Dim invoicesXML As String
					Dim xmlFormat As New XmlSerializer(GetType(List(Of Invoice)))

					Using stringWriter As New StringWriter()
						xmlFormat.Serialize(stringWriter, value)

						invoicesXML = stringWriter.ToString()
					End Using

					EditedAppointmentCopy.CustomFields("InvoicesXML") = invoicesXML
				End Set
			End Property

			Private Property SourceInvoices() As List(Of Invoice)
				Get
					Dim val As Object = SourceAppointment.CustomFields("InvoicesXML")

					Dim result As List(Of Invoice)
					Dim xmlFormat As New XmlSerializer(GetType(List(Of Invoice)))

					Using stringReader As New StringReader(val.ToString())
						result = CType(xmlFormat.Deserialize(stringReader), List(Of Invoice))
					End Using

					Return result
				End Get
				Set(ByVal value As List(Of Invoice))
					Dim invoicesXML As String
					Dim xmlFormat As New XmlSerializer(GetType(List(Of Invoice)))

					Using stringWriter As New StringWriter()
						xmlFormat.Serialize(stringWriter, value)

						invoicesXML = stringWriter.ToString()
					End Using

					SourceAppointment.CustomFields("InvoicesXML") = invoicesXML
				End Set
			End Property

			Public ReadOnly Property AppointmentId() As Integer
				Get
					Return Convert.ToInt32(SourceAppointment.GetValue(Me.Control.Storage, "ID"))
				End Get
			End Property

			Public Sub New(ByVal control As SchedulerControl, ByVal apt As Appointment)
				MyBase.New(control, apt)
			End Sub

			Public Overrides Function IsAppointmentChanged() As Boolean
				If MyBase.IsAppointmentChanged() Then
					Return True
				End If
				Return SourcePrice <> Price
			End Function

			Protected Overrides Sub ApplyCustomFieldsValues()
				SourcePrice = Price
				SourceInvoices = Invoices
			End Sub
		End Class
		#End Region
	End Class
End Namespace
