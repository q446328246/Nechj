<%@ Control Language="C#" %>
<!-- coupon right start -->
<div class="coupon_right">
    <!-- 常见问题 -->
    <div class="fqa">
        <div class="fqa_top">
            <img src="Themes/Skin_Default/Images/title_qa.gif" /></div>
        <div class="fqa_detail">
            <ul>
                <asp:Repeater ID="RepeaterData" runat="server">
                    <ItemTemplate>
                        <li><a href='<%#ShopUrlOperate.RetUrl("ArticleDetail",Eval("Guid")) %>' target="_blank">
                            <asp:Literal ID="Literal1" Text='<%#Eval("Title")%>' runat="server"></asp:Literal></a></li>
                    </ItemTemplate>
                </asp:Repeater>
                <li style="text-align: right;"><a id="AHelpMore" target="_blank" runat="server">更多>></a></li>
            </ul>
        </div>
    </div>
</div>
