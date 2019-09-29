<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopVedioComment_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopVedioComment_List" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>视频评论</title>
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="视频评论"></asp:Label>
                </h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <div>
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr style="height: 35px; vertical-align: top;">
                            <td style="text-align: right;">
                                <asp:Label ID="LabelSMemLoginID" runat="server" Text="评论人："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSMemLoginID" Width="200" CssClass="tinput" runat="server"></asp:TextBox>
                            </td>
                            <td class="lmf_padding" style="display: none">
                                <asp:Label ID="LabelSTitle" runat="server" Text="评论标题："></asp:Label>
                            </td>
                            <td style="display: none">
                                <asp:TextBox ID="TextBoxSTitle" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                            </td>
                            <td class="lmf_padding" style="display: none">
                                <asp:Label ID="LabelSIsReply" runat="server" Text="回复状态："></asp:Label>
                            </td>
                            <td style="display: none">
                                <asp:DropDownList ID="DropDownListSIsReply" runat="server" Width="207" CssClass="tselect">
                                </asp:DropDownList>
                            </td>
                            <td class="lmf_padding">
                                <asp:Label ID="LabelSIsReply0" runat="server" Text="发表IP："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSIPAddress" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LabelSIsAudit1" runat="server" Text="&nbsp;&nbsp;评论视频："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSVideoGuid" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 35px; vertical-align: top;">
                            <td class="lmf_padding">
                                <asp:Label ID="LabelSIsAudit0" runat="server" Text="评论店铺ID："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxShopID" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                                <asp:DropDownList ID="DropDownListIsAudit" Visible="false" runat="server" Width="184px"
                                    CssClass="tselect">
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                <asp:Label ID="LabelSSendTime" runat="server" Text="评论时间："></asp:Label>
                            </td>
                            <td colspan="5">
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBoxSCommentTime1" CssClass="tinput" Style="width: 58px;" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate1" runat="server"
                                                ControlToValidate="TextBoxSCommentTime1" Display="Dynamic" ErrorMessage="时间格式不正确"
                                                ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td style="padding-left: 4px; vertical-align: top;">
                                            <img id="imgCalendarSReplyTime1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                                position: relative; top: 3px; width: 16px;" />
                                        </td>
                                        <td>
                                            <t:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TextBoxSCommentTime1"
                                                PopupButtonID="imgCalendarSReplyTime1" CssClass="ajax__calendar" />
                                        </td>
                                        <td class="lmf_px">
                                            －
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxSCommentTime2" CssClass="tinput" Style="width: 58px;" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate2" runat="server"
                                                ControlToValidate="TextBoxSCommentTime2" Display="Dynamic" ErrorMessage="时间格式不正确"
                                                ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td style="padding-left: 4px; vertical-align: top;">
                                            <img id="imgCalendarSReplyTime2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                                position: relative; top: 3px; width: 16px;" />
                                        </td>
                                        <td>
                                            <t:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxSCommentTime2"
                                                PopupButtonID="imgCalendarSReplyTime2" CssClass="ajax__calendar" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxSReplyTime1" Visible="false" CssClass="tinput" Style="width: 100px;"
                                                runat="server"></asp:TextBox>
                                            <asp:TextBox ID="TextBoxSReplyTime2" Visible="false" CssClass="tinput" Style="width: 100px;"
                                                runat="server"></asp:TextBox>
                                            <asp:Button ID="ButtonSearch" runat="server" CssClass="dele" OnClick="ButtonSearch_Click"
                                                Text="查询" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top" style="display: none;">
                                <asp:LinkButton ID="ButtonReply" runat="server" CausesValidation="False" OnClientClick=" return EditButton() "
                                    CssClass="dele" Visible="false" OnClick="ButtonReply_Click"><span>查看</span></asp:LinkButton>
                            </td>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                    CssClass="shanchu lmf_btn" CausesValidation="False"><span>批量删除</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
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
                            <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" />
                    <%-- <asp:TemplateField HeaderText="评论标题">
                        <ItemTemplate>
                            <a href='<%#ShopUrlOperate.GetShopUrl(Eval("ShopID").ToString().Replace("shop",""))+"/VideoDetail/"+Eval("VideoGuid")+".html" %>'
                                target="_blank">
                                <%# Eval("Title") %></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                    <asp:BoundField HeaderText="评论视频" DataField="name" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="CommentTime" HeaderText="评论时间">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MemLoginID" HeaderText="评论人">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="店铺名称" SortExpression="ShopName">
                        <ItemTemplate>
                            <a href='<%#ShopUrlOperate.GetShopUrl(Eval("ShopID").ToString()) %>' target="_blank">
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("ShopName") %>'></asp:Label></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="店铺ID" SortExpression="ShopID">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#"shop" + Eval("ShopID") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="IPAddress" HeaderText="发表IP">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href="<%# "ShopVedioCommentChecked_Operate.aspx?type=List&guid=" + "'" + Eval("Guid") + "'" %>"
                                style="color: #4482b4;">查看</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid") %>'
                                OnClientClick=" return window.confirm('您确定要删除吗?'); " OnClick="ButtonDeleteBylink_Click">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
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
