 //增加属性
 function add_Prop(obj) {
     if ($(obj).parent().parent().parent().parent().find(".prop_handinput_text tr").size() >= 30) {
         $(obj).next().show();
         return false;
     }
     var xhtml_prop = '<tr><td width="500" class="defined_Prop">';
     xhtml_prop += '<input type="text" class="textwb" name="input_defined_1" style="width:100px;"/>：';
     xhtml_prop += '<input type="text" class="textwb" name="input_defined_2" style="width:200px;"/>';
     xhtml_prop += '&nbsp;<span class="gray1 delprop">删除</span>&nbsp;<span class="gray1 clearprop">清空</span></td></tr>';
     $(obj).parent().parent().parent().parent().find(".prop_handinput_text").append(xhtml_prop);
 }

 $(function() {
     if ($("#S_OpGoods1_ctl00_Spec_show").find(".yanskuang").text().trim() == "") {
         $("#S_OpGoods1_ctl00_Spec_show").hide();
     }
     if ($("#S_OpGoods1_ctl00_Prop_show").find(".yanskuang").text().trim() == "") {
         $("#S_OpGoods1_ctl00_Prop_show").hide();
     }
     $("#productCategoryName").text($("#S_OpGoods1_ctl00_hidCategoryName").val());
     if ($("#S_OpGoods1_ctl00_hidCategoryName").val() == undefined) {
         $("#productCategoryName").text($("#S_OpGoods1C2C_ctl00_hidCategoryName").val());
     }
     
     
     //显示品牌
     $.get(BrandAjaxUrl, null, function(data) {
         if (data != "") {
             var vdata = eval('(' + data + ')');
             var xhtml = new Array("<option value=\"0\">-请选择-</option>");

             $.each(vdata, function(m, n) {
                 if (n.name != $("#S_OpGoods2_ctl00_hidBrand").val().split(",")[1]) {
                     xhtml.push('<option value="' + n.guid + '">' + n.name + '</option>');
                 }
             });
             if ($("#S_OpGoods2_ctl00_hidBrand").val().split(",")[0] == "00000000-0000-0000-0000-000000000000") {
                 xhtml.push("<option value=\"00000000-0000-0000-0000-000000000000\" selected=\"selected\">其它</option>");
                 $("#OtherBrand").show();
                 $("#txtPersonBrand").val($("#S_OpGoods2_ctl00_hidBrand").val().split(",")[1]);
             } else if ($("#S_OpGoods2_ctl00_hidBrand").val() != "" && $("#S_OpGoods2_ctl00_hidBrand").val().split(",")[1] != "") {
                 xhtml.push("<option value=\"" + $("#S_OpGoods2_ctl00_hidBrand").val().split(",")[0] + "\" selected=\"selected\">" + $("#S_OpGoods2_ctl00_hidBrand").val().split(",")[1] + "</option>");
                 xhtml.push('<option value="00000000-0000-0000-0000-000000000000">其它</option>');
             } else {
                 xhtml.push('<option value="00000000-0000-0000-0000-000000000000">其它</option>');
             }
             $(".select_Brand").html(xhtml.join(""));
         } else {
             $("#OtherBrand").show();
             $("#txtPersonBrand").val($("#S_OpGoods2_ctl00_hidBrand").val().split(",")[1]);
         }
     });
     //显示其它品牌
     $(".select_Brand").change(function() {
         if ($(this).val() == "00000000-0000-0000-0000-000000000000") {
             $("#OtherBrand").show();
         } else {
             $("#OtherBrand").hide();
         }
     });
     //选中操作控制
     $('span[spec_check="this_check"] > input[type="checkbox"]').click(function() {
         showEdit($(this).is(":checked"), this);
         set_array();
         goods_stock_set();
     });
//	     $('#Spec_body').find('input[type="text"]').each(function(){
//	            s = $(this).attr('spec_type');
//	            V[s] = $(this).val();
//         });
     //绑定规格配置已经填写好的值
     $('#Spec_body').find('input[type="text"]').live('change', function() {
         s = $(this).attr('spec_type');
         V[s] = $(this).val();
     });

     $('input[sepc_value="this_name"]').live("blur", function() {
         set_array();
         goods_stock_set();
     });

//            $("#addProp").click(function(){alert("test");
//                   
//            });

     $(".delprop").live("click", function() {
         $(this).parent().parent().remove();
     });
     $(".clearprop").live("click", function() {
         $(this).parent().find("input").val("");
     });
     $(".ystctab").each(function() {
         if ($(this).find("tr:visible").length < 2) {
             $(this).hide();
         }
     });

 });
 //显示编辑文本框并隐藏汉字  选中后出现可以编辑的文本框 

 function showEdit(boolcheck, obj) {
     if (boolcheck) {
         $(obj).parent().parent().find(".default_txt").hide();
         $(obj).parent().parent().find(".pvname").show();
         $("#showUp_" + $(obj).attr("lang")).show();
         $("#fileup_" + $(obj).attr("spec_type")).show();
     } else {
         $(obj).parent().parent().find(".default_txt").show();
         $(obj).parent().parent().find(".default_txt").text($(obj).parent().parent().find(".pvname").find("input").val());
         $(obj).parent().parent().find(".pvname").hide();
         $("#fileup_" + $(obj).attr("spec_type")).hide();
         var i = $("#showUp_" + $(obj).attr("lang")).find("tr:visible").length;
         if (i < 2) {
             $("#showUp_" + $(obj).attr("lang")).hide();
         }
     }
 }

