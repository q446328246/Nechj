<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<% DataTable dt_fee = S_FeeTemplate_Select.dt_FeeTemplate; %>
<script type="text/javascript">
    $(document).ready(function () {
        $(".content table tr td input").each(function (i) {
            $(this).click(function () {
                var tds = $(this).parent().siblings();
                var aa = $.trim(tds[0].innerHTML) + "," + $.trim(tds[1].innerHTML);
                window.returnValue = $.trim(tds[0].innerHTML) + "," + $.trim(tds[1].innerHTML);
                window.close();
            });
        });
    });
</script>
<div class="main">
    <div class="table1" style="margin: 30px; width: 740px;">
        <div class="title" style="border: none; color: #D2691E; font-size: 15px; font-weight: bold;
            padding-bottom: 3px;">
            【店铺邮费模板】</div>
        <div class="content">
            <table width="100%" cellspacing="0" cellpadding="0" border="0" style="margin-bottom: 10px;
                padding-top: 0px;" class="blue_tbw1">
                <tr>
                    <th id="dd" class="th_le">
                        模板ID
                    </th>
                    <th>
                        模板名称
                    </th>
                    <th>
                        模板创建时间
                    </th>
                    <th class="th_ri">
                        操作
                    </th>
                </tr>
                <% if (dt_fee != null)
                   {
                       for (int i = 0; i < dt_fee.Rows.Count; i++)
                       { %>
                <tr>
                    <td align="center" class="th_le1">
                        <%= dt_fee.Rows[i]["templateid"] %>
                    </td>
                    <td align="center">
                        <%= dt_fee.Rows[i]["templatename"] %>
                    </td>
                    <td align="center">
                        <%= dt_fee.Rows[i]["createtime"] %>
                    </td>
                    <td align="center" class="th_ri1">
                        <input type="button" value="应用" class="chax" />
                    </td>
                </tr>
                <% }
                   } %>
            </table>
        </div>
    </div>
</div>
