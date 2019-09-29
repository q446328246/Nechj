<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<%@ Import Namespace="System.Data" %>
<script src="../../../Main/js/jquery-1.3.1.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    var BrandAjaxUrl = "/Api/S_OpGoods1.ashx?type=0&brand_cid=<%= Request.QueryString["ctype"] %>";

     function checkBox(cb) {
            var oOne = document.getElementById("one");
            var oTwo = document.getElementById("two");
            var oFree =document.getElementById("free");
            var oFive = document.getElementById("five");
            var oSix = document.getElementById("six");
            var oSeven = document.getElementById("seven");
            var oEight = document.getElementById("eight");

            var oDiv1 = document.getElementById("div1");
            var oDiv2 = document.getElementById("div2");
            var oDiv3 = document.getElementById("div3");
            var oDiv4 = document.getElementById("div4");
            var oDiv5 = document.getElementById("div5");
            var oDiv6 = document.getElementById("div6");
            var oDiv7 = document.getElementById("div7");

            
           /*div1的*/
            var txt_one_1=document.getElementById("txtScore_Pv_a");
            var txt_one_2=document.getElementById("txtScore_hv");
            var txt_one_3=document.getElementById("txtShopPrice_one");
            var txt_one_4=document.getElementById("txtMarketPrice_one");
            

             /*div2的*/
            var txt_two_1=document.getElementById("txtScore_Pv_a_two");
            var txt_two_2=document.getElementById("txtScore_max_hv");
            var txt_two_3=document.getElementById("txtShopPrice_two");
            var txt_two_4=document.getElementById("txtMarketPrice_two");

            
             /*div3的*/
            var txt_free_1=document.getElementById("txtScore_cv");
            var txt_free_2=document.getElementById("txtShopPrice_free");
            var txt_free_3=document.getElementById("txtMarketPrice_free");

             /*div4的*/
             var txt_five_1=document.getElementById("txtShopPrice_five");
            var txt_five_2=document.getElementById("txtMarketPrice_five");

             /*div5的*/
             var txt_six_1=document.getElementById("txtShopPrice_six");
            var txt_six_2=document.getElementById("txtMarketPrice_six");

             /*div6的*/
             var txt_seven_1=document.getElementById("txtShopPrice_seven");
            var txt_seven_2=document.getElementById("txtMarketPrice_seven");


             /*div7的*/
             var txt_eight_1=document.getElementById("txtShopPrice_eight");
            var txt_eight_2=document.getElementById("txtMarketPrice_eight");


             
            
            if(cb.checked == true){
            if (cb.id == "one") {
                if (cb.checked) {
                    oDiv1.style.display = "block";
                } 

            } if (cb.id == "two") {
                  if (cb.checked) {
                    oDiv2.style.display = "block";
                } 
               
            }  if (cb.id == "free") {
                if (cb.checked) {
                    oDiv3.style.display = "block";
                } 
                }
                if (cb.id == "five") {
                if (cb.checked) {
                    oDiv4.style.display = "block";
                } 
                }
                if (cb.id == "six") {
                if (cb.checked) {
                    oDiv5.style.display = "block";
                } 
                }
                 if (cb.id == "seven") {
                if (cb.checked) {
                    oDiv6.style.display = "block";
                } 
                }
                 if (cb.id == "eight") {
                if (cb.checked) {
                    oDiv7.style.display = "block";
                } 
                }

              }
                else  if (oTwo.checked == false && oFree.checked == false && oOne.checked == false && oFive.checked == false && oSix.checked == false && oSeven.checked == false && oEight.checked == false)
                 {
                 oDiv3.style.display = "none"; 
                  oDiv2.style.display = "none";
                  oDiv1.style.display = "none"; 

                  oDiv4.style.display = "none"; 
                  oDiv5.style.display = "none"; 
                  oDiv6.style.display = "none"; 
                  oDiv7.style.display = "none"; 
                    alert("分类至少选一个");
                 }
                 if(oOne.checked == false)
                  {
                      oDiv1.style.display = "none";  
                      txt_one_1.value="0.00";
                      txt_one_2.value="0.00";
                      txt_one_3.value="0.00";
                      txt_one_4.value="0.00";
                   }
                    if(oFree.checked == false)
                  {
                      oDiv3.style.display = "none"; 
                     txt_free_1.value="0.00";
                      txt_free_2.value="0.00";
                      txt_free_3.value="0.00";
                   }
                  if(oTwo.checked == false)
                  {
                      oDiv2.style.display = "none";  
                     
                         txt_two_1.value="0.00";
                       txt_two_2.value="0.00";
                       txt_two_3.value="0.00";
                       txt_two_4.value="0.00";
                   }
                   if (oFive.checked == false) {
                   oDiv4.style.display = "none"; 
                          txt_five_1="0.00";
                           txt_five_2="0.00";
                     }
                     if (oSix.checked == false) {
                     oDiv5.style.display = "none"; 
                          txt_six_1="0.00";
                           txt_six_2="0.00";
                     }
                     if (oSeven.checked == false) {
                     oDiv6.style.display = "none"; 
                          txt_seven_1="0.00";
                           txt_seven_2="0.00";
                     }
                     if (oEight.checked == false) {
                     oDiv7.style.display = "none"; 
                          txt_eight_1="0.00";
                           txt_eight_2="0.00";
                     }
                  
                   
                   
        }
