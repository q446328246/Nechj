<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="UpdatePassword.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.UpdatePassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <ShopNum1:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">
    </ShopNum1:ToolkitScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="修改登录密码"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            当前密码：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOldPwd" runat="server" TextMode="Password" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxOldPwd"
                                Display="Dynamic" ErrorMessage="该值不能为空" ValidationGroup="Pwd"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                                ControlToValidate="TextBoxOldPwd" Display="Dynamic" ErrorMessage="密码最多50个字符"
                                ValidationExpression="^[\s\S]{0,50}$" ValidationGroup="Pwd"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            新密码：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxNewPwd" runat="server" TextMode="Password" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxNewPwd"
                                Display="Dynamic" ErrorMessage="该值不能为空" ValidationGroup="Pwd"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxNewPwd"
                                Display="Dynamic" ErrorMessage="密码6~30个字符" ValidationExpression="^[\s\S]{6,50}$"
                                ValidationGroup="Pwd"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            确认密码：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxRePwd" runat="server" TextMode="Password" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxRepwd"
                                Display="Dynamic" ErrorMessage="该值不能为空" ValidationGroup="Pwd"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRePwd" runat="server"
                                ControlToValidate="TextBoxRepwd" Display="Dynamic" ErrorMessage="密码6~30个字符" ValidationExpression="^[\s\S]{6,50}$"
                                ValidationGroup="Pwd"></asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="CompareValidatorRePwd" Display="Dynamic" runat="server"
                                ErrorMessage="两次密码输入不一致" ControlToValidate="TextBoxRePwd" ControlToCompare="TextBoxNewPwd"
                                ValidationGroup="Pwd"></asp:CompareValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonPwd" runat="server" Text="保存" OnClick="ButtonPwd_Click" CssClass="fanh"
                    ValidationGroup="Pwd" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
