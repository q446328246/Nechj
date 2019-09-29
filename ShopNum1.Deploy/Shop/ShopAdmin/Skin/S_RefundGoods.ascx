<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="tjsp_mian">
    <p class="ptitle">
        <a href="javascript:void(0)">我是卖家</a> >> <a href="javascript:void(0)">
            <%= lblExit.Text %>申请</a></p>
    <div style="position: relative;">
        <div id="LogisticInfo" runat="server" style="background: #ffffff; display: none;
            left: 170px; position: absolute; top: 130px; z-index: 11;">
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
            <tr>
                <th colspan="2" scope="col">
                    处理<asp:Label ID="lblExit" runat="server" Text="退款"></asp:Label>
                </th>
            </tr>
            <tr>
                <td class="bordleft" width="130">
                    是否退款：
                </td>
                <td class="bordrig">
                    <select id="selisreceive" disabled="disabled">
                        <option value="0">确认退款</option>
                        <option value="1">已收到货</option>
                    </select>
                </td>
            </tr>
            <tr id="LogisticShowlie" style="display: none">
                <td class="bordleft" style="border-bottom: solid 1px #c6dfff;">
                    物流信息：
                </td>
                <td class="bordrig" style="border-bottom: solid 1px #c6dfff;">
                    <div id="LogisticShow">
                        鼠标移上显示物流信息</div>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    需要<%= lblExit.Text %>金额：
                </td>
                <td class="bordrig">
                    <asp:Label ID="lblExitMoney" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    <%= lblExit.Text %>原因：
                </td>
                <td class="bordrig">
                    <select id="selrefundCase" disabled="disabled">
                        <option data-tip="请选择<%= lblExit.Text %>原因" selected="true">请选择<%= lblExit.Text %>原因</option>
                        <option value="1" data-tip="申请七天无理由退换货，商城支持正品保障服务，收到商品时就存在破损问题，都可选">需要退换货 </option>
                        <option value="2" data-tip="商城支持正品保障服务，若您表示商品为假货，请提供有效凭证，并申请<%= lblExit.Text %>。">收到假货
                        </option>
                        <option value="3" data-tip="如果您需要退还运费，可申请此<%= lblExit.Text %>，并提供有效凭证或与商家协商一致。 ">退运费
                        </option>
                        <option value="4" data-tip="如您收到商品时就存在破损问题，可选择此项<%= lblExit.Text %>原因，并且需要提供有效的物流凭证。">
                            收到商品破损 </option>
                        <option value="5" data-tip="与卖家已经通过交流沟通达成一致进行<%= lblExit.Text %>。 ">协商一致<%= lblExit.Text %>
                        </option>
                        <option value="6" data-tip="如商家发错或漏发商品，可选择此项<%= lblExit.Text %>原因，且您需要提供有效的物流凭证。">商品错发/漏发
                        </option>
                        <option value="7" data-tip="如商品需要维修，可申请此<%= lblExit.Text %>，并提供有效凭证或与商家协商一致。 ">商品需要维修
                        </option>
                        <option value="8" data-tip="商城商家承诺提供发票，若商家实际未提供发票，您可以要求商家进行补寄，您也可以提供凭证申请维权。 ">发票问题
                        </option>
                        <option value="9" data-tip="收到的商品与商家或宝贝详情页面的描述存在不符的情况。">收到商品与描述不符 </option>
                        <option value="10" data-tip="若您收到的商品存在做工粗糙、商品瑕疵等质量问题时，可申请此原因<%= lblExit.Text %>。 ">商品质量问题
                        </option>
                        <option value="11" data-tip="无特殊约定，商家未在72小时内进行发货，您可以获得额外赔偿。">未按约定时间发货 </option>
                    </select><br />
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    <%= lblExit.Text %>说明：
                </td>
                <td class="bordrig">
                    <textarea id="txtIntroduce" runat="server" style="height: 100px; width: 400px;" disabled="disabled"></textarea>
                </td>
            </tr>
            <tr>
                <td class="bordleft" style="border-bottom: solid 1px #c6dfff;">
                    图片凭证：
                </td>
                <td class="bordrig" style="border-bottom: solid 1px #c6dfff;">
                    <a href='<%= showimg.Src %>' target="_blank">
                        <img src="" runat="server" id="showimg" style="height: 100px; width: 100px;" /></a>
                </td>
            </tr>
            <tr id="trSure">
                <td class="bordleft" style="border-bottom: solid 1px #c6dfff;">
                    是否同意<%= lblExit.Text %>：
                </td>
                <td class="bordrig" style="border-bottom: solid 1px #c6dfff;">
                    <input type="radio" name="checksure" value="1" checked="checked" />同意
                    <input type="radio" name="checksure" value="0" />不同意
                </td>
            </tr>
            <tr>
                <td class="bordleft" style="border-bottom: solid 1px #c6dfff;">
                    是否同意理由：
                </td>
                <td class="bordrig" style="border-bottom: solid 1px #c6dfff;">
                    <textarea id="txtReason" runat="server" style="height: 100px; width: 400px;"></textarea>
                </td>
            </tr>
        </table>
        <div style="margin: 20px 0px 50px 0px; text-align: center;">
            <asp:Button ID="btnSubmit" runat="server" Text="确定" CssClass="baocbtn" OnClientClick=" return checksub() " />
            <input type="button" class="baocbtn" value="返回" onclick=" window.location.href = 'S_Order_List.aspx'; " />
        </div>
    </div>
