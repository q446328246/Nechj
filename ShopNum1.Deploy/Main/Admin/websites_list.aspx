<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="websites_list.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.websites_list" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>站群列表</title>
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
                    站群设置</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            <asp:Label ID="LabelName" runat="server" Text="地区："></asp:Label>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DropDownListProductGuid1" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="DropDownListProductGuid1_SelectedIndexChanged" CssClass="tselect"
                                        Width="100">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListProductGuid2" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="DropDownListProductGuid2_SelectedIndexChanged" CssClass="tselect"
                                        Width="100">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListProductGuid3" runat="server" CssClass="tselect"
                                        Width="100">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:Button ID="ButtonSearch" runat="server" CssClass="dele" Text="搜索" OnClick="ButtonSearch_Click" />
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonInsert" runat="server" OnClick="ButtonInsert_Click" class="tianjia2 lmf_btn"><span>添加</span></asp:LinkButton>
                                <%--<asp:Button ID="ButtonInsert" runat="server" Text="添加" CssClass="tianjia2 picbtn" OnClick="ButtonInsert_Click" />--%>
                                <asp:Button ID="ButtonUpdata" runat="server" Text="编辑" CssClass="dele" OnClientClick=" return EditButton() "
                                    OnClick="ButtonUpdata_Click" Visible="false" />
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDel" runat="server" OnClick="ButtonDel_Click" OnClientClick=" return DeleteButton() "
                                    class="shanchu lmf_btn"><span>批量删除</span></asp:LinkButton>
                                <%--  <asp:Button ID="ButtonDel" runat="server" Text="批量删除" CssClass="shanchu com" OnClientClick="return DeleteOneButton()"
                    OnClick="ButtonDel_Click" />--%>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceDate" AllowMultiColumnSorting="False"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4"
                GridLines="Vertical">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--分页--%>
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("ID") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                        <HeaderStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="addressName" HeaderText="地区" SortExpression="addressName"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="domain" HeaderText="域名" SortExpression="domain" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" src='<%# GetListImageStatus(Eval("isAvailable").ToString()) %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" SortExpression="IsShow">
                        <ItemTemplate>
                            <a href="<%# "websites_Operate.aspx?ID=" + Eval("ID") %>" style="color: #4482b4;">查看</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" OnClick="ButtonDeleteBylink_Click"
                                CommandArgument='<%# Eval("ID") %>' OnClientClick=" return window.confirm('您确定要删除吗?'); ">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <div id="objDiv">
            <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="WebSiteGet"
                TypeName="ShopNum1.BusinessLogic.ShopNum1_WebSite_Action">
                <SelectParameters>
                    <asp:ControlParameter ControlID="HiddenFieldCode" Name="addressCode" PropertyName="Value"
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
    </div>
    </form>
</body>
</html>
