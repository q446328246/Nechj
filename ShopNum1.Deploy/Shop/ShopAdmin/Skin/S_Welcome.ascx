<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<%@ Import Namespace="ShopNum1.Common" %>

<div class="right_mian">
    <div class="jianjie">
        <div class="admin1">
            <dl class="adm">
                <dt><a target="_blank" href="javascript:void(0)" id="shopUrlA" runat="server">
                    <asp:Image ID="ImageShopSign" runat="server" Width="125" Height="125" onerror="javascript:this.src='/ImgUpload/noImg.jpg'" />
                </a></dt>
                <dd>
                </dd>
            </dl>
        </div>
        <div class="jjnr">
            <table width="200" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="redht">
                        <%= Common.cut(LabelName.Text, 20) %>
                        <asp:Label ID="LabelName" runat="server" Text="ShopNum1" Visible="false"></asp:Label>
                    </td>
                    <td>
                        <img src="~/Shop/ShopAdmin/images/kapic01.gif" width="27" height="22" runat="server"
                            id="imageIdd" alt="身份验证" title="身份验证" />
                    </td>
                    <td>
                        <img src="~/Shop/ShopAdmin/images/kapic02.gif" width="27" height="22" runat="server"
                            id="imageCompany" alt="企业验证" title="企业验证" />
                    </td>
                </tr>
            </table>
            <p>
                卖家信用：<asp:Label ID="LabelShopReputation" runat="server" Text="0"></asp:Label>
                <asp:Image ID="ImageShopReputation" runat="server" />
            </p>
            <p>
                店铺名称：<span class="blue"><a class="alink_blue" href="S_ShopInfo.aspx"><asp:Label ID="LabelShopName"
                    runat="server" Text="ShopNum1"></asp:Label></a></span></p>
            <p>
                店铺等级：<span class="blue"><a class="alink_blue" href="S_ShowShopRank.aspx"><asp:Label
                    ID="LabelShopRank" runat="server" Text="ShopNum1"></asp:Label></a></span>
                <asp:Image ID="ImagePic" runat="server" Height="20" />
            </p>
            <%--<p>
                过期时间：<span class="blue"><asp:Label ID="LabelVerifyTime" runat="server" Text="1900-1-1"></asp:Label>
                    <asp:Button ID="ButtonGoPayFor" runat="server" Text="续费" CssClass="chax" 
                    onclick="ButtonGoPayFor_Click"></asp:Button>
                </span>
            </p>--%>
        </div>
        <div class="dppf">
            <h1>
                动态评分(好评率<span id="shoprate"></span>%)</h1>
            <input type="hidden" id="hidShopRate" runat="server" />
            <input type="hidden" id="hidDetail" runat="server" />
            <input type="hidden" id="hidService" runat="server" />
            <input type="hidden" id="hidSpeed" runat="server" />
            <table width="170" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="60">
                        描述相符：
                    </td>
                    <td id="character">
                        <img src="images/xingxing01.gif" width="16" height="16" />
                        <img src="images/xingxing01.gif" width="16" height="16" />
                        <img src="images/xingxing01.gif" width="16" height="16" />
                        <img src="images/xingxing01.gif" width="16" height="16" />
                        <img src="images/xingxing01.gif" width="16" height="16" />
                    </td>
                </tr>
                <tr>
                    <td>
                        服务态度：
                    </td>
                    <td id="service">
                        <img src="images/xingxing02.gif" width="16" height="16" />
                        <img src="images/xingxing02.gif" width="16" height="16" />
                        <img src="images/xingxing02.gif" width="16" height="16" />
                        <img src="images/xingxing02.gif" width="16" height="16" />
                        <img src="images/xingxing02.gif" width="16" height="16" />
                    </td>
                </tr>
                <tr>
                    <td>
                        发货速度：
                    </td>
                    <td id="speed">
                        <img src="images/xingxing02.gif" width="16" height="16" />
                        <img src="images/xingxing02.gif" width="16" height="16" />
                        <img src="images/xingxing02.gif" width="16" height="16" />
                        <img src="images/xingxing02.gif" width="16" height="16" />
                        <img src="images/xingxing02.gif" width="16" height="16" />
                    </td>
                </tr>
            </table>
            <script type="text/javascript" language="javascript">
                var Detail = parseInt(document.getElementById("S_Welcome_ctl00_hidDetail").value) / 20;
                var Service = parseInt(document.getElementById("S_Welcome_ctl00_hidService").value) / 20;
                var speed = parseInt(document.getElementById("S_Welcome_ctl00_hidSpeed").value) / 20;
                setImg(Detail, "character");
                setImg(Service, "service");
                setImg(speed, "speed");
                document.getElementById("shoprate").innerHTML = document.getElementById("S_Welcome_ctl00_hidShopRate").value;

                function setImg(len, id) {
                    var imgpush = new Array();
                    for (var i = 1; i < 6; i++) {
                        if (i <= len) {
                            imgpush.push("<img src=\"images/xingxing02.gif\"/>");
                        } else {
                            imgpush.push("<img src=\"images/xingxing01.gif\"/>");
                        }
                    }
                    document.getElementById(id).innerHTML = imgpush.join("");
                }
            </script>
        </div>
    </div>
    <div class="dianputs">
        <h1>
            店铺提示</h1>
        <div class="pad" style="padding: 10px 8px 6px;">
            <table width="100%" border="0" cellspacing="4" cellpadding="2" class="dianpqk">
                <tr>
                    <th colspan="6" scope="col" align="left" style="padding-left: 10px; padding-top: 8px;">
                        您需要关注的店铺情况：
                    </th>
                </tr>
                <tr>
                    <td width="60" style="padding: 5px 1px 8px 10px; white-space: nowrap;">
                        商品提示：
                    </td>
                    <td style="padding: 5px 0px 8px; white-space: nowrap;">
                        <a href="S_StoreProduct.aspx" class="alink_blue">仓库待上架商品(<asp:Label ID="LabelSaleCount"
                            runat="server" Text="0"></asp:Label>)</a>
                    </td>
                    <td width="60" style="padding: 5px 1px 8px 10px; white-space: nowrap;">
                        咨询提示：
                    </td>
                    <td style="padding: 5px 0px 8px; white-space: nowrap;">
                        <a href="S_MessageBoardList.aspx" class="alink_blue">买家的留言(<asp:Label ID="Label_MessageBoard"
                            runat="server" Text="0"></asp:Label>)</a>
                    </td>
                    <td style="padding: 5px 1px 8px 10px; white-space: nowrap;" width="60">
                        违规提示：
                    </td>
                    <td style="padding: 5px 0px 8px; white-space: nowrap;">
                        <a href="S_MemberReport.aspx" class="alink_blue">被举报禁售(<asp:Label ID="LabelMemberReport"
                            runat="server" Text="0"></asp:Label>)</a>
                    </td>
                </tr>
            </table>
            <table border="0" cellspacing="4" cellpadding="0" style="margin: 10px;">
                <tr>
                    <td style="width: 250px;">
                        <a href="S_SellProduct.aspx">出售中的商品(<asp:Label ID="LabelSaleOnline" runat="server"
                            Text="0"></asp:Label>)</a>
                    </td>
                    <td style="width: 250px;">
                        可用金币（BV）(<asp:Label ID="LabelAdvancePayment" runat="server" Text="0"></asp:Label>)
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="notice1">
        <h1>
            公告</h1>
        <ul>
            <asp:Repeater ID="RepeaterAnnouncement" runat="server">
                <ItemTemplate>
                    <li>· <a target="_blank" href='<%#ShopUrlOperate.RetUrl("AnnouncementDetail", Eval("Guid").ToString()) %>'
                        target="_blank">
                        <%#Utils.GetUnicodeSubString(Eval("Title").ToString(), 23, "") %></a></li>
                </ItemTemplate>
            </asp:Repeater>
            <% if (RepeaterAnnouncement.Items.Count == 0)
               { %>
            <li><span>暂无数据</span></li>
            <% } %>
        </ul>
    </div>
    <div class="jyts">
        <h1>
            交易提示</h1>
        <div class="pad" style="overflow: hidden; padding: 10px 8px 6px;">
            <table width="100%" border="0" cellspacing="4" cellpadding="2" class="dianpqk">
                <tr>
                    <th colspan="6" scope="col" align="left" style="padding-left: 10px; padding-top: 8px;">
                        您需要立即处理的交易订单：
                    </th>
                </tr>
                <tr>
                    <td width="60" style="padding: 5px 1px 8px 10px; white-space: nowrap;">
                        近期售出：
                    </td>
                    <td style="padding: 5px 0px 8px; white-space: nowrap;">
                        <a href="S_Order_List.aspx" class="alink_blue">交易中的订单(<asp:Label ID="LabelPayOrderIng"
                            runat="server" Text=""></asp:Label>)</a>
                    </td>
                    <td width="60" style="padding: 5px 1px 8px 10px; white-space: nowrap;">
                        维权提示：
                    </td>
                    <td style="padding: 5px 0px 8px; white-space: nowrap;">
                        <a href="S_OrderComplaints.aspx" class="alink_blue">收到维权投诉(<asp:Label ID="LabelOrderComplaint"
                            runat="server" Text="Label"></asp:Label>)</a>
                    </td>
                    <td width="60" style="padding: 5px 1px 8px 10px; white-space: nowrap;">
                        最新评论：
                    </td>
                    <td style="padding: 5px 0px 8px; white-space: nowrap;">
                        <a href="S_CreditHonor.aspx" class="alink_blue">店铺最新评论(<asp:Label ID="LabelProductComment"
                            runat="server" Text="0"></asp:Label>)</a>
                    </td>
                </tr>
            </table>
            <table border="0" cellspacing="4" cellpadding="0" style="margin: 10px;">
                <tr>
                    <td style="width: 190px;">
                        <a href="S_Order_List.aspx?ostate=0&sstate=0&pstate=0&stype=1&PageID=6" class="alink_blue">
                            待付款(<asp:Label ID="LabelWaitPayOrder" runat="server" Text="0"></asp:Label>)</a>
                    </td>
                    <td style="width: 190px;">
                        <a href="S_Order_List.aspx?ostate=1&sstate=0&pstate=1&stype=2&PageID=2" class="alink_blue">
                            待发货(<asp:Label ID="LabelWaitSendProduct" runat="server" Text="0"></asp:Label>)</a>
                    </td>
                    <td style="width: 190px;">
                        <a href="S_Order_List.aspx?ostate=2&sstate=1&pstate=1&stype=3" class="alink_blue">待收货(<asp:Label
                            ID="LabelWaitGetProduct" runat="server" Text="0"></asp:Label>)</a>
                    </td>
                    <td style="width: 190px;">
                        <a href="S_Order_List.aspx?ostate=3&sstate=2&pstate=1&iscomment=0&stype=6" class="alink_blue">
                            待评价(<asp:Label ID="LabelWaitPinjia" runat="server" Text="Label"></asp:Label>)</a>
                    </td>
                </tr>
                <tr>
                    <td style="width: 190px;">
                        <a href="S_Order_List.aspx?ostate=1&sstate=0&pstate=3&stype=5" class="alink_blue">退款(<asp:Label
                            ID="LabelReturnMoney" runat="server" Text="0"></asp:Label>)</a>
                    </td>
                    <td style="width: 190px;">
                        <a href="S_Order_List.aspx?ostate=2&sstate=4&pstate=0&stype=8" class="alink_blue">退货(<asp:Label
                            ID="LabelReturnProduct" runat="server" Text="0"></asp:Label>)</a>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="clear: both; height: 0px;">
    </div>
    <div class="huadong">
        <div id="channel">
            <h1>
                <ul>
                    <li id="channel1" onmouseover=" channelkey(1) " style="color: #CC0000;">交易数据</li>
                    <%--<li style="text-indent:4px;" id="channel2" onmouseover="channelkey(2)">访问数据</li>--%>
                </ul>
            </h1>
            <div id="menucontent1" class="menu" style="display: block;">
                <div class="pad">
                    <table border="0" cellspacing="0" cellpadding="5" class="blue_tb10">
                        <tr>
                            <th class="th_le1" width="80" style="border-right: solid 1px #e3e3e3;">
                                &nbsp;
                            </th>
                            <th class="th_ri1">
                                成交笔数
                            </th>
                            <th class="th_ri1">
                                成交金额
                            </th>
                            <th class="th_ri1">
                                成交用户数
                            </th>
                            <th class="th_ri1">
                                成交转化率
                            </th>
                            <th class="th_ri1">
                                退款订单量
                            </th>
                        </tr>
                        <tr>
                            <td class="th_le1">
                                今天
                            </td>
                            <td>
                                <asp:Label ID="Labelztcj" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Labelztje" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Labelztuser" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Labelztzhl" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Labelztorder" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="th_le1">
                                昨天
                            </td>
                            <td>
                                <asp:Label ID="Labelqtcj" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Labelqtje" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Labelqtuser" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Labelqtzhl" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Labelqtorder" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div class="fontwei">
                        评价数据：</div>
                    <table border="0" cellspacing="0" cellpadding="5" class="blue_tb10">
                        <tr>
                            <th class="th_le1" width="80" style="border-right: solid 1px #e3e3e3;">
                                &nbsp;
                            </th>
                            <th class="th_ri1">
                                评价总数
                            </th>
                            <th class="th_ri1">
                                好评数
                            </th>
                            <th class="th_ri1">
                                中评数
                            </th>
                            <th class="th_ri1">
                                差评数
                            </th>
                        </tr>
                        <tr>
                            <td class="th_le1">
                                最近30天
                            </td>
                            <td>
                                <asp:Label ID="LabelSumComment" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelSumCommentGood" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelSumCommentZhong" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelSumCommentCha" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="menucontent2" class="menu" style="display: none; height: 278px;">
                22222
            </div>
        </div>
    </div>
    <%--<div class="weiwc">
        <h1>
            店铺运营推广</h1>
        <a href="S_GroupProduct.aspx" class="tuang_a">
            <dl class="tgo">
                <dt>
                    <img src="images/tuangou.jpg" width="86" height="81" /></dt>
                <dd>
                    参与平台发起的团购活动提高商品成交量及店铺浏览量</dd>
            </dl>
        </a><a href="S_Limit_ActivityList.aspx" class="tuang_a">
            <dl class="tgo">
                <dt>
                    <img src="images/xianshi.jpg" width="86" height="81" /></dt>
                <dd>
                    在规定时间段内对店铺中所选商品进行打折促销活动</dd>
            </dl>
        </a>
        <%--<a href="#" class="tuang_a">
      <dl class="tgo">
        <dt><img src="images/manjs.jpg" width="86" height="81" /></dt>
        <dd>商家自定义满即送标准与规则，促进购买转化率</dd>
      </dl>
      </a>--%>
        <%--<a href="S_ShopCoupon.aspx" class="tuang_a">
            <dl class="tgo">
                <dt>
                    <img src="images/youhq.jpg" width="86" height="81" /></dt>
                <dd>
                    商家自行发布的线下店铺优惠券，供买家打印使用</dd>
            </dl>--%>
        </a><%--<a href="S_PackAgeList.aspx" class="tuang_a">
            <dl class="tgo">
                <dt>
                    <img src="images/zhuhexs.jpg" width="86" height="81" /></dt>
                <dd>
                    商品组合销售、多重搭配更多实惠、商家必备营销方式</dd>
            </dl>
        </a><a href="S_ZtcApply_List.aspx" class="tuang_a">
            <dl class="tgo">
                <dt>
                    <img src="images/zhitc.jpg" width="86" height="81" /></dt>
                <dd>
                    参加直通车服务的商品可出现在商品列表页侧面</dd>
            </dl>
        </a>--%>
        <div style="clear: both;">
        </div>
        <%--<a href="#" class="tuang_a">
      <dl class="tgo">
        <dt><img src="images/daijq.jpg" width="86" height="81" /></dt>
        <dd>自定义代金券使用规则并由平台统一展示供买家领取</dd>
      </dl>
      </a>


      <a href="#" class="tuang_a"> 
      <dl class="tgo">
        <dt><img src="images/zhuthd.jpg" width="86" height="81" /></dt>
        <dd>选择商品参与平台发布的主题活动，审核后集中展示</dd>
      </dl>
      </a>--%>
    </div>
</div>
