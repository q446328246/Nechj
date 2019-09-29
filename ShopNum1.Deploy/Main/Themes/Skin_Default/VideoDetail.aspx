<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" %>

<%@ Import Namespace="ShopNum1.Common" %>
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
    <!--head Start-->
    <!-- #include file="headShop.aspx" -->
    <!--//head End-->
    <!--main Start-->
    <div class="FlowCat_cont">
        <div class="warp_site">
            首页 》<a href="/video.aspx">商城视频</a>》视频详细</div>
        <div class="article_cont clearfix">
            <div class="list_left fl">
                <!-- 相关视频 -->
                <div class="store_category_view">
                    <h3>
                        相关视频</h3>
                    <ShopNum1:VideoRelativelyList ID="VideoRelativelyList" ShowCount="1" runat="server"
                        SkinFilename="VideoRelativelyList.ascx" />
                </div>
                <!-- 热点视频 -->
                <div class="store_category_view">
                    <h3>
                        热点视频</h3>
                    <ShopNum1:VideoIsHotList ID="VideoIsHotList" ShowCount="3" runat="server" SkinFilename="VideoIsHotList.ascx" />
                </div>
            </div>
            <div class="list_right fr">
                <div class="VideoInfoBox">
                    <div class="VideoDetail fl">
                        <ShopNum1:VideoDetail ID="VideoDetail" runat="server" SkinFilename="VideoDetail.ascx" />
                    </div>
                    <div class="VideoRela fr">
                        <div class="store_category_view">
                            <h3>
                                视频信息</h3>
                            <div class="announ_list VideoRela_info">
                                <ShopNum1:VideoDetail ID="VideoInfo" runat="server" SkinFilename="VideoInfo.ascx" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="DiscussBox">
                    <!-- 评论列表 -->
                    <ShopNum1:VideoCommentList ID="VideoCommentList" runat="server" ShowCount="10" SkinFilename="VideoCommentList.ascx" />
                    <!-- 发表评论 -->
                    <div class="CommentsAdd">
                        <h1 class="CommentsAdd_title">
                            <span>发表评论</span></h1>
                        <ShopNum1:VideoCommentAdd ID="VideoCommentAdd" runat="server" SkinFilename="VideoCommentAdd.ascx" />
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
