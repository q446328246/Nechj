<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_ArticleComment.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_ArticleComment" %>
<script type="text/javascript" language="javascript">
    function IsDelete(val) {
        if (confirm("是否删除勾选项？")) {
            $.get("/Api/Main/Member/DeleteOp.ashx?type=ArticleComment&delid=" + val, null, function (data) {
                if (data == "ok") { alert("删除成功！"); location.reload(); return false; }
                else { alert("删除失败！"); return false; }
            });
        }
    }
</script>
<div class="pad">
    <table border="0" cellspacing="0" cellpadding="0" class="lineh">
        <tr class="up_spac">
            <td align="right">
                评论时间：
            </td>
            <td>
                <asp:TextBox ID="TextBoxSRegDate1" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                    class="ss_nrduan"></asp:TextBox>
            </td>
            <td class="line_spac">
                -
            </td>
            <td>
                <asp:TextBox ID="TextBoxSRegDate2" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                    class="ss_nrduan"></asp:TextBox>
            </td>
            <td align="right" class="ss_nr_spac">
                审核状态：
            </td>
            <td>
                <asp:DropDownList ID="DropDownListIsAudit" runat="server" CssClass="tselect">
                    <asp:ListItem Value="-1">-全部-</asp:ListItem>
                    <asp:ListItem Value="0">未审核</asp:ListItem>
                    <asp:ListItem Value="1">已审核</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="ButtonGet" name="12" runat="server" Text="搜索" CssClass="chax btn_spc"
                    OnClick="ButtonGet_Click" />
            </td>
        </tr>
    </table>
</div>
<div class="btntable_tbg">
    <div class="shanc">
        <a href="#" class="shanchu lmf_btn">批量删除</a>
    </div>
</div>
<table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw1">
    <tr>
        <th class="th_le" width="4%">
            <input name="checktop" type="checkbox" title="全选" />
        </th>
        <th width="30%">
            评论
        </th>
        <th width="26%">
            评论文章
        </th>
        <th width="20%">
            评论时间
        </th>
        <th width="10%">
            审核状态
        </th>
        <th width="10%" class="th_ri">
            操作
        </th>
    </tr>
    <asp:Repeater ID="RepeaterShow" runat="server">
        <ItemTemplate>
            <tr>
                <td class="th_le">
                    <input name="checksub" type="checkbox" value='<%#Eval("Guid")%>' />
                </td>
                <td style="text-align: left;">
                    <%#Eval("Content").ToString().Length > 16 ? Eval("Content").ToString().Substring(0, 16) : Eval("Content").ToString()%>
                </td>
                <td style="text-align: left;">
                    <a target="_blank" href='<%# ShopUrlOperate.RetUrl("ArticleDetail",Eval("ArticleGuid")) %>'
                        target="_blank">
                        <%#ShopNum1.MemberWebControl.M_ArticleComment.GetTitle(Eval("ArticleGuid").ToString()).Length > 20 ? ShopNum1.MemberWebControl.M_ArticleComment.GetTitle(Eval("ArticleGuid").ToString()).Substring(0, 20) : ShopNum1.MemberWebControl.M_ArticleComment.GetTitle(Eval("ArticleGuid").ToString())%>
                    </a>
                </td>
                <td>
                    <%#Eval("SendTime")%>
                </td>
                <td>
                    <%#Eval("IsAudit").ToString() == "1" ? "已审核" : "未审核"%>
                </td>
                <td class="th_ri">
                    <a href="M_ArticleCommentDetail.aspx?guid=<%#Eval("Guid")%>">查看</a>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    <%if (RepeaterShow.Items.Count == 0)
      { %>
    <tr>
        <td colspan="6" style="height: 16px; border-left: solid 1px #e3e3e3; border-right: solid 1px #e3e3e3;">
            <div class="no_data">
                暂无数据</div>
        </td>
    </tr>
    <% }%>
</table>
<div class="btntable_tbg">
    <div id="pageDiv" runat="server" class="fy">
    </div>
</div>
<script type="text/javascript">
            <!--
    var TabbedPanels1 = new Spry.Widget.TabbedPanels("list_main");
            //-->
</script>
