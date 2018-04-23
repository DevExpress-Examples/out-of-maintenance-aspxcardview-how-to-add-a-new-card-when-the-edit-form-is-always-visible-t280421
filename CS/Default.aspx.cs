using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Xpo;
using System.Collections;

public partial class _Default : System.Web.UI.Page
{
    UnitOfWork uof = XpoHelper.GetNewUnitOfWork();
    protected void Page_Init(object sender, EventArgs e)
    {
        XpoDataSource1.Session = uof;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ASPxCardView1.AddNewCard();
        }
    }
    protected void ASPxCardView1_CardInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
    {
        object newKey = null;
        if (e.AffectedRecords == 1)
        {
            ICollection objects = uof.GetObjectsToSave();
            if (objects != null && objects.Count == 1)
            {
                IEnumerator enumeration = objects.GetEnumerator();
                enumeration.MoveNext();
                Customer obj = (Customer)enumeration.Current;
                uof.CommitChanges();
                newKey = obj.Oid;
            }
        }
        ASPxCardView1.FocusedCardIndex = ASPxCardView1.FindVisibleIndexByKeyValue(newKey);
    }
    protected void ASPxCardView1_BeforeGetCallbackResult(object sender, EventArgs e)
    {
        if (!ASPxCardView1.IsEditing && !ASPxCardView1.IsNewCardEditing)
        {
            ASPxCardView1.AddNewCard();
        }
    }
}