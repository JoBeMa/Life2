'Database Access Funtions Copyright (C) 2013 Alcatel·Lucent 
'This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. 
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
'You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.IO
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Net
Imports System.Net.Mail

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la siguiente línea.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://Life_2_0_DB/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class DBService
    Inherits System.Web.Services.WebService

    Public Const EventRegisterUser As Integer = 1

    Public Const ErrorResult As Integer = -1

    Public Class UserProfile
        Public User_id As Integer
        Public Login As String
        Public Role As Integer
        Public Password As String
        Public Name As String
        Public Email As String
        Public telephonenumber As String
        Public Picture As String
        Public Language As String
        Public Home_area_lat As String
        Public Home_area_lon As String
        Public Home_area_radius As String
        Public Last_location_timestamp As String
        Public Last_location_lat As String
        Public Last_location_lon As String
        Public Notification_level As String
        Public Promoter_id As String
        Public User_average_mark As String
        Public User_votes As String
        Public Enabled As Integer
        Public Distance As Long
        Public region As String
        Public address As String
        Public adminRegion As String
    End Class

    Enum Role
        User
        Promoter
        Hub
        Small_bussines
        Technical_Admin
        Moderator_Admin
        Sys_Maintenance
    End Enum

    Public env As Environment

    Private Function CDBStr(ByVal psString As String) As String
        CDBStr = IIf(Trim(psString) <> "", "'" & Trim(Replace(Replace(psString, "\", "\\"), "'", "\'")) & "'", "Null")
    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' dbRegisterUser: Create user profile data                         
    ''' </summary>
    ''' <remarks>
    ''' Returns 0 in case of error, otherwise return the user identity
    ''' </remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 16-11-2011   1.0     Creation
    ''' 03-05-2012   1.2     Add Telephone parameter
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function dbRegisterUser(ByVal Login As String, _
                                    ByVal Role As String, _
                                    ByVal Password As String, _
                                    ByVal Name As String, _
                                    ByVal email As String, _
                                    ByVal telephonenumber As String, _
                                    ByVal Language As String, _
                                    ByVal Home_area_lat As String, _
                                    ByVal Home_area_lon As String, _
                                    ByVal Home_area_radius As String, _
                                    ByVal Notification_level As String, _
                                    ByVal region As String, _
                                    ByRef ErrorMessage As String) As Integer

        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile


        Const sIdm As String = "DBService.dbRegisterUser"
        env = New Environment("Life_2.0.DBService")

        Try

            env.WriteTrace(3, "Register user:" & Login, sIdm)

            sSql = "Login = '" & Login & "'" ' OR email = '" & email & "'"

            stUserProfile = env.DataAccess.getUserProfile(sSql)

            If stUserProfile.User_id = 0 Then

                If Trim(Login) <> "" And _
                   Trim(Role) <> "" And _
                   Trim(Password) <> "" And _
                   Trim(Name) <> "" And _
                   Trim(email) <> "" And _
                   Trim(Language) <> "" And _
                   Trim(Home_area_lat) <> "" And _
                   Trim(Home_area_lon) <> "" And _
                   Trim(Home_area_radius) <> "" And _
                   Trim(Notification_level) <> "" Then

                    bOK = env.DataAccess.DBinsert("user_profile", _
                                                  "Login", CDBStr(Login), _
                                                  "uid", CDBStr(Login), _
                                                  "Role", Role, _
                                                  "Password", CDBStr(Password), _
                                                  "userpassword", CDBStr(Password), _
                                                  "Name", CDBStr(Name), _
                                                  "cn", CDBStr(Name), _
                                                  "email", CDBStr(email), _
                                                  "telephonenumber", CDBStr(telephonenumber), _
                                                  "Language", CDBStr(Language), _
                                                  "Home_area_lat", Home_area_lat.Replace(",", "."), _
                                                  "Home_area_lon", Home_area_lon.Replace(",", "."), _
                                                  "Home_area_radius", Home_area_radius.Replace(",", "."), _
                                                  "Last_loc_lat", Home_area_lat.Replace(",", "."), _
                                                  "last_loc_lon", Home_area_lon.Replace(",", "."), _
                                                  "region", CDBStr(region.ToString), _
                                                  "Notification_level", Notification_level)

                    If bOK Then
                        env.WriteTrace(3, "User registered OK, read the user identity", sIdm)

                        stUserProfile = env.DataAccess.getUserProfile(Login)

                        If stUserProfile.User_id <> 0 Then
                            env.WriteTrace(3, "User identity = " & stUserProfile.User_id.ToString, sIdm)
                            ErrorMessage = ""

                            Notify(EventRegisterUser, _
                                   Login, _
                                   stUserProfile.User_id, _
                                   Role, _
                                   Name, _
                                   email, _
                                   Language)

                            iReturn = stUserProfile.User_id
                        Else
                            env.WriteTrace(3, "User not registered, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User not registered, error in DataAccess module", sIdm)
                        ErrorMessage = "InternalErrorInDb"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "Missing Mandatory Parameter", sIdm)
                    ErrorMessage = "MissingMandatoryParameter"
                    iReturn = ErrorResult
                End If

            Else
                env.WriteTrace(3, "User already registered", sIdm)
                ErrorMessage = "UserAlreadyRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "ERRORin " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    Public Shared Function encode(ByVal str As String) As String
        'supply True as the construction parameter to indicate
        'that you wanted the class to emit BOM (Byte Order Mark)
        'NOTE: this BOM value is the indicator of a UTF-8 string
        Dim utf8Encoding As New System.Text.UTF8Encoding(True)
        Dim encodedString() As Byte

        encodedString = utf8Encoding.GetBytes(str)

        Return utf8Encoding.GetString(encodedString)
    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' dbUpdateUser: Update user profile data                         
    ''' </summary>
    ''' <remarks>
    ''' Returns 0 in case of error, otherwise return the user identity
    ''' </remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 16-11-2011   1.0     Creation
    ''' 03-05-2012   1.2     Add Telephone parameter
    ''' 21-05-2012   1.3     Add SkillsVisibility and Interests Visibility
    ''' 10-05-2013   xxx     Add address field
    ''' 
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function dbUpdateUser(ByVal Login As String, _
                                 ByVal Role As String, _
                                 ByVal Password As String, _
                                 ByVal Name As String, _
                                 ByVal Email As String, _
                                 ByVal telephonenumber As String, _
                                 ByVal Picture As String, _
                                 ByVal Language As String, _
                                 ByVal Home_area_lat As String, _
                                 ByVal Home_area_lon As String, _
                                 ByVal Home_area_radius As String, _
                                 ByVal Last_location_timestamp As String, _
                                 ByVal Last_location_lat As String, _
                                 ByVal Last_location_lon As String, _
                                 ByVal Notification_level As String, _
                                 ByVal Promoter_id As String, _
                                 ByVal User_average_mark As String, _
                                 ByVal User_votes As String, _
                                 ByVal Enabled As Integer, _
                                 ByVal SkillsVisibility As Integer, _
                                 ByVal InterestsVisibility As Integer, _
                                 ByVal region As String, _
                                 ByVal address As String, _
                                 ByVal adminRegion As String, _
                                 ByRef ErrorMessage As String) As Integer

        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sCommand(), sSql, sTemp As String
        Dim i As Integer

        Dim stUserProfile As DataAccess.UserProfile

        Const sIdm As String = "DBService.dbUpdateUser"
        env = New Environment("Life_2.0.DBService")

        Try
            env.WriteTrace(3, "Update user:" & Login, sIdm)

            'If Email <> "" Then
            '    sSql = "Login = '" & Login & "' AND email = '" & Email & "'"
            'Else
            sSql = Login
            'End If

            stUserProfile = env.DataAccess.getUserProfile(sSql)

            If stUserProfile.User_id <> 0 Then

                '+--------------------------------------------------------+
                '| Check if the parameteris present or has to be resetted |
                '+--------------------------------------------------------+

                i = 0
                If Role <> "" Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "Role"
                    If Role = "@@" Then Role = ""
                    sCommand(i + 1) = CDBStr(Role)
                    i += 2
                End If
                If Password <> "" Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "Password"
                    If Password = "@@" Then Password = ""
                    sCommand(i + 1) = CDBStr(Password)
                    i += 2
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "userpassword"
                    sCommand(i + 1) = CDBStr(Password)
                    i += 2
                End If
                If Name <> "" Then
                    sTemp = encode(Name)
                    env.WriteTrace(3, "Name: " & sTemp, sIdm)
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "Name"
                    If Name = "@@" Then Name = ""
                    sCommand(i + 1) = CDBStr(Name)
                    i += 2
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "cn"
                    sCommand(i + 1) = CDBStr(Name)
                    i += 2
                End If
                If Email <> "" Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "Email"
                    If Email = "@@" Then Email = ""
                    sCommand(i + 1) = CDBStr(Email)
                    i += 2
                End If
                If telephonenumber <> "" Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "telephonenumber"
                    If telephonenumber = "@@" Then telephonenumber = ""
                    sCommand(i + 1) = CDBStr(telephonenumber)
                    i += 2
                End If
                If Picture <> "" Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "Picture"
                    If Picture = "@@" Then Picture = ""
                    sCommand(i + 1) = CDBStr(Picture)
                    i += 2
                End If
                If Language <> "" Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "Language"
                    If Language = "@@" Then Language = ""
                    sCommand(i + 1) = CDBStr(Language)
                    i += 2
                End If
                If Home_area_lat <> "" Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "Home_area_lat"
                    If Home_area_lat = "@@" Then Home_area_lat = ""
                    sCommand(i + 1) = Home_area_lat.Replace(",", ".")
                    i += 2
                End If
                If Home_area_lon <> "" Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "Home_area_lon"
                    If Home_area_lon = "@@" Then Home_area_lon = ""
                    sCommand(i + 1) = Home_area_lon.Replace(",", ".")
                    i += 2
                End If
                If Home_area_radius <> "" Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "Home_area_radius"
                    If Home_area_radius = "@@" Then Home_area_radius = ""
                    sCommand(i + 1) = Home_area_radius.Replace(",", ".")
                    i += 2
                End If
                If Last_location_timestamp <> "" Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "Last_loc_timestamp"
                    If Last_location_timestamp = "@@" Then Last_location_timestamp = ""
                    sCommand(i + 1) = env.DataAccess.CDBDate(Functions.getDate(Last_location_timestamp))
                    i += 2
                End If
                If Last_location_lat <> "" Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "Last_loc_lat"
                    If Last_location_lat = "@@" Then Last_location_lat = ""
                    sCommand(i + 1) = Last_location_lat.Replace(",", ".")
                    i += 2
                End If
                If Last_location_lon <> "" Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "last_loc_lon"
                    If Last_location_lon = "@@" Then Last_location_lon = ""
                    sCommand(i + 1) = Last_location_lon.Replace(",", ".")
                    i += 2
                End If
                If Notification_level <> "" Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "Notification_level"
                    If Notification_level = "@@" Then Notification_level = ""
                    sCommand(i + 1) = Notification_level
                    i += 2
                End If
                If Promoter_id <> "" Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "Promoter_id"
                    If Promoter_id = "@@" Then Promoter_id = ""
                    sCommand(i + 1) = CDBStr(Promoter_id)
                    i += 2
                End If
                If User_average_mark <> "" Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "User_average_mark"
                    If User_average_mark = "@@" Then User_average_mark = ""
                    sCommand(i + 1) = "'" & User_average_mark & "'"
                    i += 2
                End If
                If User_votes <> "" Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "User_votes"
                    If User_votes = "@@" Then User_votes = ""
                    sCommand(i + 1) = "'" & User_votes & "'"
                    i += 2
                End If
                If Not IsNothing(Enabled) Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "Enabled"
                    sCommand(i + 1) = Enabled
                    i += 2
                End If
                If Not IsNothing(SkillsVisibility) Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "SkillsVisibility"
                    sCommand(i + 1) = SkillsVisibility
                    i += 2
                End If
                If Not IsNothing(InterestsVisibility) Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "InterestsVisibility"
                    sCommand(i + 1) = InterestsVisibility
                    i += 2
                End If
                If Not IsNothing(region) Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "region"
                    sCommand(i + 1) = CDBStr(region)
                    i += 2
                End If
                If address <> "" Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "address"
                    If address = "@@" Then address = ""
                    sCommand(i + 1) = CDBStr(address)
                    i += 2
                End If
                If adminRegion <> "" Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "adminRegion"
                    If adminRegion = "@@" Then adminRegion = ""
                    sCommand(i + 1) = CDBStr(adminRegion)
                    i += 2
                End If

                bOK = env.DataAccess.DBupdate("user_profile", _
                                              "Login = '" & Login & "'", _
                                              sCommand)

                If bOK Then
                    env.WriteTrace(3, "User updated OK", sIdm)

                    stUserProfile = env.DataAccess.getUserProfile(Login)

                    If stUserProfile.User_id <> 0 Then
                        env.WriteTrace(3, "User identity = " & stUserProfile.User_id.ToString, sIdm)
                        ErrorMessage = ""
                        iReturn = stUserProfile.User_id
                    Else
                        env.WriteTrace(3, "User not registered, error in DataAccess module", sIdm)
                        ErrorMessage = "InternalErrorInDb"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User not registered, error in DataAccess module", sIdm)
                    ErrorMessage = "InternalErrorInDb"
                    iReturn = ErrorResult
                End If

            Else
                If Email <> "" Then
                    env.WriteTrace(3, "Wrong e-mail address", sIdm)
                    ErrorMessage = "WrongEmail"
                Else
                    env.WriteTrace(3, "User does not exist", sIdm)
                    ErrorMessage = "UserDoesNotExist"
                End If
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "ERRORin " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' dbUpdateUser: Update user profile data                         
    ''' </summary>
    ''' <remarks>
    ''' Returns 0 in case of error, otherwise return the user identity
    ''' </remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 16-11-2011   1.0     Creation
    ''' 07-02-2012   1.1     Return all the values of the profile
    ''' 03-05-2012   1.2     Add Telephone parameter
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function dbUserLogin(ByVal Login As String, _
                                 ByVal Password As String, _
                                 ByRef Role As Integer, _
                                 ByRef Email As String, _
                                 ByRef telephonenumber As String, _
                                 ByRef Name As String, _
                                 ByRef Picture As String, _
                                 ByRef Language As String, _
                                 ByRef Home_area_lat As String, _
                                 ByRef Home_area_lon As String, _
                                 ByRef Home_area_radius As String, _
                                 ByRef Last_location_timestamp As String, _
                                 ByRef Last_location_lat As String, _
                                 ByRef Last_location_lon As String, _
                                 ByRef Notification_level As String, _
                                 ByRef Promoter_id As String, _
                                 ByRef User_average_mark As String, _
                                 ByRef User_votes As String, _
                                 ByRef Enabled As Integer, _
                                 ByRef region As String, _
                                 ByRef ErrorMessage As String) As Integer

        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile


        Const sIdm As String = "DBService.dbUserLogin"
        env = New Environment("Life_2.0.DBService")

        Try

            env.WriteTrace(3, "Login user:" & Login, sIdm)

            sSql = "Login = " & CDBStr(Login) & " AND Password = " & CDBStr(Password)

            stUserProfile = env.DataAccess.getUserProfile(sSql)

            If stUserProfile.User_id <> 0 Then
                Dim sServer As String = Config.GetConfigVal("files", "serverUrl")

                iReturn = stUserProfile.User_id
                Email = stUserProfile.Email
                telephonenumber = stUserProfile.telephonenumber
                Name = stUserProfile.Name
                Role = stUserProfile.Role
                If stUserProfile.Picture <> "" Then
                    Picture = sServer & stUserProfile.Picture
                Else
                    Picture = ""
                End If
                Language = stUserProfile.Language
                Home_area_lat = stUserProfile.Home_area_lat
                Home_area_lon = stUserProfile.Home_area_lon
                Home_area_radius = stUserProfile.Home_area_radius
                Last_location_timestamp = stUserProfile.Last_loc_timestamp
                Last_location_lat = stUserProfile.Last_loc_lat
                Last_location_lon = stUserProfile.last_loc_lon
                Notification_level = stUserProfile.Notification_level
                Promoter_id = stUserProfile.Promoter_id
                User_average_mark = stUserProfile.User_average_mark
                User_votes = stUserProfile.User_votes
                Enabled = stUserProfile.Enabled
                region = stUserProfile.region
                iReturn = stUserProfile.User_id
                ErrorMessage = ""
                env.WriteTrace(3, "User logged in OK", sIdm)

            Else
                env.WriteTrace(3, "User not logged", sIdm)
                ErrorMessage = "LoginError"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "ERRORin " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' dbDeleteUser: Delete user profile data                         
    ''' </summary>
    ''' <remarks>
    ''' Returns 0 in case of error, otherwise return the user identity
    ''' </remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 16-11-2011   1.0     Creation
    ''' 26-02-2013           Delete the offers posted by the user
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function dbDeleteUser(ByVal Login As String, _
                                  ByRef ErrorMessage As String) As Integer

        Dim bOK As Boolean
        Dim iReturn, iResult As Integer
        Dim stUserProfile As DataAccess.UserProfile

        Const sIdm As String = "DBService.dbDeleteUser"
        env = New Environment("Life_2.0.DBService")

        Try

            env.WriteTrace(3, "Delete user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)
            iReturn = stUserProfile.User_id

            If iReturn <> 0 Then

                bOK = env.DataAccess.DBdelete("user_profile", _
                                              "Login=" & CDBStr(Login))

                If bOK Then
                    env.WriteTrace(3, "User deleted OK", sIdm)

                    Dim WsLife20E As New wsEngService.ENGService

                    WsLife20E.Url = Config.GetConfigVal("Engine", "Url")
                    env.WriteTrace(3, "WsLife20E.Url = " & WsLife20E.Url, sIdm)
                    WsLife20E.Timeout = System.Threading.Timeout.Infinite
                    WsLife20E.PreAuthenticate = True
                    WsLife20E.Credentials = System.Net.CredentialCache.DefaultCredentials

                    iResult = WsLife20E.DeleteUserOffers(stUserProfile.User_id, ErrorMessage)

                    env.WriteTrace(3, "Delete user's result: " & iResult.ToString, sIdm)
                Else
                    env.WriteTrace(3, "User not deleted, error in DataAccess module", sIdm)
                    ErrorMessage = "InternalErrorInDb"
                    iReturn = ErrorResult
                End If

            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "ERRORin " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try


    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' dbSetSkillsVisiblity: set the Skills Visiblity of a user                         
    ''' </summary>
    ''' <remarks>
    ''' Returns 0 in case of error, otherwise return the user identity
    ''' Visibility:
    ''' 0 = false --> Skills NOT visible in profile
    ''' 1 = true  --> Skills visible in profile
    ''' </remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 21-05-2012   1.0     Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function dbSetSkillsVisiblity(ByVal Login As String, _
                                          ByVal Visibility As Integer, _
                                          ByRef ErrorMessage As String) As Integer

        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sCommand(), sSql As String
        Dim i As Integer
        Dim stUserProfile As DataAccess.UserProfile

        Const sIdm As String = "DBService.dbSetSkillsVisiblity"
        env = New Environment("Life_2.0.DBService")

        Try
            sSql = Login

            stUserProfile = env.DataAccess.getUserProfile(sSql)

            If stUserProfile.User_id <> 0 Then

                '+--------------------------------------------------------+
                '| Check if the parameteris present or has to be resetted |
                '+--------------------------------------------------------+
                i = 0
                If Not IsNothing(Visibility) Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "SkillsVisibility"
                    sCommand(i + 1) = Visibility
                    i += 2
                End If

                bOK = env.DataAccess.DBupdate("user_profile", _
                                              "Login = '" & Login & "'", _
                                              sCommand)

                If bOK Then
                    env.WriteTrace(3, "User updated OK", sIdm)

                    stUserProfile = env.DataAccess.getUserProfile(Login)

                    If stUserProfile.User_id <> 0 Then
                        env.WriteTrace(3, "User identity = " & stUserProfile.User_id.ToString, sIdm)
                        ErrorMessage = ""
                        iReturn = stUserProfile.User_id
                    Else
                        env.WriteTrace(3, "User not registered, error in DataAccess module", sIdm)
                        ErrorMessage = "InternalErrorInDb"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User not registered, error in DataAccess module", sIdm)
                    ErrorMessage = "InternalErrorInDb"
                    iReturn = ErrorResult
                End If

            Else
                env.WriteTrace(3, "User does not exist", sIdm)
                ErrorMessage = "UserDoesNotExist"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "ERRORin " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try


    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' dbSetInterestsVisiblity: set the Interests Visiblity of a user                         
    ''' </summary>
    ''' <remarks>
    ''' Returns 0 in case of error, otherwise return the user identity
    ''' Visibility:
    ''' 0 = false --> Interests NOT visible in profile
    ''' 1 = true  --> Interests visible in profile
    ''' </remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 21-05-2012   1.0     Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function dbSetInterestsVisiblity(ByVal Login As String, _
                                             ByVal Visibility As Integer, _
                                             ByRef ErrorMessage As String) As Integer

        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sCommand(), sSql As String
        Dim i As Integer
        Dim stUserProfile As DataAccess.UserProfile

        Const sIdm As String = "DBService.dbSetInterestsVisiblity"
        env = New Environment("Life_2.0.DBService")

        Try
            sSql = Login

            stUserProfile = env.DataAccess.getUserProfile(sSql)

            If stUserProfile.User_id <> 0 Then

                '+--------------------------------------------------------+
                '| Check if the parameteris present or has to be resetted |
                '+--------------------------------------------------------+
                i = 0
                If Not IsNothing(Visibility) Then
                    ReDim Preserve sCommand(i + 1)
                    sCommand(i) = "InterestsVisibility"
                    sCommand(i + 1) = Visibility
                    i += 2
                End If

                bOK = env.DataAccess.DBupdate("user_profile", _
                                              "Login = '" & Login & "'", _
                                              sCommand)

                If bOK Then
                    env.WriteTrace(3, "User updated OK", sIdm)

                    stUserProfile = env.DataAccess.getUserProfile(Login)

                    If stUserProfile.User_id <> 0 Then
                        env.WriteTrace(3, "User identity = " & stUserProfile.User_id.ToString, sIdm)
                        ErrorMessage = ""
                        iReturn = stUserProfile.User_id
                    Else
                        env.WriteTrace(3, "User not registered, error in DataAccess module", sIdm)
                        ErrorMessage = "InternalErrorInDb"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User not registered, error in DataAccess module", sIdm)
                    ErrorMessage = "InternalErrorInDb"
                    iReturn = ErrorResult
                End If

            Else
                env.WriteTrace(3, "User does not exist", sIdm)
                ErrorMessage = "UserDoesNotExist"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "ERRORin " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try


    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' sqlDistance: Construct SQL sentence to get items based on distance                         
    ''' </summary>
    ''' <remarks>
    ''' Returns 0 in case of error, otherwise return the user identity
    ''' </remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 13-12-2011   1.0     Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Private Function sqlDistance(ByVal inSql As String, _
                                 ByVal sTable As String, _
                                 ByVal sUser As String) As String

        Dim sOutputSql, inputSql, ErrorMessage, sSql1, sDistance, sLat, sLon, sTemp(), sWhere, userSql, inputSql2 As String
        Dim iPos1, iPos2 As Integer
        Dim bCount As Boolean


        Const sIdm As String = "DBService.sqlDistance"
        env = New Environment("Life_2.0.DBService")

        Try
            inputSql2 = LCase(inSql)

            env.WriteTrace(3, "Input SQL sub-sentence:" & inputSql2, sIdm)

            inputSql = inputSql2.Replace("<![cdata[", "").Replace("]]>", "")

            env.WriteTrace(3, "Input SQL sub-sentence (after cleaning):" & inputSql, sIdm)

            If inputSql.Contains("count") Then
                bCount = True
                inputSql = inputSql.Replace("count", "")
            Else
                bCount = False
            End If

            If Not inputSql.Contains("language") Then
                If sUser <> "" Then
                    userSql = sqlLang(sUser)
                End If
            End If

            If inputSql.Contains("distance") And inputSql.Contains("lat") And inputSql.Contains("lon") Then
                '+-------------------------------------------------------------------------+
                '| Parse the string to get the individual parameters, a sample sql can be: |
                '| user_votes > 100 and distance < 5 and lat=0.33453 and lon=34.9857984    |
                '+-------------------------------------------------------------------------+

                '+-------------------------------------------+
                '| Get the starting position of the sentence |
                '+-------------------------------------------+
                iPos1 = Trim(inputSql).IndexOf("distance")

                env.WriteTrace(3, "iPos1:" & iPos1.ToString, sIdm)

                '+------------------------------------------------------------------------------+
                '| Extract the first part of the SQL sentence, to do it, extract the last 'and' |
                '+------------------------------------------------------------------------------+
                'sSql1 = inputSql.Substring(0, iPos1 - 1) '.Replace("and", "")
                If iPos1 <> 0 Then
                    sSql1 = StrReverse(Replace(StrReverse(inputSql.Substring(0, iPos1 - 1)), StrReverse("and"), StrReverse(""), , 1))
                Else
                    sSql1 = ""
                End If

                '+------------------------------------------------+
                '| Get position of the end of 'distance' sentence |
                '+------------------------------------------------+
                iPos2 = inputSql.IndexOf("and", iPos1)
                '+----------------------------+
                '| Get the distance condition |
                '+----------------------------+
                sDistance = inputSql.Substring(iPos1, iPos2 - iPos1)
                '+------------------+
                '| Get the latitude |
                '+------------------+
                iPos1 = inputSql.IndexOf("lat")
                iPos2 = inputSql.IndexOf("and", iPos1)
                sLat = inputSql.Substring(iPos1, iPos2 - iPos1)
                sTemp = sLat.Split("=")
                sLat = sTemp(1)
                '+-------------------+
                '| Get the longitide |
                '+-------------------+
                iPos1 = inputSql.IndexOf("lon")
                iPos2 = inputSql.Length
                sLon = inputSql.Substring(iPos1, iPos2 - iPos1)
                sTemp = sLon.Split("=")
                sLon = sTemp(1)

                '+-------------------------------------------------------------------------------------------------+
                '| We apply the Haversine formula to calculate the distance between two points on an esphere.      |
                '| The distance is calculated in Km, the formula includes the Earth average radius that is 6371 Km |
                '+-------------------------------------------------------------------------------------------------+
                If sSql1 <> "" Then
                    If userSql <> "" Then
                        sWhere = " AND " & userSql & " AND " & sSql1
                    Else
                        sWhere = " AND " & sSql1
                    End If
                Else
                    If userSql <> "" Then
                        sWhere = " AND " & userSql
                    Else
                        sWhere = ""
                    End If
                End If


                Select Case sTable

                    Case "user_profile"

                        If bCount Then
                            sOutputSql = "SELECT COUNT(*) FROM (SELECT *, " & _
                                    "( 6371 * ACOS( COS( RADIANS(" & sLat & ") ) * COS( RADIANS(Last_loc_lat) ) * COS( RADIANS(last_loc_lon) - RADIANS(" & sLon & ") ) + SIN( RADIANS(" & sLat & ") ) * SIN( RADIANS(Last_loc_lat) ) ) ) AS distance" & _
                                    " FROM user_profile HAVING " & sDistance & sWhere & ") as T1"

                        Else
                            sOutputSql = "SELECT *, " & _
                                     "( 6371 * ACOS( COS( RADIANS(" & sLat & ") ) * COS( RADIANS(Last_loc_lat) ) * COS( RADIANS(last_loc_lon) - RADIANS(" & sLon & ") ) + SIN( RADIANS(" & sLat & ") ) * SIN( RADIANS(Last_loc_lat) ) ) ) AS distance" & _
                                     " FROM user_profile HAVING " & sDistance & sWhere & " ORDER BY distance"
                        End If

                End Select

            Else
                If inputSql <> "" Then
                    If userSql <> "" Then
                        sWhere = " WHERE " & userSql & " AND " & inputSql
                    Else
                        sWhere = " WHERE " & inputSql
                    End If
                Else
                    If userSql <> "" Then
                        sWhere = " WHERE " & userSql
                    Else
                        sWhere = ""
                    End If
                End If

                If bCount Then
                    sOutputSql = "SELECT COUNT(*) FROM (SELECT * FROM user_profile " & sWhere & ") as T1"

                Else
                    sOutputSql = "SELECT * FROM user_profile " & sWhere & " ORDER BY User_Id"
                End If

            End If

            Return sOutputSql

        Catch ex As Exception
            ErrorMessage = "ERRORin " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ""
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' sqlLang: Construct SQL sentence to get items based on language                         
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 24-01-2012   1.1     Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Private Function sqlLang(ByVal sUser As String) As String

        Dim sOutputSql, ErrorMessage, sSql1, sTemp() As String
        Dim i As Integer

        Dim stUserProfile As DataAccess.UserProfile

        Const sIdm As String = "DBService.sqlLang"
        env = New Environment("Life_2.0.DBService")

        Try
            sSql1 = ""
            env.WriteTrace(3, "sUser: " & sUser, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(sUser)

            If stUserProfile.User_id <> 0 Then
                '+------------------------+
                '| Get the language field |
                '+------------------------+
                sTemp = stUserProfile.Language.Split(",")

                For i = 0 To sTemp.Length - 1
                    If i = 0 Then
                        sSql1 &= "language Like '%" & Trim(sTemp(i)) & "%'"
                    Else
                        sSql1 &= " OR " & "language Like '%" & Trim(sTemp(i)) & "%'"
                    End If
                Next

                sOutputSql = " (" & sSql1 & ") "
            Else
                sOutputSql = ""
            End If

            Return sOutputSql

        Catch ex As Exception
            ErrorMessage = "ERRORin " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ""
        End Try

    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' dbReadUser: Get user profile data                         
    ''' </summary>
    ''' <remarks>
    ''' Returns 0 in case of error, otherwise return the user identity
    ''' </remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 16-11-2011   1.0     Creation
    ''' 10-05-2013   xxx     Add address, SkillsVisibility, InterestsVisibility
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function dbReadUser(ByVal Login As String, _
                                ByRef Role As Integer, _
                                ByRef Email As String, _
                                ByRef Name As String, _
                                ByRef Picture As String, _
                                ByRef Language As String, _
                                ByRef telephonenumber As String, _
                                ByRef Home_area_lat As String, _
                                ByRef Home_area_lon As String, _
                                ByRef Home_area_radius As String, _
                                ByRef Last_location_timestamp As String, _
                                ByRef Last_location_lat As String, _
                                ByRef Last_location_lon As String, _
                                ByRef Notification_level As String, _
                                ByRef Promoter_id As String, _
                                ByRef User_average_mark As String, _
                                ByRef User_votes As String, _
                                ByRef Enabled As Integer, _
                                ByRef region As String, _
                                ByRef address As String, _
                                ByRef SkillsVisibility As Integer, _
                                ByRef InterestsVisibility As Integer, _
                                ByRef adminRegion As String, _
                                ByRef ErrorMessage As String) As Integer

        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile


        Const sIdm As String = "DBService.dbReadUser"
        env = New Environment("Life_2.0.DBService")

        Try

            env.WriteTrace(3, "Login user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                Dim sServer As String = Config.GetConfigVal("files", "serverUrl")

                iReturn = stUserProfile.User_id
                Email = stUserProfile.Email
                telephonenumber = stUserProfile.telephonenumber
                Name = stUserProfile.Name
                Role = stUserProfile.Role
                If stUserProfile.Picture <> "" Then
                    Picture = sServer & stUserProfile.Picture
                Else
                    Picture = ""
                End If
                Language = stUserProfile.Language
                Home_area_lat = stUserProfile.Home_area_lat
                Home_area_lon = stUserProfile.Home_area_lon
                Home_area_radius = stUserProfile.Home_area_radius
                Last_location_timestamp = stUserProfile.Last_loc_timestamp
                Last_location_lat = stUserProfile.Last_loc_lat
                Last_location_lon = stUserProfile.last_loc_lon
                Notification_level = stUserProfile.Notification_level
                Promoter_id = stUserProfile.Promoter_id
                User_average_mark = stUserProfile.User_average_mark
                User_votes = stUserProfile.User_votes
                Enabled = stUserProfile.Enabled
                region = stUserProfile.region
                address = stUserProfile.address
                SkillsVisibility = stUserProfile.SkillsVisibility
                InterestsVisibility = stUserProfile.InterestsVisibility
                adminRegion = stUserProfile.adminRegion

                ErrorMessage = ""
                env.WriteTrace(3, "User read OK", sIdm)

            Else
                env.WriteTrace(3, "User not read", sIdm)
                ErrorMessage = "ErrorReadingUserProfile"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "ERRORin " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' getUserList: Get user profile list                         
    ''' </summary>
    ''' <remarks>
    ''' Returns 0 in case of error, otherwise return the user identity
    ''' </remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 16-11-2011   1.0     Creation
    ''' 10-05-2013   xxx     Add address field
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function getUserList(ByVal sql As String, _
                                ByRef Ret_UserList() As UserProfile, _
                                ByVal start As Integer, _
                                ByVal count As Integer, _
                                ByVal username As String, _
                                ByRef ErrorMessage As String) As Integer

        Dim sSql As String
        Dim i As Integer = 0
        Dim iResult As Integer

        Const sIdm As String = "DBService.getUserList"
        env = New Environment("Life_2.0.DBService")

        Dim retVar(-1) As UserProfile
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing
        env.WriteTrace(2, "Entry ", sIdm)

        Try
            Dim sServer As String = Config.GetConfigVal("files", "serverUrl")

            sSql = LCase(sqlDistance(sql, "user_profile", username))
            Dim mySelectQuery As String = sSql

            If Not sSql.Contains("select count") Then
                If count <> 0 Then
                    mySelectQuery = mySelectQuery & " LIMIT " & start.ToString & "," & count.ToString
                End If
            End If
            env.DataAccess.initDB()

            mySelectQuery = mySelectQuery & ";"
            conn = New MySqlConnection(env.DataAccess.ConnectionString)
            conn.Open()
            Dim myCommand As New MySqlCommand(mySelectQuery, conn)
            myReader = myCommand.ExecuteReader(Data.CommandBehavior.CloseConnection)
            myCommand.Dispose()
            If myReader.HasRows Then
                Dim UProfile As UserProfile
                If sSql.Contains("select count") Then
                    myReader.Read()
                    iResult = myReader.GetInt64(0)
                Else
                    Do While myReader.Read()
                        UProfile = New UserProfile
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("User_id"))) Then
                            UProfile.User_id = myReader.GetValue(myReader.GetOrdinal("User_id"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Login"))) Then
                            UProfile.Login = myReader.GetValue(myReader.GetOrdinal("Login"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Name"))) Then
                            UProfile.Name = myReader.GetValue(myReader.GetOrdinal("Name"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Role"))) Then
                            UProfile.Role = myReader.GetValue(myReader.GetOrdinal("Role"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Email"))) Then
                            UProfile.Email = myReader.GetValue(myReader.GetOrdinal("Email"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("telephonenumber"))) Then
                            UProfile.telephonenumber = myReader.GetValue(myReader.GetOrdinal("telephonenumber"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Picture"))) Then
                            UProfile.Picture = sServer & myReader.GetValue(myReader.GetOrdinal("Picture"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Language"))) Then
                            UProfile.Language = myReader.GetValue(myReader.GetOrdinal("Language"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Home_area_lat"))) Then
                            UProfile.Home_area_lat = myReader.GetValue(myReader.GetOrdinal("Home_area_lat"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Home_area_lon"))) Then
                            UProfile.Home_area_lon = myReader.GetValue(myReader.GetOrdinal("Home_area_lon"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Home_area_radius"))) Then
                            UProfile.Home_area_radius = myReader.GetValue(myReader.GetOrdinal("Home_area_radius"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Last_loc_timestamp"))) Then
                            UProfile.Last_location_timestamp = myReader.GetValue(myReader.GetOrdinal("Last_loc_timestamp"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Last_loc_lat"))) Then
                            UProfile.Last_location_lat = myReader.GetValue(myReader.GetOrdinal("Last_loc_lat"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("last_loc_lon"))) Then
                            UProfile.Last_location_lon = myReader.GetValue(myReader.GetOrdinal("last_loc_lon"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Notification_level"))) Then
                            UProfile.Notification_level = myReader.GetValue(myReader.GetOrdinal("Notification_level"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Promoter_id"))) Then
                            UProfile.Promoter_id = myReader.GetValue(myReader.GetOrdinal("Promoter_id"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("User_average_mark"))) Then
                            UProfile.User_average_mark = myReader.GetValue(myReader.GetOrdinal("User_average_mark"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("User_votes"))) Then
                            UProfile.User_votes = myReader.GetValue(myReader.GetOrdinal("User_votes"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Enabled"))) Then
                            UProfile.Enabled = myReader.GetValue(myReader.GetOrdinal("Enabled"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("region"))) Then
                            UProfile.region = myReader.GetValue(myReader.GetOrdinal("region"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("address"))) Then
                            UProfile.address = myReader.GetValue(myReader.GetOrdinal("address"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("adminRegion"))) Then
                            UProfile.adminRegion = myReader.GetValue(myReader.GetOrdinal("adminRegion"))
                        End If
                        If mySelectQuery.Contains("radians(") Then
                            If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Distance"))) Then
                                UProfile.Distance = myReader.GetValue(myReader.GetOrdinal("Distance"))
                            End If
                        End If
                        retVarList.Add(UProfile)
                    Loop
                    retVar = retVarList.ToArray(GetType(UserProfile))
                    iResult = 1
                End If
            Else
                env.WriteTrace(3, "No data read from table user_profile ", sIdm)
            End If
            Ret_UserList = retVar
            env.WriteTrace(2, "End ", sIdm)
            Return iResult

        Catch ex As Exception
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ex.Message
        Finally
            If Not myReader Is Nothing Then
                myReader.Close()
            End If
            If Not conn Is Nothing Then
                conn.Close()
                conn.Dispose()
            End If
        End Try

    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' UploadPicture: Subir la foto de un usuario
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 26-10-2011   1.0.0      Creación
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function UploadPicture(ByVal Login As String, _
                                  ByVal Picture As Byte(), _
                                  ByRef ErrorMessage As String) As Integer

        Dim bolReturnStatus As Boolean = False
        Dim bOK As Boolean
        Dim sUpFolder, sFileVPath, sFile, sLocalFile, sFileExt As String
        Dim iReturn As Integer

        Dim objFileStream As FileStream

        Dim stUserProfile As DataAccess.UserProfile

        '+---------------------------+
        '| Inicializar la aplicación |
        '+---------------------------+
        Const sIdm As String = "DBService.UploadPicture"
        env = New Environment("Life_2.0.DBService")

        Try

            env.WriteTrace(3, "Login user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                iReturn = stUserProfile.User_id
                '+---------------------------------------------------+
                '| Tomamos el directorio donde guardaremos la imagen |
                '+---------------------------------------------------+
                'sUpFolder = My.Request.MapPath(Config.GetConfigVal("files", "imageFolder"))
                sUpFolder = Config.GetConfigVal("files", "imageFolder")
                If Not sUpFolder.EndsWith("\") Then
                    sUpFolder &= "\"
                End If
                env.WriteTrace(3, "Image folder: " & sUpFolder, sIdm)

                '+----------------------------------------+
                '| Componemos el nombre del archivo local |
                '+----------------------------------------+
                sLocalFile = sUpFolder & Login & ".jpg"

                '+-----------------------------------------------------------------+
                '| creates the file by opening and setting the fileaccess to write |
                '+-----------------------------------------------------------------+
                objFileStream = File.Open(sLocalFile, FileMode.Create, FileAccess.Write)

                '+------------+
                '| byte count |
                '+------------+
                Dim lngLen As Long = Picture.Length

                '+----------------+
                '| Write the file |
                '+----------------+
                objFileStream.Write(Picture, 0, CType(lngLen, Integer))

                '+------------------------------------------------+
                '| clears the buffer and writes any buffered data |
                '+------------------------------------------------+
                objFileStream.Flush()

                '+-------------------------------------------------------+
                '| close the file so it can be access by other processes |
                '+-------------------------------------------------------+
                objFileStream.Close()

                '+------------------------------------------------+
                '| Update the user data with the path of the file |
                '+------------------------------------------------+
                sFileVPath = Config.GetConfigVal("files", "imagevpath")
                If Not sFileVPath.EndsWith("/") Then
                    sFileVPath &= "/"
                End If
                sFileVPath &= Login & ".jpg"
                bOK = env.DataAccess.DBupdate("user_profile", _
                                              "Login = " & CDBStr(Login), _
                                              "Picture", CDBStr(sFileVPath))

                If bOK Then
                    env.WriteTrace(3, "User updated OK", sIdm)
                    '+-----------------------------------+
                    '| return a successful upload status |
                    '+-----------------------------------+
                Else
                    iReturn = ErrorResult
                End If

            Else
                env.WriteTrace(3, "User not read", sIdm)
                ErrorMessage = "ErrorReadingUserProfile"
                iReturn = ErrorResult
            End If


        Catch ex As Exception
            ErrorMessage = "ERRORin " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            iReturn = ErrorResult

        Finally
            '+----------------------+
            '| cleanup just in case |
            '+----------------------+
            If Not objFileStream Is Nothing Then
                objFileStream.Close()
            End If

        End Try

        Return iReturn

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' checkfolderexists: Comprobar si existe el directorio, si no existe intenta crearlo
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 07-07-2009   1.0.0      Creación
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Private Function checkfolderexists(ByVal sFolder As String) As Boolean

        'split the directory out so that you can do a check for each folder
        Dim sFolderSplit() As String = sFolder.Split("\")

        Dim strFolder As String = ""          'current folder to check              
        Try
            'loop through each folder
            For x As Int16 = 0 To sFolderSplit.GetUpperBound(0) - 1
                'set the current folder
                strFolder += sFolderSplit(x) & "\"

                'do check
                'If Directory.Exists(strFolder) = False Then
                '    'try to create the none existing folder
                '    Directory.CreateDirectory(strFolder)
                'End If
            Next

            'looped through all folders successfully
            Return True
        Catch ex As Exception
            'error occured
            Return False
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' Notify: Send notification
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    ''' 15-02-2012  Creación
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Sub Notify(ByVal idEvent As Integer, _
                      ByVal sLogin As String, _
                      ByVal sUserId As String, _
                      ByVal sRole As String, _
                      ByVal sUserName As String, _
                      ByVal sEmail As String, _
                      ByVal sLang As String)

        Dim sToList(), sCcList, sFrom, sSubject, sMessage, sLng(), sTemp(), sError As String
        Dim sbHtml As StringBuilder
        Dim iResult, i As Integer

        Const sIdm As String = "Notification.Notify"

        env = New Environment("Life_2.0.DBService")

        Try
            env.WriteTrace(3, "Notify new user registration= " & sLogin, sIdm)

            sLng = sLang.Split(",")

            Select Case idEvent

                Case EventRegisterUser
                    '+--------------------------+
                    '| Compose the message body |
                    '+--------------------------+
                    sbHtml = New StringBuilder(Functions.loadTemplate("email-newuser", Trim(sLng(0))))

            End Select

            sbHtml.Replace("{#UserLogin#}", sLogin)
            sbHtml.Replace("{#UserId#}", sUserId)
            sbHtml.Replace("{#UserRole#}", sRole)
            sbHtml.Replace("{#UserName#}", sUserName)
            sbHtml.Replace("{#Email#}", sEmail)
            sMessage = sbHtml.ToString

            env.WriteTrace(3, "sMessage = " & sMessage, sIdm)

            sTemp = sbHtml.ToString.Split(vbCr)
            sSubject = sTemp(0)

            env.WriteTrace(3, "sSubject = " & sSubject, sIdm)

            '+----------------------------------------------------------------------------+
            '| Search users with the same language and profile administrator or moderator |
            '+----------------------------------------------------------------------------+
            Dim retUsers() As UserProfile

            iResult = getUserList("Language Like '%" & sLng(0) & "%' AND Role=" & Role.Moderator_Admin, retUsers, 0, 0, sUserId, sError)

            If iResult <> -1 Then

                For i = 0 To retUsers.Length - 1
                    ReDim Preserve sToList(i)
                    sToList(i) = retUsers(i).Email
                    env.WriteTrace(3, "retUsers(i).Email = " & retUsers(i).Email, sIdm)
                Next

                sFrom = Config.GetConfigVal("Email", "From")

                If sendEmail(sToList, "", sFrom, sSubject, sMessage, sError) Then
                    sError = ""
                    env.WriteTrace(3, "e-mail sent OK ", sIdm)
                Else
                    env.WriteTrace(3, "Error sending e-mail: " & sError, sIdm)
                    sError = "ErrorSendingEmailNotification"
                End If
            Else
                env.WriteTrace(3, "Error retrieving user list, can not send notification", sIdm)
            End If

        Catch ex As Exception
            sError = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, sError, sIdm)
        End Try

    End Sub

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' sendEmail: Enviar correo por SMTP
    ''' </summary>
    ''' <param name="sToList">Lista de direcciones de envío</param>
    ''' <remarks></remarks>
    ''' <history>
    ''' 05-11-2007  Creación
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Function sendEmail(ByVal sToList() As String, _
                              ByVal sCcList As String, _
                              ByVal sFrom As String, _
                              ByVal sSubject As String, _
                              ByVal sMessage As String, _
                              ByRef sError As String) As Boolean

        Dim i As Integer
        Dim sTemp As String

        Const sIdm As String = "Notification.sendEmail"

        Try

            'Start by creating a mail message object
            Dim MyMailMessage As New MailMessage()

            'From requires an instance of the MailAddress type
            MyMailMessage.From = New MailAddress(sFrom)

            For i = 0 To sToList.Length - 1
                MyMailMessage.To.Add(sToList(i))
            Next
            'To is a collection of MailAddress types

            MyMailMessage.SubjectEncoding = Encoding.GetEncoding("iso-8859-1")
            MyMailMessage.BodyEncoding = Encoding.GetEncoding("iso-8859-1")

            MyMailMessage.Subject = sSubject
            MyMailMessage.Body = sMessage

            'Create the SMTPClient object and specify the SMTP GMail server
            sTemp = Config.GetConfigVal("Email", "SmtpServer")
            env.WriteTrace(3, "Email/SmtpServer: " & sTemp, sIdm)

            Dim SMTPServer As New SmtpClient(sTemp)

            sTemp = Config.GetConfigVal("Email", "SmtpPort")
            env.WriteTrace(3, "Email/SmtpPort: " & sTemp, sIdm)

            SMTPServer.Port = CInt(sTemp)
            SMTPServer.UseDefaultCredentials = False
            SMTPServer.Credentials = New System.Net.NetworkCredential(Config.GetConfigVal("Email", "SmtpUser"), _
                                                                      Config.GetConfigVal("Email", "SmtpPassword"))
            SMTPServer.EnableSsl = CBool(Config.GetConfigVal("Email", "SmtpSsl"))

            Try
                SMTPServer.Send(MyMailMessage)

                Return True

            Catch ex As FormatException
                sError = "Error in " & sIdm & ": Format Exception: " & ex.Message
                env.WriteTrace(3, "FormatException: " & sError, sIdm)
                Return False

            Catch ex As SmtpException
                sError = "Error in " & sIdm & ": SMTP Exception:  " & ex.Message
                env.WriteTrace(3, "SmtpException: " & sError, sIdm)
                Return False

            Catch ex As Exception
                sError = "Error in " & sIdm & ": " & ex.Message
                env.WriteTrace(3, "Exception: " & sError, sIdm)
                Return False
            End Try

        Catch ex As Exception
            sError = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(3, "Exception2: " & sError, sIdm)
            Return False

        End Try

    End Function
End Class
