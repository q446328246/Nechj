<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="pad">
    <table id="Table1" width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao">
        <tr>
            <td align="right" width="200px">
                在线客服类型：
            </td>
            <td>
                <select id="sel_OnlineServiceType" size="1" class="tselect1">
                    <option value="-1">-请选择-</option>
                    <option value="QQ">QQ</option>
                    <option value="WW">在线旺旺 </option>
                </select>
                <span class="gray1" id="typemsg" style="color: Red;">&nbsp;*</span>
                <input id="hid_TypeName" type="hidden" runat="server" value="" />
                <input id="hid_TypeValue" type="hidden" runat="server" value="" />
            </td>
        </tr>
        <tr>
            <td align="right">
                在线客服名称：
            </td>
            <td>
                <input name="input" type="text" class="textwb" id="txt_OnlineServiceName" runat="server"
                    maxlength="20" onblur="CheckNull(this,'客服名称不能为空')" />
                <span class="gray1" style="color: Red">&nbsp;*</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                在线客服账号：
            </td>
            <td>
                <input type="text" class="textwb" id="txt_OnlineServiceID" runat="server" maxlength="30"
                    onblur="CheckNull(this,'客服名称不能为空');CheckQQCommon(this,'QQ格式错误')" />
                <span class="gray1" style="color: Red">&nbsp;*</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                排序号：
            </td>
            <td>
                <input type="text" class="textwb" id="txt_OrderID" runat="server" />
                <span class="gray1">&nbsp;</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                是否前台显示：
            </td>
            <td>
                <input type="checkbox" id="check_IsShow" runat="server" />
                <span class="gray1">&nbsp;</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;
            </td>
            <td style="padding: 10px 0px 10px 0px;">
                <asp:Button ID="btn_Save" runat="server" Text="保存" CssClass="querbtn" OnClientClick=" return ClickSumbit() " />
                <asp:Button ID="btn_Back" runat="server" Text="返回" CssClass="querbtn" />
            </td>
        </tr>
    </table>
</div>
<script language="javascript" type="text/javascript">
    $(document).ready(
        $("#S_OnLineServiceOperate_ctl00_hid_TypeValue").ready(
            function () {
                var type = $("#S_OnLineServiceOperate_ctl00_hid_TypeValue").val();
                if (type != null && type != "" && type != "0") {
                    $("#sel_OnlineServiceType option[value='" + type + "']").attr("selected", true);
                }
            }
        ),
        $("#sel_OnlineServiceType").change(
            function () {
                var TypeText = $("#sel_OnlineServiceType").find("option:selected").text();
                var TypeValue = $("#sel_OnlineServiceType").find("option:selected").val();
                $("#S_OnLineServiceOperate_ctl00_hid_TypeName").val(TypeText);
                $("#S_OnLineServiceOperate_ctl00_hid_TypeValue").val(TypeValue);
            }
        )
    )
</script>
<script type="text/javascript" language="javascript">
    function ClickSumbit() {
        var OnlineServiceID = $("#S_OnLineServiceOperate_ctl00_txt_OnlineServiceID").val();
        var OnlineServiceName = $("#S_OnLineServiceOperate_ctl00_txt_OnlineServiceName").val();
        var strType = $("#sel_OnlineServiceType").find("option:selected").val();

        if (strType == "-1") {
            $("#typemsg").show().text("请选择一种类型");
            return false;
        }


        if (OnlineServiceName == "") {
            $("#S_OnLineServiceOperate_ctl00_txt_OnlineServiceName").next().text("*客服名称不能为空");
            return false;
        }


        if (OnlineServiceID == "") {
            $("#S_OnLineServiceOperate_ctl00_txt_OnlineServiceID").next().text("*客服账号不能为空");
            return false;
        } else {
            if (strType == "QQ") {
                if (!(/^\d{5,10}$/.test(OnlineServiceID))) {
                    $("#S_OnLineServiceOperate_ctl00_txt_OnlineServiceID").next().text("*QQ格式不正确");
                    return false;
                }
            }
        }
    }

    function CheckQQCommon(obj, i) {
        var str = $(obj).val();
        var strType = $("#S_OnLineServiceOperate_ctl00_hid_TypeValue").val();
        if (strType == "QQ") {
            if (str != "") {
                if (!(/^\d{5,10}$/.test(str))) {
                    $("#S_OnLineServiceOperate_ctl00_txt_OnlineServiceID").next().text("*QQ格式不正确");
                }
            } else {
                $("#S_OnLineServiceOperate_ctl00_txt_OnlineServiceID").next().text("*客服账号需要填写");
            }
        } else {
            if (str == "") {
                $("#S_OnLineServiceOperate_ctl00_txt_OnlineServiceID").next().text("*客服账号需要填写");
            }
        }
    }

</script>
