<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="tjsp_mian">
    <p class="ptitle">
        <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">店铺会员</span></p>
    <div class="pad">
        <table width="100%" cellspacing="0" cellpadding="0" border="0" style="margin-top: 10px;"
            class="btntable_t">
            <tr>
                <td style="border-left: solid 1px #e3e3e3; border-right: none; width: 30px;">
                    <input name="fx" type="checkbox" value="" id="checkboxAll" />
                </td>
                <td style="border-left: none; border-right: none; cursor: pointer; width: 5%;">
                    <label for="topcheck">
                        全选</label>
                </td>
                <td style="border-left: none;">
                    <div class="shanc">
                        <asp:LinkButton ID="LinkDelete" CssClass="lahei lmf_btn" runat="server">拉黑
                        </asp:LinkButton>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <table cellpadding="0" cellspacing="0" border="0" width="98%" class="gridview_m blue_tbw"
        style="border: none; margin: 0 auto;">
        <tr>
            <th class="th_le1">
            </th>
            <th>
                用户ID
            </th>
            <th class="th_ri1">
                用户组
            </th>
        </tr>
        <asp:Repeater ID="rep_WeiXinUser" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="th_le1" style="padding: 0 13px; text-align: right; width: 26px;">
                        <input id="checkboxItem" value='<%# Eval("MemLoginId") %>' type="checkbox" name="subcheck" />
                    </td>
                    <td>
                        <%# Eval("MemLoginId") %>
                    </td>
                    <td class="th_ri1">
                        <%# Eval("Group") != DBNull.Value ? Convert.ToInt32(Eval("Group")) == (int) ShopVipGroup.Ordinary ? "普通用户" : "已拉黑" : string.Empty %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <asp:HiddenField ID="hid_SelectVip" runat="server" />
    <!--分页-->
    <div class="shangpinkj">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_b"
            style="margin-top: 10px;">
            <tr>
                <td style="border-right: none;" class="dind_l ord_che">
                    &nbsp;
                </td>
                <td class="dind_r" style="border-left: none;">
                    <div id="pageDiv" runat="server" class="fy">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <!--分页-->
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#checkboxAll").click(function () {
                $("input[name='subcheck']").attr("checked", $(this).is(":checked"));
            });
            //批量删除
            $(".lmf_btn").click(function () {
                if (confirm("是否拉黑选择的用户？")) {
                    var arryid = new Array();
                    var bflag = false;
                    $("input[name='subcheck']").each(function () {
                        if ($(this).is(":checked")) {
                            arryid.push("'" + $(this).val() + "'");
                            $("#<%= hid_SelectVip.ClientID %>").val(arryid);
                            bflag = true;
                        }
                    });
                    if (!bflag) {

                        alert("请选择需要拉黑的用户！");
                        return false;
                    }

                } else {
                    return false;
                }
            });
        })
    </script>
</div>
