<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<script runat="server">


</script>
<script src="../js/jquery-1.6.2.min.js" type="text/javascript"></script>
<script type="text/javascript">

    function buyProduct2(guid, pid, client) {
        $.ajax({
            url: '/Api/Shop/ShopProduct.ashx',
            contentType: "application/x-www-form-urlencoded; charset=utf-8",
            data: "guid=" + guid + "&productid=" + pid + "&buynum=" + $('#' + client + "_TextBoxBuyNum1").val() + "&color=" + encodeURI($('#' + client + "_ddlColorcc").val(), "UTF-8") + "&size=" + encodeURI($('#' + client + "_ddlSizecc").val(), "UTF-8") + "&type=" + "5" ,
            success: function (result) {
                if (result == 1) {

                    var mydiv = document.getElementById("div_my_one1");
                    mydiv.style.display = "block"
                    var c = document.body.scrollTop;
                    var cc = c + 400;
                    mydiv.style.top = cc + "px";
                    mydiv.style.position = "absolute";
                    mydiv.style.left = "77%";
                    $("#div_my_one1").hide(2500);
                }
                else if (result == "0") {
                    alert("购买失败了！");
                }

                else {
                    alert(result);
                }
            }
        });
        return false;
    }



    $(function () {
        $(".or_num input[type='text']").each(function () {
            var t_num = $(this).val();
            var t_hidNum = $(this).prev().prev().val();
            if (parseInt(t_num) > parseInt(t_hidNum)) {
                $(this).parent().find(".J_AmountMsg").show();
                $(this).parent().parent().find(".t-checkbox input").removeAttr("checked");
                $(this).parent().parent().find(".t-checkbox input").attr("disabled", "disabled");
            } else {
                $(this).parent().find(".J_AmountMsg").hide();
                $(this).parent().parent().find(".t-checkbox input").attr("checked", true);
                $(this).parent().parent().find(".t-checkbox input").removeAttr("disabled");
            }
            totalPrice();
        });




        //加
        $(".ImgAdd").click
        (
        function () {
            var BuyNum = parseInt($(this).prev().val()) + 1; //购买数量

            if ($(this).prev().val() == "") { BuyNum = "1"; }

            var nowstock = $(this).parent().find("input[name='repstock']").val();

            var specstock = $(this).parent().find("input[name='repSpecStock']").val();
            if (specstock != "")
                nowstock = specstock;
            if (parseInt(nowstock) < parseInt(BuyNum)) {
                $(this).parent().find(".J_AmountMsg").show();
                $(this).val($(this).parent().find(".J_AmountMsg span").text());
                return false;
            }
            $(this).prev().val(BuyNum);



            //小计的计算
            var danjia = parseFloat($(this).parent().prev().prev().find("span").text()); //单价
            danjia = danjia == "" ? "1" : danjia;

            //            var dan = danjia * BuyNum.toFixed(2);
            //            $(".LabelAll").text(dan); //一个

            var labelAll = $(this).parent().next().find("span"); //小计

            $(labelAll).text((danjia * BuyNum).toFixed(2));


            ////商品合计（不含运费）
            var labelAlla = $("span.LabelAll"); //.parents(".order_dateil clearfix").find(".labelAll");//所有小计控件

            var NumlabelAll = 0; var checkAll = $("span[name='t_checkbox'] input");

            for (var i = 0; i < labelAlla.length; i++) {
               
                if (checkAll[i].checked) { NumlabelAll += parseFloat($(labelAlla[i]).text()); }
            }

            $(".labelAllPrice").text(NumlabelAll.toFixed(2)); //商品合计（不含运费）￥ 控件

        }
    );
        //减
        $(".ImgDelete").click
        (
            function () {
                var BuyNum = parseInt($(this).next().val()); //购买数量
                if (BuyNum > 1) {
                    $(this).next().val(BuyNum - 1);
                    BuyNum = BuyNum - 1;
                    //小计的计算
                    var danjia = parseFloat($(this).parent().prev().prev().find("span").text()); //单价
                    danjia = danjia == "" ? "1" : danjia;


                    var labelAll = $(this).parent().next().find("span"); //小计

                    $(labelAll).text((danjia * BuyNum).toFixed(2));


                    ////商品合计（不含运费）
                    var labelAlla = $("span.LabelAll"); //.parents(".order_dateil clearfix").find(".labelAll");//所有小计控件

                    var NumlabelAll = 0; var checkAll = $("span[name='t_checkbox'] input");

                    for (var i = 0; i < labelAlla.length; i++) {
                        if (checkAll[i].checked) { NumlabelAll += parseFloat($(labelAlla[i]).text()); }
                    }

                    $(".labelAllPrice").text(NumlabelAll.toFixed(2)); //商品合计（不含运费）￥ 控件

                }
            }
        );
    });

        function updateNum(o) {
            var BuyNum = parseInt($(o).val()); //购买数量
            if (BuyNum == "0") {
                //$(o).val(1);
                alert("购买不能为0!"); return false;
            }
            if ($(o).val() == "") { BuyNum = "1"; }
            var nowstock = $(o).parent().find("input[name='repstock']").val();
            var specstock = $(o).parent().find("input[name='repSpecStock']").val();
            var shu = nowstock > BuyNum ? BuyNum : nowstock;
            $(o).val(shu);
            if (nowstock < BuyNum) {
                alert("库存不足");
                return false;
            }

            if (specstock != "")
                nowstock = specstock;
            if (nowstock < parseInt(BuyNum)) {
                $(o).parent().find(".J_AmountMsg").show();
                $(o).val($(o).parent().find(".J_AmountMsg span").text());
                return false;
            }
            $(o).parent().find(".J_AmountMsg").hide();
            $(o).parent().parent().find(".t-checkbox input").attr("checked", "checked");
            $(o).parent().parent().find(".t-checkbox input").removeAttr("disabled");

            var danjia = parseFloat($(o).parent().prev().prev().find("span").text()); //单价
            danjia = danjia == "" ? "1" : danjia;
            var labelAll = $(o).parent().next().find("span"); //小计
            $(labelAll).text((danjia * BuyNum).toFixed(2));
            ////商品合计（不含运费）
            var labelAll = $("span.LabelAll");
            var NumlabelAll = 0;
            var checkAll = $("span[name='t_checkbox'] input");
            for (var i = 0; i < labelAll.length; i++) {
                if (checkAll[i].checked) {
                    NumlabelAll += parseFloat($(labelAll[i]).text());

                }
            }
                $(".labelAllPrice").text(NumlabelAll.toFixed(2)); //商品合计（不含运费）￥ 控件
            
            
        }


        $(function () {
            $("span[name='t_checkbox'] input").click(function () {
                var labelAll = $("span.LabelAll");
                var checkAll = $("span[name='t_checkbox'] input");

                var nowstock = $(this).parent().parent().find("input[name='repstock']").val();
                for (var i = 0; i < labelAll.length; i++) {
                    if (checkAll[i].checked) {
                        if (nowstock == "0") {
                            alert("库存不足,不能购买")
                            return false;
                        }

                    }

                    else {
                        totalPrice();
                    }

                }
            });
        });


        function totalPrice() {
            var price = 0;
            $("span[name='t_checkbox'] input").each(function () {
            
                if ($(this).is(":checked")) {
                    
                    price += parseFloat($(this).parent().parent().parent().find(".t-total").text());
                }
            });
            $("#<%=labelAllPrice.ClientID%>").text(price.toFixed(2));
        }

        totalPrice();


        $(function () {
            $(".jiesuan").click(function () {
                var labelAll = $("span.LabelAll");
                var checkAll = $("span[name='t_checkbox'] input");

                for (var i = 0; i < labelAll.length; i++) {
                    if (checkAll[i].checked) {
                        var guid = $(checkAll[i]).parent().parent().find("input[name='lab1']").val();
                        var pid = $(checkAll[i]).parent().parent().find("input[name='lab2']").val();

                        if (i < 10) {

                            var client = "RepeaterData_ctl0" + i;
                            buyProduct2(guid, pid, client);
                        }
                        else {
                            var client = "RepeaterData_ctl" + i;

                            buyProduct2(guid, pid, client);
                        }
                    }
                }
            });
        });



        $(function () {
           /* $(window).bind("scroll", function () {*/
            $(window).scroll(function () {
                if ($(window).scrollTop() >= 100 && $(window).scrollTop() < $(".productList").height()) {
                    $(".shoppingTotals").show();
                }
                else {
                    $(".shoppingTotals").hide();
                }
            });

        });

	</script>
    
    <div class="shoppingTotals">
        <input type="button" name="but" id="Button1"value="加入购物车" class="jiesuan"/>
        <!--
		<asp:Button ID="Button1" runat="server" Text="结算" class="jiesuan" />
        -->
		<div class="heji">合计（不含运费）：<asp:Label ID="label1" runat="server" Text="0" CssClass="labelAllPrice"></asp:Label></div>
	</div>
    
    <!--
