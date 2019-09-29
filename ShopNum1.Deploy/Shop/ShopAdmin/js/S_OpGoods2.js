
  function checkprice(name) {
      var oo = /^\d{1,10}$|^\d{1,10}\.\d{1,2}\w?$/;
      if (!oo.test(name)) {
          return false;
      } else {
          return true;
      }
  }

  function checkpriceTxt(o) {
      var oo = /^\d{1,10}$|\.\w?$|^\d{1,10}\.\d{1,5}\w?$/;
      if (!oo.test(o.value)) {
          o.value = '0.00';
      } else {
          o.value = number_format(o.value, 2);
          return true;
      }
  }

  String.prototype.trim = function() {
      return this.replace(/(^[\s]*)|([\s]*$)/g, "");
  };
  //提交方法

  function funsub() {
      var errorflag = 0;
      if (Page_ClientValidate()) {
          $("span[check='errorMsg']").hide();
          $("#stockSpec").hide();
          $("#showpic").hide();
          $("#S_OpGoods2_ctl00_hidPType").val("");
          $("input[name='pType']").each(function() {
              if ($(this).attr("checked")) {
                  $("#S_OpGoods2_ctl00_hidPType").val($("#S_OpGoods2_ctl00_hidPType").val() + $(this).attr("id"));
              }
          });
          if ($("#txtGoodsName").val().trim().length < 3) {
              $("#txtGoodsName").focus();
              $("#txtGoodsName").next().show();
              errorflag = 1;
              window.scrollTo(0, 200);
          }
          $("#S_OpGoods2_ctl00_hidName").val($("#txtGoodsName").val());
          if ($("#txtStock").val().trim() == "" || $("#txtStock").val().trim() == "0") {
              $("#txtStock").next().show();
              window.scrollTo(0, 500);
              errorflag = 2;
          }
          $("#S_OpGoods2_ctl00_hidRepertoryCount").val($("#txtStock").val());

          if ($("#txtRepertoryAlertCount").val().trim() == "" || $("#txtRepertoryAlertCount").val().trim() == "0") {
              $("#txtRepertoryAlertCount").next().show();
              window.scrollTo(0, 500);
              errorflag = 2;
              return false;
          }
          $("#S_OpGoods2_ctl00_hidRepertoryAlertCount").val($("#txtRepertoryAlertCount").val());
          

          $("#S_OpGoods2_ctl00_hidShopPrice").val($("#txtShopPrice_one").val());
          $("#S_OpGoods2_ctl00_hidMarketPrice").val($("#txtMarketPrice_one").val());
          $("#S_OpGoods2_ctl00_hidProductNum").val($("#txtNumber").val());
          $("#S_OpGoods2_ctl00_hidUnitName").val($("#txtUnitname").val());
          $("#S_OpGoods2_ctl00_hidCategoryName").val($("#productCategoryName").text());
          $("#S_OpGoods2_ctl00_hidScore_Pv_a").val($("#txtScore_Pv_a").val());
          $("#S_OpGoods2_ctl00_hidScore_Pv_b").val($("#txtScore_Pv_b").val());
          $("#S_OpGoods2_ctl00_hidScore_dv").val($("#txtScore_dv").val());
          $("#S_OpGoods2_ctl00_hidScore_hv").val($("#txtScore_hv").val());
          $("#S_OpGoods2_ctl00_hidScore_sv").val($("#txtScore_sv").val());
          $("#S_OpGoods2_ctl00_hidScore_max_hv").val($("#txtScore_max_hv").val());

          $("#S_OpGoods2_ctl00_hidScore_pv_a_two").val($("#txtScore_Pv_a_two").val());
          $("#S_OpGoods2_ctl00_hidShopPrice_two").val($("#txtShopPrice_two").val());
          $("#S_OpGoods2_ctl00_hidMarketPrice_two").val($("#txtMarketPrice_two").val());
          $("#S_OpGoods2_ctl00_hidScore_cv").val($("#txtScore_cv").val());
          $("#S_OpGoods2_ctl00_hidShopPrice_free").val($("#txtShopPrice_free").val());
          $("#S_OpGoods2_ctl00_hidMarketPrice_free").val($("#txtMarketPrice_free").val());

          $("#S_OpGoods2_ctl00_hidShopPrice_five").val($("#txtShopPrice_five").val());
          $("#S_OpGoods2_ctl00_hidMarketPrice_five").val($("#txtMarketPrice_five").val());
          $("#S_OpGoods2_ctl00_hidShopPrice_six").val($("#txtShopPrice_six").val());
          $("#S_OpGoods2_ctl00_hidMarketPrice_six").val($("#txtMarketPrice_six").val());
          $("#S_OpGoods2_ctl00_hidShopPrice_seven").val($("#txtShopPrice_seven").val());
          $("#S_OpGoods2_ctl00_hidMarketPrice_seven").val($("#txtMarketPrice_seven").val());
          $("#S_OpGoods2_ctl00_hidShopPrice_eight").val($("#txtShopPrice_eight").val());
          $("#S_OpGoods2_ctl00_hidMarketPrice_eight").val($("#txtMarketPrice_eight").val());

          $("#S_OpGoods2_ctl00_hidScore_Pv_a_CTC").val($("#txtScore_Pv_a_CTC").val());
          $("#S_OpGoods2_ctl00_hidScore_hv_CTC").val($("#txtScore_hv_CTC").val());
          $("#S_OpGoods2_ctl00_hidShopPrice_one_CTC").val($("#txtShopPrice_one_CTC").val());
          $("#S_OpGoods2_ctl00_hidMarketPrice_one_CTC").val($("#txtMarketPrice_one_CTC").val());

        

          $("#S_OpGoods2_ctl00_hidColor").val($("#txtColor").val());
          $("#S_OpGoods2_ctl00_hidSize").val($("#txtSize").val());

          $("#S_OpGoods2_ctl00_hidScore_pv_cv_DT").val($("#txtScore_pv_cv_DT").val());
          $("#S_OpGoods2_ctl00_hidShopPrice_DT").val($("#txtShopPrice_DT").val());
          $("#S_OpGoods2_ctl00_hidMarketPrice_DT").val($("#txtMarketPrice_DT").val());


          $("#S_OpGoods2_ctl00_hiddenMaxNumber_one").val($("#txtMaxNumber_one").val());
          $("#S_OpGoods2_ctl00_hiddenMyPrice").val($("#txtMyPrice").val());
          $("#S_OpGoods2_ctl00_hiddentxtUnitNumber").val($("#txtUnitNumber").val());
          $("")
          //是否是虚拟物品
          $("input[name='IsReal']").each(function() {
              if ($(this).is(":checked")) {
                  $("#S_OpGoods2_ctl00_hidIsReal").val($(this).val());
              }
          });
          var $selectbrand = $(".select_Brand").find("option:selected");
          if ($selectbrand.text() == "其它") {
              $("#S_OpGoods2_ctl00_hidBrand").val($selectbrand.val() + "," + $("#txtPersonBrand").val());
          } else if ($selectbrand.val() != "0") {
              $("#S_OpGoods2_ctl00_hidBrand").val($selectbrand.val() + "," + $selectbrand.text());
          }

          /*提交时候操作规格相关方法*/
          var spec_check = new Array();
          $('span[spec_check="this_check"] > input[type="checkbox"]:checked').each(function() {
              spec_check.push($(this).attr("lang") + "," + $(this).attr("spec_type") + "," + $(this).parent().parent().find("input[sepc_value='this_name']").val().replace("|", "").replace(",", "") + "," + $(this).parent().parent().parent().parent().next().find("input[sepc_pic='filePath_" + $(this).attr("spec_type") + "']").val());
          });
          $("#S_OpGoods2_ctl00_hidSpec_Check").val(spec_check.join("|")); //取得规格选中值  4,黑色,blob:a518296c-d429-425a-abb2-8704742ce1a7|39,160/80(XS),
          var arrvd = new  Array();
          $("input[name='check_spec']").each(function() {
              if (!$(this).is(":checked") && $(this).attr("vd") != "") {
                  arrvd.push($(this).attr("vd"));
              }
          });
          $("#S_OpGoods2_ctl00_hidVd").val(arrvd.join(","));
          var spec_stock = new Array();
          var spec_stock_value = new Array();
          var bflag = true, bflag2 = true, bflag3 = true;
          var baseid = null, strV = null;
          var objthis;
          $('#Spec_body tr').find("input").each(function() {
              if ($(this).attr("name") == "spec[sp_value]") {
                  strV = null;
                  bflag2 = true;
                  spec_stock.push($(this).attr("value").replace("*", "x") + "," + $(this).attr("sp_id"));
                  if (bflag) {
                      baseid = $(this).attr("spec_bunch");
                      bflag = false;
                  }
              } else {
                  if (bflag2) {
                      strV = baseid;
                      baseid = null;
                      strV = spec_stock.join("|") + "*" + strV;
                      spec_stock = new Array();
                      bflag = true;
                      bflag2 = false;
                  }
                  if ($(this).attr("data_type") == "goods_price") {
                      if ($(this).val() == "" || $(this).val() == "0.00") {
                          objthis = $(this);
                          bflag3 = false;
                          return false;
                      }
                      strV += "," + $(this).val();
                  }
                  if ($(this).attr("data_type") == "goods_stock") {
                      if ($(this).val() == "") {
                          objthis = $(this);
                          bflag3 = false;
                          return false;
                      }
                      strV += "," + $(this).val();
                  }
                  if ($(this).attr("data_type") == "goods_no") {
                      strV += "," + $(this).val();
                      spec_stock_value.push(strV);
                  }

              }
          });
          if (!bflag3) {
              objthis.focus();
              objthis.addClass("errortxt");
              errorflag = 5;
              window.scrollTo(0, 600);
              $("#stockSpec").show();
              return bflag3;
          }
          $("#S_OpGoods2_ctl00_hidBaseStock").val(spec_stock_value.join("&")); //取得库存值 
          /*提交时候操作规格相关方法*/
          var checklen = $(".yansda").length;
          var icheckv = 0;
          $(".yansda .spec").each(function() {
              var isflag = true;
              $(this).find("input[name='check_spec']").each(function() {
                  if ($(this).attr("checked") && isflag) {
                      icheckv++;
                      isflag = false;
                  }
              });
          });
          if (icheckv != checklen && icheckv != 0) {
              alert("规格组必须选择！");
              return false;
          }

          /*提交时候操作属性相关方法*/
          var baseprop = new  Array();
          var user_input = new Array();
          $("#S_OpGoods1_ctl00_Prop_show .prop_handinput_text").each(function() {
              $(this).find("tr").each(function() {
                  var defined_txt;
                  $(this).find("input").each(function() {
                      if ($(this).attr("name") == "input_defined_1" && $(this).val() != "") {
                          defined_txt = $(this).val();
                      }
                      if ($(this).attr("name") == "input_defined_2" && $(this).val() != "") {
                          defined_txt = defined_txt + "%" + $(this).val();
                      }
                  });
                  user_input.push(defined_txt);
              });
              baseprop.push($(this).attr("lang") + "," + user_input.join("*"));
          });
          //,11%22*33%44*55%66*77%88*99%00
          $("#S_OpGoods1_ctl00_Prop_show .prop_txtinput_text").each(function() {
              baseprop.push($(this).attr("prop_type") + "," + $(this).val());
          });
          //文字输入 
          $("#S_OpGoods1_ctl00_Prop_show .prop_radio_text").each(function() {
              if ($(this).is(":checked")) {
                  baseprop.push($(this).attr("prop_type"));
              }
          });
          $("#S_OpGoods1_ctl00_Prop_show .prop_select_text").each(function() {
              if ($(this).val() != "000") {
                  baseprop.push($(this).attr("prop_type") + "," + $(this).find("option:selected").val() + ",");
              }
          });
          //下拉框选择
          $("#S_OpGoods1_ctl00_Prop_show .prop_list_check").each(function() {
              if ($(this).is(":checked")) {
                  baseprop.push($(this).attr("prop_type") + ",");
              }
          }); //列表多选  
          var checkidarry = new Array();
          var checknamearry = new Array();
          var checkshoptype = true;
          $("input[name='shopCat']").each(function() {
              if ($(this).is(":checked")) {
                  checkshoptype = false;
                  checkidarry.push($(this).val());
                  checknamearry.push($(this).next().text());
              }
          });
          if (checkshoptype) {
              $(".xiangxsp_nr").find("span[check='errorMsg']").show();
              errorflag = 7;
              window.scrollTo(0, 2400);
          }
          /*提交时候操作属性相关方法*/
          $("#S_OpGoods2_ctl00_hidBaseProp").val(baseprop.join("|"));
          /*操作商品图片方法*/
          var isshowImg = true;
          $("img[name='pro_img']").each(function() {
              if ($(this).attr("src") != "/ImgUpload/noimg.jpg_100x100.jpg") {
                  isshowImg = false;
              }
          });
          if (isshowImg) {
              $(".select_Brand").focus();
              $("#showpic").show();
              errorflag = 9;
          }
          $("#S_OpGoods2_ctl00_hidproImage").val($("#imgvj_1").attr("src"));
          var pro_imgap = new Array();
          $("img[name='pro_img']").each(function() {
              if ($(this).attr("src").indexOf("noimg") == -1) {
                  pro_imgap.push($(this).attr("src"));
              }
          });
          $("#S_OpGoods2_ctl00_hidpro_img").val(pro_imgap.join(","));
          /*操作商品图片方法*/
          var info = $("#p_local").getLocation();
          if (info.pcode == "0") {
              $("#p_local").next().show();
              window.scrollTo(0, 2100);
              errorflag = 6;
          }
          $("#S_OpGoods2_ctl00_hidarea").val(info.province + "," + info.city + "," + info.district + "|" + info.pcode + "," + info.ccode + "," + info.dcode);
          $("#S_OpGoods2_ctl00_hidProductSeries").val(checkidarry.join(",") + "|" + checknamearry.join(","));
          //邮费模板不能为空验证
          if ($("#S_OpGoods2_ctl00_hidsubfee").val() == "0" && $("#S_OpGoods2_ctl00_hidfee_template").val() == "" && $("#S_OpGoods2_ctl00_hidfee").val() == "0") {
              $("#fee_check").show();
              window.scrollTo(0, 2200);
              errorflag = 8;
          }
          $("#spanload").show();

          var p_starttime = $("#S_OpGoods2_ctl00_Panic_starttime").val().replaceAll("-", "/");
          var p_endtime = $("#S_OpGoods2_ctl00_Panic_endtime").val().replaceAll("-", "/");
          if (Date.parse(new Date(p_starttime)) > Date.parse(new Date(p_endtime)) && $("input[name='isPanic']:checked").val() == "1") {
              $("#ftime").show();
              errorflag = 10;
          }

          if ($("#S_OpGoods2_ctl00_txtWapDetail").text().length > 4000) {
              $("#wapdetailfont").css("color", "red");
              window.scrollTo(0, 2000);
              return false;
          }

          if (errorflag != 0) {
              switch (errorflag) {
              case "1":
                  window.scrollTo(0, 150);
                  return false;
                  break;
              case "2":
                  window.scrollTo(0, 500);
                  return false;
                  break;
              case "3":
                  window.scrollTo(0, 700);
                  return false;
                  break;
              case "4":
                  window.scrollTo(0, 800);
                  return false;
                  break;
              case "5":
                  window.scrollTo(0, 600);
                  return false;
                  break;
              case "6":
                  window.scrollTo(0, 2100);
                  return false;
                  break;
              case "7":
                  window.scrollTo(0, 2200);
                  return false;
                  break;
              case "8":
                  window.scrollTo(0, 2200);
                  return false;
                  break;
              case "9":
                  window.scrollTo(0, 2200);
                  return false;
                  break;
              case "10":
                  window.scrollTo(0, 2400);
                  return false;
                  break;
              }
              return false;
          }
          //alert($("#S_OpGoods2_ctl00_txtDetail").val());return false;
          var newspec = new Array();
          $("input[name='hidNewSpec']").each(function() {
              newspec.push($(this).val());
          });
          $("#S_OpGoods2_ctl00_hidNewSpecs").val(newspec.join(","));
          return true;
      } else {
          return false;
      }
  }

  String.prototype.replaceAll = function(reallyDo, replaceWith, ignoreCase) {
      if (!RegExp.prototype.isPrototypeOf(reallyDo)) {
          return this.replace(new RegExp(reallyDo, (ignoreCase ? "gi" : "g")), replaceWith);
      } else {
          return this.replace(reallyDo, replaceWith);
      }
  };
