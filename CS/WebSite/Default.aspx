<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHiddenField" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">
        function OnImageInit(s, e) {
            var element = s.GetMainElement();
            element.onmousedown = element.onmouseup = function (event) {
                event.cancelBubble = true;
                return false;
            };
        }
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxGridView ID="GridView1" runat="server"
            KeyFieldName="ProductID" ClientInstanceName="gridView" OnBeforeGetCallbackResult="GridView1_BeforeGetCallbackResult" DataSourceID="ads" OnDataBound="GridView1_DataBound">
            <Settings ShowGroupPanel="true" />
            <SettingsBehavior AllowGroup="true" />
        </dx:ASPxGridView>
        <asp:AccessDataSource ID="ads" runat="server" DataFile="~/App_Data/nwind.mdb" SelectCommand="SELECT [ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued] FROM [Products]"></asp:AccessDataSource>
    </form>
</body>
</html>
