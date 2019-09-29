<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CouponType_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.CouponType_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�����Ż�ȯ����</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="�����Ż�ȯ����"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table border="0" cellpadding="0" cellspacing="0" class="shoptable">
                <tr>
                    <th align="right" width="150px">
                        <div class="shopth">
                            <asp:Label ID="LabelName" runat="server" Text="�������ƣ�"></asp:Label>
                        </div>
                    </th>
                    <td valign="middle">
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput" MaxLength="20"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle" runat="server"
                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="�������20���ַ�" ValidationExpression="^[\s\S]{0,20}$"></asp:RegularExpressionValidator>
                        </div>
                    </td>
                </tr>
                <%--<tr>
                    <th align="right">
                        <div class="shopth">
                            ����ؼ��֣�
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <input type="text" name="txt" class="tinput" /><span>�̳����õĹؼ��֣�����SEO�Ż���</span>
                        </div>
                    </td>
                </tr>--%>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelOrderID" runat="server" Text="��������"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxOrderID" MaxLength="9" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label4" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorOrderID" runat="server"
                                ControlToValidate="TextBoxOrderID" Display="Dynamic" ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderID" runat="server" ControlToValidate="TextBoxOrderID"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelIsShow" runat="server" Text="�Ƿ���ʾ��"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:CheckBox ID="CheckBoxIsShow" runat="server" Checked="True" /><span>�Ƿ���ʾ��</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth" style="border-bottom: none; height: 115px;">
                            <asp:Label ID="LabelDescription" runat="server" Text="����������"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd" style="border-bottom: none; height: 115px;">
                            <asp:TextBox ID="TextBoxDescription" runat="server" CssClass="tinput txtarea" TextMode="MultiLine"
                                MaxLength="50"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle1" runat="server"
                                ControlToValidate="TextBoxDescription" Display="Dynamic" ErrorMessage="�������50���ַ�"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="ȷ��"
                    ToolTip="Submit" CssClass="fanh" />
                <asp:Button ID="Button3" runat="server" CssClass="fanh" CausesValidation="false"
                    PostBackUrl="~/Main/Admin/CouponType_List.aspx" Text="�����б�" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
