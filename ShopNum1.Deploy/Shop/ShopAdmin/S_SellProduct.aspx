<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>�����е���Ʒ</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <script type="text/javascript" language="javascript" src="/JS/DatePicker/WdatePicker.js"> </script>
    <script type="text/javascript" language="javascript" src="js/showimg.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <span class="spanrig"><a href="S_SellGoods_One.aspx?op=add&step=one" class="tianjiafl lmf_btn"
                target="_blank">�����Ʒ</a> </span><a href="S_Welcome.aspx">��������</a><span class="breadcrume_icon">>></span><span
                    class="breadcrume_text">�����е���Ʒ</span></p>
        <ShopNum1ShopAdmin:S_SellProduct ID="S_SellProduct" PageSize="10" runat="server"
            SkinFilename="skin/S_SellProduct.ascx" />
    </div>
    </form>
</body>
</html>
