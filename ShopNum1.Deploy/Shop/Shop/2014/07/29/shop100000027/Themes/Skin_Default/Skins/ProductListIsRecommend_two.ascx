<%@ Control Language="C#" EnableViewState="true" %>

<%@ Import Namespace="ShopNum1.Common" %>
<script runat="server">

</script>
<script type="text/javascript">

    function buyProduct4(guid, pid, client) {

        $.ajax({
       
            url: '/Api/Shop/ShopProduct.ashx',
            contentType: "application/x-www-form-urlencoded; charset=utf-8",
            data: "guid=" + guid + "&productid=" + pid + "&buynum=" + $('#' + client + "_TextBoxBuyNum2").val() + "&color=" + encodeURI($('#' + client + "_ddlColordd").val(),"UTF-8") + "&size=" + encodeURI($('#' + client + "_ddlSizedd").val(),"UTF-8") + "&type=" + "7",
            success: function (result) {
                if (result == 1) {

                    var mydiv = document.getElementById("div_my_one3");
                    mydiv.style.display = "block"
                    var c = document.body.scrollTop;
                    var cc = c + 400;
                    mydiv.style.top = cc + "px";
                    mydiv.style.position = "absolute";
                    mydiv.style.left = "77%";
                    $("#div_my_one3").hide(2500);
                }
                 else if (result =="0" ) {
                alert("购买失败了！");
                }
                else {
                    alert(result);
                }
            }
        }


        );
        return false;
    }
</script>


<div class="bBoxnt">
    <h2>
        <span>社区店专区</span>
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
                                <asp:DropDownList ID="ddlColordd" runat="server" Style="width: 50px;" >
                                </asp:DropDownList>
                                <!--<br/>-->
                            </div>
                        </td>
                        <td>
                            <div class="qudai_color">
                                &nbsp;尺寸：
                                <asp:DropDownList ID="ddlSizedd" runat="server" Style="width: 40px;" >
                                </asp:DropDownList>
                                <!--<br/>-->
                            </div>
                        </td>
                        <td>
                            <p>
                                &nbsp;购买数量：
                                <asp:TextBox ID="TextBoxBuyNum2" runat="server" Text="1" Style="width: 30px;" />
                            </p>
                        </td>
                        <td  align="right">
                            <asp:Button ID="btnBuyProduct4" runat="server" CommandName="buy" Style="font-size: 21px;background: url(Themes/Skin_Default/Images/pb_buts.png) no-repeat;"
                               Width="87px" Height="30px" BorderStyle="None"></asp:Button>
                            <br />
                        </td>
                    </tr>
                </table>

               <HR SIZE="1">
            </ItemTemplate>
        </asp:Repeater>
      <%-- <webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageSize="10" HorizontalAlign="Center" Width="100%" meta:resourceKey="AspNetPager1" Style="font-size: 14px" AlwaysShow="false" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" SubmitButtonText="Go" SubmitButtonClass="submitBtn" CustomInfoStyle="font-size:14px;text-align:left;" InputBoxStyle="width:25px; border:1px solid #999999; text-align:center; " TextBeforeInputBox="转到第" TextAfterInputBox="页 " PageIndexBoxType="TextBox" ShowPageIndexBox="Always" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" Font-Size="14px" CustomInfoHTML="共<font color='#ff0000'>%PageCount%</font>页，第<font color='#ff0000'>%CurrentPageIndex%</font>页" ShowCustomInfoSection="Left" CustomInfoSectionWidth="19%" PagingButtonSpacing="3px" > 
</webdiyer:AspNetPager> --%>


    </div>
    <div id="div_my_one3" style="display: none; width: 150px; height: 40px; background-color: Red;">
        <h1>
            添加成功，已加入购物车</h1>
    </div>
</div>
