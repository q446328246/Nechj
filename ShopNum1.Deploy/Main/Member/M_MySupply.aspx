<%@ Page Language="C#" EnableViewState="false" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="Skin/M_MySupply.ascx" TagName="M_MySupply" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的供求</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="js/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/js/artDialog/artDialog.js"></script>
    <script type="text/javascript" language="javascript">
        function IsDelete(val) {
            if (confirm("是否删除勾选项？")) {
                $("input[type='checkbox']").removeAttr("checked");
                $.get("/Api/Main/Member/DeleteOp.ashx?type=SupplyDemand&delid=" + val, null, function (data) {
                    if (data == "ok") { alert("删除成功！"); location.reload(); window.location.href = "M_MySupply.aspx"; return false; }
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
            <a href="M_Welcome.aspx">我是买家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">我的供求</span></p>
        <uc1:M_MySupply ID="M_MySupply1" runat="server" PageSize="10" />
        <%--        <ShopNum1:M_MySupply ID="M_MySupply" runat="server" SkinFilename="Skin/M_MySupply.ascx"
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
                var falt = false;
                $("input[name='checksub']").each(function () {
                    if ($(this).is(":checked")) {
                        falt = true;
                        ArrayGuid.push("'" + $(this).val() + "'");
                    }
                });
                if (falt) {
                    IsDelete(ArrayGuid.join(","));
                }
                else {
                    alert("请选择一项数据！");
                }

            });
        });
    </script>
    </form>
</body>
</html>
