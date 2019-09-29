<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopNum1_CategoryType_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopNum1_CategoryType_List" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>������Ϣ�����б�</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    ������Ϣ�����б�
                </h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            <asp:Label ID="LabelCategoryName" runat="server" Text="�������ࣺ"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxCategoryName" CssClass="tinput" Width="160" runat="server"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            <asp:Label ID="LabelName" runat="server" Text="�������ƣ�"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxName" CssClass="tinput" Width="160" runat="server"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            <asp:Label ID="LabelID" runat="server" Text="�Ƿ���ʾ��"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsShow" Width="100" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="��ѯ"
                                CssClass="dele" />
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" CausesValidation="False"
                                    class="tianjia2 lmf_btn"><span>���</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:Button ID="ButtonEdit" runat="server" CausesValidation="False" CssClass="fanh"
                                    Text="�༭" OnClientClick=" return EditButton() " OnClick="ButtonEdit_Click" Visible="false" />
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                    CausesValidation="False" class="shanchu lmf_btn"><span>����ɾ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="ȷʵҪɾ��ָ���ļ�¼��" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceData" AllowMultiColumnSorting="False"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4"
                GridLines="Vertical">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--��ҳ--%>
                <PagerStyle CssClass="lmf_page" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("ID") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="��������" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:BoundField DataField="CategoryName" HeaderText="��������" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="�Ƿ���ʾ" SortExpression="IsShow">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# PageOperator.GetListImageStatus(Eval("IsShow").ToString()) %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <a href="<%# "ShopNum1_CategoryType_Operate.aspx?guid=" + Eval("ID") + "" %>" style="color: #4482b4;">
                                �༭</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" OnClick="ButtonDeleteBylink_Click"
                                CommandArgument='<%# Eval("ID") %>' OnClientClick=" return window.confirm('��ȷ��Ҫɾ����?'); ">ɾ��</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SearchType"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_ProductCategory_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownListIsShow" Name="isShow" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:ControlParameter ControlID="TextBoxCategoryName" Name="categoryname" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxName" Name="name" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
