<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<% DataTable dt = S_GroupOrder_List.dt_GroupOrderList;
   DataTable dt_sub = null; %>
<script type="text/javascript" language="javascript">
    $(function () {
        //搜索
        $("#sk").click(function () {
            var state = '<%= ShopNum1.Common.Common.ReqStr("st") %>';
            location.href = "S_SaleOrder_List.aspx?pn=" + escape($("#pname").val()) + "&ord=" + $("#ordernum").val() + "&sd=" + $("#txtstartdate").val() + "&ed=" + $("#txtenddate").val() + "&mid=" + escape($("#memloginid").val()) + "&st=" + state + "&";
        });
        // 全选
        $("input[name='checktop']").click(function () {
            $("#checktop1,#checktop2").attr("checked", $(this).attr("checked"));
            $("input[name='checksub']").attr("checked", $(this).attr("checked"));
        });
        //批量删除
        $(".shanchu").click(function () {
            var xcheck = new Array();
            var shopid;
            var delid = new Array();
            var bflag = true;
            $("input[name='checksub']").each(function () {
                if ($(this).is(":checked")) {
                    delid.push($(this).attr("lang"));
                    shopid = $(this).attr("vname");
                    xcheck.push("'" + $(this).val() + "'");
                    bflag = false;
                }
            });
            if (bflag) {
                alert("请选择一条数据进行删除操作！");
                return false;
            }
            if (confirm("是否执行删除操作？")) {
                $.get("/Api/ShopAdmin/OrderList.ashx?type=subdel&user=" + shopid + "&guid=" + xcheck.join(",") + "", null, function (data) {
                    if (data == "ok") {
                        alert("删除成功！");
                    }
                });
                for (var i in delid) {
                    $("#ord_" + delid[i]).remove();
                }
            }
        });
    });
    // 判断是否是数字

    function checknum(str) {
        var re = /^[0-9]+.?[0-9]*$/;
        if (!re.test(str)) {
            alert("请输入正确的数字！");
            return false;
        } else {
            return true;
        }
    }

    //页面跳转

    function ontoPage(o) {
        var pageindex = $(o).parent().parent().prev().prev().find("input").val();
        if (checknum(pageindex)) {
            var pageEnd = parseInt($(".page_2 b").text());
            if (pageEnd <= pageindex)
                pageindex = pageEnd;
            location.href = "S_SaleOrder_List.aspx?pageid=" + pageindex;
        }
    }
</script>
<style type="text/css">
    * + html .ord_check
    {
        padding-top: 0;
    }
