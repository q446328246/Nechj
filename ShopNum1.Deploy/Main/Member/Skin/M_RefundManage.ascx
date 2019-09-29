<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_RefundManage.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_RefundManage" %>
<%@ Import Namespace="ShopNum1.MemberWebControl" %>
<script type="text/javascript" language="javascript">
    $(function () {
        $("#searchsub").click(function () {
            var rType = '<%=ShopNum1.Common.Common.ReqStr("type")%>';
            location.href = "M_RefundManage.aspx?rid=" + $("#exitnumber").val() + "&oid=" + $("#ordernumber").val() + "&sid=" + $("#shopmemloginid").val() + "&type=" + rType + "";
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
            var rType = '<%=ShopNum1.Common.Common.ReqStr("type")%>';
            location.href = "M_RefundManage.aspx?rid=" + $("#exitnumber").val() + "&oid=" + $("#ordernumber").val() + "&sid=" + $("#shopmemloginid").val() + "&type=" + rType + "&pageid=" + pageindex + "";
        }
    }
</script>
<div id="content" class="ordmain1">
    <div class="pad">
        <table border="0" cellspacing="0" cellpadding="0" class="lineh">
            <tr class="up_spac">
                <td align="right">
                    退款编号：
                </td>
                <td>
                    <input id="exitnumber" type="text" class="ss_nr1" value='<%=ShopNum1.Common.Common.ReqStr("rid") %>'
                        maxlength="15" />
                </td>
                <td align="right" class="ss_nr_spac">
                    订单编号：
                </td>
                <td>
                    <input id="ordernumber" type="text" class="ss_nr1" value='<%=ShopNum1.Common.Common.ReqStr("oid") %>'
                        maxlength="15" />
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right">
                    卖家登录名：
                </td>
                <td colspan="3" style="text-align: left;">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td>
                                <input id="shopmemloginid" type="text" class="ss_nr1" value='<%=ShopNum1.Common.Common.ReqStr("sid") %>'
                                    maxlength="10" />
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
    <div id="list_main">
        <ul id="sidebar">
            <li class="<%=ShopNum1.Common.Common.ReqStr("type") == "2" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab"%>">
                <a href="M_RefundManage.aspx?type=2">申请中退款</a></li>
            <li class="<%=ShopNum1.Common.Common.ReqStr("type") == "1"|| ShopNum1.Common.Common.ReqStr("type") == ""? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab"%>">
                <a href="M_RefundManage.aspx?type=1">已处理的退款</a></li>
        </ul>
        <div class="biaogenr">
            <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tb2">
                <tr>
                    <th class="th_le">
                        退款编号
                    </th>
                    <th>
                        订单编号
                    </th>
                    <th>
                        卖家登录名
                    </th>
                    <th>
                        交易金额
                    </th>
                    <th>
                        退款金额
                    </th>
                    <th class="th_ri">
                        退款状态
                    </th>
                    <th class="th_ri">
                        退款详细
                    </th>
                </tr>
                <asp:Repeater ID="repExitMoney" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("refundid")%>
                            </td>
                            <td>
                                <%#Eval("ordernumber")%>
                            </td>
                            <td>
                                <%#Eval("shopid")%>
                            </td>
                            <td>
                                <%#Eval("shouldpayprice")%>
                            </td>
                            <td>
                                <%#Eval("refundmoney")%>
                            </td>
                            <td>
                                <%#M_RefundManage.RefundStatus(Eval("refundstatus").ToString(),"1")%>
                            </td>
                            <td>
                                <input type="hidden" id="hidIsReceive" value='<%#Eval("isreceive")%>' />
                                <input type="hidden" id="hidContent" value='<%#Eval("refundcontent")%>' />
                                <input type="hidden" id="hidRefundContent" value='<%#Eval("refundcontent")%>' />
                                <input type="hidden" id="hidRefundMoney" value='<%#Eval("refundmoney")%>' />
                                <input type="hidden" id="hidOnPassReason" value='<%#Eval("onpassreason")%>' />
                                <input type="hidden" id="hidRefundImg" value='<%#Eval("RefundImg")%>' />
                                <input type="hidden" id="hidApplyTime" value='<%#Eval("applytime")%>' />
                                <input type="hidden" id="hidStatusTxt" value='<%#M_RefundManage.RefundStatus(Eval("refundstatus").ToString(),"1")%>' />
                                <input type="hidden" id="hidStatusReason" value='<%#M_RefundManage.ReasonType(Eval("refundreason").ToString())%>' />
                                <span style="cursor: pointer" class="showRefundDetail">查看详细</span>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <%if (repExitMoney.Items.Count == 0)
              { %>
            <div class="no_datas">
                <div class="no_data">
                    没有查询到相关数据!</div>
            </div>
            <%} %>
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
            if (isReceive == "0") { receiveTxt = "未收到货"; }
            else { receiveTxt = "已收到货"; }
            $("#isreceive").text(receiveTxt);
            //alert($(this).parent().find("#hidRefundMoney").val());
            $("#exitmoney").text($(this).parent().find("#hidRefundMoney").val());
            $("#piccheck").html("<img src=\"" + $(this).parent().find("#hidRefundImg").val() + "\" width=\"160\" height=\"160\" onerror=\"javascript:this.src='/ImgUpload/noImg.jpg_160x160.jpg'\" >");
            $("#exitreason").text($(this).parent().find("#hidStatusReason").val());
            $("#exitPassReason").text($(this).parent().find("#hidOnPassReason").val());
            $("#exitintroduce").text($(this).parent().find("#hidRefundContent").val());
            $(".showpopone").show(); funOpen();
        });
    });
</script>
<style type="text/css">
    td, th
    {
        text-align: left;
    }
</style>
<!--退款详细信息弹出框-->
<div class="sp_dialog sp_dialog_out" style="display: none;" id="sp_dialog_outDiv">
    <div class="sp_dialog_cont" style="display: none;" id="sp_dialog_contDiv">
        <div class="sp_tan">
            <h4>
                退款详细信息</h4>
            <div class="sp_close">
                <a onclick="funClose()" href="javascript:void(0)"></a>
            </div>
            <div class="clear">
            </div>
        </div>
        <div style="width: 100%; height: 500px;" class="showpopone">
            <table cellspacing="0" cellpadding="0" border="0" style="padding-top: 10px; margin: 10px 0 20px 120px;">
                <tr class="up_spac">
                    <td align="right">
                        是否收到款：
                    </td>
                    <td id="isreceive" align="left">
                    </td>
                </tr>
                <tr class="up_spac">
                    <td align="right">
                        退款金额：
                    </td>
                    <td id="exitmoney" align="left">
                    </td>
                </tr>
                <tr class="up_spac">
                    <td align="right">
                        图片凭证：
                    </td>
                    <td id="piccheck" align="left">
                    </td>
                </tr>
                <tr class="up_spac">
                    <td align="right">
                        退款原因：
                    </td>
                    <td id="exitreason" align="left">
                    </td>
                </tr>
                <tr class="up_spac">
                    <td align="right">
                        退款说明：
                    </td>
                    <td style="width: 270px; padding-bottom: 20px;" align="left">
                        <textarea id="exitintroduce" style="width: 200px; height: 60px; border: 1px solid #bfbfbf;"></textarea>
                    </td>
                </tr>
                <tr class="up_spac">
                    <td align="right">
                        退款理由：
                    </td>
                    <td style="width: 270px;" align="left">
                        <textarea id="exitPassReason" style="width: 200px; height: 130px; border: 1px solid #bfbfbf;"></textarea>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<!--退款详细信息弹出框-->
