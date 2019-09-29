<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="shop_ano">
    <div class="all_top">
        <div style="padding-left: 10px; float: left; color: #000;">
            商城公告</div>
        <%-- <div class="fr more1" style="font-weight: normal;">
            <a href="<%=ShopUrlOperate.RetUrl("Default")%>">更多</a></div>--%>
    </div>
    <ul>
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <li>
                    <img src="Themes/Skin_Default/Images/ico_quote.gif" />
                    <a href='<%# ShopUrlOperate.RetUrl("AnnouncementDetail",((DataRowView)Container.DataItem).Row["guid"]) %> '
                        title='<%# ((DataRowView)Container.DataItem).Row["Title"] %>'>
                        <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Title"].ToString(),28,"")%></a></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
