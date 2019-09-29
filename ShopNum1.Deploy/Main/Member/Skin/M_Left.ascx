<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_Left.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_Left" %>
<div id="left">
    <div id="left_top">
    </div>
    <div class="sdmenu">
        <div id="ti01" onclick="te_show(1,this)">
            <span class="fh1 fh">交易管理</span>
        </div>
        <div id="te01" style="display: block;" class="lmf_submenu">
            <a target="win" href="M_OrderList.aspx" onclick="subItem(this)" class="lmf_act">我的订单</a>
            <a target="win" href="M_OrderListTwo.aspx" onclick="subItem(this)" class="lmf_act">三个月前订单</a>
            <%-- <a target="win" href="M_SaleOrderList.aspx" onclick="subItem(this)">促销订单</a> --%>
            <%--<a target="win" href="M_LifeOrderList.aspx" onclick="subItem(this)">生活服务订单</a>--%>
            <a target="win" href="M_Feedback.aspx" onclick="subItem(this)" class="lmf_act">信用评价</a>
            <%--<a target="win" href="M_OrderScoreList.aspx" onclick="subItem(this)" class="lmf_act">
                红包订单</a>--%>
        </div>
        <div id="ti02" onclick="te_show(2,this)">
            <span class="fh2 fh">我的站内信</span>
        </div>
        <div id="te02" style="display: block;" class="lmf_submenu">
            <a target="win" href="M_SysMsg.aspx?isread=0&pageid=1" onclick="subItem(this)" class="lmf_act">系统消息</a> <a target="win" href="M_Msg.aspx?isread=0&pageid=1" onclick="subItem(this)"
                class="lmf_act">会员消息</a>
        </div>
        <%-- <div id="ti03" onclick="te_show(3,this)">
            <span class="fh3 fh">推荐会员</span></div>
        <div id="te03" style="display: block;" class="lmf_submenu">
            <a target="win" href="M_RecommendUser.aspx" onclick="subItem(this)" class="lmf_act">
                推荐会员列表</a> <a target="win" href="M_RecommendCommision.aspx" onclick="subItem(this)"
                    class="lmf_act">推荐会员返利</a>
        </div>--%>
        <div id="ti04" onclick="te_show(4,this)">
            <span class="fh4 fh">维权管理</span>
        </div>
        <div id="te04" style="display: block;" class="lmf_submenu">
            <a target="win" href="M_RefundManage.aspx" onclick="subItem(this)" class="lmf_act">退款管理</a>
            <a target="win" href="M_ExitGoods.aspx" onclick="subItem(this)" class="lmf_act">退货管理</a>
            <a target="win" href="M_MyReport.aspx" onclick="subItem(this)" class="lmf_act">我的举报</a>
            <a target="win" href="M_Complaints.aspx" onclick="subItem(this)" class="lmf_act">我的投诉</a>
            <a target="win" href="M_MyMessageBoard.aspx" onclick="subItem(this)" class="lmf_act">我的店铺留言</a>
            <%--<a target="win" href="M_SearchTicket.aspx" onclick="subItem(this)" class="lmf_act">
                    发票查询</a>--%>
        </div>
        <%--<div id="ti05" onclick="te_show(5,this)">
            <span class="fh5 fh">我的红包</span></div>
        <div id="te05" style="display: block;" class="lmf_submenu">
            <a target="win" href="M_CreditDetails.aspx?type=0&pageid=1" onclick="subItem(this)"
                class="lmf_act">红包明细</a>
        </div>--%>
        <%--<div id="ti06" onclick="te_show(6,this)">
            <span class="fh6 fh">供求信息</span></div>
        <div id="te06" style="display: block;" class="lmf_submenu">
            <a target="win" href="M_MySupply.aspx" onclick="subItem(this)" class="lmf_act">我的供求</a>
            <a target="win" href="M_AddSupply.aspx" onclick="subItem(this)" class="lmf_act">发布供求</a>
        </div>--%>
        <div id="ti07" onclick="te_show(7,this)">
            <span class="fh7 fh">我的收藏</span>
        </div>
        <div id="te07" style="display: block;" class="lmf_submenu">
            <a target="win" href="M_MyCollect.aspx?type=0&pageid=1" onclick="subItem(this)" class="lmf_act">我的收藏</a>
        </div>
        <div id="ti08" onclick="te_show(8,this)">
            <span class="fh8 fh">我的评论</span>
        </div>
        <div id="te08" style="display: block;" class="lmf_submenu lmf_submenu1">
            <a target="win" href="M_Comment.aspx?type=0&pageid=1" onclick="subItem(this)" class="lmf_act">我的评论</a>
        </div>
        <div id="ti03" runat="server" style="display: block;" onclick="te_show(3,this)">
            <span class="fh3 fh">推荐会员</span>
        </div>
        <div id="te03" runat="server" style="display: block;" class="lmf_submenu">

            <%--<a target="win" href="M_TJmemberTG.aspx" onclick="subItem(this)"
                class="lmf_act">推广链接注册顾客</a>--%>
            <%-- <div id="ywy" class="lmf_act" onclick="subItem(this)" runat="server">--%>
            <a target="win" href="M_TJmemberTGYWY.aspx" onclick="subItem(this)" class="lmf_act">推广链接</a>

            <%--</div>--%>
            <a target="win" href="M_TJLB.aspx?type=0&pageid=1" onclick="subItem(this)" class="lmf_act">推荐列表</a>
        </div>
        <div id="ti09" runat="server" onclick="te_show(9,this)">
            <span class="fh9 fh">车辆信息绑定</span>
        </div>
        <div id="te09" runat="server" style="display: block;" class="lmf_submenu">
            <a target="win" href="M_CarBand.aspx" onclick="subItem(this)" class="lmf_act">车辆绑定申请</a>
        </div>
        <div id="ti10" onclick="te_show(10,this)" runat="server">
            <span class="fh10 fh">车辆里程</span>
        </div>
        <div id="te10" style="display: block;" class="lmf_submenu" runat="server">
            <a target="win" href="M_ReplaceAll.aspx?type=0&pageid=1" onclick="subItem(this)" class="lmf_act">每日里程记录</a>

        </div>
    </div>
    <div id="left_bot">
    </div>
</div>
