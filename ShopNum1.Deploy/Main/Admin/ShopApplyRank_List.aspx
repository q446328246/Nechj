<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopApplyRank_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopApplyRank_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>店铺等级审核</title>
    <link rel="stylesheet" type="text/css" href="css/index.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body style="background-image: url(images/Bg_right.gif); background-repeat: repeat;
    padding: 0;">
    <form id="form1" runat="server">
    <div class="navigator">
        <asp:Label ID="LabelTitle" runat="server" Text="【店铺等级列表】" />
    </div>
    <div class="query">
        <table cellpadding="0" cellspacing="1" width="100%">
            <tr>
                <td align="right">
                    <asp:Localize ID="LocalizeIsAudit" runat="server" Text="会员ID："></asp:Localize>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxMemLoginID" CssClass="allinput3" runat="server"></asp:TextBox>
                </td>
                <td align="right">
                </td>
                <td>
                </td>
                <td>
                    <asp:Button ID="ButtonSearch" runat="server" Text="查询" CssClass="bt2" OnClick="ButtonSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div class="table1">
        <cc1:num1gridview id="Num1GridViewShow" runat="server" autogeneratecolumns="False"
            allowpaging="True" allowsorting="True" ascendingimageurl="~/images/SortAsc.gif"
            descendingimageurl="~/images/SortDesc.gif" width="100%" addsequencecolumn="False"
            allowmulticolumnsorting="False" bordercolor="#CCDDEF" borderstyle="Solid" borderwidth="1px"
            cellpadding="4" del="False" deleteprompttext="确实要删除指定的记录吗？" edit="False" fixheader="False"
            gridviewsortdirection="Ascending" pagingstyle="None" style="margin-left: 2px;"
            tablename="" datasourceid="ObjectDataSourceDate">
                    <HeaderStyle HorizontalAlign="Center" BackColor="#6699CC" Font-Bold="True" ForeColor="#FFFFFF">
                    </HeaderStyle>
                    <PagerStyle HorizontalAlign="Left" BackColor="#EEEEEE" ForeColor="#6699CC"></PagerStyle>
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <input id="checkboxItem" value='<%# Eval("ID") %>' type="checkbox" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="店铺等级" SortExpression="Name" />
                        <asp:BoundField DataField="MemberLoginID" HeaderText="会员ID" 
                                        SortExpression="MemberLoginID" />
                        <asp:TemplateField HeaderText="店铺ID" SortExpression="shopid">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#"shop" + Eval("shopid") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ApplyTime" HeaderText="申请时间" 
                                        SortExpression="ApplyTime" />
                    </Columns>
                </cc1:num1gridview>
    </div>
    <div class="vote2">
        <asp:Button ID="ButtonAudit" runat="server" Visible="false" Text="审核通过" CssClass="bt3"
            OnClick="ButtonAudit_Click" OnClientClick=" return AuditButton() " />
        <asp:Button ID="ButtonCancelAudit" runat="server" Visible="false" Text="审核未通过" CssClass="bt3"
            OnClientClick=" return AuditButton() " OnClick="ButtonCancelAudit_Click" />
        <asp:Button ID="ButtonDelete" runat="server" Text="删除" CssClass="bt2" OnClick="ButtonDelete_Click"
            OnClientClick=" return DeleteButton() " />
        <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
    </div>
    <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="GetShopRankApply"
        TypeName="ShopNum1.ShopBusinessLogic.Shop_ShopApplyRank_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxMemLoginID" DefaultValue="-1" Name="memLoginID"
                PropertyName="Text" Type="String" />
            <asp:Parameter DefaultValue="1" Name="isaudit" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
    </form>
</body>
</html>
