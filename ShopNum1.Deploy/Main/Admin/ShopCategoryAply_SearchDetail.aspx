<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopCategoryAply_SearchDetail.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopCategoryAply_SearchDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>µÍ∆Ã…Í«Î∑÷¿‡≤Èø¥œÍœ∏</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelTitle" runat="server" Text="µÍ∆Ã…Í«Î∑÷¿‡≤Èø¥œÍœ∏"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Localize ID="LocalizeName" runat="server" Text="µÍ∆Ã√˚≥∆£∫"></asp:Localize>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxShopName" CssClass="tinput" ReadOnly="true" runat="server"></asp:TextBox>
                            <span>«Î ‰»ÎµÍ∆Ã√˚≥∆</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localizereplacement" runat="server" Text="…Í«ÎµÍ∆Ãª·‘±£∫"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMemberLoginID" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>«Î ‰»Î…Í«ÎµÍ∆Ãª·‘±</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize2" runat="server" Text="…Í«Î«∞µÍ∆Ã∑÷¿‡£∫"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOldShopCategory" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>«Î ‰»Î…Í«Î«∞µÍ∆Ã∑÷¿‡</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize3" runat="server" Text="…Í«Î«∞µÍ∆Ã∆∑≈∆£∫"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOldShopBrand" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>«Î ‰»Î…Í«Î«∞µÍ∆Ã∆∑≈∆</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize4" runat="server" Text="…Í«ÎµÍ∆Ã∑÷¿‡£∫"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxShopApplyCategory" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>«Î ‰»Î…Í«ÎµÍ∆Ã∑÷¿‡</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize5" runat="server" Text="…Í«ÎµÍ∆Ã∆∑≈∆£∫"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxShopApplyBrand" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>«Î ‰»Î…Í«Î«∞µÍ∆Ã∑÷¿‡</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize6" runat="server" Text="…Í«Î ±º‰£∫"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxApplyTime" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>«Î ‰»Î…Í«Î ±º‰</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize1" runat="server" Text="±∏◊¢£∫"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxComment" TextMode="MultiLine" Height="100px" Width="500px"
                                CssClass="tinput txtarea" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonBack" CssClass="fanh" runat="server" Text="∑µªÿ¡–±Ì" OnClick="ButtonBack_Click" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