// 按规格存储规格值数据
 var spec_group_checked = ['', ''];
 var spec_group_checked_0 = new Array();
 var spec_group_checked_1 = new Array();
 var spec_group_checked_2 = new Array();
 //设置规格数组
 var x, y;
 var V = new Array();
 var check_spec_count = new Array();

 function set_array() {
     spec_group_checked_0 = new Array();
     $('div[shop_spec="Spec_group_0"]').find('input[type="checkbox"]:checked').each(function() {
         x = $(this).parent().parent().find('input[sepc_value="this_name"]').val();
         y = $(this).attr('spec_type');
         spec_group_checked_0[spec_group_checked_0.length] = [x, y];
     });
     spec_group_checked[0] = spec_group_checked_0;
     spec_group_checked_1 = new Array();
     $('div[shop_spec="Spec_group_1"]').find('input[type="checkbox"]:checked').each(function() {
         x = $(this).parent().parent().find('input[sepc_value="this_name"]').val();
         y = $(this).attr('spec_type');
         spec_group_checked_1[spec_group_checked_1.length] = [x, y];
     });

     spec_group_checked[1] = spec_group_checked_1;

     spec_group_checked_2 = new Array();
     $('div[shop_spec="Spec_group_2"]').find('input[type="checkbox"]:checked').each(function() {
         x = $(this).parent().parent().find('input[sepc_value="this_name"]').val();
         y = $(this).attr('spec_type');
         spec_group_checked_2[spec_group_checked_2.length] = [x, y];
     });
     spec_group_checked[2] = spec_group_checked_2;
 }

// 计算商品库存

 function stock_total() {
     var stock = 0;
     $('input[data_type="goods_stock"]').each(function() {
         if ($(this).val() != '') {
             stock += parseInt($(this).val());
         }
     });
     $('#txtStock').val(stock);
 }

// 计算价格

 function price_total() {
     var max = 0.01;
     var min = 10000000;
     $('input[data_type="goods_price"]').each(function() {
         if ($(this).val() != '') {
             max = Math.max(max, $(this).val());
             min = Math.min(min, $(this).val());
         }
     });
     if (max > min) {
         $('input[name="goods_price_sum"]').val(number_format(min, 2) + ' - ' + number_format(max, 2));
     } else {
         $('input[name="goods_price_sum"]').val('');
     }
     if (min != 10000000) {
         $('#txtShopPrice').val(number_format(min, 2));
     }
 }

// 计算商品库存
//$('input[data_type="goods_stock"]').live('change',function(){
//	stock_total();
//});

 function onchangestock(o) {
     stock_total();
     price_total();
     s = $(o).attr('spec_type');
     V[s] = $(o).val();
 }

// 计算商品价格区间
//$('input[data_type="goods_price"]').live('change',function(){
//	price_total();
//});

