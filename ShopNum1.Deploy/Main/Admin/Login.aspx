<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Login.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>国际电子商城-后台管理平台-登录页面</title>
    <link type="text/css" rel="Stylesheet" href='<%= ResolveUrl("css/logindex.css") %>' />
    <script src="js/jquery-1.9.1.js" type="text/javascript"> </script>
    <script src="js/logintanchuDIV2.js" type="text/javascript"> </script>
    <script type="text/javascript">
        if (top.location != location) top.location.href = location.href;

        function reloadcode() {
            var verify = document.getElementById('ImgCode');
            verify.setAttribute('src', 'AdminImgCode.aspx?' + Math.random());
        }

        function check() {
            var boolresult = false;
            var TextBoxLoginID = $("#TextBoxLoginID").val();
            var pwd = $("#TextBoxPwd").val();
            var txtcode = $(".txtcode").val();
            var Megcontent = "";
            if (TextBoxLoginID == "") {
                Megcontent = "用户名不能为空！";
                $("#TextBoxLoginID").focus();
            } else {
                if (pwd == "") {
                    Megcontent = "密码不能为空！";
                    $("#TextBoxPwd").focus();
                } else {
                    if (txtcode == "" || txtcode == "请输入验证码") {
                        Megcontent = "验证码不能为空！";
                        $(".txtcode").focus();
                    } else {
                        loadwindow2(800, 600);
                        $("#d-content-ButtonLogin").html("登录中...");
                        $("#zhezhao").delay(3000).hide(1);
                        $.ajax({
                            url: "/PageHander/Main/CheckAdminLogin.ashx",
                            async: false,
                            data: "type=checklogin&loginID=" + TextBoxLoginID + "&pwd=" + pwd + "&code=" + txtcode,
                            success: function (result) {
                                if (result == "0") {
                                    Megcontent = "用户名或密码错误！";
                                }
                                if (result == "-1") {
                                    Megcontent = "用户被锁定！";
                                }
                                if (result == "-2") {
                                    Megcontent = "验证码错误！";
                                }
                                if (result == "1") {
                                    boolresult = true;
                                }
                            }
                        });
                    }
                }
            }
            if (boolresult == false) {
                loadwindow2(800, 600);
                $("#d-content-ButtonLogin").html(Megcontent);
                $("#zhezhao").delay(1000).hide(1);

            }
            $(".d-outer").parent("div").attr("class", "artTest").attr("style", "");
            $(".d-outer").attr("style", "");
            return boolresult;

        }

        document.onkeydown = function (e) {
            var keyCode;
            var element;
            /*ie support event&keyCode*/
            keyCode = event.keyCode;
            element = event.srcElement;
            if (keyCode == 13 && element.type == 'text') {
                document.getElementById("<%=ButtonLogin.ClientID %>").click();
            }
        }

    </script>
    <style type="text/css">
        .d-border, .d-dialog
        {
            border: 0 none;
            border-collapse: collapse;
            margin: 0;
            width: 100%;
        }
        
        .d-nw, .d-n, .d-ne, .d-w, .d-c, .d-e, .d-sw, .d-s, .d-se, .d-header, .d-main, .d-footer
        {
            padding: 0;
        }
        
        .d-main
        {
            background: url(images/jinggao.jpg) no-repeat 15px 10px;
            min-width: 9em;
            text-align: center;
            vertical-align: middle;
        }
        
        .d-inner
        {
            background: #fdfdea;
            border: 1px solid #cccccc;
            height: 60px;
            width: 320px;
        }
        
        .arttest
        {
            margin: 0 auto;
            position: relative;
            width: 322px;
        }
        
        .d-outer
        {
            position: absolute;
            top: 200px;
            width: 322px;
        }
        
        .d-titleBar
        {
            display: none;
        }
        
        .zhezhao
        {
            margin: 0 auto;
            position: relative;
            width: 322px;
        }
        
        #Divfahuo
        {
            margin: 0 0;
            overflow-x: hidden;
            overflow-y: hidden;
            position: absolute;
            top: 260px;
            z-index: 1;
        }
        
        .d-content
        {
            color: #666666;
            display: block;
            font-family: "宋体";
            font-size: 14px;
            text-align: left;
        }
        
        .zhezhao1
        {
            -moz-opacity: 0.3;
            filter: alpha(opacity=30);
            height: 100%;
            height: 100%;
            opacity: 0.3;
            position: fixed;
            position: absolute;
            top: 0;
            width: 100%;
            width: 100%;
            _position: absolute;
        }
    </style>
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <!--弹出框-->
    <div id="zhezhao" style="display: none;">
        <div id="Divfahuo" style="background: #dedede; display: none; padding: 3px;">
            <table class="d-border">
                <tbody>
                    <tr>
                        <td class="d-c">
                            <div class="d-inner">
                                <table class="d-dialog">
                                    <tbody>
                                        <tr>
                                            <td style="height: auto; width: auto;" class="d-main">
                                                <div style="padding: 21px 10px 18px 28px; padding-left: 52px;" id="d-content-ButtonLogin"
                                                    class="d-content">
                                                    用户名不能为空！</div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div class="alogin_bg">
        <div class="warp">
            <div class="logo">
            </div>
            <div class="admin_login_box" style="position: relative;">
                <div class="ad">
                    <ul class="admin_login">
                        <li class="left_txt">
                            <asp:Label ID="LabelLoginID" runat="server" Text="用户名："></asp:Label>
                        </li>
                        <li class="right_input">
                            <asp:TextBox ID="TextBoxLoginID" runat="server" CssClass="text"></asp:TextBox>
                        </li>
                        <li class="left_txt">
                            <asp:Label ID="LabelPwd" runat="server" Text=""></asp:Label>
                            密&nbsp;码： </li>
                        <li class="right_input">
                            <asp:TextBox ID="TextBoxPwd" runat="server" CssClass="text" TextMode="Password" onkeydown="if(event.keyCode==13){document.getElementById('<%= ButtonLogin.ClientID %>').focus();document.getElementById('<%= ButtonLogin.ClientID %>').click();}"></asp:TextBox>
                        </li>
                    </ul>
                </div>
                <div>
                    <div class="code_left">
                        <asp:Label ID="LabelCheckCode" runat="server" Text="验证码："></asp:Label>
                    </div>
                    <div class="code_rigth">
                        <input name="verifycode" type="text" value="请输入验证码" onfocus=" this.value = '' " class="txtcode"
                            onkeydown=" if (event.keyCode == 13) {document.getElementById('<%= ButtonLogin.ClientID %>').focus();document.getElementById('<%= ButtonLogin.ClientID %>').click();} " />
                        <img id="ImgCode" src="AdminImgCode.aspx" onclick=" javascript:this.src = 'AdminImgCode.aspx?' + Math.random(); "
                            width="56" height="22" style="height: 22px; overflow: hidden; position: relative;
                            top: 5px;" />
                        <a onclick=" reloadcode() " class="on" style="cursor: pointer;">看不清楚？点一下</a>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="adminbtn" style="margin-top: 5px; *margin-top: 2px; margin-top: 2px\9;
                    position: absolute; right: 20px; top: 0px; _margin-top: 2px;">
                    <asp:Button ID="ButtonLogin" runat="server" OnClick="ButtonLogin_Click" Text="登录"
                        CssClass="bt3" OnClientClick=" return check(); " />
                    <img src="../../Images/ajax_loading.gif" />
                    <asp:Label ID="Message" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <p class="copyright">
            Powered by <a href="http://www.t.com" target="_blank"></a>Copyright (C) 2010-2014,
            All Rights Reserved
        </p>
    </div>
    </form>
</body>
</html>
