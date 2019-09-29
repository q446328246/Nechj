<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Tg_Settings.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Tg_Settings" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>整合团购系统</title>
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
                    <asp:Label ID="Label1" runat="server" Text="整合团购系统"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="LabelUnionPostUrl" runat="server" Text="tTG团购地址："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxUnionPostUrl" runat="server" CssClass="tinput" Width="418px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoUnionPostUrl" runat="server"
                                ControlToValidate="TextBoxUnionPostUrl" Display="Dynamic" ErrorMessage="最多200个字符"
                                ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator><span>请输入tTG团购地址</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelKey" runat="server" Text="密钥："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxKey" runat="server" CssClass="tinput" Width="418px">></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxKey"
                                Display="Dynamic" ErrorMessage="最多200个字符" ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator><span>请输入您的密钥</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelIsIntergration" runat="server" Text="是否集成："></asp:Label>
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsIntergration" runat="server" Checked="True" Text="是" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="确定" ToolTip="Submit" OnClick="ButtonConfirm_Click"
                    CssClass="fanh" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
