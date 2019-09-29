<%@ Page Language="C#" EnableViewState="false" %>

<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>直通车申请列表</title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="js/jquery.pack.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">直通车申请列表</span></p>
        <ShopNum1ShopAdmin:S_ZtcApply_List ID="S_ZtcApply_List" runat="server" SkinFilename="skin/S_ZtcApply_List.ascx"
            PageSize="10" />
        <script type="text/javascript" language="javascript">
            //跳转到制定的页码
            function ontoPage(txtId) {
                location.href = '?isread=<%= ShopNum1.Common.Common.ReqStr("type") %>&pageid=' + $("#txtIndex").val();
            }
        </script>
    </div>
    </form>
</body>
</html>
