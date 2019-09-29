<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="SkinSelect.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.SkinSelect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ģ�����</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <script src="js/CommonJS.js" type="text/javascript"> </script>
    <script type="text/javascript">
        $(function () {
            //����Ч��
            $(".bfrist").hover(function () {
                $(this).addClass("skinhover");

            },
                    function () {
                        $(this).removeClass("skinhover");
                    }); //ѡ��Ч��
            var LabelNameValue = $("#LabelNameValue").html();
            var DataList_NameValue = $(".bfrist").next().children("span");
            for (var i = 0; i < DataList_NameValue.length; i++) {
                if ($(DataList_NameValue[i]).html() == LabelNameValue) {
                    $(DataList_NameValue[i]).parent().prev(".bfrist").addClass("skinSelect");
                }
            }

        })

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    ģ�����</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="backcon">
                <div class="query" style="border-bottom: 1px #c4d2db dashed;">
                    <div class="backimg">
                        <asp:Image ID="ImageCurrentSkin" runat="server" Height="138" Width="132" BackColor="White"
                            BorderStyle="Solid" BorderWidth="1" />
                    </div>
                    <div class="bname" style="color: #464646; padding: 10px 5px;">
                        <p>
                            <b>
                                <asp:Label ID="LabelCurrentSkins" runat="server" Text="��ǰģ��"></asp:Label></b></p>
                        <p>
                            <asp:Label ID="LabelFolderName" runat="server" Text="ģ���ļ������ƣ�"></asp:Label>
                            <asp:Label ID="LabelFolderNameValue" runat="server"></asp:Label></p>
                        <p>
                            <asp:Label ID="LabelName" runat="server" Text="ģ�����ƣ�"></asp:Label>
                            <asp:Label ID="LabelNameValue" runat="server"></asp:Label></p>
                        <p>
                            <asp:Label ID="LabelDescription" runat="server" Text="ģ��˵����"></asp:Label>
                            <asp:Label ID="LabelDescriptionValue" runat="server"></asp:Label>
                        </p>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="btit">
                    <asp:Label ID="LabelSkins" runat="server" Text="����ģ��"></asp:Label>
                </div>
                <div class="backlist">
                    <ul>
                        <asp:DataList ID="DataListShow" runat="server" RepeatDirection="Horizontal" Width="100%"
                            HorizontalAlign="Center" OnItemCommand="DataListShow_ItemCommand" RepeatLayout="Flow">
                            <ItemTemplate>
                                <li style="text-align: center;">
                                    <div class="bfrist">
                                        <asp:Image ID="ImageSkin" ImageUrl='<%# Eval("SkinImage") %>' runat="server" Height="133"
                                            Width="127" />
                                        <div class="lmf_xuanzhong">
                                        </div>
                                        <div class="lmf_xuanzhongtext">
                                            ����ʹ��</div>
                                        <asp:HiddenField ID="HiddenFieldFolderName" runat="server" Value='<%# Eval("FolderName") %>' />
                                    </div>
                                    <asp:Label ID="LabelFolderName" runat="server" Text="ģ���ļ������ƣ�" Visible="false"></asp:Label>
                                    <asp:Label ID="LabelFolderNameValue" runat="server" Text='<%# Eval("FolderName") %>'
                                        Visible="false"></asp:Label>
                                    <asp:Label ID="LabelSkinNameValue" runat="server" Text='<%#Eval("SkinName") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="LabelName" runat="server" Text="ģ�����ƣ�" Visible="false"></asp:Label>
                                    <asp:Label ID="LabelDescription" runat="server" Text="ģ��˵����" Visible="false"></asp:Label>
                                    <asp:Label ID="LabelDescriptionValue" runat="server" Text='<%# Eval("Description") %>'
                                        Visible="false"></asp:Label>
                                    <p style="color: #333; font-size: 14px; padding-top: 5px;">
                                        <asp:Label ID="LabelNameValue" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                    </p>
                                    <p style="padding-left: 12px;">
                                        <asp:LinkButton ID="LinkButtonSelect" Style="margin-right: 10px;" runat="server"
                                            CommandName="select">Ӧ��</asp:LinkButton>
                                        <a target="_blank" href='<%# Page.ResolveUrl(Eval("SkinImage").ToString()) %>' style="margin-right: 10px;">
                                            Ԥ��</a>
                                        <asp:LinkButton ID="LinkButtonDelete" Style="margin-right: 10px;" runat="server"
                                            CommandName="delete">ɾ��</asp:LinkButton>
                                    </p>
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
