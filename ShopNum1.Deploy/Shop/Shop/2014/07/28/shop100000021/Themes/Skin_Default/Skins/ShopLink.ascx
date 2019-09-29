<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<div class="ks_panel">
    <div class="storn_hd">
        <h3>友情链接</h3>
    </div>
    <div class="ks_link clearfix">
        <asp:Repeater EnableViewState="False" ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <a href='<%#Eval("ShopUrl")%>' target="_blank" runat="server">
                    <%#Eval("ShopName") %>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
