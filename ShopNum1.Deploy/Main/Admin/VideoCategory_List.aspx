<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="VideoCategory_List.aspx.cs"
         Inherits="ShopNum1.Deploy.Main.Admin.VideoCategory_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <link rel='stylesheet' type='text/css' href='style/css.css' />
        <link rel="stylesheet" type="text/css" href="style/css.css" />
        <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    </head>
    <body style="background-image: url(images/Bg_right.gif); background-repeat: repeat; padding: 0;" alink="200%">
        <form id="form1" runat="server">
            <div id="right">
                <div class="rhigth">
                    <div class="rl">
                    </div>
                    <div class="rcon">
                        <h3>
                            视频分类</h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix" style="height: 800px;">
                    <div style="margin-bottom: 20px;">
                        <asp:TreeView ID="TreeViewCategory" runat="server" ShowCheckBoxes="All" ShowLines="True"
                                      Style="margin-left: 20px;">
                            <RootNodeStyle Font-Bold="False" Font-Size="12px" />
                        </asp:TreeView>
                    </div>
                    <div class="btnlist btnadd">
                        <div class=" fl">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td valign="top">
                                        <asp:LinkButton ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" OnClientClick=" GetCheckedBoxValues() "
                                                        CausesValidation="False" CssClass="tianjiafl lmf_btn"><span>添加分类</span></asp:LinkButton>
                                    </td>
                                    <td valign="top" class="lmf_app">
                                        <asp:LinkButton ID="ButtonEdit" runat="server" OnClick="ButtonEdit_Click" CausesValidation="False"
                                                        CssClass="bji lmf_btn" OnClientClick=" return EditButton() "><span>编辑</span></asp:LinkButton>
                                    </td>
                                    <td valign="top" class="lmf_app">
                                        <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                                        CausesValidation="False" CssClass="shanchu lmf_btn"><span>批量删除</span></asp:LinkButton>
                                    </td>
                                    <td valign="top" class="lmf_app">
                                        <asp:LinkButton ID="ButtonNodeOperate" runat="server" CausesValidation="False" CssClass="zhankai lmf_btn"
                                                        OnClick="ButtonNodeOperate_Click" ToolTip="NoExpand"><span>全部展开</span></asp:LinkButton>
                                    </td>
                                    <td valign="top" class="lmf_app">
                                        <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        </form>
    </body>
</html>