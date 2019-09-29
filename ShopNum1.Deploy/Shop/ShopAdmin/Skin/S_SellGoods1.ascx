<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<div style="background: #fff; border: 1px solid #008800; display: none; height: 30px;
    left: 600px; line-height: 30px; position: absolute; text-align: center; top: 500px;
    width: 90px;" id="popload">
    <img src="images/loading.gif" />加载中...
</div>
<div class="con_order">
    <!--步骤-->
    <div class="buzho">
        <ul>
            <li>
                <img src="images/buzho01_1.jpg" width="317" height="51" /></li>
            <li>
                <img src="images/buzho02.jpg" width="388" height="51" /></li>
            <li>
                <img src="images/buzho03.jpg" width="295" height="51" /></li>
        </ul>
    </div>
    <div>
        <table width="100%" border="0" cellspacing="15" cellpadding="0" class="shangpss">
            <tr>
                <td align="right" width="32%" style="height: 54px;">
                    <img src="images/fenleisous.jpg" width="110" height="33" />
                </td>
                <td align="center" width="36%">
                    <input name="" type="text" class="shoustext" onkeydown=" KeyEnter(event) " />
                </td>
                <td align="left" width="32%">
                    <input name="" id="skgo" type="button" value=" " class="sousbt" />
                </td>
            </tr>
        </table>
    </div>
    <div class="back_to_sort" style="display: none;">
        <a href="JavaScript:void(0);"><< 返回商品分类选择</a>
    </div>
    <div class="leimxz" style="display: none">
        <span style="vertical-align: 4px;">您经常使用的类目：</span>
        <select name="sel" size="1" class="tselect" style="width: 260px;">
            <option value="1">--请选择--</option>
            <option value="2">卖家</option>
            <option value="3">卖家</option>
        </select>
        <span>&nbsp;</span>
    </div>
    <!--选择商品-->
    <div class="quzsp" style="margin-top: 12px;">
        <div class="quz" id="quz_1">
            <ul>
                <%
                    DataTable dTable = S_SellGoods1.dt_ParentType;
                    if (dTable != null)
                    {
                        for (int i = 0; i < dTable.Rows.Count; i++)
                        { %>
                <li id='<%= dTable.Rows[i]["code"] %>' lang="<%= dTable.Rows[i]["categorytype"] %>"
                    code='<%= dTable.Rows[i]["code"] %>' onclick=" GetSubType(this, 1) "><a href="javascript:void(0)"
                        class="shangpa">
                        <%= dTable.Rows[i]["name"] %></a> </li>
                <% }
                    } %>
            </ul>
            <div id="div_1" style="display: none">
                <li></li>
            </div>
            <%--   <script type="text/javascript" language="javascript" src="js/S_SellGoods1.js"></script>--%>
            <script type="text/javascript" language="javascript">
                function KeyEnter(o) {
                    if (o.keyCode == 13) {
                        document.getElementById("skgo").focus();
                        $("#skgo").click();
                    }
                }

                $(function () {
                    $(".buzhx_btn").hide();
                    //分类搜索
                    $(".sousbt").click(function () {
                        $(".back_to_sort").show();
                        $(".quz,.quz_lw").hide();
                        $(".quz_typelw").show();
                        var xhtml = new Array();
                        var sk = $(".shoustext").val();
                        $.get("/Api/S_OpGoods1.ashx?type=2&keyword=" + escape(sk), null, function (data) {
                            if (data != "") {
                                var typedata = eval('(' + data + ')');
                                var xhtml = new Array();
                                $.each(typedata, function (m, n) {
                                    xhtml.push('<li id="' + n.id + '" lang="' + n.categorytype + '" code="' + n.code + '" onclick="GetSubType(this,4)"><a href="javascript:void(0)" class="shangpa">' + n.typename.replace(sk, "<font color='red'>" + sk + "</font>") + '</a></li>');
                                });
                                $(".quz_typelw ul").html(xhtml.join(""));
                            }

                        });
                        $(".buzhx_btn").show();
                    });
                    //重新设置分类
                    $("#reSet,.back_to_sort").click(function () {
                        $(this).hide();
                        $(".quz,.quz_lw").show();
                        $(".quz_typelw").hide();
                    });
                    //选择好分类跳转页面
                    $(".buzhx_btn").click(function () {
                        var id = $("#hidID").val();
                        var type = $("#hidType").val();
                        var code = $("#hidCode").val();
                        if (id != "") {
                            var pid = '<%= ShopNum1.Common.Common.ReqStr("pid") == "" ? "0" : ShopNum1.Common.Common.ReqStr("pid") %>';
                            location.href = "S_SellGoods_Two.aspx?op=add&step=two&cid=" + id + "&ctype=" + type + "&pid=" + pid + "&code=" + code;
                            return false;
                        } else {
                            alert("请选择分类！");
                            return false;
                        }
                    });
                });

                //操作选择分类联动 

                function GetSubType(o, type) {
                    var id = $(o).attr("id");
                    var code = $(o).attr("code");
                    var typex = $(o).attr("lang");
                    typex = typex == "" ? "0" : typex;
                    $("#hidType").val(typex);
                    $("#hidCode").val(code);
                    $("#hidID").val(id);
                    $("#popload").show();
                    if (type == "1") {
                        $("#quz_2 ul").html("");
                        $("#quz_3 ul").html("");
                        $(o).parent().find("a").removeClass("typehover");
                        $(o).find("a").addClass("typehover");
                        $("#quz_" + parseInt(parseInt(type) + 1)).removeClass("quz_lw").addClass("quz");
                        $(".shangpts_bot").text("您当前选择的商品类别是:" + $(o).find("a").text());
                    } else if (type == "2") {
                        $("#quz_" + parseInt(parseInt(type) + 1)).removeClass("quz_lw").addClass("quz");
                        $("#quz_2 a").removeClass("typehover");
                        $(o).find("a").addClass("typehover");
                        var type1 = $(".quzsp div").eq(0).find(".typehover").text();
                        var type2 = $("#quz_2 a.typehover").text();
                        $(".shangpts_bot").text("您当前选择的商品类别是:" + type1 + " > " + type2);
                    } else if (type == "3") {
                        $("#quz_3 a").removeClass("typehover");
                        $(o).find("a").addClass("typehover");
                        var type1 = $(".quzsp div").eq(0).find(".typehover").text();
                        var type2 = $(".quzsp #quz_2 a.typehover").text();
                        var type3 = $(".quzsp #quz_3 a.typehover").text();
                        $(".shangpts_bot").text("您当前选择的商品类别是:" + type1 + " > " + type2 + " > " + type3);
                        $("#popload").hide();
                        $(".buzhx_btn").show();
                        return false;
                    } else {
                        $(".shangpts_bot").text("您当前选择的商品类别是:" + $(o).find("a").text());
                        $("#popload").hide();
                        return false;
                    }
                    if ($("#div_" + id).text() != "") {
                        $("#popload").hide();
                        $("#quz_" + parseInt(parseInt(type) + 1)).find("ul").html($("#div_" + id).html());
                        return false;
                    }
                    $.get("/Api/S_OpGoods1.ashx?type=1&id=" + id, null, function (data) {
                        if (data != "error") {
                            if (data == "") {
                                $("#popload").hide();
                                $(".buzhx_btn").show();
                                return false;
                            } else {
                                $(".buzhx_btn").hide();
                                $("#quz_3 ul").html("");
                            }

                            var typedata = eval('(' + data + ')');
                            var xhtml = new Array();
                            $.each(typedata, function (m, n) {
                                if (type == "1") {
                                    xhtml.push('<li id="' + n.code + '" lang="' + n.categorytype + '" code="' + n.code + '" onclick="GetSubType(this,2)"><a href="javascript:void(0)" class="shangpa">' + n.name + '</a></li>');
                                } else if (type == "2") {
                                    xhtml.push('<li id="' + n.code + '" lang="' + n.categorytype + '" code="' + n.code + '" onclick="GetSubType(this,3)"><a href="javascript:void(0)" class="shangpa">' + n.name + '</a></li>');
                                }
                            });
                            $("body").append("<div id='div_" + id + "' style='display:none'>" + xhtml.join("") + "</div>");
                            $("#quz_" + parseInt(parseInt(type) + 1)).find("ul").html(xhtml.join(""));
                            $("#popload").hide();
                        } else {
                            $("#quz_2 ul").html("");
                            $("#quz_3 ul").html("");
                        }
                    });

                }
            </script>
        </div>
        <div class="quz_lw" id="quz_2">
            <ul>
            </ul>
        </div>
        <div class="quz_lw" id="quz_3">
            <ul>
            </ul>
        </div>
        <div style="clear: both;">
        </div>
        <div class="quz_typelw" style="background: #ffffff; display: none; margin: 10px 18px;">
            <ul style="margin: 20px;">
                <li>
                    <input type="button" value="重新选择分类" id="reSet" /></li>
            </ul>
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <div class="shangpts">
    </div>
    <div class="shangpts_bot">
        <font color="red">请选择商品类别</font>
    </div>
    <div class="buzobtn">
        <button class="buzhx_btn">
        </button>
        <input type="hidden" id="hidID" />
        <input type="hidden" id="hidType" />
        <input type="hidden" id="hidCode" />
    </div>
</div>
<style type="text/css">
    .shoustext
    {
        background: none;
        background: url(../ShopAdmin/images/shangswen.jpg) no-repeat 0 0;
        border: none;
        color: #666;
        height: 31px;
        line-height: 31px;
        padding-left: 10px;
        width: 357px;
    }
    
    .sousbt
    {
        background: none;
        background: url(../ShopAdmin/images/shangssbtn.jpg) no-repeat 0 0;
        border: none;
        height: 31px;
        width: 62px;
    }
    
    .buzhx_btn
    {
        background: url(../ShopAdmin/images/nextx_btn.jpg) no-repeat 0 0;
        border: none;
        cursor: pointer;
        height: 39px;
        width: 148px;
    }
    
    .shangpts
    {
        background: url(../ShopAdmin/images/xuants_bg.jpg) no-repeat 0 0;
        height: 9px;
        margin-top: 10px;
    }
</style>
