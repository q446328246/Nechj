<%@ Page Language="C#" EnableViewState="false" %>

<%@ Register src="Skin/M_ShopVideoCommentDetail.ascx" tagname="M_ShopVideoCommentDetail" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>店铺视频评论详细</title>
    <link rel='stylesheet' type='text/css' href='style/m.css' />
</head>
<body>
    <form id="form1" runat="server">
    <div class="tjsp_mian">
        <p class="ptitle">
            <a href="M_Welcome.aspx">我是买家</a><span class="breadcrume_icon">>></span><a href="M_Comment.aspx?type=1&pageid=1">供求评论</a><span
                class="breadcrume_icon">>></span><span class="breadcrume_text">我的店铺视频评论详细</span></p>
        <uc1:M_ShopVideoCommentDetail ID="M_ShopVideoCommentDetail1" runat="server" />
<%--        <ShopNum1:M_ShopVideoCommentDetail ID="M_ShopVideoCommentDetail" runat="server" SkinFilename="Skin/M_ShopVideoCommentDetail.ascx" />--%>
    </div>
    </form>
</body>
</html>
