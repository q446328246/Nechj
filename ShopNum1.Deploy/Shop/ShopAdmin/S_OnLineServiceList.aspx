<%@ Page Language="C#" EnableViewState="false" %>

<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>�ͷ�����</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <script src="js/SpryTabbedPanels.js" type="text/javascript"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">��������</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">�ͷ�����</span></p>
        <ShopNum1ShopAdmin:S_OnLineServiceList ID="S_OnLineServiceList" runat="server" SkinFilename="Skin/S_OnLineServiceList.ascx"
            PageSize="10" />
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
