<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="UptateRank_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.UptateRank_Operate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改店铺等级</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script language="javascript" type="text/javascript">
        function Changes(element) {
            var AllCheckBox = document.getElementsByTagName("input");
            for (var i = 0; i < AllCheckBox.length; i++) {
                if (AllCheckBox[i].type == "checkbox") {
                    AllCheckBox[i].checked = false;
                }
            }
            element.checked = true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="修改店铺等级"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td valign="top">
                            <asp:LinkButton ID="BottonConfirm" runat="server" OnClientClick=" return EditButton() "
                                OnClick="ButtonConfirm_Click" CssClass="bji lmf_btn"><span>修改</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                            <asp:LinkButton ID="Button1" runat="server" CssClass="chongxinfs lmf_btn" CausesValidation="false"
                                PostBackUrl="~/Main/Admin/ShopInfoList_Manage.aspx"><span>返回列表</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                            <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                        </td>
                    </tr>
                </table>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceDate" AllowMultiColumnSorting="False"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4"
                GridLines="Vertical" Style="margin-top: 15px;">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--分页--%>
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <input id="checkboxItem" onclick="Changes(this)" runat="server" type="checkbox" value='<%# Eval("Guid") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="等级名称" SortExpression="Name" />
                    <asp:BoundField DataField="MaxProductCount" HeaderText="可添加的商品数量" SortExpression="MaxProductCount" />
                    <asp:TemplateField HeaderText="等级图片" SortExpression="Pic">
                        <ItemTemplate>
                            <img alt="" src='<%# Page.ResolveUrl(Eval("Pic").ToString()) %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="Search"
        TypeName="ShopNum1.ShopBusinessLogic.Shop_Rank_Action">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="isDeleted" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldShopRank" runat="server" Value="0" />
    </form>
    <script type="text/javascript" src="js/showimg.js"> </script>
</body>
</html>
