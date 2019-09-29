
<%@ Import Namespace="ShopNum1.Common" %>
<script src="Js/jquery-1.6.2.min.js" type="text/javascript"></script>
<!--首页搜索切换JS-->
<%
        string Category = "1";
        if ( Page.Request.QueryString["category"]!="")
      {
          Category = Page.Request.QueryString["category"];
          if(Category!="9")
          {
          Category="1";
          }
      }
        else if(Page.Request.Cookies["category"] !=null)
        {
            Category = Page.Request.Cookies["category"].Value;
            if(Category!="9")
          {
          Category="1";
          }
        }
        
         %>
<script type="text/javascript" language="javascript">
    //首页搜索切换JS
    function chang(value) {
        for (var i = 1; i <= 5; i++) {
            document.getElementById("hh" + i).className = "";
        }
        document.getElementById("HiddenSwitchType").value = value;
        document.getElementById("hh" + value).className = "cur";
        //切换搜索自动提示
        showHint($("#textfield").val());
    }

    function test(c_type, c_name) {
        var type = $("#HiddenSwitchType").val();
        var name = escape($("#textfield").val());
        if (type == "1" || c_type == "1") {
            if (c_type == "1") {
                var key = $(c_name).html();
                name = escape(key);
            }
            //商品搜索
            var a = '<%=GetPageName.RetUrlcenter("Search_productlist",Category)%>' + "&search=" + name + "&pv=" + type;
            location.href = a;
        }
        else if (type == "2" || c_type == "2") {
            if (c_type == "2") {
                var key = $(c_name).html();
                name = escape(key);
            }
            //店铺搜索
            var a = '<%=GetPageName.RetUrl("ShopListSearch")%>' + "?search=" + name + "&pv=" + type;
            location.href = a;

        }
        else if (type == "3") {
            //文章搜索
            var a = '<%=GetPageName.RetUrl("ArticleListSearch")%>' + "?search=" + name + "&pv=" + type;
            location.href = a;
        }
        else if (type == "4") {
            //分类搜索
            var a = '<%=GetPageName.RetUrl("CategoryListSearch")%>' + "?search=" + name + "&pv=" + type;
            location.href = a;
        }
        else if (type == "5") {
            //供求搜索
            var a = '<%=GetPageName.RetUrl("SupplyDemandListSearch")%>' + "?search=" + name + "&pv=" + type;
            location.href = a;
        }
    }
  
  
			
  
</script>
<script type="text/javascript">
    $(document).ready(function () {
        $(".ll_all_search").hide();

        $("div:not([class='ll_all_search'])").click(function () {
            $(".ll_all_search").hide();
        });

    });

    //搜索自动提示
    function showHint(str) {
        var var_tag; //标识
        var var_data; //请求数据

        if ($("#mallSearch .switchover #hh1").attr("class") == "cur") {
            var_tag = "0";
            var_data = "type=searchproduct&keyword=" + str + "";
        }
        if ($("#mallSearch .switchover #hh2").attr("class") == "cur") {
            var_tag = "1";
            var_data = "type=searchshop&keyword=" + str + "";
        }

        if (str != "") {
            $(".ll_all_search").show();
            //绑定切换搜索的标签
            var changetag = "<p class=\"ll_p\" onclick=\"chang(1)\"><a >搜索“" + str + "” <span>商品</span></a></p>";
            changetag += "<p class=\"ll_p\" onclick=\"chang(2)\"><a >搜索“" + str + "” <span>店铺</span></a></p>";

            $.ajax({
                type: "GET",
                async: false,
                url: "/api/AutoSearchName.ashx",
                data: "" + var_data + "",
                success: function (result) {
                    if (result != null) {
                        if (result != "") {
                            $(".ll_xiala").html(result);
                        }
                        else {
                            $(".ll_xiala").html("<div style=\"line-height:2\">没有搜索到符合条件数据</div>");
                        }
                        //切换分类（隐藏当前标签，显示其他）
                        $(".checktag").html(changetag);
                        $(".checktag p").show();
                        $(".ll_all_search p:eq(" + var_tag + ")").hide();
                    }
                    else {
                        $(".ll_all_search").hide();
                    }
                }
            })
        }
        else {
            $(".ll_all_search").hide();
        }
    }
</script>
<!--head Start 头部开始-->
<!--site Start-->
<div id="site">
    <!--site_nav Start-->
    <div id="site_nav">
        <div class="sn_bg">
            <div class=" sn_bg_right">
            </div>
        </div>
        <div class="sn_bd">
            <b class="sn_edge"></b>
            <ShopNum1:WelcomeControl ID="WelcomeControl" runat="server" />
        </div>
    </div>
    <!--//site_nav End-->
    <!--mallHome Start-->
    <div id="mallHome">
        <div id="header" class="treehead">
            <div class="headerCon">
                <!--头部Logo Start-->
                <h1 id="mallLogo">
                    <img height="74" width="407" src="Themes/Skin_Default/Images/logo.jpg" />
                </h1>
                <!--//头部Logo End-->
                <!--头部搜索 Start-->
                <div class="topsearch">
                    <div class="mallSearch" id="mallSearch">
                        <div class="switchover">
                            <ul>
                                <li><a id="hh1" class="cur" onclick="chang(1)">宝贝</a> </li>
                                <li><a id="hh2" class="" onclick="chang(2)">店铺</a> </li>
                                <li><a id="hh3" class="" onclick="chang(3)">资讯</a> </li>
                                <li><a id="hh4" class="" onclick="chang(4)">分类</a> </li>
                                <li><a id="hh5" class="" onclick="chang(5)">供求</a> </li>
                            </ul>
                        </div>
                        <div class="FormBox">
                            <div class="mallSearch_input clearfix">
                                <label for="mq">
                                </label>
                                <input class="txtinput" type="text" name="textfield" id="textfield" maxlength="50"
                                    onkeyup="showHint(this.value)" autocomplete="off" />
                                <input id="ButtonSearch" type="button" class="search_buttom" onclick="javascript:test(0,'')"
                                    value="" />
                            </div>
                        </div>
                    </div>
                    <asp:hiddenfield id="HiddenSwitchType" runat="server" value="1" />
                    <!--热门搜索-->
                    <div class="KeyWords clearfix">
                        <ShopNum1:KeyWords ID="keyWords" runat="server" SkinFilename="KeyWords.ascx" />
                    </div>
                </div>
                <!--//头部搜索 End-->
            </div>
        </div>
    </div>
    <!--//mallHome End-->
</div>
<!--//site End-->
<!--//head End 头部结束-->
<!--[if lte IE 6]>
<script src="Themes/Skin_Default/Js/DD_belatedPNG_0.0.8a.js" type="text/javascript"></script>
    <script type="text/javascript">
        DD_belatedPNG.fix('div, ul, img, li, input , a, *');
    </script>
<![endif]-->
