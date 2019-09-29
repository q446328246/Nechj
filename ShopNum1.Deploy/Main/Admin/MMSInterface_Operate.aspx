<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="MMSInterface_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.MMSInterface_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>���Žӿ�����</title>
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
                    <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="���Žӿ�����"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="LabelName" runat="server" Text="���ͷ�ʽ��"></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:DropDownList ID="DropDownListType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListType_SelectedIndexChanged"
                                Width="160" CssClass="tselect">
                                <asp:ListItem Text="-��ѡ��-" Value="-1"></asp:ListItem>
                                <%--   <asp:ListItem Text="������Žӿ�" Value="1"></asp:ListItem>
                                <asp:ListItem Text="���������Žӿ�" Value="2"></asp:ListItem>--%>
                                <asp:ListItem Text="���ű����Žӿ�" Value="3"></asp:ListItem>
                                <%--<asp:ListItem Text="������ʹ" Value="4" ></asp:ListItem>--%>
                            </asp:DropDownList>
                            <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:CompareValidator ID="CompareFatherCateGory" runat="server" ControlToValidate="DropDownListType"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1">
                            </asp:CompareValidator>
                        </td>
                    </tr>
                    <asp:Panel ID="PanelType" runat="server" Visible="false">
                        <tr>
                            <th align="right">
                                <asp:Label ID="Label3" runat="server" Text="��ҵ���룺"></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxCode" runat="server" Style="width: 150px;"></asp:TextBox>
                                <asp:Label ID="Label7" runat="server" Text="*" ForeColor="red"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxCode"
                                    Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxCode"
                                    Display="Dynamic" ErrorMessage="���50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label4" runat="server" Text="�û�����"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxName" runat="server" Style="width: 150px;" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label5" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="���50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label6" runat="server" Text="�˺����룺"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxPwd" runat="server" Style="width: 150px;" CssClass="tinput"
                                TextMode="Password"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxPwd"
                                Display="Dynamic" ErrorMessage="���50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            �����ֻ��ţ�
                        </th>
                        <td>
                            <asp:TextBox ID="txtTel" runat="server" Style="width: 150px;" CssClass="tinput"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                ID="butTest" runat="server" Text="���Է���" ToolTip="Submit" CssClass="fanh" OnClick="butTest_Click" />(����ǰ���ȱ�����ȷ������)
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            �������ݣ�
                        </th>
                        <td>
                            <asp:TextBox ID="txtRc" runat="server" Style="width: 150px;" CssClass="tinput" Text="[�人�ƽ�����]"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="��������" ToolTip="Submit" CssClass="fanh"
                    OnClick="ButtonConfirm_Click" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
