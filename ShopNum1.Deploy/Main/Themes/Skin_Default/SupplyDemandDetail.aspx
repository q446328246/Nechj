<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <%--<ShopNum1:SupplyDemandMeto ID="SupplyDemandMeto" runat="server" SkinFilename="SupplyDemandMeto.ascx" />--%>
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Js/jquery-1.6.2.min.js" type="text/javascript"></script>
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
    <div class="FlowCat_cont clearfix">
        <div class="warp_site">
            首页 》供求详情
        </div>
        <div class="supply_page demand">
            <!--供求详细（有个GuID参数）-->
            <ShopNum1:SupplyDemandDetail ID="SupplyDemandDetail" runat="server" SkinFilename="SupplyDemandDetail.ascx" />
            <!-- 隔开 -->
            <div class="UserReviews">
                <!-- 用户评论 -->
                <ShopNum1:SupplyDemandCommentList ID="SupplyDemandCommentList" runat="server" ShowCount="10"
                    SkinFilename="SupplyDemandCommentList.ascx" />
                <!--添加供求评论-->
                <ShopNum1:SupplyDemandCommentAdd ID="SupplyDemandCommentAdd" runat="server" SkinFilename="SupplyDemandCommentAdd.ascx" />
            </div>
        </div>
    </div>
    <!--main end-->
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--foot End-->
    </form>
</body>
</html>
