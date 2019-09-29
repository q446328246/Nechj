<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="Themes/Skin_Default/js/jquery-1.js"></script>
</head>
<body>
    <form id="from1" runat="server">
    <!--head start-->
    <!-- #include file="headShop.aspx" -->
    <!--main start-->
    <div class="FlowCat_cont">
        <div class="warp_site">
            <span id="PageAddressCategory"><a href=''>Ê×Ò³</a>&nbsp;&gt;&nbsp;µØÍ¼</span>
        </div>
        <ShopNum1:AgentCountOfArea ID="AgentCountOfArea" runat="server" SkinFilename="AgentCountOfArea.ascx" />
    </div>
    <script type="text/javascript" language="javascript" src="Themes/Skin_Default/js/jquery-maphilight.js"></script>
    <!--main end-->
    <!--foot start-->
    <!-- #include file="foot2.aspx" -->
    <!--foot end-->
    </form>
</body>
</html>
