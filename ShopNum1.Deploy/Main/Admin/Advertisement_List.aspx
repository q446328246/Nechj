<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advertisement_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Advertisement_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>广告列表</title>
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
                    广告列表</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td style="display: none">
                            页面名：
                        </td>
                        <td style="display: none">
                            <asp:TextBox ID="TextBoxPageName" runat="server" CssClass="tinput"></asp:TextBox>
                        </td>
                        <td class="lmf_padding" style="display: none">
                            文件名：
                        </td>
                        <td style="display: none">
                            <asp:DropDownList ID="DropDownListFileName" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                        <td>
                            广告位ID：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxdivid" runat="server" CssClass="tinput"></asp:TextBox>
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
                                <asp:LinkButton ID="ButtonAdd" runat="server" CausesValidation="False" OnClick="ButtonAdd_Click"
                                    CssClass="tianjia2 lmf_btn" Visible="false">
                                            <span>添加</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonEdit" runat="server" CausesValidation="False" OnClientClick=" return EditButton() "
                                    OnClick="ButtonEdit_Click" CssClass="bji lmf_btn" Visible="false"><span>编辑</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" CausesValidation="False" OnClientClick=" return DeleteButton() "
                                    OnClick="ButtonDelete_Click" CssClass="shanchu lmf_btn" Visible="false"><span>批量删除</span></asp:LinkButton>
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
                            <input id="checkboxItem" type="checkbox" value='<%# Eval("guid") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="divid" SortExpression="divid" HeaderText="广告位ID" />
                    <asp:BoundField DataField="pagename" SortExpression="pagename" HeaderText="页面名" Visible="false" />
                    <asp:BoundField DataField="explain" SortExpression="explain" HeaderText="说明" />
                    <asp:BoundField DataField="filename" SortExpression="filename" HeaderText="文件名" Visible="false" />
                    <asp:TemplateField SortExpression="type" HeaderText="类型">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# AdType(Eval("type")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="href" SortExpression="href" HeaderText="链接地址" />
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href="<%# "Advertisement_Operate.aspx?guid=" + Eval("guid") %>" style="color: #4482b4;">
                                编辑</a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search1"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_Advertisement_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBoxdivid" Name="pagename" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListFileName" Name="fileName" PropertyName="SelectedValue"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
