<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript">
//<![CDATA[
    var theForm = document.forms[0];
    if (!theForm) {
        theForm = document.form1;
    }
    function SecondLogin(eventTarget, eventArgument) {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
            theForm.secondEVENTTARGET.value = eventTarget;
            theForm.secondEVENTARGUMENT.value = eventArgument;
            theForm.submit();
        }
    }
//]]>
</script>
<!--sn_container Start-->
<div class="sn_container">
    <!--sn_login_info Start-->
    <div class="sn_login_info" style="display: inline;">
        <!--已经登录状态 Start-->
        <div runat="server" visible="true" id="loginOut">
            您好！ <a href="/Main/Member/M_index.aspx">
                <asp:Label ID="MemLoginID" runat="server" Style="font-weight: bold; color: balack;" /></a>&nbsp;欢迎来到本商城!&nbsp;
            <a href="/Main/loginOut.aspx">[退出]</a>
        </div>
        <!--//已经登录状态 End-->
        <!--已经退出状态 Start-->
        <div runat="server" visible="true" id="login">
            <span class="sog">欢迎光临！请<a href='<%= ShopUrlOperate.RetUrl("Login") %>'>登录</a></span>
            <%--<span><a href='<%= ShopUrlOperate.RetUrl("MemberRegister") %>'>申请店铺</a> </span>&nbsp;
            <span><a href='<%= ShopUrlOperate.RetUrl("MemberRegisterMandarin") %>'>用户注册</a> </span>--%>
            <asp:Repeater ID="RepeaterSecondLogin" runat="server" Visible="false">
                <HeaderTemplate>
                    <span>&nbsp;可以通过</span>
                </HeaderTemplate>
                <ItemTemplate>
                    <a href="javascript:SecondLogin('<%#((DataRowView)Container.DataItem).Row["ID"] %>','')"
                        onclick="javascript:SecondLogin('<%#((DataRowView)Container.DataItem).Row["ID"] %>','')">
                        <img src='<%# Page.ResolveUrl(((DataRowView)Container.DataItem).Row["ImgSrc"].ToString())%>'
                            style="height: 16px; width: 16px;" /></a>
                </ItemTemplate>
                <FooterTemplate>
                    <span>&nbsp;登录</span>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!--//已经退出状态 End-->
    </div>
    <!--//sn_login_info End-->
    <!--sn_quick_menu Start-->
    <ul class="sn_quick_menu">
        <li class="sn_mytaobao menu_item">
            <div id="headtest" class="menu_hd menu_hd1 ie6top">
                <a href="<%= ShopUrlOperate.RetShopadminUrl("s_index") %>" style="_height: 20px;">卖家中心</a>
                <div class="sub_huaguo1">
                    <a href='<%= ShopUrlOperate.RetShopadminUrl("s_index") %>?tosurl=S_Order_List.aspx'>
                        已售出的商品</a> <a href='<%= ShopUrlOperate.RetShopadminUrl("s_index") %>?tosurl=S_SellProduct.aspx'>
                            销售中的商品</a>
                </div>
            </div>
        </li>
        <li class="sn_mytaobao menu_item">
            <div id="headtest2" class="menu_hd menu_hd1 ie6top">
                <a href='<%= ShopUrlOperate.RetMemberUrl("M_index") %>'>我的商城</a>
                <div class="wdsc">
                    <!--已经退出状态 Start-->
                    <div class="sub_wdsc" runat="server" visible="true" id="loginTwo">
                        <div class="qd_bg">
                            <div class="cldd" style="display: none">
                                <a href='<%= ShopUrlOperate.RetMemberUrl("M_index") %>?tomurl=M_OrderList.aspx'>待处理订单</a>
                            </div>
                            <div class="zxhf">
                                <a href='<%= ShopUrlOperate.RetMemberUrl("M_index") %>'>咨询回复</a>
                            </div>
                            <div class="wddd">
                                <a href='<%= ShopUrlOperate.RetMemberUrl("M_index") %>?tomurl=M_OrderList.aspx'>我的订单</a>
                            </div>
                            <div class="wdjf">
                                <a href='<%= ShopUrlOperate.RetMemberUrl("M_index") %>?tomurl=M_CreditDetails.aspx?type=0&pageid=1'>
                                    我的红包</a>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                    <!--//已经退出状态 End-->
                    <!--已经登录状态 Start-->
                    <div runat="server" visible="true" id="loginOutTwo" class="lambert_sub">
                        <div class="qd_bg">
                            <div class="cldd" style="display: none">
                                <a href='<%= ShopUrlOperate.RetMemberUrl("M_index") %>?tomurl=M_OrderList.aspx'>待处理订单</a>
                            </div>
                            <div class="zxhf">
                                <a href='<%= ShopUrlOperate.RetMemberUrl("M_index") %>?tomurl=M_MyMessageBoard.aspx'>
                                    咨询回复</a>
                            </div>
                            <div class="wddd">
                                <a href='<%= ShopUrlOperate.RetMemberUrl("M_index") %>?tomurl=M_OrderList.aspx'>我的订单</a>
                            </div>
                            <div class="wdjf">
                                <a href='<%= ShopUrlOperate.RetMemberUrl("M_index") %>?tomurl=M_CreditDetails.aspx?type=0&pageid=1'>
                                    我的红包</a>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                    <!--//已经登录状态 End-->
                </div>
            </div>
        </li>
        <li class="sn_mytaobao menu_item">
            <div id="headtest3" class="menu_hd menu_hd2 ie6top">
                <a href="<%= ShopUrlOperate.RetUrl("ShoppingCart1") %>">我的购物车</a>
                <div class="wdgwc fr">
                    <div>
                        <div class="sub_wdsc1">
                            <a class="cartenet" href="<%= ShopUrlOperate.RetUrl("ShoppingCart1") %>"><span class="qdl1"
                                id="shopcart1" runat="server">购物车中还没有商品，赶紧选购吧！ </span><span class="qdl1" id="shopcart2"
                                    runat="server">购物车共<asp:Literal ID="LiteralCartCount" runat="server" Text="0"></asp:Literal>件商品
                                </span></a>
                        </div>
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
        </li>
        <li class="sn_mytaobao menu_item">
            <div id="headtest1" class="menu_hd menu_hd1 ie6top">
                <a href="javascript:void(0)">我的收藏</a>
                <div class="sub_huaguo1">
                    <a href='<%= ShopUrlOperate.RetMemberUrl("m_index") %>?tomurl=M_MyCollect.aspx?type=0&pageid=1'>
                        收藏的商品</a> <a href='<%= ShopUrlOperate.RetMemberUrl("m_index") %>?tomurl=M_MyCollect.aspx?type=1&pageid=1'>
                            收藏的店铺</a>
                </div>
            </div>
        </li>
        <%--        <li class="sn_mytaobao menu_item">
            <div class="menu_hd">
                <a href='<%= ShopUrlOperate.RetUrl("mobile") %>' target="_blank">手机App下载</a>
            </div>
        </li>--%>
        <%--        <li class="sn_mytaobao menu_item">
            <div class="menu_hd">
                <a href='<%= ShopUrlOperate.RetUrl("MerchantsIn") %>' target="_blank">招商加盟</a>
            </div>
        </li>--%>
        <%--        <li class="sn_mytaobao menu_item" style="background: none;">
            <div class="menu_hd">
                <a href="<%= ShopUrlOperate.RetUrl("HelpListIndex") %>">帮助中心</a>
            </div>
        </li>--%>
        <li style="display: none;"><a onclick="javascript:SecondLogin('cartClick','')" href="javascript:void(0)"
            rel="nofollow" onclick="">
            <img src="Themes/Skin_Default/Images/shop.jpg" />
            <span>购物车共<span><asp:Literal ID="LiteralCartCount1" runat="server" Text="0"></asp:Literal></span>件商品</span>
        </a></li>
    </ul>
    <!--sn_quick_menu End-->
</div>
<!--//sn_container End-->
<div>
    <input type="hidden" name="secondEVENTTARGET" id="secondEVENTTARGET" value="" />
    <input type="hidden" name="secondEVENTARGUMENT" id="secondEVENTARGUMENT" value="" />
</div>
