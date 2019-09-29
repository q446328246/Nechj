<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<%@ Import Namespace="System.Data" %>
<!--店铺信息-->
<div class="ks_panel">
    <div class="ks_panel_tab">
        <table>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="shopkper">
                        <%#((DataRowView)Container.DataItem).Row["ShopName"]%>
                    </td>
                </tr>
                <tr>
                    <td class="shopkperInfo">
                        <dl>
                            <dt class="ncs_infn">
                                <img id="Img1" width="64" height="64" src='<%# ((DataRowView)Container.DataItem).Row["Banner"]%>' runat="server" />
                            </dt>
                            <dd class="ncs_name">
                                <a class="shopkps">
                                    <%#((DataRowView)Container.DataItem).Row["MemLoginID"]%></a></dd>
                            <dd class="ncs_level">
                                <asp:Image ID="ImageReputation" runat="server" /></dd>
                            <dd>
                                好评率：
                                <%#Convert.ToDouble(((DataRowView)Container.DataItem).Row["HaoPingLV"]) * 100%>%
                            </dd>
                        </dl>
                        <span style="display: none;">店铺等级：<asp:Label ID="LabelShopRank" runat="server" Text="1"></asp:Label></span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="shop_rate">
                            <h4>店铺动态评分：</h4>
                            <dl>
                                <dt>描述相符：</dt>
                                <dd class="rate_star">
                                    <ul>
                                        <li class="ncs_bfl">
                                            <%#((DataRowView)Container.DataItem).Row["ShopCharacter"].ToString() == string.Empty ? "暂无评论" : ((DataRowView)Container.DataItem).Row["ShopCharacter"]%>
                                        </li>
                                        <li class="<%#Convert.ToDouble(((DataRowView)Container.DataItem).Row["CharacterBL"]) >= 0  ? "star_red" : "star_gren"%>">
                                            <%#Convert.ToDouble(((DataRowView)Container.DataItem).Row["CharacterBL"]) >= 0 ? "<div class=\"gaoyu\"><span class=\"over\">高于</span></div>" : "<div class=\"diyu\"><span class=\"down\">低于</span></div>"%>
                                        </li>
                                        <li class="centage">
                                            <%#(Convert.ToDouble(((DataRowView)Container.DataItem).Row["CharacterBL"]) * 100).ToString().Replace("-", "")%>%
                                        </li>
                                    </ul>
                                </dd>
                                <dt>服务态度：</dt>
                                <dd class="rate_star">
                                    <ul>
                                        <li class="ncs_bfl">
                                            <%#((DataRowView)Container.DataItem).Row["ShopAttitude"].ToString() == string.Empty ? "暂无评论" : ((DataRowView)Container.DataItem).Row["ShopAttitude"]%>
                                        </li>
                                        <li class="<%#Convert.ToDouble(((DataRowView)Container.DataItem).Row["AttitudeBL"]) >= 0  ? "star_red" : "star_gren"%>">
                                            <%#Convert.ToDouble(((DataRowView)Container.DataItem).Row["AttitudeBL"]) >= 0 ? "<div class=\"gaoyu\"><span class=\"over\">高于</span></div>" : "<div class=\"diyu\"><span class=\"down\">低于</span></div>"%>
                                        </li>
                                        <li class="centage">
                                            <%#(Convert.ToDouble(((DataRowView)Container.DataItem).Row["AttitudeBL"]) * 100).ToString().Replace("-", "")%>%
                                        </li>
                                    </ul>
                                </dd>
                                <dt>发货速度：</dt>
                                <dd class="rate_star">
                                    <ul>
                                        <li class="ncs_bfl">
                                            <%#((DataRowView)Container.DataItem).Row["ShopSpeed"].ToString() == string.Empty ? "暂无评论" : ((DataRowView)Container.DataItem).Row["ShopSpeed"]%>
                                        </li>
                                        <li class="<%#Convert.ToDouble(((DataRowView)Container.DataItem).Row["SpeedBL"]) >= 0  ? "star_red" : "star_gren"%>">
                                            <%#Convert.ToDouble(((DataRowView)Container.DataItem).Row["SpeedBL"]) >= 0 ? "<div class=\"gaoyu\"><span class=\"over\">高于</span></div>" : "<div class=\"diyu\"><span class=\"down\">低于</span></div>"%>
                                        </li>
                                        <li class="centage">
                                            <%#(Convert.ToDouble(((DataRowView)Container.DataItem).Row["SpeedBL"]) * 100).ToString().Replace("-", "")%>%
                                        </li>
                                    </ul>
                                </dd>
                            </dl>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="shop_detail">
                            <h4>店铺信息</h4>
                            <dl>
                                <dt>店铺名称：</dt><dd><%#((DataRowView)Container.DataItem).Row["ShopName"]%><input type="hidden" id="hfShopName" value='<%#((DataRowView)Container.DataItem).Row["ShopName"]%>' /></dd>
                                <dt>固定电话：</dt><dd><%# string.IsNullOrEmpty(((DataRowView)Container.DataItem).Row["Tel"].ToString()) == true ? "暂无" : ((DataRowView)Container.DataItem).Row["Tel"]%></dd>
                                <dt>手机号码：</dt><dd><%# string.IsNullOrEmpty(((DataRowView)Container.DataItem).Row["Phone"].ToString()) == true ? "暂无" : ((DataRowView)Container.DataItem).Row["Phone"]%></dd>
                                <dt>店铺地址：</dt><dd class="shop_addre"><%#((DataRowView)Container.DataItem).Row["Address"]%><input type="hidden" id="hfAddress" value='<%#((DataRowView)Container.DataItem).Row["Address"]%>' /></dd>
                                <dt>店铺保障：</dt><dd><ShopNum1Shop:ShopEnsure ID="ShopEnsure1" runat="server" SkinFilename="ShopEnsure1.ascx" />
                                </dd>
                            </dl>
                        </div>
                    </td>
                </tr>
                <tr id="TRIdentity" runat="server">
                    <td>
                        <div class="shop_detail">
                            <dl>
                                <dt>认证信息：</dt>
                                <dd>
                                    <p>
                                        <a href="javascript:void(0)" title="实名认证">
                                            <asp:Image ID="ImageIdentity" ImageUrl="/Main/Themes/Skin_Default/Images/rz1.jpg" runat="server" /></a> 
                                        <a href="javascript:void(0)" title="公司认证">
                                            <asp:Image ID="ImageCompan" ImageUrl="/Main/Themes/Skin_Default/Images/rz2.jpg" runat="server" /></a>
                                    </p>                
                                </dd>                                
                            </dl>
                        </div>
                    </td>
                </tr>
                <asp:HiddenField ID="HiddenFieldLongitude" runat="server" Value='<%#((DataRowView)Container.DataItem).Row["Longitude"]%>' />
                <asp:HiddenField ID="HiddenFieldLatitude" runat="server" Value='<%#((DataRowView)Container.DataItem).Row["Latitude"]%>' />
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div style="display: none;"><asp:Button ID="ButtonBooking" runat="server" Text="" CssClass="shopbtn" /></div>
    </div>
</div>
<div class="ks_panels">
    <ul>
        <li id="dz1" onmouseover="changes(1)" onmouseout="showsearch()" class="ncs_map"><a><span>店铺地图</span></a></li>
        <li id="dz2" onmouseover="changes(2)" onmouseout="showsearch()"  class="ncs_cord"><a><span>店铺二维码</span></a></li>        
    </ul>    
    <div class="ristn">
        <!--百度地图-->    
        <div id="map1" class="ncs_ctain" ></div>
        
        <!--手机扫描二维码--> 
        <div id="map2" class="ncs_ctain">
            <p style="text-align: center;"><img src="Themes/Skin_Default/Images/qrcode.png"/></p>
            <p class="ncs_cord_word">手机扫描二维码</p>
        </div>
    </div>    
</div>
