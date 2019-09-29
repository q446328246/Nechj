<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvancePaymentFreezeOperate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.AdvancePaymentFreezeOperate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>冻结金币（BV）列表</title>
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
                    冻结金币（BV）</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit" style="display: none;">
                <div style="margin-bottom: 10px;">
                    <table border="0" cellspacing="0" cellpadding="0" style="margin-bottom: 7px;">
                        <tr>
                            <td width="60" style="padding-right: 5px; text-align: right;">
                                <asp:Label ID="LabelSDate" runat="server" Text="冻结日期："></asp:Label>
                            </td>
                            <td width="330">
                                <asp:TextBox ID="TextBoxSDate1" runat="server" CssClass="tinput" Width="100px"></asp:TextBox>
                                <img id="imgCalendarSDate1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                    width: 16px;" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorSDate1" runat="server"
                                    ControlToValidate="TextBoxSDate1" Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                                <ShopNum1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"
                                    EnableScriptLocalization="True">
                                </ShopNum1:ToolkitScriptManager>
                                <ShopNum1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxSDate1"
                                    PopupButtonID="imgCalendarSDate1" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                </ShopNum1:CalendarExtender>
                                -<asp:TextBox ID="TextBoxSDate2" runat="server" CssClass="tinput" Width="100px"></asp:TextBox>
                                <img id="imgCalendarSDate2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                    width: 16px;" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorSDate2" runat="server"
                                    ControlToValidate="TextBoxSDate2" Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="CompareValidatorTextBoxSDate2" runat="server" ErrorMessage="开始时间应当早于结束时间"
                                    Type="Date" Display="Dynamic" ControlToValidate="TextBoxSDate2" ControlToCompare="TextBoxSDate1"
                                    Operator="GreaterThan"></asp:CompareValidator>
                                <ShopNum1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxSDate2"
                                    PopupButtonID="imgCalendarSDate2" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                </ShopNum1:CalendarExtender>
                            </td>
                            <td width="70" style="padding-right: 5px; text-align: right;">
                                <asp:Label ID="LabelSOperateType" runat="server" Text="冻结类型："></asp:Label>
                            </td>
                            <td width="130">
                                <asp:DropDownList ID="DropdownListSOperateType" runat="server" AutoPostBack="True"
                                    CssClass="tselect" Width="180px">
                                    <asp:ListItem Value="-1" Selected="True">-全部-</asp:ListItem>
                                    <asp:ListItem Value="0">冻结</asp:ListItem>
                                    <asp:ListItem Value="1">解冻</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="90">
                                <asp:Button ID="ButtonSearch" runat="server" CausesValidation="False" Text="查询" OnClick="ButtonSearch_Click"
                                    CssClass="dele" />
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
                GridLines="Vertical" Style="margin-top: 15px;" Visible="false">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--分页--%>
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" />
                    <asp:BoundField DataField="Date" HeaderText="操作日期" SortExpression="Date">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="操作类型" SortExpression="OperateType">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# ChangeOperateType(DataBinder.Eval(Container,
                                                                                                                      "DataItem(OperateType)", "{0}")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="CurrentAdvancePayment" HeaderText="当前冻结金币（BV）" SortExpression="CurrentAdvancePayment">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="OperateMoney" HeaderText="冻结|解冻金额" SortExpression="OperateMoney">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="冻结|解冻后金额" DataField="LastOperateMoney" SortExpression="LastOperateMoney">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="备注" DataField="Memo" SortExpression="Memo">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
            </ShopNum1:Num1GridView>
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="LabelMemLoginID" runat="server" Text="当前会员用户名："></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelMemLoginIDValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelRealName1" runat="server" Text="当前会员姓名："></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelRealNameValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelAdvancePayment_" runat="server" Text="当前金币（BV）："></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelAdvancePayment" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="radiobtn">
                        <th align="right">
                            <asp:Label ID="LabelLockAdvancePayment_" runat="server" Text="冻结金币（BV）："></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelLockAdvancePayment" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelOperateMoney" runat="server" Text="操作类型："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListOperateType" runat="server" CssClass="tselect"
                                Width="230">
                                <asp:ListItem Value="0">冻结</asp:ListItem>
                                <asp:ListItem Value="1">解冻</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label3" runat="server" Text="金额："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOperateMoney" runat="server" CssClass="tinput" Width="230"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelMemo" runat="server" Text="备注："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMemo" runat="server" Height="60px" TextMode="MultiLine" Width="440px"
                                MaxLength="200" CssClass="tinput txtarea"></asp:TextBox>
                            <br />
                            备注不能超过200个字符
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="确定" OnClick="ButtonConfirm_Click"
                    OnClientClick=" return checkSub(); " ToolTip="Submit" CssClass="fanh" />
                <asp:Button ID="ButtonBack" runat="server" Text="返回列表" CssClass="fanh" PostBackUrl="~/Main/Admin/Member_List.aspx"
                    CausesValidation="false" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
            <script type="text/javascript" language="javascript">
                function checkSub() {
                    var operMoney = $("#TextBoxOperateMoney").val();
                    if (operMoney <= 0) {
                        alert("操作冻结金额必须大于0");
                        return false;
                    }
                    if ($("#TextBoxMemo").val().trim().length > 200) {
                        alert("备注不能超过200个字符");
                        return false;
                    }
                    return true;
                }
            </script>
        </div>
    </div>
    <asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_AdvancePaymentFreezeLog_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="LabelMemLoginIDValue" Name="memLoginID" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSDate1" Name="date1" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSDate2" Name="date2" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="DropdownListSOperateType" Name="operateType" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:Parameter Name="IsDeleted" Type="Int32" DefaultValue="0" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    </form>
</body>
</html>
