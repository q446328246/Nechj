<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data" %>
<div class="latest_shop">
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <div class="article_list">
                <div class="article_time" style="border: none; display: none;">
                    发布时间：<%# Convert.ToDateTime(((DataRowView)Container.DataItem).Row["ReleaseTime"]).ToString("yyyy-MM-dd")%>
                    发布者：<%# ((DataRowView)Container.DataItem).Row["MemberID"]%></div>
                <div class="article_detail">
                    <div class="supdem">
                        <div class="zeus">
                            <asp:Image ID="Image1" runat="server" Width="300" Height="300" ImageUrl='<%#((DataRowView)Container.DataItem).Row["Image"]%>'
                                onerror="javascript:this.src='../ImgUpload/noImage.gif'" />
                        </div>
                        <div class="poseidon">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr class="title">
                                    <td>
                                        <span class="fonsize crimson">【<%# ((DataRowView)Container.DataItem).Row["TradeType"].ToString() == "0" ? "供应" : "求购"%>】</span>
                                        <span class="fonsize">
                                            <%# ((DataRowView)Container.DataItem).Row["Title"]%></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            信息类型：</label>
                                        <%# ((DataRowView)Container.DataItem).Row["TradeType"].ToString() == "0" ? "供应" : "求购"%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            发布时间：</label><span class="azure"><%# Convert.ToDateTime(((DataRowView)Container.DataItem).Row["ReleaseTime"]).ToString("yyyy-MM-dd")%></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            有效时间：</label>
                                        <span class="loyseau">
                                            <%# Convert.ToDateTime(((DataRowView)Container.DataItem).Row["ValidTime"].ToString().Split('/')[0]).ToString("yyyy-MM-dd")%></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            发&nbsp;布&nbsp;者：</label><%# ((DataRowView)Container.DataItem).Row["MemberID"]%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            区&nbsp;&nbsp;&nbsp;&nbsp;域：</label><%# ((DataRowView)Container.DataItem).Row["AddressValue"]%>
                                    </td>
                                </tr>
                                <tr class="other">
                                    <td>
                                        <label>
                                            电&nbsp;&nbsp;&nbsp;&nbsp;话：</label>
                                        <span class="damask">
                                            <%# ((DataRowView)Container.DataItem).Row["Tel"]%></span>
                                    </td>
                                </tr>
                                <tr class="other">
                                    <td>
                                        <label>
                                            邮&nbsp;&nbsp;&nbsp;&nbsp;箱 ：</label><span class="heras"><%# ((DataRowView)Container.DataItem).Row["Email"]%></span>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <!-- 隔开 -->
                    <div class="cle" style="width: 700px; height: 8px; line-height: 8px; overflow: hidden;
                        font-size: 8px;">
                    </div>
                    <div class="triton">
                        <h1>
                            详细说明</h1>
                        <div class="supdem_detail">
                            <%# Server.HtmlDecode(((DataRowView)Container.DataItem).Row["Content"].ToString())%>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <!-- 隔开 -->
    <!-- 上一篇，下一篇 -->
    <asp:Repeater ID="RepeaterDataUpDown" runat="server" Visible="false">
        <ItemTemplate>
            <div class="pageupdown">
                <%# ((DataRowView)Container.DataItem).Row["Name"]%><a href='<%# ShopUrlOperate.RetUrl("SupplyDemandDetail",((DataRowView)Container.DataItem).Row["ID"]) %>'><%# ((DataRowView)Container.DataItem).Row["Title"]%></a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
