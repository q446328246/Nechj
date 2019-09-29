<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="CommentsList">
    <h1 class="CommentsList_title">
        评论列表</h1>
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <div class="CommentsList_con clearfix">
                <div class="CommentIp">
                    <div class="ip fl">
                        <%# ((DataRowView)Container.DataItem).Row["MemLoginID"]%></div>
                    <div class="date fr">
                        <%# string.Format("{0:yyyy年MM月dd日HH时mm分ss秒}", Eval("CreateTime"))%>
                    </div>
                    <div class="clearfix">
                    </div>
                </div>
                <div class="discussCon">
                    <font>评论内容：</font><%# ((DataRowView)Container.DataItem).Row["Content"]%>
                </div>
            </div>
        </ItemTemplate>
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
                        <asp:Button ID="ButtonSure" runat="server" Text="Button" CssClass="page_btn" ValidationGroup="buttonGroup" />
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
</div>
