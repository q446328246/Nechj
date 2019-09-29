<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="UserDefinedColumn_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.UserDefinedColumn_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>������Ŀ</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="������Ŀ"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table border="0" cellpadding="0" cellspacing="0" class="shoptable">
                <tr>
                    <th align="right" width="150px">
                        <div class="shopth">
                            <asp:Localize ID="LocalizeName" runat="server" Text="��Ŀ���ƣ�"></asp:Localize>
                        </div>
                    </th>
                    <td valign="middle">
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput" MaxLength="10"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:Label ID="Label4" runat="server" Text="ע��:�Զ�����Ŀ���ܳ���10���ַ�,����ǰ̨��������"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Localize ID="LocalizeLinkAddress" runat="server" Text="���ӵ�ַ��"></asp:Localize>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxLinkAddress" runat="server" CssClass="tinput" MaxLength="15"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server" ControlToValidate="TextBoxLinkAddress"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:Label ID="Label5" runat="server" Text="ע��:��վ��ֱַ��дҳ�����磺shopnum1,������ַ��д������ַ�磺http://www.t.com "></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr style="display: none">
                    <th align="right">
                        <div class="shopth">
                            <asp:Localize ID="Localize1" runat="server" Text="�Ƿ�Ӧ���ڵ���ǰ̨��"></asp:Localize>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListIsShop" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                            <span style="display: none">�Ƿ�Ӧ���ڵ���ǰ̨</span>
                            <asp:CompareValidator ID="CompareValidatorIsShop" runat="server" ControlToValidate="DropDownListIsShop"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </div>
                    </td>
                </tr>
                <tr style="display: none">
                    <th align="right">
                        <div class="shopth">
                            <asp:Localize ID="Localize2" runat="server" Text="�Ƿ�Ӧ���ڻ�Ա���ģ�"></asp:Localize>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListIsMember" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                            <span style="display: none">�Ƿ�Ӧ���ڻ�Ա����</span>
                            <asp:CompareValidator ID="CompareValidatorIsMember" runat="server" ControlToValidate="DropDownListIsMember"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </div>
                    </td>
                </tr>
                <tr style="display: none">
                    <th align="right">
                        <div class="shopth">
                            <asp:Localize ID="Localize3" runat="server" Text="�Ƿ�Ӧ������վǰ̨��"></asp:Localize>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListIsSite" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                            <span style="display: none">�Ƿ�Ӧ������վǰ̨</span>
                            <asp:CompareValidator ID="CompareValidatorIsSite" runat="server" ControlToValidate="DropDownListIsSite"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Localize ID="LocalizeShowLocation" runat="server" Text="��ʾλ�ã�"></asp:Localize>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListShowLocation" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                            <span style="display: none">��ʾλ��</span>
                            <asp:CompareValidator ID="CompareShowLocation" runat="server" ControlToValidate="DropDownListShowLocation"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Localize ID="LocalizeIfOpen" runat="server" Text="�Ƿ����´��ڴ򿪣�"></asp:Localize>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListIfOpen" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                            <span style="display: none">�Ƿ����´��ڴ�</span>
                            <asp:CompareValidator ID="CompareOpen" runat="server" ControlToValidate="DropDownListIfOpen"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Localize ID="LocalizeOrderID" runat="server" Text="�����кţ�"></asp:Localize>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxOrderID" MaxLength="9" runat="server" CssClass="tinput"></asp:TextBox><span>�Զ�����</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryOrderID" runat="server"
                                ControlToValidate="TextBoxOrderID" ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Localize ID="Localize5" runat="server" Text="�Ƿ�ǰ̨��ʾ��"></asp:Localize>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListIfShow" CssClass="tselect" runat="server">
                            </asp:DropDownList>
                            <span style="display: none">�Ƿ���ǰ̨��ʾ��</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth" style="border-bottom: none; height: 115px;">
                            <asp:Localize ID="LocalizeRemark" runat="server" Text="˵����"></asp:Localize>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd" style="border-bottom: none; height: 115px;">
                            <asp:TextBox ID="TextBoxRemark" runat="server" TextMode="MultiLine" CssClass="tinput txtarea"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorRemark" runat="server" ControlToValidate="TextBoxRemark"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRemark" runat="server"
                                ControlToValidate="TextBoxRemark" Display="Dynamic" ErrorMessage="���200���ַ�" ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" OnClick="ButtonConfirm_Click"
                    ToolTip="Submit" CssClass="fanh" />
                <asp:Button ID="Button1" runat="server" CssClass="fanh" CausesValidation="false"
                    PostBackUrl="~/Main/Admin/UserDefinedColumn_List.aspx" Text="�����б�" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
