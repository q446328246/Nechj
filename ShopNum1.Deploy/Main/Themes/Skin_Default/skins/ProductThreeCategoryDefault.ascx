<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<script language="javascript" src="js/jquery-1.6.2.min.js" type="text/javascript">
</script>
<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $("#dchild").hide();

        $("#dparent").hover(
			function () {
			    $("#dchild").show();
			    $("#dparent").css("border", "1px solid #C60204");
			},
			function () {
			    $("#dchild").hide();
			    $("#dparent").css("border", "0px solid #e6e6e6");

			}
		);

    });


    function show(element) {
        if (element.parentNode.getElementsByTagName("DIV")[2] != null) {
            element.parentNode.getElementsByTagName("DIV")[2].className = "show";
        }
    }
</script>
<script type="text/javascript">
    function show(element) {
        if (element.parentNode.getElementsByTagName("DIV")[2] != null) {
            element.parentNode.getElementsByTagName("DIV")[2].className = "pop_subcategory pop_subcategory1 show";
        }
    }


    function show1(element) {
        //判断有无数据
        var check = element.getElementsByTagName("input")[1].value;
        if (check == "0")//第三级没有数据 就不显示
        {
            return;
        }

        if (element.parentNode.getElementsByTagName("DIV")[2] != null) {
            element.parentNode.getElementsByTagName("DIV")[2].className = "pop_subcategory pop_subcategory1 show";
        }

    }


    function hidden1(element) {
        if (element.parentNode.getElementsByTagName("DIV")[2] != null) {
            element.parentNode.getElementsByTagName("DIV")[2].className = "pop_subcategory pop_subcategory1 hidden";
        }
        //element.getElementsByTagName("DIV")[1].className = "hidden";
        //document.getElementById("123").style.display = "";
    }

    function show2(element) {


        if (element.parentNode.getElementsByTagName("DIV")[1] != null) {
            element.className = "pop_subcategory pop_subcategory1 show";
            // this.className="pbox_con_hover";
        }
    }

    function hidden2(element) {
        element.className = "pop_subcategory pop_subcategory1 hidden";
    }    
    
    
</script>
<!--三级分类 面板切换-->
<script type="text/javascript">
    $(function () {
        //.mallCategory子 div 前5个 显示 后面都隐藏
        var divmallCategory = $(".mallCategory");

        for (var i = 0; i < divmallCategory.length; i++) {
            $(divmallCategory[i]).children("div:lt(5)").show(); //选取索引小于5的元素
        }
        //初始化隐藏域的值
        $("#hiddenShowID").val("J_AllCategory");

        $(".allthree").toggle(
        function () {
            for (var i = 0; i < divmallCategory.length; i++) {
                $(divmallCategory[i]).children("div").show();
            }

            var hidedenShowID = $("#hiddenShowID").val(); //当前显示的面板ID
            $("#" + hidedenShowID).addClass("categerheight");
        },
        function () {
            for (var i = 0; i < divmallCategory.length; i++) {
                $(divmallCategory[i]).children("div:gt(4)").hide(); //选取索引大于4的元素
            }
            var hidedenShowID = $("#hiddenShowID").val(); //当前显示的面板ID
            $("#" + hidedenShowID).removeClass("categerheight");
        }

    );

    })

    var number = 5;
    function change_option(index) {
        var divmallCategory = $(".mallCategory");
        for (var i = 0; i < divmallCategory.length; i++) {
            $(divmallCategory[i]).children("div:gt(4)").hide(); //选取索引大于4的元素
        }

        for (var i = 1; i <= number; i++) {
            document.getElementById('current' + i).className = '';
            document.getElementById('content' + i).style.display = 'none';
        }
        document.getElementById('current' + index).className = 'selected';
        document.getElementById('content' + index).style.display = 'block';
        var currentid = $("#content" + index).children("div").attr("id");
        $("#hiddenShowID").val(currentid);
    }

</script>
<style type="text/css">
    .hidden
    {
        display: none;
    }
    .show
    {
        display: block;
    }
