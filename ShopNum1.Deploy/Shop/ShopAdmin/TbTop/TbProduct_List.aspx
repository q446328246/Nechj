<%@ Page AutoEventWireup="True" CodeBehind="TbProduct_List.aspx.cs" Inherits="ShopNum1.Deploy.Shop.ShopAdmin.TbTop.TbProduct_List"
    Language="C#" %>

<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��Ʒ�б�</title>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link rel="stylesheet" type="text/css" href="style/tbindex.css" />
    <link rel="stylesheet" type="text/css" href="style/index.css" />
    <script src="/Main/js/CommonJS.js" type="text/javascript"> </script>
    <script type="text/javascript" src="/js/jquery-1.6.2.min.js"> </script>
    <script language="javascript" type="text/javascript">
        function SelectAllCheckboxes(obj) {
            var theTable = obj.parentNode.parentNode.parentNode;
            var inputs = theTable.getElementsByTagName('input');
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    inputs[i].checked = obj.checked;
                }
            }
        }

        function GetCheckedBoxValues() {
            var checkedBoxValues = "";
            var inputs = document.getElementsByTagName("input");
            for (var j = 0; j < inputs.length; j++) {
                if (inputs[j].type == "checkbox" && inputs[j].id != "checkboxAll") {
                    if (inputs[j].checked == true) {
                        checkedBoxValues += "'" + inputs[j].value + "',";
                    }
                }
            }
            if (checkedBoxValues.length > 0) {
                checkedBoxValues = checkedBoxValues.substring(0, checkedBoxValues.length - 1);
            }

            return checkedBoxValues;
        }

        function DeleteBt(msg) {
            var checkedBoxValues = GetCheckedBoxValues();
            if (checkedBoxValues == "") {
                alert("��ѡ��Ҫ" + msg + "�ļ�¼��");
                return false;
            } else if (window.confirm("��ȷ��Ҫ" + msg + "��?")) {
                document.getElementById('<%= CheckGuid.ClientID %>').value = checkedBoxValues;
                return true;
            } else {
                return false;
            }
        }

        function EditBt() {
            var checkedBoxValues = GetCheckedBoxValues();
            if (checkedBoxValues == "") {
                alert("��ѡ��Ҫ�����ļ�¼��");
                return false;
            } else if (checkedBoxValues.split(",").length > 1) {
                alert("��ÿ��ֻ��ѡ��һ����¼������");
                return false;
            } else {
                document.getElementById('<%= CheckGuid.ClientID %>').value = checkedBoxValues;
                return true;
            }
        }
    </script>
