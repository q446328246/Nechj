<%@ Page Language="C#" EnableViewState="true" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="Skin/S_PostageSettings.ascx" TagName="S_PostageSettings"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�ʷ�����</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <script src="js/SpryTabbedPanels.js" type="text/javascript"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">��������</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">�ʷ�����</span></p>
       <uc1:S_PostageSettings ID="S_PostageSettings" runat="server" PageSize="10" />
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
