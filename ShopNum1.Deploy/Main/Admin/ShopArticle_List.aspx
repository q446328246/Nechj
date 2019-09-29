<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopArticle_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopArticle_List" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>店铺文章列表</title>
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
                    店铺文章列表</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            资讯标题：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxRepeat" runat="server"
                                ControlToValidate="TextBoxTitle" Display="Dynamic" ErrorMessage="最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                        <td class="lmf_padding">
                            发布人：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxPublisher" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxRepeat0" runat="server"
                                ControlToValidate="TextBoxPublisher" Display="Dynamic" ErrorMessage="最多50个字符"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                        <td class="lmf_padding">
                            状态：
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsAudit" runat="server" CssClass="tselect" Width="201">
                                <asp:ListItem Selected="True" Value="-3">-全部-</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            发布时间：
                        </td>
                        <td colspan="5">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="textBoxStartDate" runat="server" CssClass="tinput" Width="58"></asp:TextBox>
                                    </td>
                                    <td style="padding-left: 4px; vertical-align: top;">
                                        <img id="imgCalendarSReplyTime2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                            position: relative; top: 3px; width: 16px;" />
                                    </td>
                                    <td>
                                        <t:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="textBoxStartDate"
                                            PopupButtonID="imgCalendarSReplyTime2" CssClass="ajax__calendar" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxTime1" runat="server"
                                            ControlToValidate="textBoxStartDate" Display="Dynamic" ErrorMessage="时间格式不正确"
                                            ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td class="lmf_px">
                                        -
                                    </td>
                                    <td>
                                        <asp:TextBox ID="textBoxEndDate" runat="server" CssClass="tinput" Width="58"></asp:TextBox>
                                    </td>
                                    <td style="padding-left: 4px; vertical-align: top;">
                                        <img id="img1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative;
                                            top: 3px; width: 16px;" />
                                    </td>
                                    <td>
                                        <t:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="textBoxEndDate"
                                            PopupButtonID="img1" CssClass="ajax__calendar" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="textBoxEndDate"
                                            Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonSearch" runat="server" Text="查询" CssClass="dele" OnClick="ButtonSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top" style="display: none;">
                                <asp:LinkButton ID="ButtonSearchDetails" runat="server" OnClientClick=" return EditButton() "
                                    CssClass="dele" OnClick="ButtonSearchDetails_Click" Visible="false"><span>查看</span></asp:LinkButton>
                            </td>
                            <td valign="top">
                                <asp:DropDownList ID="DropDownListOperate" runat="server" CssClass="tselect" Width="150">
                                    <asp:ListItem Value="0">-请选择-</asp:ListItem>
                                    <asp:ListItem Value="3">设置禁止</asp:ListItem>
                                    <asp:ListItem Value="1">取消禁止</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonAudit" runat="server" CssClass="zxcz lmf_btn" OnClick="ButtonAudit_Click"
                                    OnClientClick=" return OperateButton() "><span>执行操作</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" CausesValidation="False" OnClientClick=" return DeleteButton() "
                                    OnClick="ButtonDelete_Click" CssClass="shanchu lmf_btn"><span>批量删除</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app" style="display: none;">
                                <asp:LinkButton ID="ButtonHidden" runat="server" CssClass="addcate lmf_btn" Visible="False">
                                            <span>前台隐藏</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app" style="display: none;">
                                <asp:LinkButton ID="ButtonBrowse" runat="server" CssClass="addcate lmf_btn" Visible="False">
                                            <span>前台预览</span></asp:LinkButton>
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
                GridLines="Vertical" Style="margin-top: 15px;">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--分页--%>
                <PagerStyle CssClass="lmf_page" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" SortExpression="Guid">
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="标题" SortExpression="Title">
                        <ItemTemplate>
                            <a href='<%# ShopUrlOperate.shopDetailHref(Eval("Guid").ToString(), Eval("MemLoginID").ToString(), "NewsDetail") %>'
                                target="_blank">
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Title") %>'></asp:Label></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="店铺" SortExpression="MemLoginID">
                        <ItemTemplate>
                            <center>
                                <%#GetShopName(Eval("MemLoginID").ToString()) %></center>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="MemLoginID" HeaderText="发布人" SortExpression="MemLoginID"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Name" HeaderText="所属类型" SortExpression="Name" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="发布时间" DataField="CreateTime" SortExpression="CreateTime"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:TemplateField HeaderText="状态" SortExpression="IsAudit">
                        <ItemTemplate>
                            <asp:Image ID="Image2" runat="server" src='<%# PageOperator.GetListImageStatus(Eval("IsAudit").ToString() == "0" ? "1" : "0") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" SortExpression="IsShow">
                        <ItemTemplate>
                            <a href="<%# "ShopArticle_Details.aspx?Guid='" + Eval("guid") %>'" style="color: #4482b4;">
                                查看</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid") %>'
                                OnClientClick=" return window.confirm('您确定要删除吗?'); " OnClick="ButtonDeleteBylink_Click">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
            <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
            <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
                TypeName="ShopNum1.BusinessLogic.ShopNum1_ArticleCheck_Action" OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBoxTitle" Name="title" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="TextBoxPublisher" Name="shopID" PropertyName="Text"
                        Type="String" />
                    <asp:ControlParameter ControlID="textBoxStartDate" Name="startdate" PropertyName="Text"
                        Type="String" />
                    <asp:ControlParameter ControlID="textBoxEndDate" Name="enddate" PropertyName="Text"
                        Type="String" />
                    <asp:ControlParameter ControlID="DropDownListIsAudit" Name="IsAudit" PropertyName="SelectedValue"
                        Type="Int32" />
                    <asp:Parameter Name="isDeleted" Type="Int32" DefaultValue="0" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
    </form>
</body>
</html>
