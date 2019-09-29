<%@ Control Language="C#" AutoEventWireup="true" %>

<script type="text/javascript">
    
    function HideWenzi0()
    {
        $("#w0").hide();
        $("#w1").hide();
        $("#w2").hide();
        
        document.getElementById("q0").className = "";
        document.getElementById("q1").className = "";
        document.getElementById("q2").className = "";
        
        document.getElementById("d0").className = "";
        document.getElementById("d1").className = "";
        document.getElementById("d2").className = "";
    }
     function HideWenzi1()
    {
        $("#w1").hide();
        $("#w2").hide();
    }
    function HideWenzi2()
    {      
        $("#w2").hide();
    }
</script>

<script type="text/javascript">
        function changeTab(selfid,targetid,index,count,selfclass,otherclass,BNum,Bclass) {
            for(var i=0;i<count;i++) {
                if(i == index) {
                    document.getElementById(selfid + i).className = selfclass;
                    document.getElementById(targetid + i).style.display = "block";
                }
                else {
                    document.getElementById(selfid + i).className = otherclass;

                    document.getElementById(targetid + i).style.display = "none";
                }
                 document.getElementById("d" + i).className = "";
            }
            document.getElementById("d" + BNum).className =Bclass;
        }   
</script>

<script type="text/javascript">
        function tab(selfid,targetid,index,count,selfclass,otherclass) {
            for(var i=0;i<count;i++) {
                if(i == index) {
                    document.getElementById(selfid + i).className = selfclass;
                    document.getElementById(targetid + i).style.display = "block";
                     
                }
                else {
                    document.getElementById(selfid + i).className = otherclass;
                    document.getElementById(targetid + i).style.display = "none";
                }
                
            }
            
            
        }
</script>

<!--首页广告位-->
<script type="text/javascript">
$(function() {
	var sWidth = $("#focus").width(); //获取焦点图的宽度（显示面积）
	var len = $("#focus ul li").length; //获取焦点图个数
	var index = 0;
	var picTimer;
	
	//以下代码添加数字按钮和按钮后的半透明长条
	var btn = "<div class='btnBg'></div><div class='btn'>";
	for(var i=0; i < len; i++) {
		btn += "<span>" + (i+1) + "</span>";
	}
	btn += "</div>"
	$("#focus").append(btn);
	$("#focus .btnBg").css("opacity",0.2);
	
	//为数字按钮添加鼠标滑入事件，以显示相应的内容
	$("#focus .btn span").mouseenter(function() {
		index = $("#focus .btn span").index(this);
		showPics(index);
	}).eq(0).trigger("mouseenter");
	
	//本例为左右滚动，即所有li元素都是在同一排向左浮动，所以这里需要计算出外围ul元素的宽度
	$("#focus ul").css("width",sWidth * (len + 1));
	
//鼠标滑入某li中的某div里，调整其同辈div元素的透明度，由于li的背景为黑色，所以会有变暗的效果
	$("#focus ul li div").hover(function() {
		$(this).siblings().css("opacity",0.7);
	},function() {
		$("#focus ul li div").css("opacity",1);
	});
	
	//鼠标滑上焦点图时停止自动播放，滑出时开始自动播放
	$("#focus").hover(function() {
		clearInterval(picTimer);
	},function() {
		picTimer = setInterval(function() {
			if(index == len) { //如果索引值等于li元素个数，说明最后一张图播放完毕，接下来要显示第一张图，即调用showFirPic()，然后将索引值清零
				showFirPic();
				index = 0;
			} else { //如果索引值不等于li元素个数，按普通状态切换，调用showPics()
				showPics(index);
			}
			index++;
		},5000); //此3000代表自动播放的间隔，单位：毫秒
	}).trigger("mouseleave");
	
	//显示图片函数，根据接收的index值显示相应的内容
	function showPics(index) { //普通切换
		var nowLeft = -index*sWidth; //根据index值计算ul元素的left值
		$("#focus ul").stop(true,false).animate({"left":nowLeft},500); //通过animate()调整ul元素滚动到计算出的position
		$("#focus .btn span").removeClass("on").eq(index).addClass("on"); //为当前的按钮切换到选中的效果
	}
	
	function showFirPic() { //最后一张图自动切换到第一张图时专用
		$("#focus ul").append($("#focus ul li:first").clone());
		var nowLeft = -len*sWidth; //通过li元素个数计算ul元素的left值，也就是最后一个li元素的右边
		$("#focus ul").stop(true,false).animate({"left":nowLeft},500,function() {
			//通过callback，在动画结束后把ul元素重新定位到起点，然后删除最后一个复制过去的元素
			$("#focus ul").css("left","0");
			$("#focus ul li:last").remove();
		}); 
		$("#focus .btn span").removeClass("on").eq(0).addClass("on"); //为第一个按钮添加选中的效果
	}
	
	
});

