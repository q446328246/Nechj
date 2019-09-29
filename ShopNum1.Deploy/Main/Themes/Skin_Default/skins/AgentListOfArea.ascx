<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data" %>
<style type="text/css">
    .container
    {
        background: url(Themes/Skin_Default/images/diquimg.jpg) no-repeat left top;
        border: 1px solid #cccccc;
        width: 1188px;
        margin-top: 10px;
    }
    .con_h
    {
        font-size: 14px;
        font-family: "微软雅黑";
        color: #666666;
        font-weight: bold;
        height: 30px;
        line-height: 28px;
        padding-left: 38px;
    }
    .con_content
    {
        padding: 14px 14px 10px;
    }
    h5
    {
        color: #c7241b;
        font-size: 13px;
        font-family: "微软雅黑";
        font-weight: bold;
        border-bottom: 1px #e4e4e4 dashed;
        height: 30px;
        line-height: 30px;
        padding: 0;
        margin: 0;
        padding-left: 20px;
        float: none;
    }
    ul.con_gs
    {
        margin: 0;
        list-style: none;
        padding: 10px 0px 0 30px;
        clear: both;
        overflow: hidden;
        zoom: 1;
    }
    ul.con_gs li
    {
        margin: 0;
        list-style: none;
        padding-left: 15px;
        background: url(Themes/Skin_Default/images/dp_icon.jpg) no-repeat left 7px;
        height: 24px;
        line-height: 24px;
        display: block;
        float: left;
        min-width: 170px;
        _width: 170px;
    }
    ul.con_gs li a
    {
        color: #666666;
        font-size: 12px;
        text-decoration: none;
    }
    ul.con_gs li a:hover
    {
        color: #c7241b;
        font-size: 12px;
        text-decoration: underline;
    }
</style>
<div class="container" id="agentlist">
    <div class="con_h">
        <asp:Label ID="LabelLevel1AreaName" runat="server" Text=""></asp:Label>所在地</div>
    <div class="con_content">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <%#Eval("MemLoginID").ToString() == "" ? "" : "  <h5 areacode=\"" + Eval("areacodet").ToString() + "\">" + Eval("name").ToString() + "</h5>"%>
                <%#Eval("MemLoginID").ToString() == "" ? "" : "<ul class=\"con_gs\"> <li><a href=\"" + ShopUrlOperate.GetShopUrl(Eval("shopid").ToString()) + "\">" + Eval("RealName").ToString() + "</a></li></ul>"%>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
<script type="text/javascript">

    $(document).ready(function() {
        $("#agentlist .con_content").find("h5[areacode]").each(function(m) {
            var ah5code = $(this).attr("areacode");
            var newahcode = ah5code.substring(ah5code.indexOf(",") + 1, ah5code.lastIndexOf(","));
            $(this).attr("areacode", newahcode);
            var ah5txt = $(this).text();
            var newahtxt = ah5txt.substring(ah5txt.indexOf(",") + 1, ah5txt.lastIndexOf(","));
            $(this).text(newahtxt);
        });
        HeBingByLikeCode();
    });

    function HeBingByLikeCode() {
        var codes = $("#agentlist .con_content").find("h5[areacode]");
        codes.each(function(i) {
            var code = $(this).attr("areacode");
            if (code.length > 2) {
                var otherlikecode = $(this).siblings("h5[areacode='" + code + "']");

                if (otherlikecode != null && otherlikecode.length > 0) {
                    for (i = 0; i < otherlikecode.length; i++) {
                        if (code.length == otherlikecode.eq(i).attr("areacode").length) {
                            $(this).next("ul").append(otherlikecode.eq(i).next("ul").html());
                            otherlikecode.eq(i).next("ul").remove();
                            otherlikecode.eq(i).remove();
                        }
                    }

                    HeBingByLikeCode();
                }
            }
        });
    }

</script>
