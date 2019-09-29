<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ChangeAdvancePaymentLog_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ChangeAdvancePaymentLog_List" %>

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
                    金币（BV）变更日志</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit" style="margin-bottom: 1px;">
                <div>
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr style="height: 35px; vertical-align: top;">
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="会员ID："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextMemLoginIDValue" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                            </td>

                            <td class="lmf_padding">
                                <asp:Label ID="LabelMemos" runat="server" Text="备注："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxMemos" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                            </td>

                            <td class="lmf_padding">
                                <asp:Label ID="LabelSOperateType" runat="server" Text="变更类型："></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropdownListSOperateType" runat="server" Width="201px" CssClass="tselect">
                                    <asp:ListItem Value="-1" Selected="True">-全部-</asp:ListItem>
                                    <asp:ListItem Value="1">USDT充值</asp:ListItem>
                                    <asp:ListItem Value="2">USDT提现</asp:ListItem>
                                    <asp:ListItem Value="3">USDT消费</asp:ListItem>
                                    <asp:ListItem Value="4">USDT收入</asp:ListItem>
                                    <asp:ListItem Value="5">USDT系统</asp:ListItem>
                                    <asp:ListItem Value="6">USDT转账</asp:ListItem>
                                    <asp:ListItem value="7">冻结NEC消费（PV_A）</asp:ListItem>
                                    <asp:ListItem value="8">冻结NEC获得（PV_A）</asp:ListItem>
                                   <asp:ListItem value="9">ETH消费（HV）</asp:ListItem>
                                   <asp:ListItem value="10">ETH获得（HV）</asp:ListItem>
                                   <asp:ListItem value="14">NEC消费(DV)</asp:ListItem>
                                   <asp:ListItem value="15">NEC获得(DV)</asp:ListItem>
                                   </asp:DropDownList>
                            </td>
                            <td class="lmf_padding">
                                <asp:Label ID="LabelSDate" runat="server" Text="变更日期："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSDate1" runat="server" CssClass="tinput_data"></asp:TextBox>
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
                                <asp:TextBox ID="TextBoxSDate2" runat="server" CssClass="tinput_data"></asp:TextBox>
                            </td>
                            <td style="padding-left: 4px; vertical-align: top;">
                                <img id="imgCalendarCreateTime2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                    position: relative; top: 3px; width: 16px;">
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
                            <td>
                                <asp:LinkButton ID="ButtonReportAll" OnClick="ButtonReportAll_Click" runat="server"
                                    OnClientClick=" return ImportData(true); " CausesValidation="False" CssClass="daochubtn lmf_btn"><span>导出全部</span></asp:LinkButton>
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
                    <asp:TemplateField Visible="false">
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                        </ItemTemplate>
                        <HeaderStyle Height="25px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="MemLoginID" HeaderText="会员ID" SortExpression="MemLoginID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" />
                    <asp:BoundField DataField="Date" HeaderText="变更日期" SortExpression="Date">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="变更类型" SortExpression="OperateType">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# ChangeOperateType(DataBinder.Eval(Container, "DataItem(OperateType)", "{0}")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="money_first" HeaderText="当前额度" SortExpression="money_first">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="money_two" HeaderText="变更金额" SortExpression="money_two">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                   <%-- <asp:TemplateField HeaderText="变更金额" SortExpression="OperateMoney">
                        <ItemTemplate>
                            <%#MoneyAddOrDel(Eval("CurrentAdvancePayment"), Eval("LastOperateMoney")) %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                    <asp:BoundField HeaderText="变更后金额" DataField="money_free" SortExpression="money_free">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="备注" DataField="Memo" SortExpression="Memo">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
            </ShopNum1:Num1GridView>
            <div id="divPage" runat="server" style="display: none;">
                <div class="navigator">
                    &nbsp;
                    <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="变更金币（BV）"></asp:Label>
                </div>
                <table cellpadding="0" cellspacing="1" border="0" style="width: 100%">
                    <tr>
                        <td colspan="2" style="width: 100%;">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%;">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td align="right">
                            <asp:Label ID="LabelMemLoginID" runat="server" Text="会员ID："></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="LabelMemLoginIDValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td align="right">
                            <asp:Label ID="LabelRealName1" runat="server" Text="会员姓名："></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="LabelRealNameValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td align="right">
                            <asp:Label ID="LabelCurrentAdvancePayment" runat="server" Text="当前金币（BV）："></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="LabelCurrentAdvancePaymentValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td align="right">
                            <asp:Label ID="LabelOperateMoney" runat="server" Text="变更金额："></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListOperateType" runat="server" CssClass="tselect">
                                <asp:ListItem Value="1">充值</asp:ListItem>
                                <asp:ListItem Value="0">提现</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="TextBoxOperateMoney" runat="server" CssClass="tinput" Width="230"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorOperateMoney" runat="server"
                                ControlToValidate="TextBoxOperateMoney" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorOperateMoney" runat="server"
                                ControlToValidate="TextBoxOperateMoney" Display="Dynamic" ErrorMessage="输入格式不正确或金额较大"
                                ValidationExpression="^((\d{0,9})|(\d{0,5}(.[0-9]{1,3})?))$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td align="right">
                            <asp:Label ID="LabelMemo" runat="server" Text="备注："></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBoxMemo" runat="server" Height="60px" TextMode="MultiLine" Width="440px"
                                CssClass="tinput txtarea"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorMemo" runat="server"
                                ControlToValidate="TextBoxMemo" Display="Dynamic" ErrorMessage="备注最多250个字符" ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="background-color: #EEEEEE;" class="btconfig; height:30px;">
                        <td align="right">
                            &nbsp;
                        </td>
                        <td align="left">
                            <div style="width: 80%;">
                                <asp:Button ID="ButtonConfirm" runat="server" Text="确定" OnClick="ButtonConfirm_Click"
                                    ToolTip="Submit" CssClass="fanh" />
                                <%--  <input id="inputReset" runat="server" type="reset" value="重置" CssClass="fanh" />--%>
                                <asp:Button ID="ButtonBack" runat="server" Text="返回列表" CssClass="fanh" PostBackUrl="~/Main/Admin/Member_List.aspx"
                                    CausesValidation="false" />
                                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_AdvancePaymentModifyLog_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextMemLoginIDValue" Name="memLoginID" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSDate1" Name="date1" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSDate2" Name="date2" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="DropdownListSOperateType" Name="operateType" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:Parameter Name="IsDeleted" Type="Int32" DefaultValue="0" />
            <asp:ControlParameter ControlID="TextBoxMemos" Name="Memo" 
                PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>
</body>
</html>
