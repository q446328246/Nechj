<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data " %>
<div class="panic_se">
    <div class="panic_se_left_top">
        <div class="psl_left">
            母婴用品专场</div>
        <div class="psl_right">
            共<b class="totle"><asp:Label ID="LabelCount" runat="server"></asp:Label></b>个商品
            <b><span style="color: #ff6400;">
                <asp:Label ID="LabelIndex" runat="server"></asp:Label>
            </span>/<asp:Label ID="LabelPageCount" runat="server"></asp:Label>
            </b>
            <asp:LinkButton ID="LinkButtonLast" runat="server" Enabled="false" class="page_up">上一页</asp:LinkButton>
            <asp:LinkButton ID="LinkButtonNext" runat="server" class="page_down">下一页</asp:LinkButton>
        </div>
    </div>
    <div class="panic_cont">
        <div class="panic_se_right">
            <ShopNum1:AdSimpleImage ID="AdSimpleImage20" runat="server" AdImgId="20" SkinFilename="AdSimpleImage.ascx" />
        </div>
        <div class="panic_se_left">
            <div class="panic_se_left_detail">
                <asp:Repeater ID="RepeaterData" runat="server">
                    <ItemTemplate>
                        <div class="psld_de">
                            <div class="panic_img">
                                <a href='<%#ShopUrlOperate.shopDetailHrefByShopID(Eval("Guid").ToString(),Eval("ShopID").ToString(),"ProductIsPanic_Detail") %>'
                                    target="_blank">
                                    <img alt="" src='<%# Page.ResolveUrl(Eval("ThumbImage").ToString())+"_160x160.jpg" %>'
                                        onerror="javascript:this.src='../ImgUpload/noimg.jpg_160x160.jpg'" /></a>
                            </div>
                            <div class="panic_name">
                                <a href='<%#ShopUrlOperate.shopDetailHrefByShopID(Eval("Guid").ToString(),Eval("ShopID").ToString(),"ProductIsPanic_Detail") %>'
                                    target="_blank">
                                    <%# ShopNum1.Common.Utils.GetUnicodeSubString(Eval("Name").ToString(),19,"") %></a>
                            </div>
                            <%--  <div class="panic_time" id='<%# "PanicBuy" + (PanicBuyList.i).ToString() %>'>
                                剩余时间：<span class="time"><script>show_date_time(('<%# PanicBuyList.IsBegin(Eval("PanicBuyStartTime"),Eval("PanicBuyEndTime")).Replace("-","/") %>'),'<%# "PanicBuy" + (PanicBuyList.i++).ToString() %>')</script></span>
                            </div>--%>
                            <div class="panic_price">
                                <span class="fl">抢购价：<span class="qgjia">￥<%#Eval("ShopPrice")%></span></span><del>￥<%#Eval("MarketPrice")%></del>
                                <a href='<%#ShopUrlOperate.shopDetailHrefByShopID(Eval("Guid").ToString(),Eval("ShopID").ToString(),"ProductIsPanic_Detail") %>'
                                    target="_blank" style="display: none;"></a>
                                <div class="clear">
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
</div>
