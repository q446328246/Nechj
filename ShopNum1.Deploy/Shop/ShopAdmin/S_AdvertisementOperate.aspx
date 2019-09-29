<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>广告管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><a href="S_AdvertisementList.aspx">页面广告</a><span
                class="breadcrume_icon">>></span> <span class="breadcrume_text">页面广告编辑</span>
        </p>
        <ShopNum1ShopAdmin:S_AdvertisementOperate ID="S_AdvertisementOperate" runat="server"
            SkinFilename="skin/S_AdvertisementOperate.ascx" />
    </div>
    </form>
</body>
</html>
