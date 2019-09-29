<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adduser.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.adduser" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <link rel="stylesheet" type="text/css" href="style/css.css" />
        <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
        <script type="text/javascript" language="javascript" src="JS/jquery-1.9.1.js"> </script>
        <script type="text/javascript" language="javascript" src="JS/CommonJS.js"> </script>
    </head>
    <body style="background: none;">
        <form id="form1" runat="server">
            <div style="padding: 20px;">
                <div class="inner_page_list">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <th align="right" width="20%">
                                <asp:Label ID="LabelName" runat="server" Text="用户名："></asp:Label>
                            </th>
                            <td align="left">
                                <asp:TextBox ID="TextBoxLoginID" CssClass="tinput" Width="220" runat="server"></asp:TextBox>
                                <asp:Label ID="Label3" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorLoginID" runat="server" ControlToValidate="TextBoxLoginID"
                                                            Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorLoginID" runat="server"
                                                                ControlToValidate="TextBoxLoginID" Display="Dynamic" ErrorMessage="用户名不能超过50个字符"
                                                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelPassword1" runat="server" Text="密码："></asp:Label>
                            </th>
                            <td align="left">
                                <asp:TextBox ID="TextBoxPassword1" CssClass="tinput" Width="220" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:Label ID="Label7" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxPassword1"
                                                            Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelPassword2" runat="server" Text="确认密码："></asp:Label>
                            </th>
                            <td align="left">
                                <asp:TextBox ID="TextBoxPassword2" CssClass="tinput" Width="220" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:Label ID="Label8" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPassword2"
                                                            Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="TextBoxPassword1"
                                                      ControlToValidate="TextBoxPassword2" ErrorMessage="两次密码输入不一致"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelRealName" runat="server" Text="姓名："></asp:Label>
                            </th>
                            <td align="left">
                                <asp:TextBox ID="TextBoxRealName" CssClass="tinput" Width="220" runat="server"></asp:TextBox>
                                <asp:Label ID="Label4" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRealName" runat="server" ControlToValidate="TextBoxRealName"
                                                            Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorRealName" runat="server"
                                                                ControlToValidate="TextBoxRealName" Display="Dynamic" ErrorMessage="姓名最多50个字符"
                                                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelSex" runat="server" Text="性别："></asp:Label>
                            </th>
                            <td align="left">
                                <asp:DropDownList ID="DropDownListSex" runat="server" Width="220" CssClass="tselect">
                                    <asp:ListItem Selected="True" Value="1">男</asp:ListItem>
                                    <asp:ListItem Value="0">女</asp:ListItem>
                                    <asp:ListItem Value="2">保密</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr class="radiobtn">
                            <th align="right">
                                用户身份：
                            </th>
                            <td>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                                     RepeatLayout="Flow" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                    <asp:ListItem Value="1" Text="操作员" Selected="True" name="input"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="管理员" name="input"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <th align="right">
                                <asp:Label ID="LabelDept" runat="server" Text="所属部门："></asp:Label>
                            </th>
                            <td align="left" style="display: none">
                                <asp:DropDownList ID="DropDownListDept" runat="server" Width="220" CssClass="tselect">
                                    <asp:ListItem Value="-1">请选择</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label5" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                                <%-- <asp:CompareValidator ID="CompareValidatorDept" runat="server" ControlToValidate="DropDownListDept"
                                    Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>--%>
                            </td>
                        </tr>
                        <asp:Panel runat="server" ID="pane1">
                            <tr id="DropGroup">
                                <%-- <th align="right">
                                <asp:Label ID="LabelGroup" runat="server" Text="所属用户组："></asp:Label>
                            </th>
                            <td align="left">
                                <asp:CheckBoxList ID="CheckBoxListGroup" runat="server">
                                </asp:CheckBoxList>
                            </td>--%>
                                <th align="right">
                                    <asp:Label ID="LabelGroup" runat="server" Text="所属角色组："></asp:Label>
                                </th>
                                <td align="left">
                                    <asp:DropDownList ID="DropDownListGroup" runat="server" Width="220" CssClass="tselect">
                                        <asp:ListItem Value="-1">请选择</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="Label10" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="DropDownListGroup"
                                                          Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                                </td>
                            </tr>
                        </asp:Panel>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelAge" runat="server" Text="年龄："></asp:Label>
                            </th>
                            <td align="left">
                                <asp:TextBox ID="TextBoxAge" MaxLength="3" CssClass="tinput" Width="220" runat="server">0</asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxAge"
                                                                runat="server" ControlToValidate="TextBoxAge" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"
                                                                Display="Dynamic"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelWorkNumber" runat="server" Text="工号："></asp:Label>
                            </th>
                            <td align="left">
                                <asp:TextBox ID="TextBoxWorkNumber" MaxLength="20" CssClass="tinput" Width="220"
                                             runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelEmail" runat="server" Text="Email(电子邮箱)："></asp:Label>
                            </th>
                            <td align="left">
                                <asp:TextBox ID="TextBoxEmail" CssClass="tinput" Width="220" runat="server"></asp:TextBox>
                                <asp:Label ID="Label6" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="TextBoxEmail"
                                                            Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server"
                                                                ControlToValidate="TextBoxEmail" Display="Dynamic" ErrorMessage="邮箱最多100个字符"
                                                                ValidationExpression="^[\s\S]{0,100}$"></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEmail"
                                                                Display="Dynamic" ErrorMessage="邮箱格式不正确！" ValidationExpression="^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelTelephone" runat="server" Text="电话："></asp:Label>
                            </th>
                            <td align="left">
                                <asp:TextBox ID="TextBoxTelephone" CssClass="tinput" Width="220" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxTelephone" runat="server"
                                                                ControlToValidate="TextBoxTelephone" Display="Dynamic" ErrorMessage="请填写正确的电话号码"
                                                                ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelIsForbid" runat="server" Text="状态："></asp:Label>
                            </th>
                            <td align="left">
                                <asp:DropDownList ID="DropDownListIsForbid" runat="server" Width="220" CssClass="tselect">
                                    <asp:ListItem Value="1">禁用</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="0">启用</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <div style="margin-top: 12px; text-align: center;">
                        <asp:Button ID="ButtonConfirm" runat="server" Text="确定" OnClick="ButtonConfirm_Click"
                                    ToolTip="Submit" CssClass="dele" />
                        <input id="inputReset" runat="server" type="reset" value="重置" class="dele" visible="false" />
                        <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
        </form>
    </body>
</html>