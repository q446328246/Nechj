<%@ Control Language="C#" %>
<script type="text/javascript">

    function reloadcode() {
        var verify = document.getElementById('Img1');
        verify.setAttribute('src', '/imagecode.aspx?' + Math.random());
    }
    function subCheck() {
        var VContent = $("#SupplyDemandCommentAdd_ctl00_TextBoxContent").val();
        if (VContent.length > 500) {
            alert("评论内容不能超过500个字符!"); return false;
        }
        return true;
    }
</script>
<div class="CommentsAdd">
    <h1 class="CommentsAdd_title">
        <span>发表评论</span></h1>
    <div class="CommentsAdd_con">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="MemberName">
                    <label>
                        用户名：</label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxMemLoginID" CssClass="MemberNameArea" TextMode="MultiLine"
                        runat="server"></asp:TextBox>
                    <a id="LoginHref" runat="server">【登陆】</a>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                        ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBoxMemLoginID">用户名不能为空！</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="display: none">
                <td class="title">
                    <label>
                        评论标题：</label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TextBoxTitle" CssClass="titleArea" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="content">
                    <label>
                        评论内容：</label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxContent" CssClass="contentArea" MaxLength="200" runat="server"
                        TextMode="MultiLine" Width="400" Height="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                        ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBoxContent">评论内容不能为空！</asp:RequiredFieldValidator>
                    <br />
                    评论内容不能大于500个字符
                </td>
            </tr>
            <tr id="trCode" runat="server">
                <td class="identifyCode">
                    <label>
                        验证码：</label>
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0" border="0" class="identyTab">
                        <tr>
                            <td valign="middle" align="left">
                                <asp:TextBox ID="TextBoxCode" Style="border: 1px solid #bbb; height: 24px; line-height: 24px;"
                                    onfocus="this.value=''" TextMode="MultiLine" MaxLength="4" runat="server" onkeydown="if(event.keyCode==13){document.getElementById('SupplyDemandCommentAdd_ctl00_ButtonAdd').focus();document.getElementById('SupplyDemandCommentAdd_ctl00_ButtonAdd').click();}"></asp:TextBox>
                            </td>
                            <td valign="middle" align="left">
                                <img src="/imagecode.aspx?javascript:Math.random()" id="Img1" border="0" onclick="reloadcode()"
                                    alt="看不清?点一下" style="cursor: pointer;" />
                            </td>
                            <td valign="middle" align="left">
                                <a style="cursor: pointer" onclick="reloadcode()">看不清楚?点一下</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td class="submitBtn">
                    <span>
                        <asp:Button ID="ButtonAdd" class="submit" runat="server" Text="" OnClientClick="return subCheck();" /></span>
                </td>
            </tr>
        </table>
    </div>
</div>
