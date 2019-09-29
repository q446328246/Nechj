<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Baofoopay_post.aspx.cs"
    Inherits="ShopNum1.Deploy.PayReturn.Baofoo.Baofoopay_post" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>充值接口-提交信息处理</title>
</head>
<body onload=' document.pay.submit() '>
    <form name='pay' id="pay" method="post" action="https://paygate.baofoo.com/PayReceive/bankpay.aspx">
    <!--此地址为测试地址，上线请更换为正式地址-->
    <input type='hidden' name='MerchantID' value='<%= strMerchantID %>'>
    <input type='hidden' name='PayID' value='<%= strPayID %>'>
    <input type='hidden' name='TradeDate' value='<%= strTradeDate %>'>
    <input type='hidden' name='TransID' value='<%= strTransID %>'>
    <input type='hidden' name='OrderMoney' value='<%= strOrderMoney %>'>
    <input type='hidden' name='ProductName' value='<%= strProductName %>'>
    <input type='hidden' name='Amount' value='<%= strAmount %>'>
    <input type='hidden' name='ProductLogo' value='<%= strProductLogo %>'>
    <input type='hidden' name='Username' value='<%= strUsername %>'>
    <input type='hidden' name='Email' value='<%= strEmail %>'>
    <input type='hidden' name='Mobile' value='<%= strMobile %>'>
    <input type='hidden' name='AdditionalInfo' value='<%= strAdditionalInfo %>'>
    <input type='hidden' name='Merchant_url' value='<%= strMerchant_url %>'>
    <input type='hidden' name='Return_url' value='<%= strReturn_url %>'>
    <input type='hidden' name='Md5Sign' value='<%= strMd5Sign %>'>
    <input type='hidden' name='NoticeType' value='<%= strNoticeType %>'>
    </form>
</body>
</html>
