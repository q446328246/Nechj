<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopNum1_SupplyDemandCategory_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopNum1_SupplyDemandCategory_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��ӹ������</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelTitle" runat="server" Text="��ӹ������"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Localize ID="Localize1" runat="server" Text="����������ƣ�"></asp:Localize>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="��������������50���ַ�"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeFatherCateGory" runat="server" Text="�ϼ����ࣺ"></asp:Localize>
                        </th>
                        <td>
                            <asp:DropDownList CssClass="tselect" ID="DropDownListFatherCateGory" runat="server">
                            </asp:DropDownList>
                            <span>�����������ࡣ</span>
                            <asp:CompareValidator ID="CompareFatherCateGory" runat="server" ControlToValidate="DropDownListFatherCateGory"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize2" runat="server" Text="�������ؼ��֣�"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxKeywords" runat="server" CssClass="tinput"></asp:TextBox><span>
                                ����������õĹؼ��֣�����SEO�Ż���</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorKeywords" runat="server"
                                ControlToValidate="TextBoxKeywords" Display="Dynamic" ErrorMessage="����ؼ������200���ַ�"
                                ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize4" runat="server" Text="�����������"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOrderID" MaxLength="9" runat="server" CssClass="tinput"></asp:TextBox><span>
                                (�Զ�����)</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxOrderID" runat="server"
                                ControlToValidate="TextBoxOrderID" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryOrderID" runat="server"
                                ControlToValidate="TextBoxOrderID" ErrorMessage="����������" ValidationExpression="^[0-9]*$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize5" runat="server" Text="�Ƿ�ǰ̨��ʾ��"></asp:Localize>
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsShow" runat="server" Checked="True" Text="��" /><span>��������Ƿ���ǰ̨��ʾ��</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize3" runat="server" Text="�������������"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDescription" runat="server" TextMode="MultiLine" CssClass="tinput txtarea"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorDescription" runat="server"
                                ControlToValidate="TextBoxDescription" Display="Dynamic" ErrorMessage="��������������200���ַ�"
                                ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" CssClass="fanh" OnClick="ButtonConfirm_Click"
                    ToolTip="Submit" />
                <asp:Button ID="ButtonBack" runat="server" CssClass="fanh" PostBackUrl="~/Main/Admin/ShopNum1_SupplyDemandCategory_List.aspx"
                    Text="�����б�" CausesValidation="False" />
                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
