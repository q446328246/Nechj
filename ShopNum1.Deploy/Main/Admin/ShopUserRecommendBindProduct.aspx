<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopUserRecommendBindProduct.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.ShopUserRecommendBindProduct" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>已绑定商品列表</title>
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
                    会员：<asp:Label runat="server" ID="lablehead" 
                        style="color:red" ></asp:Label>
                    已绑定的推荐商品</h3>
            </div>
            <div class="rr">
            </div>
        </div>
         <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
               
                    <tr>
                        
                        
                        <td valign="top" class="lmf_app">
                            <asp:LinkButton ID="ButtonDelete" runat="server"  OnClientClick=" return DeleteButton() "
                                    CausesValidation="False" CssClass="shanchu lmf_btn" 
                                onclick="ButtonDelete_Click"><span>批量删除</span></asp:LinkButton>
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
                                    <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ProductID" HeaderText="商品ID" SortExpression="ProductID">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="商品名称" DataField="Name" SortExpression="Name">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="绑定时间" DataField="ProduactBindDate" SortExpression="ProduactBindDate">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="结算时间" DataField="LastSettlementDate" SortExpression="LastSettlementDate">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            
                            <asp:TemplateField HeaderText="操作" SortExpression="IsShow">
                                <ItemTemplate>
                                    
                                    <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid") %>' OnClientClick=" return window.confirm('您确定要删除吗?'); " OnClick="LinkButtonDelete_Click">删除</asp:LinkButton>
                                                    <%-- OnClick="ButtonDeleteBylink_Click"--%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:TemplateField>
                        </Columns>
                    </cc1:num1gridview>
        </div>
         <div class="tablebtn">
               
                <asp:Button ID="ButtonBindProduct" runat="server" CssClass="fanh" 
                    onclick="ButtonBindProduct_Click" Text="返回" />
                
            </div>
        <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="SearchBindProduct"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_ShopUserRecommend_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="CheckMemid" Name="memLoginID" 
                    PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        <br />
        <asp:HiddenField ID="CheckMemid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>

