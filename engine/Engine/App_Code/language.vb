'Database Access Funtions Copyright (C) 2013 Alcatel·Lucent 
'This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. 
'This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
'You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
Imports Microsoft.VisualBasic
Imports System.Xml

Public Class Language
    Inherits ALUInterface

#Region "    Private members"

    Private Const HeadPrefix As String = "configuration"

    Private Const LanguagePrefix As String = "lang"

    Private m_document As XmlDocument = Nothing

#End Region

#Region "    Events"

    Event SendTrace As SendTraceEventHandler

    Protected Overrides Sub OnSendTrace(ByVal e As TraceInformationEventArgs)
        RaiseEvent SendTrace(Me, e)
    End Sub

    Protected Overrides Sub OnSendAlarm(ByVal e As AlarmInformationEventArgs)
        '' Not implemented in this classe
    End Sub

#End Region

#Region "    Private functions"

    Private Sub writeTrace(ByVal traceLevel As Byte, ByVal message As String, ByVal functionName As String)
        OnSendTrace(New TraceInformationEventArgs(traceLevel, message, functionName))
    End Sub

    Private Function GetChildNode(ByVal aNode As XmlNode, ByVal aName As String) As XmlNode
        ' Given a Node, return the ChildNode with a given Name
        Dim node As XmlNode
        If aName = "" Then Return Nothing
        If Not aNode.HasChildNodes Then Return Nothing
        For Each node In aNode.ChildNodes
            If node.Name = aName Then Return node
        Next
        Return Nothing
    End Function

    Private Function ChildNodeNamesAsCollection(ByVal aNode As XmlNode) As Collection
        Dim node As XmlNode
        Dim clx As New Collection
        If aNode.HasChildNodes = False Then Return clx
        For Each node In aNode.ChildNodes
            clx.Add(node.Name)
        Next
        Return clx
    End Function

    Private Function GetNode(ByVal aName As String, ByVal [partial] As Boolean, ByVal aXMLDoc As XmlDocument) As XmlNode
        'Get the node with the name Xpath configuration/aSection/aKey
        Dim node As XmlNode = aXMLDoc
        Dim node2 As XmlNode
        Dim str As String() = Split(aName, "/", -1, CompareMethod.Text)
        Dim strName As String
        For Each strName In str
            node2 = node
            node = GetChildNode(node, strName)
            If node Is Nothing Then
                If [partial] Then Return node2 Else Return Nothing
            End If
        Next
        Return node
    End Function

    Private Function GetConfigInfo(ByVal key As String, ByVal defaultValue As String) As Collection
        Dim node As XmlNode
        Dim clx As New Collection
        Dim strB As New StringBuilder
        ' Build the full Name of the Node - as far as it goes
        strB.Append(HeadPrefix)

        ' Append the section
        strB.Append("/" & LanguagePrefix)
        If key <> "" Then strB.Append("/" & key)
        ' Append the key

        node = GetNode(aName:=strB.ToString, [partial]:=False, aXMLDoc:=m_document)
        If node Is Nothing Then
            ' Didn' find the node: 
            ' If no section was given, this means that we didn't find the root node: configuration : return an empty collection
            ' If no key as given, we didn't find any key for this section: return an empty collection
            ' if aKey was given, it doesn't exist: return the defaultValue  
            If key <> "" Then clx.Add(defaultValue)
            Return clx
        End If
        If node.Name = key Then
            ' Return its value
            clx.Add(node.InnerText)
            Return clx
        Else
            ' Return the defaultValue if aKey was given
            ' Else return a collection with the sections or keys
            If key <> "" Then
                clx.Add(defaultValue)
                Return clx
            End If
            Return ChildNodeNamesAsCollection(node)
        End If
    End Function

#End Region

#Region "    Public members"

    Public Function LoadDocument(ByVal lng As String) As Boolean
        Const sIdm As String = "Idiomas.LoadDocument"
        Dim leng As StringBuilder

        Try
            writeTrace(2, "Init", sIdm)

            If lng.Length <> 0 Then
                leng = New StringBuilder(lng & ".xml")
            Else
                '+-------------------------------------------+
                '| Idioma por defecto es-ES (español-ESPAÑA) |
                '+-------------------------------------------+
                leng = New StringBuilder("es-ES.xml")
            End If

            leng.Insert(0, Config.GetConfigVal("files", "AppPath") & Config.GetConfigVal("files", "langPath") & "/")
            m_document = New XmlDocument
            m_document.Load(leng.ToString)
        Catch ex As Exception
            writeTrace(1, "There has been an error: " & ex.Message, sIdm)
            Return False
        Finally
            writeTrace(2, "End", sIdm)
        End Try

        Return True
    End Function

    Public Function Translate(ByVal sentence As String) As String
        Return CStr(GetConfigInfo(sentence, String.Empty).Item(1))
    End Function

#End Region

End Class
