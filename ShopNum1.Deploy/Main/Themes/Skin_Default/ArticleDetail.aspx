<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" %>

<%@ Register TagPrefix="ShopNum1" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:ArticleMeto ID="ArticleMeto" runat="server" SkinFilename="ArticleMeto.ascx" />
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
    <ShopNum1:Form ID="Form1" method="post" runat="server">
        <!--head Start-->
        <!-- #include file="headShop.aspx" -->
        <!--//head End-->
        <!--main Start-->
        <div class="FlowCat_cont clearfix">
            <div class="warp_site">
                <a hfef="default.aspx">首页</a> 》<a href="#">资讯</a></div>
            <div class="article_cont">
                <!--left start-->
                <div class="list_left fl">
                    <ShopNum1:ArticleNewList ID="ArticleNewList1" runat="server" ShowCount="10" SkinFilename="ArticleNew.ascx"
                        Title="最新资讯" />
                    <!--商品销售排行
                    <ShopNum1:DeProductOrder ID="DeProductOrder1" runat="server" SkinFilename="DeProductOrder.ascx"
                        OrderType="SaleNumber" ShowCount="4" Title="销售排行" />-->
                </div>
                <!-- right -->
                <div class="list_right fr">
                    <%--资讯详细--%>
                    <ShopNum1:ArticleDetail ID="ArticleDetail" runat="server" SkinFilename="ArticleDetail.ascx" />
                    <div>
                        <ShopNum1:ArticleCommentLists ID="ArticleCommentLists" runat="server" SkinFilename="ArticleCommentLists.ascx" />
                        <ShopNum1:ArticleCommentAdd ID="ArticleCommentAdd" runat="server" SkinFilename="ArticleCommentAdd.ascx" />
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <!--//main End-->
        <!--foot Start-->
        <!-- #include file="foot1.aspx" -->
        <!--//foot End-->
    </ShopNum1:Form>
</body>
</html>
