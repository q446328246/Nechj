<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RexodMemberLogo.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.RexodMemberLogo" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>团队领导人记录</title>
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
                    团队领导人记录</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td class="lmf_padding">
                            <asp:Label ID="LabelSMemLoginNO" runat="server" Text="用户编号："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxMemLoginNO" runat="server" CssClass="tinput" Width="150px"></asp:TextBox>
                        </td>
                        
                        <td class="lmf_padding">
                            <asp:Label ID="LabelSDate" runat="server" Text="结算日期："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSDate1" runat="server" CssClass="tinput_data"></asp:TextBox>
                        </td>
                        <td style="padding-left: 4px; vertical-align: top;">
                            <img id="imgCalendarSDate1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                position: relative; top: 3px; width: 16px;" />
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate" runat="server"
                                ControlToValidate="TextBoxSDate1" Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                        </td>
                        <td>
                            <ShopNum1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"
                                EnableScriptLocalization="True">
                            </ShopNum1:ToolkitScriptManager>
                        </td>
                        <td>
                            <ShopNum1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxSDate1"
                                PopupButtonID="imgCalendarSDate1" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                            </ShopNum1:CalendarExtender>
                        </td>
                        <td class="lmf_px">
                            -
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSDate2" runat="server" CssClass="tinput_data"></asp:TextBox>
                        </td>
                        <td style="padding-left: 4px; vertical-align: top;">
                            <img id="imgCalendarSDate2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                position: relative; top: 3px; width: 16px;" />
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEndDate" runat="server"
                                ControlToValidate="TextBoxSDate2" Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                        </td>
                        <td>
                            <ShopNum1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxSDate2"
                                PopupButtonID="imgCalendarSDate2" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                            </ShopNum1:CalendarExtender>
                        </td>
                        <td>
                            <asp:Button ID="ButtonSearch" runat="server" Text="查询" OnClick="ButtonSearch_Click"
                                CssClass="dele" />
                        </td>
                    </tr>
                   
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                          
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonReportAll" OnClick="ButtonReportAll_Click" runat="server"
                                    CausesValidation="False" CssClass="daochubtn lmf_btn"><span>导出全部</span></asp:LinkButton>
                                    
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </td>
                          
                        </tr>
                    </table>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False"  Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="Default" TableName="" DataSourceID="ObjectDataSourceData" AllowMultiColumnSorting="False" 
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
                BorderWidth="0px" CellPadding="4"
                GridLines="Vertical" EnableModelValidation="True">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--分页--%>
                <PagerStyle CssClass="lmf_page" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                   
                    <asp:BoundField DataField="MemberLoginID" HeaderText="MemberLoginID" Visible="False" />
                    <asp:BoundField DataField="MemberLoginID" HeaderText="用户编号" SortExpression="MemLoginID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="OldRcodMember" HeaderText="原来团队领导人" SortExpression="RealName">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NewRcodMember" HeaderText="当前团队领导人" SortExpression="CreateTime">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CreateTime" HeaderText="记录时间" SortExpression="Bonus1">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    

                   
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SelectRcodMemBerLogo"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_AdvancePaymentApplyLog_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBoxMemLoginNO" Name="MemLoginID" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxSDate1" Name="date1" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxSDate2" Name="date2" PropertyName="Text"
                    Type="String" />
                    <asp:ControlParameter ControlID="TextIsadmin" DefaultValue="0" Name="isadmin"  Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
           <asp:HiddenField ID="TextIsadmin" runat="server" Value="0" />
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
