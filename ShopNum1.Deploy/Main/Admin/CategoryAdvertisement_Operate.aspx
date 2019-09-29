<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CategoryAdvertisement_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.CategoryAdvertisement_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��ӷ�����</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type="text/javascript">

        //ѡ��ͼ
        function openSingleChild1() {
            var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
            if (k != null) {
                var imgvalue = new Array();
                imgvalue = k.split(",");
                var strLen = k.length;
                var lastIndex = k.lastIndexOf('/');
                document.getElementById("TextBoxAdNowPic").value = k.substring(lastIndex + 1, strLen);
                document.getElementById("ImageOriginalImge1").src = imgvalue[1];
            }
        }


        function openSingleChild2() {
            var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
            if (k != null) {
                var imgvalue = new Array();
                imgvalue = k.split(",");
                var strLen = k.length;
                var lastIndex = k.lastIndexOf('/');
                document.getElementById("TextBoxDefaultPic").value = k.substring(lastIndex + 1, strLen);
                document.getElementById("ImageOriginalImge2").src = imgvalue[1];
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="��ӷ�����"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            ������ƣ�
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxPageName" runat="server" CssClass="tinput"></asp:TextBox><span
                                style="color: Red">*</span><span>����Ϊ��</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxOrderID" runat="server"
                                ControlToValidate="TextBoxPageName" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ���λ��
                        </th>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DropDownListAdPageName" AutoPostBack="true" runat="server"
                                        Width="140px" OnSelectedIndexChanged="DropDownListAdPageName_SelectedIndexChanged"
                                        CssClass="tselect">
                                        <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                        <asp:ListItem Value="1">��Ʒ����</asp:ListItem>
                                        <asp:ListItem Value="2">������Ϣ����</asp:ListItem>
                                        <asp:ListItem Value="3">�������</asp:ListItem>
                                        <asp:ListItem Value="4">���̷���</asp:ListItem>
                                        <asp:ListItem Value="5">��Ѷ����</asp:ListItem>
                                        <asp:ListItem Value="6">Ʒ�Ʒ���</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListAdID" AutoPostBack="true" runat="server" Width="140px"
                                        OnSelectedIndexChanged="DropDownListAdID_SelectedIndexChanged" CssClass="tselect">
                                        <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                    </asp:DropDownList>
                                    <span style="color: Red">*</span>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="DropDownListAdID"
                                        Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ���λID��
                        </th>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="TextBoxCategoryAdID" ReadOnly="true" runat="server" CssClass="tinput"></asp:TextBox>
                                    <span style="color: Red">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxCategoryAdID" runat="server"
                                        ControlToValidate="TextBoxCategoryAdID" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            �����ࣺ
                        </th>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DropDownListCategory1" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownListCategory1_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListCategory2" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownListCategory2_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListCategory3" runat="server">
                                        <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                    </asp:DropDownList>
                                    <span style="color: Red">*</span> <span style="color: Red">������ѡ����λ��</span>
                                    <asp:CompareValidator ID="CompareDdl" runat="server" ControlToValidate="DropDownListCategory1"
                                        Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ���Ĭ��ͼƬ��
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDefaultPic" CssClass="tinput" runat="server"></asp:TextBox>
                            <input id="Button1" class="selpic" type="button" value="ѡ��ͼƬ" onclick=" openSingleChild2() " /><asp:RegularExpressionValidator
                                ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxDefaultPic"
                                Display="Dynamic" ErrorMessage="���250���ַ�" ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxDefaultPic"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <img id="ImageOriginalImge2" alt="" src="" runat="server" width="20" height="20" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ���Ĭ�����ӵ�ַ��
                        </th>
                        <td>
                            <ShopNum1:TextBox ID="TextBoxDefaultLikeAddress" RequiredFieldType="��ҳ��ַ" MaxLength="200"
                                CssClass="tinput" runat="server"></ShopNum1:TextBox><span> ����������</span>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxDefaultLikeAddress"
                    Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ���۸�
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAdPrice" MaxLength="9" CssClass="tinput" runat="server"></asp:TextBox><span>
                                ����۸�</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxAdPrice"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertory" runat="server"
                                ControlToValidate="TextBoxAdPrice" ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ���������
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAdvertisementflow" MaxLength="9" CssClass="tinput" runat="server"></asp:TextBox>
                            /��
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxAdvertisementflow"
                                ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxAdvertisementflow"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            �����⣺
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAdIntroduce" MaxLength="50" CssClass="tinput" runat="server"></asp:TextBox><span>
                                ���������</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            �Ƿ���ʾ��
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsShow" Checked="true" runat="server" /><span> �Ƿ�ǰ̨��ʾ��</span>
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
    <asp:HiddenField ID="HiddenFieldCategoryCode" runat="server" Value="-1" />
    </form>
</body>
</html>
