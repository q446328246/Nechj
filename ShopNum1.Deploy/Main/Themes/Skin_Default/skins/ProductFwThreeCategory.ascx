<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $(".more_drop_l").click(function () {
            if ($(this).parent().prev().attr("class") == "atrCint")//此时是展开的
            {
                $(this).parent().prev().attr("class", "atrCint_drop");
                $(this).children("i").css("background-position", "0px 0px");
                $(this).children("div").html("更多");
                $(this).parent().parent().parent().css("background", "");
                return;
            }
            else//此时是收起的
            {
                //其他都收起
                $(".atrCint").attr("class", "atrCint_drop");
                $(".more_drop_allow").css("background-position", "0px -7px");
                $(".wenzi1").html("更多");
                $(".FlowCategory_item").css("background", "");
                //自己展开
                $(this).parent().prev().attr("class", "atrCint");
                $(this).children("i").css("background-position", "0px 0px");
                $(this).children("div").html("收起");
                $(this).parent().parent().parent().css("background", "#837574");
            }
        });
    });
</script>
<!--三级分类-->
<div class="tsCategory_con">
    <asp:Repeater ID="RepeaterCategoryOne" runat="server">
        <ItemTemplate>
            <!--二级 和 三级 鲜花-->
            <div id="content1" class="FlowCategory_item">
                <div class="attrKey">
                    <a href='<%#ShopUrlOperate.RetShopUrl("Search_productlist",((DataRowView)Container.DataItem).Row["Code"].ToString(),"Code")%>'
                        target="_self">
                        <%# Eval("Name")%></a>
                </div>
                <asp:HiddenField ID="HiddenFieldCategory1" runat="server" Value='<%# Eval("ID")%>' />
                <div class="attrValues">
                    <div class="atrCint_drop" id="ShouHe1">
                        <asp:Repeater ID="RepeaterCategory2" runat="server">
                            <ItemTemplate>
                                <!--二级 鲜花-->
                                <ul class="av_collapse">
                                    <li id="Div1">
                                        <div class="entity">
                                            <ul class="items">
                                                <li class="arit_bcategory">
                                                    <asp:HiddenField ID="HiddenFieldCategory2" runat="server" Value='<%# Eval("ID")%>' />
                                                    <asp:HiddenField ID="HiddenFieldCheck" runat="server" Value='1' />
                                                    <a href='<%#ShopUrlOperate.RetShopUrl("Search_productlist",((DataRowView)Container.DataItem).Row["Code"].ToString(),"Code")%>'>
                                                        <%# Eval("Name")%></a> </li>
                                                <li class="cagethree">
                                                    <asp:Repeater ID="RepeaterCategory3" runat="server">
                                                        <ItemTemplate>
                                                            <a href='<%#ShopUrlOperate.RetShopUrl("Search_productlist",((DataRowView)Container.DataItem).Row["Code"].ToString(),"Code")%>'>
                                                                <%# Eval("Name")%></a>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </li>
                                            </ul>
                                        </div>
                                    </li>
                                    <!--三级-->
                                </ul>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="av_options">
                        <a class="more_drop_l" id="shouqi1">
                            <div id="wenzi1" class="wenzi1">
                                更多</div>
                            <i id="Qiantou1" class="more_drop_allow"></i></a>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<!--[if lte IE 6]>
<div class="iframebox"><iframe frameborder="0" style=" background-color:#FFCC33;filter:alpha(opacity=0);-moz-opacity:0;" height="1000px"   width="1000px"></iframe></div>
<![endif]-->
