<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="MemberActualAuthentication_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.MemberActualAuthentication_List" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link type="text/css" rel="Stylesheet" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
</head>
<style type="text/css">
    .gridview_m tr td
    {
        text-align: center;
    }
</style>
<body>
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
                    会员实名认证列表</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit" style="margin-bottom: 5px;">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td align="right">
                            会员登录名：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxMemberName" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                        </td>
                        <td align="right" class="lmf_padding">
                            会员真实名称：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxRealName" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td align="right">
                            身份证号码:
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxCardNum" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                        </td>
                        <td align="right" class="lmf_padding">
                            申请时间：
                        </td>
                        <td class="style1">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxStartTime" CssClass="tinput" runat="server" Width="65"></asp:TextBox>
                                    </td>
                                    <td style="padding-left: 4px; vertical-align: top;">
                                        <img id="imgCalendarSReplyTime2" alt="" src="/ImgUpload/Calendar.png" style="width: 16px;
                                            height: 18px; position: relative; top: 3px" />
                                    </td>
                                    <td>
                                        <t:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TextBoxStartTime"
                                            PopupButtonID="imgCalendarSReplyTime2" CssClass="ajax__calendar" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxTime1" runat="server"
                                            ControlToValidate="TextBoxStartTime" Display="Dynamic" ErrorMessage="时间格式不正确"
                                            ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                                    </td>
                                    <td class="lmf_px">
                                        -
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxEndTime" CssClass="tinput" runat="server" Width="65"></asp:TextBox>
                                    </td>
                                    <td style="padding-left: 4px; vertical-align: top;">
                                        <img id="img1" alt="" src="/ImgUpload/Calendar.png" style="width: 16px; height: 18px;
                                            position: relative; top: 3px" />
                                    </td>
                                    <td>
                                        <t:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxEndTime"
                                            PopupButtonID="img1" CssClass="ajax__calendar" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEndTime"
                                            Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;<asp:Button ID="ButtonSearch" runat="server" Text="查询" CssClass="fanh"
                                            OnClick="ButtonSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td valign="top" class="lmf_app">
                            &nbsp;&nbsp;<asp:LinkButton ID="ButtonDelete" runat="server" CausesValidation="False"
                                OnClientClick="return DeleteButton()" OnClick="butDel_Click" CssClass="shanchu lmf_btn"><span>批量删除</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                            <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                        </td>
                    </tr>
                </table>
            </div>
            <cc1:Num1GridView ID="Num1GridViewShow" runat="server" Width="98%" AddSequenceColumn="False"
                AllowMultiColumnSorting="False" AllowPaging="True" AutoGenerateColumns="False"
                BorderColor="#CCDDEF" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectDataSourceData"
                Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" AllowSorting="True">
                <HeaderStyle HorizontalAlign="Center" BackColor="#6699CC" Font-Bold="True" ForeColor="#FFFFFF"
                    CssClass="list_header"></HeaderStyle>
                <PagerStyle HorizontalAlign="Left" BackColor="#EEEEEE" ForeColor="#6699CC"></PagerStyle>
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick="javascript:SelectAllCheckboxes(this);" type="checkbox" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="MemLoginID" HeaderText="会员登录名" SortExpression="MemLoginID" />
                    <asp:BoundField DataField="RealName" HeaderText="真实姓名" SortExpression="RealName" />
                    <asp:BoundField DataField="IdentityCard" HeaderText="身份证号码" SortExpression="IdentityCard" />
                    <asp:BoundField DataField="IdentificationTime" HeaderText="申请时间" SortExpression="IdentificationTime" />
                    <asp:TemplateField>
                        <HeaderTemplate>
                            审核状态</HeaderTemplate>
                        <ItemTemplate>
                            <%#Is(Eval("IdentificationIsAudit"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" SortExpression="IsShow">
                        <ItemTemplate>
                            <a href="<%# "MemberActualAuthentication_Operate.aspx?guid="+"'"+Eval("Guid")+"'"%>"
                                style="color: #4482b4;">查看</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" OnClick="ButtonDeleteBylink_Click"
                                CommandArgument='<%# Eval("Guid") %>' OnClientClick="return window.confirm('您确定要删除吗?');">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </cc1:Num1GridView>
            <div class="vote" style="padding-left: 2px; margin: 15px 42px;">
                <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SearchPassMemberInfo"
                    TypeName="ShopNum1.BusinessLogic.ShopNum1_Member_Action" OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TextBoxMemberName" Name="MemLoginID" PropertyName="Text"
                            Type="String" />
                        <asp:ControlParameter ControlID="TextBoxRealName" Name="RealName" PropertyName="Text"
                            Type="String" />
                        <asp:ControlParameter ControlID="TextBoxCardNum" Name="IdentityCard" PropertyName="Text"
                            Type="String" />
                        <asp:ControlParameter ControlID="TextBoxStartTime" Name="StartTime" PropertyName="Text"
                            Type="String" />
                        <asp:ControlParameter ControlID="TextBoxEndTime" Name="EndTime" PropertyName="Text"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
