<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="PageAdID_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.PageAdID_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��ӹ��λ</title>
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
                    <asp:Label ID="lbltitle" runat="server" Text="��ӹ��λ"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            ҳ������
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxPageName" CssClass="tinput" runat="server" ReadOnly="true"></asp:TextBox>
                            <span class="red" style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPageName" ControlToValidate="TextBoxPageName"
                                runat="server" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorDescription" runat="server"
                                ControlToValidate="TextBoxPageName" Display="Dynamic" ErrorMessage="�벻Ҫ����150���ַ�"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            �ļ�����
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListFileName" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                            <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:CompareValidator ID="CompareFatherCateGory" runat="server" ControlToValidate="DropDownListFileName"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ���λID��
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAdID" CssClass="tinput" runat="server" ReadOnly="true"></asp:TextBox><span></span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            �߶ȣ�
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxHeight" CssClass="tinput" runat="server"></asp:TextBox><span>
                                ���ĸ߶�</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            ��ȣ�
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxWidth" CssClass="tinput" runat="server"></asp:TextBox><span>
                                ���Ŀ��</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ˵����
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxContent" runat="server" CssClass="tinput txtarea" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" CssClass="fanh" OnClick="ButtonConfirm_Click" />
                <asp:Button ID="ButtonBack" runat="server" Text="�����б�" CssClass="fanh" CausesValidation="false"
                    OnClick="ButtonBack_Click" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldADCount" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldADGuid" runat="server" Value="0" />
    </form>
</body>
</html>
