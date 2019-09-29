<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" %>


<%@ Import Namespace="ShopNum1.Common" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link type="text/css" href="Themes/Skin_Default/Style/index.css" rel="Stylesheet" />
    <script src="Themes/Skin_Default/Js/jquery.min.js" type="text/javascript"></script>
    <link href="Themes/Skin_Default/inc/Style/top.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        if (top.location != location) top.location.href = location.href;
        $(document).ready(function () {

            $("#FlowCate").mouseover(function () {
                $("#ThrCategory").show();
                $("#ThrCategory").focus();
            }).mouseout(function () {
                $("#ThrCategory").hide();
            });


            $("#ThrCategory").mouseover(function () {
                $("#ThrCategory").show();
            }).mouseout(function () {
                $("#ThrCategory").hide();
            });

        });
    </script>
    <script type="text/javascript" language="javascript">
        function LiEmail() {
            document.getElementById("divEmail").style.display = "block";
            document.getElementById("divTel").style.display = "none";
            document.getElementById("Email").style.background = "url(Themes/Skin_Default/Images/reggg.jpg) center no-repeat";
            document.getElementById("Email").style.color = "#FFF";
            document.getElementById("Mobile").style.background = "#FFF";
            document.getElementById("Mobile").style.color = "#D40000";
            $("#<%=sign.ClientID %>").val("1");
        }

        function LiMobile() {
            document.getElementById("divEmail").style.display = "none";
            document.getElementById("divTel").style.display = "block";
            document.getElementById("Email").style.background = "#FFF";
            document.getElementById("Email").style.color = "#D40000";
            document.getElementById("Mobile").style.background = "url(Themes/Skin_Default/Images/reggg.jpg) center no-repeat";
            document.getElementById("Mobile").style.color = "#FFF";
            $("#<%=sign.ClientID %>").val("2");
        }
      
    </script>
</head>
<body>
    <form id="from1" runat="server">
    <!--head Start-->
    <!-- #include file="headtop.aspx" -->
    <!--//head End-->
    <!--main Start-->
    <div class="FlowCat_cont">
        <div class="position">
            所在位置:<a href="Default.aspx">首页</a> > 邮箱验证</div>
        <div class="findpwd">
            <h1>
                找回密码</h1>
            <div class="findcont">
                <p class="findimg">
                    <img src="Themes/Skin_Default/Images/findpwd1.jpg" width="866" height="30" /></p>
                <div class="findtable">
                    <table border="0" cellpadding="0" cellspacing="0" align="center">
                        <tr>
                            <td align="right">
                                用户名：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBox1" runat="server" Text="用户名/邮箱/已验证手机" CssClass="findinput"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                验证码：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="findyanzhen"></asp:TextBox><img
                                    src="Themes/Skin_Default/Images/imagecode.gif" /><a href="#">看不清楚？点一下</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                                <asp:Button ID="Button1" runat="server" Text="下一步" CssClass="finbtn" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="findpwd">
            <h1>
                找回密码</h1>
            <div class="findcont">
                <p class="findimg">
                    <img src="Themes/Skin_Default/Images/findpwd2.jpg" width="866" height="30" /></p>
                <div class="findtable">
                    <table border="0" cellpadding="0" cellspacing="0" align="center">
                        <tr class="trsrucee">
                            <td align="right">
                                <img src="Themes/Skin_Default/Images/ban_prompt.gif" />
                            </td>
                            <td align="left">
                                <p class="yellow1">
                                    证邮件已发送，请<a href="#">登录邮箱</a>邮箱完成验证！</p>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <!--//main End-->
    <!--foot Start-->
    <div class="wrapBox FootMessage">
        <ShopNum1:Bottom ID="Bottom" runat="server" SkinFilename="Bottom.ascx" class="foot_bg" />
    </div>
    <!--//foot End-->
    <asp:HiddenField ID="sign" runat="server" />
    </form>
</body>
</html>
