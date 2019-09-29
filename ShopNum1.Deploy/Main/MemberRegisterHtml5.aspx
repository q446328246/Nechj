<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberRegisterHtml5.aspx.cs" Inherits="ShopNum1.Deploy.Main.MemberRegisterHtml5" %>
<!DOCTYPE html>
<html lang="zh-CN">
<head>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
<title>用户注册</title>
    <link href="../Main/jquery/css/login.css" rel="stylesheet" type="text/css" />
    <link href="../Main/jquery/css/normalize.css" rel="stylesheet" type="text/css" />
    <script src="../Main/jquery/common/js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../Main/jquery/common/layer/layer.js" type="text/javascript"></script>
    <script src="../Main/jquery/common/js/index.js" type="text/javascript"></script>
    <script src="../Main/jquery/js/rem.js" type="text/javascript"></script>
    <style>
        #Button1
        {
            transform:rotate(180deg);
            } 
           
           .counter_btn
           {
               display:none;
                   background-color: rgb(97,140,189);
    height: 36px;
    line-height: 36px;
    width: 146px;
    color: #000;
    border-top-right-radius: 36px 36px;
    border-bottom-right-radius: 36px 36px;
               } 
               .counter_btn .btn_right
               {
                   width 50px;
                   }
              
    </style>
