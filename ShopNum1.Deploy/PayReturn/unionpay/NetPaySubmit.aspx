<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="NetPaySubmit.aspx.cs" Inherits="ShopNum1.Deploy.PayReturn.NetPaySubmit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>支付交易</title>
</head>
<body onload=" javascript:myform.submit(); ">
    <form id="myform" runat="server" method="post" action="http://www.baidu.com">
    <h1>
        支付交易</h1>
    <h3>
        支付测试方法</h3>
    <h4>
        点击“支付”按钮，跳转到农商行网关支付页面后，输入卡密和验证码即可完成支付，输入密码时请选择“键盘”</h4>
    <h5>
        卡号：[123456789001]</h5>
    <h5>
        密码：[789001]</h5>
    <h5>
        <a href="javascript:window.location.reload()">刷新本页以改变订单号</a></h5>
    <h5>
        <span style="color: red">*</span>&nbsp;&nbsp;表示必填</h5>
    <table>
        <tr>
            <td>
                商户号:
            </td>
            <td>
                <asp:TextBox ID="MerId" runat="server" Text="808080580006321"></asp:TextBox>
                &nbsp;&nbsp;<span style="color: red">*</span>&nbsp;&nbsp;15位长度
            </td>
        </tr>
        <tr>
            <td>
                支付版本号:
            </td>
            <td>
                <asp:TextBox ID="Version" runat="server" Text="20070129"></asp:TextBox>
                &nbsp;&nbsp;<span style="color: red">*</span>
            </td>
        </tr>
        <tr>
            <td>
                订单号:
            </td>
            <td>
                <%--<input id="OrdId" name="OrdId" value="<%=SignData.getOrdId() %>" />--%>
                <asp:TextBox ID="OrdID" runat="server"></asp:TextBox>
                &nbsp;&nbsp;<span style="color: red">*</span>&nbsp;&nbsp;16位长度
            </td>
        </tr>
        <tr>
            <td>
                订单金额:
            </td>
            <td>
                <asp:TextBox ID="TransAmt" runat="server" Text="000002000001"></asp:TextBox>
                &nbsp;&nbsp;<span style="color: red">*</span>&nbsp;&nbsp;单位为分，12位长度，不足12位左补0
            </td>
        </tr>
        <tr>
            <td>
                货币代码:
            </td>
            <td>
                <asp:TextBox ID="CuryId" runat="server" Text="156"></asp:TextBox>
                &nbsp;&nbsp;<span style="color: red">*</span>&nbsp;&nbsp;3位长度
            </td>
        </tr>
        <tr>
            <td>
                订单日期:
            </td>
            <td>
                <%--<input id="TransDate" name="TransDate" value="<%=SignData.getTransDate() %>" />--%>
                <asp:TextBox ID="TransDate" runat="server"></asp:TextBox>
                &nbsp;&nbsp;<span style="color: red">*</span>&nbsp;&nbsp;8位长度
            </td>
        </tr>
        <tr>
            <td>
                交易类型:
            </td>
            <td>
                <asp:TextBox ID="TransType" runat="server" Text="0001"></asp:TextBox>
                &nbsp;&nbsp;<span style="color: red">*</span>&nbsp;&nbsp;4位长度
            </td>
        </tr>
        <tr>
            <td>
                后台返回地址:
            </td>
            <td>
                <asp:TextBox ID="BgRetUrl" runat="server"></asp:TextBox>
                &nbsp;&nbsp;<span style="color: red">*</span>&nbsp;&nbsp;长度不要超过80个字节
            </td>
        </tr>
        <tr>
            <td>
                页面返回地址:
            </td>
            <td>
                <asp:TextBox ID="PageRetUrl" runat="server"></asp:TextBox>
                &nbsp;&nbsp;<span style="color: red">*</span>&nbsp;&nbsp;长度不要超过80个字节
            </td>
        </tr>
        <tr>
            <td>
                网关号:
            </td>
            <td>
                <asp:TextBox ID="GateId" runat="server" Text="8607" />
            </td>
        </tr>
        <tr>
            <td>
                备注:
            </td>
            <td>
                <asp:TextBox ID="Priv1" runat="server" Text="memo" />
            </td>
        </tr>
        <tr>
            <td>
                密钥:
            </td>
            <td>
                <asp:TextBox ID="ChkValue" runat="server" Text="ChkValue" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <input type="submit" id="subT" value="提交" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
