<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopReputation_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopReputation_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
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
                    店铺信誉等级</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td valign="top" style="display: none;">
                            <asp:DropDownList ID="DropDownListType" runat="server" Visible="false" OnSelectedIndexChanged="DropDownListType_SelectedIndexChanged"
                                AutoPostBack="true">
                                <asp:ListItem Value="1">信誉等级</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td valign="top">
                            <asp:LinkButton ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" OnClientClick=" GetCheckedBoxValues() "
                                CausesValidation="False" CssClass="tianjia2 lmf_btn"><span>添加</span></asp:LinkButton>
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
                            <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
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
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5% " />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="名称" DataField="Name" SortExpression="Name" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="最小信誉值" DataField="minScore" SortExpression="minScore"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="最大信誉值" DataField="maxScore" SortExpression="maxScore"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="备注" DataField="Memo" SortExpression="Memo" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="等级图片" SortExpression="pic">
                        <ItemTemplate>
                            <img src='<%#Eval("Pic") %>' alt="" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" SortExpression="IsShow">
                        <ItemTemplate>
                            <a href="<%# "ShopReputation_Operate.aspx?Guid=" + Eval("Guid") %>" style="color: #4482b4;">
                                编辑</a>
                            <asp:LinkButton ID="LinkDelte" CommandArgument='<%# Eval("Guid") %>' runat="server"
                                Style="color: #4482b4;" OnClick="ButtonDeleteBylink_Click" OnClientClick=" return window.confirm('您确定要删除吗?'); ">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="Search"
            TypeName="ShopNum1.ShopBusinessLogic.Shop_Reputation_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownListType" Name="type" PropertyName="SelectedValue"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
