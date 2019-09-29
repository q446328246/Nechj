<%@ Page Language="C#" AutoEventWireup="true" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
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
    <div class="FlowCat_cont">
        <div class="article_cont">
            <!-- left -->
            <div class="list_left fl">
                <!--店铺分类-->
                <ShopNum1:ShopCategory ID="ShopCategory1" runat="server" SkinFilename="ShopCategory.ascx" />
            </div>
            <!-- left end -->
            <!-- right -->
            <div class="list_right fr">
                <%-- 明星--%>
                <ShopNum1:ShopEspecialSeach ID="ShopEspecialSeach1" runat="server" SkinFilename="ShopEspecialSeach.ascx"
                    ShowCount="10" Title="明星店铺" ShopType="IsHot" />
                <%-- 推荐--%>
                <ShopNum1:ShopEspecialSeach ID="ShopEspecialSeach2" runat="server" SkinFilename="ShopEspecialSeach.ascx"
                    ShowCount="10" Title="推荐店铺" ShopType="IsRecommend" />
                <%-- 人气--%>
                <ShopNum1:ShopEspecialSeach ID="ShopEspecialSeach3" runat="server" SkinFilename="ShopEspecialSeach.ascx"
                    ShowCount="10" Title="人气店铺" ShopType="IsVisits" />
            </div>
        </div>
    </div>
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--foot end-->
    </form>
</body>
</html>