</script>

<!--品牌担保-->
<script type="text/javascript">
$(function(){
    //鼠标划入时
    $('#drop1').hover
    (
            function()
            {     
                  $(this).children('#w0').show();
                  $(this).children('#w1').hide();
                  $(this).children('#w2').hide();
                  
                  $(this).children('dt').children('a').toggleClass("dhover");
                  $("#drop2").children('dt').children('a').toggleClass("cc");
                  $("#drop3").children('dt').children('a').toggleClass("cc");
                  
                  $(this).children('dt').children('a').children('b').addClass("d0");
            },
            //鼠标移除时
            function()
            {
                  $(this).children('#w0').hide();
                  
                  $(this).children('dt').children('a').attr("class","");
                  $("#drop2").children('dt').children('a').attr("class","");
                  $("#drop3").children('dt').children('a').attr("class","");
                  
                  $(this).children('dt').children('a').children('b').removeClass("d0");
            }
     );
     
      $('#drop2').hover
      (
            function()
            {
                  $(this).children('#w0').hide();
                  $(this).children('#w1').show();
                  $(this).children('#w2').hide();
                  
                  $(this).children('dt').children('a').toggleClass("dhover");
                  $("#drop1").children('dt').children('a').toggleClass("cc");
                  $("#drop3").children('dt').children('a').toggleClass("cc");
                  
                  $(this).children('dt').children('a').children('b').addClass("d1");
            
            },
            //鼠标移除时
            function()
            {
                $(this).children('#w1').hide();
                 $(this).children('dt').children('a').attr("class","");
                  $("#drop1").children('dt').children('a').attr("class","");
                  $("#drop3").children('dt').children('a').attr("class","");
                  
                  $(this).children('dt').children('a').children('b').removeClass("d1");
            }
        
      );
      
      $('#drop3').hover
      (
            function()
            {
                  $(this).children('#w0').hide();
                  $(this).children('#w1').hide();
                  $(this).children('#w2').show();
                  
                  $(this).children('dt').children('a').toggleClass("dhover");
                  $("#drop1").children('dt').children('a').toggleClass("cc");
                  $("#drop2").children('dt').children('a').toggleClass("cc");
                  
                  $(this).children('dt').children('a').children('b').addClass("d2");
            
            },
            //鼠标移除时
            function()
            {
                  $(this).children('#w2').hide();
                  
                  $(this).children('dt').children('a').attr("class","");
                  $("#drop1").children('dt').children('a').attr("class","");
                  $("#drop2").children('dt').children('a').attr("class","");
                  
                  $(this).children('dt').children('a').children('b').removeClass("d2");
                  
            }
        
      );
//     $(".itenone h3 a,.itenone .item_col a,.itentwo h3 a,.itentwo .item_col a").each(function(){
//            $(this).removeAttr("href");
//     });
})
</script>

