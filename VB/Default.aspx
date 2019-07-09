<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Xpo.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Xpo" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASPxCardView - How to add a new card when the edit form is always visible</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxCardView ID="ASPxCardView1" runat="server" AutoGenerateColumns="False" OnBeforeGetCallbackResult="ASPxCardView1_BeforeGetCallbackResult" DataSourceID="XpoDataSource1" KeyFieldName="Oid" OnCardInserted="ASPxCardView1_CardInserted">
            <SettingsPager>
                <SettingsTableLayout ColumnCount="2" RowsPerPage="2" />
            </SettingsPager>
            <SettingsBehavior AllowFocusedCard="True" />
            <Columns>
                <dx:CardViewTextColumn FieldName="Oid" ReadOnly="True" SortIndex="0" SortOrder="Ascending" Visible="False" VisibleIndex="0">
                </dx:CardViewTextColumn>
                <dx:CardViewTextColumn FieldName="CompanyName" VisibleIndex="2">
                </dx:CardViewTextColumn>
                <dx:CardViewTextColumn FieldName="ContactName" VisibleIndex="3">
                </dx:CardViewTextColumn>
                <dx:CardViewTextColumn FieldName="Country" VisibleIndex="5">
                </dx:CardViewTextColumn>
            </Columns>
            <CardLayoutProperties>
                <Items>
                    <dx:CardViewCommandLayoutItem HorizontalAlign="Right" ShowEditButton="True" ShowNewButton="True">
                    </dx:CardViewCommandLayoutItem>
                    <dx:CardViewColumnLayoutItem ColumnName="Oid">
                    </dx:CardViewColumnLayoutItem>
                    <dx:CardViewColumnLayoutItem ColumnName="Company Name">
                    </dx:CardViewColumnLayoutItem>
                    <dx:CardViewColumnLayoutItem ColumnName="Contact Name">
                    </dx:CardViewColumnLayoutItem>
                    <dx:CardViewColumnLayoutItem ColumnName="Country">
                    </dx:CardViewColumnLayoutItem>
                    <dx:EditModeCommandLayoutItem HorizontalAlign="Right">
                    </dx:EditModeCommandLayoutItem>
                </Items>
            </CardLayoutProperties>
        </dx:ASPxCardView>
        <dx:XpoDataSource ID="XpoDataSource1" runat="server" TypeName="Customer"></dx:XpoDataSource>
    </div>
    </form>
</body>
</html>