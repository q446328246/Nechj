<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript">

    $(function () {
        //鼠标划入时
        $('.store_category_title').hover
    (
            function () {
                $(this).children('div').show();

            },
        //鼠标移除时
            function () {
                $(this).children('div').hide();
            }

     );


        //鼠标划入时
        $('.store_category_detailon').hover
    (
            function () {
                $(this).children('div').show();

            },
        //鼠标移除时
            function () {
                $(this).children('div').hide();
            }

     );


    })
</script>
<h3>
    文章分类</h3>
<asp:Repeater ID="RepeaterData" runat="server">
    <ItemTemplate>
        <div class="store_category_view_list">
            <div class="store_category_title">
                <a href='<%# ShopUrlOperate.RetUrl("articlelist",((DataRowView)Container.DataItem).Row["ID"]) %>'>
                    <%# ((DataRowView)Container.DataItem).Row["Name"]%>>></a>
                <div style="display: none">
                    <asp:Repeater ID="RepeaterChild" runat="server">
                        <ItemTemplate>
                            <div class="store_category_detailon">
                                <a href='<%# ShopUrlOperate.RetUrl("articlelist",((DataRowView)Container.DataItem).Row["ID"]) %>'>
                                    <%# ((DataRowView)Container.DataItem).Row["Name"]%></a>
                                <div class="store_category_detailon_sub">
                                    <asp:Repeater ID="RepeaterthreeChild" runat="server">
                                        <ItemTemplate>
                                            <a href='<%# ShopUrlOperate.RetUrl("articlelist",((DataRowView)Container.DataItem).Row["ID"]) %>'>
                                                <%# ((DataRowView)Container.DataItem).Row["Name"]%></a>
                                            <asp:Literal ID="LiteralLine" runat="server">|</asp:Literal>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <asp:HiddenField ID="HiddenFieldFID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <asp:HiddenField ID="HiddenFieldCID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
        </div>
    </ItemTemplate>
</asp:Repeater>
