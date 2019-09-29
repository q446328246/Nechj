<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script type="text/javascript" language="javascript">
    $(function () {
        //批量删除操作
        $(".shanchu").click(function () {
            var ArrayGuid = new Array();
            $("input[name='checksub']").each(function () {
                if ($(this).is(":checked")) {
                    ArrayGuid.push("'" + $(this).val() + "'");
                }
            });
            IsDelete(ArrayGuid.join(","));
        });
    });

    function Alert(str) {
        art.dialog({
            title: '提示',
            content: str,
            icon: 'succeed',
            ok: function () {
                window.location.reload();
                return false;
            }
        });
    }

    function IsDelete(val) {
        art.dialog({
            content: '是否删除勾选项？',
            ok: function () {
                $("input[type='checkbox']").removeAttr("checked");
                $.get("/Api/ShopAdmin/S_DeleteOp.ashx?type=ShopSEO&delid=" + val, null, function (data) {
                    if (data == "ok") {
                        Alert("删除成功！");
                        location.reload();
                        return false;
                    } else {
                        Alert("删除失败！");
                        return false;
                    }
                });
            },
            cancelVal: '关闭',
            cancel: true
        });
    }

    $(function () {
        $("#checktop").click(function () {
            $("input[name='checksub']").attr("checked", $(this).is(":checked"));
        });
    });
</script>
<div id="content" class="ordmain1">
    <div class="biaogenr">
        <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw1">
            <thead>
                <tr>
                    <th class="th_le" width="30%">
                        页面名
                    </th>
                    <th width="30%">
                        SEO标题
                    </th>
                    <th width="10%">
                        SEO关键字
                    </th>
                    <th width="20%">
                        SEO描述
                    </th>
                    <th class="th_ri" width="10%">
                        操作
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="RepeaterShow" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="th_le">
                                <asp:Label ID="LabelName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PageName") %>'></asp:Label>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "Title") %>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "KeyWords") %>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "Description") %>
                            </td>
                            <td class="th_ri">
                                <a href="S_ShopSEOManageEdit.aspx?pid='<%#Eval("PageName") %>'">编辑</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <!--分页-->
        <div class="btntable_tbg">
            <div id="pageDiv" runat="server" class="fy">
            </div>
        </div>
        <!--分页-->
    </div>
</div>
