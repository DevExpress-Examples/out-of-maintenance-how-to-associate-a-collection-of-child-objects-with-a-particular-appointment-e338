Namespace SchedulerAppointmentChildObjects
    Partial Public Class CustomAppointmentForm
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.timeEnd = New DevExpress.XtraEditors.TimeEdit()
            Me.timeStart = New DevExpress.XtraEditors.TimeEdit()
            Me.dtEnd = New DevExpress.XtraEditors.DateEdit()
            Me.dtStart = New DevExpress.XtraEditors.DateEdit()
            Me.txPrice = New DevExpress.XtraEditors.TextEdit()
            Me.lblCustomName = New System.Windows.Forms.Label()
            Me.lblStart = New System.Windows.Forms.Label()
            Me.lblLabel = New System.Windows.Forms.Label()
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.edStatus = New DevExpress.XtraScheduler.UI.AppointmentStatusEdit()
            Me.edLabel = New DevExpress.XtraScheduler.UI.AppointmentLabelEdit()
            Me.txSubject = New DevExpress.XtraEditors.TextEdit()
            Me.lblSubject = New System.Windows.Forms.Label()
            Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
            Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
            Me.lblEnd = New System.Windows.Forms.Label()
            Me.groupBox1 = New System.Windows.Forms.GroupBox()
            Me.dgvPets = New System.Windows.Forms.DataGridView()
            Me.iDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.nameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.isNeuturedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.typeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.petsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.carsDBDataSet_Renamed = New SchedulerAppointmentChildObjects.CarsDBDataSet()
            Me.lblPets = New System.Windows.Forms.Label()
            Me.dgvInvoices = New System.Windows.Forms.DataGridView()
            Me.ColumnId = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ColumnDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ColumnPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.lblInvoices = New System.Windows.Forms.Label()
            Me.petsTableAdapter = New SchedulerAppointmentChildObjects.CarsDBDataSetTableAdapters.PetsTableAdapter()
            DirectCast(Me.timeEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.timeStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.dtEnd.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.dtEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.dtStart.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.dtStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.txPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.edStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.edLabel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.txSubject.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.groupBox1.SuspendLayout()
            DirectCast(Me.dgvPets, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.petsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.carsDBDataSet_Renamed, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.dgvInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' timeEnd
            ' 
            Me.timeEnd.EditValue = New Date(2006, 3, 28, 0, 0, 0, 0)
            Me.timeEnd.Location = New System.Drawing.Point(206, 68)
            Me.timeEnd.Name = "timeEnd"
            Me.timeEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.timeEnd.Size = New System.Drawing.Size(80, 20)
            Me.timeEnd.TabIndex = 21
            ' 
            ' timeStart
            ' 
            Me.timeStart.EditValue = New Date(2006, 3, 28, 0, 0, 0, 0)
            Me.timeStart.Location = New System.Drawing.Point(206, 44)
            Me.timeStart.Name = "timeStart"
            Me.timeStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.timeStart.Size = New System.Drawing.Size(80, 20)
            Me.timeStart.TabIndex = 19
            ' 
            ' dtEnd
            ' 
            Me.dtEnd.EditValue = New Date(2005, 11, 25, 0, 0, 0, 0)
            Me.dtEnd.Location = New System.Drawing.Point(94, 68)
            Me.dtEnd.Name = "dtEnd"
            Me.dtEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.dtEnd.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.dtEnd.Size = New System.Drawing.Size(96, 20)
            Me.dtEnd.TabIndex = 20
            ' 
            ' dtStart
            ' 
            Me.dtStart.EditValue = New Date(2005, 11, 25, 0, 0, 0, 0)
            Me.dtStart.Location = New System.Drawing.Point(94, 44)
            Me.dtStart.Name = "dtStart"
            Me.dtStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.dtStart.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.dtStart.Size = New System.Drawing.Size(96, 20)
            Me.dtStart.TabIndex = 18
            ' 
            ' txPrice
            ' 
            Me.txPrice.EditValue = ""
            Me.txPrice.Location = New System.Drawing.Point(94, 172)
            Me.txPrice.Name = "txPrice"
            Me.txPrice.Size = New System.Drawing.Size(192, 20)
            Me.txPrice.TabIndex = 26
            ' 
            ' lblCustomName
            ' 
            Me.lblCustomName.Location = New System.Drawing.Point(6, 173)
            Me.lblCustomName.Name = "lblCustomName"
            Me.lblCustomName.Size = New System.Drawing.Size(80, 19)
            Me.lblCustomName.TabIndex = 34
            Me.lblCustomName.Text = "Price:"
            ' 
            ' lblStart
            ' 
            Me.lblStart.Location = New System.Drawing.Point(6, 47)
            Me.lblStart.Name = "lblStart"
            Me.lblStart.Size = New System.Drawing.Size(56, 18)
            Me.lblStart.TabIndex = 33
            Me.lblStart.Text = "Start:"
            ' 
            ' lblLabel
            ' 
            Me.lblLabel.Location = New System.Drawing.Point(6, 140)
            Me.lblLabel.Name = "lblLabel"
            Me.lblLabel.Size = New System.Drawing.Size(48, 19)
            Me.lblLabel.TabIndex = 31
            Me.lblLabel.Text = "Label:"
            ' 
            ' lblStatus
            ' 
            Me.lblStatus.Location = New System.Drawing.Point(6, 116)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(48, 18)
            Me.lblStatus.TabIndex = 28
            Me.lblStatus.Text = "Status:"
            ' 
            ' edStatus
            ' 
            Me.edStatus.Location = New System.Drawing.Point(94, 116)
            Me.edStatus.Name = "edStatus"
            Me.edStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.edStatus.Size = New System.Drawing.Size(192, 20)
            Me.edStatus.TabIndex = 24
            ' 
            ' edLabel
            ' 
            Me.edLabel.Location = New System.Drawing.Point(94, 140)
            Me.edLabel.Name = "edLabel"
            Me.edLabel.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.edLabel.Size = New System.Drawing.Size(192, 20)
            Me.edLabel.TabIndex = 25
            ' 
            ' txSubject
            ' 
            Me.txSubject.EditValue = ""
            Me.txSubject.Location = New System.Drawing.Point(94, 12)
            Me.txSubject.Name = "txSubject"
            Me.txSubject.Size = New System.Drawing.Size(192, 20)
            Me.txSubject.TabIndex = 17
            ' 
            ' lblSubject
            ' 
            Me.lblSubject.Location = New System.Drawing.Point(6, 13)
            Me.lblSubject.Name = "lblSubject"
            Me.lblSubject.Size = New System.Drawing.Size(48, 18)
            Me.lblSubject.TabIndex = 22
            Me.lblSubject.Text = "Subject:"
            ' 
            ' btnCancel
            ' 
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.Location = New System.Drawing.Point(170, 251)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(60, 27)
            Me.btnCancel.TabIndex = 30
            Me.btnCancel.Text = "Cancel"
            ' 
            ' btnOK
            ' 
            Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.btnOK.Location = New System.Drawing.Point(104, 251)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(60, 27)
            Me.btnOK.TabIndex = 29
            Me.btnOK.Text = "OK"
            ' 
            ' lblEnd
            ' 
            Me.lblEnd.Location = New System.Drawing.Point(6, 71)
            Me.lblEnd.Name = "lblEnd"
            Me.lblEnd.Size = New System.Drawing.Size(48, 18)
            Me.lblEnd.TabIndex = 36
            Me.lblEnd.Text = "End:"
            ' 
            ' groupBox1
            ' 
            Me.groupBox1.Controls.Add(Me.dgvPets)
            Me.groupBox1.Controls.Add(Me.lblPets)
            Me.groupBox1.Controls.Add(Me.dgvInvoices)
            Me.groupBox1.Controls.Add(Me.lblInvoices)
            Me.groupBox1.Location = New System.Drawing.Point(303, 13)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Size = New System.Drawing.Size(376, 305)
            Me.groupBox1.TabIndex = 37
            Me.groupBox1.TabStop = False
            Me.groupBox1.Text = "Child objects"
            ' 
            ' dgvPets
            ' 
            Me.dgvPets.AutoGenerateColumns = False
            Me.dgvPets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvPets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvPets.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() { Me.iDDataGridViewTextBoxColumn, Me.nameDataGridViewTextBoxColumn, Me.isNeuturedDataGridViewCheckBoxColumn, Me.typeDataGridViewTextBoxColumn})
            Me.dgvPets.DataSource = Me.petsBindingSource
            Me.dgvPets.Location = New System.Drawing.Point(13, 186)
            Me.dgvPets.Name = "dgvPets"
            Me.dgvPets.Size = New System.Drawing.Size(350, 113)
            Me.dgvPets.TabIndex = 26
            ' 
            ' iDDataGridViewTextBoxColumn
            ' 
            Me.iDDataGridViewTextBoxColumn.DataPropertyName = "ID"
            Me.iDDataGridViewTextBoxColumn.HeaderText = "ID"
            Me.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn"
            Me.iDDataGridViewTextBoxColumn.ReadOnly = True
            ' 
            ' nameDataGridViewTextBoxColumn
            ' 
            Me.nameDataGridViewTextBoxColumn.DataPropertyName = "Name"
            Me.nameDataGridViewTextBoxColumn.HeaderText = "Name"
            Me.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn"
            ' 
            ' isNeuturedDataGridViewCheckBoxColumn
            ' 
            Me.isNeuturedDataGridViewCheckBoxColumn.DataPropertyName = "IsNeutured"
            Me.isNeuturedDataGridViewCheckBoxColumn.HeaderText = "IsNeutured"
            Me.isNeuturedDataGridViewCheckBoxColumn.Name = "isNeuturedDataGridViewCheckBoxColumn"
            ' 
            ' typeDataGridViewTextBoxColumn
            ' 
            Me.typeDataGridViewTextBoxColumn.DataPropertyName = "Type"
            Me.typeDataGridViewTextBoxColumn.HeaderText = "Type"
            Me.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn"
            ' 
            ' petsBindingSource
            ' 
            Me.petsBindingSource.DataMember = "Pets"
            Me.petsBindingSource.DataSource = Me.carsDBDataSet_Renamed
            ' 
            ' carsDBDataSet
            ' 
            Me.carsDBDataSet_Renamed.DataSetName = "CarsDBDataSet"
            Me.carsDBDataSet_Renamed.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' lblPets
            ' 
            Me.lblPets.AutoSize = True
            Me.lblPets.Location = New System.Drawing.Point(10, 170)
            Me.lblPets.Name = "lblPets"
            Me.lblPets.Size = New System.Drawing.Size(32, 13)
            Me.lblPets.TabIndex = 25
            Me.lblPets.Text = "Pets:"
            ' 
            ' dgvInvoices
            ' 
            Me.dgvInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvInvoices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() { Me.ColumnId, Me.ColumnDescription, Me.ColumnPrice})
            Me.dgvInvoices.Location = New System.Drawing.Point(13, 37)
            Me.dgvInvoices.Name = "dgvInvoices"
            Me.dgvInvoices.Size = New System.Drawing.Size(350, 123)
            Me.dgvInvoices.TabIndex = 24
            ' 
            ' ColumnId
            ' 
            Me.ColumnId.DataPropertyName = "Id"
            Me.ColumnId.HeaderText = "Id"
            Me.ColumnId.Name = "ColumnId"
            Me.ColumnId.ReadOnly = True
            ' 
            ' ColumnDescription
            ' 
            Me.ColumnDescription.DataPropertyName = "Description"
            Me.ColumnDescription.HeaderText = "Description"
            Me.ColumnDescription.Name = "ColumnDescription"
            ' 
            ' ColumnPrice
            ' 
            Me.ColumnPrice.DataPropertyName = "Price"
            Me.ColumnPrice.HeaderText = "Price"
            Me.ColumnPrice.Name = "ColumnPrice"
            ' 
            ' lblInvoices
            ' 
            Me.lblInvoices.AutoSize = True
            Me.lblInvoices.Location = New System.Drawing.Point(10, 20)
            Me.lblInvoices.Name = "lblInvoices"
            Me.lblInvoices.Size = New System.Drawing.Size(51, 13)
            Me.lblInvoices.TabIndex = 23
            Me.lblInvoices.Text = "Invoices:"
            ' 
            ' petsTableAdapter
            ' 
            Me.petsTableAdapter.ClearBeforeFill = True
            ' 
            ' CustomAppointmentForm
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(691, 330)
            Me.Controls.Add(Me.groupBox1)
            Me.Controls.Add(Me.lblEnd)
            Me.Controls.Add(Me.timeEnd)
            Me.Controls.Add(Me.timeStart)
            Me.Controls.Add(Me.dtEnd)
            Me.Controls.Add(Me.dtStart)
            Me.Controls.Add(Me.txPrice)
            Me.Controls.Add(Me.lblCustomName)
            Me.Controls.Add(Me.lblStart)
            Me.Controls.Add(Me.lblLabel)
            Me.Controls.Add(Me.lblStatus)
            Me.Controls.Add(Me.edStatus)
            Me.Controls.Add(Me.edLabel)
            Me.Controls.Add(Me.txSubject)
            Me.Controls.Add(Me.lblSubject)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOK)
            Me.Name = "CustomAppointmentForm"
            Me.Text = "My Appointment Form"
            DirectCast(Me.timeEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.timeStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.dtEnd.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.dtEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.dtStart.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.dtStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.txPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.edStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.edLabel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.txSubject.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.groupBox1.ResumeLayout(False)
            Me.groupBox1.PerformLayout()
            DirectCast(Me.dgvPets, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.petsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.carsDBDataSet_Renamed, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.dgvInvoices, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private WithEvents timeEnd As DevExpress.XtraEditors.TimeEdit
        Private WithEvents timeStart As DevExpress.XtraEditors.TimeEdit
        Private WithEvents dtEnd As DevExpress.XtraEditors.DateEdit
        Private WithEvents dtStart As DevExpress.XtraEditors.DateEdit
        Private txPrice As DevExpress.XtraEditors.TextEdit
        Private lblCustomName As System.Windows.Forms.Label
        Private lblStart As System.Windows.Forms.Label
        Private lblLabel As System.Windows.Forms.Label
        Private lblStatus As System.Windows.Forms.Label
        Private edStatus As DevExpress.XtraScheduler.UI.AppointmentStatusEdit
        Private edLabel As DevExpress.XtraScheduler.UI.AppointmentLabelEdit
        Private txSubject As DevExpress.XtraEditors.TextEdit
        Private lblSubject As System.Windows.Forms.Label
        Private btnCancel As DevExpress.XtraEditors.SimpleButton
        Private WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
        Private lblEnd As System.Windows.Forms.Label
        Private groupBox1 As System.Windows.Forms.GroupBox
        Private WithEvents dgvInvoices As System.Windows.Forms.DataGridView
        Private lblInvoices As System.Windows.Forms.Label
        Private ColumnId As System.Windows.Forms.DataGridViewTextBoxColumn
        Private ColumnDescription As System.Windows.Forms.DataGridViewTextBoxColumn
        Private ColumnPrice As System.Windows.Forms.DataGridViewTextBoxColumn
        Private dgvPets As System.Windows.Forms.DataGridView
        Private lblPets As System.Windows.Forms.Label

        Private carsDBDataSet_Renamed As CarsDBDataSet
        Private petsBindingSource As System.Windows.Forms.BindingSource
        Private petsTableAdapter As SchedulerAppointmentChildObjects.CarsDBDataSetTableAdapters.PetsTableAdapter
        Private iDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Private nameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Private isNeuturedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
        Private typeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace