<%@ Control Language="C#" EnableViewState="false"%>

<script>
 function addimg(tc) {

    WdatePicker({ skin : 'whyGreen',
		oncleared : function() {
			tc.blur();
		},
		onpicked : function() {
			tc.blur();
		}
	})
}
</script>
<div class="bBoxnt">
    <h2>预约订购</h2>
    <div class="content">
    <table width="100%" class="adr" cellspacing="1" cellpadding="0">
        <tr>
            <td width="40%" align="right">
                <asp:Label ID="LabelName" runat="server" Text="姓名："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" ForeColor="red" Text="*"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBox" runat="server" ControlToValidate="TextBoxName"
                    Display="Dynamic" ValidationGroup="BookingGroup" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBox" runat="server"
                    ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="最多50个字符" ValidationGroup="BookingGroup" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="LabelAddress" runat="server" Text="详细地址："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" ForeColor="red" Text="*"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxAddress"
                    Display="Dynamic" ValidationGroup="BookingGroup" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxAddress"
                    Display="Dynamic" ErrorMessage="最多50个字符" ValidationGroup="BookingGroup" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="LabelMobile" runat="server" Text="手机号码："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxMobile" runat="server"></asp:TextBox>
                <asp:Label ID="Label5" runat="server" ForeColor="red" Text="*"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxMobile"
                    Display="Dynamic" ValidationGroup="BookingGroup" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxMobile" runat="server" 
                    ControlToValidate="TextBoxMobile" Display="Dynamic" ErrorMessage="请填写正确的手机号" ValidationGroup="BookingGroup"
                    ValidationExpression="^(1[3|5|8][0-9])\d{8}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="LabelPostalcode" runat="server" Text="邮政编码："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxPostalcode" runat="server"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" ForeColor="red" Text="*"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPostalcode"
                    Display="Dynamic" ValidationGroup="BookingGroup" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxPostalcode"
                    runat="server" ControlToValidate="TextBoxPostalcode" ValidationGroup="BookingGroup"  ErrorMessage="邮政编码格式不对"
                    ValidationExpression="^[1-9][0-9]{5}$" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="LabelTel" runat="server" Text="电话号码："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxTel" runat="server"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" ForeColor="red" Text="*"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="BookingGroup"
                    runat="server" ControlToValidate="TextBoxTel" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxTel" runat="server"
                    ControlToValidate="TextBoxTel" Display="Dynamic" ValidationGroup="BookingGroup"  ErrorMessage="请填写正确的电话号码" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="LabelEmail" runat="server" Text="电子邮件："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
                <asp:Label ID="Label6" runat="server" ForeColor="red" Text="*"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxEmail"
                    Display="Dynamic" ValidationGroup="BookingGroup" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBoxEmail"
                    Display="Dynamic" ValidationGroup="BookingGroup" ErrorMessage="邮箱格式不正确！" ValidationExpression="^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="LabelSendDate" runat="server" Text="送货日期："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxSendDate" runat="server" name="test" class="Wdate" onfocus="addimg(this)"></asp:TextBox>
                <asp:Label ID="Label9" runat="server" ForeColor="red" Text="*"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxSendDate"
                    Display="Dynamic" ValidationGroup="BookingGroup" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate" runat="server"
                    ValidationGroup="BookingGroup" ControlToValidate="TextBoxSendDate" Display="Dynamic"
                    ErrorMessage="时间格式不正确" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="LabelRank" runat="server" Text="备注："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxRank" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp:Label ID="Label7" runat="server" ForeColor="red" Text="*"></asp:Label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TextBoxRank"
                    Display="Dynamic" ValidationGroup="BookingGroup" ErrorMessage="最多500个字符" ValidationExpression="^[\s\S]{0,500}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" class="BookingBtns">
                <asp:Button ID="ButtonConfirm" ValidationGroup="BookingGroup" runat="server" Text="确 定"
                    CssClass="bnt1" OnClientClick="return Page_ClientValidate('BookingGroup')" />
                <input id="inputReset" runat="server" type="reset" value="重 置" class="bnt3" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
    </div>
</div>
