<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<script type="text/javascript">
    $(function () {
        // 获取需要修正的高度
        function getOffsetHeight(object) {
            // 获取屏幕的可视高度
            var clientHeight = $(window).height();
            // 当前滚动条高度
            var scrollTop = $(document).scrollTop();
            // 当前元素滚动高度
            var obj_top = object.offset().top;

            // 当前元素底部距离滚动高度
            var height = object.outerHeight() + obj_top - scrollTop;
            return clientHeight - height;
        }
        //鼠标划入时
        $('.iten').hover
    (
            function () {
                var children_div = $(this).children('div');

                //获取子分类个数
                var len = children_div.find('li').length;

                //没有子分类时不显示
                if (len <= 0) {
                    return false;
                }
                //有子分类时才显示
                children_div.show();

                // 先保存原始高度，用于隐藏后进行还原
                children_div.data('origin_top', children_div.css('top'));

                // 注意必须要元素显示以后在调用此函数，否则获取不到元素的相对顶部的偏移高度
                var offsetHeight = getOffsetHeight(children_div);

                // 只有高度超过的才需要修正
                if (offsetHeight < 0) {
                    children_div.css({
                        position: 'absolute',
                        top: offsetHeight
                    });
                }
                $(this).addClass('selected');

            },
        //鼠标移除时
            function () {
                var children_div = $(this).children('div');
                children_div.css({
                    top: children_div.data('origin_top')
                })
                children_div.hide();

                $(this).removeClass('selected');
            }

     );
        $('.iten:nth-child(1)').css("margin-top", "0");
    })
</script>
<div class="mallLeft">
    <div class="categoryn">
        <h2 class="categoryHd">
        </h2>
        <div class="menu">
            <ul>
                <asp:Repeater ID="RepeaterCategory" runat="server">
                    <ItemTemplate>
                        <li class="iten itenone" style='display: <%#Container.ItemIndex>5?"none":"block" %>'>
                            <h3 class="item_hd item_hd1">
                                <asp:Image ID="ImageLogo" runat="server" ImageUrl='<%# Eval("logoimg").ToString()%>'
                                    Width="28" Height="16" onerror="javascript:this.src='/ImgUpload/noimg.jpg_25x25.jpg'" />
                                <a href='<%#ShopUrlOperate.RetUrl("Search_productlist",((DataRowView)Container.DataItem).Row["code"].ToString(),"code")%>'>
                                    <%# Eval("Name")%></a>
                            </h3>
                            <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID")%>' />
                            <p class="itemCol1 item_col">
                                <asp:Repeater ID="RepeaterCategoryTwo" runat="server">
                                    <ItemTemplate>
                                        <a href='<%#ShopUrlOperate.RetUrl("Search_productlist",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                            <%# Eval("Name")%></a>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </p>
                            <div class="subCategory">
                                <div class="subView">
                                    <asp:DataList ID="DataListCategoryRight" runat="server" RepeatDirection="Horizontal"
                                        RepeatColumns="3" RepeatLayout="Flow">
                                        <ItemTemplate>
                                            <ul>
                                                <li class="subItem">
                                                    <h3 class="subItem_hd">
                                                        <a href='<%#ShopUrlOperate.RetUrl("Search_productlist",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                            <%# Eval("Name")%></a>
                                                    </h3>
                                                    <p class="subItem_cat">
                                                        <asp:HiddenField ID="HiddenFieldCategoryTwoID" runat="server" Value='<%#Eval("ID")%>' />
                                                        <asp:Repeater ID="RepeaterCategoryThree" runat="server">
                                                            <ItemTemplate>
                                                                <a href='<%#ShopUrlOperate.RetUrl("Search_productlist",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                    <%# Eval("Name")%></a>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </p>
                                                </li>
                                            </ul>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                            </div>
                        </li>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <li class="iten itentwo" style='display: <%#Container.ItemIndex>5?"none":"block" %>'>
                            <h3 class="item_hd item_hd2">
                                <asp:Image ID="ImageLogo" runat="server" ImageUrl='<%# Eval("logoimg")%>' Width="28"
                                    Height="16" onerror="javascript:this.src='/ImgUpload/noimg.jpg_25x25.jpg'" />
                                <a href='<%#ShopUrlOperate.RetUrl("Search_productlist",((DataRowView)Container.DataItem).Row["code"].ToString(),"code")%>'>
                                    <%# Eval("Name")%></a>
                            </h3>
                            <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID")%>' />
                            <p class="itemCol1 item_col">
                                <asp:Repeater ID="RepeaterCategoryTwo" runat="server">
                                    <ItemTemplate>
                                        <a href='<%#ShopUrlOperate.RetUrl("Search_productlist",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                            <%# Eval("Name")%></a>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </p>
                            <div class="subCategory">
                                <div class="subView">
                                    <asp:DataList ID="DataListCategoryRight" runat="server" RepeatDirection="Horizontal"
                                        RepeatColumns="3" RepeatLayout="Flow">
                                        <ItemTemplate>
                                            <ul>
                                                <li class="subItem">
                                                    <h3 class="subItem_hd">
                                                        <a href='<%#ShopUrlOperate.RetUrl("Search_productlist",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                            <%# Eval("Name")%></a>
                                                    </h3>
                                                    <p class="subItem_cat">
                                                        <asp:HiddenField ID="HiddenFieldCategoryTwoID" runat="server" Value='<%#Eval("ID")%>' />
                                                        <asp:Repeater ID="RepeaterCategoryThree" runat="server">
                                                            <ItemTemplate>
                                                                <a href='<%#ShopUrlOperate.RetUrl("Search_productlist",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                    <%# Eval("Name")%></a>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </p>
                                                </li>
                                            </ul>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                            </div>
                        </li>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
</div>
