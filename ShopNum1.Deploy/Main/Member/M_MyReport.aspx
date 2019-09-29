<%@ Page Language="C#" EnableViewState="false" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="Skin/M_MyReport.ascx" TagName="M_MyReport" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的举报</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="js/Common.js"></script>
    <script type="text/javascript" language="javascript">
        function sethash() {
            var hashH = document.documentElement.scrollHeight; try {
                parent.document.getElementById("mainFrame").style.height = "800px";
            } catch (e) { }
        } window.onload = sethash;
    </script>
    <script type="text/javascript" language="javascript">
        function IsDelete(val) {
            if (confirm("是否删除勾选项？")) {
                $("input[type='checkbox']").removeAttr("checked");
                $.get("/Api/Main/Member/DeleteOp.ashx?type=Report&delid=" + val, null, function (data) {
                    if (data == "ok") { alert("删除成功！"); location.reload(); return false; }
                    else { alert("删除失败！"); return false; }
                });
            }
        }

        $(function () {
            $("input[name='checktop']").click(function () {
                $("input[name='checksub']").attr("checked", $(this).is(":checked"));
            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="M_Welcome.aspx">我是买家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">我的举报</span></p>
        <uc1:M_MyReport ID="M_MyReport1" runat="server" PageSize="10" />
        <%--        <ShopNum1:M_MyReport ID="M_MyReport" runat="server" SkinFilename="Skin/M_MyReport.ascx"
            PageSize="10" />--%>
    </div>
    <script type="text/javascript" language="javascript">
        //跳转到制定的页码
        function ontoPage(txtId) {
            location.href = '?isread=<%= ShopNum1.Common.Common.ReqStr("isread") %>&pageid=' + $("#txtIndex").val();
        }
        $(function () {
            //批量删除操作
            $(".shanchu").click(function () {
                var ArrayGuid = new Array();
                var bflag = true;
                $("input[name='checksub']").each(function () {
                    if ($(this).is(":checked")) {
                        bflag = false
                        ArrayGuid.push("'" + $(this).val() + "'");
                    }
                });
                if (bflag) {
                    alert("请勾选一项！");
                    return;
                }
                IsDelete(ArrayGuid.join(","));
            });
        });
    </script>
    </form>
</body>
</html>
