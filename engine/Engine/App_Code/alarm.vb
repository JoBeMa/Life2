'Database Access Funtions Copyright (C) 2013 Alcatel·Lucent 
'This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. 
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
'You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
Imports Microsoft.VisualBasic
Imports System.Diagnostics
Imports System
Imports System.Net
Imports System.Net.Mail

Public Class Alarm
    Inherits ALUInterface

#Region "    Events"

    Event SendTrace As SendTraceEventHandler

    Protected Overrides Sub OnSendTrace(ByVal e As TraceInformationEventArgs)
        RaiseEvent SendTrace(Me, e)
    End Sub

    Protected Overrides Sub OnSendAlarm(ByVal e As AlarmInformationEventArgs)
        '' Not implemented in this class
    End Sub

#End Region

    Private Sub writeTrace(ByVal traceLevel As Byte, ByVal message As String, ByVal functionName As String)
        OnSendTrace(New TraceInformationEventArgs(traceLevel, message, functionName))
    End Sub

    Public Sub SendAlarm(ByVal alarmInformation As AlarmInformationEventArgs, ByVal source As String)
        Const sIdm As String = "Alarm.SendAlarm"

        Try
            writeTrace(2, "Init", sIdm)

            Dim ev As New EventLog("Application", System.Environment.MachineName, source)
            ev.WriteEntry(alarmInformation.ErrorCause, System.Diagnostics.EventLogEntryType.Error, alarmInformation.EventValue)
            sendEmail(alarmInformation.ErrorCause)
            ev.Close()
        Catch ex As Exception
            writeTrace(1, "There has been an error: " & ex.Message, sIdm)
        Finally
            writeTrace(2, "End", sIdm)
        End Try
    End Sub

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' sendEmail: Enviar correo por SMTP
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    ''' 12-05-2011  Creación
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Sub sendEmail(ByVal sMessage As String)

        Dim strCC(), sToList, sSubject, sCcList, sFrom As String
        Dim message As MailMessage

        Const sIdm As String = "Alarm.sendEmail"

        Try
            sToList = Config.GetConfigVal("Email", "toList")
            sCcList = Config.GetConfigVal("Email", "ccList")
            sFrom = Config.GetConfigVal("Email", "From")
            sSubject = Config.GetConfigVal("Email", "Subject")

            message = New MailMessage(sFrom, sToList, sSubject, sMessage)

            If Trim(sCcList) <> "" Then
                strCC = Split(sCcList, ",")
                Dim strThisCC As String
                If strCC.Length > 0 Then
                    For Each strThisCC In strCC
                        message.CC.Add(Trim(strThisCC))
                    Next
                End If
            End If
            message.IsBodyHtml = True

            Dim _SMTP As New SmtpClient
            _SMTP.Credentials = _
                 New System.Net.NetworkCredential(Config.GetConfigVal("Email", "SmtpUser"), _
                                                  Config.GetConfigVal("Email", "SmtpPassword"))
            _SMTP.Host = Config.GetConfigVal("Email", "SmtpServer")
            _SMTP.Port = CInt(Config.GetConfigVal("Email", "SmtpPort"))
            _SMTP.EnableSsl = CBool(Config.GetConfigVal("Email", "SmtpSsl"))

            _SMTP.Send(message)


        Catch ex As FormatException

            writeTrace(1, "Format Exception: " & ex.Message, sIdm)

        Catch ex As SmtpException

            writeTrace(1, "SMTP Exception:  " & ex.Message, sIdm)

        Catch ex As Exception
            writeTrace(1, "ERROR in " & sIdm & ": " & ex.Message, sIdm)
        End Try

    End Sub


End Class

Public Class AlarmInformationEventArgs
    Inherits System.EventArgs

#Region "        Private members"

    Private m_eventValue As Integer

    Private m_errorCause As String

#End Region

#Region "        Properties"

    Public ReadOnly Property EventValue() As Integer
        Get
            Return m_eventValue
        End Get
    End Property

    Public ReadOnly Property ErrorCause() As String
        Get
            Return m_errorCause
        End Get
    End Property

#End Region

    Public Sub New(ByVal eventValue As Integer, ByVal errorCause As String)

        m_eventValue = eventValue
        m_errorCause = ErrorCause
    End Sub

End Class
