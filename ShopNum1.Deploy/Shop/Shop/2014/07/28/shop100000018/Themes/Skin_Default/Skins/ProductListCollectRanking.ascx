<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="System.Data" %>
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
                    <a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>' target="_blank" title='<%# Eval("ProductName")%>'>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ThumbImage")+"_60x60.jpg"%>'
                            onerror="javascript:this.src='/ImgUpload/noimg.jpg_60x60.jpg'" CssClass="mar_img" />
                    </a>
                </div>
            </li>
            <li class="sel_info">
                <p>
                    <a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>' target="_blank" title='<%# Eval("ProductName")%>'>
                        <%# Utils.GetUnicodeSubString(Eval("ProductName").ToString(), 18, "")%>
                    </a>
                </p>  
                <p><strong>￥<%# Eval("ShopPrice")%>元</strong></p>
                <p class="sale_out">收藏人气 <span><%# Eval("CollectCount")%></span></p>
            </li>
        </ul>
    </ItemTemplate>
</asp:Repeater>

