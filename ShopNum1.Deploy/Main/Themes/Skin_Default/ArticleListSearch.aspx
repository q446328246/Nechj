<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Themes/Skin_Default/Js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //咨询搜索 标题
            var ArticlesSearch = $("#ArticleSearch1_ctl00_HiddenFieldSearchName").val();
            $("#A_ArticlesSearch").html(ArticlesSearch);
            $(".art_right").children("h3").html(ArticlesSearch);

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
    <!-- #include file="headnews.aspx" -->
    <!--//head End-->
    <!--main Start-->
    <div class="FlowCat_cont">
        <div class="site_img">
            <a href="#">
                <ShopNum1:AdSimpleImage ID="AdSimpleImage41" runat="server" AdImgId="41" SkinFilename="AdSimpleImage.ascx" />
            </a>
        </div>
        <div class="warp_site">
            <a href="default.aspx">首页</a> 》<a href="#">资讯</a></div>
        <div class="article_cont">
            <!--left start-->
            <div class="list_left fl">
                <!--最新资讯-->
                <ShopNum1:ArticleNewList ID="ArticleNewList1" runat="server" SkinFilename="ArticleNew.ascx"
                    Title="最新资讯" ShowCount="11" />
                <!--商品销售排行-->
                <ShopNum1:DeProductOrder ID="DeProductOrder1" runat="server" SkinFilename="DeProductOrder.ascx"
                    OrderType="SaleNumber" ShowCount="4" Title="销售排行" />
            </div>
            <!--资讯列表-->
            <div class="list_right fr">
                <!--资讯列表-->
                <ShopNum1:ArticleSearch ID="ArticleSearch1" runat="server" SkinFilename="ArticleSearch.ascx"
                    PageSize="6" />
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
