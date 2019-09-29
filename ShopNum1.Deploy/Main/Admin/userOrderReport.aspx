﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userOrderReport.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.userOrderReport" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>订单详情</title>
        <link rel="stylesheet" type="text/css" href="style/css.css" />

        <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>

    </head>
    <body>
        <form id="form1" runat="server">
   `    <!--    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"
                               runat="server">
            </asp:ScriptManager>-->

            <div id="right">
                <div class="rhigth">
                    <div class="rl">
                    </div>
                    <div class="rcon">
                        <h3>
                            订单详情</h3>
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
                                        收货人：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtperson" runat="server" CssClass="tinput" Width="111"></asp:TextBox>
                                    </td>
                                 
                                    <td class="lmf_padding">
                                        时间：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxStartDate" runat="server" CssClass="tinput" Width="111"></asp:TextBox>
                                    </td>
                                    <td style="padding-left: 4px; vertical-align: top;">
                                        <img id="imgCalendarSReplyTime1" alt="UserName" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative; top: 3px; width: 16px;" />
                                    </td>
                                    <td>
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate" runat="server"
                                                                        ControlToValidate="TextBoxStartDate" Display="Dynamic" ErrorMessage="时间格式不正确"
                                                                        ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <t:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxStartDate"
                                                                   PopupButtonID="imgCalendarSReplyTime1" CssClass="ajax__calendar" />
                                    </td>
                                    <td class="lmf_px">
                                        -
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxEndDate" runat="server" CssClass="tinput" Width="111"></asp:TextBox>
                                    </td>
                                    <td style="padding-left: 4px; vertical-align: top;">
                                        <img id="imgCalendarSReplyTime2" alt="UserName" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative; top: 3px; width: 16px;" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEndDate"
                                                                        Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <t:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxEndDate"
                                                                   PopupButtonID="imgCalendarSReplyTime2" CssClass="ajax__calendar" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonSearch" runat="server" Text="搜索" CssClass="dele" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="sbtn">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td valign="top">
                                        <asp:LinkButton ID="ButtonReport" runat="server" OnClick="ButtonReport_Click"  CausesValidation="False"
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
                            <asp:BoundField DataField="OrderNumber" HeaderText="订单号" SortExpression="OrderNumber">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="收货人" SortExpression="Name">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Address" HeaderText="收获地址" SortExpression="Address">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                             <asp:BoundField DataField="Mobile" HeaderText="电话号码" SortExpression="Mobile">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                             <asp:BoundField DataField="ConfirmTime" HeaderText="确认时间" SortExpression="ConfirmTime">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                    </ShopNum1:Num1GridView>
                </div>
                <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SearchOrderInfos"
                                      TypeName="ShopNum1.BusinessLogic.ShopNum1_OrderInfo_Action">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtperson" Name="personname"
                                              PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="TextBoxStartDate" DefaultValue="" Name="startdate"
                                              PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="TextBoxEndDate" DefaultValue="" Name="enddate"
                                              PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>

            </div>
        </form>
    </body>
</html>
