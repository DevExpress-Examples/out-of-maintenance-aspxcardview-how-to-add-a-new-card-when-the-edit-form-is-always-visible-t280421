Imports System
Imports DevExpress.Xpo

Public Class Customer
    Inherits XPObject

    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
    End Sub

    Private _CompanyName As String
    Public Property CompanyName() As String
        Get
            Return _CompanyName
        End Get
        Set(ByVal value As String)
            SetPropertyValue("CompanyName", _CompanyName, value)
        End Set
    End Property

    Private _ContactName As String
    Public Property ContactName() As String
        Get
            Return _ContactName
        End Get
        Set(ByVal value As String)
            SetPropertyValue("ContactName", _ContactName, value)
        End Set
    End Property

    Private _Country As String
    Public Property Country() As String
        Get
            Return _Country
        End Get
        Set(ByVal value As String)
            SetPropertyValue("Country", _Country, value)
        End Set
    End Property
End Class

