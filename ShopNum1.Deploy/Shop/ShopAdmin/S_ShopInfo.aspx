<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>店铺信息编辑</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <link rel='stylesheet' type='text/css' href='style/dshow.css' />
    <script type="text/javascript" src="js/dshow.js"> </script>
    <script type="text/javascript" src="js/SpryTabbedPanels.js"> </script>
    <script type="text/javascript" language="javascript"> </script>
    <script src="JS/jquery.pack.js" type="text/javascript"> </script>
    <script src="/Main/js/areas.js" type="text/javascript"> </script>
    <script src="/Main/js/location.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        $(function () {
            // 加载区域
            $("#p_local").LocationSelect();
        })
    </script>
    <script type="text/javascript" language="javascript">
        function checkSumbit() {
            //提交地区信息
            var info = $("#p_local").getLocation();
            if (info.pcode == "0") {
                $("#p_local").next().show();
            }
            $("#S_ShopInfo_ctl00_S_ShopInfo_Settings_ctl00_hid_Area").val(info.province + "," + info.city + "," + info.district + "|" + info.pcode + "," + info.ccode + "," + info.dcode);

        }
    </script>
    <script type="text/javascript" language="javascript">
        $(document).ready(
                function () {
                    var area = $("#S_ShopInfo_ctl00_S_ShopInfo_Settings_ctl00_hid_Area").val().split("|");
                    if ($("#S_ShopInfo_ctl00_S_ShopInfo_Settings_ctl00_hid_Area").val() != "") {
                        var areacode = area[1].split(",");
                        var areaname = area[0].split(",");
                        $("select[name='province']").append("<option value=\"" + areacode[0] + "\" selected=\"selected\">" + areaname[0] + "</option>");
                        $("select[name='city']").append("<option value=\"" + areacode[1] + "\" selected=\"selected\">" + areaname[1] + "</option>");
                        $("select[name='district']").append("<option value=\"" + areacode[2] + "\" selected=\"selected\">" + areaname[2] + "</option>");
                    }

                }
            );
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">店铺信息</span></p>
        <ShopNum1ShopAdmin:S_ShopInfo ID="S_ShopInfo" runat="server" SkinFilename="skin/S_ShopInfo.ascx" />
    </div>
    </form>
</body>
</html>
