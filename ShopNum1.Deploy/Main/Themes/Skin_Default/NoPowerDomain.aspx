<%@ Page Language="C#" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>����δ��Ȩ</title>
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
</head>
<body style="background: none;">
    <form id="from1" runat="server">
    <%--<div class="clearmiddle" style="padding-top:80px; margin:0 auto; width: 800px; overflow:hidden;">
      <div class="errorbox">
      <img src="Themes/Skin_Default/Images/errorlogo.jpg" />
      <div class="errorsession">
      �Բ���������������δ����Ȩ
      </div>
 
      <div class="errorcontrol">
   
      </div>
      </div>
      <div style="clear:both; padding-top:20px;"></div>
       
<!-- bottom -->
    </div>--%>
    <div class="warp clearfix grantor">
        <div class="nopower">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td class="notd">
                        �𾴵��û���<br />
                        ���ã�<br />
                        ������վĿǰ��ʱ�޷����ʣ���������û�б���Ȩ����<br />
                        IP����ֹ�����ˣ����˽����飬�뾡����ϵ��˾�ͷ���Ա��<br />
                        ��л������������<a href="http://www.T.com" target="_blank" style="color: #cc3300;">�人�ƽ��������޹�˾</a>��������֧�֣�<br />
                        <br />
                        <p>
                            ��ϵ�绰��<span>400-691-8851</span></p>
                        <p>
                            E-mail:<a href="mailto:manager@shopnum1.com?subject=Hello" target="_blank">manager@shopnum1.com</a></p>
                        <p>
                            ��ַ��<a href="http://www.T.com" target="_blank">www.T.com</a></p>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</html>
