<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B_CSChongZhi.aspx.cs" Inherits="ShopNum1.Deploy.Main.Bourse.B_CSChongZhi" %>
<%@ Register Src="Skin/B_CSChongZhi.ascx" TagName="B_CSChongZhi" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="/js/jquery-1.6.2.min.js" type="text/javascript"></script>
  
    <link href="../Account/style/style.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.pack.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/SpryTabbedPanels.js"></script>
    <script src="/JS/DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="js/Common.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="B_Welcome.aspx">原料中心</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">充值CS积分</span></p>
       
        
        <uc1:B_CSChongZhi ID="B_CSChongZhi1" runat="server"  />
     
    </div>
    </form>
</body>
</html>

