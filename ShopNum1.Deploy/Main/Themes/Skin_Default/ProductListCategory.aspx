<%@ Page Language="C#" AutoEventWireup="true" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
</head>
<body>
    <form id="form1" runat="server">
    <!--head start-->
    <!-- #include file="headShop.aspx" -->
    <!--main start-->
    <div class="warp clearfix">
        <!--left start-->
        <div class="sidebar fl">
        </div>
        <!--商品分类-->
        <ShopNum1:ProductCategory ID="ProductCategory1" runat="server" SkinFilename="ProductCategory.ascx" />
        <%-- 商品品牌分类搜索--%>
        <ShopNum1:ProductBrandCategorySearch ID="ProductBrandCategorySearch" runat="server"
            SkinFilename="ProductBrandCategorySearch.ascx" />
        <%--品牌列表--%>
        <ShopNum1:Brand ID="Brand" runat="server" SkinFilename="Brand.ascx" ShowCount="10" />
    </div>
    <!--main end-->
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--foot End-->
    </form>
</body>
</html>
