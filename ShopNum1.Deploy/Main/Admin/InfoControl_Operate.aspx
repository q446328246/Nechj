<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="InfoControl_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.InfoControl_Operate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ģ���б���Ϣ</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js">        function inputReset_onclick() {

        } </script>
    <script type="text/javascript">

        //ѡ��ͼ
        function openSingleChild() {
            var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
            if (k != null) {
                var strArray = k.split(',');
                document.getElementById("TextBoxControlImg").value = strArray[0];
                document.getElementById("ImgControlImg").src = strArray[1];
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
                    <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="ģ���б���Ϣ"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="LabelTitle" runat="server" Text="ҳ����������"></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxPageName" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                            <font style="color: Red">
                                <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label></font>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" ControlToValidate="TextBoxPageName"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorT" runat="server" ControlToValidate="TextBoxPageName"
                                Display="Dynamic" ErrorMessage="�������50���ַ�" ValidationExpression="^[\s\S]{0,50}$">
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label5" runat="server" Text="ҳ���ļ�����"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxPageFileName" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                            <font style="color: Red">
                                <asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label></font>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxPageFileName"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxPageFileName"
                                Display="Dynamic" ErrorMessage="�������50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label3" runat="server" Text="�ؼ���������"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxControlName" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                            <font style="color: Red">
                                <asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label></font>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxControlName"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxControlName"
                                Display="Dynamic" ErrorMessage="�������50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label8" runat="server" Text="�ؼ��ļ�����"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxControlFileName" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                            <font style="color: Red">
                                <asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label></font>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxControlFileName"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxControlFileName"
                                Display="Dynamic" ErrorMessage="�������50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label1" runat="server" Text="�ؼ���ʶ��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxControlKey" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                            <font style="color: Red">
                                <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label></font>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxControlKey"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBoxControlKey"
                                Display="Dynamic" ErrorMessage="�������50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label10" runat="server" Text="�ؼ���ͼ��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxControlImg" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:Label ID="Label15" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxControlImg"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <input id="Button2" type="button" value="ѡ��ͼƬ" onclick=" openSingleChild() " class="selpic" />
                            <img id="ImgControlImg" alt="" src="../../ImgUpload/noImage.gif" height="150" width="150"
                                onerror="javascript:this.src='../../ImgUpload/noImage.gif'" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label11" runat="server" Text="�Ƿ���ʾ��"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListIsShow" runat="server" CssClass="tselect">
                                <asp:ListItem Text="��" Value="0"></asp:ListItem>
                                <asp:ListItem Text="��" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="BottonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="ȷ��"
                    CssClass="fanh" ToolTip="Submit" />
                <asp:Button ID="BottonBack" runat="server" Text="�����б�" CausesValidation="False" CssClass="fanh"
                    OnClick="BottonBack_Click" />
                <asp:Button ID="ButtonSeeData" runat="server" CausesValidation="False" Text="����ؼ�����"
                    CssClass="c_fanh" OnClick="ButtonSeeData_Click" Visible="false" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <%-- <div class="navigator">
        ��
        <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="ģ���б���Ϣ"></asp:Label>
        ��</div>
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" width="20%">
                <asp:Label ID="LabelTitle" runat="server" Text="ҳ����������"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxPageName" CssClass="allinput1" runat="server" Width="200"></asp:TextBox>
                <font style="color: Red">
                    <asp:Label ID="Label4" runat="server" Text="*"></asp:Label></font>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" ControlToValidate="TextBoxPageName"
                    Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorT" runat="server" ControlToValidate="TextBoxPageName"
                    Display="Dynamic" ErrorMessage="�������50���ַ�" ValidationExpression="^[\s\S]{0,50}$">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label5" runat="server" Text="ҳ���ļ�����"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxPageFileName" CssClass="allinput1" runat="server" Width="200"></asp:TextBox>
                <font style="color: Red">
                    <asp:Label ID="Label6" runat="server" Text="*"></asp:Label></font>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxPageFileName"
                    Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxPageFileName"
                    Display="Dynamic" ErrorMessage="�������50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label3" runat="server" Text="�ؼ���������"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxControlName" CssClass="allinput1" runat="server" Width="200"></asp:TextBox>
                <font style="color: Red">
                    <asp:Label ID="Label7" runat="server" Text="*"></asp:Label></font>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxControlName"
                    Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxControlName"
                    Display="Dynamic" ErrorMessage="�������50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label8" runat="server" Text="�ؼ��ļ�����"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxControlFileName" CssClass="allinput1" runat="server" Width="200"></asp:TextBox>
                <font style="color: Red">
                    <asp:Label ID="Label9" runat="server" Text="*"></asp:Label></font>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxControlFileName"
                    Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxControlFileName"
                    Display="Dynamic" ErrorMessage="�������50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label10" runat="server" Text="�ؼ���ʶ��"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxControlKey" CssClass="allinput1" runat="server" Width="200"></asp:TextBox>
                <font style="color: Red">
                    <asp:Label ID="Label11" runat="server" Text="*"></asp:Label></font>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxControlKey"
                    Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBoxControlKey"
                    Display="Dynamic" ErrorMessage="�������50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label12" runat="server" Text="�ؼ���ͼ��"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxControlImg" CssClass="allinput1" runat="server"></asp:TextBox>
                <asp:Label ID="Label15" runat="server" Text="*" ForeColor="red"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxControlImg"
                    Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                <input id="Button1" type="button" value="ѡ��ͼƬ" onclick="openSingleChild()" class="bt3" />
                <img id="ImgControlImg" alt="" src="../../ImgUpload/noImage.gif" height="150" width="150" onerror="javascript:this.src='../../ImgUpload/noImage.gif'" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label13" runat="server" Text="�Ƿ���ʾ��"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="DropDownListIsShow" runat="server">
                    <asp:ListItem Text="��" Value="0"></asp:ListItem>
                    <asp:ListItem Text="��" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="background-color: #EEEEEE;" class="btconfig">
            <td align="right">
            </td>
            <td align="left">
                <div>
                    <asp:Button ID="BottonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="ȷ��"
                        ToolTip="Submit" CssClass="bt2" />
                    <input id="inputReset" runat="server" type="reset" value="����" class="bt2" />
                    <asp:Button ID="BottonBack" runat="server" Text="�����б�" CssClass="bt3" CausesValidation="False"
                        OnClick="BottonBack_Click" />
                    <asp:Button ID="ButtonSeeData" runat="server" CausesValidation="False" Text="����ؼ�����"
                        CssClass="bt3" OnClick="ButtonSeeData_Click" Visible="false" />
                    <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                </div>
            </td>
        </tr>
    </table>--%>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
