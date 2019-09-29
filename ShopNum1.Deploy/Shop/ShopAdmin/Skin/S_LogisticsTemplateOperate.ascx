<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<%@ Register Src="../UserControl/TemplateArea.ascx" TagName="TemplateArea" TagPrefix="uc1" %>
<div id="list_main">
    <ul id="sidebar">
        <li class="TabbedPanelsTab TabbedPanelsTabSelected">运费模板</li>
    </ul>
    <div id="content">
        <div class="TabbedPanelsContentVisible" style="display: block;">
            <table width="100%" cellspacing="0" cellpadding="0" border="0" class="tabbiao">
                <tr>
                    <td align="right" style="width: 130px;">
                        模板名称：
                    </td>
                    <td>
                        <input type="text" onchange="CheckTemplateName()" class="textwb" maxlength="50" id="texttemplateName"
                            runat="server" />
                        <span id="spantemplateName" class="gray1">请输入模板名称</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        计价方式：
                    </td>
                    <td>
                        按商品件数计算邮费
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        运送方式：
                    </td>
                    <td>
                        除指定地区外，其余地区的运费采用"默认运费"
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td style="width: 700px">
                        <input type="checkbox" name="tplType" onclick="ExpressCheckBox(this)" value="-4"
                            id="checkboxExpress" class="J_Delivery" runat="server" />
                        快递
                    </td>
                </tr>
                <tr id="trExpress" style="display: none">
                    <td align="right">
                    </td>
                    <td>
                        <table width="95%" cellspacing="0" cellpadding="0" border="0" class="yunf">
                            <tr>
                                <td style="padding-left: 10px;" class="yunfbg" id="postExpress" colspan="6" runat="server">
                                    默认邮费：<input type="text" disabled="disabled" value="1" name="express_start_0" style="background: #EEE;
                                        border: 1px solid #7F9DB9; width: 72px;" />
                                    件内，<input type="text" name="express_postage_0" value="10" id="express_postage_0"
                                        style="background: #fff; border: 1px solid #7F9DB9; width: 72px;" runat="server" />
                                    元， 每增加
                                    <input type="text" value="1" name="express_plus_0" style="background: #EEE; border: 1px solid #7F9DB9;
                                        width: 72px;" />
                                    件， 增加邮费
                                    <input type="text" id="express_postageplus_0" name="express_postageplus_0" value="0"
                                        style="background: #fff; border: 1px solid #7F9DB9; width: 72px;" runat="server" />
                                    元
                                    <input id="hiddenExpressNum" value="1" type="hidden" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 10px;">
                                    <table width="95%" cellspacing="0" cellpadding="0" border="0" class="yunftab" id="ExpressRows">
                                        <tr>
                                            <th scope="col" style="width: 150px;">
                                                运送到
                                            </th>
                                            <th scope="col">
                                                首件(件)
                                            </th>
                                            <th scope="col">
                                                首费(元)
                                            </th>
                                            <th scope="col">
                                                续件(件)
                                            </th>
                                            <th scope="col">
                                                续费(元)
                                            </th>
                                            <th scope="col" width="10%">
                                                操作
                                            </th>
                                        </tr>
                                        <asp:Repeater ID="RepeaterExpress" runat="server">
                                            <ItemTemplate>
                                                <tr runat="server" id="trExpress">
                                                    <td style="text-align: center;">
                                                        <span>
                                                            <%# ((DataRowView) Container.DataItem).Row["groupregionnames"] %></span>
                                                        <input type="hidden" name="express_areas_<%#RepeaterExpress.Items.Count %>" value="<%# ((DataRowView) Container.DataItem).Row["groupregioncodes"] %>" />
                                                        <input type="hidden" name="express_areasnames_<%#RepeaterExpress.Items.Count %>"
                                                            value="<%# ((DataRowView) Container.DataItem).Row["groupregionnames"] %>" />
                                                        <a href="javascript:void(0)" onclick=" SetDivPosition(this, -200, 20, 'express') ">编辑</a>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <input type="text" disabled="disabled" value="1" name="express_start_<%#RepeaterExpress.Items.Count %>"
                                                            style="background: #EEE; border: 1px solid #7F9DB9; width: 72px;" />
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <input type="text" name="express_postagevalue_<%#RepeaterExpress.Items.Count %>"
                                                            value='<%# ((DataRowView) Container.DataItem).Row["fee"] %>' style="background: #fff;
                                                            border: 1px solid #7F9DB9; width: 72px;" />
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <input type="text" value="1" name="express_plus_<%#RepeaterExpress.Items.Count %>"
                                                            style="background: #EEE; border: 1px solid #7F9DB9; width: 72px;" />
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <input type="text" name="express_postageplusvalue_<%#RepeaterExpress.Items.Count %>"
                                                            value="<%# ((DataRowView) Container.DataItem).Row["oneadd"] %>" style="background: #fff;
                                                            border: 1px solid #7F9DB9; width: 72px;" />
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <a href="javascript:void(0)" onclick=" DeleteAddress(this) ">删除</a>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 10px;">
                                    <a href="javascript:void(0)" onclick=" AddAdress(this, 'express', 'ExpressRows') ">为指定地区城市设置邮费</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                    </td>
                    <td style="width: 700px">
                        <input id="checkboxEMS" runat="server" class="J_Delivery" type="checkbox" onclick="EmsCheckBox(this)"
                            name="checkboxEMS" />EMS
                    </td>
                </tr>
                <tr id="trEMS" style="display: none">
                    <td class="tab_r">
                    </td>
                    <td>
                        <table width="95%" cellspacing="0" cellpadding="0" border="0" class="yunf">
                            <tr>
                                <td style="padding-left: 10px;" class="yunfbg" id="postEms" colspan="6" runat="server">
                                    默认邮费：
                                    <input type="text" style="background: #EEE; border: 1px solid #7F9DB9; width: 72px;"
                                        name="ems_start_0" disabled="disabled" value="1">
                                    件内，
                                    <input id="ems_postage_0" runat="server" type="text" style="background: #fff; border: 1px solid #7F9DB9;
                                        width: 72px;" value="10" name="ems_postage_0" />
                                    元， 每增加
                                    <input type="text" style="background: #EEE; border: 1px solid #7F9DB9; width: 72px;"
                                        name="ems_plus_0" value="1">
                                    件， 增加邮费
                                    <input id="ems_postageplus_0" type="text" style="background: #fff; border: 1px solid #7F9DB9;
                                        width: 72px;" value="0" name="ems_postageplus_0" runat="server" />
                                    元
                                    <input id="hiddenemsNum" type="hidden" value="0" name="hiddenemsNum">
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 10px;">
                                    <table width="95%" cellspacing="0" cellpadding="0" border="0" class="yunftab" id="EmsRows">
                                        <tr>
                                            <th scope="col" style="width: 150px;">
                                                运送到
                                            </th>
                                            <th scope="col">
                                                首件(件)
                                            </th>
                                            <th scope="col">
                                                首费(元)
                                            </th>
                                            <th scope="col">
                                                续件(件)
                                            </th>
                                            <th scope="col">
                                                续费(元)
                                            </th>
                                            <th scope="col">
                                                操作
                                            </th>
                                        </tr>
                                        <asp:Repeater ID="RepeaterEMS" runat="server">
                                            <ItemTemplate>
                                                <tr runat="server" id="trEMS">
                                                    <td style="text-align: center;">
                                                        <span>
                                                            <%# ((DataRowView) Container.DataItem).Row["groupregionnames"] %>
                                                        </span>
                                                        <input type="hidden" name="ems_areas_<%#RepeaterEMS.Items.Count %>" value="<%# ((DataRowView) Container.DataItem).Row["groupregioncodes"] %>" />
                                                        <input type="hidden" name="ems_areasnames_<%#RepeaterEMS.Items.Count %>" value="<%# ((DataRowView) Container.DataItem).Row["groupregionnames"] %>" />
                                                        <a href="javascript:void(0)" onclick=" SetDivPosition(this, -200, 20, 'ems') ">编辑</a>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <input disabled="disabled" value="1" type="text" name="ems_start_<%#RepeaterEMS.Items.Count %>"
                                                            style="background: #EEE; border: 1px solid #7F9DB9; width: 72px;" />
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <input type="text" name="ems_postagevalue_<%#RepeaterEMS.Items.Count %>" value='<%# ((DataRowView) Container.DataItem).Row["fee"] %>'
                                                            style="background: #fff; border: 1px solid #7F9DB9; width: 72px;" />
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <input value="1" type="text" name="ems_plus_<%#RepeaterEMS.Items.Count %>" style="background: #EEE;
                                                            border: 1px solid #7F9DB9; width: 72px;" />
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <input type="text" name="ems_postageplusvalue_<%#RepeaterEMS.Items.Count %>" value="<%# ((DataRowView) Container.DataItem).Row["oneadd"] %>"
                                                            style="background: #fff; border: 1px solid #7F9DB9; width: 72px;" />
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <a href="javascript:void(0)" onclick=" DeleteAddress(this) ">删除</a>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 10px;">
                                    <a href="javascript:void(0)" onclick=" AddAdress(this, 'ems', 'EmsRows') ">为指定地区城市设置邮费</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                    </td>
                    <td style="width: 700px">
                        <input id="checkboxPost" runat="server" class="J_Delivery" type="checkbox" onclick="PostCheckBox(this)"
                            name="checkboxPost" />平邮
                    </td>
                </tr>
                <tr id="trPost" style="display: none">
                    <td class="tab_r">
                    </td>
                    <td>
                        <table width="95%" cellspacing="0" cellpadding="0" border="0" class="yunf">
                            <tr>
                                <td style="padding-left: 10px;" class="yunfbg" id="postPost" colspan="6" runat="server">
                                    默认邮费：
                                    <input type="text" style="background: #EEE; border: 1px solid #7F9DB9; width: 72px;"
                                        name="post_start_0" disabled="disabled" value="1">
                                    件内，
                                    <input id="post_postage_0" runat="server" type="text" style="background: #fff; border: 1px solid #7F9DB9;
                                        width: 72px;" value="10" name="post_postage_0">
                                    元， 每增加
                                    <input type="text" style="background: #EEE; border: 1px solid #7F9DB9; width: 72px;"
                                        name="post_plus_0" value="1">
                                    件， 增加邮费
                                    <input id="post_postageplus_0" runat="server" type="text" style="background: #fff;
                                        border: 1px solid #7F9DB9; width: 72px;" value="0" name="post_postageplus_0">
                                    元
                                    <input id="hiddenpostNum" type="hidden" value="0" name="hiddenpostNum">
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 10px;">
                                    <table width="95%" cellspacing="0" cellpadding="0" border="0" class="yunftab" id="PostRows">
                                        <tr>
                                            <th scope="col" style="width: 150px;">
                                                运送到
                                            </th>
                                            <th scope="col">
                                                首件(件)
                                            </th>
                                            <th scope="col">
                                                首费(元)
                                            </th>
                                            <th scope="col">
                                                续件(件)
                                            </th>
                                            <th scope="col">
                                                续费(元)
                                            </th>
                                            <th scope="col">
                                                操作
                                            </th>
                                        </tr>
                                        <asp:Repeater ID="RepeaterPost" runat="server">
                                            <ItemTemplate>
                                                <tr runat="server" id="trPost">
                                                    <td style="width: 293px;">
                                                        <span>
                                                            <%# ((DataRowView) Container.DataItem).Row["groupregionnames"] %>
                                                        </span>
                                                        <input type="hidden" name="post_areas_<%#RepeaterPost.Items.Count %>" value="<%# ((DataRowView) Container.DataItem).Row["groupregioncodes"] %>" />
                                                        <input type="hidden" name="post_areasnames_<%#RepeaterPost.Items.Count %>" value="<%# ((DataRowView) Container.DataItem).Row["groupregionnames"] %>" />
                                                        <a href="javascript:void(0)" onclick=" SetDivPosition(this, -200, 20, 'post') ">编辑</a>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <input disabled="disabled" value="1" type="text" name="post_start_<%#RepeaterPost.Items.Count %>"
                                                            style="background: #EEE; border: 1px solid #7F9DB9; width: 72px;" />
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <input type="text" name="post_postagevalue_<%#RepeaterPost.Items.Count %>" value='<%# ((DataRowView) Container.DataItem).Row["fee"] %>'
                                                            style="background: #fff; border: 1px solid #7F9DB9; width: 72px;" />
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <input value="1" type="text" name="post_plus_<%#RepeaterPost.Items.Count %>" style="background: #EEE;
                                                            border: 1px solid #7F9DB9; width: 72px;" />
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <input type="text" name="post_postageplusvalue_<%#RepeaterPost.Items.Count %>" value="<%# ((DataRowView) Container.DataItem).Row["oneadd"] %>"
                                                            style="background: #fff; border: 1px solid #7F9DB9; width: 72px;" />
                                                    </td>
                                                    <td style="text-align: center; width: 40px;">
                                                        <a href="javascript:void(0)" onclick=" DeleteAddress(this) ">删除</a>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 10px;">
                                    <a href="javascript:void(0)" onclick=" AddAdress(this, 'post', 'PostRows') ">为指定地区城市设置邮费</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td style="padding-top: 15px;">
                        <script type="text/javascript" language="javascript">
                //<![CDATA[
                            var theForm = document.forms['form1'];
                            if (!theForm) {
                                theForm = document.form1;
                            }

                            function __PostBack(eventTarget) {
                                if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
                                    theForm._btnAction.value = eventTarget;
                                    if (SumbitCheck()) {
                                        theForm.submit();
                                    }
                                }
                            }
