<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminWelcome_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.AdminWelcome_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <%= HeaderInfo("欢迎页") %>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<style type="text/css">
    .welcon
    {
        color: #666666;
        font-size: 13px;
        text-decoration: none;
    }
    
    .welcon a
    {
        color: #666666;
        font-size: 13px;
        text-decoration: none;
    }
    
    .welcon a span
    {
        font-weight: bold;
    }
    
    .welcon a:hover
    {
        color: #4482b4;
        font-size: 13px;
        text-decoration: none;
    }
    
    .ordercont
    {
        color: #666666;
        font-size: 13px;
        text-decoration: none;
    }
    
    .ordercont span
    {
        font-weight: bold;
    }
</style>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <!--系统版本信息-->
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    欢迎页</h3>
            </div>
            <div style="color: #888888; float: left; font-size: 12px; padding-left: 10px; padding-top: 10px;">
                欢迎您：<font color="#ff6600" style="font-weight: bold;"><%= ShopNum1LoginID %>
                </font>&nbsp;&nbsp;您上次登录的时间是：<asp:Label ID="LabelLastLoginTime" runat="server"></asp:Label>&nbsp;&nbsp;
                您当前系统的版本是：<font class="StorePrice"><asp:Label ID="LabelVersion" runat="server"></asp:Label>
                </font>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <!--订单信息-->
            <div class="orderinfo">
                <h5>
                    订单信息</h5>
                <div class="ordercont">
                    <p>
                        <a href="Order_List.aspx?style=1">总订单量：
                            <asp:Label ID="LabelForCount" runat="server"></asp:Label>个</a></p>
                    <p>
                        <a href="Order_List.aspx?style=2&status=0">待付款的订单：
                            <asp:Label ID="LabelForPayCount" runat="server"></asp:Label>个</a></p>
                    <p>
                        <a href="Order_List.aspx?style=3&status=1">已支付待发货订单：
                            <asp:Label ID="LabelForDispatchCount" runat="server"></asp:Label>个</a></p>
                    <p>
                        <a href="Order_List.aspx?style=4&status=2">已发货待确认的订单：
                            <asp:Label ID="LabelForConfirmCount" runat="server"></asp:Label>个</a></p>
                    <p>
                        <a href="Order_List.aspx?style=5&status=3">已成交的订单数：
                            <asp:Label ID="LabelFinishedCount" runat="server"></asp:Label>个</a></p>
                </div>
            </div>
            <!--商品信息-->
            <div class="orderinfo rc2">
                <h5>
                    商品信息</h5>
                <div class="ordercont">
                    <p style="display: none;">
                        <a href="ProuductChecked_List.aspx">待审核的商品数：
                            <asp:Label ID="LabelAuditProductCount" runat="server"></asp:Label></a></p>
                    <p>
                        <a href="Prouduct_List.aspx">网站商品总数：
                            <asp:Label ID="LabelProductCount" runat="server"></asp:Label>件</a></p>
                    <p style="display: none;">
                        <a href="ProuductSpellBuy_List.aspx">团购商品数：
                            <asp:Label ID="LabelSpellBuyProductCount" runat="server"></asp:Label>件</a></p>
                    <p>
                        <a href="ProuductPanicBuy_List.aspx">抢购商品数：
                            <asp:Label ID="LabelPanicBuyProductCount" runat="server"></asp:Label>件</a></p>
                    <p>
                        <a href="Prouduct_List.aspx?good=1">精品商品数：
                            <asp:Label ID="LabelBestCount" runat="server"></asp:Label>件</a></p>
                    <p>
                        <a href="Prouduct_List.aspx?recommend=1">推荐商品数：
                            <asp:Label ID="LabelRecommendCount" runat="server"></asp:Label>件</a></p>
                    <p>
                        <a href="Prouduct_List.aspx?new=1">新品商品数：
                            <asp:Label ID="LabelNewCount" runat="server"></asp:Label>件</a></p>
                    <p>
                        <a href="Prouduct_List.aspx?hot=1">热销商品数：
                            <asp:Label ID="LabelHotCount" runat="server"></asp:Label>件</a>
                    </p>
                </div>
            </div>
            <!--待处理事务-->
            <div class="orderinfo rc3">
                <h5>
                    待处理事务</h5>
                <div class="ordercont">
                    <p>
                        <a href="ShopInfoList_Audit.aspx">待审核的店铺：
                            <asp:Label ID="LabelAuditShopCount" runat="server"></asp:Label>个</a></p>
                    <p>
                        <a href="AdvancePaymentMemApplyLog_List.aspx?operateStatus=1">未处理会员充值：
                            <asp:Label ID="LabelMemApply" runat="server"></asp:Label>个</a></p>
                    <p>
                        <a href="AdvancePaymentApplyLog_List.aspx?operateStatus=1">未处理会员提现：
                            <asp:Label ID="LabelPaymentApply" runat="server"></asp:Label>个</a></p>
                    <p>
                        <a href="ShopNum1MessageBoard_List.aspx">会员建议列表：
                            <asp:Label ID="LabelMessageBoard" runat="server"></asp:Label>个</a></p>
                    <p>
                        <a href="ShopNum1_SupplyDemandCheck_List.aspx?isAudit=0">待审核供求信息：
                            <asp:Label ID="LabelDemandCheck" runat="server"></asp:Label>个</a></p>
                    <p style="display: none">
                        <a href="ShopNum1_CategoryInfoChecked_List.aspx">待审核分类信息：
                            <asp:Label ID="LabelCategoryChecked" runat="server"></asp:Label>个</a></p>
                    <p>
                        <a href="ProuductChecked_List.aspx">待审核的商品数：
                            <asp:Label ID="LabelProuductChecked" runat="server"></asp:Label>个</a></p>
                    <p>
                        <a href="ShopProductCommentAudit_List.aspx">待处理商品评论：
                            <asp:Label ID="LabelProductCommentAudit" runat="server"></asp:Label>个</a></p>
                </div>
            </div>
            <!--商城动态-->
            <div class="orderinfo rc4">
                <h5>
                    商城动态</h5>
                <div class="ordercont">
                    <p>
                        今日销售总金额： ￥<asp:Label ID="LabelProductPriceCount" runat="server"></asp:Label></p>
                    <p>
                        今日订单量：
                        <asp:Label ID="LabelOrderNow" runat="server"></asp:Label>个</p>
                    <p>
                        今日注册会员数：
                        <asp:Label ID="LabelMemberCount" runat="server"></asp:Label>个</p>
                    <p>
                        今日入驻的店铺：
                        <asp:Label ID="LabelShopNowCount" runat="server"></asp:Label>个</p>
                    <p>
                        会员总数：
                        <asp:Label ID="LabelMemberAllCount" runat="server"></asp:Label>个</p>
                    <p>
                        店铺总数量：
                        <asp:Label ID="LabelShopAllCount" runat="server"></asp:Label>个</p>
                    <p style="display: none;">
                        今日销售商品总量：
                        <asp:Label ID="LabelBuyNumberCount" runat="server"></asp:Label></p>
                </div>
            </div>
        </div>
    </div>
    <div class="product" style="display: none;">
        <div class="product_title">
            留言评论</div>
        <div class="product_content">
            <table width="100%" border="0" cellspacing="1" cellpadding="0" bgcolor="#f1f1f1">
                <tr>
                    <td width="20%" bgcolor="#ffffff">
                        最新留言：
                    </td>
                    <td width="30%" bgcolor="#ffffff">
                        <a href="ShopProductComment_List.aspx">
                            <asp:Label ID="LabelMessageBoardCount" runat="server"></asp:Label></a>
                    </td>
                    <td width="20%" bgcolor="#ffffff">
                        未读站内短信：
                    </td>
                    <td width="30%" bgcolor="#ffffff">
                        <a href="ReceiveMessage_List.aspx">
                            <asp:Label ID="Label1MessageCount" runat="server"></asp:Label></a>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#ffffff">
                        最新资讯评论：
                    </td>
                    <td bgcolor="#ffffff">
                        <a href="ArticleComment_List.aspx">
                            <asp:Label ID="LabelArticleComment" runat="server"></asp:Label></a>
                    </td>
                    <td bgcolor="#ffffff">
                        最新商品评论：
                    </td>
                    <td bgcolor="#ffffff">
                        <a href="ShopProductComment_List.aspx">
                            <asp:Label ID="LabelProductComment" runat="server"></asp:Label></a>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <%--屏蔽--%>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
