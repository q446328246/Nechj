<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="fr hot_product">
    <div class="all_top">
        <div class="new_info_title_left fl" style="padding-left: 10px; color: #AE270F; font-size: 14px;">
            热销排行</div>
        <div class="new_info_title_right fr">
            <a href="<%=ShopUrlOperate.RetUrl("ProductListSearch")%>">更多>></a></div>
    </div>
    <div class="hot_product_detail">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <a href='<%#ShopUrlOperate.RedirectProductDetailByShopID(((DataRowView)Container.DataItem).Row["ProductGuid"].ToString(),((DataRowView)Container.DataItem).Row["Shopids"].ToString(),((DataRowView)Container.DataItem).Row["IsPanicBuy"].ToString(),((DataRowView)Container.DataItem).Row["IsSpellBuy"].ToString() ) %>'
                    target="_blank">
                    <%#((DataRowView)Container.DataItem).Row["Name"]%>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
