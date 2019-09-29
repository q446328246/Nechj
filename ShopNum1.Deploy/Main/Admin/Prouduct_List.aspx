<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Prouduct_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Prouduct_List" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��ƽ̨-��Ʒ�б�</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
    <script type='text/javascript' src='js/resolution-test.js'></script>
    <script type="text/javascript" language="javascript">
        String.prototype.trim = function () {
            return this.replace(/(^\s*)|(\s*$)/g, '');
        }
        function checkPrice() {
            $("#TextBoxPrice1").val($("#TextBoxPrice1").val().trim()); $("#TextBoxPrice2").val($("#TextBoxPrice2").val().trim());
            return true;
        }

        var check = false;
        function SelectAllCheckboxesNew(o) {
            var inputs = document.getElementsByTagName("input");
            for (var j = 0; j < inputs.length; j++) {
                inputs[j].checked = o.checked;
            }
        }
        var oldcolor; function Num1GridViewShow_mout(rowEl) { for (var i = 0; i < rowEl.cells.length; i++) { rowEl.cells[i].style.backgroundColor = oldcolor; } } function Num1GridViewShow_mover(rowEl) { for (var i = 0; i < rowEl.cells.length; i++) { oldcolor = rowEl.cells[i].style.backgroundColor; rowEl.cells[i].style.backgroundColor = "#ebeef5"; } }

    </script>
