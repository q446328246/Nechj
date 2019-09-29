<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="pad">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_top"
        style="margin-top: 10px;">
        <tr>
            <td style="border-right: none;" class="dind_l ord_che">
                <input name="fx" type="checkbox" value="" id="checkboxAll" />
            </td>
            <td style="border-right: none; padding-left: 10px; text-align: left; width: 50px;">
                全选
            </td>
            <td style="border-left: none;">
                <div class="shanc">
                    <asp:LinkButton ID="LinkDelete" CssClass="shanchu lmf_btn" runat="server">批量删除
                    </asp:LinkButton>
                </div>
                <div class="fy">
                </div>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw" style="margin-top: 8px;">
        <tr>
            <th class="th_le1" width="5%">
            </th>
            <th>
                预约人
            </th>
            <th>
                手机
            </th>
            <th>
                电话
            </th>
            <th>
                送货时间
            </th>
            <th>
                是否预约
            </th>
            <th class="th_ri1">
                操作
            </th>
        </tr>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="th_le1">
                        <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Name") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Mobile") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Tel") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "SendDate") %>
                    </td>
                    <td>
                        <%# ShopNum1.ShopAdminWebControl.S_ProductBookingList.IsOrNo(DataBinder.Eval(Container.DataItem, "IsAudit")) %>
                    </td>
                    <td valign="middle" class="th_ri1">
                        <a href='S_ProductBookingDetail.aspx?guid=<%# DataBinder.Eval(Container.DataItem, "Guid") %>'
                            class="alink_blue">查看</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Repeater ID="Rep_NoValue" runat="server" Visible="false">
            <ItemTemplate>
                <tr>
                    <td style="border-left: solid 1px #e3e3e3; border-right: solid 1px #e3e3e3; height: 16px;"
                        colspan="9">
                        <div class="no_data">
                            <%# DataBinder.Eval(Container.DataItem, "NoValue") %>
                        </div>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <asp:HiddenField ID="hid_SelectGuid" runat="server" />
    <table width="100%" border="0" cellspacing="0" cellpadding="5" class="btntable_t">
    </table>
    <!--分页-->
    <div class="fenye">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_t">
            <tr>
                <td style="border-left: solid 1px #e3e3e3; border-right: none; width: 30px;">
                    &nbsp;
                </td>
                <td style="border-left: none;">
                    <div id="pageDiv" runat="server" class="fy">
                    </div>
                </td>
            </tr>
        </table>
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
                        $("#S_ProductBookingList_ctl00_hid_SelectGuid").val(arryid);
                        bflag = true;
                    }
                });
                if (!bflag) {
                    alert("请选择需要删除的自定义栏目！");
                    return false;
                }

            }
        });

    })

</script>
