<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReChat.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.ReChat" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="t" %>
<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员列表</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
    <script type='text/javascript' src='js/resolution-test.js'></script>
    <script src="/Main/js/location.js" type="text/javascript"></script>
    <script src="/Main/js/areas.js" type="text/javascript"></script>
</head>
<body class="widthah" style=" font-weight:bold">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"
        runat="server">
    </asp:ScriptManager>
    <table align="center" bgcolor="Silver" cellpadding="4" cellspacing="1" width="100%">
                        <tr>
                            <td height="36" bgcolor="#ffffff" class="style4">
                                &nbsp;&nbsp;&nbsp;请输入会员编号：<asp:TextBox ID="ValueBox" runat="server" MaxLength="20"
                                    SkinID="TextBoxCss" Width="148px"></asp:TextBox>
                                &nbsp;<asp:Button ID="FindBtn" runat="server" CssClass="button_bak" Text="查找" UseSubmitBehavior="False"
                                    OnClick="FindBtn_Click" />

                                <input id="ReturnBtn" runat="server" class="button_bak" onclick="javascript:history.back(-1)"
                                    type="button" value="返回" />
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff">
                                <asp:TreeView ID="TreeView1" runat="server" ShowLines="True" EnableTheming="True"
                                    OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" OnTreeNodeExpanded="tvChart_TreeNodeExpanded">
                                    <ParentNodeStyle Font-Bold="False" />
                                    <HoverNodeStyle Font-Underline="False" />
                                    <SelectedNodeStyle Font-Underline="False" HorizontalPadding="4px" VerticalPadding="4px" />
                                    <RootNodeStyle Font-Bold="False" />
                                    <NodeStyle HorizontalPadding="4px" />
                                </asp:TreeView>
                            </td>
                        </tr>
                    </table>


    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
    <asp:HiddenField ID="HiddenFieldRegionCode" runat="server" Value="-1" />
    <asp:HiddenField ID="HiddenFieldRegionValue" runat="server" Value="-1" />
    </form>
</body>
</html>
