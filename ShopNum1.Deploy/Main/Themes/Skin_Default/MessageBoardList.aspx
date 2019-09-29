<%@ Page Language="C#" AutoEventWireup="true" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
</head>
<body>
    <form id="form1" runat="server">
    <ShopNum1:MessageBoardList ID="MessageBoardList" runat="server" SkinFilename="MessageBoardList.ascx" />
    </form>
</body>
</html>
