<%@ Page Language="C#" EnableViewState="false" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="Skin/M_OrderScoreDetailed.ascx" TagName="M_OrderScoreDetailed"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的举报</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="js/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/js/artDialog/artDialog.js"></script>
    <script type="text/javascript" language="javascript">
        function Alert(str) {
            art.dialog({
                title: '提示',
                content: str,
                icon: 'succeed',
                ok: function () { window.location.reload(); return false; }
            });
        }
        function IsDelete(val) {
            art.dialog({
                content: '是否删除勾选项？',
                ok: function () {
                    $("input[type='checkbox']").removeAttr("checked");
                    $.get("/Api/Main/Member/DeleteOp.ashx?type=Report&delid=" + val, null, function (data) {
                        if (data == "ok") { Alert("删除成功！"); location.reload(); return false; }
                        else { Alert("删除失败！"); return false; }
                    });
                },
                cancelVal: '关闭',
                cancel: true
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="#">我是买家</a>&nbsp;>>&nbsp;<a href="#">交易管理</a>&nbsp;>>&nbsp;<a href="M_OrderScoreList.aspx">红包订单</a>
            >><span>红包订单详细</span></p>
        <uc1:M_OrderScoreDetailed ID="M_OrderScoreDetailed1" runat="server" />
        <%--        <ShopNum1:M_OrderScoreDetailed ID="M_OrderScoreDetailed" runat="server" SkinFilename="Skin/M_OrderScoreDetailed.ascx" />--%>
    </div>
    <script type="text/javascript" language="javascript">
        //跳转到制定的页码
        function ontoPage(txtId) {
            location.href = '?isread=<%= ShopNum1.Common.Common.ReqStr("isread") %>&pageid=' + $("#" + txtId).val();
        }
        $(function () {
            //批量删除操作
            $(".shanchu").click(function () {
                var ArrayGuid = new Array();
                $("input[name='checksub']").each(function () {
                    if ($(this).is(":checked")) {
                        ArrayGuid.push("'" + $(this).val() + "'");
                    }
                });
                IsDelete(ArrayGuid.join(","));
            });
        });
    </script>
    </form>
</body>
</html>
