<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<div class="announcements" style="margin-top: 0; border: 1px solid #b3b3b3;">
    <div class="brand_best">
        <img width="55" height="55" src="Themes/Skin_Default/Images/brandbest.gif" /></div>
    <div class="announ_top">
        <div class="fl">
            <img src="Themes/Skin_Default/Images/brand1.jpg" /></div>
        <div class="fr" style="padding-top: 9px; padding-right: 45px;">
            <a href="javascript:void(0)">更多>></a></div>
    </div>
    <div style="clear: both; width: 100%; height: 20px; line-height: 20px; overflow: hidden;">
    </div>
    <asp:Repeater ID="RepeaterBrand" runat="server">
        <ItemTemplate>
            <div class="announ_list">
                <a href='BrandDetail.aspx?BrandGuid=<%# ((DataRowView)Container.DataItem).Row["Guid"] %>'
                    target="_blank">
                    <asp:Image ID="ImageBrand" Width="182" Height="62" runat="server" ImageUrl='<%#((DataRowView)Container.DataItem).Row["Logo"] %>' />
                </a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
