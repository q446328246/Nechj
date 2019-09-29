<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<!--得到排序状态-->
<script type="text/javascript">

    $(function() {
        //下拉框 排序
        $(".comRange").hover
        (
            function() {
                $(this).children("div").show();
            },
            //鼠标移除时
            function() {
                $(this).children("div").hide();
            }
        );
        var lodding = "<img  src='/Main/Themes/Skin_Default/Images/lodding.gif'/>";
        //下拉框 所在地
        $(".comArea").hover
        (
            function() {
                //请求数据
                if ($("#DivCity").html() == "") {
                    $("#DivCity").html(lodding);
                    getCity("2", "10", $("#DivCity"));
                } else {
                }
                if ($("#DivProvinces").html() == "") {
                    getCity("1", "", $("#DivProvinces"));
                }

                $(this).children("div").show();
            },
            //鼠标移除时
            function() {
                $(this).children("div").hide();
            }
        );

        //大图显示
        $(".showbigImg").hover
        (
            function() {
                $(this).children("div").show();
            },
            function() {
                $(this).children("div").hide();
            }
        );

        //店铺动态评分
        $(".plun").hover
        (
            function() {
                $(this).children("div").show();
            },
            function() {
                $(this).children("div").hide();
            }
        );
    });
    $(document).ready(function () {
        $("div:not([class='combtn'])").click(function () {
            $(".combtn").hide();
        });
    });

    //获得地区 和地区选中样式
    $(function() {
        //这里就是放页面加载的时候执行的函数。
        var CodeValues = $("#<%=HiddenFieldAddCode.ClientID %>").val(); //url 中的code值
        if (CodeValues == "0") //新增
        {
        } else //编辑
        {
            var Aobject = document.getElementById("souzaidi-list").getElementsByTagName("a");
            for (var j = 0; j < Aobject.length; j++) {
                var aaa = Aobject[j].getAttribute("value").split(';');

                if (CodeValues == aaa[0]) {
                    Aobject[j].className = "CategoryCode";
                    spanAddress.innerHTML = aaa[1];
                }
            }
        }
        //得到排序状态
        var OrdeState = $("#ShopListSearch1_ctl00_HiddenFieldOrdeState").val();
        $(".comRange-text").html(OrdeState);
    });

</script>

<!--相关商品 左右滚动效果-->

<script language="javascript" type="text/javascript">

    $(document).ready(function () {

        var input = $("[class='HiddenFieldIndex']"); //初始化所有 当前页面 隐藏域
        for (var i = 0; i < input.length; i++) {
            $(input[i]).val("1");
        }

        var tes = $(".RelatedProduct_jquery");
        for (var i = 0; i < tes.length; i++) {
            $(tes[i]).children(":eq(0)").children().hide();
            $(tes[i]).children(":eq(0)").children(":eq(0)").show();
        }
        $(".releft").click(function () {
            ProductRelatedLeftClick(this);

        });

        $(".rerigth").click(function () {
            ProductRelatedRightClick(this);
        });

    });
    function ProductRelatedLeftClick(obj) {
        var divobj = $(".reconts");
        //var divobj=$(obj).parent().next().next().next();//要更新的模板 div
        var shopid = $(obj).parent().parent().parent().prev().val();
        // alert(shopid+"|"+$("#HiddenFieldRelatedProduct").val());
        var pageIndex = $(obj).parent().next(); //当前页面的隐藏域
        //alert($(".HiddenFieldIndex").val()+"|"+$(pageIndex).val());
        var pagecount = $(pageIndex).next().val(); //总页码数字
        var pageSum = Math.ceil(parseInt(pagecount) / 4); //总页码数字
        if ($(pageIndex).val() <= 1) {
            $(pageIndex).val("1"); alert("已经是第一页！");
        }
        else {
            if ($(pageIndex).val() >= pageSum) {
                $(pageIndex).val(pageSum);
            }
            $(pageIndex).val(parseInt($(pageIndex).val()) - 1);
            getbill(divobj, shopid, $(pageIndex).val(), "4"); //请求数据
        }

    }
    function ProductRelatedRightClick(obj) {
        var divobj = $(".reconts");
        //var divobj=$(obj).parent().prev();//要更新的模板 div
        var shopid = $(obj).parent().parent().parent().prev().val();
        //alert(shopid+"|"+$("#HiddenFieldRelatedProduct").val());
        var pageIndex = $(obj).parent().prev().prev().prev(); //当前页面的隐藏域
        //alert($(".HiddenFieldIndex").val()+"|"+$(pageIndex).val());
        var pagecount = $(pageIndex).next().val(); //总页码数字
        var pageSum = Math.ceil(parseInt(pagecount) / 4); //总页码数字
        if ($(pageIndex).val() <= 1) {
            $(pageIndex).val("1");
        }
        if ($(pageIndex).val() >= pageSum) {
            $(pageIndex).val(pageSum); alert("已经是最后一页！");
        }
        else {
            $(pageIndex).val(parseInt($(pageIndex).val()) + 1);
            getbill(divobj, shopid, $(pageIndex).val(), "4"); //请求数据

        }
    }
