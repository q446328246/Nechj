<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaveLogList.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.SaveLogList" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>提现审核</title>
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
                    <h3>提现审核</h3>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="welcon clearfix">
                <div class="order_edit">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr style="height: 35px; vertical-align: top;">
                           
                            <td class="lmf_padding">
                                <asp:Label ID="LabelSMemLoginID" runat="server" Text="会员名："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSMemLoginID" runat="server" CssClass="tinput" Width="150px"></asp:TextBox>
                            </td>
                            <td class="lmf_padding">
                                <asp:Label ID="LabelSOperateStatus" runat="server" Text="状态："></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropdownListSOperateStatus" runat="server" Width="100px" CssClass="tselect">
                                    <asp:ListItem Value="-1" Selected="True">-全部-</asp:ListItem>
                                    <asp:ListItem Value="0">未确认</asp:ListItem>
                                    <asp:ListItem Value="1">已完成</asp:ListItem>
                                    <asp:ListItem Value="2">已拒绝</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="lmf_padding">
                                <asp:Label ID="LabelSDate" runat="server" Text="操作日期："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSDate1" runat="server" CssClass="tinput_data"></asp:TextBox>
                            </td>
                            <td style="padding-left: 4px; vertical-align: top;">
                                <img id="imgCalendarSDate1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative; top: 3px; width: 16px;" />
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
                            <td class="lmf_px">-
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSDate2" runat="server" CssClass="tinput_data"></asp:TextBox>
                            </td>
                            <td style="padding-left: 4px; vertical-align: top;">
                                <img id="imgCalendarSDate2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative; top: 3px; width: 16px;" />
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
                        <tr height="30" style="display: none;">
                            <td align="right">
                                <asp:Label ID="LabelSOperateType" runat="server" Text="操作类型："></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropdownListSOperateType" runat="server" Width="180px" CssClass="tselect">
                                    <asp:ListItem Value="0" Selected="True">提现</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td colspan="2"></td>
                        </tr>
                    </table>
                    <div class="sbtn">
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                          
                                <td valign="top" class="lmf_app">
                                    <td valign="top" class="lmf_app">
                       
                                    <ShopNum1:MessageShow ID="MessageShow1" runat="server" Visible="False" />
                                </td><ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    
                </div>
                <div id="gzts" runat="server"></div>
                <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                    AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                    descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                    Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
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
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                            </HeaderTemplate>
                            <HeaderStyle CssClass="select_width" />
                            <ItemTemplate>
                                <input id="checkboxItem" value='<%# Eval("id") %>' type="checkbox" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="id" HeaderText="id" Visible="False" />
                        <asp:BoundField DataField="id" HeaderText="记录id" SortExpression="id">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="memloginid" HeaderText="会员名" SortExpression="memloginid">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="time" HeaderText="时间" SortExpression="time">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="savesum" HeaderText="提现救赎币">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                          <asp:BoundField DataField="savepv_a" HeaderText="消耗冻结nec币">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>


                          <asp:BoundField DataField="savedv" HeaderText="消耗可用nec币">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                           <asp:TemplateField HeaderText="状态" SortExpression="status">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# NECChangeOperateStatus(DataBinder.Eval(Container, "DataItem(status)", "{0}")) %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                     <%--   <asp:BoundField DataField="NECAddress" HeaderText="提现地址" SortExpression="NECAddress">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>--%>
                  <%--      <asp:BoundField DataField="Shop_NECAddress" HeaderText="NEC地址" SortExpression="Shop_NECAddress">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>--%>
                     <%--   <asp:TemplateField HeaderText="查询以太坊交易号" SortExpression="TxHash">
                            <ItemTemplate>
                               <asp:HyperLink Id="HyperLink1" NavigateUrl='<%# Eval("TxHash", "https://etherscan.io/tx/{0}") %>' Target="_blank" runat="server" style="color:#4482b4;">查询交易状态</asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                       <%-- <asp:TemplateField HeaderText="状态" SortExpression="Status">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# NECChangeOperateStatus(DataBinder.Eval(Container, "DataItem(Status)", "{0}")) %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="操作" SortExpression="IsShow">
                            <ItemTemplate>
                                <%--<a href="<%# "AdvancePaymentMemApplyLog_Operate.aspx?guid=" + Eval("Guid") + "&Type=0" %>"
                                style="color: #4482b4;">审核</a>--%>
                                <asp:LinkButton ID="ButtonExamineBylink" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("id") %>'
                                    OnClientClick=" return window.confirm('您确定要审核操作吗?'); " OnClick="ButtonExamineBylink_Click">审核</asp:LinkButton>
                                <%--<a href="<%# "AdvancePaymentMemApplyLog_Operate.aspx?guid=" + Eval("Guid") + "&Type=0" %>"
                                style="color: #4482b4;">拒绝</a>--%>
                                <asp:LinkButton ID="ButtonRefuseBylink" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("id") %>'
                                    OnClientClick=" return window.confirm('您确定要拒绝操作吗?'); " OnClick="ButtonRefuseBylink_Click">拒绝</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:TemplateField>
                    </Columns>
                </ShopNum1:Num1GridView>
            </div>
            <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SearchSaveLog"
                TypeName="ShopNum1.BusinessLogic.ShopNum1_AdvancePaymentApplyLog_Action">
                <SelectParameters>
              
                    <asp:ControlParameter ControlID="TextBoxSMemLoginID" Name="memLoginID" PropertyName="Text"
                        Type="String" />
                    <asp:ControlParameter ControlID="TextBoxSDate1" Name="date1" PropertyName="Text"
                        Type="String" />
                    <asp:ControlParameter ControlID="TextBoxSDate2" Name="date2" PropertyName="Text"
                        Type="String" />
     
                    <asp:ControlParameter ControlID="DropdownListSOperateStatus" DefaultValue="0" Name="operateStatus" PropertyName="SelectedValue" Type="Int32" />
         
                </SelectParameters>
            </asp:ObjectDataSource>
            <%--<asp:HiddenField ID="CheckGuid" runat="server" Value="0" />--%>
            <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        </div>
    </form>
</body>
</html>
