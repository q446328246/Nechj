
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M_TJmemberTGYWY.aspx.cs" Inherits="ShopNum1.Deploy.Main.Member.M_TJmemberTGYWY" %>

<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Import Namespace="ShopNum1.Common" %>

<%@ Register Src="Skin/M_TJmemberTGYWY.ascx" TagName="M_TJmemberTGYWY" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%=TEXT%></title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="/js/DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="js/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/js/artDialog/artDialog.js"></script>
    <style type="text/css">
       td
       {
           text-align:left;
           }
   </style>
   <script type="text/javascript">
       var jiathis_config = {
           url: "<%=URL %>",
           title: "注册顾客",
           summary: "<%=TEXT%>",
           shortUrl: false,
           hideMore: false
       } 
</script> 
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="M_Welcome.aspx">我是买家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">推广链接</span></p>
        <uc1:M_TJmemberTGYWY ID="M_TJmemberTGYWY1" runat="server" PageSize="10" />
        <%--        <ShopNum1:M_CreditDetails ID="M_CreditDetails" runat="server" SkinFilename="Skin/M_CreditDetails.ascx"
            PageSize="10" />--%>
            <asp:Image ID="Image1" runat="server" />
       </div>
    </form>
</body>
</html>
