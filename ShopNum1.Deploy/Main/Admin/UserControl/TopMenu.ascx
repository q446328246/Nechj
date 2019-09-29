<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopMenu.ascx.cs" Inherits="ShopNum1.Deploy.Main.Admin.UserControl.TopMenu" %>
<a href="~/ServiceAdmin/Html/AboutShopNum1.htm" target="mainFrame" id="top" runat="server">
    关于ShopNum1</a>&nbsp; <a href="~/Default.aspx" id="A1" runat="server" target="_blank">
                             浏览前台</a>&nbsp;
<asp:LinkButton ID="LinkButtonIsExite" runat="server" OnClick="LinkButtonIsExite_Click">退出后台&nbsp;</asp:LinkButton>