<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopEnsure_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopEnsure_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>���̵�������</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
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
                    <asp:Label ID="Label_Oprate" runat="server" Text="�������̵���"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="Label2" runat="server" Text="�������ƣ�"></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxName" CssClass="tinput" runat="server"></asp:TextBox>
                            <font color="red"><span style="color: Red">*</span></font>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle" runat="server"
                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="���50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label4" runat="server" Text="������ʶ��"></asp:Label>
                        </th>
                        <td>
                            <asp:FileUpload ID="FileUploadImage" runat="server" /><font color="red"> <span style="color: Red">
                                *</span></font>
                            <asp:Image ID="ImagePath" runat="server" />
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="Label5" runat="server" Text="���ӣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="textBoxhref" runat="server" CssClass="tinput" MaxLength="100"></asp:TextBox><span>���̵�������</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelSpec" runat="server" Text="������"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxEnsureMoney" CssClass="tinput" runat="server" MaxLength="7"
                                Width="100"></asp:TextBox>
                            <span>Ԫ</span> <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxEnsureMoney"
                                runat="server" ControlToValidate="TextBoxEnsureMoney" Display="Dynamic" ErrorMessage="�۸��ʽ����ȷ"
                                ValidationExpression="^[0-9]{1,7}(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxEnsureMoney" runat="server"
                                ControlToValidate="TextBoxEnsureMoney" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label1" runat="server" Text="��ע��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxRemark" CssClass="tinput txtarea" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="btnConfirm" runat="server" Text="ȷ��" OnClick="btnConfirm_Click" CssClass="fanh" />
                <asp:Button ID="Button3" runat="server" CssClass="fanh" CausesValidation="false"
                    PostBackUrl="~/Main/Admin/ShopEnsure_List.aspx" Text="�����б�" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
