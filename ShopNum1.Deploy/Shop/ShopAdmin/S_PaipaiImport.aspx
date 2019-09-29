<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>拍拍数据包导入 Jely20130817</title>
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <script type="text/javascript" src="/JS/jquery-1.6.2.min.js"> </script>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" src="uploadify/swfobject.js"> </script>
    <script type="text/javascript" src="uploadify/jquery.uploadify.v2.1.4.min.js"> </script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="javascript:return WebForm_OnSubmit();"
    enctype="multipart/form-data">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">拍拍数据包批量导入</span></p>
        <script type="text/javascript" src="js/Page_ClientValidate.js"> </script>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <ShopNum1ShopAdmin:S_PaipaiImport ID="S_PaipaiImport" runat="server" SkinFilename="skin/S_PaipaiImport.ascx" />
    </div>
    </form>
</body>
</html>
