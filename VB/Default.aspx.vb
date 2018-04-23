Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Xpo
Imports System.Collections

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Private uof As UnitOfWork = XpoHelper.GetNewUnitOfWork()
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        XpoDataSource1.Session = uof
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            ASPxCardView1.AddNewCard()
        End If
    End Sub
    Protected Sub ASPxCardView1_CardInserted(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertedEventArgs)
        Dim newKey As Object = Nothing
        If e.AffectedRecords = 1 Then
            Dim objects As ICollection = uof.GetObjectsToSave()
            If objects IsNot Nothing AndAlso objects.Count = 1 Then
                Dim enumeration As IEnumerator = objects.GetEnumerator()
                enumeration.MoveNext()
                Dim obj As Customer = DirectCast(enumeration.Current, Customer)
                uof.CommitChanges()
                newKey = obj.Oid
            End If
        End If
        ASPxCardView1.FocusedCardIndex = ASPxCardView1.FindVisibleIndexByKeyValue(newKey)
    End Sub
    Protected Sub ASPxCardView1_BeforeGetCallbackResult(ByVal sender As Object, ByVal e As EventArgs)
        If (Not ASPxCardView1.IsEditing) AndAlso (Not ASPxCardView1.IsNewCardEditing) Then
            ASPxCardView1.AddNewCard()
        End If
    End Sub
End Class