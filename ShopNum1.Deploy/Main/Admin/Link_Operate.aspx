<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Link_Operate.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Link_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>������������</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        //ѡ��ͼ
        function openSingleChild() {
            var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
            if (k != null) {
                //          var strLen=k.length;
                //          var lastIndex=k.lastIndexOf('/');
                var strArray = k.split(",");
                // alert(strArray[0]);
                document.getElementById("textBoxImgAddress").value = strArray[0];
                //           k.substring(lastIndex+1,strLen); 
                document.getElementById("ImageOriginalImge").src = strArray[1];
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="������������"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="lblLinkType" runat="server" Text="�������ͣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropListLinkType" CssClass="tselect" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="DropListLinkType_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Label ID="Label1" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="lblTitle" runat="server">�������ƣ�</asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="textBoxTitle" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server"
                                ControlToValidate="textBoxTitle" ErrorMessage="����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorT" runat="server" ControlToValidate="textBoxTitle"
                                Display="Dynamic" ErrorMessage="�������50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="lblLinkAddress" runat="server" Text="���ӵ�ַ��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="textBoxLinkAddress" runat="server" CssClass="tinput">http://</asp:TextBox>
                            <asp:Label ID="Label3" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                            <asp:Label ID="Label11" runat="server" Text="����ʽ��http://...��"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                ControlToValidate="textBoxLinkAddress" ErrorMessage="����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="textBoxLinkAddress"
                                ErrorMessage="��ַ��ʽ����" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="lblOrderID" runat="server" Text="����ţ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="textBoxOrderID" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label6" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderID" runat="server" ControlToValidate="textBoxOrderID"
                                ErrorMessage="����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="textBoxOrderID"
                                ErrorMessage="ֻ��Ϊ����" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <asp:Panel ID="PanelPic" runat="server">
                        <tr>
                            <th align="right">
                                <asp:Label ID="lblIMGTYPE" runat="server" Text="ͼƬ���ͣ�"></asp:Label>
                            </th>
                            <td>
                                <asp:RadioButtonList ID="radioButtonImgType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="radioButtonIMGTYPE_SelectedIndexChanged"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Selected="True" Value="0">����ͼƬ</asp:ListItem>
                                    <asp:ListItem Value="1">Զ��ͼƬ</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="lblImgAddress" runat="server" Text="�����ϴ���"></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="textBoxImgAddress" runat="server" CssClass="tinput"></asp:TextBox><asp:Label
                                    ID="Label10" runat="server" Text="*" ForeColor="red"></asp:Label><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidatorImgAddress" runat="server" ControlToValidate="textBoxImgAddress"
                                        ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                                <asp:Panel ID="Panelimage" runat="server">
                                    <input id="ButtonSelectSingleImage" class="selpic" type="button" value="ѡ��ͼƬ" onclick=" openSingleChild() " /><img
                                        id="ImageOriginalImge" runat="server" alt="" src="" width="60" height="60" /></asp:Panel>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPackImagePath" runat="server"
                                    ControlToValidate="textBoxImgAddress" Display="Dynamic" ErrorMessage="·�����250���ַ�"
                                    ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <th align="right">
                            <asp:Label ID="lblDescription" runat="server" Text="վ����ܣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="textBoxDescription" runat="server" CssClass="tinput txtarea" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="lblIsShow" runat="server" Text="�Ƿ�ǰ̨��ʾ��"></asp:Label>
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsShow" runat="server" Checked="True" Text="��" /><span>�Ƿ���ǰ̨��ʾ��</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="lblRemark" runat="server" Text="��ע��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="textBoxMemo" runat="server" CssClass="tinput txtarea" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="BottonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="ȷ��"
                    CssClass="fanh" />
                <asp:Button ID="ButtonBack" runat="server" CssClass="fanh" PostBackUrl="~/Main/Admin/Link_Manage.aspx"
                    Text="�����б�" CausesValidation="False" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
