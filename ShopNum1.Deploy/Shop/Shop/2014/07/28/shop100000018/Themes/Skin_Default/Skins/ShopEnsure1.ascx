<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>

<span class="shopEnsure">
     <asp:Repeater ID="RepeaterData" runat="server">
      <ItemTemplate>      
        <b><img  id='Image1Ensure' alt="" runat="server" src='<%# Eval("ImagePath")%>' width="14" height="15"  title=' <%#(Eval("Name"))%>'/></b> 
    </ItemTemplate>
    </asp:Repeater>  
</span>
