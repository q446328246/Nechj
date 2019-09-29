<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<script type="text/javascript">
    $(function() {
        $('ul.contsh:last').css('border-bottom', 'none');
    })    
</script>
<asp:Repeater ID="RepeaterData" runat="server">
    <ItemTemplate>
        <ul class="contsh">
            <li class="sel_rank">
                <div class="prdt_img">
                    <a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>' target="_blank" title='<%# Eval("Name")%>'>
                        <asp:Image ID="ImageProduct" runat="server" ImageUrl='<%# Eval("OriginalImage")+"_60x60.jpg"%>'
                            onerror="javascript:this.src='/ImgUpload/noimg.jpg_60x60.jpg'" CssClass="mar_img" />
                    </a>
                </div>
            </li>
            <li class="sel_info">
                <p>
                    <a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>' target="_blank" title='<%# Eval("Name")%>'>
                        <%# Utils.GetUnicodeSubString(Eval("Name").ToString(),18,"") %>
                    </a>
                </p>
                <p><strong>￥<%# Eval("ShopPrice")%>元</strong></p>
                <p class="sale_out">已售出<span><%# Eval("SaleNumber")%></span>笔</p>
            </li>
        </ul>
    </ItemTemplate>
</asp:Repeater>

