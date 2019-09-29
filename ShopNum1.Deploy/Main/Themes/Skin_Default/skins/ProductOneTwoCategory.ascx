<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript">
    $(function () {
        $(".shangsearch_product").toggle
    (
        function () {
            $(this).attr("class", "shangsearch_product1");
            $(this).next().show();
        },
        function () {
            $(this).attr("class", "shangsearch_product2");
            $(this).next().hide();
        }
    );
    });
</script>
<div class="searchcate">
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <dl>
                <dt class="shangsearch_product">
                    <%# ((DataRowView)Container.DataItem).Row["Name"]%></dt>
                <dd style="display: none">
                    <asp:Repeater ID="RepeaterChild" runat="server">
                        <ItemTemplate>
                            <a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"])%>'>
                                <%# ((DataRowView)Container.DataItem).Row["Name"]%></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </dd>
            </dl>
            <asp:HiddenField ID="HiddenFieldCID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
        </ItemTemplate>
    </asp:Repeater>
</div>
