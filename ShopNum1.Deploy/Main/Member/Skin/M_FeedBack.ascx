<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_FeedBack.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_FeedBack" %>
<%@ Import Namespace="ShopNum1.Common" %>
<div id="list_main">
    <ul id="sidebar">
        <li class="<%=ShopNum1.Common.Common.ReqStr("type")=="1"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>">
            <a href="?type=1">卖家的评价</a></li>
        <li class="<%=ShopNum1.Common.Common.ReqStr("type")==""||ShopNum1.Common.Common.ReqStr("type")=="2"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>">
            <a href="?type=2">给他人的评价</a></li>
    </ul>
    <div id="content" class="ordmain1">
        <div class="biaogenr" id="feedback">
            <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw1">
                <tr>
                    <th width="10%" class="th_le">
                        评价
                    </th>
                    <th width="40%">
                        评论内容
                    </th>
                    <th width="20%">
                        <%--<%=ShopNum1.Common.Common.ReqStr("type") == "1" ? "评价人" : "被评价店铺"%>--%>
                        店铺名称
                    </th>
                    <th width="30%" class="th_ri">
                        宝贝信息
                    </th>
                    <th width="10%" class="th_ri" style="display: none;">
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="repBingComment" runat="server">
                    <ItemTemplate>
                        <tr class="feedback" data-id="<%#Eval("Guid")%>">
                            <td class="rate th_le">
                                <span class="rate-icon rate-ok">
                                    <%#Common.SetShopCommentTxt(Eval("Commenttype").ToString())%>
                                    <%--  <%if (ShopNum1.Common.Common.ReqStr("type") == "1")
                                   { %>
                                    
                                    <%}
                                   else
                                   { %><%#Common.SetShopCommentTxt(Eval("BuyerAttitude").ToString())%><%} %>--%>
                                </span>
                            </td>
                            <%if (ShopNum1.Common.Common.ReqStr("type") == "1")
                              { %>
                            <td class="reviews-cnt">
                                <div class="reviews-cnt-bd">
                                    <p class="rate" style="text-align: left;">
                                        <%#Eval("reply").ToString() == "" ? "" : Eval("reply").ToString()%>
                                    </p>
                                    <span class="date" style="text-align: right; display: block; color: #999999;">
                                        <%#Eval("replytime").ToString() == "" ? "" : "["+Eval("replytime").ToString()+"]"%></span>
                                </div>
                            </td>
                            <%}
                              else
                              { %>
                            <td class="reviews-cnt">
                                <div class="reviews-cnt-bd">
                                    <p class="rate" style="text-align: left;">
                                        <%#Eval("comment")%>
                                    </p>
                                    <span class="date" style="text-align: right; display: block; color: #005ea7;">[<%#Eval("commenttime")%>]</span>
                                </div>
                                <div class="reviews-cnt-bd" style='<%#Eval("continuecomment").ToString()==""?"display:none": "display:block;"%>'>
                                    <p class="rate" style="text-align: left;">
                                        <%#Eval("continuecomment")%>
                                    </p>
                                    <span class="date" style="text-align: right; display: block; color: #999999;">[<%#Eval("continuetime")%>]</span>
                                </div>
                            </td>
                            <%} %>
                            <td>
                                <a href="<%#ShopUrlOperate.GetShopUrlcenter(Eval("shopid").ToString(),Eval("shop_category_id").ToString()) %>" target="_blank"
                                    class="shop_Name"><span>[<%#Eval("ShopName")%>]</span></a>
                            </td>
                            <td style="text-align: left;" class="th_ri">
                                <div class="auction">
                                    <a href="<%#ShopUrlOperate.shopHrefcenter(Eval("productguid").ToString(),Eval("shoploginid").ToString(),Eval("shop_category_id").ToString()) %>"
                                        title="<%#Eval("ProductName")%>" target="_blank">
                                        <%#Eval("ProductName")%></a>
                                    <div class="price">
                                        <%#Eval("ProductPrice")%>元</div>
                                </div>
                            </td>
                            <td class="th_ri" style="display: none;">
                                &nbsp;
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <%if (repBingComment.Items.Count == 0)
                  { %>
                <tr>
                    <td colspan="5" style="height: 16px;">
                        <div class="no_data">
                            暂无数据</div>
                    </td>
                </tr>
                <%} %>
            </table>
            <!--分页-->
            <div class="btntable_tbg">
                <div id="divPage" runat="server" class="fy">
                </div>
                <!--分页-->
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
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
            location.href = "M_Feedback.aspx?pageid=" + pageindex;
        }
    }
</script>
