''' &lt;summary&gt;
''' Represents a class (named SchoolClass to avoid collision with VB.NET reserved keyword).
''' Contains a unique identifier, display name, and ordered list of enrolled students.
''' &lt;/summary&gt;
Public Class SchoolClass
    ''' &lt;summary&gt;
    ''' Gets or sets the unique GUID identifier for this class.
    ''' &lt;/summary&gt;
    Public Property Id As String

    ''' &lt;summary&gt;
    ''' Gets or sets the display name of the class, e.g., "T-Level Digital Y1".
    ''' &lt;/summary&gt;
    Public Property Name As String

    ''' &lt;summary&gt;
    ''' Gets or sets the ordered list of students enrolled in this class.
    ''' &lt;/summary&gt;
    Public Property Students As List(Of Student)

    ''' &lt;summary&gt;
    ''' Initializes a new instance of the SchoolClass with an empty student list.
    ''' &lt;/summary&gt;
    Public Sub New()
        Students = New List(Of Student)()
    End Sub

    ''' &lt;summary&gt;
    ''' Returns the class name for use in dropdowns.
    ''' &lt;/summary&gt;
    ''' &lt;returns&gt;The Name property value.&lt;/returns&gt;
    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class
