<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="sp_dialog_info">
    <div class="sp_general info_title">
        ��Ҫ���ߣ�</div>
    <div class="sp_general">
        <label class="sp_lable">
            �ٱ���ţ�</label>
        <span class="sp_word">615561156615</span>
    </div>
    <div class="sp_general" style="height: 160px;">
        <label class="sp_lable">
            �������ݣ�</label>
        <span class="sp_txtare">
            <asp:TextBox ID="TextBoxComplaintContent" runat="server" TextMode="MultiLine" Width="340"
                Height="140"></asp:TextBox>
        </span>
    </div>
    <div class="sp_general">
        <label class="sp_lable" style="line-height: 22px;">
            ����ͼƬ��</label>
        <input type="button" value="�ϴ�ͼƬ" />
    </div>
    <div class="sp_general">
        <span class="sp_lable"></span>
        <input type="button" class="sp_annoe" value="�ύ" onclick=" funSelectClick() " />
    </div>
</div>
