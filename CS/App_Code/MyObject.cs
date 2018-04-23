using System;
using DevExpress.Xpo;

public class Customer : XPObject {
    public Customer (Session session)
        : base(session) { }

    public override void AfterConstruction () {
        base.AfterConstruction();
    }

    string _CompanyName;
    public string CompanyName {
        get { return _CompanyName; }
        set { SetPropertyValue("CompanyName", ref _CompanyName, value); }
    }

    string _ContactName;
    public string ContactName {
        get { return _ContactName; }
        set { SetPropertyValue("ContactName", ref _ContactName, value); }
    }

    string _Country;
    public string Country {
        get { return _Country; }
        set { SetPropertyValue("Country", ref _Country, value); }
    }
}

