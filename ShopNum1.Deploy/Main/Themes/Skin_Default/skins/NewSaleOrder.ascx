<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.Common" %>
<div class="tsBottom_right fr">
    <div class="NewDeal">
        <div class="NewDeal_title">
            最新成交<span class="lmf_t_more" style="padding-left: 100px"><a href="/Search_productlist.aspx?search=">更多&gt;&gt;</a></span></div>
        <div class="NewDealBox">
            <ul class="marquee">
                <asp:Repeater ID="RepNewSaleOrder" runat="server">
                    <ItemTemplate>
                        <li>
                            <div class="dealimg">
                                <a target="_blank" href="<%#ShopUrlOperate.shopDetailHref(Eval("ProductGuId").ToString(),Eval("shopid").ToString(),"ProductDetail")%>"
                                    title="<%#Eval("ProductName") %>">
                                    <img alt="<%#Eval("ProductName") %>" src="<%#Eval("ProductImg")+"_60x60.jpg" %>"
                                        width="60" height="60" onerror="javascript:this.src='../ImgUpload/noimg.jpg_100x100.jpg'" /></a>
                            </div>
                            <div class="dealinfo">
                                <p class="name">
                                    <a target="_blank" href="<%#ShopUrlOperate.shopDetailHref(Eval("ProductGuId").ToString(),Eval("shopid").ToString(),"ProductDetail")%>"
                                        title="<%#Eval("ProductName") %>">
                                        <%#Common.cut(Eval("ProductName"),21) %></a></p>
                                <p class="price">
                                    <%#Eval("buyprice", "{0:C}")%></p>
                                <p class="number">
                                    销量：<%#Eval("salenumber")%>笔</p>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
</div>
