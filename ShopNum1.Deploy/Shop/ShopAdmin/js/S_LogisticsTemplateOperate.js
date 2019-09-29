 String.prototype.replaceAll = function(reallyDo, replaceWith, ignoreCase) {
     if (!RegExp.prototype.isPrototypeOf(reallyDo)) {
         return this.replace(new RegExp(reallyDo, (ignoreCase ? "gi" : "g")), replaceWith);
     } else {
         return this.replace(reallyDo, replaceWith);
     }
 };
 String.prototype.trim = function() {
     return this.replace(/(^[\s]*)|([\s]*$)/g, "");
 };


 var istemplatename = true;
//模板名称是否可用
 ///检查模板名称

 function CheckTemplateName() {
     var secondtemplateName = $("#S_LogisticsTemplateOperate_ctl00_texttemplateName").val(); //将当前的模板名称存下
     if ($.trim(secondtemplateName) == "") {
         $("#spantemplateName").css("color", "black").html("");
         return;
     } else {
         $("#spantemplateName").css("color", "red").html("查询中...");
         var geturl = "/Main/Api/shopfeetemplate.ashx";
         var urlparams = { yz: "shopnum1ntbl", type: "feename", templatename: secondtemplateName };
         $.get(geturl, urlparams, function(data) { //alert(data);
             if (data == null) {
                 $("#spantemplateName").css("color", "red").html("查询失败!");
             }
             if (data == "1") {
                 $("#spantemplateName").css("color", "red").html("模板名称已存在!");
                 istemplatename = false;
             } else {
                 $("#spantemplateName").css("color", "red").html("√");
                 istemplatename = true;
             }
         });
     }
 }

///快递添加地区组

 function AddAdress(obj, vname, rows) {
     //获取模板内容
     var varfeetemplateTr = $("#fee_templateTr").html();
     //替换成对应的模板
     var varexpresstemplateTr = varfeetemplateTr.replaceAll("{delivery}", vname, false); //模板tr内容
     varexpresstemplateTr = varexpresstemplateTr.replaceAll("{num}", "1", false);
     varexpresstemplateTr = varexpresstemplateTr.replaceAll("{TagName}", vname, false);
     $("#" + rows + " tbody").append(varexpresstemplateTr);
 }

 function SetDivPosition(vobj, x, y, logisticname) {
     vselspan = $(vobj).parent().find("span"); //随后要设置地区名称的span
     vselhidden = $(vobj).parent().find("input:eq(0)"); //要设置地区value的hidden
     vselregionnames = $(vobj).parent().find("input:eq(1)"); //要设置地区value的hidden
     $("#dialog_areas").show();
     $("#alldiv").show();
     //选中已选择的地区
     var DataRowCheck = new Array();
     var MyCheck = new Array();
     if (logisticname == "express") {
         $("#ExpressRows tr").each(function() {
             if (vselregionnames.val().indexOf($(this).find("td:eq(0) input:eq(1)").val()) == -1) {
                 DataRowCheck.push($(this).find("td:eq(0) input:eq(1)").val());
             } else {
                 MyCheck.push($(this).find("td:eq(0) input:eq(1)").val());
             }
         });
     } else if (logisticname == "ems") {
         $("#EmsRows tr").each(function() {
             if (vselregionnames.val().indexOf($(this).find("td:eq(0) input:eq(1)").val()) == -1) {
                 DataRowCheck.push($(this).find("td:eq(0) input:eq(1)").val());
             } else {
                 MyCheck.push($(this).find("td:eq(0) input:eq(1)").val());
             }
         });
     } else if (logisticname == "post") {
         $("#PostRows tr").each(function() {
             if (vselregionnames.val().indexOf($(this).find("td:eq(0) input:eq(1)").val()) == -1) {
                 DataRowCheck.push($(this).find("td:eq(0) input:eq(1)").val());
             } else {
                 MyCheck.push($(this).find("td:eq(0) input:eq(1)").val());
             }
         });
     }
     $('#J_CityList').find('input[type="checkbox"]').attr('checked', false).removeAttr('disabled');
     $('#J_CityList').find('.check_num').html('');

     var SelectArea = new Array();
     if (DataRowCheck.join(",") != '') {
         var expAreas = DataRowCheck.join(",").split(',');
         for (var v in expAreas) {
             SelectArea[expAreas[v]] = true;
         }
     }
     //其它行已选中的在这里都置灰
     $('#J_CityList').find('input[type="checkbox"]').each(function() {
         if (DataRowCheck.join(",").indexOf($(this).next().text().trim()) != -1) {
             $(this).attr('disabled', 'disabled').attr('checked', false);
         }

         if (MyCheck.join(",").indexOf($(this).next().text().trim()) != -1) {
             $(this).attr('checked', true);
         }
     });
     $('.J_Province').each(function() {
         if ($(this).attr("disabled")) {
             $(this).parent().find(".citys").find('input[type="checkbox"]').attr('disabled', 'disabled').attr('checked', false);
         }

         if ($(this).attr("checked")) {
             $(this).parent().find(".citys").find('input[type="checkbox"]').attr('checked', true);
         }
     });
     //循环每一行，如果一行的省都被disabled，则大区域也disabled
     $('#J_CityList>li').each(function() {
         $(this).find('.J_Group').attr('disabled', 'disabled');
         father = this;
         $(this).find('.J_Province').each(function() {
             if (!$(this).attr('disabled')) {
                 $(father).find('.J_Group').removeAttr('disabled');
                 return;
             }
         });
     });

 }

 function ClosePopWin() {
     $("#alldiv").css('display', 'none');
     $('.ks-ext-mask').css('display', 'none');
     $("#dialog_areas").css('display', 'none');
 }

 var vselspan = null;
