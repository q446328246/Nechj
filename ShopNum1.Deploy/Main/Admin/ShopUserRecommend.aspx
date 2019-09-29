<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopUserRecommend.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.ShopUserRecommend" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员留言</title>
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
                    会员留言</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                        <td valign="top" class="lmf_app">
                       会员ID：
                        </td>
                            <td valign="top" class="lmf_app">
                            <input type="text" id="txtMemLoginID"  class="tinput"
                                style="width: 200px;"  runat="server" />
                            </td>
                            <td style="text-align: right;">
                            <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="查询"
                                            CssClass="dele" />
                        </td>
                            </tr>
                    <tr>
<%--                        <td valign="top" >
                            <asp:LinkButton ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" OnClientClick=" GetCheckedBoxValues() "
                                CausesValidation="False" CssClass="tianjiafl lmf_btn"><span>添加会员</span></asp:LinkButton>
                        </td>--%>
                        
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
            <cc1:num1gridview id="Num1GridviewShow" runat="server" autogeneratecolumns="False"
                allowpaging="True" allowsorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" addsequencecolumn="False" width="98%"
                del="False" deleteprompttext="确实要删除指定的记录吗？" edit="False" fixheader="False" gridviewsortdirection="Ascending"
                pagingstyle="None" tablename="" datasourceid="ObjectDataSourceDate" allowmulticolumnsorting="False"
                backcolor="White" bordercolor="#DEDFDE" borderstyle="None" borderwidth="1px"
                cellpadding="4" gridlines="Vertical" EnableModelValidation="True">
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                        <%--分页--%>
                        <PagerStyle CssClass="lmf_page"  BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                                </HeaderTemplate>
                                <HeaderStyle CssClass="select_width" />

                                <ItemTemplate>
                                    <input id="checkboxItem" value='<%# Eval("Mid") %>' type="checkbox" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Mname" HeaderText="会员ID" SortExpression="Mname">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="留言信息" DataField="MMessage" SortExpression="MMessage">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                             <asp:BoundField HeaderText="电话" DataField="mobile" SortExpression="mobile">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="创建时间" DataField="Mcreate" SortExpression="Mcreate">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                            
<%--                            <asp:TemplateField HeaderText="操作" SortExpression="IsShow">
                                <ItemTemplate>
                                    <a href="<%# "ShopUserRecommendBind.aspx?memloginid=" + Eval("MemLoginID") %>" style="color: #4482b4;">
                                        推荐商品</a>
                                    <asp:LinkButton ID="LinkAdd" runat="server" OnClick="LinkAdd_Click" Style="color: #4482b4;"  CommandArgument='<%# Eval("MemLoginID") %>' OnClientClick=" return window.confirm('您确定结算吗?'); ">结算福利</asp:LinkButton>

                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:TemplateField>--%>
                        </Columns>
                    </cc1:num1gridview>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="Search"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_ShopUserRecommend_Action">
            <SelectParameters>
                <asp:Parameter Name="memLoginID" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="Mid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
