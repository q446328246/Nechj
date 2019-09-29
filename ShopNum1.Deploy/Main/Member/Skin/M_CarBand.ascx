<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_CarBand.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_CarBand" %>
<script type="text/javascript">
    $(document).ready(function () {
        check();

        $(":radio").click(function () {
            check();
        });

        function check() {
            if ($("input[name='M_MemberUpgrade2$radbutton']").attr("checked") == 'checked') {
                $("span[name='M_MemberUpgrade2$TextBoxPlacement']").hide();


            } else {
                $("span[name='M_MemberUpgrade2$TextBoxPlacement']").show();
            }
        }
    });
</script>
<div class="pad">
        <table border="0" cellspacing="0" cellpadding="0" class="lineh">
                        <tr class="up_spac">
                <td align="center" colspan="5" style="border-left: 1px solid #C6DFFF; border-top: 1px solid #C6DFFF;
                    border-right: 1px solid #C6DFFF;">
                    <span style="font-size: 15px; color: red;">绑定车辆</span>
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right">
                    请选车辆类型：
                </td>
                <td width="150">
                    <asp:RadioButton GroupName="radbutton" ID="RadioButtonAgentMember" name="RadioButtonAgentMember" runat="server"
                        Checked="True" />&nbsp;&nbsp;<span style="font-size: 15px; color: red;">新能源汽车</span>
                </td>
                <td>
                </td>
                <td width="150">
                    <asp:RadioButton GroupName="radbutton" ID="RadioButtonCommunityMember" 
                        name="RadioButtonCommunityMember" runat="server"  />&nbsp;&nbsp;<span
                        style="font-size: 15px; color: red;">燃油汽车</span>
                </td>
                <td width="50">
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right">
                    车牌号：
                </td>
                <td width="150">
                    <asp:TextBox ID="TextBoxShopNames" name="TextBoxShopNames" runat="server" 
                        class="ss_nr1" MaxLength="32"></asp:TextBox>
                </td>
                <td align="right"  >
                  设备号：
                </td>
                <td width="150">
                    <asp:TextBox ID="Textshebei" runat="server" class="ss_nr1" MaxLength="32"></asp:TextBox>
                </td>
                <td width="50">
                </td>
            </tr>





            <%--<tr class="up_spac">
                <td style="border-left: 1px solid #C6DFFF;border-top: 1px solid #C6DFFF; ">
                    上传身份证：
                </td>
                <td colspan="3" style="border-top: 1px solid #C6DFFF; ">
                    <asp:FileUpload ID="FileUploadIdentityCardImage" runat="server" onchange="funUpdateImage1()" /><span
                        class="gray1" id="errIdentityCardimage" style="color: red">&nbsp;</span>
                        
                </td>
                <td width="50" style="border-right: 1px solid #C6DFFF;border-top: 1px solid #C6DFFF;">
                </td>
            </tr>
            <tr class="up_spac">
                
                <td colspan="4" style="border-bottom: 1px solid #C6DFFF;border-left: 1px solid #C6DFFF;">
                    <span
                        class="gray1" id="errIdentityCardimage" style="color: red">&nbsp;格式jpg，jpeg，png，gif，请保证图片清晰且文件大小不超过500KB</span>
                        
                </td>
                <td width="50" style="border-right: 1px solid #C6DFFF; border-bottom: 1px solid #C6DFFF;">
                </td>
            </tr>--%>


        <tr class="up_spac">
                <td align="right">
                    上传行驶证：
                </td>
                <td colspan="3" >
                    <asp:FileUpload ID="FileUploadOrganizationImage" runat="server" onchange="funUpdateImage1()" /><span
                        class="gray1" id="Span7" style="color: red">&nbsp;</span>
                        
                </td>
                <td width="50" >
                </td>
            </tr>


          <tr class="up_spac">
                
                <td colspan="4" style="border-bottom: 1px solid #C6DFFF;border-left: 1px solid #C6DFFF;">
                    <span
                        class="gray1" id="Span6" style="color: red">&nbsp;格式jpg，jpeg，png，gif，请保证图片清晰且文件大小不超过500KB</span>
                        
                </td>
                <td width="50" style="border-right: 1px solid #C6DFFF; border-bottom: 1px solid #C6DFFF;">
                </td>
            </tr>
          
      
     

            <tr class="up_spac" >
                <td ></td><td></td><td><asp:Button ID="Button1" runat="server" Text="申请" class="chax btn_spc" name="12"
                        OnClick="ButtonUpgrade_Click" /></td><td></td><td></td>

            </tr>
           
        </table>
    </div>
</div>
