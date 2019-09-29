<%@ Control Language="C#" %>
<script language="javascript" type="text/javascript">
    function reloadcode() {
        var verify = document.getElementById('Img1');
        verify.setAttribute('src', 'imagecode.aspx?' + Math.random());
    }
</script>
<div style="margin-top: 12px;">
    <div class="bBoxnt">
        <h2>
            我要评论</h2>
    </div>
    <div style="border: 1px solid #D4D4D4; padding: 8px;">
        <table width="100%" border="0" cellpadding="3">
            <tr>
                <td align="right">
                    用户名：
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="TextBoxMemLoginID" ValidationGroup="comment" runat="server" Style="border: 1px solid #B70113;"></asp:TextBox>
                    <asp:Label ID="Label8" runat="server" Text="*" ForeColor="red"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorMemLoginID" runat="server"
                        ControlToValidate="TextBoxMemLoginID" ValidationGroup="comment" Display="Dynamic"
                        ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorMemLoginID" runat="server"
                        ControlToValidate="TextBoxMemLoginID" ValidationGroup="comment" Display="Dynamic"
                        ErrorMessage="只能输入50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    评论等级：
                </td>
                <td style="text-align: left">
                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="gp1" Checked="True" />
                    <asp:HyperLink ID="HyperLink5" runat="server" ImageUrl="../images/stars4.gif" />
                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="gp1" />
                    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="../images/stars2.gif" />
                    <asp:RadioButton ID="RadioButton3" runat="server" GroupName="gp1" />
                    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="../images/stars1.gif" />
                    <asp:RadioButton ID="RadioButton4" runat="server" GroupName="gp1" />
                    <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="../images/stars3.gif" />
                    <asp:RadioButton ID="RadioButton5" runat="server" GroupName="gp1" />
                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="../images/stars0.gif" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    评论标题：
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="TextBoxTitle" ValidationGroup="comment" runat="server" Style="border: 1px solid #B70113;"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" ControlToValidate="TextBoxTitle"
                        Display="Dynamic" ValidationGroup="comment" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle" runat="server"
                        ControlToValidate="TextBoxTitle" ValidationGroup="comment" Display="Dynamic"
                        ErrorMessage="只能输入50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    评论内容：
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="TextBoxContent" runat="server" Height="60px" TextMode="MultiLine"
                        Width="440px" Style="border: 1px solid #B70113;"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorContent" runat="server" ControlToValidate="TextBoxContent"
                        Display="Dynamic" ValidationGroup="comment" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr id="VerifyCode" runat="server">
                <td style="text-align: right">
                    <asp:Localize ID="LocalizeCode" runat="server" Text="验证码："></asp:Localize>
                </td>
                <td align="left">
                    <asp:TextBox ID="TextBoxCode" Style="border: 1px solid #B70113;" runat="server" CssClass="allinput1"
                        onkeydown="if(event.keyCode==13){(document.getElementById('MessageBoardAdd_ctl00_ButtonConfrim')).focus();(document.getElementById('MessageBoardAdd_ctl00_ButtonConfrim')).click();}"></asp:TextBox>
                    <img src="imagecode.aspx?javascript:Math.random()" id="Img1" border="0" onclick="reloadcode()"
                        alt="看不清?点一下" style="cursor: pointer;" />
                    <a style="cursor: pointer" onclick="reloadcode()">看不清楚?点一下</a>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="text-align: left">
                    <asp:Button ID="ButtonConfirm" ValidationGroup="comment" Text="确定" runat="server"
                        CssClass="bnt1" />
                </td>
            </tr>
        </table>
    </div>
