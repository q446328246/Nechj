<%@ Page Language="C#" EnableViewState="false" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="Skin/A_AdPayRecharge.ascx" TagName="A_AdPayRecharge" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>财务管理-人民币充值</title>
    <script src="/js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script src="js/jquery.pack.js" type="text/javascript"></script>
    <script src="/JS/DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="js/Common.js" type="text/javascript"></script>
</head>
<body>
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="A_Welcome.aspx">账户管理</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">人民币充值</span></p>
        <form runat="server" id="fromA_AdPayTiXian">
        <%--        <ShopNum1Account:A_AdPayRecharge ID="A_AdPayRecharge" runat="server" SkinFilename="Skin/A_AdPayRecharge.ascx"
            PageSize="10" />--%>
        <uc1:A_AdPayRecharge ID="A_AdPayRecharge1" runat="server" PageSize="10" />
        </form>
        <script type="text/javascript" language="javascript">
            // 判断是否是数字
            function checknum(str) {
                var re = /^[0-9]+.?[0-9]*$/;
                if (!re.test(str)) {
                    alert("请输入正确的数字！");
                    return false;
                } else { return true; }
            }
            //跳转到制定的页码
            function ontoPage(txtId) {
                var pageindex = $(o).parent().parent().prev().prev().find("input").val();
                if (checknum(pageindex)) {
                    location.href = '?sort=<%=ShopNum1.Common.Common.ReqStr("sort")%>&StartTime=<%=ShopNum1.Common.Common.ReqStr("StartTime")%>&EndTime=<%=ShopNum1.Common.Common.ReqStr("EndTime")%>&RechargeType=<%=ShopNum1.Common.Common.ReqStr("RechargeType")%>&type=1&pageid=' + pageindex;
                }

            }
        </script>
    </div>
</body>
