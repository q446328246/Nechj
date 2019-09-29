<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="MerchantFailure.aspx.cs"
    Inherits="ShopNum1.Deploy.PayReturn.MerchantFailure" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>农行网上支付平台失败结果接收</title>
    <link type="text/css" rel="Stylesheet" href="style/index.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="_text-align: center;">
        <div style="margin: 0 auto; margin-top: 13px; text-align: left; width: 1000px; _zoom: 1;">
            <div class="all_main">
                <div class="all_dingdan">
                    <div class="dd2">
                        返回信息<br />
                        <asp:Label ID="lblReturnCode" runat="server" Text="Label"></asp:Label>
                        :
                        <asp:Label ID="lblErrorMessage" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="dd_but">
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <input id="butIndex" type="button" value="回到首页" onclick=" javascript:location.href = '/'; "
                                        class="hdsy" />
                                </td>
                                <td>
                                    <input id="butOrder" type="button" value="会到个人中心" class="hyzx" onclick=" javascript:location.href = '/index.html?shopurlOrderList.aspx'; " />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="ad1">
                <a href="#">
                    <img src="Images/ad1.jpg" /></a></div>
        </div>
    </div>
    </form>
</body>
</html>
