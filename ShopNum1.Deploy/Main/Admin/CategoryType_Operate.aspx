<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CategoryType_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.CategoryType_Operate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�����Ʒ����</title>
    <script type="text/javascript" language="javascript" src="js/jquery-1.9.1.js"> </script>
    <link href="css/css.css" rel="stylesheet" type="text/css" id="cssfile2" />
    <style type="text/css">
            .page {
                padding: 9px 20px 20px;
                text-align: left;
            }

            .fixed-bar {
                left: 0;
                margin-left: 20px;
                padding: 8px 20px 8px 0;
                position: fixed;
                top: 0;
                width: 99%;
                z-index: 99;
            }

            * html .fixedbar {
                left: -20px;
                margin-top: -10px;
                position: relative;
                width: 100%;
            }

            .fixed-empty { height: 50px !important; }

            .item-title {
                clear: both;
                line-height: 20px;
                margin-bottom: 0 !important;
                overflow: hidden;
                _padding-bottom: 10px;



            

            +padding-bottom: 10px;} 

            .item-title h3 {
                float: left;
                margin-right: 20px;
            }

            .tab-base {
                float: left;
                overflow: hidden;
                padding-top: 16px;
            }

            .tab-base li { float: left; }

            .tab-base a {
                cursor: pointer;
                float: left;
                font-weight: 700;
                height: 20px;
                line-height: 20px;
                margin-right: 2px;
                padding-left: 9px;
            }

            .tab-base a:hover {
                background-position: 0 -220px;
                color: #09C;
            }

            .tab-base a span {
                color: #555;
                float: left;
                padding-right: 9px;
            }

            .tab-base a:hover span { background-position: 100% -220px; }

            .tab-base a.current, .tab-base a:hover.current {
                background-position: 0 -240px;
                cursor: default;
            }

            .tab-base a.current span, .tab-base a:hover.current span {
                background-position: 100% -240px;
                color: #FFF;
            }
