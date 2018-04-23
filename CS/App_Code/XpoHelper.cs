using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;

/// <summary>
/// Summary description for XpoHelper
/// </summary>
public static class XpoHelper {
    static XpoHelper () {
        CreateDefaultObjects();
    }

    public static Session GetNewSession () {
        return new Session(DataLayer);
    }

    public static UnitOfWork GetNewUnitOfWork () {
        return new UnitOfWork(DataLayer);
    }

    private readonly static object lockObject = new object();

    static IDataLayer fDataLayer;
    static IDataLayer DataLayer {
        get {
            if (fDataLayer == null) {
                lock (lockObject) {
                    fDataLayer = GetDataLayer();
                }
            }
            return fDataLayer;
        }
    }

    private static IDataLayer GetDataLayer () {
        XpoDefault.Session = null;

        InMemoryDataStore ds = new InMemoryDataStore();
        XPDictionary dict = new ReflectionDictionary();
        dict.GetDataStoreSchema(typeof(Customer).Assembly);

        return new ThreadSafeDataLayer(dict, ds);
    }

    static void CreateDefaultObjects () {
        using (UnitOfWork uow = GetNewUnitOfWork()) {
            Customer cust = new Customer(uow);
            cust.CompanyName = "Alfreds Futterkiste";
            cust.ContactName = "Maria Anders";
            cust.Country = "Germany";
   
            cust = new Customer(uow);
            cust.CompanyName = "Ana Trujillo Emparedados y helados";
            cust.ContactName = "Ana Trujillo";
            cust.Country = "Mexico";

            cust = new Customer(uow);
            cust.CompanyName = "Antonio Moreno Taquería";
            cust.ContactName = "Antonio Moreno";
            cust.Country = "Mexico";

            cust = new Customer(uow);
            cust.CompanyName = "Blondel père et fils";
            cust.ContactName = "Frédérique Citeaux";
            cust.Country = "France";

            cust = new Customer(uow);
            cust.CompanyName = "Berglunds snabbköp";
            cust.ContactName = "Christina Berglund";
            cust.Country = "Sweden";

            cust = new Customer(uow);
            cust.CompanyName = "Bottom-Dollar Markets";
            cust.ContactName = "Elizabeth Lincoln";
            cust.Country = "Canada";

            uow.CommitChanges();
        }
    }
}

