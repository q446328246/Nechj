<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopAmountReport.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopAmountReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>店铺销售排行</title>
    <link type="text/css" rel="Stylesheet" href="css/index.css" />
</head>
<body style="background-image: url(images/Bg_right.gif); background-repeat: repeat;
    padding: 0;">
    <form id="form1" runat="server">
    <div class="navigator">
        【店铺销售排行】</div>
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"
        runat="server">
    </asp:ScriptManager>
    <div class="query">
        <table style="width: 100%">
            <tr>
                <td align="right" style="width: 20%;">
                    时间段查询:
                </td>
                <td align="left">
                    <asp:TextBox ID="TextBoxStartDate" runat="server" CssClass="allinput1"></asp:TextBox>
                    <img id="imgCalendarSReplyTime1" alt="UserName" src="/ImgUpload/Calendar.png" style="height: 18px;
                        position: relative; top: 4px; top: 4px; width: 16px;" /><asp:RegularExpressionValidator
                            ID="RegularExpressionValidatorStartDate" runat="server" ControlToValidate="TextBoxStartDate"
                            Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                    &nbsp;<t:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxStartDate"
                        PopupButtonID="imgCalendarSReplyTime1" CssClass="ajax__calendar" />
                    -<asp:TextBox ID="TextBoxEndDate" runat="server" CssClass="allinput1"></asp:TextBox>
                    <img id="imgCalendarSReplyTime2" alt="UserName" src="/ImgUpload/Calendar.png" style="height: 18px;
                        position: relative; top: 4px; top: 4px; width: 16px;" /><asp:RegularExpressionValidator
                            ID="RegularExpressionValidatorStartDate0" runat="server" ControlToValidate="TextBoxEndDate"
                            Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                    &nbsp;<t:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxEndDate"
                        PopupButtonID="imgCalendarSReplyTime2" CssClass="ajax__calendar" />
                </td>
                <td align="left">
                    <asp:Button ID="ButtonSearch" runat="server" Text="搜索" CssClass="bt2" OnClick="ButtonSearch_Click"
                        UseSubmitBehavior="false" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="ButtonReport" runat="server" OnClick="ButtonReport_Click" Text="导出到Excel"
                        CausesValidation="False" CssClass="bt3" />
                    &nbsp;
                    <asp:Button ID="ButtonHtml" runat="server" CausesValidation="False" CssClass="bt3"
                        OnClientClick=" javascript:document.getElementById('form1').target = '_blank';window.location.href = window.location.href; "
                        OnClick="ButtonHtml_Click" Text="导出到Html" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" DataSourceID="ObjectDataSourceData"
            AddSequenceColumn="False" AllowMultiColumnSorting="False" AutoGenerateColumns="False"
            BorderColor="#CCDDEF" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Del="False"
            DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
            PagingStyle="None" Style="margin-left: 2px;" TableName="" Width="99%">
            <HeaderStyle HorizontalAlign="Center" BackColor="#6699CC" Font-Bold="True" ForeColor="#FFFFFF">
            </HeaderStyle>
            <PagerStyle HorizontalAlign="Left" BackColor="#EEEEEE" ForeColor="#6699CC"></PagerStyle>
            <Columns>
                <asp:BoundField DataField="MemLoginID" HeaderText="店主" SortExpression="MemLoginID">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ShopName" HeaderText="店铺名称" SortExpression="ShopName">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="OrderNum" HeaderText="数量" SortExpression="OrderNum">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Amount" HeaderText="交易金额" SortExpression="Amount">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
        </ShopNum1:Num1GridView>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SearchShopAmount"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_ShopInfoList_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxStartDate" DefaultValue="-1" Name="startdate"
                PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="TextBoxEndDate" DefaultValue="-1" Name="enddate"
                PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>
</body>
</html>
