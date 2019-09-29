<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
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
            <%-- 店铺搜索--%>
            <%--<ShopNum1:ShopSearch ID="ShopSearch" runat="server" SkinFilename="ShopSearch.ascx" />--%>
            <%-- 明星店铺--%>
            <ShopNum1:ShopEspecialSeach ID="ShopEspecialSeach1" runat="server" SkinFilename="ShopEspecialSeach.ascx"
                ShowCount="10" Title="明星店铺" ShopType="IsHot" />
            <%-- 推荐店铺--%>
            <ShopNum1:ShopEspecialSeach ID="ShopEspecialSeach2" runat="server" SkinFilename="ShopEspecialSeach.ascx"
                ShowCount="10" Title="推荐店铺" ShopType="IsRecommend" />
            <%-- 人气店铺--%>
            <ShopNum1:ShopEspecialSeach ID="ShopEspecialSeach3" runat="server" SkinFilename="ShopEspecialSeach.ascx"
                ShowCount="10" Title="人气店铺" ShopType="IsVisits" />
            <%-- 最新店铺--%>
            <ShopNum1:ShopIsNew ID="ShopIsNew" runat="server" SkinFilename="ShopIsNew.ascx" ShowCount="10" />
        </div>
    </div>
    <!--main end-->
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--foot end-->
    </form>
</body>
</html>
