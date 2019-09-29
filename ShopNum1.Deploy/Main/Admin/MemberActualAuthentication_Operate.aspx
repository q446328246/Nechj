<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="MemberActualAuthentication_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.MemberActualAuthentication_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��Աʵ���б�</title>
    <link type="text/css" rel="Stylesheet" href="style/css.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="������Աʵ����֤"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table cellpadding="0" cellspacing="1" border="0">
                    <tr>
                        <th align="right">
                            ��Ա��¼���� </td>
                            <td align="left">
                                <asp:TextBox ID="TextBoxName" ReadOnly="true" CssClass="allinput3" runat="server"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ��Ա��ʵ������ </td>
                            <td align="left">
                                <asp:TextBox ID="TextBoxRealName" ReadOnly="true" CssClass="allinput3" runat="server"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <th align="right" width="20%">
                            ��Ա���֤�ţ� </td>
                            <td align="left">
                                <asp:TextBox ID="TextBoxCardNum" ReadOnly="true" CssClass="allinput3" runat="server"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ����ʱ�䣺 </td>
                            <td align="left">
                                <asp:TextBox ID="TextBoxTime" ReadOnly="true" CssClass="allinput3" runat="server"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ���֤lͼƬ(����)�� </td>
                            <td align="left">
                                <asp:Image ID="ImageIdentityCard" runat="server" />
                            </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ���֤lͼƬ(����)�� </td>
                            <td align="left">
                                <asp:Image ID="ImageIdentityCardBack" runat="server" />
                            </td>
                    </tr>
                    <tr id="trID" runat="server">
                        <th align="right">
                            <asp:Label ID="LabelAuditStatus" runat="server" Text="���״̬��"></asp:Label>
                        </th>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListAuditStatus" runat="server" AutoPostBack="true"
                                Width="180px">
                                <asp:ListItem Value="2">���δͨ��</asp:ListItem>
                                <asp:ListItem Value="1">�����ͨ��</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <%-- <tr>
            <th>
                ���״̬
            </th>
            <td><%=strstate%></td>
        </tr>--%>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelAuditFailedReason" runat="server" Text="������ɣ�"></asp:Label>
                        </th>
                        <td align="left">
                            <textarea id="TextBoxAuditFailedReason" runat="server" style="height: 100px; width: 500px;"
                                class="allinput1"></textarea>
                            <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxAuditFailedReason" ValidationGroup="ConfiirmButton"
                                ControlToValidate="TextBoxAuditFailedReason" runat="server" ErrorMessage="�������"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxAuditFailedReason"
                                runat="server" ControlToValidate="TextBoxAuditFailedReason" ValidationGroup="ConfiirmButton"
                                Display="Dynamic" ErrorMessage="��ע���250���ַ�" ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
                <div class="vote" style="margin: 15px 42px; margin-left: 250px; padding-left: 2px;">
                    <asp:Button ID="ButtonConfiirm" runat="server" ValidationGroup="ConfiirmButton" Text="ȷ��"
                        CssClass="fanh" OnClick="ButtonConfiirm_Click" />
                    <input id="inputReset" runat="server" type="reset" value="����" cssclass="fanh" visible="false" />
                    <asp:Button ID="ButtonBank" runat="server" Text="�����б�" CssClass="fanh" OnClick="ButtonBank_Click" />
                    <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
