<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>欢迎页</title>
    <link rel='stylesheet' type='text/css' href='style/s.css' />
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
</head>
<body>
    <form action="?act=store_album&op=replace_image_upload" method="post" enctype="multipart/form-data"
    id="image_form">
    <ShopNum1ShopAdmin:S_ReplaceUpload ID="S_ReplaceUpload" runat="server" SkinFilename="skin/S_ReplaceUpload.ascx" />
    </form>
</body>
</html>
