<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="sp_dialog_info">
    <p class="sp_general">
        <label class="sp_lable">
            ��Ʒ���ƣ�</label>
        <asp:TextBox ID="TextBoxNumber" runat="server" class="sp_input" onblur="funGetData()"
            Width="300"></asp:TextBox>
        <span id="SpanNumErr"></span><span id="SpanNumRight" style="display: none">
            <img src="/ImgUpload/shopNum1Admin-right.gif" />
        </span>
    </p>
    <p class="sp_general" style="height: 72px;">
        <span class="sp_lable" style="height: 72px;"></span>��ʾ������ֻ��ʾ���µ�50�����ݣ���������û������Ҫ����Ʒ����������ϸ����Ʒ���ƽ���������
    </p>
    <div class="sp_general">
        <label class="sp_lable" style="line-height: 22px;">
            ������� ��</label>
        <p class="sp_general fl" style="line-height: 30px;">
            <asp:DropDownList ID="DropDownListProductSeriesCode1" runat="server" CssClass="tselect"
                Width="100px">
                <asp:ListItem Value="-1">-��ѡ��-</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownListProductSeriesCode2" runat="server" CssClass="tselect"
                Width="100px">
                <asp:ListItem Value="-1">-��ѡ��-</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownListProductSeriesCode3" runat="server" CssClass="tselect"
                Visible="false" Width="100px">
                <asp:ListItem Value="-1">-��ѡ��-</asp:ListItem>
            </asp:DropDownList>
        </p>
        <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="0" />
        <span id="SpanAdressErr"></span><span id="SpanAdressRight" style="display: none">
            <img src="/ImgUpload/shopNum1Admin-right.gif" />
        </span>
    </div>
    <div class="sp_general">
        <span class="sp_lable"></span><span>
            <input type="button" class="sp_annoe" value="��ѯ" onclick=" funGetData() " /></span>
        <span style="color: Red; display: none; float: left; font-size: 12px;" id="showLoading">
            <img src="/Images/ajax_loading.gif" /></span>
    </div>
    <p class="sp_general" style="height: 160px;">
        <label class="sp_lable">
            ѡ����Ʒ��</label>
        <select id="selectproduct" class="ss_nr1" style="height: 150px; width: 300px;" size="10">
        </select>
    </p>
    <p class="sp_general">
        <span class="sp_lable"></span>
        <input type="button" class="sp_annoe" value="�ύ" onclick=" funSelectClick() " />
    </p>
</div>
