<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<!--得到排序状态-->
<script type="text/javascript">

    $(function() {
        //下拉框 排序
        $(".comRange").hover(
            function() {
                $(this).children("div").show();
            },
            //鼠标移除时
            function() {
                $(this).children("div").hide();
            }
        );

        //下拉框 所在地
        $(".comArea").hover(
            function() {
                $(this).children("div").show();
            },
            //鼠标移除时
            function() {
                $(this).children("div").hide();
            }
        );

        //大图显示
        $(".showbigImg").hover(
            function() {
                $(this).children("div.areabox").show();
            },
            function() {
                $(this).children("div.areabox").hide();
            }
        );

    });


    function Show() {
        $(".combtn").show();
    }

    $(document).ready(function () {
        $("div:not([class='combtn'])").click(function () {
            $(".combtn").hide();
        });
    });


    //获得地区 和地区选中样式
    $(function() {
        //这里就是放页面加载的时候执行的函数。
        var CodeValues = $("#<%=HiddenFieldAddCode.ClientID %>").val(); //url 中的code值
        if (CodeValues == "0")//新增
        {
        } else//编辑
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
<!--所在地 省市 模板 1 step -->
<!--所在地 省市 模板 1 step -->
<script type="template" id="templateCity">
<@ for(var i=0;i<data.length;i++){@>
    <a href="<@=data[i]["Url"]@>"
        value="<@=data[i]["NAME"]@>;<@=data[i]["code"]@>"><@=data[i]["SuoName"]@></a>
<@}@>
</script>
<!--获得数据 城市 所在地 2 step-->
<script type="text/javascript">
    //城市 所在地
    function getCity(strLevel, count, divobj) {
        var url = '<%=HttpContext.Current.Request.Url.ToString()%>'; //当前网页的url地址
        var urlCanshu = '<%=HttpContext.Current.Request.Url.Query %>'; //当前网页的url地址参数
        $.ajax({
            cache: false,
            type: "post",
            url: "/PageHander/Main/Address.ashx",
            data: { showcount: count, Level: strLevel, url: url, urlCanshu: urlCanshu, type: "searchcity" },
            error: function(h, s, t) { alert(t) },
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


    $(function() {
        var lodding = "<img  src='/Main/Themes/Skin_Default/Images/lodding.gif'/>";
        //下拉框 所在地
        $(".comArea").hover(
            function() {
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

    });
    function NumTxt_Int(o) {
        $(".combtn").show();
        o.value = o.value.replace(/\D/g, '');
    }
</script>
<style type="text/css">
    .product-wrap
    {
        background: #ffffff;
        border: 1px solid #dddddd;
        width: 221px;
    }
    .pro_img
    {
        width: 190px;
        height: 190px;
    }
    .pro_img a
    {
        border: none;
        width: 190px;
        height: 190px;
        display: block;
        margin-top: 16px;
    }
    .pro_img a:hover
    {
        border: none;
        width: 190px;
        height: 190px;
        display: block;
    }
    .pro_img a img
    {
        width: 190px;
        height: 190px;
    }
    .weixin_bg
    {
        background: #f3f3f3;
        margin-top: 18px;
        padding: 10px;
    }
    .pro_name
    {
        margin: 0;
    }
    .product-wrap
    {
        height: auto;
    }
    .pro_name
    {
        height: 24px;
    }
    .pro_name a
    {
        font-size: 14px;
        font-weight: bold;
        color: #666666;
    }
    .product-wrap-hover
    {
        background: #ffffff;
        border: 1px solid #cd0300;
        color: #ffffff;
    }
    .product-wrap-hover .weixin_bg
    {
        background: #cd0300;
    }
    .product-wrap-hover .pro_name a
    {
        color: #ffffff;
    }
    .product-wrap
    {
        margin-right: 13px;
    }
    .pro_list
    {
        left: 10px;
    }
</style>
<script>
    $(function () {
        $(".product-wrap").hover(

        function () {
            $(this).addClass("product-wrap-hover");
        },
        function () {
            $(this).removeClass("product-wrap-hover");
        }
    )
    });
</script>
<div class="pro_area pro_area1">
    <!--排序条件-->
    <div class="paixu">
        <span class="paispan">所在地：</span>
        <div class="comArea">
            <span id="spanAddress">
                <asp:Label ID="LabelAdress" runat="server" Text="所有地区"></asp:Label></span>
            <div id="souzaidi-list" class="souzaidi-list" style="display: none;">
                <div class="citysearch">
                    <a value="000;所有地区" href="<%=ShopUrlOperate.RetUrlForSearch("WeiXinUserListV82","000","addcode")%>">
                        所有地区</a>
                </div>
                <div class="citysearch" style="display: none">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="cityborder"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" Text="确定" CssClass="cityqueding" />
                </div>
                <!--热门城市-->
                <div id="DivCity" style="border-bottom: 1px dashed #ccc; padding-bottom: 3px; margin-bottom: 3px;">
                </div>
                <!--省-->
                <div id="DivProvinces">
                </div>
            </div>
        </div>
        <span class="paispan">排序：</span>
        <div class="comRange">
            <b class="comRange-text">默认排序</b>
            <div class="moren-list" style="display: none">
                <a href="<%=ShopUrlOperate.RetUrlForSearch("WeiXinUserListV82","clickcount&sort=desc","ordername")%>"
                    title="按人气从高到低"><i class="mr-ico-pu"></i>按人气从高到低</a> <a href="<%=ShopUrlOperate.RetUrlForSearch("WeiXinUserListV82","salenumber&sort=desc","ordername")%>"
                        title="按销量从高到低"><i class="mr-ico-pd"></i>销量从高到低 </a><a href="<%=ShopUrlOperate.RetUrlForSearch("WeiXinUserListV82","shopreputation&sort=desc","ordername")%>"
                            title="按信用从高到低"><i class="mr-ico-sd"></i>按信用从高到低 </a><a href="<%=ShopUrlOperate.RetUrlForSearch("WeiXinUserListV82","orderid&sort=desc","ordername")%>">
                                恢复默认排序</a>
            </div>
        </div>
        <asp:LinkButton ID="LinkButtonRenqi" runat="server" CssClass="comSort" title="按人气从高到低">
            人气<i id="IRenqi" runat="server" class="comSort-d"></i></asp:LinkButton>
        <asp:LinkButton ID="LinkButtonSales" runat="server" CssClass="comSort">
            销量<i id="ISales" runat="server" class="comSort-d"></i></asp:LinkButton>
        <asp:LinkButton ID="LinkButtonXinyong" runat="server" CssClass="comSort">
            信用<i id="IXinyong" runat="server" class="comSort-d"></i></asp:LinkButton>
        <div class="shoprigth">
            微信名称：
            <input type="text" id="tbWeiXinName" runat="server" class="shopinput" />
            <span class="xiant" style="display: none;"></span>公众号：
            <input type="text" id="tbPublicNo" runat="server" class="shopinput" />
            <span class="xiant" style="display: none;"></span>
            <asp:Button ID="ButtonSearch" runat="server" Text="搜索" Class="shopsbtn" />
        </div>
    </div>
    <asp:Panel ID="PanelNoFind" runat="server" Visible="false">
        <p class="nofind_search">
            没有找到符合条件的商品！</p>
    </asp:Panel>
    <!--微信店铺展示-->
    <div class="pro_list">
        <asp:Repeater ID="RepeaterGrid" runat="server">
            <ItemTemplate>
                <div class="product-wrap">
                    <div class="pro_img">
                        <a>
                            <img src="<%# Page.ResolveUrl(((DataRowView)Container.DataItem).Row["TwoDimensionalPic"].ToString())+"_160x160.jpg"%>"
                                onerror="javascript:this.src='../ImgUpload/noimg.jpg_160x160.jpg'" />
                        </a>
                    </div>
                    <div class="weixin_bg">
                        <div class="pro_name">
                            <a title="<%#((DataRowView)Container.DataItem).Row["WeiXinName"].ToString() %>">微信名称：<%#ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["WeiXinName"].ToString(), 100, "")%>
                            </a>
                        </div>
                        <div class="pro_name">
                            <a title="<%#((DataRowView)Container.DataItem).Row["PublicNo"].ToString() %>">公众号：<%#ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["PublicNo"].ToString(), 100, "")%>
                            </a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="clear">
        </div>
    </div>
    <!--分页 Start-->
    <div class="fenye">
        <!--分页跳转 Start-->
        <div class="page_skip">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        <span class="fenye1">共</span>
                    </td>
                    <td>
                        <span>
                            <asp:Label ID="LabelPageCount" runat="server" Text=""></asp:Label></span>
                    </td>
                    <td>
                        <span class="fenye2">页，到第</span>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxIndex" runat="server" CssClass="page_input">
                        </asp:TextBox>
                    </td>
                    <td>
                        <span class="fenye3">页</span>
                    </td>
                    <td>
                        <asp:Button ID="ButtonSure" runat="server" Text="Button" CssClass="page_btn" />
                    </td>
                </tr>
            </table>
        </div>
        <!--//分页跳转 End-->
        <!--分页排序 Start-->
        <div id="pageDiv" runat="server" class="page_sort">
        </div>
        <!--//分页排序 End-->
        <div class="clear">
        </div>
    </div>
    <!--//分页 End-->
</div>
<asp:HiddenField ID="HiddenFieldAddCode" runat="server" />
<asp:HiddenField ID="HiddenFieldOrdername" runat="server" />
<asp:HiddenField ID="HiddenFieldOrdeState" runat="server" />
