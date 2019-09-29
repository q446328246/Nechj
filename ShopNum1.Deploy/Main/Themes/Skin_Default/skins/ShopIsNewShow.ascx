<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="nsnp_de_newly_title">
    最新店铺</div>
<div class="nsnp_de_newly_detail">
    <ul>
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <li><a href='<%#ShopUrlOperate.GetShopUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString())%>'
                    target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["ShopName"] %>'>
                    <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["ShopName"].ToString(),34,"")%></a></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
