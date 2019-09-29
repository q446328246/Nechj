<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="TbSetAppKey.aspx.cs" Inherits="ShopNum1.Deploy.Shop.ShopAdmin.TbTop.TbSetAppKey" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <link rel='stylesheet' type='text/css' href='../style/style.css' />
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="dpsc_mian">
                <p class="ptitle">
                    <a href="../S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span
                                                                                                   class="breadcrume_text">淘宝TOP系统参数</span></p>
                <div class="pad divheig" style="padding-left: 30px;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="lineh" style="line-height: 260%;">
                        <tr>
                            <td width="65" align="right" style="text-align: right;">
                                AppKey：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxTbKey" runat="server" Width="212px" CssClass="ss_nr1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxTbKey" runat="server"
                                                            ErrorMessage="不能为空!" ControlToValidate="TextBoxTbKey" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="65" align="right" style="text-align: right;">
                                AppSecret：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxTbSecret" runat="server" Width="212px" CssClass="ss_nr1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxTbSecret" runat="server"
                                                            ErrorMessage="不能为空!" ControlToValidate="TextBoxTbSecret" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="ButtonUpdate" runat="server" Text="修改" OnClick="ButtonUpdate_Click"
                                            CssClass="chax" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </form>
    </body>
</html>