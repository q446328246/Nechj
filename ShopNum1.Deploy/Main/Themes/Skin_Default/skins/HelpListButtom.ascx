<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="floor_load">
    <div id="help">
        <ul class="jd_menu clearfix">
            <asp:Repeater ID="RepeaterHelpList" runat="server">
                <ItemTemplate>
                    <li>
                        <dl>
                            <dt>
                                <div class="gtotop_title">
                                    <%#((DataRowView)Container.DataItem).Row["Name"]%></div>
                                <asp:HiddenField ID="HiddenFieldGuid" runat="server" Visible="False" Value='<%#((DataRowView)Container.DataItem).Row["Guid"] %>' />
                            </dt>
                            <asp:Repeater ID="RepeaterHelp" runat="server">
                                <ItemTemplate>
                                    <dd>
                                        <a href='<%#ShopUrlOperate.RetUrl("HelpList",((DataRowView)Container.DataItem).Row["Guid"])%>'
                                            target="_blank">
                                            <%#((DataRowView)Container.DataItem).Row["Title"]%></a>
                                    </dd>
                                </ItemTemplate>
                            </asp:Repeater>
                        </dl>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
