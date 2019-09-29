<%@ Page Language="C#" EnableViewState="false" %>

<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="Skin/M_Comment.ascx" TagName="M_Comment" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>我的评论</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="js/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/js/artDialog/artDialog.js"></script>
    <script type="text/javascript" language="javascript" src="/js/DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <%--    <ShopNum1:M_Comment ID="M_Comment" runat="server" SkinFilename="Skin/M_Comment.ascx"
        PageSize="10" />--%>
    <uc1:M_Comment ID="M_Comment1" runat="server" PageSize="10" />
    </form>
</body>
</html>
