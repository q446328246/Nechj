<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="store_category_view">
    <h3>
        帮助分类</h3>
    <asp:Repeater ID="RepeaterHelpList" runat="server">
        <ItemTemplate>
            <div class="store_category_view_list">
                <div class="store_categoryon_title">
                    <span class="san"></span>
                    <%# ((DataRowView)Container.DataItem).Row["Name"]%>
                </div>
                <asp:Repeater ID="RepeaterHelp" runat="server">
                    <ItemTemplate>
                        <div class="store_category_detail">
                            ·<a href='<%# "HelpList.aspx?guid=" + ((DataRowView)Container.DataItem).Row["Guid"]%>'
                                target="_self"><%#((DataRowView)Container.DataItem).Row["Title"]%></a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:HiddenField ID="HiddenFieldGuid" runat="server" Visible="False" Value='<%#((DataRowView)Container.DataItem).Row["Guid"] %>' />
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
