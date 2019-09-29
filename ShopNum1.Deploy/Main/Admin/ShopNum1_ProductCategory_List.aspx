<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopNum1_ProductCategory_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopNum1_ProductCategory_List" %>

<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>商品分类列表</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script src="js/dragbox/Shopnum1.Dialog.min.js" type="text/javascript"> </script>
    <link rel="stylesheet" type="text/css" href="js/dragbox/Shopnum1.DragBox.min.css" />
    <link rel="stylesheet" type="text/css" href="style/Shopnum1.treelist.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    商品分类列表</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td style="border: none;">
                            <a href="ShopNum1_ProductCategory_Operate.aspx?guid=0&tc=true&width=810&height=500"
                                class="tianjiafl lmf_btn dialog"><span>添加目录</span></a>
                        </td>
                        <td>
                            (友情提示：如果分类下面有子分类或者该分类下面有商品，则删除按钮隐藏。)*
                        </td>
                        <td style="border: none; display: none; padding-left: 10px;">
                            <a href="#" class="guanlikj lmf_btn cporder"><span>批量保存</span></a>
                        </td>
                    </tr>
                </table>
            </div>
            <table cellpadding="0" cellspacing="0" border="0" width="98%" class="gridview_m"
                style="border: none; margin: 0 auto;">
                <tr class="list_header">
                    <th style="text-align: left;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;分类排序&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;分类名称
                    </th>
                    <th>
                        Code
                    </th>
                    <th>
                        是否在前台显示
                    </th>
                    <th>
                        操作
                    </th>
                </tr>
                <% if (dataTable != null)
                   {
                       foreach (DataRow dataRow in dataTable.Rows)
                       { %>
                <tr class="one lmf_huaguo" id='parent_<%= dataRow["ID"] %>'>
                    <td align="left" valign="top">
                        <div class="lmf_jia fl">
                            <% if (dataRow["v"].ToString() != "")
                               { %>
                            <img style="border-width: 0px;" src="images/lmf_jia.jpg" onclick=' funsub(this, <%= dataRow["ID"] %>) '>
                            <% }
                               else
                               { %>
                            <span style="display: block; height: 20px; width: 13px;">&nbsp;</span>
                            <% } %>
                        </div>
                        <div class="lmf_xuanze fl" style="display: none">
                            <input type="checkbox" class="checkboxsn vcheck" onclick=" checksub(this, '<%= dataRow["ID"] %>') "
                                value='<%= dataRow["ID"] %>' /></div>
                        <div class="lmf_paixu fl">
                            <input type="text" name="orderby" style="width: 60px;" maxlength="8" onkeyup=" NumTxt_Int(this) "
                                lang='<%= dataRow["ID"] %>' value='<%= dataRow["OrderID"] %>' /></div>
                        <div class="lmf_titlee fl">
                            <input type="text" value='<%= dataRow["Name"] %>' /></div>
                    </td>

                    <td align="left" valign="top">
                        
                        <div class="lmf_titlee fl">
                             <input type="text" value='<%= dataRow["Code"] %>' /></div>
                        </div>
                    </td>

                    <td align="center" valign="top" width="100px">
                        <% if (dataRow["isshow"].ToString() == "1")
                           { %>
                        <img style="border-width: 0px;" src="images/dui.jpg" class="isshow" lang='<%= dataRow["ID"] + "-" %><%= dataRow["isshow"] %>' />
                        <% }
                           else
                           { %>
                        <img style="border-width: 0px;" src="images/cuo.jpg" class="isshow" lang='<%= dataRow["ID"] + "-" %><%= dataRow["isshow"] %>' />
                        <% } %>
                    </td>
                    <td align="center" valign="top" width="300px">
                        <a href="#" class="saveedit" style="color: #4482b4;" lang='<%= dataRow["ID"] %>'
                            onclick=" treelist_save(this) ">保存</a>&nbsp; <a href="ShopNum1_ProductCategory_Operate.aspx?op=edit&guid=<%= dataRow["ID"] %>&tc=true&width=810&height=500"
                                class="dialog" style="color: #4482b4;">编辑</a>&nbsp;
                        <% if (dataRow["m"].ToString() == "")
                           { %>
                        <a href="#" style="color: #4482b4;" lang='<%= dataRow["ID"] %>' class="delv" onclick=" treelist_delete(this) ">
                            删除</a>&nbsp;
                        <% } %>
                        <a href='ShopNum1_ProductCategory_Operate.aspx?op=add&guid=<%= dataRow["ID"] %>&level=1&width=810&height=500'
                            class="dialog" style="color: #4482b4;">添加子分类</a>
                    </td>
                </tr>
                <tr style="display: none;" class="two" id='sub_two_<%= dataRow["ID"] %>'></tr>
                <% }
                   } %>
                <tr class="lmf_page" style="background: #e8e8e8; display: none;">
                    <td valign="top" align="left" style="background: #e8e8e8; padding: 0 20px;" colspan="3">
                        <div class="fl">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="background: #e8e8e8; border: none; padding-left: 10px;">
                                        <a href="ShopNum1_ProductCategory_Operate.aspx?guid=0&width=810&height=500" class="tianjiafl lmf_btn dialog">
                                            <span>添加目录</span></a>(友情提示：如果分类下面有子分类或者该分类下面有商品，删除按钮隐藏。)
                                    </td>
                                    <td style="background: #e8e8e8; border: none; padding-left: 10px;">
                                        <a href="#" class="tianjiafl lmf_btn cporder"><span>保存排序</span></a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <script type="text/javascript">
        function NumTxt_Int(o) {
            o.value = o.value.replace(/\D/g, '');
        }

        var ajaxurl = "/Api/GetProductType.ashx";

        function treelist_two_html(arry) {
            var xhtml = '<td align="left" valign="top" colspan="3" style="padding: 0; border: 0;">';
            xhtml += '<table cellpadding="0" cellspacing="0" border="0" width="100%" class="sub_lmf">';
            xhtml += '<tr class="sublmf_huaguo" id="delete_this_' + arry.id + '">';
            xhtml += '<td align="left" valign="top">';
            xhtml += '<div class="sublmf_jia fl" onclick="funthreesub(this,' + arry.id + ')">';
            if (arry.v != "") {
                xhtml += '<img style="border-width: 0px;" src="images/lmf_jia.jpg"/>';
            } else {
                xhtml += '<span style="width:13px; display:block; height:20px;">&nbsp;</span>';
            }
            xhtml += '</div><div class="sublmf_xuanze fl" style="display:none"><input type="checkbox" value="' + arry.id + '" onclick="treelist_subcheck(this)"  lang="c_' + arry.id + '" class="c_p vcheck"/></div>';
            xhtml += '<div class="sublmf_paixu fl">';
            xhtml += '<input type="text" name=\"orderby\" style="width:60px;" maxlength="8" onkeyup="NumTxt_Int(this)" value="' + arry.orderid + '" lang="' + arry.id + '"/></div>';
            xhtml += '<div class="sublmf_titlee fl">';
            xhtml += '<input type="text" value="' + arry.name + '" /></div>';
            xhtml += '<div class="sublmf_titlee fl">';
            xhtml += '<input type="text" value="' + arry.code + '" /></div>';
            xhtml += '</td>';

            xhtml += '<td align="center" valign="top" width="100px">';
            if (arry.isshow == 1) {
                xhtml += '<img style="border-width: 0px;" src="images/dui.jpg" onclick="treelist_isshow(this)" class="isshow" lang="' + arry.id + '-' + arry.isshow + '">';
            } else {
                xhtml += '<img style="border-width: 0px;" src="images/cuo.jpg" onclick="treelist_isshow(this)" class="isshow" lang="' + arry.id + '-' + arry.isshow + '">';
            }
            xhtml += '</td>';
            xhtml += '<td align="center" valign="top" width="300px">';
            xhtml += '<a class="saveedit" href="#" lang="' + arry.id + '" style="color: #4482b4;" onclick="treelist_save(this)">保存</a>&nbsp;';
            xhtml += '<a href="#" lang="ShopNum1_ProductCategory_Operate.aspx?op=edit&guid=' + arry.id + '&width=810&height=500" onclick="treelist_edit(this,0)" class="dialog vdr" style="color: #4482b4;">编辑</a>&nbsp;';
            if (arry.m == "") {
                xhtml += '<a href="#" lang="' + arry.id + '" class="delv" style="color: #4482b4;" onclick="treelist_delete(this)">删除</a>&nbsp;';
            }
            xhtml += '<a href="#" lang="ShopNum1_ProductCategory_Operate.aspx?op=add&level=2&guid=' + arry.id + '&width=810&height=500" class="dialog vdr" onclick="treelist_edit(this,1)" style="color: #4482b4;">添加子分类</a>';
            xhtml += '</td>';
            xhtml += '</tr>';
            xhtml += '<tr style="display:none;" class="three" id="two_three_' + arry.id + '"></tr>';
            return xhtml;
        }

        function treelist_three_html(arry) {
            var xhtml = "";
            xhtml += '<tr class="subsublmf_huaguo" id="delete_this_' + arry.id + '">';
            xhtml += '<td align="left" valign="top">';
            xhtml += '<div class="subsublmf_xuanze fl">';
            xhtml += '<input type="checkbox" value="' + arry.id + '" class="c_t vcheck" onclick="treelist_subcheck(this)" style="display:none"/></div><div></div>';
            xhtml += '<div class="sublmf_paixu fl">';
            xhtml += '<input type="text" name=\"orderby\" style="width:60px;" maxlength="8" onkeyup="NumTxt_Int(this)" value="' + arry.orderid + '" lang="' + arry.id + '" /></div>';
            xhtml += '<div class="subsublmf_titlee fl">';
            xhtml += '<input type="text" value="' + arry.name + '" /></div>';
            xhtml += '<div class="sublmf_titlee fl">';
            xhtml += '<input type="text" value="' + arry.code + '" /></div></td>';
            xhtml += '<td align="center" valign="top" width="100px">';
            if (arry.isshow == "1") {
                xhtml += '<img style="border-width: 0px;" onclick="treelist_isshow(this)" lang="' + arry.id + '-' + arry.isshow + '" class="isshow" src="images/dui.jpg">';
            } else {
                xhtml += '<img style="border-width: 0px;" class="isshow" onclick="treelist_isshow(this)" lang="' + arry.id + '-' + arry.isshow + '" src="images/cuo.jpg">';
            }
            xhtml += '</td><td align="center" valign="top" width="300px">';
            xhtml += '<a class="saveedit" href="#" lang="' + arry.id + '" style="color: #4482b4;" onclick="treelist_save(this)">保存</a>&nbsp;';
            xhtml += '<a href="#" lang="ShopNum1_ProductCategory_Operate.aspx?op=edit&guid=' + arry.id + '&width=810&height=500" class="dialog vdr" onclick="treelist_edit(this,0)" style="color: #4482b4;">编辑</a>&nbsp;';
            if (arry.m == "") {
                xhtml += '<a href="#" lang="' + arry.id + '" class="delv" style="color: #4482b4;" onclick="treelist_Threedelete(this)">删除</a>';
            }
            xhtml += '</td></tr>';
            return xhtml;
        }

        //opener.getElementById("loadMask").style.display="none";
        $(function () {
            //滑过效果
            $(".lmf_huaguo").hover(function () { $(this).addClass("lmf_hover"); },
                        function () { $(this).removeClass("lmf_hover"); });
            $(".sublmf_huaguo").hover(function () { $(this).addClass("lmf_hover"); },
                        function () { $(this).removeClass("lmf_hover"); });
            $(".subsublmf_huaguo").hover(function () { $(this).addClass("lmf_hover"); },
                        function () { $(this).removeClass("lmf_hover"); }); //更改展开收缩图标
            $(".lmf_jia").click(function () {
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
            $(".sublmf_jia").click(function () {
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
            //$(o).toggle(function(){$(o).attr("src","images/lmf_jia.jpg");},function(){$(o).attr("src","images/lmf_jian.jpg");});
            if ($("#sub_two_" + parentid).html() == "") {
                $.get(ajaxurl + "?parentid=" + parentid + "", null, function (data) {
                    var typedata = eval('(' + data.split("&&")[0] + ')');
                    var arry = new Array();
                    $.each(typedata, function (m, n) {
                        arry.push(treelist_two_html(n));
                    });
                    arry.push('</table></td>');
                    $("#sub_two_" + parentid).html(arry.join(""));
                });
            }
            //       $("#sub_two_"+parentid).html("<img src='images/ajax_loading.gif'/>");
            //       // $("#sub_two_"+parentid).live('click',mytoggle).trigger('click'); 
            //       $.get(ajaxurl+"?parentid="+parentid+"",null,function(data){
            //               var typedata=eval('('+data.split("&&")[0]+')');
            //               var arry=new Array();
            //               $.each(typedata,function(m,n){
            //                     arry.push(treelist_two_html(n.id,n.name,n.orderid,n.isshow,n.v));
            //               }); 
            //               arry.push('</table></td>');
            //               $("#sub_two_"+parentid).html(arry.join(""));
            //       });
            //        if($("#sub_two_"+parentid).attr("style").indexOf("none")!=-1)
            //        {
            //            //$(o).children("img").attr("src","images/lmf_jia.jpg");
            //            $("#sub_two_"+parentid).hide();
            //        }
            //        else
            //        {
            //            //$(o).children("img").attr("src","images/lmf_jian.jpg");
            //            $("#sub_two_"+parentid).show();
            //        }
        }

        //获取三级分类

        function funthreesub(o, parentid) {
            if ($("#two_three_" + parentid).html() == "") {
                $.get(ajaxurl + "?parentid=" + parentid + "", null, function (data) {
                    var typedata = eval('(' + data + ')');
                    var arry = new Array();
                    arry.push('<td align="left" valign="top" colspan="3" style="padding: 0; border: 0;">');
                    arry.push('<table cellpadding="0" cellspacing="0" border="0" width="100%" class="subsub_lmf"><tr style="display:none"></tr>');
                    $.each(typedata, function (m, n) {
                        arry.push(treelist_three_html(n));
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
            $.get(ajaxurl + "?savedata=" + escape(adata), null, function (data) {
            });
            alert("保存成功！");
            return false;
        }

        //删除

        function treelist_delete(o) {
            if (confirm("是否确定删除？")) {
                $this = $(o);
                $.get(ajaxurl + "?delectid=" + $this.attr("lang"), null, function (data) {
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

        function treelist_Threedelete(o) {
            if (confirm("是否确定删除？")) {
                $this = $(o);
                $.get(ajaxurl + "?delectid=" + $this.attr("lang"), null, function (data) {
                    if (data.split("|")[0] != "ok") {
                        var arr = data.split("|")[1].split(",");
                        for (var i in arr) {
                            $("#delete_this_" + arr[i]).remove();
                        }
                        window.location.reload();
                        alert("删除成功,部分分类不能删除！");
                    } else {
                        //$this.parents().find("#two_three_"+$this.val()).hide();
                        $this.parent().parent().hide();
                    }
                });
            }
        }

        //是否显示

        function treelist_isshow(o) {
            var id = $(o).attr("lang").split('-')[1];
            id = id == "1" ? "0" : "1";
            $.get(ajaxurl + "?isshow=" + $(o).attr("lang").split('-')[0] + "-" + id, null, function (data) {
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
            $m_two.each(function () {
                $("#two_three_" + $(this).val()).find(".c_t").attr("checked", $(this).is(":checked"));
            });
            $("#two_three_" + v).find(".c_t").attr("checked", $(this).is(":checked"));
        }

        $(function () {
            var flag = true;
            //批量保存操作
            $(".cporder").click(function () {
                var append = new Array();
                $(".vcheck").each(function (m, n) {
                    if ($(this).is(":checked")) {
                        append.push($(this).val() + "|" + $(this).parent().next().find("input").val() + "|" + $(this).parent().next().next().find("input").val());
                    }
                });
                if (append.join(",") == "") {
                    alert("请勾选一条你要保存的数据！");
                    return false;
                }
                $.get(ajaxurl + "?vd=" + escape(append.join(",")), null, function (data) {
                });
                alert("批量保存成功！");
                return false;
            });
            //背景特效
            //         $('.subsublmf_huaguo,.sublmf_huaguo').live('mouseover',function(event){
            //	           $(this).addClass("lmf_hover");
            //         }).live('mouseout',function(event){
            //	         $(this).removeClass("lmf_hover");
            //         });
        });
    </script>
    </form>
</body>
</html>
