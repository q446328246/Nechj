<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>店铺等级</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <link rel='stylesheet' type='text/css' href='style/dshow.css' />
    <script type="text/javascript" src="js/dshow.js"> </script>
    <script type="text/javascript" src="js/SpryTabbedPanels.js"> </script>
    <script language="javascript" type="text/javascript" src="js/jquery.pack.js"> </script>
    <script src="/JS/jquery-1.6.2.min.js" type="text/javascript"> </script>
    <script src="/Main/js/areas.js" type="text/javascript"> </script>
    <script src="/Main/js/location.js" type="text/javascript"> </script>
    <style type='text/css'>
        .addOnline
        {
            color: #F60;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ShopNum1ShopAdmin:S_ShowShopRank ID="S_ShowShopRank" runat="server" SkinFilename="skin/S_ShowShopRank.ascx" />
    </form>
</body>
</html>
