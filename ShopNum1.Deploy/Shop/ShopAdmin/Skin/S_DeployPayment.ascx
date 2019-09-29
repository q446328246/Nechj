<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script>
    //判断支付方式名称
    function funTextBoxName() {
        var TextBoxName = $("#<%= TextBoxName.ClientID %>").val();
        if (TextBoxName == "") {
            $("#errTextBoxName").html("支付方式名称不能为空！");
            return false;
        }
        $("#errTextBoxName").html("*");
        return true;
    }

    //收款支付宝账号
    function funTextBoxAlipay() {
        var TextBoxAlipay = $("#<%= TextBoxAlipay.ClientID %>").val();
        if (TextBoxAlipay == "") {
            $("#errTextBoxAlipay").html("收款支付宝账号不能为空！");
            return false;
        }
        $("#errTextBoxAlipay").html("*");
        return true;
    }

    //商户号
    function funTextBoxMerchantCode() {
        var TextBoxMerchantCode = $("#<%= TextBoxMerchantCode.ClientID %>").val();
        if (TextBoxMerchantCode == "") {
            var type = $("#<%= HiddenFieldType.ClientID %>").val(); //支付方式类型
            if (type == "Alipay3.aspx" || type == "Alipay.aspx" || type == "Alipay2.aspx") {
                $("#errTextBoxMerchantCode").html("合作者身份不能为空！");
            } else {
                $("#errTextBoxMerchantCode").html("商户号不能为空！");
            }

            return false;
        }
        $("#errTextBoxMerchantCode").html("*");
        return true;
    }

    //商户密钥
    function funTextBoxSecretKey() {
        var TextBoxSecretKey = $("#<%= TextBoxSecretKey.ClientID %>").val();
        if (TextBoxSecretKey == "" || TextBoxSecretKey == null) {
            var type = $("#<%= HiddenFieldType.ClientID %>").val(); //支付方式类型
            if (type == "Alipay3.aspx" || type == "Alipay.aspx" || type == "Alipay2.aspx") {
                $("#errTextBoxSecretKey").html("安全校验码不能为空！");
            } else {
                $("#errTextBoxSecretKey").html("商户密钥不能为空！");
            }
            return false;
        }
        $("#errTextBoxSecretKey").html("*");
        return true;
    }

    function funButton() {
        var DeployPay = $("#S_DeployPayment_ctl00_TextBoxCharge").val();
        if (parseFloat(DeployPay) < 0) {
            alert("手续费必须大于等于0");
            return false;
        }

        var type = $("#<%= HiddenFieldType.ClientID %>").val(); //支付方式类型
        //        alert(type);
        if (type == "BankTransfer.aspx") {
            if (funTextBoxName()) {
                return true;
            }
            return false;
        } else if (type == "Alipay2.aspx") {
            if (funTextBoxName() && funTextBoxAlipay() && funTextBoxMerchantCode() && funTextBoxSecretKey()) {
                return true;
            }
            return false;
        } else if (type == "Alipay3.aspx") {
            if (funTextBoxName() && funTextBoxAlipay() && funTextBoxMerchantCode() && funTextBoxSecretKey()) {
                return true;
            }
            return false;
        } else if (type == "Alipay.aspx") {
            if (funTextBoxName() && funTextBoxAlipay() && funTextBoxMerchantCode() && funTextBoxSecretKey()) {
                return true;
            }
            return false;
        } else if (type == "DeliveryPay.aspx") {
            if (funTextBoxName()) {
                return true;
            }
            return false;
        } else if (type == "Tenpay.aspx") {
            if (funTextBoxName() && funTextBoxMerchantCode() && funTextBoxSecretKey()) {
                return true;
            }
            return false;
        } else if (type == "TenpayMed.aspx") {
            if (funTextBoxName() && funTextBoxMerchantCode() && funTextBoxSecretKey()) {
                return true;
            }
            return false;
        } else if (type == "YeepaySZX.aspx") {
            if (funTextBoxName() && funTextBoxMerchantCode() && funTextBoxSecretKey()) {
                return true;
            }
            return false;
        } else if (type == "Yeepay.aspx") {
            if (funTextBoxName() && funTextBoxMerchantCode() && funTextBoxSecretKey()) {
                return true;
            }
            return false;
        } else if (type == "Allbuy.aspx") {
            if (funTextBoxName() && funTextBoxMerchantCode() && funTextBoxSecretKey()) {
                return true;
            }
            return false;
        } else if (type == "PreDeposits.aspx") {
            if (funTextBoxName()) {
                return true;
            }
            return false;
        } else if (type == "PayPal.aspx") {
            if (funTextBoxName() && funTextBoxMerchantCode() && funTextBoxSecretKey()) {
                return true;
            }
            return false;
        } else if (type == "Send.aspx") {
            if (funTextBoxName() && funTextBoxMerchantCode() && funTextBoxSecretKey()) {
                return true;
            }
            return false;
        } else if (type == "NetPayClient.aspx") {
            if (funTextBoxName() && funTextBoxMerchantCode() && funTextBoxSecretKey()) {
                return true;
            }
            return false;
        } else if (type == "IcardPay.aspx") {
            if (funTextBoxName() && funTextBoxMerchantCode() && funTextBoxSecretKey()) {
                return true;
            }
            return false;
        } else {
            return true;
        }
        return false;

    }

