<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>唐江宝宝 打印订单</title>
    <link rel='stylesheet' type='text/css' href='style/printOrder.css' />
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <script type="text/javascript" src="js/jquery.poshytip.min.js"> </script>
    <script type="text/javascript" src="js/jquery.printarea.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <ShopNum1ShopAdmin:S_PrintOrder ID="S_PrintOrder" runat="server" SkinFilename="skin/S_PrintOrder.ascx" />
    </form>
</body>
</html>
