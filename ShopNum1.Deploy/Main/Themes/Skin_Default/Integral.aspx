<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="true" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Themes/Skin_Default/Js/jquery.min.js" type="text/javascript"></script>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!--head Start-->
    <!-- #include file="headShop.aspx" -->
    <!--//head End-->
    <!--main Start-->
    <div class="FlowCat_cont clearfix">
        <div class="warp_site">
            首页 》红包</div>
        <div class="integral clearfix">
            <!--红包登录-->
            <div class="list_left fl">
                <div class="sleft">
                    <ShopNum1:IntegralLogin ID="IntegralLogin" runat="server" SkinFilename="IntegralLogin.ascx" />
                </div>
            </div>
            <!--幻灯-->
            <div class="list_right fr">
                <div id="focus" class="integral_focus">
                    <div id="Rleft">
                        <div id='ad8' runat='server'>
                        </div>
                        <ShopNum1:AdvertisementPPTStyle ID="AdvertisementPPTStyle" runat="server" SkinFilename="AdvertisementPPT.ascx"
                            AdID="ad8" AdType="2" />
                        <script src="Themes/Skin_Default/js/hp.js" type="text/javascript"></script>
                    </div>
                </div>
            </div>
        </div>
        <!--广告-->
        <div class="integral_adv clearfix">
            <%--
            <a href="#"><img src="Themes/Skin_Default/Images/sad1.jpg" width="1190" height="93" /></a>--%>
            <ShopNum1:AdSimpleImage ID="AdSimpleImage" runat="server" AdImgId="90" SkinFilename="AdSimpleImage.ascx" />
        </div>
        <div class="integral_con clearfix">
            <div class="list_left fl">
                <ShopNum1:IntegralPhb ID="IntegralPhb" runat="server" SkinFilename="IntegralPhb.ascx" />
                <div>
                    <%--  <a href="#"> <img src="Themes/Skin_Default/Images/sad.jpg" width="218" height="327" /></a>--%>
                    <ShopNum1:AdSimpleImage ID="AdSimpleImage81" runat="server" AdImgId="81" SkinFilename="AdSimpleImage.ascx" />
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="list_right fr">
                <ShopNum1:IntegralProductlist ID="IntegralProductlist" runat="server" SkinFilename="IntegralProductlist.ascx"
                    ShowCount="20" />
            </div>
        </div>
        <div class="article_cont" style="margin-top: 20px; display: none;">
            <ShopNum1:CouponsListControl ID="CouponsListControl" runat="server" Visible="false" />
        </div>
    </div>
    <!--//main End-->
    <!--foot Start-->
    <!-- #include file="foot1.aspx" -->
    <!--//foot End-->
    <!--图片广告模块调用  幻灯片 -->
    </form>
</body>
</html>
