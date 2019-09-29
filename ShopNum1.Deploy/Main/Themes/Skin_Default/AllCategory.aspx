<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
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
    <!--head start-->
    <!-- #include file="headShop.aspx" -->
    <!--main start-->
    <div class="FlowCat_cont">
        <div class="article_cont">
            <!--left start-->
            <div class="sidebar fl">
            </div>
            <!--店铺分类-->
            <ShopNum1:ShopCategory ID="ShopCategory" runat="server" SkinFilename="ShopCategory.ascx" />
            <!--商品分类-->
            <ShopNum1:ProductCategory ID="ProductCategory" runat="server" SkinFilename="ProductCategory.ascx" />
            <%--资讯分类列表--%>
            <ShopNum1:ArticleCategoryList ID="ArticleCategoryList" runat="server" SkinFilename="ArticleCategoryList.ascx" />
            <!--分类信息分类-->
            <ShopNum1:CategoryInfoCategory ID="CategoryInfoCategory" runat="server" SkinFilename="CategoryInfoCategory.ascx" />
        </div>
    </div>
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--foot end-->
    </form>
</body>
</html>
