<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>��Ʒ����</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">��������</a><span class="breadcrume_icon">>></span><a href="S_MessageBoardList.aspx">��Ʒ����</a><span
                class="breadcrume_icon">>></span> <span class="breadcrume_text">��Ʒ������ϸ</span></p>
        <ShopNum1ShopAdmin:S_ProductMessageBoardReply ID="S_ProductMessageBoardReply" runat="server"
            SkinFilename="skin/S_ProductMessageBoardReply.ascx" />
    </div>
    </form>
</body>
</html>
