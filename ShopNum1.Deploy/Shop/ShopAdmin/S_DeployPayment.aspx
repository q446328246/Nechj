<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>配置支付方式插件</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script language="javascript" type="text/javascript" src="js/jquery.pack.js"> </script>
    <script type="text/javascript" src="js/SpryTabbedPanels.js"> </script>
    <link type="text/css" href="/js/artDialog/skins/chrome.css" rel="stylesheet"></link>
    <script src="/JS/artDialog/artDialog.js" type="text/javascript"> </script>
    <script type="text/javascript" src="js/SpryTabbedPanels.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><a href="S_ShowPaymentType.aspx">店铺支付方式</a><span
                class="breadcrume_icon">>></span><span class="breadcrume_text">配置支付方式</span></p>
        <ShopNum1ShopAdmin:S_DeployPayment ID="S_DeployPayment" runat="server" SkinFilename="Skin/S_DeployPayment.ascx" />
    </div>
    </form>
</body>
</html>
