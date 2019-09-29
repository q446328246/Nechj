 $(function() {
     $(".cancelActivity").click(function() {
         var id = $(this).attr("lang");
         if (confirm("是否取消该限时折扣活动？")) {
             $.get("/Api/ShopAdmin/S_Limit_ProductOp.ashx?type=cancelAct&id=" + id + "", null, function(data) {
             });
         }
         $(this).hide();
         $(this).parent().prev().text("已取消");

     });
     var discount = $("#S_Limit_AddProduct_ctl00_lblDisCount").text();
     $(".butAdd").click(function() {
         var guid = $(this).attr("lang");
         var $this1 = $(this);
         $.get("/Api/ShopAdmin/S_Limit_ProductOp.ashx?guid=" + guid + "&lid=" + lid + "&discount=" + discount + "&type=addlimitproduct", null, function(data) {
             $this1.parent().text("已参加");
         });
     });
     //删除限时折扣商品
     $(".dellimit").click(function() {
         var id = $(this).attr("lang");
         var $this2 = $(this);
         if (confirm("是否删除该限时折扣商品？")) {
             $.get("/Api/ShopAdmin/S_Limit_ProductOp.ashx?type=del&id=" + id + "", null, function(data) {
                 $this2.parent().parent().remove();
             });
         }
     });
     //取消限制折扣商品
     $(".cancellimit").click(function() {
         var id = $(this).attr("lang");
         var $this2 = $(this);
         if (confirm("是否取消该限时折扣商品？")) {
             $.get("/Api/ShopAdmin/S_Limit_ProductOp.ashx?type=cancel&id=" + id + "", null, function(data) {
                 $this2.parent().parent().remove();
             });
         }
     });
     //鼠标移动过来显示提示修改信息
     $(".nosbe").hover(function() { $(this).children("div").css("display", "block"); }, function() { $(this).children("div").css("display", "none"); });
     //双击修改
     $(".nosbe").dblclick(function() {
         $(this).find(".edit_name").hide();
         $(this).find(".edit_v").show();
     });
     //保存修改
     $(".btn_save").click(function() {
         var discount = $(this).prev().val();
         if (!checkprice(discount)) {
             $(this).parent().next().find(".ord_sub").css("color", "red").text("折扣值不合法！");
             return false;
         }
         $.get("/Api/ShopAdmin/S_Limit_ProductOp.ashx?type=updatediscount&txtdiscount=" + discount + "&id=" + $(this).attr("lang"), null, function(data) {
         });
         $(this).parent().parent().find(".edit_name").text($(this).prev().val());
         $(this).parent().hide();
         $(this).parent().prev().show();
         $(this).parent().next().show().find(".ord_sub").css("color", "").text("双击修改折扣");
     });
 });

//添加限时折扣活动

 function checksub() {
     $("span[check='errormsg']").hide();
     var name = $("#S_Limit_ActivityOpreate_ctl00_txtName").val();
     var starttime = $("#S_Limit_ActivityOpreate_ctl00_txtStartTime").val();
     var endtime = $("#S_Limit_ActivityOpreate_ctl00_txtEndTime").val();
     var DisCount = $("#S_Limit_ActivityOpreate_ctl00_txtDisCount").val();
     if (name == "") {
         $("#S_Limit_ActivityOpreate_ctl00_txtName").focus().next().show().text("活动名称不能为空！");
         return false;
     }
     if (!compareTime($("#showstarttime").text(), starttime)) {
         $("#S_Limit_ActivityOpreate_ctl00_txtStartTime").focus().next().show().text("开始时间必须大于" + $("#showstarttime").text() + "！");
         return false;
     }
     if (!compareTime(starttime, endtime)) {
         $("#S_Limit_ActivityOpreate_ctl00_txtEndTime").focus().next().show().text("开始时间不能大于结束时间！");
         return false;
     }
//               if(!compareTime($("#S_Limit_ActivityOpreate_ctl00_lblStartTime").text(),starttime))
//               {
//                    $("#S_Limit_ActivityOpreate_ctl00_txtEndTime").focus().next().show().text("开始时间不能为空且不能早于2013-07-19！");return false;
//               }
//               if(!compareTime(endtime,$("#S_Limit_ActivityOpreate_ctl00_lblEndTime").text()))
//               {
//                    $("#S_Limit_ActivityOpreate_ctl00_txtEndTime").focus().next().show().text("结束时间不能为空且不能晚于2013-08-19！");return false;
//               }
     if (!checkDisCount(DisCount)) {
         $("#S_Limit_ActivityOpreate_ctl00_txtDisCount").focus().next().show().text("折扣不合法！");
         return false;
     }
     return true;
 }