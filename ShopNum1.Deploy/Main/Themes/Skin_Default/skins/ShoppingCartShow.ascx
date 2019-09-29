<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<asp:HyperLink ID="shoppingCart" runat="server" Text="查看购物车" Target="_self">
    您的购物车中有
    <asp:Label ID="LableProductCount" runat="server" />件商品，总计金额
    <%# Globals.MoneySymbol%>
    <asp:Label ID="LabelAllPrice" runat="server" /></asp:HyperLink>
