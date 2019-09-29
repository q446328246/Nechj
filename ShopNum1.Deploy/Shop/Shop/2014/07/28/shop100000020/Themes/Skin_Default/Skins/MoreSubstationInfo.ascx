<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>

<dl>
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
           <a href='<%# MoreSubstationInfo.returnAgentUlr(Eval("AgentLoginID")) %>' target="_blank" > <%# Eval("Name") %></a>
       </ItemTemplate>                    
    </asp:Repeater>
</dl>
