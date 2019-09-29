<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="A_Welcome.ascx.cs" Inherits="ShopNum1.Deploy.Main.Account.Skin.A_Welcome" %>
<asp:Repeater ID="Rep_AoccountDetail" runat="server">
    <ItemTemplate>
        <div class="myzh">
            <div class="myzh_right">
                <div class="pxian">
                    欢迎！<span class="redht">
                        <%# DataBinder.Eval(Container.DataItem, "MemLoginID")%></span></div>
                <div style="padding-top: 10px;">
                    <div style=" display:none;" >
                    红包：<strong class="red"><%# DataBinder.Eval(Container.DataItem, "Score_hv")%></strong>
                    </div> 
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                 人民币(BV)：<span class="redbold">￥<%# DataBinder.Eval(Container.DataItem, "AdvancePayment")%></span>
                            </td>
                            <td>
                                <input name="12" type="button" class="chax" value="充值" onclick="window.location.href='A_AdPayRecharge.aspx'" />
                            </td>
                        </tr>
                        <tr >
                            <td colspan="2">
                                新能源链(LNEC)：<span class="redbold"><%# DataBinder.Eval(Container.DataItem, "Score_pv_a")%></span>
                            </td>
                        </tr>
                        <tr >
                            <td colspan="2">
                                新能源币(NEC)：<span class="redbold"><%# DataBinder.Eval(Container.DataItem, "Score_dv")%></span>
                            </td>
                        </tr>
                        <tr >
                            <td colspan="2">
                                总里程：<span class="redbold"><%# Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "Score_pv_b"))*Convert.ToDecimal(0.1)%></span>公里
                            </td>
                        </tr>
                        <tr style=" display:none;">
                            <td colspan="2">
                                商城积分（PV）：<span class="redbold">￥<%# DataBinder.Eval(Container.DataItem, "Score_pv_a")%></span>
                            </td>
                        </tr>
                        <tr style=" display:none;">
                            <td colspan="2">
                                商城重消积分（PV）：<span class="redbold">￥<%# DataBinder.Eval(Container.DataItem, "Score_pv_b")%></span>
                            </td>
                        </tr>
                        
                    </table>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
        <div class="tixq">
            <div class="ptitle2">
                买家提醒区：</div>
            <dl class="maij">
                <dt>买到的商品：</dt>
                <dd>
                    在最近30天内，您的购买订单<span class="red"><%# DataBinder.Eval(Container.DataItem, "buyOrder")%></span>个商品，请到
                    <a target="_parent" href="/main/member/m_index.aspx?tomurl=m_orderlist.aspx" onclick="subItem(this)"
                        class="lmf_act" style="color: #ff6600;">已买商品</a> 查看 。</dd>
            </dl>
            <div class="ptitle2">
                卖家提醒区：</div>
            <dl class="maij">
                <dt>卖出的商品：</dt>
                <dd>
                    在最近30天内，您的出售订单有<span class="red"><%# DataBinder.Eval(Container.DataItem, "shopOrder")%></span>个，请到
                    <a target="_parent" href="/shop/shopadmin/s_index.aspx?tosurl=s_order_list.aspx"
                        onclick="subItem(this)" class="lmf_act" style="color: #ff6600;">已卖商品</a> 查看。</dd>
            </dl>
        </div>
    </ItemTemplate>
</asp:Repeater>
