<%@ Control Language="C#" ClassName="S_StoreProduct" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<%@ Import Namespace="ShopNum1.Common" %>
<script type="text/javascript" language="javascript">
    $(function () {
        //Ajax查询商品分类
        //           GetProductCategory("0","#tselect1");
        GetShopProductCategory("0", "#selectshopType1");
        //           $("#tselect1").change(function(){ $("#tselect2").html("<option value=\"00\">-请选择-</option>");
        //           $("#tselect3").html("<option value=\"00\">-请选择-</option>");
        //                var id=$(this).find("option:selected").val();
        //                 GetProductCategory(id,"#tselect2");
        //           });
        //            $("#tselect2").change(function(){
        //            $("#tselect3").html("<option value=\"00\">-请选择-</option>");
        //                var id=$(this).find("option:selected").val();
        //                 GetProductCategory(id,"#tselect3");
        //           });
        //全选反选
        $("input[name='checktop']").click(function () {
            $("input[name='checktop']").attr("checked", $(this).is(":checked"));
            $("input[name='subcheck']").attr("checked", $(this).is(":checked"));
        });
        $("#selectshopType1").change(function () {
            $("#selectshopType2").html("<option value=\"00\">-请选择-</option>");
            var id = $(this).find("option:selected").attr("lang");
            GetShopProductCategory(id, "#selectshopType2");
        });
        //批量删除
        $(".shanchu").click(function () {
            if (confirm("是否执行批量删除操作？")) {
                var arryid = new Array();
                var bflag = false;
                $("input[name='subcheck']").each(function () {
                    if ($(this).is(":checked")) {
                        arryid.push($(this).val());
                        bflag = true;
                    }
                });
                if (!bflag) {
                    alert("请选择一件商品进行操作！");
                    return false;
                }
                $.get("/Api/ShopAdmin/S_SellProduct.ashx?type=3&ids=" + arryid.join(","), null, function (data) {
                    for (var i in arryid) {
                        $("#tab_" + arryid[i]).hide();
                        $("#Maintab_" + arryid[i]).hide();
                    }
                });
                alert("删除成功！");
                $("input[name='subcheck']").removeAttr("checked");
                window.location.href = "S_StoreProduct.aspx";
                $("#tipmsg").show().find("font").text("删除成功！");
            }
        });
        //上架
        $(".shangj").click(function () {
            var arryid = new Array();
            var bflag = true;
            $("input[name='subcheck']").each(function () {
                if ($(this).is(":checked")) {
                    arryid.push($(this).val());
                    bflag = false;
                }
            });
            if (bflag) {
                alert("请勾选一条数据进行上架操作！");
                return false;
            }
            if (confirm("是否执行上架操作？")) {
                $.get("/Api/ShopAdmin/S_SellProduct.ashx?type=4&sale=1&ids=" + arryid.join(","), null, function (data) {
                    for (var i in arryid) {
                        $("#tab_" + arryid[i]).hide();
                        $("#Maintab_" + arryid[i]).hide();
                    }
                });
                alert("上架成功!");
                $("input[name='subcheck']").removeAttr("checked");
                $("#tipmsg").show().find("font").text("上架成功！");
                window.location.href = "S_StoreProduct.aspx";
            }
        });
        //搜索
        $("input[name='btnsearch']").click(function () {
            var pn = $("input[name='ProductName']").val();
            var no = $("input[name='Number']").val();
            var s1 = $("#tselect1").find("option:selected").val();
            var s2 = $("#tselect2").find("option:selected").val();
            var s3 = $("#tselect3").find("option:selected").val();
            var sname = "";
            if (s1 != "00") {
                sname = $("#tselect1").find("option:selected").text();
                if (s2 != "00") {
                    sname = $("#tselect2").find("option:selected").text();
                    if (s3 != "00") {
                        sname = $("#tselect3").find("option:selected").text();
                    }
                }
            }
            var scname = "";
            var shopct1 = $("#selectshopType1").find("option:selected").val();
            var shopct2 = $("#selectshopType2").find("option:selected").val();
            if (shopct1 != "00") {
                scname = $("#selectshopType1").find("option:selected").val();
                if (shopct2 != "00") {
                    scname = $("#selectshopType2").find("option:selected").val();
                }
            }
            location.href = "?no=" + escape(no) + "&pn=" + escape(pn) + "&shopct=" + escape(scname) + "&currentpage=1";
        });
        //双击修改
        $(".nosbe").dblclick(function () {
            $(this).find(".edit_name").hide();
            $(this).find(".edit_v").show();
        });
        $(".btn_save").click(function () {
            if ($(this).prev().val().length > 50 || $(this).prev().val().length < 3 && $(this).attr("name") == "name") {
                alert("商品标题名称长度至少3个字符，最长50个汉字!");
                return false;
            }
            if ($(this).attr("name") == "price" && !checkpriceTxt($(this).prev())) {
                alert("输入价格格式有误!");
                return false;
            }
            $.get("/Api/ShopAdmin/S_SellProduct.ashx?type=2&col=" + $(this).attr("name") + "&guid=" + $(this).attr("lang") + "&vl=" + escape($(this).prev().val()), null, function (data) {
            });
            $(this).parent().parent().find(".edit_name").text($(this).prev().val().substring(0, 10));
            $(this).parent().hide();
            $(this).parent().prev().show();
            $("#tipmsg").show().find("font").text("修改成功！");
        });
        //鼠标移动过来显示提示修改信息
        $(".nosbe").hover(function () { $(this).children("div").css("display", "block"); }, function () { $(this).children("div").css("display", "none"); });
    });
    //    function GetProductCategory(id,divid)
    //    {
    //         
    //         $.get("/Api/ShopAdmin/S_SellProduct.ashx?type=0&parentid="+id,null,function(data){
    //                  var vdata=eval('('+data+')');
    //                  var ts=new Array();
    //                  $.each(vdata,function(m,n){alert(n.code);
    //                      
    //                  });
    //                  $(divid).append(ts.join(""));
    //         }); 
    //    }

    function GetShopProductCategory(id, divid) {
        $.get("/Api/ShopAdmin/S_SellProduct.ashx?type=5&parentid=" + id, null, function (data) {
            var vdata = eval('(' + data + ')');
            var ts = new Array();
            $.each(vdata, function (m, n) {
                var ccode = '<%= ShopNum1.Common.Common.ReqStr("shopct") %>';
                var cvcode = '<%= ShopNum1.Common.Common.ReqStr("shopct") %>';
                if (cvcode == n.code) {
                    ts.push("<option value=\"" + n.code + "\" lang=\"" + n.id + "\" selected=\"selected\">" + n.name + "</option>");
                }
                if (ccode != "")
                    ccode = ccode.substring(0, 3);
                if (ccode == n.code) {
                    ts.push("<option value=\"" + n.code + "\" lang=\"" + n.id + "\" selected=\"selected\">" + n.name + "</option>");
                    GetShopProductCategory(n.id, "#selectshopType2");
                } else if (cvcode != n.code) {
                    ts.push("<option value=\"" + n.code + "\" lang=\"" + n.id + "\">" + n.name + "</option>");
                }
            });
            $(divid).append(ts.join(""));
        });
    }

    // 判断是否是数字

    function checknum(str) {
        var re = /^[0-9]+.?[0-9]*$/;
        if (!re.test(str)) {
            alert("请输入正确的数字！");
            return false;
        } else {
            return true;
        }
    }

    //页面跳转

    function ontoPage(o) {
        var pageindex = $(o).parent().parent().prev().prev().find("input").val();
        if (checknum(pageindex)) {
            var pageEnd = parseInt($(".page_2 b").text());
            if (pageEnd <= pageindex)
                pageindex = pageEnd;
            location.href = "S_StoreProduct.aspx?pageid=" + pageindex;
        }
    }

    function NumTxt_Int(o) {
        o.value = o.value.replace(/\D/g, '');
    }

    function checkpriceTxt(o) {
        var oo = /^\d{1,10}$|\.\w?$|^\d{1,10}\.\d{1,5}\w?$/;
        if (!oo.test(o.val())) {
            return false;
        } else {
            o.val(number_format(o.val(), 2));
            return true;
        }
    }

    //商品价格格式化方法

    function number_format(num, ext) {
        if (ext < 0) {
            return num;
        }
        num = Number(num);
        if (isNaN(num)) {
            num = 0;
        }
        var _str = num.toString();
        var _arr = _str.split('.');
        var _int = _arr[0];
        var _flt = _arr[1];
        if (_str.indexOf('.') == -1) {
            /* 找不到小数点，则添加 */
            if (ext == 0) {
                return _str;
            }
            var _tmp = '';
            for (var i = 0; i < ext; i++) {
                _tmp += '0';
            }
            _str = _str + '.' + _tmp;
        } else {
            if (_flt.length == ext) {
                return _str;
            }
            /* 找得到小数点，则截取 */
            if (_flt.length > ext) {
                _str = _str.substr(0, _str.length - (_flt.length - ext));
                if (ext == 0) {
                    _str = _int;
                }
            } else {
                for (var i = 0; i < ext - _flt.length; i++) {
                    _str += '0';
                }
            }
        }
        return _str;
    }