</head>
<body class="right_body">
    <form id="form1" runat="server">
    <div class="main">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="table1">
            <div class="title">
                ��Ʒ�б�
            </div>
            <div class="content">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="text-align: right">
                            ��Ʒ���ƣ�
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="allinput1"></asp:TextBox>
                        </td>
                        <td style="text-align: right">
                            ���ţ�
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxProductNum" runat="server" CssClass="allinput1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            ����ۣ�
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxBeginPrice" runat="server" CssClass="allinput1"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorCostPrice1" runat="server"
                                ControlToValidate="TextBoxBeginPrice" Display="Dynamic" ErrorMessage="�۸��ʽ����ȷ"
                                ValidationExpression="^[0-9]+(.[0-9]{1,3})?$"></asp:RegularExpressionValidator>��
                            <asp:TextBox ID="TextBoxEndPrice" runat="server" CssClass="allinput1"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEndPrice"
                                Display="Dynamic" ErrorMessage="�۸��ʽ����ȷ" ValidationExpression="^[0-9]+(.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                        </td>
                        <td style="text-align: right">
                            ��Ʒ���ͣ�
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListType" runat="server" Width="66px">
                                <asp:ListItem Value="-1" Selected="True">-ȫ��-</asp:ListItem>
                                <asp:ListItem Value="IsNew">��Ʒ</asp:ListItem>
                                <asp:ListItem Value="IsHot">����</asp:ListItem>
                                <asp:ListItem Value="IsPromotion">����</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            ��Ʒ���ࣺ
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DropDownListProductSeriesCode1" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListProductSeriesCode2" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListProductSeriesCode3" runat="server">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td style="text-align: right">
                            �Ƿ��ϼܣ�
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsSaled" runat="server" CssClass=" btbt2">
                                <asp:ListItem Text="-ȫ��-" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="δ�ϼ�" Value="0"></asp:ListItem>
                                <asp:ListItem Text="���ϼ�" Value="1"></asp:ListItem>
                                <asp:ListItem Text="�¼�" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="ButtonSearch" runat="server" Text="��ѯ" CssClass="bt2" />
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" width="100%" style="text-align: center">
                    <tr class="MemberTr">
                        <td width="30" style="text-align: center">
                            <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                        </td>
                        <td style="text-align: center">
                            ��Ʒ����
                        </td>
                        <td style="text-align: center">
                            ��Ʒ����
                        </td>
                        <td style="text-align: center">
                            ����
                        </td>
                        <td style="text-align: center">
                            ���
                        </td>
                        <td style="text-align: center">
                            �����
                        </td>
                        <td style="text-align: center">
                            ��Ӯ��
                        </td>
                        <td style="text-align: center">
                            �ϼ�
                        </td>
                        <td style="text-align: center">
                            ��Ʒ
                        </td>
                        <td style="text-align: center">
                            ����
                        </td>
                        <td style="text-align: center">
                            ����
                        </td>
                        <td style="text-align: center">
                            ���ʱ��
                        </td>
                        <td style="text-align: center">
                            �Ƿ����
                        </td>
                        <td style="text-align: center">
                            ͬ��״̬
                        </td>
                    </tr>
                    <asp:Repeater EnableViewState="False" ID="RepeaterShow" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="text-align: center">
                                    <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                                </td>
                                <td style="text-align: center">
                                    <a href='<%#ShopUrlOperate.shopDetailHrefByShopID(Eval("Guid").ToString(), Eval("ShopID").ToString(), "ProductDetail") %>'
                                        target="_blank"><span title='<%# DataBinder.Eval(Container.DataItem, "Name") %>'>
                                            <%# Utils.GetUnicodeSubString(DataBinder.Eval(Container.DataItem, "Name").ToString(), 40, "") %></span></a>
                                </td>
                                <td style="text-align: center">
                                    <%# DataBinder.Eval(Container.DataItem, "ProductSeriesName") %>
                                </td>
                                <td style="text-align: center">
                                    <%# DataBinder.Eval(Container.DataItem, "ProductNum") %>
                                </td>
                                <td style="text-align: center">
                                    <%# DataBinder.Eval(Container.DataItem, "RepertoryCount") %>
                                </td>
                                <td style="text-align: center">
                                    <%# DataBinder.Eval(Container.DataItem, "ShopPrice") %>
                                </td>
                                <td style="text-align: center">
                                    <%# DataBinder.Eval(Container.DataItem, "GroupPrice") %>
                                </td>
                                <td style="color: Red; font-weight: bold; text-align: center;">
                                    <%--   <%# Product_List.ChangIsNew(Eval("IsSaled").ToString())%>--%>
                                </td>
                                <td style="color: Red; font-weight: bold; text-align: center;">
                                    <%--     <%# Product_List.ChangIsNew (Eval( "IsNew").ToString())%>--%>
                                </td>
                                <td style="color: Red; font-weight: bold; text-align: center;">
                                    <%--         <%# Product_List.ChangIsNew(Eval("IsHot").ToString())%>--%>
                                </td>
                                <td style="color: Red; font-weight: bold; text-align: center;">
                                    <%--  <%# Product_List.ChangIsNew(Eval("IsPromotion").ToString())%>--%>
                                </td>
                                <td style="text-align: center; width: 9%">
                                    <%# DataBinder.Eval(Container.DataItem, "CreateTime").ToString() %>
                                </td>
                                <td style="text-align: center; width: 7%">
                                    <%# DataBinder.Eval(Container.DataItem, "IsAudit").ToString() == "1" ? "���ͨ��" : (DataBinder.Eval(Container.DataItem, "IsAudit").ToString() == "2" ? "���δͨ��" : "δ���") %>
                                </td>
                                <td style="text-align: center; width: 7%">
                                    <%# DataBinder.Eval(Container.DataItem, "IsAudit").ToString() == "1" ? "���ͨ��" : (DataBinder.Eval(Container.DataItem, "IsAudit").ToString() == "2" ? "���δͨ��" : "δ���") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <!-- ��ҳ����-->
            <div class="pager">
                <asp:Label ID="LabelPageMessage" runat="server"></asp:Label>
                &nbsp;<asp:HyperLink ID="lnkFirst" runat="server"><span class="fpager">[ ��ҳ</span></asp:HyperLink>
                <asp:HyperLink ID="lnkPrev" runat="server"><span class="fpager">| ��һҳ</span></asp:HyperLink>
                <asp:HyperLink ID="lnkNext" runat="server"><span class="fpager">| ��һҳ</span></asp:HyperLink>
                <asp:HyperLink ID="lnkLast" runat="server"><span class="fpager">| ĩҳ ]</span></asp:HyperLink>
                &nbsp;<span class="fpager">ת��
                    <asp:Literal ID="lnkTo" runat="server" />
                    ҳ</span>
            </div>
        </div>
        <asp:HiddenField ID="CheckGuid" runat="server" />
        <asp:Button runat="server" ID="ButtonSearchDetail" Text="�鿴" CssClass="bt2 bt3" OnClientClick=" return EditBt() "
            OnClick="ButtonSearchDetail_Click" />
        <asp:Button ID="ButtonAdd" runat="server" Text="���" CssClass="bt2 bt3" CausesValidation="false"
            OnClick="ButtonAdd_Click" />
        <asp:Button runat="server" ID="ButtonEdit" Text="�༭" CssClass="bt2" OnClientClick=" return EditBt() "
            OnClick="ButtonEdit_Click" />
        <asp:Button runat="server" ID="ButtonDelete" Text="ɾ��" CssClass="bt2" OnClientClick=" return DeleteBt('ɾ��') "
            OnClick="ButtonDelete_Click" />
        <asp:Button runat="server" ID="ButtonUpSaled" Text="�ϼ�" CssClass="bt2" OnClientClick=" return DeleteBt('�ϼ�') "
            OnClick="ButtonUpSaled_Click" />
        <asp:Button runat="server" ID="ButtonDownSaled" Text="�¼�" CssClass="bt2" OnClientClick=" return DeleteBt('�¼�') "
            OnClick="ButtonDownSaled_Click" />
    </div>
    </form>
</body>
</html>
