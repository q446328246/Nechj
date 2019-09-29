<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="TbSendGood.aspx.cs" Inherits="ShopNum1.Deploy.Shop.ShopAdmin.TbTop.TbSendGood" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <link rel="stylesheet" type="text/css" href="style/tbindex.css" />
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="navigator">
                <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="���ջ���Ϣ��"></asp:Label>
            </div>
            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                <tr>
                    <td align="right" width="20%">
                        <asp:Label ID="LabelName" runat="server" Text="��ϵ�ˣ�"></asp:Label>
                    </td>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="TextBoxeller_name" runat="server"></asp:TextBox>
                        <asp:Label ID="Label3" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxeller_name"
                                                    Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                                                        ControlToValidate="TextBoxeller_name" Display="Dynamic" ErrorMessage="�������50���ַ�"
                                                        ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="20%">
                        ������
                    </td>
                    <td colspan="2">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlProvince" runat="server" Height="25px" AutoPostBack="true"
                                                  OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlCity" runat="server" Height="25px">
                                </asp:DropDownList>
                                <span style="color: Red;">*</span>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlProvince" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="20%">
                        <asp:Label ID="Labelseller_address" runat="server" Text="�ֵ���ַ��"></asp:Label>
                    </td>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="TextBoxseller_address" runat="server" TextMode="MultiLine" Width="300"></asp:TextBox>
                        <asp:Label ID="Label2" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxseller_address"
                                                    Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxseller_address"
                                                        Display="Dynamic" ErrorMessage="�ֵ���ַ���150���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="20%">
                        <asp:Label ID="Labelseller_zip" runat="server" Text="�������룺"></asp:Label>
                    </td>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="TextBoxseller_zip" runat="server"></asp:TextBox>
                        <asp:Label ID="Label5" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxseller_zip"
                                                    Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxseller_zip"
                                                        Display="Dynamic" ErrorMessage="�����������50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="20%">
                        <asp:Label ID="Label6" runat="server" Text="�绰���룺"></asp:Label>
                    </td>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="TextBoxseller_phone" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="20%">
                        <asp:Label ID="Label7" runat="server" Text="�ֻ����룺"></asp:Label>
                    </td>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="TextBoxseller_mobile" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxseller_mobile"
                                                        Display="Dynamic" ErrorMessage="�ֻ��������50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            <div class="btconfig">
                <asp:Button ID="ButtonUpdate" runat="server" Text="����" OnClick="ButtonUpdate_Click"
                            CssClass="bt2" />
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="navigator">
                        <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="��ѡ����������"></asp:Label>
                    </div>
                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                        <tr id="nn" runat="server">
                            <td align="right" width="20%">
                                <asp:Label ID="Label11" runat="server" Text="������˾��"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListcompany_code" runat="server">
                                    <asp:ListItem>��ѡ��һ��������˾</asp:ListItem>
                                    <asp:ListItem>EMS</asp:ListItem>
                                    <asp:ListItem>Բͨ���</asp:ListItem>
                                    <asp:ListItem>��ͨ�ٵ�</asp:ListItem>
                                    <asp:ListItem>լ����</asp:ListItem>
                                    <asp:ListItem>�ϴ����</asp:ListItem>
                                    <asp:ListItem>������</asp:ListItem>
                                    <asp:ListItem>һ���ٵ�</asp:ListItem>
                                    <asp:ListItem>�°�����</asp:ListItem>
                                    <asp:ListItem>�ǳ�����</asp:ListItem>
                                    <asp:ListItem>��������</asp:ListItem>
                                    <asp:ListItem>��ͨ����</asp:ListItem>
                                    <asp:ListItem>������</asp:ListItem>
                                    <asp:ListItem>˳������</asp:ListItem>
                                    <asp:ListItem>CCES</asp:ListItem>
                                    <asp:ListItem>��ͨE����</asp:ListItem>
                                    <asp:ListItem>�����ܴ�</asp:ListItem>
                                    <asp:ListItem>����ƽ��</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                <asp:Label ID="Label12" runat="server" Text="������ʽ��"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RadioButtonorder_type" AutoPostBack="true" runat="server"
                                                     RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonorder_type_SelectedIndexChanged">
                                    <asp:ListItem Text="��ʱ����" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="�����µ�" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="�Լ���ϵ����" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="��������" Value="3"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr id="Tr1" visible="false" runat="server">
                            <td align="right" width="20%">
                                <asp:Label ID="Label18" runat="server" Text="��ʱ��ʽ��"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RadioButtonList1" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Value="0">�γ���</asp:ListItem>
                                    <asp:ListItem Value="1" Selected="True">���մ�</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr id="date" runat="server">
                            <td align="right" width="20%">
                                <asp:Label ID="Label13" runat="server" Text="ԤԼ���ڣ�"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="dateTime" runat="server">
                            <td align="right" width="20%">
                                <asp:Label ID="Label14" runat="server" Text="ԤԼʱ�Σ�"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                    <asp:ListItem>8.00</asp:ListItem>
                                    <asp:ListItem>8.30</asp:ListItem>
                                    <asp:ListItem>9.00</asp:ListItem>
                                    <asp:ListItem>9.30</asp:ListItem>
                                    <asp:ListItem>10.00</asp:ListItem>
                                    <asp:ListItem>10.30</asp:ListItem>
                                    <asp:ListItem>11.00</asp:ListItem>
                                    <asp:ListItem>11.30</asp:ListItem>
                                    <asp:ListItem>12.00</asp:ListItem>
                                    <asp:ListItem>12.30</asp:ListItem>
                                    <asp:ListItem>13.00</asp:ListItem>
                                    <asp:ListItem>13.30</asp:ListItem>
                                    <asp:ListItem>14.00</asp:ListItem>
                                    <asp:ListItem>14.30</asp:ListItem>
                                    <asp:ListItem>15.00</asp:ListItem>
                                    <asp:ListItem>15.30</asp:ListItem>
                                    <asp:ListItem>16.00</asp:ListItem>
                                    <asp:ListItem>16.30</asp:ListItem>
                                    <asp:ListItem>17.00</asp:ListItem>
                                    <asp:ListItem>17.30</asp:ListItem>
                                    <asp:ListItem>18.00</asp:ListItem>
                                    <asp:ListItem>19.30</asp:ListItem>
                                    <asp:ListItem>20.00</asp:ListItem>
                                    <asp:ListItem>20.30</asp:ListItem>
                                </asp:DropDownList>
                                ��
                                <asp:DropDownList ID="DropDownList3" runat="server">
                                    <asp:ListItem>8.00</asp:ListItem>
                                    <asp:ListItem>8.30</asp:ListItem>
                                    <asp:ListItem>9.00</asp:ListItem>
                                    <asp:ListItem>9.30</asp:ListItem>
                                    <asp:ListItem>10.00</asp:ListItem>
                                    <asp:ListItem>10.30</asp:ListItem>
                                    <asp:ListItem>11.00</asp:ListItem>
                                    <asp:ListItem>11.30</asp:ListItem>
                                    <asp:ListItem>12.00</asp:ListItem>
                                    <asp:ListItem>12.30</asp:ListItem>
                                    <asp:ListItem>13.00</asp:ListItem>
                                    <asp:ListItem>13.30</asp:ListItem>
                                    <asp:ListItem>14.00</asp:ListItem>
                                    <asp:ListItem>14.30</asp:ListItem>
                                    <asp:ListItem>15.00</asp:ListItem>
                                    <asp:ListItem>15.30</asp:ListItem>
                                    <asp:ListItem Selected="True">16.00</asp:ListItem>
                                    <asp:ListItem>16.30</asp:ListItem>
                                    <asp:ListItem>17.00</asp:ListItem>
                                    <asp:ListItem>17.30</asp:ListItem>
                                    <asp:ListItem>18.00</asp:ListItem>
                                    <asp:ListItem>19.30</asp:ListItem>
                                    <asp:ListItem>20.00</asp:ListItem>
                                    <asp:ListItem>20.30</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="Panel1" runat="server">
                        <div class="navigator">
                            <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="��ȷ���ջ���Ϣ����д�˵��š�"></asp:Label>
                        </div>
                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                            <tr id="mm" runat="server" visible="false">
                                <td align="right" width="20%">
                                    <asp:Label ID="Label17" runat="server" Text="������˾��"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="20%">
                                    <asp:Label ID="Label16" runat="server" Text="�˵����룺"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxout_sid" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="btconfig">
                <asp:Button ID="btnOK" runat="server" Text="ȷ��" OnClick="btnOK_Click" CssClass="bt2" />
                <asp:Button ID="btnCancel" runat="server" Text="���ض����б�" CssClass="bt2" OnClick="btnCancel_Click"
                            CausesValidation="false" />
            </div>
            <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
        </form>
    </body>
</html>