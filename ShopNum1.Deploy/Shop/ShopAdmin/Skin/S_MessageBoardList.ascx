<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div id="content" class="ordmain1">
    <div class="biaogenr">
        <div class="btntable_tbg">
            <div class="shanc">
                <a href="javascript:void(0)" class="shanchu lmf_btn">批量删除</a>
            </div>
            <div class="shanc">
                <asp:LinkButton ID="LinkDelete" CssClass="shanchu lmf_btn" runat="server" Visible="false">
                </asp:LinkButton>
            </div>
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw1">
            <tr>
                <th class="th_le" width="6%">
                    <input name="fx" type="checkbox" id="checkboxAll" value="全选" />
                </th>
                <th width="10%">
                    留言人
                </th>
                <th width="10%">
                    留言类型
                </th>
                <th width="10%">
                    留言标题
                </th>
                <th width="20%">
                    留言时间
                </th>
                <th width="20%">
                    回复时间
                </th>
                <th width="7%">
                    是否回复
                </th>
                <th class="th_ri" width="10%">
                    操作
                </th>
            </tr>
            <asp:Repeater ID="RepeaterShow" runat="server">
                <ItemTemplate>
                    <tr>
                        <td width="30" class="th_le1">
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" name="subcheck" />
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "memloginid").ToString() == string.Empty ? "匿名" : DataBinder.Eval(Container.DataItem, "memloginid") %>
                        </td>
                        <td>
                            <%# ShopNum1.ShopAdminWebControl.S_MessageBoardList.IsType(DataBinder.Eval(Container.DataItem, "MessageType")) %>
                        </td>
                        <td>
                            <%#Eval("Title").ToString().Length > 16 ? Eval("Title").ToString().Substring(0, 16) : Eval("Title").ToString() %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "SendTime") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "ReplyTime") %>
                        </td>
                        <td>
                            <%# ShopNum1.ShopAdminWebControl.S_MessageBoardList.IsShow(DataBinder.Eval(Container.DataItem, "IsReply")) %>
                        </td>
                        <td class="th_ri1" style="line-height: 150%;" valign="middle" class="th_ri1">
                            <a href='S_MessageBoardReply.aspx?guid=<%# DataBinder.Eval(Container.DataItem, "Guid") %>'
                                class="alink_blue">查看/回复</a>
                            <asp:LinkButton ID="LinkButton_delete" runat="server" CssClass="alink_blue" OnClientClick=" return window.confirm('您确定要删除吗?'); "
                                CommandName="delete">删除</asp:LinkButton>
                            <input type="hidden" runat="server" id="hid_Guid" value='<%# DataBinder.Eval(Container.DataItem, "Guid") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="Rep_NoValue" runat="server" Visible="false">
                <ItemTemplate>
                    <tr>
                        <td colspan="9" class="th_le th_ri">
                            <div class="no_datas">
                                <div class="no_data">
                                    <%# DataBinder.Eval(Container.DataItem, "NoValue") %></div>
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <asp:HiddenField ID="hid_SelectGuid" runat="server" />
        <!--分页-->
        <div class="btntable_tbg">
            <div id="pageDiv" runat="server" class="fy">
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
    $(function () {
        $("#checkboxAll").click(function () {
            $("input[name='subcheck']").attr("checked", $(this).is(":checked"));
        });
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
            $.get("/Api/Main/Member/DeleteOp.ashx?type=shopmessageBoard&delid=" + val, null, function (data) {
                if (data == "ok") {
                    alert("删除成功！");
                    location.reload();
                    return false;
                } else {
                    alert("删除失败！");
                    return false;
                }
            });
        }
    }

</script>
