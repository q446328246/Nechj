<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopInfoList_Manage.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopInfoList_Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>���̹����б�</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"
        runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    �����б�</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td align="right">
                            �������ƣ�
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxShopName" CssClass="tinput" runat="server" Style="width: 200px;"></asp:TextBox>
                        </td>
                        <td class="lmf_padding" align="right">
                            ��ԱID��
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxMemberName" runat="server" Style="width: 200px;" CssClass="tinput"></asp:TextBox>
                        </td>
                        <td class="lmf_padding" align="right">
                            �������ڵأ�
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListRegionCode1" runat="server" AutoPostBack="true"
                                CssClass="tselect" OnSelectedIndexChanged="DropDownListRegionCode1_SelectedIndexChanged"
                                Width="90">
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListRegionCode2" runat="server" AutoPostBack="true"
                                CssClass="tselect" OnSelectedIndexChanged="DropDownListRegionCode2_SelectedIndexChanged"
                                Width="90">
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListRegionCode3" runat="server" Width="90" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                        <%-- <td align="right" width="100px">
                            �������ƣ�
                        </td>
                        <td width="25%">--%>
                        <asp:TextBox ID="TextBoxName" CssClass="tinput" runat="server" Visible="false" Style="width: 160px;"></asp:TextBox>
                        <%-- </td>--%>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td align="right">
                            ���̵ȼ���
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListShopRank" Width="207px" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding" align="right" style="display: none">
                            ����״̬��
                        </td>
                        <td style="display: none">
                            <asp:DropDownList ID="DropDownListIsAudit" Width="207px" runat="server" CssClass="tselect">
                                <asp:ListItem Selected="True" Value="-1">-ȫ��-</asp:ListItem>
                                <asp:ListItem Value="1">��ͨ��</asp:ListItem>
                                <asp:ListItem Value="2">�ѹ���</asp:ListItem>
                                <asp:ListItem Value="3">�ѹر�</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding" align="right">
                            �Ƿ��Ƽ���
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsRecommend" runat="server" Width="207px" CssClass="tselect">
                                <asp:ListItem Selected="True" Value="-1">-ȫ��-</asp:ListItem>
                                <asp:ListItem Value="1">��</asp:ListItem>
                                <asp:ListItem Value="0">��</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding" align="right">
                            ���̷��ࣺ
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListShopCategoryCode1" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="DropDownListShopCategoryCode1_SelectedIndexChanged" CssClass="tselect"
                                Style="width: 90px;">
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListShopCategoryCode2" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="DropDownListShopCategoryCode2_SelectedIndexChanged" CssClass="tselect"
                                Style="width: 90px;">
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListShopCategoryCode3" runat="server" CssClass="tselect"
                                Style="width: 90px;">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="display: none; height: 35px; vertical-align: top;">
                        <%-- <td align="right">
                            �������ã�
                        </td>
                        <td>--%>
                        <asp:DropDownList ID="DropDownListShopReputation" Width="160px" runat="server" Visible="false"
                            CssClass="tinput">
                        </asp:DropDownList>
                        <%-- </td>--%>
                        <td align="right">
                            �Ƿ�������
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsVisits" runat="server" CssClass="tselect" Width="207">
                                <asp:ListItem Selected="True" Value="-1">-ȫ��-</asp:ListItem>
                                <asp:ListItem Value="1">��</asp:ListItem>
                                <asp:ListItem Value="0">��</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding" align="right">
                            �Ƿ����ǣ�
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIshot" runat="server" CssClass="tselect" Width="207">
                                <asp:ListItem Selected="True" Value="-1">-ȫ��-</asp:ListItem>
                                <asp:ListItem Value="1">��</asp:ListItem>
                                <asp:ListItem Value="0">��</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding" align="right">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr height="30" style="display: none;">
                        <%--<td align="right">
                            ���̵�����
                        </td>
                        <td>--%>
                        <asp:DropDownList ID="DropDownListShopEnsure" Width="160px" runat="server" Visible="false"
                            CssClass="tinput">
                        </asp:DropDownList>
                        <%--</td>--%>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td align="right">
                            ����ʱ�䣺
                        </td>
                        <td colspan="5">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxStartTime" CssClass="tinput" runat="server" Width="66"></asp:TextBox>
                                    </td>
                                    <td style="padding-left: 4px; vertical-align: top;">
                                        <img id="imgCalendarSReplyTime2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                            position: relative; top: 3px; width: 16px;" />
                                    </td>
                                    <td>
                                        <ShopNum1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TextBoxStartTime"
                                            PopupButtonID="imgCalendarSReplyTime2" CssClass="ajax__calendar" Format="yyyy-MM-dd" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxTime1" runat="server"
                                            ControlToValidate="TextBoxStartTime" Display="Dynamic" ErrorMessage="ʱ���ʽ����ȷ"
                                            ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td class="lmf_px">
                                        -
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxEndTime" CssClass="tinput" runat="server" Width="66"></asp:TextBox>
                                    </td>
                                    <td style="padding-left: 4px; vertical-align: top;">
                                        <img id="img1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative;
                                            top: 3px; width: 16px;" />
                                    </td>
                                    <td>
                                        <ShopNum1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxEndTime"
                                            PopupButtonID="img1" CssClass="ajax__calendar" Format="yyyy-MM-dd" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEndTime"
                                            Display="Dynamic" ErrorMessage="ʱ���ʽ����ȷ" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonSearch" runat="server" OnClientClick=" document.getElementById('form1').target = '';return true; "
                                            OnClick="ButtonSearch_Click" Text="��ѯ" CssClass="dele" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="display: none; height: 35px; vertical-align: top;">
                        <td align="right" style="display: none">
                            �Ƿ�ʵ����֤��
                        </td>
                        <td style="display: none">
                            <asp:DropDownList ID="DropDownListIdentityIsAudit" runat="server" CssClass="tselect"
                                Width="207">
                                <asp:ListItem Selected="True" Value="-1">-ȫ��-</asp:ListItem>
                                <asp:ListItem Value="1">��</asp:ListItem>
                                <asp:ListItem Value="0">��</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding" align="right" style="display: none">
                            �Ƿ�˾��֤��
                        </td>
                        <td style="display: none">
                            <asp:DropDownList ID="DropDownListCompanIsAudit" runat="server" CssClass="tselect"
                                Width="207">
                                <asp:ListItem Selected="True" Value="-1">-ȫ��-</asp:ListItem>
                                <asp:ListItem Value="1">��</asp:ListItem>
                                <asp:ListItem Value="0">��</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:DropDownList ID="DropDownListOperate" runat="server" Width="150" CssClass="tselect">
                                    <asp:ListItem Value="-1">-��ѡ��-</asp:ListItem>
                                    <%--<asp:ListItem Value="7"> ��Ϊ����</asp:ListItem>
                                    <asp:ListItem Value="6"> ��Ϊ����</asp:ListItem>--%>
                                    <asp:ListItem Value="5"> ��Ϊ�Ƽ�</asp:ListItem>
                                     <asp:ListItem Value="26"> ��Ϊ����վ</asp:ListItem>
                                    <asp:ListItem Value="3">��Ϊ�ر�</asp:ListItem>
                                    <%--<asp:ListItem Value="15">��Ϊʵ����֤</asp:ListItem>
                                    <asp:ListItem Value="16">��Ϊ��˾��֤</asp:ListItem>--%>
                                    <asp:ListItem Value="19">��Ϊ�ٷ�����</asp:ListItem>
                                    <asp:ListItem>---------------</asp:ListItem>
                                    <%--<asp:ListItem Value="10"> ȡ������</asp:ListItem>
                                    <asp:ListItem Value="9"> ȡ������</asp:ListItem>--%>
                                    <asp:ListItem Value="8"> ȡ���Ƽ�</asp:ListItem>
                                    <asp:ListItem Value="27"> ȡ������վ</asp:ListItem>
                                    <asp:ListItem Value="12"> ȡ���ر�</asp:ListItem>
                                    <%--<asp:ListItem Value="17">ȡ��ʵ����֤</asp:ListItem>
                                    <asp:ListItem Value="18">ȡ����˾��֤</asp:ListItem>--%>
                                    <asp:ListItem Value="20">ȡ���ٷ�����</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonOperate" runat="server" OnClick="ButtonOperate_Click" OnClientClick=" document.getElementById('form1').target = '';return OperateButton(); "
                                    class="zxcz lmf_btn"><span>ִ�в���</span></asp:LinkButton>
                            </td>
                            <%--<td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" document.getElementById('form1').target = '';return DeleteButton(); "
                                    class="shanchu lmf_btn" Visible="false"><span>����ɾ��</span></asp:LinkButton>
                            </td>--%>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonUpdateRank" runat="server" OnClick="ButtonUpdateRank_Click"
                                    OnClientClick=" document.getElementById('form1').target = '';return EditButton(); "
                                    class="xiudp lmf_btn"><span>�޸ĵ��̵ȼ�</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonManagerShop" runat="server" OnClick="ButtonManagerShop_Click"
                                    OnClientClick=" if (true) {document.getElementById('form1').target = '_blank';return MangeShop('��ֻ��ѡ��һ�����̽��й���');}return false; "
                                    class="guanlidp lmf_btn"><span>�������</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonUpataShopURL" runat="server" OnClick="ButtonUpataShopURL_Click"
                                    OnClientClick=" document.getElementById('form1').target = '';return EditButton(); "
                                    class="xgdpurl lmf_btn"><span>�޸ĵ���URL</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonChangeOrderID" runat="server" OnClick="ButtonChangeOrderID_Click"
                                    OnClientClick=" document.getElementById('form1').target = '';return EditButton(); "
                                    class="glpx lmf_btn"><span>��������</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonShopPayMent" runat="server" OnClick="ButtonShopPayMent_Click"
                                    OnClientClick=" document.getElementById('form1').target = '';return EditButton(); "
                                    class="guanli lmf_btn"><span>����֧������</span></asp:LinkButton>
                            </td>
                            <td>
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </td>
                        </tr>
                    </table>
                    <%--<asp:Button ID="ButtonOperate" runat="server" Text="ִ�в���" OnClick="ButtonOperate_Click"
                        OnClientClick="return OperateButton()" class="zxcz lmf_btn" />--%>
                    <asp:Button ID="ButtonSearchShop" runat="server" CausesValidation="False" Text="�༭"
                        OnClientClick=" return EditButton() " CssClass="dele" OnClick="ButtonSearchShop_Click"
                        Visible="false" />
                    <%--<asp:Button ID="ButtonDelete" runat="server" CausesValidation="False" Text="����ɾ��"
                        OnClientClick="return DeleteButton()" CssClass="shanchu lmf_btn" OnClick="ButtonDelete_Click" />--%>
                    <%--<asp:Button ID="ButtonUpdateRank" runat="server" Text="�޸ĵ��̵ȼ�" CssClass="xiudp lmf_btn"
                        OnClientClick="return EditButton()" OnClick="ButtonUpdateRank_Click" />--%>
                    <%--<asp:Button ID="ButtonManagerShop" runat="server" Text="�������" class="guanlidp lmf_btn"
                        OnClientClick="if(EditButton()){this.form.target='_blank';window.location.href=window.location.href;} else return false;"
                        OnClick="ButtonManagerShop_Click" />--%>
                    <%--<asp:Button ID="ButtonUpataShopURL" runat="server" Text="�޸ĵ���URL" CssClass="xgdpurl lmf_btn"
                        OnClientClick="return EditButton()" OnClick="ButtonUpataShopURL_Click" />--%>
                    <%--<asp:Button ID="ButtonChangeOrderID" runat="server" Text="��������" class="glpx lmf_btn"
                        OnClientClick="return EditButton()" OnClick="ButtonChangeOrderID_Click" />--%>
                    <%--<asp:Button ID="ButtonShopPayMent" runat="server" Text="����֧������" CssClass="guanli lmf_btn"
                        OnClientClick="return EditButton()" OnClick="ButtonShopPayMent_Click" />--%>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="ȷʵҪɾ��ָ���ļ�¼��" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSource" AllowMultiColumnSorting="False"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4"
                GridLines="Vertical">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--��ҳ--%>
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" CssClass="lmf_page" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="��������" SortExpression="ShopName">
                        <ItemTemplate>
                            <a id="A1" href='<%#ShopUrlOperate.GetShopUrl(Eval("ShopID").ToString()) %>' target="_blank"
                                runat="server">
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("ShopName") %>'></asp:Label></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="���̵�ַ" SortExpression="ShopID">
                        <ItemTemplate>
                            <a id="A2" href='<%#ShopUrlOperate.GetShopUrl(Eval("ShopID").ToString()) %>' target="_blank"
                                runat="server">
                                <asp:Label ID="Label7" runat="server" Text='<%#ShopUrlOperate.GetShopUrl(Eval("ShopID").ToString()) %>'></asp:Label></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="��ԱID" DataField="MemLoginID" SortExpression="MemLoginID"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:TemplateField HeaderText="���̵���" SortExpression="AddressValue" FooterStyle-CssClass="">
                        <ItemTemplate>
                            <%#Eval("AddressValue").ToString().Replace(",", "") %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="���̵ȼ�" SortExpression="RankName">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("RankName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="��������" SortExpression="ShopType">
                        <ItemTemplate>
                            <%# Eval("ShopType").ToString() == "1" ? "��ҵ����" : "���˵���" %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����״̬" SortExpression="IsClose">
                        <ItemTemplate>
                            <asp:Image ID="Image5" runat="server" ImageUrl='<%# GetListImageStatus(Eval("IsClose").ToString() == "1" ? "0" : "1") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="����" DataField="OrderID" SortExpression="OrderID" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <a href="<%# "ShopInfo_Operate.aspx?Guid='" + Eval("Guid") + "'" %>" style="color: #4482b4;">
                                �༭</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid") %>'
                                OnClick="ButtonDeleteBylink_Click" OnClientClick=" return window.confirm('��ȷ��Ҫɾ����?'); "> ɾ�� </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <RowStyle BackColor="#F7F7DE" />
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSource" runat="server" SelectMethod="SearchInfoList"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_ShopInfoList_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBoxShopName" Name="ShopName" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxName" Name="Name" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="TextBoxMemberName" Name="memberLoginID" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter Name="type" Type="String" DefaultValue="" ControlID="HiddenFieldCode"
                    PropertyName="Value" />
                <asp:ControlParameter ControlID="HiddenFieldRegionCode" DefaultValue="" Name="AddressCode"
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="DropDownListIshot" Name="Ishot" PropertyName="SelectedValue"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListIsVisits" Name="IsVisits" PropertyName="SelectedValue"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListIsRecommend" Name="IsRecommend" PropertyName="SelectedValue"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListIsExpires" Name="IsExpires" PropertyName="SelectedValue"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListIdentityIsAudit" Name="IdentityIsAudit"
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="DropDownListCompanIsAudit" Name="CompanIsAudit"
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="DropDownListShopRank" Name="shoprank" PropertyName="SelectedValue"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListShopReputation" Name="shoprepution"
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="DropDownListShopEnsure" Name="shopensure" PropertyName="SelectedValue"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListIsAudit" Name="IsAudit" PropertyName="SelectedValue"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxStartTime" DefaultValue="" Name="startTime"
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="TextBoxEndTime" DefaultValue="" Name="endTime" PropertyName="Text"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
        <asp:HiddenField ID="HiddenFieldRegionCode" runat="server" Value="-1" />
    </div>
    <div style="display: none">
        <asp:DropDownList ID="DropDownListIsExpires" runat="server" CssClass="tselect" Width="207">
            <asp:ListItem Selected="True" Value="-1">-ȫ��-</asp:ListItem>
            <asp:ListItem Value="1">��</asp:ListItem>
            <asp:ListItem Value="0">��</asp:ListItem>
        </asp:DropDownList>
    </div>
    </form>
</body>
</html>
