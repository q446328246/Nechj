<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberRegister.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Themes.Skin_Default.MemberRegister" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="skins/MemberRegister.ascx" TagName="MemberRegister" TagPrefix="uc1" %>
<%@ Register Src="skins/Bottom.ascx" TagName="Bottom" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Themes/Skin_Default/Js/jquery.min.js" type="text/javascript"></script>
    <link href="Themes/Skin_Default/inc/Style/top.css" rel="stylesheet" type="text/css" />
    <!--[if lte IE 6]>
    <script src="Themes/Skin_Default/Js/DD_belatedPNG_0.0.8a.js" type="text/javascript"></script>
    <script type="text/javascript">
        DD_belatedPNG.fix('div, ul, img, li, input , a');
    </script>
    <![endif]-->
</head>
<body style="background: #f6f6f6;">
    <form id="from1" runat="server">
    <!--head Start-->
    <div id="top">
        <a target="_blank" href='http://<%=ShopSettings.siteDomain  %>'>
            <div class="top_box">
                <div class="logo_login">
                    塘江国际电子商务中心</div>
            </div>
        </a>
    </div>
    <!--//head End-->
    <!--main Start-->
    <div class="LoginBox m_top">
        <uc1:MemberRegister ID="MemberRegister1" runat="server" />
    </div>
    <!--//main End-->
    <!--foot Start-->
    <div class="wrapBox FootMessage">
        <uc2:Bottom ID="Bottom1" runat="server" />
    </div>
    <!--//foot End-->
    </form>
</body>
</html>
