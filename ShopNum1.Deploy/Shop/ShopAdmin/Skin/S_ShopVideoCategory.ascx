<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script src="/JS/jquery-1.6.2.min.js" type="text/javascript"> </script>
<script type="text/javascript" language="javascript">
    $(function () {
        //批量删除操作
        $(".shanchu").click(function () {
            var ArrayGuid = new Array();
            var flat = false;
            $("input[name='checksub']").each(function () {
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
            $.get("/Api/ShopAdmin/S_DeleteOp.ashx?type=Shop_VideoCategory&delid=" + val, null, function (data) {
                if (data == "ok") {
                    alert("删除成功！");
                    location.reload();
                    return false;
                } else {
                    Alert("删除失败！");
                    return false;
                }
            });
        }
    }

    $(function () {
        $("#checktop").click(function () {
            $("input[name='checksub']").attr("checked", $(this).is(":checked"));
        });
    });
</script>
<div id="content" class="ordmain1">
    <div class="biaogenr">
        <!--列表操作按钮-->
        <div class="btntable_tbg">
            <div class="shanc">
                <a href="javascript:void(0)" class="shanchu lmf_btn">批量删除</a>
            </div>
            <div class="shanc">
                <a href="S_ShopVideoCategoryEdit.aspx" class="tianjiafl lmf_btn">添加分类</a>
            </div>
        </div>
        <!--列表-->
        <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw1">
            <tr>
                <th class="th_le" width="4%">
                    <input name="checktop" type="checkbox" title="全选" id="checktop" />
                </th>
                <th width="24%">
                    分类名称
                </th>
                <th width="40%">
                    分类关键字
                </th>
                <th width="10%">
                    分类排序
                </th>
                <th width="10%">
                    是否显示
                </th>
                <th width="10%" class="th_ri">
                    操作
                </th>
            </tr>
            <asp:Repeater ID="RepeaterShow" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="th_le">
                            <input name="checksub" type="checkbox" class="vcheck" value='<%#Eval("Guid") %>' />
                        </td>
                        <td>
                            <%#Eval("Name") %>
                        </td>
                        <td>
                            <%#Eval("Keywords").ToString().Length > 20 ? Eval("Keywords").ToString().Substring(0, 20) : Eval("Keywords").ToString() %>
                        </td>
                        <td>
                            <%#Eval("OrderID") %>
                        </td>
                        <td>
                            <%#Eval("IsShow").ToString() == "1" ? "显示" : "不显示" %>
                        </td>
                        <td class="th_ri">
                            <a href='S_ShopVideoCategoryEdit.aspx?guid=<%#Eval("Guid") %>'>编辑</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <% if (RepeaterShow.Items.Count == 0)
               { %>
            <tr>
                <td colspan="7" class="th_le th_ri">
                    <div class="no_datas">
                        <div class="no_data">
                            暂无数据</div>
                    </div>
                </td>
            </tr>
            <% } %>
        </table>
        <!--分页-->
        <div class="btntable_tbg">
            <div id="pageDiv" runat="server" class="fy">
            </div>
        </div>
        <!--分页-->
    </div>
</div>
