<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="SetMap.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.SetMap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>վ���ͼ</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <script src="js/CommonJS.js" type="text/javascript"> </script>
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
                    վ���ͼ</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="180px">
                            ��ҳ����Ƶ�ʣ�
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListDefaultPriority" runat="server" Width="180px" CssClass="tselect">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareDdl" runat="server" ControlToValidate="DropDownListDefaultPriority"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                            <asp:DropDownList ID="DropDownListDefaultChangefreq" runat="server" Width="180px"
                                CssClass="tselect">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="DropDownListDefaultChangefreq"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ��Ʒ����ҳ����Ƶ�ʣ�
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListProductCategroyPriority" runat="server" Width="180px"
                                CssClass="tselect">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="DropDownListProductCategroyPriority"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                            <asp:DropDownList ID="DropDownListProductCategroyChangefreq" runat="server" Width="180px"
                                CssClass="tselect">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="DropDownListProductCategroyChangefreq"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ��Ѷ����ҳ����Ƶ�ʣ�
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListArticleCategroyPriority" runat="server" Width="180px"
                                CssClass="tselect">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="DropDownListArticleCategroyPriority"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                            <asp:DropDownList ID="DropDownListArticleCategroyChangefreq" runat="server" Width="180px"
                                CssClass="tselect">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToValidate="DropDownListArticleCategroyChangefreq"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ��Ѷ����ҳ����Ƶ�ʣ�
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListArticlePriority" runat="server" Width="180px" CssClass="tselect">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="DropDownListArticlePriority"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                            <asp:DropDownList ID="DropDownListArticleChangefreq" runat="server" Width="180px"
                                CssClass="tselect">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator9" runat="server" ControlToValidate="DropDownListArticleChangefreq"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            �������ҳ����Ƶ�ʣ�
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListSupplyDemandPriority" runat="server" Width="180px"
                                CssClass="tselect">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidatorDropDownListSupplyDemandPriority" runat="server"
                                ControlToValidate="DropDownListSupplyDemandPriority" Display="Dynamic" ErrorMessage="��ֵ����ѡ��"
                                Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                            <asp:DropDownList ID="DropDownListSupplyDemandChangefreq" runat="server" Width="180px"
                                CssClass="tselect">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidatorDropDownListSupplyDemandChangefreq" runat="server"
                                ControlToValidate="DropDownListSupplyDemandChangefreq" Display="Dynamic" ErrorMessage="��ֵ����ѡ��"
                                Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <%--  <tr >
                        <th align="right">
                            ������Ϣ����ҳ����Ƶ�ʣ�
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListCategoryInfoCatagoryPriority" runat="server" Width="180px"
                                CssClass="tselect">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidatorDropDownListCategoryInfoCatagoryPriority"
                                runat="server" ControlToValidate="DropDownListCategoryInfoCatagoryPriority" Display="Dynamic"
                                ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                            <asp:DropDownList ID="DropDownListCategoryInfoCatagoryChangefreq" runat="server"
                                Width="180px" CssClass="tselect">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidatorDropDownListCategoryInfoCatagoryChangefreq"
                                runat="server" ControlToValidate="DropDownListCategoryInfoCatagoryChangefreq"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>--%>
                    <%--<tr>
                <td align="right" style="line-height: 30px; height: 30px;">
                    Ʒ�Ʒ���ҳ����Ƶ�ʣ�
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListBrandCategoryPriority" runat="server" CssClass="select1">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidatorDropDownListBrandCategoryPriority" runat="server"
                        ControlToValidate="DropDownListBrandCategoryPriority" Display="Dynamic" ErrorMessage="��ֵ����ѡ��"
                        Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListBrandCategoryChangefreq" runat="server" CssClass="select1">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidatorDropDownListBrandCategoryChangefreq" runat="server"
                        ControlToValidate="DropDownListBrandCategoryChangefreq" Display="Dynamic" ErrorMessage="��ֵ����ѡ��"
                        Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>--%>
                    <tr>
                        <th align="right">
                            ����ҳ��ҳ����Ƶ�ʣ�
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListOtherPriority" runat="server" Width="180px" CssClass="tselect">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator14" runat="server" ControlToValidate="DropDownListOtherPriority"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                            <asp:DropDownList ID="DropDownListOtherChangefreq" runat="server" Width="180px" CssClass="tselect">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator15" runat="server" ControlToValidate="DropDownListOtherChangefreq"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="����" OnClick="ButtonConfirm_Click"
                    CssClass="fanh" />
                <asp:Literal ID="LiteralURL" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
