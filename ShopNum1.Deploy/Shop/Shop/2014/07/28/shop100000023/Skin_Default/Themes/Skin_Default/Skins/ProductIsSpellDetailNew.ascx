<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.ShopNewWebControl" %>
<%@ Import Namespace="System.Data " %>

<script language="javascript" type="text/javascript">
    function selectimg(element) {   
        document.getElementById("ProductIsSpellDetail_ctl00_RepeaterData_ctl00_Image1").src = element.src;
        document.getElementById("ProductIsSpellDetail_ctl00_RepeaterData_ctl00_Image1").alt= element.src;
    }
</script>

<asp:Repeater ID="RepeaterData" runat="server">
    <ItemTemplate>
        <div class="spll_datei">
                <h1><%# ((DataRowView)Container.DataItem).Row["Name"]%></h1>
                <div class="spell_dl fl">
                    <div class="tuan-infos">
                        <div class="tuan-buy">
                            <p class="price">
                                ￥<%#((DataRowView)Container.DataItem).Row["GroupPrice"] %>
                                <label for="ProductIsSpellDetail_ctl00_RepeaterData_ctl00_ButtonShopCar"><a title="马上参团"> </a></label>
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
                        <div class="tuan-color" style="display:none; height:100px;">
                            <div>
                                <span class="color-black">选择颜色：<b>军绿</b></span>
                                <ul>
                                    <li class="select"><a><img src="" /></a></li>
                                    <li><a><img src="" /></a></li>
                                    <li><a><img src="" /></a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="tuan-size" style="display:none;">
                            <div>
                                <span class="color-black">选择尺码：<b>均码</b></span>
                                <ul>
                                    <li class="select"><a>XS</a></li>
                                    <li><a>S</a></li>
                                    <li><a>M</a></li>
                                    <li><a>L</a></li>
                                    <li><a>XL</a></li>
                                    <li><a>XXL</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="tuan-count">
                            <p>
                              <span id='<%# "Panicspan" + (ProductIsPanicDetail.i).ToString() %>'>
                                <script>show_date_time(('<%# ProductIsSpellDetail.IsBegin(Eval("EndTime"),Eval("StartTime")).Replace("-","/") %>'),'<%# "Panicspan" + (ProductIsPanicDetail.i++).ToString() %>')</script>

                            </span></p>
                        </div>
                        <div class="tuan-sold">
                            <p class="buy-num">
                                <i></i>
                                <strong><%# ProductIsSpellDetail.SetNotNull(((DataRowView)Container.DataItem).Row["groupcount"])%></strong>
                                <span>人已购买</span>
                                <span class="tishi">数量有限，下单要快哦</span>
                            </p>
                            <div class="lijijq">
                                <asp:Button ID="ButtonShopCar" runat="server" Text="我要团购" CssClass="bnt1" />
                            </div>
                        </div>                        
                    </div>
                </div>
                <div class="fr" style="position:relative;">
                    <div class="prod_img tc">
                        <img id="ProductImgurl" runat="server" src='<%# Page.ResolveUrl(((DataRowView)Container.DataItem).Row["groupimg"].ToString())%>'
                            width="250" height="250" onerror="javascript:this.src='Themes/Skin_Default/Images/noImage.gif'" />
                    </div>
                  <%--  <div class="fenxiang-tuan" style="display:none;">
                        <p id="ckepop"> 
                            <span class="jiathis_txt">分享到：</span> <a class="jiathis_button_qzone"></a> 
                            <a class="jiathis_button_tsina"></a> <a class="jiathis_button_tqq"></a> 
                            <a class="jiathis_button_renren"></a> <a class="jiathis_button_kaixin001"></a> 
                            <a class="jiathis_button_tsohu"></a> <a class="jiathis_button_fav"></a> 
                            <a class="jiathis_button_douban"></a> 
                            <a href="http://www.jiathis.com/share" class="jiathis jiathis_txt jtico jtico_jiathis" target="_blank"></a>
                            <script type="text/javascript" src="http://v2.jiathis.com/code/jia.js" charset="utf-8"></script>
                        </p>
                    </div>--%>
                </div>
                <div class="clear"></div>
            </div>
        <div class="bBox Cbox">
            <div class="tuan-title">
                <h2 class="fl"><span class="fl">本团介绍</span></h2>
            </div>
            <div class="content">
                <%#  Server.HtmlDecode(((DataRowView)Container.DataItem).Row["Introduce"].ToString())%>
            </div>
            <div class="clear"></div>
        </div>
    </ItemTemplate>
</asp:Repeater>
<input type="hidden" id="hidProductGuId" runat="server" />