</script>
<style type="text/css">
    .editbox
    {
        display: inline;
        height: 25px;
        line-height: 25px;
        padding: 0px;
        width: 35px;
    }
    
    .hint
    {
        color: #BBBBBB;
        line-height: 20px;
    }
    
    input.spec_txt
    {
        border: 1px solid #A7A6AA;
        height: auto;
        margin: 0;
        width: 100px;
    }
</style>

<%
    //这里是判断规格属性品牌如果没有绑定商品类型则更改显示方式
     //if (ShopNum1.Common.Common.ReqStr("pid").Length < 30 || Spec_show.InnerHtml.Length<50) { Spec_show.Visible = false; Prop_show.Visible = false; } %>
<asp:HiddenField ID="hidSetsp" runat="server" />
<input type="hidden" id="hidCategoryName" runat="server" />
<input type="hidden" id="hidEditBind" runat="server" />
<dl class="tibxxbg" style="display: none">
    <dt>宝贝类型：</dt>
    <dd>
        <input name="gType" type="radio" value="0" checked="checked" />全新
        <input name="gType" type="radio" value="1" />二手
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>物品类型：</dt>
    <dd>
        <input name="IsReal" type="radio" value="1" checked="checked" />实际物品
      <%--  <input name="IsReal" type="radio" value="0" />生活服务--%>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>主站商品分类：</dt>
    <dd>
        <div class="fudong" id="productCategoryName">
            &nbsp;</div>
        <div class="fudong">
            <a href='S_SellGoods_One.aspx?op=add&step=one&cid=<%= Request.QueryString["cid"] %>&pid=<%= Request.QueryString["pid"] %>'
                class="selpic"><span>编辑</span></a>
        </div>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>商品类别：</dt>
    <dd>
        <input name="pType" type="checkbox" id="isnew" value="0" />新品
        <input name="pType" type="checkbox" id="ishot" value="1" />热卖
        <input name="pType" type="checkbox" id="ispromotion" value="2" />促销
        <input name="pType" type="checkbox" id="Isrecommend" value="3" />推荐</dd>
</dl>
<dl class="tibxxbg">
    <dt>商品名称：</dt>
    <dd>
        <input name="input" type="text" id="txtGoodsName" class="textwb" style="width: 300px;"
            maxlength="50" /><span check="errorMsg" style="color: Red; display: none">商品标题名称长度至少3个字符，最长50个汉字！</span><span
                style="color: Red;">*</span>
        <br />
        <span class="gray1">商品标题名称长度至少3个字符，最长50个汉字</span>
    </dd>
</dl>

<dl class="tibxxbg">
    <dt>商品库存：</dt>
    <dd>
        <input name="input" id="txtStock" type="text" class="textwb" onkeyup=" NumTxt_Int(this) "
            maxlength="5" value="1" /><span check="errorMsg" style="color: Red; display: none">商铺库存数量必须为1~1000000000之间的整数！</span><span
                style="color: Red;">*</span><br />
        <span class="gray1">商铺库存数量必须为0~100000之间的整数</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>库存警告数量：</dt>
    <dd>
        <input name="input" id="txtRepertoryAlertCount" type="text" class="textwb" onkeyup=" NumTxt_Int(this) "
            maxlength="5" value="1" /><span check="errorMsg" style="color: Red; display: none">商铺库存警告数量必须为1~1000000000之间的整数！</span><span
                style="color: Red;">*</span><br />
        <span class="gray1">商铺库存警告数量必须为1~100000之间的整数</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>设置颜色信息: &nbsp;</dt>
    <input id="txtColor" type="text"  class="textwb" name="Color_My"/><br />
    <span style="color:Red;"> 多种颜色请用“，”隔开</span><br />
    </dl>
    <dl class="tibxxbg">
    <dt>设置尺寸信息: &nbsp;</dt>
    <input id="txtSize" type="text"   class="textwb" name="Color_My"/><br />
    <span style="color:Red;"> 多种尺寸请用“，”隔开</span><br />
    </dl>
 &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 
