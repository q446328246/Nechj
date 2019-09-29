<%@ Page Language="C#" EnableViewState="false" %>

<%@ Register Src="Skin/M_LifeOrderList.ascx" TagName="M_LifeOrderList" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>生活服务订单</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="/JS/DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <%-- <ShopNum1:M_LifeOrderList ID="M_LifeOrderList" runat="server" PageSize="8" SkinFilename="skin/M_LifeOrderList.ascx" />--%>
    <uc1:M_LifeOrderList ID="M_LifeOrderList1" runat="server" PageSize="10" />
    </form>
</body>
</html>
