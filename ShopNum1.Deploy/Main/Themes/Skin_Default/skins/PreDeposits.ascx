<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PreDeposits.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Themes.Skin_Default.skins.PreDeposits" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%
    if (ShopSettings.GetValue("IsMobileCheckPay") == "1")
    {
        IsPay.Visible = true;
    }
    
    

%>



<div id="divAgainLogin" runat="server" class="PayPage">
    <div class="PayPageUp">
        <p>
            您正在使用<%=  JyFs%>交易...</p>
    </div>

    <div class="PayPageInfo">
        <p>
            交易号：<a href="Member/M_OrderDetail.aspx?guid=<%= allOrderguid%>&ordertype=<%= allOrderordertype %>&id=<%= allOrdershop_category_id %>"
                            class="alink_blue" target="_parent" ><b class="alink_blue"><%= Page.Request.QueryString["TradeID"] %></b></a></p>
        <p>
            交易金额：<asp:Label ID="LabelShouldPay" name="LabelShouldPay" runat="server" CssClass="font2" style="display: none;"></asp:Label>
            <asp:Label ID="LabelHiddenShouldPay" name="LabelHiddenShouldPay" runat="server" CssClass="font2" style="display: none;"></asp:Label>元</p>
          
             <p runat="server" id="pScore_pv_a" style=" display:none;">
            得到积分:<asp:Label ID="LabelScore_pv_a"  runat="server"   CssClass="font2"></asp:Label>分</p>
            <p runat="server" id="pScore_pv_b" style=" display:none;">
            得到积分:<asp:Label ID="LabelScore_pv_b"  runat="server"   CssClass="font2"></asp:Label>分</p>
            <p runat="server" id="pScore_pv_cv" style=" display:none;">
            得到积分:<asp:Label ID="LabelScore_pv_cv"  runat="server"   CssClass="font2"></asp:Label>分</p>
            <p runat="server" id="pScore_cv">
            可用积分：<asp:Label ID="labelScore_cv" runat="server"  CssClass="font2"></asp:Label>元</p>
             <p runat="server" id="pScore_hv">
            得到红包：<asp:Label ID="LabelScore_hv" runat="server"  CssClass="font2"></asp:Label>元</p>
             <p runat="server" id="pScore_max_hv" style="display: none;">
            可使用重销积分：<asp:Label ID="labelScore_max_hv" runat="server" CssClass="font2" ></asp:Label>元
            
        </p>
        <p style="display: none;">已抵用<%=  Jf%>积分：<asp:Label ID="labelScore_dv" name="labelScore_dv" runat="server" CssClass="font2" ></asp:Label>元</p>
        <p style=" display:none;">
            
            <asp:Label ID="LabelHiddenScore_dv" name="LabelHiddenScore_dv" runat="server" CssClass="font2" style="display: none;"></asp:Label>元
            
        </p>
            <p class="samle" id="disable_hv" runat="server" style="display: none;" >
                    是否使用红包：
                    <asp:RadioButtonList ID="RadioButtonScore_hv" runat="server" RepeatLayout="Flow"
 RepeatDirection="Horizontal" name="RadioButtonScore_hv" >
                        <asp:ListItem Value="0" Selected="True" >是</asp:ListItem>
                        <asp:ListItem Value="1" >否</asp:ListItem>
                    </asp:RadioButtonList>
            </p>
        <p id="disable_hvTS" runat="server" style="color:red">
        提示：使用抵扣红包会减少与抵扣等数量的所获B积分！
        </p>
        <p id="zfBV" runat="server" class="fenge">
            <b><%=  JyFs%></b>可交易余额：<asp:Label ID="LabelAdvancePayment" runat="server" CssClass="font3"></asp:Label>元</p>
        <p class="fenge" runat="server" id="noPay">
            <b><a target="_blank" href='http://<%=ShopNum1.Common.ShopSettings.siteDomain%>/main/account/A_Index.aspx?toaurl=A_PwdSer.aspx'>
                警告：您尚未设置交易密码，马上去设置交易密码</a></b></p>
        <div class="buzhu" id="xianshi" runat="server"  style="display: none;">
            <p>
                您的账户没有可交易余额不足，请使用其它方式付款，或<a href="account/A_Index.aspx?toaurl=A_AdPayRecharge.aspx"
                    target="_blank">充值</a>后付款</p>
        </div>
        <script type="text/javascript" language="javascript">
            $(function  (){
                var LabelAdvancePayment = $("#<%=LabelAdvancePayment.ClientID%>").text(); //金币（BV）可交易余额
                var preDeposits_ctl00_LabelShouldPay = $("#<%=LabelShouldPay.ClientID%>").text(); //订单金额
                if (parseFloat(LabelAdvancePayment) < parseFloat(preDeposits_ctl00_LabelShouldPay)) {
                    document.getElementById("PreDeposits1_xianshi").style.display = "block";

                } 
                else {
                    //1
                }
            });
        </script>
        <script type="text/javascript">
            $(document).ready(function () {
                check();

                $(":radio").click(function () {
                    check();
                });

                function check() {
                    if ($("input[name='PreDeposits1$RadioButtonScore_hv']").attr("checked") == 'checked') {
                        $("span[name='LabelShouldPay']").show();
                        $("span[name='labelScore_dv']").show();
                        $("span[name='LabelHiddenShouldPay']").hide();
                        $("span[name='LabelHiddenScore_dv']").hide();

                        var LabelAdvancePayment = $("#<%=LabelAdvancePayment.ClientID%>").text(); //订单金额
                        var preDeposits_ctl00_LabelShouldPay = $("span[name='LabelHiddenShouldPay']").text(); //订单金额
                        var dispp;
                        if (parseFloat(LabelAdvancePayment) < parseFloat(preDeposits_ctl00_LabelShouldPay)) {
                            //                    document.getElementById("PreDeposits1_xianshi").style.display = "block";
                            dispp = "block";
                        }
                        else {
                            //2
                            //                    document.getElementById("PreDeposits1_xianshi").style.display = "none";
                            dispp = "none";
                        }
                        document.getElementById("PreDeposits1_xianshi").style.display = dispp;

                    } else {
                        $("span[name='LabelShouldPay']").show();
                        $("span[name='labelScore_dv']").show();
                        $("span[name='LabelHiddenShouldPay']").hide();
                        $("span[name='LabelHiddenScore_dv']").hide();


                        var LabelAdvancePayment = $("#<%=LabelAdvancePayment.ClientID%>").text(); //金币（BV）可交易余额
                        var preDeposits_ctl00_LabelShouldPay = $("#<%=LabelShouldPay.ClientID%>").text(); //订单金额
                        var dispp;
                        if (parseFloat(LabelAdvancePayment) < parseFloat(preDeposits_ctl00_LabelShouldPay)) {
                            //                    document.getElementById("PreDeposits1_xianshi").style.display = "block";
                            dispp = "block";
                        }
                        else {
                            //3

                            dispp = "none";
                        }
                        document.getElementById("PreDeposits1_xianshi").style.display = dispp;
                    }
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
            <ShopNum1:TextBox ID="TextBoxPayPass1word" runat="server" TextMode="Password" CanBeNull="必填"
                IsReplaceInvertedComma="true" MaxLength="30" CssClass="PwdText" autocomplete="off"/>
        </p>
        <p>
            <asp:Button ID="ButtonPay" class="PaySure" runat="server" Text="确定支付" 
                OnClientClick="return checkPay()" onclick="ButtonPay_Click" /></p> <%--
            <asp:Button ID="ButtonPay" class="PaySure" runat="server" Text="确定支付" 
                OnClientClick="document.forms[0].submit();disabled=true;" onclick="ButtonPay_Click" />--%>
                <%--<form name=form1 method="POST" action="/" onsubmit="return checkPay();">--%>
                <%--<p>
                    <asp:Button ID="Button1" runat="server" Text="Button" />
                <input type="button" value="确定支付"  class="PaySure"  onclick="" onserverclick="ButtonPay_Click" runat="server"/>
                </p>--%>
              <%--  </form>--%>
                
                 <script type="text/javascript">
                     var i = 0;
                     function clickR() {
                         if (i == 0) {
                             i = 1;
                             return true;
                         }
                         return false;
                     }



                     
     </script>
        <script type="text/javascript">
//            $('#ButtonPay').click(function () {
//                $(this).attr('disabled', 'disabled').die('click');
//                // other code
//            });
       

            function checkPay() {
//                var ButtonPay = $("#<%=ButtonPay.ClientID%>");
//                ButtonPay.Attributes["onclick"] = this.GetPostBackEventReference(this.ButtonPay) + ";this.disabled=true;";
                //                $("#<%=ButtonPay.ClientID%>").attr('disabled', 'disabled');
               
 
               

                if ($("#<%=TextBoxPayPass1word.ClientID%>").val() == "") {
                    alert("请输入交易密码");
                    document.getElementById('PreDeposits1$ButtonPay').style.display = 'block';
                    return false;
                }
                if ($("#<%=txtMobileCode.ClientID%>").is(":visible")) {
                    if ($("#<%=txtMobileCode.ClientID%>").val() == "") { alert("手机验证码不能为空！"); return false; }
                    else {
                        $.get("/Api/CheckInfo.ashx?type=8&key=" + $("#<%=txtMobileCode.ClientID%>").val() + "", null, function (data) {
                            if (data == "0") { alert("短信无法发送出去，请在后台检测短信接口是否可用！"); return false; } else { return true; }
                        });
                    }
                }
            }
        </script>
    </div>
</div>
