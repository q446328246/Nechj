<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="A_AdPayDetailList.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Account.Skin.A_AdPayDetailList" %>
<div id="list_main" class="list_main">
    <div id="Div1">
        <div id="content">
            <div class="pad">
                <table border="0" cellspacing="0" cellpadding="0" class="lineh">
                    <tr class="up_spac">
                        <td align="right">
                            ����ʱ�䣺
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <input type="text" class="ss_nrduan Wdate" runat="server" id="txt_StartTime" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                                    </td>
                                    <td class="line_spac">
                                        -
                                    </td>
                                    <td>
                                        <input type="text" class="ss_nrduan Wdate" runat="server" id="txt_EndTime" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="right" class="ss_nr_spac">
                            �ʽ����
                        </td>
                        <td>
                            <select name="sel" size="1" class="tselect" id="sel_Type" runat="server">
                                <option value="-1">ȫ����BV��</option>
                                <option value="1">��ֵ��BV��</option>
                                <option value="3">���ѣ�BV��</option>
                                <option value="5">ϵͳ��BV��</option>
                                <option value="6">ת�ˣ�BV��</option>
                                <option value="7">����Դ�����ѣ�LNEC��</option>
                                <option value="8">����Դ����ã�LNEC��</option>
                                <%--<option value="9">��������ȯ���ѣ�HV��</option>
                                <option value="10">��������ȯ��ã�HV��</option>--%>
                                <%--<option value="11">������������(PV_B)</option>
                                <option value="12">�������ֻ��(PV_B)</option>
                                <option value="13">�������롢����(RV)</option>--%>
                                <option value="14">����Դ�����ѣ�NEC��</option>
                                <option value="15">����Դ�һ�ã�NEC��</option>
                                <%--<option value="16">C��������(CV)</option>
                                <option value="17">C���ֻ��(CV)</option>
                                <option value="18">�������롢�۳�(RV)</option>--%>
                            </select>
                        </td>
                        <td>
                            <asp:Button ID="Btn_Select" runat="server" Text="��ѯ" CssClass="chax"  OnClick="Btn_Select_Click"/>
                        </td>
                    </tr>
                </table>
                <%--  ��������--%>
                <input type="hidden" runat="server" id="hid_type" runat="server" value="-1" />
            </div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_top"
                style="margin-top: 10px;">
                <tr>
                    <td style="border-left: solid 1px #e3e3e3; text-align: left;" id="MYid_one" runat="server">
                        &nbsp;&nbsp;&nbsp;���ױ�����<span style="color: #ff0000; font-weight: bold;"><asp:Label
                            ID="lab_PayNum" runat="server" Text="0"></asp:Label>
                        </span>�� &nbsp;&nbsp;&nbsp; ����� ��<span style="color: #ff0000; font-weight: bold;"><asp:Label
                            ID="lab_PayDetail" runat="server" Text="0.00"></asp:Label>
                        </span>
                    </td>
                </tr>
            </table>
            <table border="0" cellspacing="1" cellpadding="0" class="biaodhd1" width="100%">
                <tr>
                    <th>
                        ����ʱ��
                    </th>
                    <th>
                        ���ǰ���
                    </th>
                    <th>
                        �������
                    </th>
                    <th>
                        �������
                    </th>
                    <th width="10%">
                        ����
                    </th>
                    <th>
                        ��ע
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="Rep_PayA_AdPayDetailList">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "Date")%>
                            </td>
                            <td class="red" align="right">
                                <%# DataBinder.Eval(Container.DataItem, "money_first")%>
                            </td>
                            <td style="color: Red" align="right">
                                <%# ShopNum1.AccountWebControl.A_AdPayDetailList.GetMoney(Eval("money_first").ToString(), Eval("money_free").ToString(), Eval("money_two").ToString())%>
                            </td>
                            <td class="red">
                                <%# DataBinder.Eval(Container.DataItem, "money_free")%>
                            </td>
                            <td>
                                <%# ShopNum1.AccountWebControl.A_AdPayDetailList.ChangeOperateType(Eval("OperateType").ToString())%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "Memo")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <%if (Rep_PayA_AdPayDetailList.Items.Count == 0)
                  { %>
                <tfoot>
                    <tr>
                        <td colspan="6" style="height: 86px;">
                            <div class="no_data">
                                ��������</div>
                        </td>
                    </tr>
                </tfoot>
                <% }%>
            </table>
            <!--��ҳ-->
            <div class="fenye">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_b">
                    <tr>
                        <td style="border-right: none; border-left: solid 1px #e3e3e3; width: 30px;">
                            &nbsp;
                        </td>
                        <td style="border-left: none;">
                            <div id="pageDiv" runat="server" class="fy">
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
    $(function () {
        $("#<%=sel_Type.ClientID%>").find("option[value='" + sel_Type + "']").attr("selected", true);
        $("#<%=txt_StartTime.ClientID%>").val(startTime);
        $("#<%=txt_EndTime.ClientID%>").val(endTime);
        $("#<%=sel_Type.ClientID%>").change(function () {
            var TypeValue = $("#<%=sel_Type.ClientID%>").find("option:selected").val();
            $("#<%=hid_type.ClientID%>").val(TypeValue);
        });

    })
</script>
