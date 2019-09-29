<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>

<script type="text/javascript" src="/js/jquery-1.6.2.min.js"></script>
<script type="text/javascript">
var sitedomain='<%=ShopUrlOperate.GetSiteDomain() %>';
</script>
<script type="text/javascript" language="javascript" src="/main/js/shop1/head.js"></script>
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
<div id="site_nav">
    <div class="sn_bg">
        <div class="sn_bg_right"></div>
    </div>
    <div class="warp sn_bd">
        <b class="sn_edge"></b>
        <div class="sn_container">
            <div class="sn_login_info">
                <div id="islogin" runat="server">
                    欢迎光临！<asp:Label ID="LabelMemLoginID" runat="server"></asp:Label>，您可以登录<a href="http://<%=ShopSettings.siteDomain %>/main/member/m_index.aspx">【个人中心】</a>      <a href="http://<%=ShopSettings.siteDomain %>/main/loginOut.aspx">【退出】</a>
                </div>
                <span id="unlogin" runat="server">
                    <span class="sog">欢迎光临！请<a href='<%= ShopUrlOperate.GetShopLoginGoBack() %>'>登录</a></span>
                    <span><a href='<%= AgentHead.SetUrl("MemberRegister") %>' class="register">免费注册</a></span>
                </span>
            </div>
            <ul class="sn_quick_menu">
		        <li class="sn_mytaobao menu_item">
                    <div class="menu_hd">
                        <a href='<%= ShopUrlOperate.RetUrl("default") %>'">返回首页</a>
                    </div>
                </li>
                <li class="sn_mytaobao menu_item">
                    <div class="menu_hd">
                        <a href="javascript:void(0)" onclick="addFav()">添加收藏</a>
                    </div>
                </li>
                <li class="sn_mytaobao menu_item">
                      <div class="menu_hd">
                        <a href='<%= ShopUrlOperate.RetUrl("HelpListIndex") %>'>帮助中心</a></div>
                </li>
                <li class="sn_mytaobao menu_item">
                    <div id="headtest2" class="menu_hd menu_hd1 ie6top">
                        <a href='<%= ShopUrlOperate.RetUrl("Login") %>'>我的商城</a>
                        <div class="wdsc fl">
                            <!--已经退出状态-->
                            <div class="sub_wdsc" runat="server" visible="true" id="loginTwo">
                                <div class="qdl" style="display:none;">
                                    您好，请登录！
                                    <a class="btn_login" href='<%= ShopUrlOperate.RetUrl("Login") %>'>
                                        <img src="Themes/Skin_Default/Images/lmf_denglu.jpg" /></a>
                                    <a class="btn_register" href='<%= ShopUrlOperate.RetUrl("MemberRegister") %>'>
                                        <img src="Themes/Skin_Default/Images/lmf_zhuce.jpg" /></a>
                                </div>
                                <div class="qd_bg">
                                    <div class="cldd">
                                        <a href='/main/member/m_index.aspx?tomurl=M_MyCollect.aspx?type=0&pageid=1' target="_blank">我的收藏</a></div>
                                    <div class="zxhf">
                                        <a href='<%= ShopUrlOperate.RetMemberUrl("m_index") %>?tomurls=MemberProductCommentList.aspx'>咨询回复</a></div>
                                    <div class="wddd">
                                        <a href='<%= ShopUrlOperate.RetMemberUrl("m_index") %>?tomurls=OrderList.aspx'>我的订单</a></div>
                                    <div class="wdjf">
                                        <a href='<%= ShopUrlOperate.RetMemberUrl("m_index") %>?tomurls=ChangeScoreModifyLog.aspx'>我的积分</a></div>
                                    <div class="clear"></div>
                                </div>
                            </div>
                            <!--已经登录状态-->
                            <div runat="server" visible="true" id="loginOutTwo" class="lambert_sub">
                                <div class="qdl2" style="display:none;">
                                    您好，<a class="memberName" href='<%= ShopUrlOperate.RetMemberUrl("m_index") %>'>
                                        <asp:Label ID="LabelMemLoginIDTwo" runat="server" /></a>，欢迎来到本商城！
                                    <a href="loginOut.aspx" style="display: none">退出</a>
                                </div>
                                <div class="qd_bg">
                                    <div class="cldd">
                                        <a href='/main/member/m_index.aspx?tomurl=M_MyCollect.aspx?type=0&pageid=1' target="_blank">我的收藏</a></div>
                                    <div class="zxhf">
                                        <a href='<%= ShopUrlOperate.RetMemberUrl("m_index") %>?tomurl=M_OrderList.aspx'>我的订单</a></div>
                                    <div class="wddd">
                                        <a href='<%= ShopUrlOperate.RetMemberUrl("m_index") %>?tomurl=M_MyMessageBoard.aspx'>咨询回复</a></div>
                                    <div class="wdjf">
                                        <a href='<%= ShopUrlOperate.RetMemberUrl("m_index") %>?tomurl=M_CreditDetails.aspx'>我的积分</a></div>
                                    <div class="clear"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
                <li class="sn_mytaobao menu_item" style="background: none;">
                    <div id="headtest3" class="menu_hd menu_hd2 ie6top">
                        <a href='<%= ShopUrlOperate.RetUrl("Login") %>'>我的购物车</a>
                        <div class="wdgwc fr">
                            <div class="sub_wdsc1">
                                <a class="cartenet" href="<%= ShopUrlOperate.RetUrl("ShoppingCart1") %>">
                                    <div class="qdl1" id="shopcart1" runat="server">
                                        购物车中还没有商品，赶紧选购吧！
                                    </div>
                                    <div id="shopcart2" class="qdl1" runat="server">
                                        购物车共<asp:Literal ID="LiteralCartCount" runat="server" Text="0"></asp:Literal><span>件商品</span>
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
        <div class="warp headerCon">
            <h1 id="mallLogo">
                <a href="http://<%=ShopSettings.siteDomain %>"><asp:Image ID="ImageShopLogo" runat="server" /></a>
            </h1>
            <div class="mallSearch" id="mallSearch">
                <ShopNum1Shop:TopSearch ID="TopSearch" runat="server" SkinFilename="AgentAllSearch.ascx" />
            </div>
        </div>
    </div>
    <input type="hidden" name="secondEVENTTARGET" id="secondEVENTTARGET" value="" />
</div>
