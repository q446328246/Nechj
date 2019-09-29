<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<table border="0" cellspacing="0" cellpadding="0" class="tabbiao">
    <tr>
        <td width="130" style="padding-left: 40px;">
            鼠标点击获取经纬度：
        </td>
        <td>
            <asp:TextBox ID="TextBoxMapValue" runat="server" CssClass="textwb"></asp:TextBox>
            <span class="red" id="errMapValue">*</span>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <div id="allmap" style="height: 500px; margin-left: 20px; width: 750px;">
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="line-height: 46px; padding-top: 20px; text-align: center;">
            <asp:Button ID="ButtonSave" runat="server" Text="设置" CssClass="baocbtn" />
        </td>
    </tr>
</table>
<!--地理位置 start-->
<script type="text/javascript" src="http://api.map.baidu.com/api?v=1.4"> </script>
<script type="text/javascript">
    var Result = $("#<%= TextBoxMapValue.ClientID %>").val();

    var map = new BMap.Map("allmap");
    map.centerAndZoom(new BMap.Point(Result.split(',')[0], Result.split(',')[1]), 14);

    var point = new BMap.Point(Result.split(',')[0], Result.split(',')[1]);
    var marker = new BMap.Marker(point);
    map.addOverlay(marker);


    map.addEventListener("click", function () {

    });


    map.addControl(new BMap.NavigationControl());
    //添加默认缩放平移控件
    map.addControl(new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_RIGHT, type: BMAP_NAVIGATION_CONTROL_SMALL }));
    //右上角，仅包含平移和缩放按钮
    map.addControl(new BMap.NavigationControl({ anchor: BMAP_ANCHOR_BOTTOM_LEFT, type: BMAP_NAVIGATION_CONTROL_PAN }));
    //左下角，仅包含平移按钮
    map.addControl(new BMap.NavigationControl({ anchor: BMAP_ANCHOR_BOTTOM_RIGHT, type: BMAP_NAVIGATION_CONTROL_ZOOM }));
    //右下角，仅包含缩放按钮

    //点击获取点击鼠标的经纬度
    map.addEventListener("click", function (e) {
        $("#<%= TextBoxMapValue.ClientID %>").val(e.point.lng + "," + e.point.lat);
        //    this.openInfoWindow(infoWindow, map.getCenter());      // 打开信息窗口
    });

</script>
<!--地理位置 End-->
