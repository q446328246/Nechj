<%@ Control Language="C#" %>
<div class="bBox">
    <h2>
        资讯列表</h2>
    <div class="content">
        <strong>资讯标题</strong>
        <td width="50%">
            <strong>添加日期</strong>
        </td>
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <table width="100%" border="0" cellpadding="0" cellspacing="1" style="text-align: center"
                    class="table1">
                    <tr>
                        <td width="50%">
                            <a href='<%# Eval("Guid")%>' target="_blank">
                                <%# Eval("Name")%></a>
                        </td>
                        <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("Guid")%>' />
                        <asp:Repeater ID="RepeaterDataTitle" runat="server">
                            <ItemTemplate>
                                <td width="50%">
                                    <a target="_blank">
                                        <%# Eval("Name")%></a>
                                </td>
                            </ItemTemplate>
                       </asp:Repeater>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
