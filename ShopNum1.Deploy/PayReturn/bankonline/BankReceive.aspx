<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="BankReceive.aspx.cs" Inherits="ShopNum1.Deploy.PayReturn.bankonline.BankReceive" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>支付结果</title>
</head>
<body>
    <form id="form1" runat="server">
    <table width="500" border="0" align="center" cellpadding="0" cellspacing="0">
        <%
            if (str == v_md5str)
            {
        %>
        <tr>
            <td valign="top" align="middle">
                <div align="left">
                    <b>订单号:<%= v_oid %></b></div>
            </td>
        </tr>
        <tr>
            <td valign="top" align="middle">
                <div align="left">
                    <b>支付银行:<%= v_pmode %></b></div>
            </td>
        </tr>
        <tr>
            <td valign="top" align="middle">
                <div align="left">
                    <b>支付结果:<%= v_pstring %></b></div>
            </td>
        </tr>
        <tr>
            <td valign="top" align="middle">
                <div align="left">
                    <b>支付金额:<%= v_amount %></b></div>
            </td>
        </tr>
        <tr>
            <td valign="top" align="middle">
                <div align="left">
                    <b>支付币种:<%= v_moneytype %></b></div>
            </td>
        </tr>
        <tr>
            <td valign="top" align="middle">
                <div align="left">
                    <b>备注1:<%= remark1 %></b></div>
            </td>
        </tr>
        <tr>
            <td valign="top" align="middle">
                <div align="left">
                    <b>备注2:<%= remark2 %></b></div>
            </td>
        </tr>
    </table>
    <%
        }
            else
            {
    %>
    <table width="500" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td valign="top" align="middle">
                <%= status_msg %>
            </td>
        </tr>
    </table>
    <%
        }
    %>
    </form>
</body>
</html>
