<%@ Page Language="C#" EnableViewState="false" %>

<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>��ѯ�ظ�</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script src="js/jquery.pack.js" type="text/javascript"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <span class="spanrig"></span><a href="S_Welcome.aspx">��������</a><span class="breadcrume_icon">>></span><span
                class="breadcrume_text">��ѯ�ظ�</span></p>
        <ShopNum1ShopAdmin:S_MessageBoardList ID="S_MessageBoardList" runat="server" SkinFilename="skin/S_MessageBoardList.ascx"
            PageSize="5" />
    </div>
    </form>
    <script type="text/javascript" language="javascript">
        //��ת���ƶ���ҳ��
        function ontoPage(txtId) {
            var pageindex = $(o).parent().parent().prev().prev().find("input").val();
            if (checknum(pageindex)) {
                var pageEnd = parseInt($(".page_2 b:eq(0)").text());
                if (pageEnd <= pageindex)
                    pageindex = pageEnd;
                location.href = '?isread=<%= ShopNum1.Common.Common.ReqStr("isread") %>&pageid=' + pageindex;
            }
        }

        // �ж��Ƿ�������

        function checknum(str) {
            var re = /^[0-9]+.?[0-9]*$/;
            if (!re.test(str)) {
                alert("��������ȷ�����֣�");
                return false;
            } else {
                return true;
            }
        }
    </script>
</body>
</html>
