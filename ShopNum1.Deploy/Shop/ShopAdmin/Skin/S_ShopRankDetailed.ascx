<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="tjsp_mian">
    <p class="ptitle">
        <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><a href="S_ShowShopRank.aspx">店铺信息</a><span
            class="breadcrume_icon">>></span> <span class="breadcrume_text">店铺等级详细</span></p>
    <asp:Repeater ID="RepeaterShow" runat="server">
        <ItemTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
                <tr>
                    <th colspan="2" scope="col">
                        店铺等级详细
                    </th>
                </tr>
                <tr>
                    <td class="bordleft" width="130">
                        店铺等级名称：
                    </td>
                    <td class="bordrig">
                        <%#Eval("Name") %>
                    </td>
                </tr>
                <tr>
                    <td class="bordleft" width="130">
                        最大商品数量：
                    </td>
                    <td class="bordrig">
                        <%#Eval("MaxProductCount") %>
                    </td>
                </tr>
                <tr>
                    <td class="bordleft" width="130">
                        等级图片：
                    </td>
                    <td class="bordrig">
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Pic") %>' />
                    </td>
                </tr>
                <tr>
                    <td class="bordleft" width="130">
                        收费标准：
                    </td>
                    <td class="bordrig">
                        <%#Eval("price") %>元/年
                    </td>
                </tr>
                <tr>
                    <td class="bordleft" width="130">
                        最大资讯数量：
                    </td>
                    <td class="bordrig">
                        <%#Eval("MaxArticleCout") %>
                    </td>
                </tr>
                <tr>
                    <td class="bordleft" width="130">
                        最大视频数量：
                    </td>
                    <td class="bordrig">
                        <%#Eval("MaxVedioCount") %>
                    </td>
                </tr>
                <tr>
                    <td class="bordleft" width="130">
                        可用模板：
                    </td>
                    <td class="bordrig">
                        <asp:HiddenField ID="HiddenFieldShopTemplate" runat="server" Value='<%# Eval("shopTemplate") %>' />
                        <table>
                            <asp:Repeater ID="RepeaterData" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <a href='<%#"/Template/ShopTemplate/" + Eval("TemplateImg") %>' target="_blank">
                                                <img src='<%# Page.ResolveUrl("/Template/ShopTemplate/" + Eval("TemplateImg")) %>'
                                                    width="100px" height="150px" alt="" />
                                            </a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
    <div style="margin: 20px 0px 50px 0px; text-align: center;">
        <asp:Button ID="ButtonBackList" runat="server" Text="返回" CssClass="baocbtn" />
    </div>
</div>
<asp:HiddenField ID="HiddenFieldMember" runat="server" Value="no" />
