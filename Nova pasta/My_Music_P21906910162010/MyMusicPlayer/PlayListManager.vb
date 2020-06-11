
Imports System.IO

Public Class PlaylistManager

#Region " Private Members "

    Private _SongTitle() As String
    Private _SongFile() As String
    Private _SongLength() As Long
    Private _FileName As String

#End Region

#Region " Constructor "

    Public Sub New(ByVal fileName As String)
        _FileName = fileName
    End Sub

#End Region

#Region " Public Properties "

    Public ReadOnly Property SongTitle(ByVal index As Integer) As String
        Get
            Return _SongTitle(index)
        End Get
    End Property

    Public ReadOnly Property SongLength(ByVal index As Integer) As String
        Get
            Return CStr(_SongLength(index))
        End Get
    End Property

    Public ReadOnly Property SongFile(ByVal index As Integer) As String
        Get
            Return _SongFile(index)
        End Get
    End Property

    Public ReadOnly Property Songs() As Integer
        Get
            Return UBound(_SongFile)
        End Get
    End Property

#End Region

#Region " Public Methods "

    Public Function Read() As Boolean
        Dim reader As StreamReader
        Dim line1 As String

        reader = File.OpenText(_FileName)
        ReDim Preserve _SongFile(0)

        line1 = reader.ReadLine()
        Select Case line1
            Case "#EXTM3U" 'm3u playlist, winamp
                Call ReadM3UFile(reader)
        End Select
        reader.Close()
    End Function

    Public Function SaveToM3U(ByVal fileName() As String, ByVal songName() As String, ByVal songLength() As Long) As Boolean
        Dim writer As StreamWriter, x As Integer

        writer = File.CreateText(_FileName)

        writer.WriteLine("#EXTM3U")
        For x = 1 To UBound(fileName)
            If songLength(x - 1) > 0 Then
                writer.WriteLine("#EXTINF:" & songLength(x - 1) & "," & songName(x - 1))
            End If
            writer.WriteLine(fileName(x - 1))
        Next

        writer.Close()
    End Function

    Private Sub ReadM3UFile(ByVal reader As StreamReader)
        Dim line1, line2 As String
        Dim getPosition As Integer, currentElement As Integer

        While reader.Peek <> -1
            line1 = reader.ReadLine()
            If Left(line1, 8) = "#EXTINF:" Then
                Try
                    currentElement = UBound(_SongFile)
                Catch ex As IndexOutOfRangeException
                    currentElement = 0
                End Try

                ReDim Preserve _SongFile(currentElement + 1)
                ReDim Preserve _SongTitle(currentElement + 1)
                ReDim Preserve _SongLength(currentElement + 1)
                getPosition = InStr(line1, ",")
                _SongLength(currentElement) = CLng(Mid(line1, 9, getPosition - 9))
                _SongTitle(currentElement) = Mid(line1, getPosition + 1)

                line2 = reader.ReadLine()
                _SongFile(currentElement) = line2
                'messagebox.Show(me.SongTitle(curElement) & " ## " & me.SongLength(curelement) & " ## " & me.SongFile(curElement))
            Else
                Try
                    currentElement = UBound(_SongFile)
                Catch ex As IndexOutOfRangeException
                    currentElement = 0
                End Try

                ReDim Preserve _SongFile(currentElement + 1)
                ReDim Preserve _SongTitle(currentElement + 1)
                ReDim Preserve _SongLength(currentElement + 1)
                _SongLength(currentElement) = 0
                _SongTitle(currentElement) = FilterFileName(line1)
                _SongFile(currentElement) = line1
            End If
        End While
    End Sub

    Public Function FilterFileName(ByVal filePath As String) As String
        Dim lastPosition, newPosition As Integer, filter As String
        lastPosition = InStr(filePath, "\")
        newPosition = lastPosition

        Do While lastPosition > 0
            newPosition = lastPosition
            lastPosition = InStr(newPosition + 1, filePath, "\")
        Loop
        filter = Mid(filePath, newPosition + 1)

        lastPosition = InStr(filter, ".")
        newPosition = lastPosition
        Do While lastPosition > 0
            newPosition = lastPosition
            lastPosition = InStr(newPosition + 1, filter, ".")
        Loop

        filter = Mid(filter, 1, newPosition - 1)
        Return filter
    End Function

#End Region

End Class

Public Class PlaylistData

#Region " Private Members "

    Private _FileName As String
    Private _Title As String
    Private _Length As Long

#End Region

#Region " Constructor "

    Public Sub New(ByVal fileName As String, ByVal title As String)
        _FileName = fileName
        _Title = title
    End Sub

    Public Sub New(ByVal fileName As String, ByVal title As String, ByVal songLength As Long)
        _FileName = fileName
        _Title = title
        _Length = songLength
    End Sub

#End Region

#Region " Public Properties "

    Public ReadOnly Property FileName() As String
        Get
            Return _FileName
        End Get
    End Property

    Public ReadOnly Property Title() As String
        Get
            Return _Title
        End Get
    End Property

    Public ReadOnly Property Length() As Long
        Get
            Return _Length
        End Get
    End Property

#End Region

#Region " Public Methods "

    Public Overrides Function ToString() As String
        Return _Title
    End Function

    Public Function ReturnFileName() As String
        Return _FileName
    End Function

    Public Function ReturnLength() As Long
        Return _Length
    End Function

#End Region

End Class
