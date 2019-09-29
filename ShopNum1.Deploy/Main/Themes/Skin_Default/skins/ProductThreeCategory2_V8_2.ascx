<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<style>
/*字体图标*/
@font-face {
	font-family:fp-font;
	src:url(../fonts/font_1.eot);
	src:url(../fonts/font_1.eot?#iefix) format('embedded-opentype'),url(../fonts/font_2.woff) format('woff'),url(../fonts/font_3.ttf) format('truetype'),url(../fonts/font_4.svg#svgFontName) format('svg')
}
.fp-iconfont{font-family:fp-font;}
.cat-nav-icon{ display:inline-block;*display:inline;*zoom:1;width:40px;margin-right:3px;text-align:right;text-decoration:none;font-size:16px;}

.cate_nav{font-size:12px;color:#000000;}
.cate_nav li{height:30px;line-height:30px;font-family:'宋体';}
.cate_nav li a{color:#000000;font-size:12px;text-decoration:none;}
.cate_nav li a:hover{text-decoration:underline;}

.tmall_cat_content{width:800px;height:483px;}
.tmall_cat_content,.cat_pannel .cat_banner{border-right:1px #E5E5E5 solid;}
.cat_pannel .cat_detail{width:130px;height:461px;padding:10px;position:relative;}
.cat_pannel .market_banner{display:block;width:170px;height:140px;position:absolute;bottom:-21px;left:-30px;}
.cat_pannel .cat_label_list{padding-left:10px;}
.cat_pannel .cat_label_list li{width:50px;height:25px;line-height:25px;float:left;}
.cat_pannel .cat_label_list li.second_label{padding-left:12px;}
.cat_pannel .cat_label_list li a{color:#FFFFFF;font-size:12px;text-decoration:none;}
.cat_pannel .cat_label_list li a:hover{text-decoration:underline;}
.cat_pannel .market_list{width:140px;padding-left:10px;}
.cat_pannel .market_list li{width:50px;height:34px;line-height:34px;text-align:center;margin-right:10px;border-bottom:1px #CE3132 solid;}
.cat_pannel .market_list li a,.cat_pannel h3.cat_title{font-weight:bold;font-size:14px;}
.cat_pannel h3.cat_label_title{font-size:12px;color:#E4A8A3;text-align:center;padding:15px 0 8px 0;}
.cat_pannel h3.cat_title{color:#FFFFFF;text-align:center;height:30px;line-height:23px;}
.cat_pannel .cat_title{margin-bottom:10px;}
.cat_pannel .grid_col_1 .cat_title{border-bottom:1px #D64F74 solid;}
.cat_pannel .grid_col_2 .cat_title{border-bottom:1px #66B0D2 solid;}
.cat_pannel .grid_col_3 .cat_title{border-bottom:1px #9F6EA1 solid;}
.cat_pannel .grid_col_4 .cat_title{border-bottom:1px #D14F88 solid;}
.cat_pannel .grid_col_5 .cat_title{border-bottom:1px #4E81D5 solid;}
.cat_pannel .grid_col_6 .cat_title{border-bottom:1px #F15A6A solid;}
.cat_pannel .grid_col_7 .cat_title{border-bottom:1px #F88F44 solid;}
.cat_pannel .grid_col_8 .cat_title{border-bottom:1px #6998E6 solid;}
.cat_pannel .grid_col_9 .cat_title{border-bottom:1px #DA6542 solid;}
.cat_pannel .grid_col_10 .cat_title{border-bottom:1px #CFB8A1 solid;}
.cat_pannel .grid_col_11 .cat_title{border-bottom:1px #9EA6C2 solid;}
.cat_pannel .grid_col_12 .cat_title{border-bottom:1px #C1CA5F solid;}
.cat_pannel .grid_col_13 .cat_title{border-bottom:1px #58CA9D solid;}
.cat_pannel .grid_col_14 .cat_title{border-bottom:1px #88B463 solid;}
.cat_pannel .grid_col_15 .cat_title{border-bottom:1px #54A9BD solid;}


.cat_pannel .cat_brand{ position:relative;height:101px;width:120px;padding-top:13px;margin:10px 0 0 5px;overflow:hidden;}
.cat_pannel .grid_col_1 .cat_brand{border-top:1px #D64F74 dotted;}
.cat_pannel .grid_col_2 .cat_brand{border-top:1px #66B0D2 dotted;}
.cat_pannel .grid_col_3 .cat_brand{border-top:1px #9F6EA1 dotted;}
.cat_pannel .grid_col_4 .cat_brand{border-top:1px #D14F88 dotted;}
.cat_pannel .grid_col_5 .cat_brand{border-top:1px #4E81D5 dotted;}
.cat_pannel .grid_col_6 .cat_brand{border-top:1px #F15A6A dotted;}
.cat_pannel .grid_col_7 .cat_brand{border-top:1px #F88F44 dotted;}
.cat_pannel .grid_col_8 .cat_brand{border-top:1px #6998E6 dotted;}
.cat_pannel .grid_col_9 .cat_brand{border-top:1px #DA6542 dotted;}
.cat_pannel .grid_col_10 .cat_brand{border-top:1px #CFB8A1 dotted;}
.cat_pannel .grid_col_11 .cat_brand{border-top:1px #9EA6C2 dotted;}
.cat_pannel .grid_col_12 .cat_brand{border-top:1px #C1CA5F dotted;}
.cat_pannel .grid_col_13 .cat_brand{border-top:1px #58CA9D dotted;}
.cat_pannel .grid_col_14 .cat_brand{border-top:1px #88B463 dotted;}
.cat_pannel .grid_col_15 .cat_brand{border-top:1px #54A9BD dotted;}

.cat_brand .cat_slide_brand li{width:130px;}
.cat_brand .cat_slide_brand a{ display:block;width:120px;height:40px;background:#FFFFFF;text-align:center;margin-bottom: 2px;}
.cat_brand .cat_slide_nav{ height:18px;line-height:18px;position:absolute;bottom:0;left:45px;}
.cat_brand .cat_slide_nav li{ float:left;width:5px;font-family:Tahoma,Helvetica;font-size:15px;_font-size:25px;color:#B2B2B2;margin-right:7px;cursor:pointer;}
.cat_brand .cat_slide_nav li.on{ color:#FFFFFF;}


.cat_pannel .cat_banner{width:459px;height:482px;position:relative;}
.cat_pannel .cat_banner .num{overflow:hidden;height:20px;position:absolute;bottom:6px;right:0;zoom:1;z-index:3}
.cat_pannel .cat_banner .num li{width:20px;height:20px;line-height:20px;text-align:center;font-size:12px;font-weight:400;font-family:"微软雅黑", Arial;color:#FFFFFF;background:#000000;margin-right:6px;border-radius:50%;cursor:pointer;float:left;}
.cat_pannel .cat_banner .num li.on{background:#C40000;}

.cat_pannel .cat_banner .prev_pic,
.cat_pannel .cat_banner .next_pic{ display:none;width:39px;height:50px;background:url(../images/btn.png) no-repeat;position:absolute;top:216px;}
.cat_pannel .cat_banner .prev_pic{ left:5px;}
.cat_pannel .cat_banner .next_pic{ right:5px;background-position:right;}

.banner-grid-b1,.banner-grid-b2, .banner-grid-b4{display:block;border-right:1px #e5e5e5 solid;}
.cat_pannel .cat_banner .banner-grid-b1{height:321px; border-bottom:1px #e5e5e5 solid;}
.cat_pannel .cat_banner .banner-grid-b2{width:229px;height:160px;}

.cat_pannel .cat_small_banner{width:190px;background:#F2F2F2;overflow:hidden;}
.cat_pannel .cat_small_banner li{height:160px;border-bottom:1px #E5E5E5 solid;position:relative;}

/*当前栏目*/
.cate_nav li.on,.cate_nav li.on a{color:#FFFFFF;}
.cate_nav li.on .cat_0_nav,.grid_col_0{background:#C10000;}
.cate_nav li.on .cat_1_nav,.grid_col_1{background:#CD1B49;}
.cate_nav li.on .cat_2_nav,.grid_col_2{background:#1F94CC;}
.cate_nav li.on .cat_3_nav,.grid_col_3{background:#8A4C8A;}
.cate_nav li.on .cat_4_nav,.grid_col_4{background:#C62173;}
.cate_nav li.on .cat_5_nav,.cate_nav li.on .cat_8_nav,.grid_col_5,.grid_col_8{background:#2766D0;}
.cate_nav li.on .cat_6_nav,.grid_col_6{background:#DF4050;}
.cate_nav li.on .cat_7_nav,.grid_col_7{background:#F36B18;}
.cate_nav li.on .cat_9_nav,.grid_col_9{background:#C93C1B;}
.cate_nav li.on .cat_10_nav,.grid_col_10{background:#BFA588;}
.cate_nav li.on .cat_11_nav,.grid_col_11{background:#7A83A5;}
.cate_nav li.on .cat_12_nav,.grid_col_12{background:#A0AF00;}
.cate_nav li.on .cat_13_nav,.grid_col_13{background:#10B68C;}
.cate_nav li.on .cat_14_nav,.grid_col_14{background:#6DA43D;}
.cate_nav li.on .cat_15_nav,.grid_col_15{background:#0090B0;}
</style>
<script type="text/javascript">
    $(function () {
        // 获取需要修正的高度
        function getOffsetHeight(object) {
            // 获取屏幕的可视高度
            var clientHeight = $(window).height();
            // 当前滚动条高度
            var scrollTop = $(document).scrollTop();
            // 当前元素滚动高度
            var obj_top = object.offset().top;

            // 当前元素底部距离滚动高度
            var height = object.outerHeight() + obj_top - scrollTop;
            return clientHeight - height;
        }
        //鼠标划入时
        $('.iten').hover
    (
            function () {
                var children_div = $(this).children('div');

                var t_this = $(this);
                if (t_this.find(".subCategory .subView").text() == "") {
                    t_this.find(".subCategory .subView").html("<img src=\"/Main/Themes/Skin_Default/Images/lodding.gif\" alt=\"加载中...\"/>");
                    var pcategoryId = $(this).find("input[name='hidProductCategoryID']").val();
                    $.get("/Api/Main/V8_2_ProductCategory.ashx?pid=" + pcategoryId + "&type=index_productType&", null, function (data) {
                        if (data != "") {
                            var vdata = eval('(' + data + ')');
                            var xshopComment = new Array();
                            $.each(vdata, function (m, n) { xshopComment.push(setHtml(n)); });
                            t_this.find(".subCategory .subView").html(xshopComment.join(""));
                        }
                    });
                }

                //有子分类时才显示
                children_div.show();
                $(this).addClass('selected');

            },
        //鼠标移除时
            function () {
                var children_div = $(this).children('div');
                children_div.css({
                    top: children_div.data('origin_top')
                });
                children_div.hide();

                $(this).removeClass('selected');
            }

     );
        $('.iten:nth-child(1)').css("margin-top", "0");
    });
    //html标签
    function setHtml(arry) {
        var xhtml = new Array();
        xhtml.push("<ul><li class=\"subItem\">");
        xhtml.push("<h3 class=\"subItem_hd\">");
        xhtml.push("<a href=\"/Search_productlist.aspx?code=" + arry.code + "\" target=\"_blank\">" + arry.name + "</a></h3>");
        xhtml.push("<p class=\"subItem_cat\">");
        $.each(arry.subdata, function (x, y) { xhtml.push("<a href=\"/Search_productlist.aspx?code=" + y.code + "\" target=\"_blank\">" + y.name + "</a>"); });
        xhtml.push("</p></li></ul>");
        return xhtml.join("");
    }
</script>
<script type="text/javascript" src="Main/Themes/Skin_Default/Js/jquery1.42.min.js"></script>
<script type="text/javascript" src="Main/Themes/Skin_Default/Js/jquery.SuperSlide.2.1.1.js"></script>
<div class="mallLeft">
    <div class="categoryn">
        <h2 class="categoryHd">
        </h2>
        <div class="menu">
            <div id="tmall_nav">
                <!--左侧栏目开始-->
                <asp:Repeater ID="RepeaterCategory" runat="server">
                    <ItemTemplate>
                        <div class="tmall_cat_nav fl">
                            <div class="tmall_mod_title">
                                商品服务分类</div>
                            <ul class="cate_nav">
                                <li style='display: <%#Container.ItemIndex>14?"none":"block" %>'>>
                                    <div class="cat_0_nav">
                                        <s class="cat-nav-icon fp-iconfont">&#x3451;</s>
                                        <asp:Image ID="ImageLogo" runat="server" ImageUrl='<%# Eval("logoimg").ToString()%>'
                                            Width="28" Height="16" onerror="javascript:this.src='/ImgUpload/noimg.jpg_25x25.jpg'" />
                                        <a href='<%#ShopUrlOperate.RetUrl("Search_productlist",((DataRowView)Container.DataItem).Row["code"].ToString(),"code")%>'>
                                            <%# Eval("Name")%></a>
                                    </div>
                                    <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID")%>' />
                                    <input type="hidden" name="hidProductCategoryID" value='<%# Eval("ID")%>' />
                                </li>
                            </ul>
                        </div>
                        <!--左侧栏目结束-->
                        <!--右侧内容开始-->
                        <div class="tmall_cat_content fr">
                            <div class="cat_pannel clearfix">
                                <div class="fl cat_detail grid_col_0">
                                    <ul class="cat_label_list market_list clearfix">
                                        <li>
                                            <asp:Repeater ID="RepeaterCategoryTwo" runat="server">
                                                <ItemTemplate>
                                                    <a href='<%#ShopUrlOperate.RetUrl("Search_productlist",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                        <%# Eval("Name")%></a>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </li>
                                    </ul>
                                    <h3 class="cat_label_title">
                                        主题购</h3>
                                    <ul class="cat_label_list">
                                        <li><a href="http://www.datouwang.com/">新衣过年</a></li>
                                        <li class="second_label"><a href="http://www.datouwang.com/">达人说菜</a></li>
                                        <li><a href="http://www.datouwang.com/">科技生活</a></li>
                                        <li class="second_label"><a href="http://www.datouwang.com/">春季备孕</a></li>
                                        <li><a href="http://www.datouwang.com/">安全守护</a></li>
                                        <li class="second_label"><a href="http://www.datouwang.com/">香聚一堂</a></li>
                                    </ul>
                                    <a class="market_banner" href="http://www.datouwang.com/">
                                        <img src="images/0.png" /></a>
                                </div>
                                <div class="fl cat_banner">
                                    <ul class="cat_banner_pic">
                                        <li><a href="http://www.datouwang.com/">
                                            <img src="images/1.jpg" width="459" height="482" /></a></li>
                                        <li><a href="http://www.datouwang.com/">
                                            <img src="images/2.jpg" width="459" height="482" /></a></li>
                                        <li><a href="http://www.datouwang.com/">
                                            <img src="images/3.jpg" width="459" height="482" /></a></li>
                                    </ul>
                                    <a class="prev_pic" href="javascript:void(0)"></a><a class="next_pic" href="javascript:void(0)">
                                    </a>
                                    <div class="num">
                                        <ul>
                                        </ul>
                                    </div>
                                </div>
                                <ul class="fl cat_small_banner">
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="images/21jpg.jpg" width="190" height="160" /></a></li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="images/22.jpg" width="190" height="160" /></a></li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="images/23.jpg" width="190" height="160" /></a></li>
                                </ul>
                            </div>
                        </div>
                        <!--右侧内容结束-->
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <script type="text/javascript">
                $(".cat_banner").hover(function () {
                    $(this).find(".prev_pic,.next_pic").fadeTo("show", 0.2);
                }, function () {
                    $(this).find(".prev_pic,.next_pic").hide();
                })
                $(".prev_pic,.next_pic").hover(function () {
                    $(this).fadeTo("show", 0.5);
                }, function () {
                    $(this).fadeTo("show", 0.2);
                })
                $(".cat_banner").slide({
                    titCell: ".num ul",
                    mainCell: ".cat_banner_pic",
                    effect: "left",
                    prevCell: ".prev_pic",
                    nextCell: ".next_pic",
                    autoPlay: true,
                    interTime: 3000,
                    delayTime: 500,
                    autoPage: true
                });
                $(".cat_small_banner li").hover(function () {
                    $(this).animate({ "left": -5 }, 200);
                }, function () {
                    $(this).animate({ "left": 0 }, 200);
                });
                $(".cat_brand").slide({
                    titCell: ".cat_slide_nav li",
                    mainCell: ".cat_slide_brand",
                    effect: "left",
                    autoPlay: true,
                    interTime: 3000,
                    delayTime: 700
                });
                $("#tmall_nav").slide({
                    titCell: ".cate_nav li",
                    mainCell: ".tmall_cat_content",
                    autoPlay: true,
                    interTime: 7400,
                    delayTime: 0
                });
            </script>
        </div>
        <!-- 代码 结束 -->
    </div>
</div>
