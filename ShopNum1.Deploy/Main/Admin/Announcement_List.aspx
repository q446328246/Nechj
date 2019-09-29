<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Announcement_List.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Announcement_List" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>公告管理</title>
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
                            公告管理</h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div class="order_edit">
                        <div>
                            <table border="0" cellspacing="0" cellpadding="0">
                                <tr style="height: 35px; vertical-align: top;">
                                    <td>
                                        公告标题：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                                    </td>
                                    <td class="lmf_padding" align="right">
                                        发布人：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxCreateUser" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 35px; vertical-align: top;">
                                    <td>
                                        公告分类：
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListCategory" Width="207" runat="server" CssClass="tselect">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="lmf_padding">
                                        发布时间：
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="TextBoxStartTime" CssClass="tinput_data" runat="server"></asp:TextBox>
                                                </td>
                                                <td style="padding-left: 4px; vertical-align: top;">
                                                    <img id="imgCalendarSReplyTime2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative; top: 3px; width: 16px;" />
                                                </td>
                                                <td>
                                                    <t:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TextBoxStartTime"
                                                                               PopupButtonID="imgCalendarSReplyTime2" CssClass="ajax__calendar" />
                                                </td>
                                                <td>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxTime1" runat="server"
                                                                                    ControlToValidate="TextBoxStartTime" Display="Dynamic" ErrorMessage="时间格式不正确"
                                                                                    ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                                </td>
                                                <td class="lmf_px">
                                                    -
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxEndTime" CssClass="tinput_data" runat="server"></asp:TextBox>
                                                </td>
                                                <td style="padding-left: 4px; vertical-align: top;">
                                                    <img id="img1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative; top: 3px; width: 16px;" />
                                                </td>
                                                <td>
                                                    <t:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxEndTime"
                                                                               PopupButtonID="img1" CssClass="ajax__calendar" />
                                                </td>
                                                <td>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEndTime"
                                                                                    Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                                </td>
                                                <td>
                                                    <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="查询"
                                                                CssClass="dele" />
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
                                    <td valign="top">
                                        <asp:LinkButton ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" CausesValidation="False"
                                                        class="tianjia2 lmf_btn"><span>添加</span></asp:LinkButton>
                                        <asp:Button ID="ButtonEdit" runat="server" CausesValidation="False" Text="编辑" Visible="false"
                                                    OnClientClick=" return EditButton() " OnClick="ButtonEdit_Click" CssClass="dele" />
                                    </td>
                                    <td valign="top" class="lmf_app">
                                        <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                                        CausesValidationGroup="False" class="shanchu lmf_btn"  Visible="false"><span>批量删除</span></asp:LinkButton>
                                    </td>
                                    <td valign="top" class="lmf_app">
                                        <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
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
                        <footerstyle backcolor="#CCCC99" />
                        <headerstyle horizontalalign="Center" cssclass="list_header" forecolor="White"></headerstyle>
                        <%--分页--%>
                        <pagerstyle cssclass="lmf_page" backcolor="#F7F7DE" forecolor="Black" horizontalalign="Right" />
                        <selectedrowstyle backcolor="#CE5D5A" font-bold="True" forecolor="White" />
                        <alternatingrowstyle backcolor="White" />
                        <columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                                </HeaderTemplate>
                                <HeaderStyle CssClass="select_width" />
                                <ItemTemplate>
                                    <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Guid" HeaderText="GUID" SortExpression="Guid" Visible="False"
                                            ItemStyle-HorizontalAlign="Center" />
                            <asp:TemplateField HeaderText="公告分类" SortExpression="announcementcategoryid">
                                <ItemTemplate>
                                    <%#GetCategryName(Eval("announcementcategoryid").ToString()) %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="公告标题" SortExpression="Title">
                                <ItemTemplate>
                                    <a href='<%#ShopUrlOperate.RetUrl("AnnouncementDetail", Eval("Guid").ToString()) %>'
                                       target="_blank">
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Title") %>'></asp:Label></a>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="CreateUser" HeaderText="发布人" SortExpression="CreateUser">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CreateTime" HeaderText="发布时间" SortExpression="CreateTime">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <a href="<%# "Announcement_Operate.aspx?guid='" + Eval("Guid") + "'" %>" style="color: #4482b4;">
                                        编辑</a>
                                    <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" OnClick="ButtonDeleteBylink_Click"
                                                    CommandArgument='<%# Eval("Guid") %>' OnClientClick=" return window.confirm('您确定要删除吗?'); ">删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </columns>
                    </ShopNum1:Num1GridView>
                </div>
            </div>
            <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
                                  TypeName="ShopNum1.BusinessLogic.ShopNum1_Announcement_Action" OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBoxTitle" Name="title" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="TextBoxCreateUser" Name="creater" PropertyName="Text"
                                          Type="String" />
                    <asp:ControlParameter ControlID="TextBoxStartTime" Name="startDate" PropertyName="Text"
                                          Type="String" />
                    <asp:ControlParameter ControlID="TextBoxEndTime" Name="endDate" PropertyName="Text"
                                          Type="String" />
                    <asp:Parameter DefaultValue="0" Name="isDeleted" Type="Int32" />
                    <asp:ControlParameter ControlID="DropDownListCategory" Name="category" PropertyName="SelectedValue"
                                          Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        </form>
    </body>
</html>