//设置规格库存配置html

 function goods_html_set(spec_bunch, td_1, td_2, td_3, checklen2, checklen3) {
     var str = "";
     str += '<td><input type="hidden" name="spec[sp_value]" spec_bunch="' + spec_bunch + '" sp_id="' + td_1[1] + '" value=' + td_1[0] + ' />' + td_1[0] + '</td>';
     if (checklen2 != 0) {
         str += '<td><input type="hidden" name="spec[sp_value]" spec_bunch="' + spec_bunch + '"  sp_id="' + td_2[1] + '" value=' + td_2[0] + ' />' + td_2[0] + '</td>';
     }
     if (checklen3 != 0) {
         str += '<td><input type="hidden" name="spec[sp_value]" spec_bunch="' + spec_bunch + '" sp_id="' + td_3[1] + '" value=' + td_3[0] + ' />' + td_3[0] + '</td>';
     }
     str += '<td><input class="spec_txt" type="text" name="spec[' + spec_bunch + '][price]" onblur="checkpriceTxt(this);onchangestock(this)" maxlength="6" data_type="goods_price" value="0.00" spec_type="' + spec_bunch + '|price" value="" /></td>';
     str += '<td><input class="spec_txt" type="text" name="spec[' + spec_bunch + '][stock]" onblur="NumTxt_Int(this);onchangestock(this)" maxlength="6" data_type="goods_stock" value="1" spec_type="' + spec_bunch + '|stock" value="" /></td>';
     str += '<td><input class="spec_txt" type="text" name="spec[' + spec_bunch + '][sku]" maxlength="8" data_type="goods_no" value="" spec_type="' + spec_bunch + '|sku" value="" /></td></tr>';
     return str;
 }

