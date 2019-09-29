<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<div class="strlist strlist_all str_padt">
    <div class="strlist_title">所有宝贝</div>
    <div class="strlist_cont">
        <ul>
            <li class="fl">共搜索到<strong>42</strong>个符合条件的商品!</li>
            <li class="fr">关键字：<asp:TextBox ID="TextBoxKeywords" runat="server"></asp:TextBox>&nbsp;&nbsp;
                价格范围：<asp:TextBox ID="TextBoxPriceStart" CssClass="intprice" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPriceStart" runat="server"
                    ControlToValidate="TextBoxPriceStart" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"
                    Display="Dynamic"></asp:RegularExpressionValidator>
                <span style="padding: 0 2px;">到</span><asp:TextBox ID="TextBoxPriceEnd" CssClass="intprice"
                    runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPriceEnd" runat="server"
                    ControlToValidate="TextBoxPriceEnd" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"
                    Display="Dynamic"></asp:RegularExpressionValidator>
                <asp:Button ID="ButtonSearch" runat="server" CssClass="searchen" Text="" />
            </li>
        </ul>
    </div>
</div>
<div class="bBox bBoxnt">
    <div class="sercher_list serchan">
        <div class="pattern">
            <label>显示方式：</label>
            <asp:ImageButton ID="ImageButtonList" runat="server" ImageUrl="../Images/tabulat.png" />&nbsp;
            <asp:ImageButton ID="ImageButtonGrid" runat="server" ImageUrl="../Images/large_bg.png" />&nbsp;
        </div>
        <div class="pattern">
            <ul>
                <li>排序：</li>
                <li><a class="as_rise as_down" href="#">销量</a><a class="as_rise" href="#">价格</a><a
                    class="as_rise" href="#">人气</a><a class="as_rise" href="#">时间</a></li>
            </ul>
        </div>
        <div class="pagenet">
            1/5
            <input name="upnext" class="pgup pgnext" value="上一页" id="upnext" />
            <input name="upnext" value="下一页" class="pgup" id="Text1" />
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="false">
        <ContentTemplate>
            <ul class="shoplisttitle">
                <li style="display: none;">商品分类：
                    <asp:DropDownList ID="DropDownListProductSeriesCode1" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownListProductSeriesCode2" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownListProductSeriesCode3" runat="server">
                    </asp:DropDownList>
                </li>
                <li id="show">&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
                    &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
                    &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 排列方式：
                    <asp:DropDownList ID="DropDownListSort" runat="server" AutoPostBack="true">
                        <asp:ListItem Value="ModifyTime">上架时间</asp:ListItem>
                        <asp:ListItem Value="SaleNumber">销量</asp:ListItem>
                        <asp:ListItem Value="ShopPrice">价格</asp:ListItem>
                        <asp:ListItem Value="ClickCount">浏览量</asp:ListItem>
                    </asp:DropDownList>
                </li>
            </ul>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="content clearfix" style="border: none;">
        <div class="middle">
            <p class="nofind">
                没有找到符合条件的商品！
            </p>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
                <ContentTemplate>
                    <asp:Repeater ID="RepeaterDataGrid" runat="server">
                        <ItemTemplate>
                            <div class="pruct_zs">
                                <div class="pdt_img">
                                    <p class="ncs_img">
                                        <a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>' target="_blank"
                                            title='<%# Eval("Name")%>'>
                                            <img id="Img1" borderwidth="1px" alt='<%# Eval("Name")%>' src='<%# Eval("OriginalImage")%>'
                                                runat="server" onerror="javascript:this.src='Themes/Skin_Default/Images/noImage.gif'"
                                                style="width: 160px; height: 160px" />
                                        </a>
                                    </p>
                                </div>
                                <p class="pdt_name">
                                    <a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>' target="_blank"
                                        title='<%# Eval("Name")%>'>
                                        <asp:Literal ID="LiteralProductName" runat="server" Text='<%# ShopNum1.Common.Utils.GetUnicodeSubString(Eval("Name").ToString(),26,"") %>'></asp:Literal>
                                    </a>
                                </p>
                                <p class="pdt_price">
                                    <strong>￥<asp:Literal ID="LiteralGroupPrice" runat="server" Text='<%# Eval("ShopPrice")%>'></asp:Literal>元</strong>
                                </p>
                                <p class="pdtsele_out">
                                    已售出：<span class="span">100000</span>件</p>
                                <%--<p class="pdt_but">
                                        <span class="fl"><a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>' target="_blank">
                                            <img src="Themes/Skin_Default/Images/Buy.gif" />
                                        </a></span><span class="fr" style="padding-right: 6px;"></span>
                                    </p>--%>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="RepeaterDataList" runat="server">
                        <ItemTemplate>
                            <div class="prdct_entry">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left" width="18%">
                                            <div class="small_pict">
                                                <a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>' target="_blank"
                                                    title='<%# Eval("Name")%>'>
                                                    <asp:Image ID="ImageProduct" runat="server" Height="75px" ImageUrl='<%# Eval("OriginalImage") %>'
                                                        Width="75px" />
                                                </a>
                                                <asp:Literal ID="LiteralProductGuid" runat="server" Text='<%# Eval("guid")%>' Visible="false"></asp:Literal>
                                                <asp:Literal ID="LiteralShopName" runat="server" Text='<%# Eval("ShopName")%>' Visible="false"></asp:Literal>
                                                <asp:Literal ID="LiteralMemLoginID" runat="server" Text='<%# Eval("MemLoginID")%>'
                                                    Visible="false"></asp:Literal>
                                            </div>
                                        </td>
                                        <td style="width: 220px;">
                                            <p class="pdt_name">
                                                <a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>' target="_blank"
                                                    title='<%# Eval("Name")%>'>
                                                    <asp:Literal ID="LiteralProductName" runat="server" Text='<%#ShopNum1.Common.Utils.GetUnicodeSubString(Eval("Name").ToString(),30,"") %>'></asp:Literal></a>
                                            </p>
                                        </td>
                                        <td width="17%">
                                            <p class="pdtsele_out">
                                                已售出：<span class="span">100000</span>件</p>
                                        </td>
                                        <td width="18%">
                                            <p class="pdt_price">
                                                <strong>￥<asp:Literal ID="LiteralGroupPrice" runat="server" Text='<%# Eval("ShopPrice")%>'></asp:Literal></strong>
                                            </p>
                                        </td>
                                        <td width="17%">
                                            <a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>' target="_blank">
                                                <img src="Themes/Skin_Default/Images/clbuy.png" />
                                            </a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="bottom">
            <span class="left"></span><span class="right"></span>
        </div>
    </div>
</div>
<!-- 分页部分-->
<div class="pager" style="display: none;">
    <asp:Label ID="LabelPageMessage" runat="server"></asp:Label>
    &nbsp;<asp:HyperLink ID="lnkFirst" runat="server"><span class="fpager">[ 首页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkPrev" runat="server"><span class="fpager">| 上一页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkNext" runat="server"><span class="fpager">| 下一页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkLast" runat="server"><span class="fpager">| 末页 ]</span></asp:HyperLink>
    &nbsp;<span class="fpager">转到<asp:Literal ID="lnkTo" runat="server" />页</span>
</div>
