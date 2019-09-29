<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CategoryAdID_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.CategoryAdID_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��ӷ�����λ</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type="text/javascript">

        //ѡ��ͼ
        function openSingleChild() {
            var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
            if (k != null) {
                var imgvalue = new Array();
                imgvalue = k.split(",");
                var strLen = k.length;
                var lastIndex = k.lastIndexOf('/');
                document.getElementById("TextBoxAdDefaultPic").value = k.substring(lastIndex + 1, strLen);
                document.getElementById("ImageOriginalImge").src = imgvalue[1];
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
                    ��ӷ�����λ</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            ���λ���ƣ�
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxAdName" CssClass="tinput" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxAdName" runat="server"
                                ControlToValidate="TextBoxAdName" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ҳ������
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListPageName" CssClass="tselect" runat="server">
                                <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                <asp:ListItem Value="1">��Ʒ����</asp:ListItem>
                                <asp:ListItem Value="2">������Ϣ����</asp:ListItem>
                                <asp:ListItem Value="3">�������</asp:ListItem>
                                <asp:ListItem Value="4">���̷���</asp:ListItem>
                                <asp:ListItem Value="5">��Ѷ����</asp:ListItem>
                                <asp:ListItem Value="6">Ʒ�Ʒ���</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                            <asp:CompareValidator ID="CompareDdl" runat="server" ControlToValidate="DropDownListPageName"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ���λ��ȣ�
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAdWidth" MaxLength="10000" CssClass="tinput" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span><span>px</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertory" runat="server"
                                ControlToValidate="TextBoxAdWidth" ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ���λ�߶ȣ�
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxHeight" CssClass="tinput" MaxLength="10000" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span><span>px</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxHeight"
                                ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ���λĬ��ͼƬ��
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAdDefaultPic" CssClass="tinput" runat="server"></asp:TextBox>
                            <input id="ButtonSelectSingleImage" class="selpic" type="button" value="ѡ��ͼƬ" onclick=" openSingleChild() " /><asp:RegularExpressionValidator
                                ID="RegularExpressionValidatorLogo" runat="server" ControlToValidate="TextBoxAdDefaultPic"
                                Display="Dynamic" ErrorMessage="���250���ַ�" ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                            <img id="ImageOriginalImge" alt="" src="" runat="server" width="20" height="20" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ���λĬ�����ӣ�
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDefaultLike" CssClass="tinput" runat="server"></asp:TextBox><span>�������</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxDefaultLike"
                                Display="Dynamic" ErrorMessage="���250���ַ�" ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td align="right">
                            ���λ������
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBoxCategoryAdflow" MaxLength="10000" CssClass="allinput1" runat="server">0</asp:TextBox>
                            <span style="color: Red">*</span>��ÿ�죩
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxCategoryAdflow"
                                ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td align="right">
                            ���λ����������
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBoxvisitPeople" CssClass="allinput1" MaxLength="10000" runat="server">0</asp:TextBox>
                            <span style="color: Red">*</span>��ÿ�죩
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBoxvisitPeople"
                                ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            �Ƿ���ʾ��
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsShow" Checked="true" runat="server" /><span>�Ƿ�ǰ̨��ʾ��</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ˵����
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAdIntroduce" runat="server" CssClass="tinput txtarea" TextMode="MultiLine"></asp:TextBox>
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
