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
                <div class="fy" style="float: left;">
                    <a href="S_UserDefinedColumnOperate.aspx" class="tianjiafl lmf_btn">添加栏目</a>
                </div>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw" style="margin-top: 8px;">
        <tr>
            <th class="th_le1" width="2%">
                &nbsp;
            </th>
            <th>
                栏目名称
            </th>
            <th>
                链接地址
            </th>
            <th>
                是否显示
            </th>
            <th>
                排序号
            </th>
            <th class="th_ri1">
                操作
            </th>
        </tr>
        <asp:Repeater ID="Rep_UserDefinedColumn" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="th_le1" style="width: 26px; text-align: right; padding: 0 13px;">
                        <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" name="subcheck" />
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Name")%>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "LinkAddress")%>
                    </td>
                    <td>
                        <%#ShopNum1.ShopAdminWebControl.S_UserDefinedColumnList.IsShow(DataBinder.Eval(Container.DataItem, "IsShow"))%>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "OrderID")%>
                    </td>
                    <td style="line-height: 150%;" valign="middle" class="th_ri1">
                        <a href='S_UserDefinedColumnOperate.aspx?guid=<%# DataBinder.Eval(Container.DataItem, "Guid") %>'
                            class="alink_blue">编辑</a>
                        <asp:LinkButton ID="LinkButton_delete" runat="server" CssClass="alink_blue" OnClientClick="return window.confirm('您确定要删除吗?');"
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
                        <%# DataBinder.Eval(Container.DataItem, "NoValue")%>
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
                <td style="border-right: none; border-left: solid 1px #e3e3e3; width: 30px;">
                    &nbsp;
                </td>
                <td style="border-left: none;">
                    <div id="pageDiv" runat="server" class="fy">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <!--分页-->
</div>
<script type="text/javascript" language="javascript">
    $(function () {
        $("#checkboxAll").click(function () {
            $("input[name='subcheck']").attr("checked", $(this).is(":checked"));
        });
        //批量删除
        $(".shanchu").click(function () {
            if (confirm("是否执行批量删除操作？")) {
                var arryid = new Array(); var bflag = false;
                $("input[name='subcheck']").each(function () {
                    if ($(this).is(":checked")) {
                        arryid.push("'" + $(this).val() + "'");
                        $("#S_UserDefinedColumnList_ctl00_hid_SelectGuid").val(arryid);
                        bflag = true;
                    }


                });
                if (!bflag) {

                    alert("请选择需要删除的自定义栏目！"); return false;
                }

            }
            else {
                return false;
            }
        });

    })
 
</script>
