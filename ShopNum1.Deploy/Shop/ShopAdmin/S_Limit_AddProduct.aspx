<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加商品</title>
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <script type="text/javascript" language="javascript" src="js/S_Limit.js"> </script>
    <script type="text/javascript" src="js/Common.js" language="javascript"> </script>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" language="javascript">
        // 判断是否是数字
        function checknum(str) {
            var re = /^[0-9]+.?[0-9]*$/;
            if (!re.test(str)) {
                alert("请输入正确的数字！");
                return false;
            } else {
                return true;
            }
        }

        //页面跳转

        function ontoPage(o) {
            var pageindex = $(o).parent().parent().prev().prev().find("input").val();
            if (checknum(pageindex)) {
                var pageEnd = parseInt($(".page_2 b").text());
                if (pageEnd <= pageindex)
                    pageindex = pageEnd;
                location.href = 'S_Limit_AddProduct.aspx?act=add&lid=<%= Request.QueryString["lid"] %>&pageid=' + pageindex;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ShopNum1ShopAdmin:S_Limit_AddProduct ID="S_Limit_AddProduct" PageSize="8" runat="server"
        SkinFilename="skin/S_Limit_AddProduct.ascx" />
    </form>
</body>
</html>
