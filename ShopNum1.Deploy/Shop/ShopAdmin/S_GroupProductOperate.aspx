<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>����Ź���Ʒ</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <link rel='stylesheet' type='text/css' href='style/dshow.css' />
    <script type="text/javascript" language="javascript" src="js/dshow.js"> </script>
    <script type="text/javascript" language="javascript">
        function getFullPath(obj) {
            //��ȡ���ϴ����ļ�·��
            var filepath = obj.value;
            //Ϊ�˱���ת�巴б�ܳ����⣬���ｫ�������ת��
            var re = /(\\+)/g;
            var filename = filepath.replace(re, "#");
            //��·���ַ������м��н�ȡ
            var one = filename.split("#");
            //��ȡ���������һ�������ļ���
            var two = one[one.length - 1];
            //�ٶ��ļ������н�ȡ����ȡ�ú�׺��
            var three = two.split(".");
            //��ȡ��ȡ�����һ���ַ�������Ϊ��׺��
            var last = three[three.length - 1];
            //�����Ҫ�жϵĺ�׺������
            var tp = "jpg,gif,bmp,png,JPG,GIF,BMP,PNG";
            //���ط��������ĺ�׺�����ַ����е�λ��
            var tiparry = tp.split(",");
            var bflag = true;
            for (var i in tiparry) {
                if (tiparry[i] == last) {
                    bflag = false;
                }
            }
            var rs = tp.indexOf(last);
            //������صĽ�����ڻ����0��˵�����������ϴ����ļ�����
            if (bflag) {
                alert("��ѡ����ϴ��ļ�������Ч��ͼƬ�ļ���");
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
                $("#ShopType2").html("<option value=\"0\">ȫ������</option>");
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

        //�ر�
        //    function funClose()
        //    {
        //        $("#sp_dialog_contDiv").css("display","none");
        //        $("#sp_dialog_outDiv").css("display","none");
        //        $("#sp_overlayDiv").css("display","none");
        //    }
        //�ύ

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

        //����

        function GetData() {
            var textName = $("#S_GroupProductOperate_ctl00_txtKeyWord").val(); //��Ʒ����
            var code = $("#ShopType").find("option:selected").val(); //���̷���id
            var code2 = $("#ShopType2").find("option:selected").val(); //���̷���id
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
                        $("#selectproduct").append("<option>û�к��ʵ���Ʒ��</option>");
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
                $("#S_GroupProductOperate_ctl00_txtGroupStock").focus().next().show().text("�Ź���Ʒ����Ӧ���ڻ�С�ڸ���Ʒ����������Ҵ���0!");
                return false;
            }
            if (pstock < stocknum) {
                $("#S_GroupProductOperate_ctl00_txtGroupStock").focus().next().show().text("�Ź���Ʒ����Ӧ���ڻ�С�ڸ���Ʒ����������Ҵ���0!");
                return false;
            }
            if (parseFloat(gprice.val()) > parseFloat($("#spanprice").text())) {
                gprice.focus().next().show().text("�Ź��۸����С�ڵ��̼۸�");
                return false;
            }
            $("#spanshow").hide();
            $("span[check='errormsg']").hide();
            if (groupname.val() == "") {
                groupname.focus().next().show().text("�Ź����Ʋ���Ϊ�գ�");
                return false;
            }
            if (pname.val() == "") {
                pname.click();
                return false;
            }
            if (!checkprice(gprice.val())) {
                gprice.focus().next().show().text("�Ź��۸񲻺Ϸ���");
                return false;
            }
            if (parseFloat(gprice.val()) < 0.01 || parseFloat(gprice.val()) > 10000) {
                gprice.focus().next().show().text("������0.01~10000.00֮�������");
                return false;
            }
            if ($("#S_GroupProductOperate_ctl00_GroupPic").attr("src") == "" || $("#S_GroupProductOperate_ctl00_GroupPic").attr("src") == undefined) {
                $("#S_GroupProductOperate_ctl00_GroupPic").focus().next().show().text("���ϴ��Ź�ͼƬ��");
                return false;
            }
            var aid = $("select[name='GroupActivityName']").find("option:selected").val();
            if ($("select[name='GroupActivityName'] option").size() == 0) {
                $("select[name='GroupActivityName']").focus().next().show().text("û�п��õ��Ź����");
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
            <a href="S_Welcome.aspx">��������</a><span class="breadcrume_icon">>></span><a href="S_GroupProduct.aspx">�Ź���Ʒ�б�</a><span
                class="breadcrume_icon">>></span><span class="breadcrume_text">�Ź���Ʒ����ҳ��</span></p>
        <ShopNum1ShopAdmin:S_GroupProductOperate ID="S_GroupProductOperate" runat="server"
            SkinFilename="skin/S_GroupProductOperate.ascx" />
        <link rel="stylesheet" href="/kindeditor/plugins/code/prettify.css" />
        <script type="text/javascript" charset="utf-8" src="/kindeditor/kindeditor.js"> </script>
        <script type="text/javascript" charset="utf-8" src="/kindeditor/lang/zh_CN.js"> </script>
        <script type="text/javascript" charset="utf-8" src="/kindeditor/plugins/code/prettify.js"> </script>
        <script type="text/javascript" language="javascript">
            //�༭�����÷���
            var editor;
            KindEditor.ready(function (K) {
                editor = K.create('.textwebedit', {
                    //�ϴ�����
                    uploadJson: '/kindeditor/file/upload_json.ashx',
                    //�ļ�����
                    fileManagerJson: '/kindeditor/file/file_manager_json.ashx',
                    allowFileManager: true,
                    //�༭���߶�
                    width: '100%',
                    //�༭�����
                    height: '300px;',
                    //���ñ༭���Ĺ�����
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
