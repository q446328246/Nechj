<%@ Page Language="C#" AutoEventWireup="true" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <!--head start-->
    <!-- #include file="head.aspx" -->
    <!--main start-->
    <div class="FlowCat_cont">
        <div class="warp clearfix">
            <!--left start-->
            <div class="sidebar fl">
            </div>
            <!--留言添加-->
            <ShopNum1:MessageBoardAdd ID="MessageBoardAdd" runat="server" SkinFilename="MessageBoardAdd.ascx" />
            <!--foot start-->
        </div>
    </div>
    <!-- #include file="foot1.aspx" -->
    <!--foot end -->
    </form>
</body>
</html>
