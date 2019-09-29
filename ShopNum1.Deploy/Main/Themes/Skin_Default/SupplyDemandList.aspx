<%@ Page Language="C#" EnableViewState="false" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Js/jquery-1.6.2.min.js" type="text/javascript"></script>
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
    <script type="text/javascript">
        $(document).ready(function () {
            $(".test div").css("margin-right", "0");
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <!--head start-->
    <!-- #include file="headShop.aspx" -->
    <!--main start-->
    <!-- middle -->
    <div class="FlowCat_cont clearfix">
        <div class="warp_site">
            首页 》供求
        </div>
        <div class="supply_page">
            <%--供求分类列表--%>
            <ShopNum1:SupplyDemandList runat="server" ID="SupplyDemandList" ShowCountOne="10"
                ShowCountTwo="8" SkinFilename="SupplyDemandList.ascx" />
            <!--广告-->
            <div class="supply_img">
                <a href="#">
                    <%--<img src="Themes/Skin_Default/Images/supply01.jpg" width="1000" height="90" />--%>
                    <ShopNum1:AdSimpleImage ID="AdSimpleImage24" runat="server" AdImgId="24" SkinFilename="AdSimpleImage.ascx" />
                </a>
            </div>
            <!--信息列表-->
            <div class="message_lists clearfix">
                <ShopNum1:SupplyListByCategory ID="SupplyListByCategory" Titel="农林牧渔" runat="server"
                    ShowCount="4" CategoryCode="001" SkinFilename="SupplyListByCategory.ascx" />
                <ShopNum1:SupplyListByCategory ID="SupplyListByCategory1" Titel="服装、服饰" runat="server"
                    ShowCount="4" CategoryCode="002" SkinFilename="SupplyListByCategory.ascx" />
                <ShopNum1:SupplyListByCategory ID="SupplyListByCategory2" Titel="安全、防护" runat="server"
                    ShowCount="4" CategoryCode="003" CssClass="test" SkinFilename="SupplyListByCategory.ascx" />
            </div>
            <!--广告-->
            <div class="supply_img">
                <a href="#">
                    <%--<img src="Themes/Skin_Default/Images/supply02.jpg" width="1000" height="90" />--%>
                    <ShopNum1:AdSimpleImage ID="AdSimpleImage25" runat="server" AdImgId="25" SkinFilename="AdSimpleImage.ascx" />
                </a>
            </div>
            <div class="message_lists clearfix">
                <!--信息列表-->
                <ShopNum1:SupplyListByCategory ID="SupplyListByCategory3" Titel="食品、饮料" runat="server"
                    ShowCount="4" CategoryCode="004" SkinFilename="SupplyListByCategory.ascx" />
                <ShopNum1:SupplyListByCategory ID="SupplyListByCategory4" Titel="电子电工" runat="server"
                    ShowCount="4" CategoryCode="005" SkinFilename="SupplyListByCategory.ascx" />
                <ShopNum1:SupplyListByCategory ID="SupplyListByCategory5" Titel="印刷、出版" runat="server"
                    ShowCount="4" CategoryCode="006" CssClass="test" SkinFilename="SupplyListByCategory.ascx" />
            </div>
            <!--广告-->
            <div class="supply_img">
                <a href="#">
                    <%--<img src="Themes/Skin_Default/Images/supply03.jpg" width="1000" height="90" />--%>
                    <ShopNum1:AdSimpleImage ID="AdSimpleImage26" runat="server" AdImgId="26" SkinFilename="AdSimpleImage.ascx" />
                </a>
            </div>
            <div class="message_lists clearfix">
                <!--信息列表-->
                <ShopNum1:SupplyListByCategory ID="SupplyListByCategory6" Titel="纺织、皮革" runat="server"
                    ShowCount="4" CategoryCode="007" SkinFilename="SupplyListByCategory.ascx" />
                <ShopNum1:SupplyListByCategory ID="SupplyListByCategory7" Titel="处理" runat="server"
                    ShowCount="4" CategoryCode="008" SkinFilename="SupplyListByCategory.ascx" />
                <ShopNum1:SupplyListByCategory ID="SupplyListByCategory8" Titel="玩具" runat="server"
                    ShowCount="4" CategoryCode="009" CssClass="test" SkinFilename="SupplyListByCategory.ascx" />
            </div>
            <div class="supply_img">
                <a href="#">
                    <%--<img src="Themes/Skin_Default/Images/supply03.jpg" width="1000" height="90" />--%>
                    <ShopNum1:AdSimpleImage ID="AdSimpleImage1" runat="server" AdImgId="86" SkinFilename="AdSimpleImage.ascx" />
                </a>
            </div>
            <div class="message_lists clearfix">
                <!--信息列表-->
                <ShopNum1:SupplyListByCategory ID="SupplyListByCategory9" Titel="能源动力" runat="server"
                    ShowCount="4" CategoryCode="010" SkinFilename="SupplyListByCategory.ascx" />
                <ShopNum1:SupplyListByCategory ID="SupplyListByCategory10" Titel="建材、房地产" runat="server"
                    ShowCount="4" CategoryCode="011" SkinFilename="SupplyListByCategory.ascx" />
                <ShopNum1:SupplyListByCategory ID="SupplyListByCategory11" Titel="通讯" runat="server"
                    ShowCount="4" CategoryCode="012" CssClass="test" SkinFilename="SupplyListByCategory.ascx" />
            </div>
        </div>
    </div>
    <!--main end-->
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--foot end-->
    </form>
</body>
</html>
