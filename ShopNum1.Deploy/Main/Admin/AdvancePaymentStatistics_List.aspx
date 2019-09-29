<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvancePaymentStatistics_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.AdvancePaymentStatistics_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员兑换额（PV）统计</title>
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
                    会员兑换额（PV）统计</h3>
            </div>
            <div class="rr">
            </div>

        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            <asp:Label ID="LabelSMemLoginID" runat="server" Text="会员ID："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSMemLoginID" runat="server" CssClass="tinput" Width="200px"></asp:TextBox>
                        </td>
                        <td style="width: 30px">
                            
                        </td>
                         <%--<td>
                            <asp:Label ID="LabelOperateType" runat="server" Text="资金选择："></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropdownListSOperateType"  runat="server" Width="201px" CssClass="tselect">
                                    <asp:ListItem Value="1" Selected="True">-BV-</asp:ListItem>
                                    <asp:ListItem Value="2">RV</asp:ListItem>
                                    <asp:ListItem Value="3">DV</asp:ListItem>
                                   </asp:DropDownList>
                        </td>--%>
                        <td>
                            <asp:Button ID="ButtonSearch" runat="server" Text="查询" OnClick="ButtonSearch_Click"
                                CssClass="dele" />
                        </td>
                    </tr>
                </table>
<%--                <div style="width: 100%;">
                    当前会员累计金额【￥<asp:Label ID="LabelMoney" runat="server" Text="" ForeColor="Red"></asp:Label>】,
                    会员兑换额（PV）统计累计金额【￥<asp:Label ID="LabelLockAdvancePayment" runat="server" Text="" ForeColor="Red"></asp:Label>】
                </div>
                <div>
                    <asp:LinkButton ID="ButtonReport" runat="server" OnClick="ButtonReport_Click" CausesValidation="False"
                        CssClass="daochubtn lmf_btn"><span>导出当前数据</span></asp:LinkButton>
                </div>--%>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceData" AllowMultiColumnSorting="False"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
                BorderWidth="0px" CellPadding="4"
                GridLines="Vertical" EnableModelValidation="True">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--分页--%>
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="MemLoginID" HeaderText="会员ID" SortExpression="MemLoginID"
                        ItemStyle-Width="160">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="num1" HeaderText="兑换额" ItemStyle-Width="160">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="num2345" HeaderText="流通额" ItemStyle-Width="160">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Allnum" HeaderText="pv总和" ItemStyle-Width="160">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CreateTime" HeaderText="时间" ItemStyle-Width="160">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SearchPV"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_Member_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBoxSMemLoginID" Name="MemLoginID" PropertyName="Text"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
