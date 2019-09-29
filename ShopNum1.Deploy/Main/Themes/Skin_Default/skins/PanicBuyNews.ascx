<%@ Control Language="C#" %>
<!--抢购广告-->
<asp:Repeater ID="RepeaterData" runat="server" Visible="false">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li><a href='<%#ShopUrlOperate.RetUrl("ArticleDetail",Eval("Guid")) %>'>
            <%# ShopNum1.Common.Utils.GetUnicodeSubString(Eval("Title").ToString(),36,"")%></a></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
