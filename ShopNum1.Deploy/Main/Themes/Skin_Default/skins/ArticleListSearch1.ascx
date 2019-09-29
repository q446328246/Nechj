<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
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
<script type="text/javascript" src="js/DatePicker/WdatePicker.js"></script>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<h3>
    信息搜索</h3>
<div class="search_bonx_detail">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <p>
                <span>文章一级：</span>
                <asp:DropDownList ID="DropDownListArticleCategoryCf" CssClass="artic_select" runat="server"
                    AutoPostBack="True">
                </asp:DropDownList>
            </p>
            <p>
                <span>文章二级：</span>
                <asp:DropDownList ID="DropDownListArticleCategoryCs" CssClass="artic_select" runat="server"
                    AutoPostBack="True">
                </asp:DropDownList>
            </p>
            <p>
                <span>文章三级：</span>
                <asp:DropDownList ID="DropDownListArticleCt" CssClass="artic_select" runat="server">
                </asp:DropDownList>
            </p>
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
        <span>发布时间：</span>
        <asp:TextBox ID="TextBoxStartTime" runat="server" class="Wdate artic_select" onclick="WdatePicker()"></asp:TextBox>
        <asp:TextBox ID="TextBoxEndTime" runat="server" class="Wdate Wdate1 artic_select"
            onclick="WdatePicker()"></asp:TextBox>
    </p>
    <p>
        <span>文章标题：</span>
        <asp:TextBox ID="TextBoxTitle" CssClass="artic_select" runat="server"></asp:TextBox>
    </p>
    <p>
        <span class="atircl_key">关键字：</span>
        <asp:TextBox ID="TextBoxKeywords" CssClass="artic_select" runat="server"></asp:TextBox>
    </p>
    <div class="ser_but">
        <asp:Button ID="ButtonSearch" runat="server" Text="" CssClass="search_butom1" />
    </div>
</div>
<!-- 搜索结果 -->
<div class="latest_shop" style="display: none;">
    <div class="all_top">
        <div class="latest_shop1 fl">
            <asp:Label ID="LabelArticleProductName" runat="server" Text="-全部-"></asp:Label>
        </div>
    </div>
    <div class="article_list">
        <ul>
            <asp:Repeater ID="RepeaterShow" runat="server">
                <ItemTemplate>
                    <li>·<a href='<%# ShopUrlOperate.RetUrl("ArticleDetail",((DataRowView)Container.DataItem).Row["Guid"]) %>'
                        target="_blank">
                        <%# ((DataRowView)Container.DataItem).Row["Title"]%></a> <span class="date_right">
                            <%# Convert.ToDateTime(((DataRowView)Container.DataItem).Row["CreateTime"]).ToString("yyyy-MM-dd") %>
                        </span></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <div class="page">
        <asp:LinkButton ID="LinkButtonFirst" runat="server">首页</asp:LinkButton>
        <asp:LinkButton ID="LinkButtonLast" runat="server">上一页</asp:LinkButton>
        <asp:LinkButton ID="LinkButtonNext" runat="server">下一页</asp:LinkButton>
        <asp:LinkButton ID="LinkButtonEnd" runat="server">尾页</asp:LinkButton>
        <asp:Label ID="LabelPageIndex" runat="server" Text="1"></asp:Label>/
        <asp:Label ID="LabelPageCount" runat="server" Text="0"></asp:Label>
        <asp:TextBox ID="TextBoxPageNum" MaxLength="4" runat="server" onfocus="this.select();"
            Height="15px" Width="30px"></asp:TextBox>
        <asp:Button ID="ButtonGo" runat="server" Text="Go" OnClientClick="return Ispost()"
            CssClass="bnt3" />
    </div>
</div>
