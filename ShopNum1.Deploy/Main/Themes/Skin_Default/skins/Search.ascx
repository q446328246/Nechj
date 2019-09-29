<%@ Control Language="C#" %>
<asp:DropDownList ID="DropDownListType" runat="server" Style="border: 1px solid #1C618E;
    zoom: 1; display; z-index: -1">
    <asp:ListItem Value="0">搜索商品</asp:ListItem>
    <asp:ListItem Value="1">搜索店铺</asp:ListItem>
    <asp:ListItem Value="2">搜索资讯</asp:ListItem>
    <asp:ListItem Value="3">搜索视频</asp:ListItem>
    <asp:ListItem Value="4">搜索供求</asp:ListItem>
</asp:DropDownList>
<asp:TextBox ID="TextBoxKeywords" runat="server" value="" class="InputBorder" onkeydown="if(event.keyCode==13) {document.getElementById('search_ctl00_ImageButtonSearch').focus();document.getElementById('search_ctl00_ImageButtonSearch').click();}"></asp:TextBox>
<asp:ImageButton ID="ImageButtonSearch" runat="server" ImageUrl="../Images/search_submit.png"
    Style="position: relative; top: 6px;" CausesValidation="False" />
<a href='<%= ShopUrlOperate.RetUrl("ProductAdvancedSearch") %>'><span style="color: #C7241B;
    text-decoration: underline;">高级搜索</span></a> 