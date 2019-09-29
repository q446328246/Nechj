<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="sp_dialog_info">
    <div class="sp_general info_title">
        我要申诉：</div>
    <div class="sp_general">
        <label class="sp_lable">
            举报编号：</label>
        <span class="sp_word">615561156615</span>
    </div>
    <div class="sp_general" style="height: 160px;">
        <label class="sp_lable">
            申诉内容：</label>
        <span class="sp_txtare">
            <asp:TextBox ID="TextBoxComplaintContent" runat="server" TextMode="MultiLine" Width="340"
                Height="140"></asp:TextBox>
        </span>
    </div>
    <div class="sp_general">
        <label class="sp_lable" style="line-height: 22px;">
            申诉图片：</label>
        <input type="button" value="上传图片" />
    </div>
    <div class="sp_general">
        <span class="sp_lable"></span>
        <input type="button" class="sp_annoe" value="提交" onclick=" funSelectClick() " />
    </div>
</div>
