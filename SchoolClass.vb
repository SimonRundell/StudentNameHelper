''' <summary>
''' Represents a class (named SchoolClass to avoid collision with VB.NET reserved keyword).
''' Contains a unique identifier, display name, and ordered list of enrolled students.
''' </summary>
Public Class SchoolClass
    ''' <summary>
    ''' Gets or sets the unique GUID identifier for this class.
    ''' </summary>
    Public Property Id As String

    ''' <summary>
    ''' Gets or sets the display name of the class, e.g., "T-Level Digital Y1".
    ''' </summary>
    Public Property Name As String

    ''' <summary>
    ''' Gets or sets the ordered list of students enrolled in this class.
    ''' </summary>
    Public Property Students As List(Of Student)

    ''' <summary>
    ''' Initializes a new instance of the SchoolClass with an empty student list.
    ''' </summary>
    Public Sub New()
        Students = New List(Of Student)()
    End Sub

    ''' <summary>
    ''' Returns the class name for use in dropdowns.
    ''' </summary>
    ''' <returns>The Name property value.</returns>
    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class