// 生成库存配置核心js代码

 function goods_stock_set() {
     //  店铺价格 商品库存改为只读
     $('#txtShopPrice').attr('readonly', 'readonly').css('background', '#E7E7E7 none');
     $('#txtStock').attr('readonly', 'readonly').css('background', '#E7E7E7 none');
     $('#showSpecTab').show();
     var strApp = new Array();
     strApp.push('<tr>');
     for (var i_0 = 0; i_0 < spec_group_checked[0].length; i_0++) {
         td_1 = spec_group_checked[0][i_0];
         var spec_bunch_1 = 'i_' + td_1[1];
         if ($('div[shop_spec="Spec_group_1"]').length == "0") {
             strApp.push(goods_html_set(spec_bunch_1, td_1, "", "", spec_group_checked[1].length, spec_group_checked[2].length));
         }
         for (var i_1 = 0; i_1 < spec_group_checked[1].length; i_1++) {
             td_2 = spec_group_checked[1][i_1];
             var spec_bunch_2 = 'i_';
             spec_bunch_2 += td_1[1];
             spec_bunch_2 += td_2[1];
             if ($('div[shop_spec="Spec_group_2"]').length == "0") {
                 strApp.push(goods_html_set(spec_bunch_2, td_1, td_2, "", spec_group_checked[1].length, spec_group_checked[2].length));
             }
             for (var i_2 = 0; i_2 < spec_group_checked[2].length; i_2++) {
                 td_3 = spec_group_checked[2][i_2];
                 var spec_bunch_3 = 'i_';
                 spec_bunch_3 += td_1[1];
                 spec_bunch_3 += td_2[1];
                 spec_bunch_3 += td_3[1];
                 strApp.push(goods_html_set(spec_bunch_3, td_1, td_2, td_3, spec_group_checked[1].length, spec_group_checked[2].length));
             }
         }
     }
     if (strApp.join("") == '<tr>') {
         //  店铺价格 商品库存取消只读
         $('#txtShopPrice').removeAttr('readonly').css('background', '');
         $('#txtStock').removeAttr('readonly').css('background', '');
         $('#showSpecTab').hide();
     }
     $('#Spec_body')
         .empty()
         .html(strApp.join(""))
         .find('input[type="text"]').each(function() {
             s = $(this).attr('spec_type');
             try {
                 $(this).val(V[s]);
             } catch(ex) {
                 $(this).val('');
             }
             ;
             if ($(this).attr('data_type') == 'goods_price' && $(this).val() == '') {
                 $(this).val($('input[name="goods_store_price"]').val());
             }
         });
     stock_total(); // 计算商品库存
     price_total(); // 计算价格区间
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

 function NumTxt_Int(o) {
     o.value = o.value.replace(/\D/g, '');
 }

///* 火狐下取本地全路径 */
//function getFullPath(obj)
//{
//    if(obj)
//    {
//        if (window.navigator.userAgent.indexOf("MSIE")>=1)
//        {
//            obj.select();
//            if(window.navigator.userAgent.indexOf("MSIE") == 25){
//            	obj.blur();
//            }
//        }
//        else if(window.navigator.userAgent.indexOf("Firefox")>=1)
//        {
//            if(obj.files)
//            {
//                $(obj).parent().next().find("img").attr("src",window.URL.createObjectURL(obj.files.item(0))); return false;
//            }
//        }
//        $(obj).parent().next().find("img").attr("src",obj.value);return false;
//    }
//    $(obj).parent().next().find("img").attr("src",obj.value);return false;
//}

 $(function() {
     $("select[name='select_album']").change(function() {
         $("#albumtype").val($(this).find("option:selected").val());
         GetAjaxContent(1, "");
     });
 });

 //ajax上传图片

 function SpecfileUpload(obj, imgid) {
     $("#" + $(obj).attr("id") + "_upload").hide();
     $("#" + $(obj).attr("id") + "_del").show();
     var fileName = $(obj).val();
     if (fileName.indexOf("\\") != -1)
         fileName = fileName.substring(fileName.lastIndexOf("\\") + 1, fileName.length);
     //开始提交
     $("#form1").ajaxSubmit({
         beforeSubmit: function(formData, jqForm, options) {
             $(imgid).attr("src", "images/loading.gif");
         },
         success: function(data, textStatus) {
             var imageinfo = eval('(' + data + ')');
             $("#errpicmsg").hide();
             if (imageinfo.msg == "1") {
                 $(obj).next().val(imageinfo.imagepath);
                 $(imgid).attr("src", imageinfo.imagepath);
                 $(obj).val("");
                 $(obj).parent().prev().find("input").val(imageinfo.imagepath);
             } else {
                 $("#errpicmsg").show().html(imageinfo.imagepath);
             }
         },
         error: function(data, status, e) {
             alert("上传失败，错误信息：" + e);
             $(obj).val("");
         },
         url: "/Api/S_OpGoods1.ashx?opspec=vj&filename=" + fileName,
         type: "post",
         dataType: "text",
         timeout: 600000
     });
 }

 function changfile(obj, imgid) {
     $("#" + $(obj).attr("id") + "_upload").hide();
     $("#" + $(obj).attr("id") + "_del").show();
     var fileName = $(obj).val();
     if (fileName.indexOf("\\") != -1)
         fileName = fileName.substring(fileName.lastIndexOf("\\") + 1, fileName.length);
     //开始提交
     $("#form1").ajaxSubmit({
         beforeSubmit: function(formData, jqForm, options) {
             $(imgid).attr("src", "images/loading.gif");
         },
         success: function(data, textStatus) {
             var imageinfo = eval('(' + data + ')');
             $("#errpicmsg").hide();
             if (imageinfo.msg == "1") {
                 $(obj).next().val(imageinfo.imagepath);
                 $(imgid).attr("src", imageinfo.imagepath);
                 $(obj).val("");
                 $(obj).parent().prev().find("input").val(imageinfo.imagepath);
             } else {
                 $("#errpicmsg").show().html(imageinfo.imagepath);
             }
         },
         error: function(data, status, e) {
             alert("上传失败，错误信息：" + e);
             $(obj).val("");
         },
         url: "/Api/S_OpGoods1.ashx?filename=" + fileName,
         type: "post",
         dataType: "text",
         timeout: 600000
     });
 }

 function changTabPic(str, obj) {
     $(obj).addClass("chali1").removeClass("chali2");
     $(str).addClass("chali2").removeClass("chali1");
     str = str == "#tabpic2" ? "display:none" : "display:block";
     GetAjaxContent(1, str);
     $("#TabAlbum").attr("style", str);
     if ($("select[name='select_album'] option").length <= 2) {
         $.get("/Api/S_OpGoods1.ashx?type=4&op=getalubm", null, function(data) {
             var data = eval('(' + data + ')');
             $.each(data, function(m, n) {
                 $("select[name='select_album']").append("<option value=\"" + n.id + "\">" + n.name + "</option>");
             });

         });
     }
 }

//分页代码  Jely liuxing

 function initMyPages(nowPage, pages) {
     $("#OtherPageNum").html("");
     var endPage = pages;
     var startPage = 1;
     if (pages > 1) {
         if (nowPage - 4 > 0) {
             startPage = nowPage - 4;
         }
         if (nowPage + 5 < pages) {
             endPage = nowPage + 5;
         } else {
             endPage = pages;
         }
     }
     var pageNumStr = "";
     if (nowPage != 1) {
         pageNumStr += "<a href=\"javascript:;\" onclick='javascript:;GetAjaxContent(1)'>首页</a><a href=\"javascript:;\" onclick=\"javascript:;GetAjaxContent(" + (nowPage - 1) + ")\">上一页</a> ";
     }
     for (var i = startPage; i <= endPage; i++) {
         if (nowPage == i) {
             pageNumStr += "&nbsp;<b><font color='red'>" + i + "</font></b>";
         } else {
             pageNumStr += "&nbsp;<a href='javascript:;' onclick='javascript:;GetAjaxContent(" + i + ")'>" + i + "</a>";
         }
     }
     //判断什么时候显示下一页
     if (nowPage < pages) {
         pageNumStr += " <a href='javascript:;' onclick='javascript:;GetAjaxContent(" + (nowPage + 1) + ")'>下一页</a><a href=\"javascript:;\" onclick='javascript:;GetAjaxContent(" + pages + ")'>末页</a>";
     }
     $("#OtherPageNum").html(pageNumStr);
 }

 function GetAjaxContent(index, str) {
     $.get("/Api/S_OpGoods1.ashx?type=3&page=" + index + "&str=" + str + "&hidtype=" + $("#albumtype").val(), null, function(data) {
         var countinfo = eval('(' + data.split("|")[0] + ')');
         var mylist = new Array();
         if (data.split("|")[1] != "") {
             var sp = eval('(' + data.split("|")[1] + ')');
             $.each(sp, function(m, n) {
                 mylist.push("<li onclick=\"setpic('" + n.imagepath + "')\"><img src=\"" + n.imagepath + "\" width=\"59\" height=\"60\" border=\"1\" onerror=\"javascript:this.src='/ImgUpload/noimg.jpg_60x60.jpg'\"/></li>");
             });
         }
         $("#albumlist ul").html(mylist.join(""));
         count = countinfo.countinfo[0].countpage;
         initMyPages(index, count);
         $("#lblpageCount").html(count++);
         $("#lblpageIndex").text(index);
         $(".lblNumCount").text(countinfo.countinfo[0].allcount);
     });
 }

//从图库中调用商品图片

 function setpic(imgpath) {
     $("img[name='pro_img']").each(function() {
         if ($(this).attr("src") == "/ImgUpload/noimg.jpg_100x100.jpg") {
             $("#file_" + (parseInt($(this).attr("id").replace("imgvj_", "")) - 1) + "_del").show();
             $("#file_" + (parseInt($(this).attr("id").replace("imgvj_", "")) - 1) + "_upload").hide();
             $(this).attr("src", imgpath);
             return false;
         }
     });

 }


 //编辑器调用方法
 KindEditor.ready(function(K) {
     var editor = K.create('.textwebedit', {
         //上传管理
         uploadJson: '/kindeditor/file/upload_json.ashx',
         //文件管理
         fileManagerJson: '/kindeditor/file/file_manager_json.ashx',
         allowFileManager: true,
         //编辑器高度
         width: '100%',
         //编辑器宽度
         height: '300px;',
         //配置编辑器的工具栏
         items: [
             'source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
             'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent', 'subscript',
             'superscript', 'clearhtml', 'quickformat', 'selectall', '|', 'fullscreen', '/',
             'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
             'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image', 'multiimage',
             'flash', 'media', 'insertfile', 'table', 'hr', 'emoticons', 'baidumap', 'pagebreak',
             'anchor', 'link', 'unlink', '|', 'about'
         ],
         afterBlur: function() { editor.sync(); }
     });
     prettyPrint();
 });
 //编辑器调用方法
 KindEditor.ready(function(K) {
     wapeditor = K.create('.textwebeditv', {
         useContextmenu: false,
         pasteType: 0,
         //编辑器高度
         width: '330px',
         //编辑器宽度
         height: '400px;',
         items: [
             'source', 'preview', 'plainpaste', 'wordpaste', 'fullscreen', 'clearhtml', 'removeformat', 'link', 'unlink', '|', 'about'
         ],
         afterBlur: function() { wapeditor.sync(); }
     });
     prettyPrint();
 });

 //编辑器调用方法
 KindEditor.ready(function(K) {
     wapeditor = K.create('.textwebeditvp', {
         //useContextmenu:false,
                //pasteType:0,
                //编辑器高度
         width: '100%',
         //编辑器宽度
         height: '200px;',
         items: [
             'source', 'preview', 'plainpaste', 'wordpaste', 'fullscreen', 'clearhtml', 'removeformat', 'link', 'unlink', '|', 'about'
         ],
         afterBlur: function() { wapeditor.sync(); }
     });
     prettyPrint();
 });