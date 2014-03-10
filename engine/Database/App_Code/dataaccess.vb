'Database Access Funtions Copyright (C) 2013 Alcatel·Lucent 
'This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. 
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
'You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
Option Strict Off

Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Web
Imports MySql.Data.MySqlClient

Public Class DataAccess
    Inherits ALUInterface

    Public conn As MySqlConnection
    'Private m_environment As Environment

    'Public Sub New(ByVal M_e As Environment)

    '    m_environment = M_e
    'End Sub

    Public Enum EN_Status As Integer
        ALLOWED = 0
        DISALLOWED = 1
    End Enum

#Region "    Events"

    Event SendTrace As SendTraceEventHandler

    Protected Overrides Sub OnSendTrace(ByVal traceInformation As TraceInformationEventArgs)
        RaiseEvent SendTrace(Me, traceInformation)
    End Sub

    Event SendAlarm As SendAlarmEventHandler

    Protected Overrides Sub OnSendAlarm(ByVal alarmInformation As AlarmInformationEventArgs)
        RaiseEvent SendAlarm(Me, alarmInformation)
    End Sub

#End Region

#Region "    Private members"

    Private m_ConnectionString As String

#End Region

#Region "    Public properties"

    Property ConnectionString() As String
        Get
            Return m_ConnectionString
        End Get
        Set(ByVal value As String)
            m_ConnectionString = value
        End Set
    End Property

#End Region


#Region "    Private functions"

    Private Sub writeTrace(ByVal traceLevel As Byte, ByVal message As String, ByVal functionName As String)
        OnSendTrace(New TraceInformationEventArgs(traceLevel, message, functionName))
    End Sub

    Private Sub writeAlarm(ByVal eventValue As Integer, ByVal errorCause As String)
        OnSendAlarm(New AlarmInformationEventArgs(eventValue, errorCause))
    End Sub

#End Region

#Region "    Public structures"

    Public Structure retMsg
        Public retCode As Integer
        Public retMsg As String
    End Structure

    Public Structure UserProfile
        Public User_id As Integer
        Public Login As String
        Public Role As Integer
        Public Password As String
        Public Name As String
        Public Email As String
        Public telephonenumber As String
        Public Picture As String
        Public Language As String
        Public Home_area_lat As Double
        Public Home_area_lon As Double
        Public Home_area_radius As Double
        Public Last_loc_timestamp As Date
        Public Last_loc_lat As Double
        Public last_loc_lon As Double
        Public Notification_level As Integer
        Public Promoter_id As Integer
        Public User_average_mark As Double
        Public User_votes As Integer
        Public Enabled As Integer
        Public Distance As Long
        Public region As Integer
        Public address As String
        Public SkillsVisibility As Integer
        Public InterestsVisibility As Integer
        Public adminRegion As String
    End Structure

    Enum Role
        User
        Promoter
        Hub
        Small_bussines
        Technical_Admin
        Moderator_Admin
        Sys_Maintenance
    End Enum

#End Region

