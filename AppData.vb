''' <summary>
''' Root data container that holds all classes and is serialized directly to/from students.json.
''' </summary>
Public Class AppData
    ''' <summary>
    ''' Gets or sets the list of all school classes.
    ''' </summary>
    Public Property Classes As List(Of SchoolClass)

    ''' <summary>
    ''' Initializes a new instance of AppData with an empty class list.
    ''' </summary>
    Public Sub New()
        Classes = New List(Of SchoolClass)()
    End Sub
End Class
