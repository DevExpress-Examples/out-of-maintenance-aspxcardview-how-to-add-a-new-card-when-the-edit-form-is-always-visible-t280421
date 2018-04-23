Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo.Metadata

''' <summary>
''' Summary description for XpoHelper
''' </summary>
Public NotInheritable Class XpoHelper

    Private Sub New()
    End Sub

    Shared Sub New()
        CreateDefaultObjects()
    End Sub

    Public Shared Function GetNewSession() As Session
        Return New Session(DataLayer)
    End Function

    Public Shared Function GetNewUnitOfWork() As UnitOfWork
        Return New UnitOfWork(DataLayer)
    End Function

    Private ReadOnly Shared lockObject As New Object()

    Private Shared fDataLayer As IDataLayer
    Private Shared ReadOnly Property DataLayer() As IDataLayer
        Get
            If fDataLayer Is Nothing Then
                SyncLock lockObject
                    fDataLayer = GetDataLayer()
                End SyncLock
            End If
            Return fDataLayer
        End Get
    End Property

    Private Shared Function GetDataLayer() As IDataLayer
        XpoDefault.Session = Nothing

        Dim ds As New InMemoryDataStore()
        Dim dict As XPDictionary = New ReflectionDictionary()
        dict.GetDataStoreSchema(GetType(Customer).Assembly)

        Return New ThreadSafeDataLayer(dict, ds)
    End Function

    Private Shared Sub CreateDefaultObjects()
        Using uow As UnitOfWork = GetNewUnitOfWork()
            Dim cust As New Customer(uow)
            cust.CompanyName = "Alfreds Futterkiste"
            cust.ContactName = "Maria Anders"
            cust.Country = "Germany"

            cust = New Customer(uow)
            cust.CompanyName = "Ana Trujillo Emparedados y helados"
            cust.ContactName = "Ana Trujillo"
            cust.Country = "Mexico"

            cust = New Customer(uow)
            cust.CompanyName = "Antonio Moreno Taquería"
            cust.ContactName = "Antonio Moreno"
            cust.Country = "Mexico"

            cust = New Customer(uow)
            cust.CompanyName = "Blondel père et fils"
            cust.ContactName = "Frédérique Citeaux"
            cust.Country = "France"

            cust = New Customer(uow)
            cust.CompanyName = "Berglunds snabbköp"
            cust.ContactName = "Christina Berglund"
            cust.Country = "Sweden"

            cust = New Customer(uow)
            cust.CompanyName = "Bottom-Dollar Markets"
            cust.ContactName = "Elizabeth Lincoln"
            cust.Country = "Canada"

            uow.CommitChanges()
        End Using
    End Sub
End Class

