<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleComment_Audit.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ArticleComment_Audit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>平台资讯评论审核</title>
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="平台资讯评论审核"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table style="width: 100%">
                    <tr style="height: 30px;">
                        <td width="65" style="padding-right: 5px; text-align: right;">
                            <asp:Label ID="LabelSMemLoginID" runat="server" Text="评论人："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSMemLoginID" runat="server" CssClass="tinput" Width="253"></asp:TextBox>
                        </td>
                        <td width="90" style="padding-right: 5px; text-align: right;">
                            <asp:Label ID="LabelSTitle" runat="server" Text="评论标题："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSTitle" runat="server" CssClass="tinput" Width="176"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td style="height: 25px; width: 42px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td width="65" style="padding-right: 5px; text-align: right;">
                            <asp:Label ID="LabelSIsAudit1" runat="server" Text="评论资讯："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSArticleGuid" runat="server" CssClass="tinput" Width="253"></asp:TextBox>
                        </td>
                        <td width="90" style="padding-right: 5px; text-align: right;">
                            <asp:Label ID="LabelSIsAudit0" runat="server" Text="审核状态："></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListSIsAudit" runat="server" Width="180px" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td style="height: 25px; width: 42px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td width="65" style="padding-right: 5px; text-align: right;">
                            <asp:Label ID="LabelSIsReply0" runat="server" Text="发表IP："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSIPAddress" runat="server" CssClass="tinput" Width="253"></asp:TextBox>
                        </td>
                        <td width="90" style="padding-right: 5px; text-align: right;">
                            <asp:Label ID="LabelSIsReply" runat="server" Text="回复状态："></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListSIsReply" runat="server" Width="180px" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td style="height: 25px; width: 42px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td width="65" style="padding-right: 5px; text-align: right;">
                            <asp:Label ID="LabelSSendTime" runat="server" Text="评论时间："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSSendTime1" runat="server" CssClass="tinput" Style="width: 100px;"></asp:TextBox>
                            <img id="imgCalendarSSendTime1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                position: relative; top: 6px; width: 16px;" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorSendTime1" runat="server"
                                ControlToValidate="TextBoxSSendTime1" Display="Dynamic" ErrorMessage="时间格式不正确"
                                ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                            <ShopNum1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"
                                EnableScriptLocalization="True">
                            </ShopNum1:ToolkitScriptManager>
                            &nbsp;<ShopNum1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxSSendTime1"
                                PopupButtonID="imgCalendarSSendTime1" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                            </ShopNum1:CalendarExtender>
                            -&nbsp;<asp:TextBox ID="TextBoxSSendTime2" runat="server" CssClass="tinput" Style="width: 100px;"></asp:TextBox>
                            <img id="imgCalendarSSendTime2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                position: relative; top: 6px; width: 16px;" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorSendTime2" runat="server"
                                ControlToValidate="TextBoxSSendTime2" Display="Dynamic" ErrorMessage="时间格式不正确"
                                ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                            <ShopNum1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxSSendTime2"
                                PopupButtonID="imgCalendarSSendTime2" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                            </ShopNum1:CalendarExtender>
                        </td>
                        <td style="height: 25px; width: 42px;" colspan="5">
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td width="65" style="padding-right: 5px; text-align: right;">
                            <asp:Label ID="LabelSReplyTime" runat="server" Text="回复时间："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSReplyTime1" runat="server" CssClass="tinput" Style="width: 100px;"></asp:TextBox>
                            <img id="imgCalendarSReplyTime1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                position: relative; top: 6px; width: 16px;" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorSReplyTime1" runat="server"
                                ControlToValidate="TextBoxSReplyTime1" Display="Dynamic" ErrorMessage="时间格式不正确"
                                ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                            <ShopNum1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TextBoxSReplyTime1"
                                PopupButtonID="imgCalendarSReplyTime1" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                            </ShopNum1:CalendarExtender>
                            &nbsp;&nbsp;-&nbsp;<asp:TextBox ID="TextBoxSReplyTime2" runat="server" CssClass="tinput"
                                Style="width: 100px;"></asp:TextBox>
                            <img id="imgCalendarSReplyTime2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                position: relative; top: 6px; width: 16px;" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorSReplyTime2" runat="server"
                                ControlToValidate="TextBoxSReplyTime2" Display="Dynamic" ErrorMessage="时间格式不正确"
                                ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                            <ShopNum1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TextBoxSReplyTime2"
                                PopupButtonID="imgCalendarSReplyTime2" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                            </ShopNum1:CalendarExtender>
                        </td>
                        <td align="left">
                            &nbsp; &nbsp;
                            <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="查询"
                                CssClass="dele" />
                        </td>
                        <td colspan="5">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <asp:Button ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" if (Page_ClientValidate()) return DeleteButton();return false; "
                        Text="批量删除" CausesValidation="False" CssClass="shanchu com" />
                    <asp:Button ID="ButtonIsAudit1" runat="server" OnClick="ButtonIsAudit1_Click" OnClientClick=" if (Page_ClientValidate()) return OperateButton();return false; "
                        Text="审核通过" CausesValidation="False" CssClass="qb" />
                    <asp:Button ID="ButtonIsAudit0" runat="server" OnClick="ButtonIsAudit0_Click" OnClientClick=" if (Page_ClientValidate()) return OperateButton();return false; "
                        Text="审核未通过" CausesValidation="False" CssClass="qb" />
                    <asp:Button ID="ButtonReply" runat="server" CausesValidation="False" OnClientClick=" if (Page_ClientValidate()) return EditButton();return false; "
                        Text="查看|回复" OnClick="ButtonReply_Click" CssClass="liuyan com" />
                    <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" Width="98%" AddSequenceColumn="False"
                AllowMultiColumnSorting="False" BorderColor="#CCDDEF" BorderStyle="Solid" BorderWidth="1px"
                CellPadding="4" Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False"
                GridViewSortDirection="Ascending" PagingStyle="None" Style="margin-top: 15px;"
                TableName="" DataSourceID="ObjectDataSourceData">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--分页--%>
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" />
                    <asp:TemplateField HeaderText="评论" SortExpression="Title">
                        <ItemTemplate>
                            <a href='<%#ShopUrlOperate.RetUrl("ArticleDetail", Eval("ArticleGuid").ToString()) %>'
                                target="_blank">
                                <%#Eval("Content").ToString().Length > 26 ? Eval("Content").ToString().Substring(0, 26) : Eval("Content").ToString() %>
                            </a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="评论资讯" DataField="ArticleTitle" SortExpression="ArticleTitle"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="SendTime" HeaderText="评论时间" SortExpression="SendTime">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MemLoginID" HeaderText="评论人" SortExpression="MemLoginID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="回复时间" DataField="ReplyTime" SortExpression="ReplyTime">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="审核状态" SortExpression="IsAudit">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# ChangeIsAudit(DataBinder.Eval(Container, "DataItem(IsAudit)", "{0}")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="回复状态" SortExpression="IsReply">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# ChangeIsReply(DataBinder.Eval(Container, "DataItem(IsReply)", "{0}")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="IPAddress" HeaderText="发表IP" SortExpression="IPAddress">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_ArticleComment_Action" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="CheckGuid" DefaultValue="" Name="guid" PropertyName="Value"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSArticleGuid" Name="articleName" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSMemLoginID" Name="memLoginID" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSTitle" DefaultValue="" Name="title" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSSendTime1" Name="sendTime1" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSSendTime2" Name="sendTime2" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSReplyTime1" Name="replyTime1" PropertyName="Text"
                Type="String" DefaultValue="" />
            <asp:ControlParameter ControlID="TextBoxSReplyTime2" Name="replyTime2" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="DropDownListSIsReply" Name="isReply" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:ControlParameter ControlID="DropDownListSIsAudit" Name="isAudit" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="isDeleted" Type="Int32" />
            <asp:ControlParameter ControlID="TextBoxSIPAddress" Name="IP" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
