<%@ Page Language="C#" EnableViewState="false" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="Skin/A_AdPayDecrease.ascx" TagName="A_AdPayDecrease" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�˻�����-����ҹ���</title>
    <script src="/js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script src="js/jquery.pack.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/SpryTabbedPanels.js"></script>
    <script src="/JS/DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="/JS/DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="A_Welcome.aspx">�˻�����</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">����</span></p>
        <form runat="server" id="fromA_AdPayTiXian">
        <%--        <ShopNum1Account:A_AdPayDecrease ID="A_AdPayDecrease" runat="server" SkinFilename="Skin/A_AdPayDecrease.ascx"
            PageSize="10" />--%>
        <uc1:A_AdPayDecrease ID="A_AdPayDecrease1" runat="server" PageSize="10" />
        <script type="text/javascript" language="javascript">
            // �ж��Ƿ�������
            function checknum(str) {
                var re = /^[0-9]+.?[0-9]*$/;
                if (!re.test(str)) {
                    alert("��������ȷ�����֣�");
                    return false;
                } else { return true; }
            }
            //ҳ����ת
            function ontoPage(o) {
                var pageindex = $(o).parent().parent().prev().prev().find("input").val();
                if (checknum(pageindex)) {
                    var pageEnd = parseInt($(".page_2 b:eq(0)").text());
                    if (pageEnd <= pageindex)
                        pageindex = pageEnd;
                    location.href = 'A_AdPayDecrease.aspx?sort=<%=ShopNum1.Common.Common.ReqStr("sort")%>&type=1&pageid=' + pageindex;
                }
            }
        </script>
        </form>
    </div>
</body>
</html>
