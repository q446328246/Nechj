<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopEnsureVerifyChecked_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopEnsureVerifyChecked_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>店铺担保审核列表</title>
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
                    店铺担保审核列表</h3>
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
                                担保名称：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                            </td>
                            <td class="lmf_padding">
                                申请店铺：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxShopID" runat="server" CssClass="tinput" Width="200px"></asp:TextBox>
                            </td>
                            <td class="lmf_padding">
                                审核状态：
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListIsAudit" runat="server" CssClass="tselect" Width="201">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" Text="查询" OnClick="ButtonSearch_Click"
                                    CssClass="dele" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonAudit" runat="server" CssClass="shtg lmf_btn" OnClientClick=" return EditButton(); "
                                    OnClick="ButtonAudit_Click">
                                            <span>审核通过</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonCancelAudit" runat="server" CssClass="shwtg lmf_btn" OnClientClick=" return EditButton(); "
                                    OnClick="ButtonCancelAudit_Click">
                                            <span>审核未通过</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" CausesValidation="False" OnClientClick=" return DeleteButton(); "
                                    OnClick="ButtonDelete_Click" CssClass="shanchu lmf_btn">
                                            <span>批量删除</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
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
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="保障名称" DataField="Name" SortExpression="Name" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="申请店铺" SortExpression="ShopID">
                        <ItemTemplate>
                            <%--    <a href='<%#ShopUrlOperate.shopHref(Eval("ShopID").ToString())%>' target="_blank">--%>
                            <asp:Label ID="LabelShopID" runat="server" Text='<%# Eval("ShopID") %>'></asp:Label></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ApplyTime" HeaderText="申请时间" SortExpression="ApplyTime"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="PaymentName" HeaderText="支付方式" SortExpression="PaymentName"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="支付状态" SortExpression="IsPayMent">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("IsPayMent").ToString() == "1" ? "已支付" : "未支付" %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="是否审核" SortExpression="IsAudit">
                        <ItemTemplate>
                            <asp:Label ID="IsAudit" runat="server" Text='<%# IsAudit(Eval("IsAudit")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Remarks" HeaderText="备注" SortExpression="Remarks" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="操作" SortExpression="IsShow">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid") %>'
                                OnClientClick=" return window.confirm('您确定要删除吗?'); " OnClick="ButtonDeleteBylink_Click">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SearchEnsureApply_List"
        TypeName="ShopNum1.ShopBusinessLogic.Shop_Ensure_Action" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxName" Name="name" PropertyName="Text" Type="String"
                DefaultValue="" />
            <asp:ControlParameter ControlID="DropDownListIsAudit" Name="isAudit" PropertyName="SelectedValue"
                Type="String" DefaultValue="-1" />
            <asp:ControlParameter ControlID="TextBoxShopID" Name="shopid" PropertyName="Text"
                Type="String" DefaultValue="" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>
</body>
</html>
