<%@ Page Language="C#" EnableViewState="false" %>

<%@ Register Src="Skin/M_Msg.ascx" TagName="M_Msg" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会员信息</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" language="javascript" src="js/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" language="javascript" src="js/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/js/artDialog/artDialog.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="M_Welcome.aspx">我是买家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">会员消息</span></p>
        <uc1:M_Msg ID="M_Msg1" runat="server" PageSize="10" />
        <%--      <ShopNum1:M_Msg ID="M_Msg" runat="server" SkinFilename="Skin/M_Msg.ascx" PageSize="10" />--%>
    </div>
    </form>
</body>
</html>
