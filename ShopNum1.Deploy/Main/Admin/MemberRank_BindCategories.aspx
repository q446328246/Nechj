<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberRank_BindCategories.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.MemberRank_BindCategories" %>

<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>绑定专区</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="right">
            <div class="rhigth">
                <div class="rl">
                </div>
                <div class="rcon">
                    <h3>
                        <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="绑定可读专区"></asp:Label></h3>
                </div>
                <div class="rr">
                </div>
            </div>
        </div>

        <div>

            <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="category_name" DataValueField="id">
            </asp:CheckBoxList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Connection String %>" SelectCommand="SELECT [category_name], [id] FROM [ShopNum1_Shop_CustomerCategory]"></asp:SqlDataSource>
        </div>
        <div class="tablebtn">
            <asp:Button ID="ButtonConfirm" runat="server" Text="确定" CssClass="fanh" OnClick="ButtonConfirm_Click" />
            <asp:Button ID="Button3" runat="server" CssClass="fanh" CausesValidation="false"
                PostBackUrl="~/Main/Admin/MemberRank_LinkCategory.aspx" Text="返回等级页面" />
        </div>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        <asp:HiddenField ID="IsReadOrBuy" runat="server" Value="0" />
        <asp:HiddenField ID="IsCreateOrEdit" runat="server" Value="0" />
    </form>
</body>
</html>
