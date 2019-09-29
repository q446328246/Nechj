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
                    <a href='<%# GetPageName.RetUrlcenter("ProductDetail",Eval("guid"),Eval("shop_category_id").ToString())%>' target="_blank" title='<%# Eval("Name")%>'>
                        <asp:Image ID="ImageProduct" runat="server" ImageUrl='<%# Eval("OriginalImage")+"_60x60.jpg"%>'
                            onerror="javascript:this.src='/ImgUpload/noimg.jpg_60x60.jpg'" CssClass="mar_img" />
                    </a>
                </div>
            </li>
            <li class="sel_info">
                <p>
                    <a href='<%# GetPageName.RetUrlcenter("ProductDetail",Eval("guid"),Eval("shop_category_id").ToString())%>' target="_blank" title='<%# Eval("Name")%>'>
                        <%# Utils.GetUnicodeSubString(Eval("Name").ToString(),18,"") %>
                    </a>
                </p>
                   <%
        string Category = "1";
        if (Page.Request.QueryString["category"] != null)
        {
            Category = Page.Request.QueryString["category"];
        }
        else if (Page.Request.Cookies["category"] != null)
        {
            Category = Page.Request.Cookies["category"].Value;
        }

        
         %>
                  <%  if (Category == "3" )
                        {%>
                        <p class="pdt_price" >
                        <strong>积分:<asp:Literal ID="Literal1" runat="server" Text='<%# Convert.ToDecimal(Eval("Score_cv"))*-1%>'></asp:Literal></strong>
                    </p>
                    
                    <% }
                      %>
                      
                    
                    <%
                        else
                        {%>
                        <p class="pdt_price" >
                        <strong>￥<asp:Literal ID="LiteralGroupPrice" runat="server" Text='<%# Eval("ShopPrice")%>'></asp:Literal>元</strong>
                    </p>
                    <%} %>
                <p class="sale_out">已售出<span><%# Eval("SaleNumber")%></span>笔</p>
            </li>
        </ul>
    </ItemTemplate>
</asp:Repeater>