<asp:Button ID="butAllPrice" runat="server" Text="Button" />
所有价钱总和(不含运费)<asp:Label ID="labelAllPrice" runat="server" Text="0" CssClass="labelAllPrice"></asp:Label>
-->

<div style="width:100%" class="productList"  >
    <h2>
        <span>区代专区</span>
    </h2>
   <div  style="width:123%;" > 

<!--标题-->


                    
            <div class="column t-goods" style="width:270px; float:left;padding-left:80px">
                店铺宝贝</div>
            <div class="column t-price"style="width:160px; float:left;padding-left:40px;">
                单价(元)</div>
            <div class="column t-num"style="width:80px; float:left;;padding-left:30px">
                购买数量</div>



<!--end-->


    <div style="width:100%"> 
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>


               <div style="width:1000px;float:left; padding-top:30px ; font-size:10px;">            
                       <!--勾选-->
                       <div class="cartcolumn t-checkbox" style="width:20px;float:left; padding:0 10px 0 10px; text-align:center">
                       <div style="">

                                <input type="hidden" value='<%#Eval("guid")%>'  name="lab1"/>
                                <input type="hidden" value='<%#Eval("productId")%>' name="lab2" />
                                </div>
                                    <input type="hidden" value='<%#Eval("ShopPrice")%>' name="shopprice" />
                                    <input type="hidden" value='<%#Eval("RepertoryCount")%>' name="repstock" />
                                    <asp:CheckBox ID="checkbox1" name="t_checkbox" runat="server" CssClass="incheck"
                                    Checked="false" style="padding-right:15px" onclick="aa()"  /> 
                        </div>
                       <!--勾选end-->
                       

                           <div style="width:350px;float:left">
                               <div style="padding-left:6px;width:200px;float:left;font-size:15px;">
                                <a  href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>?category=<%#Eval("shop_category_id")%>'
                                    target="_blank" title='<%# Eval("Name")%>'>
                                    <%# Utils.GetUnicodeSubString(Eval("Name").ToString(),40,"") %>
                                </a>
                                </div>
                                <div style="padding-left:6px;width:100px;float:left;font-size:13px;color:Blue">
                                    &nbsp;颜色：
                                    <asp:DropDownList ID="ddlColorcc" runat="server" Style="width: 40px;">
                                    </asp:DropDownList>
                                    <!--<br/>-->
                            
                                
                                    &nbsp;尺寸：
                                    <asp:DropDownList ID="ddlSizecc" runat="server" Style="width: 40px;">
                                    </asp:DropDownList>                    
                                    <!--<br/>-->
                                </div>
                            </div>
                            

                            <div style="width:40px;float:left">
                                <asp:Literal ID="LiteralProductName" runat="server" Visible="false" Text='<%# Eval("Name").ToString() %>'></asp:Literal>
                            </div>
                            <div style="width:80px;float:left;color:red;font-size:15px;">
                                ¥<asp:Label ID="LiteralGroupPrice" runat="server" Text='<%# Eval("ShopPrice")%>'></asp:Label>元
                            </div>
                            
                            <div style="width:100px;float:left;font-size:10px;">
                                库存：<asp:Label ID="LabelRepertoryCount" runat="server" Text='<%# Eval("RepertoryCount")%>'></asp:Label>件
                            </div>
                            
                                

                                <asp:Literal ID="LiteralProductGuid" runat="server" Text='<%# Eval("guid")%>' Visible="false"></asp:Literal>
                                <asp:Literal ID="LiteralShopName" runat="server" Text='<%# Eval("ShopName")%>' Visible="false"></asp:Literal>
                                <asp:Literal ID="LiteralMemLoginID" runat="server" Text='<%# Eval("MemLoginID")%>'
                                    Visible="false"></asp:Literal>
                                <asp:Literal ID="LiteralProductId" runat="server" Text='<%# Eval("productId")%>'
                                    Visible="false"></asp:Literal>
 




                            <div style="width:87px;float:left;font-size:15px;">
                                    <input type="hidden" value='<%#Eval("ShopPrice")%>' name="shopprice" />
                                    <input type="hidden" value='<%#Eval("RepertoryCount")%>' name="repstock" />
                                    <input type="hidden" value='' name="repSpecStock" />

                                <img class="ImgDelete" src="Themes/Skin_Default/Images/jj.jpg" />&nbsp;
                                    <asp:TextBox ID="TextBoxBuyNum1" runat="server" 
                                        CssClass="or_input" name="textName" style="border: 1px solid #98b2d5;width: 38px;height: 19px;line-height: 19px; padding-top:2px " value="0" onkeyup="NumTxt_Int(this)" onchange="updateNum(this)">
                                     </asp:TextBox>&nbsp;<img class="ImgAdd" src="Themes/Skin_Default/Images/jiaj.jpg" />
                            </div>
                            <div class="cartcolumn t-total" style="display:none";">
                                <b>
                               
                                        <asp:Label ID="LabelAll" CssClass="LabelAll" runat="server" Text="0"/>
                                  
                                   
                                    </b>
                            </div>

                            <div style="width:87px;float:left;display:none";">
                            
                                <asp:Button ID="btnBuyProduct2" runat="server"  Style="font-size: 21px;background: url(Themes/Skin_Default/Images/pb_buts.png) no-repeat;"
                                    Width="87px" Height="30px" BorderStyle="None" ></asp:Button>
                                <br />
                             </div>

                </div>
                            
                       
                        
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div id="div_my_one1" style="display: none; width: 150px; height: 40px; background-color: Red;">
        
            添加成功，已加入购物车</h1>
    </div>

    <div style="width:100%;height:20px;float:left"> </div>
    <div class="shoppingTotals2">
        <input type="button" name="but" id="Button2"value="加入购物车" class="jiesuan"/>
		
		<div class="heji">合计（不含运费）：
        <asp:Label ID="label3" runat="server" Text="0" CssClass="labelAllPrice"></asp:Label>
        </div>
    </div>


</div>
</div>


