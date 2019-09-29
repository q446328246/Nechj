<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_MemberUpgrade2.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_MemberUpgrade2" %>
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
<div id="content" class="ordmain1">
    <div class="pad">
        <table border="0" cellspacing="0" cellpadding="0" class="lineh">
        <tr class="up_spac">
                <td style="border-left: 1px solid #C6DFFF;border-top: 1px solid #C6DFFF; ">
                    上传身份证：
                </td>
                <td colspan="3" style="border-top: 1px solid #C6DFFF; ">
                    <asp:FileUpload ID="FileUploadIdentityCardImage" runat="server" onchange="funUpdateImage1()" /><span
                        class="gray1" id="Span7" style="color: red">&nbsp;</span>
                        
                </td>
                <td width="50" style="border-right: 1px solid #C6DFFF;border-top: 1px solid #C6DFFF;">
                </td>
            </tr>
            <tr class="up_spac">
                <td style="border-left: 1px solid #C6DFFF;border-top: 1px solid #C6DFFF; ">
                    上传营业执照：
                </td>
                <td colspan="3" style="border-top: 1px solid #C6DFFF; ">
                    <asp:FileUpload ID="FileUploadLicenseImage" runat="server" onchange="funUpdateImage1()" /><span
                        class="gray1" id="errIdentityCardimage" style="color: red">&nbsp;</span>
                        
                </td>
                <td width="50" style="border-right: 1px solid #C6DFFF;border-top: 1px solid #C6DFFF;">
                </td>
            </tr>
            <tr class="up_spac">
                <td style="border-left: 1px solid #C6DFFF;border-top: 1px solid #C6DFFF; ">
                    上传房租租赁合同：
                </td>
                <td colspan="3" style="border-top: 1px solid #C6DFFF; ">
                    <asp:FileUpload ID="FileUploadOrganizationImage" runat="server" onchange="funUpdateImage1()" /><span
                        class="gray1" id="Span1" style="color: red">&nbsp;</span>
                        
                </td>
                <td width="50" style="border-right: 1px solid #C6DFFF;border-top: 1px solid #C6DFFF;">
                </td>
            </tr>
            <tr class="up_spac">
                <td style="border-left: 1px solid #C6DFFF;border-top: 1px solid #C6DFFF; ">
                    上传税务登记：
                </td>
                <td colspan="3" style="border-top: 1px solid #C6DFFF; ">
                    <asp:FileUpload ID="FileUploadRegistrationImage" runat="server" onchange="funUpdateImage1()" /><span
                        class="gray1" id="Span2" style="color: red">&nbsp;</span>
                        
                </td>
                <td width="50" style="border-right: 1px solid #C6DFFF;border-top: 1px solid #C6DFFF;">
                </td>
            </tr>
            <tr class="up_spac">
                <td style="border-left: 1px solid #C6DFFF;border-top: 1px solid #C6DFFF; ">
                    上传店铺内部情况1：
                </td>
                <td colspan="3" style="border-top: 1px solid #C6DFFF; ">
                    <asp:FileUpload ID="FileUploadShopImageone" runat="server" onchange="funUpdateImage1()" /><span
                        class="gray1" id="Span3" style="color: red">&nbsp;</span>
                        
                </td>
                <td width="50" style="border-right: 1px solid #C6DFFF;border-top: 1px solid #C6DFFF;">
                </td>
            </tr>
            <tr class="up_spac">
                <td style="border-left: 1px solid #C6DFFF;border-top: 1px solid #C6DFFF; ">
                    上传店铺内部情况2：
                </td>
                <td colspan="3" style="border-top: 1px solid #C6DFFF; ">
                    <asp:FileUpload ID="FileUploadShopImagetwo" runat="server" onchange="funUpdateImage1()" /><span
                        class="gray1" id="Span4" style="color: red">&nbsp;</span>
                        
                </td>
                <td width="50" style="border-right: 1px solid #C6DFFF;border-top: 1px solid #C6DFFF;">
                </td>
            </tr>
            <tr class="up_spac">
                <td style="border-left: 1px solid #C6DFFF;border-top: 1px solid #C6DFFF; ">
                    上传开业门头照片：
                </td>
                <td colspan="3" style="border-top: 1px solid #C6DFFF; ">
                    <asp:FileUpload ID="FileUploadOpeningImage" runat="server" onchange="funUpdateImage1()" /><span
                        class="gray1" id="Span5" style="color: red">&nbsp;</span>
                        
                </td>
                <td width="50" style="border-right: 1px solid #C6DFFF;border-top: 1px solid #C6DFFF;">
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
            <tr class="up_spac">
                <td></td><td></td><td><asp:Button ID="Button1" runat="server" Text="申请" class="chax btn_spc" name="12"
                        OnClick="ButtonUpgrade_Click" /></td><td></td><td></td>

            </tr>
           
        </table>
    </div>
</div>
