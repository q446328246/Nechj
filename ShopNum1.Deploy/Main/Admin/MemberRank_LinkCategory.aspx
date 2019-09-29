<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberRank_LinkCategory.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.MemberRank_LinkCategory" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>专区绑定</title>
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
                    会员绑定</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <cc1:num1gridview id="Num1GridviewShow" runat="server" autogeneratecolumns="False"
                allowpaging="True" allowsorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" addsequencecolumn="False" width="98%"
                del="False" deleteprompttext="确实要删除指定的记录吗？" edit="False" fixheader="False" gridviewsortdirection="Ascending"
                pagingstyle="None" tablename="" datasourceid="ObjectDataSourceDate" allowmulticolumnsorting="False"
                backcolor="White" bordercolor="#DEDFDE" borderstyle="None" borderwidth="1px"
                cellpadding="4" gridlines="Vertical">
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                        <%--分页--%>
                        <PagerStyle CssClass="lmf_page"  BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="等级名称" SortExpression="Name">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="创建者" DataField="CreateUser" SortExpression="CreateUser">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="创建时间" DataField="CreateTime" SortExpression="CreateTime">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="操作" SortExpression="IsShow">
                                <ItemTemplate>
                                    <a href="<%# "MemberRank_BindCategories.aspx?guid="  + Eval("Guid") + "&&right=1" %>" style="color: #4482b4;">
                                        绑定可缆专区</a>
                                    <a href="<%# "MemberRank_BindCategories.aspx?guid="  + Eval("Guid") + "&&right=2" %>" style="color: #4482b4;">
                                        绑定可买专区</a>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:TemplateField>
                        </Columns>
                    </cc1:num1gridview>
            
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="Search"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_MemberRank_Action">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="isDeleted" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
