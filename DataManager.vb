Imports System.IO
Imports System.Text
Imports System.Web.Script.Serialization

''' &lt;summary&gt;
''' Handles loading and saving application data to/from JSON file using JavaScriptSerializer.
''' &lt;/summary&gt;
Public Class DataManager
    ''' &lt;summary&gt;
    ''' The file path where application data is stored.
    ''' &lt;/summary&gt;
    Private ReadOnly _filePath As String

    ''' &lt;summary&gt;
    ''' The JSON serializer instance.
    ''' &lt;/summary&gt;
    Private ReadOnly _serializer As JavaScriptSerializer

    ''' &lt;summary&gt;
    ''' Initializes a new instance of DataManager.
    ''' &lt;/summary&gt;
    ''' &lt;param name="filePath"&gt;The path to the JSON data file.&lt;/param&gt;
    Public Sub New(filePath As String)
        _filePath = filePath
        _serializer = New JavaScriptSerializer()
    End Sub

    ''' &lt;summary&gt;
    ''' Loads application data from the JSON file.
    ''' &lt;/summary&gt;
    ''' &lt;returns&gt;The deserialized AppData object, or a new empty AppData if the file doesn't exist.&lt;/returns&gt;
    ''' &lt;remarks&gt;
    ''' Includes defensive null checks to guard against manual JSON edits.
    ''' If Classes is Nothing, initializes to empty list.
    ''' For each SchoolClass, if Students is Nothing, initializes to empty list.
    ''' &lt;/remarks&gt;
    Public Function Load() As AppData
        ' If file doesn't exist, return new empty AppData
        If Not File.Exists(_filePath) Then
            Return New AppData()
        End If

        ' Read JSON from file
        Dim json As String = File.ReadAllText(_filePath, Encoding.UTF8)

        ' Deserialize
        Dim data As AppData = _serializer.Deserialize(Of AppData)(json)

        ' Defensive null checks (guard against manual JSON edits)
        If data.Classes Is Nothing Then
            data.Classes = New List(Of SchoolClass)()
        End If

        For Each sc As SchoolClass In data.Classes
            If sc.Students Is Nothing Then
                sc.Students = New List(Of Student)()
            End If
        Next

        Return data
    End Function

    ''' &lt;summary&gt;
    ''' Saves application data to the JSON file.
    ''' &lt;/summary&gt;
    ''' &lt;param name="data"&gt;The AppData object to serialize and save.&lt;/param&gt;
    Public Sub Save(data As AppData)
        ' Serialize to JSON
        Dim json As String = _serializer.Serialize(data)

        ' Write to file, overwriting any existing content
        File.WriteAllText(_filePath, json, Encoding.UTF8)
    End Sub
End Class
