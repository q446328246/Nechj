<%@ Page Language="C#" EnableViewState="false" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register src="Skin/M_ComplaintsDetailed.ascx" tagname="M_ComplaintsDetailed" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的投诉</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <link type="text/css" href="/js/artDialog/skins/chrome.css" rel="stylesheet"></link>
</head>
<body>
    <form id="form1" runat="server">
    <div class="tjsp_mian">
        <p class="ptitle">
            <a href="M_Welcome.aspx">我是买家</a><span class="breadcrume_icon">>></span><a href="M_Complaints.aspx">我的投诉</a><span
                class="breadcrume_icon">>></span> <span class="breadcrume_text">投诉详细</span></p>
        <uc1:M_ComplaintsDetailed ID="M_ComplaintsDetailed1" runat="server" />
<%--        <ShopNum1:M_ComplaintsDetailed ID="M_ComplaintsDetailed" runat="server" SkinFilename="Skin/M_ComplaintsDetailed.ascx" />--%>
    </div>
    </form>
</body>
</html>
