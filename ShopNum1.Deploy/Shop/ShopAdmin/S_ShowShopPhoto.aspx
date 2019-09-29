<%@ Page Language="C#" EnableViewState="false" %>

<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>相册</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script language="javascript" type="text/javascript" src="js/jquery.pack.js"> </script>
    <script type="text/javascript" language="javascript" src="JS/CommonJS.js"> </script>
    <link href="uploadify/uploadify.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="uploadify/jquery-1.4.2.min.js"> </script>
    <script type="text/javascript" src="uploadify/swfobject.js"> </script>
    <script type="text/javascript" src="uploadify/jquery.uploadify.v2.1.4.min.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <script type="text/javascript" language="javascript">
        //跳转到制定的页码
        function ontoPage(txtId) {
            location.href = '?isread=<%= ShopNum1.Common.Common.ReqStr("type") %>&pageid=' + $("#txtIndex").val();
        }

        $(function () {
            $(".spanfy,.page_3,.page_4,.page_5").hide();
        });
    </script>
    <ShopNum1ShopAdmin:S_ShowShopPhoto ID="S_ShowShopPhoto" runat="server" SkinFilename="Skin/S_ShowShopPhoto.ascx"
        PageSize="8" />
    </form>
</body>
</html>
