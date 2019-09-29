  //opener.getElementById("loadMask").style.display="none";
    $(function() {
        //滑过效果
        $(".lmf_huaguo").hover(function() { $(this).addClass("lmf_hover"); },
            function() { $(this).removeClass("lmf_hover"); });
        $(".sublmf_huaguo").hover(function() { $(this).addClass("lmf_hover"); },
            function() { $(this).removeClass("lmf_hover"); });
        $(".subsublmf_huaguo").hover(function() { $(this).addClass("lmf_hover"); },
            function() { $(this).removeClass("lmf_hover"); }); //更改展开收缩图标
        $(".lmf_jia").click(function() {
            if ($(this).parents(".lmf_huaguo").next("tr").is(":visible")) {
                $(this).children("img").attr("src", "images/lmf_jia.jpg");
                $(this).parents(".lmf_huaguo").next("tr").hide();
            } else {
                $(this).children("img").attr("src", "images/lmf_jian.jpg");
                $(this).parents(".lmf_huaguo").next("tr").show();
                $(this).parents(".lmf_huaguo").find(".sublmf_huaguo").next("tr").hide();
            }
        });
//更改子菜单展开收缩图标
        $(".sublmf_jia").click(function() {
            if ($(this).parents(".sublmf_huaguo").next("tr").is(":visible")) {
                $(this).children("img").attr("src", "images/lmf_jia.jpg");
                $(this).parents(".sublmf_huaguo").next("tr").hide();
            } else {
                $(this).children("img").attr("src", "images/lmf_jian.jpg");
                $(this).parents(".sublmf_huaguo").next("tr").show();
            }
        });
    });


//var flagshow=true;    
//function mytoggle() { 
////   if(flagshow)
////   {
////      $(this).show();flagshow=false;
////   }
//    alert($(this).attr("style"));
//    $(this).attr("style","display:block");
//} 


    //获取二级分类

    function funsub(o, parentid) {
        if ($("#sub_two_" + parentid).html() == "") {
            $.get(ajaxurl + "?parentid=" + parentid + "", null, function(data) {
                var typedata = eval('(' + data.split("&&")[0] + ')');
                var arry = new Array();
                $.each(typedata, function(m, n) {
                    arry.push(treelist_two_html(n.id, n.name, n.orderid, n.isshow, n.v));
                });
                arry.push('</table></td>');
                $("#sub_two_" + parentid).show().html(arry.join(""));
            });
        }
    }

//获取三级分类

    function funthreesub(o, parentid) {
        if ($("#two_three_" + parentid).html() == "") {
            $.get(ajaxurl + "?parentid=" + parentid + "", null, function(data) {
                var typedata = eval('(' + data + ')');
                var arry = new Array();
                arry.push('<td align="left" valign="top" colspan="3" style="padding: 0; border: 0;">');
                arry.push('<table cellpadding="0" cellspacing="0" border="0" width="100%" class="subsub_lmf"><tr style="display:none"></tr>');
                $.each(typedata, function(m, n) {
                    arry.push(treelist_three_html(n.id, n.name, n.orderid, n.isshow));
                });
                arry.push("</table></td>");
                $("#two_three_" + parentid).show().html(arry.join(""));
            });
        }

        if ($(o).parents(".sublmf_huaguo").next("tr").is(":visible")) {
            $(o).children("img").attr("src", "images/lmf_jia.jpg");
            $("#two_three_" + parentid).hide();
        } else {
            $(o).children("img").attr("src", "images/lmf_jian.jpg");
            $("#two_three_" + parentid).show();
        }
    }

//编辑

    function treelist_edit(o, txt) {
        ECF.dialog.open($(o).attr("lang"), { width: 810, height: 500, title: txt == "0" ? "编辑子分类" : "添加子分类" });
    }

//保存

    function treelist_save(o) {
        var adata = $(o).attr("lang") + "|" + $(o).parent().prev().prev().find("input[name='orderby']").val() + "|" + $(o).parent().prev().prev().find("input[name='orderby']").parent().next().children("input").val();
        $.get(ajaxurl + "?savedata=" + escape(adata), null, function(data) {
        });
        alert("保存成功！");
        return false;
    }

//删除

    function treelist_delete(o) {
        if (confirm("是否确定删除？")) {
            $this = $(o);
            $.get(ajaxurl + "?delectid=" + $this.attr("lang"), null, function(data) {
                if (data.split("|")[0] != "ok") {
                    var arr = data.split("|")[1].split(",");
                    for (var i in arr) {
                        $("#delete_this_" + arr[i]).remove();
                    }
                    window.location.reload();
                    alert("删除成功,部分分类不能删除！");
                } else {
                    $this.parent().parent().next().hide();
                    $this.parents().find("#two_three_" + $this.val()).hide();
                    $this.parent().parent().hide();
                }
            });
        }
    }

//是否显示

    function treelist_isshow(o) {
        var id = $(o).attr("lang").split('-')[1];
        id = id == "1" ? "0" : "1";
        $.get(ajaxurl + "?isshow=" + $(o).attr("lang").split('-')[0] + "-" + id, null, function(data) {
        });
        if ($(o).attr("src") == "images/dui.jpg") {
            $(o).attr("src", "images/cuo.jpg");
            $(o).attr("lang", $(o).attr("lang").split('-')[0] + "-" + id);
        } else {
            $(o).attr("src", "images/dui.jpg");
            $(o).attr("lang", $(o).attr("lang").split('-')[0] + "-" + id);
        }
    }

//子菜单全选反选操作

    function treelist_subcheck(o) {
        $("#two_three_" + $(o).val()).find(".c_t").attr("checked", $(o).attr("checked"));
    }

//全选反选操作

    function checksub(o, v) {
        $m_two = $("#sub_two_" + v).find(".c_p");
        $m_two.attr("checked", $(o).is(":checked"));
        $m_two.each(function() {
            $("#two_three_" + $(this).val()).find(".c_t").attr("checked", $(this).is(":checked"));
        });
        $("#two_three_" + v).find(".c_t").attr("checked", $(this).is(":checked"));
    }

    $(function() {
        var flag = true;
        //批量保存操作
        $(".cporder").click(function() {
            var append = new Array();
            $(".vcheck").each(function(m, n) {
                if ($(this).is(":checked")) {
                    append.push($(this).val() + "|" + $(this).parent().next().find("input").val() + "|" + $(this).parent().next().next().find("input").val());
                }
            });
            if (append.join(",") == "") {
                alert("请勾选一条你要保存的数据！");
                return false;
            }
            $.get(ajaxurl + "?vd=" + escape(append.join(",")), null, function(data) {
            });
            alert("批量保存成功！");
            return false;
        });
        //背景特效
        $('.subsublmf_huaguo,.sublmf_huaguo').live('mouseover', function(event) {
            $(this).addClass("lmf_hover");
        }).live('mouseout', function(event) {
            $(this).removeClass("lmf_hover");
        });
    });