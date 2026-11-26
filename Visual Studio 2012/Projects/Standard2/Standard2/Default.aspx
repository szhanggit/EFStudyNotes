<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Standard2.Default" %>
<%@ Register src="~/UserControl/uc.ascx" tagname="search" tagprefix="asp" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Class Management System</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:search ID="search" runat="server" />
        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
        <asp:Button ID="btnGeneratePage" runat="server" Text="Generate Page" OnClick="btnGeneratePage_Click" />
    <div>
        <div><asp:GridView ID="gvClass" runat="server"></asp:GridView></div>
        <div><asp:GridView ID="gvTeacher" runat="server"></asp:GridView></div>
        <div><asp:GridView ID="gvStudent" runat="server"></asp:GridView></div>
        <div><asp:GridView ID="gvStudentClass" runat="server"></asp:GridView></div>
        <div><asp:GridView ID="gvTI" runat="server"></asp:GridView></div>
        <br /><br />
        <asp:Panel ID="Panel1" runat="server">
            <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True"></asp:DropDownList>
            <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True"></asp:DropDownList>
            <asp:Button ID="btnAddRegistration" runat="server" Text="Register" OnClick="btnAddRegistration_Click" />
        </asp:Panel>
    </div>        
    </form>
</body>
</html>
