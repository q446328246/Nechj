<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>开店-步骤3</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" src="js/SpryTabbedPanels.js"> </script>
    <script type="text/javascript" language="javascript"> </script>
    <script src="/JS/jquery-1.6.2.min.js" type="text/javascript"> </script>
    <script src="/Main/js/areas.js" type="text/javascript"> </script>
    <script src="/Main/js/location.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function sethash() {
            var hashH = document.documentElement.scrollHeight;
            parent.document.getElementById("mainFrame").style.height = hashH + "px";
        }

        window.onload = sethash;
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ShopNum1ShopAdmin:S_ShopOpenStep3 ID="S_ShopOpenStep3" runat="server" SkinFilename="skin/S_ShopOpenStep3.ascx" />
    </form>
</body>
</html>
