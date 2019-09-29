<%@ Page Language="C#" EnableViewState="false" %>

<%@ Register Src="Skin/A_AddressOpeater.ascx" TagName="A_AddressOpeater" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>账户管理-账户安全设置</title>
    <script src="/js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.pack.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="js/Common.js"></script>
    <script src="../js/location.js" type="text/javascript"></script>
    <script src="../js/areas.js" type="text/javascript"></script>
</head>
<body>
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="A_Welcome.aspx">账户管理</a><span class="breadcrume_icon">>></span><a href="A_ShipAddress.aspx">收货地址列表</a><span
                class="breadcrume_icon">>></span><span class="breadcrume_text">收货地址</span>
            <form id="fromAddress" runat="server">
            <%--            <ShopNum1Account:A_AddressOpeater ID="A_AddressOpeater" runat="server" SkinFilename="Skin/A_AddressOpeater.ascx" />--%>
            <uc1:A_AddressOpeater ID="A_AddressOpeater1" runat="server" />
            </form>
    </div>
</body>
</html>
