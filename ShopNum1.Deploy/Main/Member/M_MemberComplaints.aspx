<%@ Page Language="C#" EnableViewState="false" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="Skin/M_MemberComplaints.ascx" TagName="M_MemberComplaints" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>�ҵ�Ͷ��</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="js/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/js/artDialog/artDialog.js"></script>
    <script type="text/javascript" language="javascript">
     function IsDelete(val){
        if(confirm("�Ƿ�ɾ����ѡ�"))
        {
            $("input[type='checkbox']").removeAttr("checked");
               $.get("/Main/Member/ajax/DeleteOp.ashx?type=sysmsg&delid="+val,null,function(data){
                    if(data=="ok"){alert("ɾ���ɹ���");location.reload(); return false;}
                    else{alert("ɾ��ʧ�ܣ�");return false;}
        }
     }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="tjsp_mian">
        <p class="ptitle">
            <a href="M_Welcome.aspx">�������</a><span class="breadcrume_icon">>></span><a href="M_Complaints.aspx">�ҵ�Ͷ��</a><span
                class="breadcrume_icon">>></span><span class="breadcrume_text">��ҪͶ��</span></p>
        <uc1:M_MemberComplaints ID="M_MemberComplaints1" runat="server" />
        <%--        <ShopNum1:M_MemberComplaints ID="M_MemberComplaints" runat="server" SkinFilename="Skin/M_MemberComplaints.ascx" />--%>
    </div>
    <script type="text/javascript" language="javascript">
        //��ת���ƶ���ҳ��
        function ontoPage(txtId) {
            location.href = '?isread=<%= ShopNum1.Common.Common.ReqStr("isread") %>&pageid=' + $("#" + txtId).val();
        }
        $(function () {
            //����ɾ������
            $(".shanchu").click(function () {
                var ArrayGuid = new Array();
                $("input[name='checksub']").each(function () {
                    ArrayGuid.push("'" + $(this).val() + "'");
                });
                IsDelete(ArrayGuid.join(","));
            });
        });
    </script>
    </form>
</body>
</html>
