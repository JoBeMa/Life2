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
    End Structure

    Public Structure StRequest
        Public Request_id As Integer
        Public Requester_id As Integer
        Public Request_type As String
        Public Category_id As String
        Public Short_description As String
        Public Description As String
        Public When_Request As String
        Public Where_Request As String
        Public Filtering_preferences As Integer
        Public Status As Integer
        Public Deadline As Date
        Public Candidates As String
        Public Distance As Long
        Public lng As String
        Public ContactType As Integer
        Public SubmissionDate As Date
    End Structure

    Public Structure stOffer
        Public Offer_id As Integer
        Public Offer_type As Integer
        Public Category As String
        Public Promoter_id As String
        Public Short_Description As String
        Public Detailed_info As String
        Public When_offer As String
        Public Where_offer As String
        Public Deadline As Date
        Public Offer_average_mark As Double
        Public Offer_votes As Integer
        Public Distance As Long
        Public lng As String
        Public Candidates As String
        Public ContactType As Integer
        Public SubmissionDate As Date
    End Structure

    Public Structure stJoin
        Public Join_id As Integer
        Public Id As Integer
        Public User_id As Integer
        Public Status As Integer
        Public Type As Integer
    End Structure

    Public Structure stSkill
        Public skill_id As String
        Public skill_name As String
        Public promoter_id As String
        Public lng As String
    End Structure

    Public Structure stInterest
        Public interest_id As String
        Public interest_name As String
        Public user_id As String
        Public lng As String
    End Structure

    Public Structure stCategory
        Public category_id As String
        Public category_name As String
        Public category_desc As String
        Public status As Integer
        Public lng As String
    End Structure

    Public Structure stCatalogue
        Public Id As Integer
        Public Type As Integer
        Public Category As String
        Public Promoter_id As String
        Public Short_Description As String
        Public Detailed_info As String
        Public When_c As String
        Public Where_c As String
        Public Deadline As Date
        Public Average_mark As Double
        Public Votes As Integer
        Public Distance As Long
        Public lng As String
        Public Candidates As String
        Public ContactType As Integer
        Public SubmissionDate As Date
    End Structure

    Public Structure stRecommendations
        Public recid As Integer
        Public Offer_id As Integer
        Public User_id As String
        Public Comment As String
        Public RecList As String
        Public lng As Long
    End Structure

    Public Structure stRegion
        Public id As Integer
        Public name As String
        Public country As String
        Public country_code As String
        Public lat As String
        Public lon As String
        Public radius As Long
        Public lng As String
    End Structure

    Public Structure stBusiness
        Public SB_id As Integer
        Public User_id As Integer
        Public Name As String
        Public Area As Integer
        Public SB_average_mark As Double
        Public SB_votes As Integer
        Public lng As String
        Public Category As Integer
        Public Address As String
    End Structure

    Public Structure stHub
        Public Hub_id As Integer
        Public User_id As Integer
        Public Name As String
        Public Area As Integer
        Public Hub_average_mark As Double
        Public Hub_votes As Integer
        Public lng As String
        Public Category As Integer
        Public Address As String
    End Structure

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
                Try
                    result.User_id = oDR.GetValue(oDR.GetOrdinal("User_id"))
                Catch ex As Exception
                    result.User_id = ""
                End Try
                Try
                    result.Login = oDR.GetString(oDR.GetOrdinal("Login"))
                Catch ex As Exception
                    result.Login = ""
                End Try
                Try
                    result.Role = oDR.GetString(oDR.GetOrdinal("Role"))
                Catch ex As Exception
                    result.Role = 0
                End Try
                Try
                    result.Password = oDR.GetString(oDR.GetOrdinal("Password"))
                Catch ex As Exception
                    result.Password = ""
                End Try
                Try
                    result.Name = oDR.GetString(oDR.GetOrdinal("Name"))
                Catch ex As Exception
                    result.Name = ""
                End Try
                Try
                    result.Email = oDR.GetString(oDR.GetOrdinal("Email"))
                Catch ex As Exception
                    result.Email = ""
                End Try
                Try
                    result.telephonenumber = oDR.GetString(oDR.GetOrdinal("telephonenumber"))
                Catch ex As Exception
                    result.telephonenumber = ""
                End Try
                Try
                    result.Picture = oDR.GetString(oDR.GetOrdinal("Picture"))
                Catch ex As Exception
                    result.Picture = ""
                End Try
                Try
                    result.Language = oDR.GetString(oDR.GetOrdinal("Language"))
                Catch ex As Exception
                    result.Language = ""
                End Try
                Try
                    result.Home_area_lat = oDR.GetValue(oDR.GetOrdinal("Home_area_lat"))
                Catch ex As Exception
                    result.Home_area_lat = 0.0
                End Try
                Try
                    result.Home_area_lon = oDR.GetValue(oDR.GetOrdinal("Home_area_lon"))
                Catch ex As Exception
                    result.Home_area_lon = 0.0
                End Try
                Try
                    result.Last_loc_timestamp = oDR.GetValue(oDR.GetOrdinal("Last_loc_timestamp"))
                Catch ex As Exception
                    result.Last_loc_timestamp = Now
                End Try
                Try
                    result.Last_loc_lat = oDR.GetValue(oDR.GetOrdinal("Last_loc_lat"))
                Catch ex As Exception
                    result.Last_loc_lat = 0.0
                End Try
                Try
                    result.last_loc_lon = oDR.GetValue(oDR.GetOrdinal("last_loc_lon"))
                Catch ex As Exception
                    result.last_loc_lon = 0.0
                End Try
                Try
                    result.Notification_level = oDR.GetValue(oDR.GetOrdinal("Notification_level"))
                Catch ex As Exception
                    result.Notification_level = oDR.GetValue(oDR.GetOrdinal("Notification_level"))
                End Try
                Try
                    result.Promoter_id = oDR.GetValue(oDR.GetOrdinal("Promoter_id"))
                Catch ex As Exception
                    result.Promoter_id = 0
                End Try
                Try
                    result.User_average_mark = oDR.GetValue(oDR.GetOrdinal("User_average_mark"))
                Catch ex As Exception
                    result.User_average_mark = 0.0
                End Try
                Try
                    result.User_votes = oDR.GetValue(oDR.GetOrdinal("User_votes"))
                Catch ex As Exception
                    result.User_votes = 0
                End Try
                Try
                    result.Enabled = oDR.GetValue(oDR.GetOrdinal("Enabled"))
                Catch ex As Exception
                    result.Enabled = 0
                End Try
                Try
                    result.region = oDR.GetValue(oDR.GetOrdinal("region"))
                Catch ex As Exception
                    result.region = 0
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
    ''' getUserProfile: Get the user profile data                         
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 16-11-2011   1.0     Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Function getUserName(ByVal pLogin As String) As String

        Dim sCommand As String
        Dim oDR As MySqlDataReader
        Dim sReturn As String

        Const sIdm As String = "dataaccess.getUserName"
        Try
            initDB()

            sCommand = "Select Name From user_profile Where " & pLogin

            Dim myConnection As New MySqlConnection(ConnectionString)
            Dim myCommand As New MySqlCommand(sCommand, myConnection)
            myConnection.Open()
            oDR = myCommand.ExecuteReader()

            If oDR.Read() Then
                Try
                    sReturn = oDR.GetString(oDR.GetOrdinal("Name")) & " "
                Catch ex As Exception
                    sReturn = ""
                End Try
            End If
            oDR.Close()
            myCommand.Dispose()

            Return sReturn

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
    ''' DBexecute: Execute sql command MySQL
    ''' </summary>
    ''' <returns>
    ''' True  -> Si el comando se ejecuta correctamente
    ''' False -> Si el comando no se puede ejecutar
    ''' </returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' 17-01-2013 Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    ''' 
    Public Function DBexecute(ByVal p_sql As String) As Boolean

        Const sIdm As String = "Dataacess.DBexecute"

        initDB()

        writeTrace(3, p_sql, sIdm)
        '+---------------------------+
        '| Ejecutamos el comando SQL |
        '+---------------------------+
        Try
            Dim myConnection As New MySqlConnection(ConnectionString)
            Dim myCommand As New MySqlCommand(p_sql, myConnection)
            myConnection.Open()
            myCommand.ExecuteNonQuery()
            myCommand.Dispose()

            DBexecute = True

        Catch ex As MySqlException
            writeTrace(1, "ERROR in " & sIdm & ": " & ex.Message, sIdm)
            DBexecute = False
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

        Const sIdm As String = "dataccess.DBdelete"

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


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' getRequest: Get a request                         
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 16-11-2011   1.0     Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Function getRequest(ByVal pSql As String) As StRequest

        Dim sCommand As String
        Dim oDR As MySqlDataReader
        Dim result As StRequest

        Const sIdm As String = "dataaccess.getRequest"
        Try
            initDB()

            sCommand = "Select * From request Where " & pSql

            Dim myConnection As New MySqlConnection(ConnectionString)
            Dim myCommand As New MySqlCommand(sCommand, myConnection)
            myConnection.Open()
            oDR = myCommand.ExecuteReader()

            If oDR.Read() Then
                '+-------------------------------------------------------------+
                '| Read only the first record, as the query can return several |
                '+-------------------------------------------------------------+
                Try
                    result.Request_id = oDR.GetValue(oDR.GetOrdinal("RequestId"))
                Catch ex As Exception
                    result.Request_id = 0
                End Try
                Try
                    result.Requester_id = oDR.GetString(oDR.GetOrdinal("RequesterId"))
                Catch ex As Exception
                    result.Requester_id = 0
                End Try
                Try
                    result.Request_type = oDR.GetString(oDR.GetOrdinal("RequestType"))
                Catch ex As Exception
                    result.Request_type = ""
                End Try
                Try
                    result.Category_id = oDR.GetString(oDR.GetOrdinal("CategoryId"))
                Catch ex As Exception
                    result.Category_id = ""
                End Try
                Try
                    result.Description = oDR.GetString(oDR.GetOrdinal("Description"))
                Catch ex As Exception
                    result.Description = ""
                End Try
                Try
                    result.Short_description = oDR.GetString(oDR.GetOrdinal("Short_description"))
                Catch ex As Exception
                    result.Short_description = ""
                End Try
                Try
                    result.When_Request = oDR.GetString(oDR.GetOrdinal("WhenReq"))
                Catch ex As Exception
                    result.When_Request = ""
                End Try
                Try
                    result.Where_Request = oDR.GetString(oDR.GetOrdinal("WhereReq"))
                Catch ex As Exception
                    result.Where_Request = ""
                End Try
                Try
                    result.Filtering_preferences = oDR.GetValue(oDR.GetOrdinal("FilteringPrefs"))
                Catch ex As Exception
                    result.Filtering_preferences = 0
                End Try
                Try
                    result.Status = oDR.GetValue(oDR.GetOrdinal("Status"))
                Catch ex As Exception
                    result.Status = 0
                End Try
                Try
                    result.Deadline = oDR.GetValue(oDR.GetOrdinal("Deadline"))
                Catch ex As Exception
                    result.Deadline = Nothing
                End Try
                Try
                    result.Candidates = oDR.GetValue(oDR.GetOrdinal("Candidates"))
                Catch ex As Exception
                    result.Candidates = ""
                End Try
                Try
                    result.ContactType = oDR.GetValue(oDR.GetOrdinal("ContactType"))
                Catch ex As Exception
                    result.ContactType = 0
                End Try
                Try
                    result.lng = oDR.GetValue(oDR.GetOrdinal("lng"))
                Catch ex As Exception
                    result.lng = ""
                End Try
                Try
                    result.SubmissionDate = oDR.GetValue(oDR.GetOrdinal("SubmissionDate"))
                Catch ex As Exception
                    result.SubmissionDate = Nothing
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
    ''' getRequest: Get a request                         
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 16-11-2011   1.0     Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Function getRecommendation(ByVal pSql As String) As stRecommendations

        Dim sCommand As String
        Dim oDR As MySqlDataReader
        Dim result As stRecommendations

        Const sIdm As String = "dataaccess.getRecommendation"
        Try
            initDB()

            sCommand = "Select * From Recommendations Where " & pSql

            Dim myConnection As New MySqlConnection(ConnectionString)
            Dim myCommand As New MySqlCommand(sCommand, myConnection)
            myConnection.Open()
            oDR = myCommand.ExecuteReader()

            If oDR.Read() Then
                '+-------------------------------------------------------------+
                '| Read only the first record, as the query can return several |
                '+-------------------------------------------------------------+
                Try
                    result.recid = oDR.GetValue(oDR.GetOrdinal("recid"))
                Catch ex As Exception
                    result.recid = 0
                End Try
                Try
                    result.Offer_id = oDR.GetString(oDR.GetOrdinal("Offer_id"))
                Catch ex As Exception
                    result.Offer_id = 0
                End Try
                Try
                    result.User_id = oDR.GetString(oDR.GetOrdinal("User_id"))
                Catch ex As Exception
                    result.User_id = ""
                End Try
                Try
                    result.Comment = oDR.GetString(oDR.GetOrdinal("Comment"))
                Catch ex As Exception
                    result.Comment = ""
                End Try
                Try
                    result.RecList = oDR.GetString(oDR.GetOrdinal("RecList"))
                Catch ex As Exception
                    result.RecList = ""
                End Try
                Try
                    result.lng = oDR.GetString(oDR.GetOrdinal("lng"))
                Catch ex As Exception
                    result.lng = ""
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
    ''' getCatalogue: Get catalogue item                         
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 16-11-2011   1.0     Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Function getCatalogue(ByVal pSql As String) As stCatalogue

        Dim sCommand As String
        Dim myReader As MySqlDataReader
        Dim result As stCatalogue

        Const sIdm As String = "dataaccess.getCatalogue"
        Try
            initDB()

            sCommand = "Select * From catalogue Where " & pSql
            writeTrace(3, "sCommand: " & sCommand, sIdm)

            Dim myConnection As New MySqlConnection(ConnectionString)
            Dim myCommand As New MySqlCommand(sCommand, myConnection)
            myConnection.Open()
            myReader = myCommand.ExecuteReader()

            If myReader.Read() Then
                '+-------------------------------------------------------------+
                '| Read only the first record, as the query can return several |
                '+-------------------------------------------------------------+
                result.Id = myReader.GetValue(myReader.GetOrdinal("Offer_id"))
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Offer_type"))) Then
                    result.Type = myReader.GetValue(myReader.GetOrdinal("Offer_type"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category_id"))) Then
                    result.Category = myReader.GetValue(myReader.GetOrdinal("Category_id"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Promoter_id"))) Then
                    result.Promoter_id = myReader.GetValue(myReader.GetOrdinal("Promoter_id"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Short_description"))) Then
                    result.Short_Description = myReader.GetValue(myReader.GetOrdinal("Short_description"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Detailed_info"))) Then
                    result.Detailed_info = myReader.GetValue(myReader.GetOrdinal("Detailed_info"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("WhenCat"))) Then
                    result.When_c = myReader.GetValue(myReader.GetOrdinal("WhenCat"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("WhereCat"))) Then
                    result.Where_c = myReader.GetValue(myReader.GetOrdinal("WhereCat"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Deadline"))) Then
                    result.Deadline = myReader.GetValue(myReader.GetOrdinal("Deadline"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Offer_average_mark"))) Then
                    result.Average_mark = myReader.GetValue(myReader.GetOrdinal("Offer_average_mark"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Offer_votes"))) Then
                    result.Votes = myReader.GetValue(myReader.GetOrdinal("Offer_votes"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lng"))) Then
                    result.lng = myReader.GetValue(myReader.GetOrdinal("lng"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Candidates"))) Then
                    result.Candidates = myReader.GetValue(myReader.GetOrdinal("Candidates"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("ContactType"))) Then
                    result.ContactType = myReader.GetValue(myReader.GetOrdinal("ContactType"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("SubmissionDate"))) Then
                    result.SubmissionDate = myReader.GetValue(myReader.GetOrdinal("SubmissionDate"))
                End If
            End If
            myReader.Close()
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
    ''' getOffer: Get an offer                         
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 16-11-2011   1.0     Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Function getOffer(ByVal pSql As String) As stOffer

        Dim sCommand As String
        Dim myReader As MySqlDataReader
        Dim result As stOffer

        Const sIdm As String = "dataaccess.getOffer"
        Try
            initDB()

            sCommand = "Select * From catalogue Where " & pSql
            writeTrace(3, "sql = " & sCommand, sIdm)

            Dim myConnection As New MySqlConnection(ConnectionString)
            Dim myCommand As New MySqlCommand(sCommand, myConnection)
            myConnection.Open()
            myReader = myCommand.ExecuteReader()

            If myReader.Read() Then
                '+-------------------------------------------------------------+
                '| Read only the first record, as the query can return several |
                '+-------------------------------------------------------------+
                result.Offer_id = myReader.GetValue(myReader.GetOrdinal("Offer_id"))
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Offer_type"))) Then
                    result.Offer_type = myReader.GetValue(myReader.GetOrdinal("Offer_type"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category_id"))) Then
                    result.Category = myReader.GetValue(myReader.GetOrdinal("Category_id"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Promoter_id"))) Then
                    result.Promoter_id = myReader.GetValue(myReader.GetOrdinal("Promoter_id"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Short_description"))) Then
                    result.Short_Description = myReader.GetValue(myReader.GetOrdinal("Short_description"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Detailed_info"))) Then
                    result.Detailed_info = myReader.GetValue(myReader.GetOrdinal("Detailed_info"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("WhenCat"))) Then
                    result.When_offer = myReader.GetValue(myReader.GetOrdinal("WhenCat"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("WhereCat"))) Then
                    result.Where_offer = myReader.GetValue(myReader.GetOrdinal("WhereCat"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Deadline"))) Then
                    result.Deadline = myReader.GetValue(myReader.GetOrdinal("Deadline"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Offer_average_mark"))) Then
                    result.Offer_average_mark = myReader.GetValue(myReader.GetOrdinal("Offer_average_mark"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Offer_votes"))) Then
                    result.Offer_votes = myReader.GetValue(myReader.GetOrdinal("Offer_votes"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lng"))) Then
                    result.lng = myReader.GetValue(myReader.GetOrdinal("lng"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Candidates"))) Then
                    result.Candidates = myReader.GetValue(myReader.GetOrdinal("Candidates"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("ContactType"))) Then
                    result.ContactType = myReader.GetValue(myReader.GetOrdinal("ContactType"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("SubmissionDate"))) Then
                    result.SubmissionDate = myReader.GetValue(myReader.GetOrdinal("SubmissionDate"))
                End If
            End If
            myReader.Close()
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
    ''' getOffer: Get an offer                         
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 16-11-2011   1.0     Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Function getJoin(ByVal pSql As String) As stJoin

        Dim sCommand As String
        Dim myReader As MySqlDataReader
        Dim result As stJoin

        Const sIdm As String = "dataaccess.getJoin"
        Try
            initDB()

            sCommand = "Select * From Joins Where " & pSql

            Dim myConnection As New MySqlConnection(ConnectionString)
            Dim myCommand As New MySqlCommand(sCommand, myConnection)
            myConnection.Open()
            myReader = myCommand.ExecuteReader()

            If myReader.Read() Then
                '+-------------------------------------------------------------+
                '| Read only the first record, as the query can return several |
                '+-------------------------------------------------------------+
                result.Join_id = myReader.GetValue(myReader.GetOrdinal("idJoin"))
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Id"))) Then
                    result.Id = myReader.GetValue(myReader.GetOrdinal("Id"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("User_id"))) Then
                    result.User_id = myReader.GetValue(myReader.GetOrdinal("User_id"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Status"))) Then
                    result.Status = myReader.GetValue(myReader.GetOrdinal("Status"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Type"))) Then
                    result.Type = myReader.GetValue(myReader.GetOrdinal("Type"))
                End If
            End If
            myReader.Close()
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
    ''' getSkill: Get skills                         
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 16-11-2011   1.0     Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Function getSkill(ByVal pSql As String) As stSkill

        Dim sCommand As String
        Dim myReader As MySqlDataReader
        Dim result As stSkill

        Const sIdm As String = "dataaccess.getSkill"
        Try
            initDB()

            sCommand = "Select * From promoter_skills Where " & pSql

            Dim myConnection As New MySqlConnection(ConnectionString)
            Dim myCommand As New MySqlCommand(sCommand, myConnection)
            myConnection.Open()
            myReader = myCommand.ExecuteReader()

            If myReader.Read() Then
                '+-------------------------------------------------------------+
                '| Read only the first record, as the query can return several |
                '+-------------------------------------------------------------+
                result.skill_id = myReader.GetValue(myReader.GetOrdinal("Skill_id")).ToString
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Skill_name"))) Then
                    result.skill_name = myReader.GetValue(myReader.GetOrdinal("Skill_name"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Promoter_id"))) Then
                    result.promoter_id = myReader.GetValue(myReader.GetOrdinal("Promoter_id")).ToString
                End If
            End If
            myReader.Close()
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
    ''' getInterest: Get interest                         
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 17-05-2012   1.0     Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Function getInterest(ByVal pSql As String) As stInterest

        Dim sCommand As String
        Dim myReader As MySqlDataReader
        Dim result As stInterest

        Const sIdm As String = "dataaccess.getInterest"
        Try
            initDB()

            sCommand = "Select * From user_interests Where " & pSql

            Dim myConnection As New MySqlConnection(ConnectionString)
            Dim myCommand As New MySqlCommand(sCommand, myConnection)
            myConnection.Open()
            myReader = myCommand.ExecuteReader()

            If myReader.Read() Then
                '+-------------------------------------------------------------+
                '| Read only the first record, as the query can return several |
                '+-------------------------------------------------------------+
                result.interest_id = myReader.GetValue(myReader.GetOrdinal("interest_id")).ToString
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("interest_name"))) Then
                    result.interest_name = myReader.GetValue(myReader.GetOrdinal("interest_name"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("user_id"))) Then
                    result.user_id = myReader.GetValue(myReader.GetOrdinal("user_id")).ToString
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lng"))) Then
                    result.lng = myReader.GetValue(myReader.GetOrdinal("lng")).ToString
                End If
            End If
            myReader.Close()
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
    ''' getCategory: Get a category                         
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 16-11-2011   1.0     Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Function getCategory(ByVal pSql As String) As stCategory

        Dim sCommand As String
        Dim myReader As MySqlDataReader
        Dim result As stCategory

        Const sIdm As String = "dataaccess.getCategory"
        Try
            initDB()

            sCommand = "Select * From category Where " & pSql

            Dim myConnection As New MySqlConnection(ConnectionString)
            Dim myCommand As New MySqlCommand(sCommand, myConnection)
            myConnection.Open()
            myReader = myCommand.ExecuteReader()

            If myReader.Read() Then
                '+-------------------------------------------------------------+
                '| Read only the first record, as the query can return several |
                '+-------------------------------------------------------------+
                result.category_id = myReader.GetValue(myReader.GetOrdinal("Category_id")).ToString
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category_name"))) Then
                    result.category_name = myReader.GetValue(myReader.GetOrdinal("Category_name"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category_description"))) Then
                    result.category_desc = myReader.GetValue(myReader.GetOrdinal("Category_description")).ToString
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("status"))) Then
                    result.status = myReader.GetValue(myReader.GetOrdinal("status")).ToString
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lng"))) Then
                    result.lng = myReader.GetValue(myReader.GetOrdinal("lng")).ToString
                End If
            End If
            myReader.Close()
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
    ''' getActCategory: Get an activity category                         
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 05-10-2012   1.0     Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Function getActCategory(ByVal pSql As String) As stCategory

        Dim sCommand As String
        Dim myReader As MySqlDataReader
        Dim result As stCategory

        Const sIdm As String = "dataaccess.getActCategory"
        Try
            initDB()

            sCommand = "Select * From activity_category Where " & pSql

            Dim myConnection As New MySqlConnection(ConnectionString)
            Dim myCommand As New MySqlCommand(sCommand, myConnection)
            myConnection.Open()
            myReader = myCommand.ExecuteReader()

            If myReader.Read() Then
                '+-------------------------------------------------------------+
                '| Read only the first record, as the query can return several |
                '+-------------------------------------------------------------+
                result.category_id = myReader.GetValue(myReader.GetOrdinal("Category_id")).ToString
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category_name"))) Then
                    result.category_name = myReader.GetValue(myReader.GetOrdinal("Category_name"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category_description"))) Then
                    result.category_desc = myReader.GetValue(myReader.GetOrdinal("Category_description")).ToString
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("status"))) Then
                    result.status = myReader.GetValue(myReader.GetOrdinal("status")).ToString
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lng"))) Then
                    result.lng = myReader.GetValue(myReader.GetOrdinal("lng")).ToString
                End If
            End If
            myReader.Close()
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
    ''' getCompCategory: Get a company category                         
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 21-11-2012   1.0     Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Function getCompCategory(ByVal pSql As String) As stCategory

        Dim sCommand As String
        Dim myReader As MySqlDataReader
        Dim result As stCategory

        Const sIdm As String = "dataaccess.getCompCategory"
        Try
            initDB()

            sCommand = "Select * From company_category Where " & pSql

            Dim myConnection As New MySqlConnection(ConnectionString)
            Dim myCommand As New MySqlCommand(sCommand, myConnection)
            myConnection.Open()
            myReader = myCommand.ExecuteReader()

            If myReader.Read() Then
                '+-------------------------------------------------------------+
                '| Read only the first record, as the query can return several |
                '+-------------------------------------------------------------+
                result.category_id = myReader.GetValue(myReader.GetOrdinal("Category_id")).ToString
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category_name"))) Then
                    result.category_name = myReader.GetValue(myReader.GetOrdinal("Category_name"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category_description"))) Then
                    result.category_desc = myReader.GetValue(myReader.GetOrdinal("Category_description")).ToString
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("status"))) Then
                    result.status = myReader.GetValue(myReader.GetOrdinal("status")).ToString
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lng"))) Then
                    result.lng = myReader.GetValue(myReader.GetOrdinal("lng")).ToString
                End If
            End If
            myReader.Close()
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
    ''' getRegion: Get a region                         
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 16-11-2011   1.0     Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Function getRegion(ByVal pSql As String) As stRegion

        Dim sCommand As String
        Dim myReader As MySqlDataReader
        Dim result As stRegion

        Const sIdm As String = "dataaccess.getRegion"
        Try
            initDB()

            sCommand = "Select * From regions Where " & pSql

            Dim myConnection As New MySqlConnection(ConnectionString)
            Dim myCommand As New MySqlCommand(sCommand, myConnection)
            myConnection.Open()
            myReader = myCommand.ExecuteReader()

            If myReader.Read() Then
                '+-------------------------------------------------------------+
                '| Read only the first record, as the query can return several |
                '+-------------------------------------------------------------+
                result.id = myReader.GetValue(myReader.GetOrdinal("id")).ToString
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("name"))) Then
                    result.name = myReader.GetValue(myReader.GetOrdinal("name"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("country"))) Then
                    result.country = myReader.GetValue(myReader.GetOrdinal("country")).ToString
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("country_code"))) Then
                    result.country_code = myReader.GetValue(myReader.GetOrdinal("country_code")).ToString
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lat"))) Then
                    result.lat = myReader.GetValue(myReader.GetOrdinal("lat")).ToString
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lon"))) Then
                    result.lon = myReader.GetValue(myReader.GetOrdinal("lon")).ToString
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("radius"))) Then
                    result.radius = myReader.GetValue(myReader.GetOrdinal("radius")).ToString
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lng"))) Then
                    result.lng = myReader.GetValue(myReader.GetOrdinal("lng")).ToString
                End If
            End If
            myReader.Close()
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
    ''' getBusiness: Get a business                         
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 23-11-2012   1.0     Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Function getBusiness(ByVal pSql As String) As stBusiness

        Dim sCommand As String
        Dim myReader As MySqlDataReader
        Dim result As stBusiness

        Const sIdm As String = "dataaccess.getBusiness"
        Try
            initDB()

            sCommand = "Select * From small_business Where " & pSql

            Dim myConnection As New MySqlConnection(ConnectionString)
            Dim myCommand As New MySqlCommand(sCommand, myConnection)
            myConnection.Open()
            myReader = myCommand.ExecuteReader()

            If myReader.Read() Then
                '+-------------------------------------------------------------+
                '| Read only the first record, as the query can return several |
                '+-------------------------------------------------------------+
                result.SB_id = myReader.GetValue(myReader.GetOrdinal("SB_id")).ToString
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("User_id"))) Then
                    result.User_id = myReader.GetValue(myReader.GetOrdinal("User_id"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Name"))) Then
                    result.Name = myReader.GetValue(myReader.GetOrdinal("Name")).ToString
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Area"))) Then
                    result.Area = myReader.GetValue(myReader.GetOrdinal("Area"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("SB_average_mark"))) Then
                    result.SB_average_mark = myReader.GetValue(myReader.GetOrdinal("SB_average_mark"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("SB_votes"))) Then
                    result.SB_votes = myReader.GetValue(myReader.GetOrdinal("SB_votes"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lng"))) Then
                    result.lng = myReader.GetValue(myReader.GetOrdinal("lng")).ToString
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category"))) Then
                    result.Category = myReader.GetValue(myReader.GetOrdinal("Category"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Address"))) Then
                    result.Address = myReader.GetValue(myReader.GetOrdinal("Address")).ToString
                End If
            End If
            myReader.Close()
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
    ''' getBusiness: Get a business                         
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 27-11-2012   1.0     Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Function getHub(ByVal pSql As String) As stHub

        Dim sCommand As String
        Dim myReader As MySqlDataReader
        Dim result As stHub

        Const sIdm As String = "dataaccess.getHub"
        Try
            initDB()

            sCommand = "Select * From hub Where " & pSql

            Dim myConnection As New MySqlConnection(ConnectionString)
            Dim myCommand As New MySqlCommand(sCommand, myConnection)
            myConnection.Open()
            myReader = myCommand.ExecuteReader()

            If myReader.Read() Then
                '+-------------------------------------------------------------+
                '| Read only the first record, as the query can return several |
                '+-------------------------------------------------------------+
                result.Hub_id = myReader.GetValue(myReader.GetOrdinal("Hub_id")).ToString
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("User_id"))) Then
                    result.User_id = myReader.GetValue(myReader.GetOrdinal("User_id"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Name"))) Then
                    result.Name = myReader.GetValue(myReader.GetOrdinal("Name")).ToString
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Area"))) Then
                    result.Area = myReader.GetValue(myReader.GetOrdinal("Area"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Hub_average_mark"))) Then
                    result.Hub_average_mark = myReader.GetValue(myReader.GetOrdinal("Hub_average_mark"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Hub_votes"))) Then
                    result.Hub_votes = myReader.GetValue(myReader.GetOrdinal("Hub_votes"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lng"))) Then
                    result.lng = myReader.GetValue(myReader.GetOrdinal("lng")).ToString
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category"))) Then
                    result.Category = myReader.GetValue(myReader.GetOrdinal("Category"))
                End If
                If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Address"))) Then
                    result.Address = myReader.GetValue(myReader.GetOrdinal("Address")).ToString
                End If
            End If
            myReader.Close()
            myCommand.Dispose()

            Return result

        Catch ex As Exception
            writeTrace(1, "ERROR in " & sIdm & ": " & ex.Message, sIdm)
            Return Nothing
        Finally
            writeTrace(2, "End", sIdm)
        End Try

    End Function

#End Region

End Class
