''' &lt;summary&gt;
''' Root data container that holds all classes and is serialized directly to/from students.json.
''' &lt;/summary&gt;
Public Class AppData
    ''' &lt;summary&gt;
    ''' Gets or sets the list of all school classes.
    ''' &lt;/summary&gt;
    Public Property Classes As List(Of SchoolClass)

    ''' &lt;summary&gt;
    ''' Initializes a new instance of AppData with an empty class list.
    ''' &lt;/summary&gt;
    Public Sub New()
        Classes = New List(Of SchoolClass)()
    End Sub
End Class
