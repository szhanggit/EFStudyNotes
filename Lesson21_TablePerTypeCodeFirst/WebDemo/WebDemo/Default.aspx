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
            <div style="font-family: Arial">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True"
                    OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem Text="Load all Employees" Value="All"></asp:ListItem>
                    <asp:ListItem Text="Load Permanent Employees" Value="Permanent"></asp:ListItem>
                    <asp:ListItem Text="Load Contract Employees" Value="Contract"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
                <br />
                <asp:Button ID="btnAddPermanentEmployee" runat="server" 
                    Text="Add Permanent Employee"
                    OnClick="btnAddPermanentEmployee_Click" />
                <br />
                <br />
                <asp:Button ID="btnAddContractEmployee" runat="server" Text="Add Contract Employee"
                    OnClick="btnAddContractEmployee_Click" />
            </div>
        </div>
    </div>

</asp:Content>