</div>
<input type="hidden" id="hidIsReceive" runat="server" value="1" />
<input type="hidden" id="hidProductGuID" runat="server" value="" />
<input type="hidden" id="hidRefundReason" runat="server" value="" />
<input type="hidden" id="hidOrderNumber" runat="server" value="" />
<input type="hidden" id="hidcategory" runat="server" value="" />
<input type="hidden" id="hidSureState" runat="server" />
<input type="hidden" id="hidShouldPayprice" runat="server" />
<input type="hidden" id="hidPaymentmemLoginid" runat="server" />
<input type="hidden" id="hidAdvancePayment" runat="server" />
<input type="hidden" id="hidShopPayment" runat="server" />
<input type="hidden" id="hidPayMentName" runat="server" />
<input type="hidden" id="hidShopId" runat="server" />
<input type="hidden" id="hidMemloginId" runat="server" />
<input type="hidden" id="hidRefundStatus" runat="server" />
<script type="text/javascript" language="javascript">
    $(function () {
        var refundstatus = $("#S_RefundGoods_ctl00_hidRefundStatus").val();
        if (refundstatus == "1") {
            $("#trSure").hide();
            $("#S_RefundGoods_ctl00_btnSubmit").hide();
        }
        $("#selrefundCase").change(function () { $("#datatip").text($(this).find("option:selected").attr("data-tip")); });
        if ($("#S_RefundGoods_ctl00_hidRefundReason").val() != "") {
            $("#datatip").hide();
            $("#selrefundCase option:eq(" + $("#S_RefundGoods_ctl00_hidRefundReason").val() + ")").attr('selected', 'selected');
        }
        if ($("#S_RefundGoods_ctl00_hidIsReceive").val() != "") {
            $("#selisreceive").find("option[value='" + $("#S_RefundGoods_ctl00_hidIsReceive").val() + "']").attr('selected', 'selected');
        }

        if ($("#selisreceive").val() == 1) {
            $("#LogisticShowlie").show();
        }
        $("#LogisticShow").hover(function () { $("#S_RefundGoods_ctl00_LogisticInfo").show(); }, function () {
        });
        $("#S_RefundGoods_ctl00_LogisticInfo").hover(function () {
        }, function () { $("#S_RefundGoods_ctl00_LogisticInfo").hide(); });

    });

    function checksub() {
        $("input[name='checksure']").each(function () {
            if ($(this).attr("checked")) {
                $("#S_RefundGoods_ctl00_hidSureState").val($(this).val());
            }
        });
        return true;
    }
</script>
