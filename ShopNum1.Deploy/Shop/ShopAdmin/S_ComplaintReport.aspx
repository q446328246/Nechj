<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>举报管理</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script language="javascript" type="text/javascript" src="js/jquery.pack.js"> </script>
    <script type="text/javascript" src="js/SpryTabbedPanels.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="#">我是卖家</a> >> <a href="#">客户服务</a> >> <a href="S_MemberReport.aspx">举报管理</a>
            >>我要申诉</p>
        <ShopNum1ShopAdmin:S_ComplaintReport ID="S_ComplaintReport" runat="server" SkinFilename="Skin/S_ComplaintReport.ascx" />
    </div>
    </form>
</body>
</html>
