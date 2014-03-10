'Database Access Funtions Copyright (C) 2013 Alcatel·Lucent 
'This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. 
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
'You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
Imports Microsoft.VisualBasic
Imports System.Globalization


Public NotInheritable Class Functions

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' strToDate: Convertir cadena a fecha según formato
    ''' </summary>
    ''' <param name="pStrDate">Cadena que representa la fecha</param>
    ''' <param name="pStrFormat">Cadena que representa el formato en el que llega la
    '''                          cadena de fecha</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' 27-04-2006  Creación
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    ''' 
    Shared Function StrToDate(ByVal pStrDate As String, ByVal pStrFormat As String) As Date
        strToDate = Date.ParseExact(pStrDate, pStrFormat, System.Globalization.DateTimeFormatInfo.InvariantInfo)
    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' dateToStr: Convertir en cadena una fecha según formato
    ''' </summary>
    ''' <param name="pDate">Fecha</param>
    ''' <param name="pStrFormat">Cadena que representa el formato en el que llega la
    '''                          fecha</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' 27-04-2006  Creación
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    ''' 
    Shared Function DateToStr(ByVal pDate As Date, ByVal pStrFormat As String) As String
        dateToStr = String.Format("{0:" & pStrFormat & "}", pDate)
    End Function

    'Shared Function MapPath(ByVal path As String) As String

    '    Return My.Application.Info.DirectoryPath & "\" & path.Replace("/", "\")
    'End Function

    ''' <summary>
    ''' Determina si el texto cumple el formato de dirección IP
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function IsIP(ByVal ip As String) As Boolean
        Dim params As String() = ip.Split(".")

        Return params.Length = 4 AndAlso (IsNumeric(params(0)) And IsNumeric(params(1)) And IsNumeric(params(2)) And IsNumeric(params(3)))
    End Function

    Shared Sub DeleteFile(ByVal sFile As String)

        My.Computer.FileSystem.DeleteFile(sFile, _
                              FileIO.UIOption.OnlyErrorDialogs, _
                              FileIO.RecycleOption.SendToRecycleBin)
    End Sub

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' StripFileName: Separar el nombre de archivo
    ''' </summary>
    ''' <param name="rsFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' 23-09-2001: Creación
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Shared Function StripFileName2(ByVal rsFileName As String) As String
        Dim i As Integer

        On Error Resume Next

        For i = Len(rsFileName) To 1 Step -1
            If Mid(rsFileName, i, 1) = "\" Then
                Exit For
            End If
        Next

        StripFileName2 = Mid(rsFileName, i + 1, Len(rsFileName))

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' StripFileExtension: Separar la extensión del archivo
    ''' </summary>
    ''' <param name="rsFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' 23-09-2001: Creación
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Shared Function StripFileExtension(ByVal rsFileName As String) As String
        Dim i As Integer

        On Error Resume Next

        For i = Len(rsFileName) To 1 Step -1
            If Mid(rsFileName, i, 1) = "." Then
                Exit For
            End If
        Next

        StripFileExtension = Mid(rsFileName, i + 1, Len(rsFileName))

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' getDate: Try to convert string to date
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' 29-11-2011: Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Shared Function getDate(ByVal sDate As String) As Date

        Dim dDate As Date
        Dim i As Integer

        Try
            Dim formats() As String = {"dd/MM/yyyy HH:mm", _
                                       "dd/MM/yyyy", _
                                       "dd/MM/yy", _
                                       "MM/dd/yyyy", _
                                       "MM/dd/yy", _
                                       "MMM d HH:mm", _
                                       "MMM dd HH:mm", _
                                       "MMM d yyyy", _
                                       "M/d/yyyy h:mm:ss tt", _
                                       "M/d/yyyy h:mm tt", _
                                       "MM/dd/yyyy hh:mm:ss", _
                                       "M/d/yyyy h:mm:ss", _
                                       "M/d/yyyy hh:mm tt", _
                                       "M/d/yyyy hh tt", _
                                       "M/d/yyyy h:mm", _
                                       "M/d/yyyy h:mm", _
                                       "MM/dd/yyyy hh:mm", _
                                       "M/dd/yyyy hh:mm"}

            For Each formatString As String In formats
                Try
                    dDate = Date.ParseExact(sDate, formatString, System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    Exit For
                Catch ex As Exception
                    i += 1
                End Try
            Next

            Return dDate

        Catch ex As Exception

        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' loadTemplate: Load a Template
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' 15-02-2012  Creación
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Shared Function loadTemplate(ByVal Skin As String, ByVal lang As String) As String

        Dim sFile, sTemplateFolder As String

        sTemplateFolder = My.Request.MapPath("templates")
        sFile = sTemplateFolder & "\" & Skin & "." & lang

        If My.Computer.FileSystem.FileExists(sFile) Then
            loadTemplate = My.Computer.FileSystem.ReadAllText(sFile, Encoding.GetEncoding("iso-8859-1"))
        Else
            sFile = sTemplateFolder & "\" & Skin & ".en"
            loadTemplate = My.Computer.FileSystem.ReadAllText(sFile, Encoding.GetEncoding("iso-8859-1"))
        End If

    End Function

End Class
