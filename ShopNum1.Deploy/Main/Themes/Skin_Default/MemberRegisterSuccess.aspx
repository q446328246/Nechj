<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberRegisterSuccess.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Themes.Skin_Default.MemberRegisterSuccess" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="skins/MemberRegisterSuccess.ascx" TagName="MemberRegisterSuccess"
    TagPrefix="uc1" %>
<%@ Register src="skins/Bottom.ascx" tagname="Bottom" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Themes/Skin_Default/Js/jquery.min.js" type="text/javascript"></script>
    <link href="Themes/Skin_Default/inc/Style/top.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="from1" runat="server">
    <!--head start-->
    <div id="top">
        <a target="_blank" href='http://<%=ShopSettings.siteDomain  %>'>
            <div class="top_box">
                <div class="logo_login">
                    塘江国际电子商务中心</div>
            </div>
        </a>
    </div>
    <!--main start-->
    <div class="FlowCat_cont m_top">
        <div class="article_cont" style="border: 1px solid #CCCCCC;">
            <!--底部帮助-->
            <uc1:MemberRegisterSuccess ID="MemberRegisterSuccess1" runat="server" />
        </div>
    </div>
    <!--foot start-->
    <div class="wrapBox FootMessage">

        <uc2:Bottom ID="Bottom1" runat="server" />

    </div>
    <!--foot end-->
    </form>
</body>
</html>
