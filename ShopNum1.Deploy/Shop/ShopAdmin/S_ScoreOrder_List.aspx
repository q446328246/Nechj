<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>红包订单列表</title>
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script src="/JS/artDialog/artDialog.js" type="text/javascript"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <ShopNum1ShopAdmin:S_ScoreOrder_List ID="S_ScoreOrder_List" PageSize="10" runat="server"
        SkinFilename="skin/S_ScoreOrder_List.ascx" />
    </form>
</body>
</html>
