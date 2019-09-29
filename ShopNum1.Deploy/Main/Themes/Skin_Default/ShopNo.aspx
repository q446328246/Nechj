<%@ Page Language="C#" AutoEventWireup="true" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:ShopCategoryMeto ID="ShopCategoryMeto" runat="server" SkinFilename="ShopCategoryMeto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Themes/Skin_Default/Js/jquery.min.js" type="text/javascript"></script>
    <script src="/JS/baiduTemplate.js" type="text/javascript"></script>
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
    <!--站点地图-->
    <!-- middle -->
    <div class="FlowCat_cont">
        <div class="warp_site">
            <a href="default.aspx">首页</a> 》<a href="#">店铺没找到页面</a>
        </div>
        <div class="shopsearch">
            <div class="ser_brand shoptop">
                <div class="att_key">
                    店铺类目</div>
                <div class="att_values">
                    <ul class="att_ul" style="height: auto;">
                        <li><a href="#">服装鞋包(10)</a></li><li><a href="#">3C数码(5)</a></li><li><a href="#">美容护理(0)</a></li>
                        <li><a href="#">家居用品(6)</a></li><li><a href="#">食品/保健(12)</a></li><li><a href="#">母婴用品(10)</a></li>
                        <li><a href="#">文体/汽车(3)</a></li><li><a href="#">珠宝/首饰(7)</a></li><li><a href="#">收藏/爱好(1)</a></li>
                        <li><a href="#">生活/服务(19)</a></li>
                    </ul>
                </div>
            </div>
            <div class="shop_conts">
                <div class="paixu">
                    <span class="paispan">所在地：</span>
                    <div class="comArea">
                        <b class="comArea-text">请选择</b>
                        <div class="souzaidi-list" style="display: none;">
                            <a href="#">杭州</a><a href="#">武汉</a><a href="#">南京</a> <a href="#">北京</a><a href="#">福建</a><a
                                href="#">广州</a> <a href="#">上海</a><a href="#">南宁</a><a href="#">拉萨</a>
                        </div>
                    </div>
                    <%--排序--%>
                    <div class="shoppai">
                        <a href="#" class="mr" title="">默认</a> <a href="#" class="xl" title="">销量</a> <a
                            href="#" class="xy" title="">信用</a> <a href="#" class="rzsj" title="">入驻时间</a>
                    </div>
                    <div class="shoprigth">
                        店铺名称：<input type="text" name="txtname" class="shopinput" /><span class="xiant" style="display: none;"></span>
                        会员名称：<input type="text" name="txtmenber" class="shopinput" /><span class="xiant"
                            style="display: none;"></span>
                        <input type="button" name="btn" value="搜索" class="shopsbtn" />
                    </div>
                </div>
                <div class="shopno">
                    <span class="snoimg"></span>没有找到符合条件的店铺!
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
    </div>
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--foot end-->
    </form>
</body>
</html>
