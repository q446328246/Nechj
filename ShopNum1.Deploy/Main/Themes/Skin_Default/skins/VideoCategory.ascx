<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div id="article_categroy" class="VideoCategoryBox">
    <asp:Repeater ID="RepeaterCategory" runat="server">
        <ItemTemplate>
            <ul>
                <li class="f2">
                    <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%#((DataRowView)Container.DataItem).Row["ID"] %>' />
                    <a href='Video_ListV82.aspx?guid=<%#((DataRowView)Container.DataItem).Row["ID"]%>&PageID=1'>
                        <%#((DataRowView)Container.DataItem).Row["Name"] %>
                    </a></li>
                <asp:Repeater ID="RepeaterSubCategory" runat="server">
                    <ItemTemplate>
                        <li><a href='Video_ListV82.aspx?guid=<%#((DataRowView)Container.DataItem).Row["ID"]%>&PageID=1'>
                            <%#((DataRowView)Container.DataItem).Row["Name"]  %>
                        </a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </ItemTemplate>
    </asp:Repeater>
</div>
