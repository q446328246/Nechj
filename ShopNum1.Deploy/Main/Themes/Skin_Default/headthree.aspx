
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
        for (var i = 1; i <= 5; i++) {
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
            var a = '<%=GetPageName.RetUrl("CategoryListSearch")%>' + "?search=" + name + "&pv=" + type;
            location.href = a;
        }
        else if (type == "5") {
            //��������
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
        <div id="header" class="treehead">
            <div class="headerCon">
                <!--ͷ��Logo Start-->
                <h1 id="mallLogo">
                    <img height="74" width="407" src="Themes/Skin_Default/Images/logo.jpg" />
                </h1>
                <!--//ͷ��Logo End-->
                <!--ͷ������ Start-->
                <div class="topsearch">
                    <div class="mallSearch" id="mallSearch">
                        <div class="switchover">
                            <ul>
                                <li><a id="hh1" class="cur" onclick="chang(1)">����</a> </li>
                                <li><a id="hh2" class="" onclick="chang(2)">����</a> </li>
                                <li><a id="hh3" class="" onclick="chang(3)">��Ѷ</a> </li>
                                <li><a id="hh4" class="" onclick="chang(4)">����</a> </li>
                                <li><a id="hh5" class="" onclick="chang(5)">����</a> </li>
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
                    <!--��������-->
                    <div class="KeyWords clearfix">
                        <ShopNum1:KeyWords ID="keyWords" runat="server" SkinFilename="KeyWords.ascx" />
                    </div>
                </div>
                <!--//ͷ������ End-->
            </div>
        </div>
    </div>
    <!--//mallHome End-->
</div>
<!--//site End-->
<!--//head End ͷ������-->
<!--[if lte IE 6]>
<script src="Themes/Skin_Default/Js/DD_belatedPNG_0.0.8a.js" type="text/javascript"></script>
    <script type="text/javascript">
        DD_belatedPNG.fix('div, ul, img, li, input , a, *');
    </script>
<![endif]-->
