<%@ Control Language="C#" %>
<div class="aBox">
    <h2>
        邮件订阅
    </h2>
    <div class="content">
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    订阅类型：
                    <asp:DropDownList ID="DropDownListBookTypeName" runat="server">
                    </asp:DropDownList>
                    <asp:Label ID="LabelBookTypeName" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    邮箱地址：
                    <asp:TextBox ID="TextBoxEmailAddress" runat="server" Width="100"></asp:TextBox><br />
                    <asp:Label ID="LabelEmailAddress" runat="server" Text="" ForeColor="Red"></asp:Label>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server"
                        ControlToValidate="TextBoxEmailAddress" Display="Dynamic" ErrorMessage="只能输入100个字符"
                        ValidationExpression="^[\s\S]{0,100}$"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmailAccout" runat="server"
                        ControlToValidate="TextBoxEmailAddress" Display="Dynamic" ErrorMessage="邮箱格式不正确！"
                        ValidationExpression="^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonConfirm" runat="server" Text="订阅" ToolTip="Submit" class="bnt1"
                        CausesValidation="False" />
                    &nbsp;
                    <asp:Button ID="ButtonCancelBook" runat="server" Text="退订" CausesValidation="False"
                        ToolTip="Submit" class="bnt1" />
                </td>
            </tr>
        </table>
    </div>
</div>