<input type="checkbox" id="one" onClick="checkBox(this);" <% if(S_OpGoods2.cbChecks[0]) { %> checked="checked"  <% } %> /><label for="">矿机专区</label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
 <input type="checkbox" id="two" onClick="checkBox(this);" <% if(S_OpGoods2.cbChecks[1]) { %> checked="checked"  <% } %>/><label for="">兑换专区</label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
 <input type="checkbox" id="free" onClick="checkBox(this);" <% if(S_OpGoods2.cbChecks[2]) { %> checked="checked"  <% } %>/><label for="">汽车天地</label><%--&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
 <input type="checkbox" id="five" onClick="checkBox(this);" <% if(S_OpGoods2.cbChecks[3]) { %> checked="checked"  <% } %>/><label for="">区代首购专区</label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
 <input type="checkbox" id="six" onClick="checkBox(this);" <% if(S_OpGoods2.cbChecks[4]) { %> checked="checked"  <% } %>/><label for="">区代二次购物专区</label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
 <input type="checkbox" id="seven" onClick="checkBox(this);" <% if(S_OpGoods2.cbChecks[5]) { %> checked="checked"  <% } %>/><label for="">社区店首购专区</label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
 <input type="checkbox" id="eight" onClick="checkBox(this);" <% if(S_OpGoods2.cbChecks[6]) { %> checked="checked"  <% } %>/><label for="">社区店二次购物专区</label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp--%>

 <div id="div000" style="color:Red;"  >
    发布商品价格的规则是：价格必须比积分和红包高
   </div>


    <div id="div1" <% if(!S_OpGoods2.cbChecks[0]) { %>  style="display:none;"  <% } %>  >
           <dl class="tibxxbg" > 
    <dt >矿机专区可得新能源链：</dt >
    <dd>
        <input name="input" id="txtScore_Pv_a" type="text" onblur=" checkpriceTxt(this) "
            maxlength="9" class="textwb" value="0.00"/><span check="errorMsg" style="color: Red;
                display: none">新能源链必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_Score_Pv_a_sum" value="" type="hidden" />
        <span class="gray1">新能源链必须是0.00~1000000之间的数字</span>
    </dd>
</dl>
<dl class="tibxxbg" style="display:none;">
    <dt>矿机专区扣红包：</dt>
    <dd>
        <input name="input" id="txtScore_hv" type="text" onblur=" checkpriceTxt(this) "
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_Score_hv_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.00~1000000之间的数字</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>矿机专区商品价格：</dt>
    <dd>
        <input name="input" id="txtShopPrice_one" onblur=" checkpriceTxt(this) " type="text"
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">商品价格必须是0.01~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_price_sum" value="" type="hidden" />
        <span class="gray1">商品价格必须是0.01~1000000之间的数字</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>矿机专区市场价格：</dt>
    <dd>
        <input name="input" id="txtMarketPrice_one" type="text" onblur=" checkpriceTxt(this) "
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.01~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_mprice_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.01~1000000之间的数字</span>
    </dd>
</dl>
  </div>
   
    <div id="div2" <% if(!S_OpGoods2.cbChecks[1]) { %>  style="display:none;"  <% } %>>
              <dl class="tibxxbg" style=" display:none">
    <dt>兑换专区可得积分：</dt>
    <dd>
        <input name="input" id="txtScore_Pv_a_two" type="text" onblur=" checkpriceTxt(this) "
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;display: none">市场价格必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_Score_Pv_a_two_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.00~1000000之间的数字</span>
    </dd>
