<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<script language="javascript" type="text/javascript">
    var lodding = "<div class=\"tag_sx\"></div><div class=\"tag_sxl\"><img  src='/Main/Themes/Skin_Default/Images/lodding.gif'/></div>";
    $(document).ready(function () {
        var inputIshave = $(".buxingfu>input");

        for (var i = 0; i < inputIshave.length; i++) {
            if ($(inputIshave[i]).val() == "0") {
                $(inputIshave[i]).parent(".buxingfu").addClass("testeee");
            }
        }

        $(".test").hover(
			function () {

			    //判断是否有2级
			    var ishave = $(this).find("div.buxingfu>input").val();
			    if (ishave == "0") {
			        //没有2级
			        return;
			    }
			    $(this).children("div").show();
			    $(this).addClass("cate-active");
			    //ajax请求
			    var id = $(this).attr("id"); //1级分类id
			    var DivRightTwo = $("#DivTwo" + id + "");
			    if (DivRightTwo.html() == "" || DivRightTwo.val()=="") {
			        DivRightTwo.html(lodding);
			        //获取对应的2级和3级分类
			        $.ajax
                     ({
                         type: "GET",
                         async: true,
                         url: "/Api/ProductCategory.ashx",
                         data: "id=" + id + "&type=getproductcategory",
                         success: function (result) {
                             if (result != "") {
                                 DivRightTwo.html(result);
                                 $(this).children("div").show();

                             }
                             else {
                                 DivRightTwo.html("");
                             }
                         }
                     });

			    }

			},
			function () {
			    var id = $(this).attr("id"); //1级分类id
			    var DivRightTwo = $("#DivTwo" + id + "");
			    $(DivRightTwo).hide();
			    $(this).removeClass("cate-active");
			}
		);


    });
	
</script>
<!--三级分类-->
<div class="allcategroy">
    <h5>
        全部分类</h5>
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <div class="test" id="<%# ((DataRowView)Container.DataItem).Row["ID"] %>">
                <div class="xingfu">
                    <span class="namespan fl"><a href='<%# ShopUrlOperate.RetUrl("Search_productlist",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>&category=<%= Page.Request.Cookies["category"]==null?"1":(Page.Request.Cookies["category"].Value=="1"?"1":"9") %>'>
                        <%# ((DataRowView)Container.DataItem).Row["Name"]%></a></span> <span class="dtspan">
                            &gt;</span>
                </div>
                <asp:HiddenField ID="HiddenFieldCID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
                <div class="buxingfu">
                    <asp:HiddenField ID="HiddenFieldIsHaveCategory" runat="server" />
                    <asp:Repeater ID="RepeaterChild" runat="server">
                        <ItemTemplate>
                            <a href='<%# ShopUrlOperate.RetUrl("Search_productlist",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>&category=<%= Page.Request.Cookies["category"]==null?"1":(Page.Request.Cookies["category"].Value=="1"?"1":"9") %>'>
                                <%# ((DataRowView)Container.DataItem).Row["Name"]%></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="tag_list" id="DivTwo<%# ((DataRowView)Container.DataItem).Row["ID"] %>"
                    style="z-index: 9999">
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
