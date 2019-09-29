<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data" %>
<style type="text/css">
    .hua_city
    {
        width: 1000px;
        margin-top: 10px;
    }
    .flw_city_head
    {
        border-bottom: 1px solid #DCDCDC;
        font-size: 14px;
        padding: 10px 0;
        width: 1000px;
    }
    .select_city
    {
        color: #000000;
        font-weight: bold;
        height: 25px;
        line-height: 25px;
        text-align: left;
        width: 1000px;
    }
    .select_city .selected
    {
        margin-right: 5px;
        vertical-align: middle;
        width: 120px;
    }
    .select_city .cityinto
    {
        height: 23px;
        vertical-align: middle;
        width: 75px;
        cursor: pointer;
    }
    .hua_city_txt
    {
        float: left;
        margin-top: 20px;
        padding-bottom: 10px;
        width: 1000px;
    }
    .hua_city_txt strong
    {
        background: url(  "Themes/Skin_Default/Images/txt_bg.png" ) no-repeat center bottom;
        color: #FFFFFF;
        float: left;
        font-size: 14px;
        height: 34px;
    }
    .hua_city_txt strong span
    {
        background: none repeat #C00000;
        display: inline-block;
        height: 30px;
        line-height: 30px;
        padding: 0 10px;
        text-align: center;
    }
    .hua_city_con
    {
        float: left;
        font-size: 13px;
        width: 920px;
        color: #000;
    }
    .hua_city_con dt
    {
        color: #CC0000;
        float: left;
        font-family: "微软雅黑";
        font-size: 18px;
        text-align: center;
        text-transform: uppercase;
        width: 40px;
    }
    .hua_city_con dt span
    {
        display: inline-block;
        width: 30px;
    }
    .hua_city_con dd
    {
        float: left;
        width: 960px;
    }
    .hua_city_con dd a
    {
        color: #333333;
        float: left;
        margin-right: 10px;
        white-space: nowrap;
    }
    .hua_city_con .cluetip
    {
        width: 180px;
        position: absolute;
        z-index: 97;
        margin-left: -80px;
        _margin-left: -130px;
        _margin-top: 10px;
    }
    * + html .hua_city_con .cluetip
    {
        margin-left: -130px;
        margin-top: 10px;
    }
    .hua_city_con .cluetip .city
    {
        height: auto;
        background: url("Themes/Skin_Default/Images/lmf_ditu5.png" ) repeat-y center center;
        padding: 6px 10px 6px 14px;
    }
    .hua_city_con .cluetip .city ul
    {
        overflow: hidden;
    }
    .hua_city_con .cluetip .city ul li
    {
        white-space: nowrap;
    }
    .hua_city_con .cluetip .city ul li a
    {
        white-space: nowrap;
        margin: 4px;
        color: #333333;
        font-size: 13px;
    }
    .hua_city_con .cluetip .city a:hover
    {
        color: #bf0000;
    }
    .hua_city_con .cluetip_arrows
    {
        width: 205px;
        height: 20px;
        background: url("Themes/Skin_Default/Images/lmf_ditu4.png" ) no-repeat center center;
    }
    .hua_city_con .cluetip
    {
        width: 205px;
    }
    .hua_city_con .cluetip_arrows1
    {
        width: 205px;
        height: 12px;
        background: url("Themes/Skin_Default/Images/lmf_ditu6.png" ) no-repeat center top;
    }
    .hua_city_con .cluetip .city ul li
    {
        float: left;
    }
    .cityod
    {
        float: left;
        margin-right: 10px;
    }
    .qbu
    {
        display: inline-block;
        font-weight: bold;
        font-size: 13px;
        padding-right: 20px;
        float: left;
    }
