<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript" language="javascript">
    $(function () {
        //批量删除操作
        $(".shanchu").click(function () {
            var ArrayGuid = new Array();
            var flat = false;
            $("input[name='subcheck']").each(function () {
                if ($(this).is(":checked")) {
                    flat = true;
                    ArrayGuid.push("'" + $(this).val() + "'");
                }
            });
            if (flat) {
                IsDelete(ArrayGuid.join(","));
            } else {
                alert("请选择一项！");
            }
        });
    });

    function IsDelete(val) {
        if (confirm("是否删除勾选项？")) {
            $.get("/Api/Main/Member/DeleteOp.ashx?type=ProductMessageBoard&delid=" + val, null, function (data) {
                if (data == "ok") {
                    alert("删除成功！");
                    $("input[name='subcheck']").removeAttr("checked");
                    location.reload();
                    return false;
                } else {
                    alert("删除失败！");
                    return false;
                }
            });
        }
    }

    $(function () {
        $("#checktop").click(function () {
            $("input[name='subcheck']").attr("checked", $(this).is(":checked"));
        });
    });
</script>
<div id="content" class="ordmain1">
    <div class="pad">
        <table border="0" cellspacing="0" cellpadding="0" class="lineh">
            <tr class="up_spac">
                <td align="right">
                    留言会员ID：
                </td>
                <td>
                    <asp:TextBox ID="TextBoxMemLoginID" runat="server" CssClass="ss_nr1"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="ButtonSearch" runat="server" Text="查询" CssClass="chax btn_spc" name="12" />
                </td>
            </tr>
        </table>
    </div>
    <div class="btntable_tbg">
        <div class="shanc">
            <a href="javascript:void(0)" class="shanchu lmf_btn">批量删除</a>
        </div>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw1">
        <thead>
            <tr>
                <th class="th_le" width="6%">
                    <input name="fx" type="checkbox" id="checktop" value="全选" />
                </th>
                <th width="24%">
                    商品名称
                </th>
                <th width="20%">
                    留言会员ID
                </th>
                <th width="10%">
                    是否回复
                </th>
                <th width="20%">
                    留言时间
                </th>
                <th width="10%" class="th_ri">
                    操作
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="RepeaterShow" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="th_le">
                            <input name="subcheck" type="checkbox" class="vcheck" value='<%#Eval("Guid") %>' />
                        </td>
                        <td>
                            <a target="_blank" href='<%#ShopUrlOperate.shopHref(((DataRowView) Container.DataItem).Row["ProductGuid"].ToString(), ((DataRowView) Container.DataItem).Row["ShopID"].ToString()) %>'>
                                <%#ShopNum1.ShopAdminWebControl.S_ProductMessageBoardList.GetProductNameByGuid(Eval("ProductGuid").ToString()) %>
                            </a>
                        </td>
                        <td>
                            <%#Eval("MemLoginID") %>
                        </td>
                        <td>
                            <%#Eval("IsReply").ToString() == "0" ? "未回复" : "已回复" %>
                        </td>
                        <td>
                            <%#Eval("SendTime") %>
                        </td>
                        <td class="th_ri">
                            <a href="S_ProductMessageBoardReply.aspx?guid=<%#Eval("Guid") %>">查看/回复</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <% if (RepeaterShow.Items.Count == 0)
       { %>
    <div class="no_datas">
        <div class="no_data">
            暂无数据</div>
    </div>
    <% } %>
    <!--分页-->
    <div class="btntable_tbg">
        <div id="pageDiv" runat="server" class="fy">
        </div>
    </div>
    <!--分页-->
</div>
