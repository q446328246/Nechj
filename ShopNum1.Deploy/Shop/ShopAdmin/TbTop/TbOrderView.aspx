<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="TbOrderView.aspx.cs" Inherits="ShopNum1.Deploy.Shop.ShopAdmin.TbTop.TbOrderView" %>
<%@ Register TagPrefix="ShopNum1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=1.0.20229.20821, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <link rel='stylesheet' type='text/css' href='../style/style.css' />
        <script src="/js/CommonJS.js" type="text/javascript"> </script>
        <script src="/js/tanchuDIV.js" type="text/javascript"> </script>
        <script src="../js/jquery.pack.js" type="text/javascript"> </script>
    </head>
    <body>
        <form id="form1" runat="server">
            <%---------------��������------------%>
            <div id="dwindow" style="background-color: #FFFFFF; border: 2px solid #6A9500; cursor: hand; display: none; left: 0px; position: absolute; top: 0px;" onmousedown=" initializedrag(event) "
                 onmouseup=" stopdrag() " onselectstart="return false">
                <div id="Div1" class="pop_title">
                    <div class="pop_title_left" style="font-size: 14px">
                        &nbsp;&nbsp;�رս���
                    </div>
                    <div class="pop_title_right">
                        <label title="�رմ˴���" onclick=" closeit() ">
                            �ر�&nbsp;
                        </label>
                    </div>
                </div>
                <div id="dwindowcontent" class="pop_content">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="2" align="left">
                                <asp:Label ID="Label1" runat="server" Text="�رս��ף�����ȷ���Ѿ�֪ͨ��ң����Ѵ��һ���������������رս��ף������ܵ������Ͷ�ߣ�����Ӱ����ʹ��֧������Ȩ����"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                ��ѡ��رոý��׵����ɣ�
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownListReasons" runat="server">
                                    <asp:ListItem Value="0">��ϵ�������</asp:ListItem>
                                    <asp:ListItem Value="1">��Ҳ�������</asp:ListItem>
                                    <asp:ListItem Value="2">����Ѿ�ͨ�����л��</asp:ListItem>
                                    <asp:ListItem Value="3">����Ѿ�ͨ����������ֱ�Ӹ���</asp:ListItem>
                                    <asp:ListItem Value="4">��ͬ�Ǽ��潻��</asp:ListItem>
                                    <asp:ListItem Value="5">��ʱȱ��</asp:ListItem>
                                    <asp:ListItem Value="6">����ԭ��</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                ���ѣ����º��������Ʒ���ڹرս��׺�ϵͳ���Զ��ָ���Ʒ��棬������Ӱ�����¼���Ʒ��״̬��
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="ButtonbtnCancel" runat="server" CssClass="bt2" OnClientClick=" return Page_ClientValidate('UpdateIP'); "
                                            Text="ȷ��" CausesValidation="true" ValidationGroup="UpdateIP" OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="dpsc_mian">
                <p class="ptitle">
                    <a href="../S_Welcome.aspx">��������</a><span class="breadcrume_icon">>></span><span
                                                                                                   class="breadcrume_text">�鿴�Ա�����</span></p>
                <div id="content" class="ordmain1">
                    <div class="pad">
                        <table cellspacing="0" cellpadding="0" border="0" class="lineh">
                            <tr class="up_spac">
                                <td align="right">
                                    ������ţ�
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOrderID" runat="server" CssClass="ss_nr1"></asp:TextBox>
                                </td>
                                <td align="right" style="display: none">
                                    �ۺ����
                                </td>
                                <td style="display: none" class="ss_nr_spac">
                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="tselect">
                                        <asp:ListItem>-ȫ��-</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="right" class="ss_nr_spac">
                                    ����״̬��
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlOrderState" runat="server" CssClass="tselect">
                                        <asp:ListItem Value="0">-ȫ��-</asp:ListItem>
                                        <asp:ListItem Value="ALL_WAIT_PAY">�ȴ���Ҹ���</asp:ListItem>
                                        <asp:ListItem Value="WAIT_SELLER_SEND_GOODS">����Ѹ���</asp:ListItem>
                                        <asp:ListItem Value="WAIT_BUYER_CONFIRM_GOODS">�����ѷ���</asp:ListItem>
                                        <asp:ListItem Value="TRADE_FINISHED">���׳ɹ�</asp:ListItem>
                                        <asp:ListItem Value="ALL_CLOSED">���׹ر�</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="up_spac">
                                <td align="right">
                                    ����سƣ�
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbuyer" runat="server" CssClass="ss_nr1"></asp:TextBox>
                                </td>
                                <td align="right" class="ss_nr_spac">
                                    ����״̬��
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlRateState" runat="server" CssClass="tselect">
                                        <asp:ListItem Value="0">-ȫ��-</asp:ListItem>
                                        <asp:ListItem Value="RATE_UNBUYER">���δ��</asp:ListItem>
                                        <asp:ListItem Value="RATE_UNSELLER">����δ��</asp:ListItem>
                                        <asp:ListItem Value="RATE_UNBUYER_SELLER">��������</asp:ListItem>
                                        <asp:ListItem Value="RATE_BUYER_UNSELLER">��������</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="right" style="display: none" class="ss_nr_spac">
                                    ��������
                                </td>
                                <td style="display: none">
                                    <asp:DropDownList ID="ddlistdelivery" runat="server" CssClass="tselect">
                                        <asp:ListItem Value="0">-ȫ��-</asp:ListItem>
                                        <asp:ListItem Value="cod">��������</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="up_spac">
                                <td align="right">
                                    �ɽ�ʱ�䣺
                                </td>
                                <td colspan="3">
                                    <table cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtStartTime" runat="server" CssClass="ss_nrduan"></asp:TextBox>
                                                <ShopNum1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"
                                                                               EnableScriptLocalization="True">
                                                </ShopNum1:ToolkitScriptManager>
                                            </td>
                                            <td class="line_spac">
                                                -
                                            </td>
                                            <td>
                                                <ShopNum1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartTime"
                                                                           PopupButtonID="imgCalendarStartTime" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                                </ShopNum1:CalendarExtender>
                                                <asp:TextBox ID="txtEndTime" runat="server" CssClass="ss_nrduan"></asp:TextBox>
                                                <ShopNum1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEndTime"
                                                                           PopupButtonID="imgCalendarEndTime" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                                </ShopNum1:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSerch" runat="server" Text="��ѯ" OnClick="btnSerch_Click" CssClass="chax btn_spc" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="btntable_tbg">
                        <asp:LinkButton ID="btnOK" runat="server" OnClick="btnOK_Click" OnClientClick=" return EditButton() "
                                        CssClass="tjbtn1">�鿴��ϸ</asp:LinkButton>
                        <asp:LinkButton ID="btnSendProduct" Visible="false" runat="server" CssClass="tjbtn"
                                        OnClientClick=" return EditButton() " OnClick="btnSendProduct_Click">����</asp:LinkButton>
                        <input type="button" visible="false" value="�رս���" id="ButtonGuanBI" class="bt2" runat="server"
                               onclick="if (OperateButton()) { loadwindow(600, 300); }" />
                    </div>
                    <div id="orderDiv" style="width: 100%;">
                        <asp:Repeater ID="RepeaterOrder" runat="server" OnItemCommand="RepOrder_ItemCommand"
                                      OnItemDataBound="RepOrder_ItemDataBound">
                            <HeaderTemplate>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="blue_tbdd">
                                    <tr>
                                        <th align="center" width="37%" class="th_le1">
                                            ����
                                        </th>
                                        <th width="10%" align="center">
                                            ����
                                        </th>
                                        <th width="10%" align="center">
                                            ����
                                        </th>
                                        <th width="15%" align="center">
                                            ���
                                        </th>
                                        <th width="20%" align="center">
                                            ����״̬
                                        </th>
                                        <th width="8%" align="center" class="th_ri1">
                                            ʵ�տ�
                                        </th>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw">
                                    <tr>
                                        <th class="th_le" width="6%">
                                            <div class="ord_check" style="padding-top: 0;">
                                                <input id="checkboxItem" type="checkbox" value='<%# Eval("tid") %>' />
                                            </div>
                                        </th>
                                        <th class="th_ri" style="text-align: left;">
                                            �������:<%#((TbTrade) Container.DataItem).tid %>&nbsp;&nbsp;&nbsp;<span>�ɽ�ʱ��:<%#((TbTrade) Container.DataItem).created %></span>
                                            <asp:LinkButton ID="LinkButton_Tid" runat="server" CommandArgument='<%# Eval("tid") %>'></asp:LinkButton>
                                        </th>
                                    </tr>
                                </table>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="blue_tb1" style="margin-top: -1px;">
                                    <tr>
                                        <asp:Repeater ID="RepeaterChildOrder" runat="server">
                                            <ItemTemplate>
                                                <td valign="top" width="10%">
                                                    <a href='<%# GetUrl(Eval("oid")) %>' target="_blank">
                                                        <img src='<%#((TbOrder) Container.DataItem).pic_path %>' style="height: 50px; width: 50px;" /></a>
                                                </td>
                                                <td valign="top" width="30%" style="text-align: left;">
                                                    <a href="<%# GetUrl(Eval("oid")) %>" target="_blank">
                                                        <%#((TbOrder) Container.DataItem).title %></a>
                                                </td>
                                                <td align="center" width="10%">
                                                    <%#((TbOrder) Container.DataItem).price %>
                                                </td>
                                                <td align="center" width="10%">
                                                    <%#((TbOrder) Container.DataItem).num %>
                                                </td>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <td align="center" width="15%">
                                            <%#((TbTrade) Container.DataItem).buyer_nick %>
                                        </td>
                                        <td style="color: Red;" align="center" width="15%">
                                            <%#((TbTrade) Container.DataItem).statusText %>
                                        </td>
                                        <td align="center" width="10%">
                                            <%#((TbTrade) Container.DataItem).total_fee %>
                                        </td>
                                        <td style="border-bottom: 1px solid #e6e6e6; border-right: 1px solid #e6e6e6; display: none; padding-right: 2px;">
                                            &nbsp;<div style="display: none;">
                                                      <asp:LinkButton ID="LinkButtonClose" runat="server" CommandArgument="<%#((TbTrade) Container.DataItem).status %>"
                                                                      OnClientClick=" divReason.style.display = 'block' " CommandName="close">�رն���</asp:LinkButton>
                                                      <div id="divReason" runat="server" style="display: none">
                                                          �ر����ɣ�<asp:TextBox ID="txtCloseReason" runat="server" TextMode="MultiLine"></asp:TextBox><asp:LinkButton
                                                                                                                                                      ID="LinkButtonOk" runat="server" CommandName="closeOk" OnClientClick=" return confirm('�Ƿ�ȷ�Ϲر�?\')  ">ȷ��</asp:LinkButton><a
                                                                                                                                                                                                                                                                                  href="javascript:void(0)" onclick=" divReason.style.display = 'none' ">ȡ��</a></div>
                                                      <asp:LinkButton ID="LinkButtonSend" runat="server" CommandName="send" CommandArgument="<%#((TbTrade) Container.DataItem).status %>">����</asp:LinkButton>
                                                  </div>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="no_datas" style="display: none;" id="showtr">
                            <div class="no_data" style="text-align: center;">
                                ��������</div>
                        </div>
                    </div>
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
                    <script type="text/javascript">
                        $(function() {
                            if ($("#orderDiv tr").size() == 2) {
                                $("#showtr").show();
                            } else {
                                $("#pagelistDiv").show();
                            }
                        });

                    </script>
                    <div class="btntable_tbg">
                        <div id="pagelistDiv" runat="server" class="tbhtfy" style="display: none">
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
            </div>
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
        </form>
    </body>
</html>