</style>
<script type="text/javascript">

    $(function () {
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

        //下拉框 所在地
        $(".comArea").hover
    (
        function () {
            $(this).children("div").show();
        },
        //鼠标移除时
        function () {
            $(this).children("div").hide();
        }
    );

    })


    //获得地区 和地区选中样式
    $(function () {
        //这里就是放页面加载的时候执行的函数。
        var CodeValues = $("#<%=HiddenFieldAddCode.ClientID %>").val(); //url 中的code值
        if (CodeValues == "") {
            //            var HiddenFieldAdd=$("#<%=HiddenFieldAdd.ClientID %>").val() ;
            //            if(HiddenFieldAdd=="-1")
            //            {
            //                spanAddress.innerHTML="所在地";
            //            }
            //            else
            //            {
            //                spanAddress.innerHTML="所在地";
            //            }

        }
        else {
            var Aobject = document.getElementById("souzaidi-list").getElementsByTagName("a");
            for (var j = 0; j < Aobject.length; j++) {
                var aaa = Aobject[j].getAttribute("value").split(';');

                if (CodeValues == aaa[0]) {
                    Aobject[j].className = "CategoryCode";
                    spanAddress.innerHTML = aaa[1];
                }
            }

        }

    })



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
                }
                else {
                }
            }
        })
    }


    $(function () {
        var lodding = "<img  src='/Main/Themes/Skin_Default/Images/lodding.gif'/>";
        //下拉框 所在地
        $(".comArea").hover
    (
        function () {
            //请求数据
            $("#DivCity").html(lodding);
            getCity("2", "10", $("#DivCity"));

            getCity("1", "", $("#DivProvinces"));


            $(this).children("div").show();
        },
        //鼠标移除时
        function () {
            $(this).children("div").hide();
        }
    );

    })
</script>
<script type="text/javascript">
    var lodding = "<img  src='/Main/Themes/Skin_Default/Images/lodding.gif'/>";


    $(document).ready
(
    function () {

        $(".cityod").hover
        (

            function () {

                var e = this;
                var cityid = $(this).attr("cityid"); //市
                var cityul = $("#city" + cityid + "");
                var _cityul = $("#_city" + cityid + "");
                $(this).children("div").removeClass("hidden");
                //_cityul.html(lodding); 
                //获取对应的市
                $.ajax
                         ({
                             type: "GET",
                             async: true,
                             url: "/PageHander/Main/SupplyCategory.ashx",
                             data: "cityid=" + cityid + "&type=Search",
                             success: function (result) {
                                 alert(result);
                                 if (result != "") {
                                     cityul.html(result); _cityul.html("");
                                     $(this).children("div").addClass("cluetip  clearfix");

                                 }
                                 else {
                                     cityul.html("无数据"); _cityul.html("无数据");
                                 }

                             }
                         });
            },
        //鼠标移除时
            function () {
                $(this).children("div").addClass("hidden");
            }
        )
    })

</script>
<!-- 供求分类-->
<div class="CategoryArea" style="display: none">
    <div class="att_key">
        类别：</div>
    <div class="CategoryAreaList">
        <span class="qbu">全部</span>
        <asp:Repeater ID="RepeaterSupplyCategory" runat="server">
            <ItemTemplate>
                <div class="cityod" js="addshowevent" id="cityod" cityid='<%#Eval("Code")%>'>
                    <a href='<%#ShopUrlOperate.RetUrl("SupplyDemandListSearch",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                        <%#((DataRowView)Container.DataItem).Row["Name"] %></a>
                    <!--二级-->
                    <div id="city_area" js="addhideevent" class="cluetip hidden">
                        <div class="cluetip_arrows">
                        </div>
                        <div class="city">
                            <ul id="city<%# Eval("Code")%>">
                            </ul>
                            <ul id="_city<%# Eval("Code")%>" style="text-align: center">
                            </ul>
                        </div>
                        <div class="cluetip_arrows1">
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="clear">
    </div>
