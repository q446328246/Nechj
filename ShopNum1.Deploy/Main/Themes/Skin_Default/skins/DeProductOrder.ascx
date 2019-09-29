<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="store_category_view">
    <h3><asp:Literal ID="LiteralTitle" runat="server"></asp:Literal></h3>
    <div class="news_pics">
        <ul>
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <li>
                        <div class="newsimg">
                            <a href="<%#ShopUrlOperate.shopDetailHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString(),"ProductDetail")%>">
                                <asp:Image ID="ImageProduct" runat="server" ImageUrl='<%#Page.ResolveUrl(((DataRowView)Container.DataItem).Row["ThumbImage"].ToString())+"_60x60.jpg"%>'
                                    onerror="javascript:this.src='/ImgUpload/noimg.jpg_60x60.jpg'" />
                            </a>
                        </div>
                        <div class="news_name">
                            <a href="<%#ShopUrlOperate.shopDetailHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString(),"ProductDetail")%>">
                                <%#ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Name"].ToString(),32,"") %>
                            </a>
                            <p class="num">销量：<span><%# ((DataRowView)Container.DataItem).Row["SaleNumber"]%></span></p>
                            <p><%# ShopNum1.Common.Globals.MoneySymbol%><%# ((DataRowView)Container.DataItem).Row["ShopPrice"]%></p>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
