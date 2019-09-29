<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="OrderScore_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.OrderScore_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>红包订单操作</title>
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
                    红包订单详细综合</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table border="0" cellpadding="0" cellspacing="0" class="ordertable">
                <tr>
                    <td colspan="8" align="left">
                        <div class="shux">
                            <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="商品详细"></asp:Label></div>
                    </td>
                </tr>
                <tr align="center">
                    <td scope="col" style="display: none;">
                        Guid
                    </td>
                    <th scope="col">
                        商品图片
                    </th>
                    <th scope="col">
                        商品名称
                    </th>
                    <th scope="col">
                        货号
                    </th>
                    <th scope="col">
                        市场价
                    </th>
                    <th scope="col">
                        红包
                    </th>
                    <th scope="col">
                        购买数量
                    </th>
                    <th scope="col">
                        小计红包
                    </th>
                    <td style="display: none">
                    </td>
                    <td style="display: none">
                    </td>
                </tr>
                <asp:Repeater ID="RepeaterData" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center" style="display: none;">
                                <asp:Label ID="Label10" runat="server" Text='<%# Eval("ProductGuid") %>'></asp:Label>
                            </td>
                            <td align="center">
                                <a target="_blank" href='<%#ShopUrlOperate.shopDetailHref(Eval("ProductGuid").ToString(), Eval("IsShopMemLoginID").ToString(), "ProductIntegral") %>'>
                                    <asp:Image ID="ImageProduct" runat="server" Width="60" Height="60" ImageUrl='<%# Eval("OriginalImge") %>' />
                                </a>
                            </td>
                            <td align="center">
                                <a target="_blank" href='<%#ShopUrlOperate.shopDetailHref(Eval("ProductGuid").ToString(), Eval("IsShopMemLoginID").ToString(), "ProductIntegral") %>'>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                                </a>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("RepertoryNumber") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("MarketPrice") %>'></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("ProductScore") %>'></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("BuyNumber") %>'></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label12" runat="server" Text='<%# Eval("Score") %>'></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" class="ordertable2">
                <tr>
                    <th colspan="6" align="left">
                        <div class="shux">
                            <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="红包订单信息"></asp:Label>
                        </div>
                    </th>
                </tr>
                <tr>
                    <th width="10%">
                        <asp:Label ID="LabelShopID" runat="server" Text="卖家："></asp:Label>
                    </th>
                    <td width="15%">
                        <asp:Label ID="LabelShopIDValue" runat="server"></asp:Label>
                    </td>
                    <th width="10%">
                        <asp:Label ID="LabelShopName" runat="server" Text="店铺："></asp:Label>
                    </th>
                    <td width="30%">
                        <asp:Label ID="LabelShopNameValue" runat="server"></asp:Label>
                    </td>
                    <th width="10%">
                        <asp:Label ID="LabelOrderNumber" runat="server" Text="订单号："></asp:Label>
                    </th>
                    <td width="23%">
                        <asp:Label ID="LabelOrderNumberValue" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        <asp:Label ID="LabelNameMemLoginID" runat="server" Text="买家："></asp:Label>
                    </th>
                    <td>
                        <asp:Label ID="LabelMemLoginIDValue" runat="server"></asp:Label>
                        <asp:Label ID="LabelMemLoginIDValueShow" runat="server"></asp:Label>
                    </td>
                    <th>
                        <asp:Label ID="LabelOderStatus" runat="server" Text="处理状态："></asp:Label>
                    </th>
                    <td>
                        <asp:Label ID="LabelOderStatusValue" runat="server"></asp:Label>
                    </td>
                    <th>
                        <asp:Label ID="LabelCreateTime" runat="server" Text="下单时间："></asp:Label>
                    </th>
                    <td>
                        <asp:Label ID="LabelCreateTimeValue" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        <asp:Label ID="LabelNameDispatchModeName" runat="server" Text="处理时间："></asp:Label>
                    </th>
                    <td>
                        <asp:Label ID="LabelConfirmTimeValue" runat="server"></asp:Label>
                    </td>
                    <th>
                        <asp:Label ID="LabelTotalScore" runat="server" Text="订单总红包："></asp:Label>
                    </th>
                    <td>
                        <asp:Label ID="LabelTotalScoreValue" runat="server"></asp:Label>
                    </td>
                    <th>
                    </th>
                    <td>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" border="0" class="ordertable2">
                <tr>
                    <th colspan="6" align="left">
                        <div class="shux">
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="收货人信息"></asp:Label>
                        </div>
                    </th>
                </tr>
                <tr>
                    <td align="left" width="10%">
                        <asp:Label ID="LabelName" runat="server" Text="收货人："></asp:Label>
                    </td>
                    <td align="right" width="40%">
                        <asp:Label ID="LabelNameValue" runat="server"></asp:Label>
                    </td>
                    <td align="right" width="10%">
                        <asp:Label ID="LabelEmail" runat="server" Text="电子邮件："></asp:Label>
                    </td>
                    <td align="left" width="40%">
                        <asp:Label ID="LabelEmailValue" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="LabelAddress" runat="server" Text="地址："></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="LabelAddressValue" runat="server" Text=""></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="LabelPostalcode" runat="server" Text="邮编："></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="LabelPostalcodeValue" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="LabelMobile" runat="server" Text="手机："></asp:Label>
                    </td>
                    <td align="left" colspan="3">
                        <asp:Label ID="LabelMobileValue" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="tablebtn">
        <asp:Button ID="ButtonOderStatus" runat="server" CssClass="fanh" CausesValidation="false"
            Text="处理" OnClick="ButtonOderStatus_Click" Visible="false" />
        <asp:Button ID="ButtonBack" runat="server" CssClass="fanh" CausesValidation="false"
            Text="返回列表" OnClick="ButtonBack_Click" />
        <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" />
    </form>
</body>
</html>
