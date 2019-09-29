<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<script type="text/javascript" language="javascript">
    //首页搜索切换JS
    function chang(value) {
        for (var i = 1; i <= 5; i++) {
            document.getElementById("hh" + i).className = "";
        }
        //	 document.getElementById("TopSearchShou_ctl00_HiddenSwitchType").value=value;
        document.getElementById("TopSearch_ctl00_HiddenSwitchType").value = value;
        document.getElementById("hh" + value).className = "cur";
    }
  
</script>
<style type="text/css">
    .FormBox
    {
        background: url(Themes/Skin_Default/Images/lmf_search.png) no-repeat left top;
        width: 482px;
        height: 32px;
        margin-top: -3px;
    }
    .switchover
    {
        position: relative;
        z-index: 22;
    }
    #mq, .txtinput
    {
        border: none;
        background: none;
    }
    .mallSearch_input
    {
        background: none;
    }
    #mallSearch button, .search_buttom
    {
        width: 96px;
        height: 26px;
        margin-top: 3px;
        margin-right: 3px;
    }
    #mq, .txtinput
    {
        padding-top: 6px;
        font-size: 12px;
        font-weight: normal;
        color: #666666;
    }
    .search_buttom:hover
    {
        background: url(Themes/Skin_Default/Images/sear_bt_hov.png) no-repeat left top;
    }
    .mallSearch
    {
        margin-left: 105px;
    }
</style>
<div class="mallSearch" id="mallSearch">
    <div class="switchover">
        <ul>
            <li><a id="hh1" class="cur" onclick="chang(1)">宝贝</a> </li>
            <li><a id="hh2" class="" onclick="chang(2)">店铺</a> </li>
            <li><a id="hh3" class="" onclick="chang(3)">资讯</a> </li>
            <li><a id="hh4" class="" onclick="chang(4)">分类</a> </li>
            <li><a id="hh5" class="" onclick="chang(5)">供求</a> </li>
        </ul>
    </div>
    <div class="FormBox">
        <div class="mallSearch_input clearfix">
            <label for="mq" style="visibility: visible;">
            </label>
            <input class="txtinput" type="text" name="textfield" id="textfield" maxlength="50"
                style="width: 368px!important; border: none!important; outline: none; resize: none;" />
            <asp:Button ID="ButtonSearch" Text="" runat="server" CssClass="search_buttom" CausesValidation="false" />
        </div>
    </div>
</div>
<asp:HiddenField ID="HiddenSwitchType" runat="server" Value="1" />
