<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:ShopCategoryMeto ID="ShopCategoryMeto" runat="server" SkinFilename="ShopCategoryMeto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
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
    <form id="form1" runat="server">
    <!--head Start-->
    <!-- #include file="headShop.aspx" -->
    <!--//head End-->
    <!-- main Start -->
    <div class="FlowCat_cont">
        <div class="warp_site">
            首页 》<a href="/WeiXinUserListV82.html">微信店铺</a></div>
        <div class="shopsearch">
            <!--店铺分类 店铺类目-->
            <ShopNum1:ShopCategoryCountV82 ID="ShopCategoryCountV82" runat="server" SkinFilename="ShopCategoryCountV82.ascx"
                ShowCountOne="60" />
            <!--店铺搜索结果-->
            <ShopNum1:WeiXinUserListV82 ID="WeiXinUserListV82" ShowCount="20" runat="server"
                SkinFilename="WeiXinUserListV82.ascx" />
        </div>
    </div>
    <!-- //main End -->
    <!--foot Start-->
    <!-- #include file="foot1.aspx" -->
    <!--//foot End-->
    </form>
</body>
</html>
<script src="/JS/baiduTemplate.js" type="text/javascript"></script>
