<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>店铺优惠券管理</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script language="javascript" type="text/javascript" src="js/jquery.pack.js"> </script>
    <script type="text/javascript" src="js/SpryTabbedPanels.js"> </script>
    <script type="text/javascript" language="javascript" src="/js/DatePicker/WdatePicker.js"> </script>
    <script src="JS/jquery.form.js" type="text/javascript"> </script>
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
            $("#S_ShopCouponEdit_ctl00_hid_Area").val(info.province + "," + info.city + "," + info.district + "|" + info.pcode + "," + info.ccode + "," + info.dcode);

        }
    </script>
    <script type="text/javascript" language="javascript">
        $(document).ready(
                function () {
                    var area = $("#S_ShopCouponEdit_ctl00_hid_Area").val().split("|");
                    if ($("#S_ShopCouponEdit_ctl00_hid_Area").val() != "") {
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
    <ShopNum1ShopAdmin:S_ShopCouponEdit ID="S_ShopCouponEdit" runat="server" SkinFilename="Skin/S_ShopCouponEdit.ascx" />
    </form>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/kindeditor.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/lang/zh_CN.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/plugins/code/prettify.js"> </script>
    <script src="js/CommonJS.js" type="text/javascript"> </script>
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            var editor = K.create('.Texteditor', {
                //上传管理
                uploadJson: '/kindeditor/file/upload_json.ashx',
                //文件管理
                fileManagerJson: '/kindeditor/file/file_manager_json.ashx',

                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                },
                allowFileManager: true,
                //编辑器高度
                width: '590px',
                //编辑器宽度
                height: '420px;',
                //配置编辑器的工具栏
                items: [
                        'source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'code', 'cut', 'copy', 'paste',
                        'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                        'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent', 'subscript',
                        'superscript', 'clearhtml', 'quickformat', 'selectall', '|', 'fullscreen', '/',
                        'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
                        'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image', 'multiimage',
                        'flash', 'media', 'insertfile', 'table', 'hr', 'emoticons', 'baidumap', 'pagebreak',
                        'anchor', 'link', 'unlink', '|', 'about'
                    ]
            });
            prettyPrint();
        });
    </script>
</body>
</html>