</dl>
<!--这个方法我还没做-->
  <dl class="tibxxbg" style="display:none;">
    <dt>兑换专区可用重销积分：</dt>
    <dd>
        <input name="input" id="txtScore_max_hv" type="text" onblur=" checkpriceTxt(this) "
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_Score_max_hv_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.00~1000000之间的数字</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>兑换专区商品价格：</dt>
    <dd>
        <input name="input" id="txtShopPrice_two" onblur=" checkpriceTxt(this) " type="text"
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">商品价格必须是0.01~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_price_two_sum" value="" type="hidden" />
        <span class="gray1">商品价格必须是0.01~1000000之间的数字</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>兑换专区市场价格：</dt>
    <dd>
        <input name="input" id="txtMarketPrice_two" type="text" onblur=" checkpriceTxt(this) "
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.01~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_mprice_two_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.01~1000000之间的数字</span>
    </dd>
</dl>
</div>
<div id="div3" <% if(!S_OpGoods2.cbChecks[2]) { %>  style="display:none;"  <% } %>>
<dl class="tibxxbg" style="display:none;">
    <dt>积分专区可用积分：</dt>
    <dd>
        <input name="input" id="txtScore_cv" type="text" onblur=" checkpriceTxt(this) "
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_Score_cv_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.00~1000000之间的数字</span>
    </dd>
</dl>


<dl class="tibxxbg" >
    <dt>汽车天地商品价格：</dt>
    <dd>
        <input name="input" id="txtShopPrice_free" onblur=" checkpriceTxt(this) " type="text"
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">商品价格必须是0.01~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_price_free_sum" value="" type="hidden" />
        <span class="gray1">商品价格必须是0.01~1000000之间的数字</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>汽车天地市场价格：</dt>
    <dd>
        <input name="input" id="txtMarketPrice_free" type="text" onblur=" checkpriceTxt(this) "
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.01~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_mprice_free_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.01~1000000之间的数字</span>
    </dd>
</dl>
    </div>


<div id="div4" <% if(!S_OpGoods2.cbChecks[3]) { %>  style="display:none;"  <% } %>>


<dl class="tibxxbg">
    <dt>区代专区首次购物价格商品价格：</dt>
    <dd>
        <input name="input" id="txtShopPrice_five" onblur=" checkpriceTxt(this) " type="text"
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">商品价格必须是0.01~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_price_five_sum" value="" type="hidden" />
        <span class="gray1">商品价格必须是0.01~1000000之间的数字</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>区代专区首次购物市场价格：</dt>
    <dd>
        <input name="input" id="txtMarketPrice_five" type="text" onblur=" checkpriceTxt(this) "
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.01~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_mprice_five_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.01~1000000之间的数字</span>
    </dd>
</dl>

    </div>


<div id="div5" <% if(!S_OpGoods2.cbChecks[4]) { %>  style="display:none;"  <% } %>>


<dl class="tibxxbg">
    <dt>区代专区二次购物价格商品价格：</dt>
    <dd>
        <input name="input" id="txtShopPrice_six" onblur=" checkpriceTxt(this) " type="text"
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">商品价格必须是0.01~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_price_five_sum" value="" type="hidden" />
        <span class="gray1">商品价格必须是0.01~1000000之间的数字</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>区代专区二次购物市场价格：</dt>
    <dd>
        <input name="input" id="txtMarketPrice_six" type="text" onblur=" checkpriceTxt(this) "
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.01~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_mprice_five_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.01~1000000之间的数字</span>
    </dd>
</dl>
    </div>


    <div id="div6" <% if(!S_OpGoods2.cbChecks[5]) { %>  style="display:none;"  <% } %>>


<dl class="tibxxbg">
    <dt>社区店专首次购物价格商品价格：</dt>
    <dd>
        <input name="input" id="txtShopPrice_seven" onblur=" checkpriceTxt(this) " type="text"
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">商品价格必须是0.01~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_price_five_sum" value="" type="hidden" />
        <span class="gray1">商品价格必须是0.01~1000000之间的数字</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>社区店专首次购物市场价格：</dt>
    <dd>
        <input name="input" id="txtMarketPrice_seven" type="text" onblur=" checkpriceTxt(this) "
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.01~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_mprice_five_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.01~1000000之间的数字</span>
    </dd>
</dl>

    </div>


     <div id="div7" <% if(!S_OpGoods2.cbChecks[6]) { %>  style="display:none;"  <% } %>>


