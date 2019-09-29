<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="ordmain1" id="content">
    <div class="pad" style="display: none;">
        <table border="0" cellspacing="0" cellpadding="0" class="lineh" style="display: none">
            <tr class="up_spac">
                <td align="right">
                    页面名：
                </td>
                <td>
                    <input id="txt_FileName" type="text" runat="server" class="ss_nr1" />
                </td>
                <td align="right" class="ss_nr_spac">
                    文件名：
                </td>
                <td>
                    <select name="sel" class="tselect" id="sel_File" runat="server">
                    </select>
                </td>
                <td>
                    <asp:Button ID="ButtonSearch" runat="server" Text="查询" CssClass="chax btn_spc" />
                </td>
            </tr>
        </table>
    </div>
    <div class="biaogenr">
        <table cellspacing="0" cellpadding="0" border="0" class="blue_tb2" width="100%">
            <tr>
                <th style="display: none">
                    广告ID
                </th>
                <th class="th_le">
                    幻灯片
                </th>
                <th>
                    Title
                </th>
                <th>
                    页面跳转地址
                </th>
                <th class="th_ri">
                    操作
                </th>
            </tr>
            <asp:Repeater ID="rep_AddvertismentList" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="display: none; text-align: center;">
                            <%# DataBinder.Eval(Container.DataItem, "divid") %>
                        </td>
                        <td style="text-align: center">
                            <%# DataBinder.Eval(Container.DataItem, "pagename") %>
                        </td>
                        <td style="text-align: center">
                            <%# DataBinder.Eval(Container.DataItem, "explain") %>
                        </td>
                        <td style="text-align: center">
                            <%# DataBinder.Eval(Container.DataItem, "href") %>
                        </td>
                        <td style="line-height: 150%;" valign="middle">
                            <a href='S_AdvertisementOperate.aspx?guid=<%# DataBinder.Eval(Container.DataItem, "Guid") %>'
                                class="alink_blue">编辑</a>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</div>
<input id="hid_Seletfile" type="hidden" runat="server" value="" />
<input id="hid_SeletfileValue" type="hidden" runat="server" value="-1" />
<script type="text/javascript" language="javascript">
    //将选择的银行，赋给 放银行信息的隐藏控件
    $(document).ready(
        $("#S_AdvertisementList_ctl00_sel_File").change(
            function () {
                var fileText = $("#S_AdvertisementList_ctl00_sel_File").find("option:selected").text();
                var fileValue = $("#S_AdvertisementList_ctl00_sel_File").find("option:selected").text();
                $("#S_AdvertisementList_ctl00_hid_Seletfile").val(fileText);
                $("#S_AdvertisementList_ctl00_hid_SeletfileValue").val(fileValue);

            }
        )
    )
</script>
