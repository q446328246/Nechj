<%@ Page Language="C#" EnableViewState="false" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="Skin/M_MyMessageBoardDetailed.ascx" TagName="M_MyMessageBoardDetailed"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的店铺留言详细</title>
    <link rel='stylesheet' type='text/css' href='style/m.css' />
    <link type="text/css" href="/js/artDialog/skins/chrome.css" rel="stylesheet"></link>
    <script type="text/javascript" language="javascript">
        function sethash() {
            var hashH = document.documentElement.scrollHeight;
            parent.document.getElementById("mainFrame").style.height = hashH + "px";
        }
        window.onload = sethash;
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <%--    <ShopNum1:M_MyMessageBoardDetailed ID="M_MyMessageBoardDetailed" runat="server" SkinFilename="Skin/M_MyMessageBoardDetailed.ascx" />--%>
    <uc1:M_MyMessageBoardDetailed ID="M_MyMessageBoardDetailed1" runat="server" />
    </form>
</body>
</html>
