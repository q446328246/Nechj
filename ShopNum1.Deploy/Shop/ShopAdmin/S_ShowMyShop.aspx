<%@ Page Language="C#" EnableViewState="false" %>

<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>进入我的店铺</title>
    <link rel='stylesheet' type='text/css' href='style/s.css' />
    <script language="javascript" type="text/javascript" src="js/jquery.pack.js"> </script>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <script type="text/javascript" src="js/SpryTabbedPanels.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <ShopNum1ShopAdmin:S_ShowMyShop ID="S_ShowMyShop" runat="server" SkinFilename="Skin/S_ShowMyShop.ascx"
        PageSize="10" />
    <script type="text/javascript" language="javascript">
        //跳转到制定的页码
        function ontoPage(txtId) {
            location.href = '?isread=<%= ShopNum1.Common.Common.ReqStr("type") %>&pageid=' + $("#" + txtId).val();
        }
    </script>
    </form>
</body>
</html>
