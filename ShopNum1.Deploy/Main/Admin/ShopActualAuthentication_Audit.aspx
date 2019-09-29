<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopActualAuthentication_Audit.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopActualAuthentication_Audit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>店铺实名认证审核列表</title>
    <link type="text/css" rel="Stylesheet" href="css/index.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body style="background-image: url(images/Bg_right.gif); background-repeat: repeat;
    font-size: 12px; padding: 0;">
    <div class="navigator">
        【店铺实名认证审核列表】<br />
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
                    店铺ID：
                </td>
                <td class="style1">
                    <asp:TextBox ID="TextBoxshopID" CssClass="allinput1" runat="server"></asp:TextBox>
                </td>
                <td align="right" class="style2">
                    店铺名称：
                </td>
                <td colspan="1">
                    <asp:TextBox ID="TextBoxshopName" CssClass="allinput1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    法人代表:
                </td>
                <td>
                    <asp:TextBox ID="TextBoxlegalPerson" CssClass="allinput1" runat="server"></asp:TextBox>
                </td>
                <td align="right">
                    注册号：
                </td>
                <td class="style1">
                    <asp:TextBox ID="TextBoxregistrationNum" CssClass="allinput1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="ButtonSearch" runat="server" Text="查询" CssClass="bt2" OnClick="ButtonSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <cc1:num1gridview id="Num1GridViewShow" runat="server" width="100%" addsequencecolumn="False"
                allowmulticolumnsorting="False" allowpaging="True" autogeneratecolumns="False"
                bordercolor="#CCDDEF" borderstyle="Solid" borderwidth="1px" cellpadding="4" datasourceid="ObjectDataSourceData"
                del="False" deleteprompttext="确实要删除指定的记录吗？" edit="False" fixheader="False" gridviewsortdirection="Ascending"
                pagingstyle="None" style="margin-left: 2px;" tablename="" allowsorting="True">
                        <HeaderStyle HorizontalAlign="Center" BackColor="#6699CC" Font-Bold="True" ForeColor="#FFFFFF">
                        </HeaderStyle>
                        <PagerStyle HorizontalAlign="Left" BackColor="#EEEEEE" ForeColor="#6699CC"></PagerStyle>
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
                            <asp:BoundField DataField="ShopID" HeaderText="申请店铺ID" SortExpression="ShopID" />
                            <asp:BoundField DataField="ShopName" HeaderText="店铺名称" SortExpression="ShopName" />
                            <asp:BoundField DataField="LegalPerson" HeaderText="法人代表" SortExpression="LegalPerson" />
                            <asp:BoundField DataField="RegistrationNum" HeaderText="注册号" SortExpression="RegistrationNum" />
                        </Columns>
                    </cc1:num1gridview>
            <div class="vote" style="padding-left: 2px;">
                <asp:Button ID="ButtonSearchShop" runat="server" CausesValidation="False" Text="查看"
                    OnClientClick=" return EditButton() " CssClass="bt2" OnClick="ButtonSearchShop_Click"
                    Visible="false" />
                <asp:Button ID="ButtonOperate" runat="server" Text="审核通过" OnClick="ButtonOperate_Click"
                    OnClientClick=" return OperateButton() " CssClass="bt3" Visible="false" />
                <asp:Button ID="ButtonOperate1" runat="server" Text="审核操作" OnClientClick=" return EditButton() "
                    CssClass="bt3" OnClick="ButtonOperate1_Click" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SearchIsAudit"
                    TypeName="ShopNum1.ShopBusinessLogic.Shop_ShopInfo_Action" OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TextBoxshopID" Name="shopID" PropertyName="Text"
                            Type="String" />
                        <asp:ControlParameter ControlID="TextBoxshopName" Name="shopName" PropertyName="Text"
                            Type="String" />
                        <asp:ControlParameter ControlID="TextBoxlegalPerson" Name="legalPerson" PropertyName="Text"
                            Type="String" />
                        <asp:ControlParameter ControlID="TextBoxregistrationNum" Name="registrationNum" PropertyName="Text"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
            </div>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
