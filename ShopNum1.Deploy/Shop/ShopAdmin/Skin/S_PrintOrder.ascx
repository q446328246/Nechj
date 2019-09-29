<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="print-layout">
    <div class="print-btn" id="printbtn" title="选择喷墨或激光打印机<br/>根据下列纸张描述进行<br/>设置并打印发货单据">
        <i></i><a href="javascript:void(0);">打印</a></div>
    <div class="a5-size">
    </div>
    <dl class="a5-tip">
        <dt>
            <h1>
                A5</h1>
            <em>Size: 210mm x 148mm</em></dt>
        <dd>
            当打印设置选择A5纸张、横向打印、无边距时每张A5打印纸可输出1页订单。</dd>
    </dl>
    <div class="a4-size">
    </div>
    <dl class="a4-tip">
        <dt>
            <h1>
                A4</h1>
            <em>Size: 210mm x 297mm</em></dt>
        <dd>
            当打印设置选择A4纸张、竖向打印、无边距时每张A4打印纸可输出2页订单。</dd>
    </dl>
    <div class="print-page">
        <div id="printarea">
            <% DataTable dt = S_PrintOrder.dt_OrderInfo;
               if (dt != null)
               {
                   int jk = 0;
                   for (int i = 0; i < dt.Rows.Count; i++)
                   { %>
            <% if ((i % 14 == 1 || i == 0) && i != 1)
               {
                   jk++; %>
            <div class="orderprint">
                <div class="top">
                    <div class="full-title">
                        <%= S_PrintOrder.ShopName %>店铺发货单</div>
                </div>
                <table class="buyer-info">
                    <tr>
                        <td class="w200">
                            收货人：<%= S_PrintOrder.Name %>
                        </td>
                        <td class="w300">
                            电话：<%= S_PrintOrder.Tel %>
                        </td>
                        <td>
                            手机：<%= S_PrintOrder.Mobile %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            地址：<%= S_PrintOrder.Address %>
                        </td>
                        <td>
                            邮编：<%= S_PrintOrder.PostCode %>
                        </td>
                        <td>
                            订单号：<%= S_PrintOrder.OrderNumber %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            下单时间：<%= S_PrintOrder.CreateTime %>
                        </td>
                        <td>
                            快递名称：<%= S_PrintOrder.Logisticscompany %>
                        </td>
                        <td>
                            <span>发货单号：<%= S_PrintOrder.ShipmentNumber %></span>
                        </td>
                    </tr>
                </table>
                <table class="order-info">
                    <thead>
                        <tr>
                            <th class="w40">
                                序号
                            </th>
                            <th class="tl">
                                商品名称
                            </th>
                            <th class="w150 tl">
                                规格
                            </th>
                            <th class="w70 tl">
                                单价(元)
                            </th>
                            <th class="w50">
                                数量
                            </th>
                            <th class="w70 tl">
                                小计(元)
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <% } %>
                        <tr>
                            <td>
                                <%= i + 1 %>
                            </td>
                            <td class="tl">
                                <%= dt.Rows[i]["productname"] %>
                            </td>
                            <td class="tl">
                                <%= dt.Rows[i]["specificationname"].ToString().Replace("%2F", "/") %>
                            </td>
                            <td class="tl">
                                &yen;<%= dt.Rows[i]["buyprice"] %>
                            </td>
                            <td>
                                <%= dt.Rows[i]["buynumber"] %>
                            </td>
                            <td class="tl">
                                &yen;<%=Convert.ToDecimal( dt.Rows[i]["buyprice"])* Convert.ToDecimal( dt.Rows[i]["buynumber"]) %>
                            </td>
                        </tr>
                        <% if ((i % 14 == 0 || (i +1 )== dt.Rows.Count ) && i != 0 || dt.Rows.Count == 1)
                           { %>
                        <tr>
                            <th>
                            </th>
                            <th class="tl" colspan="3">
                            </th>
                            <th>
                            </th>
                            <th class="tl">
                            </th>
                        </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                            <th colspan="10">
                                <span>订单总额：&yen;<%= S_PrintOrder.TotalPrice %></span><span>支付费用：&yen;<%= S_PrintOrder.PaymentPrice %></span><span>运费：&yen;<%= S_PrintOrder.DispatchPrice %></span>
                                <span>店铺：<%= S_PrintOrder.ShopName %></span><span>一审：               </span>
                                <span>二审：                 </span><span>电话：<%= S_PrintOrder.ShopMobile %></span><span>专区：<%= S_PrintOrder.Area%></span>
                            </th>
                        </tr>
                    </tfoot>
                </table>
                <div class="explain">
                </div>
                <div class="tc page">
                    第<%= jk %>页/共<%= dt.Rows.Count/14 %>页</div>
            </div>
            <% } %>
            <% }
               }
            %>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">

    $(function () {
        $("#printbtn").click(function () {
            $("#printarea").printArea();
        });
    });
    $('#printbtn').poshytip({
        className: 'tip-yellowsimple',
        showTimeout: 1,
        alignTo: 'target',
        alignX: 'center',
        alignY: 'bottom',
        offsetY: 5,
        allowTipHover: false
    });
</script>
