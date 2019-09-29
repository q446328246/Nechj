<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="LogisticsCompany_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.LogisticsCompany_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>【添加物流公司】</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth" style="display: none">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelTitle" runat="server" Text="添加物流公司"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px;">
                            <asp:Localize ID="LocalizeName" runat="server" Text="物流公司名称："></asp:Localize>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxName" runat="server"
                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxName" runat="server"
                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localizereplacement" runat="server" Text="物流公司代码："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxValueCode" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxValueCode"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxValueCode"
                                Display="Dynamic" ErrorMessage="最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize2" runat="server" Text="是否显示："></asp:Localize>
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsShow" Checked="true" runat="server" /><span>是否在前台显示。</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" style="border-bottom: none; height: 115px;">
                            <asp:Localize ID="Localize1" runat="server" Text="备注："></asp:Localize>
                        </th>
                        <td style="border-bottom: none; height: 115px;">
                            <asp:TextBox ID="TextBoxContent" TextMode="MultiLine" runat="server" CssClass="tinput txtarea"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxContent"
                                Display="Dynamic" ErrorMessage="最多500个字符" ValidationExpression="^[\s\S]{0,500}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="确定" CssClass="fanh" OnClick="ButtonConfirm_Click"
                    ToolTip="" />
                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
                <asp:HiddenField ID="HiddenFieldCode" Value="0" runat="server" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
