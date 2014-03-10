'Database Access Funtions Copyright (C) 2013 Alcatel·Lucent 
'This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. 
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
'You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
Option Strict On

Imports System.Xml
Imports System.Text
Imports System.IO
Imports Microsoft.Win32
Imports System.Security
Imports System.Security.AccessControl

Public NotInheritable Class Config

    Const prfx As String = "configuration"

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' Retorna el valor del parámetro "key" del registro de configuración
    ''' </summary>
    ''' <returns>
    ''' Devuelve un parámetro de configuración en formato String
    ''' </returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' 19-09-2004 Creación
    ''' 16-01-2006 Eliminamos el parámetro de entrada de fichero de configuración y
    '''            tomamos el fichero que se introduce al crear el objeto
    ''' 2008-11-03 Modificación Guillermo de Mas Alted
    '''            Modificación para tener la configuración guardada en el registro de sistema
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Shared Function GetConfigVal(ByVal section As String, ByVal key As String) As String

        Dim permissionCheck As RegistryKeyPermissionCheck = RegistryKeyPermissionCheck.ReadWriteSubTree
        Dim rights As System.Security.AccessControl.RegistryRights = System.Security.AccessControl.RegistryRights.FullControl

        Dim softwareKey As RegistryKey = Registry.LocalMachine.OpenSubKey("Software", permissionCheck, rights)
        Dim aluKey As RegistryKey = softwareKey.OpenSubKey("Life_2_0", permissionCheck, rights)
        If aluKey Is Nothing Then
            Dim aluKey0 As RegistryKey = softwareKey.OpenSubKey("Wow6432Node", permissionCheck, rights)
            aluKey = aluKey0.OpenSubKey("Life_2_0", permissionCheck, rights)
        End If
        'Dim appKey As RegistryKey = aluKey.OpenSubKey("DBService", permissionCheck, rights)

        Return CStr(IIf(IsNothing(aluKey.GetValue(section & "/" & key)), "", aluKey.GetValue(section & "/" & key)))
    End Function

    ''' <summary>
    ''' Guarda el valor en el parametro del registro de sistema
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub SetConfigVal(ByVal section As String, ByVal key As String, ByVal value As String)

        Dim permissionCheck As RegistryKeyPermissionCheck = RegistryKeyPermissionCheck.ReadWriteSubTree
        Dim rights As System.Security.AccessControl.RegistryRights = System.Security.AccessControl.RegistryRights.FullControl

        Dim softwareKey As RegistryKey = Registry.LocalMachine.OpenSubKey("Software", permissionCheck, rights)
        Dim aluKey As RegistryKey = softwareKey.OpenSubKey("Life_2_0", permissionCheck, rights)
        If aluKey Is Nothing Then
            Dim aluKey0 As RegistryKey = softwareKey.OpenSubKey("Wow6432Node", permissionCheck, rights)
            aluKey = aluKey0.OpenSubKey("Life_2_0", permissionCheck, rights)
        End If
        'Dim appKey As RegistryKey = aluKey.OpenSubKey("DBService", permissionCheck, rights)

        aluKey.SetValue(section & "/" & key, value)
    End Sub

End Class