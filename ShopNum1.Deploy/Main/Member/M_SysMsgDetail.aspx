<%@ Page Language="C#" EnableViewState="false" %>

<%@ Register Src="Skin/M_SysMsgDetail.ascx" TagName="M_SysMsgDetail" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统信息详细</title>
    <link rel='stylesheet' type='text/css' href='style/m.css' />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--        <ShopNum1:M_SysMsgDetail ID="M_SysMsgDetail" runat="server" SkinFilename="Skin/M_SysMsgDetail.ascx" />--%>
        <uc1:M_SysMsgDetail ID="M_SysMsgDetail1" runat="server" />
    </div>
    </form>
</body>
</html>
