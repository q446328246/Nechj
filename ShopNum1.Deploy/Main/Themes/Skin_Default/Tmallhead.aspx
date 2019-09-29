<!--head start-->
<div id="site">
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
    <div id="mallHome">
        <div id="header">
            <div class="headerCon">
                <h1 id="mallLogo">
                    <img height="74" width="247" src="Themes/Skin_Default/Images/logo.jpg" />
                    <%--<ShopNum1:LogoControl ID="LogoControl" runat="server" />--%>
                </h1>
                <ShopNum1:TopSearch ID="TopSearch" runat="server" SkinFilename="TopSearch.ascx" />
                <div class="slogan">
                </div>
            </div>
        </div>
    </div>
</div>
<!--ÖÐ²¿µ¼º½-->
<ShopNum1:MiddleNavigationControl ID="MiddleNavigationControl" runat="server" />
<!--Middle-->