/* table
------------------------------------------------------------------- */

            .table {
                clear: both;
                margin-top: 8px;
                width: 100%;
            }

            .table th, .table td {
                height: 26px;
                padding: 6px !important;
            }

            .space th {
                background-color: #F3FBFE;
                font-weight: 600;
            }

            .nohover td { background: #FFF !important; }

            .ckbox { width: 700px; }

            .ckbox li {
                float: left;
                height: 20px;
                margin: 5px 10px 5px 0;
                white-space: nowrap;
                width: 130px;
            }

            .partition, .partition2 {
                color: #09C;
                font-weight: 700;
                line-height: 21px;
            }

            .tb-type2 th {
                color: #333;
                line-height: 21px;
                padding: 5px 5px 3px 0;
            }

            .tb-type2 td { padding: 5px 5px 3px 0; }

            .tb-type2 td input[type="text"], .tb-type1 td select {
                margin-left: 4px;
                margin-right: 4px;
                _margin-left: 2px;
                _margin-right: 2px;
            }

            .tb-type2 td select { width: auto; }

            .tb-type2 .txt-short { width: 80px; }

            .tb-type2 .txt {
                height: 20px;
                line-height: 20px;
                width: 140px;
            }

            a.btn {
                color: #555;
                cursor: pointer;
                display: inline-block;
                font-size: 14px;
                font-weight: 700;
                height: 38px;
                line-height: 18px;
                margin-right: 6px;
                padding-left: 15px;
            }

            a.btn:hover { background-position: 0 -318px; }

            a.btn:active { background-position: 0 -356px; }

            a.btn span {
                display: inline-block;
                height: 18px;
                padding: 10px 15px 10px 0;
            }

            a:hover.btn span {
                background-position: 100% -318px;
                color: #1AA3D1;
            }

            a:active.btn span {
                background-position: 100% -356px;
                color: #63C7ED;
            }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="lblSpec" runat="server" Text="�����Ʒ����"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            ������ʾ��
                        </th>
                        <td valign="middle" colspan="2">
                            <ul>
                                <li>��������Ǳ�ѡ�����Ӱ����Ʒ����ʱ�Ĺ�񼰼۸��¼�롣��ѡΪû�й��</li>
                                <li>����Ʒ�Ʋ��Ǳ�ѡ�����Ӱ����Ʒ����ʱ��Ʒ��ѡ��</li>
                                <li>����ֵ������Ӷ����ÿ������ֵ֮����Ҫʹ�ö��Ÿ�����</li>
                                <li>ѡ�����Եġ���ʾ��ѡ������Խ�������Ʒ�б�ҳ��ʾ��</li>
                            </ul>
                            <input type="hidden" value="ok" name="form_submit">
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <font color="red">*</font>
                            <label class="validation">
                                �������ƣ�</label>
                        </th>
                        <td align="left" colspan="2">
                            <input type="text" runat="server" class="tinput" name="t_mane" id="txtTypeName" maxlength="50" /><span
                                class="tipmsg"></span>
                        </td>
                    </tr>
                    <tr class="radiobtn">
                        <th align="right">
                            <font color="red">*</font>
                            <label class="validation">
                                ����</label>
                        </th>
                        <td align="left">
                            <input type="text" runat="server" class="tinput" onkeyup="NumTxt_Int(this)" onafterpaste="NumTxt_Int(this)"
                                name="t_sort" id="txtSortId" value="0" />
                            <span class="tipmsg">����д��Ȼ���������б���������������С����������ʾ��</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <label class="validation">
                                ������</label>
                        </th>
                        <td colspan="2">
                            <textarea id="txtDesc" runat="server" class="tinput txtarea" style="height: 100px;
                                width: 350px;"></textarea>
                            <span class="tipmsg">������д����Ʒ���ͷ���������Ϣ��</span>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            <label class="validation">
                                �Ƿ���ʾ��</label>
                        </th>
                        <td>
                            <asp:CheckBox ID="IsShow" runat="server" />
                            �Ƿ���ʾ��ǰ̨ <span class="tipmsg">�Ƿ���ʾ����ѡ���ʾ��ʾ��</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <label>
                                ѡ��������</label>
                        </th>
                        <td>
                            <table class="table tb-type2" cellpadding="0" cellspacing="0">
                                <thead class="thead">
                                    <tr>
                                        <td style="background: #f3f3f3;">
                                            <input class="checkitem" type="checkbox" style="display: none;" />
                                        </td>
                                        <td style="background: #f3f3f3;">
                                            �������
                                        </td>
                                        <td style="background: #f3f3f3;">
                                            ���ֵ
                                        </td>
                                    </tr>
                                </thead>
                                <tbody>
                                    <% if (dt_Spec != null)
                                       {
                                           for (int i = 0; i < dt_Spec.Rows.Count; i++)
                                           {
                                               if (dt_Spec.Rows[i]["detailSpec"].ToString() != "")
                                               { %>
                                    <tr class="hover edit">
                                        <td class="w24">
                                            <input class="checkitem" type="checkbox" value='<%= dt_Spec.Rows[i]["id"] %>' name="spec_id[check]"
                                                <%= dt_Spec.Rows[i]["ischeck"].ToString() == "" || dt_Spec.Rows[i]["ischeck"].ToString() == "0" ? "" : "checked='true'" %>>
                                        </td>
                                        <td class="w18pre">
                                            <%= dt_Spec.Rows[i]["SpecName"] %>
                                        </td>
                                        <td>
                                            <%= dt_Spec.Rows[i]["detailSpec"] %>
                                        </td>
                                    </tr>
                                    <% }
                                           }
                                       } %>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <label for="member_name">
                                ѡ�����Ʒ�ƣ�</label>
                        </th>
                        <td>
                            <table class="table tb-type2" cellpadding="0" cellspacing="0">
                                <thead class="thead">
                                    <tr class="space">
                                        <td colspan="2" style="background: #f3f3f3;">
                                            <h6 class="clear">
                                                Ʒ��</h6>
                                        </td>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr class="hover">
                                        <td>
                                            <ul class="nofloat">
                                                <% if (dt_Brand != null)
                                                   {
                                                       for (int i = 0; i < dt_Brand.Rows.Count; i++)
                                                       { %>
                                                <% if ((i % 10 == 1 || i == 0) && i != 1)
                                                   { %>
                                                <li class="left w25pre h36" style="width: 800px;">
                                                    <% } %>
                                                    <input type="checkbox" <%= dt_Brand.Rows[i]["ischeck"].ToString() == "" ? "" : "checked='true'" %>
                                                        name="brand_id[check]" value='<%= dt_Brand.Rows[i]["guid"] %>' id='brand_<%= dt_Brand.Rows[i]["guid"] %>' />
                                                    <label for='brand_<%= dt_Brand.Rows[i]["guid"] %>'>
                                                        <%= dt_Brand.Rows[i]["name"] %></label>
                                                    <% if ((i % 10 == 0 || i == dt_Brand.Rows.Count) && i != 0 || dt_Brand.Rows.Count == 1)
                                                       { %>
                                                </li>
                                                <% }
                                                       }
                                                   } %>
                                            </ul>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <label for="member_name">
                                ѡ��������ԣ�</label>
                        </th>
                        <td>
                            <table class="table tb-type2" cellpadding="0" cellspacing="0">
                                <thead class="thead">
                                    <tr>
                                        <td style="background: #f3f3f3;">
                                            <input class="checkitem" type="checkbox" style="display: none;" />
                                        </td>
                                        <td style="background: #f3f3f3;">
                                            ��������
                                        </td>
                                        <td style="background: #f3f3f3;">
                                            ���Կ�ѡֵ
                                        </td>
                                    </tr>
                                </thead>
                                <tbody>
                                    <% if (dt_Prop != null)
                                       {
                                           for (int i = 0; i < dt_Prop.Rows.Count; i++)
                                           { %>
                                    <tr class="hover edit">
                                        <td class="w24">
                                            <input type="checkbox" class="checkitem" name="Prop_id[check]" value='<%= dt_Prop.Rows[i]["id"] %>'
                                                <%= dt_Prop.Rows[i]["ischeck"].ToString() == "" || dt_Prop.Rows[i]["ischeck"].ToString() == "0" ? "" : "checked='true'" %> />
                                        </td>
                                        <td class="w18pre">
                                            <%= dt_Prop.Rows[i]["propname"] %>
                                        </td>
                                        <td>
                                            <%= dt_Prop.Rows[i]["propDetail"] %>
                                        </td>
                                    </tr>
                                    <% }
                                       } %>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <input type="hidden" id="hidSpec" runat="server" />
                <input type="hidden" id="hidBrand" runat="server" />
                <input type="hidden" id="hidProp" runat="server" />
                <asp:Button ID="butSub" runat="server" CssClass="fanh" OnClick="butSub_Click" OnClientClick=" return checkType(); "
                    Text="�ύ" />
                <a id="submitBtn" class="btn" href="JavaScript:void(0);" style="display: none"><span>
                    �ύ</span> </a><span id="spanHtml" runat="server" style="color: Red"></span>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">
        function NumTxt_Int(o) {
            o.value = o.value.replace(/\D/g, '');
        }

        function checkType() {
            var bflag = true;
            $("input[name='spec_id[check]']").each(function () {
                if ($(this).is(":checked")) {
                    bflag = false;
                }
            });
            $("input[name='brand_id[check]']").each(function () {
                if ($(this).is(":checked")) {
                    bflag = false;
                }
            });
            $("input[name='Prop_id[check]']").each(function () {
                if ($(this).is(":checked")) {
                    bflag = false;
                }
            });
            if (bflag) {
                alert("�������Ʒ������Ҫ��ѡһ��!");
                return false;
            }
            var specId = new Array();
            var maxcount = 0;
            $("input[name='spec_id[check]']").each(function () {
                if ($(this).is(":checked")) {
                    specId.push("J" + $(this).val());
                    maxcount++;
                }
            });
            if (maxcount > 3) {
                alert("ÿ����Ʒ������๴ѡ����������ݣ�");
                return false;
            }
            var propId = new Array();
            $("input[name='Prop_id[check]']").each(function () {
                if ($(this).is(":checked")) {
                    propId.push($(this).val());
                }
            });

            var brandId = new Array();
            $("input[name='brand_id[check]']").each(function () {
                if ($(this).is(":checked")) {
                    brandId.push($(this).val());
                }
            });
            $("#hidSpec").val(specId.join(","));
            $("#hidProp").val(propId.join(","));
            $("#hidBrand").val(brandId.join(","));
            var typename = $("#txtTypeName");
            var sortvalue = $("#txtSortId");
            var desc = $("#txtDesc").val();
            $(".tipmsg").hide();
            var bflag = false;
            if (typename.val() == "") {
                typename.focus();
                typename.next().show().html("�������Ʋ���Ϊ�գ�");
                bflag = true;
            }
            if (sortvalue.val() == "") {
                sortvalue.focus();
                sortvalue.next().show().html("�����Ų���Ϊ�գ�");
                bflag = true;
            }
            if (bflag) {
                return false;
            }
            return true;
        }
    </script>
    </form>
</body>
</html>
