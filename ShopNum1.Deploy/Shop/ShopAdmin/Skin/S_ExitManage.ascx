<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script type="text/javascript" language="javascript">

    $(function () {
        $("#searchsub").click(function () {
            var type = '<%= ShopNum1.Common.Common.ReqStr("type") %>';
            location.href = "S_ExitManage.aspx?rid=" + $("#exitnumber").val() + "&oid=" + $("#ordernumber").val() + "&sid=" + $("#shopmemloginid").val() + "&type=" + type;
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
            var rType = '<%= ShopNum1.Common.Common.ReqStr("type") %>';
            location.href = "S_ExitManage.aspx?rid=" + $("#exitnumber").val() + "&oid=" + $("#ordernumber").val() + "&sid=" + $("#shopmemloginid").val() + "&type=" + rType + "&pageid=" + pageindex + "";
        }
    }
</script>
<div id="list_main">
    <div id="content" class="ordmain1">
        <div class="pad">
            <table border="0" cellspacing="0" cellpadding="0" class="lineh">
                <tr class="up_spac">
                    <td align="right">
                        退款编号：
                    </td>
                    <td>
                        <input id="exitnumber" type="text" class="ss_nr1" value='<%= ShopNum1.Common.Common.ReqStr("rid") %>' />
                    </td>
                    <td align="right" class="ss_nr_spac">
                        订单编号：
                    </td>
                    <td>
                        <input id="ordernumber" type="text" class="ss_nr1" value='<%= ShopNum1.Common.Common.ReqStr("oid") %>' />
                    </td>
                </tr>
                <tr class="up_spac">
                    <td align="right">
                        买家登录名：
                    </td>
                    <td colspan="3">
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <input id="shopmemloginid" type="text" class="ss_nr1" value='<%= ShopNum1.Common.Common.ReqStr("sid") %>' />
                                </td>
                                <td>
                                    <input id="searchsub" type="button" class="chax btn_spc" value="搜索" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <ul id="sidebar">
            <li class="<%= ShopNum1.Common.Common.ReqStr("type") == "1" || ShopNum1.Common.Common.ReqStr("type") == "" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>">
                <a href="S_ExitManage.aspx?type=1">已处理退款</a></li>
            <li class="<%= ShopNum1.Common.Common.ReqStr("type") == "2" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>">
                <a href="S_ExitManage.aspx?type=2">买家申请退款</a></li>
        </ul>
        <div class="biaogenr">
            <table cellspacing="1" cellpadding="0" border="0" class="blue_tb2" width="100%">
                <tr>
                    <th class="th_le" width="15%">
                        退款编号
                    </th>
                    <th width="15%">
                        订单编号
                    </th>
                    <th width="10%">
                        买家登录名
                    </th>
                    <th width="10%">
                        交易金额
                    </th>
                    <th width="10%">
                        退款金额
                    </th>
                    <th class="th_ri" width="20%">
                        退款状态
                    </th>
                    <th class="th_ri" width="10%">
                        查看详细
                    </th>
                </tr>
                <asp:Repeater ID="repExitMoney" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("refundid") %>
                            </td>
                            <td>
                                <%#Eval("ordernumber") %>
                            </td>
                            <td>
                                <%#Eval("memloginid") %>
                            </td>
                            <td>
                                <%#Eval("shouldpayprice") %>
                            </td>
                            <td>
                                <%#Eval("refundmoney") %>
                            </td>
                            <td>
                                <%#S_ExitManage.RefundStatus(Eval("refundstatus").ToString(), Eval("refundtype").ToString()) %>
                            </td>
                            <td>
                                <input type="hidden" id="hidIsReceive" value='<%#Eval("isreceive") %>' />
                                <input type="hidden" id="hidContent" value='<%#Eval("refundcontent") %>' />
                                <input type="hidden" id="hidRefundContent" value='<%#Eval("refundcontent") %>' />
                                <input type="hidden" id="hidRefundMoney" value='<%#Eval("refundmoney") %>' />
                                <input type="hidden" id="hidOnPassReason" value='<%#Eval("onpassreason") %>' />
                                <input type="hidden" id="hidRefundImg" value='<%#Eval("RefundImg") %>' />
                                <input type="hidden" id="hidApplyTime" value='<%#Eval("applytime") %>' />
                                <input type="hidden" id="hidStatusTxt" value='<%#S_ExitManage.RefundStatus(Eval("refundstatus").ToString(), "1") %>' />
                                <input type="hidden" id="hidStatusReason" value='<%#S_ExitManage.ReasonType(Eval("refundreason").ToString()) %>' />
                                <span style="cursor: pointer" class="showRefundDetail">查看详细</span>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <% if (repExitMoney.Items.Count == 0)
               { %>
            <div class="no_datas">
                <div class="no_data">
                    没有查询到相关数据!</div>
            </div>
            <% } %>
            <div class="btntable_tbg">
                <div id="pageDiv" runat="server" class="fy">
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
    $(function () {
        $(".showRefundDetail").click(function () {
            window.parent.scrollTo(0, 200);
            var receiveTxt = "";
            var isReceive = $(this).parent().find("#hidIsReceive").val();
            if (isReceive == "0") {
                receiveTxt = "未收到货";
            } else {
                receiveTxt = "已收到货";
            }
            $("#isreceive").text(receiveTxt);
            //alert($(this).parent().find("#hidRefundMoney").val());
            $("#exitmoney").text($(this).parent().find("#hidRefundMoney").val());
            $("#piccheck").html("<img src=\"" + $(this).parent().find("#hidRefundImg").val() + "\" width=\"160\" height=\"160\" onerror=\"javascript:this.src='/ImgUpload/noImg.jpg_160x160.jpg'\" >");
            $("#exitreason").text($(this).parent().find("#hidStatusReason").val());
            $("#exitintroduce").text($(this).parent().find("#hidRefundContent").val());
            $("#exitPassReason").text($(this).parent().find("#hidOnPassReason").val());
            $(".showpopone").show();
            funOpen();
        });
    });
</script>
<!--退款详细信息弹出框-->
<div class="sp_dialog sp_dialog_out" style="display: none;" id="sp_dialog_outDiv">
    <div class="sp_dialog_cont" style="display: none;" id="sp_dialog_contDiv">
        <div class="sp_tan">
            <h4>
                退款详细信息</h4>
            <div class="sp_close">
                <a onclick=" funClose() " href="javascript:void(0)"></a>
            </div>
            <div class="clear">
            </div>
        </div>
        <div style="height: 500px; width: 100%;" class="showpopone">
            <table cellspacing="0" cellpadding="0" border="0" style="margin: 10px 0 20px 120px;
                padding-top: 10px;">
                <tr class="up_spac">
                    <td align="right">
                        是否收到款：
                    </td>
                    <td id="isreceive">
                    </td>
                </tr>
                <tr class="up_spac">
                    <td align="right">
                        退款金额：
                    </td>
                    <td id="exitmoney">
                    </td>
                </tr>
                <tr class="up_spac">
                    <td align="right">
                        图片凭证：
                    </td>
                    <td id="piccheck">
                    </td>
                </tr>
                <tr class="up_spac">
                    <td align="right">
                        退款原因：
                    </td>
                    <td id="exitreason">
                    </td>
                </tr>
                <tr class="up_spac">
                    <td align="right">
                        退款说明：
                    </td>
                    <td style="padding-bottom: 20px; width: 270px;">
                        <textarea id="exitintroduce" style="border: 1px solid #bfbfbf; height: 60px; width: 200px;"></textarea>
                    </td>
                </tr>
                <tr class="up_spac">
                    <td align="right">
                        退款理由：
                    </td>
                    <td style="width: 270px;">
                        <textarea id="exitPassReason" style="border: 1px solid #bfbfbf; height: 130px; width: 200px;"></textarea>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<!--退款详细信息弹出框-->
