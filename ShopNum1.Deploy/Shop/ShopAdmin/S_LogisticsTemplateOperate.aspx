<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加邮费模板</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" language="javascript" src="/Main/js/setTable.js"> </script>
    <script type="text/javascript" src="/JS/jquery-1.6.2.min.js"> </script>
    <script type="text/javascript" language="javascript" src="js/S_LogisticsTemplateOperate.js"> </script>
    <script type="text/javascript" language="javascript">
        parent.document.getElementById("mainFrame").style.height = "1400px";
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><a href="S_Logistics.aspx">邮费模板</a><span
                class="breadcrume_icon">>></span><span class="breadcrume_text">添加模板操作</span></p>
        <ShopNum1ShopAdmin:S_LogisticsTemplateOperate ID="S_LogisticsTemplateOperate" runat="server"
            SkinFilename="skin/S_LogisticsTemplateOperate.ascx" />
    </div>
    </form>
</body>
</html>
