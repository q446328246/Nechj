<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="MMSGroupSend_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.MMSGroupSend_List" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>短信群发管理</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
    <style type="text/css">
        .hidden
        {
            display: none;
        }
    </style>
</head>
<body class="widthah">
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    短信发送历史
                </h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table border="0" cellspacing="0" cellpadding="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td align="right">
                            短信标题：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="tinput" Width="200px"></asp:TextBox>
                        </td>
                        <td class="lmf_padding" align="right">
                            发送状态：
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListState" runat="server" Width="201px" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding" align="right" style="display: none">
                            是否定时发送：
                        </td>
                        <td style="display: none">
                            <asp:DropDownList ID="DropDownListIsTime" runat="server" AutoPostBack="True" Width="201px"
                                CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td align="right">
                            发送对象：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSendObject" runat="server" CssClass="tinput" Width="200px"></asp:TextBox>
                        </td>
                        <td align="right">
                            发送时间：
                        </td>
                        <td colspan="3">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxCreateTime1" runat="server" CssClass="tinput" Width="66"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate" runat="server"
                                            ControlToValidate="TextBoxCreateTime1" Display="Dynamic" ErrorMessage="时间格式不正确"
                                            ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <ShopNum1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"
                                            EnableScriptLocalization="True">
                                        </ShopNum1:ToolkitScriptManager>
                                    </td>
                                    <td style="padding-left: 4px; vertical-align: top;">
                                        <img id="imgCalendarStartTime" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                            position: relative; top: 3px; width: 16px;" />
                                    </td>
                                    <td>
                                        <ShopNum1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxCreateTime1"
                                            PopupButtonID="imgCalendarStartTime" CssClass="ajax__calendar">
                                        </ShopNum1:CalendarExtender>
                                    </td>
                                    <td class="lmf_px">
                                        -
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxCreateTime2" runat="server" CssClass="tinput" Width="66"></asp:TextBox>
                                    </td>
                                    <td style="padding-left: 4px; vertical-align: top;">
                                        <img id="imgCalendarEndTime" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                            position: relative; top: 3px; width: 16px;" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEndDate" runat="server"
                                            ControlToValidate="TextBoxCreateTime2" Display="Dynamic" ErrorMessage="时间格式不正确"
                                            ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <ShopNum1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TextBoxCreateTime2"
                                            PopupButtonID="imgCalendarEndTime" CssClass="ajax__calendar">
                                        </ShopNum1:CalendarExtender>
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
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonSend" runat="server" OnClick="ButtonSend_Click" OnClientClick=" if (Page_ClientValidate()) return EditButton();return false; "
                                    class="chongxinfs lmf_btn"><span >重新发送</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                    class="shanchu lmf_btn"><span>批量删除</span></asp:LinkButton>
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
                    <asp:BoundField DataField="MMSTitle" HeaderText="短信标题" SortExpression="MMSTitle"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="SendObject" HeaderText="发送对象" SortExpression="SendObject">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="发送状态" SortExpression="State">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# ChangeState(DataBinder.Eval(Container, "DataItem(State)", "{0}")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="SendObjectMMS" HeaderText="发送对象" SortExpression="SendObjectMMS">
                        <HeaderStyle CssClass="hidden" />
                        <ItemStyle CssClass="hidden" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CreateTime" HeaderText="发送时间" SortExpression="CreateTime">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <%-- <asp:TemplateField HeaderText="发送方式" SortExpression="IsTime">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# ChangeisTime(DataBinder.Eval(Container, "DataItem(IsTime)","{0}")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SearchMMSGroupSend"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_MMS_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBoxCreateTime1" Name="strtime1" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxTitle" Name="mmstitle" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxCreateTime2" Name="strtime2" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxSendObject" Name="sendObjectMMS" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListState" PropertyName="SelectedValue"
                    Name="state" Type="Int32"></asp:ControlParameter>
                <asp:ControlParameter ControlID="DropDownListIsTime" Name="istime" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenFieldXmlPath" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
