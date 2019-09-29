<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="OrderPrint_One.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.OrderPrint_One" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>打印订单第一步</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    订单批量打印第一步
                </h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div style="color: Red" class="order_edit">
                在这里选择您要打印快递单的订单，然后进行下一步操作。
                <div class="sbtn">
                    <table cellspacing="0" cellpadding="0" border="0">
                        <tbody>
                            <tr>
                                <td valign="top">
                                    <a href="javascript:__doPostBack('ButtonGoTo','')" class="shanchu lmf_btn" id="ButtonGoTo"
                                        onclick=" return PrintButton1(); "><span>下一步</span></a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div>
                <table cellspacing="0" cellpadding="4" border="1" style="background-color: White;
                    border-collapse: collapse; border-color: #DEDFDE; border-style: None; border-width: 1px;
                    margin-top: 15px; width: 98%;" id="Num1GridViewShow" descendingimageurl="~/images/SortDesc.gif"
                    ascendingimageurl="~/images/SortAsc.gif" rules="cols" class="gridview_m">
                    <tbody>
                        <tr align="center" style="background-color: #6699CC; color: White; font-weight: bold;"
                            class="list_header">
                            <th scope="col" class="select_width">
                                <input type="checkbox" onclick=" javascript: SelectAllCheckboxes(this); " id="checkboxAll">
                            </th>
                            <th scope="col" class="hidden">
                                Guid
                            </th>
                            <th scope="col">
                                <a style="color: White;">订单号</a>
                            </th>
                            <th scope="col">
                                <a style="color: White;">收货人</a>
                            </th>
                            <th scope="col">
                                <a style="color: White;">地区</a>
                            </th>
                            <th scope="col">
                                <a style="color: White;">详细地址</a>
                            </th>
                            <th scope="col">
                                <a style="color: White;">订单配送方式</a>
                            </th>
                        </tr>
                        <%
                        %>
                        <tr style="cursor: default;" onmouseout=" Num1GridViewShow_mout(this) " onmouseover=" Num1GridViewShow_mover(this) ">
                            <td align="center" style="width: 30px;">
                                <input type="checkbox" checked="checked" value="7b6a866b-ab43-4ca8-9065-2c781723f5ab"
                                    id="checkboxItem">
                            </td>
                            <td align="center" class="hidden" style="">
                                7b6a866b-ab43-4ca8-9065-2c781723f5ab
                            </td>
                            <td align="center" style="">
                                <span id="Num1GridViewShow_ctl02_LabelOrderNumber">201305112728210</span>
                            </td>
                            <td align="center" style="">
                                22
                            </td>
                            <td align="center" style="">
                                <span id="Num1GridViewShow_ctl02_LabelRegionCode">湖北省武汉市江夏区</span>
                            </td>
                            <td align="center" style="">
                                上海市上海辖区卢湾区22
                            </td>
                            <td align="center" style="">
                                中通快递
                            </td>
                        </tr>
                        <tr style="background-color: White; cursor: default;" onmouseout=" Num1GridViewShow_mout(this) "
                            onmouseover=" Num1GridViewShow_mover(this) ">
                            <td align="center" style="width: 30px;">
                                <input type="checkbox" checked="checked" value="092447e4-a439-4555-916e-6da9b087e8e7"
                                    id="checkboxItem">
                            </td>
                            <td align="center" class="hidden" style="">
                                092447e4-a439-4555-916e-6da9b087e8e7
                            </td>
                            <td align="center" style="">
                                <span id="Num1GridViewShow_ctl03_LabelOrderNumber">201306165021967</span>
                            </td>
                            <td align="center" style="">
                                linney
                            </td>
                            <td align="center" style="">
                                <span id="Num1GridViewShow_ctl03_LabelRegionCode">北京市北京辖区东城区</span>
                            </td>
                            <td align="center" style="">
                                北京市北京辖区东城区11100号
                            </td>
                            <td align="center" style="">
                                EMS
                            </td>
                        </tr>
                        <tr style="cursor: default;" onmouseout=" Num1GridViewShow_mout(this) " onmouseover=" Num1GridViewShow_mover(this) ">
                            <td align="center" style="width: 30px;">
                                <input type="checkbox" checked="checked" value="fe4732ce-de98-4f2a-b274-7c9ecf919c17"
                                    id="checkboxItem">
                            </td>
                            <td align="center" class="hidden" style="">
                                fe4732ce-de98-4f2a-b274-7c9ecf919c17
                            </td>
                            <td align="center" style="">
                                <span id="Num1GridViewShow_ctl04_LabelOrderNumber">201306031301978</span>
                            </td>
                            <td align="center" style="">
                                123123
                            </td>
                            <td align="center" style="">
                                <span id="Num1GridViewShow_ctl04_LabelRegionCode">辽宁省鞍山市台安县</span>
                            </td>
                            <td align="center" style="">
                                辽宁省鞍山市台安县12312312
                            </td>
                            <td align="center" style="">
                                EMS
                            </td>
                        </tr>
                        <tr style="background-color: White; cursor: default;" onmouseout=" Num1GridViewShow_mout(this) "
                            onmouseover=" Num1GridViewShow_mover(this) ">
                            <td align="center" style="width: 30px;">
                                <input type="checkbox" checked="checked" value="af4e2edb-6366-4dd6-b672-8ba5bdffba62"
                                    id="checkboxItem">
                            </td>
                            <td align="center" class="hidden" style="">
                                af4e2edb-6366-4dd6-b672-8ba5bdffba62
                            </td>
                            <td align="center" style="">
                                <span id="Num1GridViewShow_ctl05_LabelOrderNumber">201305223413404</span>
                            </td>
                            <td align="center" style="">
                                jerry
                            </td>
                            <td align="center" style="">
                                <span id="Num1GridViewShow_ctl05_LabelRegionCode">天津市天津辖区河东区</span>
                            </td>
                            <td align="center" style="">
                                天津市天津辖区河东区64544
                            </td>
                            <td align="center" style="">
                                中通快递
                            </td>
                        </tr>
                        <tr style="cursor: default;" onmouseout=" Num1GridViewShow_mout(this) " onmouseover=" Num1GridViewShow_mover(this) ">
                            <td align="center" style="width: 30px;">
                                <input type="checkbox" checked="checked" value="bc26f70f-b132-4bca-93ac-92d393bee678"
                                    id="checkboxItem">
                            </td>
                            <td align="center" class="hidden" style="">
                                bc26f70f-b132-4bca-93ac-92d393bee678
                            </td>
                            <td align="center" style="">
                                <span id="Num1GridViewShow_ctl06_LabelOrderNumber">201305112805788</span>
                            </td>
                            <td align="center" style="">
                                22
                            </td>
                            <td align="center" style="">
                                <span id="Num1GridViewShow_ctl06_LabelRegionCode">湖北省武汉市江夏区</span>
                            </td>
                            <td align="center" style="">
                                上海市上海辖区卢湾区22
                            </td>
                            <td align="center" style="">
                                中通快递
                            </td>
                        </tr>
                        <tr style="background-color: White; cursor: default;" onmouseout=" Num1GridViewShow_mout(this) "
                            onmouseover=" Num1GridViewShow_mover(this) ">
                            <td align="center" style="width: 30px;">
                                <input type="checkbox" checked="checked" value="cd87b3cf-b086-4a20-898f-9d3e4042a167"
                                    id="checkboxItem">
                            </td>
                            <td align="center" class="hidden" style="">
                                cd87b3cf-b086-4a20-898f-9d3e4042a167
                            </td>
                            <td align="center" style="">
                                <span id="Num1GridViewShow_ctl07_LabelOrderNumber">201305110935328</span>
                            </td>
                            <td align="center" style="">
                                22
                            </td>
                            <td align="center" style="">
                                <span id="Num1GridViewShow_ctl07_LabelRegionCode">上海市上海辖区卢湾区</span>
                            </td>
                            <td align="center" style="">
                                上海市上海辖区卢湾区22
                            </td>
                            <td align="center" style="">
                                顺达快递
                            </td>
                        </tr>
                        <tr style="cursor: default;" onmouseout=" Num1GridViewShow_mout(this) " onmouseover=" Num1GridViewShow_mover(this) ">
                            <td align="center" style="width: 30px;">
                                <input type="checkbox" checked="checked" value="8f04803b-15a5-4099-b5ef-b032a7429264"
                                    id="checkboxItem">
                            </td>
                            <td align="center" class="hidden" style="">
                                8f04803b-15a5-4099-b5ef-b032a7429264
                            </td>
                            <td align="center" style="">
                                <span id="Num1GridViewShow_ctl08_LabelOrderNumber">201306165257562</span>
                            </td>
                            <td align="center" style="">
                                linney
                            </td>
                            <td align="center" style="">
                                <span id="Num1GridViewShow_ctl08_LabelRegionCode">北京市北京辖区东城区</span>
                            </td>
                            <td align="center" style="">
                                北京市北京辖区东城区11100号
                            </td>
                            <td align="center" style="">
                                申通快递
                            </td>
                        </tr>
                        <tr style="background-color: White; cursor: default;" onmouseout=" Num1GridViewShow_mout(this) "
                            onmouseover=" Num1GridViewShow_mover(this) ">
                            <td align="center" style="width: 30px;">
                                <input type="checkbox" checked="checked" value="b253ea0f-648f-48c0-b905-b118b98b317f"
                                    id="checkboxItem">
                            </td>
                            <td align="center" class="hidden" style="">
                                b253ea0f-648f-48c0-b905-b118b98b317f
                            </td>
                            <td align="center" style="">
                                <span id="Num1GridViewShow_ctl09_LabelOrderNumber">201305111252235</span>
                            </td>
                            <td align="center" style="">
                                summer
                            </td>
                            <td align="center" style="">
                                <span id="Num1GridViewShow_ctl09_LabelRegionCode">湖北省武汉市江夏区</span>
                            </td>
                            <td align="center" style="">
                                湖北省武汉市江夏区东西湖高新区
                            </td>
                            <td align="center" style="">
                                中通快递
                            </td>
                        </tr>
                        <tr style="cursor: default;" onmouseout=" Num1GridViewShow_mout(this) " onmouseover=" Num1GridViewShow_mover(this) ">
                            <td align="center" style="width: 30px;">
                                <input type="checkbox" checked="checked" value="05904531-219a-422c-929c-caa4bb6effcb"
                                    id="checkboxItem">
                            </td>
                            <td align="center" class="hidden">
                                05904531-219a-422c-929c-caa4bb6effcb
                            </td>
                            <td align="center">
                                <span id="Num1GridViewShow_ctl10_LabelOrderNumber">201306164932873</span>
                            </td>
                            <td align="center">
                                linney
                            </td>
                            <td align="center">
                                <span id="Num1GridViewShow_ctl10_LabelRegionCode">北京市北京辖区东城区</span>
                            </td>
                            <td align="center">
                                北京市北京辖区东城区11100号
                            </td>
                            <td align="center">
                                EMS
                            </td>
                        </tr>
                        <tr style="background-color: White; cursor: default;" onmouseout=" Num1GridViewShow_mout(this) "
                            onmouseover=" Num1GridViewShow_mover(this) ">
                            <td align="center" style="width: 30px;">
                                <input type="checkbox" checked="checked" value="dba654fa-f268-487c-9758-e6c0f6e7855a"
                                    id="checkboxItem">
                            </td>
                            <td align="center" class="hidden">
                                dba654fa-f268-487c-9758-e6c0f6e7855a
                            </td>
                            <td align="center">
                                <span id="Num1GridViewShow_ctl11_LabelOrderNumber">201305225830517</span>
                            </td>
                            <td align="center">
                                jerry
                            </td>
                            <td align="center">
                                <span id="Num1GridViewShow_ctl11_LabelRegionCode">天津市天津辖区河东区</span>
                            </td>
                            <td align="center">
                                天津市天津辖区河东区64544
                            </td>
                            <td align="center">
                                EMS
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <input type="hidden" value="0" id="CheckGuid" name="CheckGuid">
        <input type="hidden" value="8f04803b-15a5-4099-b5ef-b032a7429264,092447e4-a439-4555-916e-6da9b087e8e7,05904531-219a-422c-929c-caa4bb6effcb,fe4732ce-de98-4f2a-b274-7c9ecf919c17,af4e2edb-6366-4dd6-b672-8ba5bdffba62,dba654fa-f268-487c-9758-e6c0f6e7855a,bc26f70f-b132-4bca-93ac-92d393bee678,7b6a866b-ab43-4ca8-9065-2c781723f5ab,b253ea0f-648f-48c0-b905-b118b98b317f,cd87b3cf-b086-4a20-898f-9d3e4042a167"
            id="HiddenFieldGuid" name="HiddenFieldGuid">
    </div>
    </form>
</body>
</html>
