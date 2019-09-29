<%@ Page Language="C#" EnableViewState="false" %>

<%@ Register Src="Skin/M_SysMsg.ascx" TagName="M_SysMsg" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统消息</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script src="js/jquery.pack.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="js/Common.js"></script>
    <%-- <script type="text/javascript" language="javascript" src="js/Alert.js"></script>--%>
    <script type="text/javascript" language="javascript">
        var ajax_delurl = "/Api/Main/Member/DeleteOp.ashx";
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="M_Welcome.aspx">我是买家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">系统消息</span></p>
        <uc1:M_SysMsg ID="M_SysMsg1" runat="server" PageSize="10" />
        <%--        <ShopNum1:M_SysMsg ID="M_SysMsg1" runat="server" SkinFilename="Skin/M_SysMsg.ascx"
            PageSize="10" />--%>
    </div>
    </form>
</body>
</html>
