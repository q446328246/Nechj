<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<script type="text/javascript" src="Themes/Skin_Default/js/jquery.min.js"></script>
<script type="text/javascript">

    $(function () {
        $("#headtest2").hover(
            function () {
                $(this).addClass("huaguo2");

            },
            function () {
                $(this).removeClass("huaguo2");
            }
        );
    });
    $(function () {
        $("#headtest3").hover(
            function () {
                $(this).addClass("huaguo3");

            },
            function () {
                $(this).removeClass("huaguo3");
            }
        );
    });

    function addFav() {
        var sitedomain = '<%=ShopUrlOperate.GetSiteDomain() %>';
        if (document.all) {
            try {
                window.external.addFavorite(sitedomain, document.title);
            }
            catch (e1) {
                try {
                    window.external.addToFavoritesBar(sitedomain, document.title);
                }
                catch (e2) {
                    alert('请使用按键 Ctrl+D收藏本网站');
                }
            }
        }
        else if (window.sidebar) {
            window.sidebar.addPanel(document.title, sitedomain, "");
        }
        else {
            alert('请使用按键 Ctrl+D收藏本网站');
        }

    }
    function setHomepage() {
        var sitedomain = '<%=ShopUrlOperate.GetSiteDomain() %>';
        if (document.all) {
            document.body.style.behavior = 'url(#default#homepage)';
            document.body.setHomePage(sitedomain);
        }
        else if (window.sidebar) {
            if (window.netscape) {
                try {
                    netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
                    var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);
                    prefs.setCharPref('browser.startup.homepage', sitedomain);
                }
                catch (e) {
                    alert("您的浏览器未启用[设为首页]功能，开启方法：先在地址栏内输入about:config,然后将选项 signed.applets.codebase_principal_support 值该为true即可");
                }
            }

        }
    }
</script>
<script type="text/javascript">
    function addFav() {
        if (document.all) {

            try {
                window.external.addFavorite('<%=AgentHead.SetAgentUrl()%>', document.title);
            }
            catch (e1) {
                try {
                    window.external.addToFavoritesBar('<%=AgentHead.SetAgentUrl()%>', document.title);
                }
                catch (e2) {
                    alert('请使用按键 Ctrl+D收藏本网站');
                }
            }
        }
        else if (window.sidebar) {
            window.sidebar.addPanel(document.title, '<%=AgentHead.SetAgentUrl()%>', "");
        }
        else {
            alert('请使用按键 Ctrl+D收藏本网站');
        }

    }
    function setHomepage() {
        if (document.all) {
            document.body.style.behavior = 'url(#default#homepage)';
            document.body.setHomePage('<%=AgentHead.SetAgentUrl()%>');
        }
        else if (window.sidebar) {
            if (window.netscape) {
                try {
                    netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
                }
                catch (e) {
                    alert("您的浏览器未启用[设为首页]功能，开启方法：先在地址栏内输入about:config,然后将选项 signed.applets.codebase_principal_support 值该为true即可");
                }
            }
        }
    }
</script>
<script type="text/javascript">
//<![CDATA[
    var theForm = document.forms[0];
    if (!theForm) {
        theForm = document.form1;
    }
    function RedirectCart(eventTarget) {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
            theForm.secondEVENTTARGET.value = eventTarget;
            theForm.submit();
        }
    }
//]]>
</script>
<script type="text/javascript">

    $(function () {
        //鼠标划入时
        $('#DivShangcheng').hover
    (
            function () {
                $(this).children('div').show();
                $(this).children('span').css("color", "#780002");
            },
        //鼠标移除时
            function () {
                $(this).children('div').hide();
                $(this).children('span').css("color", "");
            }
     );


        //鼠标划入时
        $('#DivGouwuche').hover
    (
            function () {
                $(this).children('div').show();
                $(this).children('span').css("color", "#780002");
            },
        //鼠标移除时
            function () {
                $(this).children('div').hide();
                $(this).children('span').css("color", "");
            }
     );
    })
