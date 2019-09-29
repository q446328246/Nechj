<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="nsnp_de_newly">
    <div class="nsnp_de_newly_title" style="color: #FF3300;">
        人气店铺</div>
    <div class="nsnp_de_newly_detail">
        <ul>
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <li><a href='<%#ShopUrlOperate.GetShopUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString())%>'
                        target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["ShopName"] %>'>
                        <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["ShopName"].ToString(), 34, "")%></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <!-- adv10 -->
    <div class="adv10">
        <a href="javascript:void(0)">
            <img width="192" height="60" src="Themes/Skin_Default/Images/002.jpg" /></a>
    </div>
</div>
