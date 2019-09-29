<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="biaogenr">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod">
        <tr>
            <th colspan="2">
                新增活动
            </th>
        </tr>
        <tr>
            <td class="bordleft">
                活动名称：
            </td>
            <td class="bordrig">
                <input type="text" id="txtName" runat="server" maxlength="25" class="ss_nr1" /><span
                    class="star">*</span>
                <div class="gray">
                    活动名称最多为25个字符</div>
            </td>
        </tr>
        <tr>
            <td class="bordleft" width="130">
                开始时间：
            </td>
            <td class="bordrig">
                <span id="showstarttime" style="display: none;">
                    <%= DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd") %></span>
                <input type="text" id="txtStartTime" runat="server" onclick="WdatePicker({minDate:'%y-%M-#{%d}'})"
                    class="ss_nrduan1" /><span class="star">*</span>
                <div class="gray">
                    开始时间不能为空且不晚于结束时间<asp:Label ID="lblStartTime" runat="server" Visible="false"></asp:Label></div>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                结束时间：
            </td>
            <td class="bordrig">
                <input type="text" id="txtEndTime" runat="server" onclick="WdatePicker({minDate:'%y-%M-#{%d}'})"
                    class="ss_nrduan1" /><span class="star">*</span>
                <div class="gray">
                    结束时间不能为空且不能早于开始时间<asp:Label ID="lblEndTime" runat="server" Visible="false"></asp:Label></div>
            </td>
        </tr>
        <tr>
            <td class="bordleft" style="border-bottom: solid 1px #c6dfff;">
                折扣：
            </td>
            <td class="bordrig" style="border-bottom: solid 1px #c6dfff;">
                <input type="text" id="txtDisCount" runat="server" class="op_text" /><span class="star">*</span>
                <div class="gray">
                    折扣必须为0.1-1.0之间的数字</div>
            </td>
        </tr>
    </table>
    <div class="op_btn">
        <asp:Button ID="btnSub" runat="server" Text="提交" OnClientClick=" return checksub() "
            CssClass="baocbtn" />
    </div>
</div>
