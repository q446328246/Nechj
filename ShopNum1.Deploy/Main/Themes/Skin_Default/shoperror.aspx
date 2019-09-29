<%@ Page Language="C#" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:ProductCategoryMeto ID="ProductCategoryMeto" runat="server" SkinFilename="ProductCategoryMeto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var num = 60;
        var timeInterv = window.setInterval(function onTime1() {
            var spanTimeValue = document.getElementById("spanTime").innerHTML;
            if (parseInt(spanTimeValue) <= 0) {
                window.clearInterval(timeInterv);
                window.location.href = '<%=ShopUrlOperate.GetSiteDomain() %>';
            } else {
                document.getElementById("spanTime").innerHTML = parseInt(spanTimeValue) - 1;
            }

        }, 1000);
    </script>
</head>
<body style="background: none;">
    <form id="form1" runat="server">
    <!--head Start-->
    <!-- #include file="headShop.aspx" -->
    <!--//head End-->
    <!-- main Start -->
    <div class="ShopError clearfix">
        <!--���̹ر�-->
        <div class="ignore">
            <dl>
                <dt class="knight">
                    <img src="Themes/Skin_Default/Images/mofines.jpg" /></dt>
                <dd class="warrior snipe">
                    <h4>
                        �Բ��������ʵĵ��̿����ѱ��ر�......</h4>
                    ���ڣ������Խ������²�����
                    <p class="courtday">
                        1.<span id="spanTime" class="redtwo">60</span> �����ת�� <a href="/">��ҳ</a><br />
                        2.���� <a href='<%= ShopUrlOperate.RetUrl("ShopListSearch") %>'>���̳�</a> �������̣������кܶ����Ѱ�ҵĺõ���<br />
                        3.<a href="javascript:void(0)" onclick="window.history.go(-1)">����</a> ���ղŵ�����</p>
                    <p>
                    </p>
                </dd>
            </dl>
        </div>
    </div>
    <!-- //main End -->
    <!--foot Start-->
    <!-- #include file="foot1.aspx" -->
    <!--//foot End-->
    </form>
</html>
