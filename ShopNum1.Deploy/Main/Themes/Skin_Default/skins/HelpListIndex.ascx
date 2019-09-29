<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript">
    function CheckIsEmpty() {
        var str = document.getElementById("HelpListIndex_ctl00_TextBoxSearch").value;
        if (str == "") {
            return false;
        }
        return true;
    }
</script>
<!---->
<div class="help_search">
    <table border="0" cellpadding="0" cellspacing="0" class="help_tab">
        <tbody>
            <tr>
                <td>
                    <span class="zhao">找帮助</span>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxSearch" runat="server" CssClass="help_input"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="ButtonAgainSearch" runat="server" Text="" CssClass="helpbtn" OnClientClick=" return CheckIsEmpty()" />
                </td>
                <td align="right">
                    <img src="Themes/Skin_Default/Images/help_phone.jpg" />
                </td>
            </tr>
        </tbody>
    </table>
</div>
<div class="help_con">
    <h3 class="help_con_title">
        购物流程</h3>
    <div class="help_contents">
        <div class="tree">
            <img src="Themes/Skin_Default/Images/liuc.jpg" /></div>
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
            </ItemTemplate>
        </asp:Repeater>
        <div class="guide" style="display: none;">
            <h1 class="guide_title">
                快速引导</h1>
            <div class="guide_con">
                <dl>
                    <dt>账号管理</dt>
                    <dd>
                        <a href="#">注册与激活</a>|&nbsp;&nbsp;<a href="#">登录与开通</a>|&nbsp;&nbsp; <a href="#">账户信息维护</a>|&nbsp;&nbsp;<a
                            href="#">港澳台及海外会员</a>
                    </dd>
                </dl>
                <dl>
                    <dt>我是卖家</dt>
                    <dd>
                        <a href="#">商品发布与开店</a>|&nbsp;&nbsp;<a href="#">出售商品</a>|&nbsp;&nbsp; <a href="#">交易评价</a>|&nbsp;&nbsp;<a
                            href="#">消费者保障服务</a>|&nbsp;&nbsp; <a href="#">卖家工具及服务</a>|&nbsp;&nbsp;<a href="#">卖家考试</a>|&nbsp;&nbsp;<a
                                href="#">卖家活动报名</a>
                    </dd>
                </dl>
                <dl>
                    <dt>退款& 维权举报</dt>
                    <dd>
                        <a href="#">退款管理 </a>|&nbsp;&nbsp;<a href="#">维权管理</a>|&nbsp;&nbsp; <a href="#">举报管理</a>|&nbsp;&nbsp;<a
                            href="#">处罚</a>
                    </dd>
                </dl>
                <dl>
                    <dt>我是买家</dt>
                    <dd>
                        <a href="#">挑选商品</a>|&nbsp;&nbsp;<a href="#">购买商品</a>|&nbsp;&nbsp;<a href="#">优惠卡券</a>
                    </dd>
                </dl>
                <dl>
                    <dt>特色频道</dt>
                    <dd>
                        <a href="#">淘宝游戏交易平台 </a>|&nbsp;&nbsp;<a href="#">机票/酒店/彩票/旅游</a>|&nbsp;&nbsp; <a
                            href="#">保险</a>|&nbsp;&nbsp;<a href="#">手机淘宝</a>|&nbsp;&nbsp;<a href="#">淘宝充值平台</a>|&nbsp;&nbsp;
                        <a href="#">良无限</a>
                    </dd>
                </dl>
                <dl>
                    <dt>阿里旺旺</dt>
                    <dd>
                        <a href="#">下载与安装</a>|&nbsp;&nbsp;<a href="#">登录与退出</a>|&nbsp;&nbsp; <a href="#">优惠卡券</a>|&nbsp;&nbsp;<a
                            href="#">联系人中心</a>|&nbsp;&nbsp; <a href="#">常见问题</a>
                    </dd>
                </dl>
                <div class="clear">
                </div>
            </div>
        </div>
    </div>
</div>
