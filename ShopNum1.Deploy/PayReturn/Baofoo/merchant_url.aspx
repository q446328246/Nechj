<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="merchant_url.aspx.cs" Inherits="ShopNum1.Deploy.PayReturn.Baofoo.merchant_url" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>充值结果</title>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="30" align="center">
                <h1>
                    ※ 宝付在线支付完成 ※
                </h1>
            </td>
        </tr>
    </table>
    <table bordercolor="#cccccc" cellspacing="5" cellpadding="0" width="400" align="center"
        border="0">
        <tr>
            <td class="text_12" bordercolor="#ffffff" align="right" width="100" height="20">
                订单号：
            </td>
            <td class="text_12" bordercolor="#ffffff" align="left">
                <asp:Label ID="lbOrderID" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="text_12" bordercolor="#ffffff" align="right" width="100" height="20">
                支付金额：
            </td>
            <td class="text_12" bordercolor="#ffffff" align="left">
                <asp:Label ID="lbMoney" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="text_12" bordercolor="#ffffff" align="right" width="100" height="20">
                交易时间：
            </td>
            <td class="text_12" bordercolor="#ffffff" align="left">
                <asp:Label ID="lbDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="text_12" bordercolor="#ffffff" align="right" width="100" height="20">
                交易状态：
            </td>
            <td class="text_12" bordercolor="#ffffff" align="left">
                <asp:Label ID="lbFlag" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
