<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopActualAuthentication_Detai.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopActualAuthentication_Detai" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link type="text/css" rel="Stylesheet" href="css/index.css" />
</head>
<body style="background-image: url(images/Bg_right.gif); background-repeat: repeat;
    font-size: 12px; padding: 0;">
    <form id="form1" runat="server">
    <div class="navigator">
        <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="����Աʵ���б�"></asp:Label></div>
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td align="right">
                �������ID��
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxShopID" ReadOnly="true" CssClass="allinput3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="20%">
                �������ƣ�
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxShopName" ReadOnly="true" CssClass="allinput3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="20%">
                ���˴���
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxLegalPerson" ReadOnly="true" CssClass="allinput3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                ע��ţ�
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxRegistrationNum" ReadOnly="true" CssClass="allinput3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                Ӫҵִ�գ�
            </td>
            <td align="left">
                <asp:Image ID="ImageIdentityCard" Width="300px" Height="300px" runat="server" />
            </td>
        </tr>
        <div id="divShowHide" runat="server">
            <tr>
                <td align="right">
                    <asp:Label ID="LabelAuditFailedReason" runat="server" Text="��ͨ��ԭ��"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TextBoxAuditFailedReason" runat="server" Height="100px" TextMode="MultiLine"
                        Width="500px" CssClass="allinput1"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxAuditFailedReason" ValidationGroup="ConfiirmButton"
                        ControlToValidate="TextBoxAuditFailedReason" runat="server" ErrorMessage="�������"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxAuditFailedReason"
                        runat="server" ControlToValidate="TextBoxAuditFailedReason" ValidationGroup="ConfiirmButton"
                        Display="Dynamic" ErrorMessage="��ע���250���ַ�" ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
        </div>
        <tr id="trID" runat="server">
            <td align="right">
                <asp:Label ID="LabelAuditStatus" runat="server" Text="���״̬��"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="DropDownListAuditStatus" runat="server" AutoPostBack="true"
                    Width="180px" OnSelectedIndexChanged="DropDownListAuditStatus_SelectedIndexChanged">
                    <asp:ListItem Value="2">���δͨ��</asp:ListItem>
                    <asp:ListItem Value="1">�����ͨ��</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="display: none">
            <td>
                ���״̬
            </td>
            <td>
                <asp:TextBox ID="TextBox" ReadOnly="true" CssClass="allinput3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="ButtonConfiirm" runat="server" ValidationGroup="ConfiirmButton" Text="ȷ��"
                    CssClass="bt2" OnClick="ButtonConfiirm_Click" />
                <input id="inputReset" runat="server" type="reset" value="����" class="bt2" />
                <asp:Button ID="ButtonBank" runat="server" Text="�����б�" CssClass="bt3" OnClick="ButtonBank_Click" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
