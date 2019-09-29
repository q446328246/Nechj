<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" language="javascript" src="/JS/DatePicker/WdatePicker.js"> </script>
    <script type="text/javascript" language="javascript" src="js/dshow.js"> </script>
    <link rel='stylesheet' type='text/css' href='style/dshow.css' />
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">退款管理</span></p>
        <ShopNum1ShopAdmin:S_ExitManage ID="S_ExitManage" runat="server" PageSize="10" SkinFilename="skin/S_ExitManage.ascx" />
    </div>
    </form>
</body>
</html>
