<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="OrdeComplaints_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.OrdeComplaints_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>投诉管理评论</title>
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="投诉管理"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <div>
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr style="height: 35px; vertical-align: top;">
                            <td>
                                投诉对象：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxComplaintShop" CssClass="tinput" Width="258" runat="server"></asp:TextBox>
                            </td>
                            <td class="lmf_padding">
                                投诉类别：
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListType" runat="server" Width="201" CssClass="tselect">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" CssClass="dele" OnClick="ButtonSearch_Click"
                                    Text="查询" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="Button1" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                    CssClass="shanchu lmf_btn"><span>批量删除</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonReply" runat="server" CausesValidation="False" OnClientClick=" return EditButton() "
                                    CssClass="liuyan lmf_btn" OnClick="ButtonReply_Click" Visible="false"><span>查看｜回复</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div>
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
                                <input id="checkboxItem" value='<%# Eval("ID") %>' type="checkbox" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" />
                        <asp:TemplateField HeaderText="投诉编号" SortExpression="ID">
                            <ItemTemplate>
                                <a href='<%#"OrdeComplaints_Operate.aspx?guid=" + Eval("ID") %>'>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label></a>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="MemLoginID" HeaderText="投诉人" SortExpression="Title" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderText="投诉对象" DataField="ComplaintShop" SortExpression="ComplaintShop"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="ComplaintTime" HeaderText="投诉时间" SortExpression="ComplaintTime">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="投诉类型" DataField="ComplaintType" SortExpression="ComplaintType"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="处理状态" SortExpression="ProcessingStatus">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#IsProcess(Eval("ProcessingStatus"))
    %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <a href="<%# "OrdeComplaints_Operate.aspx?guid=" + Eval("ID") %>" style="color: #4482b4;">
                                    回复</a>
                                <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("ID") %>'
                                    OnClientClick=" return window.confirm('您确定要删除吗?'); " OnClick="ButtonDeleteBylink_Click">删除</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:TemplateField>
                    </Columns>
                </ShopNum1:Num1GridView>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="GetOrderComplaints"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_OrdeComplaints_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxComplaintShop" Name="ComplaintShop" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="DropDownListType" Name="type" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
