<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M_MemberApprovalDetailedA.aspx.cs" Inherits="ShopNum1.Deploy.Main.Member.M_MemberApprovalDetailedA" %>
<%@ Register Src="Skin/M_MemberApprovalDetailed.ascx" TagName="M_MemberApprovalDetailed" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>详细信息</title>
    <script type="text/javascript" language="javascript" src="js/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" language="javascript" src="js/Common.js"></script>
    <link rel='stylesheet' type='text/css' href='js/dragbox/Shopnum1.DragBox.min.css' />

</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            
     <a href="M_Welcome.aspx">我是买家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">详细信息</span></p>
       
        <uc1:M_MemberApprovalDetailed ID="M_MemberApprovalDetailed" runat="server" PageSize="10" />
       <%--  <ShopNum1:M_MemberApproval1 ID="M_MemberApproval1" runat="server" SkinFilename="Skin/M_MemberApproval1.ascx" />--%>
    </div>
    </form>
</body>
</html>
