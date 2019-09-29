<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default1.aspx.cs" Inherits="ShopNum1.Deploy.Main.Themes.Skin_Default.Default1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
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
    <ShopNum1:Advertisement ID="dd" SkinFilename="Advertisement.ascx" runat="server" />
    <!-- 代码 开始 -->
    <div class="banner-box">
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
            <!-- //最新推荐 End-->
            <div class="tsBottom_right fr">
                <!-- 仿京东 Start-->
                <div class="dropdown" id="dropdown">
                    <dl id="drop1" class="">
                        <dt><a href="javascript:void(0)" id="q0" class=""><b id="d0"></b><strong class="sh">
                            品牌担保</strong></a></dt>
                        <dd id="w0" class="d0">
                            <strong>品牌担保</strong>
                            <p>
                                在本多用户商城所购物品不仅有本公司进行全程监管，同时所支付的方式也可采用支付宝担保交易。</p>
                            <div class="extra">
                            </div>
                        </dd>
                    </dl>
                    <dl id="drop2">
                        <dt><a href="javascript:void(0)" id="q1" class="dd"><b id="d1"></b><strong class="sh">
                            市区免费送</strong></a></dt>
                        <dd id="w1">
                            <strong>市区免费送</strong>
                            <p>
                                凡是本多用户商城会员均可享受，但部分较偏远的地区除外，详见网站公示规则或与在线客服咨询。</p>
                            <div class="extra">
                            </div>
                        </dd>
                    </dl>
                    <dl id="drop3">
                        <dt><a href="javascript:void(0)" id="q2" class="ee"><b id="d2"></b><strong class="sh">
                            200%包赔</strong> </a></dt>
                        <dd id="w2">
                            <strong>200%包赔</strong>
                            <p>
                                客户按时支付成功，我们没有做任何处理，我们将100%全额退款，退回至客户指定帐户，或存入客户会员余额(可随时订购抵扣)，同时，和客户另协商配送时间，我们免费重新派送原订单。属于200%退赔。</p>
                            <div class="extra">
                            </div>
                        </dd>
                    </dl>
                    <div class="clear">
                    </div>
                </div>
                <!-- //仿京东 End-->
                <!-- 最新公告 Start-->
                <div class="newstw">
                    <ul class="newstw_top">
                        <li id="a0" class="aa" onmouseover="tab('a','b',0,2,'aa','bb')"><a>最新公告</a></li>
                        <li id="a1" class="bb" onmouseover="tab('a','b',1,2,'aa','bb')"><a>最新文章</a></li>
                    </ul>
                    <div class="newstw_con">
                        <div class="newcontain" id="b0" style="display: block;">
                            <ShopNum1:AnnouncementNewList ID="AnnouncementNewList" runat="server" SkinFilename="AnnouncementNewList.ascx" />
                        </div>
                        <div class="newcontain" id="b1" style="display: none;">
                            <ShopNum1:ArticleNewList ID="ArticleNewList" runat="server" SkinFilename="ArticleNewList.ascx" />
                        </div>
                    </div>
                </div>
                <!-- //最新公告 End-->
                <!-- 推荐品牌 Start-->
                <div class="menber">
                    <div class="menber_top">
                        <span class="huy">推荐品牌</span> <a href="BrandDetail.aspx" class="more">更多</a>
                    </div>
                    <div class="login1">
                        <ShopNum1:DeBrandList ID="DeBrandList1" runat="server" SkinFilename="DeBrandList1.ascx" />
                    </div>
                </div>
                <!--//推荐品牌 End-->
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
    </div>
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