<dl class="tibxxbg">
    <dt>社区店专二次购物价格商品价格：</dt>
    <dd>
        <input name="input" id="txtShopPrice_eight" onblur=" checkpriceTxt(this) " type="text"
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">商品价格必须是0.01~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_price_five_sum" value="" type="hidden" />
        <span class="gray1">商品价格必须是0.01~1000000之间的数字</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>社区店专二次购物市场价格：</dt>
    <dd>
        <input name="input" id="txtMarketPrice_eight" type="text" onblur=" checkpriceTxt(this) "
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.01~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_mprice_five_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.01~1000000之间的数字</span>
    </dd>
</dl>
    </div>
    <div id="div11" style="display:none;">
           <dl class="tibxxbg">
    <dt>可得积分：</dt>
    <dd>
        <input name="input" id="txtScore_Pv_a_CTC" type="text" onblur=" checkpriceTxt(this) "
            maxlength="9" class="textwb" value="0.00"/><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_Score_Pv_a_CTC_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.00~1000000之间的数字</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>可用红包：</dt>
    <dd>
        <input name="input" id="txtScore_hv_CTC" type="text" onblur=" checkpriceTxt(this) "
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_Score_hv_CTC_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.00~1000000之间的数字</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>商品价格：</dt>
    <dd>
        <input name="input" id="txtShopPrice_one_CTC" onblur=" checkpriceTxt(this) " type="text"
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">商品价格必须是0.01~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_price_CTC_sum" value="" type="hidden" />
        <span class="gray1">商品价格必须是0.01~1000000之间的数字</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>市场价格：</dt>
    <dd>
        <input name="input" id="txtMarketPrice_one_CTC" type="text" onblur=" checkpriceTxt(this) "
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.01~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_mprice_CTC_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.01~1000000之间的数字</span>
    </dd>
</dl>
  </div>

<dl class="tibxxbg"  style="display:none;">
    <dt>可得积分：</dt>
    <dd>
        <input name="input" id="txtScore_Pv_b" type="text" onblur=" checkpriceTxt(this) "
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_Score_Pv_b_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.00~1000000之间的数字</span>
    </dd>
</dl>

<dl class="tibxxbg"  style="display:none;">
    <dt>可得赠送币：</dt>
    <dd>
        <input name="input" id="txtScore_dv" type="text" onblur=" checkpriceTxt(this) "
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_Score_dv_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.00~1000000之间的数字</span>
    </dd>
</dl>

<dl class="tibxxbg" style="display:none;">
    <dt>区代社区首次购买限制：</dt>
    <dd>
        <input name="input" id="txtMaxNumber_one"  type="text"
            maxlength="6" class="textwb" value="1000000" /><span  style="color: Red;
                display: none">商品价格必须是1~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_MaxNumber_one_sum" value="" type="hidden" />
        <span class="gray1">商品价格必须是1~1000000之间的数字</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>发货数量：</dt>
    <dd>
        <input name="input" id="txtUnitNumber"  type="text"
            maxlength="6" class="textwb" value="1" /><span  style="color: Red;
                display: none">商品价格必须是1~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_txtUnitNumber_sum" value="" type="hidden" />
        <span class="gray1">商品价格必须是1~1000000之间的数字</span>
    </dd>
</dl>
<dl class="tibxxbg" style="display:none;">
    <dt>慈善金额：</dt>
    <dd>
        <input name="input" id="txtScore_sv" type="text" onblur=" checkpriceTxt(this) "
            maxlength="6" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_Score_sv_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.00~1000000之间的数字</span>
    </dd>
</dl>

<dl class="tibxxbg"  style="display:none;">
    <dt>零售价：</dt>
    <dd>
        <input name="input" id="txtMyPrice" type="text" onblur=" checkpriceTxt(this) "
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_MyPrice" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.00~1000000之间的数字</span>
    </dd>
</dl>

<dl class="tibxxbg">
    <dt>商品货号：</dt>
    <dd>
        <input name="input" id="txtNumber" type="text" class="textwb" maxlength="20" />
        <span class="gray1">最多可输入20个字符，支持输入中文、字母、数字、_、/、-和小数点</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>商品单位：</dt>
    <dd>
        <input name="input" id="txtUnitname" type="text" class="textwb" />
        <span class="gray1">&nbsp;</span>
    </dd>
