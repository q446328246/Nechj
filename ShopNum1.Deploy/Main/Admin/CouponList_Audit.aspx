<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CouponList_Audit.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.CouponList_Audit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
</head>
<body class="widthah1">
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
                    待审核优惠券列表
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
                            <td>
                                优惠券名称：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxShopName" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                            </td>
                            <td class="lmf_padding">
                                所属店铺：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxShopID" CssClass="tinput" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td class="lmf_padding">
                                店铺所在地：
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListRegionCode1" runat="server" AutoPostBack="true"
                                    CssClass="tselect" Style="width: 100px;" OnSelectedIndexChanged="DropDownListRegionCode1_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="DropDownListRegionCode2" runat="server" AutoPostBack="true"
                                    CssClass="tselect" Style="width: 100px;" OnSelectedIndexChanged="DropDownListRegionCode2_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="DropDownListRegionCode3" runat="server" CssClass="tselect"
                                    Style="width: 100px;">
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height: 35px; vertical-align: top;">
                            <td>
                                优惠券类别：
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListType" Width="207px" runat="server" CssClass="tselect">
                                </asp:DropDownList>
                            </td>
                            <td class="lmf_padding">
                                审核状态：
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListIsAudit" runat="server" Width="207px" CssClass="tselect">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="查询"
                                    CssClass="dele" />
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellspacing="0" cellpadding="0" style="display: none; margin-bottom: 7px;">
                        <tr>
                            <td width="80" style="padding-right: 5px; text-align: right;">
                                开始时间：
                            </td>
                            <td width="350">
                                <asp:TextBox ID="TextBoxStartTime1" CssClass="tinput" Style="width: 100px;" runat="server"></asp:TextBox>
                                <img id="imgCalendarSReplyTime2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                    position: relative; top: 4px; width: 16px;" /><t:CalendarExtender ID="CalendarExtender4"
                                        runat="server" TargetControlID="TextBoxStartTime1" PopupButtonID="imgCalendarSReplyTime2"
                                        CssClass="ajax__calendar" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxTime1" runat="server"
                                    ControlToValidate="TextBoxStartTime1" Display="Dynamic" ErrorMessage="时间格式不正确"
                                    ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                -
                                <asp:TextBox ID="TextBoxStartTime2" CssClass="tinput" Style="width: 100px;" runat="server"></asp:TextBox>
                                <img id="img1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative;
                                    top: 4px; width: 16px;" /><t:CalendarExtender ID="CalendarExtender1" runat="server"
                                        TargetControlID="TextBoxStartTime2" PopupButtonID="img1" CssClass="ajax__calendar" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxStartTime2"
                                    Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                            </td>
                            <td width="100" style="padding-right: 5px; text-align: right;">
                                结束时间：
                            </td>
                            <td width="280">
                                <asp:TextBox ID="TextBoxEndTime1" CssClass="tinput" Style="width: 100px;" runat="server"></asp:TextBox>
                                <img id="img2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative;
                                    top: 4px; width: 16px;" /><t:CalendarExtender ID="CalendarExtender2" runat="server"
                                        TargetControlID="TextBoxEndTime1" PopupButtonID="img2" CssClass="ajax__calendar" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxEndTime1"
                                    Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                                -
                                <asp:TextBox ID="TextBoxEndTime2" CssClass="tinput" Style="width: 100px;" runat="server"></asp:TextBox>
                                <img id="img3" alt="" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative;
                                    top: 4px; width: 16px;" /><t:CalendarExtender ID="CalendarExtender3" runat="server"
                                        TargetControlID="TextBoxEndTime2" PopupButtonID="img3" CssClass="ajax__calendar" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxEndTime2"
                                    Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonSearchShop" runat="server" CausesValidation="False" OnClientClick=" return EditButton() "
                                    CssClass="dele" OnClick="ButtonSearchShop_Click" Visible="false">
                                            <span>查看</span></asp:LinkButton>
                            </td>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonOperate" runat="server" OnClick="ButtonOperate_Click" OnClientClick=" return OperateButton() "
                                    CssClass="shtg lmf_btn">
                                            <span>审核通过</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonOperate1" runat="server" OnClientClick=" return OperateButton() "
                                    CssClass="shwtg lmf_btn" OnClick="ButtonOperate1_Click">
                                            <span>审核未通过</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" CausesValidation="False" OnClientClick=" return DeleteButton() "
                                    CssClass="shanchu lmf_btn" OnClick="ButtonDelete_Click">
                                            <span>批量删除</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
                    <asp:ObjectDataSource ID="ObjectDataSource" runat="server" SelectMethod="SearchCouponInfo"
                        TypeName="ShopNum1.ShopBusinessLogic.Shop_Coupon_Action">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TextBoxShopName" Name="Name" PropertyName="Text"
                                Type="String" DefaultValue="-1" />
                            <asp:ControlParameter Name="type" Type="String" DefaultValue="-1" ControlID="DropDownListType"
                                PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="DropDownListIsAudit" Name="isshow" PropertyName="SelectedValue"
                                Type="String" DefaultValue="-1" />
                            <asp:ControlParameter ControlID="TextBoxStartTime1" Name="starttime1" PropertyName="Text"
                                Type="String" DefaultValue="-1" />
                            <asp:ControlParameter ControlID="TextBoxStartTime2" Name="starttime2" PropertyName="Text"
                                Type="String" DefaultValue="-1" />
                            <asp:ControlParameter ControlID="TextBoxEndTime1" Name="endtime1" PropertyName="Text"
                                Type="String" DefaultValue="-1" />
                            <asp:ControlParameter ControlID="TextBoxEndTime2" Name="endtime2" PropertyName="Text"
                                Type="String" DefaultValue="-1" />
                            <asp:ControlParameter ControlID="TextBoxShopID" Name="shopid" PropertyName="Text"
                                Type="String" DefaultValue="-1" />
                            <asp:ControlParameter ControlID="HiddenFieldRegionCode" Name="adresscode" PropertyName="Value"
                                Type="String" DefaultValue="-1" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSource" AllowMultiColumnSorting="False"
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
                            <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="CouponName" HeaderText="优惠券名称" SortExpression="CouponName"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField HeaderText="优惠券类别" DataField="Name" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="所属店铺" SortExpression="ShopName">
                        <ItemTemplate>
                            <a href='<%#ShopUrlOperate.GetShopUrl(Eval("ShopID").ToString()) %>' target="_blank">
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("ShopName") %>'></asp:Label></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="店铺ID" SortExpression="ShopID">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%#"Shop" + Eval("ShopID") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="所在地">
                        <ItemTemplate>
                            <%# Eval("AdressName").ToString().Replace(",", "") %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="审核状态" SortExpression="IsAudit">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("IsAudit").ToString() == "2" ? "审核未通过" : "未审核" %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" SortExpression="IsShow">
                        <ItemTemplate>
                            <%--   <a href="#" style="color: #4482b4;">
                                查看</a>--%>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid") %>'
                                OnClientClick=" return window.confirm('您确定要删除吗?'); " OnClick="ButtonDeleteBylink_Click">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
    </div>
    <asp:HiddenField ID="HiddenFieldRegionCode" runat="server" Value="-1" />
    </form>
</body>
</html>
