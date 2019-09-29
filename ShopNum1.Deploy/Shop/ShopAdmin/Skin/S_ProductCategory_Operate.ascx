<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script type="text/javascript" language="javascript">
    function check_confrim() {
        $("span[lang='isnull']").hide();
        if ($("#S_ProductCategory_Operate_ctl00_txtName").val() == "" || $("#S_ProductCategory_Operate_ctl00_txtName").val().length > 20) {
            $("span[lang='isnull']").show();
            return false;
        } else if ($("#S_ProductCategory_Operate_ctl00_txtKeyWord").val().length > 100) {
            $("#S_ProductCategory_Operate_ctl00_txtKeyWord").next().show();
            return false;
        } else if ($("#S_ProductCategory_Operate_ctl00_txtDesc").val().length > 200) {
            $("#S_ProductCategory_Operate_ctl00_txtDesc").next().show();
            return false;
        } else if (!IsNum($("#S_ProductCategory_Operate_ctl00_txtOrderId").val())) {
            $("#S_ProductCategory_Operate_ctl00_txtOrderId").next().show();
            return false;
        }
        return true;
    }

    function IsNum(num) {
        var reNum = /^\d*$/;
        return (reNum.test(num));
    }
</script>
<div class="dpsc_mian">
    <p class="ptitle">
        <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><a href="S_ProductCategory.aspx">店铺商品分类</a><span
            class="breadcrume_icon">>></span> <span class="breadcrume_text">
                <%= lblShopCategory.Text %></span></p>
    <div class="biaogenr">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
            <tr>
                <th colspan="2" scope="col">
                    <asp:Label ID="lblShopCategory" runat="server"></asp:Label>
                </th>
            </tr>
            <tr>
                <td class="bordleft" width="130">
                    分类名称：
                </td>
                <td class="bordrig">
                    <input type="text" id="txtName" runat="server" class="op_text" /><span class="star">*</span><span
                        lang="Isnull" style="color: Red; display: none;">分类名称不能为空或分类不能超过20个字符</span>
                    <span lang="length_check" style="color: Red; display: none;">最多20个字符</span>
                </td>
            </tr>
            <tr id="trIv" runat="server">
                <td class="bordleft">
                    上级分类：
                </td>
                <td class="bordrig">
                    <select name="selectCategory" id="selectCategory" runat="server" class="op_select">
                    </select>
                    <span id="mustselect" style="color: Red; display: none;">该值必需选择</span>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    分类关键字：
                </td>
                <td class="bordrig">
                    <input type="text" id="txtKeyWord" runat="server" class="op_text" maxlength="100" />
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    分类描述：
                </td>
                <td class="bordrig">
                    <textarea id="txtDesc" runat="server" rows="2" cols="20" class="op_area" maxlength="300"></textarea>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    分类排序：
                </td>
                <td class="bordrig">
                    <input type="text" id="txtOrderId" runat="server" value="0" maxlength="5" class="op_text" />
                </td>
            </tr>
            <tr>
                <td class="bordleft" style="border-bottom: solid 1px #c6dfff;">
                    是否前台显示：
                </td>
                <td class="bordrig" style="border-bottom: solid 1px #c6dfff;">
                    <asp:CheckBox ID="cbIsshow" runat="server" />是
                </td>
            </tr>
        </table>
        <div class="op_btn">
            <asp:Button ID="btnConfrim" runat="server" Text="确定" CssClass="baocbtn" OnClientClick=" return check_confrim() " />
            <input type="button" class="baocbtn" value="返回" onclick=" window.location.href = 'S_ProductCategory.aspx?javascript:Math.random()'; " />
        </div>
    </div>
</div>
