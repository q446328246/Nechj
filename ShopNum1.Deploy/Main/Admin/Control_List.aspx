<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Control_List.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Control_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>����ҳ��ؼ�</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body>
    <form id="form2" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    ����ҳ��ؼ�</h3>
            </div>
            <div class="rr">
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <div style="margin-bottom: 10px;">
                    <table border="0" cellspacing="0" cellpadding="0" style="margin-bottom: 7px;">
                        <tr>
                            <td width="100" style="padding-right: 5px; text-align: right;">
                                <asp:Label ID="LabelPageType" runat="server" Text="��ǰҳ�����ͣ�"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelPageTypeShow" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100" style="padding-right: 5px; text-align: right;">
                                <asp:Label ID="LabelPageName" runat="server" Text="��ǰҳ�����ƣ�"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelPageNameShow" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100" style="padding-right: 5px; text-align: right;">
                                <asp:Label ID="LabelPagePath" runat="server" Text="��ǰҳ��Դ�ļ���"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelPagePathShow" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <asp:Button ID="ButtonAdd" runat="server" CausesValidation="False" Text="���" OnClick="ButtonAdd_Click"
                            CssClass="addcate" />
                        <asp:Button ID="ButtonEdit" runat="server" CausesValidation="False" Text="�༭" OnClientClick=" return EditButton() "
                            OnClick="ButtonEdit_Click" CssClass="dele" />
                        <asp:Button ID="ButtonDelete" runat="server" CausesValidation="False" Text="����ɾ��"
                            OnClientClick=" return DeleteButton() " OnClick="ButtonDelete_Click" CssClass="shanchu com" />
                    </div>
                </div>
            </div>
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
                    <asp:BoundField DataField="ControlType" HeaderText="�ؼ�����" SortExpression="ControlType">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="�ؼ�����" DataField="Name" SortExpression="Name">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="�ؼ�ID" DataField="ControlID" SortExpression="ControlID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="����" DataField="Description" SortExpression="Description">
                    </asp:BoundField>
                </Columns>
            </ShopNum1:Num1GridView>
            <div id="divPage" runat="server">
                <div class="navigator">
                    &nbsp;
                    <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="�����ؼ�"></asp:Label>
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
                            <asp:Label ID="LabelControlType" runat="server" Text="�ؼ����ͣ�"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListControlType" runat="server" CssClass="tselect"
                                Width="190px" OnSelectedIndexChanged="DropDownListControlType_SelectedIndexChanged">
                                <asp:ListItem Value="Button">��ͨ��ť</asp:ListItem>
                                <asp:ListItem Value="LinkButton">���Ӱ�ť</asp:ListItem>
                                <asp:ListItem Value="ImageButton">ͼƬ��ť</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td align="right">
                            <asp:Label ID="LabelControlName" runat="server" Text="�ؼ����ƣ�"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBoxControlName" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxControlName"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td align="right">
                            <asp:Label ID="LabelControlID" runat="server" Text="�ؼ�ID��"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBoxControlID" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorControlID" runat="server" ControlToValidate="TextBoxControlID"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td align="right">
                            <asp:Label ID="LabelDescription" runat="server" Text="������"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBoxDescription" runat="server" CssClass="tinput txtarea" TextMode="MultiLine"
                                Width="440px" Height="60px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="background-color: #EEEEEE;" class="btconfig; height:30px;">
                        <td align="right">
                            &nbsp;
                        </td>
                        <td align="left">
                            <div style="width: 80%;">
                                <asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" OnClick="ButtonConfirm_Click"
                                    ToolTip="Submit" CssClass="fanh" />
                                <%-- <input id="inputReset" runat="server" type="reset" value="����" class="bt2" />--%>
                                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenControlGuid" runat="server" Value="0" />
    &nbsp;<asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_PageWebControl_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="hiddenGuid" Name="pageGuid" PropertyName="Value"
                Type="String" DefaultValue="" />
            <asp:Parameter Name="guid" Type="String" />
            <asp:Parameter Name="IsDeleted" Type="Int32" DefaultValue="0" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    </form>
</body>
</html>
