<%@ Control Language="C#" EnableViewState="false" %>
<div>
    <div class="Combination_title">
        <h3><asp:Label ID="lblPackName" runat="server"></asp:Label></h3>
    </div>
    <div class="Combination_con">
        <!--图片+属性--> 
        <div class="meta-combo">
            <div class="gallery fl">
                <div class="booth jqzoom" id="boothPic"><asp:Literal ID="literalImg" runat="server"></asp:Literal></div>
                <ul class="thumb clearfix">
                    <asp:Repeater ID="repImg" runat="server">
                    <ItemTemplate>
                         <li class='<%#Container.ItemIndex==0?"selected":""%>' lang='<%#Eval("originalimage") %>'>
                            <div class="pic">
                                <img src='<%#Eval("originalimage")+"_60x60.jpg" %>' onerror="javascript:this.src='/ImgUpload/noimg.jpg_60x60.jpg'" />
                            </div>
                        </li>
                     </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="clear"></div>
            </div>
            <div class="property fl">
                <div class="TipBlock" style="display:none;">
                    <div>
                        <img src="Themes/Skin_Default/images/xiaobao.png" />
                        <p>该套餐已加入<a href="#">消保</a>，将保障您的购物资金与运费安全。</p>
                    </div>
                </div>
                <div class="price-combo">
                    <div class="flag">
                        <p>立省</p>
                        <p><span><asp:Label ID="lblSaveMoney" runat="server"></asp:Label></span>元</p>
                    </div>
                    <ul class="meta">
                        <li class="market-price clearfix">
                            <span>原&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;价：</span>
                            <del><asp:Label ID="lblOldPrice" runat="server"></asp:Label></del>元
                        </li>
                        <li class="detail-price clearfix">
                            <span>促 销 价：</span>
                            <i></i>
                            <strong><asp:Label ID="lblSalePrice" runat="server"></asp:Label></strong>元
                        </li>
                    </ul>
                </div>
                <div style="display:none;">
                    <ul>
                        <li class="featureSer">
                            <span>特色服务：</span>
                            <a href="#"><i></i>七天退换</a>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="clear"></div>
        </div>
        <!--套餐商品-->
        <div class="property-combo">
            <h4>本优惠套餐包含以下宝贝:</h4>
            <div id="myPackAge">
               <asp:Repeater ID="repPackProduct" runat="server">
                   <ItemTemplate>
                       <div class="key">
                        <div class="skin clearfix">
                            <div class="thumb-single fl">
                                <a href='<%#ShopUrlOperate.shopDetailHref(Eval("guid").ToString(),Eval("memloginid").ToString(),"ProductDetail") %>' target="_blank">
                                    <img src='<%#Eval("originalimage")+"_100x100.jpg" %>' onerror="javascript:this.src='/ImgUpload/noimg.jpg_100x100.jpg'" /></a>
                            </div>
                            <div class="prop-summary fl">
                                <p class="jiequs"><a href='<%#ShopUrlOperate.shopDetailHref(Eval("guid").ToString(),Eval("memloginid").ToString(),"ProductDetail") %>' target="_blank"><%# ShopNum1.Common.Utils.GetUnicodeSubString(Eval("Name").ToString(), 25, "")%> </a></p>
                                <p>
                                    <em><%#Eval("shopprice") %></em>(库存<span class="pstock"><%#Eval("repertorycount") %></span>件)
                                </p>
                            </div>
                        </div>
                          <div class="spec-summary">
                               <div class="restrict errorselect" id="hideSpecDiv" runat="server">
                               <input type="hidden" name="hidGuId" class="hidGuId" runat="server" id="hidGuId" value='<%#Eval("guid")%>' />
                                <asp:Repeater ID="RepeaterProductSepc" runat="server" EnableViewState="false">
                                    <ItemTemplate>
                                        <dl class="tb_prop clearfix">
                                            <dt><%#Eval("specname")%>：</dt>
                                            <dd><ul>
                                                    <asp:Repeater ID="RepeaterProductSepcDetail" runat="server" EnableViewState="false">
                                                        <ItemTemplate>
                                                            <li specvalue='<%#Eval("SpecDetailName")%>' spc='<%#Eval("SpecDetail")%>' spcv='<%#Eval("SpecDetailv")%>'>
                                                            <a href="javascript:void(0)">
                                                                <input type="hidden" name="hidImgPath" value='<%#Eval("ImagePath")%>' />
                                                                <input type="hidden" name="hidProductImg" value='<%#Eval("productimage")%>' />
                                                                <input type="hidden" name="hidSpecValueName" value='<%#Eval("SpecValueName") %>' />
                                                                <span>
                                                                  <%--  <%#((DataRowView)Container.DataItem).Row["productimage"].ToString() != "" ? "<img src='" + ((DataRowView)Container.DataItem).Row["productimage"] + "_25x25.jpg' lang='" + ((DataRowView)Container.DataItem).Row["productimage"] + "' width=\"25\" height=\"25\" title='" + ((DataRowView)Container.DataItem).Row["SpecValueName"] + "'/>" : ((DataRowView)Container.DataItem).Row["SpecValueName"]%>--%>
                                                                </span></a></li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul></dd>
                                        </dl>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div class="divnoSelect" style="clear: both; padding-top: 6px; padding-top: 0px\9;">
                                            <span style="font-weight: bold; clear: both;">请选择</span>：<span id="spanNoSelect"
                                                style="font-weight: bold; clear: both;" runat="server">"颜色" </span>
                                        </div>
                                        <div class="divSelect" style="clear: both; display: none;">
                                            <span style="font-weight: bold; clear: both;">已选择</span>：<span class="selected"></span></div>
                                     
                                    </FooterTemplate>
                                </asp:Repeater>
                                </div>
                          </div>
                      </div>
                   </ItemTemplate>
               </asp:Repeater>
                <div class="clear"></div>
                </div>
                </div>
                <div class="combo-buy">
                    <p>我 要 买：<input type="text" id="txtBuyNum" runat="server" value="1" onkeyup="NumTxt_Int(this)"/> 套</p>
                    <input type="hidden" id="hidProductGuID" runat="server" />
                     <input type="hidden" id="hidShopName" runat="server" />
                    <input type="hidden" id="hidMemloginId" runat="server" />
                    <input type="hidden" id="hidSpecId" runat="server" />
                    <input type="hidden" id="hidSpecName" runat="server" />
                    <input type="hidden" id="hidPack_Price" runat="server" />
                    <p><asp:Label ID="lblMsg" runat="server" Text="用户未登陆" ForeColor="Red" Visible="false"></asp:Label><asp:Button ID="btnBuyPack" runat="server" Text="立即购买" CssClass="ZuHeBtn" OnClientClick="return CheckBuy()" /></p>
                </div>
                <script type="text/javascript" language="javascript">
   var imgmultbf="";//多图备份