</script>
<!--相关商品 ajax请求数据-->
<script language="javascript" type="text/javascript">
    function showXiangguan(obj) {
        $(obj).parent().parent().parent().parent().parent().next().next().toggleClass("relatedBaby"); //  添加/删除类交替进行
    }
    var lodding = "<img  src='/Main/Themes/Skin_Default/Images/lodding.gif'/>";
    $(document).ready(function () {
        $(".taob").click(
			function () {
			    var divrelatedBaby = $(this).parent().parent().parent().parent().parent().next().next(); //div控制显示隐藏的
			    if ($(this).attr("value") == "0")//马上显示
			    {
			        //显示
			        var divReconts = $(this).parent().parent().parent().parent().parent().next().next().children("div.rebpros").children("div.reconts");
			        var shopid = $(this).parent().parent().parent().parent().parent().next().val(); //得到隐藏域HiddenFieldRelatedProduct 值 会员id
			        //开始请求数据
			        $(divrelatedBaby).show(); //div显示
			        divReconts.html(lodding);
			        //看看有没有数据 得到记录总数
			        $.ajax
                         ({
                             type: "GET",
                             async: true,
                             url: "/PageHander/Main/ShopProducts.ashx",
                             data: "shopid=" + shopid + "&type=shopproductcount",
                             success: function (result) {
                                 if (result != "")//有数据
                                 {
                                     getbill(divReconts, shopid, "1", "4"); //请求数据
                                     $(divrelatedBaby).show(); //div显示
                                     $(divrelatedBaby).children().children("input:eq(1)").val(result); //记录总共页数

                                 }
                                 else {
                                     $(divrelatedBaby).hide(); //div隐藏
                                 }
                             }
                         });
			        $(this).attr("value", "1");
			        return;
			    }
			    if ($(this).attr("value") == "1")//隐藏没有效果
			    {
			        $(divrelatedBaby).hide();
			        $(this).attr("value", "0");
			    }
			}
		);
    });
	
</script>

