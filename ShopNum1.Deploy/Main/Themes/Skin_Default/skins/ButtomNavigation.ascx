<%@ Control Language="C#"  %>
<%@ Import Namespace="ShopNum1.WebControl"%>
<%@ Import Namespace="System.Data" %>
<p class="btNagt">
<asp:Repeater ID="RepeaterData" runat="server">
     <ItemTemplate>
                    <a  href='<%# ButtomNavigation.LinkUrl(((DataRowView)Container.DataItem).Row["LinkAddress"].ToString())%>' 
                target='<%# ButtomNavigation.ShowIsOpen(((DataRowView)Container.DataItem).Row["IfOpen"].ToString())%>' > 
            <%# ((DataRowView)Container.DataItem).Row["Name"]%></a>
    </ItemTemplate>
</asp:Repeater> 
</p>
 