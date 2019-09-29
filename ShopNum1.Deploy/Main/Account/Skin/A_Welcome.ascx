<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="A_Welcome.ascx.cs" Inherits="ShopNum1.Deploy.Main.Account.Skin.A_Welcome" %>
<asp:Repeater ID="Rep_AoccountDetail" runat="server">
    <ItemTemplate>
        <div class="myzh">
            <div class="myzh_right">
                <div class="pxian">
                    ��ӭ��<span class="redht">
                        <%# DataBinder.Eval(Container.DataItem, "MemLoginID")%></span></div>
                <div style="padding-top: 10px;">
                    <div style=" display:none;" >
                    �����<strong class="red"><%# DataBinder.Eval(Container.DataItem, "Score_hv")%></strong>
                    </div> 
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                 �����(BV)��<span class="redbold">��<%# DataBinder.Eval(Container.DataItem, "AdvancePayment")%></span>
                            </td>
                            <td>
                                <input name="12" type="button" class="chax" value="��ֵ" onclick="window.location.href='A_AdPayRecharge.aspx'" />
                            </td>
                        </tr>
                        <tr >
                            <td colspan="2">
                                ����Դ��(LNEC)��<span class="redbold"><%# DataBinder.Eval(Container.DataItem, "Score_pv_a")%></span>
                            </td>
                        </tr>
                        <tr >
                            <td colspan="2">
                                ����Դ��(NEC)��<span class="redbold"><%# DataBinder.Eval(Container.DataItem, "Score_dv")%></span>
                            </td>
                        </tr>
                        <tr >
                            <td colspan="2">
                                ����̣�<span class="redbold"><%# Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "Score_pv_b"))*Convert.ToDecimal(0.1)%></span>����
                            </td>
                        </tr>
                        <tr style=" display:none;">
                            <td colspan="2">
                                �̳ǻ��֣�PV����<span class="redbold">��<%# DataBinder.Eval(Container.DataItem, "Score_pv_a")%></span>
                            </td>
                        </tr>
                        <tr style=" display:none;">
                            <td colspan="2">
                                �̳��������֣�PV����<span class="redbold">��<%# DataBinder.Eval(Container.DataItem, "Score_pv_b")%></span>
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
                �����������</div>
            <dl class="maij">
                <dt>�򵽵���Ʒ��</dt>
                <dd>
                    �����30���ڣ����Ĺ��򶩵�<span class="red"><%# DataBinder.Eval(Container.DataItem, "buyOrder")%></span>����Ʒ���뵽
                    <a target="_parent" href="/main/member/m_index.aspx?tomurl=m_orderlist.aspx" onclick="subItem(this)"
                        class="lmf_act" style="color: #ff6600;">������Ʒ</a> �鿴 ��</dd>
            </dl>
            <div class="ptitle2">
                ������������</div>
            <dl class="maij">
                <dt>��������Ʒ��</dt>
                <dd>
                    �����30���ڣ����ĳ��۶�����<span class="red"><%# DataBinder.Eval(Container.DataItem, "shopOrder")%></span>�����뵽
                    <a target="_parent" href="/shop/shopadmin/s_index.aspx?tosurl=s_order_list.aspx"
                        onclick="subItem(this)" class="lmf_act" style="color: #ff6600;">������Ʒ</a> �鿴��</dd>
            </dl>
        </div>
    </ItemTemplate>
</asp:Repeater>
