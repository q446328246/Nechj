<%@ Page Language="C#" EnableViewState="false" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register src="Skin/M_ReportDetailed.ascx" tagname="M_ReportDetailed" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的举报</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
</head>
<body>
    <form id="form1" runat="server" style="height: 800px;">
    <div class="tjsp_mian">
<%--        <ShopNum1:M_ReportDetailed ID="M_ReportDetailed" runat="server" SkinFilename="Skin/M_ReportDetailed.ascx" />--%>
        <uc1:M_ReportDetailed ID="M_ReportDetailed1" runat="server" />
    </div>
    </form>
</body>
</html>
