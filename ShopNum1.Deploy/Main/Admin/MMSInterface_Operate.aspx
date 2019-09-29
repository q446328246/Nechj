<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="MMSInterface_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.MMSInterface_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>短信接口设置</title>
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
                    <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="短信接口设置"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="LabelName" runat="server" Text="发送方式："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:DropDownList ID="DropDownListType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListType_SelectedIndexChanged"
                                Width="160" CssClass="tselect">
                                <asp:ListItem Text="-请选择-" Value="-1"></asp:ListItem>
                                <%--   <asp:ListItem Text="喻蜂短信接口" Value="1"></asp:ListItem>
                                <asp:ListItem Text="短信王短信接口" Value="2"></asp:ListItem>--%>
                                <asp:ListItem Text="短信宝短信接口" Value="3"></asp:ListItem>
                                <%--<asp:ListItem Text="极速天使" Value="4" ></asp:ListItem>--%>
                            </asp:DropDownList>
                            <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:CompareValidator ID="CompareFatherCateGory" runat="server" ControlToValidate="DropDownListType"
                                Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual" ValueToCompare="-1">
                            </asp:CompareValidator>
                        </td>
                    </tr>
                    <asp:Panel ID="PanelType" runat="server" Visible="false">
                        <tr>
                            <th align="right">
                                <asp:Label ID="Label3" runat="server" Text="企业代码："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxCode" runat="server" Style="width: 150px;"></asp:TextBox>
                                <asp:Label ID="Label7" runat="server" Text="*" ForeColor="red"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxCode"
                                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxCode"
                                    Display="Dynamic" ErrorMessage="最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label4" runat="server" Text="用户名："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxName" runat="server" Style="width: 150px;" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label5" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label6" runat="server" Text="账号密码："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxPwd" runat="server" Style="width: 150px;" CssClass="tinput"
                                TextMode="Password"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxPwd"
                                Display="Dynamic" ErrorMessage="最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            接收手机号：
                        </th>
                        <td>
                            <asp:TextBox ID="txtTel" runat="server" Style="width: 150px;" CssClass="tinput"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                ID="butTest" runat="server" Text="测试发送" ToolTip="Submit" CssClass="fanh" OnClick="butTest_Click" />(测试前请先保存正确的配置)
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            发送内容：
                        </th>
                        <td>
                            <asp:TextBox ID="txtRc" runat="server" Style="width: 150px;" CssClass="tinput" Text="[武汉唐江国际]"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="保存配置" ToolTip="Submit" CssClass="fanh"
                    OnClick="ButtonConfirm_Click" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
