<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>商品分类</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <link rel='stylesheet' type='text/css' href='style/Shopnum1.treelist.css' />
    <script src="js/jquery.pack.js" type="text/javascript"> </script>
    <script src="js/Shopnum1.treelist.js" type="text/javascript"> </script>
    <script type="text/javascript">
        var ajaxurl = "/Api/S_ProductCategory.ashx";

        function treelist_two_html(id, name, orderid, isshow, issub, parentid) {
            var xhtml = '<td align="left" valign="top" colspan="3" style="padding: 0; border: 0;">';
            xhtml += '<table cellpadding="0" cellspacing="0" border="0" width="100%" class="sub_lmf">';
            xhtml += '<tr class="sublmf_huaguo" id="delete_this_' + id + '">';
            xhtml += '<td align="left" valign="top" class="th_le1_bg">';
            xhtml += '<div class="sublmf_jia fl" onclick="funthreesub(this,' + id + ')">';
            //        if(issub!=""){xhtml+='<img style="border-width: 0px;" src="images/lmf_jia.jpg"/>';
            //        }else{}
            xhtml += '<span style="width:13px; display:block; height:20px;">&nbsp;</span>';
            xhtml += '</div><div class="sublmf_xuanze fl"><input type="checkbox" value="' + id + '" onclick="treelist_subcheck(this)"  lang="c_' + id + '" class="c_p vcheck"/></div>';
            xhtml += '<div class="sublmf_paixu fl">';
            xhtml += '<input type="text" name=\"orderby\" value="' + orderid + '" lang="' + id + '" style="width:65px;" /></div>';
            xhtml += '<div class="sublmf_titlee fl">';
            xhtml += '<input type="text" value="' + name + '" class="subtxt" /></div>';
            xhtml += '</td>';
            xhtml += '<td align="center" valign="top" width="100px">';
            if (isshow == 1) {
                xhtml += '<img style="border-width: 0px;" src="images/dui.jpg" onclick="treelist_isshow(this)" class="isshow" lang="' + id + '-' + isshow + '">';
            } else {
                xhtml += '<img style="border-width: 0px;" src="images/cuo.jpg" onclick="treelist_isshow(this)" class="isshow" lang="' + id + '-' + isshow + '">';
            }
            xhtml += '</td>';
            xhtml += '<td align="center" valign="top" width="300px" class="th_ri1">';
            xhtml += '<a class="saveedit" href="#" lang="' + id + '" style="color: #4482b4;" onclick="treelist_save(this)">保存</a>&nbsp;&nbsp;';
            xhtml += '<a href="S_ProductCategory_Operate.aspx?op=edit&id=' + id + '&parentid=' + parentid + '&width=810&height=500" onclick="treelist_edit(this,0)" class="dialog vdr" style="color: #4482b4;">编辑</a>&nbsp;&nbsp;';
            xhtml += '<a href="#" lang="' + id + '" class="delv" style="color: #4482b4;" onclick="treelist_delete(this)">删除</a>&nbsp;&nbsp;';
            xhtml += '</td>';
            xhtml += '</tr>';
            xhtml += '<tr style="display:none;" class="three" id="two_three_' + id + '"></tr>';
            return xhtml;
        }

        $(function () {
            //全选
            $("#topcheck").click(function () {
                $(".vcheck").attr("checked", $(this).is(":checked"));
            });
            //删除
            $(".shanchu").click(function () {

                var varry = new Array();
                var bflag = true;
                $(".vcheck").each(function () {
                    if ($(this).is(":checked")) {
                        varry.push($(this).val());
                        bflag = false;
                    }
                });
                if (bflag) {
                    alert("请选中一条数据！");
                    return false;
                }
                if (confirm("是否批量删除？")) {
                    $.get(ajaxurl + "?op=batchdel&batch=" + varry.join(","), null, function (data) {
                    });
                    for (var i in varry) {
                        $("#parent_" + varry[i]).remove();
                        $("#sub_two_" + varry[i]).remove();
                        $("#delete_this_" + varry[i]).remove();
                    }
                    alert("删除成功！");
                }
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <span class="spanrig"><a class="tianjiafl lmf_btn" href="S_ProductCategory_Operate.aspx?op=add&id=0">
                添加分类</a></span> <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span
                    class="breadcrume_text">店铺商品分类</span></p>
        <ShopNum1ShopAdmin:S_ProductCategory ID="S_ProductCategory" runat="server" SkinFilename="Skin/S_ProductCategory.ascx" />
    </div>
    </form>
</body>
</html>
