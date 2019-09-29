<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript">
    $(function () {
        var objDate = new Date();

        var dateEnd = new Date($("#ThemesProduct_ctl00_HiddenEndDate").val().replace(/-/g, "\/"));
        if (objDate > dateEnd) {
            $(".fenye").hide();
            $("#ThemeImages").hide();
            $("#ThemeProducts").hide();
            $("#ThemeEnd").show();
            setTimeout("setLoginout()", 1000);
        }
    });
    function setLoginout() {
        location.href = "Default.aspx";
    }

</script>
<div id="ThemeEnd" style="display: none; text-align: center; font-family: 微软雅黑; font-size: 20px;
    font-weight: bold; color: #FF6600;">
    活动已结束！</div>
<div class="ThemeAdv" id="ThemeImages">
    <asp:Image ID="ImageTheme" runat="server" Width="1190px" />
</div>
<div class="ThemeBox clearfix" id="ThemeProducts">
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <%# (Container.ItemIndex+1)%5==0?"<div class=\"ThemeList LastList\">":"<div class=\"ThemeList\">" %>
            <div class="ThemeTitle">
            </div>
            <div class="ThemeImg">
                <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["ProductGuid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() ) %>'
                    target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["ProductName"]%>'>
                    <img src='<%# Eval("ProductImage")%>_160x160.jpg' onerror="javascript:this.src='/ImgUpload/noimg.jpg_160x160.jpg'" /></a>
            </div>
            <div class="ThemeInfo">
                <div class="clearfix">
                    <span class="curPrice fl">现价:￥<i><%#Eval("ProductPrice")%></i></span> <span class="oriPrice fr"
                        style="display: none;"><i>原价</i>:120</span>
                </div>
                <div class="intro">
                    <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["ProductGuid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() ) %>'
                        target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["ProductName"]%>'>
                        <%# ShopNum1.Common.Utils.GetUnicodeSubString(Eval("ProductName").ToString(), 48, "")%></a></div>
            </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
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
                    <asp:Button ID="ButtonSure" runat="server" Text="Button" CssClass="page_btn" />
                </td>
            </tr>
        </table>
    </div>
    <!--//分页跳转 End-->
    <!--分页排序 Start-->
    <div id="pageDiv" runat="server" class="page_sort">
        <span class="disabled">< </span><span class="current">1</span> <a href="#?page=2">2</a>
        <span class="diandian">...</span> <a href="#?page=200">200</a> <a href="#?page=2">></a>
    </div>
    <!--//分页排序 End-->
    <div class="clear">
    </div>
</div>
<!--//分页 End-->
<input type="hidden" id="HiddenEndDate" runat="server" />