<div class="shop_conts clearfix">
    <div class="paixu">
        <span class="paispan">所在地：</span>
        <div class="comArea">
            <span id="spanAddress"><asp:Label ID="LabelAdress" runat="server" Text="所有地区"></asp:Label></span>
            <div id="souzaidi-list" class="souzaidi-list" style="display: none;">
                <div class="citysearch">
                    <a value="000;所有地区" href="<%=ShopUrlOperate.RetUrlForSearch("ShopListSearch","000","addcode")%>">
                        所有地区</a>
                </div>
                <div class="citysearch" style=" display:none">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="cityborder"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" Text="确定" CssClass="cityqueding" />
                </div>
                <!--热门城市-->
                <div id="DivCity" style="border-bottom: 1px dashed #ccc; padding-bottom: 3px; margin-bottom: 3px;"></div>
                <!--省-->
                <div id="DivProvinces"></div>
            </div>
        </div>
        <span class="paispan">排序：</span>
        <div class="comRange">
            <b class="comRange-text">默认排序</b>
            <div class="moren-list" style="display: none">
                <a href="<%=ShopUrlOperate.RetUrlForSearch("ShopListSearch","clickcount&sort=desc","ordername")%>"
                    title="按人气从高到低"><i class="mr-ico-pu"></i>按人气从高到低</a> <a href="<%=ShopUrlOperate.RetUrlForSearch("ShopListSearch","ordersum&sort=desc","ordername")%>"
                        title="按销量从高到低"><i class="mr-ico-pd"></i>销量从高到低 </a><a href="<%=ShopUrlOperate.RetUrlForSearch("ShopListSearch","shopreputation&sort=desc","ordername")%>"
                            title="按信用从高到低"><i class="mr-ico-sd"></i>按信用从高到低 </a><a href="<%=ShopUrlOperate.RetUrlForSearch("ShopListSearch","orderid&sort=desc","ordername")%>">
                                恢复默认排序</a>
            </div>
        </div>
        
        <asp:LinkButton ID="LinkButtonRenqi" runat="server" CssClass="comSort" title="按人气从高到低">人气<i id="IRenqi" runat="server"  class="comSort-d"></i></asp:LinkButton>
        <asp:LinkButton ID="LinkButtonSales" runat="server" CssClass="comSort">销量<i id="ISales" runat="server"  class="comSort-d"></i></asp:LinkButton>
        <asp:LinkButton ID="LinkButtonXinyong" runat="server" CssClass="comSort">信用<i id="IXinyong" runat="server" class="comSort-d"></i></asp:LinkButton>
        <div class="shoprigth">
            店铺名称：
            <asp:TextBox ID="TextBoxShopname" runat="server" CssClass="shopinput"></asp:TextBox>
            <span class="xiant" style="display: none;"></span>会员名称：
            <asp:TextBox ID="TextBoxMember" runat="server" CssClass="shopinput"></asp:TextBox>
            <span class="xiant" style="display: none;"></span>
            <asp:Button ID="ButtonSearch" runat="server" Text="搜索" CssClass="shopsbtn" />
        </div>
    </div>
    <asp:Panel ID="PanelNoFind" runat="server" Visible="false">
        <p class="nofind_search">
            没有找到符合条件的店铺！
        </p>
    </asp:Panel>
    <!--搜索结果-->
    <div class="shoplists">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <div class="shopdateil clearfix">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" value="<%#Container.ItemIndex+1%>">
                        <tr value="2">
                            <td width="500">
                                <div class="shoppics">
                                    <a href="<%#ShopUrlOperate.GetShopUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString())%>?category=9">
                                        <asp:Image Visible="true" ID="Image1" runat="server" Width="70" Height="70" Style="" ImageUrl='<%#((DataRowView)Container.DataItem).Row["banner"]%>'
                                            onerror="javascript:this.src='/ImgUpload/noImage.gif'" />
                                    </a>
                                </div>
                                <div class="shopmiaoshu">
                                    <div class="shopname">
                                        <a href="<%#ShopUrlOperate.GetShopUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString())%>?category=9">
                                            <%#((DataRowView)Container.DataItem).Row["ShopName"]%></a></div>
                                    <p class="shopsales">
                                        主营宝贝：<a><%#((DataRowView)Container.DataItem).Row["MainGoods"]%></a></p>
                                    <div class="shopkeeper">
                                        店主：<b><%#((DataRowView)Container.DataItem).Row["Name"]%></b> <span class="keepericon">
                                            <!--店铺担保-->
                                            <asp:HiddenField ID="HiddenFieldMemLoginID" runat="server" Value='<%#((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() %>' />
                                            <asp:Repeater ID="RepeaterShopEnsure" runat="server" EnableViewState="false">
                                                <ItemTemplate>
                                                    <asp:Image ID="Image2" runat="server" Height="15" Width="15" ImageUrl='<%#((DataRowView)Container.DataItem).Row["ImagePath"]%>'
                                                        onerror="javascript:this.src='../ImgUpload/noImage.gif'" />
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </span>
                                    </div>
                                </div>
                            </td>
                            <td width="200">
                                <div class="salesdateil" value="1">
                                    <p>
                                        共<b><%#((DataRowView)Container.DataItem).Row["ProductNum"]%></b>件宝贝</p>
                                    <p>
                                        最近成交<b><%#((DataRowView)Container.DataItem).Row["ordersum"]%></b>单</p>
                                    <p class="taob" value="0">
                                        <a>查看相关宝贝</a></p>
                                </div>
                            </td>
                            <td valign="middle" align="center" width="250">
                                <div class="cityname">
                                    <%#ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["AddressValue"].ToString(), 6, "")%></div>
                            </td>
                            <td valign="top">
                                <div class="shopcomments">
                                    <div class="commentsimgs" style="background: none; padding: 0; height: 20px;">
                                        <asp:Image ID="ImageProduct" runat="server" Height="15" Style="" ImageUrl='<%#((DataRowView)Container.DataItem).Row["mrankpic"].ToString()%>' />
                                    </div>
                                    <p style="padding-left: 0;">
                                        好评率： <%#Math.Round(Convert.ToDouble(((DataRowView)Container.DataItem).Row["HaoPingLV"].ToString().Replace("-","")),2) * 100%>%</p>
                                    <div class="plun" style="">
                                        <b>店铺动态评分</b>
                                        <div class="shopcoms" style="display: none; z-index: 1111111; zoom: 1;">
                                            <div class="spsan">
                                            </div>
                                            <div class="shopplun">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="shoptable">
                                                    <tr>
                                                        <td>
                                                            <strong style="color:Black;">店铺动态评分</strong>
                                                        </td>
                                                        <td>
                                                             <strong style="color:Black;">与同行业相比</strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            描述相符：<b><%#((DataRowView)Container.DataItem).Row["ShopCharacter"].ToString() == string.Empty ? "暂无评论" : ((DataRowView)Container.DataItem).Row["ShopCharacter"]%></b>
                                                        </td>
                                                        <td>
                                                            <%#Convert.ToDouble(((DataRowView)Container.DataItem).Row["CharacterBL"]) >= 0  ? "<div class=\"gaoyu\"><span class=\"over\">高于</span>" : "<div class=\"diyu\"><span class=\"down\">低于</span>"%>
                                                              <%#Math.Round(Convert.ToDouble(((DataRowView)Container.DataItem).Row["CharacterBL"].ToString().Replace("-","")),2) * 100%>%</div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            服务态度：<b><%#((DataRowView)Container.DataItem).Row["ShopAttitude"].ToString() == string.Empty ? "暂无评论" : ((DataRowView)Container.DataItem).Row["ShopAttitude"]%></b>
                                                        </td>
                                                        <td>
                                                            <%#Convert.ToDouble(((DataRowView)Container.DataItem).Row["AttitudeBL"]) >= 0 ? "<div class=\"gaoyu\"><span class=\"over\">高于</span>" : "<div class=\"diyu\"><span class=\"down\">低于</span>"%>
                                                            <%#Math.Round(Convert.ToDouble(((DataRowView)Container.DataItem).Row["AttitudeBL"].ToString().Replace("-","")),2) * 100%>%</div>
                                                        </td> 
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            发货速度：<b><%#((DataRowView)Container.DataItem).Row["ShopSpeed"].ToString() == string.Empty ? "暂无评论" : ((DataRowView)Container.DataItem).Row["ShopSpeed"]%></b>
                                                        </td>
                                                        <td>
                                                            <%#Convert.ToDouble(((DataRowView)Container.DataItem).Row["SpeedBL"]) >= 0  ? "<div class=\"gaoyu\"><span class=\"over\">高于</span>" : "<div class=\"diyu\"><span class=\"down\">低于</span>"%>
                                                            <%#Math.Round(Convert.ToDouble(((DataRowView)Container.DataItem).Row["SpeedBL"].ToString().Replace("-","")),2) * 100%>%</div>
                                                        </td>
                                                    </tr>
                                                </table> 
                                            </div> 
                                        </div> 
                                    </div> 
                                </div> 
                            </td> 
                        </tr> 
                    </table>
                    <asp:HiddenField ID="HiddenFieldRelatedProduct" runat="server" Value='<%# Eval("MemLoginID")%>' />
                    <!--相关商品-->
                    <div class="relatedBaby" id="divXiangguan">
                        <div class="rbxian">
                        </div>
                        <div class="rebpros">
                            <a>
                                <div class="releft">
                                </div>
                            </a>
                            <input id="HiddenFieldIndex" type="hidden" class="HiddenFieldIndex" value='1' />
                            <asp:HiddenField ID="HiddenFieldCount" runat="server" Value='0' />
                            <!--divReconts-->
                            <div class="reconts" style="width: 800px; left: 20px;">
                            </div>
                            <a>
                                <div class="rerigth" style="float: right;">
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <!--分页 Start-->
    <div class="fenye">
        <!--分页跳转 Start-->
        <div class="page_skip">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td><span class="fenye1">共</span></td>
                    <td><span><asp:Label ID="LabelPageCount" runat="server" Text=""></asp:Label></span></td>
                    <td><span class="fenye2">页，到第</span></td>
                    <td>
                        <asp:TextBox ID="TextBoxIndex" runat="server" CssClass="page_input">
                        </asp:TextBox>
                    </td>
                    <td><span class="fenye3">页</span></td>
                    <td>
                        <asp:Button ID="ButtonSure" runat="server" Text="Button" CssClass="page_btn" />
                    </td>
                </tr>
            </table>
        </div>
        <!--//分页跳转 End-->
        
        <!--分页排序 Start-->
        <div id="pageDiv" runat="server" class="page_sort">
            <span class="disabled">< </span>
            <span class="current">1</span> 
            <a href="#?page=2">2</a>
            <span class="diandian">...</span> 
            <a href="#?page=200">200</a> 
            <a href="#?page=2">></a>
        </div>
        <!--//分页排序 End-->
        <div class="clear"></div>
    </div>
    <!--//分页 End-->
