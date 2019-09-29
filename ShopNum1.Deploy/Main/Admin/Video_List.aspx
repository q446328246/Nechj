<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Video_List.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Video_List" %>
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
</head>
<body style="background-image: url(images/Bg_right.gif); background-repeat: repeat;
    padding: 0;">
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    视频列表
                </h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table border="0" cellspacing="0" cellpadding="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td style="text-align: right;">
                            <asp:Localize ID="LocalizeTitle" runat="server" Text="视频标题："></asp:Localize>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding" style="text-align: right;">
                            视频分类：
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListCategoryID" runat="server" CssClass="tselect" Width="207">
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding" style="text-align: right;">
                            <asp:Localize ID="LocalizePublisher" runat="server" Text="作者/发布人："></asp:Localize>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxPublisher" runat="server" CssClass="tinput" Width="100"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td align="right">
                            <asp:Localize ID="LocalizeIsRecommend" runat="server" Text="是否推荐："></asp:Localize>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsRecommend" runat="server" CssClass="tselect"
                                Width="207">
                                <asp:ListItem Value="-1">-全部-</asp:ListItem>
                                <asp:ListItem Value="1">是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding" style="text-align: right;">
                            发布时间：
                        </td>
                        <td colspan="3">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxStartTime" runat="server" CssClass="tinput_data"></asp:TextBox>
                                    </td>
                                    <td valign="top" style="padding-left: 4px;">
                                        <img id="imgCalendarStartTime" alt="" src="/ImgUpload/Calendar.png" style="height: 16px;
                                            position: relative; top: 3px; width: 16px;" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxStartTime"
                                            Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                                    </td>
                                    <td style="display: none;">
                                        <cc2:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server" EnableScriptGlobalization="True"
                                            EnableScriptLocalization="True">
                                        </cc2:ToolkitScriptManager>
                                        <cc2:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TextBoxStartTime"
                                            PopupButtonID="imgCalendarStartTime" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                        </cc2:CalendarExtender>
                                    </td>
                                    <td class="lmf_px">
                                        -
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxEndTime" runat="server" CssClass="tinput_data"></asp:TextBox>
                                    </td>
                                    <td valign="top" style="padding-left: 4px;">
                                        <img id="imgCalendarEndTime" alt="" src="/ImgUpload/Calendar.png" style="height: 16px;
                                            position: relative; top: 3px; width: 16px;" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxEndTime"
                                            Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                                        <asp:CompareValidator ID="CompareTextBoxEndTime" runat="server" ControlToValidate="TextBoxEndTime"
                                            Display="Dynamic" ErrorMessage="结束时间必须大于开始时间" Operator="GreaterThan" Type="Date"
                                            ControlToCompare="TextBoxStartTime"></asp:CompareValidator>
                                    </td>
                                    <td>
                                        <cc2:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TextBoxEndTime"
                                            PopupButtonID="imgCalendarEndTime" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                        </cc2:CalendarExtender>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="查询"
                                            Style="margin: 0" CssClass="dele" />
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
                                <asp:LinkButton ID="ButtonAdd" runat="server" CausesValidation="False" OnClick="ButtonAdd_Click"
                                    CssClass="tianjia2 lmf_btn"><span>添加</span></asp:LinkButton>
                            </td>
                            <%--  <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonEdit" runat="server" CausesValidation="False" OnClick="ButtonEdit_Click"
                                    OnClientClick="return DeleteOneButton()" CssClass="bji lmf_btn"><span>编辑</span></asp:LinkButton>
                            </td>--%>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" if (Page_ClientValidate()) return DeleteButton();return false; "
                                    CausesValidation="False" CssClass="shanchu lmf_btn"><span>批量删除</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonSearchComment" runat="server" CausesValidation="False"
                                    OnClientClick=" if (Page_ClientValidate()) return EditButton();return false; "
                                    CssClass="chakanpl lmf_btn" OnClick="ButtonSearchComment_Click">
                                            <span>查看评论</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="false" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <cc1:num1gridview id="Num1GridViewShow" runat="server" autogeneratecolumns="False"
                allowpaging="True" allowsorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" addsequencecolumn="False" width="98%"
                del="False" deleteprompttext="确实要删除指定的记录吗？" edit="False" fixheader="False" gridviewsortdirection="Ascending"
                pagingstyle="None" tablename="" datasourceid="ObjectDataSourceData" allowmulticolumnsorting="False"
                backcolor="White" bordercolor="#DEDFDE" borderstyle="None" borderwidth="1px"
                cellpadding="4" gridlines="Vertical" style="margin-top: 15px;">
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                        <%--分页--%>
                        <PagerStyle CssClass="lmf_page" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                                </HeaderTemplate>
                                <HeaderStyle CssClass="select_width" />
                                <ItemTemplate>
                                    <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="视频标题" SortExpression="Title">
                                <ItemTemplate>
                                    <a href="<%# GetUrl(Eval("Guid")) %>" target="_blank">
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Title") %>'></asp:Label></a>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="视频分类" DataField="Name" SortExpression="Name" />
                            <asp:BoundField DataField="CreateTime" HeaderText="发布时间" SortExpression="CreateTime">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="发布者" DataField="CreateUser" SortExpression="CreateUser" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="播放次数" DataField="BroadcastCount" SortExpression="BroadcastCount" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="评论次数" DataField="CommentCount" SortExpression="CommentCount" ItemStyle-HorizontalAlign="Center" />
                            <asp:TemplateField HeaderText="推荐" SortExpression="Title">
                                <ItemTemplate>
                                    <%#IsRecommend(Eval("isrecommend").ToString()) %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <a href="<%# "Video_Operate.aspx?Guid='" + Eval("Guid") + "'" %>" style="color: #4482b4;">
                                        编辑</a>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </cc1:num1gridview>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="GetVideoAll"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_Video_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBoxTitle" Name="title" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="DropDownListCategoryID" Name="categoryCode" PropertyName="SelectedValue"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxPublisher" Name="publisher" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListIsRecommend" Name="IsRecommend" PropertyName="SelectedValue"
                    Type="Int32" />
                <asp:ControlParameter ControlID="TextBoxStartTime" Name="time1" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxEndTime" Name="time2" PropertyName="Text"
                    Type="String" />
                <asp:Parameter DefaultValue="0" Name="isDeleted" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
