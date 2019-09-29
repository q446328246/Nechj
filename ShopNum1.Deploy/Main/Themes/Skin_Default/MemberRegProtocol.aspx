<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" %>


<%@ Import Namespace="ShopNum1.Common" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Themes/Skin_Default/Js/jquery.min.js" type="text/javascript"></script>
    <link href="Themes/Skin_Default/inc/Style/top.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
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
</head>
<body>
    <form id="form1" runat="server">
    <!--head Start-->
    <div id="top">
        <div class="top_box">
            <div class="logo_login">
                塘江国际电子商务中心</div>
        </div>
    </div>
    <!--//head End-->
    <!--main Start-->
    <div class="FlowCat_cont clearfix">
        <div class="warp_site">
            <a href="Default.aspx">首页</a> 》<a>用户协议</a></div>
        <div>
            <ShopNum1:MemberRegProtocol ID="MemberRegProtocol" runat="Server" SkinFilename="MemberRegProtocol.ascx" />
        </div>
    </div>
    <!--//main End-->
    <!--foot Start-->
    <div class="wrapBox FootMessage">
        <ShopNum1:Bottom ID="Bottom" runat="server" SkinFilename="Bottom.ascx" class="foot_bg" />
    </div>
    <!--//foot End-->
    </form>
    <script src="Themes/Skin_Default/js/jquery-1.4.4.min.js" type="text/javascript"></script>
</body>
</html>
