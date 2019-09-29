<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="T5.aspx.cs" Inherits="ShopNum1.Deploy.Main.Themes.Skin_Default.T5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Themes/Skin_Default/js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="Themes/Skin_Default/js/jquery1.42.min.js"></script>
    <script type="text/javascript" src="Themes/Skin_Default/js/jquery.SuperSlide.2.1.1.js"></script>
    <link href="Themes/Skin_Default/Style/datouwang.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <!--head start-->
    <!-- #include file="headbak.aspx" -->
    <!--//head end-->
    
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--foot end-->
    <!--js-->
    <script src="/js/load.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8">
        $(function () {
            $("#content img:not([class='imghdp'])").lazyload({ placeholder: "/ImgUpload/noImg.jpg" });
            $("img").each(function () { $(this).attr("src", $(this).attr("original")); });
        });
    </script>
    </form>
</body>
</html>