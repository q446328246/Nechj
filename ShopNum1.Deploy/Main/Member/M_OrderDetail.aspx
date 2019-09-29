<%@ Page Language="C#" EnableViewState="false" %>

<%@ Register Src="Skin/M_Head.ascx" TagName="M_Head" TagPrefix="uc1" %>
<%@ Register Src="Skin/M_OrderDetail.ascx" TagName="M_OrderDetail" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会员订单详细页面</title>
    <link rel='stylesheet' type='text/css' href='style/myorder.css' />
    <script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="js/M_Index.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="containe_bg">
        <uc1:M_Head ID="M_Head1" runat="server" />
        <%--        <ShopNum1:M_Head ID="M_Head" runat="server" SkinFilename="Skin/M_Head.ascx" />--%>
        <div id="content_bg">
            <%--           <ShopNum1:M_OrderDetail ID="M_OrderDetail" runat="server" SkinFilename="skin/M_OrderDetail.ascx" />--%>
            <uc2:M_OrderDetail ID="M_OrderDetail1" runat="server" />
        </div>
        <!--底部文件调用-->
        <!-- #include file="m_bottom.aspx" -->
        <!--底部文件调用-->
    </div>
    </form>
</body>
</html>
