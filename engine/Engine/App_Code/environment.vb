'Database Access Funtions Copyright (C) 2013 Alcatel·Lucent 
'This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. 
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
'You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
Imports Microsoft.VisualBasic

Public Class Environment

#Region "    Constants"
    Public Const ALM_EXECUTION_ERROR As Integer = 1002
    Public Const ALM_SCRIPT_NOT_DEFINED As Integer = 1003
    Public Const ALM_ERROR_CONNECTING_SERVER As Integer = 1004
    Public Const ALM_NO_FILES_IN_SERVER As Integer = 1005
    Public Const ALM_ERROR_DOWNLOADING_FILES_FROM_SERVER As Integer = 1006
    Public Const ALM_CAN_NOT_CHECK_PROGRAM As Integer = 1007
    Public Const ALM_CAN_NOT_CHECK_PPV_PROGRAM As Integer = 1008
    Public Const ALM_WRONG_DATE_FORMAT As Integer = 1009

#End Region

#Region "    Private members"

    'Private WithEvents m_authentication As Authentication

    Private WithEvents m_language As Language

    Private WithEvents m_alarm As Alarm

    'Private WithEvents m_license As License

    Private WithEvents m_dataAccess As DataAccess

    'Private WithEvents m_msIPTVAccess As MSIPTVAccess

    Private m_trace As Trace

    Private m_source As String

    Private m_skinPath As String

    Private m_AppPath As String

    Private m_TaskID As Long


#End Region

#Region "    Public elements"

    Public Const VirtualChannelText As String = " - Virtual Channel: "

    Public Enum GRCType As Short
        Undefined
        GRCSet
        GRC
    End Enum

    Public Enum EventStatus As Short
        Undefined
        Scheduled
        Executing
        Complete
    End Enum

    Public Enum MenuAction
        None = 0
        Remove = 1
    End Enum

    Public Enum PopUpStyle
        OkOnly = 0
        YesNo = 4
    End Enum

#End Region

#Region "    Properties"

    'Public ReadOnly Property Authentication() As Authentication
    '    Get
    '        Return m_authentication
    '    End Get
    'End Property

    Public ReadOnly Property Source() As String
        Get
            Return m_source
        End Get
    End Property

    Public ReadOnly Property SkinPath() As String
        Get
            Return m_skinPath
        End Get
    End Property

    Public ReadOnly Property AppPath() As String
        Get
            Return m_AppPath
        End Get
    End Property

    Public ReadOnly Property TaskID() As Long
        Get
            Return m_TaskID
        End Get
    End Property



    Public ReadOnly Property DataAccess() As DataAccess
        Get
            Return m_dataAccess
        End Get
    End Property

    'Public ReadOnly Property MSIPTVAccess() As MSIPTVAccess
    '    Get
    '        Return m_msIPTVAccess
    '    End Get
    'End Property

#End Region

