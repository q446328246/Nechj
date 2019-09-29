<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttachMentCateGory_List.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.AttachMentCateGory_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>附件分类管理</title>
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
                            <asp:Label ID="Label1" runat="server" Text="附件分类列表" /></h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div class="order_edit">
                        <asp:Button ID="ButtonAdd" runat="server" Text="添加" CssClass="tianjia2 picbtn" OnClick="ButtonAdd_Click" />
                        <asp:Button ID="ButtonEdit" runat="server" OnClientClick=" return EditButton() "
                                    Text="编辑" CssClass="fanh" OnClick="ButtonEdit_Click" Visible="false" />
                        <asp:Button ID="ButtonDelete" runat="server" Text="批量删除" CssClass="shanchu com" OnClientClick=" return DeleteButton() "
                                    OnClick="ButtonDelete_Click" />
                        <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                    </div>
                    <ShopNum1:Num1GridView ID="num1GridViewShow" runat="server" AutoGenerateColumns="False"
                                           AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                                           descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                                           Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                                           PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceData" AllowMultiColumnSorting="False"
                                           BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4"
                                           GridLines="Vertical">
                        <footerstyle backcolor="#CCCC99" />
                        <headerstyle horizontalalign="Center" cssclass="list_header" forecolor="White"></headerstyle>
                        <%--分页--%>
                        <pagerstyle backcolor="#F7F7DE" forecolor="Black" horizontalalign="Right" />
                        <selectedrowstyle backcolor="#CE5D5A" font-bold="True" forecolor="White" />
                        <alternatingrowstyle backcolor="White" />
                        <columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="附件分类名称" DataField="CategoryName" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="描述" DataField="Description" ItemStyle-HorizontalAlign="Center" />
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <a href="<%# "AttachMentCateGory_Operate.aspx?guid=" + "'" + Eval("Guid") + "'" %>" style="color: #4482b4;">
                                        编辑</a>
                                    <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid") %>'
                                                    OnClientClick=" return window.confirm('您确定要删除吗?'); " OnClick="ButtonDeleteBylink_Click">删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </columns>
                    </ShopNum1:Num1GridView>
                    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
                                          TypeName="ShopNum1.BusinessLogic.ShopNum1_AttachMentCategory_Action"></asp:ObjectDataSource>
                </div>
                <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
            </div>
        </form>
    </body>
</html>