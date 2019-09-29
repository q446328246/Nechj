<%@ Page Language="C#" %>

<%@ Register Src="Skin/M_AddProductComment.ascx" TagName="M_AddProductComment" TagPrefix="uc1" %>
<%@ Register Src="Skin/M_Head.ascx" TagName="M_Head" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <script type="text/javascript" language="javascript" src="js/jquery-1.6.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="containe_bg">
        <%--        <ShopNum1:M_Head ID="M_Head" runat="server" SkinFilename="Skin/M_Head.ascx" />--%>
        <uc2:M_Head ID="M_Head1" runat="server" />
        <div id="content_bg">
            <%--<ShopNum1:M_AddProductComment ID="M_AddProductComment" runat="server" SkinFilename="skin/M_AddProductComment.ascx" />--%>
            <uc1:M_AddProductComment ID="M_AddProductComment1" runat="server" />
        </div>
        <!--底部文件调用-->
        <!-- #include file="m_bottom.aspx" -->
        <!--底部文件调用-->
    </div>
    </form>
</body>
</html>
