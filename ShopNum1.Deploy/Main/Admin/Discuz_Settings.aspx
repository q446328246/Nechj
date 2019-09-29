<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Discuz_Settings.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Discuz_Settings" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>整合Discuz论坛</title>
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="整合Discuz论坛"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="LabelUnionPostUrl" runat="server" Text="Discuz!NT地址："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxDiscuzPostUrl" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoUnionPostUrl" runat="server"
                                ControlToValidate="TextBoxDiscuzPostUrl" Display="Dynamic" ErrorMessage="最多200个字符"
                                ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                            <span>请输入Discuz!NT地址</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelApiKey" runat="server" Text="API KEY："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxApiKey" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxApiKey"
                                Display="Dynamic" ErrorMessage="最多200个字符" ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                            <span>请输入API KEY</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelSecret" runat="server" Text="密钥："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxSecret" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoKey" runat="server"
                                ControlToValidate="TextBoxSecret" Display="Dynamic" ErrorMessage="最多200个字符" ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                            <span>请输入您的密钥</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelDomain" runat="server" Text="主站主机名："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDomain" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxDomain"
                                Display="Dynamic" ErrorMessage="最多200个字符" ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                            <span style="color: Red; font-size: 12px;">域名为http://www.t.com，格式为shopnum1.com</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelIsIntegration" runat="server" Text="是否集成："></asp:Label>
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsIntegration" runat="server" Checked="True" Text="是" AutoPostBack="true"
                                OnCheckedChanged="CheckBoxIsIntegration_CheckedChanged" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="确定" ToolTip="Submit" OnClick="ButtonConfirm_Click"
                    CssClass="fanh" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
