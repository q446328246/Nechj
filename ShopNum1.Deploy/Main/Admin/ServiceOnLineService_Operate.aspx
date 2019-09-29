<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ServiceOnLineService_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ServiceOnLineService_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="t" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>���߿ͷ����</title>
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
                    <asp:Label ID="LabelTitle" runat="server" Text="���߿ͷ����"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Localize ID="LocalizeType" runat="server" Text="���߿ͷ����ͣ�"></asp:Localize>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListType" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                            <asp:Label ID="Label1" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:CompareValidator ID="CompareDropDownListType" runat="server" ControlToValidate="DropDownListType"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeName" runat="server" Text="���߿ͷ����ƣ�"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxName" runat="server"
                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxName" runat="server"
                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="���50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeServiceAccount" runat="server" Text="���߿ͷ��˺ţ�"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxServiceAccount" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxServiceAccount" runat="server"
                                ControlToValidate="TextBoxServiceAccount" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxServiceAccount"
                                runat="server" ControlToValidate="TextBoxServiceAccount" Display="Dynamic" ErrorMessage="���25���ַ�"
                                ValidationExpression="^[\s\S]{0,25}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeOrderID" runat="server" Text="����ţ�"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOrderID" MaxLength="9" runat="server" CssClass="tinput"></asp:TextBox><span>(�Զ�����)</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxOrderID" runat="server"
                                ControlToValidate="TextBoxOrderID" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxOrderID" runat="server"
                                ControlToValidate="TextBoxOrderID" Display="Dynamic" ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize5" runat="server" Text="�Ƿ�ǰ̨��ʾ��"></asp:Localize>
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsShow" runat="server" Checked="True" Text="��" /><span> �Ƿ�ǰ̨��ʾ��</span>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" CssClass="qued" OnClick="ButtonConfirm_Click"
                    ToolTip="Submit" />
                <asp:Button ID="ButtonBack" runat="server" CssClass="fanh" CausesValidation="false"
                    PostBackUrl="ServiceOnLineService_List.aspx" Text="�����б�" /><t:MessageShow
                        ID="MessageShow" Visible="false" runat="server" />
                <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
