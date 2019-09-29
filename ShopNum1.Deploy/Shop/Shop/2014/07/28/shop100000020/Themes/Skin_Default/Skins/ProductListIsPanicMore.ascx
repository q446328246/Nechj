<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<div class="bBox">
    <h2>
        <span class="fl">抢购商品</span><span class="fr">
            <table width="300" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        排列方式：
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListSort" runat="server" AutoPostBack="true">
                            <asp:ListItem Value="ModifyTime">上架时间</asp:ListItem>
                            <asp:ListItem Value="SaleNumber">销量</asp:ListItem>
                            <asp:ListItem Value="ShopPrice">价格</asp:ListItem>
                            <asp:ListItem Value="ClickCount">浏览量</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        显示方式：
                    </td>
                    <td>
                        <asp:ImageButton ID="ImageButtonList" runat="server" ImageUrl="../Images/productDisplayList.gif" />&nbsp;
                        <asp:ImageButton ID="ImageButtonGrid" runat="server" ImageUrl="../Images/productDisplayGrid.gif" />&nbsp;
                    </td>
                </tr>
            </table>
        </span>
    </h2>
    <div class="content product-img">
        <div class="middle clearfix">
            <asp:Repeater ID="RepeaterDataGrid" runat="server">
                <ItemTemplate>
                    <div class="a2 clearfix" style="float: left; height: 200px;">
                        <table width="170" border="0" cellpadding="2" cellspacing="3" style="float: left">
                            </td><tr>
                                <td align="center">
                                    <a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>' target="_blank">
                                        <asp:Image ID="ImageProduct" runat="server" Height="130px" ImageUrl='<%# Eval("OriginalImage") %>'
                                            Width="140px" />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>' target="_blank">
                                     <%# Utils.GetUnicodeSubString(Eval("Name").ToString(), 25, "")%> </a>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                  <%--  结束时间：<%# Eval("PanicBuyEndTime")%><br />
                                    还剩数量:<%# ProductListIsPanic.GetCount((Eval("PanicBuyCount")), (Eval("SaledNum")))%><br />
                                    <asp:Literal ID="LiteralLastBuyInfo" runat="server" Text='<%# ProductListIsPanic.SetLastBuyTime(Eval("MemberLoginID"),Eval("LastTime"))%>'
                                        Visible="false"></asp:Literal>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                </td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="RepeaterDataList" runat="server">
                <ItemTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-bottom: 1px solid #f1f1f1">
                        <tr>
                            <td align="left" class="vote" width="10%" rowspan="3">
                                <div class="ProductImg">
                                    <a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>' target="_blank">
                                        <asp:Image ID="ImageProduct" runat="server" Height="52px" ImageUrl='<%# Eval("OriginalImage") %>'
                                            Width="52px" />
                                    </a>
                                </div>
                            </td>
                            <td width="20%" align="left">
                                <%--<asp:CheckBox ID="CheckBoxCompare" runat="server" />--%><span runat="server" visible="false"
                                    id="guid"><%# Eval("Guid") %></span><a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>'
                                        target="_blank">
                                        <%# Utils.GetUnicodeSubString(Eval("Name").ToString(), 25, "")%></a>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                本店价格：<font class="StorePrice"><%# Eval("ShopPrice")%></font>
                            </td>
                        </tr>
                       <%-- <tr>
                            <td align="left">
                                结束时间：<%# Eval("PanicBuyEndTime")%>
                                还剩数量:<%# ProductListIsPanic.GetCount((Eval("PanicBuyCount")), (Eval("SaledNum")))%><br />
                                <asp:Literal ID="LiteralLastBuyInfo" runat="server" Text='<%# ProductListIsPanic.SetLastBuyTime(Eval("MemberLoginID"),Eval("LastTime"))%>'></asp:Literal>
                            </td>
                        </tr>--%>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>
<!-- 分页部分-->
<div class="pager">
    <asp:Label ID="LabelPageMessage" runat="server"></asp:Label>
    &nbsp;<asp:HyperLink ID="lnkFirst" runat="server"><span class="fpager">[ 首页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkPrev" runat="server"><span class="fpager">| 上一页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkNext" runat="server"><span class="fpager">| 下一页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkLast" runat="server"><span class="fpager">| 末页 ]</span></asp:HyperLink>
    &nbsp;<span class="fpager">转到
        <asp:Literal ID="lnkTo" runat="server" />
        页</span>
</div>
