<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopNum1_SupplyDemand_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopNum1_SupplyDemand_List" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>供求信息列表</title>
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
                    供求信息列表</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td align="right">
                            信息标题：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxTitle" CssClass="tinput" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            发布人：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxMemLoginID" CssClass="tinput" Width="200" runat="server"></asp:TextBox>
                            <asp:DropDownList ID="DropDownListIsAudit" Visible="false" Width="180px" runat="server"
                                CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding">
                            <asp:Localize ID="LocalizeFavourTickitName" runat="server" Text="供求分类："></asp:Localize>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListCommon_Cf" runat="server" AutoPostBack="true" CssClass="tselect"
                                OnSelectedIndexChanged="DropDownListCommon_Cf_SelectedIndexChanged" Style="margin-right: 0;
                                width: 100px;">
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListCommon_Cs" runat="server" AutoPostBack="true" CssClass="tselect"
                                OnSelectedIndexChanged="DropDownListCommon_Cs_SelectedIndexChanged" Style="margin-right: 0;
                                width: 100px;">
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListCommon_Ct" runat="server" CssClass="tselect" Style="margin-right: 0;
                                width: 100px;">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td align="right">
                            供求类型：
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListType" Width="207px" runat="server" CssClass="tselect">
                                <asp:ListItem Selected="True" Value="-1">-全部-</asp:ListItem>
                                <asp:ListItem Value="0">供应</asp:ListItem>
                                <asp:ListItem Value="1">求购</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right" class="lmf_padding">
                            有效期：
                        </td>
                        <td colspan="3">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxCreateTime1" CssClass="tinput" Width="58" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="padding-left: 4px; vertical-align: top;">
                                        <img id="imgCalendarCreateTime1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                            position: relative; top: 3px; width: 16px;" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorCreateTime1" runat="server"
                                            ControlToValidate="TextBoxCreateTime1" Display="Dynamic" ErrorMessage="时间格式不正确"
                                            ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <ShopNum1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"
                                            EnableScriptLocalization="True">
                                        </ShopNum1:ToolkitScriptManager>
                                    </td>
                                    <td>
                                        <ShopNum1:CalendarExtender Format="yyyy-MM-dd" ID="CalendarExtender1" runat="server"
                                            TargetControlID="TextBoxCreateTime1" PopupButtonID="imgCalendarCreateTime1" CssClass="ajax__calendar">
                                        </ShopNum1:CalendarExtender>
                                    </td>
                                    <td class="lmf_px">
                                        -
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="tinput" Width="58" ID="TextBoxCreateTime2" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="padding-left: 4px; vertical-align: top;">
                                        <img id="imgCalendarCreateTime2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                            position: relative; top: 3px; width: 16px;" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorCreateTime2" runat="server"
                                            ControlToValidate="TextBoxCreateTime2" Display="Dynamic" ErrorMessage="时间格式不正确"
                                            ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <ShopNum1:CalendarExtender Format="yyyy-MM-dd" ID="CalendarExtender2" runat="server"
                                            TargetControlID="TextBoxCreateTime2" PopupButtonID="imgCalendarCreateTime2" CssClass="ajax__calendar">
                                        </ShopNum1:CalendarExtender>
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
                            <td valign="top">
                                <asp:Button ID="ButtonSerch" runat="server" Text="查看" CssClass="fanh" Visible="false"
                                    OnClientClick=" return EditButton() " OnClick="ButtonSerch_Click" />
                                <asp:Button ID="ButtonAudit" runat="server" Visible="false" Text="审核通过" CssClass="fanh"
                                    OnClick="ButtonAudit_Click" OnClientClick=" return AuditButton() " />
                                <asp:Button ID="ButtonCancelAudit" runat="server" Visible="false" Text="审核未通过" CssClass="fanh"
                                    OnClientClick=" return AuditButton() " OnClick="ButtonCancelAudit_Click" />
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClientClick=" return DeleteButton() "
                                    OnClick="ButtonDelete_Click" CausesValidation="False" class="shanchu lmf_btn"><span>批量删除</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceDate1" AllowMultiColumnSorting="False"
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
                            <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("ID") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="信息标题" SortExpression="Title">
                        <ItemTemplate>
                            <a href='<%# ShopUrlOperate.RetUrl("SupplyDemandDetail", Eval("ID").ToString()) %>'
                                target="_blank">
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Title") %>'></asp:Label></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="MemberID" HeaderText="发布人" SortExpression="MemberID" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="所属分类" DataField="CategoryName" SortExpression="CategoryName"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="供求类型" SortExpression="TradeType">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# ShowTradeType(Eval("TradeType")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="查询关键字" DataField="Keywords" SortExpression="Keywords"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="信息有效期" SortExpression="ValidTime">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# IsValidTime(Eval("ValidTime").ToString()) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="序号" DataField="OrderID" SortExpression="OrderID" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href="<%# "SupplyDemandDetails.aspx?guid=" + Eval("ID") + "&&type=list" %>" style="color: #4482b4;">
                                查看</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" OnClick="ButtonDeleteBylink_Click"
                                CommandArgument='<%# Eval("ID") %>' OnClientClick=" return window.confirm('您确定要删除吗?'); ">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceDate1" runat="server" SelectMethod="SearchList"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_SupplyDemandCheck_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="HiddenFieldCode" Name="codes" PropertyName="Value"
                    Type="String" DefaultValue="-1" />
                <asp:ControlParameter ControlID="TextBoxMemLoginID" DefaultValue="-1" Name="associatedMemberIDs"
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="TextBoxTitle" DefaultValue="-1" Name="titles" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListType" DefaultValue="-1" Name="types"
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="TextBoxCreateTime1" Name="startTimes" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxCreateTime2" Name="endtimes" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListIsAudit" DefaultValue="-1" Name="isAudits"
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
    </div>
    </form>
</body>
</html>
