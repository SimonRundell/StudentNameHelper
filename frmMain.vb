Imports System.IO
Imports System.Text

Public Class frmMain
    Inherits Form

    Private WithEvents cboClass As ComboBox
    Private WithEvents cboStudent As ComboBox
    Private WithEvents rbFirstLast As RadioButton
    Private WithEvents rbLastFirst As RadioButton
    Private WithEvents btnCopyStudent As Button
    Private WithEvents btnCopyAllNames As Button
    Private WithEvents txtFolderPath As TextBox
    Private WithEvents btnBrowseFolder As Button
    Private WithEvents btnCreateFolders As Button
    Private WithEvents btnManageData As Button
    Private WithEvents lblStatus As Label
    Private tipMain As ToolTip
    Private _dataManager As DataManager
    Private components As System.ComponentModel.IContainer
    Friend WithEvents grpSelect As GroupBox
    Friend WithEvents lblClass As Label
    Friend WithEvents lblStudent As Label
    Friend WithEvents lblFormat As Label
    Friend WithEvents lblHint As Label
    Friend WithEvents grpFolders As GroupBox
    Friend WithEvents lblFolder As Label
    Private _appData As AppData

    Public Sub New()
        InitializeComponent()
        _dataManager = New DataManager(GetDataFilePath())
        LoadData()
    End Sub

    Private Function GetDataFilePath() As String
        Return Path.Combine(Application.StartupPath, "students.json")
    End Function

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tipMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCopyStudent = New System.Windows.Forms.Button()
        Me.btnCopyAllNames = New System.Windows.Forms.Button()
        Me.btnCreateFolders = New System.Windows.Forms.Button()
        Me.grpSelect = New System.Windows.Forms.GroupBox()
        Me.lblClass = New System.Windows.Forms.Label()
        Me.cboClass = New System.Windows.Forms.ComboBox()
        Me.lblStudent = New System.Windows.Forms.Label()
        Me.cboStudent = New System.Windows.Forms.ComboBox()
        Me.lblFormat = New System.Windows.Forms.Label()
        Me.rbFirstLast = New System.Windows.Forms.RadioButton()
        Me.rbLastFirst = New System.Windows.Forms.RadioButton()
        Me.lblHint = New System.Windows.Forms.Label()
        Me.grpFolders = New System.Windows.Forms.GroupBox()
        Me.lblFolder = New System.Windows.Forms.Label()
        Me.txtFolderPath = New System.Windows.Forms.TextBox()
        Me.btnBrowseFolder = New System.Windows.Forms.Button()
        Me.btnManageData = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.grpSelect.SuspendLayout()
        Me.grpFolders.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCopyStudent
        '
        Me.btnCopyStudent.Location = New System.Drawing.Point(72, 148)
        Me.btnCopyStudent.Name = "btnCopyStudent"
        Me.btnCopyStudent.Size = New System.Drawing.Size(158, 32)
        Me.btnCopyStudent.TabIndex = 8
        Me.btnCopyStudent.Text = "Copy Student Name"
        Me.tipMain.SetToolTip(Me.btnCopyStudent, "Copies the selected student's name in the chosen format." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "First Last: ""John Smith" &
        """  |  Last, First: ""Smith, John""")
        '
        'btnCopyAllNames
        '
        Me.btnCopyAllNames.Location = New System.Drawing.Point(240, 148)
        Me.btnCopyAllNames.Name = "btnCopyAllNames"
        Me.btnCopyAllNames.Size = New System.Drawing.Size(148, 32)
        Me.btnCopyAllNames.TabIndex = 9
        Me.btnCopyAllNames.Text = "Copy All Names"
        Me.tipMain.SetToolTip(Me.btnCopyAllNames, "Copies every student in the selected class." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "First Last: one name per line (singl" &
        "e Excel column)." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Last, First: Last[TAB]First per line (two Excel columns).")
        '
        'btnCreateFolders
        '
        Me.btnCreateFolders.Location = New System.Drawing.Point(94, 62)
        Me.btnCreateFolders.Name = "btnCreateFolders"
        Me.btnCreateFolders.Size = New System.Drawing.Size(148, 30)
        Me.btnCreateFolders.TabIndex = 3
        Me.btnCreateFolders.Text = "Create Folders"
        Me.tipMain.SetToolTip(Me.btnCreateFolders, "Creates one subfolder per student inside the chosen parent folder." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "First Last: f" &
        "older named ""John Smith""." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Last, First: folder named ""Smith John""." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Existing fol" &
        "ders are silently skipped.")
        '
        'grpSelect
        '
        Me.grpSelect.Controls.Add(Me.lblClass)
        Me.grpSelect.Controls.Add(Me.cboClass)
        Me.grpSelect.Controls.Add(Me.lblStudent)
        Me.grpSelect.Controls.Add(Me.cboStudent)
        Me.grpSelect.Controls.Add(Me.lblFormat)
        Me.grpSelect.Controls.Add(Me.rbFirstLast)
        Me.grpSelect.Controls.Add(Me.rbLastFirst)
        Me.grpSelect.Controls.Add(Me.lblHint)
        Me.grpSelect.Controls.Add(Me.btnCopyStudent)
        Me.grpSelect.Controls.Add(Me.btnCopyAllNames)
        Me.grpSelect.Location = New System.Drawing.Point(10, 10)
        Me.grpSelect.Name = "grpSelect"
        Me.grpSelect.Size = New System.Drawing.Size(460, 210)
        Me.grpSelect.TabIndex = 0
        Me.grpSelect.TabStop = False
        Me.grpSelect.Text = "Select Class & Student"
        '
        'lblClass
        '
        Me.lblClass.Location = New System.Drawing.Point(8, 28)
        Me.lblClass.Name = "lblClass"
        Me.lblClass.Size = New System.Drawing.Size(60, 20)
        Me.lblClass.TabIndex = 0
        Me.lblClass.Text = "Class:"
        Me.lblClass.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboClass
        '
        Me.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClass.Location = New System.Drawing.Point(72, 25)
        Me.cboClass.Name = "cboClass"
        Me.cboClass.Size = New System.Drawing.Size(376, 23)
        Me.cboClass.TabIndex = 1
        '
        'lblStudent
        '
        Me.lblStudent.Location = New System.Drawing.Point(8, 62)
        Me.lblStudent.Name = "lblStudent"
        Me.lblStudent.Size = New System.Drawing.Size(60, 20)
        Me.lblStudent.TabIndex = 2
        Me.lblStudent.Text = "Student:"
        Me.lblStudent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboStudent
        '
        Me.cboStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStudent.Location = New System.Drawing.Point(72, 59)
        Me.cboStudent.Name = "cboStudent"
        Me.cboStudent.Size = New System.Drawing.Size(376, 23)
        Me.cboStudent.TabIndex = 3
        '
        'lblFormat
        '
        Me.lblFormat.Location = New System.Drawing.Point(8, 98)
        Me.lblFormat.Name = "lblFormat"
        Me.lblFormat.Size = New System.Drawing.Size(60, 20)
        Me.lblFormat.TabIndex = 4
        Me.lblFormat.Text = "Format:"
        Me.lblFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rbFirstLast
        '
        Me.rbFirstLast.Checked = True
        Me.rbFirstLast.Location = New System.Drawing.Point(72, 96)
        Me.rbFirstLast.Name = "rbFirstLast"
        Me.rbFirstLast.Size = New System.Drawing.Size(90, 22)
        Me.rbFirstLast.TabIndex = 5
        Me.rbFirstLast.TabStop = True
        Me.rbFirstLast.Text = "First Last"
        '
        'rbLastFirst
        '
        Me.rbLastFirst.Location = New System.Drawing.Point(168, 96)
        Me.rbLastFirst.Name = "rbLastFirst"
        Me.rbLastFirst.Size = New System.Drawing.Size(95, 22)
        Me.rbLastFirst.TabIndex = 6
        Me.rbLastFirst.Text = "Last, First"
        '
        'lblHint
        '
        Me.lblHint.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Italic)
        Me.lblHint.ForeColor = System.Drawing.Color.Gray
        Me.lblHint.Location = New System.Drawing.Point(72, 122)
        Me.lblHint.Name = "lblHint"
        Me.lblHint.Size = New System.Drawing.Size(378, 16)
        Me.lblHint.TabIndex = 7
        Me.lblHint.Text = "Copy All: 'First Last' - one name per line  |  'Last, First' - Last[TAB]First (tw" &
    "o Excel columns)"
        '
        'grpFolders
        '
        Me.grpFolders.Controls.Add(Me.lblFolder)
        Me.grpFolders.Controls.Add(Me.txtFolderPath)
        Me.grpFolders.Controls.Add(Me.btnBrowseFolder)
        Me.grpFolders.Controls.Add(Me.btnCreateFolders)
        Me.grpFolders.Location = New System.Drawing.Point(10, 230)
        Me.grpFolders.Name = "grpFolders"
        Me.grpFolders.Size = New System.Drawing.Size(460, 108)
        Me.grpFolders.TabIndex = 1
        Me.grpFolders.TabStop = False
        Me.grpFolders.Text = "Create Student Folders"
        '
        'lblFolder
        '
        Me.lblFolder.Location = New System.Drawing.Point(8, 28)
        Me.lblFolder.Name = "lblFolder"
        Me.lblFolder.Size = New System.Drawing.Size(82, 20)
        Me.lblFolder.TabIndex = 0
        Me.lblFolder.Text = "Parent folder:"
        Me.lblFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFolderPath
        '
        Me.txtFolderPath.Location = New System.Drawing.Point(94, 25)
        Me.txtFolderPath.Name = "txtFolderPath"
        Me.txtFolderPath.ReadOnly = True
        Me.txtFolderPath.Size = New System.Drawing.Size(270, 23)
        Me.txtFolderPath.TabIndex = 1
        '
        'btnBrowseFolder
        '
        Me.btnBrowseFolder.Location = New System.Drawing.Point(372, 24)
        Me.btnBrowseFolder.Name = "btnBrowseFolder"
        Me.btnBrowseFolder.Size = New System.Drawing.Size(78, 26)
        Me.btnBrowseFolder.TabIndex = 2
        Me.btnBrowseFolder.Text = "Browse..."
        '
        'btnManageData
        '
        Me.btnManageData.Location = New System.Drawing.Point(10, 350)
        Me.btnManageData.Name = "btnManageData"
        Me.btnManageData.Size = New System.Drawing.Size(230, 32)
        Me.btnManageData.TabIndex = 2
        Me.btnManageData.Text = "Manage Classes and Students..."
        '
        'lblStatus
        '
        Me.lblStatus.ForeColor = System.Drawing.Color.DimGray
        Me.lblStatus.Location = New System.Drawing.Point(7, 397)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(460, 18)
        Me.lblStatus.TabIndex = 3
        Me.lblStatus.Text = "Ready."
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmMain
        '
        Me.ClientSize = New System.Drawing.Size(480, 424)
        Me.Controls.Add(Me.grpSelect)
        Me.Controls.Add(Me.grpFolders)
        Me.Controls.Add(Me.btnManageData)
        Me.Controls.Add(Me.lblStatus)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Student Name Helper"
        Me.grpSelect.ResumeLayout(False)
        Me.grpFolders.ResumeLayout(False)
        Me.grpFolders.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private Sub LoadData()
        _appData = _dataManager.Load()
        PopulateClassDropdown()
    End Sub

    Private Sub PopulateClassDropdown()
        Dim previousName As String = Nothing
        If cboClass.SelectedItem IsNot Nothing Then
            previousName = TryCast(cboClass.SelectedItem, SchoolClass)?.Name
        End If

        cboClass.Items.Clear()
        cboStudent.Items.Clear()

        For Each sc As SchoolClass In _appData.Classes
            cboClass.Items.Add(sc)
        Next

        If previousName IsNot Nothing Then
            For i As Integer = 0 To cboClass.Items.Count - 1
                Dim sc As SchoolClass = TryCast(cboClass.Items(i), SchoolClass)
                If sc IsNot Nothing AndAlso sc.Name = previousName Then
                    cboClass.SelectedIndex = i
                    Exit For
                End If
            Next
        End If

        If cboClass.SelectedIndex = -1 AndAlso cboClass.Items.Count > 0 Then
            cboClass.SelectedIndex = 0
        End If
    End Sub

    Private Sub PopulateStudentDropdown()
        cboStudent.Items.Clear()

        Dim sc As SchoolClass = TryCast(cboClass.SelectedItem, SchoolClass)
        If sc IsNot Nothing Then
            For Each student As Student In sc.Students
                cboStudent.Items.Add(student)
            Next

            If cboStudent.Items.Count > 0 Then
                cboStudent.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Function GetSelectedFormat() As NameFormat
        If rbLastFirst.Checked Then
            Return NameFormat.LastFirst
        Else
            Return NameFormat.FirstLast
        End If
    End Function

    Private Sub SetStatus(message As String, Optional isError As Boolean = False)
        lblStatus.Text = message
        lblStatus.ForeColor = If(isError, Color.Crimson, Color.DimGray)
    End Sub

    Private Sub cboClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClass.SelectedIndexChanged
        PopulateStudentDropdown()
    End Sub

    Private Sub btnCopyStudent_Click(sender As Object, e As EventArgs) Handles btnCopyStudent.Click
        Dim student As Student = TryCast(cboStudent.SelectedItem, Student)
        If student Is Nothing Then
            SetStatus("Please select a student first.", True)
            Return
        End If

        Dim name As String
        If GetSelectedFormat() = NameFormat.FirstLast Then
            name = String.Format("{0} {1}", student.FirstName, student.LastName)
        Else
            name = String.Format("{0}, {1}", student.LastName, student.FirstName)
        End If

        Clipboard.SetText(name)
        SetStatus(String.Format("Copied: {0}", name))
    End Sub

    Private Sub btnCopyAllNames_Click(sender As Object, e As EventArgs) Handles btnCopyAllNames.Click
        Dim sc As SchoolClass = TryCast(cboClass.SelectedItem, SchoolClass)
        If sc Is Nothing OrElse sc.Students.Count = 0 Then
            SetStatus("Please select a class with students.", True)
            Return
        End If

        Dim format As NameFormat = GetSelectedFormat()
        Dim sb As New StringBuilder()

        For Each s As Student In sc.Students
            If format = NameFormat.FirstLast Then
                sb.AppendLine(String.Format("{0} {1}", s.FirstName, s.LastName))
            Else
                sb.AppendLine(String.Format("{0}{1}{2}", s.LastName, vbTab, s.FirstName))
            End If
        Next

        Clipboard.SetText(sb.ToString().TrimEnd())
        SetStatus(String.Format("Copied {0} name(s) from '{1}'.", sc.Students.Count, sc.Name))
    End Sub

    Private Sub btnBrowseFolder_Click(sender As Object, e As EventArgs) Handles btnBrowseFolder.Click
        Using dlg As New FolderBrowserDialog()
            dlg.Description = "Select the parent folder where student folders will be created:"
            dlg.ShowNewFolderButton = True

            If Not String.IsNullOrEmpty(txtFolderPath.Text) AndAlso Directory.Exists(txtFolderPath.Text) Then
                dlg.SelectedPath = txtFolderPath.Text
            End If

            If dlg.ShowDialog(Me) = DialogResult.OK Then
                txtFolderPath.Text = dlg.SelectedPath
            End If
        End Using
    End Sub

    Private Sub btnCreateFolders_Click(sender As Object, e As EventArgs) Handles btnCreateFolders.Click
        Dim sc As SchoolClass = TryCast(cboClass.SelectedItem, SchoolClass)
        If sc Is Nothing OrElse sc.Students.Count = 0 Then
            SetStatus("Please select a class with students.", True)
            Return
        End If

        If String.IsNullOrEmpty(txtFolderPath.Text) Then
            SetStatus("Please select a parent folder first.", True)
            Return
        End If

        Dim parent As String = txtFolderPath.Text
        Dim format As NameFormat = GetSelectedFormat()
        Dim created As Integer = 0

        For Each s As Student In sc.Students
            Dim folderName As String
            If format = NameFormat.FirstLast Then
                folderName = String.Format("{0} {1}", s.FirstName, s.LastName)
            Else
                folderName = String.Format("{0} {1}", s.LastName, s.FirstName)
            End If

            Dim fullPath As String = Path.Combine(parent, folderName)
            If Not Directory.Exists(fullPath) Then
                Directory.CreateDirectory(fullPath)
                created += 1
            End If
        Next

        Dim skipped As Integer = sc.Students.Count - created
        SetStatus(String.Format("Done - {0} folder(s) created, {1} already existed.", created, skipped))
    End Sub

    Private Sub btnManageData_Click(sender As Object, e As EventArgs) Handles btnManageData.Click
        Using frm As New frmManage(_appData, _dataManager)
            frm.ShowDialog(Me)
        End Using

        LoadData()
        SetStatus("Data reloaded.")
    End Sub
End Class
