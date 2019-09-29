<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<ul class="fl">
    <asp:Repeater ID="RepeaterSecondLogin" runat="server" >
        <ItemTemplate>
            <li>
                <a href="javascript:SecondLoginUrl('<%#((DataRowView)Container.DataItem).Row["id"] %>','')" >
                    <img src='<%# Page.ResolveUrl(((DataRowView)Container.DataItem).Row["ImgSrc"].ToString())%>' />
                </a>
            </li>
            <li>
                <a href="javascript:SecondLoginUrl('<%#((DataRowView)Container.DataItem).Row["id"] %>','')">
                     <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["TypeName"].ToString(), 34, "")%>
                </a>
            </li>
            <li>|</li>
        </ItemTemplate>
    </asp:Repeater>
    <li>
       <%-- <a href="#">更多>></a>--%>
    </li>    
</ul>