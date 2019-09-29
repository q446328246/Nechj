<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Robots_List.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Robots_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Robots设置</title>
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
                    Robots编辑</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div style="margin: 10px 30px 0 30px; width: 80%;">
                <textarea cols="70" id="ckeditormark" runat="server" name="editor1" style="height: 320px;
                    width: 100%;"></textarea>
                <asp:Button ID="butSave" runat="server" OnClick="butSave_Click" Text="保存修改" class="fanh"
                    Style="display: block; margin-top: 14px;" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
