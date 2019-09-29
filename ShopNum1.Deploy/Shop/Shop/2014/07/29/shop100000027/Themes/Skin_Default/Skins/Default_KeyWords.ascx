<%@ Control Language="C#" %>

<asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
        <itemtemplate>
                  <a href='<%# DataBinder.Eval(Container.DataItem,"Href") %>' target="_blank">
                        <%# Eval("Title")%></a> 
        </itemtemplate>
    </ItemTemplate>
</asp:Repeater>
<asp:Repeater ID="Repeater2" runat="server">
    <ItemTemplate>
        <itemtemplate>
                  <a href='<%# DataBinder.Eval(Container.DataItem,"Href") %>' target="_blank">
                        <%# Eval("Title")%></a> 
        </itemtemplate>
    </ItemTemplate>
</asp:Repeater>
<asp:Repeater ID="Repeater3" runat="server">
    <ItemTemplate>
        <itemtemplate>
                  <a href='<%# DataBinder.Eval(Container.DataItem,"Href") %>' target="_blank">
                        <%# Eval("Title")%></a> 
      </itemtemplate>
    </ItemTemplate>
</asp:Repeater>
<asp:Repeater ID="Repeater4" runat="server">
    <ItemTemplate>
        <itemtemplate>
                  <a href='<%# DataBinder.Eval(Container.DataItem,"Href") %>' target="_blank">
                        <%# Eval("Title")%></a> 
        </itemtemplate>
    </ItemTemplate>
</asp:Repeater>
