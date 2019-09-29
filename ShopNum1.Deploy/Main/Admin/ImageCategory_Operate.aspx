<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ImageCategory_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ImageCategory_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>����ͼƬ����</title>
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
                    <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="����ͼƬ����"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px;">
                            <asp:Label ID="LabelName" runat="server" Text="�������ƣ�"></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="���������벻Ҫ����50���ַ�"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelFatherID" runat="server" Text="���ࣺ"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListFatherID" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                            <span>�̳��������ࡣ</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            �Ƿ�ǰ̨��ʾ��
                        </th>
                        <td>
                            <input id="Checkbox1" type="checkbox" /><span>�Ƿ���ǰ̨��ʾ��</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" style="border-bottom: none; height: 115px;">
                            <asp:Label ID="LabelDescription" runat="server" Text="����������"></asp:Label>
                        </th>
                        <td style="border-bottom: none; height: 115px;">
                            <asp:TextBox ID="TextBoxDescription" runat="server" CssClass="tinput txtarea" TextMode="MultiLine"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorDescription" runat="server"
                                ControlToValidate="TextBoxDescription" Display="Dynamic" ErrorMessage="֧����ʽ���150���ַ�"
                                ValidationExpression="^[\s\S]{0,150}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="ȷ��"
                    ToolTip="Submit" CssClass="fanh" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
    </form>
</body>
</html>
