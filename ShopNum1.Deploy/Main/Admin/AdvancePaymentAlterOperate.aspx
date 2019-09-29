<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvancePaymentAlterOperate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.AdvancePaymentAlterOperate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>变更金币（BV）</title>
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
                    变更金币（BV）</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit" style="display: none; margin-bottom: 1px;">
                <div>
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr style="height: 35px; vertical-align: top;">
                            <td>
                                <asp:Label ID="LabelSMemLoginID" runat="server" Text="会员ID："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSMemLoginID" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LabelSOperateType" runat="server" Text="变更类型："></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropdownListSOperateType" runat="server" Width="201px" CssClass="tselect">
                                    <asp:ListItem Value="-1" Selected="True">-全部-</asp:ListItem>
                                    <asp:ListItem Value="0">后台提现</asp:ListItem>
                                    <asp:ListItem Value="1">后台充值</asp:ListItem>
                                    <asp:ListItem Value="2">会员自助提现</asp:ListItem>
                                    <asp:ListItem Value="3">会员自助充值</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="lmf_padding">
                                <asp:Label ID="LabelSDate" runat="server" Text="变更日期："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSDate1" runat="server" CssClass="tinput" Width="100"></asp:TextBox>
                            </td>
                            <td style="padding-left: 4px; vertical-align: top;">
                                <img id="imgCalendarCreateTime1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                    position: relative; top: 3px; width: 16px;" />
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxSDate1" runat="server"
                                    ControlToValidate="TextBoxSDate1" Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <ShopNum1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"
                                    EnableScriptLocalization="True">
                                </ShopNum1:ToolkitScriptManager>
                            </td>
                            <td>
                                <ShopNum1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxSDate1"
                                    PopupButtonID="imgCalendarCreateTime1" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                </ShopNum1:CalendarExtender>
                            </td>
                            <td class="lmf_px">
                                -
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSDate2" runat="server" CssClass="tinput" Width="100"></asp:TextBox>
                            </td>
                            <td style="padding-left: 4px; vertical-align: top;">
                                <img id="imgCalendarCreateTime2" alt="" src="/ImgUpload/Calendar.png" style="position: relative;
                                    top: 3px; width: 16px;">
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxSDate2" runat="server"
                                    ControlToValidate="TextBoxSDate2" Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:CompareValidator ID="CompareValidatorTextBoxSDate2" runat="server" ErrorMessage="开始时间应当大于结束时间"
                                    Type="Date" Display="Dynamic" ControlToValidate="TextBoxSDate2" ControlToCompare="TextBoxSDate1"
                                    Operator="GreaterThan"></asp:CompareValidator>
                            </td>
                            <td>
                                <ShopNum1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxSDate2"
                                    PopupButtonID="imgCalendarCreateTime2" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                </ShopNum1:CalendarExtender>
                            </td>
                            <td>
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
                GridLines="Vertical" Visible="false">
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
                        <HeaderStyle Height="25px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" />
                    <asp:BoundField DataField="Date" HeaderText="变更日期" SortExpression="Date">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="变更类型" SortExpression="OperateType">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# ChangeOperateType(DataBinder.Eval(Container,
                                                                                                                      "DataItem(OperateType)", "{0}")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="CurrentAdvancePayment" HeaderText="当前金币（BV）" SortExpression="CurrentAdvancePayment">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="OperateMoney" HeaderText="变更金额" SortExpression="OperateMoney">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="变更后金额" DataField="LastOperateMoney" SortExpression="LastOperateMoney">
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
                            <asp:Label ID="LabelMemLoginID" runat="server" Text="会员ID："></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelMemLoginIDValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelRealName1" runat="server" Text="会员姓名："></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelRealNameValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelCurrentAdvancePayment" runat="server" Text="当前金币（BV）："></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelCurrentAdvancePaymentValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="radiobtn">
                        <th align="right">
                            <asp:Label ID="LabelOperateMoney" runat="server" Text="操作类型："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListOperateType" runat="server" CssClass="tselect"
                                Width="230">
                                <asp:ListItem Value="1">充值</asp:ListItem>
                                <asp:ListItem Value="0">提现</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label3" runat="server" Text="金额："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOperateMoney" runat="server" CssClass="tinput" Width="230"></asp:TextBox>
                            <asp:Label ID="LabelColor" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxOperateMoney"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxOperateMoney"
                                Display="Dynamic" ErrorMessage="输入格式不正确或金额较大" ValidationExpression="^((\d{0,9})|(\d{0,5}(.[0-9]{1,3})?))$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelMemo" runat="server" Text="备注："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMemo" runat="server" Height="60px" TextMode="MultiLine" Width="440px"
                                CssClass="tinput txtarea"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorMemo" runat="server"
                                ControlToValidate="TextBoxMemo" Display="Dynamic" ErrorMessage="备注最多250个字符" ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="确定" OnClick="ButtonConfirm_Click"
                    ToolTip="Submit" CssClass="fanh" />
                <%--  <input id="inputReset" runat="server" type="reset" value="重置" CssClass="fanh" />--%>
                <asp:Button ID="ButtonBack" runat="server" Text="返回列表" CssClass="fanh" PostBackUrl="~/Main/Admin/Member_List.aspx"
                    CausesValidation="false" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_AdvancePaymentModifyLog_Action">
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
    </form>
</body>
</html>
