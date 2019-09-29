<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="store_category_view shoppu">
    <h3>推荐店铺<asp:Literal ID="LiteralTitle" runat="server" Visible="false"></asp:Literal></h3>
    <div class="news_pics">
        <ul>
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <li><a href='<%#ShopUrlOperate.GetShopUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString())%>' class="shopimg">
                    <asp:Image ID="Img1" ImageUrl='<%# ((DataRowView)Container.DataItem).Row["Banner"]%>'
                        runat="server" alt="图片"  width="74" height="74"  onerror="javascript:this.src='../ImgUpload/noImage.gif'" />
                        </a>
                        <div class="shop_name">
                            <a href='<%#ShopUrlOperate.GetShopUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString())%>' target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["ShopName"] %>'> <%#ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["ShopName"].ToString(),20,"")%></a>
                            <p class="dianzhu">
                                店主：<%#((DataRowView)Container.DataItem).Row["shopname"].ToString()%></p>
                            <div>
                               <asp:Image id="EnsureImg"  runat="server" alt="图片" Width="16px" Height="16px" ImageUrl='<%#((DataRowView)Container.DataItem).Row["mrankpic"].ToString() %>'  onerror="javascript:this.src='../ImgUpload/noImage.gif'" />
                            </div>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
