<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>团购订单列表</title>
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <link rel='stylesheet' type='text/css' href='style/s.css' />
    <script type="text/javascript" language="javascript" src="/JS/DatePicker/WdatePicker.js"> </script>
</head>
<body>
    <div id="theEnd" style="position: relative">
    </div>
    <form id="form1" runat="server">
    <ShopNum1ShopAdmin:S_GroupOrder_List ID="S_GroupOrder_List" PageSize="8" runat="server"
        SkinFilename="skin/S_GroupOrder_List.ascx" />
    </form>
</body>
</html>
