<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
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
<!-- 搜索框 -->
<div class="search_box">
    <div class="search_box_top">
        店铺搜索</div>
    <div class="search_box_detail">
        <table>
            <tr>
                <td>
                    省<span style="padding-left: 23px">份</span>：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListRegionCode1" CssClass="areCarge" runat="server"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
                <td>
                    地<span style="padding-left: 23px">市：</span>
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
                    店铺一级：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListShopCategoryCode1" CssClass="areCarge" runat="server"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
                <td>
                    店铺二级：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListShopCategoryCode2" CssClass="areCarge" runat="server"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
                <td>
                    店铺三级：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListShopCategoryCode3" CssClass="areCarge" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        店铺名称：
        <asp:TextBox ID="TextBoxShopName" CssClass="areCarge" runat="server"></asp:TextBox>
        会员名：
        <asp:TextBox ID="TextBoxMemberID" CssClass="areCarge" runat="server"></asp:TextBox>
        <br />
        <div class="ser_but" style="padding-left: 66px;">
            <asp:Button ID="ButtonSearch" runat="server" Text="店铺搜索" CssClass="search_btn" />
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
            <asp:Label ID="LabelShopProductName" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <div class="latest_shop_detail">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="80" valign="top" style="border-right: 1px dashed #e1e1e1; background: #fcfcfc;">
                            <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["MemLoginID"].ToString()) %>'
                                target="_blank">
                                <asp:Image ID="Img1" src='<%# ((DataRowView)Container.DataItem).Row["Banner"].ToString().Replace("~","")%>'
                                    runat="server" onerror="javascript:this.src='../ImgUpload/noImage.gif'" Width="90"
                                    Height="90" /></a>
                        </td>
                        <td rowspan="2">
                            <span class="las_t"><a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["MemLoginID"].ToString()) %>'
                                target="_blank">
                                <%# ((DataRowView)Container.DataItem).Row["ShopName"]%></a></span> <span id="spanMemLoginID"
                                    runat="server" visible="false">
                                    <%# ((DataRowView)Container.DataItem).Row["MemLoginID"]%></span>
                            <br />
                            店主：<%# ((DataRowView)Container.DataItem).Row["MemLoginID"]%>
                            <asp:Image ID="ImageReputation" runat="server" />
                            <br />
                            主营宝贝：<asp:Repeater ID="RepeaterProduct" runat="server">
                                <ItemTemplate>
                                    <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                                        <%#((DataRowView)Container.DataItem).Row["Name"]%></a>
                                </ItemTemplate>
                            </asp:Repeater>
                            <br />
                            所在地区：
                            <%# ((DataRowView)Container.DataItem).Row["AddressValue"]%>
                            <br />
                            店铺介绍：<%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["shopIntroduce"].ToString(),190,"...")%>
                        </td>
                    </tr>
                    <tr>
                        <td width="80" valign="top" style="border-right: 1px dashed #e1e1e1; background: #fcfcfc;">
                            <asp:Repeater ID="RepeaterImg" runat="server">
                                <ItemTemplate>
                                    <img id="EnsureImg" alt="图片" width="16" height="17" src='<%#((DataRowView)Container.DataItem).Row["ImagePath"] %>'
                                        runat="server" />
                                </ItemTemplate>
                            </asp:Repeater>
                            <br />
                            <a href='<%#ShopUrlOperate.GetShopMessageBoardUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString()) %>'>
                                留言</a> <a href='<%#ShopUrlOperate.GetShopUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString(),"ProductBooking") %>'
                                    target="_blank">预约</a>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:HiddenField ID="HiddenFieldReputation" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ShopReputation"]%>' />
        </ItemTemplate>
    </asp:Repeater>
    <div class="page" style="border: 0px; margin: 4px;">
        <asp:LinkButton ID="LinkButtonFirst" runat="server">首页</asp:LinkButton>
        <asp:LinkButton ID="LinkButtonLast" runat="server">上一页</asp:LinkButton>
        <asp:LinkButton ID="LinkButtonNext" runat="server">下一页</asp:LinkButton>
        <asp:LinkButton ID="LinkButtonEnd" runat="server">尾页</asp:LinkButton>
        <asp:Label ID="LabelPageIndex" runat="server" Text="1"></asp:Label>/
        <asp:Label ID="LabelPageCount" runat="server" Text="0"></asp:Label>
        <asp:TextBox ID="TextBoxPageNum" runat="server" onfocus="this.select();" Height="15px"
            Width="30px"></asp:TextBox>
        <asp:Button ID="ButtonGo" runat="server" Text="Go" OnClientClick="return Ispost()"
            CssClass="bnt1" />
    </div>
</div>
