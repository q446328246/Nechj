<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Third_loginList.aspx.cs"
         Inherits="ShopNum1.Deploy.Main.Admin.Third_loginList" %>
<%@ Import Namespace="System.Data" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server" id="Head">
        <title>第三方设置</title>
        <link rel='stylesheet' type='text/css' href='style/css.css' />
        <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
        <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
        <script type='text/javascript' src='js/resolution-test.js'> </script>
    </head>
    <body class="widthah">
        <form id="form1" runat="server">
            <div id="right">
                <div class="rhigth">
                    <div class="rl">
                    </div>
                    <div class="rcon">
                        <h3>
                            第三方设置
                        </h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div class="order_edit" style="display: none;">
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td valign="top">
                                    <asp:LinkButton ID="ButtonDelete" runat="server" CausesValidation="False" OnClientClick=" return DeleteButton() "
                                                    OnClick="ButtonDelete_Click" CssClass="shanchu lmf_btn"><span>批量删除</span></asp:LinkButton>
                                </td>
                                <td valign="top">
                                    <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                                           AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                                           descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                                           Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                                           PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceData" AllowMultiColumnSorting="False"
                                           BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4"
                                           GridLines="Vertical">
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                        <%--分页--%>
                        <PagerStyle CssClass="lmf_page" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField Visible="false">
                                <HeaderTemplate>
                                    <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                                </HeaderTemplate>
                                <HeaderStyle CssClass="select_width" />
                                <ItemTemplate>
                                    <input id="checkboxItem" value='<%# Eval("ID") %>' type="checkbox" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="TypeName" HeaderText="名称" SortExpression="TypeName" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="AppID" HeaderText="AppID" SortExpression="AppID" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="AppSecret" HeaderText="AppSecret" SortExpression="AppSecret"
                                            ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="content" HeaderText="描述" SortExpression="content" ItemStyle-HorizontalAlign="Center" />
                            <asp:TemplateField HeaderText="状态">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" src='<%#base.GetAvailState(((DataRowView) Container.DataItem).Row["isAvabile"]) %>'
                                               Height="14" Width="14" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="图片" SortExpression="ImgSrc">
                                <ItemTemplate>
                                    <img src='<%# Page.ResolveUrl(Eval("ImgSrc").ToString()) %> ' height="20" width="20" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <a href="<%# "Third_loginOperate.aspx?id=" + Eval("ID") %>" style="color: #4482b4;">
                                        编辑</a>
                                    <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("ID") %>'
                                                    Visible="false" OnClientClick=" return window.confirm('您确定要删除吗?'); " OnClick="ButtonDeleteBylink_Click">删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:TemplateField>
                        </Columns>
                    </ShopNum1:Num1GridView>
                </div>
                <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
                <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="GetList"
                                      TypeName="ShopNum1.Second.ShopNum1_SecondTypeAccess">
                    <SelectParameters>
                        <asp:Parameter Name="strWhere" Type="String" DefaultValue=" " />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </form>
    </body>
</html>