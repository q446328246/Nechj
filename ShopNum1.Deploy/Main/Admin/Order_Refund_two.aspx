<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order_Refund_two.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Order_Refund_two" %>
<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="t" %>
<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>申请退款的列表（需要客服审核）</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
    <script type='text/javascript' src='js/resolution-test.js'></script>
    <script src="/Main/js/location.js" type="text/javascript"></script>
    <script src="/Main/js/areas.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    
        <div class="welcon clearfix">
            <div class="order_edit">
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top" style="text-align: right;">
                                订单编号：
                            </td>
                            <td valign="top" class="lmf_app">
                                <input type="text" id="txtMemLoginID" class="tinput" style="width: 200px;" runat="server" />
                            </td>
                            
                            <td style="text-align: left;">
                                <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="查询"
                                    CssClass="dele" />
                            </td>
                        </tr>
                        
                        
                    </table>
                </div>
            </div>
            <cc1:Num1GridView ID="ShipNum1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" AllowMultiColumnSorting="False"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" GridLines="Vertical" EnableModelValidation="True" OnPageIndexChanging="ShipNum1GridViewShow_click">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--分页--%>
                <PagerStyle CssClass="lmf_page" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    
                    <asp:TemplateField  HeaderText="订单ID">
                    <ItemTemplate>
                    <%# Eval("OrderNumber")%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  HeaderText="付款人ID">
                    <ItemTemplate>
                    <%# Eval("MemLoginID")%>
                    </ItemTemplate>
                    </asp:TemplateField>
               
                   
                    <asp:TemplateField HeaderText="操作" >
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkPass" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("OrderNumber") %>'
                                OnClientClick=" return window.confirm('您确定要审批通过吗?'); " OnClick="ButtonPassByShip_Click">审核</asp:LinkButton>
                            
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </cc1:Num1GridView>

        </div>
        <
        <asp:HiddenField ID="CheckShipID" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
