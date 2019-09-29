<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<div class="noproduct">
    <h1>
        您是不是想找以下商品</h1>
    <div class="noproduct_cont">
        <asp:Literal ID="LiteralTitle" runat="server" Visible="false"></asp:Literal>
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <div class="noItem">
                    <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'
                        class="nohove">
                        <asp:Image ID="Image1" ImageUrl='<%# ((DataRowView)Container.DataItem).Row["OriginalImage"]%>'
                            runat="server" Width="160" Height="160" onerror="javascript:this.src='../ImgUpload/noImage.gif'" /></a>
                    <p>
                        <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                            <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Name"].ToString(),28,"")%></a>
                    </p>
                    <div class="noprice">
                        <%# Globals.MoneySymbol%><%# ((DataRowView)Container.DataItem).Row["MarketPrice"]%></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="clear">
    </div>
</div>
