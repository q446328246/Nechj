<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>直通车申请</title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="js/jquery.pack.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><a href="S_ZtcApply_List.aspx">直通车申请列表</a><span
                class="breadcrume_icon">>></span> <span class="breadcrume_text">直通车申请</span></p>
        <ShopNum1ShopAdmin:S_ZtcApply_Edit ID="S_ZtcApply_Edit" runat="server" SkinFilename="skin/S_ZtcApply_Edit.ascx" />
        <div class="sp_dialog sp_dialog_out" style="display: none;" id="sp_dialog_outDiv">
            <!-----红包------>
            <div class="sp_dialog_cont" style="display: none;" id="sp_dialog_contDiv">
                <div class="sp_tan">
                    <h4>
                        选择商品</h4>
                    <div class="sp_close">
                        <a href="javascript:void(0)" onclick=" funClose() "></a>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="sp_tan_content">
                    <ShopNum1ShopAdmin:S_ZtcApply ID="S_ZtcApply" runat="server" SkinFilename="skin/S_ZtcApply.ascx" />
                </div>
            </div>
        </div>
        <div class="sp_overlay" style="display: none" id="sp_overlayDiv">
        </div>
    </div>
    </form>
</body>
</html>