//触发地区 里面的span
 var vselhidden = null;
//触发地区 里面hidden
 var vselregionnames = null;
//触发地区名称 里面的hidden
 $(function() {
     /*	关闭弹出的市级小层*/
     $('.close_button').click(function() {
         $(this).parent().parent().parent().parent().removeClass('showCityPop');
     });
     $(".ks-ext-close").click(function() {
         ClosePopWin();
     });
     $('.J_Cancel').click(function() {
         $("#dialog_areas").css('display', 'none');
         $("#dialog_batch").css('display', 'none');
         $('.ks-ext-mask').css('display', 'none');
     });

     $('.J_Submit').click(function() {
         var CityText = '', CityText2 = '', CityValue = '';
         $('#J_CityList').find('.gareas').each(function() {
             var a = $(this).find('input[type="checkbox"]').size();
             var b = $(this).find('input:checked').size();
             if (a == b) {
                 CityText += ($(this).find('.J_Province').next().html()) + ',';
             } else {
                 $(this).find('.J_City').each(function() {
                     if ($(this).attr('checked')) {
                         CityText2 += ($(this).next().html()) + ',';
                     }
                 });
             }
         });
         CityText += CityText2;
         $('#J_CityList').find('.province-list').find('input[type="checkbox"]').each(function() {
             if ($(this).attr('checked')) {
                 CityValue += $(this).val() + ',';
             }
         });
         CityText = CityText.replace(/(,*$)/g, '');
         CityValue = CityValue.replace(/(,*$)/g, '');
         //返回选择的文本内容
         if (CityText == '') CityText = '未添加地区';
         if (vselspan != null && CityText != "") {
             vselspan.css("color", "#333333");
             vselspan.html(CityText); //设置地区名称
             vselhidden.val(CityValue); //设置地区value值
             vselregionnames.val(CityText); //设置地区的名称
             ClosePopWin();
         }
         $(".check_num").html('');
         $('#J_CityList').find('input[type="checkbox"]').attr('checked', false);
     });
     $('.J_Province').click(function() {
         if ($(this).attr('checked')) {
             //选择所有未被disabled的子地区 
             $(this).parent().parent().find('.citys').find('input[type="checkbox"]').each(function() {
                 if ($(this).attr('disabled')) {
                     $(this).attr('checked', false);
                 } else {
                     $(this).attr('checked', true);
                 }
             });
             //计算并显示所有被选中的子地区数量
             num = '(' + $(this).parent().find('.citys').eq(0).find('input[type="checkbox"]').size() + ')';
             if (num == '(0)') num = '';
             $(this).parent().parent().find(".check_num").eq(0).html(num);

             //如果该大区域所有省都选中，该区域选中
             input_checked = $(this).parent().parent().parent().find('input:checked').size();
             input_all = $(this).parent().parent().parent().find('input[type="checkbox"]').size();
             if (input_all == input_checked) {
                 $(this).parent().parent().parent().parent().find('.J_Group').attr('checked', true);
             }

         } else {
             //取消全部子地区选择，取消显示数量
             $(this).parent().parent().find(".check_num").eq(0).html('');
             $(this).parent().find('.citys').eq(0).find('input[type="checkbox"]').attr('checked', false);
             //取消大区域选择
             $(this).parent().parent().parent().parent().find('.J_Group').attr('checked', false);
         }
     });

/*	大区域点击事件（华北、华东、华南...）*/
     $('.J_Group').click(function() {
         if ($(this).attr('checked')) {
             //区域内所有没有被disabled复选框选中，带disabled说明已经被选择过了，不能再选
             $(this).parent().parent().parent().find('input[type="checkbox"]').each(function() {
                 if ($(this).attr('disabled')) {
                     $(this).attr('checked', false);
                 } else {
                     $(this).attr('checked', true);
                 }
             });
             //循环显示每个省下面的市级的数量
             $(this).parent().parent().parent().find('.province-list').find('.ecity').each(function() {
                 //显示该省下面已选择的市的数量
                 num = '(' + $(this).find('.citys').find('input[type="checkbox"]:checked').size() + ')';
                 //如果是0，说明没有选择，不显示数量
                 if (num != '(0)') {
                     $(this).find(".check_num").html(num);
                 }
             });
         } else {
             //区域内所有筛选框取消选中
             $(this).parent().parent().parent().find('input[type="checkbox"]').attr('checked', false);
             //循环清空每个省下面显示的市级数量
             $(this).parent().parent().parent().find('.province-list').find('.ecity').each(function() {
                 $(this).find(".check_num").html('');
             });
         }
     });
     /*	市级地区单事件*/
     $('.J_City').click(function() {
         //显示选择市级数量，在所属省后面
         num = '(' + $(this).parent().parent().find('input:checked').size() + ')';
         if (num == '(0)') num = '';
         $(this).parent().parent().parent().find(".check_num").eq(0).html(num);
         //如果市级地区全部选中，则父级省份也选中，反之有一个不选中,则省份和大区域也不选中
         if (!$(this).attr('checked')) {
             //取消省份选择
             $(this).parent().parent().parent().find('.J_Province').attr('checked', false);
             //取消大区域选择
             $(this).parent().parent().parent().parent().parent().parent().find('.J_Group').attr('checked', false);
         } else {
             //如果该省所有市都选中，该省选中
             input_checked = $(this).parent().parent().find('input:checked').size();
             input_all = $(this).parent().parent().find('input[type="checkbox"]').size();
             if (input_all == input_checked) {
                 $(this).parent().parent().parent().find('.J_Province').attr('checked', true);
             }
             //如果该大区域所有省都选中，该区域选中
             input_checked = $(this).parent().parent().parent().parent().parent().find('input:checked').size();
             input_all = $(this).parent().parent().parent().parent().parent().find('input[type="checkbox"]').size();
             if (input_all == input_checked) {
                 $(this).parent().parent().parent().parent().parent().parent().find('.J_Group').attr('checked', true);
             }
         }
     });

/*	省份下拉事件*/
     $(".trigger").click(function() {
         objTrigger = this;
         objHead = $(this).parent();
         objPanel = $(this).next();
         if ($(this).next().css('display') == 'none') {
             //隐藏所有已弹出的省份下拉层，只显示当前点击的层
             $('.ks-contentbox').find('.ecity').removeClass('showCityPop');
             $(this).parent().parent().addClass('showCityPop');
         } else {
             //隐藏当前的省份下拉层
             $(this).parent().parent().removeClass('showCityPop');
         }
         //点击省，市所在的head与panel层以外的区域均隐藏当前层
         var oHandle = $(this);
         var de = document.documentElement ? document.documentElement : document.body;
         de.onclick = function(e) {
             var e = e || window.event;
             var target = e.target || e.srcElement;
             var getTar = target.getAttribute("id");
             while (target) {
                 //循环最外层一个时，会出现异常
                 try {
                     //jquery 转成DOM对象，比较两个DOM对象
                     if (target == $(objHead)[0]) return true;
                     if (target == $(objPanel)[0]) return true;
                 } catch(ex) {
                 }
                 ;
                 target = target.parentNode;
             }
             $(objTrigger).parent().parent().removeClass('showCityPop');
         };
     });
 });


 //当 ems选择  checkbox

 function EmsCheckBox(obj) {
     if (obj.checked) {
         $("#trEMS").show();
     } else {
         $("#trEMS").hide();
     }
 }

