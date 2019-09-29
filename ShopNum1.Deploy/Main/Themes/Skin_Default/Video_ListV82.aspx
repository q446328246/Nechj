<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <!--head Start-->
    <!-- #include file="headShop.aspx" -->
    <!--//head End-->
    <!--main Start-->
    <div class="FlowCat_cont">
        <div class="warp_site">
            首页 》商城视频</div>
        <div class="article_cont clearfix">
            <div class="list_left fl">
                <!-- 视频分类 -->
                <div class="store_category_view">
                    <h3>
                        视频分类</h3>
                    <div class="announ_list">
                        <ShopNum1:VideoCategory ID="VideoCategory" ShowCount="10" runat="server" SkinFilename="VideoCategory.ascx" />
                    </div>
                </div>
                <!-- 推荐视频 -->
                <div class="store_category_view">
                    <h3>
                        推荐视频</h3>
                    <div class="announ_list">
                        <ShopNum1:VideoIsRecommendList ID="VideoIsRecommendList" ShowCount="10" runat="server"
                            SkinFilename="VideoIsRecommendList.ascx" />
                    </div>
                </div>
                <!-- 热点视频 -->
                <div class="store_category_view">
                    <h3>
                        热点视频</h3>
                    <ShopNum1:VideoIsHotList ID="VideoIsHotList1" ShowCount="3" runat="server" SkinFilename="VideoIsHotList.ascx" />
                </div>
            </div>
            <div class="list_right fr">
                <!-- 推荐视频 -->
                <div class="precont VideoBox">
                    <div class="all_top">
                        <span class="latest_shop1 fl">视频列表</span></div>
                    <div class="preshow clearfix">
                        <ShopNum1:VideoList ID="VideoList" runat="server" SkinFilename="VideoList.ascx" PageCount="20" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--//main End-->
    <!--foot Start-->
    <!-- #include file="foot1.aspx" -->
    <!--//foot End-->
    </form>
    <!--js-->
    <script src="/js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="/js/load.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8">
        $(function () {
            $("#article_cont img").lazyload({ placeholder: "/Images/grey.gif" });
        });
    </script>
</body>
</html>
