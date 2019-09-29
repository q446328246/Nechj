<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CategoryAdID_List.aspx.cs"
         Inherits="ShopNum1.Deploy.Main.Admin.CategoryAdID_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>分类广告位列表</title>
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
                            分类广告位列表</h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div class="order_edit">
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr style="height: 35px; vertical-align: top;">
                                <td>
                                    页面名：
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListAdPageName" AutoPostBack="true" runat="server"
                                                      CssClass="tselect" Width="201px">
                                        <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                                        <asp:ListItem Value="1">商品分类</asp:ListItem>
                                        <asp:ListItem Value="2">分类信息分类</asp:ListItem>
                                        <asp:ListItem Value="3">供求分类</asp:ListItem>
                                        <asp:ListItem Value="4">店铺分类</asp:ListItem>
                                        <asp:ListItem Value="5">资讯分类</asp:ListItem>
                                        <asp:ListItem Value="6">品牌分类</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="lmf_padding">
                                    广告位ID：
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxAdID" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="ButtonSearch" runat="server" Text="查询" CssClass="dele" OnClick="ButtonSearch_Click" />
                                </td>
                            </tr>
                        </table>
                        <div class="sbtn">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td valign="top">
                                        <asp:Button ID="ButtonSearchDetail" runat="server" CausesValidation="False" Text="查看详细"
                                                    OnClientClick=" return EditButton() " CssClass="fanh" OnClick="ButtonSearchDetail_Click"
                                                    Visible="false" />
                                        <asp:LinkButton ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" CausesValidation="False"
                                                        class="tianjia2 lmf_btn"><span>添加</span></asp:LinkButton>
                                    </td>
                                    <td valign="top" class="lmf_app">
                                        <asp:Button ID="ButtonEdit" runat="server" CausesValidation="False" Text="编辑" OnClientClick=" return EditButton() "
                                                    OnClick="ButtonEdit_Click" CssClass="fanh" Visible="false" />
                                        <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                                        CausesValidation="False" class="shanchu lmf_btn"><span>批量删除</span></asp:LinkButton>
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
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                                </HeaderTemplate>
                                <HeaderStyle CssClass="select_width" />
                                <ItemTemplate>
                                    <input id="checkboxItem" type="checkbox" value='<%# Eval("ID") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ID" HeaderText="广告位ID" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="页面名">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# PageName(Eval("CategoryType")) %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="CategoryAdName" HeaderText="广告名称" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="height" HeaderText="高度" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="width" HeaderText="宽度" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="默认图片" SortExpression="CategoryAdDefalutPic">
                                <ItemTemplate>
                                    <img src='<%# Page.ResolveUrl("~/ImgUpload/" + Eval("CategoryAdDefalutPic")) %> '
                                         onmouseover=" javascript:ddrivetip('<img width=200px height=200 src=<%# Page.ResolveUrl("~/ImgUpload/" + Eval("CategoryAdDefalutPic")) %> >', '#ffffff'); "
                                         onmouseout=" hideddrivetip() " height="20" width="20" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <a href="<%# "CategoryAdID_Operate.aspx?ID=" + Eval("ID") %>" style="color: #4482b4;">
                                        编辑</a>
                                    <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" OnClick="ButtonDeleteBylink_Click"
                                                    CommandArgument='<%# Eval("ID") %>' OnClientClick=" return window.confirm('您确定要删除吗?'); ">删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </ShopNum1:Num1GridView>
                </div>
            </div>
            <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
                                  TypeName="ShopNum1.BusinessLogic.ShopNum1_CategoryAdID_Action" OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownListAdPageName" Name="categoryType" PropertyName="SelectedValue"
                                          Type="String" DefaultValue="" />
                    <asp:ControlParameter ControlID="TextBoxAdID" Name="adID" PropertyName="Text" DefaultValue="-1"
                                          Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        </form>
        <script type="text/javascript" src="js/showimg.js"> </script>
    </body>
</html>