<style type="text/css">
    .messagetext
    {
        overflow: hidden;
        zoom: 1;
        border-left: 1px solid #000;
        border-right: 1px solid #000;
        padding: 0 10px;
        text-align: left;
        background: #ffffe1;
        word-break: break-all;
        letter-break: break-all;
    }
    .messagetext img
    {
        float: left;
        margin: 0 3px 3px 3px;
    }
    .infomessage
    {
        float: right;
        margin-top: -10px;
        margin-right: -4px;
    }
</style>
<!--提示层部分开始-->
<span id="hintdivup" style="display: none; position: absolute; z-index: 500;">
    <div style="position: absolute; visibility: visible; width: 271px; z-index: 501;">
        <p>
            <img src="/images/commandbg.gif" /></p>
        <div class="messagetext">
            <img src="/images/dot.gif" /><span id="hintinfoup"></span></div>
        <p>
            <img src="/images/commandbg2.gif" /></p>
    </div>
    <iframe id="hintiframeup" style="position: absolute; z-index: 100; width: 266px;
        scrolling: no;" frameborder="0"></iframe>
</span><span id="hintdivdown" style="display: none; position: absolute; z-index: 500;">
    <div style="position: absolute; visibility: visible; width: 271px; z-index: 501;">
        <p>
            <img src="/images/commandbg3.gif" /></p>
        <div class="messagetext">
            <img src="/images/dot.gif" /><span id="hintinfodown"></span></div>
        <p>
            <img src="/images/commandbg4.gif" /></p>
    </div>
    <iframe id="hintiframedown" style="position: absolute; z-index: 100; width: 266px;
        scrolling: no;" frameborder="0"></iframe>
</span>
<!--提示层部分结束-->
