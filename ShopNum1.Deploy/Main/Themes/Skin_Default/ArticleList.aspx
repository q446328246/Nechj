<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" %>


<%@ OutputCache CacheProfile="CommomPage" VaryByParam="None" %>
<%@ Import Namespace="ShopNum1.Common" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto" runat="server" Type="1" SkinFilename="Meto.ascx" />
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
    <form id="from1" runat="server">
    <!--head Start-->
    <!-- #include file="headShop.aspx" -->
    <!--//head End-->
    <!--main Start-->
    <div class="FlowCat_cont clearfix">
        <div class="article_cont">
            <!--left Start-->
            <div class="list_left fl">
                <div class="store_category_view">
                    <!--文章分类-->
                    <ShopNum1:AriticleCategory ID="articlecategory" runat="server" SkinFilename="AriticleCategory.ascx"
                        ShowCountOne="10" ShowCountTwo="10" ShowCountThree="10" />
                    <ShopNum1:ArticleListSearch ID="ArticleListSearch1" runat="server" SkinFilename="ArticleListSearch1.ascx" />
                </div>
            </div>
            <!--//left End-->
            <!-- right Start-->
            <div class="list_right fr">
                <!--文章列表-->
                <ShopNum1:ArticleListSearch ID="ArticleListSearch" runat="server" SkinFilename="ArticleListSearch.ascx" />
            </div>
            <!-- //right End-->
            <div class="clear">
            </div>
        </div>
    </div>
    <!--//main End-->
    <!--foot Start-->
    <!-- #include file="foot1.aspx" -->
    <!--//foot End-->
    </form>
</body>
</html>
