﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_LifeOrderList.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_LifeOrderList" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Deploy.Main.Member.Skin" %>
<% DataTable dt = M_LifeOrderList.dt_OrderList; %>
<script type="text/javascript" language="javascript">
    $(function () {
        //搜索
        $("#sk").click(function () {
            var state = '<%=ShopNum1.Common.Common.ReqStr("st") %>';
            var state = '<%=ShopNum1.Common.Common.ReqStr("st") %>';
            var ostate = '<%=ShopNum1.Common.Common.ReqStr("ostate") %>';
            var sstate = '<%=ShopNum1.Common.Common.ReqStr("sstate") %>';
            var pstate = '<%=ShopNum1.Common.Common.ReqStr("pstate") %>';
            var stype = '<%=ShopNum1.Common.Common.ReqStr("stype") %>';
            location.href = "M_LifeOrderList.aspx?ostate=" + ostate + "&sstate=" + sstate + "&pstate=" + pstate + "&stype=" + stype + "&pn=" + escape($("#pname").val()) + "&ord=" + $("#ordernum").val() + "&sd=" + $("#txtstartdate").val() + "&ed=" + $("#txtenddate").val() + "&sn=" + escape($("#shopname").val()) + "&st=" + state + "&";
        });
        // 全选
        $("input[name='checktop']").click(function () {
            $("input[name='checktop']").attr("checked", $(this).is(":checked"));
            $("input[name='checksub']").attr("checked", $(this).is(":checked"));
        });

        //批量删除
        $(".shanchu").click(function () {
            var xcheck = new Array(); var shopid; var delid = new Array(); var bflag = true;
            $("input[name='checksub']").each(function () {
                if ($(this).is(":checked")) {
                    delid.push($(this).attr("lang")); shopid = $(this).attr("vname");
                    xcheck.push("'" + $(this).val() + "'"); bflag = false;
                }
            });
            if (bflag) {
                alert("请选择一条数据进行删除操作！"); return false;
            }
            if (confirm("是否执行删除操作？")) {
                $.get("/Api/ShopAdmin/OrderList.ashx?type=subdel&user=" + shopid + "&guid=" + xcheck.join(",") + "", null, function (data) {
                    if (data == "ok") {
                        alert("删除成功！");
                    }
                });
                for (var i in delid) {
                    $("#ord_" + delid[i]).remove(); $("#ord2_" + delid[i]).remove();
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
        } else { return true; }
    }
    //页面跳转
    function ontoPage(o) {
        var pageindex = $(o).parent().parent().prev().prev().find("input").val();
        if (checknum(pageindex)) {
            var pageEnd = parseInt($(".page_2 b:eq(0)").text());
            if (pageEnd <= pageindex)
                pageindex = pageEnd;
            var stype = '<%=ShopNum1.Common.Common.ReqStr("st")%>';
            location.href = "M_LifeOrderList.aspx?st=" + stype + "&pageid=" + pageindex;
        }
    }
</script>
<div id="list_main">
    <ul class="sidebar">
        <li class='<%=ShopNum1.Common.Common.ReqStr("st")=="all"||ShopNum1.Common.Common.ReqStr("st")==""?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="M_LifeOrderList.aspx?st=all">全部</a></li>
        <li class='<%=ShopNum1.Common.Common.ReqStr("st")=="0"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="M_LifeOrderList.aspx?st=0">等待付款</a></li>
        <li class='<%=ShopNum1.Common.Common.ReqStr("st")=="1"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="M_LifeOrderList.aspx?st=1">等待消费</a></li>
        <li class='<%=ShopNum1.Common.Common.ReqStr("st")=="3"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="M_LifeOrderList.aspx?st=3">确认消费</a></li>
        <li class='<%=ShopNum1.Common.Common.ReqStr("st")=="4"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="M_LifeOrderList.aspx?st=4">交易关闭</a></li>
    </ul>
    <div id="content" class="ordmain">
        <div class="pad">
            <table border="0" cellspacing="0" cellpadding="0" class="lineh">
                <tr class="up_spac">
                    <td align="right">
                        订单编号：
                    </td>
                    <td>
                        <input name="ordernum" id="ordernum" type="text" class="ss_nr1" value='<%=ShopNum1.Common.Common.ReqStr("ord") %>' />
                    </td>
                    <td align="right" class="ss_nr_spac">
                        商品名称：
                    </td>
                    <td>
                        <input name="pname" type="text" id="pname" class="ss_nr1" value='<%=ShopNum1.Common.Common.ReqStr("pn") %>' />
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
                                    <input value='<%=ShopNum1.Common.Common.ReqStr("sd") %>' name="startdate" type="text"
                                        id="txtstartdate" class="ss_nrduan" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                                </td>
                                <td class="line_spac">
                                    -
                                </td>
                                <td>
                                    <input value='<%=ShopNum1.Common.Common.ReqStr("ed") %>' name="enddate" type="text"
                                        id="txtenddate" class="ss_nrduan" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="right" class="ss_nr_spac">
                        店铺名称：
                    </td>
                    <td>
                        <input name="shopname" id="shopname" type="shopname" class="ss_nr1" value='<%=ShopNum1.Common.Common.ReqStr("sn") %>' />
                    </td>
                    <td>
                        <input name="sk" id="sk" type="button" class="chax btn_spc" value="查询" />
                    </td>
                </tr>
            </table>
        </div>
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="blue_table">
            <tr>
                <th width="314" class="blue_l">
                    商品信息
                </th>
                <th scope="col" width="90">
                    <span id="OrderPanic">单价(元)</span>
                </th>
                <th scope="col" width="46">
                    <span id="OrderPanic2">数量 </span>
                </th>
                <th scope="col" width="92">
                    售后
                </th>
                <th scope="col" width="110">
                    <span id="OrderPanic3">实收款(元)</span>
                </th>
                <th width="98" class="blue_r">
                    <span id="OrderPanic6">操作</span>
                </th>
            </tr>
        </table>
        <div class="shangpinkjdd">
            <div class="btntable_tbg">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_top">
                    <tr>
                        <td width="4%" class="check_td" style="display: none">
                            <input type="checkbox" name="checktop" id="checktop1" />
                        </td>
                        <td width="6%" style="border-right: none; text-align: left; padding-left: 10px; display: none;">
                            <label for="checktop1">
                                全选</label>
                        </td>
                        <td width="90%" style="border-left: none;" class="dind_r">
                            <div class="shanc" style="display: none">
                                <a href="#" class="shanchu lmf_btn">批量删除</a>
                            </div>
                            <!--分页-->
                            <div id="pageDiv1" runat="server" class="fy">
                            </div>
                            <!--分页-->
                        </td>
                    </tr>
                </table>
            </div>
            <%if (dt != null)
              {
                  DataTable dt_Sub = M_LifeOrderList.dt_GetOrderProduct(""); bool bflag = true;
                  for (int i = 0; i < dt.Rows.Count; i++)
                  {
                      DataRow dr = dt.Rows[i];
                      DataRow[] drr = dt_Sub.Select("OrderInfoGuid='" + dr["guid"] + "'");
                      string strDispatchprice = dr["dispatchprice"].ToString();
                      if (drr.Length != 0)
                      {
            %>
            <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw" id="ord_<%=i%>">
                <tr>
                    <th scope="col" colspan="5" class="th_le">
                        <div class="ord_check" style="display: none;">
                            <input name="checksub" type="checkbox" value="<%=dr["guid"] %>" lang="<%=i%>" vname='<%=dr["memloginid"] %>' /></div>
                        &nbsp; 订单编号：<span style="color: #005ea7;"><%=dr["ordernumber"]%></span>&nbsp;&nbsp;&nbsp;
                        商家：<%=dr["shopname"]%>&nbsp;&nbsp;&nbsp;<strong>下单时间：<%=dr["createtime"]%></strong>
                    </th>
                    <th scope="col" class="th_color th_ri">
                        订单状态：<span><%=M_LifeOrderList.setOrderState(dr["oderstatus"].ToString())%></span>
                    </th>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tb1" style="margin-top: -1px;"
                id="ord2_<%=i%>">
                <%for (int k = 0; k < drr.Length; k++)
                  {
                      string strPayUrl = "M_PayOp.aspx?pname=" + drr[k]["ProductName"] + "&orderguid=" + dr["guid"] + "&mid=" + dr["memloginid"] + "&shopid=" + dr["shopid"] + "&ordertype=" + dr["ordertype"] + "&sign=welcomeshopnum1";
                %>
                <!--商品循环代码-->
                <tr>
                    <td width="82">
                        <a class="alink_blue" href="<%=ShopUrlOperate.shopHref(drr[k]["ProductGuId"].ToString(),drr[k]["ShopId"].ToString())%>"
                            target="_blank" title="<%=drr[k]["ProductName"] %>">
                            <img src="<%=drr[k]["ProductImg"]%>_60x60.jpg" width="60" height="60" onerror="javascript:this,src='/ImgUpload/noImg.jpg_60x60.jpg'" /></a>
                    </td>
                    <td width="200" style="text-align: left;">
                        <a class="alink_blue" href="<%=ShopUrlOperate.shopHref(drr[k]["ProductGuId"].ToString(),drr[k]["ShopId"].ToString())%>"
                            target="_blank" title="<%=drr[k]["ProductName"] %>">
                            <%=ShopNum1.Common.Utils.GetUnicodeSubString(drr[k]["ProductName"].ToString(),20,"...")%></a><br />
                        <span>
                            <%=drr[k]["specificationName"].ToString().Replace("%2f", "/").Replace("0", "")%></span>
                    </td>
                    <td width="70">
                        <span class="redbold">
                            <%=drr[k]["ShopPrice"]%></span>
                    </td>
                    <td width="30">
                        <%=drr[k]["buynumber"]%>
                    </td>
                    <!--操作显示一行一列-->
                    <%if (k == 0)
                      { %>
                    <td rowspan="<%=drr.Length%>" style="width: 70px;">
                        <%if (Convert.ToInt32(dr["oderstatus"]) > 0 && Convert.ToInt32(dr["oderstatus"]) < 3)
                          { %>
                        <%if (dr["refundtype"].ToString() == "0")
                          {
                              if (dr["vrefund"].ToString() == "1")
                              { 
                        %>
                        <a href="m_index.aspx?tomurl=M_RefundGoods.aspx?view=exitmoney|<%=drr[k]["shopid"] %>|<%=dr["guid"] %>|@<%=dr["oderstatus"] %>#lifeorder&"
                            target="_search" class="redv">退款成功</a>
                        <%}
                              else if (dr["vrefund"].ToString() == "2")
                              {%>
                        <a href="m_index.aspx?tomurl=M_RefundGoods.aspx?view=exitmoney|<%=drr[k]["shopid"] %>|<%=dr["guid"] %>|@<%=dr["oderstatus"] %>#lifeorder&"
                            target="_search" class="redv">卖家拒绝退款</a>
                        <%}
                              else if (dr["vrefund"].ToString() == "0")
                              {%>
                        <a href="m_index.aspx?tomurl=M_RefundGoods.aspx?view=exitmoney|<%=drr[k]["shopid"] %>|<%=dr["guid"] %>|@<%=dr["oderstatus"] %>#lifeorder&"
                            target="_search" class="redv">正在退款</a>
                        <%}
                          }
                          else if (dr["vrefund"].ToString() != "2" && dr["vrefund"].ToString() != "1" && Convert.ToInt32(dr["oderstatus"]) == 1 && dr["paymentname"].ToString() != "线下支付" && dr["paymentname"].ToString() != "货到付款")
                          { %>
                        <a href="m_index.aspx?tomurl=M_RefundGoods.aspx?op=exitmoney|<%=drr[k]["shopid"] %>|<%=dr["guid"] %>|@<%=dr["oderstatus"] %>#lifeorder&"
                            target="_search" class="redv">退款</a>
                        <% }
                          if (dr["refundtype"].ToString() == "1")
                          {
                              if (dr["vrefund"].ToString() == "1")
                              {%>
                        <a href="m_index.aspx?tomurl=M_RefundGoods.aspx?view=exitgoods|<%=drr[k]["shopid"] %>|<%=dr["guid"] %>|lifeorder&"
                            target="_search" class="redv">退货成功</a>
                        <%}
                              else if (dr["vrefund"].ToString() == "2")
                              {%>
                        <a href="m_index.aspx?tomurl=M_RefundGoods.aspx?view=exitgoods|<%=drr[k]["shopid"] %>|<%=dr["guid"] %>|lifeorder&"
                            target="_search" class="redv">卖家拒绝退货</a>
                        <%  }
                              else
                              {%>
                        <a href="m_index.aspx?tomurl=M_RefundGoods.aspx?view=exitgoods|<%=drr[k]["shopid"] %>|<%=dr["guid"] %>|lifeorder&"
                            target="_search" class="redv">正在退货</a>
                        <% }
                          }
                          else if (dr["vrefund"].ToString() != "2" && dr["vrefund"].ToString() != "1" && Convert.ToInt32(dr["oderstatus"]) == 2 && dr["paymentname"].ToString() != "线下支付" && dr["paymentname"].ToString() != "货到付款")
                          {%>
                        <a href="m_index.aspx?tomurl=M_RefundGoods.aspx?op=exitgoods|<%=drr[k]["shopid"] %>|<%=dr["guid"] %>|lifeorder&"
                            target="_search" class="redv">退货</a>
                        <% }
                          }
                        %>
                        <%if (dr["ocid"].ToString() != "")
                          { %>
                        <div>
                            <a href='m_index.aspx?tomurl=M_ComplaintsDetailed.aspx?id=<%=dr["ocid"].ToString() %>'
                                target="_blank">查看投诉</a></div>
                        <%}
                          else
                          { %>
                        <div>
                            <a href='m_index.aspx?tomurl=M_MemberComplaints.aspx?shopid=<%=drr[k]["shopid"] %>|<%=dr["ordernumber"] %>'
                                target="_blank">我要投诉</a></div>
                        <%} %>
                    </td>
                    <td rowspan="<%=drr.Length%>" style="width: 92px;">
                        邮费：<%=strDispatchprice%>
                        <div class="redbold">
                            <%=dr["shouldpayprice"]%></div>
                        <div>
                            <%=dr["paymentname"]%></div>
                    </td>
                    <td rowspan="<%=drr.Length%>">
                        <%if (Convert.ToInt32(dr["oderstatus"]) > 3)
                          { %>
                        <a href="javascript:void(0)" onclick="if(confirm('是否删除？')){location.href='?del=<%=dr["ordernumber"]%>&sign=del'}"
                            class="alink_blue">删除</a><%} %>
                        <a href="M_OrderDetail.aspx?guid=<%=dr["guid"]%>&ordertype=<%=dr["ordertype"] %>"
                            class="alink_blue" target="_parent">查看</a><br />
                        <%if (dr["oderstatus"].ToString() == "0")
                          { %>
                        <a href='<%=strPayUrl%>' class="alink_blue" target="_blank">付款</a>
                        <%}
                          else if (dr["oderstatus"].ToString() == "3" && dr["IsBuyComment"].ToString() == "0")
                          { %>
                        <a href="M_ProductComment.aspx?orid=<%=dr["guid"] %>" class="alink_blue" target="_parent">
                            评价</a>
                        <%}
                          else if (dr["IsBuyComment"].ToString() == "1")
                          { %>
                        <a href="M_AddProductComment.aspx?orid=<%=dr["guid"] %>" class="alink_blue" target="_parent">
                            追加评价</a>
                        <%} %>
                    </td>
                    <%} %>
                    <!--操作显示一行一列-->
                </tr>
                <!--商品循环代码-->
                <%} %>
            </table>
            <%}
                      else
                      {
                          if (bflag)
                          {
                              bflag = false; %>
            <div class="no_datas">
                <div class="no_data">
                    没有查询到相关数据!
                </div>
            </div>
            <% }
                      }
                  }
              }
              else
              {%>
            <div class="no_datas">
                <div class="no_data">
                    没有数据！</div>
            </div>
            <%} %>
            <div class="btntable_tbg">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_top">
                    <tr>
                        <td width="4%" class="check_td" style="display: none">
                            <input name="checktop" type="checkbox" id="checktop2" />
                        </td>
                        <td width="6%" style="border-right: none; text-align: left; padding-left: 10px; display: none;">
                            <label for="checktop2">
                                全选</label>
                        </td>
                        <td width="90%">
                            <!--分页-->
                            <div id="pageDiv2" runat="server" class="fy">
                            </div>
                            <!--分页-->
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</div>
