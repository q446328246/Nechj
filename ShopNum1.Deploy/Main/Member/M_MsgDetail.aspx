<%@ Page Language="C#" EnableViewState="false" %>

<%@ Register Src="Skin/M_MsgDetail.ascx" TagName="M_MsgDetail" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>消息详细</title>
    <link rel='stylesheet' type='text/css' href='style/m.css' />
</head>
<body>
    <form id="form1" runat="server">
    <%--    <ShopNum1:M_MsgDetail ID="M_MsgDetail" runat="server" SkinFilename="Skin/M_MsgDetail.ascx" />--%>
    <uc1:M_MsgDetail ID="M_MsgDetail1" runat="server" />
    </form>
</body>
</html>
