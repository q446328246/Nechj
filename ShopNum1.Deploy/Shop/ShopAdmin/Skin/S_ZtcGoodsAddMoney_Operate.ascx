<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script src="/js/Common.js" type="text/javascript"> </script>
<script src="/JS/jquery-1.6.2.min.js" type="text/javascript"> </script>
<script>
    function funOnClickAsk() {
        var money = $("#<%= TextBoxAddMoney.ClientID %>").val();
        if (money == "") {
            alert("请输入续费金额！");
            return false;
        } else {
            var patrn = /^(-)?(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/;
            if (patrn.test(money)) {
                var MoneyShow = $("#<%= HiddenFieldMyMoney.ClientID %>").val();
                if (money <= 0) {
                    alert("续费金额必须大于零");
                    return false;
                } else {
                    if (parseFloat(MoneyShow) < money) {
                        alert("不能大于当前金币（BV）！");
                        return false;
                    } else {
                        funOpen();
                        return false;
                    }
                }
            } else {
                alert("续费金额格式错误！");
                $("#<%= TextBoxAddMoney.ClientID %>").val("");
                return false;
            }
        }
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
<div class="biaogenr">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod">
        <tr>
            <th colspan="2">
                直通车编辑
            </th>
        </tr>
        <tr>
            <td height="30" width="30%" class="bordleft">
                直通车名称：
            </td>
            <td class="bordrig">
                <asp:Label ID="LabelZtcName" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                <asp:Label ID="Label3" runat="server" Text="商品图片："></asp:Label>
            </td>
            <td class="bordrig">
                <asp:Image ID="ImageProduct" runat="server" Width="200" Height="200" onerror="javascript:this.src='/ImgUpload/noImage.gif'" /><br />
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                <asp:Label ID="Label6" runat="server" Text="直通车剩余金额："></asp:Label>
            </td>
            <td class="bordrig">
                ￥<asp:Label ID="LabelZtcMoneyShow" runat="server" Text=""></asp:Label>
                <asp:HiddenField ID="HiddenFieldMyMoney" runat="server" Value="" />
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                显示状态：
            </td>
            <td class="bordrig">
                <asp:Label ID="LabelShowState" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                续费金额：
            </td>
            <td class="bordrig">
                <asp:TextBox ID="TextBoxAddMoney" runat="server" MaxLength="30" Width="66" Text="0.00"
                    CssClass="textwb"></asp:TextBox>
                元<asp:Label ID="LabelMenberMoney" runat="server" Text="" ForeColor="Red">*</asp:Label>
            </td>
        </tr>
    </table>
    <div class="op_btn">
        <asp:Button ID="ButtonAddMoney" runat="server" Text="确认续费" CssClass="baocbtn" OnClientClick=" return funOnClickAsk() " />&nbsp;&nbsp;
        <asp:Button ID="ButtonBackList" runat="server" Text="返回列表" CssClass="baocbtn" ValidationGroup="fh" />
    </div>
</div>
<%--交易密码弹出层 start--%>
<div class="sp_dialog sp_dialog_out" style="display: none;" id="sp_dialog_outDiv">
    <!-----支付------>
    <div class="sp_dialog_cont" style="display: none;" id="sp_dialog_contDiv">
        <div class="sp_tan">
            <h4>
                金币（BV）支付</h4>
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
                    <td colspan="2" style="line-height: 36px;">
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="ButtonPay" runat="server" Text="确认支付" CssClass="sqjdbzj" OnClientClick=" return funPay() " />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<asp:HiddenField ID="HiddenFieldPay" runat="server" Value="0" />
<%--交易密码弹出层 end--%>