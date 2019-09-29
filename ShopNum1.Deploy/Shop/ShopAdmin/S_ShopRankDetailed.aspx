<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>店铺等级详细</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" src="js/SpryTabbedPanels.js"> </script>
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <script src="/JS/jquery-1.6.2.min.js" type="text/javascript"> </script>
    <script src="/Main/js/areas.js" type="text/javascript"> </script>
    <script src="/Main/js/location.js" type="text/javascript"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <ShopNum1ShopAdmin:S_ShopRankDetailed ID="S_ShopRankDetailed" runat="server" SkinFilename="skin/S_ShopRankDetailed.ascx" />
    </form>
</body>
</html>
