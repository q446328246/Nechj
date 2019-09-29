<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="pad">
    <table id="Table1" width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao">
        <tr>
            <td class="tab_r" width="200">
                担保名称：
            </td>
            <td>
                <asp:Label ID="lab_EnsureName" runat="server" Text="消费者保障服务名称"></asp:Label>
                <span class="gray1">&nbsp;</span>
            </td>
        </tr>
        <tr>
            <td class="tab_r">
                支付方式：
            </td>
            <td>
                <select id="sel_PayMent"  runat="server" class="tselect">
                    <option>金币（BV）支付</option>
                </select>
                <input id="hid_payValue" type="hidden"  runat="server"  />
                <input id="hid_payText" type="hidden"  runat="server"  />
                <span class="gray1">&nbsp;</span><input name="12" type="button" class="chax" value="充值" onclick=" funGoPay() "/>
            </td>
        </tr>
        <tr>
            <td class="tab_r">
                当前金币（BV）：
            </td>
            <td>
                <input type="text" class="textwb" id="txt_AdvPayMent" runat="server"  readonly="readonly"    style="width: 200px" />￥
                <span class="gray1">&nbsp;</span>
            </td>
        </tr>
        <tr>
            <td class="tab_r">
                支付金额：
            </td>
            <td>
                <input type="text" class="textwb" id="txt_EnsureMoney" runat="server"  readonly="readonly"  style="width: 200px" />￥
                <a  style="color: Red" href="/main/account/A_AdPayRecharge.aspx" id="GoPayMoney">支付金额不足，马上去充值吧！</a>
            </td>
        </tr>
        <tr>
            <td class="tab_r">
                交易密码：
            </td>
            <td>
                <input type="password" class="textwb" id="txt_PayPwd" runat="server"   style="width: 200px" onblur="funCheckPayPwd()" />
                <span id="errPwd" style="color: Red">*</span>
                &nbsp;&nbsp;<a  style="color: Red"  href="/main/account/A_ChangePwdWay.aspx" runat="server" id="GoPayPwd">交易密码未设置，马上去设置吧！</a>
            </td>
        </tr>
        <tr style="display: none;">
            <td class="tab_r">
                备注：
            </td>
            <td>
                <input type="text" class="textwb" id="txt_Remark" runat="server" />
                <span class="gray1">&nbsp;</span>
            </td>
        </tr>
        <tr>
            <td class="tab_r">
                &nbsp;
            </td>
            <td style="padding: 10px 0px 10px 0px;">
                <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="querbtn" OnClientClick=" return funCheckButton() "/>
                <asp:Button ID="btn_Back" runat="server" Text="返回" CssClass="querbtn" />
            </td>
        </tr>
    </table>
</div>
<script>
    function funGoPay() {
        this.form1.target = '_parent';
        window.location.href = "/main/account/A_AdPayRecharge.aspx";
    }
</script>
<asp:HiddenField ID="HiddenFieldPay" runat="server"  Value="0"/>
<script type="text/javascript" language="javascript" >
    $(function() {
        var myMoney = $("#S_EnsureApplyRecordOperate_ctl00_txt_AdvPayMent").val();
        var payPwd = $("#S_EnsureApplyRecordOperate_ctl00_txt_EnsureMoney").val();
        if (parseFloat(payPwd) > parseFloat(myMoney)) {
            $("#GoPayMoney").show();
            $("#S_EnsureApplyRecordOperate_ctl00_btn_Sumbit").hide();
        } else {
            $("#GoPayMoney").hide();
        }
    });

    function funCheckPayPwd() {
        var payPwd = $("#<%= txt_PayPwd.ClientID %>").val();
        if (payPwd != "") {
            $.ajax({
                type: "get",
                url: "/Api/ShopAdmin/S_AdminOpt.ashx",
                async: false,
                data: "type=paypwd&payPwd=" + payPwd,
                dataType: "html",
                success: function(ajaxData) {
                    if (ajaxData != "") {

                        if (ajaxData == "false") {
                            $("#<%= HiddenFieldPay.ClientID %>").val("0");
                            $("#errPwd").html("交易密码输入错误！");
                            return true;
                        } else if (ajaxData == "true") {
                            $("#errPwd").html("*");
                            $("#<%= HiddenFieldPay.ClientID %>").val("1");
                            return false;
                        }
                    }
                }
            });
        } else {
            $("#<%= HiddenFieldPay.ClientID %>").val("0");
            $("#errPwd").html("交易密码不能为空！");
        }
    }

    function funCheckButton() {
        funCheckPayPwd();
        if ($("#<%= HiddenFieldPay.ClientID %>").val() == "1") {
            return true;
        }
        return false;
    }

</script>