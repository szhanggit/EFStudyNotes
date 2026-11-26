<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Standard2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblUserName" runat="server" Text="UserName: "></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
    </div>
    </form>
</body>
</html>
