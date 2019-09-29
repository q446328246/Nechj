<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Page_List.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Page_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ҳ�����</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"
        runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    ҳ�����</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table border="0" cellpadding="0" cellspacing="1">
                <tr style="height: 30px;">
                    <td width="90" style="padding-right: 5px; text-align: right;">
                        <asp:Label ID="LabelSPagePath" runat="server" Text="ҳ�����ƣ�"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxSName" CssClass="tinput" Width="200" runat="server"></asp:TextBox>
                    </td>
                    <td width="70" style="padding-right: 5px; text-align: right;">
                        <asp:Label ID="LabelSOne" runat="server" Text="һ��Ŀ¼��"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListSOne" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListSOne_SelectedIndexChanged"
                            Width="150px" CssClass="tselect">
                        </asp:DropDownList>
                    </td>
                    <td width="70" style="padding-right: 5px; text-align: right;">
                        <asp:Label ID="LabelSTwo" runat="server" Text="����Ŀ¼��"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListSTwo" runat="server" Width="150px" CssClass="tselect">
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td width="90" style="padding-right: 5px; text-align: right;">
                        <asp:Label ID="LabelSName" runat="server" Text="ҳ��Դ�ļ���"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxSPagePath" CssClass="tinput" Width="200" runat="server"></asp:TextBox>
                    </td>
                    <td width="70" style="padding-right: 5px; text-align: right;">
                        <asp:Label ID="LabelSPageType" runat="server" Text="ҳ�����ͣ�"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListSPageType" runat="server" AutoPostBack="True" Width="150px"
                            CssClass="tselect">
                            <asp:ListItem Value="-1" Selected="True">-ȫ��-</asp:ListItem>
                            <asp:ListItem Value="0">��߲˵�ҳ��</asp:ListItem>
                            <asp:ListItem Value="1">��ͨ����ҳ��</asp:ListItem>
                            <asp:ListItem Value="3">����ҳ��</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td colspan="3" style="padding-left: 8px;">
                        <asp:Button ID="ButtonSearch" runat="server" CausesValidation="False" Text="��ѯ" OnClick="ButtonSearch_Click"
                            CssClass="dele" />
                    </td>
                </tr>
            </table>
            <div class="vote2" style="margin-top: 10px; padding-left: 10px;">
                <asp:Button ID="ButtonAdd" runat="server" CausesValidation="False" Text="���" OnClick="ButtonAdd_Click"
                    ToolTip="addok" CssClass="addcate" />
                <asp:Button ID="ButtonEdit" runat="server" CausesValidation="False" Text="�༭" OnClientClick=" return EditButton() "
                    OnClick="ButtonEdit_Click" CssClass="dele" Visible="false" />
                <asp:Button ID="ButtonDel" runat="server" CausesValidation="False" OnClientClick=" return DeleteOneButton() "
                    Text="����ɾ��" OnClick="ButtonDel_Click" Visible="false" CssClass="shanchu com" />
                <asp:Button ID="ButtonManageControl" runat="server" CausesValidation="False" OnClick="ButtonManageControl_Click"
                    OnClientClick=" return EditButton() " Text="����ؼ�" CssClass="qb" />
            </div>
            <div>
                <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                    AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                    descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                    Del="False" DeletePromptText="ȷʵҪɾ��ָ���ļ�¼��" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                    PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceData" AllowMultiColumnSorting="False"
                    BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4"
                    GridLines="Vertical" Style="margin-top: 15px;">
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                    <%--��ҳ--%>
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" />
                        <asp:TemplateField HeaderText="ҳ������" SortExpression="PageType">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# ChangePageType(DataBinder.Eval(Container, "DataItem(PageType)", "{0}")) %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="ҳ������" SortExpression="Name">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PagePath" HeaderText="ҳ��Դ�ļ�" SortExpression="PagePath">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Description" HeaderText="����" SortExpression="Description"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="����">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkUpdate" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid") %>'
                                    OnClick="ButtonEditByLink_Click">�༭</asp:LinkButton>
                                <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" OnClick="ButtonDeleteBylink_Click"
                                    CommandArgument='<%# Eval("Guid") %>' OnClientClick=" return window.confirm('��ȷ��Ҫɾ����?'); ">ɾ��</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </ShopNum1:Num1GridView>
            </div>
            <div id="divPage" runat="server" visible="false">
                <div class="navigator">
                    &nbsp;
                    <asp:Label ID="LabelPageTitle" runat="server" Text="�����ҳ�桿" Height="30"></asp:Label>
                </div>
                <table cellpadding="0" cellspacing="1" border="0" style="width: 100%">
                    <tr>
                        <td colspan="2" style="width: 100%;">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%;">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td align="right">
                            <asp:Label ID="LabelPageType" runat="server" Text="ҳ�����ͣ�"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListPageType" runat="server" Width="184px" AutoPostBack="True"
                                OnSelectedIndexChanged="DropDownListPageType_SelectedIndexChanged" CssClass="tselect">
                                <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                <asp:ListItem Value="0">��߲˵�ҳ��</asp:ListItem>
                                <asp:ListItem Value="1">��ͨ����ҳ��</asp:ListItem>
                                <asp:ListItem Value="3">����ҳ��</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="Label5" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                            <asp:CompareValidator ID="CompareValidatorPageType" runat="server" ControlToValidate="DropDownListPageType"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr style="display: <%= (One) ? "" : "none" %>; height: 30px;">
                        <td align="right">
                            <asp:Label ID="LabelOne" runat="server" Text="һ��Ŀ¼��"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListOne" Width="184px" runat="server" AutoPostBack="True"
                                CssClass="tselect" OnSelectedIndexChanged="DropDownListOne_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Label ID="Label8" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: <%= (Two) ? "" : "none" %>; height: 30px;">
                        <td align="right">
                            <asp:Label ID="LabelTwo" runat="server" Text="����Ŀ¼��"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListTwo" Width="184px" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="DropDownListTwo_SelectedIndexChanged" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td align="right">
                            <asp:Label ID="LabelName" runat="server" Text="ҳ�����ƣ�"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBoxName" CssClass="tinput" Width="180" runat="server"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorLoginID0" runat="server"
                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="ҳ���������50���ַ�"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: <%= (PagePath) ? "" : "none" %>; height: 30px;">
                        <td align="right">
                            <asp:Label ID="LabelPagePath" runat="server" Text="ҳ��Դ�ļ���"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBoxPagePath" CssClass="tinput" Width="180" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPagePath" runat="server"
                                ControlToValidate="TextBoxPagePath" Display="Dynamic" ErrorMessage="ҳ��Դ�ļ����250���ַ�"
                                ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="height: 70px;">
                        <td align="right">
                            <asp:Label ID="LabelDescription" runat="server" Text="����:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBoxDescription" runat="server" CssClass="tinput" TextMode="MultiLine"
                                Width="440px" Height="60px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td align="right">
                            <asp:Label ID="LabelOrderID" runat="server" Text="����ţ�"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBoxOrderID" CssClass="tinput" Width="180" runat="server"></asp:TextBox>
                            <asp:Label ID="Label7" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderID" runat="server" ControlToValidate="TextBoxOrderID"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorLoginID" runat="server"
                                ControlToValidate="TextBoxOrderID" Display="Dynamic" ErrorMessage="����������" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="background-color: #EEEEEE;" class="btconfig; height:30px;">
                        <td align="right">
                            &nbsp;
                        </td>
                        <td align="left">
                            <div style="width: 80%;">
                                <asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" OnClick="ButtonConfirm_Click"
                                    ToolTip="Submit" CssClass="dele" />
                                <input id="inputReset" runat="server" type="reset" value="����" class="dele" visible="false" />
                                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_Page_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownListSOne" Name="oneID" PropertyName="SelectedValue"
                    Type="Int32" DefaultValue="-1" />
                <asp:ControlParameter ControlID="DropDownListSTwo" DefaultValue="-1" Name="twoID"
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="DropDownListSPageType" Name="pageType" PropertyName="SelectedValue"
                    Type="Int32" DefaultValue="-1" />
                <asp:ControlParameter ControlID="TextBoxSName" DefaultValue="" Name="name" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxSPagePath" Name="pagePath" PropertyName="Text"
                    Type="String" />
                <asp:Parameter Name="IsDeleted" Type="Int32" DefaultValue="0" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
