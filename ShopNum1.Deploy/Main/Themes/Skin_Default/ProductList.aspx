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
            <!--商品分类-->
            <ShopNum1:ProductCategory ID="ProductCategory1" runat="server" SkinFilename="ProductCategory.ascx" />
            <%-- 推荐--%>
            <ShopNum1:ProductEspecialSeach ID="ProductEspecialSeach1" runat="server" SkinFilename="ProductEspecialSeach.ascx"
                Title="本站推荐" ProductType="IsRecommend" ShowCount="10" />
            <%-- 精品--%>
            <ShopNum1:ProductEspecialSeach ID="ProductEspecialSeach2" runat="server" SkinFilename="ProductEspecialSeach.ascx"
                Title="精品展示" ProductType="IsBest" ShowCount="10" />
            <%-- 人气--%>
            <ShopNum1:ProductEspecialSeach ID="ProductEspecialSeach3" runat="server" SkinFilename="ProductEspecialSeach.ascx"
                Title="火热人气" ProductType="IsHot" ShowCount="10" />
            <%-- 最新--%>
            <ShopNum1:ProductEspecialSeach ID="ProductEspecialSeach4" runat="server" SkinFilename="ProductEspecialSeach.ascx"
                Title="新品上架" ProductType="IsNew" ShowCount="10" />
        </div>
    </div>
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--foot End-->
    </form>
</body>
</html>
