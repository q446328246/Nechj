<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ServiceSite_BasicSettings.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ServiceSite_BasicSettings" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��������</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script src="js/CommonJS.js" type="text/javascript"></script>
    <script type="text/javascript">
        var lock = 0;
        //ѡ��ͼ
        function openSingleChild() {
            if (lock == 0) {
                lock = 1
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                if (k == undefined) { k = window.returnValue; }
                if (k != null) {
                    var imgvalue = new Array();
                    imgvalue = k.split(",");
                    document.getElementById("TextBoxOriginalImge").value = imgvalue[0];
                    document.getElementById("ImageOriginalImge").src = imgvalue[1];
                }
                lock = 0;
            }
        }

        function openSingleChild1() {
            if (lock == 0) {
                lock = 1
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                if (k == undefined) { k = window.returnValue; }
                if (k != null) {
                    var imgvalue = new Array();
                    imgvalue = k.split(",");
                    document.getElementById("TextBoxShopOriginalImge").value = imgvalue[0];
                    document.getElementById("ImageShopOriginalImge").src = imgvalue[1];
                }
                lock = 0;
            }
        }

        function openSingleChild2() {
            if (lock == 0) {
                lock = 1
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                if (k == undefined) { k = window.returnValue; }
                if (k != null) {
                    var imgvalue = new Array();
                    imgvalue = k.split(",");
                    document.getElementById("TextBoxMemberOriginalImge").value = imgvalue[0];
                    document.getElementById("ImageMemberOriginalImge").src = imgvalue[1];
                }
                lock = 0;
            }
        } 
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
                    ��������</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="180px">
                            <asp:Label ID="LabelAddCouponIsAudit" runat="server" Text="����Ż�ȯ�Ƿ�Ĭ����ˣ�"></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:DropDownList ID="DropDownListAddCouponIsAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">����Ҫ���</asp:ListItem>
                                <asp:ListItem Value="1">��Ҫ���</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelAddProductIsAudit" runat="server" Text="�����ͨ��Ʒ�Ƿ�Ĭ����ˣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListAddProductIsAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">����Ҫ���</asp:ListItem>
                                <asp:ListItem Value="1">��Ҫ���</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelAddPanicBuyProductIsAudit" runat="server" Text="���������Ʒ�Ƿ�Ĭ����ˣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListAddPanicBuyProductIsAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">����Ҫ���</asp:ListItem>
                                <asp:ListItem Value="1">��Ҫ���</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelAddSpellBuyProductIsAudit" runat="server" Text="����Ź���Ʒ�Ƿ�Ĭ����ˣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListAddSpellBuyProductIsAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">����Ҫ���</asp:ListItem>
                                <asp:ListItem Value="1">��Ҫ���</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelProductCommentISAudit" runat="server" Text="��Ʒ�����Ƿ���Ҫ��ˣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListProductCommentISAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">����Ҫ���</asp:ListItem>
                                <asp:ListItem Value="1">��Ҫ���</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelCategoryInfoCommentISAudit" runat="server" Text="������Ϣ�����Ƿ���Ҫ��ˣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListCategoryInfoCommentISAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">����Ҫ���</asp:ListItem>
                                <asp:ListItem Value="1">��Ҫ���</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>--%>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelSupplyDemandCommentISAudit" runat="server" Text="������Ϣ�����Ƿ���Ҫ��ˣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListSupplyDemandCommentISAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">����Ҫ���</asp:ListItem>
                                <asp:ListItem Value="1">��Ҫ���</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelArticleCommentISAudit" runat="server" Text="ƽ̨��Ѷ�����Ƿ���Ҫ��ˣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListArticleCommentISAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">����Ҫ���</asp:ListItem>
                                <asp:ListItem Value="1">��Ҫ���</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelShopArticleCommentISAudit" runat="server" Text="������Ѷ�����Ƿ���Ҫ��ˣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListShopArticleCommentISAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">����Ҫ���</asp:ListItem>
                                <asp:ListItem Value="1">��Ҫ���</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelMessageCommentISAudit" runat="server" Text="ƽ̨�����Ƿ���Ҫ��ˣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListMessageCommentISAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">����Ҫ���</asp:ListItem>
                                <asp:ListItem Value="1">��Ҫ���</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelShopMessageCommentISAudit" runat="server" Text="���������Ƿ���Ҫ��ˣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListShopMessageCommentISAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">����Ҫ���</asp:ListItem>
                                <asp:ListItem Value="1">��Ҫ���</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelVideoCommentISAudit" runat="server" Text="������Ƶ�����Ƿ���Ҫ��ˣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListVideoCommentISAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">����Ҫ���</asp:ListItem>
                                <asp:ListItem Value="1">��Ҫ���</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelCategoryInfoISAudit" runat="server" Text="��Ա���������Ƿ���Ҫ��ˣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListCategoryInfoISAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">����Ҫ���</asp:ListItem>
                                <asp:ListItem Value="1">��Ҫ���</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>--%>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelSupplyDemandIsAudit" runat="server" Text="��Ա���������Ƿ���Ҫ��ˣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListSupplyDemandIsAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">����Ҫ���</asp:ListItem>
                                <asp:ListItem Value="1">��Ҫ���</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="180px">
                            <asp:Label ID="Label7" runat="server" Text="��ң�BV��֧���Ƿ���Ҫ����ȷ���룺"></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:DropDownList ID="DropDownListMobileCheck" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">����Ҫ��֤</asp:ListItem>
                                <asp:ListItem Value="1">��Ҫ��֤</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelProductCommentVerifyCode" runat="server" Text="��Ʒ�����Ƿ���Ҫ��֤�룺"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListProductCommentVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <%--   <asp:ListItem Value="0">����Ҫ��֤��</asp:ListItem>--%>
                                <asp:ListItem Value="1">��Ҫ��֤��</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <%-- <tr>
                        <th align="right">
                            <asp:Label ID="LabelCategoryInfoCommentVerifyCode" runat="server" Text="������Ϣ�����Ƿ���Ҫ��֤�룺"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListCategoryInfoCommentVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">����Ҫ��֤��</asp:ListItem>
                                <asp:ListItem Value="1">��Ҫ��֤��</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>--%>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label8" runat="server" Text="�Ƿ����ؼ��ʹ��ˣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListKewWordCheck" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">������</asp:ListItem>
                                <asp:ListItem Value="1">����</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            <asp:Label ID="LabelSupplyDemandCommentVerifyCode" runat="server" Text="������Ϣ�����Ƿ���Ҫ��֤�룺"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListSupplyDemandCommentVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <%--  <asp:ListItem Value="0">����Ҫ��֤��</asp:ListItem>--%>
                                <asp:ListItem Value="1">��Ҫ��֤��</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelProductBuyVerifyCode" runat="server" Text="������Ʒ�Ƿ���Ҫ��֤�룺"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListProductBuyVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <%--<asp:ListItem Value="0">����Ҫ��֤��</asp:ListItem>--%>
                                <asp:ListItem Value="1">��Ҫ��֤��</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            <asp:Label ID="LabelAriticleCommentVerifyCode" runat="server" Text="ƽ̨��Ѷ�����Ƿ���Ҫ��֤�룺"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListAriticleCommentVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <%-- <asp:ListItem Value="0">����Ҫ��֤��</asp:ListItem>--%>
                                <asp:ListItem Value="1">��Ҫ��֤��</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            <asp:Label ID="LabelShopAriticleCommentVerifyCode" runat="server" Text="������Ѷ�����Ƿ���Ҫ��֤�룺"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListShopAriticleCommentVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <%--<asp:ListItem Value="0">����Ҫ��֤��</asp:ListItem>--%>
                                <asp:ListItem Value="1">��Ҫ��֤��</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            <asp:Label ID="LabelVideoCommentVerifyCode" runat="server" Text="������Ƶ�����Ƿ���Ҫ��֤�룺"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListVideoCommentVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <%--<asp:ListItem Value="0">����Ҫ��֤��</asp:ListItem>--%>
                                <asp:ListItem Value="1">��Ҫ��֤��</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMessageVerifyCode" runat="server" Text="ƽ̨�����Ƿ���Ҫ��֤�룺"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListMessageVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <%--  <asp:ListItem Value="0">����Ҫ��֤��</asp:ListItem>--%>
                                <asp:ListItem Value="1">��Ҫ��֤��</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            <asp:Label ID="LabelShopMessageVerifyCode" runat="server" Text="���������Ƿ���Ҫ��֤�룺"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListShopMessageVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <%-- <asp:ListItem Value="0">����Ҫ��֤��</asp:ListItem>--%>
                                <asp:ListItem Value="1">��Ҫ��֤��</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelRegVerifyCode" runat="server" Text="��Աע���Ƿ���Ҫ��֤�룺"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListRegVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <%-- <asp:ListItem Value="0">����Ҫ��֤��</asp:ListItem>--%>
                                <asp:ListItem Value="1">��Ҫ��֤��</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMemLoginVerifyCode" runat="server" Text="��Ա��¼�Ƿ���Ҫ��֤�룺"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListMemLoginVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <%--   <asp:ListItem Value="0">����Ҫ��֤��</asp:ListItem>--%>
                                <asp:ListItem Value="1">��Ҫ��֤��</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelArticleCommentCondition" runat="server" Text="ƽ̨��Ѷ���۵�������"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListArticleCommentCondition" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">�����û�</asp:ListItem>
                                <asp:ListItem Value="1">����¼�û�</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelShopArticleCommentCondition" runat="server" Text="������Ѷ���۵�������"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListShopArticleCommentCondition" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">�����û�</asp:ListItem>
                                <asp:ListItem Value="1">����¼�û�</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMessageCondition" runat="server" Text="ƽ̨�������Ե�������"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListMessageCondition" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">�����û�</asp:ListItem>
                                <asp:ListItem Value="1">����¼�û�</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelShopMessageCondition" runat="server" Text="���̷������Ե�������"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListShopMessageCondition" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">�����û�</asp:ListItem>
                                <asp:ListItem Value="1">����¼�û�</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelSupplyDemandCommentCondition" runat="server" Text="�������۵�������"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListSupplyDemandCommentCondition" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">�����û�</asp:ListItem>
                                <asp:ListItem Value="1">����¼�û�</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelCategoryInfoCommentCondition" runat="server" Text="������Ϣ���۵�������"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListCategoryInfoCommentCondition" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">�����û�</asp:ListItem>
                                <asp:ListItem Value="1">����¼�û�</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>--%>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label1" runat="server" Text="��Ƶ���۵�������"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListVideoCommentCondition" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">�����û�</asp:ListItem>
                                <asp:ListItem Value="1">����¼�û�</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label2" runat="server" Text="ǩ���Ƿ��ͺ����"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListSignOrSendScore" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">���ͺ��</asp:ListItem>
                                <asp:ListItem Value="1">���ͺ��</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label5" runat="server" Text="ǩ���������Ѻ����"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxSignScore" runat="server" CssClass="tinput" Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label6" runat="server" Text="ǩ�����͵ȼ������"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxSignRankScore" runat="server" CssClass="tinput" Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            <asp:Label ID="LabelDecreaseRepertory" runat="server" Text="������ʱ����"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListDecreaseRepertory" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">�¶���ʱ</asp:ListItem>
                                <asp:ListItem Value="1">����ʱ</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelPayIsEmail" runat="server" Text="����ʱ��"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListPayIsEmail" runat="server" CssClass="tselect" Width="301px">
                                <asp:ListItem Value="0">�������ʼ�</asp:ListItem>
                                <asp:ListItem Value="1">�����ʼ�</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelShipmentIsEmail" runat="server" Text="����ʱ��"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListShipmentIsEmail" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">�������ʼ�</asp:ListItem>
                                <asp:ListItem Value="1">�����ʼ�</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelShipmentOKIsEmail" runat="server" Text="ȷ���ջ�ʱ��"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListShipmentOKIsEmail" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">�������ʼ�</asp:ListItem>
                                <asp:ListItem Value="1">�����ʼ�</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelCancelOrderIsEmail" runat="server" Text="ȡ������ʱ��"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListCancelOrderIsEmail" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">�������ʼ�</asp:ListItem>
                                <asp:ListItem Value="1">�����ʼ�</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelOrderIsEmail" runat="server" Text="�¶���ʱ�Ƿ���ͻ����ʼ���"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListOrderIsEmail" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">�������ʼ�</asp:ListItem>
                                <asp:ListItem Value="1">�����ʼ�</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMemberRegister" runat="server" Text="ע��ɹ����Ƿ���ͻ����ʼ���"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListMemberRegister" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">�������ʼ�</asp:ListItem>
                                <asp:ListItem Value="1">�����ʼ�</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="Label28" runat="server" Text="ע��ʱ�Ƿ���Ҫ���ͻ����ͼ����ʼ���"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListRegIsActivationEmail" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">�������ʼ�</asp:ListItem>
                                <asp:ListItem Value="1">�����ʼ�</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelApplyOpenShopIsEmail" runat="server" Text="���뿪����Ƿ���ͻ����ʼ���"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListApplyOpenShopIsEmail" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">�������ʼ�</asp:ListItem>
                                <asp:ListItem Value="1">�����ʼ�</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelAuditOpenShopIsEmail" runat="server" Text="������˺��Ƿ���ͻ����ʼ���"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListAuditOpenShopIsEmail" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">�������ʼ�</asp:ListItem>
                                <asp:ListItem Value="1">�����ʼ�</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelRegPresentScore" runat="server" Text="��Աע���������Ѻ����"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxRegPresentScore" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px">0</asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRegPresentScore" runat="server"
                                Display="Dynamic" ControlToValidate="TextBoxRegPresentScore" ErrorMessage="ֻ������

����" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxRegPresentScore" runat="server"
                                ControlToValidate="TextBoxRegPresentScore" Display="Dynamic" ErrorMessage="��ֵ����

Ϊ��"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelRegPresentRankScore" runat="server" Text="��Աע�����͵ȼ������"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxRegPresentRankScore" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px">0</asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRegPresentRankScore"
                                runat="server" ControlToValidate="TextBoxRegPresentRankScore" ErrorMessage="ֻ����������"
                                Display="Dynamic" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxRegPresentRankScore"
                                runat="server" ControlToValidate="TextBoxRegPresentRankScore" Display="Dynamic"
                                ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMyMessageRankSorce" runat="server" Text="����ƽ̨�������͵ĵȼ������"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMyMessageRankSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMyMessageRankSorce"
                                runat="server" ControlToValidate="TextBoxMyMessageRankSorce" Display="Dynamic"
                                ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxMyMessageRankSorce"
                                runat="server" ControlToValidate="TextBoxMyMessageRankSorce" ErrorMessage="ֻ����������"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMyMessageSorce" runat="server" Text="����ƽ̨�������͵����Ѻ����"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMyMessageSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMyMessageSorce" runat="server"
                                ControlToValidate="TextBoxMyMessageSorce" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxMyMessageSorce"
                                runat="server" ControlToValidate="TextBoxMyMessageSorce" ErrorMessage="ֻ����������"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMyShopMessageRankSorce" runat="server" Text="���������������͵ĵȼ������"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMyShopMessageRankSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMyShopMessageRankSorce"
                                runat="server" ControlToValidate="TextBoxMyShopMessageRankSorce" Display="Dynamic"
                                ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxMyShopMessageRankSorce"
                                runat="server" ControlToValidate="TextBoxMyShopMessageRankSorce" ErrorMessage="ֻ����������"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMyShopMessageSorce" runat="server" Text="���������������͵����Ѻ����"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMyShopMessageSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMyShopMessageSorce"
                                runat="server" ControlToValidate="TextBoxMyShopMessageSorce" Display="Dynamic"
                                ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxMyShopMessageSorce"
                                runat="server" ControlToValidate="TextBoxMyShopMessageSorce" ErrorMessage="ֻ����������"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelBuyProductRankScore" runat="server" Text="���Ѷ�����͵ȼ����������"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxBuyProductRankScore" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            % <span style="color: Red">*</span><span>(10%,��ʾ 100Ԫ����10���)</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorBuyProductRankScore" runat="server"
                                ControlToValidate="TextBoxBuyProductRankScore" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorBuyProductRankScore"
                                runat="server" ControlToValidate="TextBoxBuyProductRankScore" ErrorMessage="ֻ����������"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelBuyProductScore" runat="server" Text="���Ѷ���������Ѻ��������"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxBuyProductScore" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            % <span style="color: Red">*</span><span>(10%,��ʾ 100Ԫ����10���)</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxBuyProductScore" runat="server"
                                ControlToValidate="TextBoxBuyProductScore" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxBuyProductScore"
                                runat="server" ControlToValidate="TextBoxBuyProductScore" ErrorMessage="ֻ����������"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelMyCommentRankSorce" runat="server" Text="��Ʒ�������͵ĵȼ������"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMyCommentRankSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMyCommentRankSorce"
                                runat="server" ControlToValidate="TextBoxMyCommentRankSorce" Display="Dynamic"
                                ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxMyCommentRankSorce"
                                runat="server" ControlToValidate="TextBoxMyCommentRankSorce" ErrorMessage="ֻ����������"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelMyCommentSorce" runat="server" Text="��Ʒ�������͵����Ѻ����"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMyCommentSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMyCommentSorce" runat="server"
                                ControlToValidate="TextBoxMyCommentSorce" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxMyCommentSorce"
                                runat="server" ControlToValidate="TextBoxMyCommentSorce" ErrorMessage="ֻ����������"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelSellerCommentRankSorce" runat="server" Text="���һ������ͻ�Ա�ĵȼ������"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxSellerCommentRankSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxSellerCommentRankSorce"
                                runat="server" ControlToValidate="TextBoxSellerCommentRankSorce" Display="Dynamic"
                                ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxSellerCommentRankSorce"
                                ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelSellerCommentSorce" runat="server" Text="���һ������ͻ�Ա�����Ѻ����"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxSellerCommentSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxSellerCommentSorce"
                                runat="server" ControlToValidate="TextBoxSellerCommentSorce" Display="Dynamic"
                                ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxSellerCommentSorce"
                                ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelArticleCommentRankSorce" runat="server" Text="ƽ̨��Ѷ�������͵ĵȼ������"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxArticleCommentRankSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxArticleCommentRankSorce"
                                runat="server" ControlToValidate="TextBoxArticleCommentRankSorce" Display="Dynamic"
                                ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxArticleCommentRankSorce"
                                runat="server" ControlToValidate="TextBoxArticleCommentRankSorce" ErrorMessage="ֻ����������"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelArticleCommentSorce" runat="server" Text="ƽ̨��Ѷ�������͵����Ѻ����"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxArticleCommentSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxArticleCommentSorce"
                                runat="server" ControlToValidate="TextBoxArticleCommentSorce" Display="Dynamic"
                                ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxArticleCommentSorce"
                                runat="server" ControlToValidate="TextBoxArticleCommentSorce" ErrorMessage="ֻ����������"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelShopArticleCommentRankSorce" runat="server" Text="������Ѷ�������͵ĵȼ������"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxShopArticleCommentRankSorce" MaxLength="9" runat="server"
                                CssClass="tinput" Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxShopArticleCommentRankSorce"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBoxShopArticleCommentRankSorce"
                                ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelShopArticleCommentSorce" runat="server" Text="������Ѷ�������͵����Ѻ����"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxShopArticleCommentSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxShopArticleCommentSorce"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBoxShopArticleCommentSorce"
                                ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMySupplyDemandCommentRankSorce" runat="server" Text="�����������͵ĵȼ������"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMySupplyDemandCommentRankSorce" MaxLength="9" runat="server"
                                CssClass="tinput" Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxMySupplyDemandCommentRankSorce"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TextBoxMySupplyDemandCommentRankSorce"
                                ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMySupplyDemandCommentSorce" runat="server" Text="�����������͵����Ѻ����"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMySupplyDemandCommentSorce" MaxLength="9" runat="server"
                                Width="299px" CssClass="tinput"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBoxMySupplyDemandCommentSorce"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TextBoxMySupplyDemandCommentSorce"
                                ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMyCategoryInfoCommentRankSorce" runat="server" Text="�����������͵ĵȼ������"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMyCategoryInfoCommentRankSorce" MaxLength="9" runat="server"
                                Width="299px" CssClass="tinput"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBoxMyCategoryInfoCommentRankSorce"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="TextBoxMyCategoryInfoCommentRankSorce"
                                ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMyCategoryInfoCommentSorce" runat="server" Text="�����������͵����Ѻ����"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMyCategoryInfoCommentSorce" MaxLength="9" runat="server"
                                Width="299px" CssClass="tinput"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBoxMyCategoryInfoCommentSorce"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="TextBoxMyCategoryInfoCommentSorce"
                                ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelVideoCommentRankSorce" runat="server" Text="��Ƶ�������͵ĵȼ������"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxVideoCommentRankSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxVideoCommentRankSorce"
                                runat="server" ControlToValidate="TextBoxVideoCommentRankSorce" Display="Dynamic"
                                ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxVideoCommentRankSorce"
                                runat="server" ControlToValidate="TextBoxVideoCommentRankSorce" ErrorMessage="ֻ����������"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelVideoCommentSorce" runat="server" Text="��Ƶ�������͵����Ѻ����"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxVideoCommentSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxVideoCommentSorce" runat="server"
                                ControlToValidate="TextBoxVideoCommentSorce" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxVideoCommentSorce"
                                runat="server" ControlToValidate="TextBoxVideoCommentSorce" ErrorMessage="ֻ����������"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelGoodAppraiseReputation" runat="server" Text="��Ա�����������ӵ����ã�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxGoodAppraiseReputation" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorGoodAppraiseReputation" runat="server"
                                ControlToValidate="TextBoxGoodAppraiseReputation" Display="Dynamic" ErrorMessage="

��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorGoodAppraiseReputation"
                                runat="server" ControlToValidate="TextBoxGoodAppraiseReputation" ErrorMessage="ֻ����������"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelStandardAppraiseReputation" runat="server" Text="��Ա�����������ӵ����ã�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxStandardAppraiseReputation" MaxLength="9" runat="server"
                                Width="299px" CssClass="tinput"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorStandardAppraiseReputation"
                                runat="server" ControlToValidate="TextBoxStandardAppraiseReputation" Display="Dynamic"
                                ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorStandardAppraiseReputation"
                                runat="server" ControlToValidate="TextBoxStandardAppraiseReputation" ErrorMessage="ֻ

����������" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelBadAppraiseReputation" runat="server" Text="��Ա�������̿۳������ã�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxBadAppraiseReputation" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorBadAppraiseReputation" runat="server"
                                ControlToValidate="TextBoxBadAppraiseReputation" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorBadAppraiseReputation"
                                runat="server" ControlToValidate="TextBoxBadAppraiseReputation" ErrorMessage="ֻ����������"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <span>������Ʒƽ̨��ɱ������أ�</span>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListAdminProductFcRate" runat="server" Width="301px"
                                CssClass="tselect">
                                <asp:ListItem Value="false">������</asp:ListItem>
                                <asp:ListItem Value="true">����</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span><span>������ɿ����ܱ��������ƣ����������û�п�����Ĭ�ϰ��յ�����Ʒƽ̨��ɱ�������</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <span>������Ʒƽ̨��ɱ�����</span>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAdminProductFcRate" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px" Text="30">
                            </asp:TextBox>
                            % <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAdminProductFcRate" runat="server"
                                ControlToValidate="TextBoxAdminProductFcRate" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorAdminProductFcRate"
                                runat="server" ControlToValidate="TextBoxAdminProductFcRate" Display="Dynamic"
                                ErrorMessage="��ʽ����ȷ" ValidationExpression="^[0-9]{1,2}$">
                            </asp:RegularExpressionValidator>
                            <span>(�ٷֱ� ��������20����20%)</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <span>������Ʒ��Ӯ��ƽ̨��ɱ������أ�</span>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListIsAdminProductFcCount" runat="server" Width="301px"
                                CssClass="tselect">
                                <asp:ListItem Value="false">������</asp:ListItem>
                                <asp:ListItem Value="true">����</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <span>������Ʒ��Ӯ��ƽ̨��ɱ�����</span>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAdminProductFcCount" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px" Text="30">
                            </asp:TextBox>
                            % <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TextBoxOrderCommission"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server"
                                ControlToValidate="TextBoxOrderCommission" Display="Dynamic" ErrorMessage="��ʽ����ȷ"
                                ValidationExpression="^[0-9]{1,2}$">
                            </asp:RegularExpressionValidator>
                            <span>(�ٷֱ� ��������20����20%)</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <span>���̶�����ɿ��أ�</span>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListIsOrderCommission" runat="server" Width="301px"
                                CssClass="tselect">
                                <asp:ListItem Value="false">������</asp:ListItem>
                                <asp:ListItem Value="true">����</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <span>���̶�����ɱ�����</span>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOrderCommission" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px" Text="30">
                            </asp:TextBox>
                            % <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBoxOrderCommission"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server"
                                ControlToValidate="TextBoxOrderCommission" Display="Dynamic" ErrorMessage="��ʽ����ȷ"
                                ValidationExpression="^[0-9]{1,2}$">
                            </asp:RegularExpressionValidator>
                            <span>(�ٷֱ� ��������20����20%)</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <span>�Ƽ���Ա����Ƿ�����</span>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListIsRecommendCommision" runat="server" Width="301px"
                                CssClass="tselect">
                                <asp:ListItem Value="false">������</asp:ListItem>
                                <asp:ListItem Value="true">����</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <span>�Ƽ���Ա��ɱ�����</span>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxRecommendCommision" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px" Text="30">
                            </asp:TextBox>
                            % <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TextBoxOrderCommission"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                                ControlToValidate="TextBoxRecommendCommision" Display="Dynamic" ErrorMessage="��ʽ����ȷ"
                                ValidationExpression="^[0-9]{1,2}$">
                            </asp:RegularExpressionValidator>
                            <span>(�ٷֱ� ��������20����20%)</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="Label1SiteHtml" runat="server" Text="��վ����α��̬��"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListSiteHtml" runat="server" Width="301px" CssClass="tselect">
                                <asp:ListItem Value="false">������</asp:ListItem>
                                <asp:ListItem Value="true">����</asp:ListItem>
                            </asp:DropDownList>
                            <span>��ѡ��</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label10" runat="server" Text="����ID��ʼֵ��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxShopID" CssClass="tinput" runat="server" Width="299px">10000</asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxShopID" runat="server"
                                ControlToValidate="TextBoxShopID" ErrorMessage="ֻ����������" Display="Dynamic" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxShopID" runat="server"
                                ControlToValidate="TextBoxShopID" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <span>���������ID��ʼֵ(�������������10000,�������д��������Ĭ����������shop10000.****.com)</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label26" runat="server" Text="Ĭ���ջ�������"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDefaultReceivedDays" CssClass="tinput" runat="server" Width="299px">7</asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                ControlToValidate="TextBoxDefaultReceivedDays" ErrorMessage="ֻ����������" Display="Dynamic"
                                ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxDefaultReceivedDays"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <span>������Ĭ���ջ�����(��������Ĭ���ջ������ڻ�δ�ջ������ҿ����ڶ�����ϸҳִ��ȷ���ջ�����)</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label27" runat="server" Text="Ĭ��ȡ������������"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDefaultCancelOrderDays" CssClass="tinput" runat="server"
                                Width="299px">7</asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                ControlToValidate="TextBoxDefaultCancelOrderDays" ErrorMessage="ֻ����������" Display="Dynamic"
                                ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxDefaultCancelOrderDays"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <span>������Ĭ��ȡ����������(����ǰ������Ĭ������,ϵͳ���Զ�ȡ��������)</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="Label24" runat="server" Text="�˿������������ƽ̨���룺"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxRefundIsAdmin" CssClass="tinput" runat="server" Width="299px">7</asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                ControlToValidate="TextBoxRefundIsAdmin" ErrorMessage="ֻ����������" Display="Dynamic"
                                ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBoxRefundIsAdmin"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <span>������</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label3" runat="server" Text="ÿ�κ���һ������Ʒ����"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMaxScroeProductCount" CssClass="tinput" runat="server" Width="299px">1</asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxMaxScroeProductCount"
                                ErrorMessage="ֻ����������" Display="Dynamic" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxMaxScroeProductCount"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <span>���������һ������Ʒ��</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label4" runat="server" Text="ֱͨ��ÿ�տ۳���ң�BV����"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxZtcGoodsMoney" CssClass="tinput" runat="server" Width="299px"
                                MaxLength="8">1</asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                ControlToValidate="TextBoxMaxScroeProductCount" ErrorMessage="ֻ����������" Display="Dynamic"
                                ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxZtcGoodsMoney"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <span>�������ң�BV�����(ϵͳÿ����Զ��۳�ֱͨ���û���ң�BV��)</span>
                        </td>
                    </tr>
                    <tr>
                        <script type="text/javascript" language="javascript">
                            function checknum(str) {
                                var re = /^[0-9]+$/;
                                if (!re.test(str)) {
                                    alert("��������ȷ�����֣�");
                                    return false;
                                } else { return true; }
                            }

                            function baseCheck() {
                                var checkV = document.getElementById("txtWxPay").value;
                                if (checknum(checkV)) {
                                    return true;
                                }
                                else {
                                    return false;
                                }
                            }
                        </script>
                        <th align="right">
                            <asp:Label ID="Label9" runat="server" Text="΢��Ĭ�Ϸ��ã�"></asp:Label>
                        </th>
                        <td>
                            <input type="text" id="txtWxPay" runat="server" class="tinput" style="width: 299px"
                                maxlength="8" value="500" />
                            <span style="color: Red">*</span> <span>������΢�ŷ��ý��(΢�ŷ��ý��Ϊ����)</span>
                        </td>
                    </tr>
                    <tr class="radiobtn">
                        <th align="right">
                            <asp:Label ID="Label12" runat="server" Text="Ĭ��֧�����ͣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonListPayType" RepeatDirection="Horizontal" runat="server"
                                RepeatLayout="Flow">
                                <asp:ListItem Selected="True" Value="0">֧����ƽ̨</asp:ListItem>
                                <asp:ListItem Value="1">֧��������</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize2" runat="server" Text="ICP�����ţ�"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxICPNum" CssClass="tinput" Width="299px" runat="server"></asp:TextBox>
                            <span>������ICP������(��ҵ����Ϣ����������վ��������ϵͳ�䷢��������Ϣ���֤����)</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize3" runat="server" Text="ICP�����ļ���"></asp:Localize>
                        </th>
                        <td>
                            <asp:FileUpload ID="FileUploadICP" runat="server" CssClass="tinput" Width="299px" />
                            <span>������ICP�����ļ�(�������������֤�ļ�)</span>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonEdit" runat="server" Text="ȷ��" CssClass="qued" OnClick="ButtonEdit_Click"
                    OnClientClick="return baseCheck()" />
                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                <asp:HiddenField ID="HiddenFieldXmlPath" runat="server" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
