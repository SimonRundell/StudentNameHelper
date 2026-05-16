''' <summary>
''' Represents a student with unique identifier and name properties.
''' </summary>
Public Class Student
    ''' <summary>
    ''' Gets or sets the unique GUID identifier for this student.
    ''' Set on creation and never changed.
    ''' </summary>
    Public Property Id As String

    ''' <summary>
    ''' Gets or sets the student's given name.
    ''' </summary>
    Public Property FirstName As String

    ''' <summary>
    ''' Gets or sets the student's family name.
    ''' </summary>
    Public Property LastName As String

    ''' <summary>
    ''' Returns a string representation of the student for use in dropdowns.
    ''' </summary>
    ''' <returns>Student's full name in "FirstName LastName" format.</returns>
    Public Overrides Function ToString() As String
        Return $"{FirstName} {LastName}"
    End Function
End Class