</style>
<!--三级分类-->
<div class="ThrCategory">
    <div class="tsCategory">
        <ul class="tsCategory_nav">
            <li style="height: 74px;" class="tn1" id="current1" onmouseover="change_option(1)"><a
                class="j_CateNavLink" href='<%#ShopUrlOperate.RetUrl("Search_product")%>'>所有商品<s
                    class="all" id="s1"></s> </a></li>
            <li class="" id="current2" onmouseover="change_option(2)"><a class="j_CateNavLink"
                href='<%#ShopUrlOperate.RetUrl("Search_product")%>'>美容馆<s class="electric" id="s2"></s></a></li>
            <li class="" id="current3" onmouseover="change_option(3)"><a class="j_CateNavLink"
                href='<%#ShopUrlOperate.RetUrl("Search_product")%>'>电器城<s class="beauty" id="s3"></s></a></li>
            <li class="" id="current4" onmouseover="change_option(4)"><a class="j_CateNavLink"
                href='<%#ShopUrlOperate.RetUrl("Search_product")%>'>家装馆<s class="jia" id="s4"></s></a></li>
            <li class="" id="current5" onmouseover="change_option(5)"><a class="j_CateNavLink"
                href='<%#ShopUrlOperate.RetUrl("Search_product")%>'>医药馆<s class="yiyao" id="s5"></s></a></li>
        </ul>
        <div id="divThreeCategory" class="tsCategory_con ">
            <!--一级 所有商品-->
            <div class="mianban" id="content1" style="display: block; background: #8d7f7e;">
                <div id="J_AllCategory" class="mallCategory" style="z-index: 15;">
                    <h2 class="hdBox">
                    </h2>
                    <asp:Repeater ID="RepeaterCategory2" runat="server">
                        <ItemTemplate>
                            <!--二级 所有商品-->
                            <div style="display: none">
                                <div id="Div1" class="J_DirectPromo" onmouseout="hidden1(this)" onmouseover="show1(this)">
                                    <div class="entity">
                                        <ul class="items">
                                            <li class="item J_MenuItem" style="border-bottom: 1px solid #8d7f7e; border-top: 1px solid #8d7f7e;">
                                                <a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                    <h4 style="padding-left: 15px;">
                                                        <%# Eval("Name")%></h4>
                                                </a>
                                                <asp:HiddenField ID="HiddenFieldCategory2" runat="server" Value='<%# Eval("ID")%>' />
                                                <asp:HiddenField ID="HiddenFieldCheck" runat="server" Value='1' />
                                                <p class="item_col">
                                                    <asp:Repeater ID="RepeaterCategory3" runat="server">
                                                        <ItemTemplate>
                                                            <a id="checkA" value="<%# Eval("Name")%>" href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                <%# Eval("Name")%></a>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </p>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <!--三级-->
                                <div id="Div11" class="pop_subcategory pop_subcategory1 hidden" onmouseout="hidden2(this)"
                                    onmouseover="show2(this)">
                                    <div class="shadow">
                                        <div class="module">
                                            <div class="entity_main J_SubViewItem">
                                                <div class="lst_subcategory" style="background: #736867;">
                                                    <asp:Repeater ID="RepeaterCategory33" runat="server">
                                                        <ItemTemplate>
                                                            <dl class="first first-cage">
                                                                <dt><a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                    <span>
                                                                        <%# Eval("Name")%></span></a> </dt>
                                                                <dd>
                                                                    <asp:HiddenField ID="HiddenFieldCategory33" runat="server" Value='<%# Eval("ID")%>' />
                                                                    <asp:Repeater ID="RepeaterCategory4" runat="server" Visible="false">
                                                                        <ItemTemplate>
                                                                            <a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                                <%# Eval("Name")%></a>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </dd>
                                                            </dl>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="allthree">
                    <a>全部分类</a></div>
            </div>
            <!--一级 美容馆-->
            <div class="mianban" id="content2" style="display: none; background: #bd7382;">
                <div id="Div2" class="mallCategory" style="z-index: 15;">
                    <h2 class="hdBox">
                    </h2>
                    <asp:Repeater ID="RepeaterContent2Category2" runat="server">
                        <ItemTemplate>
                            <div style="display: none">
                                <!--二级 美容馆-->
                                <div id="Div3" class="J_DirectPromo" onmouseout="hidden1(this)" onmouseover="show1(this)">
                                    <div class="entity">
                                        <ul class="items">
                                            <li class="item J_MenuItem" style="border-bottom: 1px solid #bd7382; border-top: 1px solid #bd7382;">
                                                <asp:HiddenField ID="HiddenFieldContent2Category2" runat="server" Value='<%#((DataRowView)Container.DataItem).Row["ID"] %>' />
                                                <asp:HiddenField ID="HiddenFieldCheck" runat="server" Value='1' />
                                                <h4 style="padding-left: 15px;">
                                                    <%# Eval("Name")%></h4>
                                                <p class="item_col">
                                                    <asp:Repeater ID="RepeaterContent2Category3" runat="server">
                                                        <ItemTemplate>
                                                            <a id="checkA" value="<%# Eval("Name")%>" href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                <%# Eval("Name")%></a>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </p>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <!--三级-->
                                <div id="Div4" class="pop_subcategory pop_subcategory1 hidden" onmouseout="hidden2(this)"
                                    onmouseover="show2(this)">
                                    <div class="shadow">
                                        <div class="module">
                                            <div class="entity_main J_SubViewItem">
                                                <div class="lst_subcategory" style="background: #bd7382;">
                                                    <asp:Repeater ID="RepeaterContent2Category33" runat="server">
                                                        <ItemTemplate>
                                                            <dl class="first first-cage">
                                                                <dt><a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                    <span>
                                                                        <%# Eval("Name")%></span></a> </dt>
                                                                <dd>
                                                                    <asp:HiddenField ID="HiddenFieldContent2Category33" runat="server" Value='<%# Eval("ID")%>' />
                                                                    <asp:Repeater ID="RepeaterContent2Category4" runat="server" Visible="false">
                                                                        <ItemTemplate>
                                                                            <a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                                <%# Eval("Name")%></a>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </dd>
                                                            </dl>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="allthree">
                    <a>全部分类</a></div>
            </div>
            <!--一级 电器城-->
            <div class="mianban" id="content3" style="display: none; background: #3a4e8a;">
                <div id="Div6" class="mallCategory" style="z-index: 15;">
                    <h2 class="hdBox">
                    </h2>
                    <asp:Repeater ID="RepeaterContent3Category2" runat="server">
                        <ItemTemplate>
                            <div style="display: none">
                                <!--二级 电器城-->
                                <div id="Div5" class="J_DirectPromo" onmouseout="hidden1(this)" onmouseover="show1(this)">
                                    <div class="entity">
                                        <ul class="items">
                                            <li class="item J_MenuItem" style="border-bottom: 1px solid #3a4e8a; border-top: 1px solid #3a4e8a;">
                                                <asp:HiddenField ID="HiddenFieldContent3Category2" runat="server" Value='<%#((DataRowView)Container.DataItem).Row["ID"] %>' />
                                                <asp:HiddenField ID="HiddenFieldCheck" runat="server" Value='1' />
                                                <h4 style="padding-left: 15px;">
                                                    <a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                        <%# Eval("Name")%></a></h4>
                                                <p class="item_col">
                                                    <asp:Repeater ID="RepeaterContent3Category3" runat="server">
                                                        <ItemTemplate>
                                                            <a id="checkA" value="<%# Eval("Name")%>" href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                <%# Eval("Name")%></a>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </p>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <!--三级-->
                                <div id="Div8" class="pop_subcategory pop_subcategory1 hidden" onmouseout="hidden2(this)"
                                    onmouseover="show2(this)">
                                    <div class="shadow">
                                        <div class="module">
                                            <div class="entity_main J_SubViewItem">
                                                <div class="lst_subcategory" style="background: #3a4e8a;">
                                                    <asp:Repeater ID="RepeaterContent3Category33" runat="server">
                                                        <ItemTemplate>
                                                            <dl class="first first-cage">
                                                                <dt><a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                    <span>
                                                                        <%# Eval("Name")%></span></a> </dt>
                                                                <dd>
                                                                    <asp:HiddenField ID="HiddenFieldContent3Category33" runat="server" Value='<%# Eval("ID")%>' />
                                                                    <asp:Repeater ID="RepeaterContent3Category4" runat="server" Visible="false">
                                                                        <ItemTemplate>
                                                                            <a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                                <%# Eval("Name")%></a>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </dd>
                                                            </dl>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="allthree">
                    <a>全部分类</a></div>
            </div>
            <!--一级 家装馆-->
            <div class="mianban" id="content4" style="display: none; background: #735c4a;">
                <div id="Div14" class="mallCategory" style="z-index: 15;">
                    <h2 class="hdBox">
                    </h2>
                    <asp:Repeater ID="RepeaterContent4Category2" runat="server">
                        <ItemTemplate>
                            <div style="display: none">
                                <!--二级 家装馆-->
                                <div id="Div15" class="J_DirectPromo" onmouseout="hidden1(this)" onmouseover="show1(this)">
                                    <div class="entity">
                                        <ul class="items">
                                            <li class="item J_MenuItem" style="border-bottom: 1px solid #735c4a; border-top: 1px solid #735c4a;">
                                                <asp:HiddenField ID="HiddenFieldContent4Category2" runat="server" Value='<%#((DataRowView)Container.DataItem).Row["ID"] %>' />
                                                <asp:HiddenField ID="HiddenFieldCheck" runat="server" Value='1' />
                                                <h4 style="padding-left: 15px;">
                                                    <a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                        <%# Eval("Name")%></a></h4>
                                                <p class="item_col">
                                                    <asp:Repeater ID="RepeaterContent4Category3" runat="server">
                                                        <ItemTemplate>
                                                            <a id="checkA" value="<%# Eval("Name")%>" href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                <%# Eval("Name")%></a>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </p>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <!--三级-->
                                <div id="Div8" class="pop_subcategory pop_subcategory1 hidden" onmouseout="hidden2(this)"
                                    onmouseover="show2(this)">
                                    <div class="shadow">
                                        <div class="module">
                                            <div class="entity_main J_SubViewItem">
                                                <div class="lst_subcategory" style="background: #735c4a;">
                                                    <asp:Repeater ID="RepeaterContent4Category33" runat="server">
                                                        <ItemTemplate>
                                                            <dl class="first first-cage">
                                                                <dt><a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                    <span>
                                                                        <%# Eval("Name")%></span></a> </dt>
                                                                <dd>
                                                                    <asp:HiddenField ID="HiddenFieldContent4Category33" runat="server" Value='<%# Eval("ID")%>' />
                                                                    <asp:Repeater ID="RepeaterContent4Category4" runat="server" Visible="false">
                                                                        <ItemTemplate>
                                                                            <a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                                <%# Eval("Name")%></a>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </dd>
                                                            </dl>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="allthree">
                    <a>全部分类</a></div>
            </div>
            <!--一级 医药馆-->
            <div class="mianban" id="content5" style="display: none; background: #229b8e;">
                <div id="Div7" class="mallCategory" style="z-index: 15;">
                    <h2 class="hdBox">
                    </h2>
                    <asp:Repeater ID="RepeaterContent5Category2" runat="server">
                        <ItemTemplate>
                            <div style="display: none">
                                <!--二级 医药馆-->
                                <div id="Div9" class="J_DirectPromo" onmouseout="hidden1(this)" onmouseover="show1(this)">
                                    <div class="entity">
                                        <ul class="items">
                                            <li class="item J_MenuItem" style="border-bottom: 1px solid #229b8e; border-top: 1px solid #229b8e;">
                                                <asp:HiddenField ID="HiddenFieldContent5Category2" runat="server" Value='<%#((DataRowView)Container.DataItem).Row["ID"] %>' />
                                                <asp:HiddenField ID="HiddenFieldCheck" runat="server" Value='1' />
                                                <h4 style="padding-left: 15px;">
                                                    <a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                        <%# Eval("Name")%></a></h4>
                                                <p class="item_col">
                                                    <asp:Repeater ID="RepeaterContent5Category3" runat="server">
                                                        <ItemTemplate>
                                                            <a id="checkA" value="<%# Eval("Name")%>" href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                <%# Eval("Name")%></a>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </p>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <!--三级-->
                                <div id="Div10" class="pop_subcategory pop_subcategory1 hidden" onmouseout="hidden2(this)"
                                    onmouseover="show2(this)">
                                    <div class="shadow">
                                        <div class="module">
                                            <div class="entity_main J_SubViewItem">
                                                <div class="lst_subcategory" style="background: #229b8e;">
                                                    <asp:Repeater ID="RepeaterContent5Category33" runat="server">
                                                        <ItemTemplate>
                                                            <dl class="first first-cage">
                                                                <dt><a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                    <span>
                                                                        <%# Eval("Name")%></span></a> </dt>
                                                                <dd>
                                                                    <asp:HiddenField ID="HiddenFieldContent5Category33" runat="server" Value='<%# Eval("ID")%>' />
                                                                    <asp:Repeater ID="RepeaterContent5Category4" runat="server" Visible="false">
                                                                        <ItemTemplate>
                                                                            <a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                                <%# Eval("Name")%></a>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </dd>
                                                            </dl>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="allthree">
                    <a>全部分类</a></div>
            </div>
            <!--二级 婚庆礼仪-->
            <div class="mianban" id="content6" style="display: none; background: #fc2c49;">
                <div id="Div22" class="mallCategory" style="z-index: 15;">
                    <h2 class="hdBox">
                    </h2>
                    <asp:Repeater ID="RepeaterContent6Category2" runat="server">
                        <ItemTemplate>
                            <div style="display: none">
                                <!--二级 仿真花-->
                                <div id="Div23" class="J_DirectPromo" onmouseout="hidden1(this)" onmouseover="show1(this)">
                                    <div class="entity">
                                        <ul class="items">
                                            <li class="item J_MenuItem" style="border-bottom: 1px solid #fc2c49; border-top: 1px solid #fc2c49;">
                                                <asp:HiddenField ID="HiddenFieldContent6Category2" runat="server" Value='<%#((DataRowView)Container.DataItem).Row["ID"] %>' />
                                                <asp:HiddenField ID="HiddenFieldCheck" runat="server" Value='1' />
                                                <h4 style="padding-left: 15px;">
                                                    <a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                        <%# Eval("Name")%></a></h4>
                                                <p class="item_col">
                                                    <asp:Repeater ID="RepeaterContent6Category3" runat="server">
                                                        <ItemTemplate>
                                                            <a id="checkA" value="<%# Eval("Name")%>" href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                <%# Eval("Name")%></a>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </p>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <!--三级-->
                                <div id="Div24" class="pop_subcategory pop_subcategory1 hidden" onmouseout="hidden2(this)"
                                    onmouseover="show2(this)">
                                    <div class="shadow">
                                        <div class="module">
                                            <div class="entity_main J_SubViewItem">
                                                <div class="lst_subcategory" style="background: #fc2c49;">
                                                    <asp:Repeater ID="RepeaterContent6Category33" runat="server">
                                                        <ItemTemplate>
                                                            <dl class="first first-cage">
                                                                <dt><a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                    <span>
                                                                        <%# Eval("Name")%></span></a> </dt>
                                                                <dd>
                                                                    <asp:HiddenField ID="HiddenFieldContent6Category33" runat="server" Value='<%#Eval("ID")%>' />
                                                                    <asp:Repeater ID="RepeaterContent6Category4" runat="server" Visible="false">
                                                                        <ItemTemplate>
                                                                            <a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                                <%# Eval("Name")%></a>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </dd>
                                                            </dl>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="allthree">
                    <a>全部分类</a></div>
            </div>
        </div>
    </div>
</div>
<input id="hiddenShowID" type="hidden" value="0" />