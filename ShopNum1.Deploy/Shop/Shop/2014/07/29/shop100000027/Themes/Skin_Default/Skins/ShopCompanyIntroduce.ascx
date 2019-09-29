<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<div class="aBox11">
    <h2>
        公司介绍:</h2>
    <div style="padding: 8px 8px 8px 0; text-indent: 1em; line-height: 1.8; height:auto;">
        <asp:Repeater EnableViewState="False" ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <!--简介-->
                <%# Server.HtmlDecode(Eval("CompanyIntroduce").ToString())%>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:Button ID="ButtonBooking" runat="server" Text="预约订购" CssClass="bnt0" Visible="false" />
</div>
