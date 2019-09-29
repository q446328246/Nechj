<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<div class="bBox bBoxnt">
    <h2>
        <div class="fl">团购商品</div>
        <div class="fr">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:DropDownList ID="DropDownListSort" runat="server" AutoPostBack="true" Visible="false">
                            <asp:ListItem Value="CreateTime">上架时间</asp:ListItem>
                            <asp:ListItem Value="GroupCount">销量</asp:ListItem>
                            <asp:ListItem Value="GroupPrice">价格</asp:ListItem>
                            <asp:ListItem Value="VisitCount">浏览量</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>显示方式：</td>
                    <td>
                        <asp:ImageButton ID="ImageButtonList" runat="server" ImageUrl="../Images/productDisplayList.gif" />&nbsp;
                        <asp:ImageButton ID="ImageButtonGrid" runat="server" ImageUrl="../Images/productDisplayGrid.gif" />&nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </h2>
    <div class="content despis">
        <div class="middle clearfix">
        <asp:Panel ID="PanelNoFind" runat="server" Visible="false">
            <p class="nofind">
                没有找到符合条件的商品！
            </p>
            </asp:Panel>
            <asp:Repeater ID="RepeaterDataGrid" runat="server">
                <ItemTemplate>
                    <asp:Literal ID="LiteralProductGuid" runat="server" Text='<%# Eval("id")%>' Visible="false"></asp:Literal>
                    <asp:Literal ID="LiteralShopName" runat="server" Text='<%# Eval("ShopName")%>' Visible="false"></asp:Literal>
                    <asp:Literal ID="LiteralMemLoginID" runat="server" Text='<%# Eval("MemLoginID")%>'
                        Visible="false"></asp:Literal>
                    <div class="integ_cont">
                        <div class="integrate">
                            <div class="pdt_img">
                                <p class="ncs_img">
                                    <a href='<%# GetPageName.RetUrl("ProductIsSpell_Detail",Eval("id"))%>' target="_blank"
                                        title='<%# Eval("Name")%>'>
                                        <asp:Image ID="ImageProduct" runat="server" BorderWidth="0px" Height="150px" ImageUrl='<%# Eval("GroupImg")+"_160x160.jpg"  %>'
                                            onerror="javascript:this.src='Themes/Skin_Default/Images/noImage.gif'" Width="218px" />
                                    </a>
                                </p>
                            </div>
                            <p class="pdt_name">
                                <a href='<%# GetPageName.RetUrl("ProductIsSpell_Detail",Eval("id"))%>' target="_blank" title='<%# Eval("Name")%>'>
                                    <%# Utils.GetUnicodeSubString(Eval("Name").ToString(), 25, "")%>
                                    <asp:Literal ID="LiteralProductName" runat="server" Visible="false" Text='<%# Eval("Name").ToString() %>'></asp:Literal>
                                </a>
                            </p>
                            <p>市场价：<font class="Price"><%# Eval("shopprice")%>元</font></p>
                            <p class="pdt_price">
                                <span class="fl"><strong>￥<asp:Literal ID="LiteralShopPrice" runat="server" Text='<%# Eval("groupprice")%>'></asp:Literal></strong></span>
                                <span class="fr">
                                <a href='<%# GetPageName.RetUrl("ProductIsSpell_Detail",Eval("id"))%>' target="_blank">
                                    <img src="Themes/Skin_Default/Images/scorn.png" /></a></span>
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
                                    <a href='<%# GetPageName.RetUrl("ProductIsSpell_Detail",Eval("id"))%>' target="_blank" title='<%# Eval("Name")%>'>
                                        <asp:Image ID="ImageProduct" runat="server" Height="52px" ImageUrl='<%# Eval("GroupImg")+"_60x60.jpg" %>' Width="52px" onerror="javascript:this.src='Themes/Skin_Default/Images/noImage.gif'" />
                                    </a>
                                </div>
                            </td>
                            <td width="20%" align="left">
                                <span runat="server" visible="false" id="guid"><%# Eval("id") %></span><a href='<%# GetPageName.RetUrl("ProductIsSpell_Detail",Eval("id"))%>'  target="_blank" title='<%# Eval("Name")%>'>
                                    <%# Utils.GetUnicodeSubString(Eval("Name").ToString(), 25, "")%></a>
                            </td>
                            <td width="20%">
                                原价：<font class="Price"><%# Eval("shopprice")%>元</font>
                            </td>
                            <td width="20%">
                                团购价：<strong style="color: #FF0000;"><%# Eval("groupprice")%>元</strong>
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
                <td><span class="fenye1">共</span></td>
                <td><span><asp:Label ID="LabelPageCount" runat="server" Text=""></asp:Label></span></td>
                <td><span class="fenye2">页，到第</span></td>
                <td><asp:TextBox ID="TextBoxIndex" runat="server" CssClass="pro_input"></asp:TextBox></td>
                <td class="fenye_td1"><span class="fenye3">页</span></td>
                <td class="fenye_td2"><asp:Button ID="ButtonSure" runat="server" Text="Button" CssClass="pro_btn" /></td>
            </tr>
        </table>
    </div>
    <div id="pageDiv" runat="server" class="pro_page">
        <div class="black2 ">
            <span class="disabled">< </span><span class="current">1</span><a href="#?page=2">2</a><span
                class="diandian">...</span> <a href="#?page=200">200</a> <a href="#?page=2">></a>
        </div>
    </div>
</div>
