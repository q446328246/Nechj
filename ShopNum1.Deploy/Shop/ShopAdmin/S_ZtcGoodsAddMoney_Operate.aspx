<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>直通车商品编辑</title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="js/jquery.pack.js"> </script>
    <link rel='stylesheet' type='text/css' href='style/dshow.css' />
    <script type="text/javascript" src="js/dshow.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="#">我是卖家</a> >> <a href="#">促销管理</a> >> <a href="S_ZtcApply_List.aspx">直通车申请列表</a>
            >>直通车续费
        </p>
        <ShopNum1ShopAdmin:S_ZtcGoodsAddMoney_Operate ID="S_ZtcGoodsAddMoney_Operate" runat="server"
            SkinFilename="skin/S_ZtcGoodsAddMoney_Operate.ascx" />
    </div>
    </form>
</body>
</html>
