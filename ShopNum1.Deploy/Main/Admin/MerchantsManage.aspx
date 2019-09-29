<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="MerchantsManage.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.MerchantsManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>招商管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <link rel="stylesheet" type="text/css" href="ckeditor/style.css" />
    <script type="text/javascript" src="ckeditor/ckeditor.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    招商管理</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div>
            <textarea cols="70" id="ckeditormark" runat="server" name="editor1" style="height: 600px;
                width: 100%;"></textarea>
            <script type="text/javascript">                CKEDITOR.replace('ckeditormark', { fullPage: true, height: '460px' });
                CKEDITOR.tools.callFunction; </script>
            <!--通过这个样式控制uiColor : '#9AB8F3'，-->
            <asp:Button ID="butSave" runat="server" OnClick="butSave_Click" Text="保存修改" class="fanh" />
        </div>
    </div>
    </form>
</body>
</html>