</style>
<div id="list_main">
    <ul class="sidebar">
        <li class='<%= ShopNum1.Common.Common.ReqStr("stype") == "0" || ShopNum1.Common.Common.ReqStr("stype") == "" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="S_SaleOrder_List.aspx?stype=0">所有订单</a></li>
        <li class='<%= ShopNum1.Common.Common.ReqStr("stype") == "1" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="S_SaleOrder_List.aspx?ostate=0&sstate=0&pstate=0&stype=1">等待付款</a></li>
        <li class='<%= ShopNum1.Common.Common.ReqStr("stype") == "2" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="S_SaleOrder_List.aspx?ostate=1&sstate=0&pstate=1&stype=2">已付款</a></li>
        <li class='<%= ShopNum1.Common.Common.ReqStr("stype") == "3" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="S_SaleOrder_List.aspx?ostate=2&sstate=1&pstate=1&stype=3">已发货</a></li>
        <li class='<%= ShopNum1.Common.Common.ReqStr("stype") == "6" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="S_SaleOrder_List.aspx?ostate=3&sstate=2&pstate=1&stype=6">交易成功</a></li>
        <li class='<%= ShopNum1.Common.Common.ReqStr("stype") == "5" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="S_SaleOrder_List.aspx?ostate=1&sstate=0&pstate=3&stype=5">已退款</a></li>
        <li class='<%= ShopNum1.Common.Common.ReqStr("stype") == "8" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="S_SaleOrder_List.aspx?ostate=2&sstate=4&pstate=0&stype=8">已退货</a></li>
        <li class='<%= ShopNum1.Common.Common.ReqStr("stype") == "7" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="S_SaleOrder_List.aspx?quit=3&sstate=0&pstate=0&stype=7">交易关闭</a></li>
    </ul>
    <div id="content" class="ordmain">
        <div class="pad">
            <table border="0" cellspacing="0" cellpadding="0" class="lineh">
                <tr class="up_spac">
                    <td align="right">
                        订单编号：
                    </td>
                    <td>
                        <input name="ordernum" id="ordernum" type="text" class="ss_nr1" value='<%= ShopNum1.Common.Common.ReqStr("ord") %>' />
                    </td>
                    <td align="right" class="ss_nr_spac">
                        商品名称：
                    </td>
                    <td>
                        <input name="pname" type="text" id="pname" class="ss_nr1" value='<%= ShopNum1.Common.Common.ReqStr("pn") %>' />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr class="up_spac">
                    <td align="right">
                        下单时间：
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <input value='<%= ShopNum1.Common.Common.ReqStr("sd") %>' name="startdate" type="text"
                                        id="txtstartdate" style="width: 98px;" class="ss_nrduan Wdate" onclick=" WdatePicker({ dateFmt: 'yyyy-MM-dd' }) " />
                                </td>
                                <td class="line_spac">
                                    -
                                </td>
                                <td>
                                    <input value='<%= ShopNum1.Common.Common.ReqStr("ed") %>' name="enddate" type="text"
                                        id="txtenddate" style="width: 98px;" class="ss_nrduan Wdate" onclick=" WdatePicker({ dateFmt: 'yyyy-MM-dd' }) " />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="right" class="ss_nr_spac">
                        会员ID：
                    </td>
                    <td>
                        <input name="memloginid" id="memloginid" type="text" class="ss_nr1" value='<%= ShopNum1.Common.Common.ReqStr("mid") %>' />
                    </td>
                    <td>
                        <input name="sk" id="sk" type="button" class="chax btn_spc" value="查询" />
                    </td>
                </tr>
            </table>
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="blue_tbdd"
            style="margin-bottom: 10px; padding-top: 0px;">
            <tr>
                <th scope="col" width="324" class="ord_bl">
                    商品信息
                </th>
                <th scope="col" width="90">
                    <span id="OrderPanic">单价(元)</span>
                </th>
                <th scope="col" width="50">
                    <span id="OrderPanic2">数量 </span>
                </th>
                <th scope="col" width="90">
                    售后
                </th>
                <th scope="col" width="90">
                    <span id="OrderPanic3">促销价(元)</span>
                </th>
                <th scope="col" style="border-right: solid 1px #c6dfff;" width="127">
                    <span id="OrderPanic6">操作</span>
                </th>
            </tr>
        </table>
        <div class="shangpinkj">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_top">
                <tr>
                    <td style="border-right: none;" class="dind_l ord_che">
                        <input name="checktop" type="checkbox" id="checktop1" />
                    </td>
                    <td style="border-right: none; padding-left: 10px; text-align: left; width: 50px;">
                        <label for="checktop1">
                            全选</label>
                    </td>
                    <td style="border-left: none;">
                        <div class="shanc">
                            <a href="#" class="shanchu lmf_btn">批量删除</a>
                        </div>
                        <!--分页-->
                        <div id="pageDiv2" runat="server" class="fy">
                        </div>
                        <!--分页-->
                    </td>
                </tr>
            </table>
            <% if (dt != null)
               {
                   dt_sub = S_Order_List.dt_GetOrderProduct("");
                   bool bflag = true;
                   for (int i = 0; i < dt.Rows.Count; i++)
                   {
                       DataRow dr = dt.Rows[i];
                       string strMemloginId = dr["memloginId"].ToString();
                       string strGuId = dr["guid"].ToString();
                       string strOrderNumber = dr["ordernumber"].ToString();
                       string strShopName = dr["shopname"].ToString();
                       string strCreateTime = dr["createtime"].ToString();
                       string strOrderState = dr["oderstatus"].ToString();
                       string strShouldPayPrice = dr["shouldpayprice"].ToString();
                       string strOrderType = dr["ordertype"].ToString();
                       string strDispatchprice = dr["Dispatchprice"].ToString();
                       DataRow[] drr = dt_sub.Select("OrderInfoGuid='" + dr["guid"] + "'");
                       if (drr.Length != 0)
                       {
            %>
            <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tb1" id="Table1"
                style="border-left: 1px solid #e3e3e3; border-right: 1px solid #e3e3e3; border-top: 1px solid #e3e3e3;
                margin: 0;">
                <tr>
                    <th scope="col" colspan="5" style="border-bottom: none; text-align: left;">
                        <div class="ord_check">
                            <input name="checksub" type="checkbox" value="<%= dr["guid"] %>" lang="<%= i %>"
                                vname='<%= dr["shopid"] %>' />
                        </div>
                        订单编号：<a class="alink_blue"><%= strOrderNumber %></a>&nbsp;&nbsp;&nbsp; 买家：<%= strMemloginId %>&nbsp;&nbsp;&nbsp;<strong>下单时间：<%= strCreateTime %></strong>
                    </th>
                    <th scope="col" colspan="3" style="border-bottom: none; color: #cc0000; padding-right: 10px;
                        text-align: right;">
                        订单状态：<span><%= S_Order_List.setOrderState(strOrderState) %></span>
                    </th>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="1" cellpadding="5" class="blue_tb1" id="ord_<%= i %>"
                style="margin-top: 0;">
                <%
                    for (int j = 0; j < drr.Length; j++)
                    {
                        string strProductImg = drr[j]["ProductImg"].ToString();
                        string strProductName = drr[j]["ProductName"].ToString();
                        string strspecificationName = drr[j]["specificationName"].ToString().Replace("%2f", "/");
                        string strBuyPrice = drr[j]["ShopPrice"].ToString();
                        string strBuyNumber = drr[j]["BuyNumber"].ToString();
                        string strProductUrl = ShopUrlOperate.shopHref(drr[j]["productguid"].ToString(), drr[j]["ShopId"].ToString());
                %>
                <tr>
                    <td width="82">
                        <a href="<%= strProductUrl %>" class="alink_blue" target="_blank">
                            <img src="<%= strProductImg %>" width="65" height="66" /></a>
                    </td>
                    <td width="200" style="text-align: left;">
                        <a href="<%= strProductUrl %>" class="alink_blue" target="_blank">
                            <%= strProductName %></a> <span>
                                <%= strspecificationName.Replace("%2F", "/").Replace("0", "") %></span>
                    </td>
                    <td style="width: 70px;">
                        <span class="redbold">
                            <%= strBuyPrice %></span>
                    </td>
                    <td width="30">
                        <%= strBuyNumber %>
                    </td>
                    <% if (j == 0)
                       { %>
                    <td rowspan="<%= drr.Length + 1 %>" width="70">
                        <% if (dr["vrefund"].ToString() == "0" && dr["refundtype"].ToString() == "0")
                           { %>
                        <a href="S_index.aspx?tosurl=S_RefundGoods.aspx?view=exitmoney|<%= drr[j]["shopid"] %>|<%= dr["guid"] %>"
                            target="_blank">买家退款</a>
                        <% }
                           else if (dr["vrefund"].ToString() == "0" && dr["refundtype"].ToString() == "1")
                           { %>
                        <a href="S_index.aspx?tosurl=S_RefundGoods.aspx?view=exitgoods|<%= drr[j]["shopid"] %>|<%= dr["guid"] %>"
                            target="_blank">买家退货</a>
                        <% } %>
                        <%--<a href="b_tuihuo.html">退货</a>--%>
                    </td>
                    <td rowspan="<%= drr.Length + 1 %>" style="width: 70px;">
                        邮费：<%= strDispatchprice %>
                        <span class="redbold">
                            <br />
                            <%= strShouldPayPrice %></span>
                    </td>
                    <td rowspan="<%= drr.Length + 1 %>">
                        <a href="javascript:void(0)" onclick=" if (confirm('是否删除？')) {location.href = '?del=<%= strOrderNumber %>&sign=del';
                                                                                    } " class="alink_blue">删除</a>&nbsp;<a href="S_OrderDetail.aspx?guid=<%= strGuId %>&ordertype=<%= strOrderType %>"
                                                                                        class="alink_blue" target="_parent">查看</a><br />
                    </td>
                    <% } %>
                </tr>
                <% } %>
            </table>
            <% }
                       else
                       {
                           if (bflag)
                           {
                               bflag = false;
            %>
            <div class="no_datas">
                <div class="no_data">
                    没有查询到相关数据</div>
            </div>
            <% }
                       }
                   }
               }
               else
               { %><div class="no_datas">
                   <div class="no_data">
                       没有查询到相关数据</div>
               </div>
            <% } %>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_b"
                style="margin-top: 10px;">
                <tr>
                    <td style="border-right: none;" class="dind_l ord_che">
                        <input name="checktop" type="checkbox" id="checktop2" />
                    </td>
                    <td style="border-left: none; border-right: none; padding-left: 10px; text-align: left;
                        width: 50px;">
                        <label for="checktop2">
                            全选</label>
                    </td>
                    <td class="dind_r" style="border-left: none;">
                        <div id="pageDiv1" runat="server" class="fy">
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
