<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopNum1_ProductCategory_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopNum1_ProductCategory_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>������Ʒ����</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth" style="display: none;">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelTitle" runat="server" Text="������Ʒ����"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr id="trID" runat="server">
                        <th align="right" width="150px">
                            <asp:Localize ID="Localize6" runat="server" Text="ID��"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxId" MaxLength="9" runat="server" CssClass="tinput" Enabled="false"></asp:TextBox><span>
                                ��Ʒ����ID</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize1" runat="server" Text="�������ƣ�"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput" MaxLength="20"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="���50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize7" runat="server" Text="��Ʒ���ͣ�"></asp:Localize>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListCateType" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                            <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <span>��Ʒ���ͷ��ࡣ</span>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="DropDownListCateType"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr id="trCode" runat="server">
                        <th align="right">
                            <asp:Localize ID="Localize8" runat="server" Text="Code��"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxCode" MaxLength="9" runat="server" CssClass="tinput" Enabled="false"></asp:TextBox><span>
                                ��Ʒ������</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeFatherCateGory" runat="server" Text="�ϼ����ࣺ"></asp:Localize>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListFatherCateGory" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                            <asp:Label ID="Label3" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <span>�̳��������ࡣ</span>
                            <asp:CompareValidator ID="CompareFatherCateGory" runat="server" ControlToValidate="DropDownListFatherCateGory"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize2" runat="server" Text="����ؼ��֣�"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxKeywords" runat="server" CssClass="tinput"></asp:TextBox><span>
                                �̳����õĹؼ��֣�����SEO�Ż���</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorKeywords" runat="server"
                                ControlToValidate="TextBoxKeywords" Display="Dynamic" ErrorMessage="���200���ַ�"
                                ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize9" runat="server" Text="���÷���ͼƬ��"></asp:Localize>
                        </th>
                        <td>
                            <asp:FileUpload ID="fileCategory" runat="server" /><img src="" id="imgshow" runat="server"
                                style="height: 50px; width: 50px;" alt="" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize4" runat="server" Text="��������"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOrderID" MaxLength="8" runat="server" CssClass="tinput"></asp:TextBox><span>
                                (�Զ�����)</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxOrderID" runat="server"
                                ControlToValidate="TextBoxOrderID" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryOrderID" runat="server"
                                ControlToValidate="TextBoxOrderID" ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize5" runat="server" Text="�Ƿ�ǰ̨��ʾ��"></asp:Localize>
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsShow" runat="server" Checked="True" Text="��" /><span> ��Ʒ�����Ƿ���ǰ̨��ʾ��</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize3" runat="server" Text="����������"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDescription" runat="server" TextMode="MultiLine" CssClass="tinput txtarea"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorDescription" runat="server"
                                ControlToValidate="TextBoxDescription" Display="Dynamic" ErrorMessage="���200���ַ�"
                                ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" CssClass="fanh" OnClick="ButtonConfirm_Click"
                    ToolTip="Submit" />
                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenFieldSpecification" runat="server" Value="-1" />
    </form>
    <script type="text/javascript" src="/js/jquery-1.6.2.min.js"> </script>
</body>
</html>
