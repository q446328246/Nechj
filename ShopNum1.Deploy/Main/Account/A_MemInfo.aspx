<%@ Page Language="C#" EnableViewState="false" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register src="Skin/A_MemInfo.ascx" tagname="A_MemInfo" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>会员中心-个人信息</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script src="/js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="js/jquery.pack.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/SpryTabbedPanels.js"></script>
    <script src="/JS/DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="/main/js/location.js" type="text/javascript"></script>
    <script src="/main/js/areas.js" type="text/javascript"></script>
    <script src="js/Common.js" type="text/javascript"></script>
    <link href="/Shop/ShopAdmin/style/dshow.css" rel="stylesheet" type="text/css" />
    <script src="/Shop/ShopAdmin/js/dshow.js" type="text/javascript"></script>

</head>
<body>
    <div class="dpsc_mian">
        <p class="ptitle">
            <span class="spanrig"></span><a href="A_Welcome.aspx">账户管理</a><span class="breadcrume_icon">>></span><span
                class="breadcrume_text">个人信息</span></p>
        <form class="cmxform" id="signupForm" runat="server">
<%--        <ShopNum1Account:A_MemInfo ID="A_MemInfo" runat="server" SkinFilename="Skin/A_MemInfo.ascx" />--%>
        <uc1:A_MemInfo ID="A_MemInfo1" runat="server" />
        </form>
    </div>
</body>
</html>
