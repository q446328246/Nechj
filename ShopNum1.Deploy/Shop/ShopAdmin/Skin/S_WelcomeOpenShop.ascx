<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="dpsc_mian5" style="width: 898px;">
    <div class="maiwh1" runat="server" id="divHaveOpen">
        店铺开启成功，请退出登录账号后重新登录！
    </div>
    <div runat="server" id="divHaveOpenNo"  >
        <%--<div runat="server" id="div1" style=" display:none;" >--%>
        <h1 class="maiwh1">
            欢迎来到商城系统卖家中心</h1>
        <h2 class="maiwh2">
            您现在还没有店铺，无法对卖家中心功能进行操作，您可以：</h2>
        <div class="maiwellb">
            <ul>
                <li class="mskd"><a href="" runat="server" id="LinkA"></a></li>
                <li>选择店铺等级并填写相关信息，即可开设您的店铺。</li>
            </ul>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
<script type="text/javascript" language="javascript">
    $(function () {
        $("#S_Left", window.parent.document).hide();
        $(".ifr_right", window.parent.document).attr("style", "float: right;width:100%;");
    });
</script>
