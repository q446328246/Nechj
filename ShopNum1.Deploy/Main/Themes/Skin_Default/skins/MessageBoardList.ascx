<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<script type="text/javascript">
    var v_display = "手机、邮箱或QQ等";
    $(function() {
        $("#<%= txtRemark.ClientID  %>").val("");
        $("#<%= txtMobile.ClientID  %>").val(v_display);
        $("#<%= txtMobile.ClientID  %>").addClass("MobileCss");

        $(".PopSuggest .bckfont").focus(function() {
            if ($(this).val() == v_display) {
                $(this).val("");
                $(this).removeClass("MobileCss");
            }
        });
        $(".PopSuggest .bckfont").blur(function() {
            if ($(this).val() == "") {
                $(this).addClass("MobileCss");
                $(this).val(v_display);
            }
        });
    });

    function WindonSubmit() {
        $("#spanShow").hide();
        $("#spanMobile").hide();
        if ($("#<%= txtMobile.ClientID  %>").val() == v_display || $("#<%= txtRemark.ClientID  %>").val() == "") {
            $("#spanShow").show();
            return false;
        }
        if (!ExistMobile()) {
            $("#spanMobile").show();
            return false;
        }
        return true;
    }

    function ExistMobile() {
        var regM = new RegExp("^(1[3|5|7|8][0-9])\\d{8}$"); //手机号码
        var regQ = new RegExp("^[1-9]\\d{3,}$"); //QQ号码
        var regE = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/; //电子邮箱 
        var v_mobile = $("#<%= txtMobile.ClientID  %>").val();
        if (!regM.test(v_mobile) && !regQ.test(v_mobile) && !regE.test(v_mobile)) {
            return false;
        }
        return true;
    }
    
</script>
<style type="text/css">
    .MobileCss
    {
        color: #b3b3b3;
    }
</style>
<div>
    <a class="close">×</a>
    <p>
        写下您的意见反馈或金点子<span>(如果建议被采纳将有机会获得奖励哦！)</span></p>
    <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" MaxLength="4000"></asp:TextBox>
    <p>
        联系方式
    </p>
    <asp:TextBox ID="txtMobile" runat="server" CssClass="bckfont" MaxLength="50"></asp:TextBox>
    <span id="spanMobile" style="color: Red; display: none; font-size: 9pt;">请填写正确的联系方式！</span>
    <p>
        <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="submit-suggestion"
            BorderWidth="0" OnClientClick="return WindonSubmit()" />
        <span id="spanShow" style="display: none; color: Red;">请填写建议和联系方式！</span>
    </p>
</div>
