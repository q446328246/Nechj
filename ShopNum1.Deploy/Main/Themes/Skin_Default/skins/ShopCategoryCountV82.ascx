<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="shoptop clearfix">
    <div class="att_key">
        微信店铺类目</div>
    <div class="att_values">
        <ul class="att_ul att_ul1">
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <li><a></a><a href='/WeiXinUserListV82.aspx?tag=1&code=<%# ((DataRowView)Container.DataItem).Row["Code"]%>'>
                        <%# ((DataRowView)Container.DataItem).Row["Name"].ToString().Length > 10 ? ((DataRowView)Container.DataItem).Row["Name"].ToString().Substring(0, 10) : ((DataRowView)Container.DataItem).Row["Name"].ToString()%>(<%# ((DataRowView)Container.DataItem).Row["NUM"]%>)</a>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
