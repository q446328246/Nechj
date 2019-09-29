<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopNum1Region_list.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopNum1Region_list" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>区域分类列表</title>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabeTitle" runat="server" Text="地区列表"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="table1" style="margin-bottom: 20px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TreeView ID="TreeViewData" runat="server" OnSelectedNodeChanged="TreeViewData_SelectedNodeChanged"
                            ShowCheckBoxes="All" ShowLines="True" Style="margin-left: 20px;" OnTreeNodeExpanded="TreeViewData_TreeNodeExpanded">
                            <RootNodeStyle Font-Bold="False" Font-Size="14px" />
                        </asp:TreeView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="btnlist btnadd">
                <div class=" fl">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonAdd" runat="server" CausesValidation="False" CssClass="tianjiafl lmf_btn"
                                    OnClick="ButtonAdd_Click" OnClientClick=" return GetCheckedBoxValues() "><span>添加分类</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="Button2" runat="server" CausesValidation="False" CssClass="bji lmf_btn"
                                    OnClientClick=" return EditButton() " OnClick="ButtonEdit_Click"><span>编辑</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" CausesValidation="False" CssClass="shanchu lmf_btn"
                                    OnClientClick=" return EditButton() " OnClick="ButtonDelete_Click"><span>批量删除</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonNodeOperate" runat="server" CausesValidation="False" CssClass="zhankai lmf_btn"
                                    OnClick="ButtonNodeOperate_Click" ToolTip="NoExpand"><span>全部展开</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <ShopNum1:MessageShow ID="MessageShow1" Visible="false" runat="server" />
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
