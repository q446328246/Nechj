<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript">

    $(function () {

        if ($("#ArticleSearchNofind_ctl00_LabelProtectSearch").text() == "-1") {
            $("#nozixun").hide();
        }
    });
    function Btnclick() {
        var strProductName = document.getElementById("TextBoxProtectName").value.toLowerCase();
        if (strProductName.toLowerCase() == "search") {
            strProductName = "";
        }
        window.location.href = "/ArticleListSearch.aspx?search=" + strProductName.replace("/", "");
    }
</script>
<div class="warp_site">
    首页 》<a href="/News_List.html?tag=2">资讯</a></div>
<div class="nofind">
    <div class="nohead">
        <span class="nopic"></span>抱歉，没有找到<span id="nozixun">与“<asp:Label ID="LabelProtectSearch"
            runat="server" Text=""></asp:Label>”</span>相关的资讯哦，要不您换个关键词再找找看
    </div>
    <div class="nocont">
        <p class="nostrong">
            建议您：</p>
        <p>
            1、看看输入的文字是否有误</p>
        <p>
            2、调整关键字，如：“nokian97”改成“nokia n97”</p>
        <p>
            3、重新搜索</p>
        <div class="nosearch">
            <input id="TextBoxProtectName" type="text" class="noinput" />
            <input id="Button1" type="button" value="" class="nobtn" onclick="Btnclick()" />
        </div>
    </div>
</div>
