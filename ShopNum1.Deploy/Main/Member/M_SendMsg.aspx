<%@ Page Language="C#" EnableViewState="false" %>

<%@ Register Src="Skin/M_SendMsg.ascx" TagName="M_SendMsg" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发送站内消息</title>
    <script type="text/javascript" language="javascript" src="js/jquery-1.6.2.min.js"></script>
    <link rel='stylesheet' type='text/css' href='style/m.css' />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:M_SendMsg ID="M_SendMsg1" runat="server" />
    </div>
<%--    <ShopNum1:M_SendMsg ID="M_SendMsg" runat="server" SkinFilename="Skin/M_SendMsg.ascx" />--%>
    </form>
</body>
</html>
