<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Payment_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Payment_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <style>
        .hidden
        {
            display: none;
        }
        
        .block
        {
            display: block;
        }
    </style>
    <%--   <script src="/js/jquery-1.4.2.min.js" type="text/javascript"></script>--%>
    <script src="js/jquery-1.3.2.min.js" type="text/javascript"> </script>
    <script language="javascript" type="text/javascript">
        selectvalue = "";
        $(document).ready(function () {

            loadPaymentPower();
            $("#<%= DropDownListPaymentType.ClientID %>").change(function () {

                var objSelect = $("#<%= DropDownListPaymentType.ClientID %>").get(0);

                for (var i = 0; i < objSelect.options.length; i++) {
                    if (objSelect[i].selected == true) {
                        if (objSelect[i].value != "-1") {
                            $("#<%= TextBoxName.ClientID %>").val(objSelect[i].text);

                        }
                        selectvalue = objSelect[i].value;
                        PaymentPower(objSelect[i].value);
                        //alert(objSelect[i].text);
                    }
                }
            });

            function loadPaymentPower() {
                var objSelect = $("#<%= DropDownListPaymentType.ClientID %>").get(0);

                for (var i = 0; i < objSelect.options.length; i++) {
                    if (objSelect[i].selected == true) {
                        if (objSelect[i].value != "-1") {

                        }
                        PaymentPower(objSelect[i].value);
                    }
                }
            }

            function PaymentPower(selectval) {

                var trs = $("#form1 table:eq(0) tr");
                trs.removeAttr("style");
                if (selectval == "DeliveryPay.aspx" || selectval == "PreDeposits.aspx" || selectval == "BankTransfer.aspx") {

                    if (selectval == "PreDeposits.aspx" || selectval == "DeliveryPay.aspx") {
                        trs[8].style.display = "none";
                        $(trs[8]).find(":radio:eq(0)").attr("checked", false);
                        $(trs[8]).find(":radio:eq(1)").attr("checked", true);
                    }

                    for (i = 0; i < trs.length; i++) {
                        if (i >= 2 && i <= 4) {
                            trs[i].style.display = "none";
                        }
                    }

                }
                if (selectval == "PayPal.aspx") {

                    trs[2].style.display = "none";
                    trs[4].style.display = "none";
                }


                if (selectval == "Alipay.aspx" || selectval == "Alipay2.aspx" || selectval == "Alipay3.aspx") {
                    $("#<%= LabelMerchantCode.ClientID %>").text("合作者身份(PID)：");
                    $("#<%= LabelSecretKey.ClientID %>").text("安全校验码(Key)：");

                } else {
                    trs[2].style.display = "none";
                    $("#<%= LabelMerchantCode.ClientID %>").text("商户号：");
                    $("#<%= LabelSecretKey.ClientID %>").text("商户密钥：");
                }
            }


        });

        function CheckPass() {
            return true;
            //   // PreDeposits
            //   if (selectvalue=="Alipay.aspx"||selectvalue=="Alipay2.aspx"||selectvalue=="Alipay3.aspx")
            //   {
            //    
            //      if(CheckName()&&CheckMerchantCode()&&CheckSecretKey()&&CheckEmail()&&CheckCharge()&&CheckOrderID())
            //      {
            //      return true;
            //      }
            //      return false;
            //   }
            //   if(selectvalue=="DeliveryPay.aspx"||selectvalue=="DPreDeposits.aspx"||selectvalue=="BankTransfer.aspx")
            //   {
            //      if(CheckName()&&CheckCharge()&&CheckOrderID())
            //      {
            //      return true ;
            //      }
            //      return false;
            //   }
            //    if(selectvalue=="PayPal.aspx")
            //    {
            //       if(CheckName()&&CheckCharge()&&CheckOrderID()&&CheckMerchantCode())
            //      {
            //      return true ;
            //      }
            //      return false;
            //    }
            //      if(selectvalue=="PreDeposits.aspx")
            //    {
            ////       if(CheckName()&&CheckOrderID()&&CheckCharge())
            ////      {
            ////      return true ;
            ////      }
            ////      return false;
            //        return true;
            //    }
            //    else
            //    {
            //   
            //     if(CheckName()&&CheckMerchantCode()&&CheckSecretKey()&&CheckOrderID()&&CheckCharge())
            //      {
            //      return true;
            //      }
            //      return false;
            //    }
            //    
            //   return true;

        }

        //验证支付方式名称

        function CheckName() {
            var Name = $("#<%= TextBoxName.ClientID %>").val();
            if (Name.length <= 0) {
                $("#LabelnameErrorMessage").text("该值不能为空");
                return false;
            }
            var Validator = /^[\s\S]{0,100}$/;
            if (!Validator.test(Name)) {
                $("#LabelnameErrorMessage").text("支付方式最多100个字符");

                return false;
            }
            $("#LabelnameErrorMessage").text("");
            return true;
        }

        //验证收款支付宝账号

        function CheckEmail() {
            var Email = $("#<%= TextBoxEmail.ClientID %>").val();
            var Validator = /^[\s\S]{0,50}$/;
            if (!Validator.test(Email)) {
                $("#LabelEmailErrorMessage").text("最多50个字符");
                return false;
            }
            Validator = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;

            if (!Validator.test(Email)) {
                $("#LabelEmailErrorMessage").text("邮箱格式不正确!");
                return false;
            }
            $("#LabelEmailErrorMessage").text("");
            return true;

        }

        //MerchantCode

        function CheckMerchantCode() {
            var MerchantCode = $("#<%= TextBoxMerchantCode.ClientID %>").val();
            if (MerchantCode.length <= 0) {
                $("#LabelMerchantCodeErrorMessage").text("不能为空!");
                return false;

            }
            var Validator = /^[\s\S]{0,150}$/;
            if (!Validator.test(MerchantCode)) {
                $("#LabelMerchantCodeErrorMessage").text("商户号最多150个字符!");

                return false;
            }

            $("#LabelMerchantCodeErrorMessage").text("");

            return true;
        }

        //SecretKey

        function CheckSecretKey() {
            var SecretKey = $("#TextBoxSecretKey").val();
            var Validator = /^[\s\S]{1,150}$/;
            if (!Validator.test(SecretKey)) {
                $("#SecretKeyErrorMessage").text("密匙最多1-150个字符");
                return false;
            }

            $("#SecretKeyErrorMessage").text("");

            return true;
        }

        //Charge

        function CheckCharge() {
            var Charge = $("#TextBoxCharge").val();
            if (Charge.length <= 0) {
                $("#ChargeErrorMessage").text("不能为空！");
                return false;
            }
            var Validator = /^[0-9]{1,7}(\.[0-9]{1,3})?$/;
            if (!Validator.test(Charge)) {
                $("#ChargeErrorMessage").text("输入格式不正确！");
                return false;
            }
            $("#ChargeErrorMessage").text("");

            return true;
        }

        function CheckOrderID() {
            var OrderID = $("#TextBoxOrderID").val();
            if (OrderID.length <= 0) {
                $("#OrderIDErrorMessage").text("该值不能为空");
                return false;
            }
            var Validator = /^[0-9]*$/;
            if (!Validator.test(OrderID)) {
                $("#OrderIDErrorMessage").text("只能输入数字");
                return false;
            }
            $("#OrderIDErrorMessage").text("");
            return true;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="新增支付方式"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="LabelPaymentType" runat="server" Text="支付方式类型："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListPaymentType" runat="server" CssClass="tselect">
                                <asp:ListItem Value="Allbuy.aspx">好购(AllBuy)</asp:ListItem>
                                <asp:ListItem Value="Yeepay.aspx">易宝(YeePay)</asp:ListItem>
                                <asp:ListItem Value="YeepaySZX.aspx">易宝(YeePay)神州行</asp:ListItem>
                                <asp:ListItem Value="TenpayMed.aspx">财付通中介保护</asp:ListItem>
                                <asp:ListItem Value="Tenpay.aspx">财付通即时到账</asp:ListItem>
                                <asp:ListItem Value="DeliveryPay.aspx">货到付款</asp:ListItem>
                                <asp:ListItem Value="Alipay.aspx">支付宝担保交易</asp:ListItem>
                                <asp:ListItem Value="Alipay3.aspx">支付宝及时到账</asp:ListItem>
                                <asp:ListItem Value="Alipay2.aspx">支付宝标准双向接口</asp:ListItem>
                                <asp:ListItem Value="BankTransfer.aspx">线下支付</asp:ListItem>
                                <asp:ListItem Value="PreDeposits.aspx">金币（BV）支付</asp:ListItem>
                                <asp:ListItem Value="PayPal.aspx">贝宝支付(PayPal)</asp:ListItem>
                                <asp:ListItem Value="Send.aspx">网银支付(chinabank)</asp:ListItem>
                                <asp:ListItem Value="NetPayClient.aspx">银联支付(chinapay)</asp:ListItem>
                                <asp:ListItem Value="IcardPay.aspx">支付通</asp:ListItem>
                                <asp:ListItem Value="Dinpay.aspx">唐江自付快捷支付</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:CompareValidator ID="CompareValidatorPaymentType" runat="server" ControlToValidate="DropDownListPaymentType"
                                Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelName" runat="server" Text="支付方式名称："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:Label ID="LabelnameErrorMessage" runat="server" ForeColor="red"></asp:Label>
                            <%--      <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                    ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="支付方式最多100个字符"
                    ValidationExpression="^[\s\S]{0,100}$"></asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelEmail" runat="server" Text="收款支付宝账号："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="LabelEmailErrorMessage" runat="server" ForeColor="red"></asp:Label>
                            <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle5" runat="server"
                    ControlToValidate="TextBoxEmail" Display="Dynamic" ErrorMessage="标题最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxEmail" runat="server"
                    ControlToValidate="TextBoxEmail" Display="Dynamic" ErrorMessage="邮箱格式不正确！" ValidationExpression="^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$"></asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelMerchantCode" runat="server" Text="商户号："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMerchantCode" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label8" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:Label ID="LabelMerchantCodeErrorMessage" runat="server" ForeColor="red"></asp:Label>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidatorMerchantCode" runat="server"
                    ControlToValidate="TextBoxMerchantCode" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorMerchantCode" runat="server"
                    ControlToValidate="TextBoxMerchantCode" Display="Dynamic" ErrorMessage="商户号最多150个字符"
                    ValidationExpression="^[\s\S]{0,150}$"></asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelSecretKey" runat="server" Text="商户密钥："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxSecretKey" runat="server" CssClass="tinput"></asp:TextBox>
                            <span style="color: Red">*</span> <span style="color: Red" id="SecretKeyErrorMessage">
                            </span>
                            <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidatorSecretKey" runat="server"
                    ControlToValidate="TextBoxSecretKey" Display="Dynamic" ErrorMessage="密匙最多150个字符"
                    ValidationExpression="^[\s\S]{0,150}$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxSecretKey" runat="server"
                    ControlToValidate="TextBoxSecretKey" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            --%>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelCharge" runat="server" Text="手续费："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxCharge" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label4" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <span id="ChargeErrorMessage" style="color: Red"></span>
                            <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidatorName2" runat="server" ControlToValidate="TextBoxCharge"
                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorCharge" runat="server"
                    ControlToValidate="TextBoxCharge" Display="Dynamic" ErrorMessage="输入格式不正确" ValidationExpression="^[0-9]{1,7}(\.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                            --%>
                            <asp:CheckBox ID="CheckBoxIsPercent" runat="server" Text="百分比" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right" style="height: 115px;">
                            <asp:Label ID="LabelMemo" runat="server" Text="支付方式详细介绍："></asp:Label>
                        </th>
                        <td style="height: 115px;">
                            <asp:TextBox ID="TextBoxMemo" runat="server" TextMode="MultiLine" CssClass="tinput txtarea"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle6" runat="server"
                                ControlToValidate="TextBoxMemo" Display="Dynamic" ErrorMessage="详细介绍最多200个字符"
                                ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelOrderID" runat="server" Text="排序号："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOrderID" MaxLength="9" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label7" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <span id="OrderIDErrorMessage" style="color: Red"></span>
                            <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidatorOrderID" runat="server"
                    ControlToValidate="TextBoxOrderID" Display="Dynamic" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderID" runat="server" ControlToValidate="TextBoxOrderID"
                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            --%>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle7" 
                        runat="server" ControlToValidate="TextBoxOrderID" Display="Dynamic" 
                        ErrorMessage="排序号最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            用于金币（BV）充值：
                        </th>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonListForredepositrecharge" runat="server">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="确定"
                    class="fanh" ToolTip="Submit" OnClientClick=" return CheckPass(); " CausesValidation="false" />
                <asp:Button ID="ButtonBack" runat="server" Text="返回列表" CssClass="fanh" PostBackUrl="~/Main/Admin/Payment_List.aspx"
                    CausesValidation="false" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
