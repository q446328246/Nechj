<%@ Import Namespace="ShopNum1.Common" %>
<script type="text/javascript" language="javascript">
    var nofind = '<%=GetPageName.RetUrl("nofindsearch")%>';
</script>
<script type="text/javascript" language="javascript" src="/Main/JS/jquery-1.6.2.min.js"></script>
<script type="text/javascript" language="javascript" src="/Main/JS/headtop.js"></script>
<!--首页搜索切换JS-->
<!--悬浮三级分类 显示隐藏-->
<script type="text/javascript">
    $(document).ready(function () {
        $("#FlowCate").mouseover(function () {
            $("#ThrCategory").show(); $("#ThrCategory").focus();
        }).mouseout(function () { $("#ThrCategory").hide(); });
        $("#ThrCategory").mouseover(function () { $("#ThrCategory").show(); }).mouseout(function () { $("#ThrCategory").hide(); });
    });
</script>
<!--head Start 头部开始-->
<input type="hidden" id="hidv" value="" />
<!--site Start-->
<div id="site">
    <!--site_nav Start-->
    <div id="site_nav">
        <div class="sn_bg">
            <div class=" sn_bg_right">
            </div>
        </div>
        <div class="sn_bd">
            <b class="sn_edge"></b>
            <ShopNum1:WelcomeControl ID="WelcomeControl" runat="server" />
        </div>
    </div>
    <!--//site_nav End-->
    <!--mallHome Start-->
    <div id="mallHome">
        <div id="header">
            <div class="headerCon">
                <!--头部Logo Start-->
                <h1 id="mallLogo">
                    <ShopNum1:Logo ID="Logo" runat="server" SkinFilename="Logo.ascx" />
                </h1>
                <!--//头部Logo End-->
                <!--头部搜索 Start-->
                <div class="topsearch">
                    <div class="mallSearch" id="mallSearch">
                        <!--<div class="switchover">
                            <ul>
                                <li><a id="hh1" class="cur" onclick="chang(1)">宝贝</a></li>
                                <li><a id="hh2" class="" onclick="chang(2)">店铺</a> </li>
                                <li><a id="hh3" class="" onclick="chang(3)">资讯</a> </li>
                                <li><a id="hh4" class="" onclick="chang(4)">供求</a> </li>
                            </ul>
                        </div>-->
                        <!--热门搜索-->
                        <div class="KeyWords clearfix">
                            <ShopNum1:KeyWords ID="keyWords" runat="server" SkinFilename="KeyWords.ascx" />
                        </div>
                        <div class="FormBox">
                            <span class="span_title">搜索</span>
                            <div class="mallSearch_input clearfix">
                                <label for="mq">
                                </label>
                                <input class="txtinput" type="text" name="textfield" onkeydown="KeyEnter(event)"
                                    id="textfield" maxlength="50" accesskey="s" autocomplete="off"
                                    autofocus="true" x-webkit-speech="" x-webkit-grammar="builtin:search" />
                                <input id="ButtonSearch" type="button" class="search_buttom" onclick="javascript:searchgo(0,'')"
                                    value="" />
                            </div>
                        </div>
                    </div>
                    <!--搜索提示-->
                    <div class="ll_all_search">
                        <ul class="ll_xiala">
                        </ul>
                        <ul class="checktag">
                        </ul>
                    </div>
                    <asp:hiddenfield id="HiddenSwitchType" runat="server" value="1" />
                </div>
                <!--//头部搜索 End-->
                <!--头部联系方式-->
                <div class="tel">
                    <img src="Themes/Skin_Default/images/weixin.png" />
                    <img src="Themes/Skin_Default/images/tel.png" />
                </div>
            </div>
        </div>
    </div>
    <!--//mallHome End-->
</div>
<!--//site End-->
<!--悬浮三级分类 Start-->
<div class="ny_headcate">
    <div class="ThrCategory_fwr">
        <div id="FlowCate">
        </div>
        <div class="FlowCategory_main" id="ThrCategory">
            <ShopNum1:ProductThreeCategoryDefault ID="ProductThreeCategory11" runat="server"
                ShowOneCount="16" ShowTwoCount="1000" ShowThreeCount="1000" SkinFilename="ProductFwThreeCategory.ascx" />
        </div>
    </div>
</div>
<!--//悬浮三级分类 End-->
<!--MiddleNavigationControl Start 中部导航开始-->
<ShopNum1:MiddleNavigationControl ID="MiddleNavigationControl" runat="server" />
<!--//MiddleNavigationControl End 中部导航结束-->
<!--//head End 头部结束-->
<!--[if lte IE 6]>
<script src="Themes/Skin_Default/Js/DD_belatedPNG_0.0.8a.js" type="text/javascript"></script>
    <script type="text/javascript">
        DD_belatedPNG.fix('div, ul, img, li, input , a, *');
    </script>
<![endif]-->
