﻿<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加店铺分类</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <ShopNum1ShopAdmin:S_ProductCategory_Operate ID="S_ProductCategory_Operate" runat="server"
        SkinFilename="skin/S_ProductCategory_Operate.ascx" />
    </form>
</body>
</html>
