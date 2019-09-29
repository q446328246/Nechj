<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="TbPrdouctView.aspx.cs" Inherits="ShopNum1.Deploy.Shop.ShopAdmin.TbTop.TbPrdouctView" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.TbBusinessEntity" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <link rel='stylesheet' type='text/css' href='../style/style.css' />
        <link href="../style/dshow.css" rel="stylesheet" />
        <script src="/Main/js/CommonJS.js" type="text/javascript"> </script>
        <script src="../js/dshow.js" type="text/javascript"> </script>
        <script type="text/javascript" src="/js/jquery-1.6.2.min.js"> </script>
        <script type="text/javascript">
            function ddrivetip(oimg) {
                var imgposition = $(oimg).offset();
                $("#dhtmltooltip").css({ "top": imgposition.top + 20, "left": imgposition.left + 50 });
                var imgsrc = $(oimg).attr("src");
                $("#dhtmltooltip img").attr("src", imgsrc);
                $("#dhtmltooltip").css("display", "block");
            }

            function hideddrivetip() {

                $("#dhtmltooltip").hide();

            }

            function CheckAll(vobj) {
                var sel = $(vobj).attr("checked");
                $("#DataListProduct tbody tr").each(function() {
                    if (sel == "checked") {
                        $(this).children(":first").find(":checkbox").attr("checked", sel);
                    } else {
                        $(this).children(":first").find(":checkbox").removeAttr("checked");
                    }

                });
            }

            function DownTaobaoProducts() {
                var selnumid = "";

                var issel = false;
                $("#DataListProduct tbody tr:not(:first)").each(function() {
                    var vcheck = $(this).children(":first").find(":checkbox");
                    if (vcheck.attr("checked") == "checked") {
                        var nvalue = vcheck.val();
                        selnumid += nvalue + ",";
                        issel = true;
                    }

                });
                if (!issel) {
                    alert("��ѡ��Ҫ�������Ա���Ʒ!");
                    return false;
                }
                selnumid = selnumid.substring(0, selnumid.length - 1);
                $("#CheckGuid").val(selnumid);
                return true;
            }

            function ShopPop(m, h) {
                funOpen();
            }
        </script>
        <script src="/js/tanchuDIV.js" type="text/javascript"> </script>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div style="display: none; left: -1000px; position: absolute; top: 377px;" id="dhtmltooltip">
                <img src="" height="200" width="200px">
            </div>
            <%---------------��������------------%>
            <div class="sp_dialog sp_dialog_out" style="display: none; height: 393px;" id="sp_dialog_outDiv">
                <div class="sp_dialog_cont" style="display: none;" id="sp_dialog_contDiv">
                    <div class="sp_tan">
                        <h4>
                            ͬ���Ա���Ʒ</h4>
                        <div class="sp_close">
                            <a href="javascript:void(0)" onclick=" funClose() "></a>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="sp_tan_content" id="A_LoadUserPhoto">
                        <div id="dwindowcontent" class="pop_content">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="right" style="width: 20%;">
                                        <asp:Label ID="LabelProductCategory" runat="server" Text="��Ʒ���ࣺ"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:UpdatePanel ID="UpdatePanelProdcutCate" runat="server" UpdateMode="Conditional"
                                                         RenderMode="Inline">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="DropDownListProductCategoryCode1" runat="server" AutoPostBack="true"
                                                                  CssClass="tselect" Width="120px">
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="DropDownListProductCategoryCode2" runat="server" AutoPostBack="true"
                                                                  CssClass="tselect" Width="120px">
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="DropDownListProductCategoryCode3" runat="server" AutoPostBack="true"
                                                                  CssClass="tselect" Width="120px">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 20%;">
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 20%;">
                                        <asp:Label ID="LabelBrand" runat="server" Text="��ƷƷ�ƣ�"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:UpdatePanel ID="UpdatePanelBrand" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="DropDownListProductBrand" runat="server" AutoPostBack="true"
                                                                  CssClass="tselect" Width="120px">
                                                    <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label ID="Label27" runat="server" Text="*" ForeColor="red"></asp:Label>
                                                <asp:CompareValidator ID="CompareValidatorDropDownListProductBrand" runat="server"
                                                                      ValidationGroup="popDivGroup" ControlToValidate="DropDownListProductBrand" Display="Dynamic"
                                                                      ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 20%;">
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 20%;">
                                        <asp:Label ID="LabelSupplier" runat="server" Text="������Ʒ���ࣺ"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:UpdatePanel ID="UpdatePanelProdSeries" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="DropDownListProductSeriesCode1" runat="server" AutoPostBack="true"
                                                                  CssClass="tselect" Width="120px">
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="DropDownListProductSeriesCode2" runat="server" AutoPostBack="true"
                                                                  CssClass="tselect" Width="120px">
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="DropDownListProductSeriesCode3" runat="server" CssClass="tselect"
                                                                  Width="120px">
                                                </asp:DropDownList>
                                                <asp:Label ID="Label20" runat="server" Text="*" ForeColor="red"></asp:Label>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="DropDownListProductSeriesCode1"
                                                                      Display="Dynamic" ErrorMessage="��ֵ����ѡ��" ValidationGroup="popDivGroup" Operator="NotEqual"
                                                                      ValueToCompare="-1"></asp:CompareValidator>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 20%;">
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 20%;">
                                        <asp:Label ID="Label10" runat="server" Text="ͼƬ��᣺"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListImgCategory" runat="server" CssClass="tselect"
                                                          Width="120px">
                                        </asp:DropDownList>
                                        <asp:Label ID="Label11" runat="server" Text="*" ForeColor="red"></asp:Label>
                                        <asp:CompareValidator ID="CompareValidatorImgCategory" runat="server" ControlToValidate="DropDownListImgCategory"
                                                              Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"
                                                              ValidationGroup="popDivGroup"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 20%;">
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 20%;">
                                        <asp:Label ID="Label7" runat="server" Text="������ƷΪ��"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:CheckBox ID="CheckBoxIsNew" runat="server" Text="��Ʒ" />&nbsp;
                                        <asp:CheckBox ID="CheckBoxIsHot" runat="server" Text="����" />&nbsp;
                                        <asp:CheckBox ID="CheckBoxIsPromotion" runat="server" Text="����" />
                                        <asp:CheckBox ID="CheckBoxIsShopRecommend" runat="server" Text="�Ƽ�" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 20%;">
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 20%;">
                                        <asp:Label ID="Label1" runat="server" Text="�Ƿ��ϼܣ�"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:RadioButton ID="RadioButtonIsSaleTrue" runat="server" GroupName="issale" Text="��"
                                                         Checked="true" />&nbsp;
                                        <asp:RadioButton ID="RadioButtonIsSaleFalse" runat="server" GroupName="issale" Text="��" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 20%;">
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Button ID="ButtonbtnOk" ValidationGroup="popDivGroup" runat="server" CssClass="baocbtn"
                                                    OnClientClick=" if (Page_ClientValidate('popDivGroup')) {this.disabled = 'disabled';document.getElementById('imgSpan').style.display = 'inline';} else {return false;} "
                                                    Text="ȷ��" UseSubmitBehavior="false" CausesValidation="true" OnClick="ButtonbtnOk_Click" />
                                        <input type="button" value="ȡ��" onclick=" closeit() " class="bt2" style="display: none;" />
                                        <span style="color: #f00; height: 30px; line-height: 30px; padding-left: 5px;">(�����ڼ��벻Ҫˢ��)</span>
                                        <span id="imgSpan" runat="server" style="display: none;">
                                            <img src="/Images/load.gif" /></span>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div class="dpsc_mian">
                <p class="ptitle">
                    <a href="../S_Welcome.aspx">��������</a><span class="breadcrume_icon">>></span><span
                                                                                                   class="breadcrume_text">�鿴�Ա���Ʒ</span></p>
                <div id="content" class="ordmain1">
                    <div class="pad">
                        <table cellspacing="0" cellpadding="0" border="0" class="lineh">
                            <tr class="up_spac">
                                <td align="right">
                                    �������ƣ�
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTitle" runat="server" CssClass="ss_nr1"></asp:TextBox>
                                </td>
                                <td align="right" class="ss_nr_spac">
                                    ��Ʒ���ࣺ
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListOne" runat="server" CssClass="tselect1">
                                        <asp:ListItem Value="-1" Text="-ȫ��-"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListTwo" runat="server" CssClass="tselect1">
                                        <asp:ListItem Value="-1" Text="-ȫ��-"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="up_spac">
                                <td align="right">
                                    ��Ա���ۣ�
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDiscount" runat="server" CssClass="tselect">
                                        <asp:ListItem Value="-1">-ȫ��-</asp:ListItem>
                                        <asp:ListItem Value="true">��</asp:ListItem>
                                        <asp:ListItem Value="false">��</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="right" class="ss_nr_spac">
                                    �Ƿ�����Ƽ���
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlshowcase" runat="server" CssClass="tselect">
                                        <asp:ListItem Value="-1">-ȫ��-</asp:ListItem>
                                        <asp:ListItem Value="true">��</asp:ListItem>
                                        <asp:ListItem Value="false">��</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="btnSerch" runat="server" Text="��ѯ" OnClick="btnSerch_Click" CssClass="chax btn_spc" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="btntable_tbg">
                        <a class="tjbtn1" onclick=" if (DownTaobaoProducts()) { ShopPop(600, 300);
                                                                                                                                                                                              } ">
                            ����ͬ��</a>
                    </div>
                    <div id="productDiv">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%" class="blue_tb2" id="DataListProduct">
                            <tr>
                                <th class="th_le" width="6%">
                                    <input type="checkbox" id="inputall" name="inputall" onclick=" CheckAll(this) " />
                                </th>
                                <th>
                                    ��Ʒ����
                                </th>
                                <th width="230">
                                    ����
                                </th>
                                <th>
                                    ����
                                </th>
                                <th>
                                    ����
                                </th>
                                <th>
                                    ��Ʒ����
                                </th>
                                <th width="70">
                                    �Ƿ��Ƽ�
                                </th>
                                <th width="70">
                                    �Ƿ����
                                </th>
                                <th class="th_ri" width="70">
                                    �Ƿ�ͬ��
                                </th>
                            </tr>
                            <asp:Repeater ID="RepeaterProduct" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <input type="checkbox" value="<%#((TbItem) Container.DataItem).num_iid %>" />
                                        </td>
                                        <td style="border-bottom: 1px solid #e3e3e3; border-left: 1px solid #e3e3e3; border-right: 1px solid #e3e3e3;">
                                            <img style="height: 50px; top: 2px; width: 50px;" src='<%#((TbItem) Container.DataItem).pic_url %>'
                                                 onmouseout=" hideddrivetip() " alt="<%#((TbItem) Container.DataItem).title %>"
                                                 onmouseover=" ddrivetip(this) " />
                                        </td>
                                        <td style="border-bottom: 1px solid #e3e3e3; border-right: 1px solid #e3e3e3;">
                                            <a target="_blank" href="<%#GetProductUrl(((TbItem) Container.DataItem).num_iid) %>">
                                                <%# Utils.GetUnicodeSubString(((TbItem) Container.DataItem).title, 50, "") %>
                                            </a>
                                        </td>
                                        <td align="center" style="border-bottom: 1px solid #e3e3e3; border-right: 1px solid #e3e3e3;">
                                            <%#((TbItem) Container.DataItem).price %>
                                        </td>
                                        <td align="center" style="border-bottom: 1px solid #e3e3e3; border-right: 1px solid #e3e3e3;">
                                            <%#((TbItem) Container.DataItem).num %>
                                        </td>
                                        <td align="center" style="border-bottom: 1px solid #e3e3e3; border-right: 1px solid #e3e3e3;">
                                            <span title="<%# GetShopCategroyName(((TbItem) Container.DataItem).seller_cids) %>">
                                                <%# GetShopCategroyName(((TbItem) Container.DataItem).seller_cids) %></span>
                                        </td>
                                        <td align="center" style="border-bottom: 1px solid #e3e3e3; border-right: 1px solid #e3e3e3;">
                                            <%#Convert.ToBoolean(((TbItem) Container.DataItem).has_showcase) ? "��" : "��" %>
                                        </td>
                                        <td align="center" style="border-bottom: 1px solid #e3e3e3; border-right: 1px solid #e3e3e3;">
                                            <%#Convert.ToBoolean(((TbItem) Container.DataItem).has_discount) ? "��" : "��" %>
                                        </td>
                                        <td>
                                            <%# IsProductTaobao(((TbItem) Container.DataItem).num_iid.ToString()) %>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <tr style="display: none;" id="showtr">
                                <td colspan="9" style="border-left: solid 1px #e3e3e3; border-right: solid 1px #e3e3e3; height: 16px;">
                                    <div class="no_datas">
                                        <div class="no_data">
                                            ��������</div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="btntable_tbg">
                        <div id="pagelistDiv" runat="server" class="tbhtfy" style="display: none">
                        </div>
                    </div>
                </div>
                <script type="text/javascript">
                    $(function() {
                        if ($("#productDiv tr").size() == 2) {
                            $("#showtr").show();
                        } else {
                            $("#pagelistDiv").show();
                        }
                    });
                </script>
                <script type="text/javascript">
//<![CDATA[
                    var theForm = document.forms[0];
                    if (!theForm) {
                        theForm = document.form1;
                    }

                    function PageClick(eventTarget) {
                        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
                            theForm.pageid.value = eventTarget;
                            theForm.submit();
                        }
                    }
//]]>
        </script>
                <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
            </div>
        </form>
    </body>
</html>