</head>
<body class="widthah3">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    <div style="left: -1000px; top: 377px; visibility: hidden; position: absolute;" id="dhtmltooltip">
        <img src="" height="200" width="200px" />
    </div>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    ��Ʒ�б�</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            <asp:Localize ID="LocalizeName" runat="server" Text="��Ʒ���ƣ�"></asp:Localize>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding" style="display: none;">
                            ��Ʒ��ţ�
                        </td>
                        <td style="display: none;">
                            <asp:TextBox ID="TextBoxRepertoryNumber" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            �Ƿ��Ƽ���
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsShopRecommend" runat="server" CssClass="tselect"
                                Style="width: 207px;">
                                <asp:ListItem Selected="True" Value="-1">-ȫ��-</asp:ListItem>
                                <asp:ListItem Value="1">��</asp:ListItem>
                                <asp:ListItem Value="0">��</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding">
                            �Ƿ���Ʒ��
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsShopNew" runat="server" CssClass="tselect" Style="width: 100px;">
                                <asp:ListItem Selected="True" Value="-1">-ȫ��-</asp:ListItem>
                                <asp:ListItem Value="1">��</asp:ListItem>
                                <asp:ListItem Value="0">��</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding" style="padding-left: 46px;">
                            �Ƿ�Ʒ��
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsShopGood" runat="server" CssClass="tselect" Style="width: 100px;">
                                <asp:ListItem Selected="True" Value="-1">-ȫ��-</asp:ListItem>
                                <asp:ListItem Value="1">��</asp:ListItem>
                                <asp:ListItem Value="0">��</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            <asp:Localize ID="LocalizeShopName" runat="server" Text="�������ƣ�"></asp:Localize>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxShopName" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            �Ƿ��ϼܣ�
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsSaled" Width="207px" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding">
                            �Ƿ����ۣ�
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsSell" runat="server" CssClass="tselect" Style="width: 100px;">
                                <asp:ListItem Selected="True" Value="-1">-ȫ��-</asp:ListItem>
                                <asp:ListItem Value="1">��</asp:ListItem>
                                <asp:ListItem Value="0">��</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding" style="padding-left: 46px;">
                            �Ƿ�������
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsShopHot" runat="server" CssClass="tselect" Style="width: 100px;">
                                <asp:ListItem Selected="True" Value="-1">-ȫ��-</asp:ListItem>
                                <asp:ListItem Value="1">��</asp:ListItem>
                                <asp:ListItem Value="0">��</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td style="text-align: right;">
                            <asp:Localize ID="Localize1" runat="server" Text="��ԱID��"></asp:Localize>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxShopID" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            ��Ʒ���ࣺ
                        </td>
                        <td colspan="3">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DropDownListProductGuid1" runat="server" AutoPostBack="True"
                                        CssClass="tselect" Style="width: 150px;" OnSelectedIndexChanged="DropDownListProductGuid1_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListProductGuid2" runat="server" AutoPostBack="True"
                                        CssClass="tselect" Style="width: 150px;" OnSelectedIndexChanged="DropDownListProductGuid2_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListProductGuid3" runat="server" CssClass="tselect"
                                        Style="width: 150px;">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="lmf_padding" style="text-align: right;">
                            <asp:Localize ID="LocalizePrice" runat="server" Text="�۸�Χ��"></asp:Localize>
                        </td>
                        <td colspan="7">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxPrice1" runat="server" CssClass="tinput" Width="36"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorCostPrice1" runat="server"
                                            ControlToValidate="TextBoxPrice1" Display="Dynamic" ErrorMessage="�۸��ʽ����ȷ" ValidationExpression="^[0-9]+(.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td class="lmf_px">
                                        -
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxPrice2" runat="server" CssClass="tinput" Width="36"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxPrice2"
                                            Display="Dynamic" ErrorMessage="�۸��ʽ����ȷ" ValidationExpression="^[0-9]+(.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" Text="��ѯ" CssClass="dele" OnClientClick="return checkPrice()"
                                            OnClick="ButtonSearch_Click" /><asp:DropDownList ID="DropDownListIsAudit" Visible="false"
                                                runat="server" CssClass="tselect" Style="width: 100px;">
                                            </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <%--     <asp:Button ID="ButtonSee" runat="server" Text="�鿴" CssClass="dele" OnClick="ButtonSee_Click"
                        OnClientClick="return EditButton()"  />--%>
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:DropDownList ID="DropDownListOperate" runat="server" CssClass="tselect" Width="150">
                                    <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                    <asp:ListItem Value="IsSell,1">����</asp:ListItem>
                                    <asp:ListItem Value="IsNew,1">��Ʒ</asp:ListItem>
                                    <asp:ListItem Value="IsHot,1">����</asp:ListItem>
                                    <asp:ListItem Value="IsShopGood,1">��Ʒ</asp:ListItem>
                                    <asp:ListItem Value="IsRecommend,1">�Ƽ�</asp:ListItem>
                                    <asp:ListItem Value="IsSaled,1">�ϼ�</asp:ListItem>
                                    <asp:ListItem Value="-2">------</asp:ListItem>
                                    <asp:ListItem Value="IsSell,0">����</asp:ListItem>
                                    <asp:ListItem Value="IsNew,0">ȡ����Ʒ</asp:ListItem>
                                    <asp:ListItem Value="IsHot,0">ȡ������</asp:ListItem>
                                    <asp:ListItem Value="IsGood,0">ȡ����Ʒ</asp:ListItem>
                                    <asp:ListItem Value="IsRecommend,0">ȡ���Ƽ�</asp:ListItem>
                                    <asp:ListItem Value="IsSaled,0">ȡ���ϼ�</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonEdit" runat="server" OnClientClick="return OperateButton()"
                                    CssClass="zxcz lmf_btn" OnClick="ButtonOperate_Click"><span>ִ�в���</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" CssClass="shanchu lmf_btn" OnClick="ButtonDelete_Click"
                                    OnClientClick="return DeleteButton()"><span>����ɾ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonChangeOrderID" runat="server" CssClass="glpx lmf_btn" OnClientClick="return EditButton()"
                                    OnClick="ButtonChangeOrderID_Click"><span>��������</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <table cellspacing="0" cellpadding="4" border="0" id="Table1" rules="cols" class="gridview_m">
                <thead>
                    <tr align="center" style="color: White;" class="list_header">
                        <th scope="col" class="select_width">
                            <input type="checkbox" onclick="javascript:SelectAllCheckboxesNew(this);" id="checkboxAll">
                        </th>
                        <th scope="col">
                            ��Ʒ����
                        </th>
                        <th scope="col">
                            ������
                        </th>
                        <th scope="col">
                            ��ƷͼƬ
                        </th>
                        <th scope="col">
                            ��Ʒ�۸�
                        </th>
                        <th scope="col">
                            ���
                        </th>
                        <th scope="col">
                            ��������
                        </th>
                        <th scope="col">
                            ��Ʒ
                        </th>
                        <th scope="col">
                            ����
                        </th>
                        <th scope="col">
                            �Ƽ�
                        </th>
                        <th scope="col">
                            ��Ʒ
                        </th>
                        <th scope="col">
                            ����
                        </th>
                        <th scope="col">
                            �ϼ�
                        </th>
                        <th scope="col">
                            �����
                        </th>
                        <th scope="col">
                            ����
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <%if (dt_ProductList != null)
                      {
                          for (int i = 0; i < dt_ProductList.Rows.Count; i++)
                          {
                              DataRow dr = dt_ProductList.Rows[i];%>
                    <tr style="cursor: default;" onmouseout="Num1GridViewShow_mout(this)" onmouseover="Num1GridViewShow_mover(this)">
                        <td align="center" style="">
                            <input id="checkboxItem" value='<%=dr["guid"] %>' type="checkbox" name="checkboxorder" />
                        </td>
                        <td align="center">
                            <%=dr["Name"] %>
                        </td>
                        <td align="center">
                            <%=dr["ShopName"] %>
                        </td>
                        <td align="center">
                            <img src='<%=Page.ResolveUrl(dr["OriginalImage"].ToString())%> ' onmouseover="javascript:ddrivetip('<img width=200px height=200 src=<%=Page.ResolveUrl(dr["OriginalImage"].ToString())%> >','#ffffff')"
                                onmouseout="hideddrivetip()" height="20" width="20" />
                        </td>
                        <td align="center">
                            <%=dr["ShopPrice"] %>
                        </td>
                        <td align="center">
                            <%=dr["RepertoryCount"]%>
                        </td>
                        <td align="center">
                            <%=ShopNum1.Common.Utils.GetUnicodeSubString(dr["ProductCategoryName"].ToString(), 25, "")%>
                        </td>
                        <td align="center">
                            <img src='<%=PageOperator.GetListImageStatus(dr["IsNew"].ToString()=="0"?"1":"0")%>' />
                        </td>
                        <td align="center">
                            <img src='<%=PageOperator.GetListImageStatus(dr["IsHot"].ToString()=="0"?"1":"0")%>' />
                        </td>
                        <td align="center">
                            <img src='<%=PageOperator.GetListImageStatus(dr["IsRecommend"].ToString()=="0"?"1":"0")%>' />
                        </td>
                        <td align="center">
                            <img src='<%=PageOperator.GetListImageStatus(dr["IsShopGood"].ToString()=="0"?"1":"0") %>' />
                        </td>
                        <td align="center">
                            <img src='<%=PageOperator.GetListImageStatus(dr["IsSell"].ToString()=="0"?"1":"0")%>' />
                        </td>
                        <td align="center">
                            <img src='<%=PageOperator.GetListImageStatus(dr["IsSaled"].ToString() == "0" ? "1" : "0")%>' />
                        </td>
                        <td align="center">
                            <%=dr["OrderID"]%>
                        </td>
                        <td align="center">
                            <a href="ProductSearchDetal.aspx?guid=<%=dr["guid"] %>&Type=Other&Back=1" style="color: #4482b4;">
                                �鿴</a>&nbsp;&nbsp;<a href="javascript:void(0)" onclick="if(confirm('�Ƿ�ɾ������Ʒ?')){window.location.href='Prouduct_List.aspx?guid=<%=dr["guid"] %>&sign=del';}"
                                    style="color: #4482b4;">ɾ��</a>
                        </td>
                    </tr>
                    <%}
              } %> 
                </tbody>
            </table>
            <div class="btnlist" style="overflow: auto;" id="showPage" runat="server" visible="false">
                <div class="fnum">
                    ÿҳ��ʾ������ <a href="?pagesize=10" id="page10">10</a> <a href="?pagesize=20" id="page20">
                        20</a> <a href="?pagesize=50" id="page50">50</a>
                </div>
                <div class="fpage" id="pageDiv" runat="server">
                </div>
                <script type="text/javascript" language="javascript">
                    function NumTxt_Int(o) {
                        o.value = o.value.replace(/\D/g, '');
                    }
                    // �ж��Ƿ�������
                    function checknum(str) {
                        var re = /^[0-9]+.?[0-9]*$/;
                        if (!re.test(str)) {
                            alert("��������ȷ�����֣�");
                            return false;
                        } else { return true; }
                    }
                    $(function () {
                        var pagesize = '<%=ShopNum1.Common.Common.ReqStr("pagesize") %>';
                        $("#page" + pagesize).addClass("cur");
                        $(".fpage").find(".quedbtn").click(function () {
                            var pageindex = $("input[name='vjpage']").val();
                            if (checknum(pageindex)) {
                                location.href = '?pagesize=' + pagesize + '&pageid=' + pageindex;
                            }
                        });
                    });
                </script>
            </div>
        </div>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
    </div>
    </form>
    <script type="text/javascript" src="js/showimg.js"></script>
</body>
</html>
