<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="ordmain1" id="content">
    <div class="biaogenr">
        <div class="btntable_tbg">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_top">
                <tr>
                    <td width="4%" class="check_td">
                        <input name="fx" type="checkbox" value="" id="checkboxAll" />
                    </td>
                    <td width="6%" style="border-right: none; padding-left: 10px; text-align: left;">
                        全选
                    </td>
                    <td width="90%">
                        <div class="shanc">
                            <asp:LinkButton ID="LinkDelete" CssClass="shanchu lmf_btn" runat="server">批量删除
                            </asp:LinkButton>
                        </div>
                        <div class="fy" style="float: left;">
                            <a href="S_UserDefinedColumnOperate.aspx" class="tianjiafl lmf_btn">添加栏目</a>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw1">
            <tr>
                <th class="th_le" width="6%">
                    &nbsp;
                </th>
                <th width="24%">
                    栏目名称
                </th>
                <th width="40%">
                    链接地址
                </th>
                <th width="10%">
                    是否显示
                </th>
                <th width="10%">
                    排序号
                </th>
                <th class="th_ri" width="10%">
                    操作
                </th>
            </tr>
            <asp:Repeater ID="Rep_UserDefinedColumn" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="th_le1" style="padding: 0 13px; text-align: right; width: 26px;">
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" name="subcheck" />
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "Name") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "LinkAddress") %>
                        </td>
                        <td>
                            <%#ShopNum1.ShopAdminWebControl.S_UserDefinedColumnList.IsShow(DataBinder.Eval(Container.DataItem, "IsShow")) %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "OrderID") %>
                        </td>
                        <td style="line-height: 150%;" valign="middle" class="th_ri1">
                            <a href='S_UserDefinedColumnOperate.aspx?guid=<%# DataBinder.Eval(Container.DataItem, "Guid") %>'
                                class="alink_blue">编辑</a>
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
                        <td colspan="6">
                            <%# DataBinder.Eval(Container.DataItem, "NoValue") %>
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
        <!--分页-->
    </div>
</div>
<script type="text/javascript" language="javascript">
    $(function () {
        $("#checkboxAll").click(function () {
            $("input[name='subcheck']").attr("checked", $(this).is(":checked"));
        });
        //批量删除
        $(".shanchu").click(function () {
            if (confirm("是否执行批量删除操作？")) {
                var arryid = new Array();
                var bflag = false;
                $("input[name='subcheck']").each(function () {
                    if ($(this).is(":checked")) {
                        arryid.push("'" + $(this).val() + "'");
                        $("#S_UserDefinedColumnList_ctl00_hid_SelectGuid").val(arryid);
                        bflag = true;
                    }
                });
                if (!bflag) {

                    alert("请选择需要删除的自定义栏目！");
                    return false;
                }

            } else {
                return false;
            }
        });

    })

</script>
