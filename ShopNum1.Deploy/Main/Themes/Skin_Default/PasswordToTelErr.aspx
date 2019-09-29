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
    <form id="from1" runat="server">
    <!--head start-->
    <!-- #include file="headShop.aspx" -->
    <!--main start-->
    <!-- position -->
    <div class="FlowCat_cont">
        <div class="position">
            所在位置:<a href="Default.aspx">首页</a> > 找回密码</div>
        <!-- middle -->
        <div class="article_cont">
            <div id="divAgainLogin" runat="server" class="regester1" style="height: auto">
                <div class="regester_top">
                    手机找回密码</div>
                <!-- 隔开 -->
                <div class="cle" style="width: 700px; height: 18px; line-height: 18px; overflow: hidden;
                    font-size: 18px;">
                </div>
                <ShopNum1:PasswordToTelErr ID="PasswordToTelErr" runat="server" SkinFilename="PasswordToTelErr.ascx" />
            </div>
            <!-- 隔开 -->
            <div class="cle" style="width: 960px; margin: 0 auto; height: 8px; line-height: 8px;
                overflow: hidden; font-size: 8px;">
            </div>
        </div>
        <!--底部帮助-->
        <ShopNum1:HelpListButtom ID="HelpListButtom" ShowCount="5" SkinFilename="HelpListButtom.ascx"
            runat="server" />
        <ShopNum1:LinkList ID="LinkList" runat="server" ShowCount="10" SkinFilename="LinkList.ascx" />
    </div>
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--foot End-->
    </form>
</body>
</html>
