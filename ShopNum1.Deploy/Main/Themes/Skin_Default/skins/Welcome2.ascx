<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript">

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
                    //alert(e.message);
                    //alert(e.description)
                    //alert(e.number)
                    //alert(e.name) 
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

    function SecondLogin(eventTarget, eventArgument) {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
            theForm.secondEVENTTARGET.value = eventTarget;
            theForm.secondEVENTARGUMENT.value = eventArgument;
            theForm.submit();
        }
    }
//]]>


</script>
<div class="head clearmiddle">
    <div class="head_left fl">
        <ul>
            <li>
                <img src="Themes/Skin_Default/Images/phone.png" /></li>
            <li><a href="javascript:void(0)" onclick="setHomepage()">设为主页</a></li>
            <li><a href="javascript:void(0)" onclick="addFav()">添加收藏</a></li>
            <li><a onclick="javascript:SecondLogin('cartClick','')" href="javascript:void(0)"
                rel="nofollow" onclick="">
                <img src="Themes/Skin_Default/Images/shop.jpg" style="position: relative;" />
                <span style="position: relative; top: -3px;">购物车共<span style="font-weight: bold;
                    color: #ff6600;"><asp:Literal ID="LiteralCartCount" runat="server" Text="0"></asp:Literal></span>件商品</span></a>
            </li>
        </ul>
    </div>
    <div runat="server" visible="true" id="login" class="head_right fr">
        【<a href='<%= ShopUrlOperate.RetUrl("Login") %>'>请登录</a>】 【<a href='<%= ShopUrlOperate.RetUrl("MemberRegister") %>'>申请店铺</a>】
        <asp:Repeater ID="RepeaterSecondLogin" runat="server">
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
    <div runat="server" visible="true" class="head_right fr" id="loginOut">
        欢迎光临！
        <asp:Label ID="MemLoginID" runat="server" />， 您可以登录<a href='<%= ShopUrlOperate.RetUrl("Index") %>'>【用户中心】</a>管理账号&nbsp;&nbsp;<a
            href="loginOut.aspx">退出</a>
        <%--        <asp:LinkButton ID="LinkButtonLoginOut" runat="server" CausesValidation="False" Visible="false">[退出]</asp:LinkButton>--%>
    </div>
</div>
<div>
    <input type="hidden" name="secondEVENTTARGET" id="secondEVENTTARGET" value="" />
    <input type="hidden" name="secondEVENTARGUMENT" id="secondEVENTARGUMENT" value="" />
</div>
