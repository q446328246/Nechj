<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Themes/Skin_Default/Js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function show_date_time(time, element) {
            window.setTimeout("show_date_time('" + time + "','" + element + "')", 1000);
            BirthDay = new Date(time);
            today = new Date();
            timeold = (BirthDay.getTime() - today.getTime());
            sectimeold = timeold / 1000
            secondsold = Math.floor(sectimeold);
            msPerDay = 24 * 60 * 60 * 1000
            e_daysold = timeold / msPerDay
            daysold = Math.floor(e_daysold); //返回小于等于数字参数的最大整数
            e_hrsold = (e_daysold - daysold) * 24;
            hrsold = Math.floor(e_hrsold);
            e_minsold = (e_hrsold - hrsold) * 60;
            minsold = Math.floor((e_hrsold - hrsold) * 60);
            seconds = Math.floor((e_minsold - minsold) * 60);
            if (daysold < 0) {
                document.getElementById(element).innerHTML = "0天0小时0分0秒";
            } else {
                document.getElementById(element).innerHTML = daysold + "天" + hrsold + "小时" + minsold + "分" + seconds + "秒";
            }
        }
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
    <div class="FlowCat_cont">
        <div class="article_cont">
            <div class="panic">
                <!--抢购幻灯-->
                <div class="panic_aa">
                    <div class="panic_adv">
                        <div id="focus" class="panic_focus">
                            <div id="Rleft">
                                <div id='ad9' runat='server'>
                                </div>
                                <ShopNum1:AdvertisementPPTStyle ID="AdvertisementPPTStyle1" runat="server" SkinFilename="AdvertisementPPT.ascx"
                                    AdID="ad9" AdType="2" />
                                <script src="Themes/Skin_Default/js/hp.js" type="text/javascript"></script>
                            </div>
                        </div>
                    </div>
                    <ShopNum1:PanicBuyNews ID="PanicBuyNews" ArticleCategoryID="154" ShowCount="4" SkinFilename="PanicBuyNews.ascx"
                        runat="server" />
                </div>
                <!--抢购1 美容 珠宝专场-->
                <ShopNum1:PanicBuyListNew ID="PanicBuyList1" CategoryCode="001" PageCount="10" SkinFilename="PanicBuyList1.ascx"
                    runat="server" />
                <!--抢购2 服饰内衣-->
                <ShopNum1:PanicBuyListNew ID="PanicBuyListNew1" CategoryCode="002" PageCount="10"
                    SkinFilename="PanicBuyList2.ascx" runat="server" />
                <!--广告-->
                <div class="panic_Midadv">
                    <ShopNum1:AdSimpleImage ID="AdSimpleImage18" runat="server" AdImgId="18" SkinFilename="AdSimpleImage.ascx" />
                </div>
            </div>
            <!--抢购3 鞋包运动-->
            <ShopNum1:PanicBuyListNew ID="PanicBuyListNew2" CategoryCode="003" PageCount="10"
                SkinFilename="PanicBuyList3.ascx" runat="server" />
            <!--抢购4 母婴用品-->
            <ShopNum1:PanicBuyListNew ID="PanicBuyListNew3" CategoryCode="004" PageCount="10"
                SkinFilename="PanicBuyList4.ascx" runat="server" />
            <!--广告-->
            <div class="panic_Midadv">
                <ShopNum1:AdSimpleImage ID="AdSimpleImage21" runat="server" AdImgId="21" SkinFilename="AdSimpleImage.ascx" />
            </div>
            <!--抢购5 数码家电-->
            <ShopNum1:PanicBuyListNew ID="PanicBuyListNew4" CategoryCode="005" PageCount="10"
                SkinFilename="PanicBuyList5.ascx" runat="server" />
            <!--抢购6 美容珠宝-->
            <ShopNum1:PanicBuyListNew ID="PanicBuyListNew5" CategoryCode="006" PageCount="10"
                SkinFilename="PanicBuyList6.ascx" runat="server" />
        </div>
    </div>
    <!--//main End-->
    <!--foot Start-->
    <!-- #include file="foot1.aspx" -->
    <!--//foot End-->
    <!--图片广告模块调用  幻灯片 -->
    <%--    <ShopNum1:AdvertisementPPTStyle ID="AdvertisementPPTStyle" runat="server" SkinFilename="AdvertisementPPT.ascx" />--%>
    </form>
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
</body>
</html>
