<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<%@ Import Namespace="System.Data " %>
<script language="javascript" type="text/javascript">
    function selectimg(element) {
        document.getElementById("ProductIsSpellDetail_ctl00_RepeaterData_ctl00_Image1").src = element.src;
        document.getElementById("ProductIsSpellDetail_ctl00_RepeaterData_ctl00_Image1").alt = element.src;
    }
</script>
<asp:Repeater ID="RepeaterData" runat="server">
    <ItemTemplate>
        <div class="spll_datei">
            <h1>
                <%# ((DataRowView)Container.DataItem).Row["Name"]%></h1>
            <div class="spell_dl fl">
                <div class="tuan-infos">
                    <div class="tuan-buy">
                        <p class="price">
                            ￥<%#((DataRowView)Container.DataItem).Row["GroupPrice"] %>
                        </p>
                    </div>
                    <div class="tuan-prices">
                        <dl>
                            <dt>原价</dt>
                            <dd>
                                <del>￥<%# ((DataRowView)Container.DataItem).Row["ShopPrice"]%></del>
                            </dd>
                        </dl>
                        <dl>
                            <dt>折扣</dt>
                            <dd>
                                <asp:Label ID="LabelDiscount" runat="server" Text="0.0"></asp:Label>折
                            </dd>
                        </dl>
                        <dl class="last">
                            <dt>节省</dt>
                            <dd>
                                <%#Convert.ToDecimal(((DataRowView)Container.DataItem).Row["ShopPrice"]) - Convert.ToDecimal(((DataRowView)Container.DataItem).Row["GroupPrice"])%>
                            </dd>
                        </dl>
                    </div>
                    <div class="tuan-sold">
                        <p>
                            本商品已被团购<strong>
                                <%# ProductIsPanicBuyList.SetNoNull(((DataRowView)Container.DataItem).Row["groupcount"])%>
                            </strong>件</p>
                        <p class="numorder">
                            数量有限请您尽快下单
                        </p>
                        <div class="lijijq">
                            <asp:Button ID="ButtonShopCar" runat="server" Text="我要团购" CssClass="bnt1" />
                        </div>
                    </div>
                    <div class="tuan-count">
                        剩余<span id='panic'>
                            <script>                                show_date_time(('<%# ProductIsPanicBuyList.IsBegin(Eval("EndTime"),Eval("StartTime")).Replace("-","/") %>'), 'panic')</script>
                        </span>
                    </div>
                </div>
            </div>
            <div class="prod_img fr">
                <img id="ProductImgurl" runat="server" src='<%# Page.ResolveUrl(((DataRowView)Container.DataItem).Row["groupimg"].ToString())%>'
                    width="250" height="250" onerror="javascript:this.src='Themes/Skin_Default/Images/noImage.gif'" />
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="bBox Cbox">
            <div class="tuan-title">
                <h2 class="fl">
                    <span class="fl">商品详情</span></h2>
            </div>
            <div class="content">
                <%#  Server.HtmlDecode(((DataRowView)Container.DataItem).Row["Introduce"].ToString())%>
            </div>
            <div class="clear">
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
<input type="hidden" id="hidProductGuId" runat="server" />