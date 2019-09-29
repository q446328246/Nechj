<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_Welcome.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_Welcome" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<%@ Register Src="M_WelcomeProduct.ascx" TagName="M_WelcomeProduct" TagPrefix="uc1" %>
<script src="../js/jquery-1.6.2.min.js" type="text/javascript"></script>
<script src="../js/channle.js" type="text/javascript"></script>
<script type="text/javascript">
     


//            function MemUpgrade() {

////                $.get("/Api/Main/Member/ThreeClassify.ashx", null, function (data) {
//                    if (data != "") {
//                        if (data == "no") {
//                            var qiandao = data.split('|');
//                            $("#showjfTitle").html("A积分大于300才能升级！");
//                            $("#showjf").html("&nbsp;&nbsp;&nbsp;&nbsp;");
//                            $("#memranklevel").show(1000);
//                            return false;
//                        }

//                    }
//                }
//                    );
//            }

    


    function funHideDiv() {
        $("#qiandao").hide(1000);
        
    }

    
</script>
<div class="right_mian">
    <div class="wel">
        <div class="wel_right1">
            <p style="padding-top: 8px;">
                <span class="redht">
                    <asp:Label ID="LabelMemLoginID" runat="server" Text=""></asp:Label></span>，欢迎您！</p>
            <p style="padding-top: 8px;">
                登录次数：<strong class="red"><asp:Label ID="LabelLoginTime" runat="server" Text=""></asp:Label></strong>
                次
                <asp:Label ID="LabelShowShang" runat="server" Text="您上一次登录的时间："></asp:Label>
                <span class="orange">
                    <asp:Label ID="LabelLastLoginTime" runat="server" Text=""></asp:Label></span></p>
            <p style="padding-top: 8px;">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td>
                            <span class="shouj1" style="color: #005ea7; padding-right: 8px;">会员等级: </span>
                        </td>
                        <td style="padding-right: 10px;">
                            <asp:Image ID="ImageRank" runat="server" Style="height: 16px"></asp:Image>
                        </td>
                        <td>
                            <a href="javascript:void(0)" class="shouj" runat="server" id="Sjyz" style="color: #005ea7;">
                                手机已验证</a>
                        </td>
                        <td>
                            <a href="javascript:void(0)" class="youx" runat="server" id="Yxyz" style="color: #005ea7;">
                                邮箱已验证</a>
                        </td>
                        <td>
                            <a class="shouj11" runat="server" id="Sjwyz" style="color: #005ea7;" href="/main/account/A_PwdSer.aspx">
                                手机未验证</a>
                        </td>
                        <td>
                            <a class="youx11" runat="server" id="Yxwyz" style="color: #005ea7;" href="/main/account/A_PwdSer.aspx">
                                邮箱未验证</a>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </p>
            <div style="clear: both">
            </div>
            <div style="border: solid 1px #ffeacd; margin-top: 7px; padding: 6px; width: 95%;">
                <table border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            当前人民币：
                        </td>
                        <td>
                            <strong class="red">￥<asp:Label ID="LabelAdvancePayment" runat="server" Text="0.00"></asp:Label></strong>
                        </td>
                        <td style="padding-left: 10px;">
                            <input name="12" type="button" class="chax" value="充值" onclick="funGoPay()" />
                        </td>
                         
                        <%--<td style=" display:none">
                            冻结兑换积分：
                        </td>
                    <td style="padding-left: 10px;display:none">
                            <strong class="red"><asp:Label ID="LabelDJ" runat="server" Text="0.00"></asp:Label></strong>
                        </td>--%>

                        <td >
                            新能源链：
                        </td>
                    <td style="padding-left: 10px;">
                            <strong class="red"><asp:Label ID="LabelDJ" runat="server" Text="0.00"></asp:Label></strong>
                        </td>
                        
                    </tr>
                    <tr id="guke" runat="server">
                        <td>
                            新能源币：
                        </td>
                        <td style="padding-left: 10px;">
                            <strong class="red"><asp:Label ID="LabelScore_dv" runat="server" Text="0.00"></asp:Label></strong>
                        </td>
                        <td style="padding-left: 10px;">
                        </td>
                        <td>
                            总里程：
                        </td>
                    <td style="padding-left: 10px;">
                            <strong class="red"><asp:Label ID="LabelScore_pv_bdd" runat="server" Text="0.00"></asp:Label></strong>公里
                        </td>
                    </tr>
                        
                    <tr id="guke2" runat="server" style=" display:none">
                        <td>
                            联盟已销售额：
                        </td>
                        <td style="padding-left: 10px;">
                            <strong class="red">
                                <asp:Label ID="LabelScore_pv_a" runat="server" Text="0.00"></asp:Label></strong>
                        </td>
                        <td style="padding-left: 10px;">
                        </td>
                        <td>
                            联盟可销售额：
                        </td>
                        <td style="padding-left: 10px;">
                            <strong class="red">￥<asp:Label ID="LabelScore_rv" runat="server" Text="0.00"></asp:Label></strong>
                        </td>
                    </tr>
                    <tr id="Tr1" runat="server">
                        <td>
                            本月累计B积分：
                        </td>
                        <td style="padding-left: 10px;">
                            <strong class="red">￥<asp:Label ID="LabelScore_pv_b" runat="server" Text="0.00"></asp:Label></strong>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div class="notice">
        <h1>
            公告</h1>
        <ul>
            <asp:Repeater ID="RepeaterAnnouncement" runat="server">
                <ItemTemplate>
                    <li>· <a target="_blank" href='<%#ShopUrlOperate.RetUrl("AnnouncementDetail",Eval("Guid").ToString()) %>'
                        target="_blank">
                        <%#Utils.GetUnicodeSubString(Eval("Title").ToString(), 23, "")%></a></li>
                </ItemTemplate>
            </asp:Repeater>
            <%if (RepeaterAnnouncement.Items.Count == 0)
              { %>
            <li>暂无公告</li>
            <% }%>
        </ul>
    </div>
    <div class="nrleft">
        <div class="weiwc" style="width: 601px; height: auto; margin-top: 10px;">
            <h1>
                <%--<span class="ord_all"><a href="M_OrderList.aspx" >所有订单</a></span>--%>
                我未完成的交易(<asp:Label ID="LabelWwcOrder" runat="server" Text="0"></asp:Label>)</h1>
            <div>
                <p class="shouhzt">
                    我的订单：<a href="M_OrderList.aspx?st=0" class="alink_blue">待付款（<span class="red"><asp:Label
                        ID="LabelWaitPayOrder" runat="server" Text="0"></asp:Label></span>）</a>&nbsp;│&nbsp;<a
                            href="M_OrderList.aspx?st=2" class="alink_blue">待确认收货（<span class="red"><asp:Label
                                ID="LabelWaitMakeSure" runat="server" Text="0"></asp:Label></span>）</a></p>
                <p class="shouhzt">
                    生活服务订单：<a href="M_LifeOrderList.aspx?st=0" class="alink_blue">待付款（<span class="red"><asp:Label
                        ID="lblLifeWaitPayOrder" runat="server" Text="0"></asp:Label></span>）</a>&nbsp;│&nbsp;<a
                            href="M_LifeOrderList.aspx?st=2" class="alink_blue">待确认收货（<span class="red"><asp:Label
                                ID="lblLifeWaitMakeSure" runat="server" Text="0"></asp:Label></span>）</a></p>
            </div>
        </div>
        <%--        <ShopNum1:M_WelcomeProduct ID="M_WelcomeProduct" runat="server" SkinFilename="Skin/M_WelcomeProduct.ascx" />--%>
        <uc1:M_WelcomeProduct ID="M_WelcomeProduct1" runat="server" />
        <div class="weiwc gmbot">
            <h1>
                <span class="gmqiant">
                    <asp:HiddenField ID="HiddenFieldPage" runat="server" Value="1"></asp:HiddenField>
                    <a href="#">
                        <img src="images/scdp_left.jpg" width="16" height="19" onclick="funShang()" /></a><a
                            href="#"><img src="images/scdp_right.jpg" width="16" height="19" onclick="funNext()" /></a>
                </span>我购买过的店铺</h1>
            <div class="pad">
                <div>
                    <dl class="dpname" id="showShop">
                        <dt><a target="_blank" id="shopLink">
                            <img src="images/dianplogo.jpg" width="100" height="100" id="shopImage" /></a>
                        </dt>
                        <dd class="dpm" id="buy_shopname">
                            <a href="#" class="alink_red">重庆唐江电子商务有限公司</a></dd>
                        <dd>
                            联系电话：<span id="myphone"></span></dd>
                        <dd>
                            所在地：<span id="shopAdress"></span></dd>
                    </dl>
                </div>
                <div style="clear: both;">
                </div>
                <p class="gm_title">
                    我所购买的商品</p>
                <div style="clear: both;">
                </div>
                <div id="showShopProduct">
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function funGoPay() {
            //        this.form1.target='_parent';
            window.location.href = "/main/account/A_AdPayRecharge.aspx";
        }
        var guid, shopname, phone, addressvalue, memloginid, banner;
        $(function () {
            funAll(1);
            funBrowseProduct(1, 4);
            funGroupProduct(1, 4);
            funQgProduct(1, 4);

        })

        function funAll(val) {
            $.get("/Api/Main/Member/GetJson.ashx?type=GetBuyShop&page=" + val + "", null, function (data) {
                if (data != "") {
                    if (data != "[object XMLDocument]" && data != "") {
                        var vdata = eval('(' + data + ')');
                        $.each(vdata, function (m, n) {

                            shopname = n.shopname;
                            $("#buy_shopname").text(shopname);
                            guid = n.guid;
                            phone = n.phone;
                            $("#myphone").html(phone);
                            addressvalue = n.addressvalue;
                            $("#shopAdress").html(addressvalue);
                            memloginid = n.memloginid;
                            funAllProduct(memloginid);
                            banner = n.banner;
                            $("#shopImage").attr("src", banner.substr(0));
                            $("#shopLink").attr("href", n.ahref);
                        });
                    }
                    else {
                        $("#showShop").hide();
                    }
                }
                else {
                    $("#showShop").hide();
                }
            });
        }


        function funNext() {
            var page = $("#<%=HiddenFieldPage.ClientID %>").val();
            var nextPage = parseInt(page) + 1
            $.get("/Api/Main/Member/GetJson.ashx?type=GetBuyShop&page=" + nextPage + "", null, function (data) {
                if (data != "[object XMLDocument]" && data != "") {
                    $("#<%=HiddenFieldPage.ClientID %>").val(nextPage);
                    funAll(nextPage);
                }
                else {
                    alert("已经是最后一页！");
                }
            })



        }

        function funShang() {
            var page = $("#<%=HiddenFieldPage.ClientID %>").val();
            if (page > 1) {
                var nextPage = parseInt(page) - 1
                funAll(nextPage);
                $("#<%=HiddenFieldPage.ClientID %>").val(nextPage);
            }
            else {
                alert("已经是首页了！");
            }

        }



        function funAllProduct(val) {
            $.get("/Api/Main/Member/GetJson.ashx?type=GetBuyShopProduct&shop=" + val + "", null, function (data) {
                if (data != "") {
                    if (data != "[object XMLDocument]" && data != "") {
                        var vdata = eval('(' + data + ')');
                        var Str = "";
                        $.each(vdata, function (m, n) {
                            Str += "<dl class=\"chainxh scdp\"><dt><a target=\"_blank\" href=\"" + n.ahref + "\"><img src=\"" + n.originalimage + "\" onerror=\"javascript:this.src='/ImgUpload/noImg.jpg'\"    width=\"80\" height=\"80\" /></a></dt><dd class='cdd'><a  target=\"_blank\"   href=\"" + n.ahref + "\">" + n.name + "</a></dd><dd  class='cdd'><strong class=\"red\"  style='clear:both;width:70px;'><div style='clear:both'></div>￥" + n.shopprice + "<div style='clear:both'></div></strong><div style='clear:both'></div></dd><div style='clear:both'></div></dl>";
                        });
                        $("#showShopProduct").html(Str + "<div style='clear:both'></div>");
                    }
                }
                else {
                    $("#showShop").hide();
                }

            });
        }
    
    
    </script>
    <%--   <div class="nrright">
     <%--   <div class="paihang">
            <h1>
                推荐商品&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="/ProductListPromotion.aspx?code=-1&IsshopRecommend=1"
                    target="_blank">更多</a></h1>
            <div>
                <asp:Repeater ID="RepeaterShowCai" runat="server">
                    <ItemTemplate>
                        <dl class="chainxh">
                            <dt><a target="_blank" href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                                <img src='<%#Eval("OriginalImage") %>' width="80" height="80" onerror="javascript:this.src='/ImgUpload/noImg.jpg'" /></a></dt>
                            <dd>
                                <a target="_blank" href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                                    <%#Utils.GetUnicodeSubString(Eval("Name").ToString(), 23, "")%></a></dd>
                            <dd>
                                <strong class="red">￥<%#Eval("ShopPrice") %></strong></dd>
                        </dl>
                    </ItemTemplate>
                </asp:Repeater>
                <%if (RepeaterShowCai.Items.Count == 0)
                  { %>
                <dd>
                    暂无数据</dd>
                <% }%>
            </div>
        </div>--%>
    <%--  <div style="float: left;">
            <a href="#">
                <img src="images/xiaoadv.jpg" width="181" height="81" />
            </a>
        </div>--%>
</div>
</div>
<div style="position: fixed; left: 0; top: 0; width: 100%; height: 100%; z-index: 9999;
    display: none;" id="qiandao">
    <div style="display: block;" class="sp_overlay">
    </div>
    <div style="width: 400px; position: relative; z-index: 1000; margin: 150px auto 10px;
        background: #c5c5c5; border-radius: 3px 3px 3px 3px; padding: 3px;">
        <div style="background: #ffffff;">
            <div class="ch_title">
                <div class="pop_title_left" style="font-size: 13px; color: #464646; float: left;">
                    提示信息
                </div>
                <div class="pop_title_right" style="float: right;">
                    <a class="sp_close" onclick="funHideDiv()">关闭 </a>
                </div>
            </div>
            <div class="qd_success">
                <div class="qd_succes">
                    <h1>
                        <span id="showjfTitle"></span>
                    </h1>
                    <h2>
                        <span id="showjf"></span>
                    </h2>
                </div>
                <div style="padding: 10px 0 0;">
                    <a class="baocbtn" onclick="funHideDiv()" style="display: block; margin: 0 auto;
                        color: #ffffff;">确定</a></div>
            </div>
        </div>
    </div>
</div>
