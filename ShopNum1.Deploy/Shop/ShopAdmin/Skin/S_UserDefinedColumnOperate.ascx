<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="pad">
    <table id="Table1" width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao">
        <tr>
            <td align="right">
                栏目名称：
            </td>
            <td>
                <input name="input" type="text" class="op_text" id="txt_MenuName" runat="server"
                    onblur="CheckNull(this,'请填写栏目名称')" maxlength="50" /><span class="star">*</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                链接地址：
            </td>
            <td>
                <input type="text" class="op_text" id="txt_AdLink" runat="server" onblur="CheckNull(this,'请填写链接地址')"
                    maxlength="250" /><span class="star">*</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                是否前台显示：
            </td>
            <td>
                <input type="checkbox" id="check_IsShow" runat="server" /><span class="star">*</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                排序号：
            </td>
            <td>
                <input type="text" class="op_text" id="txt_OrderID" runat="server" />
                <span class="gray1">&nbsp;</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;
            </td>
            <td style="padding: 10px 0px 10px 0px;">
                <asp:Button ID="btn_Save" runat="server" Text="保存" CssClass="querbtn" />
                <asp:Button ID="btn_Back" runat="server" Text="返回" CssClass="querbtn" />
            </td>
        </tr>
    </table>
</div>
<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        $("#check_IsShow").change(
            function () {
                if ($("check_IsShow").attr("checked", "true")) {
                    $("#S_UserDefinedColumnOperate_ct100_hid_IsShow").val("1");
                } else {
                    $("#S_UserDefinedColumnOperate_ct100_hid_IsShow").val();
                }
            }
        );
    })

</script>
