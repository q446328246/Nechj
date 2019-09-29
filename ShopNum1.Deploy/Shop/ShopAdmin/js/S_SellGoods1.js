$(function() {
    //分类搜索
    $(".sousbt").click(function() {
        $(".quz,.quz_lw").hide();
        $(".quz_typelw").show();
        var xhtml = new Array();
        var sk = $(".shoustext").val();
        $.get("/Api/S_OpGoods1.ashx?type=2&keyword=" + escape(sk), null, function(data) {
            if (data != "") {
                var typedata = eval('(' + data + ')');
                var xhtml = new Array();
                $.each(typedata, function(m, n) {
                    xhtml.push('<li id="' + n.id + '" lang="' + n.categorytype + '" code="' + n.code + '" onclick="GetSubType(this,4)"><a href="javascript:void(0)" class="shangpa">' + n.typename.replace(sk, "<font color='red'>" + sk + "</font>") + '</a></li>');
                });
                $(".quz_typelw ul").html(xhtml.join(""));
            }

        });
    });
    //重新设置分类
    $("#reSet,.back_to_sort").click(function() {
        $(".quz,.quz_lw").show();
        $(".quz_typelw").hide();
    });
    //选择好分类跳转页面
    $(".buzhx_btn").click(function() {
        var id = $("#hidID").val();
        var type = $("#hidType").val();
        var code = $("#hidCode").val();
        if (id != "") {
            location.href = "S_SellGoods_Two.aspx?op=add&step=two&cid=" + id + "&ctype=" + type + "&pid=0&code=" + code;
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
        $("#hidID").val("");
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
    $.get("/Api/S_OpGoods1.ashx?type=1&id=" + id, null, function(data) {
        if (data != "error") {
            if (data == "") {
                $("#popload").hide();
                $(".buzhx_btn").show();
                return false;
            }

            var typedata = eval('(' + data + ')');
            var xhtml = new Array();
            $.each(typedata, function(m, n) {
                if (type == "1") {
                    xhtml.push('<li id="' + n.id + '" lang="' + n.categorytype + '" code="' + n.code + '" onclick="GetSubType(this,2)"><a href="javascript:void(0)" class="shangpa">' + n.name + '</a></li>');
                } else if (type == "2") {
                    xhtml.push('<li id="' + n.id + '" lang="' + n.categorytype + '" code="' + n.code + '" onclick="GetSubType(this,3)"><a href="javascript:void(0)" class="shangpa">' + n.name + '</a></li>');
                }
            });
            $("body").append("<div id='div_" + id + "' style='display:none'>" + xhtml.join("") + "</div>");
            $("#quz_" + parseInt(parseInt(type) + 1)).find("ul").html(xhtml.join(""));
            $("#popload").hide();
        }
    });

}