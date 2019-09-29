<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnouncementCategory_List.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.AnnouncementCategory_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>公告分类列表</title>
        <link rel="stylesheet" type="text/css" href="style/css.css" />
        <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <%--  <div class="main">
        <div class="table1">
            <div class="navigator">
                【公告分类列表】</div>
            <asp:TreeView ID="TreeViewCategory" runat="server" ShowCheckBoxes="All" ShowLines="True">
                <RootNodeStyle Font-Bold="False" Font-Size="14px" />
            </asp:TreeView>
        </div>
    </div>
    <div class="bottomLine" style="background-color: #EEEEEE;">
        <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" OnClientClick="GetCheckedBoxValues()"
            Text="添加" CausesValidation="False" CssClass="addcate" />
        &nbsp;<asp:Button ID="ButtonEdit" runat="server" OnClick="ButtonEdit_Click" Text="编辑"
            CausesValidation="False" CssClass="dele"  OnClientClick="return EditButton()" />
        &nbsp;<asp:Button ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick="return EditButton()"
            Text="删除" CausesValidation="False"CssClass="dele"  />
            <asp:Button ID="ButtonNodeOperate" runat="server" Text="全部展开" CausesValidation="False"
            CssClass="bt3" OnClick="ButtonNodeOperate_Click" ToolTip="NoExpand"  CssClass="addcate"  />
        <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
    </div>--%>
            <div id="right">
                <div class="rhigth">
                    <div class="rl">
                    </div>
                    <div class="rcon">
                        <h3>
                            <asp:Label ID="LabeTitle" runat="server" Text="公告分类列表"></asp:Label></h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div class="table1" style="margin-bottom: 20px;">
                        <asp:TreeView ID="TreeViewCategory" runat="server" ShowCheckBoxes="All" ShowLines="True"
                                      Style="padding-left: 20px;">
                            <RootNodeStyle Font-Bold="False" Font-Size="14px" />
                        </asp:TreeView>
                    </div>
                    <div class="btnlist btnadd">
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td valign="top">
                                    <asp:LinkButton ID="ButtonAdd" runat="server" OnClientClick=" GetCheckedBoxValues() "
                                                    OnClick="ButtonAdd_Click" CausesValidation="False" class="tianjia2 lmf_btn"><span>添加</span></asp:LinkButton>
                                </td>
                                <td valign="top" class="lmf_app">
                                    <asp:LinkButton ID="ButtonEdit" runat="server" OnClientClick=" return EditButton() "
                                                    OnClick="ButtonEdit_Click" CausesValidation="False" class="bji lmf_btn"><span>编辑</span></asp:LinkButton>
                                </td>
                                <td valign="top" class="lmf_app">
                                    <asp:LinkButton ID="ButtonDelete" runat="server" OnClientClick=" return DeleteButton() "
                                                    OnClick="ButtonDelete_Click" CausesValidation="False" class="shanchu lmf_btn"><span>批量删除</span></asp:LinkButton>
                                </td>
                                <td valign="top" class="lmf_app">
                                    <asp:LinkButton ID="ButtonNodeOperate" runat="server" ToolTip="NoExpand" OnClick="ButtonNodeOperate_Click"
                                                    CausesValidation="False" class="zhankai lmf_btn"><span>全部展开</span></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                        <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        </form>
    </body>
</html>