<%@ Import Namespace="ShopNum1.Common" %>
<script src="Js/jquery-1.6.2.min.js" type="text/javascript"></script>
<!--��ҳ�����л�JS-->
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
    //��ҳ�����л�JS
    function chang(value) {
        for (var i = 1; i <= 4; i++) {
            document.getElementById("hh" + i).className = "";
        }
        document.getElementById("HiddenSwitchType").value = value;
        document.getElementById("hh" + value).className = "cur";
        //�л������Զ���ʾ
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
            //��Ʒ����
            var a = '<%=GetPageName.RetUrlcenter("Search_productlist",Category)%>' + "&search=" + name + "&pv=" + type;
            location.href = a;
        }
        else if (type == "2" || c_type == "2") {
            if (c_type == "2") {
                var key = $(c_name).html();
                name = escape(key);
            }
            //��������
            var a = '<%=GetPageName.RetUrl("ShopListSearch")%>' + "?search=" + name + "&pv=" + type;
            location.href = a;

        }
        else if (type == "3") {
            //��������
            var a = '<%=GetPageName.RetUrl("ArticleListSearch")%>' + "?search=" + name + "&pv=" + type;
            location.href = a;
        }
        else if (type == "4") {
            //��������
            var a = '<%=GetPageName.RetUrl("SupplyDemandListSearch")%>' + "?search=" + name + "&pv=" + type;
            location.href = a;
        }
    }
</script>
<!--�в�����-->
<style type="text/css">
    .browse
    {
        border: 1px solid #8c0000;
        padding: 4px;
        width: 250px;
        position: relative;
        z-index: 9999;
        left: -177px;
    }
    .jiathis_style_32x32
    {
        position: relative;
        z-index: 9999;
    }
    #ckepop .button, #ckepop .jiathis_txt
    {
        font-size: 14px;
        line-height: 30px !important;
    }
</style>
<script type="text/javascript">
    $(document).ready(function () {
        //��ѯͷ�� ѡ����ʽ�仯 start
        var tag = '<%= Page.Request.QueryString["tag"]==null?"-1":Page.Request.QueryString["tag"].ToString() %>';
        var a = $("div .mallNav_main ul li"); //�в����� Ԫ�� a �ļ���
        for (var i = 1; i < a.length; i++) {
            $(a[i]).attr("class", "");

        }
        $(a[tag]).attr("class", "select");
        //��ѯͷ�� ѡ����ʽ�仯 end

        $(".ll_all_search").hide();

        $("div:not([class='ll_all_search'])").click(function () {
            $(".ll_all_search").hide();
        });

    });

    //�����Զ���ʾ
    function showHint(str) {
        var var_tag; //��ʶ
        var var_data; //��������

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
            //���л������ı�ǩ
            var changetag = "<p class=\"ll_p\" onclick=\"chang(1)\"><a >������" + str + "�� <span>��Ʒ</span></a></p>";
            changetag += "<p class=\"ll_p\" onclick=\"chang(2)\"><a >������" + str + "�� <span>����</span></a></p>";

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
                            $(".ll_xiala").html("<div style=\"line-height:2\">û��������������������</div>");
                        }
                        //�л����ࣨ���ص�ǰ��ǩ����ʾ������
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
<!--head Start ͷ����ʼ-->
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
        <div id="header">
            <div class="headerCon">
                <!--ͷ��Logo Start-->
                <h1 id="mallLogo">
                    <ShopNum1:Logo ID="Logo" runat="server" SkinFilename="Logo.ascx" />
                </h1>
                <!--//ͷ��Logo End-->
                <!--ͷ������ Start-->
                <div class="topsearch">
                    <%--<ShopNum1:TopSearch ID="TopSearch" runat="server" SkinFilename="TopSearch.ascx" />--%>
                    <div class="mallSearch" id="mallSearch">
                        <%--                        <div class="switchover">
                            <ul>
                                <li><a id="hh1" class="cur" onclick="chang(1)">����</a> </li>
                                <li><a id="hh2" class="" onclick="chang(2)">����</a> </li>
                                <li><a id="hh3" class="" onclick="chang(3)">��Ѷ</a> </li>
                                <li><a id="hh4" class="" onclick="chang(4)">����</a> </li>
                            </ul>
                        </div>--%>
                        <div class="FormBox">
                            <div class="mallSearch_input clearfix">
                                <label for="mq">
                                </label>
                                <input class="txtinput" type="text" name="textfield" id="textfield" maxlength="50"
                                    onkeyup="showHint(this.value)" autocomplete="off" accesskey="s" autocomplete="off"
                                    autofocus="true" x-webkit-speech="" x-webkit-grammar="builtin:search" />
                                <input id="ButtonSearch" type="button" class="search_buttom" onclick="javascript:test(0,'')"
                                    value="" />
                            </div>
                        </div>
                    </div>
                    <asp:hiddenfield id="HiddenSwitchType" runat="server" value="1" />
                    <!--��������-->
                    <div class="KeyWords clearfix">
                        <ShopNum1:KeyWords ID="keyWords" runat="server" SkinFilename="KeyWords.ascx" />
                    </div>
                </div>
                <!--//ͷ������ End-->
                <!--ͷ����ϵ��ʽ-->
                <div class="tel">
                    <img src="Themes/Skin_Default/images/weixin.png" />
                    <img src="Themes/Skin_Default/images/tel.png" />
                </div>
            </div>
        </div>
    </div>
    <!--//mallHome End-->
