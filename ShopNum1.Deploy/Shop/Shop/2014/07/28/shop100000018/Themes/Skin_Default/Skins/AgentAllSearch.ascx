<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<script type="text/javascript">
$(document).ready(function(){
$(".search_buttom1").mouseover(function(){
$(".search_buttom1").addClass("search_buttom3");
}).mouseout(function(){
$(".search_buttom1").removeClass("search_buttom3");
});
$(".search_buttom").mouseover(function(){
$(".search_buttom").addClass("search_buttom2");
}).mouseout(function(){
$(".search_buttom").removeClass("search_buttom2");
});
});
</script>

<div class="FormBox">
    <div class="mallSearch_input clearfix">
        <!--文本框-->
        <asp:TextBox ID="TextBoxSearchWhere" runat="server" MaxLength="50" CssClass="txtinput"></asp:TextBox>
        <!--店内搜索-->
        <asp:Button ID="ButtonIn" runat="server" Text="" CssClass="search_buttom1" CausesValidation="False" OnClientClick='form.target="_blank";' />
         <!--店外-->
        <asp:Button ID="ButtonAllSearch" runat="server" Text="" CssClass="search_buttom" CausesValidation="False" OnClientClick='form.target="_blank";' />           
    </div>
</div>
<asp:hiddenfield id="HiddenSwitchType" runat="server" value="1" />