$(function(){
    $("#myPackAge .spec-summary").each(function(){
        $(this).find(".restrict ul li").not(".litit").each(function(i){
            $(this).click(function(){
               $(this).siblings().not(".litit").children("img").remove();$(this).siblings().not(".litit").removeAttr("class");$(this).attr("class","liselect");
               $(this).append($("<img class=\"sico\" src=\"Themes/Skin_Default/Images/ii1.gif\" />"));
               var t_this=$(this).parent().parent().parent().parent();
               t_this.find(".divnoSelect").hide();t_this.find(".divSelect").show();
               var spenames="";
               var isselect=0; //规格选择的个数
               var prodspec="";//选择的规格值（所有已勾选的规格值）
               var nowprodspec="";//当前选择的规格值
             
                var prodguid=t_this.find(".hidGuId").val();  //商品guid
                var memloginid=$("#CombinationDetail_ctl00_hidMemloginId").val();//会员loginid
                if(imgmultbf==""){imgmultbf=$("#tb_gallery").html();}
                    //开始处理多图
                    nowprodspec=$(this).attr("spc");
                    var specvx=$(this).attr("spcv");
                    params = {"prodguid":prodguid,"yz":"shopnum1ntbl","loginid":memloginid,"spec":specvx,"type":"img"}; 
                    $.getJSON("/Main/Api/shopproductspec.ashx",params,function(json){
                     if(json[0].imgsrc!=null)
                     {
                           //绑定选择规格后的大图
                            $("#ProductImgurl").attr("src",""+json[0].imgsrc+"");
                            $("#ProductImgurl").attr("jqimg",""+json[0].imgsrc.replace("s_","")+"");
                            //绑定属性的缩略图
                            t_this.find(".list-h li").remove();
                            $.each(json,function(i) {
                                    if(json[i].imgsrc!="")
                                    {
                                       t_this.find(".list-h").append($("<li class=\"tb_diply\"></li>").append($("<div class=\"tb-pic tb-stn\"></div>").append($("<a></a>").append($("<img />").attr("src", json[i].imgsrc)))))
                                    }
                            });
                            //给缩略图加宽度
                            var width_l=parseInt(json.length)*60;
                    }
                    else{$("#tb_gallery").html(imgmultbf);}
			            $("#tb_gallery img").bind("mouseover",function(){
				            var src=$(this).attr("lang");
				            $("#spec-n1 img").eq(0).attr({
					            src:src.replace("\/n5\/","\/n1\/"),
					            jqimg:src.replace("\/n5\/","\/n0\/")
				            });
				            $(this).parent().parent().parent().addClass("tb_selected");
			            }).bind("mouseout",function(){
	                        $(this).parent().parent().parent().removeClass("tb_selected");
			            });	
                  });
                       //处理多图结束
                       //开始处理其它效果
                       var prodspecv="",prodspecvalue="";
                        var juls=t_this.parent().find(".restrict ul");
                        juls.each(function(i){
                                    if($(this).children("li").hasClass("liselect"))
                                    {
                                           isselect++;
                                           spenames+="\""+$(this).children(".liselect").find("span").html()+"\""+"  ";
                                           prodspecv=prodspecv+$(this).children(".liselect").attr("spcv")+";";
                                           prodspecvalue=prodspecvalue+$(this).children(".liselect").attr("specvalue")+";";
                                           prodspec=prodspec+$(this).children(".liselect").attr("spc")+";";
                                     }
                      
                         });
                        t_this.find(".divSelect .selected").html(spenames);  //选择了
                        //开始处理商品库存
                        if(juls.length==isselect)
                        {
                           prodspecv=prodspecv.substring(0,prodspecv.length-1);
                           prodspecvalue=prodspecvalue.substring(0,prodspecvalue.length-1);
                           $("#CombinationDetail_ctl00_hidSpecId").val(prodspecv+"|"+$("#CombinationDetail_ctl00_hidSpecId").val());
                           $("#CombinationDetail_ctl00_hidSpecName").val(prodspecvalue+"|"+$("#CombinationDetail_ctl00_hidSpecName").val());
                           
                           params = {"prodguid":prodguid,"yz":"shopnum1ntbl","loginid":memloginid,"spec":prodspecv,"type":"prodspec"}; 
                           $.getJSON("/Main/Api/shopproductspec.ashx",params,function(json){
                                 if(json!=null)
                                 {
                                       t_this.parent().parent().find(".prop-summary em").text(price_format(json[0].price,2));//商品价格
                                       t_this.parent().parent().find(".prop-summary .pstock").text(json[0].RepertoryCount);//库存
                                 } 
                            });
                         }
         });
                     });
            });
    });



                       $(function(){
                                   $("input[name='hidProductImg']").each(function(){
                                    if($(this).val()!="")
                                    {
                                       $(this).parent().find("span").html("<img src=\""+$(this).val()+"_25x25.jpg\" lang=\""+$(this).val()+"\" alt=\""+$(this).parent().find("input[name='hidSpecValueName']").val()+"\" width=\"25px;\" height=\"25px\"/>");
                                    }else{
                                       if($(this).parent().find("input[name='hidImgPath']").val()!=""){
                                         $(this).parent().find("span").html("<img src=\""+$(this).parent().find("input[name='hidImgPath']").val()+"\" alt=\""+$(this).parent().find("input[name='hidSpecValueName']").val()+"\" width=\"25px;\" height=\"25px\"/>"); 
                                       }
                                       else{
                                            $(this).parent().find("span").html($(this).parent().find("input[name='hidSpecValueName']").val());
                                       }  
                                     }
                                 });
                       });
                        function CheckBuy()
                        {
                            var spenames="";
                            var bflag=true;
                            $("#myPackAge .spec-summary").each(function(){
                                    
                                     $(this).find(".restrict .tb_prop dt").each(function(i){
                                             if($(this).next().find(".liselect").length==0){spenames+="\""+$.trim($(this).text())+"\""+" ";}
                                     });
                                     if(spenames!="")
                                     {
                                        alert("请选择["+$(this).prev().find(".prop-summary a").text()+"]的"+spenames);
                                        bflag=false;return false;
                                     }
                            });
                            
                            if(bflag){
                                     var pidArry=new Array();var priceArry=new Array();
                                     $("input[class='hidGuId']").each(function(){
                                            pidArry.push("'"+$(this).val()+"'");
                                     });
                                     $("#myPackAge .key .prop-summary p em").each(function(){
                                            priceArry.push($(this).text());
                                     });
                                     $("#CombinationDetail_ctl00_hidPack_Price").val(priceArry.join(","));
                                     
                                    var prodspecv="",prodspecvalue="";var SpecIdArry=new Array();var SpecNameArry=new Array();
                                    $("#myPackAge .spec-summary").each(function(){
                                            var prodspecv="",prodspecvalue="";
                                            $(this).find(".restrict ul").each(function(i){
                                                    if($(this).children("li").hasClass("liselect"))
                                                    {
                                                         prodspecv=prodspecv+$(this).children(".liselect").attr("spcv")+";";
                                                         prodspecvalue=prodspecvalue+$(this).children(".liselect").attr("specvalue")+";";
                                                     }
                                            });
                                             SpecIdArry.push(prodspecv);
                                             SpecNameArry.push(prodspecvalue);
                                    });
                                    $("#CombinationDetail_ctl00_hidSpecId").val(SpecIdArry.join("|"));
                                    $("#CombinationDetail_ctl00_hidSpecName").val(SpecNameArry.join("|"));
                                     if(parseInt($("#CombinationDetail_ctl00_txtBuyNum").val())<1)
                                     {
                                        alert("购买数量不能为空！");return false;
                                     }
                                     
                                     if(parseInt($("#CombinationDetail .pstock:eq(0)").text())<parseInt($("#CombinationDetail_ctl00_txtBuyNum").val()))
                                     {
                                         alert("购买数量必须小于组合套餐商品最小库存！");return false;
                                     }
                                     $("#CombinationDetail_ctl00_hidProductGuID").val(pidArry.join(","));
                                     return true;
                             
                             }else{return false;}
                        }
                        function sortMethod(arr) {
                                // 交换两个数组项的位置
                                var swap = function(firstIndex, secondIndex) {
                                var temp = arr[firstIndex];
                                arr[firstIndex] = arr[secondIndex];
                                arr[secondIndex] = temp;
                        };
   
                       // 升序排列
                        var bubbleSort = function() {
                             var i, j, stop, len = arr.length;
                             for (i=0; i<len; i=i+1) {
                                 for (j=0, stop = len - i; j<stop; j=j+1) {
                                    // 将这里的'>'换成'<'即为降序排列
                                      if (arr[j] > arr[j+1]) { swap(j, j+1); }
                                 }
                             }
                         }();
                    }
                </script>
            
        </div>
    </div>
    <!--套餐详情-->
    <div class="info-combo">
        <div class="info-combo-title"><span>套餐详情</span></div>
        <div class="info-combo-con">
                <asp:Literal ID="literalDetail" runat="server"></asp:Literal>
        </div>
    </div>
    <!--其他套餐-->
    <div class="simple">
        <h4>店铺其他搭配套餐</h4>
        <div class="simple-con">
            <ul class="clearfix">
                <asp:Repeater ID="OtherPackList" runat="server">
                    <ItemTemplate>
                         <li>
                            <div class="item">
                                <div class="pic">
                                    <a href='<%#ShopUrlOperate.shopDetailHref(Eval("guid").ToString(),Eval("memloginid").ToString(),"ProductDetail") %>' target="_blank">
                                        <img src='<%#Eval("originalimage")+"_100x100.jpg"%>' onerror="javascript:this.src='/ImgUpload/noimg.jpg_100x100.jpg'" />
                                    </a>
                                </div>
                                <div class="price"><strong><%#Eval("shopprice") %></strong></div>
                                <div class="desc"><a href='<%#ShopUrlOperate.shopDetailHref(Eval("guid").ToString(),Eval("memloginid").ToString(),"ProductDetail") %>'><%# ShopNum1.Common.Utils.GetUnicodeSubString(Eval("Name").ToString(), 25, "")%></a></div>
                            </div>
                         </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <!--免责申明-->
    <div class="box">
        <p>免责声明：本网所展示的宝贝供求信息由买卖双方自行提供，其真实性、准确性和合法性由信息发布人负责。本网不提供任何保证，并不承担任何法律责任。网友情提醒：为保障您的利益，请网上成交，贵重宝贝，请使用<a href="#">支付宝</a>交易</p>
    </div>
</div>