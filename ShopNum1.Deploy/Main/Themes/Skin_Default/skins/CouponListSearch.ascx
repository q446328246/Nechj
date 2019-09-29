<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript">

    $(function () {
        //下拉框 排序
        $(".comCatetory").hover
    (
        function () {
            $(this).children("div").show();
        },
        //鼠标移除时
        function () {
            $(this).children("div").hide();
        }
    );


        //下拉框 排序
        $(".comRange").hover
    (
        function () {
            $(this).children("div").show();
        },
        //鼠标移除时
        function () {
            $(this).children("div").hide();
        }
    );

        //得到分类状态
        var catename = '<%=Page.Request.QueryString["catename"]==null?"全部":Page.Request.QueryString["catename"].ToString() %>';
        $(".comArea-text").html(catename);
        //得到排序状态
        var OrdeState = $("#CouponListSearch_ctl00_HiddenFieldOrdeState").val();
        $(".comRange-text").html(OrdeState);

        var lodding = "<img  src='/Main/Themes/Skin_Default/Images/lodding.gif'/>";
        //下拉框 所在地
        $(".comArea").hover
    (
        function () {
            //请求数据
            if ($("#DivCity").html() == "") {
                $("#DivCity").html(lodding);
                getCity("2", "10", $("#DivCity"));
            }
            else {
            }
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
<div class="precont">
    <div class="paixu hyfenl">
        <div class="dzyhq fl">
            优惠券</div>
        <div class="fr">
            <span class="paispan">所在地：</span>
            <%--  <div class="comArea">
                <span id="spanAddress"></span>
                <div id="souzaidi-list" class="souzaidi-list" style="display: none;">
                    <div class="citysearch">
                        <a value="000;所有地区" href="<%=ShopUrlOperate.RetUrlForSearch("ShopListSearch","000","addcode")%>">
                            所有地区</a>
                    </div>
                    <div class="citysearch">
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
            </div>--%>
            <div class="LocationBox fl">
                <span class="LocationList">
                    <asp:DropDownList ID="DropDownListRegionCode1" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownListRegionCode2" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownListRegionCode3" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                </span>
            </div>
            <span class="paispan">分类：</span>
            <div class="comArea">
                <b class="comArea-text">-全部-</b>
                <div class="souzaidi-list" style="display: none;">
                    <p>
                        <a href='<%= ShopUrlOperate.RetUrl("CouponsList","-1&catename=全部","category")%>'>全部</a></p>
                    <asp:Repeater ID="RepeaterCategory" runat="server">
                        <ItemTemplate>
                            <a href='<%# ShopUrlOperate.RetUrl("CouponsList",((DataRowView)Container.DataItem).Row["id"].ToString()+"&catename="+((DataRowView)Container.DataItem).Row["Name"].ToString(),"category")%>'
                                title='<%#Eval("Name")%>'>
                                <%#Eval("Name").ToString().Length > 6 ? Eval("Name").ToString().Substring(0, 6) : Eval("Name").ToString()%></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <span class="paispan" style="display: none">排序：</span>
            <div class="comRange" style="display: none">
                <b class="comRange-text">默认排序</b>
                <div class="moren-list" style="display: none;">
                    <a href="<%=ShopUrlOperate.RetUrlForSearch("CouponsList","browsercount&sdesc=asc","order")%>">
                        <i class="mr-ico-pu"></i>人气从低到高</a> <a href="<%=ShopUrlOperate.RetUrlForSearch("CouponsList","browsercount&sdesc=desc","order")%>">
                            <i class="mr-ico-pd"></i>人气从高到低</a> <a href="<%=ShopUrlOperate.RetUrlForSearch("CouponsList","createtime&sdesc=desc","order")%>">
                                恢复默认排序</a>
                </div>
            </div>
            <asp:LinkButton ID="LinkButtonRenqi" runat="server" CssClass="comSort">
                人气<i id="IRenqi" runat="server" class="comSort-d"></i>
            </asp:LinkButton>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="preshow preshow1 clearfix">
        <!--优惠劵列表-->
        <div style="_width: 100%;">
            <ul>
                <asp:Repeater ID="RepeaterData" runat="server">
                    <ItemTemplate>
                        <li>
                            <div class="prelist">
                                <a href='<%# ShopUrlOperate.shopDetailHrefByShopID(Eval("Guid").ToString(),Eval("shopID").ToString(),"Coupon") %>'
                                    class="preimgs">
                                    <img id="ImgCoupon" runat="server" src="" width="175" height="111" /></a>
                                <div class="prename">
                                    <a href='<%# ShopUrlOperate.shopDetailHrefByShopID(Eval("Guid").ToString(),Eval("shopID").ToString(),"Coupon") %>'>
                                        <%#Eval("CouponName").ToString().Length > 10 ? Eval("CouponName").ToString().Substring(0, 10) : Eval("CouponName").ToString()%></a></div>
                                <p>
                                    人气：<b><%#((DataRowView)Container.DataItem).Row["BrowserCount"]%></b></p>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Panel ID="PanelNofind" runat="server" Visible="false">
                    <div class="nofind">
                        <div class="nohead">
                            <span class="nopic"></span>抱歉，没有找到相关的优惠券哦！</div>
                    </div>
                </asp:Panel>
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
</div>
<asp:HiddenField ID="HiddenFieldCategory" runat="server" />
<asp:HiddenField ID="HiddenFieldOrdername" runat="server" />
<asp:HiddenField ID="HiddenFieldOrdeState" runat="server" />
<asp:HiddenField ID="HiddenFieldRegionCode" runat="server" />
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
            error: function(h, s, t) { alert(t) },
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

</script>
