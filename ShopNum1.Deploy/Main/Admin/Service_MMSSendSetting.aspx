<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Service_MMSSendSetting.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Service_MMSSendSetting" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>站点设置</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script src="js/CommonJS.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    短信发送设置</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="180px;">
                            <asp:Label ID="LabelPayIsMMS" runat="server" Text="付款时是否给买家发送短信："></asp:Label>
                            <td>
                                <asp:DropDownList ID="DropDownListPayIsMMS" runat="server" Width="220px" CssClass="tselect">
                                    <asp:ListItem Value="0">不发送短信</asp:ListItem>
                                    <asp:ListItem Value="1">发送短信</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelShipmentIsMMS" runat="server" Text="发货时是否给买家发送短信："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:DropDownList ID="DropDownListShipmentIsMMS" runat="server" Width="220px" CssClass="tselect">
                                <asp:ListItem Value="0">不发送短信</asp:ListItem>
                                <asp:ListItem Value="1">发送短信</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelShipmentOKIsMMS" runat="server" Text="确认收货时是否给买家发送短信："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListShipmentOKIsMMS" runat="server" Width="220px" CssClass="tselect">
                                <asp:ListItem Value="0">不发送短信</asp:ListItem>
                                <asp:ListItem Value="1">发送短信</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelOrderIsMMS" runat="server" Text="下订单时是否给买家发送短信："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListOrderIsMMS" runat="server" Width="220px" CssClass="tselect">
                                <asp:ListItem Value="0">不发送短信</asp:ListItem>
                                <asp:ListItem Value="1">发送短信</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label2" runat="server" Text="下订单时是否给商家发送短信："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListOrderToShopIsMMS" runat="server" Width="220px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">不发送短信</asp:ListItem>
                                <asp:ListItem Value="1">发送短信</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelCancelOrderIsMMS" runat="server" Text="取消订单时是否给买家发送短信："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListCancelOrderIsMMS" runat="server" Width="220px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">不发送短信</asp:ListItem>
                                <asp:ListItem Value="1">发送短信</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label25" runat="server" Text="注册成功后是否给会员发送短信："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListRegistOrderIsMMS" runat="server" Width="220px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">不发送短信</asp:ListItem>
                                <asp:ListItem Value="1">发送短信</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelApplyOpenShopIsMMS" runat="server" Text="申请开店后是否给店铺发送短信："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListApplyOpenShopIsMMS" runat="server" Width="220px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">不发送短信</asp:ListItem>
                                <asp:ListItem Value="1">发送短信</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelAuditOpenShopIsMMS" runat="server" Text="开店审核后是否给店铺发送短信："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListAuditOpenShopIsMMS" runat="server" Width="220px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">不发送短信</asp:ListItem>
                                <asp:ListItem Value="1">发送短信</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label1" runat="server" Text=" 支付是否需要短信确认码："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:DropDownList ID="DropDownListMobileCheck" runat="server" CssClass="tselect"
                                Width="220px">
                                <asp:ListItem Value="0">不需要验证</asp:ListItem>
                                <asp:ListItem Value="1">需要验证</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonEdit" runat="server" Text="确定" CssClass="fanh" OnClick="ButtonEdit_Click" />
                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                <asp:HiddenField ID="HiddenFieldXmlPath" runat="server" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
