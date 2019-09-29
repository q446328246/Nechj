<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data " %>
<input type="hidden" id="hidCategroyCode" value="<%=Request.QueryString["guid"]%>" />
<script type="text/javascript">
    $(function () {
        if ($("#hidCategroyCode").val() != "-1" && $("#hidCategroyCode").val() != "") {
            $("#allCategory").removeClass("curr");
            $("#select" + $("#hidCategroyCode").val()).addClass("curr");
        }

        if ($(".group_de_ever").length <= 0) {
            $("#NoMessage").show();
        }
    });
</script>
<div class="group">
    <div class="tuanimg">
        <ShopNum1:AdSimpleImage ID="AdSimpleImage15" runat="server" AdImgId="15" SkinFilename="AdSimpleImage.ascx" />
    </div>
    <div class="group_top">
        <div class="fl">
            <span class="groupKey">商品分类：</span>
        </div>
        <div class="fr">
            <a class="curr" href='<%=ShopUrlOperate.RetUrl("SpellBuyList","-1") %>' id="allCategory">
                全部</a>
            <asp:Repeater ID="RepeaterCategory" runat="server">
                <ItemTemplate>
                    <a href='<%#ShopUrlOperate.RetUrl("SpellBuyList",Eval("Code")) %>' id='select<%#Eval("Code")%>'>
                        <%#Eval("Name").ToString() %></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="group_paixu">
        <div class="paixu">
            排序：
            <asp:LinkButton ID="LinkButtonDefault" runat="server" class="">默认</asp:LinkButton>
            <asp:LinkButton ID="LinkButtonNew" runat="server">
                最新<span id="SpanNew" runat="server" class="new"></span></asp:LinkButton>
            <asp:LinkButton ID="LinkButtonSales" runat="server">
                销量<span id="SpanSales" runat="server" class="new"></span></asp:LinkButton>
            <asp:LinkButton ID="LinkButtonPrice" runat="server">
                价格<span id="SpanPrice" runat="server" class="price"></span></asp:LinkButton>
        </div>
        <!--分页 Start-->
        <div class="pagenet" style="height: 55px; line-height: 55px;">
            <div id="pageDiv" runat="server" class="page_sort">
            </div>
        </div>
        <!--//分页 End-->
        <div class="pagenet" style="display: none;">
            <%-- 1/5--%>
            <span>
                <%=Request.QueryString["pageid"] == null ? "1" : Request.QueryString["pageid"].ToString()%></span>
            <span>/</span> <span>
                <asp:Label ID="LabelPageCount1" runat="server" Text=""></asp:Label></span> <a class="pgup">
                    <asp:LinkButton ID="linBtnPrev" runat="server"></asp:LinkButton></a> <a class="pgup">
                        上一页</a>
        </div>
    </div>
    <div class="group_content clearfix">
        <script type="text/javascript" language="javascript">
            $(function () {
                $("input[name='tgend']").each(function () {
                    if (parseInt($(this).val()) == 1) {
                        $(this).next().find(".tg_end").show();
                    }
                });
            });
        </script>
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <input type="hidden" value='<%#Eval("tgstate")%>' name="tgend" />
                <div class="group_de_ever">
                    <div class="tg_end" style="display: none;">
                        <img width="125" height="72" src="/Main/Themes/Skin_Default/images/tg_end.png" alt=""></div>
                    <div class="group_de_title">
                        <span>【<a href='<%#ShopUrlOperate.GetShopUrl(Eval("ShopID").ToString()) %>' target="_blank"><%#Eval("ShopName")%></a>】</span>
                        <a href='<%#ShopUrlOperate.shopDetailHrefByShopID(Eval("id").ToString(),Eval("ShopID").ToString(),"ProductIsSpell_Detail") %>'
                            target="_blank">
                            <%# ShopNum1.Common.Utils.GetUnicodeSubString(Eval("Name").ToString(),80,"...")%></a>
                    </div>
                    <div class="group_de_img">
                        <div class="font01">
                        </div>
                        <div class="font02">
                            <div class="MarketPrice">
                                原价：<span><%#Eval("ShopPrice")%>元</span>
                            </div>
                            <div class="BuyNum">
                                <span>
                                    <%#Eval("groupcount")%></span>人已购买
                            </div>
                        </div>
                        <a href='<%#ShopUrlOperate.shopDetailHrefByShopID(Eval("Id").ToString(),Eval("ShopID").ToString(),"ProductIsSpell_Detail") %>'
                            target="_blank">
                            <img alt="" width="260" height="200" src='<%# Page.ResolveUrl(Eval("groupimg").ToString())+"_300x300.jpg" %>' /></a>
                    </div>
                    <a href='<%#ShopUrlOperate.shopDetailHrefByShopID(Eval("id").ToString(),Eval("ShopID").ToString(),"ProductIsSpell_Detail") %>'
                        target="_blank">
                        <div class="group_de_pirce">
                            <span class="emyuan">&yen;</span> <span class="emyuan">
                                <%#Eval("GroupPrice")%></span>
                        </div>
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div id="NoMessage" class="nofind_tuan" style="display: none">
            <div class="nofind">
                <div class="nohead">
                    <span class="nopic"></span>没有查询到符合条件的团购商品！</div>
            </div>
        </div>
    </div>
    <!--分页 Start-->
    <div class="fenye">
        <!--分页跳转 Start-->
        <div class="page_skip" style="display: none;">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        <span class="fenye1">共</span>
                    </td>
                    <td>
                        <span>
                            <asp:Label ID="LabelPageCount" runat="server" Text=""></asp:Label></span>
                    </td>
                    <td>
                        <span class="fenye2">页，到第</span>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxIndex" runat="server" CssClass="page_input">
                        </asp:TextBox>
                    </td>
                    <td>
                        <span class="fenye3">页</span>
                    </td>
                    <td>
                        <asp:Button ID="ButtonSure" runat="server" Text="确定" CssClass="page_btn" />
                    </td>
                </tr>
            </table>
        </div>
        <!--//分页跳转 End-->
        <!--分页排序 Start-->
        <div id="pageDiv2" runat="server" class="page_sort">
        </div>
        <!--//分页排序 End-->
        <div class="clear">
        </div>
    </div>
    <!--//分页 End-->
</div>
