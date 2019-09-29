<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<%@ Import Namespace="System.Data " %>
<script language="javascript" type="text/javascript">
    function selectimg(element) {
        document.getElementById("ProductIsPanicDetail_ctl00_RepeaterData_ctl00_Image1").src = element.src;
        document.getElementById("ProductIsPanicDetail_ctl00_RepeaterData_ctl00_Image1").alt = element.src;
    }
</script>
<div class="detail">
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <div class="DetailImage snap">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td colspan="2" style="height: 22px;">
                            <span style="color: #010101; font-size: 16px; padding-left: 8px; font-weight: bold;
                                height: 28px; line-height: 28px;">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name")%>'></asp:Label>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="10">
                            <div>
                                <div style="position: relative; z-index: 109; top: 0px; left: 0px; display: none;">
                                    <asp:Image ID="Image2" runat="server" src="Themes/Skin_Default/Images/qianggou.gif"
                                        Width="55" Height="53" />
                                </div>
                                <div id="preview">
                                    <div id="spec-n1" class="jqzoom" style="background: #bf0000;">
                                        <img id="ProductImgurl" runat="server" src='<%# Page.ResolveUrl(((DataRowView)Container.DataItem).Row["OriginalImage"].ToString())%>'
                                            width="310" height="310" onerror="javascript:this.src='Themes/Skin_Default/Images/noImage.gif'"
                                            jqimg='<%# Page.ResolveUrl(((DataRowView)Container.DataItem).Row["OriginalImage"].ToString())%>' /></div>
                                    <div class="clearfix">
                                    </div>
                                    <div id="spec-n5" class="tb_thumb">
                                        <div class="control" id="spec-left">
                                        </div>
                                        <div class="control" id="spec-right">
                                        </div>
                                        <div class="tb_gallery" id="tb_gallery" style="height: 50px">
                                            <ShopNum1Shop:ProductMultiImage ID="ProductMultiImage" runat="server" SkinFilename="ProductMultiImage.ascx" />
                                            <%-- <ul>
                                                <li class="tb_diply">
                                                    <div class="tb_pic tb_stn">
                                                        <a href="#">
                                                            <img src="Themes/Skin_Default/Images/potu2.jpg" /></a></div>
                                                </li>
                                                <li class="tb_diply">
                                                    <div class="tb_pic tb_stn">
                                                        <a href="#">
                                                            <img src="Themes/Skin_Default/Images/potu2.jpg" /></a></div>
                                                </li>
                                                <li class="tb_diply">
                                                    <div class="tb_pic tb_stn">
                                                        <a href="#">
                                                            <img src="Themes/Skin_Default/Images/potu2.jpg" /></a></div>
                                                </li>
                                                <li class="tb_diply tb_selected">
                                                    <div class="tb_pic tb_stn">
                                                        <a href="#">
                                                            <img src="Themes/Skin_Default/Images/potu2.jpg" /></a></div>
                                                </li>
                                            </ul>--%>
                                        </div>
                                        <div id="spec-list" style="display: none;">
                                            <asp:Repeater ID="RepeaterDateImage" runat="server">
                                                <ItemTemplate>
                                                    <img id="Img1" runat="server" onclick="selectimg(this)" src='<%# Eval("imgurl") %>'
                                                        width="100" height="100" />
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </td>
                        <td style="width: 425px; display: none">
                            <asp:Label ID="LabelCarriage" runat="server" Text='<%# Eval("Carriage")%>' Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tassle">
                            <span class="flohost">商品货号：</span> <span>
                                <%# Eval("productnum")%></span>
                        </td>
                    </tr>
                    <tr>
                        <td class="tassle">
                            <span class="flohost">商品品牌：</span> <span>
                                <%# Eval("brandname")%></span>
                        </td>
                    </tr>
                    <tr>
                        <td class="tassle">
                            <span class="flohost">市场价： </span><span class="clenew">￥<asp:Label ID="Label2" runat="server"
                                Text='<%# Eval("MarketPrice")%>'></asp:Label></span>
                        </td>
                    </tr>
                    <tr>
                        <td class="tassle">
                            <span class="flohost">抢购价：</span><span class="ntsig"> ￥<%# Eval("PanicPrice")%>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td class="tassle">
                            <span class="flohost">抢购数：</span><span style="font-weight: bold;">
                                <%#Eval("PanicBuyCount")%>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td class="tassle">
                            <span class="flohost">已抢：</span><span style="color: #D30100; font-weight: bold; font-size: 15px;">
                                <%# Eval("SaledNum").ToString() == "" ? "0" : Eval("SaledNum")%>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td class="tassle">
                            <span class="flohost">
                                <asp:Label ID="LabelTime" runat="server" Text=""></asp:Label></span> <span class="cotunse"
                                    id='panic'>
                                    <%--<script>                                        show_date_time(('<%#  ProductIsPanicBuyList.IsBegin(Eval("PanicBuyStartTime"),Eval("PanicBuyEndTime")).Replace("-","/") %>'), 'panic')</script>--%>
                                </span>
                        </td>
                    </tr>
                    <tr>
                        <td class="smarter">
                            <asp:Button ID="ButtonShopCar" runat="server" Text="" CssClass="plunde" />
                        </td>
                    </tr>
                </table>
                <div style="clear: both;">
                </div>
                <div style="border: 1px solid #EF9B5A; background: #FEFFD5; padding: 8px; margin-bottom: 6px;">
                    <ShopNum1Shop:ProductIsPanicBuyList ID="ProductIsPanicBuyList1" runat="server" ShowCount="10"
                        SkinFilename="ProductIsPanicBuyList1.ascx" />
                </div>
                <div class="hd_de diagram">
                    <div class="hd_de_top">
                        <h2 class="hd_de_topli">
                            商品详细</h2>
                    </div>
                    <div class="hd_de_lr" style="line-height: 22px;">
                        <%#  Server.HtmlDecode(Eval("Detail").ToString())%>
                    </div>
                </div>
                <div class="hd_de diagram">
                    <div class="hd_de_top">
                        <h2 class="hd_de_topli">
                            抢购须知</h2>
                    </div>
                    <div class="hd_de_lr" style="line-height: 22px;">
                        <%# Server.HtmlDecode(Eval("Instruction").ToString())%>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
