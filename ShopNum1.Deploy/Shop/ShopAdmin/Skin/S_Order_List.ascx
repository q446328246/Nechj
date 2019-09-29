<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<% DataTable dt = S_Order_List.dt_OrderList;
   DataTable dt_sub = null; %>
<script type="text/javascript" language="javascript">
    $(function () {
        //搜索
        $("#sk").click(function () {
            var st = '<%= ShopNum1.Common.Common.ReqStr("st") %>';
            var ostate = '<%= ShopNum1.Common.Common.ReqStr("ostate") %>';
            var sstate = '<%= ShopNum1.Common.Common.ReqStr("sstate") %>';
            var pstate = '<%= ShopNum1.Common.Common.ReqStr("pstate") %>';
            var stype = '<%= ShopNum1.Common.Common.ReqStr("stype") %>';
            location.href = "S_Order_List.aspx?ostate=" + ostate + "&sstate=" + sstate + "&pstate=" + pstate + "&stype=" + stype + "&pn=" + escape($("#pname").val()) + "&ord=" + $("#ordernum").val() + "&sd=" + $("#txtstartdate").val() + "&ed=" + $("#txtenddate").val() + "&mid=" + escape($("#memloginid").val()) + "&st=" + st + "&";
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
            var pageEnd = parseInt($(".page_2 b:eq(0)").text());
            if (pageEnd <= pageindex)
                pageindex = pageEnd;
            location.href = "S_Order_List.aspx?pageid=" + pageindex;
        }
    }
</script>
<script type="text/javascript" language="javascript">
    function updatepop(hidpriceid, orid, memloginid, price, oguid) {
        window.parent.scrollTo(0, 0);
        funOpen();
        $(".showpopone").show();
        $("#sp_dialog_outDiv h4").text("修改费用");
        $("#hidpriceid").val(hidpriceid);
        $("#buyermemloginid").text(memloginid);
        $("#ordernumber").text(orid);
        $("#shouldprice").text(price);
        $("#hidOrderNum").val(orid);
        $("#txtNewPrice").val("");
        $("#hidOguid").val(oguid);
        $("#sureupdate").removeAttr("disabled");
    }

    function surecheck(guid, ordernumber, payname, memloginid) {
        window.parent.scrollTo(0, 0);
        funOpen();
        $(".showpoptwo").show();
        $("#S_Order_List_ctl00_hidOrderGuId").val(guid);
        $("#sp_dialog_outDiv h4").text("确认订单");
        $(".showpoptwo #payname").text(payname);
        $(".showpoptwo #order_twonum").text(ordernumber);
    }

    $(function () {
        $("#sureupdate").click(function () {
            if ($("#txtNewPrice").val() == "") {
                $("#tipmsg").show().text("修改的订单金额不能为空！");
                return false;
            } else if (!checkpriceTxt($("#txtNewPrice"))) {
                $("#tipmsg").show().text("修改的订单金额不合法！");
                return false;
            } else {
                $($("#hidpriceid").val()).text($("#txtNewPrice").val());
                $("#tipmsg").show().attr("style", "color:green;").text("修改成功！");
                $("#sureupdate").attr("disabled", "disabled");
                $.get("/Api/ShopAdmin/OrderList.ashx?type=typeprice&ordernumber=" + $("#hidOrderNum").val() + "&price=" + $("#txtNewPrice").val() + "&orid=" + $("#hidOguid").val() + "", null, function (data) {

                });
                setTimeout(function () { funClose(); }, 2000);
            }
        });
    });

    function checkpriceTxt(o) {
        var oo = /^\d{1,10}$|\.\w?$|^\d{1,10}\.\d{1,5}\w?$/;
        if (!oo.test(o.val())) {
            $("#tipmsg").show().text("修改的订单金额不合法！");
            return false;
        } else {
            o.val(number_format(o.val(), 2));
            return true;
        }
    }
</script>
<div id="list_main">
    <ul class="sidebar">
        <li class='<%= ShopNum1.Common.Common.ReqStr("stype") == "0" || ShopNum1.Common.Common.ReqStr("stype") == "" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="S_Order_List.aspx?stype=0">所有订单</a></li>
        <li class='<%= ShopNum1.Common.Common.ReqStr("stype") == "1" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="S_Order_List.aspx?ostate=0&sstate=0&pstate=0&stype=1">等待付款</a></li>
        <li class='<%= ShopNum1.Common.Common.ReqStr("stype") == "2" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="S_Order_List.aspx?ostate=1&sstate=0&pstate=1&stype=2">待发货</a></li>
        <li class='<%= ShopNum1.Common.Common.ReqStr("stype") == "3" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="S_Order_List.aspx?ostate=2&sstate=1&pstate=1&stype=3">已发货</a></li>
        <li class='<%= ShopNum1.Common.Common.ReqStr("stype") == "6" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="S_Order_List.aspx?ostate=3&sstate=2&pstate=1&stype=6">交易成功</a></li>
        <li class='<%= ShopNum1.Common.Common.ReqStr("stype") == "5" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="S_Order_List.aspx?ostate=1&sstate=0&pstate=3&stype=5">已退款</a></li>
        <li class='<%= ShopNum1.Common.Common.ReqStr("stype") == "8" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="S_Order_List.aspx?ostate=2&sstate=4&pstate=0&stype=8">已退货</a></li>
        <li class='<%= ShopNum1.Common.Common.ReqStr("stype") == "7" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="S_Order_List.aspx?quit=3&sstate=0&pstate=0&stype=7">交易关闭</a></li>
    </ul>
    <div id="content" class="ordmain">
        <!--列表条件-->
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
                </tr>
                <tr class="up_spac">
                    <td align="right">
                        付款时间：
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <input value='<%= ShopNum1.Common.Common.ReqStr("sd") %>' name="startdate" type="text"
                                        id="txtstartdate" class="ss_nrduan" onclick=" WdatePicker({ dateFmt: 'yyyy-MM-dd' }) " />
                                </td>
                                <td class="line_spac">
                                    -
                                </td>
                                <td>
                                    <input value='<%= ShopNum1.Common.Common.ReqStr("ed") %>' name="enddate" type="text"
                                        id="txtenddate" class="ss_nrduan" onclick=" WdatePicker({ dateFmt: 'yyyy-MM-dd' }) " />
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
        <!--列表总标题-->
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="blue_tbdd">
            <tr>
                <th width="324">
                    商品信息
                </th>
                <th width="90">
                    <span id="OrderPanic">单价(元)</span>
                </th>
                <th width="50">
                    <span id="OrderPanic2">数量 </span>
                </th>
                <th width="90">
                    售后
                </th>
                <th width="90">
                    <span id="OrderPanic3">实收款(元)</span>
                </th>
                <th width="127">
                    <span id="OrderPanic6">操作</span>
                </th>
            </tr>
        </table>
        <!--列表头部操作按钮分页-->
        <div class="btntable_tbg">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_top">
                <tr>
                    <td width="4%" class="check_td" style="display: none;">
                        <input name="checktop" id="checktop1" type="checkbox" value="" />
                    </td>
                    <td width="6%" style="display: none; padding-left: 10px; text-align: left;">
                        <label for="checktop1">
                            全选</label>
                    </td>
                    <td width="90%">
                        <div class="shanc" style="display: none;">
                            <a href="#" class="shanchu lmf_btn">批量删除</a>
                        </div>
                        <!--分页-->
                        <div id="pageDiv2" runat="server" class="fy">
                        </div>
                        <!--分页-->
                    </td>
                </tr>
            </table>
        </div>
        <% if (dt != null)
           {
              
               //dt_sub = S_Order_List.dt_GetOrderProduct("");
               bool bflag = true;
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   DataRow dr = dt.Rows[i];
                   string strMemloginId = dr["memloginId"].ToString();
                   string strGuId = dr["guid"].ToString();
                   string strOrderNumber = dr["ordernumber"].ToString();
                   string strCreateTime = dr["paytime"].ToString();
                   string strOrderState = dr["oderstatus"].ToString();
                   string strShouldPay = dr["shouldpayprice"].ToString();
                   string strDispatchprice = dr["dispatchprice"].ToString();
                   string strOrderType = dr["ordertype"].ToString();
                   string strCategoryName = dr["category_name"].ToString();
                   
                   DataRow[] drr = S_Order_List.dt_GetOrderProduct(dr["guid"].ToString()).Select();
                   if (drr.Length != 0)
                   {
        %>
        <!--列表标题-->
        <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw" id="Table1">
            <tr>
                <th colspan="5" class="th_le">
                    <div class="ord_check" style="display: none;">
                        <input name="checksub" type="checkbox" value="<%= dr["guid"] %>" lang="<%= i %>"
                            vname='<%= dr["shopid"] %>' /> 
                    </div>
                    &nbsp;订单编号：<a class="alink_blue"><%= strOrderNumber %></a>&nbsp;&nbsp;&nbsp; 买家：<%= strMemloginId %>&nbsp;&nbsp;&nbsp;<strong>付款时间：<%= strCreateTime %></strong>
                    &nbsp;&nbsp;&nbsp;<strong>专区：<%= strCategoryName%></strong>
                </th>
                <th class="th_color th_ri">
                    订单状态：<span><%= S_Order_List.setOrderState(strOrderState) %></span>
                </th>
            </tr>
        </table>
        <!--列表内容-->
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="blue_tb1" id="ord_<%= i %>"
            style="margin-top: -1px;">
            <%
                for (int j = 0; j < drr.Length; j++)
                {
                    string strProductImg = drr[j]["ProductImg"].ToString();
                    string strProductName = drr[j]["ProductName"].ToString();
                    string strspecificationName = drr[j]["specificationName"].ToString().Replace("%2f", "/");
                    string strBuyPrice = drr[j]["ShopPrice"].ToString();
                    string strBuyNumber = drr[j]["BuyNumber"].ToString();
                    string strProductUrl = ShopUrlOperate.shopHrefcenter(drr[j]["productguid"].ToString(), drr[j]["shopid"].ToString(), dr["shop_category_id"].ToString());
                    if (dr["ordertype"].ToString() == "4")
                        strProductUrl = ShopUrlOperate.shopDetailHrefByShopIDcenter(drr[j]["ProductGuId"].ToString(), drr[j]["ShopIds"].ToString(), "ProductIsPanic_Detail", dr["shop_category_id"].ToString());
            %>
            <tr>
                <td width="82">
                    <a href="<%= strProductUrl %>" class="alink_blue" target="_blank" title="<%= strProductName %>">
                        <img src="<%= strProductImg %>_60x60.jpg" width="60" height="60" onerror=" javascript:this, src = '/ImgUpload/noImg.jpg_60x60.jpg'; " /></a>
                </td>
                <td width="200" style="text-align: left;">
                    <a href="<%= strProductUrl %>" class="alink_blue" target="_blank" title="<%= strProductName %>">
                        <%= Utils.GetUnicodeSubString(strProductName, 25, "...") %></a><br />
                        <p>
                        商品颜色:  <%=drr[j]["Color"]%> ;商品尺寸:<%=drr[j]["Size"]%>
                        
                        </p>
                    <% if (dr["ordertype"].ToString() == "1")
                       { %>
                    <div style="color: Red">
                        <img src="images/icon_tg.png" alt="团购活动" /></div>
                    <% }
                       else if (dr["ordertype"].ToString() == "2")
                       { %><div style="color: Red">
                           <img src="images/icon_zk.png" alt="限时折扣" /></div>
                    <% }
                       else if (dr["ordertype"].ToString() == "3")
                       { %><div style="color: Red">
                           <img src="images/icon_zh.png" alt="组合套餐" /></div>
                    <% }
                       else if (dr["ordertype"].ToString() == "4")
                       { %><div style="color: Red">
                           <img src="images/icon_qg.png" alt="抢购活动" /></div>
                    <% }
                       else if (dr["ordertype"].ToString() == "8")
                       { %>手机客户端<% }
                       else if (dr["ordertype"].ToString() == "9")
                       { %>wap站<% }
                       else if (dr["ordertype"].ToString() == "10")
                       { %>微信商城<% } %>
                    <span>
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
                <td rowspan="<%= drr.Length %>" width="70">
                    <% if (dr["vrefund"].ToString() == "0" && dr["refundtype"].ToString() == "0" && strOrderState == "1" && dr["refundstatus"].ToString() != "2")
                       { %>
                    <div>
                        <a href="S_index.aspx?tosurl=S_RefundGoods.aspx?view=exitmoney|<%= drr[j]["shopid"] %>|<%= dr["guid"] %>|commonorder|<%= strMemloginId %>|<%=dr["shop_category_id"] %>|<%= strOrderNumber %>&"
                            target="_blank" class="redv">买家申请退款</a></div>
                    <% }
                       else if ((dr["vrefund"].ToString() == "1"||dr["vrefund"].ToString() == "3") && dr["refundtype"].ToString() == "0")
                       { %>
                    <div>
                        <a href="S_index.aspx?tosurl=S_RefundGoods.aspx?view=exitmoney|<%= drr[j]["shopid"] %>|<%= dr["guid"] %>|commonorder|<%= strMemloginId %>|<%=dr["shop_category_id"] %>|<%= strOrderNumber %>&"
                            target="_blank" class="redv">退款成功</a></div>
                    <% }
                       else if (dr["vrefund"].ToString() == "0" && dr["refundtype"].ToString() == "1" && strOrderState == "2")
                       { %>
                    <div>
                        <a href="S_index.aspx?tosurl=S_RefundGoods.aspx?view=exitmoney|<%= drr[j]["shopid"] %>|<%= dr["guid"] %>|commonorder|<%= strMemloginId %>|<%=dr["shop_category_id"] %>|<%= strOrderNumber %>&"
                            target="_blank" class="redv">买家申请退货</a></div>
                    <% }
                       else if (dr["vrefund"].ToString() == "1" && dr["refundtype"].ToString() == "1")
                       { %>
                    <div>
                        <a href="S_index.aspx?tosurl=S_RefundGoods.aspx?view=exitmoney|<%= drr[j]["shopid"] %>|<%= dr["guid"] %>|commonorder|<%= strMemloginId %>|<%=dr["shop_category_id"] %>|<%= strOrderNumber %>&"
                            target="_blank" class="redv">退货成功</a></div>
                    <% }
                       else if (dr["vrefund"].ToString() == "2" && dr["refundtype"].ToString() == "0" && strOrderState == "1" && dr["refundstatus"].ToString() == "2")
                       { %>
                    <div>
                        <a href="S_index.aspx?tosurl=S_RefundGoods.aspx?view=exitmoney|<%= drr[j]["shopid"] %>|<%= dr["guid"] %>|commonorder|<%= strMemloginId %>|<%=dr["shop_category_id"] %>|<%= strOrderNumber %>&"
                            target="_blank" class="redv">卖家拒绝申请</a></div>
                    <% } %>
                       
                    <%= dr["paymentname"] %>
                </td>
                <td rowspan="<%= drr.Length %>" style="width: 70px;"> 
                    邮费：<%= strDispatchprice %>
                    <span class="redbold" id="t_price_<%= i %>">
                        <br />
                        <%= strShouldPay %></span>

                        
                    <% if (strOrderState == "0" && dr["vrefund"].ToString() != "1" )
                       {%>
                       <% if (dr["shopid"].ToString()== "C0000001")
                       {%><br />
                    <a href="javascript:void(0)" class="alink_blue" onclick=" updatepop('#t_price_<%= i %>', '<%= strOrderNumber %>', '<%= strMemloginId %>', '<%= strShouldPay %>', '<%= strGuId %>') ">
                        修改价格</a>
                        <%  } %>
                    <%  } %>
                </td>
                <td rowspan="<%= drr.Length %>">
                    <% if (Convert.ToInt32(strOrderState) > 3)
                       { %>
                    <a href="javascript:void(0)" onclick=" if (confirm('是否删除？')) {location.href = '?del=<%= strOrderNumber %>&sign=del';
                                                                                                                                                                                                                                                                          } "
                        class="alink_blue">删除</a>
                    <% } %>
                    &nbsp;<a href="S_OrderDetail.aspx?guid=<%= strGuId %>&ordertype=<%= strOrderType %>&category=<%=dr["shop_category_id"]%>"
                        class="alink_blue" target="_parent">查看</a>
                    <div>
                        <% if (dr["paymentname"].ToString() == "货到付款" || dr["paymentname"].ToString() == "线下支付")
                           {
                               if (strOrderState == "0")
                               { %>
                        <a href="javascript:void(0)" class="alink_blue" onclick=" surecheck('<%= strGuId %>', '<%= strOrderNumber %>', '<%= dr["paymentname"] %>', '<%= strMemloginId %>') ">
                            确认订单</a>&nbsp;<br />
                        <% }
                               else
                               { %>
                        卖家已确认
                        <% } %>
                        <% } %>
                    </div>
                </td>
                <% } %>
            </tr>
            <% } %>
        </table>
        <% }
               }
           }
           else
           { %>
        <!--没有数据的情况-->
        <div class="no_datas">
            <div class="no_data">
                没有查询到相关数据</div>
        </div>
        <% } %>
        <!--底部分页-->
        <div class="btntable_tbg">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_top">
                <tr>
                    <td width="4%" class="check_td" style="display: none;">
                        <input name="checktop" id="checktop2" type="checkbox" />
                    </td>
                    <td width="6%" style="border-right: none; display: none; padding-left: 10px; text-align: left;">
                        <label for="checktop2">
                            全选</label>
                    </td>
                    <td width="90%">
                        <div id="pageDiv1" runat="server" class="fy">
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<!--货到付款弹框-->
<div class="sp_dialog sp_dialog_out" style="display: none;" id="sp_dialog_outDiv">
    <div class="sp_dialog_cont" style="display: none;" id="sp_dialog_contDiv">
        <div class="sp_tan">
            <h4>
                修改费用</h4>
            <div class="sp_close">
                <a onclick=" funClose() " href="javascript:void(0)"></a>
            </div>
            <div class="clear">
            </div>
        </div>
        <div style="display: none; width: 100%;" class="showpopone">
            <table cellspacing="0" cellpadding="0" border="0" style="margin: 20px 0 20px 120px;
                padding-top: 10px;">
                <tr class="up_spac">
                    <td align="right">
                        买家：
                    </td>
                    <td id="buyermemloginid">
                    </td>
                </tr>
                <tr class="up_spac">
                    <td align="right">
                        订单号：
                    </td>
                    <td id="ordernumber">
                    </td>
                </tr>
                <tr class="up_spac">
                    <td align="right">
                        原订单金额(元)：
                    </td>
                    <td id="shouldprice">
                    </td>
                </tr>
                <tr class="up_spac">
                    <td align="right">
                        修改后的订单金额(元)：
                    </td>
                    <td>
                        <input type="text" value="" id="txtNewPrice" name="sort" class="ss_nr2" onblur=" checkpriceTxt($(this)) " />
                    </td>
                </tr>
                <tr class="up_spac">
                    <td align="right" colspan="2">
                       <span style="color:Red;">提示：修改价格会对获得的B积分和红包进行对应的修改！</span>
                    </td>
                    
                </tr>
                <tr class="up_spac">
                    <td align="right">
                    </td>
                    <td>
                        <input type="button" value="提交" id="sureupdate" class="baocbtn" />
                        <input type="hidden" id="hidpriceid" value="" />
                        <input type="hidden" id="hidOrderNum" value="" />
                        <input type="hidden" id="hidOguid" value="" />
                        <span id="tipmsg" style="color: Red;"></span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="display: none; width: 100%;" class="showpoptwo">
            <table cellspacing="0" cellpadding="0" border="0" style="margin: 20px 0 20px 120px;
                padding-top: 10px;">
                <tr class="up_spac">
                    <td align="right">
                        支付方式：
                    </td>
                    <td id="payname">
                    </td>
                </tr>
                <tr class="up_spac">
                    <td align="right">
                        订单号：
                    </td>
                    <td id="order_twonum">
                    </td>
                </tr>
                <tr class="up_spac">
                    <td align="right">
                    </td>
                    <td>
                        <asp:LinkButton ID="btnSub" runat="server" Text="确认" class="chax btn_spc" Style="color: #ffffff;
                            display: block;"></asp:LinkButton>
                        <input type="hidden" id="hidOrderGuId" runat="server" />
                        <span id="Span1" style="color: Red;"></span>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
