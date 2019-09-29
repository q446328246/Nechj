<%@ Page Language="C#" AutoEventWireup="true" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
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
    <!--[if lte IE 6]>
<script src="Js/DD_belatedPNG_0.0.8a.js" type="text/javascript"></script>
    <script type="text/javascript">
        DD_belatedPNG.fix('*');
    </script>
<![endif]-->
</head>
<style type="text/css">
    .container, .tips-top, .w960
    {
        width: 1190px !important;
    }
</style>
<body>
    <form id="form1" runat="server">
    <!--head Start-->
    <div class="wrapBox ExpressHead">
        <div class="fl">
            <a href="Default.aspx">
                <ShopNum1:Logo ID="Logo" runat="server" SkinFilename="Logo.ascx" />
            </a>
        </div>
        <div class="fr">
            <ul class="clearfix">
                <li>
                    <p>
                        <a href="Default.aspx">
                            <img src="Themes/Skin_Default/Images/kuaidi_top1.jpg" /></a></p>
                    <p>
                        <a href="Default.aspx">首页</a></p>
                </li>
                <li>
                    <p>
                        <a href="member/m_index.aspx">
                            <img src="Themes/Skin_Default/Images/kuaidi_top2.jpg" /></a></p>
                    <p>
                        <a href="member/m_index.aspx">会员中心</a></p>
                </li>
                <li>
                    <p>
                        <a href="ShoppingCart1.aspx">
                            <img src="Themes/Skin_Default/Images/kuaidi_top3.jpg" /></a></p>
                    <p>
                        <a href="ShoppingCart1.aspx">我的购物车</a></p>
                </li>
                <li>
                    <p>
                        <a href="member/m_index.aspx?tomurl=M_MyCollect.aspx">
                            <img src="Themes/Skin_Default/Images/kuaidi_top4.jpg" /></a></p>
                    <p>
                        <a href="Default.aspx">我的收藏</a></p>
                </li>
            </ul>
        </div>
        <div class="clear">
        </div>
    </div>
    <!--main start-->
    <div class="FlowCat_cont">
        <iframe name="kuaidi100" src="http://www.kuaidi100.com/frame/index.html" width="1190"
            height="880" marginwidth="0" marginheight="0" hspace="0" vspace="0" frameborder="0"
            scrolling="no"></iframe>
    </div>
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--foot end-->
    </form>
</body>
</html>
