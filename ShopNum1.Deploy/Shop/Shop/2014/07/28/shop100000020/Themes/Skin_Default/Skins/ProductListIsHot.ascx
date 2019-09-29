<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<div class="bBoxnt">
    <h2>
        <span>热卖商品</span> 
        <a href='<%= GetPageName.RetUrl("ProductListHot")%>' class="more">更多&gt&gt</a>
    </h2>
    <div class="content clearfix">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <div class="pruct_zs">
                    <div class="pdt_img">
                        <p class="ncs_img">
                            <a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>' target="_blank" title='<%# Eval("Name")%>'>
                                <asp:Image ID="ImageProduct" runat="server" ImageUrl='<%# Eval("OriginalImage")+"_160x160.jpg" %>'
                                    onerror="javascript:this.src='/ImgUpload/noimg.jpg_160x160.jpg'" /></a>
                        </p>
                    </div>
                    <p class="pdt_name">
                        <a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>' target="_blank" title='<%# Eval("Name")%>'>
                            <%# Utils.GetUnicodeSubString(Eval("Name").ToString(),25,"") %>
                            <asp:Literal ID="LiteralProductName" runat="server" Visible="false" Text='<%# Eval("Name").ToString() %>'></asp:Literal>
                        </a>
                    </p>
                    <p class="pdt_price">
                        <strong>￥<asp:Literal ID="LiteralGroupPrice" runat="server" Text='<%# Eval("ShopPrice")%>'></asp:Literal>元</strong>
                    </p>
                    <p class="pdtsele_out">
                        已售出：<span><%# Eval("SaleNumber")%></span>件
                    </p>
                    <asp:Literal ID="LiteralProductGuid" runat="server" Text='<%# Eval("guid")%>' Visible="false"></asp:Literal>
                    <asp:Literal ID="LiteralShopName" runat="server" Text='<%# Eval("ShopName")%>' Visible="false"></asp:Literal>
                    <asp:Literal ID="LiteralMemLoginID" runat="server" Text='<%# Eval("MemLoginID")%>' Visible="false"></asp:Literal>                   
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
