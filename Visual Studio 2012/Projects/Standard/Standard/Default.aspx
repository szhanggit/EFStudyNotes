<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Standard.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtSalesOrderDetailID" runat="server"></asp:TextBox><asp:Button ID="btnSearchBySalesOrderDetailID" runat="server" Text="Search" OnClick="btnSearchBySalesOrderDetailID_Click"  />
    </div>
    <div>
        <asp:Label ID="lblDisplayBoard" runat="server"></asp:Label>
    </div>
    <div>
        Name: <asp:TextBox ID="txtName" runat="server"></asp:TextBox> QTY: <asp:TextBox ID="txtQTY" runat="server"></asp:TextBox><asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />
    </div>
    <div>
        Title: <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        Suffix: <asp:TextBox ID="txtSuffix" runat="server"></asp:TextBox>
        Sales Person: <asp:TextBox ID="txtSalesPerson" runat="server"></asp:TextBox>
        <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" />
    </div>
    <div>
        <asp:gridview ID="gvSalesOrderDetail" runat="server" AllowPaging="True" PageSize="20"
             AutoGenerateColumns="False">
            <columns>                
                <asp:BoundField DataField="CustomerID" Visible="false" />
                <asp:BoundField DataField="Title" HeaderText="Title" Visible="true" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" Visible="true" />
                <asp:BoundField DataField="MiddleName" HeaderText="Middle Name" Visible="true" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" Visible="true" />
                <asp:BoundField DataField="Suffix" HeaderText="Suffix" Visible="true" />
                <asp:BoundField DataField="CompanyName" HeaderText="Company Name" Visible="true" />
                <asp:BoundField DataField="SalesPerson" HeaderText="Sales Person" Visible="true" />
                <asp:BoundField DataField="EmailAddress" HeaderText="Email" Visible="true" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" Visible="true" />
                <asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" Visible="true" />
            </columns>
        </asp:gridview>
    </div>
    </form>
</body>
</html>
