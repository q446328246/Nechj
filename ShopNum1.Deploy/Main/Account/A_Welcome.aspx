<%@ Page Language="C#" EnableViewState="false" Buffer="false" %>

<%@ Register Src="Skin/A_Welcome.ascx" TagName="A_Welcome" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>账户管理</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script src="/js/jquery-1.6.2.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="A_Welcome.aspx">账户管理</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">我的账户</span></p>
        <uc1:A_Welcome ID="A_Welcome1" runat="server" />
        <%--<ShopNum1Account:A_Welcome ID="A_Welcome" runat="server" SkinFilename="Skin/A_Welcome.ascx" />--%>
    </div>
    </form>
</body>
</html>
