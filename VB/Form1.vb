Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler

Namespace SchedulerAppointmentChildObjects
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            ' TODO: This line of code loads data into the 'carsDBDataSet.CarScheduling' table. You can move, or remove it, as needed.
            Me.carSchedulingTableAdapter.Fill(Me.carsDBDataSet_Renamed.CarScheduling)

            AddHandler carSchedulingTableAdapter.Adapter.RowUpdated, AddressOf Adapter_RowUpdated

            schedulerControl1.Start = schedulerStorage1.Appointments(0).Start
        End Sub

        Private Sub AppointmentsModified(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs) Handles schedulerStorage1.AppointmentsChanged, schedulerStorage1.AppointmentsInserted, schedulerStorage1.AppointmentsDeleted
            Me.carSchedulingTableAdapter.Update(Me.carsDBDataSet_Renamed)
            Me.carsDBDataSet_Renamed.AcceptChanges()
        End Sub

        Private Sub Adapter_RowUpdated(ByVal sender As Object, ByVal e As System.Data.OleDb.OleDbRowUpdatedEventArgs)
            If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
                Dim id As Integer = 0
                Using cmd As New OleDbCommand("SELECT @@IDENTITY", Me.carSchedulingTableAdapter.Connection)
                    id = DirectCast(cmd.ExecuteScalar(), Integer)
                End Using
                e.Row("ID") = id
            End If
        End Sub

        Private Sub schedulerControl1_EditAppointmentFormShowing(ByVal sender As Object, ByVal e As AppointmentFormEventArgs) Handles schedulerControl1.EditAppointmentFormShowing
            Dim apt As Appointment = e.Appointment
            Dim customForm As New CustomAppointmentForm(schedulerControl1, apt)

            customForm.LookAndFeel.ParentLookAndFeel = schedulerControl1.LookAndFeel

            e.DialogResult = customForm.ShowDialog()
            schedulerControl1.Refresh()
            e.Handled = True
        End Sub
    End Class
End Namespace