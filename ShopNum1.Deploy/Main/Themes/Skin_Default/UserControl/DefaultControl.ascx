<%@ Control Language="C#" AutoEventWireup="true" %>
<script type="text/javascript">

    function HideWenzi0() {
        $("#w0").hide();
        $("#w1").hide();
        $("#w2").hide();

        $("q0").className = "";
        $("q1").className = "";
        $("q2").className = "";

        $("d0").className = "";
        $("d1").className = "";
        $("d2").className = "";
    }
    function HideWenzi1() {
        $("#w1").hide();
        $("#w2").hide();
    }
    function HideWenzi2() {
        $("#w2").hide();
    }
</script>

<!--首页广告位-->
<script type="text/javascript">
    $(function () {
        var sWidth = $("#focus").width(); //获取焦点图的宽度（显示面积）
        var len = $("#focus ul li").length; //获取焦点图个数
        var index = 0;
        var picTimer;

        //以下代码添加数字按钮和按钮后的半透明长条
        var btn = "<div class='btnBg'></div><div class='btn'>";
        for (var i = 0; i < len; i++) {
            btn += "<span>" + (i + 1) + "</span>";
        }
        btn += "</div>";
        $("#focus").append(btn);
        $("#focus .btnBg").css("opacity", 0.2);

        //为数字按钮添加鼠标滑入事件，以显示相应的内容
        $("#focus .btn span").mouseenter(function () {
            index = $("#focus .btn span").index(this);
            showPics(index);
        }).eq(0).trigger("mouseenter");

        //本例为左右滚动，即所有li元素都是在同一排向左浮动，所以这里需要计算出外围ul元素的宽度
        $("#focus ul").css("width", sWidth * (len + 1));

        //鼠标滑入某li中的某div里，调整其同辈div元素的透明度，由于li的背景为黑色，所以会有变暗的效果
        $("#focus ul li div").hover(function () {
            $(this).siblings().css("opacity", 0.7);
        }, function () {
            $("#focus ul li div").css("opacity", 1);
        });

        //鼠标滑上焦点图时停止自动播放，滑出时开始自动播放
        $("#focus").hover(function () {
            clearInterval(picTimer);
        }, function () {
            picTimer = setInterval(function () {
                if (index == len) { //如果索引值等于li元素个数，说明最后一张图播放完毕，接下来要显示第一张图，即调用showFirPic()，然后将索引值清零
                    showFirPic();
                    index = 0;
                } else { //如果索引值不等于li元素个数，按普通状态切换，调用showPics()
                    showPics(index);
                }
                index++;
            }, 5000); //此3000代表自动播放的间隔，单位：毫秒
        }).trigger("mouseleave");

        //显示图片函数，根据接收的index值显示相应的内容
        function showPics(index) { //普通切换
            var nowLeft = -index * sWidth; //根据index值计算ul元素的left值
            $("#focus ul").stop(true, false).animate({ "left": nowLeft }, 500); //通过animate()调整ul元素滚动到计算出的position
            $("#focus .btn span").removeClass("on").eq(index).addClass("on"); //为当前的按钮切换到选中的效果
        }

        function showFirPic() { //最后一张图自动切换到第一张图时专用
            $("#focus ul").append($("#focus ul li:first").clone());
            var nowLeft = -len * sWidth; //通过li元素个数计算ul元素的left值，也就是最后一个li元素的右边
            $("#focus ul").stop(true, false).animate({ "left": nowLeft }, 500, function () {
                //通过callback，在动画结束后把ul元素重新定位到起点，然后删除最后一个复制过去的元素
                $("#focus ul").css("left", "0");
                $("#focus ul li:last").remove();
            });
            $("#focus .btn span").removeClass("on").eq(0).addClass("on"); //为第一个按钮添加选中的效果
        }
    });

