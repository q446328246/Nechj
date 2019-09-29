<%@ Page Language="C#" EnableViewState="false" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="Skin/M_OrderScoreList.ascx" TagName="M_OrderScoreList" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的举报</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="js/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/js/artDialog/artDialog.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <%--    <ShopNum1:M_OrderScoreList ID="M_OrderScoreList" runat="server" SkinFilename="Skin/M_OrderScoreList.ascx"
        PageSize="10" />--%>
    <uc1:M_OrderScoreList ID="M_OrderScoreList1" runat="server" PageSize="10" />
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
