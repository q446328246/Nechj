<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<!--开启闭合-->
<script type="text/javascript">
    $(function () {

        $(".att_more").toggle(
        function () {
            $(this).prev().addClass("open"); //展开
            $(this).addClass("open"); //箭头变化
            $(this).children("a").html("收起<b class=\"bshang\"></b>");
        },
        function () {
            $(this).removeClass("open");
            $(this).children("a").html("更多<b class=\"bxia\"></b>");
            $(this).prev().removeClass("open"); //展开
        }
    );
        $(".ser_dash:last").css("border-bottom", 'none');
    })
</script>
<!--分隔BrandPropBorder-->
<div class="ser_box">
    <div class="ser_brand ser_dash clearfix" id="BrandBorder" runat="server">
        <div class="att_key">
            品牌</div>
        <div class="att_values">
            <ul class="att_ul">
                <asp:Repeater ID="RepeaterPtoudctBrand" runat="server">
                    <ItemTemplate>
                        <li><a href='<%# ShopUrlOperate.RetMultiUrl("Search_productlist",((DataRowView)Container.DataItem).Row["linkurl"])%>'>
                            <span id="SpanBrand" runat="server">
                                <%#ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Name"].ToString(),18,"") %></span></a></li>
                        </a>
                        <asp:HiddenField ID="HiddenFieldGuid" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["Guid"] %>'>
                        </asp:HiddenField>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div class="att_more">
                <a>更多<i></i></a></div>
        </div>
    </div>
    <div class="ser_cate clearfix" id="PropBorder" runat="server">
        <asp:Repeater ID="RepeaterShopProductProp" runat="server">
            <ItemTemplate>
                <asp:HiddenField ID="HiddenFieldPropID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
                <div class="ser_dash">
                    <div class="fenlei">
                        <%#ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["PropName"].ToString(),18,"") %></div>
                    <div class="att_values">
                        <ul class="att_ul">
                            <asp:Repeater ID="RepeaterShopProductPropValue" runat="server">
                                <ItemTemplate>
                                    <li><a title='<%# ((DataRowView)Container.DataItem).Row["Name"] %>' href='<%# ShopUrlOperate.RetMultiUrl("Search_productlist",((DataRowView)Container.DataItem).Row["linkurl"])%>'>
                                        <span id="SpanPropValue" runat="server">
                                            <%#ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Name"].ToString(),18,"") %></span></a></li>
                                    <asp:HiddenField ID="HiddenFieldPropValueID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                        <div class="att_more">
                            <a>更多<b></b></a></div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
