<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript">
    $(document).ready(function () {
        $(".sup_lists ul li span:last-child").hide();
    })
</script>
<%--<style type="text/css">
     .btitle b{display:block; width:80px;}
</style>--%>
<div class="supply_cates">
    <div class="sup_title">
        <span class="fl">供求分类列表</span><a href='<%= ShopUrlOperate.RetUrl("SupplyDemandShow") %>'
            class="sup_more">更多>></a></div>
    <div class="sup_lists">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <ul>
                    <li><a href='<%#ShopUrlOperate.RetUrl("SupplyDemandListSearch",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'
                        class="btitle"><b>
                            <%# ((DataRowView)Container.DataItem).Row["Name"]%></b></a>
                        <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID")%>' />
                        <asp:Repeater ID="RepeaterData2" runat="server">
                            <ItemTemplate>
                                <a href='<%#ShopUrlOperate.RetUrl("SupplyDemandListSearch",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                    <%# ((DataRowView)Container.DataItem).Row["Name"]%></a> <span>|</span>
                            </ItemTemplate>
                        </asp:Repeater>
                    </li>
                </ul>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
