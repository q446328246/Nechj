<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data" %>
<style type="text/css">
    .cur
    {
        font-size: 12px;
        font-weight: bold;
        color: #f00;
    }
    .tlh a:visited
    {
        color: #666;
    }
    .tlh a:visited
    {
        text-decoration: underline;
    }
    .tlh a:hover
    {
        color: #f00;
        font-size: 14;
    }
    .tlh a:active
    {
        color: #f00;
        font-weight: bold;
    }
</style>
<script language="javascript" type="text/javascript">
    function Ispost() {
        var value = document.getElementById("<%= TextBoxPageNum.ClientID %>").value;
        if (!isNaN(value)) {
            var index = document.getElementById("<%= LabelPageIndex.ClientID %>").innerHTML;
            var count = document.getElementById("<%= LabelPageCount.ClientID %>").innerHTML;
            if (value != index && parseInt(value) <= parseInt(count) && parseInt(value) > 0) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }
</script>
<script type="text/javascript" src="js/DatePicker/WdatePicker.js"></script>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="search_box">
            <div class="search_box_top">
                商品搜索</div>
            <div class="search_box_detail">
                <%-- <!--商品属性 -->
            <ShopNum1:ProductAttribute ID="ProductAttribute1" runat="server" SkinFilename="ProductAttribute.ascx" />--%>
                <table>
                    <tr>
                        <td>
                            省<span style="padding-left: 23px;">份：</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListRegionCode1" CssClass="areCarge" runat="server"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                        <td>
                            地<span style="padding-left: 23px;">市：</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListRegionCode2" CssClass="areCarge" runat="server"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                        <td>
                            县<span style="padding-left: 23px">市：</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListRegionCode3" CssClass="areCarge" runat="server"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            商品一级：
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListProductGuid1" CssClass="areCarge" runat="server"
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td>
                            商品二级：
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListProductGuid2" CssClass="areCarge" runat="server"
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td>
                            商品三级：
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListProductGuid3" CssClass="areCarge" runat="server"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <asp:Repeater ID="RepeaterBrand" runat="server">
                    <HeaderTemplate>
                        <asp:Literal ID="LiteralBrand" Text="品&nbsp;&nbsp;&nbsp;&nbsp;牌：" runat="server"></asp:Literal>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <span class="tlh">
                            <asp:LinkButton ID="LinkButtonBrand" runat="server" CommandName="LinkButtonClick"
                                CommandArgument='<%#((DataRowView)Container.DataItem).Row["Guid"]%>'> <%#((DataRowView)Container.DataItem).Row["Name"]%></asp:LinkButton>
                        </span>
                    </ItemTemplate>
                </asp:Repeater>
                <div>
                    发布时间：
                    <asp:TextBox ID="TextBoxStartDate" runat="server" class="Wdate areCarge" onclick="WdatePicker()"></asp:TextBox>
                    －
                    <asp:TextBox ID="TextBoxEndDate" runat="server" class="Wdate areCarge" onclick="WdatePicker()"></asp:TextBox>
                    <p>
                        商品名称：<asp:TextBox ID="TextBoxProductName" CssClass="areCarge" runat="server"></asp:TextBox></p>
                    <p class="ser_but" style="padding-left: 62px;">
                        <asp:Button ID="ButtonSearch" CssClass="search_btn" runat="server" Text="商品搜索" /></p>
                </div>
            </div>
        </div>
        <!-- 隔开 -->
        <div class="cle" style="width: 700px; height: 8px; line-height: 8px; overflow: hidden;
            font-size: 8px;">
        </div>
        <!-- 搜索结果 -->
        <div class="latest_shop">
            <div class="all_top">
                <div class="latest_shop1 fl" style="border: none;">
                    <asp:Label ID="LabelProductCategoryName" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <div class="latest_shop_detail">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td rowspan="3" width="101" valign="top">
                                    <div class="photo">
                                        <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                                            <asp:Image ID="Img1" src='<%#((DataRowView)Container.DataItem).Row["originalimage"].ToString().Replace("~","")+"_100x100.jpg"%>'
                                                runat="server" onerror="javascript:this.src='../ImgUpload/noImage.gif'" alt="图片"
                                                Width="90" Height="90" /></a>
                                    </div>
                                </td>
                                <td width="310" class="las_t">
                                    <%-- 商品名：--%><%#((DataRowView)Container.DataItem).Row["Name"]%>
                                </td>
                                <td width="196" rowspan="3">
                                    <p>
                                        <span class="priceon">
                                            <%#((DataRowView)Container.DataItem).Row["ShopPrice"]%></span></p>
                                    <p>
                                        市场价：<span class="line_throw">
                                            <%#((DataRowView)Container.DataItem).Row["MarketPrice"]%>
                                        </span>
                                    </p>
                                </td>
                                <td width="121" class="date">
                                    <%# Convert.ToDateTime(((DataRowView)Container.DataItem).Row["CreateTime"]).ToString("yyyy-MM-dd")%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%--店铺：--%><%#((DataRowView)Container.DataItem).Row["ShopName"]%>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%-- 地区：--%><%#((DataRowView)Container.DataItem).Row["AddressValue"]%>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <!-- 隔开 -->
            <div class="cle" style="width: 700px; height: 8px; line-height: 8px; overflow: hidden;
                font-size: 8px;">
            </div>
            <div class="page" style="margin: 4px; border: 0px;">
                <asp:LinkButton ID="LinkButtonFirst" runat="server">首页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonLast" runat="server">上一页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonNext" runat="server">下一页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonEnd" runat="server">尾页</asp:LinkButton>
                <asp:Label ID="LabelPageIndex" runat="server" Text="1"></asp:Label>/
                <asp:Label ID="LabelPageCount" runat="server" Text="0"></asp:Label>
                <asp:TextBox ID="TextBoxPageNum" runat="server" onfocus="this.select();" Height="15px"
                    Width="30px"></asp:TextBox>
                <asp:Button ID="ButtonGo" runat="server" Text="GO" CssClass="" OnClientClick="return Ispost()" />
            </div>
        </div>
        <!-- 隔开 -->
        <div class="cle" style="width: 700px; height: 8px; line-height: 8px; overflow: hidden;
            font-size: 8px;">
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
