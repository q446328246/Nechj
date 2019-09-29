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
<div class="search_box" style="display: none;">
    <div class="search_box_top">
        文章分类</div>
    <div class="search_box_detail">
        文章一级：<asp:DropDownList ID="DropDownListArticleCategoryCf" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        文章二级：
        <asp:DropDownList ID="DropDownListArticleCategoryCs" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        文章三级：
        <asp:DropDownList ID="DropDownListArticleCt" runat="server">
        </asp:DropDownList>
        <br />
        发布时间：<asp:TextBox ID="TextBoxStartTime" runat="server" class="Wdate" onclick="WdatePicker()"></asp:TextBox>
        -
        <asp:TextBox ID="TextBoxEndTime" runat="server" class="Wdate" onclick="WdatePicker()"></asp:TextBox>
        <br />
        文章标题：<asp:TextBox ID="TextBoxTitle" runat="server"></asp:TextBox>
        关键字：
        <asp:TextBox ID="TextBoxKeywords" runat="server"></asp:TextBox>
        <div class="ser_but">
            <asp:Button ID="ButtonSearch" runat="server" Text="搜索" CssClass="search_buttom1" /></div>
    </div>
</div>
<!-- 搜索结果 -->
<div class="SearchResultBox">
    <h3>
        <asp:Label ID="LabelArticleProductName" runat="server" Text="-全部-"></asp:Label></h3>
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
        <asp:TextBox ID="TextBoxPageNum" CssClass="page_input" MaxLength="4" runat="server"
            onfocus="this.select();"></asp:TextBox>
        <asp:Button ID="ButtonGo" runat="server" Text="" OnClientClick="return Ispost()"
            CssClass="page_btn" />
    </div>
</div>
