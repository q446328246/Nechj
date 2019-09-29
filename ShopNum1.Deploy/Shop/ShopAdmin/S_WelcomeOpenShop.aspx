<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>开店铺欢迎页</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
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
    <ShopNum1ShopAdmin:S_WelcomeOpenShop ID="S_WelcomeOpenShop" runat="server" SkinFilename="Skin/S_WelcomeOpenShop.ascx" />
    </form>
</body>
</html>