#Region "    Private functions"

    Private Function CDBStr(ByVal psString As String) As String
        CDBStr = IIf(Trim(psString) <> "", "'" & Trim(Replace(Replace(psString, "\", "\\"), "'", "\'")) & "'", "Null")
    End Function
    Private Function CDBStrBLOB(ByVal psString As String) As String
        CDBStrBLOB = IIf(Trim(psString) <> "", "'" & Replace(Replace(psString, "\", "\\"), "'", "\'") & "'", "Null")
    End Function

    Private Function CDBInt(ByVal psString As String, Optional ByVal nullableZero As Boolean = True) As String
        If nullableZero Then
            CDBInt = IIf(Trim(psString) <> "" And Trim(psString) <> "0", Trim(Replace(psString, ",", ".")), "Null")
        Else
            CDBInt = IIf(Trim(psString) <> "", Trim(Replace(psString, ",", ".")), "Null")
        End If
    End Function
    Public Function CDBDate(ByVal psString As DateTime) As String
        If psString = Nothing Then
            CDBDate = "Null"
        Else
            If psString.ToString.Length = 0 Then
                CDBDate = "Null"
            Else
                CDBDate = CDBStr(psString.ToString("yyyy-MM-dd HH:mm:ss"))
            End If
        End If
    End Function

    Private Sub fillerror(ByRef stErr As retMsg, ByVal Num As Integer, ByVal Descrip As String)
        stErr.retCode = Num
        stErr.retMsg = Descrip
    End Sub

    Public Sub initDB()
        Dim dbServer, dbName, dbUser, dbPassword As String
        Const sIdm As String = "dataaccess.initdb"
        Try
            writeTrace(2, "Entry ", sIdm)

            dbServer = Config.GetConfigVal("dbase", "dbServer")
            dbName = Config.GetConfigVal("dbase", "dbName")
            dbUser = Config.GetConfigVal("dbase", "dbUser")
            dbPassword = Config.GetConfigVal("dbase", "dbPassword")
            writeTrace(3, "Database server " & dbServer & " name " & dbName & " user " & dbUser & " pwd " & dbPassword, sIdm)
            m_ConnectionString = String.Format("server={0};user id={2}; password={3}; database={1}; pooling=false", dbServer, dbName, dbUser, dbPassword)

        Catch ex As Exception
            writeTrace(1, "Error " & ex.Message, sIdm)
        End Try
        writeTrace(2, "End ", sIdm)

    End Sub



#End Region

#Region "    Public functions"

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' getUserProfile: Get the user profile data                         
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 16-11-2011   1.0     Creation
    ''' 10-05-2013   xxx     Add SkillsVisibility, InterestsVisibility, address fields
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Function getUserProfile(ByVal pLogin As String) As UserProfile

        Dim sCommand As String
        Dim oDR As MySqlDataReader
        Dim result As UserProfile

        Const sIdm As String = "dataaccess.getUserProfile"
        Try
            initDB()

            If pLogin.Contains(" ") Then
                sCommand = "Select * From user_profile Where " & pLogin
            Else
                sCommand = "Select * From user_profile Where Login='" & pLogin & "'"
            End If


            Dim myConnection As New MySqlConnection(ConnectionString)
            Dim myCommand As New MySqlCommand(sCommand, myConnection)
            myConnection.Open()
            oDR = myCommand.ExecuteReader()

            If oDR.Read() Then
                writeTrace(3, "Reading User_id", sIdm)
                Try
                    result.User_id = oDR.GetValue(oDR.GetOrdinal("User_id"))
                Catch ex As Exception
                    result.User_id = ""
                End Try
                writeTrace(3, "Reading Login", sIdm)
                Try
                    result.Login = oDR.GetString(oDR.GetOrdinal("Login"))
                Catch ex As Exception
                    result.Login = ""
                End Try
                writeTrace(3, "Reading Role", sIdm)
                Try
                    result.Role = oDR.GetValue(oDR.GetOrdinal("Role"))
                Catch ex As Exception
                    result.Role = 0
                End Try
                writeTrace(3, "Reading Password", sIdm)
                Try
                    result.Password = oDR.GetString(oDR.GetOrdinal("Password"))
                Catch ex As Exception
                    result.Password = ""
                End Try
                writeTrace(3, "Reading Name", sIdm)
                Try
                    result.Name = oDR.GetString(oDR.GetOrdinal("Name"))
                Catch ex As Exception
                    result.Name = ""
                End Try
                writeTrace(3, "Reading Email", sIdm)
                Try
                    result.Email = oDR.GetString(oDR.GetOrdinal("Email"))
                Catch ex As Exception
                    result.Email = ""
                End Try
                writeTrace(3, "Reading telephonenumber", sIdm)
                Try
                    result.telephonenumber = oDR.GetString(oDR.GetOrdinal("telephonenumber"))
                Catch ex As Exception
                    result.telephonenumber = ""
                End Try
                writeTrace(3, "Reading Picture", sIdm)
                Try
                    result.Picture = oDR.GetString(oDR.GetOrdinal("Picture"))
                Catch ex As Exception
                    result.Picture = ""
                End Try
                writeTrace(3, "Reading Language", sIdm)
                Try
                    result.Language = oDR.GetString(oDR.GetOrdinal("Language"))
                Catch ex As Exception
                    result.Language = ""
                End Try
                writeTrace(3, "Reading Home_area_lat", sIdm)
                Try
                    result.Home_area_lat = oDR.GetValue(oDR.GetOrdinal("Home_area_lat"))
                Catch ex As Exception
                    result.Home_area_lat = 0.0
                End Try
                writeTrace(3, "Reading Home_area_lon", sIdm)
                Try
                    result.Home_area_lon = oDR.GetValue(oDR.GetOrdinal("Home_area_lon"))
                Catch ex As Exception
                    result.Home_area_lon = 0.0
                End Try
                writeTrace(3, "Reading Home_area_radius", sIdm)
                Try
                    result.Home_area_radius = oDR.GetValue(oDR.GetOrdinal("Home_area_radius"))
                Catch ex As Exception
                    result.Home_area_radius = 0.0
                End Try
                writeTrace(3, "Reading Last_loc_timestamp", sIdm)
                Try
                    result.Last_loc_timestamp = oDR.GetValue(oDR.GetOrdinal("Last_loc_timestamp"))
                Catch ex As Exception
                    result.Last_loc_timestamp = Now
                End Try
                writeTrace(3, "Reading Last_loc_lat", sIdm)
                Try
                    result.Last_loc_lat = oDR.GetValue(oDR.GetOrdinal("Last_loc_lat"))
                Catch ex As Exception
                    result.Last_loc_lat = 0.0
                End Try
                writeTrace(3, "Reading last_loc_lon", sIdm)
                Try
                    result.last_loc_lon = oDR.GetValue(oDR.GetOrdinal("last_loc_lon"))
                Catch ex As Exception
                    result.last_loc_lon = 0.0
                End Try
                writeTrace(3, "Reading Notification_level", sIdm)
                Try
                    result.Notification_level = oDR.GetValue(oDR.GetOrdinal("Notification_level"))
                Catch ex As Exception
                    result.Notification_level = 0
                End Try
                writeTrace(3, "Reading Promoter_id", sIdm)
                Try
                    result.Promoter_id = oDR.GetValue(oDR.GetOrdinal("Promoter_id"))
                Catch ex As Exception
                    result.Promoter_id = 0
                End Try
                writeTrace(3, "Reading User_average_mark", sIdm)
                Try
                    result.User_average_mark = oDR.GetValue(oDR.GetOrdinal("User_average_mark"))
                Catch ex As Exception
                    result.User_average_mark = 0.0
                End Try
                writeTrace(3, "Reading User_votes", sIdm)
                Try
                    result.User_votes = oDR.GetValue(oDR.GetOrdinal("User_votes"))
                Catch ex As Exception
                    result.User_votes = 0
                End Try
                writeTrace(3, "Reading Enabled", sIdm)
                Try
                    result.Enabled = oDR.GetValue(oDR.GetOrdinal("Enabled"))
                Catch ex As Exception
                    result.Enabled = 0
                End Try
                writeTrace(3, "Reading region", sIdm)
                Try
                    result.region = oDR.GetValue(oDR.GetOrdinal("region"))
                Catch ex As Exception
                    result.region = 0
                End Try
                writeTrace(3, "Reading address", sIdm)
                Try
                    result.address = oDR.GetString(oDR.GetOrdinal("address"))
                Catch ex As Exception
                    result.address = ""
                End Try
                writeTrace(3, "Reading SkillsVisibility", sIdm)
                Try
                    result.SkillsVisibility = oDR.GetValue(oDR.GetOrdinal("SkillsVisibility"))
                Catch ex As Exception
                    result.SkillsVisibility = 0
                End Try
                writeTrace(3, "Reading InterestsVisibility", sIdm)
                Try
                    result.InterestsVisibility = oDR.GetValue(oDR.GetOrdinal("InterestsVisibility"))
                Catch ex As Exception
                    result.InterestsVisibility = 0
                End Try
                writeTrace(3, "Reading adminRegion", sIdm)
                Try
                    result.adminRegion = oDR.GetString(oDR.GetOrdinal("adminRegion"))
                Catch ex As Exception
                    result.adminRegion = ""
                End Try
            End If
            oDR.Close()
            myCommand.Dispose()

            Return result

        Catch ex As Exception
            writeTrace(1, "ERROR in " & sIdm & ": " & ex.Message, sIdm)
            Return Nothing
        Finally
            writeTrace(2, "End", sIdm)
        End Try

    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' DBupdate: Ejecuta un Update en una base de datos MySQL
    ''' </summary>
    ''' <param name="p_tabla">Tabla  sobre la que se realiza el comando</param>
    ''' <param name="p_where">Clausula WHERE que indica el registro sobre el
    '''                       que se realiza el comando</param>
    ''' <param name="p_comando">Datos del comando a ejecutar: se define como un
    '''                         'ParamArray' de tipo String, se le pasan todos los
    '''                         pares 'campo' 'valor' de forma consecutiva</param>
    ''' <returns>
    ''' True  -> Si el comando se ejecuta correctamente
    ''' False -> Si el comando no se puede ejecutar
    ''' </returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' 21-01-2005 Creación
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    ''' 
    Public Function DBupdate(ByVal p_tabla As String, _
                             ByVal p_where As String, _
                             ByVal ParamArray p_comando As String()) As Boolean

        Dim vl_tmp1 As String = ""
        Dim vl_tmp2 As String = ""
        Dim vl_command As String
        Dim i As Integer

        Const sIdm As String = "Bdatos.update"

        initDB()

        '+------------------------------------------------------------+
        '| Tomar el número máximo de valores recibidos como parámetro |
        '+------------------------------------------------------------+
        Dim vl_max As Integer = p_comando.GetLength(0) - 1
        '+----------------------------------------------------------------------------+
        '| Agrupar por un lado los campos y por otro los valores, separados por comas |
        '| Recibimos los valores en el array de entrada, y pasamos los datos poniendo |
        '| parejas de 'nombre de campo', 'valor de campo'                             |
        '+----------------------------------------------------------------------------+
        For i = 0 To vl_max Step 2
            If i = 0 Then
                vl_tmp1 = p_comando(i) & "=" & p_comando(i + 1)
            Else
                vl_tmp1 = vl_tmp1 & "," & p_comando(i) & "=" & p_comando(i + 1)
            End If
        Next i
        '+----------------------------+
        '| Construimos el comando SQL |
        '+----------------------------+
        vl_command = String.Format("UPDATE {0} SET {1} WHERE {2}", _
                                   p_tabla, vl_tmp1, p_where)

        writeTrace(3, vl_command, sIdm)
        '+---------------------------+
        '| Ejecutamos el comando SQL |
        '+---------------------------+
        Try
            Dim myConnection As New MySqlConnection(ConnectionString)
            Dim myCommand As New MySqlCommand(vl_command, myConnection)
            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myCommand.Dispose()

            DBupdate = True

        Catch ex As MySqlException
            writeTrace(1, "ERROR in " & sIdm & ": " & ex.Message, sIdm)
            DBupdate = False
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' DBdelete: Ejecuta un Delete en una base de datos MySQL
    ''' </summary>
    ''' <param name="p_tabla">Tabla  sobre la que se realiza el comando</param>
    ''' <param name="p_where">Clausula WHERE que indica el registro sobre el
    '''                       que se realiza el comando</param>
    ''' <returns>
    ''' True  -> Si el comando se ejecuta correctamente
    ''' False -> Si el comando no se puede ejecutar
    ''' </returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' 21-01-2005 Creación
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    ''' 
    Public Function DBdelete(ByVal p_tabla As String, _
                             ByVal p_where As String) As Boolean

        Dim vl_command As String

        Const sIdm As String = "Bdatos.update"

        initDB()

        '+----------------------------+
        '| Construimos el comando SQL |
        '+----------------------------+
        vl_command = String.Format("DELETE FROM {0} WHERE {1}", _
                                   p_tabla, p_where)

        writeTrace(3, vl_command, sIdm)
        '+---------------------------+
        '| Ejecutamos el comando SQL |
        '+---------------------------+
        Try
            Dim myConnection As New MySqlConnection(ConnectionString)
            Dim myCommand As New MySqlCommand(vl_command, myConnection)
            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myCommand.Dispose()

            DBdelete = True

        Catch ex As MySqlException
            writeTrace(1, "ERROR in " & sIdm & ": " & ex.Message, sIdm)
            DBdelete = False
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' DBinsert: Ejecuta un Insert en una base de datos MySQL
    ''' </summary>
    ''' <param name="p_tabla">Tabla  sobre la que se realiza el comando</param>
    ''' <param name="p_comando">Datos del comando a ejecutar: se define como un
    '''                         'ParamArray' de tipo String, se le pasan todos los
    '''                         pares 'campo' 'valor' de forma consecutiva</param>
    ''' <returns>
    ''' True  -> Si el comando se ejecuta correctamente
    ''' False -> Si el comando no se puede ejecutar
    ''' </returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' 19-04-2011 Creación
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    ''' 
    Public Function DBinsert(ByVal p_tabla As String, _
                             ByVal ParamArray p_comando As String()) As Boolean

        Dim vl_tmp1 As String = ""
        Dim vl_tmp2 As String = ""
        Dim vl_command As String
        Dim i As Integer

        Const sIdm As String = "dataaccess.DBinsert"

        initDB()

        '+------------------------------------------------------------+
        '| Tomar el número máximo de valores recibidos como parámetro |
        '+------------------------------------------------------------+
        Dim vl_max As Integer = p_comando.GetLength(0) - 1
        '+----------------------------------------------------------------------------+
        '| Agrupar por un lado los campos y por otro los valores, separados por comas |
        '| Recibimos los valores en el array de entrada, y pasamos los datos poniendo |
        '| parejas de 'nombre de campo', 'valor de campo'                             |
        '+----------------------------------------------------------------------------+
        For i = 0 To vl_max Step 2
            If i = 0 Then
                vl_tmp1 = p_comando(i)
                vl_tmp2 = p_comando(i + 1)
            Else
                vl_tmp1 = vl_tmp1 & "," & p_comando(i)
                vl_tmp2 = vl_tmp2 & "," & p_comando(i + 1)
            End If
        Next i
        '+----------------------------+
        '| Construimos el comando SQL |
        '+----------------------------+
        vl_command = String.Format("INSERT INTO {0} ({1}) VALUES ({2})", _
                                   p_tabla, vl_tmp1, vl_tmp2)

        writeTrace(3, vl_command, sIdm)
        '+---------------------------+
        '| Ejecutamos el comando SQL |
        '+---------------------------+
        Try
            Dim myConnection As New MySqlConnection(ConnectionString)
            Dim myCommand As New MySqlCommand(vl_command, myConnection)
            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myCommand.Dispose()

            DBinsert = True

        Catch ex As MySqlException
            writeTrace(1, "ERROR in " & sIdm & ": " & ex.Message, sIdm)
            DBinsert = False
        End Try

    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' read: Ejecuta un lectura en la base de datos
    ''' </summary>
    ''' <param name="p_query">Sentencia SQL de lectura</param>
    ''' <returns>
    ''' Devuelve una estructura 'MySqlDataReader'
    ''' </returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' 22-01-2005 Creación
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Function read(ByVal p_query As String) As MySqlDataReader

        Const sIdm As String = "Bdatos.read"

        Try
            initDB()

            writeTrace(3, p_query, sIdm)

            Dim myConnection As New MySqlConnection(ConnectionString)
            Dim myCommand As New MySqlCommand(p_query, myConnection)
            read = myCommand.ExecuteReader()
            'myCommand.Dispose()

        Catch ex As MySqlException
            writeTrace(1, "ERROR in " & sIdm & ": " & ex.Message, sIdm)
            read = Nothing
        End Try

    End Function

#End Region

End Class
