<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<asp:Repeater ID="RepeaterData" runat="server">
    <ItemTemplate>
        <p>
            时间：<font><%# Eval("CreateTime","{0:yyyy-MM-dd}")%></font></p>
        <p>
            标签：<font><%#((DataRowView)Container.DataItem).Row["KeyWords"] %></font></p>
        <p>
            简介：</p>
        <%#((DataRowView)Container.DataItem).Row["Content"] %>
    </ItemTemplate>
</asp:Repeater>
<asp:HiddenField ID="HiddenFieldGuid" runat="server" Value="0" />
