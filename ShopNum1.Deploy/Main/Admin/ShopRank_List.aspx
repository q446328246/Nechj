<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopRank_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopRank_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>店铺等级</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    店铺等级</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td valign="top">
                            <asp:LinkButton ID="ButtonAdd" runat="server" CssClass="tianjia2 lmf_btn" PostBackUrl="~/Main/Admin/ShopRank_Operate.aspx">
                                        <span>添加</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app" style="display: none;">
                            <asp:LinkButton ID="ButtonEdit" runat="server" OnClick="ButtonEdit_Click" OnClientClick=" return EditButton() "
                                CausesValidation="False" CssClass="dele" Visible="false"><span>编辑</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                            <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                CausesValidation="False" CssClass="shanchu lmf_btn"><span>批量删除</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                            <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridviewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceDate" AllowMultiColumnSorting="False"
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
                            <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" runat="server" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="名称" SortExpression="Name" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="等级图片" SortExpression="Pic">
                        <ItemTemplate>
                            <img src='<%# Page.ResolveUrl(Eval("Pic").ToString()) %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="MaxProductCount" HeaderText="最大商品数量" SortExpression="MaxProductCount"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="开店费用(元/年)" DataField="price" SortExpression="price" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="MaxArticleCout" HeaderText="添加的最大资讯数量" SortExpression="MaxArticleCout"
                        ItemStyle-HorizontalAlign="Center" Visible="false" />
                    <asp:BoundField DataField="MaxVedioCount" HeaderText="添加的最大视频数量" SortExpression="MaxVedioCount"
                        ItemStyle-HorizontalAlign="Center" Visible="false" />
                    <asp:BoundField DataField="shopTemplate" HeaderText="可以使用的模板" SortExpression="shopTemplate"
                        ItemStyle-HorizontalAlign="Center" Visible="false" />
                    <asp:TemplateField HeaderText="等级值" SortExpression="Pic">
                        <ItemTemplate>
                            <%#Eval("RankValue") %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="是否默认" SortExpression="IsDefault">
                        <ItemTemplate>
                            <asp:Image ID="Image2" runat="server" src='<%# GetRight(Eval("IsDefault").ToString(), "0") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href="<%#"ShopRank_Operate.aspx?guid=" + Eval("Guid") %>" style="color: #4482b4;">
                                编辑</a>
                            <asp:HiddenField ID="HiddenFieldIsDefault" runat="server" Value='<%# Eval("IsDefault") %>' />
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid") %>'
                                OnClick="ButtonDeleteBylink_Click" OnClientClick=" return window.confirm('您确定要删除吗?'); ">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="Search"
            TypeName="ShopNum1.ShopBusinessLogic.Shop_Rank_Action">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="isDeleted" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
