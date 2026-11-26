<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Repeater.aspx.cs" Inherits="Standard.Repeater" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Repeater</title>
    <link rel="stylesheet" href="css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="ReptRestaurant" runat="server">
                <ItemTemplate>
                    <div class="menuType">
                        <div class="menuTypeHead">
                            <h4><asp:Literal ID="Literal1" Text='<%# Eval("Name")%>' runat="server" /></h4>
                            <asp:HyperLink ID="HyperLink1" CssClass="collapse" runat="server">Collapse</asp:HyperLink>                           
                            <asp:HyperLink ID="HyperLink2" CssClass="expand" runat="server">Expand</asp:HyperLink>
                        </div>
                        
                        <div class="inside">
                            <p><asp:Literal ID="Literal2" Text='<%# DataBinder.Eval(Container.DataItem, "address") %>' runat="server" /></p>
                            <p><asp:Literal ID="Literal3" Text='<%# DataBinder.Eval(Container.DataItem, "phone") %>' runat="server" /></p>
                            <p><asp:Literal ID="Literal4" Text='<%# DataBinder.Eval(Container.DataItem, "webaddress")%>' runat="server" /></p>
                            
                                  <asp:Repeater ID="Repeater1" DataSource='<%# Eval("menu") %>' runat="server">
                                    <ItemTemplate>
                                    <div>
                                      <td><%# Eval("name") %></td>
                                      <td><%# Eval("price") %></td>
                                      <td><%# Eval("star") %></td>  
                                    </div>
                                    </ItemTemplate>
                                  </asp:Repeater>


                            <%--Create a repeater to handle the Menu Items objects.
                                  This is the HTML mock up for the first row
                                  <div class="menuItem">
                                        <label>Calamari</label>
                                        <span>$9.95</span>
                                        <div class="menu-description">
                                                lightly hand breaded and friend to perfection served with roasted pepper dipping sauce
                                        </div>
                                        <div class="clear"></div>
                                    </div>
                                  This is the HTML mock up for the alternative rows
                                   <div class="menuItem alt">
                                        <label>Calamari</label>
                                        <span>$9.95</span>
                                        <div class="menu-description">
                                                lightly hand breaded and friend to perfection served with roasted pepper dipping sauce
                                        </div>
                                        <div class="clear"></div>
                                    </div>
                            --%>
                        </div>
                    </div>
                </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
    <script src="js/jquery-1.7.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/script.js"></script>
</body>
</html>
