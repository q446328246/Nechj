<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>订单详细页面</title>
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <script language="javascript" type="text/javascript" src="js/s_index.js"> </script>
    <link rel='stylesheet' type='text/css' href='style/myorder.css' />
</head>
<body>
    <form id="form1" runat="server">
    <div id="containe_bg">
        <!--头部Top-->
        <ShopNum1ShopAdmin:S_Head ID="S_Head" runat="server" SkinFilename="Skin/S_Head.ascx" />
        <!--内容部分Content-->
        <ShopNum1ShopAdmin:S_OrderDetail ID="S_OrderDetail" runat="server" SkinFilename="skin/S_OrderDetail.ascx" />
        <!--内容部分Content-->
        <!--页面底部Bottom-->
        <ShopNum1ShopAdmin:S_Bottom ID="S_Bottom" runat="server" SkinFilename="Skin/S_Bottom.ascx"
            class="foot_bg" />
    </div>
    </form>
</body>
</html>
