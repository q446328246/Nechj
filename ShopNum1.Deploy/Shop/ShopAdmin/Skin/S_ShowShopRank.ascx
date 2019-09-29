<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script>
    function funOnClickAsk(o, val) {
        window.parent.scrollTo(0, 0);
        var guid = $(o).attr("title");
        $("#titleDiv").html(val);
        $("#<%= HiddenFieldRankGuid.ClientID %>").val(guid);
        $("#<%= HiddenFieldPayType.ClientID %>").val(val);
        funOpen();
        return false;
    }
</script>
<script>
    function funPay() {
        $("#errPwd").html("查询中...");
        funCheckPayPwd();
        if ($("#<%= HiddenFieldPay.ClientID %>").val() == "1") {
            $("#errPwd").css("color", "green");
            $("#errPwd").html("交易密码正确！");
            return true;
        }
        $("#errPwd").html("交易密码错误！");
        return false;
    }

    //检查交易密码是否正确

    function funCheckPayPwd() {
        var payPwd = $("#<%= TextBoxPayPassWord.ClientID %>").val();
        $.ajax({
            type: "get",
            url: "/Api/ShopAdmin/S_AdminOpt.ashx",
            async: false,
            data: "type=paypwd&payPwd=" + payPwd,
            dataType: "html",
            success: function (ajaxData) {
                if (ajaxData != "") {

                    if (ajaxData == "false") {
                        $("#<%= HiddenFieldPay.ClientID %>").val("0");
                        return true;
                    } else if (ajaxData == "true") {
                        $("#<%= HiddenFieldPay.ClientID %>").val("1");
                        return false;
                    }
                }
            }
        });
    }

</script>
<div class="dpsc_mian1">
    <p class="ptitle">
        <a href="#">我是卖家</a> >> <a href="S_ShopInfo.aspx">店铺管理</a> >>店铺等级列表</p>
    <asp:Repeater ID="RepeaterShow" runat="server">
        <ItemTemplate>
            <table border="0" cellspacing="0" cellpadding="0" class="buzlb">
                <tr>
                    <td rowspan="4" style="font-weight: bold; line-height: 20px; width: 100px;" runat="server"
                        id="TdName">
                        <%#Eval("Name") %>
                    </td>
                    <td style="width: 200px;">
                        商品数：<%#Eval("MaxProductCount") %>
                    </td>
                    <td rowspan="4">
                        附加功能：<a href='S_ShopRankDetailed.aspx?guid=<%#Eval("Guid") %>'>“点击”即可了解更多功能。</a>
                    </td>
                    <td rowspan="4" style="line-height: 20px;">
                    </td>
                    <td rowspan="4" align="center">
                        <asp:HiddenField ID="HiddenFieldGuid" runat="server" Value='<%#Eval("Guid") %>' />
                        <asp:HiddenField ID="HiddenFieldName" runat="server" Value='<%#Eval("Name") %>' />
                        <asp:HiddenField ID="HiddenFieldIsDefault" runat="server" Value='<%#Eval("IsDefault") %>' />
                        <asp:HiddenField ID="HiddenFieldPrice" runat="server" Value='<%#Eval("price") %>' />
                        <asp:Button ID="runbutton" runat="server" Text="立即升级" ToolTip='<%#Eval("Guid") %>'
                            CssClass="sqjdbzj" OnClientClick=' return funOnClickAsk(this, "升级") ' />
                        <asp:Button ID="ButtonPayGoOn" runat="server" Text="续费" ToolTip='<%#Eval("Guid") %>'
                            CssClass="sqjdbzj" OnClientClick=' return funOnClickAsk(this, "续费") ' Visible="false" />
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
                        是否需要审核：否
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
    <script type="text/javascript">
            <!--
        //var TabbedPanels1 = new Spry.Widget.TabbedPanels("list_main");
    //-->
    </script>
</div>
<%--交易密码弹出层 start--%>
<div class="sp_dialog sp_dialog_out" style="display: none;" id="sp_dialog_outDiv">
    <!-----支付------>
    <div class="sp_dialog_cont" style="display: none;" id="sp_dialog_contDiv">
        <div class="sp_tan">
            <h4>
                [<span id="titleDiv"></span>]金币（BV）支付</h4>
            <div class="sp_close">
                <a href="javascript:void(0)" onclick=" funClose() "></a>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="sp_tan_content">
            <table>
                <tr>
                    <td colspan="2" style="line-height: 36px;">
                        <div>
                            <asp:Label ID="LabelYue" runat="server" Text="您当前的金币（BV）余额为：￥0.00"></asp:Label></div>
                        <div>
                            <asp:Label ID="LabelIsHavePayPwd" runat="server" Text="您当前没有设置交易密码，请点击" Visible="false"></asp:Label>
                            <a id="paypwdalink" href='/main/account/A_Index.aspx?tomurl=A_PwdSer.aspx' style="color: red"
                                visible="false" target="_parent" runat="server">设置交易密码</a>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        交易密码：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxPayPassWord" runat="server" TextMode="Password" CssClass="textwb"></asp:TextBox>
                        <span style="color: red" id="errPwd"></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                    
                    </td>
                    <td>
                        <asp:Button ID="ButtonPay" runat="server" Text="确认支付" CssClass="sqjdbzj" OnClientClick=" return funPay() " />
                        <asp:Label ID="lblNotifacate" runat="server" Text="尚未设置交易密码，不能支付" Visible="false" style="color: red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>

<%--交易密码弹出层 end--%>
<asp:HiddenField ID="HiddenFieldPay" runat="server" Value="0" />
<asp:HiddenField ID="HiddenFieldRankGuid" runat="server" Value="" />
<asp:HiddenField ID="HiddenFieldPayType" runat="server" Value="" />
