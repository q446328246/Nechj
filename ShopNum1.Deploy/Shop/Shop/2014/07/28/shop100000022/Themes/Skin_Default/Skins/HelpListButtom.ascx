<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript">
$(document).ready(function(){
    $('#help dt').each(function(){
        var index = $('#help dt').index($(this));
        $(this).addClass('dt'+index);
    });
});
</script>
<div class="floor_load">
    <div id="help" class="clearfix">
        <asp:Repeater ID="RepeaterHelpList" runat="server">
            <ItemTemplate>
                    <dl>
                        <dt>
                            <div class="gtotop_title"><%#((DataRowView)Container.DataItem).Row["Name"]%></div>
                            <asp:HiddenField ID="HiddenFieldGuid" runat="server" Visible="False" Value='<%#((DataRowView)Container.DataItem).Row["Guid"] %>' />
                        </dt>
                        <asp:Repeater ID="RepeaterHelp" runat="server">
                            <ItemTemplate>
                                <dd>
                                    <a href='<%#ShopUrlOperate.RetUrl("HelpList",((DataRowView)Container.DataItem).Row["Guid"])%>'
                                        target="_blank">
                                        <%#((DataRowView)Container.DataItem).Row["Title"]%></a></dd>
                            </ItemTemplate>
                        </asp:Repeater>
                    </dl>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
