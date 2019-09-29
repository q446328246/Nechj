<%@ Page Language="C#" EnableViewState="false" %>

<%@ Register Src="Skin/M_AddSupply.ascx" TagName="M_AddSupply" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发布供求</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
</head>
<body>
    <form id="form1" runat="server">
    <div class="tjsp_mian">
        <p class="ptitle">
            <a href="M_Welcome.aspx">我是买家</a><span class="breadcrume_icon">>></span><a href="M_MySupply.aspx">我的供求</a><span
                class="breadcrume_icon">>></span><span class="breadcrume_text">供求操作</span></p>
        <uc1:M_AddSupply ID="M_AddSupply1" runat="server" />
        <%--        <ShopNum1:M_AddSupply ID="M_AddSupply" runat="server" SkinFilename="Skin/M_AddSupply.ascx" />--%>
    </div>
    </form>
</body>
</html>
