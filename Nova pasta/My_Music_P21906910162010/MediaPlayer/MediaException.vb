Imports System
Imports System.Runtime.Serialization
Imports System.Security.Permissions

''' <summary>
''' The exception that is thrown when an error occurs while opening, playing or modifying a media file.
''' </summary>
<Serializable()> _
Public Class MediaException
    Inherits Exception
    Implements ISerializable

    Public Sub New(ByVal message As String, ByVal innerException As Exception)
        MyBase.New(message & ": " & innerException.ToString)
    End Sub

    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New(info, context)
    End Sub

    ''' <summary>Constructs a new MediaException object.</summary>
    ''' <param name="Message">Specifies the error message.</param>
    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    ''' <summary>Constructs a new MediaException object.</summary>
    ''' <remarks>The message will be set to <em>'An error occured while accessing the media file.'</em></remarks>
    Public Sub New()
        MyBase.New("An error occured while accessing the media file.")
    End Sub

    ''' <summary>Returns a string representation of this object.</summary>	
    ''' <returns>A string representation of this MediaException.</returns>
    Public Overrides Function ToString() As String
        Return "MediaException: " & Message & " " & StackTrace
    End Function

End Class
