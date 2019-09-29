<%@ Control Language="C#"%>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<%@ Import Namespace="ShopNum1.Common" %>
<div id="list_main">
    <ul class="sidebar" style="margin: 0 6px; padding-top: 20px; width: 750px;">
        <li id="Li1" class='<%= ShopNum1.Common.Common.ReqStr("type") == "0" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="?type=0">店铺设置</a></li>
        <li id="Li2" class='<%= ShopNum1.Common.Common.ReqStr("type") == "3" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="?type=3">地理位置</a></li>
    </ul>
    <div id="content" class="ordmain1">
        <asp:Panel ID="PanelShowSettings" runat="server" Visible="false">
            <ShopNum1ShopAdmin:S_ShopInfo_Settings ID="S_ShopInfo_Settings" runat="server" SkinFilename="skin/S_ShopInfo_Settings.ascx" />
        </asp:Panel>
        <asp:Panel ID="PanelShopMap" runat="server" Visible="false">
            <ShopNum1ShopAdmin:S_ShopInfo_ShopMap ID="S_ShopInfo_ShopMap" runat="server" SkinFilename="skin/S_ShopInfo_ShopMap.ascx" />
        </asp:Panel>
    </div>
</div>
