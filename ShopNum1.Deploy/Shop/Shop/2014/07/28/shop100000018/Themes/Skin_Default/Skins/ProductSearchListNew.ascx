<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<div class="strlist_all">
    <h1 class="strlist_title">所有宝贝</h1>
    <div class="strlist_cont">
        <ul class="clearfix">
            <li class="fl">共搜索到<strong><asp:Label ID="LabelSearch" runat="server" Text=""></asp:Label></strong>个符合条件的商品!</li>
            <li class="SearchArea fr">
                关键字：<asp:TextBox ID="TextBoxKeywords" runat="server"></asp:TextBox>&nbsp;&nbsp;
                价格范围：<asp:TextBox ID="TextBoxPriceStart" CssClass="intprice" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPriceStart" runat="server"
                    ControlToValidate="TextBoxPriceStart" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"
                    Display="Dynamic"></asp:RegularExpressionValidator>
                <span>&nbsp;到&nbsp;</span>
                <asp:TextBox ID="TextBoxPriceEnd" CssClass="intprice" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPriceEnd" runat="server"
                    ControlToValidate="TextBoxPriceEnd" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"
                    Display="Dynamic"></asp:RegularExpressionValidator>
                <asp:Button ID="ButtonSearch" runat="server" CssClass="searchen" Text="" />
            </li>
        </ul>
    </div>
</div>
<div class="bBoxnt">
    <div class="serchan">
        <div class="pattern">
            <label>显示方式：</label>
            <asp:ImageButton ID="ImageButtonList" runat="server" ImageUrl="../Images/tabulat.png" />&nbsp;
            <asp:ImageButton ID="ImageButtonGrid" runat="server" ImageUrl="../Images/large_bg.png" />&nbsp;
        </div>
        <div class="pattern">
            <ul>
                <li>排序：</li>
                <li>
                    <asp:LinkButton ID="LinkButtonSales" runat="server" CssClass="as_rise" title="按销量从高到低">
                        销量<i id="ISales" runat="server" class="comSort-d"></i></asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonPrice" runat="server" CssClass="as_rise" title="按价格从低到高">
                        价格<i id="IPrice" runat="server" class="comSort-u"></i></asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonRenqi" runat="server" CssClass="as_rise" title="按人气从高到低">
                        人气<i id="IRenqi" runat="server" class="comSort-d"></i></asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonCreatime" runat="server" CssClass="as_rise" title="按时间从先到后">
                        时间<i id="ICreatime" runat="server" class="comSort-d"></i></asp:LinkButton>
                </li>
            </ul>
        </div>
        <div class="pagenet">
            <asp:Label ID="LabelCurrent" runat="server" Text=""></asp:Label>
            <span>/</span>
            <asp:Label ID="LabelTotal" runat="server" Text=""></asp:Label>
            <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pgup">下一页</asp:LinkButton>
            <asp:LinkButton ID="LinkButtonPrevPage" runat="server" CssClass="pgup">上一页</asp:LinkButton>
        </div>
    </div>
    <div class="content clearfix" style="border: none;">
        <asp:Panel ID="PanelNoFind" runat="server" Visible="false">
            <p class="nofind">没有找到符合条件的商品！</p>
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Repeater ID="RepeaterDataGrid" runat="server">
                    <ItemTemplate>
                        <div class="pruct_zs">
                            <div class="pdt_img">
                                <p class="ncs_img">
                                    <a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>' target="_blank" title='<%# Eval("Name")%>'>
                                        <img id="Img1" alt='<%# Eval("Name")%>' src='<%# Eval("OriginalImage")+"_160x160.jpg"%>'
                                            runat="server" onerror="javascript:this.src='/ImgUpload/noimg.jpg_160x160.jpg'" />
                                    </a>
                                </p>
                            </div>
                            <p class="pdt_name">
                                <a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>' target="_blank" title='<%# Eval("Name")%>'>
                                    <asp:Literal ID="LiteralProductName" runat="server" Text='<%# ShopNum1.Common.Utils.GetUnicodeSubString(Eval("Name").ToString(),26,"") %>'></asp:Literal>
                                </a>
                            </p>
                            <p class="pdt_price">
                                <strong>￥<asp:Literal ID="LiteralGroupPrice" runat="server" Text='<%# Eval("ShopPrice")%>'></asp:Literal>元</strong>
                            </p>
                            <p class="pdtsele_out">
                                已售出：<span><%# Eval("SaleNumber")%></span>件
                            </p>
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
                                            <a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>' target="_blank" title='<%# Eval("Name")%>'>
                                                <asp:Image ID="ImageProduct" runat="server" Height="75px" ImageUrl='<%# Eval("OriginalImage")+"_160x160.jpg" %>'
                                                    Width="75px" onerror="javascript:this.src='/ImgUpload/noimg.jpg_160x160.jpg'" />
                                            </a>
                                            <asp:Literal ID="LiteralProductGuid" runat="server" Text='<%# Eval("guid")%>' Visible="false"></asp:Literal>
                                            <asp:Literal ID="LiteralShopName" runat="server" Text='<%# Eval("ShopName")%>' Visible="false"></asp:Literal>
                                            <asp:Literal ID="LiteralMemLoginID" runat="server" Text='<%# Eval("MemLoginID")%>'
                                                Visible="false"></asp:Literal>
                                        </div>
                                    </td>
                                    <td style="width: 220px;">
                                        <p class="pdt_name">
                                            <a href='<%# GetPageName.RetUrl("ProductDetail",Eval("guid"))%>' target="_blank" title='<%# Eval("Name")%>'>
                                                <asp:Literal ID="LiteralProductName" runat="server" 
                                                Text='<%#ShopNum1.Common.Utils.GetUnicodeSubString(Eval("Name").ToString(),30,"") %>'></asp:Literal>
                                            </a>
                                        </p>
                                    </td>
                                    <td width="17%">
                                        <p class="pdtsele_out">已售出：<span><%# Eval("SaleNumber")%></span>件</p>
                                    </td>
                                    <td width="18%">
                                        <p>
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
