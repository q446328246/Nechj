<%@ Page Language="C#" %>

<%@ Register Src="Skin/M_PayOp.ascx" TagName="M_PayOp" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <%--    <ShopNum1:M_PayOp ID="M_PayOp" runat="server" SkinFilename="skin/M_PayOp.ascx" />--%>
    <uc1:M_PayOp ID="M_PayOp1" runat="server" />
    </form>
</body>
</html>
