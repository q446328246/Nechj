<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ControlData_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ControlData_Operate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>����ģ������</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type="text/javascript" language="javascript">
        //ѡ��ͼ
        function openSingleChild() {
            var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
            if (k != null) {
                var strLen = k.length;
                var lastIndex = k.lastIndexOf('/');
                document.getElementById("TextBoxControlImg").value = k.substring(lastIndex + 1, strLen);
                document.getElementById("ImgControlImg").src = k;
            }
        }
    </script>
    <script type="text/javascript" language="javascript">
        //ѡ��ͼ
        function openLogoSingleChild2() {
            var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
            if (k != null) {
                var strLen = k.length;
                var lastIndex = k.lastIndexOf('/');

                document.getElementById("TextBoxProductImg").value = k.substring(lastIndex + 1, strLen);
                document.getElementById("ImgProductImg").src = k;
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="����ģ������"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelTitle" runat="server" Text="�������ͣ�"></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:DropDownList ID="DropDownListDataType" CssClass="tselect" Width="184px" runat="server"
                                OnSelectedIndexChanged="DropDownListDataType_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="����" Value="1"></asp:ListItem>
                                <asp:ListItem Text="ͼƬ" Value="2"></asp:ListItem>
                                <asp:ListItem Text="��Ʒ" Value="3"></asp:ListItem>
                                <asp:ListItem Text="flash" Value="4"></asp:ListItem>
                                <asp:ListItem Text="������" Value="5"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label17" runat="server" Text="���⣺"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxTitle" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:Label ID="Label18" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxTitle"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label22" runat="server" Text="���ӣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxHref" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:Label ID="Label24" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBoxHref"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                ControlToValidate="TextBoxHref" Display="Dynamic" ErrorMessage="���250���ַ�" ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                            <asp:Label ID="LabelHref" runat="server" Text="��Ҫ http:// ǰ׺"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label2" runat="server" Text="����ţ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOrderID" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorContent" runat="server" ControlToValidate="TextBoxOrderID"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryOrderID" runat="server"
                                ControlToValidate="TextBoxOrderID" ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label19" runat="server" Text="�����飺"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxGroupID" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:Label ID="Label20" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBoxGroupID"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBoxGroupID"
                                ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <asp:Panel ID="PanelImg" runat="server" Visible="false">
                        <tr>
                            <th align="right">
                                <asp:Label ID="Label11" runat="server" Text="ͼƬ��"></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxControlImg" runat="server"></asp:TextBox>
                                <asp:Label ID="Label15" runat="server" Text="*" ForeColor="red"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxControlImg"
                                    Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                                <input id="Button1" type="button" value="ѡ��ͼƬ" onclick=" openSingleChild() " />
                                <img id="ImgControlImg" alt="" src="images/noImage.gif" runat="server" />
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="PanelProduct" runat="server" Visible="false">
                        <tr>
                            <th align="right">
                                <asp:Label ID="Label9" runat="server" Text="ͼƬ��"></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxProductImg" runat="server"></asp:TextBox>
                                <asp:Label ID="Label10" runat="server" Text="*" ForeColor="red"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxControlImg"
                                    Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                                <input id="Button2" type="button" value="ѡ��ͼƬ" onclick=" openLogoSingleChild2() " />
                                <img id="ImgProductImg" alt="" src="" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="Label12" runat="server" Text="�۸�"></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxPrice" runat="server"></asp:TextBox>
                                <asp:Label ID="Label13" runat="server" Text="*" ForeColor="red"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxPrice"
                                    Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorCostPrice1" runat="server"
                                    ControlToValidate="TextBoxPrice" Display="Dynamic" ErrorMessage="�۸��ʽ����ȷ" ValidationExpression="^[0-9]{1,7}(\.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="PanelFlash" runat="server" Visible="false">
                        <tr>
                            <th align="right">
                                <asp:Label ID="Label14" runat="server" Text="���ݣ�"></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxFlashImage" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:Label ID="Label16" runat="server" Text="*" ForeColor="red"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxFlashImage"
                                    Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxFlashImage"
                                    Display="Dynamic" ErrorMessage="���250���ַ�" ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <th align="right">
                            ����
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxMore" runat="server" OnCheckedChanged="CheckBoxMore_CheckedChanged"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label1" runat="server" Text="�Ƿ���ʾ��"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListIsShow" runat="server" CssClass="tselect" Style="width: 80px;">
                                <asp:ListItem Text="��" Value="0"></asp:ListItem>
                                <asp:ListItem Text="��" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <asp:Panel ID="PanelMore" runat="server" Visible="false">
                        <tr>
                            <th align="right">
                                <asp:Label ID="Label23" runat="server" Text="����2��"></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxTitle1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="Label21" runat="server" Text="����2��"></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxHref1" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TextBoxHref1"
                                    Display="Dynamic" ErrorMessage="���250���ַ�" ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="Label25" runat="server" Text="����3��"></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxTitle2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="Label27" runat="server" Text="����3��"></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxHref2" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="TextBoxHref2"
                                    Display="Dynamic" ErrorMessage="���250���ַ�" ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="BottonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="ȷ��"
                    ToolTip="Submit" CssClass="fanh" />
                <%--<input id="inputReset" runat="server" type="reset" value="����" class="bt2" />--%>
                <asp:Button ID="BottonBack" runat="server" Text="�����б�" CssClass="fanh" CausesValidation="False"
                    OnClick="BottonBack_Click" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldControlGuid" runat="server" Value="0" />
    </form>
</body>
</html>
