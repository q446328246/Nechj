<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>店铺主题列表</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <script type="text/javascript" language="javascript">
        // 判断是否是数字
        function checknum(str) {
            var re = /^[0-9]+.?[0-9]*$/;
            if (!re.test(str)) {
                alert("请输入正确的数字！");
                return false;
            } else {
                return true;
            }
        }

        //页面跳转

        function ontoPage(o) {
            var pageindex = $(o).parent().parent().prev().prev().find("input").val();
            if (checknum(pageindex)) {
                var pageEnd = parseInt($(".page_2 b").text());
                if (pageEnd <= pageindex)
                    pageindex = pageEnd;
                location.href = "S_ThemeList.aspx?pageid=" + pageindex;
            }
        }

        $(function () {
            GetShopType("0", "#ShopType");
            $("#ShopType").change(function () {
                $("#ShopType2").hide();
                $("#ShopType2").html("<option value=\"0\">全部分类</option>");
                GetShopType($(this).find("option:selected").attr("lang"), "#ShopType2");
            });
            //全选、全不选
            $("#checkAll").click(function () {
                $("#loadProduct").find("input[type='checkbox']").attr("checked", $(this).attr("checked"));
            });

        });

        function GetShopType(id, jid) {
            $.get("/Api/ShopAdmin/S_ThemeProductOperate.ashx?type=getshoptype&id=" + id + "", null, function (data) {
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

        function GetData(pageid) {

            var textName = $("#S_ThemeList_ctl00_txtKeyWord").val(); //商品名称
            var code = $("#ShopType").find("option:selected").val(); //店铺分类id
            var code2 = $("#ShopType2").find("option:selected").val(); //店铺分类id
            var ThemeGuid = $("#ThemeGuid").val();
            if (code2 == "0")
                code2 = code;
            $("#showLoading").css("display", "block");
            $.ajax({
                type: "get",
                url: "/Api/ShopAdmin/S_ThemeProductOperate.ashx",
                async: false,
                data: "code=" + code2 + "&type=getproduct&keyword=" + escape(textName) + "&pageid=" + pageid + "&ThemeGuid=" + ThemeGuid,
                dataType: "html",
                success: function (ajaxData) {
                    var xhtml = new Array();
                    if (ajaxData != "0|") {
                        initMyPages(pageid, ajaxData.split("|")[0]);
                        var data = eval('(' + ajaxData.split("|")[1] + ')');

                        $.each(data, function (m, n) {
                            xhtml.push("<tr><td> &nbsp; <input type=\"checkbox\" id='" + n.guid + "' name='" + n.name + "' img='" + n.originalimage + "' price='" + n.shopprice + "' /></td>");
                            xhtml.push("<td style=\"text-align:center;\">" + n.name.substring(0, 20) + "</td>");
                            xhtml.push("<td style=\"text-align:center;\">" + n.shopprice + "</td>");
                            xhtml.push("<td style=\"text-align:center;\">" + n.repertorycount + "</td></tr>");

                        });
                    } else {
                        xhtml.push("<tr><td colspan=\"4\"><center>没有查询相关数据！</center></td></tr>");
                    }
                    $("#loadProduct").html(xhtml.join(""));
                    $("#showLoading").css("display", "none");
                }
            });
        }

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
                pageNumStr += "<a href=\"javascript:;\" onclick='javascript:;GetData(1)'>首页</a><a href=\"javascript:;\" onclick=\"javascript:;GetData(" + (nowPage - 1) + ")\">上一页</a> ";
            }
            //判断什么时候显示下一页
            if (nowPage < pages) {
                pageNumStr += " <a href='javascript:;' onclick='javascript:;GetData(" + (nowPage + 1) + ")'>下一页</a><a href='#' onclick='javascript:;GetData(" + pages + ")'>末页</a>";
            }
            $("#pageshow").html(pageNumStr);
        }

        //替换所有特殊符号  replaceAll
        String.prototype.replaceAll = function (reallyDo, replaceWith, ignoreCase) {
            if (!RegExp.prototype.isPrototypeOf(reallyDo)) {
                return this.replace(new RegExp(reallyDo, (ignoreCase ? "gi" : "g")), replaceWith);
            } else {
                return this.replace(reallyDo, replaceWith);
            }
        };

        function SelectSubmit() {
            var strValues = "";
            $("#loadProduct").find("input[type='checkbox']").each(function () {
                if ($(this).attr("checked")) {
                    strValues += $(this).attr("id") + "," + $(this).attr("name") + "," + $(this).attr("img").replaceAll("/", "*") + "," + $(this).attr("price") + "|";
                }
            });
            var ThemeGuid = $("#ThemeGuid").val();
            if (strValues != "") {
                $.ajax({
                    type: "post",
                    url: "/Api/ShopAdmin/S_ThemeProductOperate.ashx",
                    async: false,
                    data: "ThemeGuid=" + ThemeGuid + "&type=AddThemeProduct&strValues=" + strValues,
                    dataType: "html",
                    success: function (ajaxData) {
                        if (ajaxData == "OK") {
                            alert("成功参与活动！");
                            location.reload();
                        }
                    }
                });
            }

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <span class="spanrig" style="display: none"><a class="tianjiafl lmf_btn" href="S_ThemeProductOperate.aspx">
                添加商品</a> </span><a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span
                    class="breadcrume_text">主题活动列表</span>
        </p>
        <ShopNum1ShopAdmin:S_ThemeList ID="S_ThemeList" PageSize="5" runat="server" SkinFilename="skin/S_ThemeList.ascx" />
    </div>
    </form>
</body>
</html>
