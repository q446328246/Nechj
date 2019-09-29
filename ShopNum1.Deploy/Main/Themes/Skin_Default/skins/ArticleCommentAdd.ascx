<%@ Control Language="C#" %>
<script type="text/javascript">

    function reloadcode() {
        var verify = document.getElementById('Img1');
        verify.setAttribute('src', '/imagecode.aspx?' + Math.random());
    }
</script>
<div class="CommentsAdd" runat="server" id="CommentsAddShow">
    <h1 class="CommentsAdd_title">
        <span>发表评论</span></h1>
    <div class="pl CommentsAdd_con">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="MemberName">
                    用户名：
                </td>
                <td>
                    <asp:TextBox ID="TextBoxMemLoginID" runat="server" ReadOnly="true" Style="border: 1px solid #8f8f8f;
                        height: 20px; line-height: 20px;" MaxLength="30"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                    <a target="_self" href="" id="LoginHref" runat="server" visible="false" style="display: none;">
                        【登陆】</a>
                </td>
            </tr>
            <tr style="display: none">
                <td align="right">
                    评论等级：
                </td>
                <td>
                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="gp1" Checked="True" />
                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="../images/stars0.gif" />
                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="gp1" />
                    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="../images/stars1.gif" />
                    <asp:RadioButton ID="RadioButton3" runat="server" GroupName="gp1" />
                    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="../images/stars2.gif" />
                    <asp:RadioButton ID="RadioButton4" runat="server" GroupName="gp1" />
                    <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="../images/stars3.gif" />
                    <asp:RadioButton ID="RadioButton5" runat="server" GroupName="gp1" />
                    <asp:HyperLink ID="HyperLink5" runat="server" ImageUrl="../images/stars4.gif" />
                </td>
            </tr>
            <tr style="display: none">
                <td valign="middle">
                    评论标题：
                </td>
                <td>
                    <asp:TextBox ID="TextBoxTitle" runat="server" Style="border: 1px solid #8f8f8f; height: 20px;
                        line-height: 20px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="content">
                    评论内容：
                </td>
                <td>
                    <asp:TextBox ID="TextBoxContent" runat="server" Height="60px" TextMode="MultiLine"
                        Width="440px" Style="border: 1px solid #8f8f8f;" MaxLength="200"></asp:TextBox>
                    <asp:Label ID="Label3" runat="server" Text="*" ForeColor="red"></asp:Label>
                    <br />
                    评论内容不能超过200个字符
                </td>
            </tr>
            <tr id="trCode" runat="server">
                <td class="identifyCode">
                    验证码：
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0" class="identyTab">
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBoxCode" runat="server" Style="border: 1px solid #bbb; height: 24px;
                                    line-height: 24px;" MaxLength="4"></asp:TextBox>
                            </td>
                            <td>
                                <img src="imagecode.aspx?javascript:Math.random()" id="Img1" border="0" onclick="reloadcode()"
                                    alt="看不清?点一下" style="cursor: pointer;" />
                            </td>
                            <td>
                                <a style="cursor: pointer" onclick="reloadcode()" class="STYLE3">看不清楚?点一下</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    &nbsp;
                </td>
                <td class="submitBtn">
                    <asp:Button ID="ButtonConfirm" runat="server" Text="" UseSubmitBehavior="false" OnClientClick="if(SureConfirm()){this.disabled='disabled';}else{return false;}"
                        CssClass="submit" />
                </td>
            </tr>
        </table>
    </div>
</div>
<script type="text/javascript" language="javascript">
    function SureConfirm() {
        if ($("#ArticleCommentAdd_ctl00_TextBoxMemLoginID").val() == "") {
            alert("用户名不能为空！"); return false;
        }
        else if ($("#ArticleCommentAdd_ctl00_TextBoxContent").val() == "") {
            alert("评论内容不能为空！"); return false;
        }
        else if ($("#ArticleCommentAdd_ctl00_TextBoxContent").val().length > 200) {
            alert("评论内容不能超过200个字符!"); return false;
        }
        else if ($("#ArticleCommentAdd_ctl00_TextBoxCode").val() == "") {
            alert("验证码不能为空！"); return false;
        }
        else { return true; }
    }
</script>
