<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_Head.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_Head" %>
<%@ Import Namespace="ShopNum1.Common" %>

<div id="top">
    <!--登录-->
    <div class="fl_left">
        您好！<strong class="red"><asp:Label ID="LabelMemberID" runat="server" Text=""></asp:Label></strong>
        [<span style="color: #005ea7;"><asp:LinkButton ID="ButtonOut" 
            runat="server" Text="退出" onclick="ButtonOut_Click"></asp:LinkButton></span>]
    </div>
    <!--消息提醒-->
    <div class="xiaoxi">
        <a href="/main/member/m_index.aspx?tomurl=/main/Member/M_SysMsg.aspx?isread=0&pageid=1">
            消息提醒：您有( <span style="font-size: 14px; color: #ff6600; font-family: Arial;">
                <asp:Label ID="LabelMsg" runat="server" Text="0"></asp:Label>
            </span>)封未读系统信息.. </a>
    </div>
    <div class="top_list">
        <div class="top_mer fl">
            <a target="_blank" href='http://<%=ShopSettings.siteDomain  %>' class="top_a1">商城首页</a></div>
        <div class="top_hert allsort fl">
            <a href="#" class="top_a">我的商城</a>
            <div class="sub_customer">
                <a target="win" href="/main/Member/M_OrderList.aspx" class="lo1">购买的商品</a> <a href="/shop/ShopAdmin/s_index.aspx?tosurl=S_Order_List.aspx"
                    class="lo2">卖出的商品</a>
            </div>
        </div>
        
        <div class="top_help fl">
            <a target="_blank" href="/Main/HelpList.aspx?guid=326267b3-354f-47c7-b3fe-196498cadeab"
                class="top_a1">帮助中心</a></div>
    </div>
</div>
<div style="clear: both;">
</div>
<div id="top_container">
    <div id="top2">
        <!--会员中心Logo-->
        <div style="float: left;">
            <a target="_blank" href='http://<%=ShopSettings.siteDomain  %>'>
                <asp:Image ID="ImageShopLogo" runat="server" /></a>
        </div>
        <!--搜索Search-->
        <div class="lmf_searchs">
            <div class="lmf_search">
                <div class="lmf_search_text">
                    <input name="tex1" type="text" value="请输入商品名称!" onfocus="this.value=''" onblur="if(!value){value=defaultValue;}"
                        class="lmf_nr" /></div>
                <div class="lmf_search_btn">
                    <a href="#">
                        <input name="btn" type="button" class="lmf_btnss" value="搜索" /></a></div>
            </div>
        </div>
    </div>
</div>
<div style="clear: both;">
</div>
<div id="nav_bg">
    <div id="nav">
        <div id="gwc">
            <a href="/Main/ShoppingCart1.aspx" target="_blank">您的购物车有 <span class="green_bold">
                <asp:Label ID="LabelGouWuChe" runat="server" Text="0"></asp:Label>
            </span>件商品</a>
        </div>
        <!--菜单项nav-->
        <ul style="float: left;">
            <li><a href="m_index.aspx" class="zh">个人中心</a></li>
			<li id="lim" runat="server"  class="line"><span></span></li>
            <li id="limm" runat="server" ><a href="/shop/ShopAdmin/s_index.aspx">我是卖家</a></li>
			<li class="line"><span></span></li>
            <li><a href="/main/account/A_Index.aspx">账户管理</a></li>
            
        </ul>
    </div>
</div>
<div style="clear: both;">
</div>
<script type="text/javascript" language="javascript">
    $(function () {
        //处理搜索方法
        $(".lmf_btnss").click(function () {
            if ($(".lmf_nr").val() == "请输入商品名称!") { alert("请输入商品名称!"); return false; }
            location.href = "/Search_productlist.aspx?search=" + escape($(".lmf_nr").val());
        });
    });
</script>
