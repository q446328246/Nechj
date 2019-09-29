<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="KeyWords_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.KeyWords_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�����ؼ���</title>
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="�����ؼ���"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table border="0" cellpadding="0" cellspacing="0" class="shoptable">
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelKeyWords" runat="server" Text="�ؼ��֣�"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxKeyWords" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:Label ID="Label5" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorKeyWords" runat="server" ControlToValidate="TextBoxKeyWords"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorKeyWords" runat="server"
                                ControlToValidate="TextBoxKeyWords" Display="Dynamic" ErrorMessage="�������50���ַ�"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelCount" runat="server" Text="����������"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxCount" MaxLength="9" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label8" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCount" runat="server" ControlToValidate="TextBoxCount"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorCount" runat="server"
                                ControlToValidate="TextBoxCount" Display="Dynamic" ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelType" runat="server" Text="���ͣ�"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListType" runat="server" CssClass="tselect">
                                <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                <asp:ListItem Value="1">��Ʒ</asp:ListItem>
                                <%-- <asp:ListItem Value="2">����</asp:ListItem>
                                <asp:ListItem Value="3">��Ѷ</asp:ListItem>
                                <asp:ListItem Value="4">����</asp:ListItem>
                                <asp:ListItem Value="5">����</asp:ListItem>--%>
                            </asp:DropDownList>
                            <asp:Label ID="Label6" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:CompareValidator ID="CompareValidatorType" runat="server" ControlToValidate="DropDownListType"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelIfShow" runat="server" Text="ǰ̨�Ƿ���ʾ��"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListIfShow" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                            <asp:Label ID="Label7" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:CompareValidator ID="CompareValidatorIfShow" runat="server" ControlToValidate="DropDownListIfShow"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth" style="border-bottom: none; height: 115px;">
                            ������
                        </div>
                    </th>
                    <td>
                        <div class="shoptd" style="border-bottom: none; height: 115px;">
                            <input type="text" name="txt" class="tinput txtarea" />
                        </div>
                    </td>
                </tr>
            </table>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" OnClick="ButtonConfirm_Click"
                    ToolTip="Submit" CssClass="fanh" />
                <asp:Button ID="ButtonBack" runat="server" Text="�����б�" CssClass="fanh" PostBackUrl="~/Main/Admin/KeyWords_Manage.aspx"
                    CausesValidation="false" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldAgentID" runat="server" />
    </form>
</body>
</html>
