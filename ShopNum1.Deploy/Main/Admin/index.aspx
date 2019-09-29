<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="index.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>国际电子商城-后台管理平台</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script src="js/jquery-1.9.1.js" type="text/javascript"> </script>
    <script src="js/menu.js" type="text/javascript"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
    <script type="text/javascript" language="javascript">
        function reinitIframe() {
            var iframe = document.getElementById("mainFrame");
            try {
                var bHeight = iframe.contentWindow.document.body.scrollHeight;
                var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
                var height = Math.max(bHeight, dHeight);
                iframe.height = height;
            } catch (ex) {
            }
        }

        window.setInterval("reinitIframe()", 10);

        function test() {

            if (!$("#left").is(":hidden")) {
                $("#left").hide();
                $("#mright").addClass('mmhide');
                $("#mright").removeClass('mmshow');
                var _div = document.getElementById("test");
                _div.innerHTML = "显示菜单";

            } else {
                $("#left").show();
                $("#mright").addClass('mmshow');
                $("#mright").removeClass('mmhide');
                var _div = document.getElementById("test");
                _div.innerHTML = "隐藏菜单";
            }
        }
    </script>
    <style type="text/css">
        .mmhide {
            margin-left: 0px;
        }

        .mmshow {
            margin-left: 200px;
        }

        .mright .san {
            background: url(images/xs_.jpg) no-repeat center bottom;
            height: 10px;
            left: 4px;
            position: absolute;
            text-indent: -999em;
            top: 4px;
            width: 8px;
        }

        .mmshow .san {
            background: url(images/xs_.jpg) no-repeat center bottom;
            height: 10px;
            left: 4px;
            position: absolute;
            text-indent: -999em;
            top: 4px;
            width: 8px;
        }

        .mmhide .san {
            background: url(images/yc.jpg) no-repeat center bottom;
            height: 10px;
            left: 2px;
            position: absolute;
            text-indent: -999em;
            top: 2px;
            width: 8px;
        }
    </style>
