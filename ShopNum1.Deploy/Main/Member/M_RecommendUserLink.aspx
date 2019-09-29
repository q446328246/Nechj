<%@ Page Language="C#" EnableViewState="false" %>

<%@ Register src="Skin/M_RecommendUserLink.ascx" tagname="M_RecommendUserLink" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>快捷推荐</title>
    <link rel='stylesheet' type='text/css' href='style/m.css' />
    <script type="text/javascript" language="javascript" src="js/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" language="javascript" src="js/Common.js"></script>
    <link rel='stylesheet' type='text/css' href='js/dragbox/Shopnum1.DragBox.min.css' />
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="M_Welcome.aspx">我是买家</a><span class="breadcrume_icon">>></span><a href="M_RecommendUser.aspx">推荐会员列表</a><span
                class="breadcrume_icon">>></span><span class="breadcrume_text">快捷推荐</span></p>
        <uc1:M_RecommendUserLink ID="M_RecommendUserLink1" runat="server" />
 <%--       <ShopNum1:M_RecommendUserLink ID="M_RecommendUserLink" runat="server" SkinFilename="Skin/M_RecommendUserLink.ascx" />--%>
    </div>
    </form>
</body>
</html>
