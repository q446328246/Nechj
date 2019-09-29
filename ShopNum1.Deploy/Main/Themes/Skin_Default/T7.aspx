<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="T7.aspx.cs" Inherits="ShopNum1.Deploy.Main.T7" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <%--    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />--%>
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Themes/Skin_Default/js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="Themes/Skin_Default/js/jquery1.42.min.js"></script>
    <script type="text/javascript" src="Themes/Skin_Default/js/jquery.SuperSlide.2.1.1.js"></script>
    <link href="Themes/Skin_Default/Style/datouwang.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <!--head start-->
    <!-- #include file="headbak.aspx" -->
    <!--//head end-->
    <!--main start-->
    <%--    <ShopNum1:Advertisement ID="dd" SkinFilename="Advertisement.ascx" runat="server" />--%>
    <!-- 代码 开始 -->
    <div class="tmall_box">
        <div class="menu">
            <asp:Literal ID="literLi" runat="server"></asp:Literal>
        </div>
        <div id="tmall_nav">
            <!--左侧栏目开始-->
            <div class="tmall_cat_nav fl">
                <div class="tmall_mod_title">
                    商品服务分类</div>
                <asp:Literal ID="ltlProductCategory" runat="server"></asp:Literal>
            </div>
            <!--左侧栏目结束-->
            <!--右侧内容开始-->
            <div class="tmall_cat_content fr">
                <asp:Literal ID="lblSubProductCatogory" runat="server"></asp:Literal>
            </div>
            <!--右侧内容结束-->
        </div>
    </div>
    <script type="text/javascript">
        $(".cat_banner").hover(function () {
            $(this).find(".prev_pic,.next_pic").fadeTo("show", 0.2);
        }, function () {
            $(this).find(".prev_pic,.next_pic").hide();
        });
        $(".prev_pic,.next_pic").hover(function () {
            $(this).fadeTo("show", 0.5);
        }, function () {
            $(this).fadeTo("show", 0.2);
        });
        $(".cat_banner").slide({
            titCell: ".num ul",
            mainCell: ".cat_banner_pic",
            effect: "left",
            prevCell: ".prev_pic",
            nextCell: ".next_pic",
            autoPlay: true,
            interTime: 3000,
            delayTime: 500,
            autoPage: true
        });
        $(".cat_small_banner li").hover(function () {
            $(this).animate({ "left": -5 }, 200);
        }, function () {
            $(this).animate({ "left": 0 }, 200);
        });
        $(".cat_brand").slide({
            titCell: ".cat_slide_nav li",
            mainCell: ".cat_slide_brand",
            effect: "left",
            autoPlay: true,
            interTime: 3000,
            delayTime: 700
        });
        $("#tmall_nav").slide({
            titCell: ".cate_nav li",
            mainCell: ".tmall_cat_content",
            autoPlay: true,
            interTime: 7400,
            delayTime: 0
        });
    </script>
    <!-- 代码 结束 -->
    <ShopNum1:DefaultControl ID="DefaultControl" runat="server" />
    <!--//main end-->
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--foot end-->
    <!--js-->
    <script src="/js/load.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8">
        $(function () {
            $("#content img:not([class='imghdp'])").lazyload({ placeholder: "/ImgUpload/noImg.jpg" });
            $("img").each(function () { $(this).attr("src", $(this).attr("original")); });
        });
    </script>
    </form>
</body>
</html>
