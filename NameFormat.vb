''' <summary>
''' Defines the output format for student names in clipboard operations and folder naming.
''' </summary>
''' <remarks>
''' - FirstLast: outputs as "John Smith" / one name per line when copying all
''' - LastFirst: outputs as "Smith, John" / "Smith[TAB]First" per line (two Excel columns)
''' </remarks>
Public Enum NameFormat
    ''' <summary>
    ''' First name followed by last name, e.g., "John Smith.
    ''' </summary>
    FirstLast = 0

    ''' <summary>
    ''' Last name followed by first name with comma separator, e.g., "Smith, John".
    ''' When copying all names, uses tab separator for Excel columns.
    ''' </summary>
    LastFirst = 1
End Enum