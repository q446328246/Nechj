<%@ Page Language="C#" EnableViewState="false" %>

<%@ Register Src="Skin/M_ShopNewsCommentDetail.ascx" TagName="M_ShopNewsCommentDetail"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>店铺资讯评论详细</title>
    <link rel='stylesheet' type='text/css' href='style/m.css' />
</head>
<body>
    <form id="form1" runat="server">
    <div class="tjsp_mian">
        <p class="ptitle">
            <a href="M_Welcome.aspx">我是买家</a><span class="breadcrume_icon">>></span><a href="M_Comment.aspx?type=4&pageid=1">供求评论</a><span
                class="breadcrume_icon">>></span><span class="breadcrume_text">我的资讯评论详细</span></p>
        <uc1:M_ShopNewsCommentDetail ID="M_ShopNewsCommentDetail1" runat="server" />
        <%--        <ShopNum1:M_ShopNewsCommentDetail ID="M_ShopNewsCommentDetail" runat="server" SkinFilename="Skin/M_ShopNewsCommentDetail.ascx" />--%>
    </div>
    </form>
</body>
</html>
