'Database Access Funtions Copyright (C) 2013 Alcatel·Lucent 
'This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. 
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
'You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
Imports Microsoft.VisualBasic

Public MustInherit Class ALUInterface

    ''' <summary>
    ''' SendTrace event definition
    ''' </summary>
    ''' <remarks></remarks>
    Public Delegate Sub SendTraceEventHandler(ByVal sender As Object, ByVal traceInformation As TraceInformationEventArgs)

    Protected MustOverride Sub OnSendTrace(ByVal traceInformation As TraceInformationEventArgs)

    ''' <summary>
    ''' SendAlarm event definition
    ''' </summary>
    ''' <remarks></remarks>
    Public Delegate Sub SendAlarmEventHandler(ByVal sender As Object, ByVal alarmInformation As AlarmInformationEventArgs)

    Protected MustOverride Sub OnSendAlarm(ByVal alarmInformation As AlarmInformationEventArgs)

End Class
