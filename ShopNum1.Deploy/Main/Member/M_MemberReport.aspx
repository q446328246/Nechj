<%@ Page Language="C#" EnableViewState="false" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="Skin/M_MemberReport.ascx" TagName="M_MemberReport" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的举报</title>
    <link rel='stylesheet' type='text/css' href='style/m.css' />
    <script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="js/Common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <%--    <ShopNum1:M_MemberReport ID="M_MemberReport" runat="server" SkinFilename="Skin/M_MemberReport.ascx" />--%>
    <uc1:M_MemberReport ID="M_MemberReport1" runat="server" />
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
                    ArrayGuid.push("'" + $(this).val() + "'");
                });
                IsDelete(ArrayGuid.join(","));
            });
        });
    </script>
    </form>
</body>
</html>
