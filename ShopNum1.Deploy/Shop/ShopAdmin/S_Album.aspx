<%@ Page Language="C#" %>

<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>图库管理</title>
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" language="javascript" src="js/dshow.js"> </script>
    <link rel='stylesheet' type='text/css' href='style/dshow.css' />
    <link href="uploadify/uploadify.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="uploadify/swfobject.js"> </script>
    <script type="text/javascript" src="uploadify/jquery.uploadify.v2.1.4.min.js"> </script>
    <link href="/kindeditor/themes/default/default.css" rel="stylesheet" type="text/css" />
    <script src="/kindeditor/kindeditor-min.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#setalbum").click(function () {
                funOpen();
            });

            $("#sidebar li").click(function () {
                location.href = "?type=" + $(this).attr("id") + "&sort=" + '<%= ShopNum1.Common.Common.ReqStr("sort") %>';
            });
        });
        String.prototype.trim = function () { return this.replace(/(^\s*)|(\s*$)/g, ''); };

        function btnSure() {
            var name = $("#name").val().trim();
            var desc = $("#description").val();
            var sort = $("#sort").val().trim();
            if (name == "") {
                $("#tipmsg").show().text("相册名称不能为空！");
                return false;
            }
            $.get("/Api/ShopAdmin/S_Album.ashx?op=addalbum&name=" + escape(name) + "&desc=" + escape(desc) + "&sort=" + sort + "", null, function (data) {
                alert("相册创建成功！");
                window.location.reload();
            });
        }
    </script>
    <link rel='stylesheet' type='text/css' href='/shop/shopAdmin/style/dshow.css' />
    <!--取色器-->
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            var colorpicker;
            K('#colorpicker').bind('click', function (e) {
                e.stopPropagation();
                if (colorpicker) {
                    colorpicker.remove();
                    colorpicker = null;
                    return;
                }
                var colorpickerPos = K('#colorpicker').pos();
                colorpicker = K.colorpicker({
                    x: colorpickerPos.x,
                    y: colorpickerPos.y + K('#colorpicker').height(),
                    z: 19811214,
                    selectedColor: 'default',
                    noColor: '无颜色',
                    click: function (color) {
                        K('#S_Album_2_ctl00_txtColor').val(color);
                        colorpicker.remove();
                        colorpicker = null;
                    }
                });
            });
            K(document).click(function () {
                if (colorpicker) {
                    colorpicker.remove();
                    colorpicker = null;
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian1">
        <p class="ptitle">
            <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text"><% if (ShopNum1.Common.Common.ReqStr("type") == "1")
                                                                                                                     { %>水印管理<% }
                                                                                                                     else
                                                                                                                     { %>我的相册<% } %></span></p>
        <div id="list_main" style="overflow: hidden;">
            <ul id="sidebar">
                <li id="0" class='<%= ShopNum1.Common.Common.ReqStr("type") == "" || ShopNum1.Common.Common.ReqStr("type") == "0" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
                    我的相册</li>
                <li id="1" class='<%= ShopNum1.Common.Common.ReqStr("type") == "1" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
                    水印管理</li>
            </ul>
            <div id="content">
                <div class="pad" style="display: <%= ShopNum1.Common.Common.ReqStr("type") == "" || ShopNum1.Common.Common.ReqStr("type") == "0" ? "block" : "none" %>">
                    <ShopNum1ShopAdmin:S_Album_1 ID="S_Album_1" runat="server" SkinFilename="skin/S_Album_1.ascx" />
                </div>
                <div class="pad" style="display: <%= ShopNum1.Common.Common.ReqStr("type") == "1" ? "block" : "none" %>">
                    <ShopNum1ShopAdmin:S_Album_2 ID="S_Album_2" runat="server" SkinFilename="skin/S_Album_2.ascx" />
                </div>
            </div>
        </div>
    </div>
    <div>
    </div>
    </form>
</body>
</html>