</script>
<div id="site_nav">
    <div class="sn_bg">
        <div class=" sn_bg_right">
        </div>
    </div>
    <div class="sn_bd">
        <b class="sn_edge"></b>
        <div class="sn_container">
            <div class="sn_login_info" style="display: inline;">
                <div id="islogin" runat="server">
                    欢迎光临！<asp:Label ID="LabelMemLoginID" runat="server"></asp:Label>， 您可以登录<asp:Literal
                        ID="LiteralMemberUrl" runat="server" Text="【个人中心】"></asp:Literal>
                    <asp:LinkButton ID="LinkButtonLoginExit" runat="server">【退出】</asp:LinkButton>
                </div>
                <span id="unlogin" runat="server"><span class="sog">欢迎光临！请<a href='<%= ShopUrlOperate.GetShopLoginGoBack() %>'>登录</a>
                </span>
            </div>
            <ul class="sn_quick_menu" style="width: 350px;">
                <li class="sn_mytaobao menu_item">
                    <div class="menu_hd" style="margin-top: 2px;">
                        <a href='<%= ShopUrlOperate.RetUrl("default") %>' style="color: #F2DCC7;">返回首页</a>
                    </div>
                </li>
                <li class="sn_mytaobao menu_item">
                    <div class="menu_hd" style="margin-top: 2px;">
                        <a href="javascript:void(0)" onclick="addFav()" style="color: #F2DCC7;">添加收藏</a>
                    </div>
                </li>
                <li class="sn_mytaobao menu_item">
                    <div class="menu_hd" style="margin-top: 2px;">
                        <a href='<%= ShopUrlOperate.RetUrl("HelpListIndex") %>' style="color: #F2DCC7;">帮助中心</a></div>
                </li>
                <li class="sn_mytaobao menu_item">
                    <div id="headtest2" class="menu_hd menu_hd1" style="_zoom: 1;">
                        <a href='<%= ShopUrlOperate.RetUrl("Login") %>'>我的商城</a>
                        <div class="wdsc fl" style="height: 135px; width: 224px; padding-top: 2px; z-index: 999999;">
                            <!--已经退出状态-->
                            <div class="sub_wdsc" runat="server" visible="true" id="loginTwo">
                                <div class="qdl" style="height: 40px;">
                                    <table cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td style="color: #333; font-size: 12px; padding: 10px 0 0 10px;">
                                                您好，请登录！
                                            </td>
                                            <td style="padding-top: 6px;">
                                                <a href='<%= ShopUrlOperate.RetUrl("Login") %>'>
                                                    <img src="Themes/Skin_Default/Images/lmf_denglu.jpg" /></a>
                                            </td>
                                            <td style="padding-top: 6px; padding-left: 6px;">
                                                <a href='<%= ShopUrlOperate.RetUrl("MemberRegister") %>'>
                                                    <img src="Themes/Skin_Default/Images/lmf_zhuce.jpg" /></a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="qd_bg">
                                    <div class="cldd">
                                        <a href='<%= ShopUrlOperate.RetUrl("index") %>?shopurl=OrderList.aspx' style="color: #333333;">
                                            待处理订单</a></div>
                                    <div class="zxhf">
                                        <a href='<%= ShopUrlOperate.RetUrl("index") %>?shopurl=MemberProductCommentList.aspx'
                                            style="color: #333333;">咨询回复</a></div>
                                    <div class="wddd">
                                        <a href='<%= ShopUrlOperate.RetUrl("index") %>?shopurl=OrderList.aspx' style="color: #333333;">
                                            我的订单</a></div>
                                    <div class="wdjf">
                                        <a href='<%= ShopUrlOperate.RetUrl("index") %>?shopurl=ChangeScoreModifyLog.aspx'
                                            style="color: #333333;">我的红包</a></div>
                                    <div style="clear: both; font-size: 0; height: 0; line-height: 0;">
                                    </div>
                                </div>
                            </div>
                            <!--已经登录状态-->
                            <div runat="server" visible="true" id="loginOutTwo" class="lambert_sub">
                                <div style="padding: 0 10px;">
                                    您好，<a style="background: none; color: #333333; display: inline-block; position: relative;
                                        top: 1px; width: 50px; overflow: hidden;" href='<%= ShopUrlOperate.RetUrl("Index") %>'>
                                        <asp:Label ID="LabelMemLoginIDTwo" runat="server" /></a>，欢迎来到多用户商城！ <a href="loginOut.aspx"
                                            style="display: inline; color: #ffffff; display: none">退出</a>
                                </div>
                                <div class="qd_bg" style="margin-top: 10px;">
                                    <ul class="fore1 fl" style="margin-top: 6px;">
                                        <li style="width: 76px; text-align: center;"><a href='<%= ShopUrlOperate.RetUrl("index") %>?shopurl=OrderList.aspx'
                                            style="color: #333333;">待处理订单32423432</a> </li>
                                        <li style="width: 76px; text-align: center; margin-left: 15px;"><a href='<%= ShopUrlOperate.RetUrl("index") %>?shopurl=OrderList.aspx'
                                            style="color: #333333;">我的订单32423</a></li>
                                    </ul>
                                    <ul class="fore2 fl" style="margin-top: 6px;">
                                        <li style="width: 76px; text-align: center;"><a href='<%= ShopUrlOperate.RetUrl("index") %>?shopurl=MemberProductCommentList.aspx'
                                            style="color: #333333;">咨询回复</a></li>
                                        <li style="width: 76px; text-align: center; margin-left: 15px;"><a href='<%= ShopUrlOperate.RetUrl("index") %>?shopurl=ChangeScoreModifyLog.aspx'
                                            style="color: #333333;">我的红包</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
                <li class="sn_mytaobao menu_item" style="background: none;">
                    <div id="headtest3" class="menu_hd menu_hd2" style="width: 60px; _zoom: 1;">
                        <a href='<%= ShopUrlOperate.RetUrl("Login") %>'>我的购物车</a>
                        <div class="wdgwc fr">
                            <div class="sub_wdsc1">
                                <a class="cartenet" href="<%= ShopUrlOperate.RetUrl("ShoppingCart1") %>">
                                    <div class="qdl1" id="shopcart1" runat="server" style="padding: 10px; color: #780002;">
                                        购物车中还没有商品，赶紧选购吧！
                                    </div>
                                    <div id="shopcart2" runat="server" style="padding: 10px; color: #780002;">
                                        购物车共<asp:Literal ID="LiteralCartCount" runat="server" Text="0"></asp:Literal><span
                                            style="display: inline; color: #780002;">件商品</span>
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>
                </li>
            </ul>
        </div>
    </div>
</div>
<div id="mallHome">
    <div id="header">
        <div class="headerCon" style="_zoom: 1;">
            <h1 id="mallLogo">
                <a href='<%= "http://"+ ShopSettings.siteDomain%>'>
                    <img id="ImageOriginalImge" src="" runat="server" height="74" width="407" />
                </a>
            </h1>
            <div style="width: 482px; float: right;">
                <!--搜索-->
                <div class="mallSearch" id="mallSearch">
                    <ShopNum1Shop:TopSearch ID="TopSearch" runat="server" SkinFilename="AgentAllSearch.ascx" />
                </div>
            </div>
        </div>
    </div>
    <input type="hidden" name="secondEVENTTARGET" id="secondEVENTTARGET" value="" />
</div>
