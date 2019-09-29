<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopNewWebControl" %>
<div class="bBox bBoxnt">
    <h2>
        <span class="fl">抢购商品</span><span class="fr">
            <table width="300" border="0" cellpadding="0" cellspacing="0" style="display: none;">
                <tr>
                    <td style="color: #4D4D4D; font-size: 12px;">
                        排列方式：
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListSort" runat="server" AutoPostBack="true">
                            <asp:ListItem Value="ModifyTime">上架时间</asp:ListItem>
                            <asp:ListItem Value="SaleNumber">销量</asp:ListItem>
                            <asp:ListItem Value="MarketPrice">价格</asp:ListItem>
                            <asp:ListItem Value="ClickCount">浏览量</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="color: #4D4D4D; font-size: 12px;">
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
    <div class="content product-img" style="border:none;">
        <div class="middle clearfix">
         <asp:Panel ID="PanelNoFind" runat="server" Visible="false">
            <p class="nofind">
                没有找到符合条件的商品！
            </p>
            </asp:Panel>
            <asp:Repeater ID="RepeaterDataGrid" runat="server">
                <ItemTemplate>
                    <asp:Literal ID="LiteralProductGuid" runat="server" Text='<%# Eval("guid")%>' Visible="false"></asp:Literal>
                    <asp:Literal ID="LiteralShopName" runat="server" Text='<%# Eval("ShopName")%>' Visible="false"></asp:Literal>
                    <asp:Literal ID="LiteralMemLoginID" runat="server" Text='<%# Eval("MemLoginID")%>'
                        Visible="false"></asp:Literal>
                    <div class="scratch">
                        <div class="pruct_zs">
                            <div class="pdt_img">
                                <p class="ncs_img">
                                    <a href='<%# GetPageName.RetUrl("ProductIsPanic_Detail",Eval("guid"))%>' target="_blank"
                                        title='<%# Eval("Name")%>'>
                                        <asp:Image ID="ImageProduct" runat="server" ImageUrl='<%# Eval("OriginalImage")+"_160x160.jpg"%>'
                                            onerror="javascript:this.src='/ImgUpload/noimg.jpg_160x160.jpg'" />
                                    </a>
                                </p>
                            </div>
                            <p class="pdt_name">
                                <a href='<%# GetPageName.RetUrl("ProductIsPanic_Detail",Eval("guid"))%>' target="_blank"
                                    title='<%# Eval("Name")%>'>
                                    <%# Utils.GetUnicodeSubString(Eval("Name").ToString(), 25, "")%>
                                    <asp:Literal ID="LiteralProductName" runat="server" Visible="false" Text='<%# Eval("Name").ToString() %>'></asp:Literal>
                                </a>
                            </p>
                            <p class="pdt_price">
                                抢购价：<strong>￥<asp:Literal ID="LiteralShopPrice" runat="server" Text='<%# Eval("shopprice")%>'></asp:Literal></strong>
                               
                            </p>
                           
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="RepeaterDataList" runat="server">
                <ItemTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-bottom: 1px solid #f1f1f1">
                        <tr>
                            <td align="left" class="vote" width="10%">
                                <div class="ProductImg">
                                    <a href='<%# GetPageName.RetUrl("ProductIsPanic_Detail",Eval("guid"))%>' target="_blank"
                                        title='<%# Eval("Name")%>'>
                                        <asp:Image ID="ImageProduct" runat="server" Height="52px" ImageUrl='<%# Eval("OriginalImage") %>'
                                            Width="52px" onerror="javascript:this.src='Themes/Skin_Default/Images/noImage.gif'" />
                                    </a>
                                </div>
                            </td>
                            <td width="20%" align="left">
                               <span runat="server"
                                    visible="false" id="guid"><%# Eval("Guid") %></span><a href='<%# GetPageName.RetUrl("ProductIsPanic_Detail",Eval("guid"))%>'
                                        target="_blank" title='<%# Eval("Name")%>'>
                                        <%# Utils.GetUnicodeSubString(Eval("Name").ToString(), 25, "")%></a>
                            </td>
                            <td width="20%">
                                市场价：<font class="Price"><%# Eval("MarketPrice")%>元</font>
                            </td>
                            <td width="20%">
                                抢购价：<font style="color: #FF0000; font-weight: bold;"><%# Eval("PanicPrice")%>元</font>
                            </td>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>

 <!--分页-->
<div class="fenye">
    <div class="lambert">
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    <span class="fenye1">共</span>
                </td>
                <td>
                    <span>
                        <asp:Label ID="LabelPageCount" runat="server" Text=""></asp:Label></span>
                </td>
                <td>
                    <span class="fenye2">页，到第</span>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxIndex" runat="server" CssClass="pro_input">
                    </asp:TextBox>
                </td>
                <td style="*width: 18px; width: 18px\9;">
                    <span class="fenye3">页</span>
                </td>
                <td style="*width: 42px; width: 42px\9; padding-left: 0px\9; *padding-left: 18px;">
                    <asp:Button ID="ButtonSure" runat="server" Text="Button" CssClass="pro_btn" />
                </td>
            </tr>
        </table>
    </div>
    <div id="pageDiv" runat="server" class="pro_page">
        <div class="black2 " style="float: right; width: 210px; text-align: right;">
            <span class="disabled">< </span><span class="current">1</span> <a href="#?page=2">2</a><span
                class="diandian">...</span> <a href="#?page=200">200</a> <a href="#?page=2">></a>
        </div>
    </div>
</div>