</head>
<body style="min-width: 1024px;">
    <div class="bodywarp" value="0">
        <div class="mainbody">
            <div class="toparea clearfix">
                <%--                <div class="logoImg">
                    <img src="images/top_logo.gif" width="443" height="64" />
                </div>--%>
                <div class="topnav">
                    <a onclick=" changeIfam('AdminWelcome_List.aspx', this) ">
                        <div class="hy">
                            欢迎页
                        </div>
                    </a><a onclick=" ShowNav() ">
                        <div class="xiangdao">
                            使用向导
                        </div>
                    </a>
                    <%--<a onclick=" changeIfam('Html/AboutShopNum1.htm', this) ">
                        <div class="gy">
                            关于
                        </div>
                    </a>--%><a href="/Default.aspx" target="_blank">
                        <div class="llan">
                            浏览商城
                        </div>
                    </a>
                    <%--                    <a href="http://yizhaoshang.shopnum1.com/auth">
                        <div class="yzs">
                            易招商
                        </div>
                    </a>--%>
                    <a href="LoginExit.aspx" target="_blank">
                        <div class="exit">
                            退出后台
                        </div>
                    </a>
                </div>
            </div>
            <!--头部导航-->
            <div id="nav">
                <div class="c">
                    <div class="l">
                        <div class="r">
                            <ul>
                                <!--KCE项目修改-->
                                <li><span class="v" style="overflow: hidden;"><a id="menuTop1" class="sele" onclick=" changeTab(1, 1, this); changeIfam('RexodMemberLogo.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">NEC项目管理</a></span>
                                    <div class="kind_menu">
                                        <div class="kc">
                                            <%--<a onclick=" changeIfam('AAA_KCE_addZaiBei.aspx');changeTabSub(1, 1, 1, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                                增加债贝</a>--%> <%--<a onclick=" changeIfam('AAA_KCE_addKT.aspx');changeTabSub(1, 2, 1, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                                    增减NEC币种</a> --%>
                                            <a onclick=" changeIfam('RexodMemberLogo.aspx');changeTabSub(1, 1, 1, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">团队设置记录</a>
                                            <a onclick=" changeIfam('TeamList.aspx');changeTabSub(1, 2, 1, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">所有团队</a>

                                            <a onclick=" changeIfam('AAA_KCE_QuerySuperior.aspx');changeTabSub(1, 3, 1, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">查找推荐上级所有</a>
                                            <a onclick=" changeIfam('ReChat.aspx');changeTabSub(1, 4, 1, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">会员推荐图</a>
                                            <a onclick=" changeIfam('MemberShip_List_IsBusiness.aspx');changeTabSub(1, 5, 1, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">商家申请</a>
                                            <a onclick=" changeIfam('Payment_List.aspx', this);  changeTabSub(1, 6, 1, 99, this);javascript:shopnum1.Tool.LoadMask.show(); ">支付方式</a>
                                            <a onclick=" changeIfam('LogisticsCompany_List.aspx'); changeTabSub(1, 7, 1, 99, this);javascript:shopnum1.Tool.LoadMask.show(); ">物流公司</a>
                                            <a onclick=" changeIfam('ShopNum1Region_list.aspx'); changeTabSub(1, 8, 1, 99, this);javascript:shopnum1.Tool.LoadMask.show(); ">地区列表</a>
                                            <a onclick=" changeIfam('ImageCategory_List.aspx'); changeTabSub(1, 9, 1, 99, this);javascript:shopnum1.Tool.LoadMask.show(); ">图片管理</a>
                                            <a onclick=" changeIfam('Third_loginList.aspx'); changeTabSub(1, 10, 1, 99, this);javascript:shopnum1.Tool.LoadMask.show(); ">系统集成</a>

                                        </div>
                                    </div>
                                </li>
                                <li><span class="v" style="overflow: hidden;"><a onclick=" changeTab(2, 2, this); changeIfam('Brand_List.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">商品管理</a></span>
                                    <div class="kind_menu">
                                        <div class="kc">
                                            <a onclick=" changeIfam('Brand_List.aspx'); changeTabSub(2, 1, 2, 8, this);javascript:shopnum1.Tool.LoadMask.show(); ">商品基础设置</a> <a onclick=" changeIfam('Prouduct_List.aspx'); changeTabSub(2, 2, 2, 9, this);javascript:shopnum1.Tool.LoadMask.show(); ">商品管理</a>
                                            <%--  <a onclick="changeIfam('Group_ActivityList.aspx'); changeTabSub(2,2,2,10,this);javascript:shopnum1.Tool.LoadMask.show();">促销管理</a>--%>
                                            <a onclick=" changeIfam('ProuductChecked_List.aspx'); changeTabSub(2, 3, 2, 10, this);javascript:shopnum1.Tool.LoadMask.show(); ">商品信息审核</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(3, 3, this); changeIfam('Order_List.aspx', this); javascript:shopnum1.Tool.LoadMask.show(); ">订单管理</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('Order_List.aspx');changeTabSub(3, 1, 3, 11, this);javascript:shopnum1.Tool.LoadMask.show(); ">订单管理</a>


                                            <a onclick=" changeIfam('#');changeTabSub(3, 2, 3, 12, this); " style="display: none;">退换(货)款</a> <a onclick=" changeIfam('ComplaintsManagement_List.aspx');changeTabSub(3, 3, 3, 13, this);javascript:shopnum1.Tool.LoadMask.show(); ">举报||投诉</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(4, 4, this); changeIfam('Member_List.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">会员管理</a></span>
                                    <div class="kind_menu">
                                        <div class="kc">
                                            <a onclick=" changeIfam('Member_List.aspx'); changeTabSub(4, 1, 4, 14, this);javascript:shopnum1.Tool.LoadMask.show(); ">会员管理</a> <a onclick=" changeIfam('ReceiveMessage_List.aspx'); changeTabSub(4, 2, 4, 15, this);javascript:shopnum1.Tool.LoadMask.show(); ">站内消息</a> <a onclick=" changeIfam('ShopNum1MessageBoard_List.aspx');changeTabSub(4, 3, 4, 16, this);javascript:shopnum1.Tool.LoadMask.show(); ">建议管理</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(5, 5, this); changeIfam('ShopType_List.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">店铺管理</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('ShopType_List.aspx'); changeTabSub(5, 1, 5, 18, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺基础设置</a> <a onclick=" changeIfam('ShopInfoList_Manage.aspx'); changeTabSub(5, 2, 5, 19, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺管理</a> <a onclick=" changeIfam('ShopArticle_List.aspx'); changeTabSub(5, 3, 5, 52, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺文章</a> <a onclick=" changeIfam('ShopVedio_List.aspx'); changeTabSub(5, 4, 5, 53, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺视频</a> <a onclick=" changeIfam('ShopDoMainChecked_List.aspx'); changeTabSub(5, 5, 5, 20, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺信息审核</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="toptest" style="display: none; overflow: hidden;"><span class="v"><a onclick=" changeTab(6, 6, this);  changeIfam('Dept_List.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">系统配置</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('User_List.aspx'); changeTabSub(6, 1, 6, 21, this);javascript:shopnum1.Tool.LoadMask.show(); ">权限管理</a> <a onclick=" changeTabSub(6, 2, 6, 22, this); changeIfam('backupDB.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">数据管理</a> <a onclick=" changeIfam('SensitiveWordsSeting.aspx');changeTabSub(6, 3, 6, 23, this);javascript:shopnum1.Tool.LoadMask.show(); ">敏感字设置</a> <a onclick=" changeIfam('Cache/Global_CacheManage.aspx');changeTabSub(6, 4, 6, 24, this);javascript:shopnum1.Tool.LoadMask.show(); ">网站优化</a>
                                        </div>
                                    </div>
                                </li>


                                <!--young-->
                                <li class="toptest" style="display: none; overflow: hidden;"><span class="v"><a onclick=" changeTab(14,14, this);  changeIfam('userOrderReport.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">生成报表</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('userOrderReport.aspx'); changeTabSub(14, 1,14, 55, this);javascript:shopnum1.Tool.LoadMask.show(); ">报表管理</a>
                                        </div>
                                    </div>
                                </li>


                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(7, 7, this); changeIfam('Email_List.aspx'); javascript:shopnum1.Tool.LoadMask.show(); ">营销推广</a></span>
                                    <div class="kind_menu">
                                        <div class="kc">
                                            <a onclick=" changeIfam('Email_List.aspx'); changeTabSub(7, 1, 7, 26, this);javascript:shopnum1.Tool.LoadMask.show(); ">邮件系统</a> <a onclick=" changeIfam('MMS_List.aspx'); changeTabSub(7, 2, 7, 27, this);javascript:shopnum1.Tool.LoadMask.show(); ">短信系统</a> <a onclick=" changeIfam('SiteMota_List.aspx');changeTabSub(7, 3, 7, 28, this);javascript:shopnum1.Tool.LoadMask.show(); ">搜索引擎优化</a> <a onclick=" changeIfam('SetMap.aspx'); changeTabSub(7, 4, 7, 29, this);javascript:shopnum1.Tool.LoadMask.show(); ">站点地图</a> <a onclick=" changeIfam('SurveyTheme_Manage.aspx'); changeTabSub(7, 5, 7, 30, this);javascript:shopnum1.Tool.LoadMask.show(); ">调查列表</a> <a onclick=" changeIfam('ArticleCategory_List.aspx'); changeTabSub(7, 6, 7, 31, this);javascript:shopnum1.Tool.LoadMask.show(); ">文章管理</a> <a onclick=" changeIfam('VideoCategory_List.aspx'); changeTabSub(7, 7, 7, 32, this);javascript:shopnum1.Tool.LoadMask.show(); ">视频管理</a>
                                            <%--<a style="display: none;" onclick="changeIfam('ShopVedioComment_List.aspx'); changeTabSub(7,7,9,32,this);javascript:shopnum1.Tool.LoadMask.show();">
                                                视频管理</a> --%><a onclick=" changeIfam('AttachMent_list.aspx'); changeTabSub(7, 8, 7, 33, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                                    附件管理</a> <a onclick=" changeIfam('Link_Manage.aspx'); changeTabSub(7, 9, 7, 34, this);javascript:shopnum1.Tool.LoadMask.show(); ">友情链接</a> <a onclick=" changeIfam('SiteSpread.aspx'); changeTabSub(7, 10, 7, 35, this);javascript:shopnum1.Tool.LoadMask.show(); ">网站推广</a> <a onclick=" changeIfam('ShopNum1_ScoreProductCategory_List.aspx'); changeTabSub(7, 11, 7, 36, this);javascript:shopnum1.Tool.LoadMask.show(); ">红包商城</a><a onclick=" changeIfam('Group_ActivityList.aspx'); changeTabSub(7, 12, 7, 37, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                                                    促销管理</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(8, 8, this); changeIfam('AdvancePaymentMemApplyLog_List.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">财务管理</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('AdvancePaymentMemApplyLog_List.aspx');changeTabSub(8, 1, 8, 366, this); javascript:shopnum1.Tool.LoadMask.show(); ">会员充值</a> <a onclick=" changeIfam('AdvancePaymentApplyLog_List.aspx'); changeTabSub(8, 2, 8, 377, this);javascript:shopnum1.Tool.LoadMask.show(); ">提现管理</a> <a onclick=" changeIfam('AdvancePaymentPreTransfer_List.aspx'); changeTabSub(8, 3, 8, 38, this);javascript:shopnum1.Tool.LoadMask.show(); ">转账管理</a>
                                            <%--<a onclick="changeIfam('#');changeTabSub(8,4,8,39,this);javascript:shopnum1.Tool.LoadMask.show();"
                                                        style="display: none;">日结管理</a>--%>
                                            <a onclick=" changeIfam('AdvancePaymentStatistics_List.aspx');changeTabSub(8, 4, 8, 39, this);javascript:shopnum1.Tool.LoadMask.show(); ">金币（BV）管理</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(9, 9, this); changeIfam('ShopNum1_SupplyDemand_List.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">供求系统</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('ShopNum1_SupplyDemand_List.aspx'); changeTabSub(9, 1, 9, 40, this);javascript:shopnum1.Tool.LoadMask.show(); ">供求管理</a> <a onclick=" changeIfam('ShopNum1_SupplyDemandCheck_List.aspx');changeTabSub(9, 2, 9, 54, this);javascript:shopnum1.Tool.LoadMask.show(); ">供求审核</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(10, 10, this); changeIfam('SkinBackup.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">网站装修</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('SkinBackup.aspx'); changeTabSub(10, 1, 10, 42, this);javascript:shopnum1.Tool.LoadMask.show(); ">模板管理</a> <a onclick=" changeIfam('PageAdID_List.aspx'); changeTabSub(10, 2, 10, 43, this);javascript:shopnum1.Tool.LoadMask.show(); ">广告管理</a> <a style="display: none" onclick=" changeIfam('InfoControl_List.aspx'); changeTabSub(10, 3, 10, 44, this);javascript:shopnum1.Tool.LoadMask.show(); ">模块管理</a> <a onclick=" changeIfam('UserDefinedColumn_List.aspx'); changeTabSub(10, 4, 10, 45, this);javascript:shopnum1.Tool.LoadMask.show(); ">栏目列表</a> <a onclick=" changeIfam('Help_List.aspx');changeTabSub(10, 5, 10, 46, this);javascript:shopnum1.Tool.LoadMask.show(); ">帮助管理</a> <a onclick=" changeIfam('Announcement_List.aspx');changeTabSub(10, 6, 10, 47, this);javascript:shopnum1.Tool.LoadMask.show(); ">公告管理</a><a onclick=" changeIfam('KeyWords_Manage.aspx');changeTabSub(10, 7, 10, 100, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                                                        关键字管理</a><a onclick=" changeIfam('MerchantsManage.aspx');changeTabSub(10, 8, 10, 101, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                                                            招商管理</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(11, 11, this); changeIfam('SeeBuyRate.aspx'); javascript:shopnum1.Tool.LoadMask.show(); ">运营统计</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('SellOrder.aspx'); changeTabSub(11, 1, 11, 49, this);javascript:shopnum1.Tool.LoadMask.show(); ">销售统计</a> <a onclick=" changeIfam('ShopClickReport.aspx');changeTabSub(11, 2, 11, 50, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺统计</a> <a onclick=" changeIfam('MemberChartArea.aspx');changeTabSub(11, 3, 11, 51, this);javascript:shopnum1.Tool.LoadMask.show(); ">会员统计</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(12, 12, this); changeIfam('websites_list.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">系统集群</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('websites_list.aspx');changeTabSub(12, 1, 12, 51, this);javascript:shopnum1.Tool.LoadMask.show(); ">站群管理</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(13, 13, this);  changeIfam('User_List.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">系统配置</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('User_List.aspx'); changeTabSub(13, 1, 13, 21, this);javascript:shopnum1.Tool.LoadMask.show(); ">权限管理</a> <a onclick=" changeTabSub(13, 2, 13, 22, this); changeIfam('backupDB.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">数据管理</a> <a onclick=" changeIfam('SensitiveWordsSeting.aspx');changeTabSub(13, 3, 13, 23, this);javascript:shopnum1.Tool.LoadMask.show(); ">敏感字设置</a> <a onclick=" changeIfam('Cache/Global_CacheManage.aspx');changeTabSub(13, 4, 13, 24, this);javascript:shopnum1.Tool.LoadMask.show(); ">网站优化</a>
                                        </div>
                                    </div>
                                </li>

                                <!--young-->
                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(15, 15, this);  changeIfam('userOrderReport.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">生成报表</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('userOrderReport.aspx'); changeTabSub(15, 1, 15, 55, this);javascript:shopnum1.Tool.LoadMask.show(); ">报表管理</a>
                                        </div>
                                    </div>
                                </li>


                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div class="km">
                <div class="kr">
                    <div class="kl">
                    </div>
                </div>
            </div>
            <div class="warp clearfix">
                <!--左边-->
                <div id="left">
                    <%-- <!--网站设置->--%>
                    <div class="box_left" id="box_leftid1">
                        <div class="side-bx side-first side-bx-down" id="box_leftidSub1">
                            <div class="side-bx-title" id="sideleft1" onclick=" LeftExpansion(1, 1, this) ">
                                <h3>NEC增加货币</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <%-- <li><a class="current" onclick=" changeIfam('AAA_KCE_addZaiBei.aspx');LeftSubExpansion(1, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        增加债贝</a></li>--%>
                                    <%--<li><a onclick=" changeIfam('AAA_KCE_addKT.aspx');LeftSubExpansion(1, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        增减NEC币种</a></li>--%>
                                    <%-- <li><a onclick="changeIfam('KeyWords_Manage.aspx');LeftSubExpansion(1,3,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        热门搜索管理</a></li>--%>
                                    <%--<li><a onclick=" changeIfam('SetCategoryScale.aspx');LeftSubExpansion(1, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        分类提成设置</a></li>--%>
                                    <li><a onclick="changeIfam('Team_LeaderShip.aspx');LeftSubExpansion(1,1,this);javascript:shopnum1.Tool.LoadMask.show();">CTC团队领导</a></li>
                                    <li><a onclick=" changeIfam('RexodMemberLogo.aspx');LeftSubExpansion(1, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">团队设置记录</a></li>
                                    <li><a onclick=" changeIfam('TeamList.aspx');LeftSubExpansion(1, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">所有团队</a></li>

                                    <li><a onclick="changeIfam('AAA_KCE_QuerySuperior.aspx');LeftSubExpansion(1,4,this);javascript:shopnum1.Tool.LoadMask.show();">查找推荐上级所有</a></li>
                                    <li><a onclick=" changeIfam('ReChat.aspx', this);LeftSubExpansion(1,5,this);javascript:shopnum1.Tool.LoadMask.show(); ">会员推荐图</a></li>
                                    <li><a onclick=" changeIfam('MemberShip_List_IsBusiness.aspx', this);LeftSubExpansion(1,6,this);javascript:shopnum1.Tool.LoadMask.show(); ">商家申请</a></li>
                                </ul>
                            </div>
                        </div>
                        <%--<div class="side-bx" id="box_leftidSub2">
                            <div class="side-bx-title" id="sideleft2" onclick=" LeftExpansion(1, 2, this) ">
                                <h3>
                                    客服管理</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ServiceOnLineService_ManageShow.aspx');LeftSubExpansion(2, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        客服管理</a></li>
                                    <li><a onclick=" changeIfam('ServiceOnLineService_List.aspx');LeftSubExpansion(2, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        在线客服</a></li>
                                </ul>
                            </div>
                        </div>--%>
                        <%--<div class="side-bx" id="box_leftidSub3">
                            <div class="side-bx-title" onclick=" LeftExpansion(1, 3, this) ">
                                <h3>
                                    支付方式</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Payment_List.aspx');LeftSubExpansion(3, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        平台支付方式</a></li>
                                    <li><a class="current" onclick=" changeIfam('MobilePayment_List.aspx');LeftSubExpansion(3, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        手机支付方式</a></li>
                                    <li><a class="current" onclick=" changeIfam('PaymentType_List.aspx');LeftSubExpansion(3, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        支付类型</a></li>
                                </ul>
                            </div>
                        </div>--%>
                        <%-- <div class="side-bx" id="box_leftidSub4">
                            <div class="side-bx-title" onclick=" LeftExpansion(1, 4, this) ">
                                <h3>
                                    物流公司</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('LogisticsCompany_List.aspx');LeftSubExpansion(4, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        物流公司</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub5">
                            <div class="side-bx-title" onclick=" LeftExpansion(1, 5, this) ">
                                <h3>
                                    地区列表</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ShopNum1Region_list.aspx');;LeftSubExpansion(5, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        地区列表</a></li>
                                </ul>
                            </div>
                        </div>--%>
                        <%-- <div class="side-bx" id="box_leftidSub6">
                            <div class="side-bx-title" onclick=" LeftExpansion(1, 6, this) ">
                                <h3>
                                    图片管理</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ImageCategory_List.aspx');LeftSubExpansion(6, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        图片分类 </a></li>
                                    <li><a onclick=" changeIfam('Image_List.aspx');LeftSubExpansion(6, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        图片列表</a></li>
                                    <li><a onclick=" changeIfam('ServiceSite_ImageSettings.aspx');LeftSubExpansion(6, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        图片水印</a></li>
                                    <li style="display: none;"><a onclick=" changeIfam('ImageSpec_List.aspx');LeftSubExpansion(6, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        图片规格</a></li>
                                </ul>
                            </div>
                        </div>--%>
                        <%--<div class="side-bx" id="box_leftidSub7">
                            <div class="side-bx-title" onclick=" LeftExpansion(1, 7, this) ">
                                <h3 onclick=" ">
                                    系统集成</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Third_loginList.aspx');LeftSubExpansion(7, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        第三方登录集成</a></li>
                                    <li><a onclick=" changeIfam('Discuz_Settings.aspx');LeftSubExpansion(7, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        集成Discuz!NT</a></li>
                                    <li><a onclick=" changeIfam('UCDiscuz_Settings.aspx');LeftSubExpansion(7, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        集成UCenter</a></li>
                                    <li><a onclick=" changeIfam('Tg_Settings.aspx');LeftSubExpansion(7, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        集成团购系统</a></li>
                                    <li><a onclick=" changeIfam('Union_Settings.aspx');LeftSubExpansion(7, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        集成联盟系统</a></li>
                                    <li><a onclick=" changeIfam('TbCategory_Settings.aspx');LeftSubExpansion(7, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        淘宝分类导入参数</a></li>
                                </ul>
                            </div>
                        </div>--%>
                    </div>
                    <%-- <!--商品管理->--%>
                    <div class="box_left" id="box_leftid2" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub8">
                            <div class="side-bx-title" onclick=" LeftExpansion(2, 1, this) ">
                                <h3>商品基础设置</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Brand_List.aspx');LeftSubExpansion(8, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">商品品牌</a></li>
                                    <li><a onclick=" changeIfam('Specification_List.aspx');LeftSubExpansion(8, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">规格管理</a></li>
                                    <li><a onclick=" changeIfam('TbCIDSpecification.aspx');LeftSubExpansion(8, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">淘宝规格导入</a></li>
                                    <li><a onclick=" changeIfam('ShopNum1_ShopProductProp_List.aspx');LeftSubExpansion(8, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">属性管理</a></li>
                                    <li><a onclick=" changeIfam('ShopNum1_ProductCategory_List.aspx');LeftSubExpansion(8, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">商品分类</a></li>
                                    <li><a onclick=" changeIfam('CategoryType.aspx');LeftSubExpansion(8, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">商品类型</a></li>
                                    <%--<li><a onclick="changeIfam('SetCategoryScale.aspx');LeftSubExpansion(8,6,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        分类提成</a></li>--%>
                                    <%--      <li><a onclick="changeIfam('ShopNum1_ScoreProductCategory_List.aspx');LeftSubExpansion(8,7,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        红包商品分类</a></li>--%>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub9">
                            <div class="side-bx-title" id="sideleft9" onclick=" LeftExpansion(2, 2, this) ">
                                <h3>商品管理</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Prouduct_List.aspx');LeftSubExpansion(9, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">商品列表</a></li>
                                    <li><a onclick=" changeIfam('ProuductPanicBuy_List.aspx');LeftSubExpansion(9, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">抢购商品列表</a></li>
                                    <%--     <li><a onclick="changeIfam('ProuductSpellBuy_List.aspx');LeftSubExpansion(9,3,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        团购商品列表</a></li>
                                    --%>
                                    <li><a onclick=" changeIfam('ShopProductComment_List.aspx');LeftSubExpansion(9, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">商品评论列表</a></li>
                                    <li><a onclick=" changeIfam('BTCRecommend.aspx');LeftSubExpansion(9, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">首页推荐BTC商品</a></li>
                                    <%-- <li><a onclick="changeIfam('ProductIntegral_List.aspx');LeftSubExpansion(10,6,this);javascript:shopnum1.Tool.LoadMask.show();">红包商品</a></li>--%>
                                </ul>
                            </div>
                        </div>
                        <%-- <div class="side-bx"  id="box_leftidSub10">
                            <div class="side-bx-title" id="sideleft10" onclick="LeftExpansion(2,3,this)">
                                <h3>促销管理</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick="changeIfam('Group_ActivityList.aspx');LeftSubExpansion(10,1,this);javascript:shopnum1.Tool.LoadMask.show();">团购活动</a></li>
                                    <li><a class="current" onclick="changeIfam('Limit_ActivityList.aspx');LeftSubExpansion(10,2,this);javascript:shopnum1.Tool.LoadMask.show();">限时折扣</a></li>
                                </ul>
                            </div>
                        </div>--%>
                        <div class="side-bx" id="box_leftidSub10">
                            <div class="side-bx-title" id="sideleft10" onclick=" LeftExpansion(2, 3, this) ">
                                <h3>商品信息审核</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ProuductChecked_List.aspx');LeftSubExpansion(10, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">商品信息审核</a></li>
                                    <li><a class="current" onclick=" changeIfam('Prouduct_PanicChecked_List.aspx');LeftSubExpansion(10, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">抢购信息审核</a></li>
                                    <%-- <li><a class="current" onclick="changeIfam('Prouduct_SpellChecked_List.aspx');LeftSubExpansion(11,3,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        团购信息审核</a></li>--%>
                                    <%--                                    <li><a class="current" onclick="changeIfam('ProductIntegralChecked_List.aspx');LeftSubExpansion(10,4,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        红包信息审核</a></li>--%>
                                    <li><a onclick=" changeIfam('ShopProductCommentAudit_List.aspx');LeftSubExpansion(10, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">商品评论审核</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <%--          <!--订单管理->--%>
                    <div class="box_left" id="box_leftid3" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub11">
                            <div class="side-bx-title" onclick=" LeftExpansion(4, 1, this) ">
                                <h3>订单管理</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <li><a onclick=" changeIfam('Order_List.aspx', this); LeftSubExpansion(11, 7, this);javascript:shopnum1.Tool.LoadMask.show(); ">订单列表</a></li>

                                    <li><a onclick=" changeIfam('CTCOrder_List.aspx', this); LeftSubExpansion(11, 8, this);javascript:shopnum1.Tool.LoadMask.show(); ">CTC交易明细</a></li>
                                    <li><a onclick=" changeIfam('LifeOrder_List.aspx', this); LeftSubExpansion(11, 9, this);javascript:shopnum1.Tool.LoadMask.show(); ">生活服务订单列表</a></li>
                                    <li><a onclick=" changeIfam('Order_Refuse.aspx', this); LeftSubExpansion(11, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">被A网拒绝的订单审核</a></li>
                                    <li><a onclick=" changeIfam('Order_Refund_two.aspx', this); LeftSubExpansion(11, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">申请退款的列表</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub12" style="display: none;">
                            <div class="side-bx-title" onclick=" LeftExpansion(3, 2, this) ">
                                <h3>退换(货)款</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('#'); LeftSubExpansion(12, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">退换(货)款</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub13">
                            <div class="side-bx-title" onclick=" LeftExpansion(3, 3, this); ">
                                <h3>举报||投诉</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ComplaintsManagement_List.aspx', this); LeftSubExpansion(13, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">举报管理</a></li>
                                    <li><a onclick=" changeIfam('OrdeComplaints_List.aspx', this); LeftSubExpansion(13, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">投诉管理</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <%--  <!--会员管理->--%>
                    <div class="box_left" id="box_leftid4" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub14">
                            <div class="side-bx-title" onclick=" LeftExpansion(4, 1, this) ">
                                <h3>会员管理</h3>

                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Member_List.aspx', this);LeftSubExpansion(14, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">会员列表</a></li>
                                    <li><a onclick=" changeIfam('MemberRank_List.aspx', this);LeftSubExpansion(14, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">会员等级</a></li>
                                    <li><a onclick=" changeIfam('ShopUserRecommend.aspx', this);LeftSubExpansion(14, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">会员留言</a></li>
                                    <li><a class="current" onclick=" changeIfam('MemberShip_List.aspx', this); LeftSubExpansion(14, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">车辆绑定申请列表 </a></li>
                                    <li><a class="current" onclick=" changeIfam('ChangeScoreLog_List.aspx', this); LeftSubExpansion(14, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">消费红包操作日志 </a></li>
                                    <li><a class="current" onclick=" changeIfam('ChangeRankScoreLog_List.aspx', this); LeftSubExpansion(14, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">等级红包操作日志 </a></li>
                                    <li><a class="current" onclick=" changeIfam('MemberRank_LinkCategory.aspx', this); LeftSubExpansion(14, 7, this);javascript:shopnum1.Tool.LoadMask.show(); ">专区绑定</a></li>
                                    <li><a class="current" onclick=" changeIfam('UpdateCommunity.aspx', this); LeftSubExpansion(14, 8, this);javascript:shopnum1.Tool.LoadMask.show(); ">区代、社区调换</a></li>
                                    <li><a class="current" onclick=" changeIfam('AddMemberLoginID.aspx', this); LeftSubExpansion(14, 9, this);javascript:shopnum1.Tool.LoadMask.show(); ">代注册</a></li>
                                    <li><a class="current" onclick=" changeIfam('AZhuanB_Dv.aspx', this); LeftSubExpansion(14, 10, this);javascript:shopnum1.Tool.LoadMask.show(); ">A客户转B客户（DV）</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub15">
                            <div class="side-bx-title" onclick=" LeftExpansion(4, 2, this) ">
                                <h3>站内消息</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <%--<li><a class="current" onclick="changeIfam('ReceiveMessage_List.aspx',this);LeftSubExpansion(15,1,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        消息收件箱</a></li>--%>
                                    <li><a onclick=" changeIfam('SendMessage_List.aspx', this);LeftSubExpansion(15, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">消息发件箱</a></li>
                                    <li><a onclick=" changeIfam('Message_Operate.aspx', this);LeftSubExpansion(15, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">发送消息</a></li>
                                </ul>
                            </div>
                        </div>
                        <%--   <div class="side-bx side-bx-down">--%>
                        <div class="side-bx" id="box_leftidSub16">
                            <div class="side-bx-title" onclick=" LeftExpansion(4, 3, this) ">
                                <h3>建议管理</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ShopNum1MessageBoard_List.aspx'); LeftSubExpansion(16, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">建议管理</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <%--    <!--店铺管理->--%>
                    <div class="box_left" id="box_leftid5" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub18">
                            <div class="side-bx-title" onclick=" LeftExpansion(5, 1, this); ">
                                <h3>店铺基础设置</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ShopType_List.aspx');LeftSubExpansion(18, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺分类</a></li>
                                    <li><a onclick=" changeIfam('ShopRank_List.aspx'); LeftSubExpansion(18, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺等级列表</a></li>
                                    <li><a onclick=" changeIfam('ShopTemplate_List.aspx'); LeftSubExpansion(18, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺模板列表</a></li>
                                    <!-- <li><a onclick=" changeIfam('CouponType_List.aspx');LeftSubExpansion(18, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        优惠券分类</a></li>-->
                                    <li><a onclick=" changeIfam('ShopReputation_List.aspx');LeftSubExpansion(18, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺信誉列表</a></li>
                                    <li><a onclick=" changeIfam('ShopEnsure_List.aspx'); LeftSubExpansion(18, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺担保列表</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub19">
                            <div class="side-bx-title" onclick=" LeftExpansion(5, 2, this); ">
                                <h3>店铺管理</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ShopInfoList_Manage.aspx'); LeftSubExpansion(19, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺列表</a></li>
                                    <li><a onclick=" changeIfam('ShopEnsureVerify_List.aspx'); LeftSubExpansion(19, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">已申请担保列表</a></li>
                                    <%--<li><a onclick="changeIfam('ShopTemplate_List.aspx',this); LeftSubExpansion(19,2,this);">
                                        店铺模板列表</a></li>
                                    <li><a onclick="changeIfam('ShopEnsureVerify_List.aspx'); LeftSubExpansion(19,3,this);">
                                        店铺担保列表</a></li>--%>
                                    <li><a onclick=" changeIfam('ShopDoMain_List.aspx'); LeftSubExpansion(19, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺域名列表</a></li>
                                    <li><a onclick=" changeIfam('CouponList.aspx'); LeftSubExpansion(19, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺优惠券列表</a></li>
                                    <li><a onclick=" changeIfam('Shop_ImgManage.aspx'); LeftSubExpansion(19, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺图库列表</a></li>
                                    <li style="display: none;"><a class="current" onclick=" changeIfam('DelayWxShop_V82.aspx'); LeftSubExpansion(19, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">过期微信店铺</a></li>
                                    <%-- <li><a onclick="changeIfam('ShopVedio_List.aspx',this); LeftSubExpansion(19,6,this);">
                                        店铺视频列表</a></li>
                                    <li><a onclick="changeIfam('ShopArticle_List.aspx',this); LeftSubExpansion(19,7,this);">
                                        店铺文章列表</a></li>--%>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub52">
                            <div class="side-bx-title" onclick=" LeftExpansion(5, 3, this); ">
                                <h3>店铺文章</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ShopArticle_List.aspx'); LeftSubExpansion(52, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺文章列表</a></li>
                                    <li><a class="current" onclick=" changeIfam('ShopArticleComment_List.aspx'); LeftSubExpansion(52, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺文章评论列表</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub53">
                            <div class="side-bx-title" onclick=" LeftExpansion(5, 4, this); ">
                                <h3>店铺视频</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ShopVedio_List.aspx'); LeftSubExpansion(53, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺视频列表</a></li>
                                    <li><a onclick=" changeIfam('ShopVedioComment_List.aspx'); LeftSubExpansion(53, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺视频评论列表</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub20">
                            <div class="side-bx-title" onclick=" LeftExpansion(5, 5, this); ">
                                <h3>店铺信息审核</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <%--          <li style="display: none;"><a class="current" onclick="changeIfam('ShopInfoList_Audit.aspx',this);  LeftSubExpansion(20,1,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        店铺实名审核列表</a></li>--%>
                                    <li><a class="current" onclick=" changeIfam('ShopDoMainChecked_List.aspx', this);  LeftSubExpansion(20, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺域名审核列表</a></li>
                                    <li><a onclick=" changeIfam('ShopInfoList_Audit.aspx', this);  LeftSubExpansion(20, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺审核列表</a></li>
                                    <li><a onclick=" changeIfam('ShopInfoList_AuditNo.aspx', this);  LeftSubExpansion(20, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺审核未通过列表</a></li>
                                    <%--<li><a onclick="changeIfam('ShopApplyRankChecked_List.aspx',this);  LeftSubExpansion(20,4,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        店铺等级审核列表</a></li>
                                    <li><a onclick="changeIfam('ShopEnsureVerifyChecked_List.aspx',this);  LeftSubExpansion(20,5,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        店铺担保审核列表</a></li>--%>
                                    <li><a onclick=" changeIfam('ShopArticle_Check.aspx', this);  LeftSubExpansion(20, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺文章审核列表</a></li>
                                    <li><a onclick=" changeIfam('CouponList_Audit.aspx', this);  LeftSubExpansion(20, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺优惠券审核列表</a></li>
                                    <%--  <li><a onclick="changeIfam('ShopCategoryAply_Audit.aspx',this);  LeftSubExpansion(20,8,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        店铺申请分类审核列表</a></li>--%>
                                    <li><a onclick=" changeIfam('ShopArticleCommentAudit_List.aspx'); LeftSubExpansion(20, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺文章评论审核</a></li>
                                    <li><a onclick=" changeIfam('ShopVedioChecked_List.aspx'); LeftSubExpansion(20, 7, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺视频审核</a></li>
                                    <li><a onclick=" changeIfam('ShopVedioCommentChecked_List.aspx'); LeftSubExpansion(20, 8, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺视频评论审核</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <%-- --营销推广---%>
                    <div class="box_left" id="box_leftid7" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub26">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 1, this); ">
                                <h3>邮件系统</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <%--                                    <li style="display:none"><a onclick="changeIfam('EmailBookType_List.aspx'); LeftSubExpansion(26,1,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        邮件订阅类型</a></li>
                                    <li style="display:none"><a onclick="changeIfam('EmailBook_List.aspx'); LeftSubExpansion(26,2,this);javascript:shopnum1.Tool.LoadMask.show();">邮件订阅</a></li>
                                    <li style="display:none"><a onclick="changeIfam('EmailType_List.aspx'); LeftSubExpansion(26,3,this);javascript:shopnum1.Tool.LoadMask.show();">邮件分类</a></li>--%>
                                    <li><a class="current" onclick=" changeIfam('Email_List.aspx'); LeftSubExpansion(26, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">邮件模板</a></li>
                                    <li><a onclick=" changeIfam('ServiceSite_EmailSetting.aspx'); LeftSubExpansion(26, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">邮件接口设置</a></li>
                                    <li><a onclick=" changeIfam('EmailMemberGroup_List.aspx'); LeftSubExpansion(27, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">会员组管理</a></li>
                                    <li><a onclick=" changeIfam('EmailGropSend_Operate.aspx'); LeftSubExpansion(26, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">邮件群发</a></li>
                                    <li><a onclick=" changeIfam('EmailGroupSend_List.aspx'); LeftSubExpansion(26, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">邮件发送历史</a></li>
                                    <li><a onclick=" changeIfam('Service_EmailSendSetting.aspx'); LeftSubExpansion(26, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">邮件发送设置</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub27">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 2, this); ">
                                <h3>短信系统</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <%--                                    <li style="display:none"><a  onclick="changeIfam('MMSType_List.aspx'); LeftSubExpansion(27,1,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        短信分类列表</a></li>--%>
                                    <li><a class="current" onclick=" changeIfam('MMS_List.aspx'); LeftSubExpansion(27, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">短信模板</a></li>
                                    <li><a onclick=" changeIfam('MMSMemberGroup_List.aspx'); LeftSubExpansion(27, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">会员组管理</a></li>
                                    <li><a onclick=" changeIfam('MMSGroupSend_Operate.aspx'); LeftSubExpansion(27, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">短信群发</a></li>
                                    <li><a onclick=" changeIfam('MMSGroupSend_List.aspx'); LeftSubExpansion(27, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">短信发送历史</a></li>
                                    <li><a onclick=" changeIfam('MMSInterface_Operate.aspx'); LeftSubExpansion(27, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">短信接口设置</a></li>
                                    <li><a onclick=" changeIfam('Service_MMSSendSetting.aspx'); LeftSubExpansion(27, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">短信发送设置</a></li>
                                </ul>
                            </div>
                        </div>
                        <%--   <div class="side-bx side-bx-down">--%>
                        <div class="side-bx" id="box_leftidSub28">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 3, this); ">
                                <h3>搜索引擎优化</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('SiteMota_List.aspx', this); LeftSubExpansion(28, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">SEO设置</a></li>
                                </ul>
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Robots_List.aspx', this); LeftSubExpansion(28, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">Robots设置</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub29">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 4, this); ">
                                <h3>站点地图</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('SetMap.aspx', this); LeftSubExpansion(29, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">站点地图</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub30">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 5, this); ">
                                <h3>调查列表</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('SurveyTheme_Manage.aspx', this); LeftSubExpansion(30, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">调查列表</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub31">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 6, this); ">
                                <h3>文章管理</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ArticleCategory_List.aspx', this); LeftSubExpansion(31, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">平台文章分类</a></li>
                                    <li><a onclick=" changeIfam('Article_List.aspx', this); LeftSubExpansion(31, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">平台文章列表</a></li>
                                    <li><a onclick=" changeIfam('ArticleComment_List.aspx', this); LeftSubExpansion(33, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">平台文章评论列表</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub32">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 7, this); ">
                                <h3>视频管理</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <%--<li><a class="current" onclick="changeIfam('ShopVedio_List.aspx',this); LeftSubExpansion(32,1,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        前台分类</a></li>
                                    <li><a class="current" onclick="changeIfam('ShopVedio_List.aspx',this); LeftSubExpansion(32,1,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        前台视频列表</a></li>
                                    <li><a onclick="changeIfam('ShopVedioComment_List.aspx',this); LeftSubExpansion(32,2,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        前台视频评论</a></li>--%>
                                    <li><a class="current" onclick=" changeIfam('VideoCategory_List.aspx'); LeftSubExpansion(53, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">视频分类</a></li>
                                    <li><a class="current" onclick=" changeIfam('Video_List.aspx'); LeftSubExpansion(53, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">视频列表</a></li>
                                    <li><a onclick=" changeIfam('VideoComment_List.aspx'); LeftSubExpansion(53, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">视频评论列表</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub33">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 8, this); ">
                                <h3>附件管理</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a onclick=" changeIfam('AttachMent_list.aspx'); LeftSubExpansion(33, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">附件列表</a></li>
                                    <li><a class="current" onclick=" changeIfam('AttachMentCateGory_List.aspx'); LeftSubExpansion(33, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">附件分类</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub34">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 9, this); ">
                                <h3>友情链接</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Link_Manage.aspx', this); LeftSubExpansion(34, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">友情链接</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub35">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 10, this); ">
                                <h3>网站推广</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('SiteSpread.aspx'); LeftSubExpansion(35, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">网站推广</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub36">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 11, this); ">
                                <h3>红包商城</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ShopNum1_ScoreProductCategory_List.aspx'); LeftSubExpansion(36, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">红包商品分类</a></li>
                                    <li><a class="current" onclick=" changeIfam('ProductIntegral_List.aspx'); LeftSubExpansion(36, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">红包商品列表</a></li>
                                    <li><a onclick=" changeIfam('OrderScore_List.aspx', this); LeftSubExpansion(36, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">红包订单列表</a></li>
                                    <li><a onclick=" changeIfam('ProductIntegralChecked_List.aspx');LeftSubExpansion(36, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">红包商品审核</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub37">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 12, this); ">
                                <h3>促销活动</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Group_ActivityList.aspx');LeftSubExpansion(37, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">团购活动</a></li>
                                    <li><a class="current" onclick=" changeIfam('Limit_ActivityList.aspx');LeftSubExpansion(37, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺限时折扣</a></li>
                                    <li><a onclick=" changeIfam('Theme_ActivityList.aspx');LeftSubExpansion(37, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">主题活动</a></li>
                                    <li><a onclick=" changeIfam('ZtcGoods_List.aspx');LeftSubExpansion(37, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">直通车商品列表</a></li>
                                    <li><a onclick=" changeIfam('ShopZtcApplyAudit_List.aspx');LeftSubExpansion(37, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">直通车审核</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <%----财务管理--%>
                    <div class="box_left" id="box_leftid8" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub366">
                            <div class="side-bx-title" onclick=" LeftExpansion(8, 1, this); ">
                                <h3>会员充值</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('AdvancePaymentMemApplyLog_List.aspx'); LeftSubExpansion(366, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">会员充值</a></li>
                                    <li><a class="current" onclick=" changeIfam('AdvancePaymentApplyLog_ListETH_Cz.aspx'); LeftSubExpansion(367, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">会员ETH充值</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub377">
                            <div class="side-bx-title" onclick=" LeftExpansion(8, 2, this); ">
                                <h3>提现管理</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('AdvancePaymentApplyLog_List.aspx', this); LeftSubExpansion(377, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">提现ETH币管理</a></li>
                                    <li><a class="current" onclick=" changeIfam('AAA_KCE_addCaiWuTx.aspx', this); LeftSubExpansion(378, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">财务ETH币提现</a></li>
                                    <li><a class="current" onclick=" changeIfam('AAA_KCE_AdvancePaymentApplyLog_ListNEC.aspx', this); LeftSubExpansion(379, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">提现NEC币管理</a></li>
                                    <li><a class="current" onclick=" changeIfam('AAA_KCE_addCaiWuTxNEC.aspx', this); LeftSubExpansion(380, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">财务NEC币提现</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub38">
                            <div class="side-bx-title" onclick=" LeftExpansion(8, 3, this); ">
                                <h3>转账管理</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('AdvancePaymentPreTransfer_List.aspx', this); LeftSubExpansion(38, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">会员转账列表</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub39">
                            <div class="side-bx-title" onclick=" LeftExpansion(8, 4, this) ">
                                <h3>账户管理</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('AdvancePaymentStatistics_List.aspx', this); LeftSubExpansion(39, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">兑换额（PV）统计列表 </a></li>
                                    <li><a class="current" onclick=" changeIfam('ChangeAdvancePaymentLog_List.aspx', this); LeftSubExpansion(39, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">（NEC币种）变更日志 </a></li>
                                    <li><a class="current" onclick=" changeIfam('FreezeAdvancePaymentLog_List.aspx', this); LeftSubExpansion(39, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">（NEC币种）解/冻日志</a></li>
                                    <li id="a_Select_Money_All" runat="server" style="display: none;"><a class="current" onclick=" changeIfam('Select_Money_All.aspx', this); LeftSubExpansion(39, 8, this);javascript:shopnum1.Tool.LoadMask.show(); ">admin每日资金统计</a></li>
                                    <li id="a_NewBlackList" runat="server" style="display: none;"><a class="current" onclick=" changeIfam('NewBlackList.aspx', this); LeftSubExpansion(39, 10, this);javascript:shopnum1.Tool.LoadMask.show();">黑名单管理</a></li>
                                    <li id="a_NewSelect_Money_All" runat="server"><a class="current" onclick=" changeIfam('NewSelect_Money_All.aspx', this);LeftSubExpansion(39, 11, this);javascript:shopnum1.Tool.LoadMask.show(); ">每日资金统计</a></li>
                                </ul>
                            </div>
                        </div>

                        <div class="side-bx" id="Div1">
                            <div class="side-bx-title" onclick=" LeftExpansion(8, 5, this) ">
                                <h3>结算审核(DV)</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('AdvanceSettlementApplyLog.aspx', this); LeftSubExpansion(39, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">结算审核(DV) </a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <!--供求系统-->
                    <div class="box_left" id="box_leftid9" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub40">
                            <div class="side-bx-title" onclick=" LeftExpansion(9, 1, this) ">
                                <h3>供求管理</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <li><a onclick=" changeIfam('ShopNum1_SupplyDemand_List.aspx'); LeftSubExpansion(40, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">供求信息</a></li>
                                    <li><a onclick=" changeIfam('ShopNum1_SupplyDemandCategory_List.aspx'); LeftSubExpansion(40, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">供求分类</a></li>
                                    <li><a onclick=" changeIfam('SupplyDemandComment_List.aspx'); LeftSubExpansion(40, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">供求评论列表</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx side-first" id="box_leftidSub54">
                            <div class="side-bx-title" onclick=" LeftExpansion(9, 2, this) ">
                                <h3>供求审核</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <li><a onclick=" changeIfam('ShopNum1_SupplyDemandCheck_List.aspx'); LeftSubExpansion(54, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">供求信息审核</a></li>
                                    <li><a onclick=" changeIfam('SupplyDemandCommentAudit_List.aspx'); LeftSubExpansion(54, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">供求评论审核</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <!--网站装修-->
                    <div class="box_left" id="box_leftid10" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub42">
                            <div class="side-bx-title" onclick=" LeftExpansion(10, 1, this) ">
                                <h3>模板管理</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('SkinBackup.aspx', this);  LeftSubExpansion(42, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">模板备份</a></li>
                                    <li><a onclick=" changeIfam('SkinSelect.aspx', this);  LeftSubExpansion(42, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">模板选择</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub43">
                            <div class="side-bx-title" onclick=" LeftExpansion(10, 2, this) ">
                                <h3>广告管理</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <%--<li><a class="current" onclick="changeIfam('CategoryAdID_List.aspx',this);  LeftSubExpansion(43,1,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        分类广告位列表</a></li>--%>
                                    <%-- <li><a onclick="changeIfam('CategoryAdvertisement_List.aspx',this);  LeftSubExpansion(43,2,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        分类广告列表</a></li>
                                    <li><a onclick="changeIfam('CategoryAdBuy_List.aspx',this);  LeftSubExpansion(43,3,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        会员购买广告列表</a></li>
                                    <li><a onclick="changeIfam('PageInfo_List.aspx',this);  LeftSubExpansion(43,4,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        手动生成广告位列表</a></li>--%>
                                    <li><a onclick=" changeIfam('PageAdID_List.aspx', this);  LeftSubExpansion(43, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">广告位列表</a></li>
                                    <li><a onclick=" changeIfam('Advertisement_List.aspx', this);  LeftSubExpansion(43, 7, this);javascript:shopnum1.Tool.LoadMask.show(); ">广告列表</a></li>
                                    <li><a onclick=" changeIfam('AdvertisementImg_List.aspx', this);  LeftSubExpansion(43, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">图片广告列表</a></li>
                                    <%--<li><a onclick="changeIfam('DefaultAd_List.aspx',this);  LeftSubExpansion(43,8,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        首页幻灯片</a></li>--%>
                                </ul>
                            </div>
                        </div>
                        <%--   <div class="side-bx side-bx-down">--%>
                        <div class="side-bx" id="box_leftidSub44" style="display: none;">
                            <div class="side-bx-title" onclick=" LeftExpansion(10, 3, this) ">
                                <h3>模块管理</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('InfoControl_List.aspx', this);  LeftSubExpansion(44, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">模块列表</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub45">
                            <div class="side-bx-title" onclick=" LeftExpansion(10, 4, this) ">
                                <h3>栏目列表</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('UserDefinedColumn_List.aspx');  LeftSubExpansion(45, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">栏目列表</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub46">
                            <div class="side-bx-title" onclick=" LeftExpansion(10, 5, this) ">
                                <h3>帮助管理</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Help_List.aspx', this);  LeftSubExpansion(46, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">帮助列表</a></li>
                                    <li><a onclick=" changeIfam('HelpType_List.aspx', this);  LeftSubExpansion(46, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">帮助分类</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub47">
                            <div class="side-bx-title" onclick=" LeftExpansion(10, 6, this) ">
                                <h3>公告管理</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Announcement_List.aspx', this);  LeftSubExpansion(47, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">公告列表</a></li>
                                    <li><a onclick=" changeIfam('AnnouncementCategory_List.aspx', this);  LeftSubExpansion(47, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">公告分类</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub100">
                            <div class="side-bx-title" onclick=" LeftExpansion(10, 7, this) ">
                                <h3>关键字管理</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a onclick=" changeIfam('KeyWords_Manage.aspx');LeftSubExpansion(100, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">关键字列表</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub101">
                            <div class="side-bx-title" onclick=" LeftExpansion(10, 8, this) ">
                                <h3>招商管理</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('MerchantsManage.aspx', this);  LeftSubExpansion(101, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">招商管理</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <%--  <!--运营统计->--%>
                    <div class="box_left" id="box_leftid11" style="display: none">
                        <%-- <div class="side-bx side-first" id="box_leftidSub48" style="display: none">
                            <div class="side-bx-title" onclick="LeftExpansion(11,1,this)" style="display: none">
                                <h3>
                                    访问统计</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                   店铺访问量排行
                                    <li><a class="current" onclick="changeIfam('ShopClickReport.aspx');  LeftSubExpansion(48,1,this);javascript:shopnum1.Tool.LoadMask.show();"
                                        style="display: none">访问统计</a></li>
                                </ul>
                            </div>
                        </div>--%>
                        <div class="side-bx" id="box_leftidSub49">
                            <div class="side-bx-title" onclick=" LeftExpansion(11, 1, this) ">
                                <h3>销售统计</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('SeeBuyRate.aspx', this);  LeftSubExpansion(49, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">访问购买率报表</a></li>
                                    <li><a onclick=" changeIfam('SellOrder.aspx', this);  LeftSubExpansion(49, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">商品销售排行报表</a></li>
                                    <li><a onclick=" changeIfam('OrderProductReport.aspx', this);  LeftSubExpansion(49, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">商品销售明细报表</a></li>
                                    <li><a onclick=" changeIfam('PaymentStatistics_List.aspx', this);  LeftSubExpansion(49, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">支付方式统计报表</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub50">
                            <div class="side-bx-title" onclick=" LeftExpansion(11, 2, this) ">
                                <h3>店铺统计</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ShopClickReport.aspx', this);  LeftSubExpansion(50, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺访问排行报表</a></li>
                                    <li><a onclick=" changeIfam('ShopChartArea.aspx', this);  LeftSubExpansion(50, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺区域分布</a></li>
                                    <li><a onclick=" changeIfam('ShopSales.aspx', this);  LeftSubExpansion(50, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺销售额统计</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub51">
                            <div class="side-bx-title" onclick=" LeftExpansion(11, 3, this) ">
                                <h3>会员统计</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('MemberChartArea.aspx', this);  LeftSubExpansion(51, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">会员区域分布图</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <%--  系统配置--%>
                    <div class="box_left" id="box_leftid13" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub21">
                            <div class="side-bx-title" onclick=" LeftExpansion(13, 1, this); ">
                                <h3>权限管理</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <%--       <li style="display:none"><a class="current" onclick="changeIfam('Dept_List.aspx');  LeftSubExpansion(21,1,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        部门列表</a></li>--%>
                                    <li><a class="current" onclick=" changeIfam('User_List.aspx', this);  LeftSubExpansion(21, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">用户管理</a></li>
                                    <li><a onclick=" changeIfam('Group_List.aspx', this);  LeftSubExpansion(21, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">角色组管理</a></li>
                                    <li><a onclick=" changeIfam('OperateLog_Manage.aspx', this);  LeftSubExpansion(21, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">系统操作日志</a></li>
                                    <li><a onclick=" changeIfam('UpdatePassword.aspx', this);  LeftSubExpansion(21, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">修改密码</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub22">
                            <div class="side-bx-title" onclick=" LeftExpansion(13, 2, this); ">
                                <h3>数据管理</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('backupDB.aspx', this);  LeftSubExpansion(22, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">数据备份</a></li>
                                    <li><a onclick=" changeIfam('ClearData.aspx', this);  LeftSubExpansion(22, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">清除体验数据</a></li>
                                </ul>
                            </div>
                        </div>
                        <%--   <div class="side-bx side-bx-down">--%>
                        <div class="side-bx" id="box_leftidSub23">
                            <div class="side-bx-title" onclick=" LeftExpansion(13, 3, this); ">
                                <h3>敏感字设置</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('SensitiveWordsSeting.aspx', this);  LeftSubExpansion(23, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">敏感字设置</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub24">
                            <div class="side-bx-title" onclick=" LeftExpansion(13, 4, this); ">
                                <h3>网站优化</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Cache/Global_CacheManage.aspx', this);  LeftSubExpansion(24, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">更新缓存</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>


                    <!--young-->
                    <%--  生成报表--%>
                    <div class="box_left" id="box_leftid15" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub55">
                            <div class="side-bx-title" onclick=" LeftExpansion(15, 1, this); ">
                                <h3>报表管理</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('userOrderReport.aspx', this);  LeftSubExpansion(55, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">订单报表</a></li>
                                    <li><a class="current" onclick=" changeIfam('storeOrderReport.aspx', this);  LeftSubExpansion(55, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">发货报表</a></li>
                                    <li><a class="current" onclick=" changeIfam('Salesofinventory.aspx', this);  LeftSubExpansion(55, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">销量报表</a></li>
                                </ul>
                            </div>

                        </div>
                    </div>




                    <%--   <!--系统集群->--%>
                    <div class="box_left" id="box_leftid12" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub51">
                            <div class="side-bx-title" onclick=" LeftExpansion(12, 1, this) ">
                                <h3>站群管理</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('websites_list.aspx', this); LeftSubExpansion(51, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">站群列表</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <!--右边-->
                <div class="mright" id="mright" style="position: relative;">
                    <div id="test" onclick=" test() " style="color: #555555; cursor: pointer; font-weight: bold; text-align: left;"
                        class="san">
                        隐藏菜单
                    </div>
                    <iframe src="AdminWelcome_List.aspx" width="100%" frameborder="0" scrolling="auto"
                        id="mainFrame" name="win" onload=" this.height =100%" style="overflow-y: hidden;"></iframe>
                </div>
            </div>
            <div class=" warp clearfix" id="1">
            </div>
        </div>
        <div class="foot">
            <p class="copyright">
                Powered by <a href="http://www.T.com/" target="_blank"></a>Copyright (C) 2010-2014,
                All Rights Reserved
            </p>
        </div>
    </div>
    <!--头部大标题 选中的第几项-->
    <input id="HiddenFieldTop" type="hidden" value="1" name="HiddenFieldTop" />
    <!--头部小标题 选中的第几项-->
    <input id="HiddenTopSub" type="hidden" value="1" name="HiddenTopSub" />
    <!--左边大标题 选中的第几项-->
    <input id="HiddenLeft" type="hidden" value="1" name="HiddenTopSub" />
    <!--左边小标题 选中的第几项-->
    <input id="HiddenLeftSub" type="hidden" value="1" name="HiddenTopSub" />
    <div class="SiteNav" style="display: none;">
        <div class="SiteNavCon">
            <div class="title clearfix">
                <span class="fl"></span><a href="javascript:;" class="fr"></a>
            </div>
            <div class="con">
                <dl class="item clearfix">
                    <dt><b>网站设置</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>基本设置</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('ServiceSite_Settings.aspx');LeftSubExpansion(1, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">站点管理</a></li>
                            <li><a onclick=" changeIfam('ServiceSite_BasicSettings.aspx');LeftSubExpansion(1, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">基本设置</a></li>
                            <li><a onclick=" changeIfam('SetCategoryScale.aspx');LeftSubExpansion(1, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">分类提成设置</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>客服管理</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ServiceOnLineService_ManageShow.aspx');LeftSubExpansion(2, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">客服管理</a></li>
                            <li><a onclick=" changeIfam('ServiceOnLineService_List.aspx');LeftSubExpansion(2, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">在线客服</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>支付方式</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('Payment_List.aspx');LeftSubExpansion(3, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">平台支付方式</a></li>
                            <li><a class="current" onclick=" changeIfam('MobilePayment_List.aspx');LeftSubExpansion(3, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">手机支付方式</a></li>
                            <li><a class="current" onclick=" changeIfam('PaymentType_List.aspx');LeftSubExpansion(3, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">支付类型</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>物流公司</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('LogisticsCompany_List.aspx');LeftSubExpansion(4, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">物流公司</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>地区列表</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ShopNum1Region_list.aspx');;LeftSubExpansion(5, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">地区列表</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>图片管理</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('ImageCategory_List.aspx');LeftSubExpansion(6, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">图片分类 </a></li>
                            <li><a onclick=" changeIfam('Image_List.aspx');LeftSubExpansion(6, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">图片列表</a></li>
                            <li><a onclick=" changeIfam('ServiceSite_ImageSettings.aspx');LeftSubExpansion(6, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">图片水印</a></li>
                            <li><a onclick=" changeIfam('ImageSpec_List.aspx');LeftSubExpansion(6, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">图片规格</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>系统集成</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('Third_loginList.aspx');LeftSubExpansion(7, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">第三方登录集成</a></li>
                            <li><a onclick=" changeIfam('Discuz_Settings.aspx');LeftSubExpansion(7, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">集成Discuz!NT</a></li>
                            <li><a onclick=" changeIfam('UCDiscuz_Settings.aspx');LeftSubExpansion(7, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">集成UCenter</a></li>
                            <li><a onclick=" changeIfam('Tg_Settings.aspx');LeftSubExpansion(7, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">集成团购系统</a></li>
                            <li><a onclick=" changeIfam('Union_Settings.aspx');LeftSubExpansion(7, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">集成联盟系统</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>商品管理</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>商品基础设置</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('Brand_List.aspx');LeftSubExpansion(8, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">商品品牌</a></li>
                            <li><a onclick=" changeIfam('Specification_List.aspx');LeftSubExpansion(8, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">规格管理</a></li>
                            <li><a onclick=" changeIfam('TbCIDSpecification.aspx');LeftSubExpansion(8, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">淘宝规格导入</a></li>
                            <li><a onclick=" changeIfam('ShopNum1_ShopProductProp_List.aspx');LeftSubExpansion(8, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">属性管理</a></li>
                            <li><a onclick=" changeIfam('ShopNum1_ProductCategory_List.aspx');LeftSubExpansion(8, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">商品分类</a></li>
                            <li><a onclick=" changeIfam('CategoryType.aspx');LeftSubExpansion(8, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">商品类型</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>商品管理</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('Prouduct_List.aspx');LeftSubExpansion(9, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">商品列表</a></li>
                            <li><a onclick=" changeIfam('ProuductPanicBuy_List.aspx');LeftSubExpansion(9, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">抢购商品列表</a></li>
                            <li><a onclick=" changeIfam('ShopProductComment_List.aspx');LeftSubExpansion(9, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">商品评论列表</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>商品信息审核</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ProuductChecked_List.aspx');LeftSubExpansion(11, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">商品信息审核</a></li>
                            <li><a class="current" onclick=" changeIfam('Prouduct_PanicChecked_List.aspx');LeftSubExpansion(11, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">抢购信息审核</a></li>
                            <li><a onclick=" changeIfam('ShopProductCommentAudit_List.aspx');LeftSubExpansion(11, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">商品评论审核</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>订单管理</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>订单管理</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('Order_List.aspx', this); LeftSubExpansion(11, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">团购订单列表</a></li>
                            <li><a onclick=" changeIfam('OrderPanic_List.aspx', this); LeftSubExpansion(11, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">抢购订单列表</a></li>
                            <li><a onclick=" changeIfam('Order_List.aspx', this); LeftSubExpansion(11, 7, this);javascript:shopnum1.Tool.LoadMask.show(); ">订单列表</a></li>
                            <li><a onclick=" changeIfam('CTCOrder_List.aspx', this); LeftSubExpansion(11, 8, this);javascript:shopnum1.Tool.LoadMask.show(); ">CTC交易明细</a></li>

                            <li><a onclick=" changeIfam('Order_Refuse.aspx', this); LeftSubExpansion(11, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">被A网拒绝的订单审核</a></li>
                            <li><a onclick=" changeIfam('Order_Refund_two.aspx', this); LeftSubExpansion(11, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">申请退款的列表</a></li>
                        </ul>
                    </dd>
                    <dd class="subItem">
                        <a href="javascript:void(0);"><b>举报||投诉</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ComplaintsManagement_List.aspx', this); LeftSubExpansion(13, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">举报管理</a></li>
                            <li><a onclick=" changeIfam('OrdeComplaints_List.aspx', this); LeftSubExpansion(13, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">投诉管理</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>会员管理</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>会员管理</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('Member_List.aspx', this);LeftSubExpansion(14, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">会员列表</a></li>
                            <li><a onclick=" changeIfam('MemberRank_List.aspx', this);LeftSubExpansion(14, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">会员等级</a></li>
                            <li><a class="current" onclick=" changeIfam('MemberShip_List.aspx', this); LeftSubExpansion(14, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">会员等级申请列表 </a></li>
                            <li><a class="current" onclick=" changeIfam('ChangeScoreLog_List.aspx', this); LeftSubExpansion(14, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">消费红包操作日志 </a></li>
                            <li><a class="current" onclick=" changeIfam('ChangeRankScoreLog_List.aspx', this); LeftSubExpansion(14, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">等级红包操作日志 </a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>站内信息</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('SendMessage_List.aspx', this);LeftSubExpansion(15, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">消息发件箱</a></li>
                            <li><a onclick=" changeIfam('Message_Operate.aspx', this);LeftSubExpansion(15, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">发送消息</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>建议管理</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ShopNum1MessageBoard_List.aspx'); LeftSubExpansion(16, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">建议管理</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>店铺管理</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>店铺基础设置</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ShopType_List.aspx');LeftSubExpansion(18, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺分类</a></li>
                            <li><a onclick=" changeIfam('ShopRank_List.aspx'); LeftSubExpansion(18, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺等级列表</a></li>
                            <li><a onclick=" changeIfam('ShopTemplate_List.aspx'); LeftSubExpansion(18, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺模板列表</a></li>
                            <li><a onclick=" changeIfam('CouponType_List.aspx');LeftSubExpansion(18, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">优惠券分类</a></li>
                            <li><a onclick=" changeIfam('ShopReputation_List.aspx');LeftSubExpansion(18, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺信誉列表</a></li>
                            <li><a onclick=" changeIfam('ShopEnsure_List.aspx'); LeftSubExpansion(18, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺担保列表</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>店铺管理</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ShopInfoList_Manage.aspx'); LeftSubExpansion(19, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺列表</a></li>
                            <li><a onclick=" changeIfam('ShopEnsureVerify_List.aspx'); LeftSubExpansion(19, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">已申请担保列表</a></li>
                            <li><a onclick=" changeIfam('ShopDoMain_List.aspx'); LeftSubExpansion(19, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺域名列表</a></li>
                            <li><a onclick=" changeIfam('CouponList.aspx'); LeftSubExpansion(19, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺优惠券列表</a></li>
                            <li><a onclick=" changeIfam('Shop_ImgManage.aspx'); LeftSubExpansion(19, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺图库列表</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>店铺文章</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ShopArticle_List.aspx'); LeftSubExpansion(52, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺文章列表</a></li>
                            <li><a class="current" onclick=" changeIfam('ShopArticleComment_List.aspx'); LeftSubExpansion(52, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺文章评论列表</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>店铺视频</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ShopVedio_List.aspx'); LeftSubExpansion(53, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺视频列表</a></li>
                            <li><a onclick=" changeIfam('ShopVedioComment_List.aspx'); LeftSubExpansion(53, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺视频评论列表</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>店铺信息审核</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ShopDoMainChecked_List.aspx', this);  LeftSubExpansion(20, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺域名审核列表</a></li>
                            <li><a onclick=" changeIfam('ShopInfoList_Audit.aspx', this);  LeftSubExpansion(20, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺审核列表</a></li>
                            <li><a onclick=" changeIfam('ShopInfoList_AuditNo.aspx', this);  LeftSubExpansion(20, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺审核未通过列表</a></li>
                            <li><a onclick=" changeIfam('ShopArticle_Check.aspx', this);  LeftSubExpansion(20, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺文章审核列表</a></li>
                            <li><a onclick=" changeIfam('CouponList_Audit.aspx', this);  LeftSubExpansion(20, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺优惠券审核列表</a></li>
                            <li><a onclick=" changeIfam('ShopArticleCommentAudit_List.aspx'); LeftSubExpansion(20, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺文章评论审核</a></li>
                            <li><a onclick=" changeIfam('ShopVedioChecked_List.aspx'); LeftSubExpansion(20, 7, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺视频审核</a></li>
                            <li><a onclick=" changeIfam('ShopVedioCommentChecked_List.aspx'); LeftSubExpansion(20, 8, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺视频评论审核</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>营销推广</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>邮件系统</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('Email_List.aspx'); LeftSubExpansion(26, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">邮件模板</a></li>
                            <li><a onclick=" changeIfam('ServiceSite_EmailSetting.aspx'); LeftSubExpansion(26, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">邮件接口设置</a></li>
                            <li><a onclick=" changeIfam('EmailMemberGroup_List.aspx'); LeftSubExpansion(27, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">会员组管理</a></li>
                            <li><a onclick=" changeIfam('EmailGropSend_Operate.aspx'); LeftSubExpansion(26, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">邮件群发</a></li>
                            <li><a onclick=" changeIfam('EmailGroupSend_List.aspx'); LeftSubExpansion(26, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">邮件发送历史</a></li>
                            <li><a onclick=" changeIfam('Service_EmailSendSetting.aspx'); LeftSubExpansion(26, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">邮件发送设置</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>短信系统</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('MMS_List.aspx'); LeftSubExpansion(27, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">短信模板</a></li>
                            <li><a onclick=" changeIfam('MMSMemberGroup_List.aspx'); LeftSubExpansion(27, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">会员组管理</a></li>
                            <li><a onclick=" changeIfam('MMSGroupSend_Operate.aspx'); LeftSubExpansion(27, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">短信群发</a></li>
                            <li><a onclick=" changeIfam('MMSGroupSend_List.aspx'); LeftSubExpansion(27, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">短信发送历史</a></li>
                            <li><a onclick=" changeIfam('MMSInterface_Operate.aspx'); LeftSubExpansion(27, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">短信接口设置</a></li>
                            <li><a onclick=" changeIfam('Service_MMSSendSetting.aspx'); LeftSubExpansion(27, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">短信发送设置</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>搜索引擎优化</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('SiteMota_List.aspx', this); LeftSubExpansion(28, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">SEO设置</a></li>
                            <li><a class="current" onclick=" changeIfam('Robots_List.aspx', this); LeftSubExpansion(28, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">Robots设置</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>站点地图</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('SetMap.aspx', this); LeftSubExpansion(29, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">站点地图</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>调查列表</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('SurveyTheme_Manage.aspx', this); LeftSubExpansion(30, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">调查列表</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>文章管理</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ArticleCategory_List.aspx', this); LeftSubExpansion(31, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">平台文章分类</a></li>
                            <li><a onclick=" changeIfam('Article_List.aspx', this); LeftSubExpansion(31, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">平台文章列表</a></li>
                            <li><a onclick=" changeIfam('ArticleComment_List.aspx', this); LeftSubExpansion(33, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">平台文章评论列表</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>视频管理</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('VideoCategory_List.aspx'); LeftSubExpansion(53, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">视频分类</a></li>
                            <li><a class="current" onclick=" changeIfam('Video_List.aspx'); LeftSubExpansion(53, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">视频列表</a></li>
                            <li><a onclick=" changeIfam('VideoComment_List.aspx'); LeftSubExpansion(53, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">视频评论列表</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>附件管理</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('AttachMent_list.aspx'); LeftSubExpansion(33, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">附件列表</a></li>
                            <li><a class="current" onclick=" changeIfam('AttachMentCateGory_List.aspx'); LeftSubExpansion(33, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">附件分类</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>友情链接</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('Link_Manage.aspx', this); LeftSubExpansion(34, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">友情链接</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>网站推广</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('SiteSpread.aspx'); LeftSubExpansion(35, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">网站推广</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>红包商城</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ShopNum1_ScoreProductCategory_List.aspx'); LeftSubExpansion(36, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">红包商品分类</a></li>
                            <li><a class="current" onclick=" changeIfam('ProductIntegral_List.aspx'); LeftSubExpansion(36, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">红包商品列表</a></li>
                            <li><a onclick=" changeIfam('OrderScore_List.aspx', this); LeftSubExpansion(36, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">红包订单列表</a></li>
                            <li><a onclick=" changeIfam('ProductIntegralChecked_List.aspx');LeftSubExpansion(36, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">红包商品审核</a></li>
                        </ul>
                    </dd>
                    <dd class="last">
                        <a href="javascript:void(0);"><b>促销活动</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('Group_ActivityList.aspx');LeftSubExpansion(37, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">团购活动</a></li>
                            <li><a onclick=" changeIfam('Limit_ActivityList.aspx');LeftSubExpansion(37, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺限时折扣</a></li>
                            <li><a onclick=" changeIfam('Theme_ActivityList.aspx');LeftSubExpansion(37, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">主题活动</a></li>
                            <li><a onclick=" changeIfam('ZtcGoods_List.aspx');LeftSubExpansion(37, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">直通车商品列表</a></li>
                            <li><a onclick=" changeIfam('ShopZtcApplyAudit_List.aspx');LeftSubExpansion(37, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">直通车审核</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>财务管理</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>会员充值</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('AdvancePaymentMemApplyLog_List.aspx'); LeftSubExpansion(36, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">会员充值</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>提现管理</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('AdvancePaymentApplyLog_List.aspx', this); LeftSubExpansion(37, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">提现管理</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>转账管理</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('AdvancePaymentPreTransfer_List.aspx', this); LeftSubExpansion(38, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">会员转账列表</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>金币（BV）管理</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('AdvancePaymentStatistics_List.aspx', this); LeftSubExpansion(39, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">兑换额（PV）统计列表 </a></li>
                            <li><a class="current" onclick=" changeIfam('ChangeAdvancePaymentLog_List.aspx', this); LeftSubExpansion(39, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">金币（BV）变更日志 </a></li>
                            <li><a class="current" onclick=" changeIfam('FreezeAdvancePaymentLog_List.aspx', this); LeftSubExpansion(39, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">金币（BV）解/冻日志</a></li>
                            <li><a class="current" onclick=" changeIfam('Select_Money_All.aspx', this); LeftSubExpansion(39, 7, this);javascript:shopnum1.Tool.LoadMask.show(); ">每日资金统计</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>供求系统</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>供求管理</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('ShopNum1_SupplyDemand_List.aspx'); LeftSubExpansion(40, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">供求信息</a></li>
                            <li><a onclick=" changeIfam('ShopNum1_SupplyDemandCategory_List.aspx'); LeftSubExpansion(40, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">供求分类</a></li>
                            <li><a onclick=" changeIfam('SupplyDemandComment_List.aspx'); LeftSubExpansion(40, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">供求评论列表</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>供求审核</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('ShopNum1_SupplyDemandCheck_List.aspx'); LeftSubExpansion(54, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">供求信息审核</a></li>
                            <li><a onclick=" changeIfam('SupplyDemandCommentAudit_List.aspx'); LeftSubExpansion(54, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">供求评论审核</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>网站装修</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>模板管理</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('SkinBackup.aspx', this);  LeftSubExpansion(42, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">模板备份</a></li>
                            <li><a onclick=" changeIfam('SkinSelect.aspx', this);  LeftSubExpansion(42, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">模板选择</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>广告管理</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('PageAdID_List.aspx', this);  LeftSubExpansion(43, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">广告位列表</a></li>
                            <li><a onclick=" changeIfam('Advertisement_List.aspx', this);  LeftSubExpansion(43, 7, this);javascript:shopnum1.Tool.LoadMask.show(); ">广告列表</a></li>
                            <li><a onclick=" changeIfam('AdvertisementImg_List.aspx', this);  LeftSubExpansion(43, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">图片广告列表</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>栏目列表</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('UserDefinedColumn_List.aspx');  LeftSubExpansion(45, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">栏目列表</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>帮助管理</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('Help_List.aspx', this);  LeftSubExpansion(46, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">帮助列表</a></li>
                            <li><a onclick=" changeIfam('HelpType_List.aspx', this);  LeftSubExpansion(46, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">帮助分类</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>公告管理</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('Announcement_List.aspx', this);  LeftSubExpansion(47, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">公告列表</a></li>
                            <li><a onclick=" changeIfam('AnnouncementCategory_List.aspx', this);  LeftSubExpansion(47, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">公告分类</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>关键字管理</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('KeyWords_Manage.aspx', this);LeftSubExpansion(487, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">关键字列表</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>招商管理</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('MerchantsManage.aspx', this);  LeftSubExpansion(488, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">招商管理</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>运营统计</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>销售统计</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('SeeBuyRate.aspx', this);  LeftSubExpansion(49, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">访问购买率报表</a></li>
                            <li><a onclick=" changeIfam('SellOrder.aspx', this);  LeftSubExpansion(49, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">商品销售排行报表</a></li>
                            <li><a onclick=" changeIfam('OrderProductReport.aspx', this);  LeftSubExpansion(49, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">商品销售明细报表</a></li>
                            <li><a onclick=" changeIfam('PaymentStatistics_List.aspx', this);  LeftSubExpansion(49, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">支付方式统计报表</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>店铺统计</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('ShopClickReport.aspx', this);  LeftSubExpansion(50, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺访问排行报表</a></li>
                            <li><a onclick=" changeIfam('ShopChartArea.aspx', this);  LeftSubExpansion(50, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺区域分布</a></li>
                            <li><a onclick=" changeIfam('ShopSales.aspx', this);  LeftSubExpansion(50, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">店铺销售额统计</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>会员统计</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('MemberChartArea.aspx', this);  LeftSubExpansion(51, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">会员区域分布图</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>系统集成</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>站群管理</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('websites_list.aspx', this); LeftSubExpansion(51, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">站群列表</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>系统配置</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>权限管理</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('User_List.aspx');  LeftSubExpansion(21, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">用户管理</a></li>
                            <li><a onclick=" changeIfam('Group_List.aspx');  LeftSubExpansion(21, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">角色组管理</a></li>
                            <li><a onclick=" changeIfam('OperateLog_Manage.aspx');  LeftSubExpansion(21, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">系统操作日志</a></li>
                            <li><a onclick=" changeIfam('UpdatePassword.aspx');  LeftSubExpansion(21, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">修改密码</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>数据管理</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('backupDB.aspx', this);  LeftSubExpansion(22, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">数据备份</a></li>
                            <li><a onclick=" changeIfam('ClearData.aspx', this);  LeftSubExpansion(22, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">清除体验数据</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>敏感字设置</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('SensitiveWordsSeting.aspx', this);  LeftSubExpansion(23, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">敏感字设置</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>网站优化</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('Cache/Global_CacheManage.aspx', this);  LeftSubExpansion(24, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">更新缓存</a></li>
                        </ul>
                    </dd>
                </dl>


                <!--young-->
                <dl class="item clearfix">
                    <dt><b>生成报表</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>报表管理</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('userOrderReport.aspx', this);  LeftSubExpansion(55, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">订单报表</a></li>
                            <li><a onclick=" changeIfam('storeOrderReport.aspx', this);  LeftSubExpansion(55, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">发货报表报表</a></li>
                            <li><a class="current" onclick=" changeIfam('Salesofinventory.aspx', this);  LeftSubExpansion(55, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">销量报表</a></li>


                        </ul>

                    </dd>
                </dl>

            </div>
        </div>
    </div>
    <!--透明遮罩层-->
    <div class="mask">
    </div>
    <script type="text/javascript">
        var target = $('.item dd');
        target.hover(function () {
            $(this).children().eq(0).addClass('btn');
            $(this).children().eq(1).css('display', 'block');
        }, function () {
            $(this).children().eq(0).removeClass('btn');
            $(this).children().eq(1).css('display', 'none');
        });
        $('.item').hover(function () {
            $(this).children().eq(0).addClass('btn');
        }, function () {
            $(this).children().eq(0).removeClass('btn');
        });
    </script>
    <script type="text/javascript">
        var site_url = window.location.href.toLowerCase();
        switch (true) {
            default:
                $("#nav li").attr("class", "");
                $("#nav li").eq(0).attr("class", "nav_lishw");
                $(".nav_lishw .kind_menu").show();
        }
        $(".mask").hide();
        //初始化
        $("#HiddenTopSub").val("1");
        $("#HiddenFieldTop").val("1");
        $("#HiddenLeftSub").val("1");
        $("#HiddenLeft").val("1");
        $(".SiteNavCon .fr").click(function () {
            $(".SiteNav").hide();
            $(".mask").hide();
        });
        //头部大标题 滑过事件
        $("#nav li").hover(
            function () {
                //		    $("#nav li").children(".kind_menu").hide();
                if (!$(this).find("span.v>a").hasClass("sele")) {
                    $(this).find("span.v>a").attr("class", "sele_hover"); //当前头部大标题 样式为选中
                }

                //            $(this).children(".kind_menu").show();//当前头部大标题 下面的小标题 显示
            },
            function () {
                if (!$(this).find("span.v>a").hasClass("sele")) {
                    $(this).find("span.v>a").attr("class", ""); //当前头部大标题 样式为不选中
                }

                //            $("#nav li>div.kind_menu").hide();
                //还原原来样式
                //            var HiddenFieldTop=parseInt($("#HiddenFieldTop").val());
                //            $("#nav li:eq("+(HiddenFieldTop-1)+")>span>a").attr("class","sele");
                //            $("#nav li:eq("+(HiddenFieldTop-1)+")>div.kind_menu").show();
            }
        );

        //头部小标题 滑过事件
        $("div.kind_menu>div>a").hover(
            function () {
                $(this).attr("class", "ahover");

            },
            function () {
                $(this).removeClass("ahover");
                //还原原来样式
                var HiddenTopSub = parseInt($("#HiddenTopSub").val());
                var HiddenFieldTop = parseInt($("#HiddenFieldTop").val());
                $("#nav li:eq(" + (HiddenFieldTop - 1) + ")>div>div>a:eq(" + (HiddenTopSub - 1) + ")").attr("class", "ahover");
            }
        );
    </script>
    <script type="text/javascript" language="javascript">
        function changeIfam(obj) {
            $("#mainFrame").attr("src", obj);
            $(".SiteNav").hide();
            $(".mask").hide();
        }

        function ShowNav() {
            $(".SiteNav").show("slow");
            $(".mask").show("slow");
        }

        //头部大标题 点击事件 index:小标题 id  indexsub:页面左边导航id 

        function changeTab(index, indexLeft, obj) {
            $("div.r>ul>li>span>a").attr("class", ""); //所有大标题未选中
            $(".kind_menu").hide(); //下面的小标题隐藏
            $(obj).attr("class", "sele"); //当前大标题选中
            $(obj).parent().next().show(); //当前大标题 下面的小标题显示
            $(obj).parent().next().find("div.kc>a").attr("class", ""); //给当前小标题取消样式
            $(obj).parent().next().find("div.kc>a:eq(0)").attr("class", "ahover"); //给当前第一个小标题样式
            $("#HiddenFieldTop").val(index); //保存点击的项是第几个 用于滑过事件
            $("#HiddenTopSub").val("1"); //保存点击的项是第几个 用于滑过事件

            $(".box_left").hide(); //左边导航隐藏
            $("#box_leftid" + indexLeft).show(); //当前左边导航显示
            $("div.box_left>div>div.side-bx-bd").hide(); //当前左边导航 所有关闭
            $("#box_leftid" + indexLeft + ">div:eq(0)>div.side-bx-bd").show(); //当前左边导航 第一个展开
            $(".side-bx-bd>ul>li>a").attr("class", ""); //当前左边导航 小标题都不选中
            $("#box_leftid" + indexLeft + ">div:eq(0)>div.side-bx-bd>ul>li:eq(0)>a").attr("class", "current"); //当前左边导航 第一个小标题选中
            $("#box_leftid" + indexLeft + ">div").removeClass("side-bx-down"); //箭头变方向
            $("#box_leftid" + indexLeft + ">div:eq(0)").addClass("side-bx-down"); //箭头变方向
            $("#HiddenLeftSub").val("1"); //保存点击的项是第几个 用于滑过事件

            //有问题 要保存 box_leftidSub8 给隐藏域
            var indexLeftSub = $("#box_leftid" + indexLeft + ">div:eq(0)").attr("id");
            $("#HiddenLeft").val(indexLeftSub.substring(13)); //保存点击的项是第几个 用于滑过事件

        }

        //头部小标题 点击事件 parent:大标题 id ,index :小标题点击的项是第几个  indexsub:小标题id  indexLeft:页面左边导航id 

        function changeTabSub(parent, index, indexLeft, indexLeftSub, Aobj) {
            $("#HiddenFieldTop").val(parent); //保存 大标题点击的项是第几个 用于滑过事件
            $("#HiddenTopSub").val(index); //保存 小标题点击的项是第几个 用于滑过事件
            $("div.kind_menu>div>a").attr("class", "");
            $(Aobj).attr("class", "ahover"); //给当前a选中样式

            ////左边导航
            $(".box_left").hide(); //左边导航隐藏
            $("#box_leftid" + indexLeft).show(); //当前左边导航显示
            $("div.side-bx>div.side-bx-bd").hide();
            $("#box_leftidSub" + indexLeftSub + ">div.side-bx-bd").show();


            $(".side-bx").removeClass("side-bx-down"); //箭头初始化
            $("#box_leftidSub" + indexLeftSub).addClass("side-bx-down"); //箭头变方向

            $(".side-bx-bd>ul>li>a").attr("class", ""); //当前左边导航 小标题都不选中
            $("#box_leftidSub" + indexLeftSub + ">div.side-bx-bd>ul>li:eq(0)>a").attr("class", "current"); //当前左边导航 第一个小标题选中
            $("#HiddenLeftSub").val("1"); //保存点击的项是第几个 用于滑过事件
            $("#HiddenLeft").val(indexLeftSub); //保存点击的项是第几个 用于滑过事件
        }


        //左边 大导航 展开收缩 parent：头部大导航 li的位置,index：头部小导航 的位置 (不是id)

        function LeftExpansion(parent, index, obj) {
            //var iurl=$(obj).next().find(".current").attr("onclick");
            $(obj).next().find(".current").removeClass("current");
            if ($(obj).parent().hasClass("side-bx-down")) {
                //左边导航 展开收缩
                $(obj).parent().removeClass("side-bx-down");
                $("div.side-bx>div.side-bx-bd").hide();
                $(obj).next("div.side-bx-bd").hide();
            } else {
                //左边导航 展开收缩
                $(".side-bx").removeClass("side-bx-down");
                $(obj).parent().addClass("side-bx-down");
                $("div.side-bx>div.side-bx-bd").hide();
                $(obj).next("div.side-bx-bd").show();
            }

            //头部导航变化
            $("#HiddenFieldTop").val(parent); //保存点击的项是第几个 用于滑过事件
            $("#HiddenTopSub").val(index);
            $("div.kind_menu>div.kc>a").attr("class", "");
            $("#nav li:eq(" + (parseInt(parent) - 1) + ")>div>div>a:eq(" + (parseInt(index) - 1) + ")").attr("class", "ahover");
            //changeIfam(iurl.split("'")[1]);
        }

        //左边 小导航 点击事件 parent= box_leftidSub8;index:表示在div.side-bx-bd的第几个a

        function LeftSubExpansion(parent, index, obj) {
            $("div.side-bx-bd>ul>li>a").attr("class", "");
            $(obj).attr("class", "current"); //选中样式
            $("#HiddenLeftSub").val(index); //保存点击的项是第几个 用于滑过事件
            $("#HiddenLeft").val(parent); //保存点击的项是第几个 用于滑过事件
        }

        $(function () {
            // 左边导航 滑过事件
            $("div.side-bx-bd>ul>li>a").hover(
                function () {
                    if ($(this).hasClass("current")) {

                    } else {
                        $(this).attr("class", "test");
                    }
                },
                function () {
                    $(this).removeClass("test");
                    //还原原来样式
                    var HiddenLeftSub = parseInt($("#HiddenLeftSub").val());
                    var HiddenLeft = parseInt($("#HiddenLeft").val());
                    $("#box_leftidSub" + HiddenLeft + ">div.side-bx-bd>ul>li>a:eq(" + (HiddenLeftSub - 1) + ")").attr("class", "current");
                }
            );
        });

    </script>
    <style type="text/css">
        .loading {
            background: url("images/loading_bg.gif") no-repeat 0 0;
            color: Black;
            display: block;
            font-size: 12px;
            font-style: normal;
            font-weight: normal;
            height: 91px;
            left: 50%;
            line-height: 90px;
            margin: 0;
            opacity: 1;
            padding: 0;
            position: absolute;
            text-align: left;
            top: 50%;
            vertical-align: baseline;
            visibility: visible;
            width: 266px;
            z-index: 65535;
        }

        .loading_img {
            color: Black;
            display: block;
            float: left;
            font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;
            font-size: 12px;
            font-style: normal;
            font-weight: bold;
            height: auto;
            left: auto;
            line-height: 32px;
            margin: 0;
            opacity: 1;
            padding: 28px 10px 0 40px;
            position: static;
            text-align: left;
            top: auto;
            vertical-align: baseline;
            visibility: visible;
            width: 16px;
            z-index: auto;
        }

        .loading_message {
            color: Black;
            display: block;
            float: left;
            font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;
            font-size: 14px;
            height: auto;
            left: auto;
            line-height: 32px;
            margin: 0;
            opacity: 1;
            padding: 28px 0 0 20px;
            position: static;
            text-align: left;
            top: auto;
            vertical-align: baseline;
            visibility: visible;
            width: auto;
            z-index: auto;
        }
    </style>
</body>
</html>
