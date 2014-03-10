
'Database Access Funtions Copyright (C) 2013 Alcatel·Lucent 
'This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. 
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
'You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports MySql.Data.MySqlClient
Imports System.Net
Imports System.Net.Mail
Imports System.IO


' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la siguiente línea.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://Life_2_0_Engine/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class ENGService
    Inherits System.Web.Services.WebService

    Public Const ErrorResult As Integer = -1

    Public Const EventAddActivity As Integer = 1
    Public Const EventAddCategory As Integer = 2
    Public Const EventAddService As Integer = 3
    Public Const EventAddSkill As Integer = 4
    Public Const EventJoinActivity As Integer = 5
    Public Const EventSubmitRequest As Integer = 6
    Public Const EventAddOffer As Integer = 7
    Public Const EventReplyOffer As Integer = 8
    Public Const EventReplyRequest As Integer = 9
    Public Const EventApplyForOffer As Integer = 10
    Public Const EventApplyForRequest As Integer = 11
    Public Const EventCommentOffer As Integer = 12
    Public Const EventAddMpOffer As Integer = 13

    Public Const cJoinActivity As Integer = 0
    Public Const cJoinService As Integer = 1
    Public Const cJoinOffer As Integer = 2
    Public Const cJoinRequest As Integer = 3

    Public Const NotifNone As Integer = 0
    Public Const NotifEmail As Integer = 1
    Public Const NotifInternal As Integer = 2
    Public Const NotifBoth As Integer = 3

    Public Structure Offer
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
        Public Request_id As Integer
        Public Candidates As String
        Public ContactType As Integer
        Public SubmissionDate As Date
        Public PromoterName As String
    End Structure

    Public Structure Request
        Public Request_id As Integer
        Public Requester_id As Integer
        Public Request_type As String
        Public Category_id As String
        Public Short_description As String
        Public Description As String
        Public When_request As String
        Public Where_request As String
        Public Filtering_preferences As String
        Public Status As Integer
        Public Deadline As Date
        Public Candidates As String
        Public Distance As Long
        Public lng As String
        Public ContactType As Integer
        Public SubmissionDate As Date
        Public PromoterName As String
    End Structure

    Public Structure Regions
        Public id As Integer
        Public name As String
        Public supraRegion As String
        Public country As String
        Public lat As String
        Public lon As String
        Public radius As Long
        Public lng As String
    End Structure


    Public Structure Skill
        Public skill_id As String
        Public skill_name As String
        Public promoter_id As String
        Public Distance As Long
        Public lng As String
    End Structure

    Public Structure Interest
        Public interest_id As String
        Public interest_name As String
        Public user_id As String
        Public Distance As Long
        Public lng As String
    End Structure

    Public Structure Messages
        Public Id As String
        Public Origin As Integer
        Public Destination As Integer
        Public Sname As String
        Public Rname As String
        Public Message As String
        Public MRead As Integer
        Public DateSent As Date
        Public DateRead As Date
        Public MReplied As Integer
        Public idOffer As Integer
        Public idReq As Integer
    End Structure

    Public Structure Category
        Public category_id As String
        Public category_name As String
        Public category_desc As String
        Public status As Integer
        Public lng As String
    End Structure

    Public Structure Join
        Public Join_id As Integer
        Public Id As Integer
        Public User_id As Integer
        Public Status As Integer
        Public Type As Integer
    End Structure

    Public Structure Service
        Public Id As Integer
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

    Public Structure Activity
        Public Id As Integer
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
        Public OrgName As String
        Public Title As String
        Public DateOfActivity As Date
        Public Address As String
        Public Telephone As String
        Public Price As String
        Public Subscription As Integer
        Public MaxParticipants As Integer
        Public SubmissionDate As Date
    End Structure

    Public Structure MpOffer
        Public Id As Integer
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
        Public OrgName As String
        Public Title As String
        Public DateOfActivity As Date
        Public Address As String
        Public Telephone As String
        Public Mobile As String
        Public Email As String
        Public url_booking As String
        Public url_web As String
        Public url_brochure As String
        Public url_booking_dsc As String
        Public url_web_dsc As String
        Public url_brochure_dsc As String
        Public Price As String
        Public Subscription As Integer
        Public MaxParticipants As Integer
        Public SubmissionDate As Date
        Public Views As Integer
    End Structure

    Public Structure Stats
        Public Event_Id As Integer
        Public User_Login As String
        Public dTime As String
        Public Duration As Integer
        Public Device As String
        Public Query As String
        Public Lat As String
        Public Lon As String
        Public Distance As Long
    End Structure

    Public Structure ObjStats
        Public idStat As Integer
        Public iEvent As Integer
        Public User_Login As String
        Public dTime As String
        Public Duration As Integer
        Public Lat As String
        Public Lon As String
        Public Device As String
        Public Query As String
        Public lng As String
    End Structure

    Public Structure Recommendations
        Public recid As Integer
        Public Offer_id As Integer
        Public Request_id As Integer
        Public User_id As String
        Public Comment As String
        Public RecList As String
        Public lng As String
    End Structure

    Public Structure Business
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

    Public Structure Hub
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

    Public Structure Files
        Public idFiles As Integer
        Public fileName As String
        Public Offer As Integer
        Public url As String
        Public Userid As Integer
    End Structure

    Enum FilteringPrefs
        male_female
        closest
        best
        recommended
        my_contacts
    End Enum

    Enum Status
        SError
        Submitted
        Pending
        Pending_Approval
        Accepted
        Closed
        Rejected
    End Enum

    Enum Role
        Demo_user
        User
        Hub
        Small_bussines
        Big_bussines
        Area_manager
        Sys_admin
        Regional_admin
        Country_admin
    End Enum

    Enum OfferType
        Activity
        Service
        Help
        MarketPlace
    End Enum

    Public env As Environment

    Private Function CDBStr(ByVal psString As String) As String
        CDBStr = IIf(Trim(psString) <> "", "'" & Trim(Replace(Replace(psString, "\", "\\"), "'", "\'")) & "'", "Null")
    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' SubmitOffer: Add an Offer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 17-02-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
     Public Function SubmitOffer(ByVal Login As String, _
                                 ByVal request_id As Integer, _
                                 ByVal Category As String, _
                                 ByVal Short_desc As String, _
                                 ByVal Detailed_info As String, _
                                 ByVal When_Offer As String, _
                                 ByVal Where_Offer As String, _
                                 ByVal Deadline As Date, _
                                 ByVal ContactType As Integer, _
                                 ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String
        Dim sLatLon(), sLat, sLon As String
        Dim bLatLon As Boolean

        Dim stUserProfile As DataAccess.UserProfile
        Dim stOffer As DataAccess.stCatalogue

        Const sIdm As String = "ENGService.SubmitOffer"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Submit Offer by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    If Trim(Where_Offer) <> "" Then
                        sLatLon = Where_Offer.Split("/")
                        If sLatLon.Length = 2 Then
                            bLatLon = True
                            sLat = sLatLon(0).Replace(",", ".")
                            sLon = sLatLon(1).Replace(",", ".")
                        Else
                            bLatLon = False
                        End If
                    Else
                        bLatLon = False
                    End If
                    If Not bLatLon Then
                        sLat = stUserProfile.Last_loc_lat.ToString.Replace(",", ".")
                        sLon = stUserProfile.last_loc_lon.ToString.Replace(",", ".")
                    End If
                    
                    env.WriteTrace(3, "stUserProfile.User_id = " & stUserProfile.User_id.ToString, sIdm)

                    bOK = env.DataAccess.DBinsert("catalogue", _
                                                  "Request_id", request_id.ToString, _
                                                  "Offer_type", OfferType.Help, _
                                                  "Category_id", CDBStr(Category), _
                                                  "Promoter_id", stUserProfile.User_id, _
                                                  "Short_description", CDBStr(Short_desc), _
                                                  "Detailed_info", CDBStr(Detailed_info), _
                                                  "WhenCat", CDBStr(Left(When_Offer, 100)), _
                                                  "WhereCat", CDBStr(sLat & "/" & sLon), _
                                                  "Deadline", env.DataAccess.CDBDate(Deadline), _
                                                  "lng", CDBStr(getUserLanguage(stUserProfile.Language)), _
                                                  "lat", sLat, _
                                                  "lon", sLon, _
                                                  "ContactType", ContactType.ToString, _
                                                  "SubmissionDate", env.DataAccess.CDBDate(DateTime.Now))

                    If bOK Then
                        env.WriteTrace(3, "Offer submitted OK, now read the offer id", sIdm)

                        sSql = "Offer_type=" & OfferType.Help & _
                               " AND Category_id=" & CDBStr(Category) & _
                               " AND Promoter_id=" & stUserProfile.User_id & " ORDER BY Offer_id Desc"

                        stOffer = env.DataAccess.getCatalogue(sSql)

                        If stOffer.Id <> 0 Then
                            env.WriteTrace(3, "Offer identity = " & stOffer.Id.ToString, sIdm)
                            ErrorMessage = ""

                            Notify(Login, _
                                   EventAddActivity, _
                                   stOffer.Id, _
                                   stUserProfile.Name, _
                                   stUserProfile.Login, _
                                   stOffer.Short_Description, _
                                   stOffer.Detailed_info, _
                                   stOffer.lng, _
                                   ContactType, _
                                   ErrorMessage)


                            iReturn = stOffer.Id
                        Else
                            env.WriteTrace(3, "Offer not created, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "Offer not created, error in DataAccess module", sIdm)
                        ErrorMessage = "InternalErrorInDb"
                        iReturn = ErrorResult
                    End If

                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try
    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' GetOffer: Recover Offer list
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
     Public Function GetOffer(ByVal sql As String, _
                              ByRef ret_Offer() As Offer, _
                              ByVal start As Integer, _
                              ByVal count As Integer, _
                              ByVal username As String, _
                              ByRef ErrorMessage As String) As Integer
        Dim sSql, sUserId As String
        Dim i As Integer = 0
        Dim iResult As Integer

        Const sIdm As String = "ENGService.GetOffer"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As Offer
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            env.WriteTrace(2, "Entry ", sIdm)
            env.WriteTrace(3, "sql:" & sql, sIdm)
            env.WriteTrace(3, "start:" & start.ToString, sIdm)
            env.WriteTrace(3, "count:" & count.ToString, sIdm)
            env.WriteTrace(3, "username:" & username, sIdm)

            sSql = sqlDistance(sql, "catalogue", "", username)

            sSql = LCase(sSql)
            Dim mySelectQuery As String = sSql

            If Not sSql.Contains("select count") Then
                If count <> 0 Then
                    mySelectQuery = mySelectQuery & " LIMIT " & start.ToString & "," & count.ToString
                End If
            End If
            env.DataAccess.initDB()

            mySelectQuery = mySelectQuery & ";"
            env.WriteTrace(3, "mySelectQuery:" & mySelectQuery, sIdm)
            conn = New MySqlConnection(env.DataAccess.ConnectionString)
            conn.Open()
            Dim myCommand As New MySqlCommand(mySelectQuery, conn)
            myReader = myCommand.ExecuteReader(Data.CommandBehavior.CloseConnection)
            myCommand.Dispose()
            If myReader.HasRows Then
                Dim result As Offer
                If sSql.Contains("select count") Then
                    myReader.Read()
                    iResult = myReader.GetInt64(0)
                Else
                    Do While myReader.Read()
                        result = New Offer
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Offer_id"))) Then
                            result.Offer_id = myReader.GetValue(myReader.GetOrdinal("Offer_id"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Offer_type"))) Then
                            result.Offer_type = myReader.GetValue(myReader.GetOrdinal("Offer_type"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category_id"))) Then
                            result.Category = myReader.GetValue(myReader.GetOrdinal("Category_id"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Promoter_id"))) Then
                            sUserId = myReader.GetValue(myReader.GetOrdinal("Promoter_id"))
                            result.Promoter_id = sUserId
                            result.PromoterName = env.DataAccess.getUserName("User_id=" & sUserId)
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Short_description"))) Then
                            result.Short_Description = myReader.GetValue(myReader.GetOrdinal("Short_description"))
                            env.WriteTrace(3, "result.Short_Description:" & result.Short_Description, sIdm)
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
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Request_id"))) Then
                            result.Request_id = myReader.GetValue(myReader.GetOrdinal("Request_id"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("SubmissionDate"))) Then
                            result.SubmissionDate = myReader.GetValue(myReader.GetOrdinal("SubmissionDate"))
                        End If
                        If mySelectQuery.Contains("radians(") Then
                            If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Distance"))) Then
                                result.Distance = myReader.GetValue(myReader.GetOrdinal("Distance"))
                            End If
                        End If
                        retVarList.Add(result)
                    Loop
                    retVar = retVarList.ToArray(GetType(Offer))
                    iResult = 1
                End If
            Else
                env.WriteTrace(3, "No data read from table request ", sIdm)
            End If
            ret_Offer = retVar
            env.WriteTrace(2, "End ", sIdm)
            Return iResult

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return iResult
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
    ''' SubmitRequest: Submit a request
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function SubmitRequest(ByVal Login As String, _
                                  ByVal Request_Type As String, _
                                  ByVal Category_id As String, _
                                  ByVal Short_description As String, _
                                  ByVal Description As String, _
                                  ByVal When_request As String, _
                                  ByVal Where As String, _
                                  ByVal Filtering_preferences As FilteringPrefs, _
                                  ByVal Deadline As String, _
                                  ByVal Candidates As String, _
                                  ByVal ContactType As Integer, _
                                  ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String
        Dim sLatLon(), sLat, sLon As String
        Dim bLatLon As Boolean

        Dim stUserProfile As DataAccess.UserProfile
        Dim stRequest As DataAccess.StRequest

        Const sIdm As String = "ENGService.SubmitRequest"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Submit Request by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then

                If stUserProfile.Enabled = 1 Then

                    If Trim(Where) <> "" Then
                        sLatLon = Where.Split("/")
                        If sLatLon.Length = 2 Then
                            bLatLon = True
                            sLat = sLatLon(0).Replace(",", ".")
                            sLon = sLatLon(1).Replace(",", ".")
                        Else
                            bLatLon = False
                        End If
                    Else
                        bLatLon = False
                    End If
                    If Not bLatLon Then
                        sLat = stUserProfile.Last_loc_lat.ToString.Replace(",", ".")
                        sLon = stUserProfile.last_loc_lon.ToString.Replace(",", ".")
                    End If

                    bOK = env.DataAccess.DBinsert("request", _
                                                  "RequesterId", stUserProfile.User_id, _
                                                  "RequestType", CDBStr(Request_Type), _
                                                  "Category_Id", CDBStr(Category_id), _
                                                  "Short_description", CDBStr(Short_description), _
                                                  "Description", CDBStr(Description), _
                                                  "WhenReq", CDBStr(Left(When_request, 45)), _
                                                  "WhereReq", CDBStr(sLat & "/" & sLon), _
                                                  "FilteringPrefs", Filtering_preferences, _
                                                  "Status", Status.Submitted, _
                                                  "Deadline", env.DataAccess.CDBDate(Deadline), _
                                                  "Candidates", CDBStr(Candidates), _
                                                  "lng", CDBStr(getUserLanguage(stUserProfile.Language)), _
                                                  "lat", sLat, _
                                                  "lon", sLon, _
                                                  "ContactType", ContactType.ToString, _
                                                  "SubmissionDate", env.DataAccess.CDBDate(DateTime.Now))

                    If bOK Then
                        env.WriteTrace(3, "Request submitted OK, now read the request id", sIdm)

                        sSql = "RequesterId=" & stUserProfile.User_id & " ORDER BY RequestId DESC"

                        stRequest = env.DataAccess.getRequest(sSql)

                        If stRequest.Request_id <> 0 Then
                            env.WriteTrace(3, "Request identity = " & stRequest.Request_id.ToString, sIdm)
                            ErrorMessage = ""

                            Notify(Login, _
                                   EventSubmitRequest, _
                                   stRequest.Request_id, _
                                   stUserProfile.Name, _
                                   stUserProfile.Login, _
                                   stRequest.Short_description, _
                                   stRequest.Description, _
                                   stRequest.lng, _
                                   ContactType, _
                                   ErrorMessage)

                            iReturn = stRequest.Request_id
                        Else
                            env.WriteTrace(3, "Request not created, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "Request not created, error in DataAccess module", sIdm)
                        ErrorMessage = "InternalErrorInDb"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' UpdateRequest: Update a request
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
     Public Function UpdateRequest(ByVal Login As String, _
                                   ByVal Request_id As String, _
                                   ByVal Request_Type As String, _
                                   ByVal Category_id As String, _
                                   ByVal Short_description As String, _
                                   ByVal Description As String, _
                                   ByVal When_request As String, _
                                   ByVal Where As String, _
                                   ByVal Filtering_preferences As FilteringPrefs, _
                                   ByVal Deadline As String, _
                                   ByVal Candidates As String, _
                                   ByVal sStatus As Status, _
                                   ByVal ContactType As Integer, _
                                   ByRef ErrorMessage As String) As Integer
        Dim bOK, bAdmin As Boolean
        Dim iReturn, i As Integer
        Dim sSql As String
        Dim sLatLon(), sLat, sLon, sCommand() As String
        Dim bLatLon As Boolean

        Dim stUserProfile As DataAccess.UserProfile
        Dim stRequest As DataAccess.StRequest

        Const sIdm As String = "ENGService.UpdateRequest"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Update Request by user: " & Login, sIdm)
            env.WriteTrace(3, "Request_id: " & Request_id, sIdm)
            env.WriteTrace(3, "Request_Type :" & Request_Type, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then
                    '+--------------------------------------------+
                    '| Check that the request belongs to the user |
                    '+--------------------------------------------+
                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then
                        sSql = "RequestId = " & Request_id
                        bAdmin = True
                    Else
                        sSql = "RequestId = " & Request_id & " And RequesterId = " & stUserProfile.User_id
                        bAdmin = False
                    End If

                    stRequest = env.DataAccess.getRequest(sSql)

                    If stRequest.Request_id <> 0 Then

                        If Trim(Where) <> "" Then
                            sLatLon = Where.Split("/")
                            If sLatLon.Length = 2 Then
                                bLatLon = True
                                sLat = sLatLon(0).Replace(",", ".")
                                sLon = sLatLon(1).Replace(",", ".")
                            Else
                                bLatLon = False
                            End If
                        Else
                            bLatLon = False
                        End If
                        If Not bLatLon Then
                            sLat = stUserProfile.Last_loc_lat.ToString.Replace(",", ".")
                            sLon = stUserProfile.last_loc_lon.ToString.Replace(",", ".")
                        End If
                        If stRequest.Requester_id = stUserProfile.User_id Then
                            bAdmin = False
                        End If

                        i = 0
                        If Request_Type <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "RequestType"
                            sCommand(i + 1) = CDBStr(Request_Type)
                            i += 2
                        End If
                        If Request_Type <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "RequestType"
                            sCommand(i + 1) = CDBStr(Request_Type)
                            i += 2
                        End If
                        If Category_id <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Category_Id"
                            sCommand(i + 1) = CDBStr(Category_id)
                            i += 2
                        End If
                        If Short_description <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Short_description"
                            sCommand(i + 1) = CDBStr(Short_description)
                            i += 2
                        End If
                        If Description <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Description"
                            sCommand(i + 1) = CDBStr(Description)
                            i += 2
                        End If
                        If When_request <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "WhenReq"
                            sCommand(i + 1) = CDBStr(When_request)
                            i += 2
                        End If
                        If Deadline <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Deadline"
                            sCommand(i + 1) = env.DataAccess.CDBDate(Deadline)
                            i += 2
                        End If
                        ReDim Preserve sCommand(i + 1)
                        sCommand(i) = "FilteringPrefs"
                        sCommand(i + 1) = Filtering_preferences
                        i += 2
                        ReDim Preserve sCommand(i + 1)
                        sCommand(i) = "Status"
                        sCommand(i + 1) = sStatus
                        i += 2
                        If Candidates <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Candidates"
                            sCommand(i + 1) = CDBStr(Candidates)
                            i += 2
                        End If
                        ReDim Preserve sCommand(i + 1)
                        sCommand(i) = "ContactType"
                        sCommand(i + 1) = ContactType.ToString
                        i += 2
                        If Not bAdmin Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "WhereReq"
                            sCommand(i + 1) = CDBStr(sLat & "/" & sLon)
                            i += 2
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "lng"
                            sCommand(i + 1) = CDBStr(getUserLanguage(stUserProfile.Language))
                            i += 2
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "lat"
                            sCommand(i + 1) = sLat
                            i += 2
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "lon"
                            sCommand(i + 1) = sLon
                        End If

                        bOK = env.DataAccess.DBupdate("request", _
                                                      "RequestId = " & Request_id, _
                                                      sCommand)

                        If bOK Then
                            env.WriteTrace(3, "Request updated OK, now read the request id", sIdm)
                            iReturn = CInt(Request_id)

                            sSql = "RequestId = " & Request_id

                            stRequest = env.DataAccess.getRequest(sSql)

                            If stRequest.Request_id <> 0 Then
                                env.WriteTrace(3, "Request identity = " & stRequest.Request_id.ToString, sIdm)
                                ErrorMessage = ""

                                Notify(Login, _
                                       EventSubmitRequest, _
                                       stRequest.Request_id, _
                                       stUserProfile.Name, _
                                       stUserProfile.Login, _
                                       stRequest.Short_description, _
                                       stRequest.Description, _
                                       stRequest.lng, _
                                       ContactType, _
                                       ErrorMessage)

                                iReturn = stRequest.Request_id
                            Else
                                env.WriteTrace(3, "Request not updated, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If

                        Else
                            env.WriteTrace(3, "Request not updated, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "Request does not belongs to the user, error in DataAccess module", sIdm)
                        ErrorMessage = "RequestDoesNotBelongsToUser"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' DeleteRequest: Delete a request
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function DeleteRequest(ByVal Login As String, _
                                  ByVal Request_id As String, _
                                  ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String
        Dim stUserProfile As DataAccess.UserProfile
        Dim stRequest As DataAccess.StRequest

        Const sIdm As String = "ENGService.DeleteRequest"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Delete request:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)
            iReturn = stUserProfile.User_id

            If iReturn <> 0 Then
                If stUserProfile.Enabled = 1 Then
                    '+--------------------------------------------+
                    '| Check that the request belongs to the user |
                    '+--------------------------------------------+
                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then
                        sSql = "RequestId = " & Request_id
                    Else
                        sSql = "RequestId = " & Request_id & " And RequesterId = " & stUserProfile.User_id
                    End If

                    stRequest = env.DataAccess.getRequest(sSql)

                    If stRequest.Request_id <> 0 Then

                        bOK = env.DataAccess.DBdelete("request", _
                                                      "RequestId = " & Request_id)

                        If bOK Then
                            env.WriteTrace(3, "Request deleted OK", sIdm)
                            iReturn = CInt(Request_id)
                            ErrorMessage = ""
                        Else
                            env.WriteTrace(3, "Request not deleted, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "Request does not belongs to the user, error in DataAccess module", sIdm)
                        ErrorMessage = "RequestDoesNotBelongsToUser"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' ApplyForRequest: Apply for a request
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 06-03-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function ApplyForRequest(ByVal Login As String, _
                                    ByVal Request_id As String, _
                                    ByRef ErrorMessage As String) As Integer
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.ApplyForRequest"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Apply For request:" & Login, sIdm)

            iReturn = AddToJoin(Login, Request_id, cJoinRequest, ErrorMessage)

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' UnApplyForRequest: UnApply for a request
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 06-03-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function UnApplyForRequest(ByVal Login As String, _
                                      ByVal Request_id As String, _
                                      ByRef ErrorMessage As String) As Integer

        Dim iReturn As Integer

        Const sIdm As String = "ENGService.UnApplyForRequest"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "UnApply For request:" & Login, sIdm)

            iReturn = RemoveFromJoin(Login, Request_id, ErrorMessage)

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' GetRequestStatus: Get the status of a request
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function GetRequestStatus(ByVal Login As String, _
                                     ByVal Request_id As String, _
                                     ByRef ErrorMessage As String) As Integer
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stRequest As DataAccess.StRequest

        Const sIdm As String = "ENGService.GetRequestStatus"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Update Request by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then
                    '+--------------------------------------------+
                    '| Check that the request belongs to the user |
                    '+--------------------------------------------+
                    sSql = "RequestId = " & Request_id & " And RequesterId = " & stUserProfile.User_id

                    stRequest = env.DataAccess.getRequest(sSql)

                    If stRequest.Request_id <> 0 Then
                        iReturn = stRequest.Status
                        env.WriteTrace(3, "Request status: " & iReturn.ToString, sIdm)
                        ErrorMessage = ""
                    Else
                        env.WriteTrace(3, "Request does not belongs to the user, error in DataAccess module", sIdm)
                        ErrorMessage = "RequestDoesNotBelongsToUser"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' GetRequests: Get the list of requests
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function GetRequests(ByVal sql As String, _
                                ByRef ret_Requests() As Request, _
                                ByVal start As Integer, _
                                ByVal count As Integer, _
                                ByVal username As String, _
                                ByRef ErrorMessage As String) As Integer
        Dim sSql, sUserId As String
        Dim i As Integer = 0
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.GetRequests"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As Request
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            env.WriteTrace(2, "Entry ", sIdm)
            env.WriteTrace(3, "Sql:" & sql, sIdm)

            sSql = sqlDistance(sql, "request", "", username)

            sSql = LCase(sSql)
            Dim mySelectQuery As String = sSql

            If Not sSql.Contains("select count") Then
                If count <> 0 Then
                    mySelectQuery = mySelectQuery & " LIMIT " & start.ToString & "," & count.ToString
                End If
            End If
            env.DataAccess.initDB()

            mySelectQuery = mySelectQuery & ";"
            env.WriteTrace(3, "mySelectQuery:" & mySelectQuery, sIdm)
            conn = New MySqlConnection(env.DataAccess.ConnectionString)
            conn.Open()
            Dim myCommand As New MySqlCommand(mySelectQuery, conn)
            myReader = myCommand.ExecuteReader(Data.CommandBehavior.CloseConnection)
            myCommand.Dispose()
            If myReader.HasRows Then
                Dim result As Request
                If sSql.Contains("select count") Then
                    myReader.Read()
                    iReturn = myReader.GetInt64(0)
                Else
                    Do While myReader.Read()
                        result = New Request
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("RequestId"))) Then
                            result.Request_id = myReader.GetValue(myReader.GetOrdinal("RequestId"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("RequesterId"))) Then
                            sUserId = myReader.GetValue(myReader.GetOrdinal("RequesterId"))
                            result.Requester_id = sUserId
                            result.PromoterName = env.DataAccess.getUserName("User_id=" & sUserId)
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("RequestType"))) Then
                            result.Request_type = myReader.GetValue(myReader.GetOrdinal("RequestType"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category_Id"))) Then
                            result.Category_id = myReader.GetValue(myReader.GetOrdinal("Category_Id"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Description"))) Then
                            result.Description = myReader.GetValue(myReader.GetOrdinal("Description"))
                            env.WriteTrace(3, "result.Description:" & result.Description, sIdm)
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Short_description"))) Then
                            result.Short_description = myReader.GetValue(myReader.GetOrdinal("Short_description"))
                            env.WriteTrace(3, "result.Short_description:" & result.Short_description, sIdm)
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("WhenReq"))) Then
                            result.When_request = myReader.GetValue(myReader.GetOrdinal("WhenReq"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("WhereReq"))) Then
                            result.Where_request = myReader.GetValue(myReader.GetOrdinal("WhereReq"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("FilteringPrefs"))) Then
                            result.Filtering_preferences = myReader.GetValue(myReader.GetOrdinal("FilteringPrefs"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Status"))) Then
                            result.Status = myReader.GetValue(myReader.GetOrdinal("Status"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Deadline"))) Then
                            result.Deadline = myReader.GetValue(myReader.GetOrdinal("Deadline"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Candidates"))) Then
                            result.Candidates = myReader.GetValue(myReader.GetOrdinal("Candidates"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("ContactType"))) Then
                            result.ContactType = myReader.GetValue(myReader.GetOrdinal("ContactType"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lng"))) Then
                            result.lng = myReader.GetValue(myReader.GetOrdinal("lng"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("SubmissionDate"))) Then
                            result.SubmissionDate = myReader.GetValue(myReader.GetOrdinal("SubmissionDate"))
                        End If
                        If mySelectQuery.Contains("radians(") Then
                            If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Distance"))) Then
                                result.Distance = myReader.GetValue(myReader.GetOrdinal("Distance"))
                            End If
                        End If
                        retVarList.Add(result)
                    Loop
                    retVar = retVarList.ToArray(GetType(Request))
                    iReturn = 1
                End If
            Else
                env.WriteTrace(3, "No data read from table request ", sIdm)
            End If
            ret_Requests = retVar
            env.WriteTrace(2, "End ", sIdm)
            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ErrorResult
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
    ''' GetRegions: Get the list of regions
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function GetRegions(ByVal sql As String, _
                               ByRef ret_Regions() As Regions, _
                               ByVal start As Integer, _
                               ByVal count As Integer, _
                               ByVal username As String, _
                               ByRef ErrorMessage As String) As Integer

        Dim sSql As String
        Dim i As Integer = 0
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.GetRegions"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As Regions
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            env.WriteTrace(2, "Entry ", sIdm)
            env.WriteTrace(3, "Sql:" & sql, sIdm)

            sSql = sqlDistance(sql, "regions", "", username)

            sSql = LCase(sSql)
            Dim mySelectQuery As String = sSql

            If Not sSql.Contains("select count") Then
                If count <> 0 Then
                    mySelectQuery = mySelectQuery & " LIMIT " & start.ToString & "," & count.ToString
                End If
            End If
            env.DataAccess.initDB()

            mySelectQuery = mySelectQuery & ";"
            env.WriteTrace(3, "mySelectQuery:" & mySelectQuery, sIdm)
            conn = New MySqlConnection(env.DataAccess.ConnectionString)
            conn.Open()
            Dim myCommand As New MySqlCommand(mySelectQuery, conn)
            myReader = myCommand.ExecuteReader(Data.CommandBehavior.CloseConnection)
            myCommand.Dispose()
            If myReader.HasRows Then
                Dim result As Regions
                If sSql.Contains("select count") Then
                    myReader.Read()
                    iReturn = myReader.GetInt64(0)
                Else
                    Do While myReader.Read()
                        result = New Regions
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("id"))) Then
                            result.id = myReader.GetValue(myReader.GetOrdinal("id"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("name"))) Then
                            result.name = myReader.GetValue(myReader.GetOrdinal("name"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("supraRegion"))) Then
                            result.supraRegion = myReader.GetValue(myReader.GetOrdinal("supraRegion"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("country"))) Then
                            result.country = myReader.GetValue(myReader.GetOrdinal("country"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lat"))) Then
                            result.lat = myReader.GetValue(myReader.GetOrdinal("lat"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lon"))) Then
                            result.lon = myReader.GetValue(myReader.GetOrdinal("lon"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("radius"))) Then
                            result.radius = myReader.GetValue(myReader.GetOrdinal("radius"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lng"))) Then
                            result.lng = myReader.GetValue(myReader.GetOrdinal("lng"))
                        End If
                        retVarList.Add(result)
                    Loop
                    retVar = retVarList.ToArray(GetType(Regions))
                    iReturn = 1
                End If
            Else
                env.WriteTrace(3, "No data read from table request ", sIdm)
            End If
            ret_Regions = retVar
            env.WriteTrace(2, "End ", sIdm)
            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ErrorResult
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
    ''' GetRequests: Get the list of requests
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function GetRecommendations(ByVal sql As String, _
                                       ByRef ret_Recs() As Recommendations, _
                                       ByVal start As Integer, _
                                       ByVal count As Integer, _
                                       ByVal username As String, _
                                       ByRef ErrorMessage As String) As Integer
        Dim sSql, sUserId As String
        Dim i As Integer = 0
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.GetRecommendations"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As Recommendations
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            env.WriteTrace(2, "Entry ", sIdm)
            env.WriteTrace(3, "Sql:" & sql, sIdm)

            sSql = sqlDistance(sql, "recommendations", "", username)

            sSql = LCase(sSql)
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
                Dim result As Recommendations
                If sSql.Contains("select count") Then
                    myReader.Read()
                    iReturn = myReader.GetInt64(0)
                Else
                    Do While myReader.Read()
                        result = New Recommendations
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("recid"))) Then
                            result.recid = myReader.GetValue(myReader.GetOrdinal("recid"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Offer_id"))) Then
                            result.Offer_id = myReader.GetValue(myReader.GetOrdinal("Offer_id"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Request_id"))) Then
                            result.Request_id = myReader.GetValue(myReader.GetOrdinal("Request_id"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("User_id"))) Then
                            sUserId = myReader.GetValue(myReader.GetOrdinal("User_id"))
                            '+----------------------------------------------------------------+
                            '| Get the real name of the user in order to sen it to the client |
                            '| instead of the user identity                                   |
                            '+----------------------------------------------------------------+
                            result.User_id = env.DataAccess.getUserName("Login='" & sUserId & "'")
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Comment"))) Then
                            result.Comment = myReader.GetValue(myReader.GetOrdinal("Comment"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("RecList"))) Then
                            result.RecList = myReader.GetValue(myReader.GetOrdinal("RecList"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lng"))) Then
                            result.lng = myReader.GetValue(myReader.GetOrdinal("lng"))
                        End If
                        retVarList.Add(result)
                    Loop
                    retVar = retVarList.ToArray(GetType(Recommendations))
                    iReturn = 1
                End If
            Else
                env.WriteTrace(3, "No data read from table request ", sIdm)
            End If
            ret_Recs = retVar
            env.WriteTrace(2, "End ", sIdm)
            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ErrorResult
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
    ''' AddToJoin: Add to Join table
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 26-09-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
     Private Function AddToJoin(ByVal Login As String, _
                                ByVal Id As String, _
                                ByVal Type As Integer, _
                                ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn, iEvent As Integer
        Dim sSql As String

        Dim stJoin As DataAccess.stJoin
        Dim stUserProfile As DataAccess.UserProfile
        Dim stActivity As DataAccess.stCatalogue
        Dim stRequest As DataAccess.StRequest

        Const sIdm As String = "ENGService.AddToJoin"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Add to Join table user/Offer/Type:" & Login & "/" & Id & "/" & Type.ToString, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    sSql = "Id=" & Id & _
                           " AND User_id = " & stUserProfile.User_id & _
                           " AND Type = " & Type.ToString

                    env.WriteTrace(3, "getJoin = " & sSql, sIdm)

                    stJoin = env.DataAccess.getJoin(sSql)

                    If stJoin.Join_id <> 0 Then
                        env.WriteTrace(3, "User already joined = " & stJoin.Join_id, sIdm)
                        ErrorMessage = "ActivityAlreadyJoinedByUser"
                        iReturn = ErrorResult
                    Else
                        bOK = env.DataAccess.DBinsert("Joins", _
                                                      "Id", Id, _
                                                      "User_id", stUserProfile.User_id, _
                                                      "Type", Type, _
                                                      "Status", Status.Pending_Approval)

                        If bOK Then
                            env.WriteTrace(3, "Add to Join OK", sIdm)

                            sSql = "Id=" & Id & _
                                   " AND User_id = " & stUserProfile.User_id & _
                                   " AND Type = " & Type.ToString

                            stJoin = env.DataAccess.getJoin(sSql)

                            If stJoin.Join_id <> 0 Then

                                env.WriteTrace(3, "Join identity = " & stJoin.Join_id, sIdm)
                                ErrorMessage = ""

                                If Type = cJoinRequest Then

                                    sSql = "RequestId = " & Id

                                    stRequest = env.DataAccess.getRequest(sSql)

                                    If stRequest.Request_id <> 0 Then
                                        env.WriteTrace(3, "request identity = " & stRequest.Request_id.ToString, sIdm)
                                        ErrorMessage = ""

                                        Notify(Login, _
                                               EventApplyForRequest, _
                                               stRequest.Request_id, _
                                               stUserProfile.Name, _
                                               stUserProfile.Login, _
                                               stRequest.Short_description, _
                                               stRequest.Description, _
                                               stRequest.lng, _
                                               stRequest.ContactType, _
                                               ErrorMessage)

                                        iReturn = stRequest.Request_id
                                    Else
                                        env.WriteTrace(3, "Join wrong, error in DataAccess module", sIdm)
                                        ErrorMessage = "InternalErrorInDb"
                                        iReturn = ErrorResult
                                    End If
                                    iReturn = CInt(Id)

                                Else
                                    '+-------------------+
                                    '| Offer or Activity |
                                    '+-------------------+
                                    sSql = "Offer_id = " & Id

                                    stActivity = env.DataAccess.getCatalogue(sSql)

                                    If stActivity.Id <> 0 Then
                                        env.WriteTrace(3, "activity identity = " & stActivity.Id.ToString, sIdm)
                                        ErrorMessage = ""

                                        Select Case Type

                                            Case cJoinActivity
                                                iEvent = EventJoinActivity

                                            Case cJoinOffer
                                                iEvent = EventApplyForOffer

                                        End Select

                                        Notify(Login, _
                                               iEvent, _
                                               stActivity.Id, _
                                               stUserProfile.Name, _
                                               stUserProfile.Login, _
                                               stActivity.Short_Description, _
                                               stActivity.Detailed_info, _
                                               stActivity.lng, _
                                               stActivity.ContactType, _
                                               ErrorMessage)

                                        iReturn = stActivity.Id
                                    Else
                                        env.WriteTrace(3, "Join wrong, error in DataAccess module", sIdm)
                                        ErrorMessage = "InternalErrorInDb"
                                        iReturn = ErrorResult
                                    End If
                                    iReturn = CInt(Id)

                                End If

                            Else
                                env.WriteTrace(3, "Join not created, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "Join not created, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "The user does no exist", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' JoinActivity: Join an activity
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
     Public Function JoinActivity(ByVal Login As String, _
                                  ByVal Offer_id As String, _
                                  ByRef ErrorMessage As String) As Integer
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.JoinActivity"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Join activity user/Offer:" & Login & "/" & Offer_id, sIdm)

            iReturn = AddToJoin(Login, Offer_id, cJoinActivity, ErrorMessage)

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' UnJoinActivity: UnJoin from an activity
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function UnJoinActivity(ByVal Login As String, _
                                   ByVal Offer_id As String, _
                                   ByRef ErrorMessage As String) As Integer
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.UnJoinActivity"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Delete Join:" & Login, sIdm)

            iReturn = RemoveFromJoin(Login, Offer_id, ErrorMessage)

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' RemoveFromJoin: Remove from Join table
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 26-09-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Private Function RemoveFromJoin(ByVal Login As String, _
                                    ByVal Offer_id As String, _
                                    ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String
        Dim stUserProfile As DataAccess.UserProfile

        Const sIdm As String = "ENGService.RemoveFromJoin"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Delete Join:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)
            iReturn = stUserProfile.User_id

            If iReturn <> 0 Then
                If stUserProfile.Enabled = 1 Then
                    '+-----------------------------------------+
                    '| Check that the Join belongs to the user |
                    '+-----------------------------------------+
                    sSql = "Id = " & Offer_id & " And User_id = " & stUserProfile.User_id

                    bOK = env.DataAccess.DBdelete("Joins", sSql)

                    If bOK Then
                        env.WriteTrace(3, "Join deleted OK", sIdm)
                        iReturn = CInt(Offer_id)
                        ErrorMessage = ""
                    Else
                        env.WriteTrace(3, "Join not deleted, error in DataAccess module", sIdm)
                        ErrorMessage = "InternalErrorInDb"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' ModerateJoinActivity: Moderate Joins from an activity
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function ModerateJoinActivity(ByVal Login As String, _
                                         ByVal Offer_id As String, _
                                         ByVal Requested_id As String, _
                                         ByVal Moderation As Integer, _
                                         ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String
        Dim stUserProfile As DataAccess.UserProfile

        Const sIdm As String = "ENGService.DeleteRequest"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Delete request:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)
            iReturn = stUserProfile.User_id

            If iReturn <> 0 Then
                If stUserProfile.Enabled = 1 Then
                    '+--------------------------------------------+
                    '| Check that the request belongs to the user |
                    '+--------------------------------------------+
                    sSql = "Offer_id = " & Offer_id & " And User_id = " & Requested_id

                    bOK = env.DataAccess.DBupdate("Joins", _
                                                  sSql, _
                                                  "Status", Moderation)

                    If bOK Then
                        env.WriteTrace(3, "Join updated OK", sIdm)
                        iReturn = CInt(Offer_id)
                        ErrorMessage = ""
                    Else
                        env.WriteTrace(3, "Join not updated, error in DataAccess module", sIdm)
                        ErrorMessage = "InternalErrorInDb"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' SendFeedback: Send Feedback
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' The 'feedback' parameter contains a vote that will be used in the 'Catalogue'
    ''' table to increase the value in 'offer_votes' and 'offer_average_mark'
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function SendFeedback(ByVal Login As String, _
                                 ByVal Offer_id As String, _
                                 ByVal feedback As Integer, _
                                 ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String
        Dim dAverage, dVotes, dTotal As Double
        Dim stOffer As DataAccess.stOffer

        Const sIdm As String = "ENGService.SendFeedback"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Send feedback by user:" & Login, sIdm)

            '+----------------------------------------------------------------+
            '| Read the offer in order to get the actual values to be updated |
            '+----------------------------------------------------------------+
            sSql = "Offer_id = " & Offer_id

            stOffer = env.DataAccess.getOffer(sSql)

            If stOffer.Offer_id <> 0 Then

                If feedback < 0 Then
                    feedback = 0
                ElseIf feedback > 10 Then
                    feedback = 10
                End If

                dAverage = stOffer.Offer_average_mark
                dVotes = CDbl(stOffer.Offer_votes)
                dTotal = dAverage * dVotes
                dTotal += CDbl(feedback)
                dVotes += 1
                dAverage = dTotal / dVotes

                bOK = env.DataAccess.DBupdate("catalogue", _
                                              "Offer_id = " & Offer_id, _
                                              "Offer_average_mark", dAverage.ToString.Replace(",", "."), _
                                              "Offer_votes", dVotes.ToString)

                If bOK Then
                    env.WriteTrace(3, "Feedback updated ok", sIdm)
                    iReturn = CInt(Offer_id)
                Else
                    env.WriteTrace(3, "catalogue not updated, error in DataAccess module", sIdm)
                    ErrorMessage = "InternalErrorInDb"
                    iReturn = ErrorResult
                End If
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' SendRecommendation: Send recommendation
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function SendRecommendation(ByVal Login As String, _
                                       ByVal Offer_id As String, _
                                       ByVal Request_id As String, _
                                       ByVal Comment As String, _
                                       ByVal Reclist As String, _
                                       ByRef ErrorMessage As String) As Integer
        Dim bOK, bInsert As Boolean
        Dim iReturn As Integer
        Dim sSql, sSender, sCommenter As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stOffer As DataAccess.stOffer
        Dim stRequest As DataAccess.StRequest

        Const sIdm As String = "ENGService.SendRecommendation"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Submit Recommendation user/Offer/Request:" & Login & "/" & Offer_id & "/" & Request_id, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then
                    If Offer_id Is Nothing Or Offer_id = vbNullString Then
                        Offer_id = "0"
                    End If
                    If Offer_id <> vbNullString And Offer_id <> "0" Then
                        sSql = "offer_id = " & Offer_id

                        stOffer = env.DataAccess.getOffer(sSql)

                        If stOffer.Offer_id <> 0 Then
                            bInsert = True

                            sSender = stOffer.Promoter_id.ToString
                            sSql = "User_id=" & sSender
                            sSender = env.DataAccess.getUserName(sSql)
                            'sSql = "Login='" & Login & "'"
                            'sCommenter = env.DataAccess.getUserName(sSql)

                            Notify(Login, _
                                   EventCommentOffer, _
                                   stOffer.Offer_id, _
                                   sSender, _
                                   stUserProfile.Name & " <" & stUserProfile.Email & ">", _
                                   stOffer.Short_Description, _
                                   Comment, _
                                   stOffer.lng, _
                                   stOffer.ContactType, _
                                   ErrorMessage, _
                                   1)

                        Else
                            bInsert = False
                        End If
                    End If

                    If Request_id Is Nothing Or Request_id = vbNullString Then
                        Request_id = "0"
                    End If
                    If Request_id <> vbNullString And Request_id <> "0" Then
                        sSql = "Requestid = " & Request_id

                        stRequest = env.DataAccess.getRequest(sSql)

                        If stRequest.Request_id <> 0 Then
                            bInsert = True

                            sSender = stRequest.Requester_id.ToString
                            sSql = "User_id=" & sSender
                            sSender = env.DataAccess.getUserName(sSql)

                            Notify(Login, _
                                   EventReplyRequest, _
                                   stRequest.Request_id, _
                                   sSender, _
                                   stUserProfile.Name & " <" & stUserProfile.Email & ">", _
                                   stRequest.Short_description, _
                                   Comment, _
                                   stRequest.lng, _
                                   stRequest.ContactType, _
                                   ErrorMessage, _
                                   1)
                        Else
                            bInsert = False
                        End If
                    End If

                    If bInsert Then

                        bOK = env.DataAccess.DBinsert("recommendations", _
                                                      "Offer_id", Offer_id, _
                                                      "Request_id", Request_id, _
                                                      "User_id", CDBStr(Login), _
                                                      "Comment", CDBStr(Comment), _
                                                      "lng", CDBStr(getUserLanguage(stUserProfile.Language)), _
                                                      "RecList", CDBStr(Reclist))

                        If bOK Then
                            env.WriteTrace(3, "Recommendation submitted OK", sIdm)
                            iReturn = Offer_id

                        Else
                            env.WriteTrace(3, "Request not created, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "The offer or request does no exist", sIdm)
                        ErrorMessage = "NotExistingOfferOrRequest"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' PromoterFeedback: A Promoter/SB/HUB votes a user that requested their services 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
     Public Function PromoterFeedback(ByVal Login As String, _
                                      ByVal User_id As String, _
                                      ByVal feedback As Integer, _
                                      ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String
        Dim dAverage, dVotes, dTotal As Double
        Dim stUserProfile As DataAccess.UserProfile

        Const sIdm As String = "ENGService.PromoterFeedback"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Send feedback to user Promoter/user:" & Login & "/" & User_id, sIdm)

            '+----------------------------------------------------------------+
            '| Read the offer in order to get the actual values to be updated |
            '+----------------------------------------------------------------+
            sSql = "User_id = " & User_id

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    If feedback < 0 Then
                        feedback = 0
                    ElseIf feedback > 10 Then
                        feedback = 10
                    End If

                    dAverage = stUserProfile.User_average_mark
                    dVotes = CDbl(stUserProfile.User_votes)
                    dTotal = dAverage * dVotes
                    dTotal += CDbl(feedback)
                    dVotes += 1
                    dAverage = dTotal / dVotes

                    bOK = env.DataAccess.DBupdate("user_profile", _
                                                  "User_id = " & User_id, _
                                                  "User_average_mark", dAverage.ToString, _
                                                  "User_votes", dVotes.ToString)

                    If bOK Then
                        env.WriteTrace(3, "user updated ok", sIdm)
                        iReturn = CInt(User_id)
                    Else
                        env.WriteTrace(3, "user not updated, error in DataAccess module", sIdm)
                        ErrorMessage = "InternalErrorInDb"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' AcceptRejectRequest: A Promoter/SB/HUB Accepts or rejects a request to their services  
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
     Public Function AcceptRejectRequest(ByVal Login As String, _
                                         ByVal User_id As String, _
                                         ByVal Request_id As String, _
                                         ByVal AcceptReject As Integer, _
                                         ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stRequest As DataAccess.StRequest

        Const sIdm As String = "ENGService.AcceptRejectRequest"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Update Request by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then
                    '+--------------------------------------------+
                    '| Check that the request belongs to the user |
                    '+--------------------------------------------+
                    sSql = "RequestId = " & Request_id & " And RequesterId = " & User_id

                    stRequest = env.DataAccess.getRequest(sSql)

                    If stRequest.Request_id <> 0 Then

                        bOK = env.DataAccess.DBupdate("request", _
                                                      "RequestId = " & Request_id, _
                                                      "Status", AcceptReject)

                        If bOK Then
                            env.WriteTrace(3, "Request updated OK, now read the request id", sIdm)
                            iReturn = CInt(Request_id)
                        Else
                            env.WriteTrace(3, "Request not updated, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "Request does not belongs to the user, error in DataAccess module", sIdm)
                        ErrorMessage = "RequestDoesNotBelongsToUser"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' AddSkill: A promoter adds a skill   
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
     Public Function AddSkill(ByVal Login As String, _
                              ByVal Skill As String, _
                              ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stSkill As DataAccess.stSkill

        Const sIdm As String = "ENGService.AddSkill"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Add skill by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    'If (stUserProfile.Role = Role.Promoter) Or _
                    '   (stUserProfile.Role = Role.Moderator_Admin) Then
                    If True Then

                        bOK = env.DataAccess.DBinsert("promoter_skills", _
                                                      "Promoter_id", stUserProfile.User_id, _
                                                      "Skill_name", CDBStr(Skill), _
                                                      "lng", CDBStr(getUserLanguage(stUserProfile.Language)), _
                                                      "lat", stUserProfile.Last_loc_lat.ToString.Replace(",", "."), _
                                                      "lon", stUserProfile.last_loc_lon.ToString.Replace(",", "."))

                        If bOK Then
                            env.WriteTrace(3, "Skill submitted OK, now read the skill id", sIdm)

                            sSql = "Promoter_id=" & stUserProfile.User_id & " AND Skill_name='" & Skill & "'"

                            stSkill = env.DataAccess.getSkill(sSql)

                            If stSkill.skill_id <> 0 Then
                                env.WriteTrace(3, "Skill identity = " & stSkill.skill_id.ToString, sIdm)
                                ErrorMessage = ""

                                Notify(Login, _
                                       EventAddCategory, _
                                       stSkill.skill_id, _
                                       stUserProfile.Name, _
                                       stUserProfile.Login, _
                                       stSkill.skill_name, _
                                       stSkill.skill_name, _
                                       stSkill.lng, _
                                       1, _
                                       ErrorMessage)

                                iReturn = stSkill.skill_id
                            Else
                                env.WriteTrace(3, "Skill not created, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "Skill not created, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAPromoter"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' AddInterest: A user adds an interest   
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 17-05-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
     Public Function AddInterest(ByVal Login As String, _
                                 ByVal Interest As String, _
                                 ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stInterest As DataAccess.stInterest

        Const sIdm As String = "ENGService.AddInterest"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Add Interest by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    'If (stUserProfile.Role = Role.Promoter) Or _
                    '   (stUserProfile.Role = Role.Moderator_Admin) Then

                    If True Then

                        bOK = env.DataAccess.DBinsert("user_interests", _
                                                      "user_id", stUserProfile.User_id, _
                                                      "interest_name", CDBStr(Interest), _
                                                      "lng", CDBStr(getUserLanguage(stUserProfile.Language)), _
                                                      "lat", stUserProfile.Last_loc_lat.ToString.Replace(",", "."), _
                                                      "lon", stUserProfile.last_loc_lon.ToString.Replace(",", "."))

                        If bOK Then
                            env.WriteTrace(3, "Interest submitted OK, now read the interest id", sIdm)

                            sSql = "user_id=" & stUserProfile.User_id & " AND interest_name='" & Interest & "'"

                            stInterest = env.DataAccess.getInterest(sSql)

                            If stInterest.interest_id <> 0 Then
                                env.WriteTrace(3, "Skill identity = " & stInterest.interest_id.ToString, sIdm)
                                ErrorMessage = ""

                                Notify(Login, _
                                       EventAddCategory, _
                                       stInterest.interest_id, _
                                       stUserProfile.Name, _
                                       stUserProfile.Login, _
                                       stInterest.interest_name, _
                                       stInterest.interest_name, _
                                       stInterest.lng, _
                                       1, _
                                       ErrorMessage)

                                iReturn = stInterest.interest_id
                            Else
                                env.WriteTrace(3, "Interest not created, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "Interest not created, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter or administrator", sIdm)
                        ErrorMessage = "UserNotAPromoter"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' GetJoins: Get a list of Joins
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 21-09-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function GetJoins(ByVal sql As String, _
                             ByRef ret_joins() As Join, _
                             ByVal start As Integer, _
                             ByVal count As Integer, _
                             ByVal username As String, _
                             ByRef ErrorMessage As String) As Integer

        Dim sSql As String
        Dim i As Integer = 0
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.GetJoins"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As Join
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing
        Dim stUserProfile As DataAccess.UserProfile

        Try
            env.WriteTrace(2, "Entry ", sIdm)

            'If username <> "" Then
            '    '+-----------------------+
            '    '| Get the user identity |
            '    '+-----------------------+
            '    stUserProfile = env.DataAccess.getUserProfile(username)

            '    If stUserProfile.User_id <> 0 Then

            '        If Not sql.Contains("User_id") Then
            '            If sql.Length <> 0 Then
            '                sql = "AND User_id=" & stUserProfile.User_id.ToString
            '            Else
            '                sql = "User_id=" & stUserProfile.User_id.ToString
            '            End If
            '        End If

            '    End If

            'End If

            iReturn = lGetJoins(sql, ret_joins, start, count, "", ErrorMessage)

            env.WriteTrace(2, "End ", sIdm)
            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' GetJoins: Get a list of Joins
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 21-09-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Private Function lGetJoins(ByVal sql As String, _
                               ByRef ret_joins() As Join, _
                               ByVal start As Integer, _
                               ByVal count As Integer, _
                               ByVal username As String, _
                               ByRef ErrorMessage As String) As Integer

        Dim sSql As String
        Dim i As Integer = 0
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.lGetJoins"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As Join
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            env.WriteTrace(2, "Entry ", sIdm)
            env.WriteTrace(3, "Sql:" & sql, sIdm)

            sSql = sqlDistance(sql, "joins", "", username)

            sSql = LCase(sSql)
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
                Dim result As Join
                If sSql.Contains("select count") Then
                    myReader.Read()
                    iReturn = myReader.GetInt64(0)
                Else
                    Do While myReader.Read()
                        result = New Join
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("idJoin"))) Then
                            result.Join_id = myReader.GetValue(myReader.GetOrdinal("idJoin"))
                        End If
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
                        retVarList.Add(result)
                    Loop
                    retVar = retVarList.ToArray(GetType(Join))
                    iReturn = 1
                End If
            Else
                env.WriteTrace(3, "No data read from table request ", sIdm)
            End If
            ret_joins = retVar
            env.WriteTrace(2, "End ", sIdm)
            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ErrorResult
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
    ''' GetSkills: Get a list of promoter skills
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function GetSkills(ByVal sql As String, _
                              ByRef ret_skills() As Skill, _
                              ByVal start As Integer, _
                              ByVal count As Integer, _
                              ByVal username As String, _
                              ByRef ErrorMessage As String) As Integer

        Dim sSql As String
        Dim i As Integer = 0
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.GetSkills"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As Skill
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            env.WriteTrace(2, "Entry ", sIdm)
            env.WriteTrace(3, "Sql:" & sql, sIdm)

            sSql = sqlDistance(sql, "promoter_skills", "", username)

            sSql = LCase(sSql)
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
                Dim result As Skill
                If sSql.Contains("select count") Then
                    myReader.Read()
                    iReturn = myReader.GetInt64(0)
                Else
                    Do While myReader.Read()
                        result = New Skill
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Skill_id"))) Then
                            result.skill_id = myReader.GetValue(myReader.GetOrdinal("Skill_id"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Skill_name"))) Then
                            result.skill_name = myReader.GetValue(myReader.GetOrdinal("Skill_name"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Promoter_id"))) Then
                            result.promoter_id = myReader.GetValue(myReader.GetOrdinal("Promoter_id"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lng"))) Then
                            result.lng = myReader.GetValue(myReader.GetOrdinal("lng"))
                        End If
                        If mySelectQuery.Contains("radians(") Then
                            If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Distance"))) Then
                                result.Distance = myReader.GetValue(myReader.GetOrdinal("Distance"))
                            End If
                        End If
                        retVarList.Add(result)
                    Loop
                    retVar = retVarList.ToArray(GetType(Skill))
                    iReturn = 1
                End If
            Else
                env.WriteTrace(3, "No data read from table request ", sIdm)
            End If
            ret_skills = retVar
            env.WriteTrace(2, "End ", sIdm)
            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ErrorResult
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
    ''' GetInterests: Get a list of user interests
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 17-05-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function GetInterests(ByVal sql As String, _
                                 ByRef ret_interest() As Interest, _
                                 ByVal start As Integer, _
                                 ByVal count As Integer, _
                                 ByVal username As String, _
                                 ByRef ErrorMessage As String) As Integer

        Dim sSql As String
        Dim i As Integer = 0
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.GetInterests"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As Interest
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            env.WriteTrace(2, "Entry ", sIdm)
            env.WriteTrace(3, "Sql:" & sql, sIdm)

            sSql = sqlDistance(sql, "user_interests", "", username)

            sSql = LCase(sSql)
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
                Dim result As Interest
                If sSql.Contains("select count") Then
                    myReader.Read()
                    iReturn = myReader.GetInt64(0)
                Else
                    Do While myReader.Read()
                        result = New Interest
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("interest_id"))) Then
                            result.interest_id = myReader.GetValue(myReader.GetOrdinal("interest_id"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("interest_name"))) Then
                            result.interest_name = myReader.GetValue(myReader.GetOrdinal("interest_name"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("user_id"))) Then
                            result.user_id = myReader.GetValue(myReader.GetOrdinal("user_id"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lng"))) Then
                            result.lng = myReader.GetValue(myReader.GetOrdinal("lng"))
                        End If
                        If mySelectQuery.Contains("radians(") Then
                            If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Distance"))) Then
                                result.Distance = myReader.GetValue(myReader.GetOrdinal("Distance"))
                            End If
                        End If
                        retVarList.Add(result)
                    Loop
                    retVar = retVarList.ToArray(GetType(Interest))
                    iReturn = 1
                End If
            Else
                env.WriteTrace(3, "No data read from table request ", sIdm)
            End If
            ret_interest = retVar
            env.WriteTrace(2, "End ", sIdm)
            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ErrorResult
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
    ''' GetMessages: Get the list of messages
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 24-05-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function GetMessages(ByVal sql As String, _
                                ByRef ret_messages() As Messages, _
                                ByVal start As Integer, _
                                ByVal count As Integer, _
                                ByRef ErrorMessage As String) As Integer

        Dim sSql As String
        Dim i As Integer = 0
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.GetMessages"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As Messages
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            env.WriteTrace(2, "Entry ", sIdm)
            env.WriteTrace(3, "Sql:" & sql, sIdm)

            sSql = sqlDistance(sql, "user_messages")

            sSql = LCase(sSql)
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
                Dim result As Messages
                If sSql.Contains("select count") Then
                    myReader.Read()
                    iReturn = myReader.GetInt64(0)
                Else
                    Do While myReader.Read()
                        result = New Messages
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Id"))) Then
                            result.Id = myReader.GetValue(myReader.GetOrdinal("Id"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Origin"))) Then
                            result.Origin = myReader.GetValue(myReader.GetOrdinal("Origin"))
                            result.Sname = env.DataAccess.getUserName("User_id=" & result.Origin.ToString)
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Destination"))) Then
                            result.Destination = myReader.GetValue(myReader.GetOrdinal("Destination"))
                            result.Rname = env.DataAccess.getUserName("User_id=" & result.Destination.ToString)
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Message"))) Then
                            result.Message = myReader.GetValue(myReader.GetOrdinal("Message"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("MRead"))) Then
                            result.MRead = myReader.GetValue(myReader.GetOrdinal("MRead"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("DateSent"))) Then
                            result.DateSent = myReader.GetValue(myReader.GetOrdinal("DateSent"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("DateRead"))) Then
                            result.DateRead = myReader.GetValue(myReader.GetOrdinal("DateRead"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("MReplied"))) Then
                            result.MReplied = myReader.GetValue(myReader.GetOrdinal("MReplied"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("idOffer"))) Then
                            result.idOffer = myReader.GetValue(myReader.GetOrdinal("idOffer"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("idReq"))) Then
                            result.idReq = myReader.GetValue(myReader.GetOrdinal("idReq"))
                        End If

                        retVarList.Add(result)
                    Loop
                    retVar = retVarList.ToArray(GetType(Messages))
                    iReturn = 1
                End If
            Else
                env.WriteTrace(3, "No data read from table request ", sIdm)
            End If
            ret_messages = retVar
            env.WriteTrace(2, "End ", sIdm)
            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ErrorResult
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
    ''' UpdateMessage: Update a message
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function UpdateMessage(ByVal Id As Integer, _
                                  ByVal MRead As Integer, _
                                  ByVal MReplied As Integer) As Integer
        Dim bOK As Boolean
        Dim iReturn, iMRead, iMReplied As Integer
        Dim sSql, sErrorMessage As String
        Dim dDateRead As Date
        Dim retVar(-1) As Messages

        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Const sIdm As String = "ENGService.UpdateMessage"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Update message: " & Id.ToString, sIdm)

            sSql = "Id=" & Id.ToString

            iReturn = GetMessages(sSql, retVar, 0, 0, sErrorMessage)

            If iReturn <> -1 Then

                dDateRead = retVar(0).DateRead
                iMRead = retVar(0).MRead

                If MRead = 1 And iMRead = 0 Then
                    '+---------------+
                    '| Date read now |
                    '+---------------+
                    dDateRead = DateTime.Now
                End If

                bOK = env.DataAccess.DBupdate("user_messages", _
                                              "Id=" & Id.ToString, _
                                              "MRead", MRead.ToString, _
                                              "MReplied", MReplied.ToString, _
                                              "DateRead", env.DataAccess.CDBDate(dDateRead))

                If bOK Then
                    env.WriteTrace(3, "Message updated identity = " & Id.ToString, sIdm)
                    iReturn = Id.ToString
                Else
                    env.WriteTrace(3, "Message not updated, error in DataAccess module", sIdm)
                    iReturn = ErrorResult
                End If

            Else
                env.WriteTrace(3, "Message not updated, error in DataAccess module", sIdm)
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            sErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, sErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' UpdateSkill: Update promoter skills
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function UpdateSkill(ByVal Login As String, _
                                ByVal Skill_id As String, _
                                ByVal Skill As String, _
                                ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stSkill As DataAccess.stSkill

        Const sIdm As String = "ENGService.UpdateSkill"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Update skill by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    'If (stUserProfile.Role = Role.Promoter) Or _
                    '   (stUserProfile.Role = Role.Moderator_Admin) Then
                    If True Then

                        sSql = "Skill_id=" & Skill_id

                        stSkill = env.DataAccess.getSkill(sSql)

                        If stSkill.skill_id <> 0 Then

                            bOK = env.DataAccess.DBupdate("promoter_skills", _
                                                         "Skill_id=" & Skill_id, _
                                                         "Promoter_id", stUserProfile.User_id, _
                                                         "Skill_name", CDBStr(Skill))

                            If bOK Then
                                env.WriteTrace(3, "Skill updated identity = " & stSkill.skill_id.ToString, sIdm)
                                ErrorMessage = ""
                                iReturn = stSkill.skill_id

                                sSql = "Skill_id=" & Skill_id

                                stSkill = env.DataAccess.getSkill(sSql)

                                If stSkill.skill_id <> 0 Then
                                    env.WriteTrace(3, "Skill identity = " & stSkill.skill_id.ToString, sIdm)
                                    ErrorMessage = ""

                                    Notify(Login, _
                                           EventAddCategory, _
                                           stSkill.skill_id, _
                                           stUserProfile.Name, _
                                           stUserProfile.Login, _
                                           stSkill.skill_name, _
                                           stSkill.skill_name, _
                                           stSkill.lng, _
                                           1, _
                                           ErrorMessage)

                                    iReturn = stSkill.skill_id
                                Else
                                    env.WriteTrace(3, "Skill not updated, error in DataAccess module", sIdm)
                                    ErrorMessage = "InternalErrorInDb"
                                    iReturn = ErrorResult
                                End If
                            Else
                                env.WriteTrace(3, "Skill not updated, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "Skill not existing, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAPromoter"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' UpdateInterest: Update user interest
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 21-05-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function UpdateInterest(ByVal Login As String, _
                                   ByVal Interest_id As String, _
                                   ByVal Interest As String, _
                                   ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stInterest As DataAccess.stInterest

        Const sIdm As String = "ENGService.UpdateInterest"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Update Interest by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    'If (stUserProfile.Role = Role.Promoter) Or _
                    '   (stUserProfile.Role = Role.Moderator_Admin) Then
                    If True Then

                        sSql = "interest_id=" & Interest_id

                        stInterest = env.DataAccess.getInterest(sSql)

                        If stInterest.interest_id <> 0 Then

                            bOK = env.DataAccess.DBupdate("user_interests", _
                                                          "interest_id=" & Interest_id, _
                                                          "user_id", stUserProfile.User_id, _
                                                          "interest_name", CDBStr(Interest))

                            If bOK Then
                                env.WriteTrace(3, "Interest updated identity = " & stInterest.interest_id.ToString, sIdm)
                                ErrorMessage = ""
                                iReturn = stInterest.interest_id

                                sSql = "Skill_id=" & Interest_id

                                stInterest = env.DataAccess.getInterest(sSql)

                                'If stInterest.interest_id <> 0 Then
                                '    env.WriteTrace(3, "Interest identity = " & stInterest.interest_id.ToString, sIdm)
                                '    ErrorMessage = ""

                                '    Notify(EventAddInterest, _
                                '           stSkill.skill_id, _
                                '           stUserProfile.Name, _
                                '           stUserProfile.Login, _
                                '           stSkill.skill_name, _
                                '           stSkill.skill_name, _
                                '           stSkill.lng, _
                                '           ErrorMessage)

                                '    iReturn = stSkill.skill_id
                                'Else
                                '    env.WriteTrace(3, "Skill not updated, error in DataAccess module", sIdm)
                                '    ErrorMessage = "InternalErrorInDb"
                                '    iReturn = ErrorResult
                                'End If
                            Else
                                env.WriteTrace(3, "Interest not updated, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "Interest not existing, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAPromoter"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' DeleteSkill: Delete promoter skills
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
     Public Function DeleteSkill(ByVal Login As String, _
                                 ByVal Skill_id As String, _
                                 ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stSkill As DataAccess.stSkill

        Const sIdm As String = "ENGService.DeleteSkill"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Delete skill by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    'If (stUserProfile.Role = Role.Promoter) Or _
                    '   (stUserProfile.Role = Role.Moderator_Admin) Then
                    If True Then

                        sSql = "Skill_id=" & Skill_id
                        env.WriteTrace(3, sSql, sIdm)

                        stSkill = env.DataAccess.getSkill(sSql)

                        If stSkill.skill_id <> 0 Then

                            bOK = env.DataAccess.DBdelete("promoter_skills", _
                                                          "Skill_id=" & Skill_id)

                            If bOK Then
                                env.WriteTrace(3, "Skill deleted identity = " & stSkill.skill_id.ToString, sIdm)
                                ErrorMessage = ""
                                iReturn = stSkill.skill_id
                            Else
                                env.WriteTrace(3, "Skill not deleted, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "Skill not existing, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAPromoter"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' DeleteMessage: Delete a message
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 25-05-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
     Public Function DeleteMessage(ByVal Id As Integer, _
                                   ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Const sIdm As String = "ENGService.DeleteMessage"
        env = New Environment("Life_2.0.ENGService")

        Try

            env.WriteTrace(3, "Delete message: " & Id.ToString, sIdm)
            sSql = "Id=" & Id.ToString
            env.WriteTrace(3, sSql, sIdm)

            bOK = env.DataAccess.DBdelete("user_messages", sSql)

            If bOK Then
                env.WriteTrace(3, "Message deleted identity = " & Id.ToString, sIdm)
                ErrorMessage = ""
                iReturn = Id
            Else
                env.WriteTrace(3, "Message not deleted, error in DataAccess module", sIdm)
                ErrorMessage = "InternalErrorInDb"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' DeleteInterest: Delete user interest
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
     Public Function DeleteInterest(ByVal Login As String, _
                                    ByVal Interest_id As String, _
                                    ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stInterest As DataAccess.stInterest

        Const sIdm As String = "ENGService.DeleteInterest"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Delete Interest by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    'If (stUserProfile.Role = Role.Promoter) Or _
                    '   (stUserProfile.Role = Role.Moderator_Admin) Then
                    If True Then

                        sSql = "interest_id=" & Interest_id
                        env.WriteTrace(3, sSql, sIdm)

                        stInterest = env.DataAccess.getInterest(sSql)

                        If stInterest.interest_id <> 0 Then

                            bOK = env.DataAccess.DBdelete("user_interests", _
                                                          "interest_id=" & Interest_id)

                            If bOK Then
                                env.WriteTrace(3, "Interest deleted identity = " & stInterest.interest_id.ToString, sIdm)
                                ErrorMessage = ""
                                iReturn = stInterest.interest_id
                            Else
                                env.WriteTrace(3, "Interest not deleted, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "Interest not existing, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAPromoter"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' AddCategory: Add Category
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function AddCategory(ByVal Login As String, _
                                ByVal Category As String, _
                                ByVal Category_desc As String, _
                                ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stCategory As DataAccess.stCategory

        Const sIdm As String = "ENGService.AddCategory"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Add category by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then


                        bOK = env.DataAccess.DBinsert("category", _
                                                      "Category_name", CDBStr(Category), _
                                                      "Category_description", CDBStr(Category_desc), _
                                                      "lng", CDBStr(getUserLanguage(stUserProfile.Language)), _
                                                      "Status", Status.Pending_Approval)

                        If bOK Then
                            env.WriteTrace(3, "category submitted OK, now read the category id", sIdm)

                            sSql = "Category_name='" & Category & "' AND Category_description='" & Category_desc & "'"

                            stCategory = env.DataAccess.getCategory(sSql)

                            If stCategory.category_id <> 0 Then
                                env.WriteTrace(3, "category identity = " & stCategory.category_id.ToString, sIdm)
                                ErrorMessage = ""

                                Notify(Login, _
                                       EventAddCategory, _
                                       stCategory.category_id, _
                                       stUserProfile.Name, _
                                       stUserProfile.Login, _
                                       stCategory.category_name, _
                                       stCategory.category_desc, _
                                       stCategory.lng, _
                                       1, _
                                       ErrorMessage)

                                iReturn = stCategory.category_id
                            Else
                                env.WriteTrace(3, "category not created, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "category not created, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAPromoter"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' AddActCategory: Add Activity Category
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 05-10-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function AddActCategory(ByVal Login As String, _
                                   ByVal Category As String, _
                                   ByVal Category_desc As String, _
                                   ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stCategory As DataAccess.stCategory

        Const sIdm As String = "ENGService.AddActCategory"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Add Activity category by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        sSql = "Category_name='" & Category & "'"

                        stCategory = env.DataAccess.getActCategory(sSql)

                        If stCategory.category_id = 0 Then

                            bOK = env.DataAccess.DBinsert("activity_category", _
                                                          "Category_name", CDBStr(Category), _
                                                          "Category_description", CDBStr(Category_desc), _
                                                          "lng", CDBStr(getUserLanguage(stUserProfile.Language)), _
                                                          "Status", Status.Pending_Approval)

                            If bOK Then
                                env.WriteTrace(3, "activity_category submitted OK, now read the category id", sIdm)

                                sSql = "Category_name='" & Category & "' AND Category_description='" & Category_desc & "'"

                                stCategory = env.DataAccess.getActCategory(sSql)

                                If stCategory.category_id <> 0 Then
                                    env.WriteTrace(3, "activity_category identity = " & stCategory.category_id.ToString, sIdm)
                                    ErrorMessage = ""

                                    Notify(Login, _
                                           EventAddCategory, _
                                           stCategory.category_id, _
                                           stUserProfile.Name, _
                                           stUserProfile.Login, _
                                           stCategory.category_name, _
                                           stCategory.category_desc, _
                                           stCategory.lng, _
                                           1, _
                                           ErrorMessage)

                                    iReturn = stCategory.category_id
                                Else
                                    env.WriteTrace(3, "activity_category not created, error in DataAccess module", sIdm)
                                    ErrorMessage = "InternalErrorInDb"
                                    iReturn = ErrorResult
                                End If
                            Else
                                env.WriteTrace(3, "activity_category not created, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "activity_category not created, already existing", sIdm)
                            ErrorMessage = "CategoryAlreadyExisting"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAPromoter"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' AddActCategory: Add Company Category
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 21-11-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function AddCompCategory(ByVal Login As String, _
                                    ByVal Category As String, _
                                    ByVal Category_desc As String, _
                                    ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stCategory As DataAccess.stCategory

        Const sIdm As String = "ENGService.AddCompCategory"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Add Company category by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        sSql = "Category_name='" & Category & "'"

                        stCategory = env.DataAccess.getCompCategory(sSql)

                        If stCategory.category_id = 0 Then

                            bOK = env.DataAccess.DBinsert("company_category", _
                                                          "Category_name", CDBStr(Category), _
                                                          "Category_description", CDBStr(Category_desc), _
                                                          "lng", CDBStr(getUserLanguage(stUserProfile.Language)), _
                                                          "Status", Status.Pending_Approval)

                            If bOK Then
                                env.WriteTrace(3, "company_category submitted OK, now read the category id", sIdm)

                                sSql = "Category_name = '" & Category & "' AND Category_description = '" & Category_desc & "'"

                                stCategory = env.DataAccess.getCompCategory(sSql)

                                If stCategory.category_id <> 0 Then
                                    env.WriteTrace(3, "company_category identity = " & stCategory.category_id.ToString, sIdm)
                                    ErrorMessage = ""

                                    Notify(Login, _
                                           EventAddCategory, _
                                           stCategory.category_id, _
                                           stUserProfile.Name, _
                                           stUserProfile.Login, _
                                           stCategory.category_name, _
                                           stCategory.category_desc, _
                                           stCategory.lng, _
                                           1, _
                                           ErrorMessage)

                                    iReturn = stCategory.category_id
                                Else
                                    env.WriteTrace(3, "company_category not created, error in DataAccess module", sIdm)
                                    ErrorMessage = "InternalErrorInDb"
                                    iReturn = ErrorResult
                                End If
                            Else
                                env.WriteTrace(3, "company_category not created, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "company_category not created, already existing", sIdm)
                            ErrorMessage = "CategoryAlreadyExisting"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAPromoter"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' AddRegion: Add region
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 26-06-2012   1.0.0      Creation
    ''' 23-11-2012              Add 'country_code' parameter
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function AddRegion(ByVal Login As String, _
                              ByVal name As String, _
                              ByVal supraRegion As String, _
                              ByVal country As String, _
                              ByVal country_code As String, _
                              ByVal lat As String, _
                              ByVal lon As String, _
                              ByVal radius As String, _
                              ByVal lng As String, _
                              ByRef ErrorMessage As String) As Integer

        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stRegion As DataAccess.stRegion

        Const sIdm As String = "ENGService.AddRegion"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Add region by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then


                        bOK = env.DataAccess.DBinsert("regions", _
                                                      "name", CDBStr(name), _
                                                      "country", CDBStr(country), _
                                                      "country_code", CDBStr(country_code), _
                                                      "lat", lat, _
                                                      "lon", lon, _
                                                      "radius", radius, _
                                                      "lng", CDBStr(lng), _
                                                      "supraRegion", CDBStr(supraRegion))

                        If bOK Then
                            env.WriteTrace(3, "region created OK, now read the region id", sIdm)

                            sSql = "name='" & name & "' AND country='" & country & "'"

                            stRegion = env.DataAccess.getRegion(sSql)

                            If stRegion.id <> 0 Then
                                env.WriteTrace(3, "region identity = " & stRegion.id.ToString, sIdm)
                                ErrorMessage = ""

                                iReturn = stRegion.id
                            Else
                                env.WriteTrace(3, "region not created, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "region not created, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAPromoter"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' AddHub: Add a Hub
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 27-11-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function AddHub(ByVal Login As String, _
                           ByVal User_id As Integer, _
                           ByVal Name As String, _
                           ByVal Area As Integer, _
                           ByVal lng As String, _
                           ByVal Category As Integer, _
                           ByVal Address As String, _
                           ByRef ErrorMessage As String) As Integer

        Dim bOK, bInsert As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stHub As DataAccess.stHub

        Const sIdm As String = "ENGService.AddHub"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Add Hub by user:" & Login, sIdm)

            '+----------------------------------------------------+
            '| Check if the Login user has the right permisssions |
            '+----------------------------------------------------+
            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        '+--------------------------------------------------------------------+
                        '| Check if the user assigned to the business, exists in the database |
                        '+--------------------------------------------------------------------+
                        stUserProfile = env.DataAccess.getUserProfile("User_id = " & User_id.ToString)

                        If stUserProfile.User_id <> 0 Then
                            If stUserProfile.Enabled = 1 Then
                                '+--------------------------------------------------------------------+
                                '| The user exists and is not disabled, now check if there is another |
                                '| business assigned to the same user                                 |
                                '+--------------------------------------------------------------------+
                                sSql = "User_id = " & User_id.ToString

                                stHub = env.DataAccess.getHub(sSql)

                                If stHub.Hub_id <> 0 Then
                                    '+----------------------------------------------------------------------+
                                    '| The user has already a Hub assigned, so it can not be assigned again |
                                    '+----------------------------------------------------------------------+
                                    bInsert = False
                                    env.WriteTrace(3, "Hub not created, The user has already a Hub assigned", sIdm)
                                    ErrorMessage = "UserAlreadyHasAHub"
                                    iReturn = ErrorResult
                                Else
                                    bInsert = True
                                End If
                            Else
                                bInsert = False
                                env.WriteTrace(3, "Hub not created, The user is not enabled", sIdm)
                                ErrorMessage = "UserNotEnabled"
                                iReturn = ErrorResult
                            End If
                        Else
                            bInsert = False
                            env.WriteTrace(3, "Hub not created, The user that wants to be assigned to the hub does not exist", sIdm)
                            ErrorMessage = "UserNotRegistered"
                            iReturn = ErrorResult
                        End If

                        '+----------------+
                        '| Check the area |
                        '+----------------+
                        If bInsert Then
                            Dim stRegion As DataAccess.stRegion
                            stRegion = env.DataAccess.getRegion("id = " & Area.ToString)

                            If stRegion.id <> 0 Then
                                bInsert = True
                            Else
                                bInsert = False
                                env.WriteTrace(3, "Hub not created, The selected region does not exist", sIdm)
                                ErrorMessage = "RegionDoesNotExist"
                                iReturn = ErrorResult
                            End If
                        End If

                        '+--------------------+
                        '| Check the category |
                        '+--------------------+
                        If bInsert Then
                            Dim stCateg As DataAccess.stCategory
                            stCateg = env.DataAccess.getCompCategory("Category_id = " & Category.ToString)

                            If stCateg.category_id <> 0 Then
                                bInsert = True
                            Else
                                bInsert = False
                                env.WriteTrace(3, "Hub not created, The selected category does not exist", sIdm)
                                ErrorMessage = "CategoryDoesNotExist"
                                iReturn = ErrorResult
                            End If
                        End If

                        If bInsert Then
                            bOK = env.DataAccess.DBinsert("hub", _
                                                          "User_id", User_id.ToString, _
                                                          "Name", CDBStr(Name), _
                                                          "Area", Area.ToString, _
                                                          "lng", CDBStr(lng), _
                                                          "Category", Category.ToString, _
                                                          "Address", CDBStr(Address))

                            If bOK Then
                                env.WriteTrace(3, "business created OK, now read the id", sIdm)

                                sSql = "User_id=" & User_id.ToString

                                stHub = env.DataAccess.getHub(sSql)

                                If stHub.Hub_id <> 0 Then
                                    env.WriteTrace(3, "Hub identity = " & stHub.Hub_id.ToString, sIdm)
                                    ErrorMessage = ""

                                    iReturn = stHub.Hub_id
                                Else
                                    env.WriteTrace(3, "Hub not created, error in DataAccess module", sIdm)
                                    ErrorMessage = "InternalErrorInDb"
                                    iReturn = ErrorResult
                                End If
                            Else
                                env.WriteTrace(3, "Hub not created, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAdmin"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' AddBusiness: Add a business
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 22-11-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function AddBusiness(ByVal Login As String, _
                                ByVal User_id As Integer, _
                                ByVal Name As String, _
                                ByVal Area As Integer, _
                                ByVal lng As String, _
                                ByVal Category As Integer, _
                                ByVal Address As String, _
                                ByRef ErrorMessage As String) As Integer

        Dim bOK, bInsert As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stBusiness As DataAccess.stBusiness

        Const sIdm As String = "ENGService.AddBusiness"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Add business by user:" & Login, sIdm)

            '+----------------------------------------------------+
            '| Check if the Login user has the right permisssions |
            '+----------------------------------------------------+
            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        '+--------------------------------------------------------------------+
                        '| Check if the user assigned to the business, exists in the database |
                        '+--------------------------------------------------------------------+
                        stUserProfile = env.DataAccess.getUserProfile("User_id = " & User_id.ToString)

                        If stUserProfile.User_id <> 0 Then
                            If stUserProfile.Enabled = 1 Then
                                '+--------------------------------------------------------------------+
                                '| The user exists and is not disabled, now check if there is another |
                                '| business assigned to the same user                                 |
                                '+--------------------------------------------------------------------+
                                sSql = "User_id = " & User_id.ToString

                                stBusiness = env.DataAccess.getBusiness(sSql)

                                If stBusiness.SB_id <> 0 Then
                                    '+---------------------------------------------------------------------------+
                                    '| The user has already a business assigned, so it can not be assigned again |
                                    '+---------------------------------------------------------------------------+
                                    bInsert = False
                                    env.WriteTrace(3, "Busines not created, The user has already a business assigned", sIdm)
                                    ErrorMessage = "UserAlreadyHasABusiness"
                                    iReturn = ErrorResult
                                Else
                                    bInsert = True
                                End If
                            Else
                                bInsert = False
                                env.WriteTrace(3, "Busines not created, The user is not enabled", sIdm)
                                ErrorMessage = "UserNotEnabled"
                                iReturn = ErrorResult
                            End If
                        Else
                            bInsert = False
                            env.WriteTrace(3, "Busines not created, The user that wants to be assigned to the business does not exist", sIdm)
                            ErrorMessage = "UserNotRegistered"
                            iReturn = ErrorResult
                        End If

                        '+----------------+
                        '| Check the area |
                        '+----------------+
                        If bInsert Then
                            Dim stRegion As DataAccess.stRegion
                            stRegion = env.DataAccess.getRegion("id = " & Area.ToString)

                            If stRegion.id <> 0 Then
                                bInsert = True
                            Else
                                bInsert = False
                                env.WriteTrace(3, "Busines not created, The selected region does not exist", sIdm)
                                ErrorMessage = "RegionDoesNotExist"
                                iReturn = ErrorResult
                            End If
                        End If

                        '+--------------------+
                        '| Check the category |
                        '+--------------------+
                        If bInsert Then
                            Dim stCateg As DataAccess.stCategory
                            stCateg = env.DataAccess.getCompCategory("Category_id = " & Category.ToString)

                            If stCateg.category_id <> 0 Then
                                bInsert = True
                            Else
                                bInsert = False
                                env.WriteTrace(3, "Busines not created, The selected category does not exist", sIdm)
                                ErrorMessage = "CategoryDoesNotExist"
                                iReturn = ErrorResult
                            End If
                        End If

                        If bInsert Then
                            bOK = env.DataAccess.DBinsert("small_business", _
                                                          "User_id", User_id.ToString, _
                                                          "Name", CDBStr(Name), _
                                                          "Area", Area.ToString, _
                                                          "lng", CDBStr(lng), _
                                                          "Category", Category.ToString, _
                                                          "Address", CDBStr(Address))

                            If bOK Then
                                env.WriteTrace(3, "business created OK, now read the id", sIdm)

                                sSql = "User_id=" & User_id.ToString

                                stBusiness = env.DataAccess.getBusiness(sSql)

                                If stBusiness.SB_id <> 0 Then
                                    env.WriteTrace(3, "Busines identity = " & stBusiness.SB_id.ToString, sIdm)
                                    ErrorMessage = ""

                                    iReturn = stBusiness.SB_id
                                Else
                                    env.WriteTrace(3, "Busines not created, error in DataAccess module", sIdm)
                                    ErrorMessage = "InternalErrorInDb"
                                    iReturn = ErrorResult
                                End If
                            Else
                                env.WriteTrace(3, "Busines not created, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAdmin"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' GetHub: Read Hub
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 27-11-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function GetHub(ByVal sql As String, _
                           ByRef ret_hub() As Hub, _
                           ByVal start As Integer, _
                           ByVal count As Integer, _
                           ByVal username As String, _
                           ByRef ErrorMessage As String) As Integer

        Dim sSql As String
        Dim i As Integer = 0
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.GetHub"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As Hub
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            env.WriteTrace(2, "Entry ", sIdm)
            env.WriteTrace(3, "Sql:" & sql, sIdm)

            sSql = sqlDistance(sql, "small_business", "", username)

            env.WriteTrace(3, "sSql after: " & sSql, sIdm)

            sSql = LCase(sSql)
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
                Dim result As Hub
                If sSql.Contains("select count") Then
                    myReader.Read()
                    iReturn = myReader.GetInt64(0)
                Else
                    Do While myReader.Read()
                        result = New Hub
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Hub_id"))) Then
                            result.Hub_id = myReader.GetValue(myReader.GetOrdinal("Category_id"))
                            env.WriteTrace(3, "Hub_id: " & result.Hub_id.ToString, sIdm)
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("User_id"))) Then
                            result.User_id = myReader.GetValue(myReader.GetOrdinal("User_id"))
                            env.WriteTrace(3, "User_id: " & result.User_id.ToString, sIdm)
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Name"))) Then
                            result.Name = myReader.GetValue(myReader.GetOrdinal("Name"))
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
                            result.lng = myReader.GetValue(myReader.GetOrdinal("lng"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category"))) Then
                            result.Category = myReader.GetValue(myReader.GetOrdinal("Category"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Address"))) Then
                            result.Address = myReader.GetValue(myReader.GetOrdinal("Address"))
                        End If
                        retVarList.Add(result)
                    Loop
                    retVar = retVarList.ToArray(GetType(Hub))
                    iReturn = 1
                End If
            Else
                env.WriteTrace(3, "No data read from table request ", sIdm)
            End If
            ret_hub = retVar
            env.WriteTrace(2, "End ", sIdm)
            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ErrorResult
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
    ''' GetBusiness: Read Businesses
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 26-11-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function GetBusiness(ByVal sql As String, _
                                ByRef ret_business() As Business, _
                                ByVal start As Integer, _
                                ByVal count As Integer, _
                                ByVal username As String, _
                                ByRef ErrorMessage As String) As Integer

        Dim sSql As String
        Dim i As Integer = 0
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.GetBusiness"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As Business
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            env.WriteTrace(2, "Entry ", sIdm)
            env.WriteTrace(3, "Sql:" & sql, sIdm)

            sSql = sqlDistance(sql, "small_business", "", username)

            env.WriteTrace(3, "sSql after: " & sSql, sIdm)

            sSql = LCase(sSql)
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
                Dim result As Business
                If sSql.Contains("select count") Then
                    myReader.Read()
                    iReturn = myReader.GetInt64(0)
                Else
                    Do While myReader.Read()
                        result = New Business
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("SB_id"))) Then
                            result.SB_id = myReader.GetValue(myReader.GetOrdinal("SB_id"))
                            env.WriteTrace(3, "SB_id: " & result.SB_id.ToString, sIdm)
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("User_id"))) Then
                            result.User_id = myReader.GetValue(myReader.GetOrdinal("User_id"))
                            env.WriteTrace(3, "User_id: " & result.User_id.ToString, sIdm)
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Name"))) Then
                            result.Name = myReader.GetValue(myReader.GetOrdinal("Name"))
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
                            result.lng = myReader.GetValue(myReader.GetOrdinal("lng"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category"))) Then
                            result.Category = myReader.GetValue(myReader.GetOrdinal("Category"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Address"))) Then
                            result.Address = myReader.GetValue(myReader.GetOrdinal("Address"))
                        End If
                        retVarList.Add(result)
                    Loop
                    retVar = retVarList.ToArray(GetType(Business))
                    iReturn = 1
                End If
            Else
                env.WriteTrace(3, "No data read from table request ", sIdm)
            End If
            ret_business = retVar
            env.WriteTrace(2, "End ", sIdm)
            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ErrorResult
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
    ''' GetFile: Get a file attached to an offer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 11-03-2013   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Private Function GetFile(ByVal FileId As Integer, _
                             ByRef ret_files() As Files, _
                             ByRef ErrorMessage As String) As Integer

        Dim sSql As String
        Dim i As Integer = 0
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.GetFile"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As Files
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            env.WriteTrace(2, "Entry ", sIdm)
            env.WriteTrace(3, "FileId:" & FileId.ToString, sIdm)


            sSql = LCase("SELECT * From Files Where idfiles = " & FileId.ToString)
            Dim mySelectQuery As String = sSql

            env.DataAccess.initDB()

            mySelectQuery = mySelectQuery & ";"
            conn = New MySqlConnection(env.DataAccess.ConnectionString)
            conn.Open()
            Dim myCommand As New MySqlCommand(mySelectQuery, conn)
            myReader = myCommand.ExecuteReader(Data.CommandBehavior.CloseConnection)
            myCommand.Dispose()
            If myReader.HasRows Then
                Dim result As Files
                If sSql.Contains("select count") Then
                    myReader.Read()
                    iReturn = myReader.GetInt64(0)
                Else
                    Do While myReader.Read()
                        result = New Files
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("idfiles"))) Then
                            result.idFiles = myReader.GetValue(myReader.GetOrdinal("idfiles"))
                            env.WriteTrace(3, "idfiles: " & result.idFiles.ToString, sIdm)
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("fileName"))) Then
                            result.fileName = myReader.GetValue(myReader.GetOrdinal("fileName"))
                            env.WriteTrace(3, "fileName: " & result.fileName, sIdm)
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Offer"))) Then
                            result.Offer = myReader.GetValue(myReader.GetOrdinal("Offer"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Url"))) Then
                            result.url = myReader.GetValue(myReader.GetOrdinal("Url"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Userid"))) Then
                            result.Userid = myReader.GetValue(myReader.GetOrdinal("Userid"))
                        End If
                        retVarList.Add(result)
                    Loop
                    retVar = retVarList.ToArray(GetType(Files))
                    iReturn = 1
                End If
            Else
                env.WriteTrace(3, "No data read from table request ", sIdm)
            End If
            ret_files = retVar
            env.WriteTrace(2, "End ", sIdm)
            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ErrorResult
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
    ''' GetFiles2: Get files attached to an offer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 11-03-2013   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Private Function GetFiles2(ByVal Offer As Integer, _
                               ByVal internalFile As Boolean, _
                               ByRef ret_files() As Files, _
                               ByRef ErrorMessage As String) As Integer

        Dim sSql, sHost As String
        Dim i As Integer = 0
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.GetFiles2"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As Files
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            env.WriteTrace(2, "Entry ", sIdm)
            env.WriteTrace(3, "Offer:" & Offer.ToString, sIdm)

            If internalFile Then
                sHost = ""
            Else
                sHost = Config.GetConfigVal("files", "serverUrl")
            End If


            sSql = LCase("SELECT * From Files Where Offer = " & Offer.ToString)
            Dim mySelectQuery As String = sSql

            env.DataAccess.initDB()

            mySelectQuery = mySelectQuery & ";"
            conn = New MySqlConnection(env.DataAccess.ConnectionString)
            conn.Open()
            Dim myCommand As New MySqlCommand(mySelectQuery, conn)
            myReader = myCommand.ExecuteReader(Data.CommandBehavior.CloseConnection)
            myCommand.Dispose()
            If myReader.HasRows Then
                Dim result As Files
                If sSql.Contains("select count") Then
                    myReader.Read()
                    iReturn = myReader.GetInt64(0)
                Else
                    Do While myReader.Read()
                        result = New Files
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("idfiles"))) Then
                            result.idFiles = myReader.GetValue(myReader.GetOrdinal("idfiles"))
                            env.WriteTrace(3, "idfiles: " & result.idFiles.ToString, sIdm)
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("fileName"))) Then
                            result.fileName = myReader.GetValue(myReader.GetOrdinal("fileName"))
                            env.WriteTrace(3, "fileName: " & result.fileName, sIdm)
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Offer"))) Then
                            result.Offer = myReader.GetValue(myReader.GetOrdinal("Offer"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Url"))) Then
                            result.url = sHost & myReader.GetValue(myReader.GetOrdinal("Url"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Userid"))) Then
                            result.Userid = myReader.GetValue(myReader.GetOrdinal("Userid"))
                        End If
                        retVarList.Add(result)
                    Loop
                    retVar = retVarList.ToArray(GetType(Files))
                    iReturn = 1
                End If
            Else
                env.WriteTrace(3, "No data read from table request ", sIdm)
            End If
            ret_files = retVar
            env.WriteTrace(2, "End ", sIdm)
            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ErrorResult
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
    ''' GetFiles: Get the list of files attached to an offer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 11-03-2013   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function GetFiles(ByVal Offer As Integer, _
                             ByRef ret_files() As Files, _
                             ByRef ErrorMessage As String) As Integer

        Dim sSql As String
        Dim i As Integer = 0
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.GetFiles"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As Files
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            env.WriteTrace(2, "Entry ", sIdm)
            env.WriteTrace(3, "Offer:" & Offer.ToString, sIdm)

            iReturn = GetFiles2(Offer, False, ret_files, ErrorMessage)

            env.WriteTrace(2, "End ", sIdm)
            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ErrorResult
        End Try

    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' GetCategories: Read Categories
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function GetCategories(ByVal sql As String, _
                                  ByRef ret_categories() As Category, _
                                  ByVal start As Integer, _
                                  ByVal count As Integer, _
                                  ByVal username As String, _
                                  ByRef ErrorMessage As String) As Integer

        Dim sSql As String
        Dim i As Integer = 0
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.GetCategories"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As Category
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            env.WriteTrace(2, "Entry ", sIdm)
            env.WriteTrace(3, "Sql:" & sql, sIdm)

            sSql = sqlDistance(sql, "category", "", username)

            env.WriteTrace(3, "sSql after: " & sSql, sIdm)

            sSql = LCase(sSql)
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
                Dim result As Category
                If sSql.Contains("select count") Then
                    myReader.Read()
                    iReturn = myReader.GetInt64(0)
                Else
                    Do While myReader.Read()
                        result = New Category
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category_id"))) Then
                            result.category_id = myReader.GetValue(myReader.GetOrdinal("Category_id"))
                            env.WriteTrace(3, "Category_id: " & result.category_id, sIdm)
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category_name"))) Then
                            result.category_name = myReader.GetValue(myReader.GetOrdinal("Category_name"))
                            env.WriteTrace(3, "Category_name: " & result.category_name, sIdm)
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category_description"))) Then
                            result.category_desc = myReader.GetValue(myReader.GetOrdinal("Category_description"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("status"))) Then
                            result.status = myReader.GetValue(myReader.GetOrdinal("status"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lng"))) Then
                            result.lng = myReader.GetValue(myReader.GetOrdinal("lng"))
                        End If
                        'If mySelectQuery.Contains("radians(") Then
                        '    If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Distance"))) Then
                        '        result.Distance = myReader.GetValue(myReader.GetOrdinal("Distance"))
                        '    End If
                        'End If
                        retVarList.Add(result)
                    Loop
                    retVar = retVarList.ToArray(GetType(Category))
                    iReturn = 1
                End If
            Else
                env.WriteTrace(3, "No data read from table request ", sIdm)
            End If
            ret_categories = retVar
            env.WriteTrace(2, "End ", sIdm)
            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ErrorResult
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
    ''' GetActCategories: Read Activity Categories
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 05-10-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function GetActCategories(ByVal sql As String, _
                                     ByRef ret_categories() As Category, _
                                     ByVal start As Integer, _
                                     ByVal count As Integer, _
                                     ByVal username As String, _
                                     ByRef ErrorMessage As String) As Integer

        Dim sSql As String
        Dim i As Integer = 0
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.GetActCategories"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As Category
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            env.WriteTrace(2, "Entry ", sIdm)
            env.WriteTrace(3, "Sql:" & sql, sIdm)

            sSql = sqlDistance(sql, "activity_category", "", username)

            env.WriteTrace(3, "sSql after: " & sSql, sIdm)

            sSql = LCase(sSql)
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
                Dim result As Category
                If sSql.Contains("select count") Then
                    myReader.Read()
                    iReturn = myReader.GetInt64(0)
                Else
                    Do While myReader.Read()
                        result = New Category
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category_id"))) Then
                            result.category_id = myReader.GetValue(myReader.GetOrdinal("Category_id"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category_name"))) Then
                            result.category_name = myReader.GetValue(myReader.GetOrdinal("Category_name"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category_description"))) Then
                            result.category_desc = myReader.GetValue(myReader.GetOrdinal("Category_description"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("status"))) Then
                            result.status = myReader.GetValue(myReader.GetOrdinal("status"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lng"))) Then
                            result.lng = myReader.GetValue(myReader.GetOrdinal("lng"))
                        End If
                        'If mySelectQuery.Contains("radians(") Then
                        '    If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Distance"))) Then
                        '        result.Distance = myReader.GetValue(myReader.GetOrdinal("Distance"))
                        '    End If
                        'End If
                        retVarList.Add(result)
                    Loop
                    retVar = retVarList.ToArray(GetType(Category))
                    iReturn = 1
                End If
            Else
                env.WriteTrace(3, "No data read from table request ", sIdm)
            End If
            ret_categories = retVar
            env.WriteTrace(2, "End ", sIdm)
            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ErrorResult
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
    ''' GetCompCategories: Read Company Categories
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 21-11-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function GetCompCategories(ByVal sql As String, _
                                      ByRef ret_categories() As Category, _
                                      ByVal start As Integer, _
                                      ByVal count As Integer, _
                                      ByVal username As String, _
                                      ByRef ErrorMessage As String) As Integer

        Dim sSql As String
        Dim i As Integer = 0
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.GetCompCategories"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As Category
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            env.WriteTrace(2, "Entry ", sIdm)
            env.WriteTrace(3, "Sql:" & sql, sIdm)

            sSql = sqlDistance(sql, "company_category", "", username)

            env.WriteTrace(3, "sSql after: " & sSql, sIdm)

            sSql = LCase(sSql)
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
                Dim result As Category
                If sSql.Contains("select count") Then
                    myReader.Read()
                    iReturn = myReader.GetInt64(0)
                Else
                    Do While myReader.Read()
                        result = New Category
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category_id"))) Then
                            result.category_id = myReader.GetValue(myReader.GetOrdinal("Category_id"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category_name"))) Then
                            result.category_name = myReader.GetValue(myReader.GetOrdinal("Category_name"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Category_description"))) Then
                            result.category_desc = myReader.GetValue(myReader.GetOrdinal("Category_description"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("status"))) Then
                            result.status = myReader.GetValue(myReader.GetOrdinal("status"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lng"))) Then
                            result.lng = myReader.GetValue(myReader.GetOrdinal("lng"))
                        End If
                        'If mySelectQuery.Contains("radians(") Then
                        '    If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Distance"))) Then
                        '        result.Distance = myReader.GetValue(myReader.GetOrdinal("Distance"))
                        '    End If
                        'End If
                        retVarList.Add(result)
                    Loop
                    retVar = retVarList.ToArray(GetType(Category))
                    iReturn = 1
                End If
            Else
                env.WriteTrace(3, "No data read from table request ", sIdm)
            End If
            ret_categories = retVar
            env.WriteTrace(2, "End ", sIdm)
            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ErrorResult
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
    ''' UpdateCategory: Update Categories
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
     Public Function UpdateCategory(ByVal Login As String, _
                                    ByVal Category_id As String, _
                                    ByVal Category_name As String, _
                                    ByVal Category_desc As String, _
                                    ByVal Status As Integer, _
                                    ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String
        Dim i As Integer = 0

        Dim stUserProfile As DataAccess.UserProfile
        Dim stCategory As DataAccess.stCategory

        Const sIdm As String = "ENGService.UpdateCategory"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Update category by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then


                        sSql = "Category_id=" & Category_id

                        stCategory = env.DataAccess.getCategory(sSql)

                        If stCategory.category_id <> 0 Then

                            bOK = env.DataAccess.DBupdate("category", _
                                                          "Category_id=" & Category_id, _
                                                          "Category_name", CDBStr(Category_name), _
                                                          "Category_description", CDBStr(Category_desc), _
                                                          "Status", Status.ToString)

                            If bOK Then
                                env.WriteTrace(3, "category updated identity = " & Category_id, sIdm)
                                ErrorMessage = ""

                                sSql = "Category_id=" & Category_id

                                stCategory = env.DataAccess.getCategory(sSql)

                                If stCategory.category_id <> 0 Then
                                    env.WriteTrace(3, "category identity = " & stCategory.category_id.ToString, sIdm)
                                    ErrorMessage = ""

                                    Notify(Login, _
                                           EventAddCategory, _
                                           stCategory.category_id, _
                                           stUserProfile.Name, _
                                           stUserProfile.Login, _
                                           stCategory.category_name, _
                                           stCategory.category_desc, _
                                           stCategory.lng, _
                                           1, _
                                           ErrorMessage)

                                    iReturn = stCategory.category_id
                                Else
                                    env.WriteTrace(3, "category not updated, error in DataAccess module", sIdm)
                                    ErrorMessage = "InternalErrorInDb"
                                    iReturn = ErrorResult
                                End If
                            Else
                                env.WriteTrace(3, "category not updated, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorinDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "category not existing, error in DataAccess module", sIdm)
                            ErrorMessage = "CategoryNotExistingInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAPromoter"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' UpdateActCategory: Update Activity Categories
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 05-10-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
     Public Function UpdateActCategory(ByVal Login As String, _
                                       ByVal Category_id As String, _
                                       ByVal Category_name As String, _
                                       ByVal Category_desc As String, _
                                       ByVal Status As Integer, _
                                       ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String
        Dim i As Integer = 0

        Dim stUserProfile As DataAccess.UserProfile
        Dim stCategory As DataAccess.stCategory

        Const sIdm As String = "ENGService.UpdateActCategory"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Update activity_category by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then


                        sSql = "Category_id=" & Category_id

                        stCategory = env.DataAccess.getActCategory(sSql)

                        If stCategory.category_id <> 0 Then

                            bOK = env.DataAccess.DBupdate("activity_category", _
                                                          "Category_id=" & Category_id, _
                                                          "Category_name", CDBStr(Category_name), _
                                                          "Category_description", CDBStr(Category_desc), _
                                                          "Status", Status.ToString)

                            If bOK Then
                                env.WriteTrace(3, "activity_category updated identity = " & Category_id, sIdm)
                                ErrorMessage = ""

                                sSql = "Category_id=" & Category_id

                                stCategory = env.DataAccess.getActCategory(sSql)

                                If stCategory.category_id <> 0 Then
                                    env.WriteTrace(3, "activity_category identity = " & stCategory.category_id.ToString, sIdm)
                                    ErrorMessage = ""

                                    Notify(Login, _
                                           EventAddCategory, _
                                           stCategory.category_id, _
                                           stUserProfile.Name, _
                                           stUserProfile.Login, _
                                           stCategory.category_name, _
                                           stCategory.category_desc, _
                                           stCategory.lng, _
                                           1, _
                                           ErrorMessage)

                                    iReturn = stCategory.category_id
                                Else
                                    env.WriteTrace(3, "activity_category not updated, error in DataAccess module", sIdm)
                                    ErrorMessage = "InternalErrorInDb"
                                    iReturn = ErrorResult
                                End If
                            Else
                                env.WriteTrace(3, "activity_category not updated, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorinDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "activity_category not existing, error in DataAccess module", sIdm)
                            ErrorMessage = "CategoryNotExistingInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAPromoter"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' UpdateCompCategory: Update Company Categories
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 21-11-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
     Public Function UpdateCompCategory(ByVal Login As String, _
                                       ByVal Category_id As String, _
                                       ByVal Category_name As String, _
                                       ByVal Category_desc As String, _
                                       ByVal Status As Integer, _
                                       ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String
        Dim i As Integer = 0

        Dim stUserProfile As DataAccess.UserProfile
        Dim stCategory As DataAccess.stCategory

        Const sIdm As String = "ENGService.UpdateCompCategory"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Update company_category by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then


                        sSql = "Category_id=" & Category_id

                        stCategory = env.DataAccess.getCompCategory(sSql)

                        If stCategory.category_id <> 0 Then

                            bOK = env.DataAccess.DBupdate("company_category", _
                                                          "Category_id=" & Category_id, _
                                                          "Category_name", CDBStr(Category_name), _
                                                          "Category_description", CDBStr(Category_desc), _
                                                          "Status", Status.ToString)

                            If bOK Then
                                env.WriteTrace(3, "company_category updated identity = " & Category_id, sIdm)
                                ErrorMessage = ""

                                sSql = "Category_id=" & Category_id

                                stCategory = env.DataAccess.getCompCategory(sSql)

                                If stCategory.category_id <> 0 Then
                                    env.WriteTrace(3, "company_category identity = " & stCategory.category_id.ToString, sIdm)
                                    ErrorMessage = ""

                                    Notify(Login, _
                                           EventAddCategory, _
                                           stCategory.category_id, _
                                           stUserProfile.Name, _
                                           stUserProfile.Login, _
                                           stCategory.category_name, _
                                           stCategory.category_desc, _
                                           stCategory.lng, _
                                           1, _
                                           ErrorMessage)

                                    iReturn = stCategory.category_id
                                Else
                                    env.WriteTrace(3, "company_category not updated, error in DataAccess module", sIdm)
                                    ErrorMessage = "InternalErrorInDb"
                                    iReturn = ErrorResult
                                End If
                            Else
                                env.WriteTrace(3, "company_category not updated, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorinDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "company_category not existing, error in DataAccess module", sIdm)
                            ErrorMessage = "CategoryNotExistingInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAPromoter"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' UpdateRegion: Update region data
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 29-06-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function UpdateRegion(ByVal Login As String, _
                                  ByVal id As String, _
                                  ByVal name As String, _
                                  ByVal supraRegion As String, _
                                  ByVal country As String, _
                                  ByVal country_code As String, _
                                  ByVal lat As String, _
                                  ByVal lon As String, _
                                  ByVal radius As String, _
                                  ByVal lng As String, _
                                  ByRef ErrorMessage As String) As Integer

        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql, sCommand() As String
        Dim i As Integer = 0

        Dim stUserProfile As DataAccess.UserProfile
        Dim stRegion As DataAccess.stRegion

        Const sIdm As String = "ENGService.UpdateRegion"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Update region by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then


                        sSql = "id=" & id

                        stRegion = env.DataAccess.getRegion(sSql)

                        If stRegion.id <> 0 Then

                            i = 0
                            If name <> "" Then
                                ReDim Preserve sCommand(i + 1)
                                sCommand(i) = "name"
                                sCommand(i + 1) = CDBStr(name)
                                i += 2
                            End If
                            If supraRegion <> "" Then
                                ReDim Preserve sCommand(i + 1)
                                sCommand(i) = "supraRegion"
                                sCommand(i + 1) = CDBStr(supraRegion)
                                i += 2
                            End If
                            If country <> "" Then
                                ReDim Preserve sCommand(i + 1)
                                sCommand(i) = "country"
                                sCommand(i + 1) = CDBStr(country)
                                i += 2
                            End If
                            If country_code <> "" Then
                                ReDim Preserve sCommand(i + 1)
                                sCommand(i) = "country_code"
                                sCommand(i + 1) = CDBStr(country_code)
                                i += 2
                            End If
                            If lat <> "" Then
                                ReDim Preserve sCommand(i + 1)
                                sCommand(i) = "lat"
                                sCommand(i + 1) = lat
                                i += 2
                            End If
                            If lon <> "" Then
                                ReDim Preserve sCommand(i + 1)
                                sCommand(i) = "lon"
                                sCommand(i + 1) = lon
                                i += 2
                            End If
                            If radius <> "" Then
                                ReDim Preserve sCommand(i + 1)
                                sCommand(i) = "radius"
                                sCommand(i + 1) = radius
                                i += 2
                            End If
                            If lng <> "" Then
                                ReDim Preserve sCommand(i + 1)
                                sCommand(i) = "lng"
                                sCommand(i + 1) = CDBStr(lng)
                            End If

                            bOK = env.DataAccess.DBupdate("regions", _
                                                          "id = " & id, _
                                                          sCommand)

                            If bOK Then
                                env.WriteTrace(3, "region updated identity = " & id, sIdm)
                                ErrorMessage = ""

                                iReturn = CInt(id)
                            Else
                                env.WriteTrace(3, "region not updated, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "region not updated, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorinDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAPromoter"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' DeleteRegion: Delete region
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 29-06-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
      Public Function DeleteRegion(ByVal Login As String, _
                                   ByVal id As String, _
                                   ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stRegion As DataAccess.stRegion

        Const sIdm As String = "ENGService.DeleteRegion"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Delete Category by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        sSql = "id=" & id

                        stRegion = env.DataAccess.getRegion(sSql)

                        If stRegion.id <> 0 Then

                            bOK = env.DataAccess.DBdelete("regions", _
                                                          "id=" & id)

                            If bOK Then
                                env.WriteTrace(3, "region deleted, identity = " & id, sIdm)
                                ErrorMessage = ""
                                iReturn = CInt(id)
                            Else
                                env.WriteTrace(3, "region not deleted, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "region not existing, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAPromoter"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' UpdateCaDeleteCategorytegory: Delete Categories
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
      Public Function DeleteCategory(ByVal Login As String, _
                                     ByVal Category_id As String, _
                                     ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stCategory As DataAccess.stCategory

        Const sIdm As String = "ENGService.DeleteCategory"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Delete Category by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        sSql = "Category_id=" & Category_id

                        stCategory = env.DataAccess.getCategory(sSql)

                        If stCategory.category_id <> 0 Then

                            bOK = env.DataAccess.DBdelete("category", _
                                                          "Category_id=" & Category_id)

                            If bOK Then
                                env.WriteTrace(3, "Category deleted, identity = " & Category_id, sIdm)
                                ErrorMessage = ""
                                iReturn = CInt(Category_id)
                            Else
                                env.WriteTrace(3, "Category not deleted, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "Category not existing, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAPromoter"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' DeleteActCategory: Delete activities Categories
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 05-10-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
      Public Function DeleteActCategory(ByVal Login As String, _
                                        ByVal Category_id As String, _
                                        ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stCategory As DataAccess.stCategory

        Const sIdm As String = "ENGService.DeleteActCategory"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Delete Category by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        sSql = "Category_id=" & Category_id

                        stCategory = env.DataAccess.getActCategory(sSql)

                        If stCategory.category_id <> 0 Then

                            bOK = env.DataAccess.DBdelete("activity_category", _
                                                          "Category_id=" & Category_id)

                            If bOK Then
                                env.WriteTrace(3, "activity_category deleted, identity = " & Category_id, sIdm)
                                ErrorMessage = ""
                                iReturn = CInt(Category_id)
                            Else
                                env.WriteTrace(3, "activity_category not deleted, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "activity_category not existing, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAPromoter"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' DeleteCompCategory: Delete company Categories
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 21-11-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
      Public Function DeleteCompCategory(ByVal Login As String, _
                                         ByVal Category_id As String, _
                                         ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stCategory As DataAccess.stCategory

        Const sIdm As String = "ENGService.DeleteCompCategory"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Delete Company Category by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        sSql = "Category_id=" & Category_id

                        stCategory = env.DataAccess.getCompCategory(sSql)

                        If stCategory.category_id <> 0 Then

                            bOK = env.DataAccess.DBdelete("company_category", _
                                                          "Category_id=" & Category_id)

                            If bOK Then
                                env.WriteTrace(3, "company_category deleted, identity = " & Category_id, sIdm)
                                ErrorMessage = ""
                                iReturn = CInt(Category_id)
                            Else
                                env.WriteTrace(3, "company_category not deleted, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "company_category not existing, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAPromoter"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' DeleteRecommendation: Delete Recommendation
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 17-02-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
      Public Function DeleteRecommendation(ByVal Login As String, _
                                           ByVal Rec_id As String, _
                                           ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stRecommendation As DataAccess.stRecommendations

        Const sIdm As String = "ENGService.DeleteRecommendation"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Delete Recommendation by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        sSql = "recid=" & Rec_id

                        stRecommendation = env.DataAccess.getRecommendation(sSql)

                        If stRecommendation.recid <> 0 Then

                            bOK = env.DataAccess.DBdelete("recommendations", _
                                                          "recid=" & Rec_id)

                            If bOK Then
                                env.WriteTrace(3, "Recommendation deleted, identity = " & Rec_id, sIdm)
                                ErrorMessage = ""
                                iReturn = CInt(Rec_id)
                            Else
                                env.WriteTrace(3, "Recommendation not deleted, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "Recommendation not existing, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAPromoter"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' AddActivity: Add Activity
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' 02-07-2012              Add new parameters for phase 2
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
     Public Function AddActivity(ByVal Login As String, _
                                 ByVal Category As String, _
                                 ByVal Short_desc As String, _
                                 ByVal Detailed_info As String, _
                                 ByVal When_Activity As String, _
                                 ByVal Where_Activity As String, _
                                 ByVal Deadline As Date, _
                                 ByVal ContactType As Integer, _
                                 ByVal OrgName As String, _
                                 ByVal Title As String, _
                                 ByVal DateOfActivity As Date, _
                                 ByVal Address As String, _
                                 ByVal Telephone As String, _
                                 ByVal Price As String, _
                                 ByVal Subscription As Integer, _
                                 ByVal MaxParticipants As Integer, _
                                 ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String
        Dim sLatLon(), sLat, sLon As String
        Dim bLatLon As Boolean

        Dim stUserProfile As DataAccess.UserProfile
        Dim stActivity As DataAccess.stCatalogue

        Const sIdm As String = "ENGService.AddActivity"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Add activity by user:" & Login, sIdm)

            If OrgName <> "" Then

                stUserProfile = env.DataAccess.getUserProfile(Login)

                If stUserProfile.User_id <> 0 Then
                    If stUserProfile.Enabled = 1 Then

                        If stUserProfile.Role = Role.Area_manager Or _
                           stUserProfile.Role = Role.Sys_admin Or _
                           stUserProfile.Role = Role.Country_admin Or _
                           stUserProfile.Role = Role.Hub Or _
                           stUserProfile.Role = Role.Regional_admin Then

                            If Trim(Where_Activity) <> "" Then
                                sLatLon = Where_Activity.Split("/")
                                If sLatLon.Length = 2 Then
                                    bLatLon = True
                                    sLat = sLatLon(0).Replace(",", ".")
                                    sLon = sLatLon(1).Replace(",", ".")
                                Else
                                    bLatLon = False
                                End If
                            Else
                                bLatLon = False
                            End If
                            If Not bLatLon Then
                                sLat = stUserProfile.Last_loc_lat.ToString.Replace(",", ".")
                                sLon = stUserProfile.last_loc_lon.ToString.Replace(",", ".")
                            End If

                            bOK = env.DataAccess.DBinsert("catalogue", _
                                                          "Offer_type", OfferType.Activity, _
                                                          "Category_id", CDBStr(Category), _
                                                          "Promoter_id", stUserProfile.User_id, _
                                                          "Short_description", CDBStr(Short_desc), _
                                                          "Detailed_info", CDBStr(Detailed_info), _
                                                          "WhenCat", CDBStr(When_Activity), _
                                                          "WhereCat", CDBStr(sLat & "/" & sLon), _
                                                          "Deadline", env.DataAccess.CDBDate(Deadline), _
                                                          "lng", CDBStr(getUserLanguage(stUserProfile.Language)), _
                                                          "lat", sLat, _
                                                          "lon", sLon, _
                                                          "ContactType", ContactType.ToString, _
                                                          "OrgName", CDBStr(OrgName), _
                                                          "Title", CDBStr(Title), _
                                                          "DateOfActivity", env.DataAccess.CDBDate(DateOfActivity), _
                                                          "Address", CDBStr(Address), _
                                                          "Telephone", CDBStr(Telephone), _
                                                          "Price", CDBStr(Price), _
                                                          "Subscription", Subscription.ToString, _
                                                          "MaxParticipants", MaxParticipants.ToString, _
                                                          "SubmissionDate", env.DataAccess.CDBDate(DateTime.Now))

                            If bOK Then
                                env.WriteTrace(3, "activity submitted OK, now read the activity id", sIdm)

                                sSql = "Offer_type=" & OfferType.Activity & _
                                       " AND Category_id=" & CDBStr(Category) & _
                                       " AND Promoter_id=" & stUserProfile.User_id & " ORDER BY Offer_id Desc"

                                stActivity = env.DataAccess.getCatalogue(sSql)

                                If stActivity.Id <> 0 Then
                                    env.WriteTrace(3, "activity identity = " & stActivity.Id.ToString, sIdm)
                                    ErrorMessage = ""

                                    Notify(Login, _
                                           EventAddActivity, _
                                           stActivity.Id, _
                                           stUserProfile.Name, _
                                           stUserProfile.Login, _
                                           Title, _
                                           stActivity.Short_Description, _
                                           stActivity.lng, _
                                           ContactType, _
                                           ErrorMessage)

                                    iReturn = stActivity.Id
                                Else
                                    env.WriteTrace(3, "activity not created, error in DataAccess module", sIdm)
                                    ErrorMessage = "InternalErrorInDb"
                                    iReturn = ErrorResult
                                End If
                            Else
                                env.WriteTrace(3, "activity not created, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "User is not a promoter", sIdm)
                            ErrorMessage = "UserNotAPromoter"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User disabled", sIdm)
                        ErrorMessage = "UserDisabled"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User not registered", sIdm)
                    ErrorMessage = "UserNotRegistered"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "activity not created, missing data", sIdm)
                ErrorMessage = "MissingData"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try
    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' AddMpOffer: Add Market Place offer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Date      Version     Comments
    ''' ---------------------------------------------------------------------------------
    ''' 16-01-2013   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function AddMpOffer(ByVal Login As String, _
                               ByVal Category As String, _
                               ByVal Short_desc As String, _
                               ByVal Detailed_info As String, _
                               ByVal When_MpOffer As String, _
                               ByVal Where_MpOffer As String, _
                               ByVal Deadline As Date, _
                               ByVal ContactType As Integer, _
                               ByVal OrgName As String, _
                               ByVal Title As String, _
                               ByVal DateOfOffer As Date, _
                               ByVal Address As String, _
                               ByVal Telephone As String, _
                               ByVal Mobile As String, _
                               ByVal Email As String, _
                               ByVal url_booking As String, _
                               ByVal url_web As String, _
                               ByVal url_brochure As String, _
                               ByVal Price As String, _
                               ByVal Subscription As Integer, _
                               ByVal MaxParticipants As Integer, _
                               ByVal url_booking_dsc As String, _
                               ByVal url_web_dsc As String, _
                               ByVal url_brochure_dsc As String, _
                               ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String
        Dim sLatLon(), sLat, sLon As String
        Dim bLatLon As Boolean

        Dim stUserProfile As DataAccess.UserProfile
        Dim stMpOffer As DataAccess.stCatalogue

        Const sIdm As String = "ENGService.AddMpOffer"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Add Market Place Offer by user:" & Login, sIdm)

            If OrgName <> "" Then

                stUserProfile = env.DataAccess.getUserProfile(Login)

                If stUserProfile.User_id <> 0 Then
                    If stUserProfile.Enabled = 1 Then

                        If stUserProfile.Role = Role.Area_manager Or _
                           stUserProfile.Role = Role.Sys_admin Or _
                           stUserProfile.Role = Role.Country_admin Or _
                           stUserProfile.Role = Role.Hub Or _
                           stUserProfile.Role = Role.Small_bussines Or _
                           stUserProfile.Role = Role.Big_bussines Or _
                           stUserProfile.Role = Role.Regional_admin Then

                            If Trim(Where_MpOffer) <> "" Then
                                sLatLon = Where_MpOffer.Split("/")
                                If sLatLon.Length = 2 Then
                                    bLatLon = True
                                    sLat = sLatLon(0).Replace(",", ".")
                                    sLon = sLatLon(1).Replace(",", ".")
                                Else
                                    bLatLon = False
                                End If
                            Else
                                bLatLon = False
                            End If
                            If Not bLatLon Then
                                sLat = stUserProfile.Last_loc_lat.ToString.Replace(",", ".")
                                sLon = stUserProfile.last_loc_lon.ToString.Replace(",", ".")
                            End If

                            bOK = env.DataAccess.DBinsert("catalogue", _
                                                          "Offer_type", OfferType.MarketPlace, _
                                                          "Category_id", CDBStr(Category), _
                                                          "Promoter_id", stUserProfile.User_id, _
                                                          "Short_description", CDBStr(Short_desc), _
                                                          "Detailed_info", CDBStr(Detailed_info), _
                                                          "WhenCat", CDBStr(When_MpOffer), _
                                                          "WhereCat", CDBStr(sLat & "/" & sLon), _
                                                          "Deadline", env.DataAccess.CDBDate(Deadline), _
                                                          "lng", CDBStr(getUserLanguage(stUserProfile.Language)), _
                                                          "lat", sLat, _
                                                          "lon", sLon, _
                                                          "ContactType", ContactType.ToString, _
                                                          "OrgName", CDBStr(OrgName), _
                                                          "Title", CDBStr(Title), _
                                                          "DateOfActivity", env.DataAccess.CDBDate(DateOfOffer), _
                                                          "Address", CDBStr(Address), _
                                                          "Telephone", CDBStr(Telephone), _
                                                          "Mobile", CDBStr(Mobile), _
                                                          "Email", CDBStr(Email), _
                                                          "url_booking", CDBStr(url_booking), _
                                                          "url_web", CDBStr(url_web), _
                                                          "url_brochure", CDBStr(url_brochure), _
                                                          "Price", CDBStr(Price), _
                                                          "Subscription", Subscription.ToString, _
                                                          "MaxParticipants", MaxParticipants.ToString, _
                                                          "SubmissionDate", env.DataAccess.CDBDate(DateTime.Now), _
                                                          "url_booking_dsc", CDBStr(url_booking_dsc), _
                                                          "url_web_dsc", CDBStr(url_web_dsc), _
                                                          "url_brochure_dsc", CDBStr(url_brochure_dsc))


                            If bOK Then
                                env.WriteTrace(3, "Market Place Offer submitted OK, now read the Market Place Offer id", sIdm)

                                sSql = "Offer_type=" & OfferType.MarketPlace & _
                                       " AND Category_id=" & CDBStr(Category) & _
                                       " AND Promoter_id=" & stUserProfile.User_id & " ORDER BY Offer_id Desc"

                                stMpOffer = env.DataAccess.getCatalogue(sSql)

                                If stMpOffer.Id <> 0 Then
                                    env.WriteTrace(3, "Market Place Offer identity = " & stMpOffer.Id.ToString, sIdm)
                                    ErrorMessage = ""

                                    Notify(Login, _
                                           EventAddMpOffer, _
                                           stMpOffer.Id, _
                                           stUserProfile.Name, _
                                           stUserProfile.Login, _
                                           Title, _
                                           stMpOffer.Short_Description, _
                                           stMpOffer.lng, _
                                           ContactType, _
                                           ErrorMessage)

                                    iReturn = stMpOffer.Id
                                Else
                                    env.WriteTrace(3, "Market Place Offer not created, error in DataAccess module", sIdm)
                                    ErrorMessage = "InternalErrorInDb"
                                    iReturn = ErrorResult
                                End If
                            Else
                                env.WriteTrace(3, "Market Place Offer not created, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "User is not a promoter", sIdm)
                            ErrorMessage = "UserNotAPromoter"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User disabled", sIdm)
                        ErrorMessage = "UserDisabled"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User not registered", sIdm)
                    ErrorMessage = "UserNotRegistered"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "Market Place Offer not created, missing data", sIdm)
                ErrorMessage = "MissingData"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try
    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' GetActivities: Get Activities
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function GetActivities(ByVal sql As String, _
                                  ByRef ret_Activities() As Activity, _
                                  ByVal start As Integer, _
                                  ByVal count As Integer, _
                                  ByVal username As String, _
                                  ByRef ErrorMessage As String) As Integer
        Dim sSql As String
        Dim i As Integer = 0
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.GetActivities"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As Activity
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            env.WriteTrace(2, "Entry ", sIdm)
            env.WriteTrace(3, "Sql:" & sql, sIdm)

            sSql = sqlDistance(sql, "catalogue", "Activity", username)

            env.WriteTrace(3, "Sql after:" & sSql, sIdm)

            sSql = LCase(sSql)
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
                Dim result As Activity
                If sSql.Contains("select count") Then
                    myReader.Read()
                    iReturn = myReader.GetInt64(0)
                Else
                    Do While myReader.Read()
                        result = New Activity
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Offer_id"))) Then
                            result.Id = myReader.GetValue(myReader.GetOrdinal("Offer_id"))
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
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lng"))) Then
                            result.lng = myReader.GetValue(myReader.GetOrdinal("lng"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Candidates"))) Then
                            env.WriteTrace(2, "Candidates = " & myReader.GetValue(myReader.GetOrdinal("Candidates")), sIdm)
                            result.Candidates = myReader.GetValue(myReader.GetOrdinal("Candidates"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("SubmissionDate"))) Then
                            result.SubmissionDate = myReader.GetValue(myReader.GetOrdinal("SubmissionDate"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("OrgName"))) Then
                            result.OrgName = myReader.GetValue(myReader.GetOrdinal("OrgName"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("ContactType"))) Then
                            result.ContactType = myReader.GetValue(myReader.GetOrdinal("ContactType"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Title"))) Then
                            result.Title = myReader.GetValue(myReader.GetOrdinal("Title"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("DateOfActivity"))) Then
                            result.DateOfActivity = myReader.GetValue(myReader.GetOrdinal("DateOfActivity"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Address"))) Then
                            result.Address = myReader.GetValue(myReader.GetOrdinal("Address"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Telephone"))) Then
                            result.Telephone = myReader.GetValue(myReader.GetOrdinal("Telephone"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Price"))) Then
                            result.Price = myReader.GetValue(myReader.GetOrdinal("Price"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Subscription"))) Then
                            result.Subscription = myReader.GetValue(myReader.GetOrdinal("Subscription"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("MaxParticipants"))) Then
                            result.MaxParticipants = myReader.GetValue(myReader.GetOrdinal("MaxParticipants"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("MaxParticipants"))) Then
                            result.MaxParticipants = myReader.GetValue(myReader.GetOrdinal("MaxParticipants"))
                        End If

                        If mySelectQuery.Contains("radians(") Then
                            If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Distance"))) Then
                                result.Distance = myReader.GetValue(myReader.GetOrdinal("Distance"))
                            End If
                        End If
                        retVarList.Add(result)
                    Loop
                    retVar = retVarList.ToArray(GetType(Activity))
                    iReturn = 1
                End If
            Else
                env.WriteTrace(3, "No data read from table request ", sIdm)
            End If
            ret_Activities = retVar
            env.WriteTrace(2, "End ", sIdm)
            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ErrorResult
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
    ''' GetMpOffers: Get Market Place Offers
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 17-01-2013   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function GetMpOffers(ByVal sql As String, _
                                ByRef ret_mpOffers() As MpOffer, _
                                ByVal start As Integer, _
                                ByVal count As Integer, _
                                ByVal username As String, _
                                ByRef ErrorMessage As String) As Integer
        Dim sSql As String
        Dim i As Integer = 0
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.GetMpOffers"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As MpOffer
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            env.WriteTrace(2, "Entry ", sIdm)
            env.WriteTrace(3, "Sql:" & sql, sIdm)

            sSql = sqlDistance(sql, "catalogue", "MarketPlace", username)

            env.WriteTrace(3, "Sql after:" & sSql, sIdm)

            sSql = LCase(sSql)
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
                Dim result As MpOffer
                If sSql.Contains("select count") Then
                    myReader.Read()
                    iReturn = myReader.GetInt64(0)
                Else
                    Do While myReader.Read()
                        result = New MpOffer
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Offer_id"))) Then
                            result.Id = myReader.GetValue(myReader.GetOrdinal("Offer_id"))
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
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lng"))) Then
                            result.lng = myReader.GetValue(myReader.GetOrdinal("lng"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Candidates"))) Then
                            env.WriteTrace(2, "Candidates = " & myReader.GetValue(myReader.GetOrdinal("Candidates")), sIdm)
                            result.Candidates = myReader.GetValue(myReader.GetOrdinal("Candidates"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("SubmissionDate"))) Then
                            result.SubmissionDate = myReader.GetValue(myReader.GetOrdinal("SubmissionDate"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("OrgName"))) Then
                            result.OrgName = myReader.GetValue(myReader.GetOrdinal("OrgName"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("ContactType"))) Then
                            result.ContactType = myReader.GetValue(myReader.GetOrdinal("ContactType"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Title"))) Then
                            result.Title = myReader.GetValue(myReader.GetOrdinal("Title"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("DateOfActivity"))) Then
                            result.DateOfActivity = myReader.GetValue(myReader.GetOrdinal("DateOfActivity"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Address"))) Then
                            result.Address = myReader.GetValue(myReader.GetOrdinal("Address"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Telephone"))) Then
                            result.Telephone = myReader.GetValue(myReader.GetOrdinal("Telephone"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Mobile"))) Then
                            result.Mobile = myReader.GetValue(myReader.GetOrdinal("Mobile"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Email"))) Then
                            result.Email = myReader.GetValue(myReader.GetOrdinal("Email"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("url_booking"))) Then
                            result.url_booking = myReader.GetValue(myReader.GetOrdinal("url_booking"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("url_web"))) Then
                            result.url_web = myReader.GetValue(myReader.GetOrdinal("url_web"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("url_brochure"))) Then
                            result.url_brochure = myReader.GetValue(myReader.GetOrdinal("url_brochure"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("url_booking_dsc"))) Then
                            result.url_booking = myReader.GetValue(myReader.GetOrdinal("url_booking_dsc"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("url_web_dsc"))) Then
                            result.url_web = myReader.GetValue(myReader.GetOrdinal("url_web_dsc"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("url_brochure_dsc"))) Then
                            result.url_brochure = myReader.GetValue(myReader.GetOrdinal("url_brochure_dsc"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Price"))) Then
                            result.Price = myReader.GetValue(myReader.GetOrdinal("Price"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Subscription"))) Then
                            result.Subscription = myReader.GetValue(myReader.GetOrdinal("Subscription"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("MaxParticipants"))) Then
                            result.MaxParticipants = myReader.GetValue(myReader.GetOrdinal("MaxParticipants"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("MaxParticipants"))) Then
                            result.MaxParticipants = myReader.GetValue(myReader.GetOrdinal("MaxParticipants"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Views"))) Then
                            result.Views = myReader.GetValue(myReader.GetOrdinal("Views"))
                        End If

                        If mySelectQuery.Contains("radians(") Then
                            If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Distance"))) Then
                                result.Distance = myReader.GetValue(myReader.GetOrdinal("Distance"))
                            End If
                        End If
                        retVarList.Add(result)
                    Loop
                    retVar = retVarList.ToArray(GetType(MpOffer))
                    iReturn = 1
                End If
            Else
                env.WriteTrace(3, "No data read from table catalogue ", sIdm)
            End If
            ret_mpOffers = retVar
            env.WriteTrace(2, "End ", sIdm)
            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ErrorResult
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
    ''' UpdateHub: Update Hub
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 27-11-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function UpdateHub(ByVal Login As String, _
                              ByVal Hub_id As Integer, _
                              ByVal Name As String, _
                              ByVal User_id As Integer, _
                              ByVal Area As Integer, _
                              ByVal Hub_average_mark As String, _
                              ByVal Hub_votes As Integer, _
                              ByVal lng As String, _
                              ByVal Category As Integer, _
                              ByVal Address As String, _
                              ByRef ErrorMessage As String) As Integer

        Dim bOK, bInsert As Boolean
        Dim iReturn, i As Integer
        Dim sSql As String
        Dim sCommand() As String
        Dim bAdmin As Boolean

        Dim stUserProfile As DataAccess.UserProfile
        Dim stHub As DataAccess.stHub

        Const sIdm As String = "ENGService.UpdateHub"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Update Hub by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then

                If stUserProfile.Enabled = 1 Then
                    '+--------------------------------------------+
                    '| Check that the request belongs to the user |
                    '+--------------------------------------------+
                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        '+--------------------------------------------------------------------+
                        '| Check if the user assigned to the business, exists in the database |
                        '+--------------------------------------------------------------------+
                        stUserProfile = env.DataAccess.getUserProfile("User_id = " & User_id.ToString)

                        If stUserProfile.User_id <> 0 Then
                            If stUserProfile.Enabled = 1 Then
                                '+--------------------------------------------------------------------+
                                '| The user exists and is not disabled, now check if there is another |
                                '| business assigned to the same user                                 |
                                '+--------------------------------------------------------------------+
                                sSql = "User_id = " & User_id.ToString & " AND SB_id <> " & Hub_id.ToString

                                stHub = env.DataAccess.getHub(sSql)

                                If stHub.Hub_id <> 0 Then
                                    '+---------------------------------------------------------------------------+
                                    '| The user has already a business assigned, so it can not be assigned again |
                                    '+---------------------------------------------------------------------------+
                                    bInsert = False
                                    env.WriteTrace(3, "Hub not created, The user has already a Hub assigned", sIdm)
                                    ErrorMessage = "UserAlreadyHasAHub"
                                    iReturn = ErrorResult
                                Else
                                    bInsert = True
                                End If
                            Else
                                bInsert = False
                                env.WriteTrace(3, "Hub not created, The user is not enabled", sIdm)
                                ErrorMessage = "UserNotEnabled"
                                iReturn = ErrorResult
                            End If
                        Else
                            bInsert = False
                            env.WriteTrace(3, "Hub not created, The user that wants to be assigned to the business does not exist", sIdm)
                            ErrorMessage = "UserNotRegistered"
                            iReturn = ErrorResult
                        End If

                        '+----------------+
                        '| Check the area |
                        '+----------------+
                        If bInsert Then
                            Dim stRegion As DataAccess.stRegion
                            stRegion = env.DataAccess.getRegion("id = " & Area.ToString)

                            If stRegion.id <> 0 Then
                                bInsert = True
                            Else
                                bInsert = False
                                env.WriteTrace(3, "Hub not created, The selected region does not exist", sIdm)
                                ErrorMessage = "RegionDoesNotExist"
                                iReturn = ErrorResult
                            End If
                        End If

                        '+--------------------+
                        '| Check the category |
                        '+--------------------+
                        If bInsert Then
                            Dim stCateg As DataAccess.stCategory
                            stCateg = env.DataAccess.getCompCategory("Category_id = " & Category.ToString)

                            If stCateg.category_id <> 0 Then
                                bInsert = True
                            Else
                                bInsert = False
                                env.WriteTrace(3, "Hub not created, The selected category does not exist", sIdm)
                                ErrorMessage = "CategoryDoesNotExist"
                                iReturn = ErrorResult
                            End If
                        End If

                        If bInsert Then
                            sSql = "Hub_id = " & Hub_id.ToString

                            stHub = env.DataAccess.getHub(sSql)

                            If stHub.Hub_id <> 0 Then

                                If stHub.User_id = stUserProfile.User_id Then
                                    bAdmin = False
                                End If

                                i = 0
                                If User_id <> 0 Then
                                    ReDim Preserve sCommand(i + 1)
                                    sCommand(i) = "User_id"
                                    sCommand(i + 1) = User_id.ToString
                                    i += 2
                                End If
                                If Name <> "" Then
                                    ReDim Preserve sCommand(i + 1)
                                    sCommand(i) = "Name"
                                    sCommand(i + 1) = CDBStr(Name)
                                    i += 2
                                End If
                                If Area <> 0 Then
                                    ReDim Preserve sCommand(i + 1)
                                    sCommand(i) = "Area"
                                    sCommand(i + 1) = Area.ToString
                                    i += 2
                                End If
                                If Hub_average_mark <> "" Then
                                    ReDim Preserve sCommand(i + 1)
                                    sCommand(i) = "Hub_average_mark"
                                    sCommand(i + 1) = Hub_average_mark
                                    i += 2
                                End If
                                If Hub_votes <> 0 Then
                                    ReDim Preserve sCommand(i + 1)
                                    sCommand(i) = "Hub_votes"
                                    sCommand(i + 1) = Hub_votes.ToString
                                    i += 2
                                End If
                                If lng <> "" Then
                                    ReDim Preserve sCommand(i + 1)
                                    sCommand(i) = "lng"
                                    sCommand(i + 1) = CDBStr(lng)
                                    i += 2
                                End If
                                If Category <> 0 Then
                                    ReDim Preserve sCommand(i + 1)
                                    sCommand(i) = "Category"
                                    sCommand(i + 1) = Category.ToString
                                    i += 2
                                End If
                                If Address <> "" Then
                                    ReDim Preserve sCommand(i + 1)
                                    sCommand(i) = "Address"
                                    sCommand(i + 1) = CDBStr(Address)
                                    i += 2
                                End If

                                bOK = env.DataAccess.DBupdate("hub", _
                                                              sSql, _
                                                              sCommand)

                                If bOK Then
                                    env.WriteTrace(3, "Hub updated: " & Hub_id.ToString, sIdm)

                                    iReturn = Hub_id
                                Else
                                    env.WriteTrace(3, "Hub not updated, error in DataAccess module", sIdm)
                                    ErrorMessage = "InternalErrorInDb"
                                    iReturn = ErrorResult
                                End If
                            Else
                                env.WriteTrace(3, "Hub not updated, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If


                        End If
                    End If

                Else
                    env.WriteTrace(3, "Hub does not belongs to the user, error in DataAccess module", sIdm)
                    ErrorMessage = "RequestDoesNotBelongsToUser"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User disabled", sIdm)
                ErrorMessage = "UserDisabled"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' UpdateBusiness: Update Business
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 27-11-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function UpdateBusiness(ByVal Login As String, _
                                   ByVal SB_id As Integer, _
                                   ByVal Name As String, _
                                   ByVal User_id As Integer, _
                                   ByVal Area As Integer, _
                                   ByVal SB_average_mark As String, _
                                   ByVal SB_votes As Integer, _
                                   ByVal lng As String, _
                                   ByVal Category As Integer, _
                                   ByVal Address As String, _
                                   ByRef ErrorMessage As String) As Integer

        Dim bOK, bInsert As Boolean
        Dim iReturn, i As Integer
        Dim sSql As String
        Dim sCommand() As String
        Dim bAdmin As Boolean

        Dim stUserProfile As DataAccess.UserProfile
        Dim stBusiness As DataAccess.stBusiness

        Const sIdm As String = "ENGService.UpdateBusiness"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Update Business by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then

                If stUserProfile.Enabled = 1 Then
                    '+--------------------------------------------+
                    '| Check that the request belongs to the user |
                    '+--------------------------------------------+
                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        '+--------------------------------------------------------------------+
                        '| Check if the user assigned to the business, exists in the database |
                        '+--------------------------------------------------------------------+
                        stUserProfile = env.DataAccess.getUserProfile("User_id = " & User_id.ToString)

                        If stUserProfile.User_id <> 0 Then
                            If stUserProfile.Enabled = 1 Then
                                '+--------------------------------------------------------------------+
                                '| The user exists and is not disabled, now check if there is another |
                                '| business assigned to the same user                                 |
                                '+--------------------------------------------------------------------+
                                sSql = "User_id = " & User_id.ToString & " AND SB_id <> " & SB_id.ToString

                                stBusiness = env.DataAccess.getBusiness(sSql)

                                If stBusiness.SB_id <> 0 Then
                                    '+---------------------------------------------------------------------------+
                                    '| The user has already a business assigned, so it can not be assigned again |
                                    '+---------------------------------------------------------------------------+
                                    bInsert = False
                                    env.WriteTrace(3, "Busines not created, The user has already a business assigned", sIdm)
                                    ErrorMessage = "UserAlreadyHasABusiness"
                                    iReturn = ErrorResult
                                Else
                                    bInsert = True
                                End If
                            Else
                                bInsert = False
                                env.WriteTrace(3, "Busines not created, The user is not enabled", sIdm)
                                ErrorMessage = "UserNotEnabled"
                                iReturn = ErrorResult
                            End If
                        Else
                            bInsert = False
                            env.WriteTrace(3, "Busines not created, The user that wants to be assigned to the business does not exist", sIdm)
                            ErrorMessage = "UserNotRegistered"
                            iReturn = ErrorResult
                        End If

                        '+----------------+
                        '| Check the area |
                        '+----------------+
                        If bInsert Then
                            Dim stRegion As DataAccess.stRegion
                            stRegion = env.DataAccess.getRegion("id = " & Area.ToString)

                            If stRegion.id <> 0 Then
                                bInsert = True
                            Else
                                bInsert = False
                                env.WriteTrace(3, "Busines not created, The selected region does not exist", sIdm)
                                ErrorMessage = "RegionDoesNotExist"
                                iReturn = ErrorResult
                            End If
                        End If

                        '+--------------------+
                        '| Check the category |
                        '+--------------------+
                        If bInsert Then
                            Dim stCateg As DataAccess.stCategory
                            stCateg = env.DataAccess.getCompCategory("Category_id = " & Category.ToString)

                            If stCateg.category_id <> 0 Then
                                bInsert = True
                            Else
                                bInsert = False
                                env.WriteTrace(3, "Busines not created, The selected category does not exist", sIdm)
                                ErrorMessage = "CategoryDoesNotExist"
                                iReturn = ErrorResult
                            End If
                        End If

                        If bInsert Then
                            sSql = "SB_id = " & SB_id.ToString

                            stBusiness = env.DataAccess.getBusiness(sSql)

                            If stBusiness.SB_id <> 0 Then

                                If stBusiness.User_id = stUserProfile.User_id Then
                                    bAdmin = False
                                End If

                                i = 0
                                If User_id <> 0 Then
                                    ReDim Preserve sCommand(i + 1)
                                    sCommand(i) = "User_id"
                                    sCommand(i + 1) = User_id.ToString
                                    i += 2
                                End If
                                If Name <> "" Then
                                    ReDim Preserve sCommand(i + 1)
                                    sCommand(i) = "Name"
                                    sCommand(i + 1) = CDBStr(Name)
                                    i += 2
                                End If
                                If Area <> 0 Then
                                    ReDim Preserve sCommand(i + 1)
                                    sCommand(i) = "Area"
                                    sCommand(i + 1) = Area.ToString
                                    i += 2
                                End If
                                If SB_average_mark <> "" Then
                                    ReDim Preserve sCommand(i + 1)
                                    sCommand(i) = "SB_average_mark"
                                    sCommand(i + 1) = SB_average_mark
                                    i += 2
                                End If
                                If SB_votes <> 0 Then
                                    ReDim Preserve sCommand(i + 1)
                                    sCommand(i) = "SB_votes"
                                    sCommand(i + 1) = SB_votes.ToString
                                    i += 2
                                End If
                                If lng <> "" Then
                                    ReDim Preserve sCommand(i + 1)
                                    sCommand(i) = "lng"
                                    sCommand(i + 1) = CDBStr(lng)
                                    i += 2
                                End If
                                If Category <> 0 Then
                                    ReDim Preserve sCommand(i + 1)
                                    sCommand(i) = "Category"
                                    sCommand(i + 1) = Category.ToString
                                    i += 2
                                End If
                                If Address <> "" Then
                                    ReDim Preserve sCommand(i + 1)
                                    sCommand(i) = "Address"
                                    sCommand(i + 1) = CDBStr(Address)
                                    i += 2
                                End If

                                bOK = env.DataAccess.DBupdate("small_business", _
                                                              sSql, _
                                                              sCommand)

                                If bOK Then
                                    env.WriteTrace(3, "Business updated: " & SB_id.ToString, sIdm)

                                    iReturn = SB_id
                                Else
                                    env.WriteTrace(3, "Business not updated, error in DataAccess module", sIdm)
                                    ErrorMessage = "InternalErrorInDb"
                                    iReturn = ErrorResult
                                End If
                            Else
                                env.WriteTrace(3, "Business not updated, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If


                        End If
                    End If

                Else
                    env.WriteTrace(3, "Business does not belongs to the user, error in DataAccess module", sIdm)
                    ErrorMessage = "RequestDoesNotBelongsToUser"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User disabled", sIdm)
                ErrorMessage = "UserDisabled"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' UpdateActivity: Update Activities
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' 02-07-2012              Add parameters of phase 2
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function UpdateActivity(ByVal Login As String, _
                                   ByVal Activity_id As Integer, _
                                   ByVal Category As String, _
                                   ByVal Short_desc As String, _
                                   ByVal Detailed_info As String, _
                                   ByVal When_Activity As String, _
                                   ByVal Where_Activity As String, _
                                   ByVal Deadline As Date, _
                                   ByVal ContactType As Integer, _
                                   ByVal OrgName As String, _
                                   ByVal Title As String, _
                                   ByVal DateOfActivity As Date, _
                                   ByVal Address As String, _
                                   ByVal Telephone As String, _
                                   ByVal Price As String, _
                                   ByVal Subscription As Integer, _
                                   ByVal MaxParticipants As Integer, _
                                   ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn, i As Integer
        Dim sSql As String
        Dim sLatLon(), sLat, sLon, sCommand() As String
        Dim bLatLon, bAdmin As Boolean

        Dim stUserProfile As DataAccess.UserProfile
        Dim stActivity As DataAccess.stCatalogue

        Const sIdm As String = "ENGService.UpdateActivity"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Update Activity by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then
                    '+--------------------------------------------+
                    '| Check that the request belongs to the user |
                    '+--------------------------------------------+
                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then
                        sSql = "Offer_id = " & Activity_id
                        bAdmin = True
                    Else
                        sSql = "Offer_id = " & Activity_id & " And Promoter_id = " & stUserProfile.User_id
                        bAdmin = False
                    End If

                    stActivity = env.DataAccess.getCatalogue(sSql)

                    If stActivity.Id <> 0 Then

                        If Trim(Where_Activity) <> "" Then
                            sLatLon = Where_Activity.Split("/")
                            If sLatLon.Length = 2 Then
                                bLatLon = True
                                sLat = sLatLon(0).Replace(",", ".")
                                sLon = sLatLon(1).Replace(",", ".")
                            Else
                                bLatLon = False
                            End If
                        Else
                            bLatLon = False
                        End If
                        If Not bLatLon Then
                            sLat = stUserProfile.Last_loc_lat.ToString.Replace(",", ".")
                            sLon = stUserProfile.last_loc_lon.ToString.Replace(",", ".")
                        End If

                        If stActivity.Promoter_id = stUserProfile.User_id Then
                            bAdmin = False
                        End If

                        i = 0
                        If Category <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Category_id"
                            sCommand(i + 1) = CDBStr(Category)
                            i += 2
                        End If
                        If Short_desc <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Short_description"
                            sCommand(i + 1) = CDBStr(Short_desc)
                            i += 2
                        End If
                        If Detailed_info <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Detailed_info"
                            sCommand(i + 1) = CDBStr(Detailed_info)
                            i += 2
                        End If
                        If When_Activity <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "WhenCat"
                            sCommand(i + 1) = CDBStr(When_Activity)
                            i += 2
                        End If
                        If Not IsNothing(Deadline) Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Deadline"
                            sCommand(i + 1) = env.DataAccess.CDBDate(Deadline)
                            i += 2
                        End If
                        If Not IsNothing(ContactType) Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "ContactType"
                            sCommand(i + 1) = ContactType.ToString
                            i += 2
                        End If

                        If Not bAdmin Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "WhereCat"
                            sCommand(i + 1) = CDBStr(sLat & "/" & sLon)
                            i += 2
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "lng"
                            sCommand(i + 1) = CDBStr(getUserLanguage(stUserProfile.Language))
                            i += 2
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "lat"
                            sCommand(i + 1) = sLat
                            i += 2
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "lon"
                            sCommand(i + 1) = sLon
                        End If
                        If OrgName <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "OrgName"
                            sCommand(i + 1) = CDBStr(OrgName)
                            i += 2
                        End If
                        If Title <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Title"
                            sCommand(i + 1) = CDBStr(Title)
                            i += 2
                        End If
                        If Not IsNothing(DateOfActivity) Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "DateOfActivity"
                            sCommand(i + 1) = env.DataAccess.CDBDate(DateOfActivity)
                            i += 2
                        End If
                        If Address <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Address"
                            sCommand(i + 1) = CDBStr(Address)
                            i += 2
                        End If
                        If Telephone <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Telephone"
                            sCommand(i + 1) = CDBStr(Telephone)
                            i += 2
                        End If
                        If Price <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Price"
                            sCommand(i + 1) = CDBStr(Price)
                            i += 2
                        End If
                        If Not IsNothing(Subscription) Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Subscription"
                            sCommand(i + 1) = Subscription.ToString
                            i += 2
                        End If
                        If Not IsNothing(MaxParticipants) Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "MaxParticipants"
                            sCommand(i + 1) = MaxParticipants.ToString
                            i += 2
                        End If

                        bOK = env.DataAccess.DBupdate("catalogue", _
                                                       "Offer_id = " & Activity_id.ToString, _
                                                       sCommand)

                        If bOK Then
                            env.WriteTrace(3, "Activity updated OK, now read the request id", sIdm)

                            sSql = "Offer_id = " & Activity_id.ToString

                            stActivity = env.DataAccess.getCatalogue(sSql)

                            If stActivity.Id <> 0 Then
                                env.WriteTrace(3, "activity identity = " & stActivity.Id.ToString, sIdm)
                                ErrorMessage = ""

                                Notify(Login, _
                                       EventAddActivity, _
                                       stActivity.Id, _
                                       stUserProfile.Name, _
                                       stUserProfile.Login, _
                                       Title, _
                                       stActivity.Short_Description, _
                                       stActivity.lng, _
                                       ContactType, _
                                       ErrorMessage)

                                iReturn = stActivity.Id
                            Else
                                env.WriteTrace(3, "activity not updated, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "Activity not updated, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "Activity does not belongs to the user, error in DataAccess module", sIdm)
                        ErrorMessage = "RequestDoesNotBelongsToUser"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' UpdateMpOffer: Update Market Place Offer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 16-01-2013   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function UpdateMpOffer(ByVal Login As String, _
                                   ByVal Offer_id As Integer, _
                                   ByVal Category As String, _
                                   ByVal Short_desc As String, _
                                   ByVal Detailed_info As String, _
                                   ByVal When_Offer As String, _
                                   ByVal Where_Offer As String, _
                                   ByVal Deadline As Date, _
                                   ByVal ContactType As Integer, _
                                   ByVal OrgName As String, _
                                   ByVal Title As String, _
                                   ByVal DateOfOffer As Date, _
                                   ByVal Address As String, _
                                   ByVal Telephone As String, _
                                   ByVal Mobile As String, _
                                   ByVal Email As String, _
                                   ByVal url_booking As String, _
                                   ByVal url_web As String, _
                                   ByVal url_brochure As String, _
                                   ByVal Price As String, _
                                   ByVal Subscription As Integer, _
                                   ByVal MaxParticipants As Integer, _
                                   ByVal url_booking_dsc As String, _
                                   ByVal url_web_dsc As String, _
                                   ByVal url_brochure_dsc As String, _
                                   ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn, i As Integer
        Dim sSql As String
        Dim sLatLon(), sLat, sLon, sCommand() As String
        Dim bLatLon, bAdmin As Boolean

        Dim stUserProfile As DataAccess.UserProfile
        Dim stMpOffer As DataAccess.stCatalogue

        Const sIdm As String = "ENGService.UpdateMpOffer"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Update Activity by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then
                    '+--------------------------------------------+
                    '| Check that the request belongs to the user |
                    '+--------------------------------------------+
                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Big_bussines Or _
                       stUserProfile.Role = Role.Small_bussines Or _
                       stUserProfile.Role = Role.Hub Or _
                       stUserProfile.Role = Role.Regional_admin Then
                        sSql = "Offer_id = " & Offer_id
                        bAdmin = True
                    Else
                        sSql = "Offer_id = " & Offer_id & " And Promoter_id = " & stUserProfile.User_id
                        bAdmin = False
                    End If

                    stMpOffer = env.DataAccess.getCatalogue(sSql)

                    If stMpOffer.Id <> 0 Then

                        If Trim(Where_Offer) <> "" Then
                            sLatLon = Where_Offer.Split("/")
                            If sLatLon.Length = 2 Then
                                bLatLon = True
                                sLat = sLatLon(0).Replace(",", ".")
                                sLon = sLatLon(1).Replace(",", ".")
                            Else
                                bLatLon = False
                            End If
                        Else
                            bLatLon = False
                        End If
                        If Not bLatLon Then
                            sLat = stUserProfile.Last_loc_lat.ToString.Replace(",", ".")
                            sLon = stUserProfile.last_loc_lon.ToString.Replace(",", ".")
                        End If

                        If stMpOffer.Promoter_id = stUserProfile.User_id Then
                            bAdmin = False
                        End If

                        i = 0
                        If Category <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Category_id"
                            sCommand(i + 1) = CDBStr(Category)
                            i += 2
                        End If
                        If Short_desc <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Short_description"
                            sCommand(i + 1) = CDBStr(Short_desc)
                            i += 2
                        End If
                        If Detailed_info <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Detailed_info"
                            sCommand(i + 1) = CDBStr(Detailed_info)
                            i += 2
                        End If
                        If When_Offer <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "WhenCat"
                            sCommand(i + 1) = CDBStr(When_Offer)
                            i += 2
                        End If
                        If Not IsNothing(Deadline) Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Deadline"
                            sCommand(i + 1) = env.DataAccess.CDBDate(Deadline)
                            i += 2
                        End If
                        If Not IsNothing(ContactType) Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "ContactType"
                            sCommand(i + 1) = ContactType.ToString
                            i += 2
                        End If

                        If Not bAdmin Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "WhereCat"
                            sCommand(i + 1) = CDBStr(sLat & "/" & sLon)
                            i += 2
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "lng"
                            sCommand(i + 1) = CDBStr(getUserLanguage(stUserProfile.Language))
                            i += 2
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "lat"
                            sCommand(i + 1) = sLat
                            i += 2
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "lon"
                            sCommand(i + 1) = sLon
                        End If
                        If OrgName <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "OrgName"
                            sCommand(i + 1) = CDBStr(OrgName)
                            i += 2
                        End If
                        If Title <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Title"
                            sCommand(i + 1) = CDBStr(Title)
                            i += 2
                        End If
                        If Not IsNothing(DateOfOffer) Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "DateOfActivity"
                            sCommand(i + 1) = env.DataAccess.CDBDate(DateOfOffer)
                            i += 2
                        End If
                        If Address <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Address"
                            sCommand(i + 1) = CDBStr(Address)
                            i += 2
                        End If
                        If Telephone <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Telephone"
                            sCommand(i + 1) = CDBStr(Telephone)
                            i += 2
                        End If
                        If Mobile <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Mobile"
                            sCommand(i + 1) = CDBStr(Mobile)
                            i += 2
                        End If
                        If Email <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Email"
                            sCommand(i + 1) = CDBStr(Email)
                            i += 2
                        End If
                        If url_booking <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "url_booking"
                            sCommand(i + 1) = CDBStr(url_booking)
                            i += 2
                        End If
                        If url_web <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "url_web"
                            sCommand(i + 1) = CDBStr(url_web)
                            i += 2
                        End If
                        If url_brochure <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "url_brochure"
                            sCommand(i + 1) = CDBStr(url_brochure)
                            i += 2
                        End If
                        If Price <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Price"
                            sCommand(i + 1) = CDBStr(Price)
                            i += 2
                        End If
                        If Not IsNothing(Subscription) Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "Subscription"
                            sCommand(i + 1) = Subscription.ToString
                            i += 2
                        End If
                        If Not IsNothing(MaxParticipants) Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "MaxParticipants"
                            sCommand(i + 1) = MaxParticipants.ToString
                            i += 2
                        End If
                        If url_booking_dsc <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "url_booking_dsc"
                            sCommand(i + 1) = CDBStr(url_booking_dsc)
                            i += 2
                        End If
                        If url_web_dsc <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "url_web_dsc"
                            sCommand(i + 1) = CDBStr(url_web_dsc)
                            i += 2
                        End If
                        If url_brochure_dsc <> "" Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "url_brochure_dsc"
                            sCommand(i + 1) = CDBStr(url_brochure_dsc)
                            i += 2
                        End If

                        bOK = env.DataAccess.DBupdate("catalogue", _
                                                       "Offer_id = " & Offer_id.ToString, _
                                                       sCommand)

                        If bOK Then
                            env.WriteTrace(3, "Market Place Offer updated OK, now read the request id", sIdm)

                            sSql = "Offer_id = " & Offer_id.ToString

                            stMpOffer = env.DataAccess.getCatalogue(sSql)

                            If stMpOffer.Id <> 0 Then
                                env.WriteTrace(3, "Market Place Offer  identity = " & stMpOffer.Id.ToString, sIdm)
                                ErrorMessage = ""

                                Notify(Login, _
                                       EventAddActivity, _
                                       stMpOffer.Id, _
                                       stUserProfile.Name, _
                                       stUserProfile.Login, _
                                       Title, _
                                       stMpOffer.Short_Description, _
                                       stMpOffer.lng, _
                                       ContactType, _
                                       ErrorMessage)

                                iReturn = stMpOffer.Id
                            Else
                                env.WriteTrace(3, "Market Place Offer not updated, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "Market Place Offer not updated, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "Market Place Offer does not belongs to the user, error in DataAccess module", sIdm)
                        ErrorMessage = "RequestDoesNotBelongsToUser"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' viewOffer: Update Market Place Offer view counter
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 17-01-2013   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function viewOffer(ByVal Login As String, _
                              ByVal Offer_id As Integer, _
                              ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iUserId As Integer
        Dim stUserProfile As DataAccess.UserProfile

        Const sIdm As String = "ENGService.viewOffer"
        env = New Environment("Life_2.0.ENGService")

        Try

            bOK = env.DataAccess.DBexecute(String.Format("Call inc_offer_count ({0},{1})", Offer_id.ToString, CDBStr(Login)))

            'bOK = env.DataAccess.DBexecute("UPDATE catalogue SET Views=Views+1 Where Offer_id = " & Offer_id.ToString)


            Return Offer_id

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return 0
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' UpdateOffer: Update Offer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 17-02-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function UpdateOffer(ByVal Login As String, _
                                ByVal Offer_id As Integer, _
                                ByVal Category As String, _
                                ByVal Short_desc As String, _
                                ByVal Detailed_info As String, _
                                ByVal When_Offer As String, _
                                ByVal Where_Offer As String, _
                                ByVal Deadline As Date, _
                                ByVal ContactType As Integer, _
                                ByRef ErrorMessage As String) As Integer

        Dim bOK, bAdmin As Boolean
        Dim iReturn, i As Integer
        Dim sSql As String
        Dim sLatLon(), sLat, sLon, sCommand() As String
        Dim bLatLon As Boolean

        Dim stUserProfile As DataAccess.UserProfile
        Dim stOffer As DataAccess.stCatalogue

        Const sIdm As String = "ENGService.UpdateOffer"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Update Offer by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then
                    '+--------------------------------------------+
                    '| Check that the request belongs to the user |
                    '+--------------------------------------------+
                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        sSql = "Offer_id = " & Offer_id
                        bAdmin = True
                    Else
                        sSql = "Offer_id = " & Offer_id & " And Promoter_id = " & stUserProfile.User_id
                        bAdmin = False
                    End If

                    stOffer = env.DataAccess.getCatalogue(sSql)

                    If stOffer.Id <> 0 Then

                        If Trim(Where_Offer) <> "" Then
                            sLatLon = Where_Offer.Split("/")
                            If sLatLon.Length = 2 Then
                                bLatLon = True
                                sLat = sLatLon(0).Replace(",", ".")
                                sLon = sLatLon(1).Replace(",", ".")
                            Else
                                bLatLon = False
                            End If
                        Else
                            bLatLon = False
                        End If
                        If Not bLatLon Then
                            sLat = stUserProfile.Last_loc_lat.ToString.Replace(",", ".")
                            sLon = stUserProfile.last_loc_lon.ToString.Replace(",", ".")
                        End If
                        If stOffer.Promoter_id = stUserProfile.User_id Then
                            bAdmin = False
                        End If

                        i = 0
                        ReDim Preserve sCommand(i + 1)
                        sCommand(i) = "Category_id"
                        sCommand(i + 1) = CDBStr(Category)
                        i += 2
                        ReDim Preserve sCommand(i + 1)
                        sCommand(i) = "Short_description"
                        sCommand(i + 1) = CDBStr(Short_desc)
                        i += 2
                        ReDim Preserve sCommand(i + 1)
                        sCommand(i) = "Detailed_info"
                        sCommand(i + 1) = CDBStr(Detailed_info)
                        i += 2
                        ReDim Preserve sCommand(i + 1)
                        sCommand(i) = "WhenCat"
                        sCommand(i + 1) = CDBStr(When_Offer)
                        i += 2
                        ReDim Preserve sCommand(i + 1)
                        sCommand(i) = "Deadline"
                        sCommand(i + 1) = env.DataAccess.CDBDate(Deadline)
                        i += 2
                        ReDim Preserve sCommand(i + 1)
                        sCommand(i) = "ContactType"
                        sCommand(i + 1) = ContactType.ToString
                        i += 2
                        If Not bAdmin Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "WhereCat"
                            sCommand(i + 1) = CDBStr(sLat & "/" & sLon)
                            i += 2
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "lng"
                            sCommand(i + 1) = CDBStr(getUserLanguage(stUserProfile.Language))
                            i += 2
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "lat"
                            sCommand(i + 1) = sLat
                            i += 2
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "lon"
                            sCommand(i + 1) = sLon
                        End If

                        bOK = env.DataAccess.DBupdate("catalogue", _
                                                       "Offer_id = " & Offer_id.ToString, _
                                                       sCommand)

                        If bOK Then
                            env.WriteTrace(3, "Offer updated OK, now read the request id", sIdm)
                            iReturn = Offer_id

                            sSql = "Offer_id = " & Offer_id.ToString

                            stOffer = env.DataAccess.getCatalogue(sSql)

                            If stOffer.Id <> 0 Then
                                env.WriteTrace(3, "Offer identity = " & stOffer.Id.ToString, sIdm)
                                ErrorMessage = ""

                                Notify(Login, _
                                       EventAddActivity, _
                                       stOffer.Id, _
                                       stUserProfile.Name, _
                                       stUserProfile.Login, _
                                       stOffer.Short_Description, _
                                       stOffer.Detailed_info, _
                                       stOffer.lng, _
                                       ContactType, _
                                       ErrorMessage)

                                iReturn = stOffer.Id
                            Else
                                env.WriteTrace(3, "Offer not updated, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If

                        Else
                            env.WriteTrace(3, "Offer not updated, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "Offer does not belongs to the user, error in DataAccess module", sIdm)
                        ErrorMessage = "RequestDoesNotBelongsToUser"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' DeleteFile: Delete File attached to an offer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 11-03-2013   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function DeleteFiles(ByVal Login As String, _
                                ByVal Offer As Integer, _
                                ByRef ErrorMessage As String) As Integer
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.DeleteFile"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Delete Files of Offer/user: " & Offer.ToString & "/" & Login, sIdm)

            iReturn = DeleteOfferFiles(Login, Offer, ErrorMessage)

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' DeleteOfferFiles: Delete Files attached to an offer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 11-03-2013   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Private Function DeleteOfferFiles(ByVal Login As String, _
                                      ByVal Offer As Integer, _
                                      ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn, i As Integer
        Dim sSql, sFile As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim ret_files() As Files

        Const sIdm As String = "ENGService.DeleteOfferFiles"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Delete Files of Offer/user: " & Offer.ToString & "/" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then
                    '+--------------------------------------------+
                    '| Check that the request belongs to the user |
                    '+--------------------------------------------+
                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        sSql = "Offer = " & Offer.ToString
                    Else
                        sSql = "Offer = " & Offer.ToString & " And Userid = " & stUserProfile.User_id
                    End If

                    '+---------------------------+
                    '| Delete the physical files |
                    '+---------------------------+
                    iReturn = GetFiles2(Offer, True, ret_files, ErrorMessage)

                    For i = 0 To ret_files.Length - 1 Step 1
                        Try
                            sFile = My.Request.MapPath(ret_files(i).url)

                            My.Computer.FileSystem.DeleteFile(sFile, _
                                                              FileIO.UIOption.OnlyErrorDialogs, _
                                                              FileIO.RecycleOption.SendToRecycleBin)
                        Catch ex As Exception
                            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
                            env.WriteTrace(1, ErrorMessage, sIdm)
                        End Try
                    Next

                    bOK = env.DataAccess.DBdelete("Files", _
                                                  sSql)

                    If bOK Then
                        env.WriteTrace(3, "Files deleted OK", sIdm)
                        iReturn = Offer
                    Else
                        env.WriteTrace(3, "Files not deleted, error in DataAccess module", sIdm)
                        ErrorMessage = "InternalErrorInDb"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' DeleteFile: Delete one File attached to an offer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 11-03-2013   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function DeleteFile(ByVal Login As String, _
                               ByVal FileId As Integer, _
                               ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn, i As Integer
        Dim sSql, sFile As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim ret_files() As Files

        Const sIdm As String = "ENGService.DeleteFile"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Delete File/user: " & FileId.ToString & "/" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then
                    '+--------------------------------------------+
                    '| Check that the request belongs to the user |
                    '+--------------------------------------------+
                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        sSql = "idfiles = " & FileId.ToString
                    Else
                        sSql = "idfiles = " & FileId.ToString & " And Userid = " & stUserProfile.User_id
                    End If

                    '+---------------------------+
                    '| Delete the physical files |
                    '+---------------------------+
                    iReturn = GetFile(FileId, ret_files, ErrorMessage)

                    For i = 0 To ret_files.Length - 1 Step 1
                        Try
                            sFile = My.Request.MapPath(ret_files(i).url)

                            My.Computer.FileSystem.DeleteFile(sFile, _
                                                              FileIO.UIOption.OnlyErrorDialogs, _
                                                              FileIO.RecycleOption.SendToRecycleBin)
                        Catch ex As Exception
                            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
                            env.WriteTrace(1, ErrorMessage, sIdm)
                        End Try
                    Next

                    bOK = env.DataAccess.DBdelete("Files", _
                                                  sSql)

                    If bOK Then
                        env.WriteTrace(3, "Files deleted OK", sIdm)
                        iReturn = FileId
                    Else
                        env.WriteTrace(3, "Files not deleted, error in DataAccess module", sIdm)
                        ErrorMessage = "InternalErrorInDb"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' Delete Hub: Delete Hub
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 27-11-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function DeleteHub(ByVal Login As String, _
                              ByVal Hub_id As Integer, _
                              ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stHub As DataAccess.stHub

        Const sIdm As String = "ENGService.DeleteHub"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Delete Business by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then
                    '+--------------------------------------------+
                    '| Check that the request belongs to the user |
                    '+--------------------------------------------+
                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        sSql = "Hub_id = " & Hub_id.ToString
                    Else
                        sSql = "Hub_id = " & Hub_id.ToString & " And User_id = " & stUserProfile.User_id
                    End If

                    stHub = env.DataAccess.getHub(sSql)

                    If stHub.Hub_id <> 0 Then

                        bOK = env.DataAccess.DBdelete("hub", _
                                                      sSql)

                        If bOK Then
                            env.WriteTrace(3, "Hub deleted OK, now read the request id", sIdm)
                            iReturn = Hub_id
                        Else
                            env.WriteTrace(3, "Hub not deleted, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "Hub does not belongs to the user, error in DataAccess module", sIdm)
                        ErrorMessage = "RequestDoesNotBelongsToUser"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' DeleteBusiness: Delete Business
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 27-11-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function DeleteBusiness(ByVal Login As String, _
                                   ByVal SB_id As Integer, _
                                   ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stBusiness As DataAccess.stBusiness

        Const sIdm As String = "ENGService.DeleteBusiness"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Delete Business by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then
                    '+--------------------------------------------+
                    '| Check that the request belongs to the user |
                    '+--------------------------------------------+
                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        sSql = "SB_id = " & SB_id.ToString
                    Else
                        sSql = "SB_id = " & SB_id.ToString & " And User_id = " & stUserProfile.User_id
                    End If

                    stBusiness = env.DataAccess.getBusiness(sSql)

                    If stBusiness.SB_id <> 0 Then

                        bOK = env.DataAccess.DBdelete("small_business", _
                                                      sSql)

                        If bOK Then
                            env.WriteTrace(3, "Business deleted OK, now read the request id", sIdm)
                            iReturn = SB_id
                        Else
                            env.WriteTrace(3, "Business not deleted, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "Business does not belongs to the user, error in DataAccess module", sIdm)
                        ErrorMessage = "RequestDoesNotBelongsToUser"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' DeleteActivity: Delete Activities
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function DeleteActivity(ByVal Login As String, _
                                   ByVal Activity_id As Integer, _
                                   ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stActivity As DataAccess.stCatalogue

        Const sIdm As String = "ENGService.DeleteActivity"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Delete Activity by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then
                    '+--------------------------------------------+
                    '| Check that the request belongs to the user |
                    '+--------------------------------------------+
                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        sSql = "Offer_id = " & Activity_id
                    Else
                        sSql = "Offer_id = " & Activity_id & " And Promoter_id = " & stUserProfile.User_id
                    End If

                    stActivity = env.DataAccess.getCatalogue(sSql)

                    If stActivity.Id <> 0 Then

                        bOK = env.DataAccess.DBdelete("catalogue", _
                                                      "Offer_id = " & Activity_id.ToString)

                        If bOK Then
                            env.WriteTrace(3, "Activity deleted OK, now read the request id", sIdm)
                            iReturn = Activity_id
                        Else
                            env.WriteTrace(3, "Activity not deleted, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "Activity does not belongs to the user, error in DataAccess module", sIdm)
                        ErrorMessage = "RequestDoesNotBelongsToUser"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' AddService: Add Service
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
     Public Function AddService(ByVal Login As String, _
                                ByVal Category As String, _
                                ByVal Short_desc As String, _
                                ByVal Detailed_info As String, _
                                ByVal When_Service As String, _
                                ByVal Where_Service As String, _
                                ByVal Deadline As Date, _
                                ByVal ContactType As Integer, _
                                ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String
        Dim sLatLon(), sLat, sLon As String
        Dim bLatLon As Boolean

        Dim stUserProfile As DataAccess.UserProfile
        Dim stService As DataAccess.stCatalogue

        Const sIdm As String = "ENGService.AddService"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Add service by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        If Trim(Where_Service) <> "" Then
                            sLatLon = Where_Service.Split("/")
                            If sLatLon.Length = 2 Then
                                bLatLon = True
                                sLat = sLatLon(0).Replace(",", ".")
                                sLon = sLatLon(1).Replace(",", ".")
                            Else
                                bLatLon = False
                            End If
                        Else
                            bLatLon = False
                        End If
                        If Not bLatLon Then
                            sLat = stUserProfile.Last_loc_lat.ToString.Replace(",", ".")
                            sLon = stUserProfile.last_loc_lon.ToString.Replace(",", ".")
                        End If

                        bOK = env.DataAccess.DBinsert("catalogue", _
                                                      "Offer_type", OfferType.Service, _
                                                      "Category_id", CDBStr(Category), _
                                                      "Promoter_id", stUserProfile.User_id, _
                                                      "Short_description", CDBStr(Short_desc), _
                                                      "Detailed_info", CDBStr(Detailed_info), _
                                                      "WhenCat", CDBStr(When_Service), _
                                                      "WhereCat", CDBStr(sLat & "/" & sLon), _
                                                      "Deadline", env.DataAccess.CDBDate(Deadline), _
                                                      "lng", CDBStr(getUserLanguage(stUserProfile.Language)), _
                                                      "lat", sLat, _
                                                      "lon", sLon, _
                                                      "ContactType", ContactType.ToString, _
                                                      "SubmissionDate", env.DataAccess.CDBDate(DateTime.Now))

                        If bOK Then
                            env.WriteTrace(3, "service submitted OK, now read the service id", sIdm)

                            sSql = "Offer_type=" & OfferType.Service & _
                                   " AND Category_id=" & CDBStr(Category) & _
                                   " AND Promoter_id=" & stUserProfile.User_id & " ORDER BY Offer_id Desc"

                            stService = env.DataAccess.getCatalogue(sSql)

                            If stService.Id <> 0 Then
                                env.WriteTrace(3, "service identity = " & stService.Id.ToString, sIdm)
                                ErrorMessage = ""

                                Notify(Login, _
                                       EventAddService, _
                                       stService.Id, _
                                       stUserProfile.Name, _
                                       stUserProfile.Login, _
                                       stService.Short_Description, _
                                       stService.Detailed_info, _
                                       stService.lng, _
                                       ContactType, _
                                       ErrorMessage)

                                iReturn = stService.Id
                            Else
                                env.WriteTrace(3, "service not created, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "service not created, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAPromoter"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' GetServices: Get Services
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function GetServices(ByVal sql As String, _
                                ByRef ret_Services() As Service, _
                                ByVal start As Integer, _
                                ByVal count As Integer, _
                                ByVal username As String, _
                                ByRef ErrorMessage As String) As Integer
        Dim sSql As String
        Dim i As Integer = 0
        Dim iReturn As Integer


        Const sIdm As String = "ENGService.GetServices"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As Service
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            env.WriteTrace(2, "Entry ", sIdm)
            env.WriteTrace(3, "Sql:" & sql, sIdm)

            sSql = sqlDistance(sql, "catalogue", "Service", username)

            sSql = LCase(sSql)
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
                Dim result As Service
                If sSql.Contains("select count") Then
                    myReader.Read()
                    iReturn = myReader.GetInt64(0)
                Else
                    Do While myReader.Read()
                        result = New Service
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Offer_id"))) Then
                            result.Id = myReader.GetValue(myReader.GetOrdinal("Offer_id"))
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
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lng"))) Then
                            result.lng = myReader.GetValue(myReader.GetOrdinal("lng"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Candidates"))) Then
                            result.Candidates = myReader.GetValue(myReader.GetOrdinal("Candidates"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("SubmissionDate"))) Then
                            result.SubmissionDate = myReader.GetValue(myReader.GetOrdinal("SubmissionDate"))
                        End If
                        If mySelectQuery.Contains("radians(") Then
                            If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Distance"))) Then
                                result.Distance = myReader.GetValue(myReader.GetOrdinal("Distance"))
                            End If
                        End If
                        retVarList.Add(result)
                    Loop
                    retVar = retVarList.ToArray(GetType(Service))
                    iReturn = 1
                End If
            Else
                env.WriteTrace(3, "No data read from table request ", sIdm)
            End If
            ret_Services = retVar
            env.WriteTrace(2, "End ", sIdm)
            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ErrorResult
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
    ''' UpdateService: Update Services
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
     Public Function UpdateService(ByVal Login As String, _
                                   ByVal Service_id As String, _
                                   ByVal Category As String, _
                                   ByVal Short_desc As String, _
                                   ByVal Detailed_info As String, _
                                   ByVal When_Service As String, _
                                   ByVal Where_Service As String, _
                                   ByVal Deadline As Date, _
                                   ByVal ContactType As Integer, _
                                   ByRef ErrorMessage As String) As Integer
        Dim bOK, bAdmin As Boolean
        Dim iReturn, i As Integer
        Dim sSql, sCommand() As String
        Dim sLatLon(), sLat, sLon As String
        Dim bLatLon As Boolean

        Dim stUserProfile As DataAccess.UserProfile
        Dim stService As DataAccess.stCatalogue

        Const sIdm As String = "ENGService.UpdateService"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Update Service by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then
                    '+--------------------------------------------+
                    '| Check that the request belongs to the user |
                    '+--------------------------------------------+
                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        sSql = "Offer_id = " & Service_id
                        bAdmin = True
                    Else
                        sSql = "Offer_id = " & Service_id & " And Promoter_id = " & stUserProfile.User_id
                        bAdmin = False
                    End If

                    stService = env.DataAccess.getCatalogue(sSql)

                    If stService.Id <> 0 Then

                        If Trim(Where_Service) <> "" Then
                            sLatLon = Where_Service.Split("/")
                            If sLatLon.Length = 2 Then
                                bLatLon = True
                                sLat = sLatLon(0).Replace(",", ".")
                                sLon = sLatLon(1).Replace(",", ".")
                            Else
                                bLatLon = False
                            End If
                        Else
                            bLatLon = False
                        End If
                        If Not bLatLon Then
                            sLat = stUserProfile.Last_loc_lat.ToString.Replace(",", ".")
                            sLon = stUserProfile.last_loc_lon.ToString.Replace(",", ".")
                        End If
                        If stService.Promoter_id = stUserProfile.User_id Then
                            bAdmin = False
                        End If

                        i = 0
                        ReDim Preserve sCommand(i + 1)
                        sCommand(i) = "Category_id"
                        sCommand(i + 1) = CDBStr(Category)
                        i += 2
                        ReDim Preserve sCommand(i + 1)
                        sCommand(i) = "Short_description"
                        sCommand(i + 1) = CDBStr(Short_desc)
                        i += 2
                        ReDim Preserve sCommand(i + 1)
                        sCommand(i) = "Detailed_info"
                        sCommand(i + 1) = CDBStr(Detailed_info)
                        i += 2
                        ReDim Preserve sCommand(i + 1)
                        sCommand(i) = "WhenCat"
                        sCommand(i + 1) = CDBStr(When_Service)
                        i += 2
                        ReDim Preserve sCommand(i + 1)
                        sCommand(i) = "Deadline"
                        sCommand(i + 1) = env.DataAccess.CDBDate(Deadline)
                        i += 2
                        ReDim Preserve sCommand(i + 1)
                        sCommand(i) = "ContactType"
                        sCommand(i + 1) = ContactType.ToString
                        i += 2
                        If Not bAdmin Then
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "WhereCat"
                            sCommand(i + 1) = CDBStr(sLat & "/" & sLon)
                            i += 2
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "lng"
                            sCommand(i + 1) = CDBStr(getUserLanguage(stUserProfile.Language))
                            i += 2
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "lat"
                            sCommand(i + 1) = sLat
                            i += 2
                            ReDim Preserve sCommand(i + 1)
                            sCommand(i) = "lon"
                            sCommand(i + 1) = sLon
                        End If

                        bOK = env.DataAccess.DBupdate("catalogue", _
                                                      "Offer_id = " & Service_id.ToString, _
                                                      sCommand)

                        If bOK Then
                            env.WriteTrace(3, "Service updated OK, now read the request id", sIdm)
                            iReturn = Service_id

                            sSql = "Offer_id = " & Service_id

                            stService = env.DataAccess.getCatalogue(sSql)

                            If stService.Id <> 0 Then
                                env.WriteTrace(3, "service identity = " & stService.Id.ToString, sIdm)
                                ErrorMessage = ""

                                Notify(Login, _
                                       EventAddService, _
                                       stService.Id, _
                                       stUserProfile.Name, _
                                       stUserProfile.Login, _
                                       stService.Short_Description, _
                                       stService.Detailed_info, _
                                       stService.lng, _
                                       ContactType, _
                                       ErrorMessage)

                                iReturn = stService.Id
                            Else
                                env.WriteTrace(3, "service not updated, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "Service not updated, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "Service does not belongs to the user, error in DataAccess module", sIdm)
                        ErrorMessage = "RequestDoesNotBelongsToUser"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' DeleteService: Delete Services
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function DeleteService(ByVal Login As String, _
                                  ByVal Service_id As String, _
                                  ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stActivity As DataAccess.stCatalogue

        Const sIdm As String = "ENGService.DeleteService"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Delete service by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then
                    '+--------------------------------------------+
                    '| Check that the request belongs to the user |
                    '+--------------------------------------------+
                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        sSql = "Offer_id = " & Service_id
                    Else
                        sSql = "Offer_id = " & Service_id & " And Promoter_id = " & stUserProfile.User_id
                    End If

                    stActivity = env.DataAccess.getCatalogue(sSql)

                    If stActivity.Id <> 0 Then

                        bOK = env.DataAccess.DBdelete("catalogue", _
                                                      "Offer_id = " & Service_id.ToString)

                        If bOK Then
                            env.WriteTrace(3, "Service deleted OK, now read the request id", sIdm)
                            iReturn = Service_id
                        Else
                            env.WriteTrace(3, "Service not deleted, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "Service does not belongs to the user, error in DataAccess module", sIdm)
                        ErrorMessage = "RequestDoesNotBelongsToUser"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' DeleteUserOffers: Delete Offers created by a user
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' This method is called from the Login Web Service when a user is deleted, in order
    ''' to remove all the related offers
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 26-02-2013   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function DeleteUserOffers(ByVal User_id As Integer, _
                                     ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Const sIdm As String = "ENGService.DeleteUserOffers"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Delete offers by user_id:" & User_id.ToString, sIdm)

            sSql = "Promoter_id = " & User_id.ToString

            bOK = env.DataAccess.DBdelete("catalogue", sSql)

            If bOK Then
                env.WriteTrace(3, "Offers deleted OK", sIdm)
                iReturn = User_id
            Else
                env.WriteTrace(3, "Offer not deleted, error in DataAccess module", sIdm)
                ErrorMessage = "InternalErrorInDb"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' DeleteOffer: Delete Offers
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 17-02-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function DeleteOffer(ByVal Login As String, _
                                ByVal Offer_id As String, _
                                ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stOffer As DataAccess.stCatalogue

        Const sIdm As String = "ENGService.DeleteOffer"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Delete offer by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then
                    '+--------------------------------------------+
                    '| Check that the request belongs to the user |
                    '+--------------------------------------------+
                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        sSql = "Offer_id = " & Offer_id
                    Else
                        sSql = "Offer_id = " & Offer_id & " And Promoter_id = " & stUserProfile.User_id
                    End If

                    stOffer = env.DataAccess.getCatalogue(sSql)

                    If stOffer.Id <> 0 Then

                        bOK = env.DataAccess.DBdelete("catalogue", _
                                                      "Offer_id = " & Offer_id)

                        If bOK Then
                            env.WriteTrace(3, "Offer deleted OK, now read the request id", sIdm)
                            iReturn = CInt(Offer_id)
                            '+-----------------------+
                            '| Delete files attached |
                            '+-----------------------+
                            iReturn = DeleteOfferFiles(Login, Offer_id, ErrorMessage)
                            env.WriteTrace(3, "DeleteOfferFiles result: " & ErrorMessage, sIdm)
                        Else
                            env.WriteTrace(3, "Offer not deleted, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "Offer does not belongs to the user, error in DataAccess module", sIdm)
                        ErrorMessage = "RequestDoesNotBelongsToUser"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' ApplyForOffer: Apply for an Offer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 06-03-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function ApplyForOffer(ByVal Login As String, _
                                  ByVal Offer_id As String, _
                                  ByRef ErrorMessage As String) As Integer

        Dim iReturn As Integer

        Const sIdm As String = "ENGService.ApplyForOffer"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Update Offer by user:" & Login, sIdm)

            iReturn = AddToJoin(Login, Offer_id, cJoinOffer, ErrorMessage)

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' UnApplyForOffer: UnApply for an Offer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 06-03-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function UnApplyForOffer(ByVal Login As String, _
                                    ByVal Offer_id As String, _
                                    ByRef ErrorMessage As String) As Integer

        Dim iReturn As Integer

        Const sIdm As String = "ENGService.UnApplyForOffer"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Unapply For Offer:" & Login, sIdm)

            iReturn = RemoveFromJoin(Login, Offer_id, ErrorMessage)

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try

    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' AcceptRejectNewCategory: Accepr or reject new category
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function AcceptRejectNewCategory(ByVal Login As String, _
                                            ByVal User_id As String, _
                                            ByVal Category_id As String, _
                                            ByVal AcceptReject As Integer, _
                                            ByRef ErrorMessage As String) As Integer
        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stCategory As DataAccess.stCategory

        Const sIdm As String = "ENGService.AcceptRejectNewCategory"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Update category by user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then
                If stUserProfile.Enabled = 1 Then

                    If stUserProfile.Role = Role.Area_manager Or _
                       stUserProfile.Role = Role.Sys_admin Or _
                       stUserProfile.Role = Role.Country_admin Or _
                       stUserProfile.Role = Role.Regional_admin Then

                        sSql = "Category_id=" & Category_id

                        stCategory = env.DataAccess.getCategory(sSql)

                        If stCategory.category_id <> 0 Then

                            bOK = env.DataAccess.DBupdate("category", _
                                                          "Category_id=" & Category_id, _
                                                          "Status", AcceptReject)

                            If bOK Then
                                env.WriteTrace(3, "category updated identity = " & Category_id, sIdm)
                                ErrorMessage = ""
                                iReturn = CInt(Category_id)
                            Else
                                env.WriteTrace(3, "category not updated, error in DataAccess module", sIdm)
                                ErrorMessage = "InternalErrorInDb"
                                iReturn = ErrorResult
                            End If
                        Else
                            env.WriteTrace(3, "category not existing, error in DataAccess module", sIdm)
                            ErrorMessage = "InternalErrorInDb"
                            iReturn = ErrorResult
                        End If
                    Else
                        env.WriteTrace(3, "User is not a promoter", sIdm)
                        ErrorMessage = "UserNotAPromoter"
                        iReturn = ErrorResult
                    End If
                Else
                    env.WriteTrace(3, "User disabled", sIdm)
                    ErrorMessage = "UserDisabled"
                    iReturn = ErrorResult
                End If
            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorResult
        End Try


    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' AddStat: Add stat event
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 30-11-2011   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
     Public Function AddStat(ByVal Login As String, _
                             ByVal Event_id As String, _
                             ByVal Time As DateTime, _
                             ByVal Duration As Integer, _
                             ByVal Location_lat As String, _
                             ByVal Location_lon As String, _
                             ByVal Device As String, _
                             ByVal Query As String, _
                             ByRef ErrorMessage As String) As Integer

        Dim bOK As Boolean
        Dim iReturn As Integer
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile

        Const sIdm As String = "ENGService.AddStat"
        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "add stat event user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 Then

                iReturn = stUserProfile.User_id

                bOK = env.DataAccess.DBinsert("Stat", _
                                              "Event", TranslateEvent(Event_id), _
                                              "User_login", CDBStr(Login), _
                                              "dTime", env.DataAccess.CDBDate(Time), _
                                              "duration", stUserProfile.User_id, _
                                              "Device", CDBStr(Device), _
                                              "query", CDBStr(Query), _
                                              "lat", Location_lat.Replace(",", "."), _
                                              "lon", Location_lon.Replace(",", "."))

            Else
                env.WriteTrace(3, "User not registered", sIdm)
                ErrorMessage = "UserNotRegistered"
                iReturn = ErrorResult
            End If

            Return iReturn

        Catch ex As Exception
            Return ErrorResult
        End Try

    End Function

    Private Function TranslateEvent(ByVal idEvent As String) As String

        Dim sRet As String

        Try
            Select Case idEvent

                Case "RegisterUser"
                    sRet = "1"

                Case "UserLogin"
                    sRet = "2"

                Case "UpdateUser"
                    sRet = "3"

                Case "DeleteUser"
                    sRet = "4"

                Case "ReadUser"
                    sRet = "5"

                Case "UserList"
                    sRet = "6"

                Case "UploadPicture"
                    sRet = "7"

                Case "AcceptRejectNewCategory"
                    sRet = "8"

                Case "AcceptRejectRequest"
                    sRet = "9"

                Case "AddActivity"
                    sRet = "10"

                Case "AddCategory"
                    sRet = "11"

                Case "AddService"
                    sRet = "12"

                Case "AddSkill"
                    sRet = "13"

                Case "ApplyForOffer"
                    sRet = "14"

                Case "ApplyForRequest"
                    sRet = "15"

                Case "DeleteActivity"
                    sRet = "16"

                Case "DeleteCategory"
                    sRet = "17"

                Case "DeleteOffer"
                    sRet = "18"

                Case "DeleteRecommendation"
                    sRet = "19"

                Case "DeleteRequest"
                    sRet = "20"

                Case "DeleteService"
                    sRet = "21"

                Case "DeleteSkill"
                    sRet = "22"

                Case "GetActivities"
                    sRet = "23"

                Case "GetCategories"
                    sRet = "24"

                Case "GetOffer"
                    sRet = "25"

                Case "GetRecommendations"
                    sRet = "26"

                Case "GetRequests"
                    sRet = "27"

                Case "GetRequestStatus"
                    sRet = "28"

                Case "GetServices"
                    sRet = "29"

                Case "GetSkills"
                    sRet = "30"

                Case "GetStats"
                    sRet = "31"

                Case "GetStatsSql"
                    sRet = "32"

                Case "JoinActivity"
                    sRet = "33"

                Case "ModerateJoinActivity"
                    sRet = "34"

                Case "PromoterFeedback"
                    sRet = "35"

                Case "SendFeedback"
                    sRet = "36"

                Case "SendRecommendation"
                    sRet = "37"

                Case "SubmitOffer"
                    sRet = "38"

                Case "SubmitRequest"
                    sRet = "39"

                Case "UnApplyForOffer"
                    sRet = "40"

                Case "UnApplyForRequest"
                    sRet = "41"

                Case "UnJoinActivity"
                    sRet = "42"

                Case "UpdateActivity"
                    sRet = "43"

                Case "UpdateCategory"
                    sRet = "44"

                Case "UpdateOffer"
                    sRet = "45"

                Case "UpdateRequest"
                    sRet = "46"

                Case "UpdateService"
                    sRet = "47"

                Case "UpdateSkill"
                    sRet = "48"

                Case Else
                    sRet = "0"

            End Select

            Return sRet

        Catch ex As Exception
            Return "0"
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' GetStats: Get a list of statistics
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 02-02-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function GetStats(ByVal sql As String, _
                             ByRef ret_Stats() As Stats, _
                             ByVal start As Integer, _
                             ByVal count As Integer, _
                             ByRef ErrorMessage As String) As Integer
        Dim sSql As String
        Dim i As Integer = 0
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.GetStats"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As Stats
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            env.WriteTrace(2, "Entry ", sIdm)
            env.WriteTrace(3, "Sql:" & sql, sIdm)

            sSql = sqlDistance(sql, "stat", "", "")

            sSql = LCase(sSql)
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
                Dim result As Stats
                If sSql.Contains("select count") Then
                    myReader.Read()
                    iReturn = myReader.GetInt64(0)
                Else
                    Do While myReader.Read()
                        result = New Stats
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Event"))) Then
                            result.Event_Id = myReader.GetValue(myReader.GetOrdinal("Event"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("User_login"))) Then
                            result.User_Login = myReader.GetValue(myReader.GetOrdinal("User_login"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("dTime"))) Then
                            result.dTime = myReader.GetValue(myReader.GetOrdinal("dTime"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("duration"))) Then
                            result.Duration = myReader.GetValue(myReader.GetOrdinal("duration"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lat"))) Then
                            result.Lat = myReader.GetValue(myReader.GetOrdinal("lat"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lon"))) Then
                            result.Lon = myReader.GetValue(myReader.GetOrdinal("lon"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Device"))) Then
                            result.Device = myReader.GetValue(myReader.GetOrdinal("Device"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("query"))) Then
                            result.Query = myReader.GetValue(myReader.GetOrdinal("query"))
                        End If
                        If mySelectQuery.Contains("radians(") Then
                            If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Distance"))) Then
                                result.Distance = myReader.GetValue(myReader.GetOrdinal("Distance"))
                            End If
                        End If
                        retVarList.Add(result)
                    Loop
                    retVar = retVarList.ToArray(GetType(Stats))
                    iReturn = 1
                End If
            Else
                env.WriteTrace(3, "No data read from table stat ", sIdm)
            End If
            ret_Stats = retVar
            env.WriteTrace(2, "End ", sIdm)
            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ErrorResult
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
    ''' GetStatsSql: Get a list of statistics (Full sql input)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Fecha     Versión    Comentarios
    ''' ---------------------------------------------------------------------------------
    ''' 02-02-2012   1.0.0      Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function GetStatsSql(ByVal sql As String, _
                                ByRef ret_Stats() As ObjStats, _
                                ByRef ErrorMessage As String) As Integer
        Dim sSql As String
        Dim i As Integer = 0
        Dim iReturn As Integer

        Const sIdm As String = "ENGService.GetStatsSql"
        env = New Environment("Life_2.0.ENGService")

        Dim retVar(-1) As ObjStats
        Dim retVarList As New ArrayList
        Dim myReader As MySqlDataReader = Nothing
        Dim conn As MySqlConnection = Nothing

        Try
            env.WriteTrace(2, "Entry ", sIdm)
            env.WriteTrace(3, "Sql:" & sql, sIdm)

            sSql = LCase(sql)

            Dim mySelectQuery As String = sSql

            env.DataAccess.initDB()

            mySelectQuery = mySelectQuery & ";"
            conn = New MySqlConnection(env.DataAccess.ConnectionString)
            conn.Open()
            Dim myCommand As New MySqlCommand(mySelectQuery, conn)
            myReader = myCommand.ExecuteReader(Data.CommandBehavior.CloseConnection)
            myCommand.Dispose()
            If myReader.HasRows Then
                Dim result As ObjStats
                If sSql.Contains("select count") Then
                    myReader.Read()
                    iReturn = myReader.GetInt64(0)
                Else
                    Do While myReader.Read()
                        result = New ObjStats
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("idStat"))) Then
                            result.idStat = myReader.GetValue(myReader.GetOrdinal("idStat"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Event"))) Then
                            result.iEvent = myReader.GetValue(myReader.GetOrdinal("Event"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("User_login"))) Then
                            result.User_Login = myReader.GetValue(myReader.GetOrdinal("User_login"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("dTime"))) Then
                            result.dTime = myReader.GetValue(myReader.GetOrdinal("dTime"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("duration"))) Then
                            result.Duration = myReader.GetValue(myReader.GetOrdinal("duration"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lat"))) Then
                            result.Lat = myReader.GetValue(myReader.GetOrdinal("lat"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lon"))) Then
                            result.Lon = myReader.GetValue(myReader.GetOrdinal("lon"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("query"))) Then
                            result.Query = myReader.GetValue(myReader.GetOrdinal("query"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("Device"))) Then
                            result.Device = myReader.GetValue(myReader.GetOrdinal("Device"))
                        End If
                        If Not IsDBNull(myReader.GetValue(myReader.GetOrdinal("lng"))) Then
                            result.lng = myReader.GetValue(myReader.GetOrdinal("lng"))
                        End If
                        retVarList.Add(result)
                    Loop
                    retVar = retVarList.ToArray(GetType(ObjStats))
                    iReturn = 1
                End If
            Else
                env.WriteTrace(3, "No data read from table stat ", sIdm)
            End If
            ret_Stats = retVar
            env.WriteTrace(2, "End ", sIdm)
            Return iReturn

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, "Error " & ex.Message, sIdm)
            Return ErrorResult
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
    ''' sqlDistance: Construct SQL sentence to get items based on distance                         
    ''' </summary>
    ''' <remarks>
    ''' Returns 0 in case of error, otherwise return the user identity
    ''' </remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 19-12-2011   1.0     Creation
    ''' 24-01-2012   1.1     Treat language filtering
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Private Function sqlDistance(ByVal inSql As String, _
                                 ByVal sTable As String, _
                                 Optional ByVal sSubTable As String = "", _
                                 Optional ByVal sUser As String = "") As String

        Dim sOutputSql, inputSql, ErrorMessage, sSql1, sDistance, sLat, sLon, sTemp(), sWhere, _
            sCompSql, userSql, inputSql2 As String
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
                If inputSql.Contains("country") Then
                    bCount = False
                Else
                    bCount = True
                    inputSql = inputSql.Replace("count", "")
                End If
            Else
                bCount = False
            End If

            If Not inputSql.Contains("lng") Then
                If sUser <> "" Then
                    userSql = sqlLang(sUser)
                End If
            End If

            env.WriteTrace(3, "SQL sub-sentence after count:" & inputSql, sIdm)

            Select Case sSubTable

                Case "Activity"
                    sCompSql = "Offer_type=" & OfferType.Activity

                Case "Service"
                    sCompSql = "Offer_type=" & OfferType.Service

                Case "MarketPlace"
                    sCompSql = "Offer_type=" & OfferType.MarketPlace

                Case Else
                    sCompSql = ""

            End Select
            env.WriteTrace(3, "sCompSql:" & sCompSql, sIdm)

            If inputSql.Contains("distance") And inputSql.Contains("lat") And inputSql.Contains("lon") Then

                env.WriteTrace(3, "SQL sub-sentence contains distance:" & inputSql, sIdm)

                '+-------------------------------------------------------------------------+
                '| Parse the string to get the individual parameters, a sample sql can be: |
                '| user_votes > 100 and distance < 5 and lat=0.33453 and lon=34.9857984    |
                '+-------------------------------------------------------------------------+

                '+-------------------------------------------+
                '| Get the starting position of the sentence |
                '+-------------------------------------------+
                iPos1 = inputSql.IndexOf("distance")
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
                        sWhere = " AND (" & userSql & ") AND (" & sSql1 & ")"
                    Else
                        sWhere = " AND (" & sSql1 & ")"
                    End If
                Else
                    If userSql <> "" Then
                        sWhere = " AND (" & userSql & ")"
                    Else
                        sWhere = ""
                    End If
                End If
                If sCompSql <> "" Then
                    sWhere &= " AND " & sCompSql
                End If

                If bCount Then
                    sOutputSql = "SELECT COUNT(*) FROM (SELECT *, " & _
                            "( 6371 * ACOS( COS( RADIANS(" & sLat & ") ) * COS( RADIANS(lat) ) * COS( RADIANS(lon) - RADIANS(" & sLon & ") ) + SIN( RADIANS(" & sLat & ") ) * SIN( RADIANS(lat) ) ) ) AS distance" & _
                            " FROM " & sTable & " HAVING " & sDistance & sWhere & ") as T1"

                Else
                    sOutputSql = "SELECT *, " & _
                             "( 6371 * ACOS( COS( RADIANS(" & sLat & ") ) * COS( RADIANS(lat) ) * COS( RADIANS(lon) - RADIANS(" & sLon & ") ) + SIN( RADIANS(" & sLat & ") ) * SIN( RADIANS(lat) ) ) ) AS distance" & _
                             " FROM " & sTable & " HAVING " & sDistance & sWhere & " ORDER BY distance"
                End If

            Else
                If inputSql <> "" Then
                    If userSql <> "" Then
                        sWhere = " WHERE (" & userSql & ") AND (" & inputSql & ")"
                    Else
                        sWhere = " WHERE (" & inputSql & ")"
                    End If
                Else
                    If userSql <> "" Then
                        sWhere = " WHERE (" & userSql & ")"
                    Else
                        sWhere = ""
                    End If
                End If
                env.WriteTrace(3, "sWhere: " & sWhere, sIdm)
                If sCompSql <> "" Then
                    If sWhere <> "" Then
                        sWhere &= " AND " & sCompSql
                    Else
                        sWhere = " WHERE " & sCompSql
                    End If
                End If
                env.WriteTrace(3, "sWhere: " & sWhere, sIdm)
                If bCount Then
                    sOutputSql = "SELECT COUNT(*) FROM (SELECT * FROM " & sTable & sWhere & ") as T1"

                Else
                    Select Case sTable

                        Case "request"
                            sOutputSql = "SELECT * FROM " & sTable & sWhere & " ORDER BY RequestId DESC"

                        Case "catalogue"
                            sOutputSql = "SELECT * FROM " & sTable & sWhere & " ORDER BY Offer_id DESC"

                        Case Else
                            sOutputSql = "SELECT * FROM " & sTable & sWhere

                    End Select
                End If

            End If

            Return sOutputSql

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
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

        Const sIdm As String = "EngService.sqlLang"
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
                        sSql1 &= "lng Like '%" & Trim(sTemp(i)) & "%'"
                    Else
                        sSql1 &= " OR " & "lng Like '%" & Trim(sTemp(i)) & "%'"
                    End If
                Next

                sOutputSql = " (" & sSql1 & ") "
            Else
                sOutputSql = ""
            End If

            Return sOutputSql

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ""
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' getUserLanguage: Get the preferred language                         
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 27-01-2012   1.1     Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Private Function getUserLanguage(ByVal sUserLang As String) As String

        Dim sOutput, ErrorMessage, sSql1, sTemp() As String
        Dim i As Integer

        Const sIdm As String = "EngService.getUserLanguage"
        env = New Environment("Life_2.0.DBService")

        Try
            If sUserLang.Contains(",") Then
                sTemp = sUserLang.Split(",")
                sOutput = Trim(sTemp(0))
            Else
                sOutput = sUserLang
            End If

            Return sOutput

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ""
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' sendMessage: Send message between users                         
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 22-05-2012   1.0     Creation
    ''' 04-06-2012   1.1     Add parameters 'Offer_id' and 'Req_id'
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
       Public Function sendMessage(ByVal Login As String, _
                                   ByVal Dest As String, _
                                   ByVal Message As String, _
                                   ByVal Offer_id As Integer, _
                                   ByVal Req_id As Integer) As String

        Dim ErrorMessage, sResult As String

        Const sIdm As String = "EngService.sendMessage"
        env = New Environment("Life_2.0.DBService")

        Try

            sResult = sendMessage2(Login, _
                                   Dest, _
                                   Message, _
                                   Offer_id, _
                                   Req_id, _
                                   True)

            Return sResult

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorMessage
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' sendMessage: Send message between users                         
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 22-05-2012   1.0     Creation
    ''' 04-06-2012   1.1     Add parameters 'Offer_id' and 'Req_id'
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Private Function sendMessage2(ByVal Login As String, _
                                  ByVal Dest As String, _
                                  ByVal Message As String, _
                                  ByVal Offer_id As Integer, _
                                  ByVal Req_id As Integer, _
                                  Optional ByVal psendEmail As Boolean = False, _
                                  Optional ByVal pRec As Integer = 0) As String

        Dim ErrorMessage, sSql, sDest(), sTemp(), sFrom, sTo(), sError, sMessage, sSubject, _
            sLng, sFromName, sFromId, sFromEmail, sOffReq As String
        Dim stUserProfile As DataAccess.UserProfile
        Dim i As Integer
        Dim sbHtml As StringBuilder
        Dim bOK, bSendEmail As Boolean

        Const sIdm As String = "EngService.sendMessage2"
        env = New Environment("Life_2.0.DBService")

        Try
            '+----------------------------+
            '| Get the name of the sender |
            '+----------------------------+
            If Login = "0" Then
                sFromEmail = Config.GetConfigVal("Email", "From")
                sFromName = "Life 2.0"
                sFromId = "0"
            Else
                sSql = "Login = '" & Login & "'"
                stUserProfile = env.DataAccess.getUserProfile(sSql)
                sFromName = stUserProfile.Name
                sFromId = stUserProfile.User_id.ToString
                sFromEmail = stUserProfile.Email
            End If

            env.WriteTrace(3, "sFromEmail = " & sFromEmail, sIdm)

            '+----------------------------------+
            '| Extract the list of destinations |
            '+----------------------------------+
            sDest = Dest.Split(",")

            For i = 0 To sDest.Length - 1

                If psendEmail Then

                    sSql = "User_id = " & sDest(i)
                    stUserProfile = env.DataAccess.getUserProfile(sSql)

                    If stUserProfile.Notification_level = 1 Or stUserProfile.Notification_level = 3 Then
                        ReDim sTo(1)
                        sTo(0) = stUserProfile.Email
                        env.WriteTrace(3, "stUserProfile.Email = " & sTo(0), sIdm)

                        sLng = stUserProfile.Language

                        sFrom = getFrom(sLng)

                        bSendEmail = True
                    Else
                        bSendEmail = False
                    End If

                End If

                '+-----------------------------------+
                '| Store the message in the database |
                '+-----------------------------------+
                bOK = env.DataAccess.DBinsert("user_messages", _
                                              "Origin", sFromId, _
                                              "Destination", sDest(i), _
                                              "Message", CDBStr(Message), _
                                              "MRead", "0", _
                                              "DateSent", env.DataAccess.CDBDate(DateTime.Now), _
                                              "DateRead", env.DataAccess.CDBDate(DateAdd(DateInterval.Day, 1, DateTime.Now)), _
                                              "MReplied", pRec.ToString, _
                                              "idOffer", Offer_id.ToString, _
                                              "idReq", Req_id.ToString)

                If bOK Then

                    If bSendEmail Then

                        sOffReq = ""
                        If Offer_id <> 0 Then
                            sOffReq = getOfferTitle(Offer_id)
                        Else
                            If Req_id <> 0 Then
                                sOffReq = getRequestTitle(Req_id)
                            End If
                        End If

                        '+---------------------------+
                        '| Load the message template |
                        '+---------------------------+
                        sbHtml = New StringBuilder(Functions.loadTemplate("user-message", Trim(sLng)))

                        sbHtml.Replace("{#Message#}", Message)
                        sbHtml.Replace("{#From#}", sFromName)
                        sbHtml.Replace("{#Email#}", sFromEmail)
                        sbHtml.Replace("{#OffReq#}", sOffReq)

                        sMessage = sbHtml.ToString

                        env.WriteTrace(3, "Formatted Message = " & sMessage, sIdm)

                        sTemp = sbHtml.ToString.Split(vbCr)
                        sSubject = sTemp(0)

                        env.WriteTrace(3, "sSubject = " & sSubject, sIdm)

                        If sendEmail(sTo, "", sFrom, sSubject, sMessage, sError) Then
                            sError = ""
                            env.WriteTrace(3, "e-mail sent OK ", sIdm)
                        Else
                            env.WriteTrace(3, "Error sending e-mail: " & sError, sIdm)
                            sError = "ErrorSendingEmailNotification"
                        End If
                    End If
                Else
                    env.WriteTrace(1, "Error storing message between users", sIdm)
                End If

            Next
            Return sError

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ErrorMessage
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' getOfferTitle: Get the title of an offer                         
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 04-06-2012   1.0     Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Private Function getOfferTitle(ByVal offer_id As Integer) As String

        Dim ErrorMessage, sSql As String
        Dim stOffer As DataAccess.stOffer

        Const sIdm As String = "EngService.getOfferTitle"

        Try
            sSql = "offer_id = " & offer_id.ToString
            stOffer = env.DataAccess.getOffer(sSql)

            Return stOffer.Short_Description

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ""
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' getOfferTitle: Get the title of an offer                         
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Date     Version   Comments
    ''' ----------------------------------------------------------------------------------
    ''' 04-06-2012   1.0     Creation
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Private Function getRequestTitle(ByVal req_id As Integer) As String

        Dim ErrorMessage, sSql As String
        Dim stRequest As DataAccess.StRequest

        Const sIdm As String = "EngService.getOfferTitle"

        Try
            sSql = "Requestid = " & req_id.ToString
            stRequest = env.DataAccess.getRequest(sSql)

            Return stRequest.Short_description

        Catch ex As Exception
            ErrorMessage = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            Return ""
        End Try

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' Notify: Send notification
    ''' </summary>
    ''' <remarks>
    ''' idEvent: Event to notify
    ''' iditem:
    ''' sUserName:
    ''' sUserId:
    ''' sShortDesc: Short description
    ''' sLongDesc: Long description
    ''' sLang: Language
    ''' ContactType: Type of contact
    ''' </remarks>
    ''' <history>
    ''' 15-02-2012  Creación
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Sub Notify(ByVal Login As String, _
                      ByVal idEvent As Integer, _
                      ByVal iditem As Integer, _
                      ByVal sUserName As String, _
                      ByVal sUserId As String, _
                      ByVal sShortDesc As String, _
                      ByVal sLongDesc As String, _
                      ByVal sLang As String, _
                      ByVal ContactType As Integer, _
                      ByRef sError As String, _
                      Optional ByVal iRec As Integer = 0)

        Dim sToList(), sFrom, sSubject, sMessage, sLng(), sTemp() As String
        Dim sbHtml As StringBuilder
        Dim iResult, i, iType, iUserId, idOffer, idReq As Integer
        Dim bNotifyAdmin, bNotifyUser, bNotifySubs As Boolean
        Dim sSql As String

        Dim stUserProfile As DataAccess.UserProfile
        Dim stOffer As DataAccess.stOffer
        Dim stRequest As DataAccess.StRequest

        Const iOFFER As Integer = 1
        Const iREQUEST As Integer = 2

        Const sIdm As String = "Notification.Notify"

        env = New Environment("Life_2.0.ENGService")

        Try
            env.WriteTrace(3, "Notify idEvent = " & idEvent.ToString, sIdm)
            env.WriteTrace(3, "Notify idItem = " & iditem.ToString, sIdm)
            env.WriteTrace(3, "Notify sUserName = " & sUserName, sIdm)
            env.WriteTrace(3, "Notify sUserId = " & sUserId, sIdm)
            env.WriteTrace(3, "Notify sShortDesc = " & sShortDesc, sIdm)
            env.WriteTrace(3, "Notify sLongDesc = " & sLongDesc, sIdm)
            env.WriteTrace(3, "Notify sLang = " & sLang, sIdm)

            sLng = sLang.Split(",")

            Select Case idEvent

                Case EventAddActivity
                    '+--------------------------+
                    '| Compose the message body |
                    '+--------------------------+
                    sbHtml = New StringBuilder(Functions.loadTemplate("email-activity", Trim(sLng(0))))
                    bNotifyAdmin = True
                    bNotifyUser = False
                    bNotifySubs = True

                Case EventAddCategory
                    sbHtml = New StringBuilder(Functions.loadTemplate("email-category", Trim(sLng(0))))
                    bNotifyAdmin = True
                    bNotifyUser = False
                    bNotifySubs = False

                Case EventAddService
                    sbHtml = New StringBuilder(Functions.loadTemplate("email-service", Trim(sLng(0))))
                    bNotifyAdmin = True
                    bNotifyUser = False
                    bNotifySubs = True

                Case EventAddSkill
                    sbHtml = New StringBuilder(Functions.loadTemplate("email-skill", Trim(sLng(0))))
                    bNotifyAdmin = True
                    bNotifyUser = False
                    bNotifySubs = False

                Case EventJoinActivity
                    sbHtml = New StringBuilder(Functions.loadTemplate("email-joinactivity", Trim(sLng(0))))
                    bNotifyAdmin = True
                    bNotifyUser = False
                    bNotifySubs = False

                Case EventSubmitRequest
                    sbHtml = New StringBuilder(Functions.loadTemplate("email-request", Trim(sLng(0))))
                    bNotifyAdmin = True
                    bNotifyUser = False
                    bNotifySubs = True

                Case EventAddOffer
                    sbHtml = New StringBuilder(Functions.loadTemplate("email-offer", Trim(sLng(0))))
                    bNotifyAdmin = True
                    bNotifyUser = False
                    bNotifySubs = True

                Case EventReplyOffer
                    sbHtml = New StringBuilder(Functions.loadTemplate("email-offer", Trim(sLng(0))))
                    bNotifyAdmin = False
                    bNotifyUser = True
                    bNotifySubs = False

                Case EventReplyRequest
                    sbHtml = New StringBuilder(Functions.loadTemplate("email-replyrequest", Trim(sLng(0))))
                    bNotifyAdmin = False
                    bNotifyUser = True
                    bNotifySubs = False

                Case EventApplyForOffer
                    sbHtml = New StringBuilder(Functions.loadTemplate("email-offer", Trim(sLng(0))))
                    bNotifyAdmin = True
                    bNotifyUser = True
                    bNotifySubs = False

                Case EventApplyForRequest
                    sbHtml = New StringBuilder(Functions.loadTemplate("email-request", Trim(sLng(0))))
                    bNotifyAdmin = True
                    bNotifyUser = True
                    bNotifySubs = False

                Case EventCommentOffer
                    sbHtml = New StringBuilder(Functions.loadTemplate("email-commentoffer", Trim(sLng(0))))
                    bNotifyAdmin = False
                    bNotifyUser = True
                    bNotifySubs = False

                Case EventAddMpOffer
                    sbHtml = New StringBuilder(Functions.loadTemplate("email-offer", Trim(sLng(0))))
                    bNotifyAdmin = True
                    bNotifyUser = False
                    bNotifySubs = True

            End Select

            sbHtml.Replace("{#UserName#}", sUserName)
            sbHtml.Replace("{#UserId#}", sUserId)
            sbHtml.Replace("{#ShortDesc#}", sShortDesc)
            sbHtml.Replace("{#IdItem#}", iditem.ToString)
            sbHtml.Replace("{#LongDesc#}", sLongDesc)
            sMessage = sbHtml.ToString

            env.WriteTrace(3, "sMessage = " & sMessage, sIdm)

            sTemp = sbHtml.ToString.Split(vbCr)
            sSubject = sTemp(0)

            env.WriteTrace(3, "sSubject = " & sSubject, sIdm)

            Select Case idEvent

                Case EventReplyOffer
                    iType = iOFFER
                    idOffer = iditem
                    idReq = 0

                Case EventReplyRequest
                    iType = iREQUEST
                    idOffer = 0
                    idReq = iditem

                Case EventApplyForOffer
                    iType = iOFFER
                    idOffer = iditem
                    idReq = 0

                Case EventApplyForRequest
                    iType = iREQUEST
                    idOffer = 0
                    idReq = iditem

                Case EventCommentOffer
                    iType = iOFFER
                    idOffer = iditem
                    idReq = 0

            End Select

            '+---------------------------+
            '| Notify the administrators |
            '+---------------------------+
            If bNotifyAdmin Then
                env.WriteTrace(3, "Notify administrators ", sIdm)
                '+----------------------------------------------------------------------------+
                '| Search users with the same language and profile administrator or moderator |
                '+----------------------------------------------------------------------------+
 
                Dim WsLife20DB As New WsLife20Database.DBService
                WsLife20DB.Url = Config.GetConfigVal("dBase", "Url")
                env.WriteTrace(3, "WsLife20DB.Url = " & WsLife20DB.Url, sIdm)
                WsLife20DB.Timeout = System.Threading.Timeout.Infinite
                WsLife20DB.PreAuthenticate = True
                WsLife20DB.Credentials = System.Net.CredentialCache.DefaultCredentials

                Dim retUsers() As WsLife20Database.UserProfile

                iResult = WsLife20DB.getUserList("Language Like '%" & sLng(0) & "%' AND Role>4", retUsers, 0, 0, sUserId, sError)

                If iResult <> -1 Then

                    For i = 0 To retUsers.Length - 1
                        ReDim Preserve sToList(i)
                        If retUsers(i).Notification_level = 1 Or retUsers(i).Notification_level = 3 Then
                            sToList(i) = retUsers(i).Email
                        Else
                            sToList(i) = ""
                        End If
                        env.WriteTrace(3, "retUsers(i).Email = " & retUsers(i).Email, sIdm)

                        If retUsers(i).Notification_level = 2 Or retUsers(i).Notification_level = 3 Then

                            sError = sendMessage2(Login, retUsers(i).User_id, sSubject & ": " & sLongDesc, idOffer, idReq, , iRec)

                        End If

                    Next

                    If stUserProfile.Notification_level = 1 Or stUserProfile.Notification_level = 3 Then

                        sFrom = getFrom(sLang)

                        If sendEmail(sToList, "", sFrom, sSubject, sMessage, sError) Then
                            sError = ""
                            env.WriteTrace(3, "e-mail sent OK ", sIdm)
                        Else
                            env.WriteTrace(3, "Error sending e-mail: " & sError, sIdm)
                            sError = "ErrorSendingEmailNotification"
                        End If

                    End If

                Else
                    env.WriteTrace(3, "Error retrieving user list, can not send notification", sIdm)
                End If
            End If

            '+-------------------------------------------------+
            '| Notify the user that posted an offer or request |
            '+-------------------------------------------------+
            If bNotifyUser Then
                env.WriteTrace(3, "Notify users ", sIdm)


                Select Case iType

                    Case iOFFER

                        sSql = "offer_id = " & iditem.ToString
                        stOffer = env.DataAccess.getOffer(sSql)
                        '+-----------------------+
                        '| Get the user identity |
                        '+-----------------------+
                        iUserId = stOffer.Promoter_id


                    Case iREQUEST

                        sSql = "Requestid = " & iditem.ToString
                        stRequest = env.DataAccess.getRequest(sSql)
                        '+-----------------------+
                        '| Get the user identity |
                        '+-----------------------+
                        iUserId = stRequest.Requester_id

                End Select

                sSql = "User_id = " & iUserId.ToString
                stUserProfile = env.DataAccess.getUserProfile(sSql)

                ReDim Preserve sToList(0)
                sToList(0) = stUserProfile.Email
                env.WriteTrace(3, "stUserProfile.Email = " & stUserProfile.Email, sIdm)

                sFrom = Config.GetConfigVal("Email", "From")

                '+-----------------------------------------------------------------+
                '| Send e-mail if notification by e-mail defined in user's profile |
                '+-----------------------------------------------------------------+
                If stUserProfile.Notification_level = 1 Or stUserProfile.Notification_level = 3 Then

                    If sendEmail(sToList, "", sFrom, sSubject, sMessage, sError) Then
                        sError = ""
                        env.WriteTrace(3, "e-mail sent OK ", sIdm)
                    Else
                        env.WriteTrace(3, "Error sending e-mail: " & sError, sIdm)
                        sError = "ErrorSendingEmailNotification"
                    End If

                End If

                '+---------------------------------------------------------------------------+
                '| Send e-mail if notification by internal message defined in user's profile |
                '+---------------------------------------------------------------------------+
                If stUserProfile.Notification_level = 2 Or stUserProfile.Notification_level = 3 Then

                    sError = sendMessage2(Login, iUserId.ToString, sSubject & ": " & sLongDesc, idOffer, idReq, , iRec)

                End If

            End If

            '+--------------------------------------------------------------------------------------+
            '| Notify the users that have subscribed an activity or applied for an offer or request |
            '+--------------------------------------------------------------------------------------+
            If bNotifySubs Then

                Dim rJoins() As Join
                '+--------------------------------------------------------------+
                '| Read the list of joins related to the Offer/Request/Activity |
                '+--------------------------------------------------------------+
                sSql = "Id = " & iditem.ToString
                iResult = lGetJoins(sSql, rJoins, 0, 0, "", sError)

                '+---------------------------------------------------------------------------------------------+
                '| For each Join, read the notification level and send the corresponding mesaages to each user |
                '+---------------------------------------------------------------------------------------------+
                For i = 0 To rJoins.Length - 1
                    '+---------------------------------+
                    '| Get the subscribed user profile |
                    '+---------------------------------+
                    sSql = "User_id = " & rJoins(i).User_id.ToString

                    stUserProfile = env.DataAccess.getUserProfile(sSql)

                    If stUserProfile.User_id <> 0 Then
                        '+-----------------------------------------------------------------+
                        '| Send e-mail if notification by e-mail defined in user's profile |
                        '+-----------------------------------------------------------------+
                        If stUserProfile.Notification_level = 1 Or stUserProfile.Notification_level = 3 Then

                            If sendEmail(sToList, "", sFrom, sSubject, sMessage, sError) Then
                                sError = ""
                                env.WriteTrace(3, "e-mail sent OK ", sIdm)
                            Else
                                env.WriteTrace(3, "Error sending e-mail: " & sError, sIdm)
                                sError = "ErrorSendingEmailNotification"
                            End If

                        End If

                        '+---------------------------------------------------------------------------+
                        '| Send e-mail if notification by internal message defined in user's profile |
                        '+---------------------------------------------------------------------------+
                        If stUserProfile.Notification_level = 2 Or stUserProfile.Notification_level = 3 Then

                            sError = sendMessage2(Login, stUserProfile.User_id, sSubject & ": " & sLongDesc, idOffer, idReq, , iRec)

                        End If

                    End If

                Next

            End If

        Catch ex As Exception
            sError = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, sError, sIdm)
        End Try

    End Sub

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' getFrom: get From address
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    ''' 13-06-2012  Creación
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    Public Function getFrom(ByVal lang As String) As String

        Dim sFrom, sName, sError As String

        Const sIdm As String = "Notification.getFrom"

        Try
            sName = Functions.loadTemplate("email-header", lang)

            env.WriteTrace(3, "sName = " & sName, sIdm)

            sFrom = """" & sName & """ " & Config.GetConfigVal("Email", "From")

            'sFrom = Config.GetConfigVal("Email", "From")

            env.WriteTrace(3, "sFrom = " & sFrom, sIdm)

            Return sFrom

        Catch ex As Exception
            sError = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(1, sError, sIdm)
            Return ""
        End Try

    End Function

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
            env.WriteTrace(3, "sMessage: " & sMessage, sIdm)

            'Start by creating a mail message object
            Dim MyMailMessage As New MailMessage()

            'From requires an instance of the MailAddress type
            MyMailMessage.From = New MailAddress(sFrom)

            For i = 0 To sToList.Length - 1
                If sToList(i) <> "" Then
                    MyMailMessage.To.Add(sToList(i))
                End If
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

            MyMailMessage.Dispose()

        Catch ex As Exception
            sError = "Error in " & sIdm & ": " & ex.Message
            env.WriteTrace(3, "Exception2: " & sError, sIdm)
            Return False

        End Try

    End Function


    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' UploadFile: Upload a File and attach it to an offer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''   Date      Version     Comments
    ''' ---------------------------------------------------------------------------------
    ''' 26-10-2011   1.0.0      Creación
    ''' </history>
    ''' ----------------------------------------------------------------------------------
    <WebMethod()> _
    Public Function UploadFile(ByVal Login As String, _
                               ByVal fileName As String, _
                               ByVal Offer As Integer, _
                               ByVal objFile As Byte(), _
                               ByVal overwrite As Boolean, _
                               ByRef ErrorMessage As String) As String

        Dim bolReturnStatus As Boolean = False
        Dim bOK As Boolean
        Dim sUpFolder, sFileVPath, sLocalFile, sSql As String
        Dim fileExists As Boolean
        Dim sReturn As String = ""

        Dim objFileStream As FileStream

        Dim stUserProfile As DataAccess.UserProfile
        Dim stOffer As DataAccess.stOffer

        '+--------------------+
        '| Initialize the app |
        '+--------------------+
        Const sIdm As String = "ENGService.UploadFile"
        env = New Environment("Life_2.0.ENGService")

        Try

            env.WriteTrace(3, "Login user:" & Login, sIdm)

            stUserProfile = env.DataAccess.getUserProfile(Login)

            If stUserProfile.User_id <> 0 And stUserProfile.Enabled = 1 Then
                '+----------------------------------------+
                '| Chcek if the Offer belongs to the user |
                '+----------------------------------------+
                env.WriteTrace(3, "Chcek if the Offer belongs to the user:" & Login, sIdm)
                sSql = "Offer_id = " & Offer.ToString & " And Promoter_id = " & stUserProfile.User_id

                stOffer = env.DataAccess.getOffer(sSql)

                If stOffer.Offer_id <> 0 Then
                    '+---------------------------------------------------+
                    '| read the folder where files have to be uploaded   |
                    '+---------------------------------------------------+
                    sUpFolder = Config.GetConfigVal("files", "fileFolder")
                    If Not sUpFolder.EndsWith("\") Then
                        sUpFolder &= "\"
                    End If
                    '+--------------------------------------------------------------------------+
                    '| Add the login to the path, in order to stored files in the user's folder |
                    '+--------------------------------------------------------------------------+
                    sUpFolder &= Login & "\"

                    env.WriteTrace(3, "File folder: " & sUpFolder, sIdm)

                    '+----------------------------------------------------+
                    '| Check if the folder exists, if does not, create it |
                    '+----------------------------------------------------+
                    bOK = checkfolderexists(sUpFolder)

                    If bOK Then

                        '+-------------------------------------------+
                        '| set the full path of the local file local |
                        '+-------------------------------------------+
                        sLocalFile = sUpFolder & fileName
                        env.WriteTrace(3, "file path:" & sLocalFile, sIdm)

                        '+------------------------------+
                        '| Check if file already exists |
                        '+------------------------------+
                        fileExists = My.Computer.FileSystem.FileExists(sLocalFile)

                        If overwrite Or Not fileExists Then

                            Try 'Control any errors in writing file

                                '+-----------------------------------------------------------------+
                                '| creates the file by opening and setting the fileaccess to write |
                                '+-----------------------------------------------------------------+
                                objFileStream = System.IO.File.Open(sLocalFile, FileMode.Create, FileAccess.Write)

                                '+----------------+
                                '| Write the file |
                                '+----------------+
                                objFileStream.Write(objFile, 0, objFile.Length)

                                '+------------------------------------------------+
                                '| clears the buffer and writes any buffered data |
                                '+------------------------------------------------+
                                objFileStream.Flush()

                                '+-------------------------------------------------------+
                                '| close the file so it can be access by other processes |
                                '+-------------------------------------------------------+
                                objFileStream.Close()

                                '+------------------------------+
                                '| Create the file virtual path |
                                '+------------------------------+
                                sFileVPath = Config.GetConfigVal("files", "filevpath")
                                If Not sFileVPath.EndsWith("/") Then
                                    sFileVPath &= "/"
                                End If
                                sFileVPath &= Login & "/" & fileName

                                If Not fileExists Then
                                    '+-----------------------------------------+
                                    '| Add the URL of the file to the database |
                                    '+-----------------------------------------+
                                    bOK = env.DataAccess.DBinsert("files", _
                                                                  "fileName", CDBStr(fileName), _
                                                                  "Offer", Offer, _
                                                                  "Url", CDBStr(sFileVPath), _
                                                                  "Userid", stUserProfile.User_id)

                                    If bOK Then
                                        env.WriteTrace(3, "User updated OK", sIdm)
                                        '+-----------------------------------+
                                        '| return a successful upload status |
                                        '+-----------------------------------+
                                    Else
                                        sReturn = "DatabaseNotUpdated"
                                    End If

                                End If

                            Catch ex As Exception
                                ErrorMessage = "ERRORin " & sIdm & ": " & ex.Message
                                env.WriteTrace(1, ErrorMessage, sIdm)
                                sReturn = ErrorMessage
                            End Try
                        Else
                            env.WriteTrace(3, "Can Not Overwrite File: " & sUpFolder, sIdm)
                            ErrorMessage = "CanNotOverwriteFile"
                            sReturn = ErrorMessage
                        End If
                    Else
                        env.WriteTrace(3, "Can Not Create Folder: " & sUpFolder, sIdm)
                        ErrorMessage = "CanNotCreateFolder"
                        sReturn = ErrorMessage
                    End If
                Else
                    env.WriteTrace(3, "Offer does not belongs to the user, error in DataAccess module", sIdm)
                    sReturn = "OfferDoesNotBelongsToUser"
                End If

            Else
                env.WriteTrace(3, "User not read", sIdm)
                ErrorMessage = "ErrorReadingUserProfile"
                sReturn = ErrorMessage
            End If

        Catch ex As Exception
            ErrorMessage = "ERRORin " & sIdm & ": " & ex.Message
            env.WriteTrace(1, ErrorMessage, sIdm)
            sReturn = ErrorMessage

        Finally
            '+----------------------+
            '| cleanup just in case |
            '+----------------------+
            If Not objFileStream Is Nothing Then
                objFileStream.Close()
            End If

        End Try

        Return sReturn

    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' checkfolderexists: Check if the folder exists, if not, create it
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
                If Directory.Exists(strFolder) = False Then
                    'try to create the none existing folder
                    Directory.CreateDirectory(strFolder)
                End If
            Next

            'looped through all folders successfully
            Return True
        Catch ex As Exception
            'error occured
            Return False
        End Try

    End Function


End Class
