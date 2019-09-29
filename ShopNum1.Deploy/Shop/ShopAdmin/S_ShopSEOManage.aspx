<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>店铺SEO管理</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script language="javascript" type="text/javascript" src="js/jquery.pack.js"> </script>
    <script type="text/javascript" src="js/SpryTabbedPanels.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">SEO设置</span></p>
        <ShopNum1ShopAdmin:S_ShopSEOManage ID="S_ShopSEOManage" runat="server" SkinFilename="Skin/S_ShopSEOManage.ascx"
            PageSize="10" />
    </div>
    </form>
</body>
</html>
