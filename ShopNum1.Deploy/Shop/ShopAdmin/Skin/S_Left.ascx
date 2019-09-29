<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<!--左边导航nav-->
<div id="left">
    <div id="left_top">
    </div>
    <div class="sdmenu">
        <div id="ti01" onclick=" te_show(1, this) ">
            <span class="fh1 fh">交易管理</span></div>
        <div id="te01" style="display: block;" class="lmf_submenu">
            <a target="win" href="S_Order_List.aspx" onclick=" subItem(this) " class="lmf_act">订单管理</a>
            <a target="win" href="S_Order_List.aspx" onclick=" subItem(this) " class="lmf_act">老订单</a>
           <%-- <%--            <a target="win" href="S_SaleOrder_List.aspx" onclick="subItem(this)" class="lmf_act">促销订单</a>--%>
            <%--<a target="win" href="S_LifeOrder_List.aspx" onclick=" subItem(this) " class="lmf_act">
                生活服务订单管理</a>--%><a target="win" href="S_CreditHonor.aspx" onclick=" subItem(this) "
                    class="lmf_act">评价管理</a>
        </div>
        <div id="ti03" onclick=" te_show(3, this) ">
            <span class="fh3 fh">商品管理</span></div>
        <div id="te03" style="display: block;" class="lmf_submenu">
            <a target="win" href="S_ProductCategory.aspx" onclick=" subItem(this) " class="lmf_act">
                店铺商品分类</a> <a target="win" href="S_PageGo.aspx?pagetype=0" onclick=" subItem(this) "
                    class="lmf_act">发布商品</a> <a target="win" href="S_SellProduct.aspx" onclick=" subItem(this) "
                        class="lmf_act">出售中的商品</a> <a target="win" href="S_StoreProduct.aspx" onclick=" subItem(this) "
                            class="lmf_act">仓库中的商品</a> <a target="win" href="S_UnAuditProduct.aspx" onclick=" subItem(this) "
                                class="lmf_act">待审核的商品</a> <a target="win" href="S_RepertoryAlertProduct.aspx" onclick=" subItem(this) "
                                    class="lmf_act">库存预警</a> <a target="win" style="display: none;" href="S_ShopProductUpload.aspx"
                                        onclick=" subItem(this) " class="lmf_act">商品数据导入</a>
                         <a target="win" href="S_Import.aspx" onclick="subItem(this)" class="lmf_act">商品导出</a>
            <a target="win" href="S_Import.aspx" onclick=" subItem(this) " class="lmf_act">淘宝数据包导入</a>
           <%-- <a target="win" href="S_PaipaiImport.aspx" onclick=" subItem(this) " class="lmf_act">
                拍拍数据包导入</a> <a target="win" href="S_YiquImport.aspx" onclick=" subItem(this) " class="lmf_act">
                    易趣数据包导入</a>--%>
        </div>
        
        <div id="ti05" onclick=" te_show(5, this) ">
            <span class="fh5 fh">店铺管理</span></div>
        <div id="te05" style="display: none;" class="lmf_submenu">
            <a target="_blank" href="S_ShowMyShop.aspx" onclick=" subItem(this) " class="lmf_act">
                查看我的店铺</a> <a target="win" href="S_ShopInfo.aspx?type=0" onclick=" subItem(this) "
                    class="lmf_act">店铺信息</a> <%--<a target="win" href="S_ShowPaymentType.aspx" onclick=" subItem(this) "
                        class="lmf_act">店铺支付方式</a>--%> <a target="win" href="S_OnLineServiceList.aspx" onclick=" subItem(this) "
                            class="lmf_act">客服管理</a><a target="win" href="S_PostageSettings.aspx" onclick=" subItem(this) "
                            class="lmf_act">邮费设置</a>

        </div>
        <div id="ti06" onclick=" te_show(6, this) ">
            <span class="fh6 fh">店铺装修</span></div>
        <div id="te06" style="display: none;" class="lmf_submenu">
            <a target="win" href="S_SkinSelect.aspx" onclick=" subItem(this) " class="lmf_act">店铺可用模版</a>
            <a target="win" href="S_SkinBackup.aspx" onclick=" subItem(this) " class="lmf_act">店铺模版备份</a>
            <a target="win" href="S_AdvertisementList.aspx" onclick=" subItem(this) " class="lmf_act">
                页面广告</a> <a target="win" href="S_UserDefinedColumnList.aspx" onclick=" subItem(this) "
                    class="lmf_act">前台导航栏</a>
        </div>
        
        
        <asp:Panel ID="PanelScroe" runat="server">
            <div id="ti08" onclick=" te_show(8, this) ">
                <span class="fh8 fh">红包商城</span></div>
            <div id="te08" style="display: none;" class="lmf_submenu">
                <a target="win" href="/shop/ShopAdmin/S_ScoreOrder_List.aspx" onclick="subItem(this)"
                    class="lmf_act" runat="server" id="ScoreOrder">红包订单</a> <a target="win" href="/shop/ShopAdmin/S_ScoreProduct.aspx?type=1"
                        onclick="subItem(this)" class="lmf_act" runat="server" id="ScoreProduct">红包商品</a>
                <%--<a target="win" href="s_yinxiao.html" onclick="subItem(this)" class="lmf_act">商品营销</a>--%>
            </div>
        </asp:Panel>
        
        <div id="ti010" onclick=" te_show(10, this) ">
            <span class="fh10 fh">店铺统计</span></div>
        <div id="te010" style="display: none;" class="lmf_submenu lmf_submenu1">
            <a target="win" href="S_SeeBuyRate.aspx" onclick=" subItem(this) " class="lmf_act">商品访问统计
            </a><a target="win" href="S_StockReport.aspx#gone" onclick=" subItem(this) " class="lmf_act">
                库存报表</a> <a target="win" href="S_ShopSellOrder.aspx" onclick=" subItem(this) " class="lmf_act">
                    销售排行</a>
        </div>
        <div id="ti011" onclick=" te_show(11, this) ">
            <span class="fh11 fh">图片管理</span></div>
        <div id="te011" style="display: none;" class="lmf_submenu lmf_submenu1">
            <a target="win" href="S_Album.aspx" onclick=" subItem(this) " class="lmf_act">图片空间</a>
        </div>
        <div id="ti012" onclick=" te_show(12, this) ">
            <span class="fh12 fh">客户服务</span></div>
        <div id="te012" style="display: none;" class="lmf_submenu lmf_submenu1">
            <%--<a target="win" href="S_EnsureApplyRecordList.aspx" onclick=" subItem(this) " class="lmf_act">
                消费者保障服务</a>--%> <a target="win" href="S_ExitManage.aspx" onclick=" subItem(this) " class="lmf_act">
                    退款管理</a> <a target="win" href="S_ExitGoods.aspx" onclick=" subItem(this) " class="lmf_act">
                        退货管理</a> <a target="win" href="S_MessageBoardList.aspx" onclick=" subItem(this) "
                            class="lmf_act">咨询回复</a> <a target="win" href="S_ProductMessageBoardList.aspx" onclick=" subItem(this) "
                                class="lmf_act">商品留言</a> <a target="win" href="S_MemberReport.aspx" onclick=" subItem(this) "
                                    class="lmf_act">举报管理</a> <a target="win" href="S_OrderComplaints.aspx" onclick=" subItem(this) "
                                        class="lmf_act">投诉管理</a> <a target="win" href="S_SearchTicket.aspx" onclick=" subItem(this) "
                                            class="lmf_act">发票查询</a>
            <%-- <a target="win" href="S_ProductBookingList.aspx" onclick="subItem(this)" class="lmf_act">预约管理</a>--%>
        </div>
        
    </div>
    <div id="left_bot">
    </div>
</div>
