<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Service_EmailSendSetting.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Service_EmailSendSetting" %>

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
                    邮件发送设置</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table border="0" cellpadding="0" cellspacing="0" class="shoptable">
                <tr>
                    <th align="right" width="260px">
                        <div class="shopth">
                            <asp:Label ID="LabelPayIsEmail" runat="server" Text="付款时是否给买家发送邮件："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListPayIsEmail" runat="server" Width="180px" CssClass="tselect">
                                <asp:ListItem Value="0">不发送邮件</asp:ListItem>
                                <asp:ListItem Value="1">发送邮件</asp:ListItem>
                            </asp:DropDownList>
                            <%-- <span>请选择</span>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelShipmentIsEmail" runat="server" Text="发货时是否给买家发送邮件："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListShipmentIsEmail" runat="server" Width="180px" CssClass="tselect">
                                <asp:ListItem Value="0">不发送邮件</asp:ListItem>
                                <asp:ListItem Value="1">发送邮件</asp:ListItem>
                            </asp:DropDownList>
                            <%--   <span>请选择</span>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelShipmentOKIsEmail" runat="server" Text="确认收货时是否给买家发送邮件："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListShipmentOKIsEmail" runat="server" Width="180px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">不发送邮件</asp:ListItem>
                                <asp:ListItem Value="1">发送邮件</asp:ListItem>
                            </asp:DropDownList>
                            <%-- <span>请选择</span>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelOrderIsEmail" runat="server" Text="下订单时是否给买家发送邮件："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListOrderIsEmail" runat="server" Width="180px" CssClass="tselect">
                                <asp:ListItem Value="0">不发送邮件</asp:ListItem>
                                <asp:ListItem Value="1">发送邮件</asp:ListItem>
                            </asp:DropDownList>
                            <%--   <span>请选择</span>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="Label1" runat="server" Text="下订单时是否给商家发送邮件："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListOrderToShopIsEmail" runat="server" Width="180px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">不发送邮件</asp:ListItem>
                                <asp:ListItem Value="1">发送邮件</asp:ListItem>
                            </asp:DropDownList>
                            <%-- <span>请选择</span>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelCancelOrderIsEmail" runat="server" Text="取消订单时是否给卖家发送邮件："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListCancelOrderIsEmail" runat="server" Width="180px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">不发送邮件</asp:ListItem>
                                <asp:ListItem Value="1">发送邮件</asp:ListItem>
                            </asp:DropDownList>
                            <%--  <span>请选择</span>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelMemberRegister" runat="server" Text="注册成功后是否给会员发邮件："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListMemberRegister" runat="server" Width="180px" CssClass="tselect">
                                <asp:ListItem Value="0">不发送邮件</asp:ListItem>
                                <asp:ListItem Value="1">发送邮件</asp:ListItem>
                            </asp:DropDownList>
                            <%-- <span>请选择</span>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="Label28" runat="server" Text="注册时是否需要给会员发送激活邮件："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListRegIsActivationEmail" runat="server" Width="180px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">不发送邮件</asp:ListItem>
                                <asp:ListItem Value="1">发送邮件</asp:ListItem>
                            </asp:DropDownList>
                            <%--<span>请选择</span>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelApplyOpenShopIsEmail" runat="server" Text="申请开店后是否给店铺发邮件："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListApplyOpenShopIsEmail" runat="server" Width="180px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">不发送邮件</asp:ListItem>
                                <asp:ListItem Value="1">发送邮件</asp:ListItem>
                            </asp:DropDownList>
                            <%--  <span>请选择</span>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelAuditOpenShopIsEmail" runat="server" Text="开店审核后是否给店铺发邮件："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListAuditOpenShopIsEmail" runat="server" Width="180px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">不发送邮件</asp:ListItem>
                                <asp:ListItem Value="1">发送邮件</asp:ListItem>
                            </asp:DropDownList>
                            <%-- <span>请选择</span>--%>
                        </div>
                    </td>
                </tr>
            </table>
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
</html>