</div>
<asp:HiddenField ID="HiddenFieldAddCode" runat="server" />
<asp:HiddenField ID="HiddenFieldOrdername" runat="server" />
<asp:HiddenField ID="HiddenFieldOrdeState" runat="server" />
<!--百度模板引擎 获得相关商品 js-->

<script type="template" id="Script1">
<table cellspacing="0" border="0" style="width: 100%; border-collapse: collapse;"
    class="RelatedProduct_jquery" id="ShopListSearch1_ctl00_RepeaterData_ctl00_DataListRelatedProduct">
    <tbody>
        <tr style="display: table-row;">
            <td>
            <@ for(var i=0;i<data.length;i++){@>
                <li>
                    <div class="repics">
                        <a href="<@=data[i]["ProductDetailUrl"]@>">
                            <img style="height: 160px; width: 160px; border-width: 0px;" src="<@=data[i]["ThumbImage"].replace("~","")@>" onerror="javascript:this.src='/ImgUpload/noImage.gif'"></a>
                    </div>
                    <p class="rename">
                        <a title="1312" target="_blank" href="<@=data[i]["ProductDetailUrl"]@>">
                        
                            <@=data[i]["NAME"]@></a></p>
                    <p class="reprice">
                        ￥<i><@=data[i]["ShopPrice"]@></i>最近成交<@=data[i]["SaleNumber"]@>笔</p>
                </li>
                <@}@>
            </td>
        </tr>
    </tbody>
