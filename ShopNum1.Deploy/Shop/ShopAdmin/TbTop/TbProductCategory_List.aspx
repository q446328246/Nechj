<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="TbProductCategory_List.aspx.cs" Inherits="ShopNum1.Deploy.Shop.ShopAdmin.TbTop.TbProductCategory_List" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <link rel='stylesheet' type='text/css' href='../style/style.css' />
        <link rel="stylesheet" type="text/css" href="style/index.css" />
        <script src="/JS/CommonJS.js" type="text/javascript"> </script>
        <script src="/JS/jquery-1.6.2.min.js" type="text/javascript"> </script>
        <script type="text/javascript">
            function DeleteButton() {
                var checkedBoxValues = GetCheckedBoxValues();
                if (checkedBoxValues == "0") {
                    alert("��ѡ��Ҫɾ���ļ�¼��");
                    return false;
                } else if (window.confirm("��ȷ��Ҫɾ����?")) {
                    document.getElementById("CheckGuid").value = checkedBoxValues.replace('0,', '');
                    return true;
                } else {
                    return false;
                }
            }
        </script>
    </head>
    <body class="right_body">
        <form id="form1" runat="server">
            <div class="dpsc_mian">
                <p class="ptitle">
                    <a href="../S_Welcome.aspx">��������</a><span class="breadcrume_icon">>></span><span
                                                                                                   class="breadcrume_text">������Ʒ����</span></p>
                <div style="line-height: 30px; padding-left: 8px; padding-top: 8px; width: 740px;">
                    <p class="ultit">
                        ��Ʒ���࣬�����Ǻ��Ա��̼��Զ���������Ӧ��</p>
                    <asp:TreeView ID="TreeViewData" runat="server" ShowCheckBoxes="All">
                    </asp:TreeView>
                    <table width="270">
                        <tr>
                            <td>
                                <asp:LinkButton ID="ButtonAdd" runat="server" CssClass="tjbtn1" PostBackUrl="" OnClick="ButtonAdd_Click">��ӷ���</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton runat="server" ID="ButtonEdit" CssClass="tjbtn" OnClick="ButtonEdit_Click">�༭</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton runat="server" ID="ButtonDelete" CssClass="tjbtn" OnClientClick=" return DeleteButton() "
                                                OnClick="ButtonDelete_Click">ɾ��</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="ButtonNodeOperate" runat="server" CausesValidation="False" CssClass="tjbtn1"
                                                ToolTip="NoExpand" OnClick="ButtonNodeOperate_Click">ȫ��չ��</asp:LinkButton>
                            </td>
                            <td>
                                <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </form>
    </body>
</html>