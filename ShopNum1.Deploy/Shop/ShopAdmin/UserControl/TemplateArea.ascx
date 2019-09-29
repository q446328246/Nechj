<%@ Control Language="C#" ClassName="TemplateArea" %>
<div id="alldiv" class="ks-ext-mask" style="-moz-opacity: 0.5; background: #FFF;
    display: none; filter: alpha(opacity=50); height: 100%; margin: 0; opacity: 0.5;
    position: absolute; width: 100%; z-index: 99;">
</div>
<div style="display: none; left: 104.5px; position: absolute; top: 200.5px; z-index: 9999;"
    class="ks-ext-position ks-overlay ks-dialog dialog-areas" id="dialog_areas">
    <div class="ks-contentbox">
        <div class="ks-stdmod-header">
            <div class="title">
                选择区域</div>
        </div>
        <div class="ks-stdmod-body">
            <ul id="J_CityList">
                <style type="text/css">
                    em.zt
                    {
                        border: 4px solid;
                        border-color: #333 transparent transparent transparent;
                        border-style: solid dashed dashed dashed;
                        display: inline-block;
                        font-size: 0;
                        height: 0;
                        line-height: 0;
                        padding: 0;
                        width: 0;
                    }
                    
                    .dialog-areas
                    {
                        background-color: #FFFFFF;
                        border: 1px solid #C4D5DF;
                        position: absolute;
                        width: 580px;
                    }
                    
                    .dialog-areas .title
                    {
                        background-color: #E9F1F4;
                        border-color: #FFFFFF #FFFFFF #C4D5DF;
                        border-style: solid;
                        border-width: 1px;
                        font-weight: 700;
                        height: 22px;
                        line-height: 22px;
                        padding-left: 10px;
                    }
                    
                    .dialog-areas .even
                    {
                        background-color: #ECF4FF;
                    }
                    
                    .dialog-areas .btns
                    {
                        margin-left: 430px;
                        padding: 5px 0 5px 10px;
                    }
                    
                    .dialog-areas label
                    {
                        margin: 0 3px;
                    }
                    
                    .dialog-areas ul
                    {
                        border-bottom: 1px solid #C4D5DF;
                    }
                    
                    .dialog-areas li
                    {
                        overflow: hidden;
                        width: 100%;
                    }
                    
                    .dialog-areas li span.group-label
                    {
                        display: inline-block;
                        font-weight: 700;
                        margin-right: 5px;
                        padding: 5px 0 5px 10px;
                        width: 70px;
                    }
                    
                    .dialog-areas button
                    {
                        margin-right: 5px;
                        padding: 2px 3px;
                    }
                    
                    .dialog-areas .btns .msg
                    {
                        position: absolute;
                    }
                    
                    .dialog-areas input, .dialog-areas button
                    {
                        vertical-align: middle;
                    }
                    
                    .dialog-areas .ks-ext-close
                    {
                        font-size: 10px;
                        position: absolute;
                        right: 5px;
                        top: 5px;
                    }
                    
                    .dialog-areas .areas b
                    {
                        border-color: #666666 #FFFFFF #FFFFFF;
                        border-style: solid;
                        border-width: 4px;
                        display: none;
                        font-size: 0;
                        height: 0;
                        line-height: 0;
                        overflow: hidden;
                        vertical-align: middle;
                        width: 0;
                    }
                    
                    .ks-ext-mask
                    {
                        -moz-opacity: 0.7;
                        background-color: #FFFFFF;
                        filter: Alpha(Opacity=70);
                        opacity: 0.7;
                    }
                    
                    .dialog-address
                    {
                        background-color: #F1FAFE;
                        border: 1px solid #95D2FF;
                        position: absolute;
                        width: 580px;
                    }
                    
                    .dialog-address .hd
                    {
                        height: 30px;
                        line-height: 30px;
                        overflow: hidden;
                        padding: 0 5px;
                    }
                    
                    .dialog-address h3
                    {
                        display: inline;
                    }
                    
                    .dialog-address .action
                    {
                        float: right;
                    }
                    
                    .dialog-address table
                    {
                        border-left: 1px solid #FFFFFF;
                        width: 100%;
                    }
                    
                    .dialog-address caption
                    {
                        display: none;
                    }
                    
                    .dialog-address .col-uid
                    {
                        width: 30px;
                    }
                    
                    .dialog-address .col-name
                    {
                        width: 80px;
                    }
                    
                    .dialog-address .col-postcode
                    {
                        width: 60px;
                    }
                    
                    .dialog-address .col-phone, .dialog-address .col-mobile
                    {
                        width: 90px;
                    }
                    
                    .dialog-address td
                    {
                        background-color: #E2EFFF;
                        border-color: #FFFFFF;
                        border-style: solid;
                        border-width: 0 1px 1px 0;
                        height: 34px;
                        padding: 5px;
                        word-wrap: break-word;
                    }
                    
                    .dialog-address .even td
                    {
                        background-color: #CBE1FF;
                    }
                    
                    .dialog-address input
                    {
                        vertical-align: middle;
                    }
                    
                    .dialog-address .ft
                    {
                        padding: 5px;
                    }
                    
                    .dialog-batch
                    {
                        background-color: #FFFFFF;
                        border: 1px solid #95D2FF;
                        padding: 10px;
                        position: absolute;
                        width: 580px;
                    }
                    
                    .dialog-batch .input-readonly
                    {
                        background-color: #EEEEEE;
                        border: 1px solid #CCCCCC;
                    }
                    
                    .dialog-batch .btns
                    {
                        padding-top: 10px;
                        text-align: center;
                    }
                    
                    .dialog-batch button
                    {
                        margin: 0 5px;
                    }
                    
                    .dialog-batch .ks-ext-close
                    {
                        font-size: 10px;
                        position: absolute;
                        right: 5px;
                        top: 5px;
                    }
                    
                    .dialog-batch .input-text
                    {
                        border: 1px solid #7F9DB9;
                        height: 15px;
                        line-height: 15px;
                        padding: 1px 0;
                        width: 6em;
                    }
                    
                    button, input, select, textarea
                    {
                        font-size: 100%;
                    }
                    
                    .clearfix:after
                    {
                        clear: both;
                        content: "";
                        display: block;
                        height: 0;
                    }
                    
                    .citys
                    {
                        background-color: #FFFEC6;
                        border: 1px solid #F7E4A5;
                        display: none;
                        float: right;
                        left: 0;
                        position: absolute;
                        top: 23px;
                        white-space: normal;
                        width: 214px;
                        z-index: 20000;
                    }
                    
                    .styblock
                    {
                        display: block;
                    }
                    
                    .citys span
                    {
                        line-height: 2;
                        margin-right: 2px;
                    }
                    
                    .dialog-areas li
                    {
                        overflow: visible;
                    }
                    
                    .dcity
                    {
                        display: block;
                        vertical-align: middle;
                        z-index: 1;
                    }
                    
                    .ecity
                    {
                        float: left;
                        height: 30px;
                        margin-right: 1px;
                        padding-right: 8px;
                        position: relative;
                        width: 100px;
                    }
                    
                    .gcity, .province-list
                    {
                        display: inline-block;
                    }
                    
                    .province-list
                    {
                        width: 450px;
                    }
                    
                    .trigger
                    {
                        cursor: pointer;
                        height: 8px;
                        padding: 2px;
                        width: 8px;
                    }
                    
                    .dialog-areas li span.areas
                    {
                        display: inline-block;
                        margin-right: 3px;
                        padding: 4px 0 1px 4px;
                    }
                    
                    .dialog-areas span.gareas
                    {
                        border: 1px solid #FFFFFF;
                        display: inline-block;
                        height: 17px;
                        margin-right: 3px;
                        padding: 4px 4px 1px;
                        position: relative;
                        white-space: nowrap;
                        width: 80px;
                    }
                    
                    .dialog-areas .even span.gareas
                    {
                        background-color: #ECF4FF;
                        border-color: #ECF4FF;
                    }
                    
                    .dialog-areas li span.egareas
                    {
                        background-color: #FFFEC6;
                        border: 1px solid #F7E4A5;
                        display: inline-block;
                        margin-right: 3px;
                        padding: 3px 0 1px;
                        width: 70px;
                    }
                    
                    .showCityPop
                    {
                        z-index: 55556;
                    }
                    
                    .dialog-areas .showCityPop .gareas
                    {
                        -moz-border-bottom-colors: none;
                        -moz-border-image: none;
                        -moz-border-left-colors: none;
                        -moz-border-right-colors: none;
                        -moz-border-top-colors: none;
                        background-color: #FFFEC6;
                        border-color: #F7E4A5 #F7E4A5 #FFFEC6;
                        border-style: solid;
                        border-width: 1px;
                        z-index: 56000;
                    }
                    
                    .dialog-areas .even .showCityPop .gareas
                    {
                        background-color: #FFFEC6;
                        border-color: #F7E4A5 #F7E4A5 #FFFEC6;
                    }
                    
                    .showCityPop .citys
                    {
                        display: block;
                        z-index: 55900;
                    }
                    
                    .checkbox
                    {
                        padding: 0;
                        vertical-align: middle;
                    }
                    
                    .dialog-areas label
                    {
                        margin: 0 1px;
                    }
                    
                    .check_num
                    {
                        color: #F60;
                        font-size: 12px;
                        letter-spacing: -1px;
                        padding-right: 1px;
                    }
                    
                    .hidden
                    {
                        display: none;
                    }
                </style>
                <li>
                    <div class=" dcity clearfix">
                        <div class="ecity gcity">
                            <span class="group-label">
                                <input type="checkbox" value="" class="J_Group" id="J_Group_1" />
                                <label for="J_Group_1">
                                    华东</label>
                            </span>
                        </div>
                        <div class="province-list">
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="011" id="J_Province_011" class="J_Province">
                                    <label for="J_Province_011">
                                        浙江省</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="011001" id="my_City_011001" class="J_City"><label for="J_City_011001">杭州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="011002" id="my_City_011002" class="J_City"><label for="J_City_011002">宁波市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="011003" id="my_City_011003" class="J_City"><label for="J_City_011003">温州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="011004" id="my_City_011004" class="J_City"><label for="J_City_011004">嘉兴市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="011005" id="my_City_011005" class="J_City"><label for="J_City_011005">湖州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="011006" id="my_City_011006" class="J_City"><label for="J_City_011006">绍兴市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="011007" id="my_City_011007" class="J_City"><label for="J_City_011007">金华市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="011008" id="my_City_011008" class="J_City"><label for="J_City_011008">衢州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="011009" id="my_City_011009" class="J_City"><label for="J_City_011009">舟山市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="011010" id="my_City_011010" class="J_City"><label for="J_City_011010">台州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="011011" id="my_City_011011" class="J_City"><label for="J_City_011011">丽水市</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="014" id="J_Province_014" class="J_Province">
                                    <label for="J_Province_014">
                                        江西省</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="014001" id="my_City_014001" class="J_City"><label for="J_City_014001">南昌市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="014002" id="my_City_014002" class="J_City"><label for="J_City_014002">景德镇市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="014003" id="my_City_014003" class="J_City"><label for="J_City_014003">萍乡市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="014004" id="my_City_014004" class="J_City"><label for="J_City_014004">九江市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="014005" id="my_City_014005" class="J_City"><label for="J_City_014005">新余市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="014006" id="my_City_014006" class="J_City"><label for="J_City_014006">鹰潭市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="014007" id="my_City_014007" class="J_City"><label for="J_City_014007">赣州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="014008" id="my_City_014008" class="J_City"><label for="J_City_014008">吉安市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="014009" id="my_City_014009" class="J_City"><label for="J_City_014009">宜春市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="014010" id="my_City_014010" class="J_City"><label for="J_City_014010">抚州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="014011" id="my_City_014011" class="J_City"><label for="J_City_014011">上饶市</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="012" id="J_Province_012" class="J_Province">
                                    <label for="J_Province_012">
                                        安徽省</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="012001" id="my_City_012001" class="J_City"><label for="J_City_012001">合肥市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="012002" id="my_City_012002" class="J_City"><label for="J_City_012002">芜湖市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="012003" id="my_City_012003" class="J_City"><label for="J_City_012003">蚌埠市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="012004" id="my_City_012004" class="J_City"><label for="J_City_012004">淮南市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="012005" id="my_City_012005" class="J_City"><label for="J_City_012005">马鞍山市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="012006" id="my_City_012006" class="J_City"><label for="J_City_012006">淮北市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="012007" id="my_City_012007" class="J_City"><label for="J_City_012007">铜陵市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="012008" id="my_City_012008" class="J_City"><label for="J_City_012008">安庆市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="012009" id="my_City_012009" class="J_City"><label for="J_City_012009">黄山市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="012010" id="my_City_012010" class="J_City"><label for="J_City_012010">滁州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="012011" id="my_City_012011" class="J_City"><label for="J_City_012011">阜阳市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="012012" id="my_City_012012" class="J_City"><label for="J_City_012012">宿州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="012013" id="my_City_012013" class="J_City"><label for="J_City_012013">巢湖市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="012014" id="my_City_012014" class="J_City"><label for="J_City_012014">六安市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="012015" id="my_City_012015" class="J_City"><label for="J_City_012015">亳州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="012016" id="my_City_012016" class="J_City"><label for="J_City_012016">池州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="012017" id="my_City_012017" class="J_City"><label for="J_City_012017">宣城市</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="010" id="J_Province_010" class="J_Province">
                                    <label for="J_Province_010">
                                        江苏省</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="010001" id="my_City_010001" class="J_City"><label for="J_City_010001">南京市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="010002" id="my_City_010002" class="J_City"><label for="J_City_010002">无锡市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="010003" id="my_City_010003" class="J_City"><label for="J_City_010003">徐州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="010004" id="my_City_010004" class="J_City"><label for="J_City_010004">常州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="010005" id="my_City_010005" class="J_City"><label for="J_City_010005">苏州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="010006" id="my_City_010006" class="J_City"><label for="J_City_010006">南通市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="010007" id="my_City_010007" class="J_City"><label for="J_City_010007">连云港市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="010008" id="my_City_010008" class="J_City"><label for="J_City_010008">淮安市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="010009" id="my_City_010009" class="J_City"><label for="J_City_010009">盐城市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="010010" id="my_City_010010" class="J_City"><label for="J_City_010010">扬州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="010011" id="my_City_010011" class="J_City"><label for="J_City_010011">镇江市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="010012" id="my_City_010012" class="J_City"><label for="J_City_010012">泰州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="010013" id="my_City_010013" class="J_City"><label for="J_City_010013">宿迁市</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="009" id="J_Province_009" class="J_Province">
                                    <label for="J_Province_009">
                                        上海市</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="009001" id="my_City_009001" class="J_City"><label for="J_City_009001">上海辖区</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="015" id="J_Province_015" class="J_Province">
                                    <label for="J_Province_015">
                                        山东省</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="015001" id="my_City_015001" class="J_City"><label for="J_City_015001">济南市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="015002" id="my_City_015002" class="J_City"><label for="J_City_015002">青岛市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="015003" id="my_City_015003" class="J_City"><label for="J_City_015003">淄博市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="015004" id="my_City_015004" class="J_City"><label for="J_City_015004">枣庄市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="015005" id="my_City_015005" class="J_City"><label for="J_City_015005">东营市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="015006" id="my_City_015006" class="J_City"><label for="J_City_015006">烟台市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="015007" id="my_City_015007" class="J_City"><label for="J_City_015007">潍坊市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="015008" id="my_City_015008" class="J_City"><label for="J_City_015008">济宁市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="015009" id="my_City_015009" class="J_City"><label for="J_City_015009">泰安市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="015010" id="my_City_015010" class="J_City"><label for="J_City_015010">威海市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="015011" id="my_City_015011" class="J_City"><label for="J_City_015011">日照市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="015012" id="my_City_015012" class="J_City"><label for="J_City_015012">莱芜市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="015013" id="my_City_015013" class="J_City"><label for="J_City_015013">临沂市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="015014" id="my_City_015014" class="J_City"><label for="J_City_015014">德州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="015015" id="my_City_015015" class="J_City"><label for="J_City_015015">聊城市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="015016" id="my_City_015016" class="J_City"><label for="J_City_015016">滨州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="015017" id="my_City_015017" class="J_City"><label for="J_City_015017">荷泽市</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                        </div>
                    </div>
                </li>
                <li class="even">
                    <div class=" dcity clearfix">
                        <div class="ecity gcity">
                            <span class="group-label">
                                <input type="checkbox" value="" class="J_Group" id="J_Group_2" />
                                <label for="J_Group_2">
                                    华北</label>
                            </span>
                        </div>
                        <div class="province-list">
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="005" id="J_Province_005" class="J_Province">
                                    <label for="J_Province_005">
                                        内蒙古区</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="005001" id="my_City_005001" class="J_City">
                                            <label for="J_City_005001">
                                                呼和浩特市</label></span> <span class="areas">
                                                    <input type="checkbox" value="005002" id="my_City_005002" class="J_City"><label for="J_City_005002">包头市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="005003" id="my_City_005003" class="J_City"><label for="J_City_005003">乌海市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="005004" id="my_City_005004" class="J_City"><label for="J_City_005004">赤峰市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="005005" id="my_City_005005" class="J_City"><label for="J_City_005005">通辽市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="005006" id="my_City_005006" class="J_City"><label for="J_City_005006">鄂尔多斯市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="005007" id="my_City_005007" class="J_City"><label for="J_City_005007">呼伦贝尔市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="005008" id="my_City_005008" class="J_City"><label for="J_City_005008">巴彦淖尔市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="005009" id="my_City_005009" class="J_City"><label for="J_City_005009">乌兰察布市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="005010" id="my_City_005010" class="J_City"><label for="J_City_005010">兴安盟</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="005011" id="my_City_005011" class="J_City"><label for="J_City_005011">锡林郭勒盟</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="005012" id="my_City_005012" class="J_City"><label for="J_City_005012">阿拉善盟</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="004" id="J_Province_004" class="J_Province">
                                    <label for="J_Province_004">
                                        山西省</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="004001" id="my_City_004001" class="J_City"><label for="J_City_004001">太原市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="004002" id="my_City_004002" class="J_City"><label for="J_City_004002">大同市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="004003" id="my_City_004003" class="J_City"><label for="J_City_004003">阳泉市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="004004" id="my_City_004004" class="J_City"><label for="J_City_004004">长治市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="004005" id="my_City_004005" class="J_City"><label for="J_City_004005">晋城市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="004006" id="my_City_004006" class="J_City"><label for="J_City_004006">朔州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="004007" id="my_City_004007" class="J_City"><label for="J_City_004007">晋中市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="004008" id="my_City_004008" class="J_City"><label for="J_City_004008">运城市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="004009" id="my_City_004009" class="J_City"><label for="J_City_004009">忻州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="004010" id="my_City_004010" class="J_City"><label for="J_City_004010">临汾市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="004011" id="my_City_004011" class="J_City"><label for="J_City_004011">吕梁市</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="003" id="J_Province_003" class="J_Province">
                                    <label for="J_Province_003">
                                        河北省</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="003001" id="my_City_003001" class="J_City"><label for="J_City_003001">石家庄市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="003002" id="my_City_003002" class="J_City"><label for="J_City_003002">唐山市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="003003" id="my_City_003003" class="J_City"><label for="J_City_003003">秦皇岛市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="003004" id="my_City_003004" class="J_City"><label for="J_City_003004">邯郸市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="003005" id="my_City_003005" class="J_City"><label for="J_City_003005">邢台市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="003006" id="my_City_003006" class="J_City"><label for="J_City_003006">保定市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="003007" id="my_City_003007" class="J_City"><label for="J_City_003007">张家口市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="003008" id="my_City_003008" class="J_City"><label for="J_City_003008">承德市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="003009" id="my_City_003009" class="J_City"><label for="J_City_003009">沧州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="003010" id="my_City_003010" class="J_City"><label for="J_City_003010">廊坊市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="003011" id="my_City_003011" class="J_City"><label for="J_City_003011">衡水市</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="002" id="J_Province_002" class="J_Province">
                                    <label for="J_Province_002">
                                        天津市</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="002001" id="my_City_002001" class="J_City"><label for="J_City_002001">天津辖区</label></span>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="001" id="Checkbox1" class="J_Province">
                                    <label for="J_Province_001">
                                        北京市</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="001001" id="Checkbox2" class="J_City"><label for="J_City_001001">北京辖区</label></span>
                                    </div>
                                </span>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class=" dcity clearfix">
                        <div class="ecity gcity">
                            <span class="group-label">
                                <input type="checkbox" value="" class="J_Group" id="J_Group_3" />
                                <label for="J_Group_3">
                                    华中</label>
                            </span>
                        </div>
                        <div class="province-list">
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="017" id="J_Province_017" class="J_Province">
                                    <label for="J_Province_017">
                                        湖北省</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="017001" id="my_City_017001" class="J_City"><label for="J_City_017001">武汉市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="017002" id="my_City_017002" class="J_City"><label for="J_City_017002">黄石市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="017003" id="my_City_017003" class="J_City"><label for="J_City_017003">十堰市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="017004" id="my_City_017004" class="J_City"><label for="J_City_017004">宜昌市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="017005" id="my_City_017005" class="J_City"><label for="J_City_017005">襄樊市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="017006" id="my_City_017006" class="J_City"><label for="J_City_017006">鄂州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="017007" id="my_City_017007" class="J_City"><label for="J_City_017007">荆门市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="017008" id="my_City_017008" class="J_City"><label for="J_City_017008">孝感市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="017009" id="my_City_017009" class="J_City"><label for="J_City_017009">荆州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="017010" id="my_City_017010" class="J_City"><label for="J_City_017010">黄冈市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="017011" id="my_City_017011" class="J_City"><label for="J_City_017011">咸宁市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="017012" id="my_City_017012" class="J_City"><label for="J_City_017012">随州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="017013" id="my_City_017013" class="J_City"><label for="J_City_017013">恩施自治州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="017014" id="my_City_017014" class="J_City"><label for="J_City_017014">湖北省辖单位</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="016" id="J_Province_016" class="J_Province">
                                    <label for="J_Province_016">
                                        河南省</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="016001" id="my_City_016001" class="J_City"><label for="J_City_016001">郑州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="016002" id="my_City_016002" class="J_City"><label for="J_City_016002">开封市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="016003" id="my_City_016003" class="J_City"><label for="J_City_016003">洛阳市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="016004" id="my_City_016004" class="J_City"><label for="J_City_016004">平顶山市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="016005" id="my_City_016005" class="J_City"><label for="J_City_016005">安阳市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="016006" id="my_City_016006" class="J_City"><label for="J_City_016006">鹤壁市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="016007" id="my_City_016007" class="J_City"><label for="J_City_016007">新乡市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="016008" id="my_City_016008" class="J_City"><label for="J_City_016008">焦作市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="016009" id="my_City_016009" class="J_City"><label for="J_City_016009">濮阳市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="016010" id="my_City_016010" class="J_City"><label for="J_City_016010">许昌市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="016011" id="my_City_016011" class="J_City"><label for="J_City_016011">漯河市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="016012" id="my_City_016012" class="J_City"><label for="J_City_016012">三门峡市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="016013" id="my_City_016013" class="J_City"><label for="J_City_016013">南阳市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="016014" id="my_City_016014" class="J_City"><label for="J_City_016014">商丘市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="016015" id="my_City_016015" class="J_City"><label for="J_City_016015">信阳市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="016016" id="my_City_016016" class="J_City"><label for="J_City_016016">周口市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="016017" id="my_City_016017" class="J_City"><label for="J_City_016017">驻马店市</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="018" id="J_Province_018" class="J_Province">
                                    <label for="J_Province_018">
                                        湖南省</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="018001" id="my_City_018001" class="J_City"><label for="J_City_018001">长沙市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="018002" id="my_City_018002" class="J_City"><label for="J_City_018002">株洲市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="018003" id="my_City_018003" class="J_City"><label for="J_City_018003">湘潭市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="018004" id="my_City_018004" class="J_City"><label for="J_City_018004">衡阳市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="018005" id="my_City_018005" class="J_City"><label for="J_City_018005">邵阳市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="018006" id="my_City_018006" class="J_City"><label for="J_City_018006">岳阳市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="018007" id="my_City_018007" class="J_City"><label for="J_City_018007">常德市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="018008" id="my_City_018008" class="J_City"><label for="J_City_018008">张家界市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="018009" id="my_City_018009" class="J_City"><label for="J_City_018009">益阳市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="018010" id="my_City_018010" class="J_City"><label for="J_City_018010">郴州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="018011" id="my_City_018011" class="J_City"><label for="J_City_018011">永州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="018012" id="my_City_018012" class="J_City"><label for="J_City_018012">怀化市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="018013" id="my_City_018013" class="J_City"><label for="J_City_018013">娄底市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="018014" id="my_City_018014" class="J_City"><label for="J_City_018014">湘西自治州</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                        </div>
                    </div>
                </li>
                <li class="even">
                    <div class=" dcity clearfix">
                        <div class="ecity gcity">
                            <span class="group-label">
                                <input type="checkbox" value="" class="J_Group" id="J_Group_4">
                                <label for="J_Group_4">
                                    华南</label>
                            </span>
                        </div>
                        <div class="province-list">
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="020" id="J_Province_020" class="J_Province">
                                    <label for="J_Province_020">
                                        广西区</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="020001" id="my_City_020001" class="J_City"><label for="J_City_020001">南宁市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="020002" id="my_City_020002" class="J_City"><label for="J_City_020002">柳州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="020003" id="my_City_020003" class="J_City"><label for="J_City_020003">桂林市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="020004" id="my_City_020004" class="J_City"><label for="J_City_020004">梧州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="020005" id="my_City_020005" class="J_City"><label for="J_City_020005">北海市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="020006" id="my_City_020006" class="J_City"><label for="J_City_020006">防城港市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="020007" id="my_City_020007" class="J_City"><label for="J_City_020007">钦州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="020008" id="my_City_020008" class="J_City"><label for="J_City_020008">贵港市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="020009" id="my_City_020009" class="J_City"><label for="J_City_020009">玉林市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="020010" id="my_City_020010" class="J_City"><label for="J_City_020010">百色市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="020011" id="my_City_020011" class="J_City"><label for="J_City_020011">贺州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="020012" id="my_City_020012" class="J_City"><label for="J_City_020012">河池市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="020013" id="my_City_020013" class="J_City"><label for="J_City_020013">来宾市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="020014" id="my_City_020014" class="J_City"><label for="J_City_020014">崇左市</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="021" id="J_Province_021" class="J_Province">
                                    <label for="J_Province_021">
                                        海南省</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="021001" id="my_City_021001" class="J_City"><label for="J_City_021001">海口市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="021002" id="my_City_021002" class="J_City"><label for="J_City_021002">三亚市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="021003" id="my_City_021003" class="J_City"><label for="J_City_021003">海南直辖县</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="019" id="J_Province_019" class="J_Province">
                                    <label for="J_Province_019">
                                        广东省</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="019001" id="my_City_019001" class="J_City"><label for="J_City_019001">广州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="019002" id="my_City_019002" class="J_City"><label for="J_City_019002">韶关市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="019003" id="my_City_019003" class="J_City"><label for="J_City_019003">深圳市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="019004" id="my_City_019004" class="J_City"><label for="J_City_019004">珠海市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="019005" id="my_City_019005" class="J_City"><label for="J_City_019005">汕头市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="019006" id="my_City_019006" class="J_City"><label for="J_City_019006">佛山市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="019007" id="my_City_019007" class="J_City"><label for="J_City_019007">江门市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="019008" id="my_City_019008" class="J_City"><label for="J_City_019008">湛江市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="019009" id="my_City_019009" class="J_City"><label for="J_City_019009">茂名市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="019010" id="my_City_019010" class="J_City"><label for="J_City_019010">肇庆市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="019011" id="my_City_019011" class="J_City"><label for="J_City_019011">惠州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="019012" id="my_City_019012" class="J_City"><label for="J_City_019012">梅州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="019013" id="my_City_019013" class="J_City"><label for="J_City_019013">汕尾市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="019014" id="my_City_019014" class="J_City"><label for="J_City_019014">河源市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="019015" id="my_City_019015" class="J_City"><label for="J_City_019015">阳江市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="019016" id="my_City_019016" class="J_City"><label for="J_City_019016">清远市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="019017" id="my_City_019017" class="J_City"><label for="J_City_019017">东莞市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="019018" id="my_City_019018" class="J_City"><label for="J_City_019018">中山市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="019019" id="my_City_019019" class="J_City"><label for="J_City_019019">潮州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="019020" id="my_City_019020" class="J_City"><label for="J_City_019020">揭阳市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="019021" id="my_City_019021" class="J_City"><label for="J_City_019021">云浮市</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="013" id="J_Province_013" class="J_Province">
                                    <label for="J_Province_013">
                                        福建省</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="013001" id="my_City_013001" class="J_City"><label for="J_City_013001">福州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="013002" id="my_City_013002" class="J_City"><label for="J_City_013002">厦门市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="013003" id="my_City_013003" class="J_City"><label for="J_City_013003">莆田市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="013004" id="my_City_013004" class="J_City"><label for="J_City_013004">三明市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="013005" id="my_City_013005" class="J_City"><label for="J_City_013005">泉州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="013006" id="my_City_013006" class="J_City"><label for="J_City_013006">漳州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="013007" id="my_City_013007" class="J_City"><label for="J_City_013007">南平市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="013008" id="my_City_013008" class="J_City"><label for="J_City_013008">龙岩市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="013009" id="my_City_013009" class="J_City"><label for="J_City_013009">宁德市</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class=" dcity clearfix">
                        <div class="ecity gcity">
                            <span class="group-label">
                                <input type="checkbox" value="" class="J_Group" id="J_Group_5">
                                <label for="J_Group_5">
                                    东北</label>
                            </span>
                        </div>
                        <div class="province-list">
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="007" id="J_Province_007" class="J_Province">
                                    <label for="J_Province_007">
                                        吉林省</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="007001" id="my_City_007001" class="J_City"><label for="J_City_007001">长春市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="007002" id="my_City_007002" class="J_City"><label for="J_City_007002">吉林市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="007003" id="my_City_007003" class="J_City"><label for="J_City_007003">四平市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="007004" id="my_City_007004" class="J_City"><label for="J_City_007004">辽源市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="007005" id="my_City_007005" class="J_City"><label for="J_City_007005">通化市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="007006" id="my_City_007006" class="J_City"><label for="J_City_007006">白山市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="007007" id="my_City_007007" class="J_City"><label for="J_City_007007">松原市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="007008" id="my_City_007008" class="J_City"><label for="J_City_007008">白城市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="007009" id="my_City_007009" class="J_City"><label for="J_City_007009">延边自治州</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="008" id="J_Province_008" class="J_Province">
                                    <label for="J_Province_008">
                                        黑龙江省</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="008001" id="my_City_008001" class="J_City"><label for="J_City_008001">哈尔滨市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="008002" id="my_City_008002" class="J_City"><label for="J_City_008002">齐齐哈尔市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="008003" id="my_City_008003" class="J_City"><label for="J_City_008003">鸡西市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="008004" id="my_City_008004" class="J_City"><label for="J_City_008004">鹤岗市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="008005" id="my_City_008005" class="J_City"><label for="J_City_008005">双鸭山市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="008006" id="my_City_008006" class="J_City"><label for="J_City_008006">大庆市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="008007" id="my_City_008007" class="J_City"><label for="J_City_008007">伊春市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="008008" id="my_City_008008" class="J_City"><label for="J_City_008008">佳木斯市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="008009" id="my_City_008009" class="J_City"><label for="J_City_008009">七台河市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="008010" id="my_City_008010" class="J_City"><label for="J_City_008010">牡丹江市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="008011" id="my_City_008011" class="J_City"><label for="J_City_008011">黑河市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="008012" id="my_City_008012" class="J_City"><label for="J_City_008012">绥化市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="008013" id="my_City_008013" class="J_City"><label for="J_City_008013">大兴安岭地区</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="006" id="J_Province_006" class="J_Province"><label
                                        for="J_Province_006">辽宁省</label><span class="check_num"></span><em class="zt trigger"></em><div
                                            class="citys">
                                            <span class="areas">
                                                <input type="checkbox" value="006001" id="my_City_006001" class="J_City"><label for="J_City_006001">沈阳市</label></span><span
                                                    class="areas"><input type="checkbox" value="006002" id="my_City_006002" class="J_City"><label
                                                        for="J_City_006002">大连市</label></span><span class="areas"><input type="checkbox"
                                                            value="006003" id="my_City_006003" class="J_City"><label for="J_City_006003">鞍山市</label></span><span
                                                                class="areas"><input type="checkbox" value="006004" id="my_City_006004" class="J_City"><label
                                                                    for="J_City_006004">抚顺市</label></span><span class="areas"><input type="checkbox"
                                                                        value="006005" id="my_City_006005" class="J_City"><label for="J_City_006005">本溪市</label></span><span
                                                                            class="areas"><input type="checkbox" value="006006" id="my_City_006006" class="J_City"><label
                                                                                for="J_City_006006">丹东市</label></span><span class="areas"><input type="checkbox"
                                                                                    value="006007" id="my_City_006007" class="J_City"><label for="J_City_006007">锦州市</label></span><span
                                                                                        class="areas"><input type="checkbox" value="006008" id="my_City_006008" class="J_City"><label
                                                                                            for="J_City_006008">营口市</label></span><span class="areas"><input type="checkbox"
                                                                                                value="006009" id="my_City_006009" class="J_City"><label for="J_City_006009">阜新市</label></span><span
                                                                                                    class="areas"><input type="checkbox" value="006010" id="my_City_006010" class="J_City"><label
                                                                                                        for="J_City_006010">辽阳市</label></span><span class="areas"><input type="checkbox"
                                                                                                            value="006011" id="my_City_006011" class="J_City"><label for="J_City_006011">盘锦市</label></span><span
                                                                                                                class="areas"><input type="checkbox" value="006012" id="my_City_006012" class="J_City"><label
                                                                                                                    for="J_City_006012">铁岭市</label></span><span class="areas"><input type="checkbox"
                                                                                                                        value="006013" id="my_City_006013" class="J_City"><label for="J_City_006013">朝阳市</label></span><span
                                                                                                                            class="areas"><input type="checkbox" value="006014" id="my_City_006014" class="J_City"><label
                                                                                                                                for="J_City_006014">葫芦岛市</label></span><p style="text-align: right;">
                                                                                                                                    <input type="button" value="关闭" class="close_button"></p>
                                        </div>
                                </span>
                            </div>
                        </div>
                    </div>
                </li>
                <li class="even">
                    <div class=" dcity clearfix">
                        <div class="ecity gcity">
                            <span class="group-label">
                                <input type="checkbox" value="" class="J_Group" id="J_Group_6">
                                <label for="J_Group_6">
                                    西北</label>
                            </span>
                        </div>
                        <div class="province-list">
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="030" id="J_Province_030" class="J_Province">
                                    <label for="J_Province_030">
                                        宁夏区</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="030001" id="my_City_030001" class="J_City"><label for="J_City_030001">银川市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="030002" id="my_City_030002" class="J_City"><label for="J_City_030002">石嘴山市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="030003" id="my_City_030003" class="J_City"><label for="J_City_030003">吴忠市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="030004" id="my_City_030004" class="J_City"><label for="J_City_030004">固原市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="030005" id="my_City_030005" class="J_City"><label for="J_City_030005">中卫市</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="031" id="J_Province_031" class="J_Province">
                                    <label for="J_Province_031">
                                        新疆区</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="031001" id="my_City_031001" class="J_City"><label for="J_City_031001">乌鲁木齐市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="031002" id="my_City_031002" class="J_City"><label for="J_City_031002">克拉玛依市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="031003" id="my_City_031003" class="J_City"><label for="J_City_031003">吐鲁番地区</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="031004" id="my_City_031004" class="J_City"><label for="J_City_031004">哈密地区</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="031005" id="my_City_031005" class="J_City"><label for="J_City_031005">昌吉自治州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="031006" id="my_City_031006" class="J_City"><label for="J_City_031006">博尔塔拉州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="031007" id="my_City_031007" class="J_City"><label for="J_City_031007">巴音郭楞州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="031008" id="my_City_031008" class="J_City"><label for="J_City_031008">阿克苏地区</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="031009" id="my_City_031009" class="J_City"><label for="J_City_031009">克孜勒苏州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="031010" id="my_City_031010" class="J_City"><label for="J_City_031010">喀什地区</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="031011" id="my_City_031011" class="J_City"><label for="J_City_031011">和田地区</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="031012" id="my_City_031012" class="J_City"><label for="J_City_031012">伊犁自治州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="031013" id="my_City_031013" class="J_City"><label for="J_City_031013">塔城地区</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="031014" id="my_City_031014" class="J_City"><label for="J_City_031014">阿勒泰地区</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="031015" id="my_City_031015" class="J_City"><label for="J_City_031015">新疆省辖单位</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="029" id="J_Province_029" class="J_Province">
                                    <label for="J_Province_029">
                                        青海省</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="029001" id="my_City_029001" class="J_City"><label for="J_City_029001">西宁市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="029002" id="my_City_029002" class="J_City"><label for="J_City_029002">海东地区</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="029003" id="my_City_029003" class="J_City"><label for="J_City_029003">海北自治州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="029004" id="my_City_029004" class="J_City"><label for="J_City_029004">黄南自治州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="029005" id="my_City_029005" class="J_City"><label for="J_City_029005">海南自治州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="029006" id="my_City_029006" class="J_City"><label for="J_City_029006">果洛自治州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="029007" id="my_City_029007" class="J_City"><label for="J_City_029007">玉树自治州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="029008" id="my_City_029008" class="J_City"><label for="J_City_029008">海西自治州</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="028" id="J_Province_028" class="J_Province">
                                    <label for="J_Province_028">
                                        甘肃省</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="028001" id="my_City_028001" class="J_City"><label for="J_City_028001">兰州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="028002" id="my_City_028002" class="J_City"><label for="J_City_028002">嘉峪关市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="028003" id="my_City_028003" class="J_City"><label for="J_City_028003">金昌市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="028004" id="my_City_028004" class="J_City"><label for="J_City_028004">白银市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="028005" id="my_City_028005" class="J_City"><label for="J_City_028005">天水市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="028006" id="my_City_028006" class="J_City"><label for="J_City_028006">武威市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="028007" id="my_City_028007" class="J_City"><label for="J_City_028007">张掖市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="028008" id="my_City_028008" class="J_City"><label for="J_City_028008">平凉市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="028009" id="my_City_028009" class="J_City"><label for="J_City_028009">酒泉市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="028010" id="my_City_028010" class="J_City"><label for="J_City_028010">庆阳市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="028011" id="my_City_028011" class="J_City"><label for="J_City_028011">定西市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="028012" id="my_City_028012" class="J_City"><label for="J_City_028012">陇南市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="028013" id="my_City_028013" class="J_City"><label for="J_City_028013">临夏自治州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="028014" id="my_City_028014" class="J_City"><label for="J_City_028014">甘南自治州</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="027" id="J_Province_027" class="J_Province">
                                    <label for="J_Province_027">
                                        陕西省</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="027001" id="my_City_027001" class="J_City"><label for="J_City_027001">西安市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="027002" id="my_City_027002" class="J_City"><label for="J_City_027002">铜川市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="027003" id="my_City_027003" class="J_City"><label for="J_City_027003">宝鸡市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="027004" id="my_City_027004" class="J_City"><label for="J_City_027004">咸阳市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="027005" id="my_City_027005" class="J_City"><label for="J_City_027005">渭南市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="027006" id="my_City_027006" class="J_City"><label for="J_City_027006">延安市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="027007" id="my_City_027007" class="J_City"><label for="J_City_027007">汉中市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="027008" id="my_City_027008" class="J_City"><label for="J_City_027008">榆林市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="027009" id="my_City_027009" class="J_City"><label for="J_City_027009">安康市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="027010" id="my_City_027010" class="J_City"><label for="J_City_027010">商洛市</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class=" dcity clearfix">
                        <div class="ecity gcity">
                            <span class="group-label">
                                <input type="checkbox" value="" class="J_Group" id="J_Group_7">
                                <label for="J_Group_7">
                                    西南</label>
                            </span>
                        </div>
                        <div class="province-list">
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="024" id="J_Province_024" class="J_Province">
                                    <label for="J_Province_024">
                                        贵州省</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="024001" id="my_City_024001" class="J_City"><label for="J_City_024001">贵阳市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="024002" id="my_City_024002" class="J_City"><label for="J_City_024002">六盘水市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="024003" id="my_City_024003" class="J_City"><label for="J_City_024003">遵义市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="024004" id="my_City_024004" class="J_City"><label for="J_City_024004">安顺市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="024005" id="my_City_024005" class="J_City"><label for="J_City_024005">铜仁地区</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="024006" id="my_City_024006" class="J_City"><label for="J_City_024006">黔西南自治州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="024007" id="my_City_024007" class="J_City"><label for="J_City_024007">毕节地区</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="024008" id="my_City_024008" class="J_City"><label for="J_City_024008">黔东南自治州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="024009" id="my_City_024009" class="J_City"><label for="J_City_024009">黔南自治州</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="026" id="J_Province_026" class="J_Province">
                                    <label for="J_Province_026">
                                        西藏区</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="026001" id="my_City_026001" class="J_City"><label for="J_City_026001">拉萨市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="026002" id="my_City_026002" class="J_City"><label for="J_City_026002">昌都地区</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="026003" id="my_City_026003" class="J_City"><label for="J_City_026003">山南地区</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="026004" id="my_City_026004" class="J_City"><label for="J_City_026004">日喀则地区</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="026005" id="my_City_026005" class="J_City"><label for="J_City_026005">那曲地区</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="026006" id="my_City_026006" class="J_City"><label for="J_City_026006">阿里地区</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="026007" id="my_City_026007" class="J_City"><label for="J_City_026007">林芝地区</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="025" id="J_Province_025" class="J_Province">
                                    <label for="J_Province_025">
                                        云南省</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="025001" id="my_City_025001" class="J_City"><label for="J_City_025001">昆明市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="025002" id="my_City_025002" class="J_City"><label for="J_City_025002">曲靖市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="025003" id="my_City_025003" class="J_City"><label for="J_City_025003">玉溪市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="025004" id="my_City_025004" class="J_City"><label for="J_City_025004">保山市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="025005" id="my_City_025005" class="J_City"><label for="J_City_025005">昭通市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="025006" id="my_City_025006" class="J_City"><label for="J_City_025006">丽江市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="025007" id="my_City_025007" class="J_City"><label for="J_City_025007">思茅市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="025008" id="my_City_025008" class="J_City"><label for="J_City_025008">临沧市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="025009" id="my_City_025009" class="J_City"><label for="J_City_025009">楚雄自治州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="025010" id="my_City_025010" class="J_City"><label for="J_City_025010">红河自治州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="025011" id="my_City_025011" class="J_City"><label for="J_City_025011">文山自治州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="025012" id="my_City_025012" class="J_City"><label for="J_City_025012">西双版纳州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="025013" id="my_City_025013" class="J_City"><label for="J_City_025013">大理自治州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="025014" id="my_City_025014" class="J_City"><label for="J_City_025014">德宏自治州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="025015" id="my_City_025015" class="J_City"><label for="J_City_025015">怒江傈自治州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="025016" id="my_City_025016" class="J_City"><label for="J_City_025016">迪庆自治州</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="023" id="J_Province_023" class="J_Province">
                                    <label for="J_Province_023">
                                        四川省</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="023001" id="my_City_023001" class="J_City"><label for="J_City_023001">成都市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="023002" id="my_City_023002" class="J_City"><label for="J_City_023002">自贡市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="023003" id="my_City_023003" class="J_City"><label for="J_City_023003">攀枝花市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="023004" id="my_City_023004" class="J_City"><label for="J_City_023004">泸州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="023005" id="my_City_023005" class="J_City"><label for="J_City_023005">德阳市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="023006" id="my_City_023006" class="J_City"><label for="J_City_023006">绵阳市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="023007" id="my_City_023007" class="J_City"><label for="J_City_023007">广元市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="023008" id="my_City_023008" class="J_City"><label for="J_City_023008">遂宁市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="023009" id="my_City_023009" class="J_City"><label for="J_City_023009">内江市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="023010" id="my_City_023010" class="J_City"><label for="J_City_023010">乐山市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="023011" id="my_City_023011" class="J_City"><label for="J_City_023011">南充市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="023012" id="my_City_023012" class="J_City"><label for="J_City_023012">眉山市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="023013" id="my_City_023013" class="J_City"><label for="J_City_023013">宜宾市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="023014" id="my_City_023014" class="J_City"><label for="J_City_023014">广安市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="023015" id="my_City_023015" class="J_City"><label for="J_City_023015">达州市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="023016" id="my_City_023016" class="J_City"><label for="J_City_023016">雅安市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="023017" id="my_City_023017" class="J_City"><label for="J_City_023017">巴中市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="023018" id="my_City_023018" class="J_City"><label for="J_City_023018">资阳市</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="023019" id="my_City_023019" class="J_City"><label for="J_City_023019">阿坝自治州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="023020" id="my_City_023020" class="J_City"><label for="J_City_023020">甘孜自治州</label></span>
                                        <span class="areas">
                                            <input type="checkbox" value="023021" id="my_City_023021" class="J_City"><label for="J_City_023021">凉山自治州</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="022" id="J_Province_022" class="J_Province">
                                    <label for="J_Province_022">
                                        重庆市</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="022001" id="my_City_022001" class="J_City"><label for="J_City_022001">重庆辖区</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                        </div>
                    </div>
                </li>
                <li class="even">
                    <div class=" dcity clearfix">
                        <div class="ecity gcity">
                            <span class="group-label">
                                <input type="checkbox" value="" class="J_Group" id="J_Group_8">
                                <label for="J_Group_8">
                                    港澳台</label>
                            </span>
                        </div>
                        <div class="province-list">
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="034" id="J_Province_034" class="J_Province">
                                    <label for="J_Province_034">
                                        澳门</label>
                                    <span class="check_num"></span><em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="034" id="J_City_034" class="J_City">
                                            <label for="J_City_034">
                                                澳门</label>
                                        </span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button">
                                        </p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="033" id="J_Province_033" class="J_Province">
                                    <label for="J_Province_033">
                                        香港特区</label><span class="check_num"></span> <em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="033001" id="my_City_033001" class="J_City"><label for="J_City_033001">铜锣湾</label></span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button"></p>
                                    </div>
                                </span>
                            </div>
                            <div class="ecity">
                                <span class="gareas">
                                    <input type="checkbox" value="032" id="J_Province_032" class="J_Province">
                                    <label for="J_Province_032">
                                        台湾</label>
                                    <span class="check_num"></span><em class="zt trigger"></em>
                                    <div class="citys">
                                        <span class="areas">
                                            <input type="checkbox" value="032" id="J_City_032" class="J_City">
                                            <label for="J_City_032">
                                                新竹</label>
                                        </span>
                                        <p style="text-align: right;">
                                            <input type="button" value="关闭" class="close_button">
                                        </p>
                                    </div>
                                </span>
                            </div>
                        </div>
                    </div>
                </li>
            </ul>
            <div class="ks-stdmod-footer">
                <a href="javascript:void(0)" class="ks-ext-close"><span class="ks-ext-close-x">关闭</span></a></div>
            <div class="btns">
                <button type="button" class="J_Submit">
                    确定</button>
                <button type="button" class="J_Cancel">
                    取消</button>
            </div>
        </div>
    </div>
</div>
