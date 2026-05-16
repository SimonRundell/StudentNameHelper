Imports System.IO

Public Class frmManage
    Inherits Form

    Private lstClasses As ListBox
    Private txtClassName As TextBox
    Private btnAddClass As Button
    Private btnRemoveClass As Button
    Private lstStudents As ListBox
    Private lblStudentCount As Label
    Private txtFirstName As TextBox
    Private txtLastName As TextBox
    Private btnAddStudent As Button
    Private btnRemoveStudent As Button
    Private btnSaveClose As Button

    Private _appData As AppData
    Private _dataManager As DataManager

    Public Sub New(appData As AppData, dataManager As DataManager)
        _appData = appData
        _dataManager = dataManager
        InitializeComponent()
        PopulateClassList()
    End Sub

    Private Sub InitializeComponent()
        Me.Text = "Manage Classes & Students"
        Me.ClientSize = New Size(610, 435)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Font = New Font("Trebuchet MS", 9.0F, FontStyle.Regular)

        Dim grpClasses As New GroupBox()
        grpClasses.Text = "Classes"
        grpClasses.Location = New Point(10, 10)
        grpClasses.Size = New Size(240, 375)

        lstClasses = New ListBox()
        lstClasses.Location = New Point(10, 22)
        lstClasses.Size = New Size(220, 210)
        lstClasses.ScrollAlwaysVisible = True

        Dim lblNewClass As New Label()
        lblNewClass.Text = "New class name:"
        lblNewClass.Location = New Point(10, 244)
        lblNewClass.Size = New Size(220, 18)

        txtClassName = New TextBox()
        txtClassName.Location = New Point(10, 264)
        txtClassName.Size = New Size(220, 24)
        txtClassName.MaxLength = 100

        btnAddClass = New Button()
        btnAddClass.Text = "Add Class"
        btnAddClass.Location = New Point(10, 298)
        btnAddClass.Size = New Size(105, 28)

        btnRemoveClass = New Button()
        btnRemoveClass.Text = "Remove Class"
        btnRemoveClass.Location = New Point(122, 298)
        btnRemoveClass.Size = New Size(108, 28)

        grpClasses.Controls.Add(lstClasses)
        grpClasses.Controls.Add(lblNewClass)
        grpClasses.Controls.Add(txtClassName)
        grpClasses.Controls.Add(btnAddClass)
        grpClasses.Controls.Add(btnRemoveClass)

        Dim grpStudents As New GroupBox()
        grpStudents.Text = "Students in Selected Class"
        grpStudents.Location = New Point(262, 10)
        grpStudents.Size = New Size(338, 375)

        lstStudents = New ListBox()
        lstStudents.Location = New Point(10, 22)
        lstStudents.Size = New Size(318, 200)
        lstStudents.ScrollAlwaysVisible = True

        lblStudentCount = New Label()
        lblStudentCount.Text = "0 students"
        lblStudentCount.Location = New Point(10, 228)
        lblStudentCount.Size = New Size(318, 16)
        lblStudentCount.ForeColor = Color.Gray
        lblStudentCount.Font = New Font("Trebuchet MS", 7.5F, FontStyle.Italic)

        Dim lblFirst As New Label()
        lblFirst.Text = "First name:"
        lblFirst.Location = New Point(10, 252)
        lblFirst.Size = New Size(155, 18)

        Dim lblLast As New Label()
        lblLast.Text = "Last name:"
        lblLast.Location = New Point(172, 252)
        lblLast.Size = New Size(158, 18)

        txtFirstName = New TextBox()
        txtFirstName.Location = New Point(10, 272)
        txtFirstName.Size = New Size(155, 24)
        txtFirstName.MaxLength = 80

        txtLastName = New TextBox()
        txtLastName.Location = New Point(172, 272)
        txtLastName.Size = New Size(158, 24)
        txtLastName.MaxLength = 80

        btnAddStudent = New Button()
        btnAddStudent.Text = "Add Student"
        btnAddStudent.Location = New Point(10, 308)
        btnAddStudent.Size = New Size(130, 28)

        btnRemoveStudent = New Button()
        btnRemoveStudent.Text = "Remove Student"
        btnRemoveStudent.Location = New Point(150, 308)
        btnRemoveStudent.Size = New Size(140, 28)

        grpStudents.Controls.Add(lstStudents)
        grpStudents.Controls.Add(lblStudentCount)
        grpStudents.Controls.Add(lblFirst)
        grpStudents.Controls.Add(lblLast)
        grpStudents.Controls.Add(txtFirstName)
        grpStudents.Controls.Add(txtLastName)
        grpStudents.Controls.Add(btnAddStudent)
        grpStudents.Controls.Add(btnRemoveStudent)

        btnSaveClose = New Button()
        btnSaveClose.Text = "Save & Close"
        btnSaveClose.Location = New Point(10, 397)
        btnSaveClose.Size = New Size(140, 30)

        Dim btnDiscard As New Button()
        btnDiscard.Text = "Discard & Close"
        btnDiscard.Location = New Point(158, 397)
        btnDiscard.Size = New Size(148, 30)
        btnDiscard.DialogResult = DialogResult.Cancel

        Me.Controls.Add(grpClasses)
        Me.Controls.Add(grpStudents)
        Me.Controls.Add(btnSaveClose)
        Me.Controls.Add(btnDiscard)

        AddHandler lstClasses.SelectedIndexChanged, AddressOf lstClasses_SelectedIndexChanged
        AddHandler btnAddClass.Click, AddressOf btnAddClass_Click
        AddHandler btnRemoveClass.Click, AddressOf btnRemoveClass_Click
        AddHandler btnAddStudent.Click, AddressOf btnAddStudent_Click
        AddHandler btnRemoveStudent.Click, AddressOf btnRemoveStudent_Click
        AddHandler btnSaveClose.Click, AddressOf btnSaveClose_Click
        AddHandler txtClassName.KeyDown, AddressOf txtClassName_KeyDown
        AddHandler txtFirstName.KeyDown, AddressOf txtName_KeyDown
        AddHandler txtLastName.KeyDown, AddressOf txtName_KeyDown
    End Sub

    Private Sub PopulateClassList()
        lstClasses.Items.Clear()

        For Each sc As SchoolClass In _appData.Classes
            lstClasses.Items.Add(sc)
        Next

        lstStudents.Items.Clear()
        UpdateStudentCount(0)
    End Sub

    Private Sub PopulateStudentList()
        lstStudents.Items.Clear()

        Dim sc As SchoolClass = SelectedClass()
        If sc IsNot Nothing Then
            For Each student As Student In sc.Students
                lstStudents.Items.Add(student)
            Next
        End If

        UpdateStudentCount(lstStudents.Items.Count)
    End Sub

    Private Function SelectedClass() As SchoolClass
        Return TryCast(lstClasses.SelectedItem, SchoolClass)
    End Function

    Private Sub UpdateStudentCount(count As Integer)
        lblStudentCount.Text = String.Format("{0} student{1}", count, If(count = 1, "", "s"))
    End Sub

    Private Sub lstClasses_SelectedIndexChanged(sender As Object, e As EventArgs)
        PopulateStudentList()
    End Sub

    Private Sub txtClassName_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            btnAddClass_Click(sender, EventArgs.Empty)
        End If
    End Sub

    Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            btnAddStudent_Click(sender, EventArgs.Empty)
        End If
    End Sub

    Private Sub btnAddClass_Click(sender As Object, e As EventArgs)
        Dim className As String = txtClassName.Text.Trim()
        If String.IsNullOrEmpty(className) Then
            MessageBox.Show("Please enter a class name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtClassName.Focus()
            Return
        End If

        Dim newClass As New SchoolClass()
        newClass.Id = Guid.NewGuid().ToString()
        newClass.Name = className
        newClass.Students = New List(Of Student)()

        _appData.Classes.Add(newClass)
        lstClasses.Items.Add(newClass)

        txtClassName.Clear()
        lstClasses.SelectedItem = newClass
        txtClassName.Focus()
    End Sub

    Private Sub btnRemoveClass_Click(sender As Object, e As EventArgs)
        Dim sc As SchoolClass = SelectedClass()
        If sc Is Nothing Then
            Return
        End If

        Dim msg As String = String.Format("Remove class '{0}' and all {1} student(s)?{2}This cannot be undone after saving.", sc.Name, sc.Students.Count, vbCrLf)
        Dim result As DialogResult = MessageBox.Show(msg, "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            _appData.Classes.Remove(sc)
            lstClasses.Items.Remove(sc)
            lstStudents.Items.Clear()
            UpdateStudentCount(0)
        End If
    End Sub

    Private Sub btnAddStudent_Click(sender As Object, e As EventArgs)
        Dim sc As SchoolClass = SelectedClass()
        If sc Is Nothing Then
            MessageBox.Show("Please select a class first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim firstName As String = txtFirstName.Text.Trim()
        Dim lastName As String = txtLastName.Text.Trim()

        If String.IsNullOrEmpty(firstName) OrElse String.IsNullOrEmpty(lastName) Then
            MessageBox.Show("Please enter both first and last name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFirstName.Focus()
            Return
        End If

        Dim newStudent As New Student()
        newStudent.Id = Guid.NewGuid().ToString()
        newStudent.FirstName = firstName
        newStudent.LastName = lastName

        sc.Students.Add(newStudent)
        lstStudents.Items.Add(newStudent)
        UpdateStudentCount(lstStudents.Items.Count)

        txtFirstName.Clear()
        txtLastName.Clear()
        txtFirstName.Focus()
    End Sub

    Private Sub btnRemoveStudent_Click(sender As Object, e As EventArgs)
        Dim sc As SchoolClass = SelectedClass()
        Dim student As Student = TryCast(lstStudents.SelectedItem, Student)

        If sc Is Nothing OrElse student Is Nothing Then
            Return
        End If

        sc.Students.Remove(student)
        lstStudents.Items.Remove(student)
        UpdateStudentCount(lstStudents.Items.Count)
    End Sub

    Private Sub btnSaveClose_Click(sender As Object, e As EventArgs)
        _dataManager.Save(_appData)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class
