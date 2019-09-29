<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="SurveyOption_Manage.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.SurveyOption_Manage" %>

<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="新增调查项"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td width="90" style="text-align: right; padding-right: 5px;" valign="top">
                            添加调查选项：
                        </td>
                        <td style="width: 350px;">
                            <asp:TextBox ID="textBoxNAME" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="textBoxNAME"
                                Display="Dynamic" ValidationGroup="ValidationGroup_Add" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        </td>
                        <td valign="top">
                            <asp:Button ID="ButtonConfirm" ValidationGroup="ValidationGroup_Add" runat="server"
                                Text="确定" OnClick="ButtonOK_Click" CssClass="dele" />
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <asp:Button ID="ButtonDelete" runat="server" Text="批量删除" OnClientClick="return DeleteButton()"
                        OnClick="ButtonDelete_Click" CssClass="shanchu com" />
                    <%--<input  type="button"  class="qb"  value="返回列表" name="" />--%>
                    <asp:Button ID="ButtonBack" runat="server" Text="返回列表" CssClass="chongxinfs picbtn"
                        PostBackUrl="~/Main/Admin/SurveyTheme_Manage.aspx" />
                    <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                </div>
            </div>
            <cc1:Num1GridView ID="num1GridViewShow" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" DataSourceID="ObjectDataSourceData" Width="98%" AscendingImageUrl="~/images/SortAsc.gif"
                DescendingImageUrl="~/images/SortDesc.gif" BorderColor="#CCDDEF" BorderStyle="Solid"
                BorderWidth="1px" CellPadding="4" Style="margin-top: 15px;">
                <footerstyle backcolor="#CCCC99" />
                <headerstyle horizontalalign="Center" cssclass="list_header" forecolor="White"></headerstyle>
                <%--分页--%>
                <pagerstyle backcolor="#F7F7DE" forecolor="Black" horizontalalign="Right" />
                <selectedrowstyle backcolor="#CE5D5A" font-bold="True" forecolor="White" />
                <alternatingrowstyle backcolor="White" />
                <columns>
                        <asp:TemplateField ItemStyle-Width="50px">
                            <HeaderTemplate>
                                <input id="checkboxAll" type="checkbox" onclick="javascript: SelectAllCheckboxes(this);" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"  />
                            <ItemStyle HorizontalAlign="Center"  />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Guid" HeaderText="GUID" Visible="False" />
                        <asp:BoundField DataField="Name" HeaderText="选项内容" SortExpression="Name">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Count" HeaderText="统计次数" SortExpression="Count">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </columns>
            </cc1:Num1GridView>
        </div>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_SurveyOption_Action" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:QueryStringParameter Name="guid" QueryStringField="guid" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="HiddenFieldSurveyGuid" runat="server" />
    </div>
    </form>
</body>
</html>
