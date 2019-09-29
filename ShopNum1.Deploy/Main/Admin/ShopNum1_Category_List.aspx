<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopNum1_Category_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopNum1_Category_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>������Ϣ����</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabeTitle" runat="server" Text="������Ϣ����"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="table1" style="margin-bottom: 20px;">
                <asp:TreeView ID="TreeViewData" runat="server" OnSelectedNodeChanged="TreeViewData_SelectedNodeChanged"
                    ShowCheckBoxes="All" ShowLines="True" Style="padding-left: 20px;">
                    <RootNodeStyle Font-Bold="False" Font-Size="14px" />
                </asp:TreeView>
            </div>
            <div class="btnlist btnadd">
                <div class=" fl">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonAdd" runat="server" OnClientClick=" return GetCheckedBoxValues() "
                                    OnClick="ButtonAdd_Click" CausesValidation="False" class="tianjiafl lmf_btn"><span>��ӷ���</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonEdit" runat="server" OnClientClick=" return EditButton() "
                                    OnClick="ButtonEdit_Click" CausesValidation="False" class="bji lmf_btn"><span>�༭</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClientClick=" return DeleteButton() "
                                    OnClick="ButtonDelete_Click" CausesValidation="False" class="shanchu lmf_btn"><span>����ɾ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonNodeOperate" runat="server" ToolTip="NoExpand" OnClick="ButtonNodeOperate_Click"
                                    CausesValidation="False" class="zhankai lmf_btn"><span>ȫ��չ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetNewsCategoryList"
            TypeName="ShopNum1.ChinaBusinessLogic.China315_NewsCategory_Action">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="isDeleted" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