//当  邮递选择 checkbox

 function PostCheckBox(obj) {
     if (obj.checked) {
         $("#trPost").show();
     } else {
         $("#trPost").hide();
     }
 }

///当快递checkbox选择的时候

 function ExpressCheckBox(obj) {
     if (obj.checked) {
         $("#trExpress").show();
     } else {
         $("#trExpress").hide();
     }
 }

///设置input的焦点

 function inputSetFocus(putobj) {
     $("input").css("background-color", "");
     putobj.focus();
     $(putobj).css("background-color", "#FF8FC5");
 }

//删除地区组

 function DeleteAddress(obj) {
     if (confirm("确定要删除吗?")) {
         $(obj).parent().parent().remove();
     }
 }

 var istemplatename = true;
//模板名称是否可用

 function checkprice(name) {
     var oo = /^\d{1,10}$|^\d{1,10}\.\d{1,2}\w?$/;
     if (!oo.test(name)) {
         return false;
     } else {
         return true;
     }
 }

 var priceyz = /^(([0-9]{1,3})|([0-9]{1,3}\\.[0-9]{0,2}))$/;
//正则表达式

 function SumbitCheck() {
     var ischeckend = true;
     //验证模板名称
     if ($.trim($("#S_LogisticsTemplateOperate_ctl00_texttemplateName").val()) == "") {
         $("#spanmsg").show().html("模板名称不能为空");
         inputSetFocus($("#S_LogisticsTemplateOperate_ctl00_texttemplateName"));
         return false;
     }
     if (!istemplatename) {
         return false;
     }
     var bexpress = $("#S_LogisticsTemplateOperate_ctl00_checkboxExpress").attr("checked");
     var bems = $("#S_LogisticsTemplateOperate_ctl00_checkboxEMS").attr("checked");
     var bpost = $("#S_LogisticsTemplateOperate_ctl00_checkboxPost").attr("checked");
     if (!bexpress && !bems && !bpost) {
         $("#spanmsg").show().html("至少要选择一种邮费类型!");
         return false;
     }

     /////////////////////////验证快递////////////////////////////////////////
     if (bexpress) {
         var InputV = new Array();
         /// 首先验证默认邮费
         var expostage = $.trim($("#S_LogisticsTemplateOperate_ctl00_express_postage_0").val());
         if (expostage == "") {
             inputSetFocus($("#S_LogisticsTemplateOperate_ctl00_express_postage_0"));
             $("#spanmsg").show().html("快递默认邮费不能为空!");
             return false;
         }

         if (!checkprice(expostage)) {
             inputSetFocus($("#S_LogisticsTemplateOperate_ctl00_express_postage_0"));
             $("#spanmsg").show().html("快递邮费应输入0.00至999.99的数字!");
             return false;
         }

         /// 验证默认续费
         var expostplus = $("#S_LogisticsTemplateOperate_ctl00_express_postageplus_0").val();
         if (expostage == "") {
             inputSetFocus($("#S_LogisticsTemplateOperate_ctl00_express_postageplus_0"));
             $("#spanmsg").show().html("快递的默认续费不能为空!");
             return false;
         }

         if (!checkprice(expostplus)) {
             inputSetFocus($("#S_LogisticsTemplateOperate_ctl00_express_postageplus_0"));
             $("#spanmsg").show().html("快递的默认续费应输入0.00至999.99的数字!");
             return false;
         }
         if (parseFloat(expostage) < parseFloat(expostplus)) {
             $("#spanmsg").show().html("快递的续费不应该大于邮费!");
             inputSetFocus($("#S_LogisticsTemplateOperate_ctl00_express_postageplus_0"));
             $("#S_LogisticsTemplateOperate_ctl00_express_postageplus_0").focus();
             return false;
         }

         var AllExpressCountry = "000|全国." + expostage + "." + expostplus;
         if ($("#ExpressRows tr").length == 1)//只有全国
         {

             if ($("#S_LogisticsTemplateOperate_ctl00_hidExpress").val().indexOf("全国") == -1) {
                 $("#S_LogisticsTemplateOperate_ctl00_hidExpress").val(AllExpressCountry);
             }
         } else  //有下面城市
         {
             var Allearea = new Array();
             $("#ExpressRows").find("span").each(function() {
                 Allearea.push($(this).text());
             });
             if (Allearea.join("").indexOf('全国') == -1) {
                 InputV.push(AllExpressCountry);
             }
             //验证其它快递邮费
             $("#ExpressRows tr:gt(0)").each(
                 function(i) {
                     var ehidden = $(this).find("td:eq(0) input:eq(0)");
                     if (ehidden.val() == "0") {
                         $("#spanmsg").show().html("快递地区没有选择!");
                         ischeckend = false;
                         ehidden.parent().find("span").css("color", "red");
                         return false;
                     }
                     var einput = $(this).find("td:eq(2) input");
                     var exval = einput.val();
                     if (exval == "") {
                         inputSetFocus(einput);
                         $("#spanmsg").show().html("快递邮费不能为空!");
                         ischeckend = false;
                         return false;
                     }

                     if (!checkprice(exval)) {
                         inputSetFocus(einput);
                         ischeckend = false;
                         $("#spanmsg").show().html("快递邮费应输入0.00至999.99的数字!");
                         return false;
                     }
                     var eplusinput = $(this).find("td:eq(4) input");
                     var eplusxval = eplusinput.val();
                     if (eplusxval == "") {
                         inputSetFocus(eplusinput);
                         ischeckend = false;
                         $("#spanmsg").show().html("快递续费不能为空!");
                         return false;
                     }
                     if (!checkprice(eplusxval)) {
                         inputSetFocus(eplusinput);
                         ischeckend = false;
                         $("#spanmsg").show().html("快递续费应输入0.00至999.99的数字!");
                         return false;
                     }
                     if (parseFloat(exval) < parseFloat(eplusxval)) {
                         ischeckend = false;
                         $("#spanmsg").show().html("快递续费不应该大于邮费!");
                         eplusinput.focus();
                         return false;
                     }
                     var ehidden2 = $(this).find("td:eq(0) input:eq(1)");
                     if (ehidden2.val() == "全国") {
                         InputV.push("000|全国." + $("#S_LogisticsTemplateOperate_ctl00_express_postage_0").val() + "." + $("#S_LogisticsTemplateOperate_ctl00_express_postageplus_0").val());
                     } else {
                         InputV.push(ehidden.val() + "|" + ehidden2.val() + "." + exval + "." + eplusxval.replace(".", "-"));
                     }
                 });
             $("#S_LogisticsTemplateOperate_ctl00_hidExpress").val(InputV.join("*"));
         }

     }
     if (!ischeckend) {
         return false;
     }
     //////////验证快递结束//////////////

     /////////////////////////验证EMS////////////////////////////////////////
     if (bems) {
         var InputV = new Array();
         /// 首先验证默认邮费
         var expostage = $.trim($("#S_LogisticsTemplateOperate_ctl00_ems_postage_0").val());
         if (expostage == "") {
             inputSetFocus($("#S_LogisticsTemplateOperate_ctl00_ems_postage_0"));
             $("#S_LogisticsTemplateOperate_ctl00_ems_postage_0").change(function() { inputOnMouseChnageEvent(this); });
             $("#spanmsg").show().html("EMS默认邮费不能为空!");

             return false;
         }
         if (!checkprice(expostage)) {
             inputSetFocus($("#S_LogisticsTemplateOperate_ctl00_ems_postage_0"));
             $("#S_LogisticsTemplateOperate_ctl00_ems_postage_0").change(function() { inputOnMouseChnageEvent(this); });
             $("#spanmsg").show().html("EMS邮费应输入0.00至999.99的数字!");
             return false;
         }

         /// 验证默认续费
         var expostplus = $("#S_LogisticsTemplateOperate_ctl00_ems_postageplus_0").val();
         if (expostage == "") {
             inputSetFocus($("#S_LogisticsTemplateOperate_ctl00_ems_postageplus_0"));
             $("#S_LogisticsTemplateOperate_ctl00_ems_postageplus_0").change(function() { inputOnMouseChnageEvent(this); });
             $("#spanmsg").show().html("EMS默认续费不能为空!");

             return false;
         }

         if (!checkprice(expostplus)) {
             inputSetFocus($("#S_LogisticsTemplateOperate_ctl00_ems_postageplus_0"));
             $("#S_LogisticsTemplateOperate_ctl00_ems_postageplus_0").change(function() { inputOnMouseChnageEvent(this); });
             $("#spanmsg").show().html("EMS默认续费应输入0.00至999.99的数字!");
             return false;
         }
         if (parseFloat(expostage) < parseFloat(expostplus)) {
             $("#spanmsg").show().html("EMS默认续费不应该大于邮费!");
             $("#S_LogisticsTemplateOperate_ctl00_ems_postageplus_0").focus();
             return false;
         }
         var AllEmsCountry = "000|全国." + expostage + "." + expostplus;

         if ($("#EmsRows tr").length == 1)//只有全国
         {
             if ($("#S_LogisticsTemplateOperate_ctl00_hidEms").val().indexOf("全国") == -1) {
                 $("#S_LogisticsTemplateOperate_ctl00_hidEms").val(AllEmsCountry);
             }
         } else  //有下面城市
         {
             var Allearea = new Array();
             $("#EmsRows").find("span").each(function() {

                 Allearea.push($(this).text());

             });
             if (Allearea.join("").indexOf('全国') == -1) {
                 InputV.push(AllEmsCountry);
             }

             $("#EmsRows tr:gt(0)").each(
                 function(i) {
                     var ehidden = $(this).find("td:eq(0) input:eq(0)");
                     if (ehidden.val() == "0") {
                         $("#spanmsg").show().html("EMS地区没有选择!");
                         ischeckend = false;
                         ehidden.parent().find("span").css("color", "red");
                         return false;

                     }
                     var einput = $(this).find("td:eq(2) input");
                     var exval = einput.val();
                     if (exval == "") {
                         inputSetFocus(einput);
                         ischeckend = false;
                         $("#spanmsg").show().html("EMS邮费不能为空!");

                         return false;
                     }
                     if (!checkprice(exval)) {
                         inputSetFocus(einput);
                         ischeckend = false;
                         $("#spanmsg").show().html("EMS邮费应输入0.00至999.99的数字!");
                         return false;
                     }

                     var eplusinput = $(this).find("td:eq(4) input");
                     var eplusxval = eplusinput.val();
                     if (eplusxval == "") {
                         inputSetFocus(eplusinput);
                         ischeckend = false;
                         $("#spanmsg").show().html("EMS续费不能为空!");
                         return false;
                     }
                     if (!checkprice(eplusxval)) {

                         inputSetFocus(eplusinput);
                         ischeckend = false;
                         $("#spanmsg").show().html("EMS续费应输入0.00至999.99的数字!");
                         return false;
                     }
                     if (parseFloat(exval) < parseFloat(eplusxval)) {
                         ischeckend = false;
                         $("#spanmsg").show().html("EMS续费不应该大于邮费!");
                         eplusinput.focus();
                         return false;
                     }

                     var ehidden2 = $(this).find("td:eq(0) input:eq(1)");
                     if (ehidden2.val() == "全国") {
                         InputV.push("000|全国." + $("#S_LogisticsTemplateOperate_ctl00_ems_postage_0").val() + "." + $("#S_LogisticsTemplateOperate_ctl00_ems_postageplus_0").val());
                     } else {
                         InputV.push(ehidden.val() + "|" + ehidden2.val() + "." + exval + "." + eplusxval);
                     }
                 });
             $("#S_LogisticsTemplateOperate_ctl00_hidEms").val(InputV.join("*"));
         }
     }
     if (!ischeckend) {
         return false;
     }
     //////////验证EMS结束//////////////


     /////////////////////////验证Post////////////////////////////////////////
     if (bpost) {
         var InputV = new Array();
         /// 首先验证默认邮费
         var expostage = $.trim($("#S_LogisticsTemplateOperate_ctl00_post_postage_0").val());
         if (expostage == "") {
             inputSetFocus($("#S_LogisticsTemplateOperate_ctl00_post_postage_0"));
             $("#spanmsg").show().html("平邮默认邮费不能为空!");

             return false;
         }
         if (!checkprice(expostage)) {
             inputSetFocus($("#S_LogisticsTemplateOperate_ctl00_post_postage_0"));
             $("#spanmsg").show().html("平邮默认邮费应输入0.00至999.99的数字!");
             return false;
         }

         /// 验证默认续费
         var expostplus = $("#S_LogisticsTemplateOperate_ctl00_post_postageplus_0").val();
         if (expostage == "") {
             inputSetFocus($("#S_LogisticsTemplateOperate_ctl00_post_postageplus_0"));
             $("#spanmsg").show().html("平邮默认邮费不能为空!");

             return false;
         }
         if (!checkprice(expostplus)) {
             inputSetFocus($("#S_LogisticsTemplateOperate_ctl00_post_postageplus_0"));
             $("#spanmsg").show().html("平邮续费应输入0.00至999.99的数字!");
             return false;
         }

         if (parseFloat(expostage) < parseFloat(expostplus)) {
             $("#S_LogisticsTemplateOperate_ctl00_post_postageplus_0").focus();
             $("#spanmsg").show().html("平邮续费不应该大于邮费!");
             return false;
         }
         var AllPostCountry = "000|全国." + expostage + "." + expostplus;

         if ($("#PostRows tr").length == 1)//只有全国
         {
             if ($("#S_LogisticsTemplateOperate_ctl00_hidPost").val().indexOf("全国") == -1) {
                 $("#S_LogisticsTemplateOperate_ctl00_hidPost").val(AllPostCountry);
             }
         } else  //有下面城市
         {
             var Allearea = new Array();
             $("#PostRows").find("span").each(function() {

                 Allearea.push($(this).text());
             });
             if (Allearea.join("").indexOf('全国') == -1) {
                 InputV.push(AllPostCountry);
             }

             //验证其EMS邮费
             $("#PostRows tr:gt(0)").each(
                 function(i) {
                     var ehidden = $(this).find("td:eq(0) input:eq(0)");

                     if (ehidden.val() == "0") {
                         $("#spanmsg").show().html("平邮地区没有选择!");
                         ischeckend = false;
                         ehidden.parent().find("span").css("color", "red");
                         return false;

                     }
                     var einput = $(this).find("td:eq(2) input");
                     var exval = einput.val();
                     if (exval == "") {
                         inputSetFocus(einput);
                         ischeckend = false;
                         $("#spanmsg").show().html("平邮邮费不能为空!");

                         return false;
                     }
                     if (!checkprice(exval)) {
                         inputSetFocus(einput);
                         ischeckend = false;
                         $("#spanmsg").show().html("平邮邮费应输入0.00至999.99的数字!");
                         return false;
                     }

                     var eplusinput = $(this).find("td:eq(4) input");
                     var eplusxval = eplusinput.val();
                     if (eplusxval == "") {
                         inputSetFocus(eplusinput);
                         ischeckend = false;
                         $("#spanmsg").show().html("平邮续费不能为空!");

                         return false;
                     }
                     if (!checkprice(eplusxval)) {
                         ischeckend = false;
                         inputSetFocus(eplusinput);
                         $("#spanmsg").show().html("平邮续费应输入0.00至999.99的数字!");
                         return false;
                     }
                     if (parseFloat(exval) < parseFloat(eplusxval)) {
                         ischeckend = false;
                         $("#spanmsg").show().html("平邮续费不应该大于邮费!");
                         eplusinput.focus();
                         return false;
                     }

                     var ehidden2 = $(this).find("td:eq(0) input:eq(1)");

                     if (ehidden2.val() == "全国") {
                         InputV.push("000|全国." + $("#S_LogisticsTemplateOperate_ctl00_post_postage_0").val() + "." + $("#S_LogisticsTemplateOperate_ctl00_post_postageplus_0").val());
                     } else {
                         InputV.push(ehidden.val() + "|" + ehidden2.val() + "." + exval + "." + eplusxval);
                     }

                 });
             $("#S_LogisticsTemplateOperate_ctl00_hidPost").val(InputV.join("*"));
         }
     }
     if (!ischeckend) {
         return false;
     }
     return true;
 }