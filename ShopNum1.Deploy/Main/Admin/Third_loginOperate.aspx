<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Third_loginOperate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Third_loginOperate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>第三方账户设置</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr runat="server" id="trID" visible="false">
                        <th align="right">
                            <asp:Label ID="LabelID" runat="server" Text="ID："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxID" runat="server" CssClass="tinput" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="LabelName" runat="server" Text="名称："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="最多100个字符" ValidationExpression="^[\s\S]{0,100}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelAppID" runat="server" Text="AppID："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAppID" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label8" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAppID" runat="server" ControlToValidate="TextBoxAppID"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorAppID" runat="server"
                                ControlToValidate="TextBoxAppID" Display="Dynamic" ErrorMessage="AppId最多100个字符"
                                ValidationExpression="^[\s\S]{0,100}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelSecretKey" runat="server" Text="AppSecret："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxSecretKey" runat="server" CssClass="tinput"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorSecretKey" runat="server"
                                ControlToValidate="TextBoxSecretKey" Display="Dynamic" ErrorMessage="AppSecret最多100个字符"
                                ValidationExpression="^[\s\S]{0,100}$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorSecretKey" runat="server" ErrorMessage="该值不能为空"
                                Display="Dynamic" ControlToValidate="TextBoxSecretKey"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelredirectURL" runat="server" Text="回调地址："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxRedirectURL" runat="server" CssClass="tinput"></asp:TextBox><span>
                                请输入回调地址</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" style="height: 120px;">
                            <asp:Label ID="LabelMemo" runat="server" Text="详细介绍："></asp:Label>
                        </th>
                        <td style="height: 120px;">
                            <asp:TextBox ID="TextBoxMemo" runat="server" CssClass="tinput" TextMode="MultiLine"
                                Width="440" Height="100"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxMemo" runat="server"
                                ControlToValidate="TextBoxMemo" Display="Dynamic" ErrorMessage="详细介绍最多400个字符"
                                ValidationExpression="^[\s\S]{0,400}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelOrderID" runat="server" Text="排序号："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOrderID" runat="server" MaxLength="9" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label7" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorOrderID" runat="server"
                                ControlToValidate="TextBoxOrderID" Display="Dynamic" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderID" runat="server" ControlToValidate="TextBoxOrderID"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr class="radiobtn">
                        <th align="right">
                            <asp:Label ID="LabelAvailable" runat="server" Text="是否可用："></asp:Label>
                        </th>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonListAvailable" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Text="启用" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="禁用" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelImg" runat="server" Text="图片："></asp:Label>
                        </th>
                        <td>
                            <asp:FileUpload ID="FileUploadImgSrc" runat="server" CssClass="tinput" />
                            上传图片格式(jpg,png,gif)
                            <asp:Image ID="ImageSrc" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="确定"
                    class="fanh" ToolTip="Submit" />
                <asp:Button ID="Button3" runat="server" CssClass="fanh" CausesValidation="false"
                    PostBackUrl="~/Main/Admin/Third_loginList.aspx" Text="返回列表" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
