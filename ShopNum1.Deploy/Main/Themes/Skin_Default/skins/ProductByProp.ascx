<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<div class="tuijianpro">
    <h1>
        <asp:Literal ID="LiteralTitle" runat="server">推荐商品</asp:Literal></h1>
    <div class="tuijiancont">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <div class="tuijian">
                    <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'
                        class="tjimga">
                        <asp:Image ID="Image1" ImageUrl='<%# ((DataRowView)Container.DataItem).Row["OriginalImage"]%>'
                            onerror="javascript:this.src='../ImgUpload/noImage.gif'" runat="server" Width="65"
                            Height="65" /></a>
                    <div class="tjcont">
                        <div class="tjname">
                            <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'
                                title="<%# ((DataRowView)Container.DataItem).Row["Name"].ToString()%>">
                                <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Name"].ToString(),28,"")%></a>
                        </div>
                        <p>
                            <%# Globals.MoneySymbol%><%# ((DataRowView)Container.DataItem).Row["ShopPrice"]%></p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
