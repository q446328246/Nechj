<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Specification_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Specification_List" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>������</title>
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
                    ������</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td valign="top">
                            <asp:LinkButton ID="ButtonAdd" runat="server" CssClass="tianjia2 lmf_btn" OnClick="ButtonAdd_Click"><span>���</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                            <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                CausesValidation="False" CssClass="shanchu lmf_btn"><span>����ɾ��</span></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="ȷʵҪɾ��ָ���ļ�¼��" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSource1" AllowMultiColumnSorting="False"
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
                            <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# ((DataRowView) Container.DataItem).Row["id"] %>'
                                type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="�������" SortExpression="SpecificationName" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="LabelName" runat="server" Text='<%# ((DataRowView) Container.DataItem).Row["SpecName"] %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="���ֵ" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%#Common.cut(((DataRowView) Container.DataItem).Row["detailSpec"].ToString(), 75) %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="��ʾ����" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="LabelType" runat="server" Text='<%#(ShowTypeImg) Convert.ToInt32(((DataRowView) Container.DataItem).Row["ShowType"]) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="���ע" DataField="Memo" SortExpression="Memo" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:BoundField DataField="OrderID" HeaderText="��������" SortExpression="OrderID" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <a href="<%# "Specification_Operate.aspx?id=" + Eval("id") %>" style="color: #4482b4;">
                                �༭</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("id") %>'
                                OnClientClick=" return window.confirm('��ȷ��Ҫɾ����?'); " OnClick="ButtonDeleteBylink_Click">ɾ��</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Search"
                TypeName="ShopNum1.BusinessLogic.ShopNum1_Spec_Action" OldValuesParameterFormatString="original_{0}">
            </asp:ObjectDataSource>
        </div>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
