<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="TbRemoveShopBind.aspx.cs" Inherits="ShopNum1.Deploy.Shop.ShopAdmin.TbTop.TbRemoveShopBind" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <link rel='stylesheet' type='text/css' href='../style/style.css' />
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="dpsc_mian">
                <p class="ptitle">
                    <a href="../S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span
                                                                                                   class="breadcrume_text">删除绑定</span></p>
                <div class="pad divheig leftp" style="padding-left: 30px;">
                    <div style="margin-top: 10px;">
                        <asp:LinkButton ID="ButtonRemoveAdmin" runat="server" Text="删除淘宝店铺绑定" OnClientClick=" return confirm('所有该店铺的商品和分类等都将被删除！\n\t是否确认删除？') "
                                        OnClick="ButtonRemoveAdmin_Click" CssClass="shancbtn">删除淘宝店铺绑定</asp:LinkButton>
                    </div>
                    <ul class="scbdul">
                        <li class="ultit">删除绑定后以下信息会被删除</li>
                        <li>1. 店铺的店铺信息</li>
                        <li>2. 店铺的商品信息和商品分类</li>
                        <li>3. 店铺的订单信息</li>
                        <li>4. 店铺的会员信息</li>
                    </ul>
                </div>
            </div>
        </form>
    </body>
</html>