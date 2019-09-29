<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="OperateLog_Manage.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.OperateLog_Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>日志记录</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
</head>
<body class="widthah">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"
        runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    日志记录</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <div>
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr style="height: 35px; vertical-align: top;">
                            <td>
                                <asp:Label ID="lblOperatorID" runat="server" Text="操作者："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="textBoxOperatorID" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                            </td>
                            <td class="lmf_padding">
                                <asp:Label ID="lblIP" runat="server" Text="操作IP："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="textBoxIP" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                            </td>
                            <td class="lmf_padding">
                                <asp:Label ID="lbDate" runat="server" Text="操作日期："></asp:Label>
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="textBoxStartTime" CssClass="tinput" Width="66" runat="server"></asp:TextBox>
                                        </td>
                                        <td style="padding-left: 4px; vertical-align: top;">
                                            <img id="img2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative;
                                                top: 3px; width: 16px;" />
                                        </td>
                                        <td>
                                            <t:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="textBoxStartTime"
                                                PopupButtonID="img2" CssClass="ajax__calendar" />
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="textBoxStartTime"
                                                Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td class="lmf_px">
                                            -
                                        </td>
                                        <td>
                                            <asp:TextBox ID="textEndTime" runat="server" CssClass="tinput" Width="66"></asp:TextBox>
                                        </td>
                                        <td style="padding-left: 4px; vertical-align: top;">
                                            <img id="img3" alt="" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative;
                                                top: 3px; width: 16px;" />
                                        </td>
                                        <td>
                                            <t:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="textEndTime"
                                                PopupButtonID="img3" CssClass="ajax__calendar" />
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="textEndTime"
                                                Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" Text="查询" OnClick="ButtonSearch_Click"
                                    CssClass="dele" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="sbtn">
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td style="display: none;">
                                <asp:Label ID="Label1" runat="server" Text="时间查询："></asp:Label>
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td style="display: none;">
                                            <asp:TextBox ID="textBoxDeleteStartTime" runat="server" CssClass="tinput" Style="width: 58px;"></asp:TextBox>
                                        </td>
                                        <td style="display: none; padding-left: 4px; vertical-align: top;">
                                            <img id="imgCalendarSReplyTime3" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                                position: relative; top: 3px; width: 16px;" />
                                        </td>
                                        <td style="display: none;">
                                            <t:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="textBoxDeleteStartTime"
                                                PopupButtonID="imgCalendarSReplyTime3" CssClass="ajax__calendar" />
                                        </td>
                                        <td style="display: none;">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxTime2" runat="server"
                                                ControlToValidate="textBoxDeleteStartTime" Display="Dynamic" ErrorMessage="时间格式不正确"
                                                ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td class="lmf_px" style="display: none;">
                                            -
                                        </td>
                                        <td style="display: none;">
                                            <asp:TextBox ID="textDeleteEndTime" runat="server" CssClass="tinput" Style="width: 58px;"></asp:TextBox>
                                        </td>
                                        <td style="display: none; padding-left: 4px; vertical-align: top;">
                                            <img id="img1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative;
                                                top: 3px; width: 16px;" />
                                        </td>
                                        <td style="display: none;">
                                            <t:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="textDeleteEndTime"
                                                PopupButtonID="img1" CssClass="ajax__calendar" />
                                        </td>
                                        <td style="display: none;">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="textDeleteEndTime"
                                                Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td style="display: none; padding-left: 10px;">
                                            <asp:Button ID="ButtonDeleteAll" runat="server" OnClick="ButtonDeleteAll_Click" Text="时间删除"
                                                CssClass="shanchu com" />
                                        </td>
                                        <td valign="top">
                                            <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" CssClass="shanchu lmf_btn"
                                                OnClientClick=" return DeleteButton() ">
                                                        <span>批量删除</span></asp:LinkButton>
                                        </td>
                                        <td valign="top" class="lmf_app">
                                            <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="num1GridViewShow" runat="server" AutoGenerateColumns="False"
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
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" type="checkbox" onclick=" javascript: SelectAllCheckboxes(this); " />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="OperatorID" HeaderText="操作者" SortExpression="OperatorID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PageName" HeaderText="操作页面" SortExpression="PageName">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Date" HeaderText="操作日期" SortExpression="Date">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Record" HeaderText="操作记录" SortExpression="Record">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IP" HeaderText="操作IP" SortExpression="IP">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="操作" SortExpression="IsShow">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid") %>'
                                OnClientClick=" return window.confirm('您确定要删除吗?'); " OnClick="ButtonDeleteBylink_Click">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_OperateLog_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="textBoxOperatorID" Name="OperatorID" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="textBoxIP" Name="IP" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="textBoxStartTime" Name="StartDate" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="textEndTime" Name="EndDate" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldAgentID" runat="server" />
    <%--<cc2:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </cc2:ToolkitScriptManager>--%>
    </form>
</body>
</html>
