<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_ShopCollect.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_ShopCollect" %>
<script type="text/javascript" language="javascript">
    function IsDelete(val) {
        if (confirm("是否删除勾选项？")) {
            $("input[type='checkbox']").removeAttr("checked");
            $.get("/Api/Main/Member/DeleteOp.ashx?type=ShopCollect&delid=" + val, null, function (data) {
                if (data == "ok") {
                    alert("删除成功！");
                    var type = '<%=ShopNum1.Common.Common.ReqStr("type")%>';
                    window.location.href = "?type=" + type + "&pageid=1"; return false;
                }
                else { alert("删除失败！"); return false; }
            });
        }
    }
</script>
<div class="biaogenr">
    <div class="btntable_tbg">
        <div class="shanc">
            <a href="#" class="shanchu lmf_btn">批量删除</a>
        </div>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tb2">
        <tr>
            <th width="4%" class="th_le">
                <input name="checktop" type="checkbox" title="全选" />
            </th>
            <th width="76%">
                店铺名称
            </th>
            <th width="20%" class="th_ri">
                收藏时间
            </th>
        </tr>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <input name="checksub" type="checkbox" value='<%#Eval("Guid")%>' />
                    </td>
                    <td>
                        <a target="_blank" href='<%#ShopUrlOperate.GetShopUrl(Eval("ShopID").ToString())%>'>
                            <%#ShopNum1.MemberWebControl.M_ShopCollect.GetShopNameByShopId(Eval("ShopID").ToString())%></a>
                    </td>
                    <td>
                        <%#Eval("CollectTime")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <%if (RepeaterShow.Items.Count == 0)
          { %>
        <tr>
            <td colspan="3" style="height: 16px;">
                <div class="no_data">
                    暂无数据</div>
            </td>
        </tr>
        <% }%>
    </table>
    <!--分页-->
    <div class="btntable_tbg">
        <div id="pageDiv" runat="server" class="fy">
        </div>
    </div>
    <!--分页-->
</div>
