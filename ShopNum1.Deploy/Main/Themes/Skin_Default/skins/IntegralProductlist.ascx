<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data" %>
<div class="precont">
    <div class="all_top">
        <div class="latest_shop1 fl" style="border: none;">
            兑换礼品</div>
    </div>
    <div class="preshow clearfix">
        <asp:Repeater ID="RepeaterProductShow" runat="server">
            <HeaderTemplate>
                <ul class="clearfix">
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <div class="prelist">
                        <a href='<%#ShopUrlOperate.shopDetailHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString(),"ProductIntegral")%>'
                            class="sroceimg">
                            <asp:Image ID="ImageProduct" runat="server" Width="175" Height="175" ImageUrl='<%#Eval("OriginalImge") %>'
                                onerror="javascript:this.src='/ImgUpload/noImage.gif'" />
                        </a>
                        <div class="sname">
                            <a href='<%#ShopUrlOperate.shopDetailHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString(),"ProductIntegral")%>'>
                                <%#Eval("Name").ToString().Length > 16 ? Eval("Name").ToString().Substring(0, 16) : Eval("Name").ToString()%></a>
                        </div>
                        <div class="sprice">
                            市场价：<del>￥<%#Eval("MarketPrice")%></del></div>
                        <div class="srcore">
                            红包：<b><%#Eval("Score")%></b></div>
                    </div>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
        <!--分页 Start-->
        <div class="fenye">
            <!--分页跳转 Start-->
            <div class="page_skip">
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
                            <asp:TextBox ID="TextBoxIndex" runat="server" CssClass="page_input">
                            </asp:TextBox>
                        </td>
                        <td>
                            <span class="fenye3">页</span>
                        </td>
                        <td>
                            <asp:Button ID="ButtonSure" runat="server" Text="确定" CssClass="page_btn" />
                        </td>
                    </tr>
                </table>
            </div>
            <!--//分页跳转 End-->
            <!--分页排序 Start-->
            <div id="pageDiv" runat="server" class="page_sort">
            </div>
            <!--//分页排序 End-->
            <div class="clear">
            </div>
        </div>
        <!--//分页 End-->
    </div>
</div>