</script>
<!--品牌担保-->
<script type="text/javascript">
    $(function () {
        //鼠标划入时
        $('#drop1').hover
    (
            function () {
                $(this).children('#w0').show();
                $(this).children('#w1').hide();
                $(this).children('#w2').hide();

                $(this).children('dt').children('a').toggleClass("dhover");
                $("#drop2").children('dt').children('a').toggleClass("cc");
                $("#drop3").children('dt').children('a').toggleClass("cc");

                $(this).children('dt').children('a').children('b').addClass("d0");
            },
        //鼠标移除时
            function () {
                $(this).children('#w0').hide();

                $(this).children('dt').children('a').attr("class", "");
                $("#drop2").children('dt').children('a').attr("class", "");
                $("#drop3").children('dt').children('a').attr("class", "");

                $(this).children('dt').children('a').children('b').removeClass("d0");
            }
     );

        $('#drop2').hover
      (
            function () {
                $(this).children('#w0').hide();
                $(this).children('#w1').show();
                $(this).children('#w2').hide();

                $(this).children('dt').children('a').toggleClass("dhover");
                $("#drop1").children('dt').children('a').toggleClass("cc");
                $("#drop3").children('dt').children('a').toggleClass("cc");

                $(this).children('dt').children('a').children('b').addClass("d1");

            },
        //鼠标移除时
            function () {
                $(this).children('#w1').hide();
                $(this).children('dt').children('a').attr("class", "");
                $("#drop1").children('dt').children('a').attr("class", "");
                $("#drop3").children('dt').children('a').attr("class", "");

                $(this).children('dt').children('a').children('b').removeClass("d1");
            }

      );

        $('#drop3').hover
      (
            function () {
                $(this).children('#w0').hide();
                $(this).children('#w1').hide();
                $(this).children('#w2').show();

                $(this).children('dt').children('a').toggleClass("dhover");
                $("#drop1").children('dt').children('a').toggleClass("cc");
                $("#drop2").children('dt').children('a').toggleClass("cc");

                $(this).children('dt').children('a').children('b').addClass("d2");

            },
        //鼠标移除时
            function () {
                $(this).children('#w2').hide();

                $(this).children('dt').children('a').attr("class", "");
                $("#drop1").children('dt').children('a').attr("class", "");
                $("#drop2").children('dt').children('a').attr("class", "");

                $(this).children('dt').children('a').children('b').removeClass("d2");

            }

      );
        //     $(".itenone h3 a,.itenone .item_col a,.itentwo h3 a,.itentwo .item_col a").each(function(){
        //            $(this).removeAttr("href");
        //     });
    })
