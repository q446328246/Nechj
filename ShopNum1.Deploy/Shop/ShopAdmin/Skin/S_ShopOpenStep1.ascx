<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script>
    function funSelect(val, rguid) {
        if (val != "0") {
            if (confirm("本次开店需要支付金币（BV）" + val + "元，是否继续开店！")) {
                //判断金币（BV）
                $.ajax({
                    type: "get",
                    url: "/Api/ShopAdmin/S_AdminOpt.ashx",
                    async: false,
                    data: "type=AdvancePayment",
                    dataType: "html",
                    success: function (ajaxData) {
                        if (ajaxData != "") {
                            if (parseFloat(ajaxData) > parseFloat(val)) {
                                window.location = "S_ShopOpenStep2.aspx?type=" + rguid;
                            } else {
                                alert("抱歉，金币（BV）不足，请即时充值！");
                            }
                        }
                    }
                });
            }
        } else {
            window.location = "S_ShopOpenStep2.aspx?type=" + rguid;
        }
    }
</script>
<div class="dpsc_mian" style="width: 998px;">
    <div class="maijtitle">
    </div>
    <asp:Repeater ID="RepeaterShow" runat="server">
        <ItemTemplate>
            <table border="0" cellspacing="0" cellpadding="0" class="buzlb">
                <tr>
                    <td rowspan="4" style="color: #F60; font-weight: bold; width: 130px;">
                        <%#Eval("Name") %>
                    </td>
                    <td style="width: 160px;">
                        商品数：<%#Eval("MaxProductCount") %>
                    </td>
                    <td rowspan="4">
                        附加功能：<a href='S_ShopRankDetailed.aspx?type=open&guid=<%#Eval("Guid") %>' style="color: blue">查看等级详细</a>
                    </td>
                    <td rowspan="4">
                        用户选择“默认等级”，可以立即开通
                    </td>
                    <td rowspan="4" align="center">
                        <%--<input name="12" type="button" class="sqjdbzj" value="立即开店" onclick="javascript:location.href='S_ShopOpenStep2.aspx?type=<%#Eval("Guid")%>'"/> --%>
                        <input name="12" type="button" class="sqjdbzj" value="立即开店" onclick=' funSelect(<%#Eval("price") %>, "<%#Eval("Guid") %>") ' />
                    </td>
                </tr>
                <tr>
                    <td>
                        模板数：<asp:Label ID="LabelShopTemplateCount" runat="server" Text='<%#Eval("shopTemplate") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        收费标准：<%#Eval("price").ToString() == "0.00" ? "免费" : Eval("price") + "元/年" %>
                    </td>
                </tr>
                <tr>
                    <td>
                        需要审核： 是
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
    <div class="maijtitle1">
        <input name="12" type="button" class="sqjdbzj" value="返回" onclick=" javascript:location.href = 'S_WelcomeOpenShop.aspx'; " />
    </div>
</div>
