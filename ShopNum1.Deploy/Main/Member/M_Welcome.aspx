<%@ Page Language="C#" EnableViewState="false" %>

<%@ Register Src="Skin/M_Welcome.ascx" TagName="M_Welcome" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>欢迎页</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
</head>
<body>
    <form id="form1" runat="server">
    <%--<ShopNum1:M_Welcome ID="M_Welcome" runat="server" SkinFilename="Skin/M_Welcome.ascx" />--%>
    <uc2:M_Welcome ID="M_Welcome1" runat="server" />
    </form>
</body>
</html>
<%--  --%>