</head>
<body class="bgf5">
<div class="login-container register-container" style="background: url(../Main/jquery/images/login_bg2.png) 0 0 no-repeat /100% 100%; ">
    <div class="register-title">用户注册</div>
    <div class="formbox"  filter:0.7;-moz-opacity:0.7;opacity:0.7">
        <form name="AddUser" action="#" id="registerForm" class="formrgister" autocomplete="off" method="post" runat="server">
            <a href="javascript:void(0)" style="color: #ffffff;">UID:<asp:Label ID="MemloginID" runat="server" Text=""></asp:Label>&nbsp;&nbsp;</a>
            <div style="clear: both;"></div>
            <div id="error_display" style="text-align:center;color:red;">
               <asp:Label ID="TS" runat="server" Text=""></asp:Label>
            </div>
            <div class="input_box">
                <span><img class="icon" src="../Main/jquery/image/register_icon_name.png" alt=""/></span>
                <input type="text" id="Name" runat="server" name="username" class="username" placeholder="请输入昵称" autocomplete="off"  style="width: 75%;" />
                <input type="hidden" name="unumber" value="88195828"/>
            </div>
            <div class="input_box" style=" display:none;">
                <span><img class="icon" src="../Main/jquery/image/register_icon_phone.png" alt=""/></span>
                <select id="country" style="width: 75%;">
                    <option value="86">(+86)中国</option>
                    <option value="852">(+852)中国香港</option>
                    <option value="853">(+853)中国澳门</option>
                    <option value="886">(+886)中国台湾</option>
                    <option value="357">(+357)塞浦路斯</option>
                    <option value="1">(+1)美国</option>
                    <option value="33">(+33)法国</option>
                    <option value="44">(+44)英国</option>
                    <option value="49">(+49)德国</option>
                    <option value="81">(+81)日本</option>
                    <option value="82">(+82)韩国</option>
                    <option value="96">(+96)马尔代夫</option>
                    <option value="6">(+6)马来西亚</option>
                    <option value="65">(+65)新加坡</option>
                    <option value="66">(+66)泰国</option>
                    <option value="63">(+63)菲律宾</option>
                    <option value="84">(+84)越南</option>
                    <option value="855">(+855)柬埔寨</option>
                    <option value="85">(+85)朝鲜</option>
                    <option value="976">(+976)蒙古</option>
                    <option value="95">(+95)缅甸</option>
                    <option value="92">(+92)巴基斯坦</option>
                    <option value="39">(+39)意大利</option>
                    <option value="55">(+55)巴西</option>
                    <option value="7">(+7)哈萨克斯坦</option>
                    <option value="856">(+856)老挝人民民主共和国</option>
                </select>
            </div>
            <div class="input_box">
                <span><img class="icon" src="../Main/jquery/image/register_icon_phone.png" alt=""/></span>
                <input type="text" name="mobile" class="phone_number" placeholder="请输入手机号码" autocomplete="off" ID="Mobile" runat="server"/>

            </div>
            <div class="input_box" style="display: none;">
                <div class="input-code">
                    <span><img class="icon" src="../Main/jquery/image/register_icon_phone.png" alt="" style="margin-left: 0px;"/></span>
                    <input name="verify" class="captcha-text" placeholder="右侧验证码" style="padding-left: 25px;  id="j_verify" type="text"/>
                    <div id="captcha-container"><img alt="图形验证码" src="/Home/Login/verify_c.html" title="点击刷新"></div>
                </div>
            </div>  
            <div class="input_box">
                <div class="phone-code">
                    <span><img class="icon" src="../Main/jquery/image/register_icon_phone.png" alt="" style="margin-left: 23px;"/></span>
                    <input type="text" ID="MobileCode" runat="server" name="code" class="code" placeholder="手机验证码"  style="padding-left: 5px; width: 35%;"   oncontextmenu="return false" onpaste="return false" />
                    <asp:Button ID="Button1" runat="server" Text="" OnClick="Button1_Click" BackColor="#84c1ff" cssclass=" register-container"  autocomplete="off"  style="width:160px;text-align:center;background:url(../Main/jquery/image/P.png);" />
                    <span class="counter_btn" runat="server" id="counter_btn"><em>60</em>s之后重新获取</span>

            
                      <%--<a ID="Button1" runat="server" OnClick="Button1_Click" autocomplete="off">获取手机验证码</a> --%>
                </div>
            </div>
            <div class="input_box">
                <span><img class="icon" src="../Main/jquery/image/register_icon_password.png" alt=""></span>
                <input type="password" ID="PassWord" runat="server" name="login_pwd" class="password" placeholder="输入登录密码" oncontextmenu="return false" onpaste="return false" />
            </div>
            <div class="input_box">
                <span><img class="icon" src="../Main/jquery/image/register_icon_passwordangin.png" alt=""></span>
                <input type="password" id="Passwords" runat="server" name="relogin_pwd" class="confirm_password" placeholder="再次输入密码" oncontextmenu="return false" onpaste="return false" />
            </div>
            <div class="input_box">
                <span><img class="icon" src="../Main/jquery/image/register_icon_recommend.png" alt="" alt=""></span>
                <input type="text" ID="Tuijian" name="pid" placeholder="请输入推荐人UID" runat="server" style="width: 75%;"/>

            </div>
            <div class="input_box">
                <span><img class="icon" src="../Main/jquery/image/header_finance.png" alt=""></span>
                <input type="password" ID="IIPassWord" runat="server" name="safety_pwd" class="safety_pwd" placeholder="输入交易密码" oncontextmenu="return false" onpaste="return false" />
            </div>
            <div class="input_box">
                <span><img class="icon" src="../Main/jquery/image/header_finance.png" alt=""></span>
                <input type="password" id="IIPassWoerds" runat="server" name="resafety_pwd" class="confirm_safety_pwd" placeholder="再次输入交易密码" oncontextmenu="return false" onpaste="return false" />
            </div>
            <div  class="inde-btn" style="border-top:10px">
                <%--<button type="submit" id="Zhuce"  style=" background-color:#93ff93">注 册</button>--%>
                <asp:Button ID="Button2" runat="server" Text="注  册"   OnClick="submit_Click" CssClass=" input_box" style=" border-top:10px;background-color:#93ff93; width:210px; height:30px" />
            </div>
        </form>
    </div>
    <div class="extra_btn">
        <a  href="https://cw.pub/X3Jm" style="color: #579aeb;">下载App</a>
    </div>
</div>
    <script type="text/javascript">
        var display = document.getElementById('counter_btn').style.display;
        if (display === "block") {
            // 开始执行倒计时
            count_down(60);
        }
        var tid = null;
        function count_down(seconds) {
            if (seconds > 0) {
                $('#counter_btn em').html(seconds);
                seconds--;
                tid = setTimeout(function () {
                    count_down(seconds);
                }, 1000);
            } else {
                clearTimeout(tid);
                $('#counter_btn').hide();
                $('#Button1').show();
            }
        }
    </script>
</body>
</html>
