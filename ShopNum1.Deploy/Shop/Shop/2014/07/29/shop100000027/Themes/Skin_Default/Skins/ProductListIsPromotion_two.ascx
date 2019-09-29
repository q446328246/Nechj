<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.Common" %>
<script type="text/javascript">

    function buyProduct3(guid, pid, client) {

        $.ajax({
          
            url: '/Api/Shop/ShopProduct.ashx',
            contentType: "application/x-www-form-urlencoded; charset=utf-8",
            data: "guid=" + guid + "&productid=" + pid + "&buynum=" + $('#' + client + "_TextBoxBuyNum_two").val() + "&color=" + encodeURI($('#' + client + "_ddlColorff").val(),"UTF-8") + "&size=" + encodeURI($('#' + client + "_ddlSizeff").val(),"UTF-8") + "&type=" + "6",
            success: function (result) {
                if (result == 1) {

                    var mydiv = document.getElementById("div_my_one2");
                    mydiv.style.display = "block"
                    var c = document.body.scrollTop;
                    var cc = c + 400;
                    mydiv.style.top = cc + "px";
                    mydiv.style.position = "absolute";
                    mydiv.style.left = "77%";
                    $("#div_my_one2").hide(2500);
                }
                else if (result == "0") {
                    alert("购买失败了！");
                }
                else {
                    alert(result);
                }

            }
        });
        return false;
    }
</script>


<div class="bBoxnt">
    <h2>
        <span>社区店首次购物专区</span>
    </h2>
    <div class="content clearfix">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                               <table style="width: 100%;">
                    <tr>
                        <td style="width: 45%;">
                            <div class="qudai_gouwu">
                                <a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>?category=<%#Eval("shop_category_id")%>'
                                    target="_blank" title='<%# Eval("Name")%>'>
                                    <%# Utils.GetUnicodeSubString(Eval("Name").ToString(),40,"") %>
                                </a>
                                <asp:Literal ID="LiteralProductName" runat="server" Visible="false" Text='<%# Eval("Name").ToString() %>'></asp:Literal>
                            </div>
                        </td>
                        <td style="width: 20%;">
                            <div class="qudai_gouwu_m">
                                <strong>¥<asp:Literal ID="LiteralGroupPrice" runat="server" Text='<%# Eval("ShopPrice")%>'></asp:Literal>元</strong></div>
                        </td>
                        <td>
                            <div class="qudai_kuc">
                                库存：<asp:Label ID="LabelRepertoryCount" runat="server" Text='<%# Eval("RepertoryCount")%>'></asp:Label>件</div>
                        </td>
                        <td style="width: 20%;">
                            <asp:Literal ID="LiteralProductGuid" runat="server" Text='<%# Eval("guid")%>' Visible="false"></asp:Literal>
                            <asp:Literal ID="LiteralShopName" runat="server" Text='<%# Eval("ShopName")%>' Visible="false"></asp:Literal>
                            <asp:Literal ID="LiteralMemLoginID" runat="server" Text='<%# Eval("MemLoginID")%>'
                                Visible="false"></asp:Literal>
                            <asp:Literal ID="LiteralProductId" runat="server" Text='<%# Eval("productId")%>'
                                Visible="false"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="qudai_color">
                                &nbsp;颜色：
                                <asp:DropDownList ID="ddlColorff" runat="server" Style="width: 50px;">
                                </asp:DropDownList>
                                <!--<br/>-->
                            </div>
                        </td>
                        <td>
                            <div class="qudai_color">
                                &nbsp;尺寸：
                                <asp:DropDownList ID="ddlSizeff" runat="server" Style="width: 40px;">
                                </asp:DropDownList>
                                <!--<br/>-->
                            </div>
                        </td>
                        <td>
                            <p>
                                &nbsp;购买数量：
                                <asp:TextBox ID="TextBoxBuyNum_two" runat="server" Text="1" Style="width: 30px;" />
                            </p>
                        </td>
                        <td  align="right">
                            <asp:Button ID="btnBuyProduct3" runat="server" CommandName="buy" Style="font-size: 21px;background: url(Themes/Skin_Default/Images/pb_buts.png) no-repeat;"
                               Width="87px" Height="30px" BorderStyle="None"></asp:Button>
                            <br />
                        </td>
                    </tr>
                </table>

                <HR style=" size="1"; " >
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div id="div_my_one2" style="display: none; width: 150px; height: 40px; background-color: Red;">
        <h1>
            添加成功，已加入购物车</h1>
    </div>
</div>