</table>
</script>

<!--所在地 省市 模板 1 step -->

<script type="template" id="templateCity">
<@ for(var i=0;i<data.length;i++){@>
    <a href="<@=data[i]["Url"]@>"
        value="<@=data[i]["NAME"]@>;<@=data[i]["code"]@>"><@=data[i]["SuoName"]@></a>
<@}@>
</script>

<!--获得数据 2 step-->

<script type="text/javascript">
    //获得数据 相关商品
    function getbill(divobj, shopid, pageindex, pagesize) {
        $.ajax({
            cache: false,
            type: "post",
            url: "/PageHander/Main/ShopProducts.ashx",
            data: { shopid: shopid, pageindex: pageindex, pagesize: pagesize, type: "shopproduct" },
            error: function(h, s, t) { alert(t); },
            success: function(json) {
                if (json) {
                    var data = {};

                    data.data = json;
                    var bt = baidu.template;
                    bt.ESCAPE = false;
                    var resutlt = bt("Script1", data);

                    $(divobj).html(resutlt);
                } else {
                }
            }
        });
    }


    //城市 所在地
    function getCity(strLevel, count, divobj) {
        var url = '<%=HttpContext.Current.Request.Url.ToString()%>'; //当前网页的url地址
        var urlCanshu = '<%=HttpContext.Current.Request.Url.Query %>'; //当前网页的url地址参数

        $.ajax({
            cache: false,
            type: "post",
            url: "/PageHander/Main/Address.ashx",
            data: { showcount: count, Level: strLevel, url: url, urlCanshu: urlCanshu, type: "searchcity" },
            error: function(h, s, t) { alert(t); },
            success: function(json) {
                if (json) {
                    var data = {};
                    data.data = json;
                    var bt = baidu.template;
                    bt.ESCAPE = false;
                    var resutlt = bt("templateCity", data);
                    $(divobj).html(resutlt);
                } else {
                }
            }
        });
    }



</script>

