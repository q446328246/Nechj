<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>�����Ź���Ʒ</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <script type="text/javascript" language="javascript">
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

        //ҳ����ת

        function ontoPage(o) {
            var pageindex = $(o).parent().parent().prev().prev().find("input").val();
            if (checknum(pageindex)) {
                var pageEnd = parseInt($(".page_2 b").text());
                if (pageEnd <= pageindex)
                    pageindex = pageEnd;
                location.href = "S_GroupProduct.aspx?pageid=" + pageindex;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <span class="spanrig"><a class="tianjiafl lmf_btn" href="S_GroupProductOperate.aspx">
                �����Ʒ</a> </span><a href="S_Welcome.aspx">��������</a><span class="breadcrume_icon">>></span><span
                    class="breadcrume_text">�Ź���Ʒ</span>
        </p>
        <ShopNum1ShopAdmin:S_GroupProduct ID="S_GroupProduct" PageSize="5" runat="server"
            SkinFilename="skin/S_GroupProduct.ascx" />
    </div>
    </form>
</body>
</html>
