<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<span name="nametarget"></span>
<style type="text/css">
    /* 评价动态评分样式 */
    
    .seller-ratechart th
    {
        font-weight: 700;
        padding-left: 40px;
    }
    
    .seller-ratechart td
    {
        border: 0;
        padding: 10px 5px 0;
        text-align: left;
    }
    
    /*店铺评价进度条*/
    
    .seller-ratechart td
    {
        height: 80px;
    }
    
    .ncs-rate-column
    {
        background: url(images/rate_column.gif) no-repeat 28px -88px;
        display: inline-block;
        margin: 0 auto;
        padding: 0;
        width: 410px;
    }
    
    .ncs-rate-column dt
    {
        display: block;
        height: 14px;
        margin-left: 0px;
        margin-right: 60px;
        position: relative;
        width: 350px;
        z-index: 1;
    }
    
    .ncs-rate-column dt em
    {
        background: url(images/rate_column.gif) no-repeat 0 0;
        color: #FFF;
        display: block;
        font-weight: 600;
        height: 16px;
        line-height: 16px;
        padding: 0 0 7px 0;
        position: absolute;
        text-align: center;
        top: -25px;
        width: 37px;
    }
    
    .ncs-rate-column dd
    {
        color: #777;
        display: inline;
        float: left;
        line-height: 24px;
        text-align: center;
        width: 80px;
    }
    
    /* 信用度 */
    
    .seller-ratechart p
    {
        float: left;
    }
    
    .rate-star em, .rate-star em i
    {
        background-image: url(images/rate_star.gif);
        background-repeat: repeat-x;
        height: 12px;
    }
    
    .rate-star em
    {
        background-position: left top;
        display: block;
        float: left;
        margin: 0;
        position: relative;
        width: 70px;
        z-index: 1;
    }
    
    .rate-star em i
    {
        background-position: left bottom;
        left: 0px;
        position: absolute;
        top: 0px;
        z-index: 1;
    }
    
    .rate-star span
    {
        display: block;
        float: left;
        margin-left: 6px;
        _margin-left: 3px;
    }
