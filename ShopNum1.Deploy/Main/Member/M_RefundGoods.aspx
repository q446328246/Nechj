<%@ Page Language="C#" EnableViewState="false" %>

<%@ Register src="Skin/M_RefundGoods.ascx" tagname="M_RefundGoods" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>退款申请</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script src="js/jquery.pack.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="js/jquery.form.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <%--<ShopNum1:M_RefundGoods ID="M_RefundGoods" runat="server" SkinFilename="skin/M_RefundGoods.ascx" />--%>
    <uc1:M_RefundGoods ID="M_RefundGoods1" runat="server" />
    </form>
</body>
</html>
