<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript">
    function GotoUrl() {
        var url = window.location.href;
        return url;
    }

</script>
<div class="gmcg">
    <div class="chengcg">
        恭喜您！注册成功</div>
    <div class="mailaver">
        <p>
            您登陆本商城的用户名为：<span class="mailadd">123456@qq.com</span>，您随时可以使用此用户名享受便宜又放心的购物乐趣。</p>
        <div style="margin-top: 20px;">
            <asp:Button ID="Button2" runat="server" Text="进入会员中心" CssClass="emialbtn2" PostBackUrl="~/index.aspx" />
            <asp:Button ID="Button1" runat="server" Text="立即去购物" CssClass="emialbtn" PostBackUrl="~/Default.aspx" /></div>
    </div>
    <div class="clear">
    </div>
</div>
