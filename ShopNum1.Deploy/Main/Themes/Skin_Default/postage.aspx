<%@ Page Language="C#" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
</head>
<body style="background: none;">
    <form id="from1" runat="server">
    <div class="postage">
        <div class="post_logo">
            <a href="Default.aspx">
                <img src="Themes/Skin_Default/Images/newLogo.png" /></a>
        </div>
        <div class="post_con">
            <h1>
                �𾴵�<span>������</span>���ã�</h1>
            <p>
                ��л���ڱ��̳�( mall.t.com )����!</p>
            <p>
                ���Ķ���<b>420329444</b>��δ����뾡�츶����ɽ��롰<a href="">��������</a>��ҳ����ʱ��ע����״̬�����Զ��������޸ĵȲ�����
            </p>
            <p>
                ��л�������ǵ�֧�֣�ף���������!</p>
        </div>
        <div class="post_tips">
            <p>
                ���������ʱ��ع�����Ķ���״̬�ȣ�����<a href="">�ֻ��ƶ��ͻ���</a>�����㡢����ݣ�</p>
        </div>
    </div>
    </form>
</html>