</div>
<!--//site End-->
<!--������������ Start-->
<div class="ny_headcate">
    <div class="ThrCategory_fwr">
        <div id="FlowCate">
        </div>
        <div class="FlowCategory_main" id="ThrCategory">
            <ShopNum1:ProductThreeCategoryDefault ID="ProductThreeCategory11" runat="server"
                FlowerID="3" SimulationID="4" CartoonID="5" CakeID="6" PlantsID="7" WeddingID="8"
                SkinFilename="ProductFwThreeCategory.ascx" />
        </div>
    </div>
</div>
<!--//������������ End-->
<!--�в����� Start-->
<div id="mallNav">
    <div class="mallNav_con">
        <div id="mallTextNav" class="clearfix">
            <div class="mallNav_main nall_hid">
                <ul>
                    <li><a href="<%=ShopUrlOperate.RetUrl("Default","0","tag") %>">��ҳ</a></li>
                    <li><a href="<%=ShopUrlOperate.RetMultiUrl("ArticleListSearch","tag=1&guid=154&Category=�����Ż�ȯ") %>">
                        �����Ż�ȯ</a></li>
                    <li><a href="<%=ShopUrlOperate.RetMultiUrl("ArticleListSearch","tag=2&guid=106&Category=��������") %>">
                        ��������</a></li>
                    <li><a href="<%=ShopUrlOperate.RetMultiUrl("ArticleListSearch","tag=3&guid=103&Category=�����") %>">
                        �����</a></li>
                    <li><a href="<%=ShopUrlOperate.RetMultiUrl("ArticleListSearch","tag=4&guid=100&Category=����̳�") %>">
                        ����̳�</a></li>
                    <li><a href="<%=ShopUrlOperate.RetMultiUrl("ArticleListSearch","tag=5&guid=97&Category=�̳Ǵ���") %>">
                        �̳Ǵ���</a></li>
                </ul>
            </div>
        </div>
    </div>
</div>
<!--//�в����� End-->
<!--//head End ͷ������-->
<!--[if lte IE 6]>
<script src="Themes/Skin_Default/Js/DD_belatedPNG_0.0.8a.js" type="text/javascript"></script>
    <script type="text/javascript">
        DD_belatedPNG.fix('div, ul, img, li, input , a, *');
    </script>
<![endif]-->
