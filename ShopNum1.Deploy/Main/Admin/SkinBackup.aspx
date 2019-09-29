<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="SkinBackup.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.SkinBackup" %>

<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>模板备份</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <script src="js/CommonJS.js" type="text/javascript"></script>
    <style type="text/css">
        .backa a
        {
            display: block;
            margin: 0;
        }
        .backa .lmf_l
        {
            float: left;
        }
        .backa .lmf_r
        {
            float: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    模板备份</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="backcon">
                <div class="query" style="border-bottom: 1px #c4d2db dashed;">
                    <div class="backimg">
                        <%--<img src="images/moban.jpg" width="132" height="138" style="border:1px solid #ffffff;" />--%>
                        <asp:Image ID="ImageCurrentSkin" runat="server" Height="138" Width="132" BackColor="White"
                            BorderStyle="Solid" BorderWidth="1" />
                    </div>
                    <div class="bname" style="padding: 10px 5px; color: #464646;">
                        <p>
                            <b>当前模板</b></p>
                        <p>
                            模板文件夹名称：
                            <asp:Label ID="LabelFolderNameValue" runat="server"></asp:Label></p>
                        <p>
                            模板名称：
                            <asp:Label ID="LabelNameValue" runat="server"></asp:Label></p>
                        <p>
                            模板说明：
                            <asp:Label ID="LabelDescriptionValue" runat="server"></asp:Label></p>
                        <asp:Button ID="ButtonBackUp" runat="server" Text="备份当前模板" CssClass="backupbtn" OnClick="ButtonBackUp_Click" />
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="btit">
                    <asp:Label ID="LabelSkins" runat="server" Text="可恢复模板"></asp:Label>
                </div>
                <div class="backlist">
                    <ul>
                        <asp:DataList ID="DataListShow" runat="server" RepeatDirection="Horizontal" Width="100%"
                            HorizontalAlign="Center" OnItemCommand="DataListShow_ItemCommand" RepeatLayout="Flow">
                            <ItemTemplate>
                                <li style="text-align: center;">
                                    <div class="bfrist">
                                        <img src="images/moban.jpg" width="127" height="133" />
                                        <div class="lmf_xuanzhong">
                                        </div>
                                        <div class="lmf_xuanzhongtext">
                                            正在使用</div>
                                    </div>
                                    <p style="font-size: 14px; color: #333; padding-top: 5px;">
                                        <asp:Label ID="LabelNameValue" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["Name"].ToString()%>'></asp:Label>
                                    </p>
                                    <p class="time" style="height: 18px; line-height: 18px;">
                                        <asp:Label ID="LabelCreateTime" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["createTime"].ToString()%>'></asp:Label>
                                    </p>
                                    <div class="backa">
                                        <asp:LinkButton ID="LinkButtonSelect" runat="server" CommandName="select" CssClass="lmf_l">恢复模板</asp:LinkButton><asp:LinkButton
                                            ID="LinkButtonDel" runat="server" CommandName="delete" CssClass="lmf_r" OnClientClick="return confirm('是否确认删除?')">删除模板</asp:LinkButton>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:DataList>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
