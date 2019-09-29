<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
--%>
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
<div class="searchlist">
    <h2>
        <span class="right"></span>商品搜索</h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            地区分级查询
            <asp:DropDownList ID="DropDownListRegionCode1" runat="server" AutoPostBack="true">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownListRegionCode2" runat="server" AutoPostBack="true">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownListRegionCode3" runat="server" AutoPostBack="true">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownListRegionCode4" runat="server">
            </asp:DropDownList>
        </ContentTemplate>
    </asp:UpdatePanel>
    品牌
    <asp:Repeater ID="RepeaterDataBrand" runat="server">
        <ItemTemplate>
            <a>
                <%#((DataRowView)Container.DataItem).Row["BrandGuid"]%><%#((DataRowView)Container.DataItem).Row["BrandName"]%></a>
        </ItemTemplate>
    </asp:Repeater>
    <br />
    分类：
    <asp:Repeater ID="RepeaterDataCategory" runat="server">
        <ItemTemplate>
            <a>
                <%#((DataRowView)Container.DataItem).Row["Name"]%><%#((DataRowView)Container.DataItem).Row["Code"]%></a>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="aBox">
    <div class="content">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <table width="100%">
                    <tr>
                        <td rowspan="4">
                            <img id="Img1" src='' runat="server" alt="图片" width="100" height="100" />
                            <%# ((DataRowView)Container.DataItem).Row["SmallImage"]%>
                        </td>
                        <td colspan="2" align="left">
                            商品名：<%# ((DataRowView)Container.DataItem).Row["Name"]%>
                        </td>
                        <td align="left">
                            上架时间：<%# ((DataRowView)Container.DataItem).Row["CreateTime"]%>
                        </td>
                    </tr>
                    <tr>
                        <td width="80px;">
                            店铺：<%# ((DataRowView)Container.DataItem).Row["ShopName"]%>
                        </td>
                        <td align="left">
                            市场价：<%# ((DataRowView)Container.DataItem).Row["MarketPrice"] %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            地区：<%#  ((DataRowView)Container.DataItem).Row["AddressValue"]%>
                        </td>
                        <td width="450" style="text-align: left; text-indent: 24px;">
                            此店价：<%# ((DataRowView)Container.DataItem).Row["ShopPrice"]%>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
<div class="pager">
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
