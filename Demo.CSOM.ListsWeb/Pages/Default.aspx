<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Demo.CSOM.ListsWeb.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%;">
        <h1>CSOM List Items</h1>
        <div id="buttonContent" style="width:100%;padding:10px;" runat="server">
            <asp:TextBox Width="300" ID="viewName" runat="server"></asp:TextBox>&nbsp;&nbsp;
            <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
        </div>
        <div id="listItemsContent" style="width:100%;padding:10px;" runat="server">

        </div>
    </div>
    </form>
</body>
</html>