</script>
<div id="list_main">
    <ul id="sidebar">
        <li class="TabbedPanelsTab">配置支付方式</li>
    </ul>
    <div id="content">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;" class="tabbiao">
            <tr>
                <td align="right" width="130">
                    <asp:Label ID="LabelName" runat="server" Text="支付方式名称："></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TextBoxName" runat="server" CssClass="textwb" ReadOnly="true"></asp:TextBox>
                    <span id="errTextBoxName" style="color: Red">*</span>
                </td>
            </tr>
            <tr runat="server" id="tr1">
                <td align="right" style="line-height: 35px;">
                    <asp:Label ID="LabelAlipay" runat="server" Text="收款支付宝账号："></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TextBoxAlipay" runat="server" CssClass="textwb"></asp:TextBox>
                    <span id="errTextBoxAlipay" style="color: Red">*</span>
                </td>
            </tr>
            <tr runat="server" id="tr2">
                <td align="right" style="line-height: 35px;">
                    <asp:Label ID="LabelMerchantCode" runat="server" Text="商户号："></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TextBoxMerchantCode" runat="server" CssClass="textwb"></asp:TextBox>
                    <span id="errTextBoxMerchantCode" style="color: Red">*</span>
                </td>
            </tr>
            <tr runat="server" id="tr3">
                <td align="right" style="line-height: 35px;">
                    <asp:Label ID="LabelSecretKey" runat="server" Text="商户密钥："></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TextBoxSecretKey" runat="server" CssClass="textwb"></asp:TextBox>
                    <span id="errTextBoxSecretKey" style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td align="right" style="line-height: 35px;">
                    <asp:Label ID="LabelCharge" runat="server" Text="手续费："></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TextBoxCharge" runat="server" CssClass="textwb" Text="0"></asp:TextBox>
                    <asp:Label ID="LabelChargeErrorMessage" runat="server" ForeColor="red"></asp:Label>
                    <asp:CheckBox ID="CheckBoxIsPercent" runat="server" Text="百分比" />(设置为0表示没有手续费)
                </td>
            </tr>
            <tr>
                <td align="right" style="line-height: 35px;">
                    <asp:Label ID="LabelMemo" runat="server" Text="支付方式详细介绍："></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TextBoxMemo" runat="server" TextMode="MultiLine" Width="440" Height="60"
                        CssClass="textwb"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="line-height: 35px;">
                    <asp:Label ID="LabelOrderID" runat="server" Text="排序号："></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TextBoxOrderID" MaxLength="9" runat="server" CssClass="textwb"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="line-height: 35px;">
                    <div style="margin-top: 10px; text-align: center;">
                        <asp:Button ID="ButtonConfirm" runat="server" Text="确定" CssClass="baocbtn" ToolTip="Submit"
                            OnClientClick=" return funButton() " CausesValidation="false" />
                        <input id="ResetBack" runat="server" onclick="javascript:window.location.href='S_ShowPaymentType.aspx'"
                            type="reset" value="返回列表" class="baocbtn" />
                    </div>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </div>
</div>
<script type="text/javascript">
            <!--
    var TabbedPanels1 = new Spry.Widget.TabbedPanels("list_main");
//-->
</script>
<%--<asp:LinkButton ID="LinkButtonType" runat="server">LinkButton</asp:LinkButton>--%>
<asp:HiddenField ID="HiddenFieldType" runat="server" Value="" />
