<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加团购商品</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <link rel='stylesheet' type='text/css' href='style/dshow.css' />
    <script type="text/javascript" language="javascript" src="js/dshow.js"> </script>
    <script type="text/javascript" language="javascript">
        function getFullPath(obj) {
            //获取欲上传的文件路径
            var filepath = obj.value;
            //为了避免转义反斜杠出问题，这里将对其进行转换
            var re = /(\\+)/g;
            var filename = filepath.replace(re, "#");
            //对路径字符串进行剪切截取
            var one = filename.split("#");
            //获取数组中最后一个，即文件名
            var two = one[one.length - 1];
            //再对文件名进行截取，以取得后缀名
            var three = two.split(".");
            //获取截取的最后一个字符串，即为后缀名
            var last = three[three.length - 1];
            //添加需要判断的后缀名类型
            var tp = "jpg,gif,bmp,png,JPG,GIF,BMP,PNG";
            //返回符合条件的后缀名在字符串中的位置
            var tiparry = tp.split(",");
            var bflag = true;
            for (var i in tiparry) {
                if (tiparry[i] == last) {
                    bflag = false;
                }
            }
            var rs = tp.indexOf(last);
            //如果返回的结果大于或等于0，说明包含允许上传的文件类型
            if (bflag) {
                alert("您选择的上传文件不是有效的图片文件！");
                obj.value = "";
                return false;
            }
            if (obj) {
                if (window.navigator.userAgent.indexOf("MSIE") >= 1) {
                    obj.select();
                    $("#S_GroupProductOperate_ctl00_GroupPic").attr("src", obj.value);
                    return false;
                    if (window.navigator.userAgent.indexOf("MSIE") == 25) {
                        obj.blur();
                    }
                } else if (window.navigator.userAgent.indexOf("Firefox") >= 1) {
                    $("#S_GroupProductOperate_ctl00_GroupPic").attr("src", window.URL.createObjectURL(obj.files.item(0)));
                    return false;
                }
                $("#S_GroupProductOperate_ctl00_GroupPic").attr("src", obj.value);
                return false;
            }
            //$("#S_GroupProductOperate_ctl00_GroupPic").attr("src",obj.value);return false;
        }

        $(function () {
            if ($("#S_GroupProductOperate_ctl00_hidGuid").val() != "") {
                loadData($("#S_GroupProductOperate_ctl00_hidGuid").val());
            }
            $.get("/Api/ShopAdmin/S_GroupProductOperate.ashx?type=getactivity", null, function (data) {
                if (data != "") {
                    var vdata = eval('(' + data + ')');
                    $.each(vdata, function (m, n) {
                        if (n.id == $("#S_GroupProductOperate_ctl00_hidAid").val()) {
                            $("select[name='GroupActivityName']").append("<option value=\"" + n.id + "\" selected=\"selected\">" + n.name + "(" + n.s + "-" + n.e + ")</option>");
                        } else {
                            $("select[name='GroupActivityName']").append("<option value=\"" + n.id + "\">" + n.name + "(" + n.s + "-" + n.e + ")</option>");
                        }
                    });
                } else {
                    $("#showmsg").show();
                    $("#S_GroupProductOperate_ctl00_btnSub").attr("disabled", "disabled");
                }
            });
            $("#S_GroupProductOperate_ctl00_txtPname").click(function () {
                funOpen();
            });
            GetShopType("0", "#ShopType");
            $("#ShopType").change(function () {
                $("#ShopType2").hide();
                $("#ShopType2").html("<option value=\"0\">全部分类</option>");
                GetShopType($(this).find("option:selected").attr("lang"), "#ShopType2");
            });

        });

        function GetShopType(id, jid) {
            $.get("/Api/ShopAdmin/S_GroupProductOperate.ashx?type=getshoptype&id=" + id + "", null, function (data) {
                if (data != "") {
                    var vdata = eval('(' + data + ')');
                    $.each(vdata, function (m, n) {
                        if (jid == "#ShopType2") {
                            $(jid).show();
                        }
                        $(jid).append("<option value=\"" + n.code + "\" lang=\"" + n.id + "\">" + n.name + "</option>");
                    });
                }
            });
        }

        //关闭
        //    function funClose()
        //    {
        //        $("#sp_dialog_contDiv").css("display","none");
        //        $("#sp_dialog_outDiv").css("display","none");
        //        $("#sp_overlayDiv").css("display","none");
        //    }
        //提交

        function SelectClick() {
            var id = $("#selectproduct").find("option:selected").val();
            if (id == "") {
                $("#errormsg").show();
                return false;
            }
            $("#S_GroupProductOperate_ctl00_txtPname").val($("#selectproduct").find("option:selected").text());
            $("#S_GroupProductOperate_ctl00_hidGuid").val(id);
            loadData(id);
            funClose();

        }

        function loadData(id) {
            $.get("/Api/ShopAdmin/S_GroupProductOperate.ashx?type=getinfobyId&guid=" + id, null, function (data) {
                $("#trstock").show();
                $("#trprice").show();
                $("#S_GroupProductOperate_ctl00_spanstock").text(data.toString().split(",")[1]);
                $("#spanprice").text(data.toString().split(",")[0]);
                $("#S_GroupProductOperate_ctl00_txtPname").val(data.toString().split(",")[2]);
            });
        }

        //搜索

        function GetData() {
            var textName = $("#S_GroupProductOperate_ctl00_txtKeyWord").val(); //商品名称
            var code = $("#ShopType").find("option:selected").val(); //店铺分类id
            var code2 = $("#ShopType2").find("option:selected").val(); //店铺分类id
            if (code2 == "0")
                code2 = code;
            $("#showLoading").css("display", "block");
            $.ajax({
                type: "get",
                url: "/Api/ShopAdmin/S_GroupProductOperate.ashx",
                async: false,
                data: "code=" + code2 + "&type=getproduct&keyword=" + escape(textName),
                dataType: "html",
                success: function (ajaxData) {
                    $("#selectproduct").html("");
                    if (ajaxData != "") {
                        var data = eval('(' + ajaxData + ')');
                        var xhtml = new Array();
                        $.each(data, function (m, n) {
                            xhtml.push("<option value='" + n.guid + "'>" + n.name + "</option>");
                        });
                        $("#selectproduct").append(xhtml.join(""));
                        $("#showLoading").css("display", "none");
                    } else {
                        $("#selectproduct").append("<option>没有合适的商品！</option>");
                        $("#showLoading").css("display", "none");
                    }
                }
            });
        }

        function checkprice(name) {
            var oo = /^\d{1,10}$|^\d{1,10}\.\d{1,2}\w?$/;
            if (!oo.test(name)) {
                return false;
            } else {
                return true;
            }
        }

        function NumTxt_Int(o) {
            if (o.toString() == "")
                o.value = "0";
            o.value = o.value.replace(/\D/g, '');
        }

        function subcheck() {
            var groupname = $("#S_GroupProductOperate_ctl00_txtGroupName");
            var pname = $("#S_GroupProductOperate_ctl00_txtPname");
            var gprice = $("#S_GroupProductOperate_ctl00_txtGroupPrice");
            var gupload = $("#S_GroupProductOperate_ctl00_fileUpload");
            var stocknum = parseInt($("#S_GroupProductOperate_ctl00_txtGroupStock").val());
            var pstock = parseInt($("#S_GroupProductOperate_ctl00_spanstock").text());
            if (stocknum < 1) {
                $("#S_GroupProductOperate_ctl00_txtGroupStock").focus().next().show().text("团购商品总数应等于或小于该商品库存数量并且大于0!");
                return false;
            }
            if (pstock < stocknum) {
                $("#S_GroupProductOperate_ctl00_txtGroupStock").focus().next().show().text("团购商品总数应等于或小于该商品库存数量并且大于0!");
                return false;
            }
            if (parseFloat(gprice.val()) > parseFloat($("#spanprice").text())) {
                gprice.focus().next().show().text("团购价格必须小于店铺价格！");
                return false;
            }
            $("#spanshow").hide();
            $("span[check='errormsg']").hide();
            if (groupname.val() == "") {
                groupname.focus().next().show().text("团购名称不能为空！");
                return false;
            }
            if (pname.val() == "") {
                pname.click();
                return false;
            }
            if (!checkprice(gprice.val())) {
                gprice.focus().next().show().text("团购价格不合法！");
                return false;
            }
            if (parseFloat(gprice.val()) < 0.01 || parseFloat(gprice.val()) > 10000) {
                gprice.focus().next().show().text("必须是0.01~10000.00之间的数字");
                return false;
            }
            if ($("#S_GroupProductOperate_ctl00_GroupPic").attr("src") == "" || $("#S_GroupProductOperate_ctl00_GroupPic").attr("src") == undefined) {
                $("#S_GroupProductOperate_ctl00_GroupPic").focus().next().show().text("请上传团购图片！");
                return false;
            }
            var aid = $("select[name='GroupActivityName']").find("option:selected").val();
            if ($("select[name='GroupActivityName'] option").size() == 0) {
                $("select[name='GroupActivityName']").focus().next().show().text("没有可用的团购活动！");
                return false;
            }
            $("#S_GroupProductOperate_ctl00_hidAid").val(aid);
            var aname = $("select[name='GroupActivityName']").find("option:selected").text();
            if (aname != "") {
                aname = aname.split("(")[0] + "<br />" + aname.split("(")[1].replace(")", "");
            }
            $("#S_GroupProductOperate_ctl00_hidAname").val(aname);
            return true;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><a href="S_GroupProduct.aspx">团购商品列表</a><span
                class="breadcrume_icon">>></span><span class="breadcrume_text">团购商品操作页面</span></p>
        <ShopNum1ShopAdmin:S_GroupProductOperate ID="S_GroupProductOperate" runat="server"
            SkinFilename="skin/S_GroupProductOperate.ascx" />
        <link rel="stylesheet" href="/kindeditor/plugins/code/prettify.css" />
        <script type="text/javascript" charset="utf-8" src="/kindeditor/kindeditor.js"> </script>
        <script type="text/javascript" charset="utf-8" src="/kindeditor/lang/zh_CN.js"> </script>
        <script type="text/javascript" charset="utf-8" src="/kindeditor/plugins/code/prettify.js"> </script>
        <script type="text/javascript" language="javascript">
            //编辑器调用方法
            var editor;
            KindEditor.ready(function (K) {
                editor = K.create('.textwebedit', {
                    //上传管理
                    uploadJson: '/kindeditor/file/upload_json.ashx',
                    //文件管理
                    fileManagerJson: '/kindeditor/file/file_manager_json.ashx',
                    allowFileManager: true,
                    //编辑器高度
                    width: '100%',
                    //编辑器宽度
                    height: '300px;',
                    //配置编辑器的工具栏
                    items: [
                                'source', '|', 'undo', 'redo', '|', 'preview',
                                'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                                'justifyfull', 'fullscreen',
                                'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
                                'italic', 'underline', '/', 'lineheight', 'removeformat', '|', 'image', 'multiimage',
                                'flash', 'media', 'insertfile', 'table', 'hr', 'emoticons', 'baidumap', 'about'
                            ]
                });
                prettyPrint();
            });
        </script>
    </div>
    </form>
</body>
</html>
