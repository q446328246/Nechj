<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>普通订单列表</title>
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" language="javascript" src="/JS/DatePicker/WdatePicker.js"> </script>
    <script type="text/javascript" language="javascript" src="js/dshow.js"> </script>
    <link rel='stylesheet' type='text/css' href='style/dshow.css' />
</head>
<body>
    <form id="form1" runat="server">
    <ShopNum1ShopAdmin:S_Order_List ID="S_Order_List" PageSize="8" runat="server" SkinFilename="skin/S_Order_List.ascx" />
    </form>
</body>
</html>
