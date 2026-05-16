''' &lt;summary&gt;
''' Application entry point module.
''' &lt;/summary&gt;
Module Program
    ''' &lt;summary&gt;
    ''' The main entry point for the application.
    ''' &lt;/summary&gt;
    &lt;STAThread&gt;
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New frmMain())
    End Sub
End Module
