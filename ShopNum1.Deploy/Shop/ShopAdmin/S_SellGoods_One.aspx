<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>唐江国际商城 发布商品_选择分类</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script language="javascript" type="text/javascript" src="js/jquery.pack.js"> </script>
    <script type="text/javascript" language="javascript">
        if (top.location != location) top.location.href = location.href;
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="containe_bg">
        <!--头部Top-->
        <ShopNum1ShopAdmin:S_Head ID="S_Head" runat="server" SkinFilename="Skin/S_Head.ascx" />
        <!--内容部分Content-->
        <div id="content_bg">
            <ShopNum1ShopAdmin:S_SellGoods1 ID="S_SellGoods1" runat="server" SkinFilename="Skin/S_SellGoods1.ascx" />
        </div>
        <div style="clear: both;">
        </div>
        <!--页面底部Bottom-->
        <div style="clear: both;">
        </div>
        <!--页面底部Bottom-->
        <ShopNum1ShopAdmin:S_Bottom ID="S_Bottom" runat="server" SkinFilename="Skin/S_Bottom.ascx"
            class="foot_bg" />
    </div>
    </form>
</body>
</html>
