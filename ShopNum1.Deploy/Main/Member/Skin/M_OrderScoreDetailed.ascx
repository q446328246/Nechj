<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_OrderScoreDetailed.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_OrderScoreDetailed" %>

<%@ Import Namespace="System.Data" %>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
    <tr>
        <th colspan="2" scope="col">
            红包订单详细
        </th>
        <tr>
            <td class="bordleft" style="width: 100px">
                订单编号：
            </td>
            <td class="bordrig">
                <asp:Label ID="LabelOrderNumber" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                订单时间 ：
            </td>
            <td class="bordrig">
                <asp:Label ID="LabelCreateTime" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                订单状态 ：
            </td>
            <td class="bordrig">
                <asp:Label ID="LabelOderStatus" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="bordleft" style="border-bottom: solid 1px #c6dfff;">
                处理时间：
            </td>
            <td class="bordrig" style="border-bottom: solid 1px #c6dfff;">
                <asp:Label ID="LabelConfirmTime" runat="server"></asp:Label>
            </td>
        </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
    <tr>
        <th colspan="6" scope="col">
            红包商品信息
        </th>
    </tr>
    <tr>
        <td style="text-align: center" class="bordleft2">
            商品图片
        </td>
        <td style="text-align: center" class="bordleft1">
            商品名称
        </td>
        <td style="text-align: center" class="bordleft1">
            市场价格
        </td>
        <td style="text-align: center" class="bordleft1">
            商品红包
        </td>
        <td style="text-align: center" class="bordleft1">
            数量
        </td>
        <td style="text-align: center" class="bordrig">
            支付红包
        </td>
    </tr>
    <asp:Repeater ID="RepeaterProduct" runat="server">
        <ItemTemplate>
            <tr style="height: 0; margin: 0; padding: 0; border: 0;">
                <td style="width: 100px; padding: 10px; border-bottom: solid 1px #c6dfff;" class="bordleft2">
                    <a target="_blank" href='<%#ShopUrlOperate.shopDetailHref(((DataRowView)Container.DataItem).Row["ProductGuid"].ToString(),((DataRowView)Container.DataItem).Row["IsShopMemLoginID"].ToString(),"ProductIntegral")%>'
                        class="sroceimg">
                        <asp:Image ID="ImageProduct" runat="server" Width="120" Height="120" ImageUrl='<%# ((DataRowView)Container.DataItem).Row["OriginalImge"]%>'
                            onerror="javascript:this.src='/ImgUpload/noImage.gif'" /></a>
                </td>
                <td class="bordleft1" style="text-align: center; border-bottom: solid 1px #c6dfff;">
                    <a target="_blank" href='<%#ShopUrlOperate.shopDetailHref(((DataRowView)Container.DataItem).Row["ProductGuid"].ToString(),((DataRowView)Container.DataItem).Row["IsShopMemLoginID"].ToString(),"ProductIntegral")%>'
                        class="sroceimg">
                        <%# ((DataRowView)Container.DataItem).Row["ProductName"]%>
                    </a>
                </td>
                <td class="bordleft1" style="text-align: center; border-bottom: solid 1px #c6dfff;">
                    <%# ((DataRowView)Container.DataItem).Row["MarketPrice"]%>
                </td>
                <td id="tdPaymentName" runat="server" class="bordleft1" style="text-align: center;
                    border-bottom: solid 1px #c6dfff;">
                    <%# ((DataRowView)Container.DataItem).Row["ProductScore"]%>
                </td>
                <td id="tdDispatchPrice" runat="server" class="bordleft1" style="text-align: center;
                    border-bottom: solid 1px #c6dfff;">
                    <%# ((DataRowView)Container.DataItem).Row["BuyNumber"]%>
                </td>
                <td id="tdShouldPayPrice" runat="server" class="bordrig" style="text-align: center;
                    border-bottom: solid 1px #c6dfff;">
                    <%# ((DataRowView)Container.DataItem).Row["Score"]%>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>
<table width="100%" border="0" cellpadding="0" cellspacing="0" class="biaod" style="margin-top: 15px;">
    <tr>
        <th colspan="6" scope="col">
            卖家信息
        </th>
    </tr>
    <tr>
        <td style="width: 90px; text-align: right" class="bordleft2">
            掌柜ID：
        </td>
        <td class="bordleft1">
            <asp:Label ID="LabelShopID" runat="server"></asp:Label>
        </td>
        <td style="width: 90px; text-align: right" class="bordleft1">
            掌柜名：
        </td>
        <td class="bordleft1">
            <asp:Label ID="LabelShopName" runat="server"></asp:Label>
        </td>
        <td style="width: 90px; text-align: right" class="bordleft1">
            城市：
        </td>
        <td class="bordrig">
            <asp:Label ID="LabelShopAddress" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; border-bottom: solid 1px #c6dfff;" class="bordleft2">
            联系电话：
        </td>
        <td class="bordleft1" style="border-bottom: solid 1px #c6dfff;">
            <asp:Label ID="LabelShopPhone" runat="server"></asp:Label>
        </td>
        <td style="text-align: right; border-bottom: solid 1px #c6dfff;" class="bordleft1">
            邮件：
        </td>
        <td class="bordrig" colspan="3" style="border-bottom: solid 1px #c6dfff;">
            <asp:Label ID="LabelShopEmail" runat="server"></asp:Label>
        </td>
        <td style="display: none;">
            <asp:Label ID="LabelYiaoCode" Visible="false" runat="server"></asp:Label>
        </td>
    </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
    <tr>
        <th colspan="6" scope="col">
            收货信息
        </th>
    </tr>
    <tr>
        <td style="width: 90px; text-align: right" class="bordleft2">
            收人姓名：
        </td>
        <td class="bordleft1">
            <asp:Label ID="LabelName" runat="server"></asp:Label>
        </td>
        <td style="width: 90px; text-align: right" class="bordleft1">
            邮编号码：
        </td>
        <td class="bordleft1">
            <asp:Label ID="LabelPostalcode" runat="server"></asp:Label>
        </td>
        <td style="width: 90px; text-align: right" class="bordleft1">
            联系电话：
        </td>
        <td class="bordrig">
            <asp:Label ID="LabelMobile" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; border-bottom: solid 1px #c6dfff;" class="bordleft2">
            电子邮件：
        </td>
        <td class="bordleft1" style="border-bottom: solid 1px #c6dfff;">
            <asp:Label ID="LabelEmail" runat="server"></asp:Label>
        </td>
        <td style="text-align: right; border-bottom: solid 1px #c6dfff;" class="bordleft1">
            收货地址 ：
        </td>
        <td colspan="3" class="bordrig" style="border-bottom: solid 1px #c6dfff;">
            <asp:Label ID="LabelAddress" runat="server"></asp:Label>
        </td>
    </tr>
</table>
<div style="text-align: center; margin: 20px 0px 50px 0px;">
    <asp:Button ID="ButtonBack" runat="server" Text="返回列表" CssClass="baocbtn" 
        onclick="ButtonBack_Click" />
</div>
<asp:HiddenField ID="CheckGuid" runat="server" />
<asp:HiddenField ID="HiddenFieldShopMemLoginID" runat="server" />
