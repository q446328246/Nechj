<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<div class="pro01 fr">
    <div class="all_top">
        <div class="new_info_title_left fl" style="padding-left: 10px; color: #AE270F; font-size: 14px;">
            <asp:Literal ID="LiteralTitle" runat="server"></asp:Literal></div>
        <div class="new_info_title_right fr">
            <a href="<%=ShopUrlOperate.RetUrl("ProductListSearch")%>">更多>></a></div>
    </div>
    <div class="pro01_de">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <div class="pro_det">
                    <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                        <asp:Image ImageUrl='<%# ((DataRowView)Container.DataItem).Row["OriginalImage"]%>'
                            runat="server" Style="border: 1px solid #dedede;" Width="176px" Height="132px"
                            onerror="javascript:this.src='../ImgUpload/noImage.gif'" /></a><br />
                    <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                        <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Name"].ToString(),28,"")%></a><br />
                    市场价：<span class="line_throw"><%# Globals.MoneySymbol%><%# ((DataRowView)Container.DataItem).Row["MarketPrice"]%></span><br />
                    商城价：<span class="yellow3"><%# Globals.MoneySymbol%><%# ((DataRowView)Container.DataItem).Row["ShopPrice"]%></span>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
