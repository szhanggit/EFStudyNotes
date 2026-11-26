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
                <asp:CheckBox ID="checkBoxIncludeContactDetails"
                Text="Include Contact Details" runat="server" />
                <br />
                <asp:Button ID="Button1" runat="server" Text="Get Employee Data"
                    onclick="Button1_Click" />
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
