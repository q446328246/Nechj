<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
</head>
<body>
    <form id="form1" runat="server">
    <!--head Start-->
    <!-- #include file="headShop.aspx" -->
    <!--//head End-->
    <!--main Start-->
    <div class="warp clearfix">
        <!--left start-->
        <div class="sidebar fl">
        </div>
        <!--供求分类-->
        <ShopNum1:SupplyDemandCategory ID="supplyDemandCategory" runat="server" SkinFilename="SupplyDemandCategory.ascx" />
        <!--供求分类按模块显示-->
        <ShopNum1:SupplyDemandListByType ID="SupplyDemandListByType" Release="" Href="" runat="server"
            ShowCount="10" Code="001" CfTitle="供求分类按模块显示1" IsShowRepeaterTitle="true" SkinFilename="SupplyDemandListByType.ascx" />
        <!--供求分类按模块显示-->
        <ShopNum1:SupplyDemandListByType ID="SupplyDemandListByType1" Release="" Href=""
            runat="server" ShowCount="10" Code="001001" CfTitle="供求分类按模块显示2" IsShowRepeaterTitle="true"
            SkinFilename="SupplyDemandListByType.ascx" />
        <%-- 最新供求--%>
        <ShopNum1:SupplyDemandList ID="supplyDemandList" runat="server" ShowCount="5" SkinFilename="SupplyDemandList.ascx"
            ShowImage="0" />
    </div>
    <!--main End-->
    <!--foot Start-->
    <!-- #include file="foot1.aspx" -->
    <!--//foot End-->
    </form>
</body>
</html>
