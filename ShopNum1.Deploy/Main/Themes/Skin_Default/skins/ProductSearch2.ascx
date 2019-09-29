<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Import Namespace="System.Data" %>
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
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            商品分类查询
            <asp:DropDownList ID="DropDownListProductGuid1" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownListProductGuid2" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownListProductGuid3" runat="server">
            </asp:DropDownList>
        </ContentTemplate>
    </asp:UpdatePanel>
    商品名称：
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            发布时间:
            <asp:TextBox ID="TextBoxStartDate" runat="server" CssClass="allinput1"></asp:TextBox>
            <img id="imgCalendarSReplyTime1" alt="UserName" src="~/Main/images/Calendar.png"
                style="width: 16px; height: 18px; position: relative; top: 4px" /><asp:RegularExpressionValidator
                    ID="RegularExpressionValidatorStartDate" runat="server" ControlToValidate="TextBoxStartDate"
                    Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
            &nbsp;<ShopNum1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxStartDate"
                PopupButtonID="imgCalendarSReplyTime1" CssClass="ajax__calendar" />
            <asp:TextBox ID="TextBoxEndDate" runat="server" CssClass="allinput1"></asp:TextBox>
            <img id="imgCalendarSReplyTime2" alt="UserName" src="~/Main/images/Calendar.png"
                style="width: 16px; height: 18px; position: relative; top: 4px" /><asp:RegularExpressionValidator
                    ID="RegularExpressionValidatorStartDate0" runat="server" ControlToValidate="TextBoxEndDate"
                    Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
            &nbsp;<ShopNum1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxEndDate"
                PopupButtonID="imgCalendarSReplyTime2" CssClass="ajax__calendar" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:TextBox ID="TextBoxProductName" runat="server" CssClass="input1"></asp:TextBox>
    <br />
    <asp:Button ID="ButtonSearch" runat="server" Text="搜索" CssClass="search_btn" />
</div>
<div class="aBox">
    <h2>
        <span class="right"></span>商品搜索</h2>
    <div class="content">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <img id="Img1" src='<%#((DataRowView)Container.DataItem).Row["ThumbImage"]%>' runat="server"
                                alt="图片" width="100" height="100" />
                            <%# ((DataRowView)Container.DataItem).Row["SmallImage"]%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            商品名：<%# ((DataRowView)Container.DataItem).Row["Name"]%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            上架时间：<%# ((DataRowView)Container.DataItem).Row["CreateTime"]%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            店铺：<%# ((DataRowView)Container.DataItem).Row["ShopName"]%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            市场价：<%# ((DataRowView)Container.DataItem).Row["MarketPrice"] %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            地区：<%#  ((DataRowView)Container.DataItem).Row["AddressValue"]%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            此店价：<%# ((DataRowView)Container.DataItem).Row["ShopPrice"]%>
                        </td>
                    </tr>
                    <tr>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
        <asp:DataList ID="DataListData" runat="server" RepeatColumns="5">
            <ItemTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <img id="Img1" src='' runat="server" alt="图片" width="100" height="100" onerror="javascript:this.src='../ImgUpload/noImage.gif'" />
                            <%# ((DataRowView)Container.DataItem).Row["SmallImage"]%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            商品名：<%# ((DataRowView)Container.DataItem).Row["Name"]%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            上架时间：<%# ((DataRowView)Container.DataItem).Row["CreateTime"]%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            店铺：<%# ((DataRowView)Container.DataItem).Row["ShopName"]%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            市场价：<%# ((DataRowView)Container.DataItem).Row["MarketPrice"] %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            地区：<%#  ((DataRowView)Container.DataItem).Row["AddressValue"]%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            此店价：<%# ((DataRowView)Container.DataItem).Row["ShopPrice"]%>
                        </td>
                    </tr>
                    <tr>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
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
