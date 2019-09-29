<%@ Page Language="C#" EnableViewState="false" %>

<%@ Register Src="Skin/M_RefundManage.ascx" TagName="M_RefundManage" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>退款管理</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" language="javascript">
        window.onerror = function () { return true; }
    </script>
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"></script>
    <script type="text/javascript" language="javascript" src="/shop/shopadmin/js/dshow.js"></script>
    <link rel='stylesheet' type='text/css' href='/shop/shopadmin/style/dshow.css' />
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="M_Welcome.aspx">我是买家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">退款管理</span></p>
        <uc1:M_RefundManage ID="M_RefundManage1" runat="server" PageSize="10" />
        <%--     <ShopNum1:M_RefundManage ID="M_RefundManage" runat="server" PageSize="10" SkinFilename="skin/M_RefundManage.ascx" />--%>
    </div>
    </form>
</body>
</html>