</script>
<div id="list_main">
    <div class="ordmain1" id="content">
        <div class="pad">
            <table border="0" cellspacing="0" cellpadding="0" class="lineh">
                <tbody>
                    <tr class="up_spac">
                        <td align="right">
                            商品名称：
                        </td>
                        <td>
                            <input type="text" class="ss_nr1" name="ProductName" value="<%= ShopNum1.Common.Common.ReqStr("pn").Replace("%2f", "/") %>" />
                        </td>
                        <td align="right" class="ss_nr_spac" style="display: none;">
                            商品分类：
                        </td>
                        <td style="display: none;">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <select class="tselect1" size="1" name="sel" id="tselect1">
                                            <option value="00">-请选择-</option>
                                        </select>
                                    </td>
                                    <td>
                                        <select class="tselect1" size="1" name="sel" id="tselect2">
                                            <option value="00">-请选择-</option>
                                        </select>
                                    </td>
                                    <td>
                                        <select class="tselect1" size="1" name="sel" id="tselect3">
                                            <option value="00">-请选择-</option>
                                        </select>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="right" class="ss_nr_spac">
                            店铺商品分类：
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <select class="tselect1" size="1" id="selectshopType1">
                                            <option value="00">-请选择-</option>
                                        </select>
                                    </td>
                                    <td>
                                        <select class="tselect1" size="1" id="selectshopType2">
                                            <option value="00">-请选择-</option>
                                        </select>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="up_spac">
                        <td align="right">
                            货号：
                        </td>
                        <td colspan="3">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <input type="text" class="ss_nr1" name="Number" value="<%= ShopNum1.Common.Common.ReqStr("no").Replace("%2f", "/") %>" />
                                    </td>
                                    <td>
                                        <input type="button" value="查询" class="chax btn_spc" name="btnsearch" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="blue_tbdd">
            <tr>
                <th scope="col" width="318" style="border-left: solid 1px #c6dfff;">
                    商品名称
                </th>
                <th scope="col" width="82">
                    库存
                </th>
                <th scope="col" width="82">
                    本店价
                </th>
                <th scope="col" width="41">
                    推荐
                </th>
                <th scope="col" width="41">
                    新品
                </th>
                <th scope="col" width="41">
                    热卖
                </th>
                <th scope="col" width="41">
                    促销
                </th>
                <th width="131">
                    操作
                </th>
            </tr>
        </table>
        <div class="btntable_tbg">
            <table width="100%" cellspacing="0" cellpadding="0" border="0" class="btntable_top">
                <tr>
                    <td width="4%" class="check_td">
                        <input type="checkbox" id="topCheck" name="checktop" />
                    </td>
                    <td width="6%" style="border-right: none; padding-left: 10px; text-align: left;">
                        <label for="topCheck">
                            全选</label>
                    </td>
                    <td width="90%">
                        <div class="shanc">
                            <a class="shanchu lmf_btn" href="#">批量删除</a>
                        </div>
                        <div class="shanc1">
                            <a class="shangj lmf_btn" href="#">上架</a>
                        </div>
                        <div class="shanc1 hideme" id="tipmsg" style="padding-top: 0;">
                            <font color="green"></font>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <% DataTable dt = S_StoreProducts.dt_ShowStoreProduct;
           if (dt != null)
           {
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   DataRow dr = dt.Rows[i];
                   string strProductUrl = ShopUrlOperate.shopHref(dr["guid"].ToString(), dr["memloginId"].ToString());
                   if (dr["Productstate"].ToString() == "1")
                       strProductUrl = ShopUrlOperate.shopDetailHrefByShopID(dr["guid"].ToString(), dr["ShopId"].ToString(), "ProductIsPanic_Detail");
        %>
        <!--循环标签代码-->
        <table width="100%" id="Maintab_<%= dr["id"] %>" cellspacing="0" cellpadding="0"
            border="0" class="blue_tb12" style="margin-bottom: 0;">
            <tr>
                <th style="border-left: solid 1px #e3e3e3; text-align: right; width: 48px;">
                    <div class="ord_check" style="padding-top: 0;">
                        <input type="checkbox" value="<%= dr["id"] %>" id="fx" name="subcheck">
                    </div>
                </th>
                <th style="border-right: solid 1px #e3e3e3; text-align: left;">
                    货号：<span class="blue"><%= dr["productnum"] %></span> 店铺商品分类：<%= Utils.GetUnicodeSubString(dr["productseriesname"].ToString(), 45, "...") %>&nbsp;&nbsp;
                    添加时间：<%= dr["ModifyTime"] %>&nbsp;&nbsp;已售：<%= dr["salenumber"] %>件
                </th>
            </tr>
        </table>
        <table width="100%" id="tab_<%= dr["id"] %>" cellspacing="0" cellpadding="0" border="0"
            class="blue_tb12" style="margin-top: 0;">
            <tbody>
                <tr>
                    <td style="border-left: solid 1px #e3e3e3;" colspan="2">
                        <a href="<%= strProductUrl %>" class="alink_blue" target="_blank">
                            <img width="65" height="66" src="<%= dr["originalimage"].ToString().Replace("~/", "/") %>_60x60.jpg"
                                width="60" height="60" onerror=" javascript:this, src = '/ImgUpload/noImg.jpg_60x60.jpg'; "></a>
                    </td>
                    <td style="padding: 0px; width: 180px;">
                        <div class="nosbe">
                            <span class="edit_name" title="双击编辑">
                                <%= Utils.GetUnicodeSubString(dr["name"].ToString(), 15, "") %></span><span class="edit_v"
                                    style="display: none">
                                    <textarea class="edit_textarea"><%= dr["name"] %></textarea>
                                    <input type="button" class="btn_save" value="保存" lang="<%= dr["Guid"] %>" name="name" /></span>
                            <div class="ord_subs qiu_subos">
                                <div class="ord_sub">
                                    双击修改名称</div>
                                <div class="ord_subs_tt ord_subs_te">
                                </div>
                            </div>
                        </div>
                    </td>
                    <td style="padding: 0px; width: 80px;">
                        <% if (dr["vd"].ToString() == "")
                           { %>
                        <div class="nosbe">
                            <span class="edit_name" title="双击编辑">
                                <%= dr["repertorycount"] %></span><span class="edit_v" style="display: none">
                                    <input type="text" value="<%= dr["repertorycount"] %>" class="edit_txt" maxlength="5"
                                        onkeyup=" NumTxt_Int(this) " />
                                    <input type="button" class="btn_save" value="保存" lang="<%= dr["Guid"] %>" name="rep" /></span>
                            <div class="ord_subs qiu_subos">
                                <div class="ord_sub">
                                    双击修改库存</div>
                                <div class="ord_subs_tt ord_subs_te">
                                </div>
                            </div>
                        </div>
                        <% }
                           else
                           { %><%= dr["repertorycount"] %><% } %>
                    </td>
                    <td style="padding: 0px; width: 80px;">
                        <div class="nosbe">
                            <span class="edit_name" title="双击编辑">
                                <%= dr["shopprice"] %></span><span class="edit_v" style="display: none">
                                    <input type="text" value="<%= dr["shopprice"] %>" class="edit_txt" maxlength="6"
                                        onblur=" checkpriceTxt(this) " />
                                    <input type="button" class="btn_save" value="保存" lang="<%= dr["Guid"] %>" name="price" /></span>
                            <div class="ord_subs qiu_subos">
                                <div class="ord_sub">
                                    双击修改价格</div>
                                <div class="ord_subs_tt ord_subs_te">
                                </div>
                            </div>
                        </div>
                    </td>
                    <td style="width: 20px;">
                        <img width="12" height="12" src='<%= dr["isshoprecommend"].ToString() == "1" ? "images/duiha.gif" : "images/sctb.gif" %>'>
                    </td>
                    <td style="width: 20px;">
                        <img width="12" height="12" src='<%= dr["isshopnew"].ToString() == "1" ? "images/duiha.gif" : "images/sctb.gif" %>'>
                    </td>
                    <td style="width: 20px;">
                        <img width="12" height="12" src='<%= dr["isshophot"].ToString() == "1" ? "images/duiha.gif" : "images/sctb.gif" %>'>
                    </td>
                    <td style="width: 20px;">
                        <img width="12" height="12" src='<%= dr["isshoppromotion"].ToString() == "1" ? "images/duiha.gif" : "images/sctb.gif" %>'>
                    </td>
                    <td style="width: 110px;">
                        <a class="alink_blue" href="javascript:void(0)" onclick=" if (confirm('是否删除？')) {location.href = '?del=<%= dr["id"] %>&sign=del';
                                                                                                      } ">删除</a>
                        <a class="alink_blue" target="_blank" href="S_SellGoods_two.aspx?op=edit&ctype=<%= dr["ctype"] %>&pid=<%= dr["guid"] %>&code=<%= dr["productcategorycode"] %>">
                            编辑</a>
                    </td>
                </tr>
            </tbody>
        </table>
        <!--循环标签代码-->
        <% }
           }
           else
           { %>
        <div class="no_datas">
            <div class="no_data">
                没有查询到相关数据</div>
        </div>
        <% }
        %>
        <div class="btntable_tbg">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_top">
                <tr>
                    <td width="4%" class="check_td">
                        <input name="checktop" id="checktop2" type="checkbox" />
                    </td>
                    <td width="6%" style="border-right: none; padding-left: 10px; text-align: left;">
                        <label for="checktop2">
                            全选</label>
                    </td>
                    <td width="90%">
                        <div id="pageDiv" runat="server" class="fy">
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