</style>
<div id="list_main">
    <table class="seller-ratechart" id="sixmonth" style="margin: 30px 30px 10px;">
        <tr>
            <th colspan="3" align="left">
                店铺动态评分
            </th>
        </tr>
        <tr>
            <th>
                <p>
                    宝贝与描述相符</p>
                <p class="rate-star mt5">
                    <em><i style="width: <%= hidCharacter.Value %>%;"></i></em>
                </p>
            </th>
            <td>
                <dl class="ncs-rate-column">
                    <dt><em style="left: <%= hidCharacter.Value %>%;">
                        <%= Convert.ToInt32(hidCharacter.Value)/20 %></em></dt>
                    <dd>
                        非常不满</dd>
                    <dd>
                        不满意</dd>
                    <dd>
                        一般</dd>
                    <dd>
                        满意</dd>
                    <dd>
                        非常满意</dd>
                </dl>
            </td>
        </tr>
        <tr>
            <th>
                <p>
                    卖家的服务态度</p>
                <p class="rate-star mt5">
                    <em><i style="width: <%= hidAttitude.Value %>%;"></i></em>
                </p>
            </th>
            <td>
                <dl class="ncs-rate-column">
                    <dt><em style="left: <%= hidAttitude.Value %>%;">
                        <%= Convert.ToInt32(hidAttitude.Value)/20 %></em></dt>
                    <dd>
                        非常不满</dd>
                    <dd>
                        不满意</dd>
                    <dd>
                        一般</dd>
                    <dd>
                        满意</dd>
                    <dd>
                        非常满意</dd>
                </dl>
            </td>
        </tr>
        <tr>
            <th>
                <p>
                    卖家的发货速度</p>
                <p class="rate-star mt5">
                    <em><i style="width: <%= hidSpeed.Value %>%;"></i></em>
                </p>
            </th>
            <td>
                <dl class="ncs-rate-column">
                    <dt><em style="left: <%= hidSpeed.Value %>%;">
                        <%= Convert.ToInt32(hidSpeed.Value)/20 %></em></dt>
                    <dd>
                        非常不满</dd>
                    <dd>
                        不满意</dd>
                    <dd>
                        一般</dd>
                    <dd>
                        满意</dd>
                    <dd>
                        非常满意</dd>
                </dl>
            </td>
        </tr>
    </table>
    <div class="ordmain1">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="pinji">
            <tr>
                <th colspan="5" align="left">
                    <span style="float: right;">好评率：<asp:Label ID="lblGoodRate" runat="server" Text="0"></asp:Label>
                        %</span>
                    <%--卖家累积信用：0--%>
                </th>
            </tr>
            <tr>
                <td class="pingjia_bg">
                    &nbsp;
                </td>
                <td class="one1">
                    好评
                </td>
                <td class="one2">
                    中评
                </td>
                <td class="one3">
                    差评
                </td>
                <td class="pingjia_bg" style="border-right: solid 1px #f3f3f3;">
                    总计
                </td>
            </tr>
            <tr>
                <td>
                    最近1周
                </td>
                <td>
                    <asp:Label ID="lblWeekGood" runat="server" Text="0"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblWeekMiddle" runat="server" Text="0"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblWeekBad" runat="server" Text="0"></asp:Label>
                </td>
                <td style="border-right: solid 1px #f3f3f3;">
                    <asp:Label ID="lblWeekTotal" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    最近1个月
                </td>
                <td>
                    <asp:Label ID="lblMonthGood" runat="server" Text="0"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblMonthMiddle" runat="server" Text="0"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblMonthBad" runat="server" Text="0"></asp:Label>
                </td>
                <td style="border-right: solid 1px #f3f3f3;">
                    <asp:Label ID="lblMonthTotal" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    最近6个月
                </td>
                <td>
                    <asp:Label ID="lblSixRMonthGood" runat="server" Text="0"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSixRMonthMiddle" runat="server" Text="0"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSixRMonthBad" runat="server" Text="0"></asp:Label>
                </td>
                <td style="border-right: solid 1px #f3f3f3;">
                    <asp:Label ID="lblSixRMonthTotal" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    6个月前
                </td>
                <td>
                    <asp:Label ID="lblSixBMonthGood" runat="server" Text="0"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSixBMonthMiddle" runat="server" Text="0"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSixBMonthBad" runat="server" Text="0"></asp:Label>
                </td>
                <td style="border-right: solid 1px #f3f3f3;">
                    <asp:Label ID="lblSixBMonthTotal" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="border-bottom: solid 1px #f3f3f3;">
                    总计
                </td>
                <td style="border-bottom: solid 1px #f3f3f3;">
                    <asp:Label ID="lblGoodTotal" runat="server" Text="0"></asp:Label>
                </td>
                <td style="border-bottom: solid 1px #f3f3f3;">
                    <asp:Label ID="lblMiddleTotal" runat="server" Text="0"></asp:Label>
                </td>
                <td style="border-bottom: solid 1px #f3f3f3;">
                    <asp:Label ID="lblBadTotal" runat="server" Text="0"></asp:Label>
                </td>
                <td style="border-bottom: solid 1px #f3f3f3; border-right: solid 1px #f3f3f3;">
                    <asp:Label ID="lblAllTotal" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <ul id="sidebar">
        <li class="<%= ShopNum1.Common.Common.ReqStr("type") == "" || ShopNum1.Common.Common.ReqStr("type") == "1" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>">
            <a href="?type=1">买家的评价</a></li>
        <li class="<%= ShopNum1.Common.Common.ReqStr("type") == "2" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>">
            <a href="?type=2">给他人的评价</a></li>
    </ul>
    <div id="content" class="ordmain1">
        <div class="biaogenr">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="blue_tbw1">
                <tr>
                    <th width="10%" class="th_le">
                        评价
                    </th>
                    <th width="35%">
                        评论内容
                    </th>
                    <th width="15%">
                        <%= ShopNum1.Common.Common.ReqStr("type") == "1" ? "买家ID" : "买家ID" %>
                    </th>
                    <th width="30%" class="th_ri">
                        宝贝信息
                    </th>
                    <% if (ShopNum1.Common.Common.ReqStr("type") == "2")
                       { %>
                    <th width="10%" class="th_ri">
                        操作
                    </th>
                    <% } %>
                </tr>
                <asp:Repeater ID="repBingComment" runat="server">
                    <ItemTemplate>
                        <tr class="feedback" data-id="<%#Eval("Guid") %>">
                            <td class="th_le">
                                <span class="rate-icon rate-ok">
                                    <%#Common.SetShopCommentTxt(Eval("Commenttype").ToString()) %></span>
                            </td>
                            <td class="reviews-cnt">
                                <div class="reviews-cnt-bd">
                                    <p class="rate" style="text-align: left; word-break: break-all" mode="wrap">
                                        <%#Eval("comment").ToString() %>
                                    </p>
                                    <span class="date" style="color: #ff6600; display: block; text-align: right;">[<%#Eval("commenttime") %>]</span>
                                    <p class="rate" style="text-align: left; word-break: break-all;" mode="wrap">
                                        <%#Eval("continuecomment").ToString() %></p>
                                    <span class="date" style="color: #ff6600; display: block; text-align: right;">[<%#Eval("continuetime") %>]</span>
                                </div>
                                <% if (ShopNum1.Common.Common.ReqStr("type") == "2")
                                   { %>
                                <div class="reviews-cnt-bd">
                                    <p class="rate shopcomment" style="text-align: left; word-break: break-all" mode="wrap">
                                        <%#Eval("reply") %></p>
                                    <span class="date">
                                        <%#Eval("replytime") %></span>
                                </div>
                                <% } %>
                            </td>

                            <td>
                                <span class="shop_Name">
                                    <%#Eval("memloginID") %></span></a>
                            </td>
                            <td class="th_ri">
                                <p class="auction">
                                    <a href="<%#ShopUrlOperate.shopHrefcenter(Eval("productguid").ToString(), Eval("shoploginid").ToString(),Eval("shop_category_id").ToString()) %>"
                                        title="<%#Eval("ProductName") %>" target="_blank">
                                        <%#Eval("ProductName") %></a> <span class="price"><em>
                                            <%#Eval("ProductPrice") %></em>元</span>
                                </p>
                            </td>
                            <% if (ShopNum1.Common.Common.ReqStr("type") == "2")
                               { %>
                            <td class="th_ri" check_replay='<%#Eval("reply") %>'>
                                <span id="span"><a href="#" onclick=" ShowPopComment(this); " class="alink_blue"
                                    lang='<%#Eval("guid") %>' buyer='<%#Eval("memloginID") %>'>回评</a></span>
                            </td>
                            <% } %>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <% if (repBingComment.Items.Count == 0)
                   { %>
                <tr>
                    <td colspan="5" class="th_le th_ri">
                        <div class="no_datas">
                            <div class="no_data">
                                暂无符合条件的数据记录</div>
                        </div>
                    </td>
                </tr>
                <% } %>
            </table>
            <!--分页-->
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_b"
                style="border-left: 1px solid #e3e3e3; margin-top: 10px;">
                <tr>
                    <td>
                        <div id="divPage" runat="server" class="fy">
                        </div>
                    </td>
                </tr>
            </table>
            <!--分页-->
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
    String.prototype.trim = function () {
        return this.replace(/(^[\s]*)|([\s]*$)/g, "");
    };

    $(function () {
        $(".shopcomment").each(function () {
            if ($(this).text() == "") {
                $(this).parent().parent().next().next().next().find("span").hide();
            }
        });

        $(".blue_tbw1 .reviews-cnt-bd .rate").each(function () {
            if ($(this).text().trim() == "") {
                $(this).next().text("");
            }
        });
        //通过该方法隐藏操作按钮
        $(".opcheck").each(function () {
            if ($(this).attr("check_replay") != "") {
                $(this).html("&nbsp;&nbsp;");
            }
        });
        //回复
        $("#btnReply").click(function () {
            var buyerC = $('input:radio[name="buyercomment"]:checked').val();
            var bc = escape($("#txtReply").val());
            if ($("#txtReply").val() == "") {
                alert("回复内容不能为空！");
                return false;
            }
            var sp = $("#hidShopProductComment").val();
            $.get("/Api/ShopAdmin/S_CreditHonor.ashx?type=sendReply&buyerc=" + buyerC + "&reply=" + bc + "&pguid=" + sp + "", null, function (data) {

            });
            alert("回复成功！");
            funClose();
            location.reload();
        });

        $(".rate").each(function () {
            if ($(this).text() == "") {
                $(this).next().hide();
            }
        });
    });

    function ShowPopComment(o) {
        window.parent.scrollTo(0, 0);
        $("#showbuyer").text($(o).attr("buyer"));
        $("#hidShopProductComment").val($(o).attr("lang"));
        funOpen();
        $("#txtReply").val("");
    }
</script>
<input type="hidden" id="hidSpeed" runat="server" />
<input type="hidden" id="hidCharacter" runat="server" />
<input type="hidden" id="hidAttitude" runat="server" />
<!--弹出层-->
<div class="sp_dialog sp_dialog_out" style="display: none;" id="sp_dialog_outDiv">
    <div class="sp_dialog_cont" style="display: none;" id="sp_dialog_contDiv">
        <div class="sp_tan">
            <h4>
                对买家进行评价</h4>
            <div class="sp_close">
                <a onclick=" funClose() " href="javascript:void(0)"></a>
            </div>
            <div class="clear">
            </div>
        </div>
        <div style="padding: 20px;">
            <input type="hidden" id="hidShopProductComment" />
            买家：<span id="showbuyer"></span><br />
            <input type="radio" name="buyercomment" value="5" checked="checked" />好评
            <input type="radio" name="buyercomment" value="3" />中评
            <input type="radio" name="buyercomment" value="1" />差评
            <textarea id="txtReply" style="border: 1px solid #bfbfbf; height: 100px; width: 100%;"></textarea>
        </div>
        <div style="padding-bottom: 20px; text-align: center;">
            <input type="button" id="btnReply" value="确定" class="baocbtn" /></div>
    </div>
</div>
<!--弹出层-->
