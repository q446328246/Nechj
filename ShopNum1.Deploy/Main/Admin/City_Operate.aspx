<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="City_Operate.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.City_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link type="text/css" rel="Stylesheet" href="css/index.css" />
</head>
<body style="background-image: url(images/Bg_right.gif); background-repeat: repeat;
    padding: 0;">
    <form id="form1" runat="server">
    <div class="navigator">
        <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="【新增城市】"></asp:Label>
    </div>
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
                <asp:Label ID="LabelName" runat="server" Text="城市名称："></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxName" runat="server" CssClass="input2"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                    ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="名称最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%;">
                <asp:Label ID="LabelFatherID" runat="server" Text="所属城市："></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="DropDownListFatherID" runat="server" CssClass="select2">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%;">
                <asp:Label ID="Label5" runat="server" Text="拼音缩写："></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxShortName" runat="server" CssClass="input2"></asp:TextBox>
                <asp:Label ID="Label6" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxShortName"
                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxShortName"
                    Display="Dynamic" ErrorMessage="最多输入20个字母" ValidationExpression="^[A-Za-z]+$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%;">
                <asp:Label ID="LabelKeywords" runat="server" Text="城市字母："></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxLetter" runat="server" CssClass="input2"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" ForeColor="#FF0066" Text="*只能输入一个大写字母"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxLetter"
                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorKeywords" runat="server"
                    ControlToValidate="TextBoxLetter" Display="Dynamic" ErrorMessage="只能输入一个大写字母"
                    ValidationExpression="^[A-Z]{1}$"></asp:RegularExpressionValidator>
            </td>
            <%--"^[A-Za-z]{1}$"--%>
        </tr>
        <tr>
            <td align="right" style="width: 20%;">
                <asp:Label ID="LabelOrderID" runat="server" Text="排序ID："></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxOrderID" MaxLength="9" runat="server" CssClass="input2"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderID" runat="server" ControlToValidate="TextBoxOrderID"
                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorOrderID" runat="server"
                    ControlToValidate="TextBoxOrderID" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%;">
                <asp:Label ID="LabelIsShow" runat="server" Text="是否显示："></asp:Label>
            </td>
            <td align="left">
                <asp:CheckBox ID="CheckBoxIsShow" runat="server" Text="显示" Checked="True" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%;">
                <asp:Label ID="Label1" runat="server" Text="是否热门地区："></asp:Label>
            </td>
            <td align="left">
                <asp:CheckBox ID="CheckBoxIsHot" runat="server" Text="是否热门地区" Checked="false" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%;">
                &nbsp;
            </td>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr style="background-color: #EEEEEE; padding: 3px 0">
            <td align="right" style="width: 20%;">
                &nbsp;
            </td>
            <td align="left">
                <div style="width: 80%;">
                    <asp:Button ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="确定"
                        ToolTip="Submit" CssClass="bt2" />
                    <input id="inputReset" runat="server" type="reset" value="重置" class="bt2" visible="false" />
                    <a href="City_List.aspx">
                        <img src="images/back.png" border="0" align="top" /></a>
                    <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
    </form>
</body>
</html>
