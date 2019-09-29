<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="TbCategory_Settings.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.TbCategory_Settings" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script src="js/CommonJS.js" type="text/javascript"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="�Ա����ർ�����"></asp:Label>
                </h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="LabelUnionPostUrl" runat="server" Text="�Ա�AppKey��"></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxKey" runat="server" CssClass="tinput" Width="415px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoKey" runat="server"
                                ControlToValidate="TextBoxKey" Display="Dynamic" ErrorMessage="���200���ַ�" ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator><span>��������������Կ</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelKey" runat="server" Text="�Ա�AppSecret��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxUnionPostUrl" runat="server" CssClass="tinput" Width="416px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoUnionPostUrl" runat="server"
                                ControlToValidate="TextBoxUnionPostUrl" Display="Dynamic" ErrorMessage="���200���ַ�"
                                ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator><span>�Ա�AppKey</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelIsIntergration" runat="server" Text="�Ƿ񼯳ɣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsIntergration" runat="server" Checked="True" Text="��" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" ToolTip="Submit" OnClick="ButtonConfirm_Click"
                    CssClass="fanh" />
            </div>
        </div>
    </div>
    <%-- <div class="navigator">
        <asp:Label ID="LabelPageTitle" runat="server" Text="�� ����ShopNum1����ϵͳ ��"></asp:Label></div>
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
        <tr>
            <td align="right" style="width: 20%;">
                &nbsp;
            </td>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%;">
                <asp:Label ID="LabelUnionPostUrl" runat="server" Text="ShopNum1���˵�ַ��"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxUnionPostUrl" runat="server" CssClass="input2" Width="416px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoUnionPostUrl" runat="server"
                    ControlToValidate="TextBoxUnionPostUrl" Display="Dynamic" ErrorMessage="���200���ַ�"
                    ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%;">
                <asp:Label ID="LabelKey" runat="server" Text="��Կ��"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxKey" runat="server" CssClass="input2" Width="415px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoKey" runat="server"
                    ControlToValidate="TextBoxKey" Display="Dynamic" ErrorMessage="���200���ַ�" ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%;">
                <asp:Label ID="LabelIsIntergration" runat="server" Text="�Ƿ񼯳ɣ�"></asp:Label>
            </td>
            <td align="left">
                <asp:CheckBox ID="CheckBoxIsIntergration" runat="server" Checked="True" Text="��" />
            </td>
        </tr>
        <tr style="background:#F1F1F1;">
            <td align="right" style="width: 20%;">
                &nbsp;
            </td>
            <td style="text-align:left;">
                    <asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" Width="59px" ToolTip="Submit"
                        OnClick="ButtonConfirm_Click" CssClass="bt2" />
                    <input id="inputReset" runat="server" type="reset" value="����" class="bt2" />&nbsp;
                    <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </td>
        </tr>
    </table>--%>
    </form>
</body>
</html>