//设置商品相关的参数
  $(function() {

      $("input[name='IsReal']").click(function() {
          if ($(this).val() == "0") {
              $("input[name='fee_check']").each(function() {
                  if ($(this).val() == "0") {
                      $(this).attr("disabled", "disabled");
                  }
              });
          } else {
              $(this).removeAttr("disabled");
          }
      });
      //设置宝贝类型隐藏域
      $("input[name='gType']").click(function() {
          $("#S_OpGoods2_ctl00_hidGType").val($(this).val());
      });
//              //设置商品类型隐藏域
//              $("input[name='pType']").click(function(){
//                   if($(this).checked
//                   $("#S_OpGoods2_ctl00_hidPType").val($(this).attr("id"));
//              });

      $("input[name='fee_check']").click(function() {
          $("#S_OpGoods2_ctl00_hidfee").val($(this).val());
          if ($(this).val() == "1") {
              $("#selectfee").hide();
          } else {
              $("#selectfee").show();
          }
      });
      $("input[name='sub_fee_check']").click(function() {
          $("#S_OpGoods2_ctl00_hidsubfee").val($(this).val());
          if ($(this).val() == "0") {
              $("#subfee").show();
          } else {
              $("#subfee").hide();
          }
      });
      //jely 20130629编写的基于jquery区域下拉联动插件
      $("#p_local").LocationSelect();

      $("input[name='publishGoods']").click(function() {
          $("#S_OpGoods2_ctl00_hidpublishGoods").val($(this).val());
          $("#S_OpGoods2_ctl00_txtSendTime").attr("disabled", "disabled");
          if ($(this).val() == "1") {
              $("#S_OpGoods2_ctl00_txtSendTime").removeAttr("disabled");
          }
      });
      var checkAddProduct = $("#S_OpGoods2_ctl00_hidTipMsg").val();
      var tipAdd = new Array();
      if (checkAddProduct.indexOf("|") != -1) {
          tipAdd = checkAddProduct.split("|");
          if (tipAdd[0] == "0") {
              $("#btnOk").attr("disabled", "disabled");
              $("#erroradd").show();
          }
      }
      $("input[name='isPanic']").change(function() {
          $("#S_OpGoods2_ctl00_hidState").val($(this).val());
          if ($(this).val() == "1") {
              $("#spanendtime").show();
              $(".showPanic").show();
              window.scrollTo(0, 2100);
              if (tipAdd[1] == "0") {
                  $("#btnOk").attr("disabled", "disabled");
                  $("#erroradd").show();
              } else {
                  $("#btnOk").removeAttr("disabled");
                  $("#erroradd").hide();
              }
          } else {
              $("#spanendtime").hide();
              $(".showPanic").hide();
          }
      });

      $("input[name='setStock']").click(function() {
          $("#S_OpGoods2_ctl00_hidsubStock").val($(this).val());
      });


      $("input[name='file_btn']").click(function() {
          if (confirm("是否删除？")) {
              $this = $(this);
              $this.parent().prev().find("img").attr("src", "/ImgUpload/noimg.jpg_100x100.jpg");
              $this.parent().hide().next().show();
              return false;
              if ($(this).parent().prev().find("img").attr("src").indexOf("noimg") == -1) {
                  var delUrl = "/Api/ShopAdmin/S_DeleteOp.ashx?delid=&type=delpic&path=" + $(this).parent().prev().find("img").attr("src").replaceAll("/", "-");
                  $.get(delUrl, null, function(data) {
                      $this.parent().prev().find("img").attr("src", "/ImgUpload/noimg.jpg_100x100.jpg");
                      $this.parent().hide().next().show();
                  });
              } else {
                  $this.parent().prev().find("img").attr("src", "/ImgUpload/noimg.jpg_100x100.jpg");
                  $this.parent().hide().next().show();
              }
          }
      });
      $("span[check='checksubType']").each(function() {
          if ($(this).next().text().trim() == "") {
              $(this).hide();
          } else {
              $(this).prev().hide();
          }

      });
      $("input[name='spec_Detail']").each(function() {
          var SpecDetail = $(this).val();
          var SpecArry = SpecDetail.split("|");
          var SpecNewArry = new Array();
          for (var Vx in SpecArry) {
              SpecNewArry.push('<td><input type="hidden" value="' + SpecArry[Vx].split(',')[0] + '" sp_id="' + SpecArry[Vx].split(',')[1] + '" spec_bunch="' + $(this).attr("SpecTotal") + '" name="spec[sp_value]">' + SpecArry[Vx].split(',')[0] + '</td>');
          }
          $(this).parent().prepend(SpecNewArry.join(""));
      });
  });
