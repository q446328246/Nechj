<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopCategoryAply_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopCategoryAply_List" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link type="text/css" rel="Stylesheet" href="css/index.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body style="background-image: url(images/Bg_right.gif); background-repeat: repeat;
    font-size: 12px; padding: 0;">
    <div class="navigator">
        【待审核店铺分类】<br />
        <br />
        <br />
    </div>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"
        runat="server">
    </asp:ScriptManager>
    <div class="query">
        <table width="100%">
            <tr>
                <td align="right">
                    店铺名称：
                </td>
                <td class="style1">
                    <asp:TextBox ID="TextBoxShopName" CssClass="allinput1" runat="server" Text=""></asp:TextBox>
                </td>
                <td align="right" class="style2">
                    店铺会员ID：
                </td>
                <td colspan="1">
                    <asp:TextBox ID="TextBoxMemberName" CssClass="allinput1" runat="server" Text=""></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    店铺分类：
                </td>
                <td colspan="1" class="style1">
                    <asp:DropDownList ID="DropDownListShopCategoryCode1" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="DropDownListShopCategoryCode1_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownListShopCategoryCode2" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="DropDownListShopCategoryCode2_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownListShopCategoryCode3" runat="server">
                    </asp:DropDownList>
                </td>
                <td align="right" class="style2">
                    申请时间：
                </td>
                <td>
                    <asp:TextBox ID="TextBoxStartTime" CssClass="allinput1" runat="server"></asp:TextBox>
                    <img id="imgCalendarSReplyTime2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                        position: relative; top: 4px; width: 16px;" /><t:CalendarExtender ID="CalendarExtender4"
                            runat="server" TargetControlID="TextBoxStartTime" PopupButtonID="imgCalendarSReplyTime2"
                            CssClass="ajax__calendar" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxTime1" runat="server"
                        ControlToValidate="TextBoxStartTime" Display="Dynamic" ErrorMessage="时间格式不正确"
                        ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                    -
                    <asp:TextBox ID="TextBoxEndTime" CssClass="allinput1" runat="server"></asp:TextBox>
                    <img id="img1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative;
                        top: 4px; width: 16px;" /><t:CalendarExtender ID="CalendarExtender1" runat="server"
                            TargetControlID="TextBoxEndTime" PopupButtonID="img1" CssClass="ajax__calendar" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEndTime"
                        Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                    <asp:DropDownList ID="DropDownListIsAudit" Visible="false" runat="server" Width="184px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
                <td>
                    <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="查询"
                        CssClass="bt2" />
                </td>
            </tr>
        </table>
    </div>
    <cc1:num1gridview id="Num1GridViewShow" runat="server" width="100%" addsequencecolumn="False"
        allowmulticolumnsorting="False" allowpaging="True" autogeneratecolumns="False"
        bordercolor="#CCDDEF" borderstyle="Solid" borderwidth="1px" cellpadding="4" datasourceid="ObjectDataSource"
        del="False" deleteprompttext="确实要删除指定的记录吗？" edit="False" fixheader="False" gridviewsortdirection="Ascending"
        pagingstyle="None" style="margin-left: 2px;" tablename="" allowsorting="True">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="店铺名称" SortExpression="ShopName">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("ShopName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="OldShopCategoryName" HeaderText="申请前店铺分类" SortExpression="OldShopCategoryName">
                    </asp:BoundField>
                    <asp:BoundField DataField="ShopCategoryName" HeaderText="申请分类" SortExpression="ShopCategoryName">
                    </asp:BoundField>
                    <asp:BoundField HeaderText="店铺会员ID" DataField="ShopID"></asp:BoundField>
                    <asp:BoundField HeaderText="申请时间" DataField="ApplyTime" />
                    <asp:TemplateField HeaderText="审核状态">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Is(Eval("IsAudit")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle HorizontalAlign="Center" BackColor="#6699CC" Font-Bold="True" ForeColor="#FFFFFF">
                </HeaderStyle>
                <PagerStyle HorizontalAlign="Left" BackColor="#EEEEEE" ForeColor="#6699CC"></PagerStyle>
            </cc1:num1gridview>
    <div class="vote" style="padding-left: 2px;">
        <asp:Button ID="ButtonSearchShop" runat="server" CausesValidation="False" Text="查看"
            OnClientClick=" return EditButton() " CssClass="bt2" OnClick="ButtonSearchShop_Click" />
        <asp:Button ID="ButtonOperate" runat="server" Text="审核通过" OnClick="ButtonOperate_Click"
            OnClientClick=" return OperateButton() " CssClass="bt3" />
        <asp:Button ID="ButtonOperate1" runat="server" Text="审核未通过" OnClientClick=" return OperateButton() "
            CssClass="bt3" OnClick="ButtonOperate1_Click" />
        <asp:Button ID="ButtonDelete" runat="server" CausesValidation="False" Text="删除" OnClientClick=" return EditButton() "
            CssClass="bt2" OnClick="ButtonDelete_Click" />
        <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        <asp:ObjectDataSource ID="ObjectDataSource" runat="server" SelectMethod="GetShopCategoryApplyInfo"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_ShopInfoList_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBoxShopName" PropertyName="Text" Name="ShopName"
                    Type="String"></asp:ControlParameter>
                <asp:ControlParameter ControlID="TextBoxMemberName" Name="memberLoginID" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter Name="ShopCategoryCode" Type="String" ControlID="HiddenFieldCode"
                    PropertyName="Value" />
                <asp:ControlParameter ControlID="DropDownListIsAudit" DefaultValue="-2" Name="IsAudit"
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="TextBoxStartTime" DefaultValue="" Name="startTime"
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="TextBoxEndTime" DefaultValue="" Name="endTime" PropertyName="Text"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
    </form>
</body>
</html>
