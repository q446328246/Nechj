<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="TbProductCategory_Operate.aspx.cs" Inherits="ShopNum1.Deploy.Shop.ShopAdmin.TbTop.TbProductCategory_Operate" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <link rel='stylesheet' type='text/css' href='../style/style.css' />
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="tjsp_mian">
                <p class="ptitle">
                    <a href="S_Welcome.aspx">��������</a><span class="breadcrume_icon">>></span><a href="TbProductCategory_List.aspx">������Ʒ����</a><span
                                                                                                                                                class="breadcrume_icon">>></span> <span class="breadcrume_text">��Ʒ�������</span></p>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
                    <tr>
                        <th colspan="2" scope="col">
                            <asp:Label ID="LabelTitle" runat="server" Text="�����Ʒ����"></asp:Label>
                        </th>
                    </tr>
                    <tr>
                        <td class="bordleft" width="130">
                            <asp:Localize ID="Localize1" runat="server" Text="�������ƣ�"></asp:Localize>
                        </td>
                        <td class="bordrig">
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="ss_nr1"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                                        Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                                                            ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="���50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="bordleft" width="130">
                            <asp:Localize ID="LocalizeFatherCateGory" runat="server" Text="�ϼ����ࣺ"></asp:Localize>
                        </td>
                        <td class="bordrig">
                            <asp:DropDownList ID="DropDownListFatherCateGory" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareFatherCateGory" runat="server" ControlToValidate="DropDownListFatherCateGory"
                                                  Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="bordleft">
                            <asp:Localize ID="Localize2" runat="server" Text="����ؼ��֣�"></asp:Localize>
                        </td>
                        <td class="bordrig">
                            <asp:TextBox ID="TextBoxKeywords" runat="server" CssClass="ss_nr1"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorKeywords" runat="server"
                                                            ControlToValidate="TextBoxKeywords" Display="Dynamic" ErrorMessage="���200���ַ�"
                                                            ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="bordleft">
                            <asp:Localize ID="Localize3" runat="server" Text="����������"></asp:Localize>
                        </td>
                        <td class="bordrig" style="padding-bottom: 10px; padding-top: 10px;">
                            <asp:TextBox ID="TextBoxDescription" runat="server" TextMode="MultiLine" Width="550px"
                                         Height="120px" CssClass="ss_nr1"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorDescription" runat="server"
                                                            ControlToValidate="TextBoxDescription" Display="Dynamic" ErrorMessage="���200���ַ�"
                                                            ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="bordleft">
                            <asp:Localize ID="Localize4" runat="server" Text="��������"></asp:Localize>
                        </td>
                        <td class="bordrig">
                            <asp:TextBox ID="TextBoxOrderID" runat="server" CssClass="ss_nr1"></asp:TextBox>(�Զ�����)
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryOrderID" runat="server"
                                                            ControlToValidate="TextBoxOrderID" ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$"
                                                            Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="bordleft">
                            <asp:Localize ID="Localize5" runat="server" Text="�Ƿ�ǰ̨��ʾ��"></asp:Localize>
                        </td>
                        <td class="bordrig">
                            <asp:CheckBox ID="CheckBoxIsShow" runat="server" Checked="True" Text="��" />
                        </td>
                    </tr>
                    <tr>
                        <td class="bordleft">
                            <asp:Localize ID="Localize6" runat="server" Text="�Ƿ�ͬ���Ա���"></asp:Localize>
                        </td>
                        <td class="bordrig">
                            <asp:CheckBox ID="CheckBoxTb" runat="server" Checked="false" Text="�Ƿ�ͬ���Ա�" AutoPostBack="true"
                                          OnCheckedChanged="CheckBoxTb_CheckedChanged" />
                            <span id="spanTb" runat="server" style="color: Red;">(δͬ��)</span>
                        </td>
                    </tr>
                </table>
                <div style="margin: 20px 0px 50px 0px; text-align: center;">
                    <%--<input type="button" class="baocbtn" onclick="if (!checkImport()) { return false; } document.form1.target = '_self'; this.disabled = 'disabled'; __doPostBack('btnOk', '')" value="ȷ��" />
           <span id="spanImg" style="display:none;"><img src='/Images/load.gif'/></span>
           <span class="gray1">��Ȥ�ṩ��CSV���ܲ��Ǳ�׼�ĸ�ʽ��ע��ת�� (�ϴ��ļ���С��Ҫ����50M)</span>--%>
                    <asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" CssClass="baocbtn" ToolTip="Submit"
                                OnClick="ButtonConfirm_Click" OnClientClick=" " />
                    <input id="Reset1" type="reset" value="����" class="baocbtn" style="display: none;" />
                    <asp:Button ID="ButtonBack" runat="server" CssClass="baocbtn" Text="�����б�" CausesValidation="False"
                                OnClientClick=" window.location.href = 'TbProductCategory_List.aspx' " PostBackUrl="TbProductCategory_List.aspx" />
                    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
                </div>
            </div>
        </form>
    </body>
</html>