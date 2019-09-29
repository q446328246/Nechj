<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>组合套餐列表</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
    <script type="text/javascript" language="javascript">
        $(function () {

        });
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
                location.href = "S_PackAgeList.aspx?pageid=" + pageindex;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <span class="spanrig"><a class="tianjiafl lmf_btn" href="S_PackAgeOpreate.aspx">添加活动</a>
            </span><a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span
                class="breadcrume_text">组合套餐活动列表</span></p>
        <ShopNum1ShopAdmin:S_PackAgeList ID="S_PackAgeList" runat="server" PageSize="10"
            SkinFilename="skin/S_PackAgeList.ascx" />
    </div>
    </form>
</body>
</html>
