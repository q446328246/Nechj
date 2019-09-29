<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="SP_Post.aspx.cs" Inherits="ShopNum1.Deploy.PayReturn.ShengPay.SP_Post" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body onload=' document.pay.submit() '>
        <form id="pay" name="pay" method="post" action="http://mas.sdo.com/web-acquire-channel/cashier.htm">
            <input name="Name" type="hidden" id="Name" value="<%= ShenPayName %>" />
            <input name="Version" type="hidden" id="Version" value="<%= Version %>" />
            <input name="Charset" type="hidden" id="Charset" value="<%= Charset %>" />
            <input name="MsgSender" type="hidden" id="MsgSender" value="<%= MsgSender %>" />
            <input name="SendTime" type="hidden" id="SendTime" value="<%= SendTime %>" />
            <input name="OrderNo" type="hidden" id="OrderNo" value="<%= OrderNo %>" />
            <input name="OrderAmount" type="hidden" id="OrderAmount" value="<%= OrderAmount %>" />
            <input name="OrderTime" type="hidden" id="OrderTime" value="<%= OrderTime %>" />
            <input name="PayType" type="hidden" id="PayType" value="<%= PayType %>" />
            <input name="payChannel" type="hidden" id="payChannel" value="<%= payChannel %>" />
            <input name="InstCode" type="hidden" id="InstCode" value="<%= InstCode %>" />
            <input name="PageUrl" type="hidden" id="PageUrl" value="<%= PageUrl %>" />
            <input name="NotifyUrl" type="hidden" id="NotifyUrl" value="<%= NotifyUrl %>" />
            <input name="ProductName" type="hidden" id="ProductName" value="<%= ProductName %>" />
            <input name="BuyerContact" type="hidden" id="BuyerContact" value="<%= BuyerContact %>" />
            <input name="BuyerIp" type="hidden" id="BuyerIp" value="<%= BuyerIp %>" />
            <input name="Ext1" type="hidden" id="Ext1" value="<%= Ext1 %>" />
            <input name="SignType" type="hidden" id="SignType" value="<%= SignType %>" />
            <input name="SignMsg" type="hidden" id="SignMsg" value="<%= SignMsg %>" />
        </form>
    </body>
</html>