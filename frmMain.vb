Imports System.IO
Imports System.Text

Public Class frmMain
    Inherits Form

    Private cboClass As ComboBox
    Private cboStudent As ComboBox
    Private rbFirstLast As RadioButton
    Private rbLastFirst As RadioButton
    Private btnCopyStudent As Button
    Private btnCopyAllNames As Button
    Private txtFolderPath As TextBox
    Private btnBrowseFolder As Button
    Private btnCreateFolders As Button
    Private btnManageData As Button
    Private lblStatus As Label
    Private tipMain As ToolTip
    Private _dataManager As DataManager
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
        Me.Text = "Student Name Helper"
        Me.ClientSize = New Size(480, 400)
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular)

        tipMain = New ToolTip()

        Dim grpSelect As New GroupBox()
        grpSelect.Text = "Select Class & Student"
        grpSelect.Location = New Point(10, 10)
        grpSelect.Size = New Size(460, 210)

        Dim lblClass As New Label()
        lblClass.Text = "Class:"
        lblClass.Location = New Point(8, 28)
        lblClass.Size = New Size(60, 20)
        lblClass.TextAlign = ContentAlignment.MiddleRight

        cboClass = New ComboBox()
        cboClass.Location = New Point(72, 25)
        cboClass.Size = New Size(376, 24)
        cboClass.DropDownStyle = ComboBoxStyle.DropDownList

        Dim lblStudent As New Label()
        lblStudent.Text = "Student:"
        lblStudent.Location = New Point(8, 62)
        lblStudent.Size = New Size(60, 20)
        lblStudent.TextAlign = ContentAlignment.MiddleRight

        cboStudent = New ComboBox()
        cboStudent.Location = New Point(72, 59)
        cboStudent.Size = New Size(376, 24)
        cboStudent.DropDownStyle = ComboBoxStyle.DropDownList

        Dim lblFormat As New Label()
        lblFormat.Text = "Format:"
        lblFormat.Location = New Point(8, 98)
        lblFormat.Size = New Size(60, 20)
        lblFormat.TextAlign = ContentAlignment.MiddleRight

        rbFirstLast = New RadioButton()
        rbFirstLast.Text = "First Last"
        rbFirstLast.Location = New Point(72, 96)
        rbFirstLast.Size = New Size(90, 22)
        rbFirstLast.Checked = True

        rbLastFirst = New RadioButton()
        rbLastFirst.Text = "Last, First"
        rbLastFirst.Location = New Point(168, 96)
        rbLastFirst.Size = New Size(95, 22)

        Dim lblHint As New Label()
        lblHint.Text = "Copy All: 'First Last' - one name per line  |  'Last, First' - Last[TAB]First (two Excel columns)"
        lblHint.Location = New Point(72, 122)
        lblHint.Size = New Size(378, 16)
        lblHint.ForeColor = Color.Gray
        lblHint.Font = New Font("Segoe UI", 8.0F, FontStyle.Italic)

        btnCopyStudent = New Button()
        btnCopyStudent.Text = "Copy Student Name"
        btnCopyStudent.Location = New Point(72, 148)
        btnCopyStudent.Size = New Size(158, 32)

        btnCopyAllNames = New Button()
        btnCopyAllNames.Text = "Copy All Names"
        btnCopyAllNames.Location = New Point(240, 148)
        btnCopyAllNames.Size = New Size(148, 32)

        grpSelect.Controls.Add(lblClass)
        grpSelect.Controls.Add(cboClass)
        grpSelect.Controls.Add(lblStudent)
        grpSelect.Controls.Add(cboStudent)
        grpSelect.Controls.Add(lblFormat)
        grpSelect.Controls.Add(rbFirstLast)
        grpSelect.Controls.Add(rbLastFirst)
        grpSelect.Controls.Add(lblHint)
        grpSelect.Controls.Add(btnCopyStudent)
        grpSelect.Controls.Add(btnCopyAllNames)

        Dim grpFolders As New GroupBox()
        grpFolders.Text = "Create Student Folders"
        grpFolders.Location = New Point(10, 230)
        grpFolders.Size = New Size(460, 108)

        Dim lblFolder As New Label()
        lblFolder.Text = "Parent folder:"
        lblFolder.Location = New Point(8, 28)
        lblFolder.Size = New Size(82, 20)
        lblFolder.TextAlign = ContentAlignment.MiddleRight

        txtFolderPath = New TextBox()
        txtFolderPath.Location = New Point(94, 25)
        txtFolderPath.Size = New Size(270, 24)
        txtFolderPath.ReadOnly = True

        btnBrowseFolder = New Button()
        btnBrowseFolder.Text = "Browse..."
        btnBrowseFolder.Location = New Point(372, 24)
        btnBrowseFolder.Size = New Size(78, 26)

        btnCreateFolders = New Button()
        btnCreateFolders.Text = "Create Folders"
        btnCreateFolders.Location = New Point(94, 62)
        btnCreateFolders.Size = New Size(148, 30)

        grpFolders.Controls.Add(lblFolder)
        grpFolders.Controls.Add(txtFolderPath)
        grpFolders.Controls.Add(btnBrowseFolder)
        grpFolders.Controls.Add(btnCreateFolders)

        btnManageData = New Button()
        btnManageData.Text = "Manage Classes & Students..."
        btnManageData.Location = New Point(10, 350)
        btnManageData.Size = New Size(230, 32)

        lblStatus = New Label()
        lblStatus.Text = "Ready."
        lblStatus.Location = New Point(10, 380)
        lblStatus.Size = New Size(460, 18)
        lblStatus.ForeColor = Color.DimGray

        Me.Controls.Add(grpSelect)
        Me.Controls.Add(grpFolders)
        Me.Controls.Add(btnManageData)
        Me.Controls.Add(lblStatus)

        tipMain.SetToolTip(btnCopyStudent, "Copies the selected student's name in the chosen format." & vbCrLf & "First Last: ""John Smith""  |  Last, First: ""Smith, John""")
        tipMain.SetToolTip(btnCopyAllNames, "Copies every student in the selected class." & vbCrLf & "First Last: one name per line (single Excel column)." & vbCrLf & "Last, First: Last[TAB]First per line (two Excel columns).")
        tipMain.SetToolTip(btnCreateFolders, "Creates one subfolder per student inside the chosen parent folder." & vbCrLf & "First Last: folder named ""John Smith""." & vbCrLf & "Last, First: folder named ""Smith John""." & vbCrLf & "Existing folders are silently skipped.")

        AddHandler cboClass.SelectedIndexChanged, AddressOf cboClass_SelectedIndexChanged
        AddHandler btnCopyStudent.Click, AddressOf btnCopyStudent_Click
        AddHandler btnCopyAllNames.Click, AddressOf btnCopyAllNames_Click
        AddHandler btnBrowseFolder.Click, AddressOf btnBrowseFolder_Click
        AddHandler btnCreateFolders.Click, AddressOf btnCreateFolders_Click
        AddHandler btnManageData.Click, AddressOf btnManageData_Click
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

    Private Sub cboClass_SelectedIndexChanged(sender As Object, e As EventArgs)
        PopulateStudentDropdown()
    End Sub

    Private Sub btnCopyStudent_Click(sender As Object, e As EventArgs)
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

    Private Sub btnCopyAllNames_Click(sender As Object, e As EventArgs)
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

    Private Sub btnBrowseFolder_Click(sender As Object, e As EventArgs)
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

    Private Sub btnCreateFolders_Click(sender As Object, e As EventArgs)
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

    Private Sub btnManageData_Click(sender As Object, e As EventArgs)
        Using frm As New frmManage(_appData, _dataManager)
            frm.ShowDialog(Me)
        End Using

        LoadData()
        SetStatus("Data reloaded.")
    End Sub
End Class
