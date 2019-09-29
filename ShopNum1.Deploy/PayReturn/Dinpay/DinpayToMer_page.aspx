<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DinpayToMer_page.aspx.cs" Inherits="ShopNum1.Deploy.PayReturn.Dinpay.DinpayToMer_page" ResponseEncoding="utf-8" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>智付完成跳转返回页面文件（页面跳转同步通知页面）</title>
    <style type="text/css">
        .font_content
        {
            color: #FF6600;
            font-family: "宋体";
            font-size: 14px;
        }
        
        .font_title
        {
            color: #FF0000;
            font-family: "宋体";
            font-size: 16px;
            font-weight: bold;
        }
        
        table
        {
            border: 1px solid #CCCCCC;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table align="center" width="350" cellpadding="5" cellspacing="0">
        <tr>
            <td align="center" class="font_title" colspan="2">
                通知返回1
            </td>
        </tr>
        <tr>
            <td class="font_content" align="right">
                智付交易定单号：
            </td>
            <td class="font_content" align="left">
                <asp:Label ID="lbtrade_no" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="font_content" align="right">
                商家订单号：
            </td>
            <td class="font_content" align="left">
                <asp:Label ID="lborder_no" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="font_content" align="right">
                订单金额：
            </td>
            <td class="font_content" align="left">
                <asp:Label ID="lborder_amount" runat="server"></asp:Label>
            </td>
        </tr>
       
      
      
        
      
        <tr>
            <td class="font_content" align="right">
                交易状态：
            </td>
            <td class="font_content" align="left">
                <asp:Label ID="lbtrade_status" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="font_content" align="right">
                银行流水号：
            </td>
            <td class="font_content" align="left">
                <asp:Label ID="lbbank_seq_no" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="font_content" align="right">
                验证状态：
            </td>
            <td class="font_content" align="left">
                <asp:Label ID="lbVerify" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
