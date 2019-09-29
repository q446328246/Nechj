<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="SellOrder.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.SellOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
                    销售排行</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <div style="height: 35px; vertical-align: top;">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td>
                                商品名称：
                            </td>
                            <td>
                                <asp:TextBox ID="txtPName" runat="server" CssClass="tinput" Width="111"></asp:TextBox>
                            </td>
                            <td class="lmf_px">
                                &nbsp;&nbsp;&nbsp;店铺名称：
                            </td>
                            <td>
                                <asp:TextBox ID="txtSName" runat="server" CssClass="tinput" Width="111"></asp:TextBox>
                            </td>
                            <td class="lmf_px" style="display: none">
                                购买时间：
                            </td>
                            <td style="display: none">
                                <asp:TextBox ID="TextBoxSDispatchTime1" runat="server" CssClass="tinput" Width="111"></asp:TextBox>
                            </td>
                            <td style="display: none">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate" runat="server"
                                    ControlToValidate="TextBoxSDispatchTime1" Display="Dynamic" ErrorMessage="时间格式不正确"
                                    ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                            </td>
                            <td style="display: none">
                                <ShopNum1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"
                                    EnableScriptLocalization="True">
                                </ShopNum1:ToolkitScriptManager>
                            </td>
                            <td style="display: none; padding-left: 4px; vertical-align: top;">
                                <img id="imgCalendarStartTime" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                    position: relative; top: 3px; width: 16px;" />
                            </td>
                            <td style="display: none">
                                <ShopNum1:CalendarExtender ID="imgCalendarStartTime1" runat="server" TargetControlID="TextBoxSDispatchTime1"
                                    PopupButtonID="imgCalendarStartTime" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                </ShopNum1:CalendarExtender>
                            </td>
                            <td class="lmf_px" style="display: none">
                                -
                            </td>
                            <td style="display: none">
                                <asp:TextBox ID="TextBoxSDispatchTime2" runat="server" CssClass="tinput" Width="111"></asp:TextBox>
                            </td>
                            <td style="display: none">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxSDispatchTime2"
                                    Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                            </td>
                            <td style="display: none; padding-left: 4px; vertical-align: top;">
                                <img id="imgCalendarEndTime" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                    position: relative; top: 3px; width: 16px;" />
                            </td>
                            <td style="display: none">
                                <ShopNum1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxSDispatchTime2"
                                    PopupButtonID="imgCalendarEndTime" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                </ShopNum1:CalendarExtender>
                            </td>
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="查询"
                                    CssClass="dele" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonReport" runat="server" OnClick="ButtonReport_Click" CausesValidation="False"
                                    class="daochubtn lmf_btn"><span>导出到Excel</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonHtml" runat="server" CausesValidation="False" OnClick="ButtonHtml_Click"
                                    OnClientClick=" javascript:document.getElementById('form1').target = '_blank';window.location.href = window.location.href; "
                                    class="daochubtn lmf_btn"><span>导出到Html</span></asp:LinkButton>
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
                    <asp:BoundField DataField="ProductName" HeaderText="商品名称" SortExpression="ProductName">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ShopName" HeaderText="店铺名称" SortExpression="ShopName">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="销售数量" DataField="BuyNumber" SortExpression="BuyNumber">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="销售额" DataField="BuyPrice" SortExpression="BuyPrice">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="均价" DataField="AveragePrice" SortExpression="AveragePrice">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <%--<input ID="checkboxItem"   onclick="GetItmeValue(this)" type="checkbox" />--%>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SearchSellOrder"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_Report_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtPName" Name="Name" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtSName" Name="shopname" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="TextBoxSDispatchTime1" Name="dispatchTime1" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxSDispatchTime2" Name="dispatchTime2" PropertyName="Text"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid1" runat="server" Value="0" />
        <asp:HiddenField ID="CheckGuid2" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
