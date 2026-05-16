''' &lt;summary&gt;
''' Represents a student with unique identifier and name properties.
''' &lt;/summary&gt;
Public Class Student
    ''' &lt;summary&gt;
    ''' Gets or sets the unique GUID identifier for this student.
    ''' Set on creation and never changed.
    ''' &lt;/summary&gt;
    Public Property Id As String

    ''' &lt;summary&gt;
    ''' Gets or sets the student's given name.
    ''' &lt;/summary&gt;
    Public Property FirstName As String

    ''' &lt;summary&gt;
    ''' Gets or sets the student's family name.
    ''' &lt;/summary&gt;
    Public Property LastName As String

    ''' &lt;summary&gt;
    ''' Returns a string representation of the student for use in dropdowns.
    ''' &lt;/summary&gt;
    ''' &lt;returns&gt;Student's full name in "FirstName LastName" format.&lt;/returns&gt;
    Public Overrides Function ToString() As String
        Return $"{FirstName} {LastName}"
    End Function
End Class
