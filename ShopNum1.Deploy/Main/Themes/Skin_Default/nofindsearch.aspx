<%@ Page Language="C#" EnableViewState="false" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>没有查询找到相关的数据</title>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <!--head start-->
    <!-- #include file="headShop.aspx" -->
    <!--main start-->
    <!-- middle -->
    <!--没有搜索结果-->
    <ShopNum1:nofindsearch ID="nofindsearch" runat="server" SkinFilename="nofindsearch.ascx" />
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--       end                -->
    </form>
</body>
</html>