#Region "    Private/Protected functions"

    Private Sub create(ByVal source As String, ByVal checkAuthentication As Boolean, ByVal register As Boolean)
        Const sIdm As String = "Environment.createEnvironment"

        Try
            '' Create object Trace
            m_trace = New Trace
            m_trace.TraceLevel = IIf(IsNumeric(Config.GetConfigVal("files", "traceLevel")), CInt(Config.GetConfigVal("files", "traceLevel")), 0)
            If m_trace.TraceLevel > 0 Then
                m_trace.TraceFile = _
                    My.Request.MapPath(Config.GetConfigVal("files", "logPath") & "/" & _
                        My.Request.AppRelativeCurrentExecutionFilePath.Substring(2) & Config.GetConfigVal("files", "tracefile"))
            End If
            'WriteTrace(2, "Init", sIdm)

            'WriteTrace(3, "Licence validation", sIdm)
            'm_license = New License
            'If m_license.LicenseRight(register) Then
            '    ''If True Then
            'WriteTrace(3, "Initializing source information", sIdm)
            m_source = source

            '    m_skinPath = My.Request.MapPath(Config.GetConfigVal("files", "skinPath"))

            '    'If checkAuthentication Then
            '    '    m_authentication = New Authentication
            '    '    If Not m_authentication.Init Then
            '    '        WriteTrace(1, "There has been an error: Authentication not valid", sIdm)
            '    '        My.Response.Write("ERROR: Authentication not valid")
            '    '        My.Response.End()
            '    '    End If
            '    'End If

            '    'If m_authentication.CodeLanguage = String.Empty Then
            '    '    WriteTrace(3, "Loading default language", sIdm)
            '    '    m_authentication.CodeLanguage = Config.GetConfigVal("misc", "lang")
            '    'End If
            '    'WriteTrace(3, "Language: '" & m_authentication.CodeLanguage & "'", sIdm)

            'WriteTrace(3, "Loading language document", sIdm)
            'm_language = New Language
            'Dim documentLoaded As Boolean = m_language.LoadDocument(Config.GetConfigVal("misc", "lang"))
            'WriteTrace(3, "Result of loading language: " & documentLoaded.ToString, sIdm)

            'WriteTrace(3, "Alarm object creation", sIdm)
            m_alarm = New Alarm

            'WriteTrace(3, "DataAccess object creation", sIdm)
            m_dataAccess = New DataAccess()

            '    'm_dataAccess.DataXml = My.Request.MapPath(Config.GetConfigVal("files", "dataPath") & "/" & "blackout.xml")
            '    'm_dataAccess.DataSchema = My.Request.MapPath(Config.GetConfigVal("files", "dataPath") & "/" & "blackout.xsd")

            '    'WriteTrace(3, "msIPTVAccess object creation", sIdm)
            '    'm_msIPTVAccess = New MSIPTVAccess
            'Else
            'WriteTrace(1, "There has been an error: License not valid", sIdm)
            'My.Response.Write("ERROR: License not valid")
            'My.Response.End()
            'End If

            'm_AppPath = Config.GetConfigVal("files", "AppPath")
            'm_TaskID = Config.GetConfigVal("misc", "TaskID")

        Catch ex As Exception
            WriteTrace(1, "There has been an error: " & ex.Message, sIdm)
        Finally
            'WriteTrace(2, "End", sIdm)
        End Try
    End Sub

    'Protected Sub OnReciveTrace(ByVal sender As Object, ByVal traceInformation As TraceInformationEventArgs) _
    'Handles m_authentication.SendTrace, m_language.SendTrace, m_alarm.SendTrace, _
    '    m_license.SendTrace, m_msIPTVAccess.SendTrace, m_dataAccess.SendTrace

    '    WriteTrace(traceInformation)
    'End Sub

    Protected Sub OnReciveTrace(ByVal sender As Object, ByVal traceInformation As TraceInformationEventArgs) _
        Handles m_alarm.SendTrace, m_dataAccess.SendTrace, m_language.SendTrace

        WriteTrace(traceInformation)
    End Sub

    Protected Sub OnReciveAlarm(ByVal sender As Object, ByVal alarmInformation As AlarmInformationEventArgs) _
        Handles m_dataAccess.SendAlarm

        SendAlarm(alarmInformation)
    End Sub

#End Region

#Region "    Public functions"

    Public Sub New(ByVal source As String)

        create(source, False, False)
    End Sub


    Public Sub New(ByVal source As String, ByVal checkAuthentication As Boolean)

        create(source, checkAuthentication, False)
    End Sub

    Public Sub New(ByVal source As String, ByVal checkAuthentication As Boolean, ByVal register As Boolean)

        create(source, checkAuthentication, register)
    End Sub

    Public Sub WriteTrace(ByVal traceLevel As Byte, ByVal message As String, ByVal functionName As String)
        If Not IsNothing(m_trace) Then
            m_trace.Write(New TraceInformationEventArgs(traceLevel, message, functionName))
        End If
    End Sub

    Public Sub WriteTrace(ByVal traceInformation As TraceInformationEventArgs)
        If Not IsNothing(m_trace) Then
            m_trace.Write(traceInformation)
        End If
    End Sub

    Public Function Translate(ByVal sentence As String) As String
        Return "@@" & sentence & "@@"
    End Function

    Public Sub SendAlarm(ByVal eventValue As Integer, ByVal errorCause As String)
        If Not IsNothing(m_alarm) Then
            m_alarm.SendAlarm(New AlarmInformationEventArgs(eventValue, errorCause), m_source)
        End If
    End Sub

    Public Sub SendAlarm(ByVal alarmInformation As AlarmInformationEventArgs)
        If Not IsNothing(m_alarm) Then
            m_alarm.SendAlarm(alarmInformation, m_source)
        End If
    End Sub

#End Region

End Class
