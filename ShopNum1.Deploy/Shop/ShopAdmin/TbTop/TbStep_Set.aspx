<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="TbStep_Set.aspx.cs" Inherits="ShopNum1.Deploy.Shop.ShopAdmin.TbTop.TbStep_Set" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <link rel='stylesheet' type='text/css' href='../style/style.css' />
        <style type="text/css">
            .TB_h21 {
                background: url(images/icon.gif) 13px 2px no-repeat;
                color: #0279cc;
                font-size: 14px;
                padding-left: 35px;
            }

            .TB_h22 {
                background: url(images/icon.gif) 13px top no-repeat;
                color: #0279cc;
                font-size: 14px;
                padding-left: 35px;
            }
        </style>
    </head>
    <body class="right_body">
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="dpsc_mian">
            <p class="ptitle">
                <a href="../S_Welcome.aspx">��������</a><span class="breadcrume_icon">>></span><span
                                                                                               class="breadcrume_text">�Ա�ͬ������</span></p>
            <div class="taobaopad" style="margin-left: 15px;">
                <div style="line-height: 30px; padding-top: 8px; width: 740px;">
                    <p class="ultit">
                        ͬ������/�ر�</p>
                    <div style="height: 30px; line-height: 30px; padding-left: 20px;">
                        <asp:RadioButton ID="radStepOpen" runat="server" Text="����" GroupName="radstep" onclick="itemDivSet.style.display='block'" />
                        <asp:RadioButton ID="radStepClose" runat="server" Text="�ر�" GroupName="radstep" onclick="itemDivSet.style.display='none'" />
                    </div>
                    <div style="padding: 0 0 10px 20px;">
                        ���󶨵��Ա���Ϊ�� <span runat="server" id="spanShopName">andyoneandy</span>
                    </div>
                </div>
                <div style="display: none; margin-top: 20px;">
                    <p class="ultit">
                        ��������</p>
                    <div style="height: 25px; line-height: 25px; padding-left: 20px;">
                        ��Ʒ����ҳ�м����Ա����ۣ�
                        <asp:RadioButton ID="RadioButtonPlOpen" runat="server" Checked="true" Text="����" GroupName="radPl" />
                        <asp:RadioButton ID="RadioButtonPlClose" runat="server" Text="�ر�" GroupName="radPl" />
                    </div>
                </div>
                <div id="itemDivSet">
                    <div style="display: none; margin: 20px auto 20px auto;">
                        <p class="ultit">
                            ��������</p>
                        <div style="height: 25px; line-height: 25px; padding-left: 20px;">
                            ��Ʒ����ҳ�м����Ա�������<asp:RadioButton ID="radOrderOpen" Checked="true" runat="server" Text="��

��" GroupName="radOrder" />
                            <asp:RadioButton ID="radOrderClose" runat="server" Text="�ر�" GroupName="radOrder" />
                        </div>
                    </div>
                    <div>
                        <p class="ultit">
                            ��Ʒ˫��ͬ������ʱ��ͬ�����ã����Ա�������Ʒ���ܹ���Ӱ�죩</p>
                        <div style="padding-left: 20px;">
                            <table>
                                <tr style="height: 25px; line-height: 25px;">
                                    <td>
                                        ��Ʒ���⣺
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="tTitleTtS" runat="server" Text="�Ա�->���� " />
                                    </td>
                                </tr>
                                <tr style="height: 25px; line-height: 25px;">
                                    <td>
                                        ��Ʒ�۸�
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="tPriceTtS" runat="server" Text="�Ա�->���� " />
                                    </td>
                                </tr>
                                <tr style="height: 25px; line-height: 25px;">
                                    <td>
                                        �Զ���Ŀ��
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="tTypeTtS" runat="server" Text="�Ա�->���� " />
                                    </td>
                                </tr>
                                <tr style="height: 25px; line-height: 25px;">
                                    <td>
                                        ��Ʒ������
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="tCountTtS" runat="server" Text="�Ա�->���� " />
                                    </td>
                                </tr>
                                <tr style="height: 25px; line-height: 25px;">
                                    <td>
                                        ��Ʒ������
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="tDescTtS" runat="server" Text="�Ա�->���� " />
                                    </td>
                                </tr>
                                <tr style="display: none; height: 25px; line-height: 25px;">
                                    <td>
                                        ͼƬ���ص����أ�
                                    </td>
                                    <td colspan="2">
                                        <asp:RadioButton ID="RadioButtonTimg" runat="server" Text="��" GroupName="RadioButtonTimg" />
                                        <asp:RadioButton ID="RadioButtonTimgNo" runat="server" Text="��" GroupName="RadioButtonTimg"
                                                         Checked="true" />
                                        (ϵͳĬ����"��",�Ա�������Ʒ������ʱ��ͼƬ����Ĭ����ʹ���Ա�ͼƬ����)
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <table width="120" style="margin-top: 15px;">
                            <tr>
                                <td>
                                    <asp:LinkButton ID="btnOK" runat="server" OnClick="btnOK_Click" CssClass="tjbtn">ȷ��</asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="btnCancel" runat="server" CssClass="tjbtn">ȡ��</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>