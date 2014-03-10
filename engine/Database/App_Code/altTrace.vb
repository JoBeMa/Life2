'Database Access Funtions Copyright (C) 2013 Alcatel·Lucent 
'This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. 
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
'You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
Imports Microsoft.VisualBasic
Imports System.Web

Public Class altTrace

    Public Sub WriteTrace(ByVal traceInformation As String)

        Dim cur As HttpContext = HttpContext.Current

        Try
            If Not cur Is Nothing Then
                cur.Trace.Write(traceInformation)
            End If

        Catch ex As Exception

        End Try

    End Sub

End Class
