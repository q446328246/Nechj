<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>店铺微信接口配置</title>
    <link href="style/weixin.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.2.min.js" type="text/javascript"> </script>
    <script src="/JS/zclip/jquery.zclip.min.js" type="text/javascript"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <ShopNum1ShopAdmin:W_ShopWeiXinApiConfig ID="W_ShopWeiXinApiConfig" runat="server"
        SkinFilename="skin/weixin/W_ShopWeiXinApiConfig.ascx" />
    </form>
</body>
</html>
