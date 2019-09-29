<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="SiteMota_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.SiteMota_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SEO����</title>
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="SEO����"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="Label1" runat="server" Text="ҳ������"></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxPageName" runat="server" class="tinput"></asp:TextBox>
                            <span style="color: red">*</span> <span>ҳ������</span>
                            <asp:RequiredFieldValidator ID="Re1" ControlToValidate="TextBoxPageName" runat="server"
                                ErrorMessage="ҳ�����Ʋ���Ϊ�գ�"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label2" runat="server" Text="Title(����)��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxFileName" runat="server" class="tinput"></asp:TextBox>
                            <span style="color: red">*</span> <span>һ�㲻����80���ַ������ղ����Ĭ�ϵ���ϵͳĬ�ϵ�ҳ����⡣</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBoxFileName"
                                runat="server" ErrorMessage="����Ʋ���Ϊ�գ�"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label3" runat="server" Text="Meta_Keywords(�ؼ���)��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDivID" runat="server" class="tinput"></asp:TextBox>
                            <span style="color: red">*</span> <span>һ�㲻����100���֣����ղ����Ĭ�ϵ���ϵͳĬ��ҳ��ؼ���,�ؼ���֮����Ӣ�Ķ��Ÿ�����</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBoxDivID"
                                runat="server" ErrorMessage="�ؼ��ʲ���Ϊ�գ�"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label4" runat="server" Text="Meta_Description(����)��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxExplain" runat="server" CssClass="tinput txtarea" TextMode="MultiLine"></asp:TextBox>
                            <span style="color: red">*</span> <span>һ�㲻����200���ַ������ղ����Ĭ�ϵ���ϵͳȫ��ҳ��������</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TextBoxExplain"
                                runat="server" ErrorMessage="��������Ϊ�գ�"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" CssClass="fanh" OnClick="ButtonConfirm_Click" />
                <asp:Button ID="ButtonBack" CausesValidation="false" runat="server" Text="�����б�" CssClass="fanh"
                    OnClick="ButtonBack_Click" ValidationGroup="fh" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
