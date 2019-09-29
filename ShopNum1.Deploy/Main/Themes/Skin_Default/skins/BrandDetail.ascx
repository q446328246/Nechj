<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript">

    $(function () {
        //下拉框 排序
        $(".comRange").hover(
            function () {
                $(this).children("div").show();
            },
        //鼠标移除时
            function () {
                $(this).children("div").hide();
            }
        );

        //下拉框 所在地
        $(".comArea").hover(
            function () {
                $(this).children("div").show();
            },
        //鼠标移除时
            function () {
                $(this).children("div").hide();
            }
        );

        //大图显示
        $(".showbigImg").hover(
            function () {
                $(this).find("div.areabox").show();
            },
            function () {
                $(this).find("div.areabox").hide();
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
    $(function () {
        //这里就是放页面加载的时候执行的函数。
        var CodeValues = $("#<%=HiddenFieldAddCode.ClientID %>").val(); //url 中的code值
        if (CodeValues == "") {
            var HiddenFieldAdd = $("#<%=HiddenFieldAdd.ClientID %>").val();
            if (HiddenFieldAdd == "-1") {
                spanAddress.innerHTML = "所在地";
            } else {
                spanAddress.innerHTML = HiddenFieldAdd;
            }

        } else {
            var Aobject = document.getElementById("souzaidi-list").getElementsByTagName("a");
            for (var j = 0; j < Aobject.length; j++) {
                var aaa = Aobject[j].getAttribute("value").split(';');

                if (CodeValues == aaa[0]) {
                    Aobject[j].className = "CategoryCode";
                    spanAddress.innerHTML = aaa[1];
                }
            }

        }

    });
  
</script>
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
            error: function (h, s, t) { alert(t) },
            success: function (json) {
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


    $(function () {
        var lodding = "<img  src='/Main/Themes/Skin_Default/Images/lodding.gif'/>";
        //下拉框 所在地
        $(".comArea").hover
    (
        function () {
            //请求数据
            //             if($("#DivCity").html()=="")
            //            {
            //                $("#DivCity").html(lodding);
            //                getCity("2","10",$("#DivCity"));
            //            }
            //            else
            //            {
            //            }
            if ($("#DivProvinces").html() == "") {
                getCity("1", "", $("#DivProvinces"));
            }

            $(this).children("div").show();
        },
        //鼠标移除时
        function () {
            $(this).children("div").hide();
        }
    );

    })
</script>
<asp:Repeater ID="RepeaterData" runat="server">
    <ItemTemplate>
        <div class="brands_shop clearfix">
            <div class="brands_shop_img fl">
                <a href="javascript:void(0)">
                    <img width="164" height="65" src='<%# ((DataRowView)Container.DataItem).Row["Logo"] %>'
                        onerror="javascript:this.src='../../ImgUpload/noImage.gif'" /></a>
            </div>
            <div class="brands_shop_intro fl">
                <p class="brname">
                    <%#((DataRowView)Container.DataItem).Row["Name"]%></p>
                <p>
                    <%#((DataRowView)Container.DataItem).Row["Description"]%></p>
                <p>
                    官方网站：<a href="http://<%#((DataRowView)Container.DataItem).Row["WebSite"].ToString()%>"
                        target="_blank"><%# ((DataRowView)Container.DataItem).Row["WebSite"]%></a></p>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
<div class="pro_area" id="hideProduct" runat="server">
    <!--排序条件-->
    <div class="paixu">
        <span class="paispan" style="display: none;">库存：</span>
        <div class="comArea">
            <b class="comArea-text"><span id="spanAddress">所在地</span></b>
            <div id="souzaidi-list" class="souzaidi-list">
                <div class="citysearch">
                    <a value="000;所有地区" href="<%=ShopUrlOperate.RetUrlForSearch("Search_productlist","000","addcode")%>">
                        所有地区</a>
                </div>
                <div class="citysearch">
                    <asp:TextBox ID="TextBoxCity" runat="server" CssClass="cityborder"></asp:TextBox>
                    <asp:Button ID="ButtonCity" runat="server" Text="确定" CssClass="cityqueding" />
                </div>
                <!--热门城市-->
                <div id="DivCity" class="CityPart">
                </div>
                <!--省-->
                <div id="DivProvinces">
                </div>
            </div>
        </div>
        <span class="paispan">排序：</span>
        <div class="comRange">
            <b class="comRange-text">
                <asp:LinkButton ID="LinkButtonSortStatus" runat="server">默认排序</asp:LinkButton></b>
            <asp:DropDownList ID="DropDownListSort" runat="server" AutoPostBack="true" EnableViewState="true"
                Visible="false">
            </asp:DropDownList>
            <div class="moren-list">
                <asp:LinkButton ID="LinkButtonPriceUp" runat="server" title="价格从低到高"><i class="mr-ico-pu"></i>价格从低到高</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonPriceDown" runat="server" title="价格从高到低"><i class="mr-ico-pd"></i>价格从高到低</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonSalesDown" runat="server" title="按销量从高到低"><i class="mr-ico-msd"></i>销量从高到低</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonCreateTime" runat="server" title="按发布时间排序" Visible="false"><i class="mr-ico-td"></i>按发布时间排序</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonDefault" runat="server" title="恢复默认排序">恢复默认排序</asp:LinkButton>
            </div>
        </div>
        <asp:LinkButton ID="LinkButtonRenqi" runat="server" CssClass="comSort" title="按人气从高到低">
            人气<i id="IRenqi" runat="server" class="comSort-d"></i></asp:LinkButton>
        <asp:LinkButton ID="LinkButtonSales" runat="server" CssClass="comSort" title="按销量从高到低">
            销量<i id="ISales" runat="server" class="comSort-d"></i></asp:LinkButton>
        <asp:LinkButton ID="LinkButtonXinyong" runat="server" CssClass="comSort" title="按信用从高到低">
            信用<i id="IXinyong" runat="server" class="comSort-d"></i></asp:LinkButton>
        <asp:LinkButton ID="LinkButtonPrice" runat="server" CssClass="comSort" title="按价格从低到高">
            价格<i id="IPrice" runat="server" class="comSort-u"></i></asp:LinkButton>
        <div class="comprice">
            <div class="price-box">
                <b class="price-item"><i class="ui-price-plain">¥</i>
                    <asp:TextBox ID="TextBoxStartPrice" runat="server" onkeyup="Show();this.value=this.value.replace(/\D/g,'')"
                        onafterpaste="this.value=this.value.replace(/\D/g,'')" MaxLength="8" CssClass="priceInput"></asp:TextBox>
                </b><i class="price-split"></i><b class="price-item"><i class="ui-price-plain">¥</i>
                    <asp:TextBox ID="TextBoxEndPrice" runat="server" onkeyup="Show();this.value=this.value.replace(/\D/g,'')"
                        onafterpaste="this.value=this.value.replace(/\D/g,'')" MaxLength="8" CssClass="priceInput"></asp:TextBox>
                </b>
            </div>
            <div class="combtn" style="display: none">
                <asp:LinkButton ID="LinkButtonSearch" runat="server" CssClass="qding"></asp:LinkButton>
            </div>
            <div class="clear">
            </div>
        </div>
        <div style="float: right;">
            <asp:LinkButton ID="LinkButtonGrid" runat="server" CssClass="filterType-p" title="大图">大图<i></i></asp:LinkButton>
            <asp:LinkButton ID="LinkButtonList" runat="server" CssClass="filterType-l" title="列表">列表<i></i></asp:LinkButton>
        </div>
        <div class="clear">
        </div>
    </div>
    <!--大图横排列表-->
    <div id="divGrid" runat="server" class="pro_list" style="display: none;">
        <asp:Repeater ID="RepeaterGrid" runat="server" EnableViewState="false">
            <ItemTemplate>
                <div class="product-wrap">
                    <div class="pro_img">
                        <a href="<%#ShopUrlOperate.shopDetailHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString(),"ProductDetail")%>">
                            <img src="<%# Page.ResolveUrl(((DataRowView)Container.DataItem).Row["ThumbImage"].ToString())+"_160x160.jpg"%>"
                                onerror="javascript:this.src='../ImgUpload/noimg.jpg_160x160.jpg'" /></a></div>
                    <div class="pro_name">
                        <a href="<%#ShopUrlOperate.shopDetailHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString(),"ProductDetail")%>"
                            title="<%#((DataRowView)Container.DataItem).Row["Name"].ToString() %>" class="pname">
                            <%#ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Name"].ToString(), 100, "")%>
                        </a>
                    </div>
                    <div class="pro_price">
                        <b>
                            <%#((DataRowView)Container.DataItem).Row["ShopPrice"].ToString() == "0.00" ? "" : "￥" + ((DataRowView)Container.DataItem).Row["ShopPrice"].ToString()%></b>
                        <%#((DataRowView)Container.DataItem).Row["FeeType"].ToString() == "1" ? "商家承担运费" : "买家承担运费"%>
                    </div>
                    <div class="pro_price">
                        <a href="<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["MemloginId"].ToString())%>">
                            <%#ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["shopName"].ToString(), 32, "")%></a>
                        <%#Search_productlist.GetArea(((DataRowView)Container.DataItem).Row["AddressCode"])%>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <!--小图竖排列表-->
    <div id="divList" runat="server" class="area_list">
        <ul>
            <asp:Repeater ID="RepeaterProductShow" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <li>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td width="130" class="showbigImg">
                                    <div class="area_imgs">
                                        <a href="<%#ShopUrlOperate.shopDetailHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString(),"ProductDetail")%>"
                                            class="area_imgs">
                                            <img src='<%# Page.ResolveUrl(((DataRowView)Container.DataItem).Row["ThumbImage"].ToString())+"_100x100.jpg"%>'
                                                onerror="javascript:this.src='../ImgUpload/noimg.jpg_100x100.jpg'" /></a>
                                        <div class="areabox">
                                            <div class="boxsan">
                                            </div>
                                            <div class="boximg">
                                                <img src='<%# Page.ResolveUrl(((DataRowView)Container.DataItem).Row["ThumbImage"].ToString())+"_300x300.jpg"%>'
                                                    onerror="javascript:this.src='../ImgUpload/noimg.jpg_300x300.jpg'" />
                                            </div>
                                        </div>
                                    </div>
                                </td>
                                <td width="260">
                                    <div class="area_name">
                                        <p>
                                            <a href="<%#ShopUrlOperate.shopDetailHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString(),"ProductDetail")%>"
                                                title="<%#((DataRowView)Container.DataItem).Row["Name"].ToString() %>" class="pname">
                                                <%#ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Name"].ToString(), 100, "")%>
                                            </a>
                                        </p>
                                        <p>
                                            <a href="<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["MemloginId"].ToString())%>"
                                                class="pshop">
                                                <%#ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["shopName"].ToString(), 32, "")%></a></p>
                                    </div>
                                </td>
                                <td width="150">
                                    <div class="area_price">
                                        <b>
                                            <%#((DataRowView)Container.DataItem).Row["ShopPrice"].ToString() == "0.00" ? "" : "￥" + ((DataRowView)Container.DataItem).Row["ShopPrice"].ToString()%></b>
                                        <%#((DataRowView)Container.DataItem).Row["FeeType"].ToString() == "1" ? "商家承担运费" : "买家承担运费"%>
                                    </div>
                                </td>
                                <td width="120" align="center">
                                    <span>
                                        <%#Search_productlist.GetArea(((DataRowView)Container.DataItem).Row["AddressCode"])%>
                                    </span>
                                </td>
                                <td>
                                    <div class="guarantee">
                                        <!--店铺担保-->
                                        <asp:HiddenField ID="HiddenFieldMemLoginID" runat="server" Value='<%#((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() %>' />
                                        <asp:Repeater ID="RepeaterShopEnsure" runat="server" EnableViewState="false">
                                            <ItemTemplate>
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Image ID="Image2" runat="server" Height="15" Width="15" ImageUrl='<%#((DataRowView)Container.DataItem).Row["ImagePath"]%>'
                                                                onerror="javascript:this.src='../ImgUpload/noImage.gif'" />
                                                        </td>
                                                        <td>
                                                            <%#((DataRowView)Container.DataItem).Row["name"]%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
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
            <span class="disabled">< </span><span class="current">1</span> <a href="#?page=2">2</a>
            <span class="diandian">...</span> <a href="#?page=200">200</a> <a href="#?page=2">></a>
        </div>
        <!--//分页排序 End-->
        <div class="clear">
        </div>
    </div>
    <!--//分页 End-->
</div>
<asp:HiddenField ID="HiddenFieldAddCode" runat="server" />
<asp:HiddenField ID="HiddenFieldAdd" runat="server" />
<asp:HiddenField ID="HiddenFieldGuid" runat="server" Value="0" />
