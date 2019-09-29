<%@ Control Language="C#" EnableViewState="true" %>
<%@ Import Namespace="ShopNum1.Common" %>
<div id="mallNav">
    <div class="mallNav_con">
        <div id="mallTextNav" class="clearfix">
            <div class="mallNav_main nall_hid">
                <asp:Literal ID="literLi" runat="server"></asp:Literal>
                <%--因为Repeater受限无法加入判断，所以改成原来的方式-->
                 <%--<ul><asp:Repeater ID="RepterNav" runat="server">
                    <ItemTemplate>
                         <li style='<%#Eval("name")=="首页"?"background:url(Themes/Skin_Default/Images/navbg2.gif) no-repeat center;color:#FFFFFF;":""%>'><a id='lia<%# Container.ItemIndex+1 %>' href='http://<%=ShopSettings.siteDomain %>/<%#Eval("LinkAddress") %><%=ShopSettings.overrideUrlName %>?tag=<%#Container.ItemIndex+1 %>' target='<%#Eval("ifopen")=="0"?"_self":"_blank" %>'><%#Eval("Name")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>   </ul>--%>
            </div>
            <div class="mallNav_others" id="mallNav_others" style="display: none;">
                <ul>
                    <li class="maNav" id="dparent1"><a href="#"><span class="spjt">我的商城</span></a>
                        <div id="dchild" class="browse bao">
                            <div id="listfw" class="uclist clear">
                                <!--已经登录状态-->
                                <div runat="server" visible="true" id="loginOut">
                                    您好， <a href='<%= ShopUrlOperate.RetUrl("Index") %>'>
                                        <asp:Label ID="LabelMemLoginID" CssClass="balck" runat="server" /></a> ,欢迎来到多用户商城
                                    <asp:LinkButton ID="LinkButtonLoginOut" runat="server" OnClientClick='javascript:confirm(确定退出登录吗？) return false;'>
                                        退出
                                    </asp:LinkButton>
                                    <ul class="fore1 fl">
                                        <li><a href='<%= ShopUrlOperate.RetUrl("index") %>?shopurl=OrderList.aspx'>待处理订单</a></li>
                                        <li><a href='<%= ShopUrlOperate.RetUrl("index") %>?shopurl=OrderList.aspx'>我的订单</a></li>
                                    </ul>
                                    <ul class="fore2 fl">
                                        <li><a href='<%= ShopUrlOperate.RetUrl("index") %>?shopurl=MemberProductCommentList.aspx'>
                                            咨询回复</a></li>
                                        <li><a href='<%= ShopUrlOperate.RetUrl("index") %>?shopurl=ChangeScoreModifyLog.aspx'>
                                            我的红包</a></li>
                                    </ul>
                                </div>
                                <!--已经退出状态-->
                                <div runat="server" visible="true" id="login">
                                    <div class="fwlr_prompt">
                                        <div class="fl dpn">
                                            您好，请登录</div>
                                        <div class="fl dpn btnp_login">
                                            <a href='<%= ShopUrlOperate.RetUrl("Login") %>'>登录</a></div>
                                        <div class="fl dpn btnp_login">
                                            <a href='<%= ShopUrlOperate.RetUrl("MemberRegister") %>'>申请店铺</a></div>
                                    </div>
                                    <ul class="fore1 fl">
                                        <li><a href='<%= ShopUrlOperate.RetUrl("index") %>?shopurl=OrderList.aspx'>待处理订单</a></li>
                                        <li><a href='<%= ShopUrlOperate.RetUrl("index") %>?shopurl=OrderList.aspx'>我的订单</a></li>
                                    </ul>
                                    <ul class="fore2 fl">
                                        <li><a href='<%= ShopUrlOperate.RetUrl("index") %>?shopurl=MemberProductCommentList.aspx'>
                                            咨询回复</a></li>
                                        <li><a href='<%= ShopUrlOperate.RetUrl("index") %>?shopurl=ChangeScoreModifyLog.aspx'>
                                            我的红包</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </li>
                    <li class="mallNav_last maNav" id="dparent2"><a href='<%= ShopUrlOperate.RetUrl("ShoppingCart1") %>'>
                        <span class="spjt">购物车结算</span> </a>
                        <div class="browse bao" id="dchild2">
                            <span class="line"></span>
                            <div class="list clear">
                                <h3>
                                    <a class="cartenet" href="<%= ShopUrlOperate.RetUrl("ShoppingCart1") %>">
                                        <div id="shopcart1" runat="server">
                                            购物车中还没有商品，赶紧选购吧</div>
                                        <div id="shopcart2" runat="server">
                                            购物车共<asp:Literal ID="LiteralCartCount" runat="server" Text="0">
                                            </asp:Literal><span>件商品</span>
                                        </div>
                                    </a>
                                </h3>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</div>
