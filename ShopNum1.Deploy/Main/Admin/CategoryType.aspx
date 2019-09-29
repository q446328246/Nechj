<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CategoryType.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.CategoryType" %>

<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��Ʒ���͹���</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type="text/javascript" language="javascript" src="js/jquery-1.3.2.min.js"> </script>
    <script language="Javascript" type="text/javascript">        var oldcolor;

        function Num1GridViewShow_mout(rowEl) {
            for (var i = 0; i < rowEl.cells.length; i++) {
                rowEl.cells[i].style.backgroundColor = oldcolor;
            }
        }

        function Num1GridViewShow_mover(rowEl) {
            for (var i = 0; i < rowEl.cells.length; i++) {
                oldcolor = rowEl.cells[i].style.backgroundColor;
                rowEl.cells[i].style.backgroundColor = "#ebeef5";
            }
        }

        function opDelete() {
            location.href = "?subdel=" + $("#CheckGuid").val();
        } </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    ��Ʒ���͹���</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellspacing="0" cellpadding="0" border="0">
                    <tbody>
                    </tbody>
                </table>
                <div class="sbtn">
                    <table cellspacing="0" cellpadding="0" border="0">
                        <tbody>
                            <tr>
                                <td>
                                    <a id="Del" class="shanchu lmf_btn" onclick=" delete_list_select() "><span>����ɾ��</span>
                                    </a>
                                </td>
                                <td valign="top" class="lmf_app">
                                    <a id="ButtonAdd" class="tianjia2 lmf_btn" href="CategoryType_Operate.aspx"><span>���</span>
                                    </a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div>
                <table cellspacing="0" cellpadding="4" border="0" id="Num1GridViewShow" rules="cols"
                    class="gridview_m">
                    <tr align="center" style="color: White;" class="list_header">
                        <th scope="col" class="select_width">
                            <input type="checkbox" onclick=" javascript:SelectAllCheckboxesNew(this); " id="checkboxAll">
                        </th>
                        <th scope="col" style="width: 30px;">
                            ����
                        </th>
                        <th scope="col">
                            ��������
                        </th>
                        <th scope="col">
                            ����
                        </th>
                    </tr>
                    <% if (dt_CategoryType != null && dt_CategoryType.Rows.Count > 0)
                       {
                           for (int i = 0; i < dt_CategoryType.Rows.Count; i++)
                           { %>
                    <tr class="hover edit" style="cursor: default;" onmouseout=" Num1GridViewShow_mout(this) "
                        onmouseover=" Num1GridViewShow_mover(this) ">
                        <td align="center">
                            <input type="checkbox" class="checkitem" name="del_id" value='<%= dt_CategoryType.Rows[i]["id"] %>' />
                        </td>
                        <td align="center">
                            <input type="text" value='<%= dt_CategoryType.Rows[i]["orderid"] %>' lang='<%= dt_CategoryType.Rows[i]["id"] %>'
                                class="tshort" />
                            <input type="hidden" value='<%= dt_CategoryType.Rows[i]["orderid"] %>' />
                        </td>
                        <td align="center">
                            <span>
                                <%= dt_CategoryType.Rows[i]["name"] %></span>
                        </td>
                        <td align="center">
                            <a onclick=" if (confirm('��ȷ��Ҫɾ����?')) {deleteType('<%= dt_CategoryType.Rows[i]["id"] %>', this);} else {return false;} "
                                href="javascript:void(0)">ɾ��</a>| <a href='CategoryType_Operate.aspx?op=type_edit&t_id=<%= dt_CategoryType.Rows[i]["id"] %>'>
                                    �༭</a>
                        </td>
                    </tr>
                    <% }
                               }
                    %>
                    <tr class="lmf_page" align="right">
                        <td style="height: 30px;" colspan="7">
                            <div class="btnlist">
                                <div class="fnum">
                                    ÿҳ��ʾ������ <a href="?pagesize=10&page=1" id="page10">10</a><a href="?pagesize=20&page=1"
                                        id="page20">20</a><a href="?pagesize=50&page=1" id="page50">50</a>
                                </div>
                                <div class="fpage" id="pageDiv" runat="server">
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        function NumTxt_Int(o) {
            o.value = o.value.replace(/\D/g, '');
        }

        // �ж��Ƿ�������

        function checknum(str) {
            var re = /^[0-9]+.?[0-9]*$/;
            if (!re.test(str)) {
                alert("��������ȷ�����֣�");
                return false;
            } else {
                return true;
            }
        }

        $(function () {
            $(".fpage").find(".quedbtn").click(function () {
                var pageindex = $("input[name='vjpage']").val();
                if (checknum(pageindex)) {
                    var pageEnd = parseInt($(".fpage font.pagecount").text());
                    if (pageEnd <= pageindex)
                        pageindex = pageEnd;
                    location.href = '?pageid=' + pageindex;
                }
            });


            var pagesize = '<%= Common.ReqStr("pagesize") %>';
            $("#page" + pagesize).addClass("cur");
            $("#checkallBottom").click(function () {
                if ($(this).is(":checked")) {
                    $(".checkitem").attr("checked", "checked");
                } else {
                    $(".checkitem").removeAttr("checked");
                }
            });

            $(".tinput").blur(function () {
                if ($(this).val() != $(this).next().find("input").val()) {
                    var oid = $(this).val() + "|" + $(this).attr("lang");
                    $.get("/Api/CategoryType.ashx?oid=" + oid, null, function (data) {
                    });
                }
            });
        });

        function delete_list_select() {
            var checkitem = new Array();
            var bflag = false;
            $(".checkitem").each(function () {
                if ($(this).is(":checked")) {
                    bflag = true;
                    checkitem.push($(this).val());
                }
            });
            if (bflag) {
                if (confirm("�Ƿ�����ɾ��?")) {
                    $.get("/Api/CategoryType.ashx?delBatchId=" + checkitem.join(","), null, function (data) {
                        if (data == "ok") {
                            alert("����ɾ���ɹ���");
                            $(".checkitem").removeAttr("checked");
                            window.location.reload();
                        }
                    });
                } else {
                    return false;
                }
            } else {
                alert("���ٹ�ѡһ�����ݲ��ܽ�������ɾ��������");
                return false;
            }

        }

        function deleteType(id, o) {
            $.get("/Api/CategoryType.ashx?delBatchId=" + id, null, function (data) {
                if (data == "ok") {
                    alert("����ɾ���ɹ���");
                }
            });
            $(o).parent().parent().remove();
        }
    </script>
    </form>
</body>
</html>
