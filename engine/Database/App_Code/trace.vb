'Database Access Funtions Copyright (C) 2013 Alcatel·Lucent 
'This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. 
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
'You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Diagnostics
Imports System

Public Class Trace

#Region "    Private members"

    Private m_traceFile As String

    Private m_traceLevel As Byte

    Private m_bufferTraces(-1) As String

    Private m_bufferTraceSize As Integer = 0

#End Region

#Region "    Properties"

    Public Property TraceFile() As String
        Get
            Return m_traceFile
        End Get
        Set(ByVal value As String)
            m_traceFile = value
        End Set
    End Property

    Public Property TraceLevel() As Integer
        Get
            Return m_traceLevel
        End Get
        Set(ByVal value As Integer)
            m_traceLevel = value
        End Set
    End Property

#End Region

#Region "    Public functions"

    Public Sub Write(ByVal traceInformation As TraceInformationEventArgs)
        Dim dateTimeNow As DateTime = Now
        Const sIdm As String = "trace.Write"

        Try
            Dim traceLine As New StringBuilder()
            '' Preparamos la linea que queremos escribir
            traceLine.AppendLine()
            traceLine.AppendLine()
            traceLine.Append("Time: ")
            traceLine.Append(dateTimeNow.ToString("dd/MM/yyyy HH:mm:ss,dd "))
            traceLine.Append(traceInformation.FunctionName)
            traceLine.Append(" > ")
            traceLine.Append(traceInformation.TraceLevel.ToString)
            traceLine.AppendLine()
            traceLine.Append(traceInformation.Message)

            Dim traceText As String = traceLine.ToString

            '+----------------------------------------+
            '| Escribir en las trazas propias de .NET |
            '+----------------------------------------+
            Dim alt As New altTrace
            alt.WriteTrace(traceText)
 
            '' Si indicamos que queremos guardar el buffer de trazas...
            If m_bufferTraceSize > 0 Then
                If m_bufferTraces.Length = m_bufferTraceSize Then
                    For index As Integer = 0 To m_bufferTraces.Length - 2
                        m_bufferTraces(index) = m_bufferTraces(index + 1)
                    Next
                Else
                    ReDim Preserve m_bufferTraces(m_bufferTraces.Length)
                End If
                m_bufferTraces(m_bufferTraces.Length - 1) = traceText
            End If

            If traceInformation.TraceLevel <= m_traceLevel Then
                '' Preparamos el nombre del fichero de copia del fichero de trazas actual
                Dim newFile As String = _
                    My.Request.MapPath(Config.GetConfigVal("files", "logPath") & "/" & _
                    My.Request.AppRelativeCurrentExecutionFilePath.Substring(2) & dateTimeNow.ToString("ddMMyyyyHHmmss") & _
                    Config.GetConfigVal("files", "tracefile"))

                '' Abrir el streamWriter, en caso de no existir el fichero 
                Dim outputStreamWriter As StreamWriter = File.AppendText(m_traceFile)

                '' Miramos la longitud en bytes de lo que queremos escribir
                Dim sizeBufferInBytes As Integer = traceText.Length
                If m_traceLevel = 1 Then
                    sizeBufferInBytes = 0
                    For Each line As String In m_bufferTraces
                        sizeBufferInBytes += line.Length
                    Next
                End If

                '' Hacemos la copia del fichero si ya sobrepasamos la medida máximo de fichero
                Dim maxLogFileSize As Integer = CInt(Config.GetConfigVal("misc", "maxLogSize"))
                If (My.Computer.FileSystem.GetFileInfo(m_traceFile).Length + sizeBufferInBytes > maxLogFileSize) Then

                    outputStreamWriter.Close()
                    'My.Computer.FileSystem.CopyFile(m_traceFile, newFile)  Para no saturar el disco no hacemos copia de lo anterior
                    My.Computer.FileSystem.DeleteFile(m_traceFile)
                    outputStreamWriter = File.AppendText(m_traceFile)
                End If

                '' Si el nivel de trazas es 1, debemos copiar el buffer
                If m_traceLevel = 1 Then
                    For index As Integer = 0 To m_bufferTraces.Length - 2
                        outputStreamWriter.Write(m_bufferTraces(index))
                    Next
                    ReDim Preserve m_bufferTraces(-1)
                End If

                '' Escribir en el fichero de trazas 
                traceText = traceLine.ToString
                outputStreamWriter.Write(traceText)
                outputStreamWriter.Flush()
                outputStreamWriter.Close()
            End If
        Catch ex As Exception
            Try
                Dim sErrorFile As String
                sErrorFile = My.Request.MapPath(Config.GetConfigVal("files", "logPath") & "/" & _
                    My.Request.AppRelativeCurrentExecutionFilePath.Substring(2) & "Error.txt")
                My.Computer.FileSystem.WriteAllText(sErrorFile, dateTimeNow.ToString("dd/MM/yyyy-HH:mm:ss") & "ERROR in " & sIdm & ": " & _
                    ex.Message & ControlChars.Lf, True)
            Catch ex1 As Exception

            End Try
        End Try
    End Sub

#End Region

End Class

Public Class TraceInformationEventArgs
    Inherits System.EventArgs

#Region "        Private members"

    Private m_logTime As DateTime = DateTime.Now

    Private m_message As String

    Private m_traceLevel As Byte

    Private m_functionName As String

#End Region

#Region "        Properties"

    Public ReadOnly Property Message() As String
        Get
            Return m_message
        End Get
    End Property

    Public ReadOnly Property TraceLevel() As Byte
        Get
            Return m_traceLevel
        End Get
    End Property

    Public ReadOnly Property FunctionName() As String
        Get
            Return m_functionName
        End Get
    End Property

#End Region

    Public Sub New(ByVal traceLevel As Byte, ByVal message As String, ByVal functionName As String)

        m_traceLevel = traceLevel
        m_message = message
        m_functionName = functionName
    End Sub

End Class