///店铺模板处理
  var lock = 0;

  function SelectShopPostage(obj) {
      if (lock == 0) {
          var template = window.showModalDialog("S_FeeTemplate_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:350px");
          if (template != null) {
              var tArray = new Array();
              tArray = template.split(',');
              $(obj).val("重新选择模板");
              $(obj).prev().text(tArray[1]);
              $("#S_OpGoods2_ctl00_hidfee_template").val(tArray[0] + "," + tArray[1]);
          }
      }
  }

//反绑定商品相关
  $(function () {
      $(".spec_txt").each(function () {
          V[$(this).attr("spec_type")] = $(this).val();
      });

      $("#txtGoodsName").val($("#S_OpGoods2_ctl00_hidName").val());
      $("input[name='IsReal']").each(function () {
          if ($(this).val() == $("#S_OpGoods2_ctl00_hidIsReal").val()) {
              $(this).click();
          }
      });
      $("input[name='gType']").each(function () {
          if ($(this).val() == $("#S_OpGoods2_ctl00_hidGType").val()) {
              $(this).click();
          }
      });
      $("input[name='pType']").each(function () {
          if ($("#S_OpGoods2_ctl00_hidPType").val() != "") {
              if ($("#S_OpGoods2_ctl00_hidPType").val().indexOf($(this).attr("id")) != -1) {
                  $(this).attr("checked", "checked");
              }
          }
      });

      $("#txtStock").val($("#S_OpGoods2_ctl00_hidRepertoryCount").val());
      $("#txtRepertoryAlertCount").val($("#S_OpGoods2_ctl00_hidRepertoryAlertCount").val());
      /* $("#txtShopPrice_one").val($("#S_OpGoods2_ctl00_hidShopPrice").val());*/
      /*  $("#txtMarketPrice_one").val($("#S_OpGoods2_ctl00_hidMarketPrice").val());*/
      $("#txtNumber").val($("#S_OpGoods2_ctl00_hidProductNum").val());
      $("#txtUnitname").val($("#S_OpGoods2_ctl00_hidUnitName").val());
      /*if ($("#txtRepertoryAlertCount").val() != "") {*/
      //
      //大唐专区可得积分 txtScore_Pv_a hidScore_Pv_a
      if ($("#S_OpGoods2_ctl00_hidScore_Pv_a").val() == "") {
          $("#txtScore_Pv_a").val("0.00");
      }
      else {
          $("#txtScore_Pv_a").val($("#S_OpGoods2_ctl00_hidScore_Pv_a").val());
      }


      //大唐专区可得红包  txtScore_hv hidScore_hv
      if ($("#S_OpGoods2_ctl00_hidScore_hv").val() == "") {
          $("#txtScore_hv").val("0.00");
      }
      else {
          $("#txtScore_hv").val($("#S_OpGoods2_ctl00_hidScore_hv").val());
      }


      //大唐专区商品价格  txtShopPrice_one   hidShopPrice
      if ($("#S_OpGoods2_ctl00_hidShopPrice").val() == "") {
          $("#txtShopPrice_one").val( "0.00");
      }
      else {
          $("#txtShopPrice_one").val($("#S_OpGoods2_ctl00_hidShopPrice").val());
      }


      //大唐专区市场价格  txtMarketPrice_one hidMarketPrice
      if ($("#S_OpGoods2_ctl00_hidMarketPrice").val() == "") {
          $("#txtMarketPrice_one").val("0.00");
      }
      else {
          $("#txtMarketPrice_one").val($("#S_OpGoods2_ctl00_hidMarketPrice").val());
      }


      //VIP专区可得积分  txtScore_Pv_a_two  hidScore_Pv_a_two
      if ($("#S_OpGoods2_ctl00_hidScore_pv_a_two").val() == "") {
          $("#txtScore_Pv_a_two").val("0.00");
      }
      else {
          $("#txtScore_Pv_a_two").val($("#S_OpGoods2_ctl00_hidScore_pv_a_two").val());
      }


      //VIP专区可用红包   txtScore_max_hv  hidScore_max_hv
      if ($("#S_OpGoods2_ctl00_hidScore_max_hv").val() == "") {
          $("#txtScore_max_hv").val("0.00");
      }
      else {
          $("#txtScore_max_hv").val($("#S_OpGoods2_ctl00_hidScore_max_hv").val());
      }

     

      //VIP专区商品价格  txtShopPrice_two  hidShopPrice_two
      if ($("#S_OpGoods2_ctl00_hidShopPrice_two").val() == "") {
          $("#txtShopPrice_two").val( "0.00");
      }
      else {
          $("#txtShopPrice_two").val($("#S_OpGoods2_ctl00_hidShopPrice_two").val());
      }


      //VIP专区市场价格  txtMarketPrice_two  hidMarketPrice_two
      if ($("#S_OpGoods2_ctl00_hidMarketPrice_two").val() == "") {
          $("#txtMarketPrice_two").val("0.00");
      }
      else {
          $("#txtMarketPrice_two").val($("#S_OpGoods2_ctl00_hidMarketPrice_two").val());

      }

      //积分专区可用积分  txtScore_cv  hidScore_cv
      if ($("#S_OpGoods2_ctl00_hidScore_cv").val() == "") {
          $("#txtScore_cv").val("0.00");
      }
      else {
          $("#txtScore_cv").val($("#S_OpGoods2_ctl00_hidScore_cv").val());
      }


      //积分专区商品价格  txtShopPrice_free  hidShopPrice_free
      if ($("#S_OpGoods2_ctl00_hidShopPrice_free").val() == "") {
          $("#txtShopPrice_free").val("0.00");
      }
      else {
          $("#txtShopPrice_free").val($("#S_OpGoods2_ctl00_hidShopPrice_free").val());
      }


      //积分专区市场价格  txtMarketPrice_free  hidMarketPrice_free
      if ($("#S_OpGoods2_ctl00_hidMarketPrice_free").val() == "") {
          $("#txtMarketPrice_free").val("0.00");
      }
      else {
          $("#txtMarketPrice_free").val($("#S_OpGoods2_ctl00_hidMarketPrice_free").val());
      }


      // 区代专区首次购物价格商品价格  txtShopPrice_five  hidShopPrice_five
      if ($("#S_OpGoods2_ctl00_hidShopPrice_five").val() == "") {
          $("#txtShopPrice_five").val("0.00");
      }
      else {
          $("#txtShopPrice_five").val($("#S_OpGoods2_ctl00_hidShopPrice_five").val());
      }


      //区代专区首次购物市场价格  txtMarketPrice_five  hidMarketPrice_five
      if ($("#S_OpGoods2_ctl00_hidMarketPrice_five").val() == "") {
          $("#txtMarketPrice_five").val("0.00");
      }
      else {
          $("#txtMarketPrice_five").val($("#S_OpGoods2_ctl00_hidMarketPrice_five").val());
      }


      //区代专区二次购物价格商品价格  txtShopPrice_six  hidShopPrice_six
      if ($("#S_OpGoods2_ctl00_hidShopPrice_six").val() == "") {
          $("#txtShopPrice_six").val("0.00");
      }
      else {
          $("#txtShopPrice_six").val($("#S_OpGoods2_ctl00_hidShopPrice_six").val());
      }


      //区代专区二次购物市场价格   txtMarketPrice_six   hidMarketPrice_six
      if ($("#S_OpGoods2_ctl00_hidMarketPrice_six").val()=="") {
          $("#txtMarketPrice_six").val("0.00");
      }
      else {
          $("#txtMarketPrice_six").val($("#S_OpGoods2_ctl00_hidMarketPrice_six").val());
      }
     

      //社区店专首次购物价格商品价格  txtShopPrice_seven   hidShopPrice_seven
      if ($("#S_OpGoods2_ctl00_hidShopPrice_seven").val()=="") {
          $("#txtShopPrice_seven").val("0.00");
      }
      else {
          $("#txtShopPrice_seven").val($("#S_OpGoods2_ctl00_hidShopPrice_seven").val());
      }
      

      //社区店专首次购物市场价格  txtMarketPrice_seven   hidMarketPrice_seven
      if ($("#S_OpGoods2_ctl00_hidMarketPrice_seven").val()=="") {
          $("#txtMarketPrice_seven").val("0.00");
      }
      else {
          $("#txtMarketPrice_seven").val($("#S_OpGoods2_ctl00_hidMarketPrice_seven").val());
      }
      

      //社区店专二次购物价格商品价格  txtShopPrice_eight    hidShopPrice_eight
      if ($("#S_OpGoods2_ctl00_hidShopPrice_eight").val()=="") {
          $("#txtShopPrice_eight").val("0.00");
      }
      else {
         $("#txtShopPrice_eight").val($("#S_OpGoods2_ctl00_hidShopPrice_eight").val());
      }
     

      //社区店专二次购物市场价格  txtMarketPrice_eight  hidMarketPrice_eight
      if ($("#S_OpGoods2_ctl00_hidMarketPrice_eight").val()=="") {
          $("#txtMarketPrice_eight").val("0.00");
      }
      else { 
          $("#txtMarketPrice_eight").val($("#S_OpGoods2_ctl00_hidMarketPrice_eight").val());
    
      }
      //我的货物的颜色  hidColor  txtColor
      if ($("#S_OpGoods2_ctl00_hidColor").val() == "") {
          $("#txtColor").val("无");
      }
      else {
          $("#txtColor").val($("#S_OpGoods2_ctl00_hidColor").val());

      }
      //我的货物的尺寸  hidSize  txtSize

      if ($("#S_OpGoods2_ctl00_hidSize").val() == "") {
          $("#txtSize").val("无");
      }
      else {
          $("#txtSize").val($("#S_OpGoods2_ctl00_hidSize").val());

      }
      //CTC可得积分    txtScore_Pv_a_CTC       hidScore_Pv_a_CTC
      if ($("#S_OpGoods2_ctl00_hidScore_Pv_a_CTC").val() == "") {
          $("#txtScore_Pv_a_CTC").val("0.00");
      }
      else {
          $("#txtScore_Pv_a_CTC").val($("#S_OpGoods2_ctl00_hidScore_Pv_a_CTC").val());

      }
      //CTC可用红包    txtScore_hv_CTC         hidScore_hv_CTC
      if ($("#S_OpGoods2_ctl00_hidScore_hv_CTC").val() == "") {
          $("#txtScore_hv_CTC").val("0.00");
      }
      else {
          $("#txtScore_hv_CTC").val($("#S_OpGoods2_ctl00_hidScore_hv_CTC").val());

      }
      //CTC商品价格    txtShopPrice_one_CTC    hidShopPrice_one_CTC
      if ($("#S_OpGoods2_ctl00_hidShopPrice_one_CTC").val() == "") {
          $("#txtShopPrice_one_CTC").val("0.00");
      }
      else {
          $("#txtShopPrice_one_CTC").val($("#S_OpGoods2_ctl00_hidShopPrice_one_CTC").val());

      }
      //CTC市场价格    txtMarketPrice_one_CTC  hidMarketPrice_one_CTC
      if ($("#S_OpGoods2_ctl00_hidMarketPrice_one_CTC").val() == "") {
          $("#txtMarketPrice_one_CTC").val("0.00");
      }
      else {
          $("#txtMarketPrice_one_CTC").val($("#S_OpGoods2_ctl00_hidMarketPrice_one_CTC").val());

      }
      //可得PVC ：txtScore_pv_cv_DT  hidScore_pv_cv_DT
      if ($("#S_OpGoods2_ctl00_hidScore_pv_cv_DT").val() == "") {
         $("#txtScore_pv_cv_DT").val("0.00");
      }
      else {
          $("#txtScore_pv_cv_DT").val($("#S_OpGoods2_ctl00_hidScore_pv_cv_DT").val());

      }
      //商品价格：txtShopPrice_DT    hidShopPrice_DT
      if ($("#S_OpGoods2_ctl00_hidShopPrice_DT").val() == "") {
         $("#txtShopPrice_DT").val("0.00");
      }
      else {
          $("#txtShopPrice_DT").val($("#S_OpGoods2_ctl00_hidShopPrice_DT").val());

      }
      //市场价格：txtMarketPrice_DT  hidMarketPrice_DT
      if ($("#S_OpGoods2_ctl00_hidMarketPrice_DT").val() == "") {
          $("#txtMarketPrice_DT").val("0.00");
      }
      else {
          $("#txtMarketPrice_DT").val($("#S_OpGoods2_ctl00_hidMarketPrice_DT").val());

      }
      //首购数量限制
      if ($("#S_OpGoods2_ctl00_hiddenMaxNumber_one").val() == "") {
          $("#txtMaxNumber_one").val("100000");
      }
      else {
          $("#txtMaxNumber_one").val($("#S_OpGoods2_ctl00_hiddenMaxNumber_one").val());

      }
      if ($("#S_OpGoods2_ctl00_hiddenMyPrice").val() == "") {
          $("#txtMyPrice").val("0");
      }
      else {
          $("#txtMyPrice").val($("#S_OpGoods2_ctl00_hiddenMyPrice").val());

      }
      //发货数量
      if ($("#S_OpGoods2_ctl00_hiddentxtUnitNumber").val() == "") {
          $("#txtUnitNumber").val("1");
      }
      else {
          $("#txtUnitNumber").val($("#S_OpGoods2_ctl00_hiddentxtUnitNumber").val());

      }
      

      /* }  */
      if ($("#S_OpGoods2_ctl00_hidpro_img").val() != "") {
          var arryimg = $("#S_OpGoods2_ctl00_hidpro_img").val().split(",");
          if (arryimg.length != 0) {
              try {
                  $("img[name='pro_img']").each(function (i) {
                      if (arryimg[i].toString().indexOf("noimg") == -1) {
                          $(this).attr("src", arryimg[i]);
                          $(this).removeAttr("onerror");
                          $("#file_" + i + "_del").show();
                          $("#file_" + i + "_upload").hide();
                      } else {
                          $(this).attr("src", "/ImgUpload/noimg.jpg_100x100.jpg");
                      }
                  });
              } catch (e) {
              }
          } else {
              $("#imgvj_1").attr("src", $("#S_OpGoods2_ctl00_hidpro_img").val());
              $("#imgvj_1").removeAttr("onerror");
          }
      }
      var area = $("#S_OpGoods2_ctl00_hidarea").val().split("|");
      if ($("#S_OpGoods2_ctl00_hidarea").val() != "") {
          var areacode = area[1].split(",");
          var areaname = area[0].split(",");
          if (area[1] != "") {
              if (areaname[0] != "" || areaname[0] != "undefined") {
                  $("select[name='province']").append("<option value=\"" + areacode[0] + "\" selected=\"selected\">" + areaname[0] + "</option>");
              }
              if (areaname[1] != "" || areaname[1] != "undefined") {
                  $("select[name='city']").append("<option value=\"" + areacode[1] + "\" selected=\"selected\">" + areaname[1] + "</option>");
              }
              if (areaname[2] != "" || areaname[2] != "undefined") {
                  $("select[name='district']").append("<option value=\"" + areacode[2] + "\" selected=\"selected\">" + areaname[2] + "</option>");
              }
          }
      }
      $("input[name='fee_check']").each(function () {
          if ($(this).val() == $("#S_OpGoods2_ctl00_hidfee").val()) {
              $(this).click();
          }
      });
      $("input[name='sub_fee_check']").each(function () {
          if ($(this).val() == $("#S_OpGoods2_ctl00_hidsubfee").val()) {
              $(this).click();
          }
      });
      var shoptype = $("#S_OpGoods2_ctl00_hidProductSeries").val().split('|');
      if (shoptype[0] != "") {
          var shopcode = shoptype[0].split(",");
          for (var i in shopcode) {
              $("#shopCatId" + shopcode[i]).attr("checked", "checked");
          }
      }
      $("input[name='publishGoods']").each(function () {
          if ($(this).val() == $("#S_OpGoods2_ctl00_hidpublishGoods").val()) {
              $(this).click();
          }
      });
      $("input[name='setStock']").each(function () {
          if ($(this).val() == $("#S_OpGoods2_ctl00_hidsubStock").val()) {
              $(this).click();
          }
      });

      $("input[name='isPanic']").each(function () {
          if ($(this).val() == $("#S_OpGoods2_ctl00_hidState").val()) {
              $(this).click();
              if ($(this).val() == "1") {
                  $("#spanendtime").show();
                  $(".showPanic").show();
                  window.scrollTo(0, 2200);
              }
          }
      });
      $("#S_OpGoods2_ctl00_Panic_starttime").val($("#S_OpGoods2_ctl00_txtSendTime").val());
  });

  (function($) {
      $.fn.extend({
          insertAtCaret: function(myValue) {
              var $t = $(this)[0];
              if (document.selection) {
                  this.focus();
                  sel = document.selection.createRange();
                  sel.text = myValue;
                  this.focus();
              } else if ($t.selectionStart || $t.selectionStart == '0') {
                  var startPos = $t.selectionStart;
                  var endPos = $t.selectionEnd;
                  var scrollTop = $t.scrollTop;
                  $t.value = $t.value.substring(0, startPos) + myValue + $t.value.substring(endPos, $t.value.length);
                  this.focus();
                  $t.selectionStart = startPos + myValue.length;
                  $t.selectionEnd = startPos + myValue.length;
                  $t.scrollTop = scrollTop;
              } else {
                  this.value += myValue;
                  this.focus();
              }
          }
      });
  })(jQuery);


  var Page_ValidationVer = "125";
  var Page_IsValid = true;
  var Page_BlockSubmit = false;
  var Page_InvalidControlToBeFocused = null;

  function ValidatorUpdateDisplay(val) {
      if (typeof(val.display) == "string") {
          if (val.display == "None") {
              return;
          }
          if (val.display == "Dynamic") {
              val.style.display = val.isvalid ? "none" : "inline";
              return;
          }
      }
      if ((navigator.userAgent.indexOf("Mac") > -1) &&
          (navigator.userAgent.indexOf("MSIE") > -1)) {
          val.style.display = "inline";
      }
      val.style.visibility = val.isvalid ? "hidden" : "visible";
  }

  function ValidatorUpdateIsValid() {
      Page_IsValid = AllValidatorsValid(Page_Validators);
  }

  function AllValidatorsValid(validators) {
      if ((typeof(validators) != "undefined") && (validators != null)) {
          var i;
          for (i = 0; i < validators.length; i++) {
              if (!validators[i].isvalid) {
                  return false;
              }
          }
      }
      return true;
  }

  function ValidatorHookupControlID(controlID, val) {
      if (typeof(controlID) != "string") {
          return;
      }
      var ctrl = document.getElementById(controlID);
      if ((typeof(ctrl) != "undefined") && (ctrl != null)) {
          ValidatorHookupControl(ctrl, val);
      } else {
          val.isvalid = true;
          val.enabled = false;
      }
  }

  function ValidatorHookupControl(control, val) {
      if (typeof(control.tagName) != "string") {
          return;
      }
      if (control.tagName != "INPUT" && control.tagName != "TEXTAREA" && control.tagName != "SELECT") {
          var i;
          for (i = 0; i < control.childNodes.length; i++) {
              ValidatorHookupControl(control.childNodes[i], val);
          }
          return;
      } else {
          if (typeof(control.Validators) == "undefined") {
              control.Validators = new Array;
              var eventType;
              if (control.type == "radio") {
                  eventType = "onclick";
              } else {
                  eventType = "onchange";
                  if (typeof(val.focusOnError) == "string" && val.focusOnError == "t") {
                      ValidatorHookupEvent(control, "onblur", "ValidatedControlOnBlur(event); ");
                  }
              }
              ValidatorHookupEvent(control, eventType, "ValidatorOnChange(event); ");
              if (control.type == "text" ||
                  control.type == "password" ||
                  control.type == "file") {
                  ValidatorHookupEvent(control, "onkeypress",
                      "if (!ValidatedTextBoxOnKeyPress(event)) { event.cancelBubble = true; if (event.stopPropagation) event.stopPropagation(); return false; } ");
              }
          }
          control.Validators[control.Validators.length] = val;
      }
  }

  function ValidatorHookupEvent(control, eventType, functionPrefix) {
      var ev;
      eval("ev = control." + eventType + ";");
      if (typeof(ev) == "function") {
          ev = ev.toString();
          ev = ev.substring(ev.indexOf("{") + 1, ev.lastIndexOf("}"));
      } else {
          ev = "";
      }
      var func;
      if (navigator.appName.toLowerCase().indexOf('explorer') > -1) {
          func = new Function(functionPrefix + " " + ev);
      } else {
          func = new Function("event", functionPrefix + " " + ev);
      }
      eval("control." + eventType + " = func;");
  }

  function ValidatorGetValue(id) {
      var control;
      control = document.getElementById(id);
      if (typeof(control.value) == "string") {
          return control.value;
      }
      return ValidatorGetValueRecursive(control);
  }

  function ValidatorGetValueRecursive(control) {
      if (typeof(control.value) == "string" && (control.type != "radio" || control.checked == true)) {
          return control.value;
      }
      var i, val;
      for (i = 0; i < control.childNodes.length; i++) {
          val = ValidatorGetValueRecursive(control.childNodes[i]);
          if (val != "") return val;
      }
      return "";
  }

  function Page_ClientValidate(validationGroup) {
      Page_InvalidControlToBeFocused = null;
      if (typeof(Page_Validators) == "undefined") {
          return true;
      }
      var i;
      for (i = 0; i < Page_Validators.length; i++) {
          ValidatorValidate(Page_Validators[i], validationGroup, null);
      }
      ValidatorUpdateIsValid();
      ValidationSummaryOnSubmit(validationGroup);
      Page_BlockSubmit = !Page_IsValid;
      return Page_IsValid;
  }

  function ValidatorCommonOnSubmit() {
      Page_InvalidControlToBeFocused = null;
      var result = !Page_BlockSubmit;
      if ((typeof(window.event) != "undefined") && (window.event != null)) {
          window.event.returnValue = result;
      }
      Page_BlockSubmit = false;
      return result;
  }

  function ValidatorEnable(val, enable) {
      val.enabled = (enable != false);
      ValidatorValidate(val);
      ValidatorUpdateIsValid();
  }

  function ValidatorOnChange(event) {
      if (!event) {
          event = window.event;
      }
      Page_InvalidControlToBeFocused = null;
      var targetedControl;
      if ((typeof(event.srcElement) != "undefined") && (event.srcElement != null)) {
          targetedControl = event.srcElement;
      } else {
          targetedControl = event.target;
      }
      var vals;
      if (typeof(targetedControl.Validators) != "undefined") {
          vals = targetedControl.Validators;
      } else {
          if (targetedControl.tagName.toLowerCase() == "label") {
              targetedControl = document.getElementById(targetedControl.htmlFor);
              vals = targetedControl.Validators;
          }
      }
      var i;
      for (i = 0; i < vals.length; i++) {
          ValidatorValidate(vals[i], null, event);
      }
      ValidatorUpdateIsValid();
  }

  function ValidatedTextBoxOnKeyPress(event) {
      if (event.keyCode == 13) {
          ValidatorOnChange(event);
          var vals;
          if ((typeof(event.srcElement) != "undefined") && (event.srcElement != null)) {
              vals = event.srcElement.Validators;
          } else {
              vals = event.target.Validators;
          }
          return AllValidatorsValid(vals);
      }
      return true;
  }

  function ValidatedControlOnBlur(event) {
      var control;
      if ((typeof(event.srcElement) != "undefined") && (event.srcElement != null)) {
          control = event.srcElement;
      } else {
          control = event.target;
      }
      if ((typeof(control) != "undefined") && (control != null) && (Page_InvalidControlToBeFocused == control)) {
          control.focus();
          Page_InvalidControlToBeFocused = null;
      }
  }

  function ValidatorValidate(val, validationGroup, event) {
      val.isvalid = true;
      if ((typeof(val.enabled) == "undefined" || val.enabled != false) && IsValidationGroupMatch(val, validationGroup)) {
          if (typeof(val.evaluationfunction) == "function") {
              val.isvalid = val.evaluationfunction(val);
              if (!val.isvalid && Page_InvalidControlToBeFocused == null &&
                  typeof(val.focusOnError) == "string" && val.focusOnError == "t") {
                  ValidatorSetFocus(val, event);
              }
          }
      }
      ValidatorUpdateDisplay(val);
  }

  function ValidatorSetFocus(val, event) {
      var ctrl;
      if (typeof(val.controlhookup) == "string") {
          var eventCtrl;
          if ((typeof(event) != "undefined") && (event != null)) {
              if ((typeof(event.srcElement) != "undefined") && (event.srcElement != null)) {
                  eventCtrl = event.srcElement;
              } else {
                  eventCtrl = event.target;
              }
          }
          if ((typeof(eventCtrl) != "undefined") && (eventCtrl != null) &&
              (typeof(eventCtrl.id) == "string") &&
              (eventCtrl.id == val.controlhookup)) {
              ctrl = eventCtrl;
          }
      }
      if ((typeof(ctrl) == "undefined") || (ctrl == null)) {
          ctrl = document.getElementById(val.controltovalidate);
      }
      if ((typeof(ctrl) != "undefined") && (ctrl != null) &&
          (ctrl.tagName.toLowerCase() != "table" || (typeof(event) == "undefined") || (event == null)) &&
          ((ctrl.tagName.toLowerCase() != "input") || (ctrl.type.toLowerCase() != "hidden")) &&
          (typeof(ctrl.disabled) == "undefined" || ctrl.disabled == null || ctrl.disabled == false) &&
          (typeof(ctrl.visible) == "undefined" || ctrl.visible == null || ctrl.visible != false) &&
          (IsInVisibleContainer(ctrl))) {
          if (ctrl.tagName.toLowerCase() == "table" &&
              (typeof(__nonMSDOMBrowser) == "undefined" || __nonMSDOMBrowser)) {
              var inputElements = ctrl.getElementsByTagName("input");
              var lastInputElement = inputElements[inputElements.length - 1];
              if (lastInputElement != null) {
                  ctrl = lastInputElement;
              }
          }
          if (typeof(ctrl.focus) != "undefined" && ctrl.focus != null) {
              ctrl.focus();
              Page_InvalidControlToBeFocused = ctrl;
          }
      }
  }

  function IsInVisibleContainer(ctrl) {
      if (typeof(ctrl.style) != "undefined" &&
          ((typeof(ctrl.style.display) != "undefined" &&
                  ctrl.style.display == "none") ||
              (typeof(ctrl.style.visibility) != "undefined" &&
                  ctrl.style.visibility == "hidden"))) {
          return false;
      } else if (typeof(ctrl.parentNode) != "undefined" &&
          ctrl.parentNode != null &&
          ctrl.parentNode != ctrl) {
          return IsInVisibleContainer(ctrl.parentNode);
      }
      return true;
  }

  function IsValidationGroupMatch(control, validationGroup) {
      if ((typeof(validationGroup) == "undefined") || (validationGroup == null)) {
          return true;
      }
      var controlGroup = "";
      if (typeof(control.validationGroup) == "string") {
          controlGroup = control.validationGroup;
      }
      return (controlGroup == validationGroup);
  }

  function ValidatorOnLoad() {
      if (typeof(Page_Validators) == "undefined")
          return;
      var i, val;
      for (i = 0; i < Page_Validators.length; i++) {
          val = Page_Validators[i];
          if (typeof(val.evaluationfunction) == "string") {
              eval("val.evaluationfunction = " + val.evaluationfunction + ";");
          }
          if (typeof(val.isvalid) == "string") {
              if (val.isvalid == "False") {
                  val.isvalid = false;
                  Page_IsValid = false;
              } else {
                  val.isvalid = true;
              }
          } else {
              val.isvalid = true;
          }
          if (typeof(val.enabled) == "string") {
              val.enabled = (val.enabled != "False");
          }
          if (typeof(val.controltovalidate) == "string") {
              ValidatorHookupControlID(val.controltovalidate, val);
          }
          if (typeof(val.controlhookup) == "string") {
              ValidatorHookupControlID(val.controlhookup, val);
          }
      }
      Page_ValidationActive = true;
  }

  function ValidatorConvert(op, dataType, val) {

      function GetFullYear(year) {
          var twoDigitCutoffYear = val.cutoffyear % 100;
          var cutoffYearCentury = val.cutoffyear - twoDigitCutoffYear;
          return ((year > twoDigitCutoffYear) ? (cutoffYearCentury - 100 + year) : (cutoffYearCentury + year));
      }

      var num, cleanInput, m, exp;
      if (dataType == "Integer") {
          exp = /^\s*[-\+]?\d+\s*$/;
          if (op.match(exp) == null)
              return null;
          num = parseInt(op, 10);
          return (isNaN(num) ? null : num);
      } else if (dataType == "Double") {
          exp = new RegExp("^\\s*([-\\+])?(\\d*)\\" + val.decimalchar + "?(\\d*)\\s*$");
          m = op.match(exp);
          if (m == null)
              return null;
          if (m[2].length == 0 && m[3].length == 0)
              return null;
          cleanInput = (m[1] != null ? m[1] : "") + (m[2].length > 0 ? m[2] : "0") + (m[3].length > 0 ? "." + m[3] : "");
          num = parseFloat(cleanInput);
          return (isNaN(num) ? null : num);
      } else if (dataType == "Currency") {
          var hasDigits = (val.digits > 0);
          var beginGroupSize, subsequentGroupSize;
          var groupSizeNum = parseInt(val.groupsize, 10);
          if (!isNaN(groupSizeNum) && groupSizeNum > 0) {
              beginGroupSize = "{1," + groupSizeNum + "}";
              subsequentGroupSize = "{" + groupSizeNum + "}";
          } else {
              beginGroupSize = subsequentGroupSize = "+";
          }
          exp = new RegExp("^\\s*([-\\+])?((\\d" + beginGroupSize + "(\\" + val.groupchar + "\\d" + subsequentGroupSize + ")+)|\\d*)"
              + (hasDigits ? "\\" + val.decimalchar + "?(\\d{0," + val.digits + "})" : "")
              + "\\s*$");
          m = op.match(exp);
          if (m == null)
              return null;
          if (m[2].length == 0 && hasDigits && m[5].length == 0)
              return null;
          cleanInput = (m[1] != null ? m[1] : "") + m[2].replace(new RegExp("(\\" + val.groupchar + ")", "g"), "") + ((hasDigits && m[5].length > 0) ? "." + m[5] : "");
          num = parseFloat(cleanInput);
          return (isNaN(num) ? null : num);
      } else if (dataType == "Date") {
          var yearFirstExp = new RegExp("^\\s*((\\d{4})|(\\d{2}))([-/]|\\. ?)(\\d{1,2})\\4(\\d{1,2})\\s*$");
          m = op.match(yearFirstExp);
          var day, month, year;
          if (m != null && (m[2].length == 4 || val.dateorder == "ymd")) {
              day = m[6];
              month = m[5];
              year = (m[2].length == 4) ? m[2] : GetFullYear(parseInt(m[3], 10));
          } else {
              if (val.dateorder == "ymd") {
                  return null;
              }
              var yearLastExp = new RegExp("^\\s*(\\d{1,2})([-/]|\\. ?)(\\d{1,2})\\2((\\d{4})|(\\d{2}))\\s*$");
              m = op.match(yearLastExp);
              if (m == null) {
                  return null;
              }
              if (val.dateorder == "mdy") {
                  day = m[3];
                  month = m[1];
              } else {
                  day = m[1];
                  month = m[3];
              }
              year = (m[5].length == 4) ? m[5] : GetFullYear(parseInt(m[6], 10));
          }
          month -= 1;
          var date = new Date(year, month, day);
          if (year < 100) {
              date.setFullYear(year);
          }
          return (typeof(date) == "object" && year == date.getFullYear() && month == date.getMonth() && day == date.getDate()) ? date.valueOf() : null;
      } else {
          return op.toString();
      }
  }

  function ValidatorCompare(operand1, operand2, operator, val) {
      var dataType = val.type;
      var op1, op2;
      if ((op1 = ValidatorConvert(operand1, dataType, val)) == null)
          return false;
      if (operator == "DataTypeCheck")
          return true;
      if ((op2 = ValidatorConvert(operand2, dataType, val)) == null)
          return true;
      switch (operator) {
      case "NotEqual":
          return (op1 != op2);
      case "GreaterThan":
          return (op1 > op2);
      case "GreaterThanEqual":
          return (op1 >= op2);
      case "LessThan":
          return (op1 < op2);
      case "LessThanEqual":
          return (op1 <= op2);
      default:
          return (op1 == op2);
      }
  }

  function CompareValidatorEvaluateIsValid(val) {
      var value = ValidatorGetValue(val.controltovalidate);
      if (ValidatorTrim(value).length == 0)
          return true;
      var compareTo = "";
      if ((typeof(val.controltocompare) != "string") ||
          (typeof(document.getElementById(val.controltocompare)) == "undefined") ||
          (null == document.getElementById(val.controltocompare))) {
          if (typeof(val.valuetocompare) == "string") {
              compareTo = val.valuetocompare;
          }
      } else {
          compareTo = ValidatorGetValue(val.controltocompare);
      }
      var operator = "Equal";
      if (typeof(val.operator) == "string") {
          operator = val.operator;
      }
      return ValidatorCompare(value, compareTo, operator, val);
  }

  function CustomValidatorEvaluateIsValid(val) {
      var value = "";
      if (typeof(val.controltovalidate) == "string") {
          value = ValidatorGetValue(val.controltovalidate);
          if ((ValidatorTrim(value).length == 0) &&
              ((typeof(val.validateemptytext) != "string") || (val.validateemptytext != "true"))) {
              return true;
          }
      }
      var args = { Value: value, IsValid: true };
      if (typeof(val.clientvalidationfunction) == "string") {
          eval(val.clientvalidationfunction + "(val, args) ;");
      }
      return args.IsValid;
  }

  function RegularExpressionValidatorEvaluateIsValid(val) {
      var value = ValidatorGetValue(val.controltovalidate);
      if (ValidatorTrim(value).length == 0)
          return true;
      var rx = new RegExp(val.validationexpression);
      var matches = rx.exec(value);
      return (matches != null && value == matches[0]);
  }

  function ValidatorTrim(s) {
      var m = s.match(/^\s*(\S+(\s+\S+)*)\s*$/);
      return (m == null) ? "" : m[1];
  }

  function RequiredFieldValidatorEvaluateIsValid(val) {
      return (ValidatorTrim(ValidatorGetValue(val.controltovalidate)) != ValidatorTrim(val.initialvalue));
  }

  function RangeValidatorEvaluateIsValid(val) {
      var value = ValidatorGetValue(val.controltovalidate);
      if (ValidatorTrim(value).length == 0)
          return true;
      return (ValidatorCompare(value, val.minimumvalue, "GreaterThanEqual", val) &&
          ValidatorCompare(value, val.maximumvalue, "LessThanEqual", val));
  }

  function ValidationSummaryOnSubmit(validationGroup) {
      if (typeof(Page_ValidationSummaries) == "undefined")
          return;
      var summary, sums, s;
      for (sums = 0; sums < Page_ValidationSummaries.length; sums++) {
          summary = Page_ValidationSummaries[sums];
          summary.style.display = "none";
          if (!Page_IsValid && IsValidationGroupMatch(summary, validationGroup)) {
              var i;
              if (summary.showsummary != "False") {
                  summary.style.display = "";
                  if (typeof(summary.displaymode) != "string") {
                      summary.displaymode = "BulletList";
                  }
                  switch (summary.displaymode) {
                  case "List":
                      headerSep = "<br>";
                      first = "";
                      pre = "";
                      post = "<br>";
                      end = "";
                      break;
                  case "BulletList":
                  default:
                      headerSep = "";
                      first = "<ul>";
                      pre = "<li>";
                      post = "</li>";
                      end = "</ul>";
                      break;
                  case "SingleParagraph":
                      headerSep = " ";
                      first = "";
                      pre = "";
                      post = " ";
                      end = "<br>";
                      break;
                  }
                  s = "";
                  if (typeof(summary.headertext) == "string") {
                      s += summary.headertext + headerSep;
                  }
                  s += first;
                  for (i = 0; i < Page_Validators.length; i++) {
                      if (!Page_Validators[i].isvalid && typeof(Page_Validators[i].errormessage) == "string") {
                          s += pre + Page_Validators[i].errormessage + post;
                      }
                  }
                  s += end;
                  summary.innerHTML = s;
                  window.scrollTo(0, 0);
              }
              if (summary.showmessagebox == "True") {
                  s = "";
                  if (typeof(summary.headertext) == "string") {
                      s += summary.headertext + "\r\n";
                  }
                  var lastValIndex = Page_Validators.length - 1;
                  for (i = 0; i <= lastValIndex; i++) {
                      if (!Page_Validators[i].isvalid && typeof(Page_Validators[i].errormessage) == "string") {
                          switch (summary.displaymode) {
                          case "List":
                              s += Page_Validators[i].errormessage;
                              if (i < lastValIndex) {
                                  s += "\r\n";
                              }
                              break;
                          case "BulletList":
                          default:
                              s += "- " + Page_Validators[i].errormessage;
                              if (i < lastValIndex) {
                                  s += "\r\n";
                              }
                              break;
                          case "SingleParagraph":
                              s += Page_Validators[i].errormessage + " ";
                              break;
                          }
                      }
                  }
              }
          }
      }
  }

  if (typeof(Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();