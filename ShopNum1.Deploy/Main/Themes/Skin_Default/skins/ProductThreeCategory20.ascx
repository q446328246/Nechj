<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<script language="javascript" src="js/jquery-1.6.2.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        //鼠标划入时
        $('.iten').hover
    (
            function () {
                $(this).children('div').show();

                $(this).addClass('selected');

            },
        //鼠标移除时
            function () {
                $(this).children('div').hide();
                $(this).removeClass('selected');
            }

     );
    })
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
<div class="mallLeft">
    <div class="categoryn">
        <h2 class="categoryHd">
        </h2>
        <div class="menu">
            <ul>
                <asp:Repeater ID="RepeaterCategory" runat="server">
                    <ItemTemplate>
                        <li class="iten itenone">
                            <h3 class="item_hd item_hd1">
                                <asp:Image ID="ImageLogo" runat="server" ImageUrl='<%# Eval("logoimg").ToString()%>'
                                    Width="11" Height="11" />&nbsp;&nbsp; <a href='<%#ShopUrlOperate.RetUrl("Search_productlist",((DataRowView)Container.DataItem).Row["code"].ToString(),"code")%>'>
                                        <%# Eval("Name")%></a>
                            </h3>
                            <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID")%>' />
                            <p class="itemCol1 item_col">
                                <asp:Repeater ID="RepeaterCategoryTwo" runat="server">
                                    <ItemTemplate>
                                        <a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                            <%# Eval("Name")%></a>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </p>
                            <p class="itemCol1_wht">
                            </p>
                            <div class="subCategory" style="height: 438px; top: -10px; width: 0px; display: none">
                                <div class="subView">
                                    <asp:DataList ID="DataListCategoryRight" runat="server" RepeatDirection="Horizontal"
                                        RepeatColumns="3" RepeatLayout="Flow">
                                        <ItemTemplate>
                                            <ul>
                                                <li class="subItem">
                                                    <h3 class="subItem_hd">
                                                        <a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                            <%# Eval("Name")%></a></h3>
                                                    <p class="subItem_cat">
                                                        <asp:HiddenField ID="HiddenFieldCategoryTwoID" runat="server" Value='<%#Eval("ID")%>' />
                                                        <asp:Repeater ID="RepeaterCategoryThree" runat="server">
                                                            <ItemTemplate>
                                                                <a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                    <%# Eval("Name")%></a></ItemTemplate>
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
                        <li class="iten itentwo">
                            <h3 class="item_hd item_hd2">
                                <asp:Image ID="ImageLogo" runat="server" ImageUrl='<%# Eval("logoimg")%>' Width="11"
                                    Height="11" />&nbsp;&nbsp; <a href='<%#ShopUrlOperate.RetUrl("Search_productlist",((DataRowView)Container.DataItem).Row["code"].ToString(),"code")%>'>
                                        <%# Eval("Name")%></a>
                            </h3>
                            <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID")%>' />
                            <p class="itemCol1 item_col">
                                <asp:Repeater ID="RepeaterCategoryTwo" runat="server">
                                    <ItemTemplate>
                                        <a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                            <%# Eval("Name")%></a>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </p>
                            <p class="itemCol1_wht">
                            </p>
                            <div class="subCategory" style="height: 438px; top: -10px; width: 0px; display: none">
                                <div class="subView">
                                    <asp:DataList ID="DataListCategoryRight" runat="server" RepeatDirection="Horizontal"
                                        RepeatColumns="3" RepeatLayout="Flow">
                                        <ItemTemplate>
                                            <ul>
                                                <li class="subItem">
                                                    <h3 class="subItem_hd">
                                                        <a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                            <%# Eval("Name")%></a>
                                                    </h3>
                                                    <p class="subItem_cat">
                                                        <asp:HiddenField ID="HiddenFieldCategoryTwoID" runat="server" Value='<%#Eval("ID")%>' />
                                                        <asp:Repeater ID="RepeaterCategoryThree" runat="server">
                                                            <ItemTemplate>
                                                                <a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                    <%# Eval("Name")%></a></ItemTemplate>
                                                        </asp:Repeater>
                                                    </p>
                                                </li>
                                            </ul>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                            </div>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
</div>
