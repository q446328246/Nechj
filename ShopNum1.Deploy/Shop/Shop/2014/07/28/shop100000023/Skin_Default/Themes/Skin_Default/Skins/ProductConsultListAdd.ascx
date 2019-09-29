<%@ Control Language="C#" EnableViewState="false"%>
<div id="MessageBarod">
<div id="ProductComment" class="clearfix">在线留言</div>
<div class="MessageBox">
    <table width="100%" border="0" cellpadding="0" cellspacing="5">
        <tr>
            <td align="right" width="15%">留言人：</td>
            <td width="85%">
                <asp:TextBox ID="TextBoxMemLoginID" runat="server" CssClass="allinput1 allinputon" ValidationGroup="vaConsult" readonly="true"></asp:TextBox>
                <asp:Label ID="Label8" runat="server" Text="*" ForeColor="red"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorMemLoginID" runat="server"
                    ControlToValidate="TextBoxMemLoginID" Display="Dynamic" ErrorMessage="该值不能为空" ValidationGroup="vaConsult"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorMemLoginID" runat="server"
                    ControlToValidate="TextBoxMemLoginID" Display="Dynamic" ErrorMessage="只能输入50个字符" ValidationGroup="vaConsult"
                    ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr style="display:none">
            <td align="right" width="15%">留言标题：</td>
            <td width="85%">
                <asp:TextBox ID="TextBoxTitle" CssClass="allinput1 allinputon" runat="server" TextMode="SingleLine"  ValidationGroup="vaConsult" ></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
<%--                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" ControlToValidate="TextBoxTitle"
                    Display="Dynamic" ErrorMessage="该值不能为空" ValidationGroup="vaConsult"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td align="right" width="15%" valign="middle">留言内容：</td>
            <td width="85%">
                <asp:TextBox ID="TextBoxContent" CssClass="allinput1 allinputon" runat="server" Height="60px" TextMode="MultiLine"
                    Width="440px" ValidationGroup="vaConsult" ></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorContent" runat="server" ControlToValidate="TextBoxContent"
                    Display="Dynamic" ErrorMessage="该值不能为空" ValidationGroup="vaConsult"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="TRVerifyCode" runat="server">
            <td style="text-align: right">
                <asp:Localize ID="LocalizeCode" runat="server" Text="验证码："></asp:Localize>
            </td>
            <td align="left" class="identyfy">
                <asp:TextBox ID="TextBoxCode" Style="border: 1px solid #dfdfdf;" runat="server" CssClass="allinput1"
                    onkeydown="if(event.keyCode==13){(document.getElementById('MessageBoardAdd_ctl00_ButtonConfrim')).focus();(document.getElementById('MessageBoardAdd_ctl00_ButtonConfrim')).click();}"></asp:TextBox>
                <img src="imagecode.aspx?javascript:Math.random()" id="Img1" border="0" onclick="reloadcode()" alt="看不清?点一下" />
                <a onclick="reloadcode()">看不清楚?点一下</a>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="ButtonConfirm" Text="确定" runat="server" class="fl commentSubmit" ValidationGroup="vaConsult"
                    UseSubmitBehavior="false" OnClientClick="if(Page_ClientValidate('vaConsult')){this.disabled=true;__doPostBack('ProductConsultListAdd$ctl00$ButtonConfirm','')} return false;" />
            </td>
        </tr>
    </table>
</div>
</div>