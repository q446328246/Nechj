<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<link href="http://shop23.0851it.com/templates/default/css/base.css" rel="stylesheet"
    type="text/css">
<link href="http://shop23.0851it.com/templates/default/css/member.css" rel="stylesheet"
    type="text/css">
<link href="http://shop23.0851it.com/templates/default/css/member_store.css" rel="stylesheet"
    type="text/css">
<script type="text/javascript" src="http://shop23.0851it.com/resource/js/jquery.js"> </script>
<style type="text/css">
    body
    {
        background-color: #F5F5F5;
        margin: 0;
        padding: 0;
        position: relative;
        z-index: 0;
    }
    
    .upload_wrap
    {
        border: 0;
        padding: 0;
    }
    
    .pic-change-a
    {
        background: #F5F5F5 url(http://shop23.0851it.com/templates/default/images/member/album_bg.gif) no-repeat 0px -330px;
        color: #999;
        display: block;
        float: left;
        font-size: 12px;
        height: 20px;
        line-height: 20px;
        padding-left: 24px;
        white-space: nowrap;
        width: 60px;
    }
    
    .pic-change-b
    {
        background: #F5F5F5 url(http://shop23.0851it.com/templates/default/images/member/album_bg.gif) no-repeat -152px -330px;
        color: #36C;
        display: block;
        float: left;
        font-size: 12px;
        height: 20px;
        line-height: 20px;
        padding-left: 24px;
        text-decoration: underline;
        white-space: nowrap;
        width: 60px;
    }
</style>
<script type="text/javascript">
    function submit_form(obj) {
        obj.attr('disabled', 'disabled');
        $('#image_form').submit();
    }

    $(function () {
        $('span').hover(
            function () {
                $('#picChange').attr('class', 'pic-change-b');
            },
            function () {
                $('#picChange').attr('class', 'pic-change-a');
            });
    });
</script>
<input type="hidden" name="id" value="476">
<input type="hidden" name="form_submit" value="ok" />
<span style="height: 20px; left: 0px; position: absolute; top: 0px; width: 84px;
    z-index: 999;">
    <input onchange=" $('#submit_button').click(); " type="file" name="file" style="cursor: pointer;
        filter: alpha(opacity=0); height: 20px; opacity: 0; width: 84px;" size="1" hidefocus="true"
        maxlength="0">
</span>
<div class="pic-change-a" id="picChange">
    替换上传</div>
<input id="submit_button" style="display: none" type="button" value="提交" onclick=" submit_form($(this)) " />