<!--最新成交-->
<script type="text/javascript" type="text/javascript" src="/main/js/NewSaleOrder.js"></script>
<div id="content">
    <div class="mallFpCon">
        <div class="topScreen">
            <!--三级分类 Start-->
            <ShopNum1:ProductThreeCategory2 ID="ProductThreeCategoryDefault1" FlowerID="3" SimulationID="4"
                CartoonID="5" CakeID="6" PlantsID="7" WeddingID="8" Show0Count="3" ShowOneCount="20"
                ShowTwoCount="1000" ShowThreeCount="30" runat="server" SkinFilename="ProductThreeCategory2.ascx" CssClass="w_cate" />
            <!--//三级分类 End-->
            
            <!--幻灯片 Start-->
            <div class="tsMain">
                <div id="focus" class="tsSlide">
                    <ul class="tsSlide_list">
                        <li>
                            <div class="li1_div1">
                                <ShopNum1:AdSimpleImage ID="AdSimpleImage1" runat="server" AdImgId="1" SkinFilename="AdSimpleImage.ascx" />
                            </div>
                        </li>
                        <li>
                            <div class="li1_div2">
                                <ShopNum1:AdSimpleImage ID="AdSimpleImage2" runat="server" AdImgId="2" SkinFilename="AdSimpleImage.ascx" />
                            </div>
                        </li>
                        <li>
                           <div class="li1_div3">
                                <ShopNum1:AdSimpleImage ID="AdSimpleImage3_0" runat="server" AdImgId="3" SkinFilename="AdSimpleImage.ascx" />
                            </div>
                        </li>
                        <li>
                            <div class="li1_div4">
                                <ShopNum1:AdSimpleImage ID="AdSimpleImage4" runat="server" AdImgId="4" SkinFilename="AdSimpleImage.ascx" />
                            </div>
                        </li>
                        <li>
                            <div class="li1_div5">
                                <ShopNum1:AdSimpleImage ID="AdSimpleImage5_0" runat="server" AdImgId="5" SkinFilename="AdSimpleImage.ascx" />
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
            <!--//幻灯片 End-->
        </div>
    </div>
    <div class="mainFpCon">
        <div class="tsBottom clearfix">
            <!-- 最新推荐 Start-->
            <div class="tsBottom_left fl">
                <div class="lmf_t">
                    <img src="Themes/Skin_Default/Images/pptj.png" class="fl" />
                     <span class="lmf_t_more"><a href="/ProductListPromotion.aspx?code=-1&IsshopRecommend=1">更多>></a></span>                </div>
                <div class="lmf_main">
                    <div class="leftadv fl">
                        <ShopNum1:AdSimpleImage ID="adrecomment" runat="server" AdImgId="53" SkinFilename="AdSimpleImage.ascx" />
                    </div>
                    <div class="prodea fr">
                        <ShopNum1:ProductEspecialSeach ID="ProductEspecialSeach1" runat="server" SkinFilename="ProductEspecialSeach4.ascx"
                            ProductType="IsRecommend" ShowCount="8" />
                    </div>
                </div>
            </div>
            <!-- //最新推荐 End-->
            
            <!-- 最新成交 Start-->
          <ShopNum1:NewSaleOrder ID="NewSaleOrder" runat="server" TopSaleNum="15" SkinFilename="NewSaleOrder.ascx"/>
            <!-- //最新成交 End-->
        </div>
         <div class="maptop_index"></div>
        <!--1楼 美容美妆 Start-->
        <div class="mod_right4">
            <div class="title">
                <div class="setitle fl">
                    <ShopNum1:AdSimpleImage ID="floor1" runat="server" AdImgId="58" SkinFilename="AdSimpleImage.ascx" Visible="false" />
                    <b>1F</b>美容珠宝                    
                </div>
                <ShopNum1:ProductSubCategory ID="ProductSubCategory7" runat="server" SkinFilename="ProductSubCategory.ascx"
                    CategoryID="4" ShowCount="8"  NewCategoryID="004" />
            </div>
            <div class="brandAdvice_con clearfix">
                <div class="floorleft">
                    <ShopNum1:AdSimpleImage ID="floor1top" runat="server" AdImgId="54" SkinFilename="AdSimpleImage.ascx" />
     
                </div>
                <div class="flooright">
                    <ShopNum1:ProductListForCategory ID="ProductListForCategory7" runat="server" SkinFilename="ProductListForCategory.ascx"
                        CategoryID="004" ShowCountProduct="10" />
                </div>
            </div>
        </div>
        <!--//1楼 美容美妆 End-->
        <!--2楼 服饰内衣 Start-->
        <div class="mod_right4">
            <div class="title">
                <div class="setitle fl">
                    <ShopNum1:AdSimpleImage ID="floor2top" runat="server" AdImgId="59" SkinFilename="AdSimpleImage.ascx" Visible="false" />
                     <b>2F</b>服饰内衣
                </div>
                <ShopNum1:ProductSubCategory ID="ProductSubCategory1" runat="server" SkinFilename="ProductSubCategory.ascx"
                    CategoryID="2" ShowCount="8"  NewCategoryID="002" />
            </div>
            <div class="brandAdvice_con clearfix">
                <div class="floorleft">
                    <ShopNum1:AdSimpleImage ID="j_2_top" runat="server" AdImgId="55" SkinFilename="AdSimpleImage.ascx" />
                  
                </div>
                <div class="flooright">
                    <ShopNum1:ProductListForCategory ID="ProductListForCategory1" runat="server" SkinFilename="ProductListForCategory.ascx"
                        CategoryID="002" ShowCountProduct="10" />
                </div>
            </div>
        </div>
        <!--//2楼 服饰内衣 End-->
        <div class="maptop_index">
            <ShopNum1:AdSimpleImage ID="AdSimpleImage2_f" runat="server" AdImgId="56" SkinFilename="AdSimpleImage.ascx" />
        </div>        
        <!--3楼 鞋包运动 Start-->
        <div class="mod_right4">
            <div class="title">
                <div class="setitle fl">
                    <ShopNum1:AdSimpleImage ID="AdSimpleImage3" runat="server" AdImgId="60" SkinFilename="AdSimpleImage.ascx" Visible="false" />
                     <b>3F</b>鞋包运动
                </div>
                <ShopNum1:ProductSubCategory ID="ProductSubCategory2" runat="server" SkinFilename="ProductSubCategory.ascx"
                    CategoryID="3" ShowCount="8"  NewCategoryID="003" />
            </div>
            <div class="brandAdvice_con clearfix">
                <div class="floorleft">
                    <ShopNum1:AdSimpleImage ID="floor_3_top" runat="server" AdImgId="66" SkinFilename="AdSimpleImage.ascx" />
                 
                </div>
                <div class="flooright">
                    <ShopNum1:ProductListForCategory ID="ProductListForCategory2" runat="server" SkinFilename="ProductListForCategory.ascx"
                        CategoryID="003" ShowCountProduct="10" />
                </div>
            </div>
        </div>
        <!--//3楼 鞋包运动 End-->
        <!--4楼 母婴用品 Start-->
        <div class="mod_right4">
            <div class="title">
                <div class="setitle fl">
                    <ShopNum1:AdSimpleImage ID="floor_4" runat="server" AdImgId="61" SkinFilename="AdSimpleImage.ascx" Visible="false" />
                     <b>4F</b>母婴用品
                </div>
                <ShopNum1:ProductSubCategory ID="ProductSubCategory3" runat="server" SkinFilename="ProductSubCategory.ascx"
                    CategoryID="9" ShowCount="8"  NewCategoryID="009" />
            </div>
            <div class="brandAdvice_con clearfix">
                <div class="floorleft">
                    <ShopNum1:AdSimpleImage ID="floor_4_top" runat="server" AdImgId="68" SkinFilename="AdSimpleImage.ascx" />
                  
                </div>
                <div class="flooright">
                    <ShopNum1:ProductListForCategory ID="ProductListForCategory3" runat="server" SkinFilename="ProductListForCategory.ascx"
                        CategoryID="009" ShowCountProduct="10" />
                </div>
            </div>
        </div>
        <!--//4楼 母婴用品 End-->
        <div class="maptop_index">
            <ShopNum1:AdSimpleImage ID="AdSimpleImage5" runat="server" AdImgId="70" SkinFilename="AdSimpleImage.ascx" />
        </div>
        <!--5楼 数码家电 Start-->
        <div class="mod_right4">
            <div class="title">
                <div class="setitle fl">
                    <ShopNum1:AdSimpleImage ID="AdSimpleImage6" runat="server" AdImgId="62" SkinFilename="AdSimpleImage.ascx" Visible="false" />
                     <b>5F</b>数码家电
                </div>
                <ShopNum1:ProductSubCategory ID="ProductSubCategory4" runat="server" SkinFilename="ProductSubCategory.ascx"
                    CategoryID="6" ShowCount="8" NewCategoryID="006" />
            </div>
            <div class="brandAdvice_con clearfix">
                <div class="floorleft">
                    <ShopNum1:AdSimpleImage ID="flool_5_top" runat="server" AdImgId="71" SkinFilename="AdSimpleImage.ascx" />
            
                </div>
                <div class="flooright">
                    <ShopNum1:ProductListForCategory ID="ProductListForCategory4" runat="server" SkinFilename="ProductListForCategory.ascx"
                        CategoryID="006" ShowCountProduct="10" />
                </div>
            </div>
        </div>
        <!--//5楼 数码家电 End-->
        <!--6楼 家装家饰 Start-->
        <div class="mod_right4">
            <div class="title">
                <div class="setitle fl">
                    <ShopNum1:AdSimpleImage ID="floor_6" runat="server" AdImgId="63" SkinFilename="AdSimpleImage.ascx" Visible="false" />
                     <b>6F</b>家装家饰
                </div>
                <ShopNum1:ProductSubCategory ID="ProductSubCategory5" runat="server" SkinFilename="ProductSubCategory.ascx"
                    CategoryID="7" ShowCount="8"  NewCategoryID="007" />
            </div>
            <div class="brandAdvice_con clearfix">
                <div class="floorleft">
                    <ShopNum1:AdSimpleImage ID="floor_6_top" runat="server" AdImgId="73" SkinFilename="AdSimpleImage.ascx" />
         
                </div>
                <div class="flooright">
                    <ShopNum1:ProductListForCategory ID="ProductListForCategory5" runat="server" SkinFilename="ProductListForCategory.ascx"
                        CategoryID="007" ShowCountProduct="10" />
                </div>
            </div>
        </div>
        <!--//6楼 家装家饰 End-->
        <!--7楼 食品保健 Start-->
        <div class="mod_right4">
            <div class="title">
                <div class="setitle fl">
                    <ShopNum1:AdSimpleImage ID="floor_7" runat="server" AdImgId="64" SkinFilename="AdSimpleImage.ascx" Visible="false" />
                     <b>7F</b>食品保健
                </div>
                <ShopNum1:ProductSubCategory ID="ProductSubCategory6" runat="server" SkinFilename="ProductSubCategory.ascx"
                    CategoryID="8" ShowCount="8"  NewCategoryID="008" />
            </div>
            <div class="brandAdvice_con clearfix">
                <div class="floorleft">
                    <ShopNum1:AdSimpleImage ID="floor_7_top" runat="server" AdImgId="75" SkinFilename="AdSimpleImage.ascx" />
         
                </div>
                <div class="flooright">
                    <ShopNum1:ProductListForCategory ID="ProductListForCategory6" runat="server" SkinFilename="ProductListForCategory.ascx"
                        CategoryID="008" ShowCountProduct="10" />
                </div>
            </div>
        </div>
        <!--//7楼 食品保健 End-->
        <div class="maptop_index">
            <ShopNum1:AdSimpleImage ID="floor_bottom" runat="server" AdImgId="77" SkinFilename="AdSimpleImage.ascx" />
        </div>
    </div>
</div>