</dl>
<dl class="tibxxbg" id="Prop_show" runat="server">
    <dt>商品属性：</dt>
    <dd>
        <div class="yanskuang">
            <table width="100%" cellspacing="0" cellpadding="0" border="0" class="yanstab">
                <tbody>
                    <% DataTable dt_Prop = S_OpGoods1.dt_Provalue;
                       if (dt_Prop != null)
                       {
                           for (int i = 0; i < dt_Prop.Rows.Count; i++)
                           { %>
                    <tr>
                        <td width="100%" align="left">
                            <strong style="color: #666;">
                                <%= dt_Prop.Rows[i]["PropName"] %>：</strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ul class="clearfix">
                                <% DataTable dt_SubProp = S_OpGoods1.dt_SubPropv(dt_Prop.Rows[i]["id"].ToString());
                                   for (int j = 0; j < dt_SubProp.Rows.Count; j++)
                                   { %>
                                <% if (dt_Prop.Rows[i]["showtype"].ToString() == "0")
                                   { %>
                                <!--文字输入-->
                            <!--    <li><span>
                                    <%= dt_SubProp.Rows[j]["name"] %>:</span><input type="text" prop_type='0,<%= dt_Prop.Rows[i]["id"] %>,<%= dt_SubProp.Rows[j]["id"] %>'
                                        class="prop_txtinput_text" name='prop_check_0' lang='<%= dt_Prop.Rows[i]["id"] %>'
                                        value="<%= dt_SubProp.Rows[j]["iv"] %>"></li>
                                <!--文字输入-->
                                 <% }
                                    else if (dt_Prop.Rows[i]["showtype"].ToString() == "1")
                                   { %>
                                <!--列表单选-->
                                <li>
                                    <input type="radio" <%= dt_SubProp.Rows[j]["vcheck"].ToString() == "" ? "" : "checked='checked'" %>
                                        class="prop_radio_text" prop_type='1,<%= dt_Prop.Rows[i]["id"] %>,<%= dt_SubProp.Rows[j]["id"] %>,'
                                        value="<%= dt_SubProp.Rows[j]["id"] %>" name='prop_check_<%= dt_Prop.Rows[i]["id"] %>'
                                        lang='<%= dt_Prop.Rows[i]["id"] %>'>
                                    <span style="vertical-align: 2px;">
                                        <%= dt_SubProp.Rows[j]["name"] %></span> </li>
                                <!--列表单选-->
                                <% }
                                   else if (dt_Prop.Rows[i]["showtype"].ToString() == "2")
                                   { %>
                                <% if (j == 0)
                                   { %>
                                <!--下拉框选择-->
                                <li>
                                    <select name='prop_check_2' prop_type='2,<%= dt_Prop.Rows[i]["id"] %>' class="prop_select_text"
                                        lang='<%= dt_Prop.Rows[i]["id"] %>'>
                                        <option value="000">-请选择-</option>
                                        <% } %>
                                        <option <%= dt_SubProp.Rows[j]["vcheck"].ToString() == "" ? "" : "selected='selected'" %>
                                            value='<%= dt_SubProp.Rows[j]["id"] %>'>
                                            <%= dt_SubProp.Rows[j]["Name"] %></option>
                                        <% if (j == dt_SubProp.Rows.Count)
                                           { %>
                                    </select>
                                </li>
                                <!--下拉框选择-->
                                <% } %>
                                <% }
                                   else if (dt_Prop.Rows[i]["showtype"].ToString() == "3")
                                   { %>
                                <!--列表多选-->
                                <li>
                                    <input type="checkbox" <%= dt_SubProp.Rows[j]["vcheck"].ToString() == "" ? "" : "checked='checked'" %>
                                        class="prop_list_check" value="3,<%= dt_SubProp.Rows[j]["id"] %>" prop_type='3,<%= dt_Prop.Rows[i]["id"] %>,<%= dt_SubProp.Rows[j]["id"] %>'
                                        lang='<%= dt_Prop.Rows[i]["id"] %>'>
                                    <span style="vertical-align: 2px;">
                                        <%= dt_SubProp.Rows[j]["name"] %></span> </li>
                                <!--列表多选-->
                                <% }
                                   else if (dt_Prop.Rows[i]["showtype"].ToString() == "4")
                                   { %>
                                <li>
                                    <div class="sxtitle">
                                        <p style="border: none;">
                                            自定义属性</p>
                                        <div class="sxtitle_nr">
                                            <table width="95%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <th colspan="2" scope="col">
                                                        <input type="button" id="addProp" class="btn_add" onclick=" add_Prop(this) " value="新增属性" />
                                                        <span check="errorMsg" style="color: Red; display: none">最多添加30组自定义属性！</span>
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <th colspan="2" scope="col">
                                                        最多可添加30组自定义属性（非必填），如：镜头：15cm
                                                    </th>
                                                </tr>
                                                <tbody class="prop_handinput_text" lang='4,<%= dt_Prop.Rows[i]["id"] %>,<%= dt_SubProp.Rows[j]["id"] %>'>
                                                    <% if (dt_SubProp.Rows[j]["iv"].ToString() != "")
                                                       {
                                                           string strInput = dt_SubProp.Rows[j]["iv"].ToString();
                                                           if (strInput.IndexOf("*") != -1)
                                                           {
                                                               for (int v = 0; v < strInput.Split('*').Length; v++)
                                                               {
                                                                   if (strInput.IndexOf("%") != -1)
                                                                   {
                                                                       string[] TxtArray = strInput.Split('*')[v].Split('%');
                                                                       if (TxtArray[0] != "")
                                                                       {
                                                    %>
                                                    <!--循环自定义数据-->
                                                    <tr>
                                                        <td width="500" class="defined_Prop">
                                                            <input type="text" class="textwb" name="input_defined_1" style="width: 100px;" value="<%= TxtArray[0] %>" />：<input
                                                                type="text" class="textwb " style="width: 200px;" name="input_defined_2" value="<%= TxtArray[1] %>" />
                                                            &nbsp;<span class="gray1 delprop">删除</span>&nbsp;<span class="gray1 clearprop">清空</span>
                                                        </td>
                                                    </tr>
                                                    <!--循环自定义数据-->
                                                    <% }
                                                                   }
                                                               }
                                                           }
                                                           else
                                                           {
                                                               string[] TxtArray = strInput.Split('%');
                                                    %>
                                                    <tr>
                                                        <td width="500" class="defined_Prop">
                                                            <input type="text" class="textwb" name="input_defined_1" style="width: 100px;" value="<%= TxtArray[0] %>" />：<input
                                                                type="text" class="textwb " style="width: 200px;" name="input_defined_2" value="<%= TxtArray[1] %>" />
                                                            &nbsp;<span class="gray1 delprop">删除</span>&nbsp;<span class="gray1 clearprop">清空</span>
                                                        </td>
                                                    </tr>
                                                    <% }
                                                       } %>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </li>
                                <% }
                                   } %>
                            </ul>
                    </tr>
                    <% }
                       } %>
                </tbody>
            </table>
        </div>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>商品品牌：</dt>
    <dd>
        <select name="sel" size="1" class="select_Brand" id="selectbrand">
            <option value="00000000-0000-0000-0000-000000000000">其它</option>
        </select>
        <span style="display: none;" id="OtherBrand">
            <input type="text" id="txtPersonBrand" class="textwb" /></span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>商品图片：</dt>
    <dd>
        <div class="shappic">
            <ul>
                <li class="chali1" id="tabpic1" onclick=" changTabPic('#tabpic2', this) ">商品图片</li>
                <li class="chali2" id="tabpic2" onclick=" changTabPic('#tabpic1', this) ">从用户相册中选择</li>
            </ul>
            <div style="clear: both;">
            </div>
            <div class="shappic_nr">
                <div id="TabAlbum" style="display: none">
                    <table width="100%" border="0" cellspacing="3" cellpadding="0">
                        <tr>
                            <td>
                                &nbsp;用户相册 > 全部图片
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                <input type="hidden" id="albumtype" value="0" />
                                <select name="select_album" class="tselect">
                                    <option value="0">-请选择-</option>
                                    <option value="1">默认相册</option>
                                </select>
                            </td>
                        </tr>
                    </table>
                    <div id="albumlist">
                        <ul style="width: 100%">
                        </ul>
                    </div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td width="465">
                                <div class="fy">
                                    <span id="currentPage" style="width: 150px;">当前页<label id="lblpageIndex" style="width: 20px;">1</label>/<label
                                        id="lblpageCount"></label>页</span> <span id="OtherPageNum" class="num"></span>
                                    <span id="droplist"></span>一共<span class="lblNumCount"></span>条记录
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <ul>
                    <li style="padding-top: 10px;">
                        <img src="/ImgUpload/noimg.jpg_100x100.jpg" name="pro_img" width="114" height="114"
                            id="imgvj_1" onerror=" javascript:this.src = '/ImgUpload/noimg.jpg_100x100.jpg'; " />
                    </li>
                    <li style="display: none; padding-left: 20px; padding-top: 5px;" id="file_0_del">
                        <input type="button" value="删除图片" name="file_btn" class="selpic" /></li>
                    <li style="padding-top: 40px; position: relative;" id="file_0_upload">
                        <div class="upload-btn">
                            <span>
                                <input type="file" onchange=" changfile(this, '#imgvj_1') " id="file_0" name="file_0" />
                            </span>
                            <div class="selpic">
                                图片上传</div>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li style="padding-top: 10px;">
                        <img src="/ImgUpload/noimg.jpg_100x100.jpg" name="pro_img" width="114" height="114"
                            name="pro_img" id="imgvj_2" onerror=" javascript:this.src = '/ImgUpload/noimg.jpg_100x100.jpg'; " /></li>
                    <li style="display: none; padding-left: 20px; padding-top: 5px;" id="file_1_del">
                        <input type="button" value="删除图片" name="file_btn" class="selpic" /></li>
                    <li style="padding-top: 40px; position: relative;" id="file_1_upload">
                        <div class="upload-btn">
                            <span>
                                <input type="file" onchange=" changfile(this, '#imgvj_2') " id="file_1" name="file_1" />
                            </span>
                            <div class="selpic">
                                图片上传</div>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li style="padding-top: 10px;">
                        <img src="/ImgUpload/noimg.jpg_100x100.jpg" name="pro_img" width="114" height="114"
                            id="imgvj_3" onerror=" javascript:this.src = '/ImgUpload/noimg.jpg_100x100.jpg'; " /></li>
                    <li style="display: none; padding-left: 20px; padding-top: 5px;" id="file_2_del">
                        <input type="button" value="删除图片" name="file_btn" class="selpic" /></li>
                    <li style="padding-top: 40px; position: relative;" id="file_2_upload">
                        <div class="upload-btn">
                            <span>
                                <input type="file" onchange=" changfile(this, '#imgvj_3') " id="file_2" name="file_2" />
                            </span>
                            <div class="selpic">
                                图片上传</div>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li style="padding-top: 10px;">
                        <img src="/ImgUpload/noimg.jpg_100x100.jpg" name="pro_img" width="114" height="114"
                            id="imgvj_4" onerror=" javascript:this.src = '/ImgUpload/noimg.jpg_100x100.jpg'; " /></li>
                    <li style="display: none; padding-left: 20px; padding-top: 5px;" id="file_3_del">
                        <input type="button" value="删除图片" name="file_btn" class="selpic" /></li>
                    <li style="padding-top: 40px; position: relative;" id="file_3_upload">
                        <div class="upload-btn">
                            <span>
                                <input type="file" onchange=" changfile(this, '#imgvj_4') " id="file_3" name="file_3" />
                            </span>
                            <div class="selpic">
                                图片上传</div>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li style="padding-top: 10px;">
                        <img src="/ImgUpload/noimg.jpg_100x100.jpg" name="pro_img" width="114" height="114"
                            id="imgvj_5" onerror=" javascript:this.src = '/ImgUpload/noimg.jpg_100x100.jpg'; " /></li>
                    <li style="display: none; padding-left: 20px; padding-top: 5px;" id="file_4_del">
                        <input type="button" value="删除图片" name="file_btn" class="selpic" /></li>
                    <li style="padding-top: 40px; position: relative;" id="file_4_upload">
                        <div class="upload-btn">
                            <span>
                                <input type="file" onchange=" changfile(this, '#imgvj_5') " id="file_4" name="file_4">
                            </span>
                            <div class="selpic">
                                图片上传</div>
                        </div>
                    </li>
                </ul>
                <div style="clear: both;">
                </div>
                <h2 class="spth2">
                    此处为您的商品图片，将显示在店铺图库里，图片大小不能超过1M。<span id="errpicmsg" style="color: Red; display: none"></span></h2>
                <h3 class="spth3">
                    建议使用宽300像素-高300像素内的Jpg图片</h3>
                <h3 class="spth3">
                    <span class="red" style="display: none;" id="showpic">至少上传一张图片！</span></h3>
            </div>
        </div>
    </dd>
</dl>
