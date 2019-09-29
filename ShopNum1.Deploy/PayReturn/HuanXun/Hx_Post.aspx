<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Hx_Post.aspx.cs" Inherits="ShopNum1.Deploy.PayReturn.Hx_Post, ShopNum1.Deploy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onload=' document.pay.submit() '>
    <form name="pay" id="frm1" method="post" action="https://pay.ips.com.cn/ipayment.aspx">
    <input type="hidden" name="Mer_code" value="<%= Mer_code %>" />
    <input type="hidden" name="Billno" value="<%= Billno %>" />
    <input type="hidden" name="Amount" value="<%= Amount %>" />
    <input type="hidden" name="Date" value="<%= BillDate %>" />
    <input type="hidden" name="Currency_Type" value="<%= Currency_Type %>" />
    <input type="hidden" name="Gateway_Type" value="<%= Gateway_Type %>" />
    <input type="hidden" name="Lang" value="<%= Lang %>" />
    <input type="hidden" name="Merchanturl" value="<%= Merchanturl %>" />
    <input type="hidden" name="FailUrl" value="<%= FailUrl %>" />
    <input type="hidden" name="ErrorUrl" value="<%= ErrorUrl %>" />
    <input type="hidden" name="Attach" value="<%= Attach %>" />
    <input type="hidden" name="DispAmount" value="<%= DispAmount %>" />
    <input type="hidden" name="OrderEncodeType" value="<%= OrderEncodeType %>" />
    <input type="hidden" name="RetEncodeType" value="<%= RetEncodeType %>" />
    <input type="hidden" name="Rettype" value="<%= Rettype %>" />
    <input type="hidden" name="ServerUrl" value="<%= ServerUrl %>" />
    <input type="hidden" name="SignMD5" value="<%= SignMD5 %>" />
    </form>
</body>
</html>
