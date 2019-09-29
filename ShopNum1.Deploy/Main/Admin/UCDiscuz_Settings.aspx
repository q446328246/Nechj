<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="UCDiscuz_Settings.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.UCDiscuz_Settings" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>����UCenter</title>
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="����UCenter"></asp:Label>
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
                            <asp:Label ID="LabelUnionPostUrl" runat="server" Text="���ط�����IP��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDiscuzPostUrl" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoUnionPostUrl" runat="server"
                                ControlToValidate="TextBoxDiscuzPostUrl" Display="Dynamic" ErrorMessage="���200���ַ�"
                                ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator><span>�����뱾�ط�����IP</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelApiKey" runat="server" Text="UCenter��ַ��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxUCenterUrl" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxUCenterUrl"
                                Display="Dynamic" ErrorMessage="���200���ַ�" ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator><span>������UCenter��ַ</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelSecret" runat="server" Text="��Կ��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxSecret" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoKey" runat="server"
                                ControlToValidate="TextBoxSecret" Display="Dynamic" ErrorMessage="���200���ַ�" ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator><span>������������Կ</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelID" runat="server" Text="Ӧ��ID��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxIDValue" runat="server" CssClass="tinput" Text="1"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBox" runat="server" ControlToValidate="TextBoxIDValue"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryOrderID" runat="server"
                                ControlToValidate="TextBoxIDValue" ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelDomain" runat="server" Text="UCenter���룺"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxCharset" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxCharset"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <span>������UCenter����</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelIsIntegration" runat="server" Text="�Ƿ񼯳ɣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsIntegration" runat="server" Checked="True" Text="��" OnCheckedChanged="CheckBoxIsIntegration_CheckedChanged" />
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
    </form>
</body>
</html>
