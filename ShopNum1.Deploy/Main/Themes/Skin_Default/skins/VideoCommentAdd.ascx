<%@ Control Language="C#" %>
<script language="javascript" type="text/javascript">
    // 评论验证码刷新
    function reloadcodeVideoCommentAdd() {
        var verify = document.getElementById('VideoCommentAddVerifyImg');
        verify.setAttribute('src', 'imagecode.aspx?' + Math.random());
    }

    function subCheck() {
        var VContent = $("#VideoCommentAdd_ctl00_TextBoxContent").val();
        if (VContent.length > 200) {
            alert("评论内容不能超过200个字符!"); return false;
        }
        return true;
    }
</script>
<div class="CommentsAdd_con">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr style="height: 50px;">
            <td align="right" width="15%">
                用户名：
            </td>
            <td width="85%">
                <asp:TextBox ID="TextBoxMemLoginID" runat="server" CssClass="MemLoginID" ReadOnly="true"></asp:TextBox>
                <asp:Label ID="Label8" runat="server" Text="*" ForeColor="red"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorMemLoginID" runat="server"
                    ControlToValidate="TextBoxMemLoginID" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorMemLoginID" runat="server"
                    ControlToValidate="TextBoxMemLoginID" Display="Dynamic" ErrorMessage="只能输入50个字符"
                    ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="15%" valign="top">
                评论内容：
            </td>
            <td width="85%">
                <asp:TextBox ID="TextBoxContent" runat="server" TextMode="MultiLine" CssClass="contentArea"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorContent" runat="server" ControlToValidate="TextBoxContent"
                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                <br />
                评论内容不能超过200字符
            </td>
        </tr>
        <tr style="height: 45px;">
            <td align="right" width="15%">
                <asp:Label ID="LabelCheckCode" runat="server" Text="验证码："></asp:Label>
            </td>
            <td width="85%">
                <div id="divVerifyCode" runat="server">
                    <table cellpadding="0" cellspacing="0" border="0" class="identyTab">
                        <tr>
                            <td valign="middle" align="left">
                                <input runat="server" id="VideoCommentAddVerifyCode" name="VideoCommentAddVerifyCode"
                                    type="text" value="请输入验证码" onfocus="this.value=''" onkeydown="if(event.keyCode==13){(document.getElementById('VideoCommentAdd_ctl00_ButtonConfirm')).focus();(document.getElementById('VideoCommentAdd_ctl00_ButtonConfirm')).click();}"
                                    class="identyArea" />
                            </td>
                            <td valign="middle" align="left">
                                <img src="imagecode.aspx" id="VideoCommentAddVerifyImg" onclick="reloadcodeVideoCommentAdd()"
                                    alt="看不清?点一下" />
                            </td>
                            <td valign="middle" align="left">
                                <a style="cursor: pointer" onclick="reloadcodeVideoCommentAdd()">看不清楚?点一下</a>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="submitBtn">
                <span>
                    <asp:Button ID="ButtonConfirm" runat="server" CssClass="submit" OnClientClick="return subCheck();" /></span>
            </td>
        </tr>
    </table>
</div>
