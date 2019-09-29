<%@ Page Language="C#" %>

<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加组合套餐</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <script type="text/javascript" language="javascript" src="js/Common.js"> </script>
    <link rel="stylesheet" href="/kindeditor/plugins/code/prettify.css" />
    <script type="text/javascript" charset="utf-8" src="/kindeditor/kindeditor.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/lang/zh_CN.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/plugins/code/prettify.js"> </script>
    <script type="text/javascript" language="javascript">
        String.prototype.replaceAll = function (reallyDo, replaceWith, ignoreCase) {
            if (!RegExp.prototype.isPrototypeOf(reallyDo)) {
                return this.replace(new RegExp(reallyDo, (ignoreCase ? "gi" : "g")), replaceWith);
            } else {
                return this.replace(reallyDo, replaceWith);
            }
        };

        function initMyPages(nowPage, pages) {
            $("#pageshow").html("");
            nowPage = parseInt(nowPage);
            var endPage = pages;
            var startPage = 1;
            if (pages > 1) {
                if (nowPage - 4 > 0) {
                    startPage = nowPage - 4;
                }
                if (nowPage + 5 < pages) {
                    endPage = nowPage + 5;
                } else {
                    endPage = pages;
                }
            }
            var pageNumStr = "";
            if (nowPage != 1) {
                pageNumStr += "<a href=\"javascript:;\" onclick='javascript:;GetAjaxContent(1)'>首页</a><a href=\"javascript:;\" onclick=\"javascript:;GetAjaxContent(" + (nowPage - 1) + ")\">上一页</a> ";
            }
            //判断什么时候显示下一页
            if (nowPage < pages) {
                pageNumStr += " <a href='javascript:;' onclick='javascript:;GetAjaxContent(" + (nowPage + 1) + ")'>下一页</a><a href='#' onclick='javascript:;GetAjaxContent(" + pages + ")'>末页</a>";
            }
            $("#pageshow").html(pageNumStr);
        }

        $(function () {
            $("#addProduct").click(function () {
                $("#showProuct,#search_Pro").show();
                LoadCategoryAjax();
                GetAjaxContent("1");
            });

            $("#search_sub").click(function () {
                GetAjaxContent("1");
            });

            $("#loadProduct #btnAdd").live("click", function (data) {
                var id = $(this).attr("lang");
                if ($(this).val() == "取消搭配") {
                    $("#trd_" + id).remove();
                    $(this).val("添加搭配");
                } else {
                    if ($("#tbProduct tr").size() > 4) {
                        alert("您已经添加了5件商品了!");
                        return false;
                    }
                    $("#hidPackage").val($(this).attr("lang") + "," + $("#hidPackage").val());
                    $(this).val("取消搭配");
                    var xhtml = new Array();
                    xhtml.push("<tr id=\"trd_" + id + "\"><td style=\"text-algin:left\">" + $(this).parent().prev().prev().prev().html() + "</td>");
                    xhtml.push("<td>" + $(this).parent().prev().prev().html() + "</td>");
                    xhtml.push("<td>" + $(this).parent().prev().html() + "</td>");
                    xhtml.push("<td>" + $(this).parent().html().replaceAll("取消搭配", "移除") + "</td></tr>");
                    $("#tbProduct").append(xhtml.join(""));
                    totalPrice();
                }
            });
            $("#tbProduct #btnAdd").live("click", function (data) {
                if (confirm("是否移除？")) {
                    var productGuId = $(this).prev().val();
                    var packId = '<%= ShopNum1.Common.Common.ReqStr("packid") %>';
                    $(this).parent().parent().remove();
                    totalPrice();
                    if ($(this).val() == "移除" && packId != "") {
                        $.get("/Api/ShopAdmin/S_PackAgeOpreate.ashx?sing=deleted&pid=" + productGuId + "&packid=" + packId + "", null, function (data) {
                        });
                    }
                    $("#loadProduct .addpack_" + $(this).attr("lang")).val("添加搭配");
                }
            });
            var packid = new Array();
            $("input[name='hidId']").each(function () {
                packid.push($(this).val());
            });
            $("#hidPackage").val(packid.join(","));
        });

        function totalPrice() {
            var pricecount = 0;
            $("#tbProduct input[name='hid_price']").each(function () {
                pricecount += parseFloat($(this).val());
            });
            $("#S_PackAgeOpreate_ctl00_lblShopPrice").text(number_format(pricecount, 2));
        }

        function GetAjaxContent(pageid) {
            var tp = $("#txtProductName").val();
            var pcode = $("#ProSelect").html();
            if ($("#txtProductName").val() == "")
                tp = "";
            if (pcode == "")
                pcode = "0";
            else
                pcode = $("#ProSelect").find("option:selected").val();
            var packId = '<%= ShopNum1.Common.Common.ReqStr("packid") %>';
            $.get("/Api/ShopAdmin/S_PackAgeOpreate.ashx?packId=" + packId + "&pageid=" + pageid + "&pcode=" + pcode + "&pname=" + escape(tp) + "", null, function (data) {
                var xhtml = new Array();
                if (data != "") {
                    initMyPages(pageid, data.split("|")[0]);
                    $("#hidPageCount").val(data.split("|")[0]);
                    data = data.split("|")[1];
                    var vdata = eval('(' + data + ')');
                    $.each(vdata, function (m, n) {
                        xhtml.push("<tr id=\"tr_" + n.id + "\"><td style=\"text-algin:left\"><input type=\"hidden\" value=\"" + n.originalimage + "\" name=\"hid_pic\"/> <img src=\"" + n.originalimage + "_25x25.jpg\" style=\"width:25px;height:25px;\" onerror=\"javascript:this,src='/ImgUpload/noImg.jpg_25x25.jpg'\" />" + n.name.substring(0, 20) + "</td>");
                        xhtml.push("<td style=\"text-align:center\"><input type=\"hidden\" value=\"" + n.shopprice + "\" name=\"hid_price\"/>" + n.shopprice + "</td>");
                        xhtml.push("<td style=\"text-align:center\">" + n.repertorycount + "</td>");
                        xhtml.push("<td><input type=\"hidden\" name=\"hidguid\" value=\"" + n.guid + "\"/><input type=\"button\" id=\"btnAdd\" lang='" + n.id + "' class=\"addpack_" + n.id + " tjdp\" value=\"添加搭配\"/></td></tr>");
                    });
                } else {
                    xhtml.push("<tr><td colspan=\"4\"><center>没有查询相关数据！</center></td></tr>");
                }
                $("#loadProduct").html(xhtml.join(""));
                var arryPackId = $("#hidPackage").val().split(",");
                for (var i in arryPackId) {
                    $("#loadProduct .addpack_" + arryPackId[i]).val("取消搭配");
                    $("#tbProduct .addpack_" + arryPackId[i]).parent().parent().attr("id", "trd_" + arryPackId[i]);
                }
            });
        }

        function LoadCategoryAjax() {
            $.get("/Api/ShopAdmin/S_PackAgeOpreate.ashx?ptype=ptype", null, function (data) {
                var xhtml = new Array("<option value=\"0\">-请选择-</option>");
                var vdata = eval('(' + data + ')');
                $.each(vdata, function (m, n) {
                    xhtml.push("<option value=\"" + n.code + "\">" + n.name + "</option>");
                });
                $("#ProSelect").html(xhtml.join(""));
            });
        }

        //编辑器调用方法
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('.textwebedit', {
                uploadJson: '/kindeditor/file/upload_json.ashx',
                fileManagerJson: '/kindeditor/file/file_manager_json.ashx',
                allowFileManager: true,
                width: '100%',
                height: '300px;',
                items: [
                        'source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'code', 'cut', 'copy', 'paste',
                        'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright', '|', 'fullscreen',
                        'forecolor', 'hilitecolor', 'formatblock', 'fontname', 'fontsize', '|', 'bold',
                        'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image', 'multiimage',
                        'flash', 'media', 'insertfile', 'table', 'hr', 'emoticons', 'baidumap', 'pagebreak',
                        'anchor', 'link', 'unlink', '|', 'about'
                    ]
            });
            prettyPrint();
        });

        function checkpriceTxt(o) {
            var oo = /^\d{1,10}$|\.\w?$|^\d{1,10}\.\d{1,5}\w?$/;
            if (!oo.test(o.value)) {
                o.value = '';
            } else {
                var shopPrice = parseFloat($("#S_PackAgeOpreate_ctl00_lblShopPrice").text());
                if (parseFloat(o.value) > shopPrice) {
                    alert("组合销售价格必须小于等于原价！");
                    o.value = '';
                }
                o.value = number_format(o.value, 2);
                return true;
            }
        }

        //商品价格格式化方法

        function number_format(num, ext) {
            if (ext < 0) {
                return num;
            }
            num = Number(num);
            if (isNaN(num)) {
                num = 0;
            }
            var _str = num.toString();
            var _arr = _str.split('.');
            var _int = _arr[0];
            var _flt = _arr[1];
            if (_str.indexOf('.') == -1) {
                /* 找不到小数点，则添加 */
                if (ext == 0) {
                    return _str;
                }
                var _tmp = '';
                for (var i = 0; i < ext; i++) {
                    _tmp += '0';
                }
                _str = _str + '.' + _tmp;
            } else {
                if (_flt.length == ext) {
                    return _str;
                }
                /* 找得到小数点，则截取 */
                if (_flt.length > ext) {
                    _str = _str.substr(0, _str.length - (_flt.length - ext));
                    if (ext == 0) {
                        _str = _int;
                    }
                } else {
                    for (var i = 0; i < ext - _flt.length; i++) {
                        _str += '0';
                    }
                }
            }
            return _str;
        }

        function checksub() {
            if ($("#tbProduct tr").size() < 2) {
                alert("组合套餐必须至少2件商品了!");
                return false;
            }
            if ($("#S_PackAgeOpreate_ctl00_txtName").val() == "") {
                alert("活动名称不能为空！");
                $("#S_PackAgeOpreate_ctl00_txtName").focus();
                return false;
            }
            var checkguid = new Array();
            var Numflag = 1;
            $("#tbProduct input[name='hidguid']").each(function () {
                checkguid.push($(this).val());
                Numflag++;
            });
            if (!checkprice($("#S_PackAgeOpreate_ctl00_txtSalePrice").val()) || $("#S_PackAgeOpreate_ctl00_txtSalePrice").val() == "") {
                alert("价格不合法！");
                $("#S_PackAgeOpreate_ctl00_txtSalePrice").focus();
                return false;
            }
            if (Numflag < 2) {
                alert("至少选择两条数据进行套餐搭配！");
                return false;
            }
            $("#S_PackAgeOpreate_ctl00_hidPic").val($("#tbProduct input[name='hid_pic']:eq(0)").val());
            $("#S_PackAgeOpreate_ctl00_hidCheckIsOpen").val($("input[name='opencheck']:checked").val());
            $("#S_PackAgeOpreate_ctl00_hidProductGuId").val(checkguid.join(","));
            $("#S_PackAgeOpreate_ctl00_hidPrice").val($("#S_PackAgeOpreate_ctl00_lblShopPrice").text());
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="javascript:void(0)">我是卖家</a>>><a href="S_PackAgeList.aspx">组合套餐活动列表</a><span
                class="breadcrume_icon">>></span><span class="breadcrume_text">组合套餐活动操作页面</span></p>
        <ShopNum1ShopAdmin:S_PackAgeOpreate ID="S_PackAgeOpreate" runat="server" SkinFilename="Skin/S_PackAgeOpreate.ascx" />
    </div>
    </form>
</body>
</html>
