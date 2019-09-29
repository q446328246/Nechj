<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>红包商品</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" src="js/SpryTabbedPanels.js"> </script>
    <script type="text/javascript" language="javascript"> </script>
    <script src="JS/jquery.pack.js" type="text/javascript"> </script>
    <script src="/Main/js/areas.js" type="text/javascript"> </script>
    <script src="/Main/js/location.js" type="text/javascript"> </script>
    <link rel='stylesheet' type='text/css' href='style/dshow.css' />
    <script type="text/javascript" src="js/dshow.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><a href="S_ScoreProduct.aspx">红包商城</a><span
                class="breadcrume_icon">>></span><span class="breadcrume_text">红包商品操作</span></p>
        <ShopNum1ShopAdmin:S_AddScoreProduct ID="S_AddScoreProduct" runat="server" SkinFilename="skin/S_AddScoreProduct.ascx" />
    </div>
    </form>
</body>
</html>
