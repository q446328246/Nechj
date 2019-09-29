<%@ Control Language="C#" EnableViewState="false"%>

<script language="javascript" type="text/javascript">
    function reloadcode(){
    var verify=document.getElementById('Img1');
    verify.setAttribute('src','imagecode.aspx?'+Math.random());
    }
    
    function subCheck()
    {
       var VContent=$("#VideoCommentAdd_ctl00_TextBoxContent").val();
       if(VContent.length>200)
       {
          alert("评论内容不能超过200个字符!");return false;
       }
       return true;
    }
</script>

<div class="bBox bBoxnt" style="margin-top: 5px;">
    <h2>我要评论</h2>
    <div class="content voide_conts" style="padding: 0px;">
        <table width="100%" border="0" cellpadding="3">
            <tr>
                <td align="right"><label>用户名：</label></td>
                <td align="left">
                    <asp:TextBox ID="TextBoxMemLoginID" runat="server" CssClass="inpt_cont fqt_input" TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="Label8" runat="server" Text="*" ForeColor="red"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorMemLoginID" runat="server"
                        ControlToValidate="TextBoxMemLoginID" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorMemLoginID" runat="server"
                        ControlToValidate="TextBoxMemLoginID" Display="Dynamic" ErrorMessage="只能输入50个字符"
                        ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr style="display:none">
                <td align="right"><label>评论等级：</label></td>
                <td align="left">
                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="gp1" Checked="True" />
                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="../images/stars0.png" />
                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="gp1" />
                    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="../images/stars1.png" />
                    <asp:RadioButton ID="RadioButton3" runat="server" GroupName="gp1" />
                    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="../images/stars2.png" />
                    <asp:RadioButton ID="RadioButton4" runat="server" GroupName="gp1" />
                    <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="../images/stars3.png" />
                    <asp:RadioButton ID="RadioButton5" runat="server" GroupName="gp1" />
                    <asp:HyperLink ID="HyperLink5" runat="server" ImageUrl="../images/stars4.png" />
                </td>
            </tr>
            <tr style="display:none">
                <td align="right"><label>评论标题：</label></td>
                <td align="left">
                    <asp:TextBox ID="TextBoxTitle" Height="20" runat="server" CssClass="inpt_cont" TextMode="MultiLine" MaxLength="20"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" ControlToValidate="TextBoxTitle"
                        Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle" runat="server"
                        ControlToValidate="TextBoxTitle" Display="Dynamic" ErrorMessage="只能输入50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>--%>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top"><label>评论内容：</label></td>
                <td align="left">
                    <asp:TextBox ID="TextBoxContent" runat="server" CssClass="inpt_cont fqt_input" Height="74px"
                        TextMode="MultiLine" Width="440px" MaxLength="200"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label><br/>评论内容不能超过200个字符
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorContent" runat="server" ControlToValidate="TextBoxContent"
                        Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr id="VerifyCode" runat="server">
                <td align="right">
                    <label><asp:Localize ID="LocalizeCode" runat="server" Text="验证码："></asp:Localize></label>
                </td>
                <td align="left">
                    <p class="yanzma">
                        <asp:TextBox ID="TextBoxCode" runat="server" CssClass="allinput1 inpt_cont fqt_input fl"
                            onkeydown="if(event.keyCode==13){(document.getElementById('VideoCommentAdd_ctl00_ButtonConfirm')).focus();(document.getElementById('VideoCommentAdd_ctl00_ButtonConfirm')).click();}"></asp:TextBox>
                        <img class="yz_pict fl" src="imagecode.aspx?javascript:Math.random()" id="Img1" border="0"
                            onclick="reloadcode()" alt="看不清?点一下" style="cursor: pointer;" />
                        <a style="cursor: pointer; float:left; display:block; padding-left:4px; padding-top:12px;" onclick="reloadcode()">看不清楚?点一下</a>
                    </p>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td align="left"><asp:Button ID="ButtonConfirm" Text="" runat="server" CssClass="bnt1" OnClientClick="return subCheck()"/></td>
            </tr>
        </table>
    </div>
</div>