//]]>
                        </script>
                        <input type="hidden" id="hidExpress" runat="server" value="0" />
                        <input type="hidden" id="hidEms" runat="server" value="0" />
                        <input type="hidden" id="hidPost" runat="server" value="0" />
                        <asp:Button ID="btnSub" runat="server" Text="保存" class="baocbtn" OnClientClick=" return SumbitCheck(); " />
                        <span id="spanmsg" class="red hideme"></span>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div>
        <input value="" id="_btnAction" name="btnAction" type="hidden" />
    </div>
    <!--后台调用邮费模板-->
    <div id="feeTemplateDiv" runat="server" visible="false">
        默认邮费：<input type="text" value="1" disabled="disabled" name="S_LogisticsTemplateOperate_ctl00_{delivery}_start_0"
            style="background: #EEE; border: 1px solid #7F9DB9; width: 72px;" />
        件内，<input type="text" name="S_LogisticsTemplateOperate_ctl00_{delivery}_postage_0"
            id="S_LogisticsTemplateOperate_ctl00_{delivery}_postage_0" value="{value}" style="background: #fff;
            border: 1px solid #7F9DB9; width: 72px;" />
        元， 每增加
        <input type="text" value="1" name="S_LogisticsTemplateOperate_ctl00_{delivery}_plus_0"
            style="background: #EEE; border: 1px solid #7F9DB9; width: 72px;" />
        件， 增加邮费
        <input type="text" name="S_LogisticsTemplateOperate_ctl00_{delivery}_postageplus_0"
            id="S_LogisticsTemplateOperate_ctl00_{delivery}_postageplus_0" value="{plusvalue}"
            style="background: #fff; border: 1px solid #7F9DB9; width: 72px;" />
        元
        <input id="hidden{delivery}Num" name="S_LogisticsTemplateOperate_ctl00_hidden{delivery}Num"
            value="{postnumvalue}" type="hidden" />
    </div>
    <uc1:TemplateArea ID="TemplateArea1" runat="server" />
    <script id="fee_templateTr" type="text/template">
            <tr>
                <td  style="text-align: center;">
                        <span>未添加地区 </span>
                        <input type="hidden" name="{delivery}_areas_{num}" value="0" />
                        <input type="hidden" name="{delivery}_areasnames_{num}" value="0" />
                        <a href="javascript:void(0)" onclick="SetDivPosition(this,-200,20,'{TagName}')">编辑</a>
                </td>
                <td style="text-align: center;">
                    <input type="text" disabled="disabled" value="1" name="{delivery}_start_{num}" style="background: #EEE; width: 72px; border: 1px solid  #7F9DB9;" />
                </td>
                <td style="text-align: center;">
                    <input type="text" name="{delivery}_postagevalue_{num}" style="background: #fff; width: 72px;border: 1px solid  #7F9DB9;" value="10" />
                </td>
                <td style="text-align: center;">
                    <input type="text"  value="1" name="{delivery}_plus_{num}" style="background: #EEE; width: 72px; border: 1px solid  #7F9DB9;" />
                </td>
                <td style="text-align: center;">
                    <input type="text" name="{delivery}_postageplusvalue_{num}" style="background: #fff; width: 72px;border: 1px solid  #7F9DB9;" value="0" />
                </td>
                <td style="text-align: center;">
                    <a href="javascript:void(0)" onclick="DeleteAddress(this)">删除</a>
                </td>
             </tr>             
    </script>
    <script id="fee_template" type="text/template">
          <table cellpadding="0" cellspacing="0" width="100%" style="text-align: center; margin-top: 10px;">
                                <tr>
                                    <td colspan="6">
                                        默认邮费：<input type="text" disabled="disabled" value="1"  name="{delivery}_start_0" style="background: #EEE; width: 72px; border: 1px solid  #7F9DB9;" />
                                        件内，<input type="text" id="{delivery}_postage_0" name="{delivery}_postage_0" value="10" style="background: #fff; width: 72px; border: 1px solid  #7F9DB9;" />
                                        元， 每增加
                                        <input type="text" disabled="disabled" value="1" name="{delivery}_plus_0" style="background: #EEE; width: 72px; border: 1px solid  #7F9DB9;" />
                                        件， 增加邮费
                                        <input type="text" id="{delivery}_postageplus_0" value="0" name="{delivery}_postageplus_0" style="background: #fff; width: 72px; border: 1px solid  #7F9DB9;" />
                                        元
                                        <input id="hidden{delivery}Num" name="hidden{delivery}Num" value="1" type="hidden" />
                                    </td>
                                </tr>
                                <tr class="MemberTr" style="line-height: 30px;">
                                    <td style="width: 293px; text-align: center;">
                                        运送到
                                    </td>
                                    <td style="text-align: center;">
                                        首件(件)
                                    </td>
                                    <td style="text-align: center;">
                                        首费(元)
                                    </td>
                                    <td style="text-align: center;">
                                        续件(件)
                                    </td>
                                    <td style="text-align: center;">
                                        续费(元)
                                    </td>
                                    <td style="text-align: center;">
                                        操作
                                    </td>
                                </tr>
                                <tr>
                            <td colspan="6">
                                <a href="javascript:void(0)" onclick="AddAdress(this,'{delivery}')">为指定地区城市设置邮费</a>
                            </td>
                        </tr>
                        </table>
    </script>
</div>
<script type="text/javascript" language="javascript">
    $(function () {
        if ($("#S_LogisticsTemplateOperate_ctl00_checkboxExpress").is(":checked")) {
            $("#trExpress").show();
        }
        if ($("#S_LogisticsTemplateOperate_ctl00_checkboxEMS").is(":checked")) {
            $("#trEMS").show();
        }
        if ($("#S_LogisticsTemplateOperate_ctl00_checkboxPost").is(":checked")) {
            $("#trPost").show();
        }

        $("input[value='000']").each(function () {
            $(this).parent().parent().hide();
        });
    });
</script>
