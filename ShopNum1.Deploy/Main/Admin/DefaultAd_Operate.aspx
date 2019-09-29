<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="DefaultAd_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.DefaultAd_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��ҳ�õ�ƬͼƬ</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type="text/javascript">
        //ѡ��ͼ
        function openLogoSingleChild() {
            var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
            if (k != null) {
                var strLen = k.length;
                var lastIndex = k.lastIndexOf('/');
                document.getElementById("TextBoxpath").value = "/ImgUpload/" + k.substring(lastIndex + 1, strLen);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="��ӻõ�ƬͼƬ"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            ͼƬ���ƣ�
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxExplain" CssClass="tinput" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxExplain" runat="server"
                                ControlToValidate="TextBoxExplain" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorDescription" runat="server"
                                ControlToValidate="TextBoxExplain" Display="Dynamic" ErrorMessage="�벻Ҫ����50���ַ�"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ͼƬ��ַ���ͣ�
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListPathType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPathType_SelectedIndexChanged"
                                CssClass="tselect">
                                <asp:ListItem Value="0">·��</asp:ListItem>
                                <asp:ListItem Value="1">�ϴ�</asp:ListItem>
                            </asp:DropDownList>
                            <span>ͼƬ�������ࡣ</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ���ӵ�ַ��
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxHref" CssClass="tinput" runat="server"></asp:TextBox><span>
                                �������ӵ�ַ</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ͼƬ��ַ��
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxpath" runat="server" Visible="true" CssClass="tinput"></asp:TextBox>
                            <asp:FileUpload ID="FileUploadpath" runat="server" Visible="false" />
                            <input id="ButtonSelectSingleImage" runat="server" type="button" value="����ͼƬ" visible="true"
                                onclick="openLogoSingleChild()" class="selpic" style="position: relative; top: 1px;
                                top: 0px\9; *top: -1px; _top: -1px;" />
                        </td>
                    </tr>
                    <tr id="adheight" runat="server">
                        <th align="right">
                            �߶ȣ�
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxHeight" CssClass="tinput" runat="server"></asp:TextBox><span>
                                ����߶�</span>
                        </td>
                    </tr>
                    <tr id="adwidth" runat="server">
                        <th align="right">
                            ��ȣ�
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxWidth" CssClass="tinput" runat="server"></asp:TextBox><span>
                                ������</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ����ţ�
                        </th>
                        <td>
                            <asp:TextBox CssClass="tinput" MaxLength="9" ID="TextBoxLocation" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxLocation" runat="server"
                                ControlToValidate="TextBoxLocation" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxLocation"
                                runat="server" ControlToValidate="TextBoxLocation" ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
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
    </form>
</body>
</html>
