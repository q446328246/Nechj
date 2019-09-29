<%@ Page Language="C#" EnableViewState="false" %>

<%@ Register src="Skin/A_LoadUserPhoto.ascx" tagname="A_LoadUserPhoto" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.6.2.min.js" type="text/javascript"></script>

    <link href="style/loadImage.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.2.6.js" type="text/javascript"></script>
    <script src="js/ui.core.packed.js" type="text/javascript"></script>
    <script src="js/ui.draggable.packed.js" type="text/javascript"></script>
    <script src="/Shop/ShopAdmin/js/dshow.js" type="text/javascript"></script>
    <link href="/Shop/ShopAdmin/style/dshow.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function Step1() {
            $("#Step2Container").hide();
        }
        function Step2() {
            $("#CurruntPicContainer").hide();
        }
        function setPic(picurl) {
            // $("#A_MemInfo_ctl00_ImagePath").src=picurl;
            window.parent.document.getElementById("A_MemInfo1_ImagePath").src = picurl;
            parent.location.replace('A_MemInfo.aspx?type=2');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
<%--    <ShopNum1Account:A_LoadUserPhoto ID="A_LoadUserPhoto" runat="server" SkinFilename="Skin/A_LoadUserPhoto.ascx" />--%>
    <uc1:A_LoadUserPhoto ID="A_LoadUserPhoto1" runat="server" />
    </form>
</body>
</html>