</script>
<div id="content">
    <div class="mainFpCon">
        <div class="tsBottom clearfix">
            <!-- 最新推荐 Start-->
            <div class="tsBottom_left fl">
                <div class="lmf_t">
					<h4 class="fl" >最新推荐</h4>
                    <span class="lmf_t_more"><a href="http://shop100000027.qlxcars.com/ProductListNew.aspx?category=1&select=1&tab">
                        更多>></a></span>
                </div>
                <div class="lmf_main" >
                    <div class="leftadv fl">
                        <ShopNum1:AdSimpleImage ID="adrecomment" runat="server" AdImgId="53" SkinFilename="AdSimpleImage.ascx" />
                    </div>
                    <div class="prodea fr">
                        <ShopNum1:ProductEspecialSeach ID="ProductEspecialSeach1" runat="server" SkinFilename="ProductEspecialSeach4.ascx"
                            ProductType="IsRecommend" ShowCount="10" />
                    </div>
                </div>
            </div>
            
        </div>
        <div class="maptop_index">
            <%-- <ShopNum1:AdSimpleImage ID="AdSimpleImage18" runat="server" AdImgId="78" SkinFilename="AdSimpleImage.ascx" />--%>
        </div>
        <!--1楼 美容美妆 Start-->
        <div class="mod_right4" style=" display:none;">
            <div class="title">
                <div class="setitle fl">
                    <ShopNum1:AdSimpleImage ID="floor1" runat="server" AdImgId="58" SkinFilename="AdSimpleImage.ascx"
                        Visible="false" />
                    <b>1F</b>唐江系列大礼包
                </div>
                <%--<ShopNum1:ProductSubCategory ID="ProductSubCategory7" runat="server" SkinFilename="ProductSubCategory.ascx"
                    CategoryID="4" ShowCount="8" NewCategoryID="043" />--%>
            </div>
            <div class="brandAdvice_con clearfix">
                <div class="floorleft">
                    <ShopNum1:AdSimpleImage ID="floor1top" runat="server" AdImgId="54" SkinFilename="AdSimpleImage.ascx" />
                </div>
                <div class="flooright">
                    <ShopNum1:ProductListForCategory ID="ProductListForCategory7" runat="server" SkinFilename="ProductListForCategory.ascx"
                        CategoryID="043" ShowCountProduct="10" />
                </div>
            </div>
        </div>
        <!--//1楼 美容美妆 End-->
        <!--2楼 服饰内衣 Start-->
        <div class="mod_right4" style=" display:none;">
            <div class="title">
                <div class="setitle fl">
                    <ShopNum1:AdSimpleImage ID="floor2top" runat="server" AdImgId="59" SkinFilename="AdSimpleImage.ascx"
                        Visible="false" />
                    <b>1F</b>服饰内衣
                </div>
                <%--<ShopNum1:ProductSubCategory ID="ProductSubCategory1" runat="server" SkinFilename="ProductSubCategory.ascx"
                    CategoryID="2" ShowCount="8" NewCategoryID="038" />--%>
            </div>
            <div class="brandAdvice_con clearfix">
                <div class="floorleft">
                    <ShopNum1:AdSimpleImage ID="j_2_top" runat="server" AdImgId="55" SkinFilename="AdSimpleImage.ascx" />
                </div>
                <div class="flooright">
                    <ShopNum1:ProductListForCategory ID="ProductListForCategory1" runat="server" SkinFilename="ProductListForCategory.ascx"
                        CategoryID="038" ShowCountProduct="10" />
                </div>
            </div>
        </div>
        <!--//2楼 服饰内衣 End-->
        <div class="maptop_index" style=" display:none;">
            <ShopNum1:AdSimpleImage ID="AdSimpleImage2_f" runat="server" AdImgId="56" SkinFilename="AdSimpleImage.ascx" />
        </div>
        <!--3楼 鞋包运动 Start-->
        <div class="mod_right4" style=" display:none;">
            <div class="title">
                <div class="setitle fl">
                    <ShopNum1:AdSimpleImage ID="AdSimpleImage3" runat="server" AdImgId="60" SkinFilename="AdSimpleImage.ascx"
                        Visible="false" />
                    <b>2F</b>洗涤用品
                </div>
                <%--<ShopNum1:ProductSubCategory ID="ProductSubCategory2" runat="server" SkinFilename="ProductSubCategory.ascx"
                    CategoryID="3" ShowCount="8" NewCategoryID="039" />--%>
            </div>
            <div class="brandAdvice_con clearfix">
                <div class="floorleft">
                    <ShopNum1:AdSimpleImage ID="floor_3_top" runat="server" AdImgId="66" SkinFilename="AdSimpleImage.ascx" />
                </div>
                <div class="flooright">
                    <ShopNum1:ProductListForCategory ID="ProductListForCategory2" runat="server" SkinFilename="ProductListForCategory.ascx"
                        CategoryID="039" ShowCountProduct="10" />
                </div>
            </div>
        </div>
        <!--//3楼 鞋包运动 End-->
        <!--4楼 母婴用品 Start-->
        <div class="mod_right4" style=" display:none;">
            <div class="title">
                <div class="setitle fl">
                    <ShopNum1:AdSimpleImage ID="floor_4" runat="server" AdImgId="61" SkinFilename="AdSimpleImage.ascx"
                        Visible="false" />
                    <b>3F</b>日用百货
                </div>
                <%--<ShopNum1:ProductSubCategory ID="ProductSubCategory3" runat="server" SkinFilename="ProductSubCategory.ascx"
                    CategoryID="9" ShowCount="8" NewCategoryID="040" />--%>
            </div>
            <div class="brandAdvice_con clearfix">
                <div class="floorleft">
                    <ShopNum1:AdSimpleImage ID="floor_4_top" runat="server" AdImgId="68" SkinFilename="AdSimpleImage.ascx" />
                </div>
                <div class="flooright">
                    <ShopNum1:ProductListForCategory ID="ProductListForCategory3" runat="server" SkinFilename="ProductListForCategory.ascx"
                        CategoryID="040" ShowCountProduct="10" />
                </div>
            </div>
        </div>
        <!--//4楼 母婴用品 End-->
        <div class="maptop_index" style=" display:none;">
            <ShopNum1:AdSimpleImage ID="AdSimpleImage5" runat="server" AdImgId="70" SkinFilename="AdSimpleImage.ascx" />
        </div>
       <%-- <!--5楼 数码家电 Start-->
        <div class="mod_right4">
            <div class="title">
                <div class="setitle fl">
                    <ShopNum1:AdSimpleImage ID="AdSimpleImage6" runat="server" AdImgId="62" SkinFilename="AdSimpleImage.ascx"
                        Visible="false" />
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
        <!--//5楼 数码家电 End-->--%>
        <!--6楼 家装家饰 Start-->
        <div class="mod_right4" style=" display:none;">
            <div class="title">
                <div class="setitle fl">
                    <ShopNum1:AdSimpleImage ID="floor_6" runat="server" AdImgId="63" SkinFilename="AdSimpleImage.ascx"
                        Visible="false" />
                    <b>4F</b>家装家纺
                </div>
               <%-- <ShopNum1:ProductSubCategory ID="ProductSubCategory5" runat="server" SkinFilename="ProductSubCategory.ascx"
                    CategoryID="7" ShowCount="8" NewCategoryID="041" />--%>
            </div>
            <div class="brandAdvice_con clearfix">
                <div class="floorleft">
                    <ShopNum1:AdSimpleImage ID="floor_6_top" runat="server" AdImgId="73" SkinFilename="AdSimpleImage.ascx" />
                </div>
                <div class="flooright">
                    <ShopNum1:ProductListForCategory ID="ProductListForCategory5" runat="server" SkinFilename="ProductListForCategory.ascx"
                        CategoryID="041" ShowCountProduct="10" />
                </div>
            </div>
        </div>
        <!--//6楼 家装家纺 End-->
        <!--7楼 食品保健 Start-->
        <div class="mod_right4" style=" display:none;">
            <div class="title">
                <div class="setitle fl">
                    <ShopNum1:AdSimpleImage ID="floor_7" runat="server" AdImgId="64" SkinFilename="AdSimpleImage.ascx"
                        Visible="false" />
                    <b>5F</b>食品保健
                </div>
                <%--<ShopNum1:ProductSubCategory ID="ProductSubCategory6" runat="server" SkinFilename="ProductSubCategory.ascx"
                    CategoryID="8" ShowCount="8" NewCategoryID="008" />--%>
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
        <!--8楼 BTC  热销商品 Start-->
        <div class="mod_right4"  style="display:none;">
            <div class="title">
                <div class="setitle fl">
                    <ShopNum1:AdSimpleImage ID="AdSimpleImage1" runat="server" AdImgId="64" SkinFilename="AdSimpleImage.ascx"
                        Visible="false" />
                    <b>7F</b>BTC  热销商品
                </div>
                <%--<ShopNum1:ProductSubCategory ID="ProductSubCategory6" runat="server" SkinFilename="ProductSubCategory.ascx"
                    CategoryID="8" ShowCount="8" NewCategoryID="008" />--%>
            </div>
            <div class="brandAdvice_con clearfix">
                <div class="floorleft">
                    <ShopNum1:AdSimpleImage ID="AdSimpleImage2" runat="server" AdImgId="901" SkinFilename="AdSimpleImage.ascx" />
                </div>
                <div class="flooright">
                    <ShopNum1:ProductListForCategory ID="ProductListForCategory4" runat="server" SkinFilename="ProductListForCategory.ascx"
                        CategoryID="HOT" ShowCountProduct="10" />
                </div>
            </div>
        </div>
        <!--//8楼 BTC  热销商品 End-->
        <!--9楼 BTC  最新商品 Start-->
        <div class="mod_right4"  style="display:none;">
            <div class="title">
                <div class="setitle fl">
                    <ShopNum1:AdSimpleImage ID="AdSimpleImage4" runat="server" AdImgId="64" SkinFilename="AdSimpleImage.ascx"
                        Visible="false" />
                    <b>8F</b>BTC  最新商品
                </div>
                <%--<ShopNum1:ProductSubCategory ID="ProductSubCategory6" runat="server" SkinFilename="ProductSubCategory.ascx"
                    CategoryID="8" ShowCount="8" NewCategoryID="008" />--%>
            </div>
            <div class="brandAdvice_con clearfix">
                <div class="floorleft">
                    <ShopNum1:AdSimpleImage ID="AdSimpleImage6" runat="server" AdImgId="911" SkinFilename="AdSimpleImage.ascx" />
                </div>
                <div class="flooright">
                    <ShopNum1:ProductListForCategory ID="ProductListForCategory8" runat="server" SkinFilename="ProductListForCategory.ascx"
                        CategoryID="NEW" ShowCountProduct="10" />
                </div>
            </div>
        </div>
        <!--//9楼 BTC  最新商品 End-->
        <!--10楼 BTC  特色商品 Start-->
        <div class="mod_right4"  style="display:none;">
            <div class="title">
                <div class="setitle fl">
                    <ShopNum1:AdSimpleImage ID="AdSimpleImage7" runat="server" AdImgId="64" SkinFilename="AdSimpleImage.ascx"
                        Visible="false" />
                    <b>9F</b>BTC  特色商品
                </div>
                <%--<ShopNum1:ProductSubCategory ID="ProductSubCategory6" runat="server" SkinFilename="ProductSubCategory.ascx"
                    CategoryID="8" ShowCount="8" NewCategoryID="008" />--%>
            </div>
            <div class="brandAdvice_con clearfix">
                <div class="floorleft">
                    <ShopNum1:AdSimpleImage ID="AdSimpleImage8" runat="server" AdImgId="921" SkinFilename="AdSimpleImage.ascx" />
                </div>
                <div class="flooright">
                    <ShopNum1:ProductListForCategory ID="ProductListForCategory9" runat="server" SkinFilename="ProductListForCategory.ascx"
                        CategoryID="Tercel" ShowCountProduct="10" />
                </div>
            </div>
        </div>
        <!--//10楼 BTC  特色商品 End-->
        <div class="maptop_index" style=" display:none;">
            <ShopNum1:AdSimpleImage ID="floor_bottom" runat="server" AdImgId="77" SkinFilename="AdSimpleImage.ascx" />
        </div>
    </div>
</div>
