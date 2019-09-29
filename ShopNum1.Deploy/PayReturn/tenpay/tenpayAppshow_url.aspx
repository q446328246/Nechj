<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="tenpayAppshow_url.aspx.cs"
    Inherits="ShopNum1.Deploy.PayReturn.tenpayAppshow_url" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>财付通支付成功</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link type="text/css" rel="Stylesheet" href="style/index.css" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <div class="all_head" style="_text-align: center;">
        <div class="all_tops">
            <div class="all_top">
                <div class="all_top_right fr">
                    <ul>
                        <li><a href="#">添加收藏</a> </li>
                        <li><a href="#">帮助中心</a> </li>
                        <li><a href="#">我的商城</a> </li>
                        <li class="cart"><a href="#">购物车<span style="color: #ffffff; font-weight: bold;">0</span>件</a>
                        </li>
                    </ul>
                </div>
                <div class="login fr">
                    欢迎光临！<span><%= strUser %></span>， 您可以登录<a href="/index.html">【个人中心】</a> <a href="/loginOut.aspx">
                        【退出】</a>
                </div>
            </div>
        </div>
        <div class="clearfix">
        </div>
        <div class="skin_width">
            <div class="all_logo fl">
                <a href="#">
                    <img src="Images/logo.jpg" /></a>
            </div>
            <div class="mallSearch fr">
                <div class="FormBox">
                    <div class="mallSearch_input clearfix">
                        <input type="text" class="search_text" id="search_text" />
                        <input type="button" class="search_button" onclick=" searchinf('search_text') " />
                    </div>
                </div>
            </div>
            <script type="text/javascript" language="javascript">
                function searchinf(id) {
                    if (document.getElementById(id).value != "") {
                        window.location.href = "/Search_productlist.aspx?search=" + escape(document.getElementById(id).value) + "&pv=1";
                    }
                }
            </script>
            <div class="clearfix">
            </div>
        </div>
    </div>
    <div style="_text-align: center;">
        <div style="margin: 0 auto; margin-top: 13px; text-align: left; width: 1000px; _zoom: 1;">
            <div class="all_main">
                <div class="all_dingdan">
                    <div class="dd1">
                        <asp:Label ID="LabelTime" runat="server" Text="订单于：00：00 支付成功！"></asp:Label>
                    </div>
                    <div class="dd2">
                        <%= strOrderinfo %>
                    </div>
                    <div class="dd_but">
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <input id="butIndex" type="button" value="回到首页" onclick=" javascript:location.href = '/'; "
                                        class="hdsy" />
                                </td>
                                <td>
                                    <input id="butOrder" type="button" value="回到账户管理" onclick=" javascript:location.href = '/main/account/A_Index.aspx?toaurl=A_AdPayRecharge.aspx?type=1'; "
                                        class="hyzx" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="ad1">
                <a href="#">
                    <img src="Images/ad1.jpg" /></a></div>
        </div>
    </div>
    <div id="footer">
        <div style="clear: both; display: block; overflow: hidden;" class="lmf_all_foot">
            <div style="margin: 0 auto; width: 1000px;">
                <div class="floor_load">
                    <div id="help">
                        <table width="100%" cellspacing="0" cellpadding="0" border="0">
                            <tr>
                                <td>
                                    <dl>
                                        <dt>
                                            <div class="gtotop_title">
                                                特色服务</div>
                                        </dt>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/3949fcbf-1acb-4a4d-a534-028009197354.html">
                                                礼物赠送</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/6747acec-16aa-404c-b50a-1c71c76838c7.html">
                                                延保服务</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/10d64e84-4be2-4fb0-b9d8-73fb53201d4d.html">
                                                价格保护</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/ba54e47c-9931-4232-9acc-a3c4f7e1fd8a.html">
                                                商品拍卖</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/ab27c814-ce16-4cc2-9a10-af9a1674ea60.html">
                                                上门服务</a></dd>
                                    </dl>
                                </td>
                                <td>
                                    <dl>
                                        <dt>
                                            <div class="gtotop_title">
                                                售后服务</div>
                                        </dt>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/8b69efb9-4e0f-4787-93c4-01fc26951c3f.html">
                                                上门维修</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/8301c423-69f6-4804-89a0-68d1e8dc5a4b.html">
                                                联系客服</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/f579713d-3a8e-4511-8133-9eba7502e252.html">
                                                保修换货</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/30d5bd2c-6cce-4590-a480-d942246ee554.html">
                                                延迟发货</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/36655a65-3db0-4f04-a903-e37fceccb7a3.html">
                                                退货说明</a></dd>
                                    </dl>
                                </td>
                                <td>
                                    <dl>
                                        <dt>
                                            <div class="gtotop_title">
                                                支付方式</div>
                                        </dt>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/c80ce511-6ccd-4010-9574-17d3c0bc477e.html">
                                                银行转账</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/8e798030-5e03-4108-81d8-2ddb8ee79433.html">
                                                网银支付</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/35cf16e8-b55a-4e02-b929-6214a892cf8e.html">
                                                公司转账</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/d6e0bc68-5bb2-4c70-954d-eeb6a9c90dd0.html">
                                                邮局汇款</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/5935c140-484d-4c32-b2c8-f1796929ca22.html">
                                                货到付款</a></dd>
                                    </dl>
                                </td>
                                <td>
                                    <dl>
                                        <dt>
                                            <div class="gtotop_title">
                                                配送方式</div>
                                        </dt>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/4b293e5d-3426-40d0-98ad-2a25067d4909.html">
                                                中铁快运</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/33962a74-feeb-4621-a3c5-428da05be881.html">
                                                邮局普包</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/2ee6a1cb-0e24-47c2-b2fb-42eec42bc7a5.html">
                                                快递运输</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/4f65dec6-e9ab-447e-af28-54107b5fa046.html">
                                                申通快递</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/78dc26bb-4d89-428e-ac00-7e076d41d80d.html">
                                                特快专递(EMS)</a></dd>
                                    </dl>
                                </td>
                                <td>
                                    <dl>
                                        <dt>
                                            <div class="gtotop_title">
                                                购物指南</div>
                                        </dt>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/dc52ed6b-b9df-4ce2-afeb-40b8977fbe68.html">
                                                联系客服</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/75b176f9-edd8-4f7d-b0e6-45fa17ee7cae.html">
                                                红包方案</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/7e649e0a-88b9-43e0-bb29-551a3fef3c37.html">
                                                购物流程</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/55f12deb-fdab-4909-8d4a-e7d126a24c64.html">
                                                交易条款</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/627c500b-378d-42c7-b7a1-e8779db3bf8d.html">
                                                系统指引</a></dd>
                                    </dl>
                                </td>
                                <td>
                                    <dl>
                                        <dt>
                                            <div class="gtotop_title">
                                                关于我们</div>
                                        </dt>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/326267b3-354f-47c7-b3fe-196498cadeab.html">
                                                如何申请开店</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/9c7290cc-ebe0-477b-88e1-32bb76a75228.html">
                                                如何管理店铺</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/f41a2101-a258-4729-9123-654ec3bfaddb.html">
                                                查看售出商品</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/6f94039b-62c2-4c6d-8391-909d06e0f88d.html">
                                                法律声明</a></dd>
                                        <dd>
                                            <a target="_blank" href="http://www.t.com/HelpList/4062943f-b9e7-4e9b-8cc6-b6000e86100f.html">
                                                如何发货</a></dd>
                                    </dl>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="copyright">
            <div style="text-align: center;">
                <img src="Images/bottm_10.jpg"></div>
            <span id="DomainCopyright"><span id="DomainCopyright_ctl00_labelButtomInfo">
                <div style="margin: 0px auto; text-align: center;">
                </div>
                <p class="rx">
                    <span>全国订购热线：<span id="FootControl1_DomainCopyright_ctl00_labelNationalOrderHotline">400-691-8851</span></span>
                    <span>7×24小时在线订购</span> <span>客服工作时间：<span id="FootControl1_DomainCopyright_ctl00_labelWorkTime">08:00--23:00</span></span>
                    <span>Email：<span id="FootControl1_DomainCopyright_ctl00_labelCompanyEmail">t2009@hotmail.com</span></span>
                </p>
                <p class="rx">
                    <span><a target="_blank" href="http://www.t.com" id="FootControl1_DomainCopyright_ctl00_HyperLinkUrl">
                        Copyright&reg;<span id="FootControl1_DomainCopyright_ctl00_labelPoweredBy">Powered by
                            ShopNum1[t]</span></a> </span><span><a href="http://www.t.com/"><span
                                id="FootControl1_DomainCopyright_ctl00_labelBottomWebsiteName">唐江国际技术</span></a></span>
                    <span>ALL Rights Reserved</span> <span><a href="http://www.t.com/"><span id="FootControl1_DomainCopyright_ctl00_labelICPNum">
                        ICP证书或ICP备案证书号</span></a></span>
                </p>
            </span></span>
        </div>
    </div>
    </form>
</body>
</html>
