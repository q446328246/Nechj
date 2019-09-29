<%@ Page Language="C#" %>

<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>红包商品</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" src="js/SpryTabbedPanels.js"> </script>
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <script src="/Main/js/areas.js" type="text/javascript"> </script>
    <script src="/Main/js/location.js" type="text/javascript"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">红包商品</span></p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <ShopNum1ShopAdmin:S_ScoreProduct ID="S_ScoreProduct" runat="server" SkinFilename="skin/S_ScoreProduct.ascx" />
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
