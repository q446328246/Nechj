<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="HelpType_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.HelpType_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="t" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��������</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="lbladd" runat="server" Text="��Ӱ�������"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Localize ID="LocalizeName" runat="server" Text="�����������ƣ�"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="���50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeOrderID" runat="server" Text="����ţ�"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOrderID" MaxLength="9" runat="server" CssClass="tinput"></asp:TextBox><span>
                                �Զ�����</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryOrderID" runat="server"
                                ControlToValidate="TextBoxOrderID" ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeDescription" runat="server" Text="����������ܣ�"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDescription" runat="server" CssClass="tinput txtarea" TextMode="MultiLine"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescription" runat="server"
                                ControlToValidate="TextBoxDescription" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorDescription" runat="server"
                                ControlToValidate="TextBoxDescription" Display="Dynamic" ErrorMessage="���250���ַ�"
                                ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" CssClass="fanh" OnClick="ButtonConfirm_Click" />
                <asp:Button ID="ButtonBack" runat="server" CssClass="fanh" PostBackUrl="~/Main/Admin/HelpType_List.aspx"
                    Text="�����б�" CausesValidation="False" />
                <t:MessageShow ID="MessageShow" Visible="false" runat="server" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="HiddenFieldAgentLoginID" runat="server" />
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
