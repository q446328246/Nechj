<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Discuz_Settings.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Discuz_Settings" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>����Discuz��̳</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script src="js/CommonJS.js" type="text/javascript"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="����Discuz��̳"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="LabelUnionPostUrl" runat="server" Text="Discuz!NT��ַ��"></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxDiscuzPostUrl" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoUnionPostUrl" runat="server"
                                ControlToValidate="TextBoxDiscuzPostUrl" Display="Dynamic" ErrorMessage="���200���ַ�"
                                ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                            <span>������Discuz!NT��ַ</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelApiKey" runat="server" Text="API KEY��"></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxApiKey" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxApiKey"
                                Display="Dynamic" ErrorMessage="���200���ַ�" ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                            <span>������API KEY</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelSecret" runat="server" Text="��Կ��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxSecret" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoKey" runat="server"
                                ControlToValidate="TextBoxSecret" Display="Dynamic" ErrorMessage="���200���ַ�" ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                            <span>������������Կ</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelDomain" runat="server" Text="��վ��������"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDomain" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxDomain"
                                Display="Dynamic" ErrorMessage="���200���ַ�" ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                            <span style="color: Red; font-size: 12px;">����Ϊhttp://www.t.com����ʽΪshopnum1.com</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelIsIntegration" runat="server" Text="�Ƿ񼯳ɣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsIntegration" runat="server" Checked="True" Text="��" AutoPostBack="true"
                                OnCheckedChanged="CheckBoxIsIntegration_CheckedChanged" />
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
