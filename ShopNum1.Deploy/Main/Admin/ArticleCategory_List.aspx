<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleCategory_List.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.ArticleCategory_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>资讯分类管理</title>
        <link rel="stylesheet" type="text/css" href="style/css.css" />
        <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
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
                            <asp:Label ID="LabeTitle" runat="server" Text="资讯分类管理"></asp:Label></h3>
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
                        <div class=" fl">
                            <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" OnClientClick=" GetCheckedBoxValues() "
                                        Text="添加分类" CausesValidation="False" CssClass="tianjiafl picbtn" />
                            <asp:Button ID="Button2" runat="server" OnClick="ButtonEdit_Click" Text="编辑" CausesValidation="False"
                                        CssClass="bji picbtn" />
                            <asp:Button ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" if (window.confirm('您确定要删除吗?')) {return EditButton();
                            } else {return false;} " Text="删除" CausesValidation="False" CssClass="shanchu com" />
                            <asp:Button ID="ButtonNodeOperate" runat="server" Text="全部展开" CausesValidation="False"
                                        CssClass="zhankai picbtn" OnClick="ButtonNodeOperate_Click" ToolTip="NoExpand" />
                            <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                </div>
                <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="GetNewsCategoryList"
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