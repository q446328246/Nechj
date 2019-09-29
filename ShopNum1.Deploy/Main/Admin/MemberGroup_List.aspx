<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="MemberGroup_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.MemberGroup_List" %>
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
<head id="Head1" runat="server">
    <title>会员组管理</title>
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
                    会员组管理</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="添加" OnClientClick=" GetCheckedBoxValues() "
                    CssClass="addcate" />
                <asp:Button ID="ButtonEdit" runat="server" OnClick="ButtonEdit_Click" OnClientClick=" return EditButton() "
                    Text="编辑" CssClass="dele" Visible="false" />
                <asp:Button ID="ButtonDelete" runat="server" Text="批量删除" OnClientClick=" return DeleteButton() "
                    OnClick="ButtonDelete_Click" CssClass="shanchu com" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
            <cc1:num1gridview id="Num1GridViewShow" runat="server" autogeneratecolumns="False"
                allowpaging="True" allowsorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" addsequencecolumn="False" width="98%"
                del="False" deleteprompttext="确实要删除指定的记录吗？" edit="False" fixheader="False" gridviewsortdirection="Ascending"
                pagingstyle="None" tablename="" datasourceid="ObjectDataSourceData" allowmulticolumnsorting="False"
                backcolor="White" bordercolor="#DEDFDE" borderstyle="None" borderwidth="0" cellpadding="4"
                gridlines="Vertical">
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
                                <ItemTemplate>
                                    <%--                   <input ID="checkboxItem"   onclick="GetItmeValue(this)" type="checkbox" />--%>
                                    <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" />
                            <asp:BoundField DataField="Name" HeaderText="分组名称" SortExpression="Name" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="分组描述" DataField="Description" SortExpression="Description"
                                            ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                            <asp:TemplateField HeaderText="操作" SortExpression="IsShow">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkEdite" runat="server" Style="color: #4482b4;" OnClick="ButtonEdit_Click"
                                                    OnClientClick=" return EditButton() ">查看</asp:LinkButton>
                                    <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" OnClick="ButtonDelete_Click"
                                                    OnClientClick=" return DeleteButton() ">删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:TemplateField>
                        </Columns>
                    </cc1:num1gridview>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SearchMemberGroup"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_Member_Action">
            <SelectParameters>
                <asp:Parameter DefaultValue="-1" Name="guid" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
