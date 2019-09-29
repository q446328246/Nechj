<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="A_PwdSer.ascx.cs" Inherits="ShopNum1.Deploy.Main.Account.Skin.A_PwdSer" %>
<div class="zhszmian">
    <div class="zhszmian_nr">
        <div class="zhs_le">
            <dl>
                <dt>您的账号安全等级：<span class="redbold">
                    <asp:Label ID="Lab_SafeRank" runat="server" Text=""></asp:Label>
                </span></dt>
                <dd>
                    <asp:Image ID="Image_SafeRankImg" runat="server" Width="360" Height="13" />
                </dd>
                <dd>
                    <asp:Label ID="Lab_SafeRankTitle" runat="server" Text=""></asp:Label></dd>
            </dl>
        </div>
        <div class="zhs_ri">
            <ul>
                <li>提高账号安全等级，您可以：</li>
                <li>
                    <asp:LinkButton ID="LinkButton_Mobile" runat="server" CssClass="alink_blue" PostBackUrl="../A_BindMobile.aspx">手机绑定</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton_Email" runat="server" CssClass="alink_blue" PostBackUrl="../A_BindEmail.aspx">邮箱绑定</asp:LinkButton></li>
                <%--<li>
                    <asp:LinkButton ID="LinkButton_Set" runat="server" CssClass="alink_blue" PostBackUrl="<% =Url1 %>">设置交易密码</asp:LinkButton>
                </li>--%>
            </ul>
        </div>
    </div>
    <div style="clear: both;">
    </div>
    <div class="dengl">
        <div class="denflot done">
            登录密码
        </div>
        <div class="denflot dtwo">
            <ul>
                <li>登录商城时需要使用的密码。</li>
                <li><span class="orange">最基本的账号保护手段，请不要轻易告知他人。</span></li>
            </ul>
        </div>
        <div class="denflot dthree">
            <a href="A_UpPwd.aspx" class="xiug" target="win" onclick="subItem(this)">修改 </a>
        </div>
    </div>
    <div class="dengl">
        <div class="denflot" id="divTradePwd">
            交易密码
            <asp:HiddenField ID="hfTradePwd" runat="server" />
        </div>
        <div class="denflot dtwo">
            <ul>
                <li>交易密码能为您提供额外的安全保障。启用交易密码，为你的交易保驾护航。</li>
                <li><span class="orange">与登录密码不同，交易密码仅在进行店铺管理，金额支付等操作时才需要输入。</span></li>
            </ul>
        </div>
        <div class="denflot dthree">
            <a href="<% =Url2 %>" class="xiug" target="win" onclick="subItem(this)">设置
            </a>
        </div>
    </div>
    <div class="dengl">
        <div class="denflot done" id="div1">
            设置资金保护
            <asp:HiddenField ID="HiddenField1" runat="server" />
        </div>
        <div class="denflot dtwo">
            <ul>
                <li>开启后转账、提现需要短信验证</li>
                <li><span class="orange">开启后可以在此处进行关闭</span></li>
            </ul>
        </div>
        <div class="denflot dthree">
            <a href="A_ProtectingTheDeal.aspx" class="xiug" target="win" onclick="subItem(this)">设置
            </a>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
    $(function () {
        //设置过交易密码跟换样式
        if ($("#<%= hfTradePwd.ClientID %>").val() == "0") {
            $("#divTradePwd").addClass("done2");
        }
        else {
            $("#divTradePwd").addClass("done");
        }
    })
    
</script>
