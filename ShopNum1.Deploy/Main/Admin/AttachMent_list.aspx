<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttachMent_list.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.AttachMent_list" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>附件列表</title>
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
                            附件列表</h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div class="order_edit">
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr style="height: 35px; vertical-align: top;">
                                <td>
                                    <asp:Localize ID="LocalizeAssociatedCategoryGuid" runat="server" Text="附件类别："></asp:Localize>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListAssociatedCategoryGuid" runat="server" Width="258px"
                                                      CssClass="tselect">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="Button1" CssClass="dele" runat="server" Text="查询" />
                                </td>
                            </tr>
                        </table>
                        <div class="sbtn">
                            <asp:Button ID="Button2" runat="server" CssClass="tianjia2 picbtn" Text="添加" OnClick="ButtonAdd_Click" />
                            <asp:Button ID="Button3" runat="server" Text="批量删除" CssClass="shanchu com" OnClientClick=" return DeleteButton() "
                                        OnClick="ButtonDelete_Click" />
                            <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                        </div>
                    </div>
                    <ShopNum1:Num1GridView ID="num1GridViewShow" runat="server" AutoGenerateColumns="False"
                                           AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                                           descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                                           Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                                           PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceDate" AllowMultiColumnSorting="False"
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
                            <asp:BoundField HeaderText="附件名称" DataField="Title" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="附件地址" DataField="AttachmentURL" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="附件分类" DataField="CategoryName" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="描述" DataField="Description" ItemStyle-HorizontalAlign="Center" />
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <%-- <a href="<%# "AttachMent_Operate.aspx?Guid='"+Eval("Guid")+"'" %>" style="color: #4482b4;">
                                编辑</a>--%>
                                    <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" OnClick="ButtonDeleteBylink_Click"
                                                    CommandArgument='<%# Eval("Guid") %>' OnClientClick=" return window.confirm('您确定要删除吗?'); ">删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </columns>
                    </ShopNum1:Num1GridView>
                    <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="Search"
                                          TypeName="ShopNum1.BusinessLogic.ShopNum1_AttachMent_Action">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownListAssociatedCategoryGuid" Name="AssociatedCategoryGuid"
                                                  PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
                <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
            </div>
        </form>
    </body>
</html>