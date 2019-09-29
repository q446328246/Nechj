<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopVedioCommentChecked_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopVedioCommentChecked_List" %>
    <%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>视频评论</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="视频评论"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table style="width: 100%">
                    <tr style="height: 30px;">
                        <td width="70" style="padding-right: 5px; text-align: right;">
                            <asp:Label ID="LabelSMemLoginID" runat="server" Text="评论人："></asp:Label>
                        </td>
                        <td width="400">
                            <asp:TextBox ID="TextBoxSMemLoginID" CssClass="tinput" runat="server" Width="220"></asp:TextBox>
                        </td>
                        <td width="100" style="display: none; padding-right: 5px; text-align: right;">
                            <asp:Label ID="LabelSTitle" runat="server" Text="评论标题："></asp:Label>
                        </td>
                        <td style="display: none">
                            <asp:TextBox ID="TextBoxSTitle" CssClass="tinput" runat="server" Width="180"></asp:TextBox>
                        </td>
                        <td width="100" style="padding-right: 5px; text-align: right;">
                            <asp:Label ID="Label3" runat="server" Text="评论店铺ID："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxShopID" CssClass="tinput" runat="server" Width="173"></asp:TextBox>
                            <asp:DropDownList ID="DropDownListSIsReply" Visible="false" runat="server" Width="180">
                            </asp:DropDownList>
                        </td>
                        <td style="height: 25px; width: 42px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td width="70" style="padding-right: 5px; text-align: right;">
                            <asp:Label ID="LabelSIsAudit1" runat="server" Text="评论视频："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSVideoGuid" CssClass="tinput" runat="server" Width="220"></asp:TextBox>
                        </td>
                        <td width="100" style="padding-right: 5px; text-align: right;">
                            <asp:Label ID="LabelSIsAudit0" runat="server" Text="审核状态："></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsAudit" runat="server" Width="180px" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
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
                        <td width="70" style="padding-right: 5px; text-align: right;">
                            <asp:Label ID="LabelSIsReply0" runat="server" Text="发表IP："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSIPAddress" CssClass="tinput" runat="server" Width="220"></asp:TextBox>
                        </td>
                        <td width="70" style="padding-right: 5px; text-align: right;">
                            <asp:Label ID="LabelSSendTime" runat="server" Text="评论时间："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSCommentTime1" CssClass="tinput" Style="width: 100px;" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate1" runat="server"
                                ControlToValidate="TextBoxSCommentTime1" Display="Dynamic" ErrorMessage="时间格式不正确"
                                ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                            <img id="imgCalendarSReplyTime1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                position: relative; top: 4px; width: 16px;" /><t:CalendarExtender ID="CalendarExtender4"
                                    runat="server" TargetControlID="TextBoxSCommentTime1" PopupButtonID="imgCalendarSReplyTime1"
                                    CssClass="ajax__calendar" />
                            －<asp:TextBox ID="TextBoxSCommentTime2" CssClass="tinput" Style="width: 100px;" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate2" runat="server"
                                ControlToValidate="TextBoxSCommentTime2" Display="Dynamic" ErrorMessage="时间格式不正确"
                                ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                            <img id="imgCalendarSReplyTime2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                position: relative; top: 4px; width: 16px;" /><t:CalendarExtender ID="CalendarExtender1"
                                    runat="server" TargetControlID="TextBoxSCommentTime2" PopupButtonID="imgCalendarSReplyTime2"
                                    CssClass="ajax__calendar" />
                        </td>
                        <td align="center">
                            &nbsp;&nbsp;
                            <asp:Button ID="ButtonSearch" runat="server" CssClass="dele" OnClick="ButtonSearch_Click"
                                Text="查询" />
                            <asp:TextBox ID="TextBoxSReplyTime1" Visible="false" CssClass="allinput1" runat="server"></asp:TextBox>
                            <asp:TextBox ID="TextBoxSReplyTime2" Visible="false" CssClass="allinput1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:Button ID="ButtonReply" runat="server" CausesValidation="False" OnClientClick=" return EditButton() "
                                    CssClass="dele" Text="查看" OnClick="ButtonReply_Click" Visible="false" />
                            </td>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonIsAudit1" runat="server" OnClick="ButtonAudit_Click" OnClientClick=" return AuditButton() "
                                    CssClass="shtg lmf_btn" CausesValidation="False"><span>审核通过</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonIsAudit0" runat="server" OnClick="ButtonCancelAudit_Click"
                                    OnClientClick=" return AuditButton() " CssClass="shwtg lmf_btn" CausesValidation="False">
                                            <span>审核未通过</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                    CssClass="shanchu lmf_btn" CausesValidation="False">
                                            <span>批量删除</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <cc1:num1gridview id="Num1GridViewShow" runat="server" autogeneratecolumns="False"
                allowpaging="True" allowsorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" width="100%" addsequencecolumn="False"
                allowmulticolumnsorting="False" bordercolor="#CCDDEF" borderstyle="Solid" borderwidth="1px"
                cellpadding="4" del="False" deleteprompttext="确实要删除指定的记录吗？" edit="False" fixheader="False"
                gridviewsortdirection="Ascending" pagingstyle="None" style="margin-left: 2px;"
                tablename="" datasourceid="ObjectDataSourceData">
                        <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White">
                        </HeaderStyle>
                        <PagerStyle  BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right"></PagerStyle>
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" />
                            <asp:BoundField HeaderText="评论视频" DataField="name" />
                            <asp:BoundField DataField="CommentTime" HeaderText="评论时间">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MemLoginID" HeaderText="评论人">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="评论店铺">
                                <ItemTemplate>
                                    <a href='<%#ShopUrlOperate.GetShopUrl(Eval("ShopID").ToString()) %>' target="_blank">
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("ShopName") %>'></asp:Label></a>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="店铺ID">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%#"shop" + Eval("ShopID") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="IPAddress" HeaderText="发表IP">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                    </cc1:num1gridview>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_VedioCommentChecked_Action" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxSTitle" Name="title" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSMemLoginID" Name="memLoginID" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSVideoGuid" Name="name" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxShopID" Name="ShopID" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSCommentTime1" Name="CommentTime1" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSCommentTime2" Name="CommentTime2" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSReplyTime1" Name="replyTime1" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSReplyTime2" Name="replyTime2" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="DropDownListSIsReply" Name="isReply" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:ControlParameter ControlID="DropDownListIsAudit" Name="isAudit" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:ControlParameter ControlID="TextBoxSIPAddress" Name="ipAddress" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
