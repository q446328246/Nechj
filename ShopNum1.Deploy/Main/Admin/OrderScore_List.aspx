<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="OrderScore_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.OrderScore_List" %>
    <%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��������б�</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
    <style type="text/css">
        #CalendarExtender1_popupDiv
        {
            height: 200px;
        }
        
        #CalendarExtender2_popupDiv
        {
            height: 200px;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function ImportData() {
            var checkedBoxValues = GetCheckedBoxValues();
            if (checkedBoxValues == "0") {
                alert("��ѡ��Ҫ���������ݣ�");
                return false;
            } else {
                document.getElementById("CheckGuid").value = checkedBoxValues.replace('0,', '');
                return true;
            }
        }

        function GetCheckedBoxValues() {
            var checkedBoxValues = "0";
            var inputs = document.getElementsByTagName("input");
            for (var j = 0; j < inputs.length; j++) {
                if (inputs[j].checked == true) {
                    checkedBoxValues += ("," + "'" + inputs[j].value + "'");
                }
            }
            return checkedBoxValues;
        }

    </script>
</head>
<body class="widthah">
    <form id="form1" runat="server">
    <div id="right">
        <div class="mhead">
            <div class="ml">
                <div class="mr">
                    <ul class="mul">
                        <li id="current1">
                            <asp:LinkButton ID="LinkButtonAll" runat="server" CssClass="cur" OnClick="LinkButtonAll_Click">ȫ������</asp:LinkButton>
                        </li>
                        <li id="current2">
                            <asp:LinkButton ID="LinkButtonOderStatusOk" runat="server" OnClick="LinkButtonOderStatusOk_Click">�Ѵ���</asp:LinkButton>
                        </li>
                        <li id="current3">
                            <asp:LinkButton ID="LinkButtonOderStatusNo" runat="server" OnClick="LinkButtonOderStatusNo_Click">δ����</asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td style="text-align: right;">
                            <asp:Label ID="LabelOrderNumber" runat="server" Text="�����ţ�"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxOrderNumber" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding" style="text-align: right;">
                            <asp:Label ID="LabelMemLoginID" runat="server" Text="�ջ��ˣ�"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxMemLoginID" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            �ֻ����룺
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxPhone" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td style="text-align: right;">
                            ����ID��
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxShopID" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            <asp:Label ID="LabelCreateTime" runat="server" Text="�µ����ڣ�"></asp:Label>
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxCreateTime1" CssClass="dinput" runat="server" Width="66"></asp:TextBox>
                                    </td>
                                    <td valign="top" style="padding-left: 4px;">
                                        <img id="imgCalendarCreateTime1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                            position: relative; top: 4px; width: 16px;" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <ShopNum1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"
                                            EnableScriptLocalization="True">
                                        </ShopNum1:ToolkitScriptManager>
                                    </td>
                                    <td>
                                        <ShopNum1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxCreateTime1"
                                            PopupButtonID="imgCalendarCreateTime1" CssClass="ajax__calendar">
                                        </ShopNum1:CalendarExtender>
                                    </td>
                                    <td class="lmf_px">
                                        -
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="dinput" ID="TextBoxCreateTime2" runat="server" Width="66"></asp:TextBox>
                                    </td>
                                    <td valign="top" style="padding-left: 4px;">
                                        <img id="imgCalendarCreateTime2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                            position: relative; top: 4px; width: 16px;" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <ShopNum1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxCreateTime2"
                                            PopupButtonID="imgCalendarCreateTime2" CssClass="ajax__calendar">
                                        </ShopNum1:CalendarExtender>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="lmf_padding">
                            <asp:Label ID="LabelShouldPayPrice" runat="server" Text="���������"></asp:Label>
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxShouldPayPrice1" CssClass="dinput" runat="server" Width="66"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorShouldPayPrice1" runat="server"
                                            ControlToValidate="TextBoxShouldPayPrice1" Display="Dynamic" ErrorMessage="�����ʽ����ȷ"
                                            ValidationExpression="^[0-9]+(.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td class="lmf_px">
                                        -
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxShouldPayPrice2" runat="server" CssClass="dinput dp" Width="66"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorShouldPayPrice2" runat="server"
                                            ControlToValidate="TextBoxShouldPayPrice2" Display="Dynamic" ErrorMessage="�����ʽ����ȷ"
                                            ValidationExpression="^[0-9]+(.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonSearch" runat="server" Text="����" CssClass="orderbtn" OnClick="ButtonSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonReport" runat="server" CausesValidation="False" CssClass="daochubtn lmf_btn"
                                    OnClick="ButtonReport_Click"><span>������Excel</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app" style="display: none;">
                                <asp:LinkButton ID="ButtonEdit" runat="server" OnClientClick=" return EditButton() "
                                    CausesValidation="False" CssClass="bt2" Visible="false"><span>�鿴</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClientClick=" return DeleteButton() "
                                    CausesValidation="False" CssClass="shanchu lmf_btn" OnClick="ButtonDelete_Click"><span>����ɾ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" cssclass="bt2" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <cc1:num1gridview id="Num1GridViewShow" runat="server" autogeneratecolumns="False"
                allowpaging="True" allowsorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" addsequencecolumn="False" width="98%"
                del="False" deleteprompttext="ȷʵҪɾ��ָ���ļ�¼��" edit="False" fixheader="False" gridviewsortdirection="Ascending"
                pagingstyle="None" tablename="" allowmulticolumnsorting="False" backcolor="White"
                bordercolor="#DEDFDE" borderstyle="None" onpageindexchanging="Num1GridViewShow_Changing">
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                        <%--��ҳ--%>
                        <PagerStyle  CssClass="lmf_page"  BackColor="#E8E8E8" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                                </HeaderTemplate>
                                <HeaderStyle CssClass="select_width" />
                                <ItemTemplate>
                                    <input id="checkboxItem" runat="server" value='<%# Eval("Guid") %>' type="checkbox" />
                                    <input type="hidden" value='<%# Eval("OrderNumber") %>' name="checkboxorder" type="checkbox" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="3%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="false">
                                <HeaderStyle CssClass="hidden" />
                                <ItemStyle CssClass="hidden" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="������">
                                <ItemTemplate>
                                    <a href='OrderScore_Operate.aspx?guid=<%#Eval("Guid") %>&OrderNumber=<%#Eval("OrderNumber") %>'>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("OrderNumber") %>' ForeColor="#4482b4"></asp:Label></a>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="10%" ForeColor="#4482b4" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ShopMemLoginID" HeaderText="����ID">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="��ϸ��ַ" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="LabelAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="�ʱ�" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="LabelCode" runat="server" Text='<%#Eval("Postalcode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TotalScore" HeaderText="�����ܺ��" >
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MemLoginID" HeaderText="��һ�Ա��">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="�ջ���" DataField="Name">
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="�ֻ�����">
                                <ItemTemplate>
                                    <asp:Label ID="Labelmobile" runat="server" Text='<%#Eval("Mobile") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="�����ʼ�" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="Labelemail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="״̬" SortExpression="OderStatus">
                                <ItemTemplate>
                                    <%#GetState(Eval("OderStatus").ToString()) %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="9%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="CreateTime" HeaderText="�µ�ʱ��" >
                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="����">
                                <ItemTemplate>
                                    <a href='OrderScore_Operate.aspx?guid=<%#Eval("Guid") %>&OrderNumber=<%#Eval("OrderNumber") %>' style="color: #4482b4;">
                                        �鿴</a>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle BackColor="#F7F7DE" />
                    </cc1:num1gridview>
        </div>
    </div>
    <%--����� ����ɾ��--%>
    <div class="query" style="display: none;">
        <asp:Label ID="LabelOderStatus" runat="server" Text="����״̬��"></asp:Label>
        <asp:DropDownList ID="DropDownListOderStatus" runat="server" CssClass="inputselect">
        </asp:DropDownList>
        <table style="width: 100%">
            <tr>
                <td align="right">
                    <asp:Label ID="LabelAddress1" runat="server" Text="��ϸ��ַ��"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxAddress" CssClass="allinput1" runat="server"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label ID="LabelPostalcode" runat="server" Text="�ʱࣺ"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxPostalcode" CssClass="allinput1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="LabelMobile" runat="server" Text="�ֻ����룺"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxMobile" CssClass="allinput1" runat="server"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label ID="LabelEmail" runat="server" Text="�����ʼ���"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEmail" CssClass="allinput1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="LabelTel" runat="server" Text="��ϵ�绰��"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxTel" CssClass="allinput1" runat="server"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label ID="LabelName" runat="server" Text="�ջ��ˣ�"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxName" CssClass="allinput1" runat="server"></asp:TextBox>
                </td>
                <td align="right">
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListType" runat="server" Width="180px">
                        <asp:ListItem Value="0">��ͨ����</asp:ListItem>
                        <asp:ListItem Value="-1">ȫ������</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="LabelPaymentState" runat="server" Text="����״̬��"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListPaymentState" runat="server" CssClass="select1">
                        <asp:ListItem Value="-1" Text="-ȫ��-"></asp:ListItem>
                        <asp:ListItem Value="0" Text="δ����"></asp:ListItem>
                        <asp:ListItem Value="1" Text="�Ѹ���"></asp:ListItem>
                        <asp:ListItem Value="2" Text="���˿�"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label ID="LabelShipmentState" runat="server" Text="����״̬��"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListShipmentState" runat="server" CssClass="select1">
                        <asp:ListItem Value="-1" Text="-ȫ��-"></asp:ListItem>
                        <asp:ListItem Value="0" Text="δ����"></asp:ListItem>
                        <asp:ListItem Value="1" Text="�ѷ���"></asp:ListItem>
                        <asp:ListItem Value="2" Text="���ջ�"></asp:ListItem>
                        <asp:ListItem Value="3" Text="���˻�"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
