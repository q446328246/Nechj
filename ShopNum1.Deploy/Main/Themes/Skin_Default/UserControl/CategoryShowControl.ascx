<%@ Control Language="C#" AutoEventWireup="true" %>
<div class="warp_site">
    首页 》<a href="#">分类页面</a></div>
<div class="supply_page">
    <!--信息分类列表-->
    <ShopNum1:CategoryAllCategory runat="server" ID="CategoryAllCategory" ShowCountOne="10"
        ShowCountTwo="9" SkinFilename="CategoryAllCategory.ascx" />
    <!--广告-->
    <div class="supply_img">
        <a href="#">
            <ShopNum1:AdSimpleImage ID="AdSimpleImage27" runat="server" AdImgId="27" SkinFilename="AdSimpleImage.ascx" />
        </a>
    </div>
    <!--信息列表-->
    <div id="divMessage_lists" class="message_lists clearfix">
        <ShopNum1:CategoryListByCategory ID="CategoryListByCategory" Titel="数码" runat="server"
            ShowCount="4" CategoryCode="018" SkinFilename="CategoryListByCategory.ascx" />
        <ShopNum1:CategoryListByCategory ID="SupplyListByCategory1" Titel="家电" runat="server"
            ShowCount="4" CategoryCode="017" SkinFilename="CategoryListByCategory.ascx" />
        <ShopNum1:CategoryListByCategory ID="SupplyListByCategory2" Titel="服装" runat="server"
            ShowCount="4" CategoryCode="022" CssClass="test" SkinFilename="CategoryListByCategory.ascx" />
    </div>
    <!--广告-->
    <div class="supply_img">
        <a href="#">
            <ShopNum1:AdSimpleImage ID="AdSimpleImage28" runat="server" AdImgId="28" SkinFilename="AdSimpleImage.ascx" />
        </a>
    </div>
    <!--信息列表-->
    <div class="message_lists clearfix">
        <ShopNum1:CategoryListByCategory ID="SupplyListByCategory3" Titel="汽车.车品" runat="server"
            ShowCount="4" CategoryCode="011" SkinFilename="CategoryListByCategory.ascx" />
        <ShopNum1:CategoryListByCategory ID="SupplyListByCategory4" Titel="家居建材" runat="server"
            ShowCount="4" CategoryCode="014" SkinFilename="CategoryListByCategory.ascx" />
        <ShopNum1:CategoryListByCategory ID="SupplyListByCategory5" Titel="日用百货" runat="server"
            ShowCount="4" CategoryCode="012" CssClass="test" SkinFilename="CategoryListByCategory.ascx" />
    </div>
    <!--广告-->
    <div class="supply_img">
        <a href="#">
            <ShopNum1:AdSimpleImage ID="AdSimpleImage29" runat="server" AdImgId="29" SkinFilename="AdSimpleImage.ascx" />
        </a>
    </div>
    <!--信息列表-->
    <div class="message_lists clearfix">
        <ShopNum1:CategoryListByCategory ID="SupplyListByCategory6" Titel="文化玩乐" runat="server"
            ShowCount="4" CategoryCode="010" SkinFilename="CategoryListByCategory.ascx" />
        <ShopNum1:CategoryListByCategory ID="SupplyListByCategory7" Titel="母婴用品" runat="server"
            ShowCount="4" CategoryCode="015" SkinFilename="CategoryListByCategory.ascx" />
        <ShopNum1:CategoryListByCategory ID="SupplyListByCategory8" Titel="虚拟" runat="server"
            ShowCount="4" CategoryCode="023" CssClass="test" SkinFilename="CategoryListByCategory.ascx" />
    </div>
</div>
