''' &lt;summary&gt;
''' Defines the output format for student names in clipboard operations and folder naming.
''' &lt;/summary&gt;
''' &lt;remarks&gt;
''' - FirstLast: outputs as "John Smith" / one name per line when copying all
''' - LastFirst: outputs as "Smith, John" / "Smith[TAB]John" per line (two Excel columns)
''' &lt;/remarks&gt;
Public Enum NameFormat
    ''' &lt;summary&gt;
    ''' First name followed by last name, e.g., "John Smith".
    ''' &lt;/summary&gt;
    FirstLast = 0

    ''' &lt;summary&gt;
    ''' Last name followed by first name with comma separator, e.g., "Smith, John".
    ''' When copying all names, uses tab separator for Excel columns.
    ''' &lt;/summary&gt;
    LastFirst = 1
End Enum
