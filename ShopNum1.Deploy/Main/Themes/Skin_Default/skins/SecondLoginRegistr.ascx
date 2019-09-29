<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<asp:Repeater ID="RepeaterSecondLogin" runat="server">
    <ItemTemplate>
        <p>
            <a href="javascript:SecondLoginUrl('<%#((DataRowView)Container.DataItem).Row["id"] %>','')"
                onclick="javascript:SecondLoginUrl('<%#((DataRowView)Container.DataItem).Row["id"] %>','')">
                <img src='Themes/Skin_Default/Images/ThreeSecond_<%#Eval("id") %>.jpg' /></a></p>
    </ItemTemplate>
</asp:Repeater>