</div>
<!-- 搜索结果 -->
<div class="SearchResultsArea">
    <!--排序-->
    <div class="paixu">
        <div class="att_key">
            全部信息</div>
        <div class="fr">
            <span class="paispan">地区：</span>
            <div class="comArea">
                <b class="comArea-text"><span id="spanAddress">
                    <asp:Label ID="LabelAdress" runat="server" Text="所在地"></asp:Label></span></b>
                <div id="souzaidi-list" class="souzaidi-list souzaidi-list1" style="display: none;">
                    <div class="citysearch">
                        <a value="000;所有地区" href="<%=ShopUrlOperate.RetUrlForSearch("Search_productlist","000","addcode")%>">
                            所有地区</a>
                    </div>
                    <div class="citysearch" style="display: none">
                        <asp:TextBox ID="TextBoxCity" runat="server" CssClass="cityborder"></asp:TextBox>
                        <asp:Button ID="ButtonCity" runat="server" Text="确定" CssClass="cityqueding" />
                    </div>
                    <!--热门城市-->
                    <div id="DivCity" style="border-bottom: 1px dashed #ccc; padding-bottom: 3px; margin-bottom: 3px;">
                    </div>
                    <!--省-->
                    <div id="DivProvinces">
                    </div>
                </div>
            </div>
            <%--   <span class="paispan">排序：</span>
            <div class="comRange">
                <b class="comRange-text">
                    <asp:LinkButton ID="LinkButtonSortStatus" runat="server">默认排序</asp:LinkButton></b>
                <div class="moren-list" style="display: none;">
                    <asp:LinkButton ID="LinkButtonPriceUp" runat="server" title="价格从低到高"><i class="mr-ico-pu"></i>价格从低到高</asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonPriceDown" runat="server" title="价格从高到低"><i class="mr-ico-pd"></i>价格从高到低</asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonSalesDown" runat="server" title="按销量从高到低"><i class="mr-ico-msd"></i>销量从高到低</asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonCreateTime" runat="server" title="按发布时间排序" Visible="false"><i class="mr-ico-td"></i>按发布时间排序</asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonDefault" runat="server" title="恢复默认排序">恢复默认排序</asp:LinkButton>
                </div>
            </div>--%>
            <%--<a href="#" class="comSort" title="按月销量从高到低">时间<i class="comSort-d"></i></a>--%>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="SearchResultsList">
        <asp:Repeater ID="RepeaterData" runat="server" Visible="true" EnableViewState="true">
            <ItemTemplate>
                <div class="SearchResultsList_detail clearfix">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td width="500">
                                <div class="gongqiupics fl">
                                    <a href='<%# ShopUrlOperate.RetUrl("SupplyDemandDetail",((DataRowView)Container.DataItem).Row["ID"]) %>'
                                        target="_blank">
                                        <asp:Image ID="Image1" Width="90" Height="90" runat="server" ImageUrl='<%#((DataRowView)Container.DataItem).Row["Image"]%>'
                                            onerror="javascript:this.src='../ImgUpload/noImage.gif'" /></a>
                                </div>
                                <div class="describe fl">
                                    <p class="title">
                                        <a href='<%# ShopUrlOperate.RetUrl("SupplyDemandDetail",((DataRowView)Container.DataItem).Row["ID"]) %>'
                                            target="_blank">
                                            <%# ((DataRowView)Container.DataItem).Row["Title"]%>
                                        </a>
                                    </p>
                                    <p class="introduction">
                                        <%#ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Description"].ToString(),200,"...")%>
                                    </p>
                                    <p class="promulgator">
                                        发布者：<b><%# ((DataRowView)Container.DataItem).Row["MemberID"]%></b> <span class="gongqiutime">
                                            <%# Convert.ToDateTime(((DataRowView)Container.DataItem).Row["ReleaseTime"]).ToString("yyyy-MM-dd")%></span>
                                    </p>
                                </div>
                            </td>
                            <td valign="middle">
                                <p class="local">
                                    <%# ((DataRowView)Container.DataItem).Row["AddressValue"]%>
                                </p>
                            </td>
                            <td valign="middle" width="145">
                                <div class="commentKey">
                                    <a href='<%# ShopUrlOperate.RetUrl("SupplyDemandDetail",((DataRowView)Container.DataItem).Row["ID"]) %>'
                                        target="_blank">我要点评</a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
        </asp:Panel>
        <%if (RepeaterData.Items.Count == 0)
          { %>
        <p class="nofind_search">
            没有查询到符合条件的供求信息！</p>
        <%} %>
    </div>
    <div class="clear">
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
