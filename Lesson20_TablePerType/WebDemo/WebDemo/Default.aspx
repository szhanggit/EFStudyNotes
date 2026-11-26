<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebDemo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-12">
            <h2>Getting started</h2>
            <div style="font-family:Arial">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server"
                AutoPostBack="True"
                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem Text="All Employees" Value="All"></asp:ListItem>
                <asp:ListItem Text="Load Permanent Employees" Value="Permanent">
                </asp:ListItem>
                <asp:ListItem Text="Load Contract Employees" Value="Contract">
                </asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
