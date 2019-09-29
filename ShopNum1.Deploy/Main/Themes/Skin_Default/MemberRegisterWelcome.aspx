<%@ Page Language="C#" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
    <form id="from1" runat="server">
    <!--head start-->
	<div id="top">
        <div class="top_box">
            <div class="logo_login">
                塘江国际电子商务中心</div>
        </div>
    </div>
    <!--main start-->
    <div class="FlowCat_cont">
        <div class="article_cont" style="border: 1px solid #CCCCCC; width: 998px;">
            <ShopNum1:MemberRegisterWelcome ID="MemberRegisterWelcome" runat="server" SkinFilename="MemberRegisterWelcome.ascx" />
            <!--底部帮助-->
        </div>
        <ShopNum1:HelpListButtom ID="HelpListButtom" ShowCount="6" SkinFilename="HelpListButtom.ascx"
            runat="server" />
        <ShopNum1:LinkList ID="LinkList" runat="server" ShowCount="10" SkinFilename="LinkList.ascx" />
    </div>
    <!--foot start-->
    <div class="wrapBox FootMessage">
        <ShopNum1:Bottom ID="Bottom" runat="server" SkinFilename="Bottom.ascx" class="foot_bg" />
    </div>
    <!--foot end-->
    </form>
</body>
</html>
