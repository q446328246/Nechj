<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PreDeposits.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Themes.Skin_Default.skins.PreDeposits" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%
    if (ShopSettings.GetValue("IsMobileCheckPay") == "1")
    {
        IsPay.Visible = true;
    }
    
    

%>
<script type="text/javascript">
    $(document).ready(function () {
        check();

        $(":radio").click(function () {
            check();
        });

        function check() {
            if ($("input[name='PreDeposits1$RadioButtonScore_hv']").attr("checked") == 'checked') {
                $("span[name='LabelShouldPay']").hide();
                $("span[name='LabelHiddenShouldPay']").show();

            } else {
                $("span[name='LabelShouldPay']").show();
                $("span[name='LabelHiddenShouldPay']").hide();
            }
        }
    });  
</script>


<div id="divAgainLogin" runat="server" class="PayPage">
    <div class="PayPageUp">
        <p>
            您正在使用金币（BV）支付交易...</p>
    </div>

    <div class="PayPageInfo">
        <p>
            交易号：<asp:TextBox ID="TextBoxOrderID" Enabled="false" runat="server" CssClass="font1"></asp:TextBox></p>
        <p>
            交易金额：<asp:Label ID="LabelShouldPay" name="LabelShouldPay" Enabled="false" runat="server" CssClass="font2"></asp:Label>
            <asp:Label ID="LabelHiddenShouldPay" name="LabelHiddenShouldPay" Enabled="false" runat="server" CssClass="font2"></asp:Label>元</p>
          
             <p>
            得到积分:<asp:Label ID="LabelScore_pv_a"  runat="server"   CssClass="font2"></asp:Label>分</p>
            <p>
            可用积分：<asp:Label ID="labelScore_cv" runat="server"  CssClass="font2"></asp:Label>元</p>
             <p>
            得到红包：<asp:Label ID="LabelScore_hv" runat="server"  CssClass="font2"></asp:Label>元</p>
             <p>
            可用红包：<asp:Label ID="labelScore_max_hv" runat="server" CssClass="font2" ></asp:Label>元
            
        </p>
            <p class="samle">
                    是否使用红包：
                    <asp:RadioButtonList ID="RadioButtonScore_hv" runat="server" RepeatLayout="Flow"
 RepeatDirection="Horizontal" name="RadioButtonScore_hv" >
                        <asp:ListItem Value="0">是</asp:ListItem>
                        <asp:ListItem Value="1" Selected="True">否</asp:ListItem>
                    </asp:RadioButtonList>
                </p>
        <p class="fenge">
            <b>金币（BV）账户</b>可交易余额：<asp:Label ID="LabelAdvancePayment" runat="server" CssClass="font3"></asp:Label>元</p>
        <p class="fenge" runat="server" id="noPay">
            <b><a target="_blank" href='http://<%=ShopNum1.Common.ShopSettings.siteDomain%>/main/account/A_Index.aspx?toaurl=A_PwdSer.aspx'>
                警告：您尚未设置交易密码，马上去设置交易密码</a></b></p>
        <div class="buzhu" id="xianshi" style="display: none;">
            <p>
                您的账户没有可交易余额不足，请使用其它方式付款，或<a href="account/A_Index.aspx?toaurl=A_AdPayRecharge.aspx"
                    target="_blank">充值</a>后付款</p>
        </div>
        <script type="text/javascript" language="javascript">
            $(function () {
                var LabelAdvancePayment = $("#<%=LabelAdvancePayment.ClientID%>").text(); //金币（BV）可交易余额
                var preDeposits_ctl00_LabelShouldPay = $("#<%=LabelShouldPay.ClientID%>").text(); //订单金额
                if (parseFloat(LabelAdvancePayment) < parseFloat(preDeposits_ctl00_LabelShouldPay)) {
                    document.getElementById("xianshi").style.display = "block";

                } else {
                    //$("#<%=ButtonPay.ClientID%>").attr("disabled","disabled");
                }
            });
        </script>
        <div id="IsPay" runat="server" visible="false">
            <p class="indent">
                <b class="indextB">短信确认码：</b>
                <asp:TextBox ID="txtMobileCode" runat="server" Text="" CssClass="PwdText"></asp:TextBox><span
                    style="color: Red">*</span>
                <input type="button" id="butGetCode" value="获取验证码" />
            </p>
            <script type="text/javascript" language="javascript">
                var timerId;
                $(function () {
                    $("#<%=txtMobileCode.ClientID%>").val("");
                    $("#butGetCode").click(function () {
                        $("#butGetCode").val("已发送验证码(60秒)");
                        timerId = setInterval("goTo()", 2000);
                        $("#butGetCode").attr("disabled", "disabled");
                        $.get("/Api/CheckInfo.ashx?type=6", null, function (data) {
                            if (data == "0") { alert("手机验证码发送失败！"); $("#butGetCode").val("获取验证码"); $("#butGetCode").removeAttr("disabled"); return false; }
                        });
                    });
                });
                var i = 60;
                function goTo() {
                    i--;
                    $("#butGetCode").val("已发送验证码(" + i + "秒)");
                    if (i == 0) {
                        $("#butGetCode").val("获取验证码");
                        $("#butGetCode").removeAttr("disabled");
                        clearInterval(timerId); i = 60;
                    }
                }
            </script>
        </div>
        <p class="indent">
            <b>请输入交易密码：</b>
            <ShopNum1:TextBox ID="TextBoxPayPassword" runat="server" TextMode="Password" CanBeNull="必填"
                IsReplaceInvertedComma="true" MaxLength="30" CssClass="PwdText" />
        </p>
        <p>
            <asp:Button ID="ButtonPay" class="PaySure" runat="server" Text="确定支付" 
                OnClientClick="return checkPay()" onclick="ButtonPay_Click" /></p>
        <script type="text/javascript">
            function checkPay() {
                if ($("#<%=TextBoxPayPassword.ClientID%>").val() == "") {
                    alert("请输入交易密码");
                    return false;
                }
                if ($("#<%=txtMobileCode.ClientID%>").is(":visible")) {
                    if ($("#<%=txtMobileCode.ClientID%>").val() == "") { alert("手机验证码不能为空！"); return false; }
                    else {
                        //                           $.get("/Api/CheckInfo.ashx?type=7",null,function(data){
                        //                               if(data!="1"){alert("对不起，请在安全中心绑定手机号码才能完成支付！");return false;}
                        //                           });
                        $.get("/Api/CheckInfo.ashx?type=8&key=" + $("#<%=txtMobileCode.ClientID%>").val() + "", null, function (data) {
                            if (data == "0") { alert("短信无法发送出去，请在后台检测短信接口是否可用！"); return false; } else { return true; }
                        });
                    }
                }
            }
        </script>
    </div>
</div>
