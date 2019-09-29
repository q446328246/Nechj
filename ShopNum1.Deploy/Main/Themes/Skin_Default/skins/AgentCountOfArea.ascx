<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<div class="MapContainer clearfix" id="agentareacount">
    <div class="all">
        <form name="searchform" id="searchform" action="sites_details_query.asp" method="get">
        <div style="display: block; background: url(Themes/Skin_Default/images/stomap.png) no-repeat 0 0;
            position: relative; padding: 0px; width: 850px; height: 713px;">
            <canvas width="850" height="713" style="width: 850px; height: 713px; position: absolute;
                left: 0px; top: 0px; padding: 0px; border: 0px none; opacity: 0.818712;"></canvas>
            <img class="maphilighted" style="opacity: 0; position: absolute; left: 0px; top: 0px;
                padding: 0px; border: 0px none;" src="Themes/Skin_Default/images/stomap.png"
                id="MAP_IMAGE" usemap="#planetmap">
        </div>
        <map name="planetmap" id="planetmap">
            <area shape="polygon" coords="114,168,122,172,119,176,120,203,111,208,107,221,83,227,72,233,55,231,46,240,38,238,34,232,31,235,26,231,8,241,2,251,3,256,1,261,3,265,7,264,15,272,12,291,9,291,4,293,20,308,19,323,47,339,66,332,73,337,77,344,83,345,103,356,113,348,128,354,143,359,150,356,163,356,178,349,189,350,200,347,220,355,228,354,238,359,251,353,246,352,246,346,249,344,256,336,242,325,241,316,248,312,286,305,291,302,296,302,294,276,297,272,314,262,337,251,336,243,339,242,325,210,319,208,299,192,283,192,265,185,263,178,269,168,271,158,261,134,258,134,254,128,244,128,245,124,237,116,232,110,235,101,222,100,216,113,206,116,203,119,200,137,189,142,185,139,181,139,167,132,151,161,154,168,141,166,141,163,121,164"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=031")%>" alt="新疆">
            <area shape="polygon" coords="47,338,47,352,55,360,54,366,52,383,59,387,57,399,50,400,44,395,38,397,44,408,42,420,47,420,62,434,63,438,74,451,80,448,110,469,110,476,117,473,120,478,119,484,131,490,136,495,147,503,147,505,162,506,168,513,193,512,194,516,193,520,195,525,212,508,228,513,242,516,245,522,260,518,274,509,277,509,296,498,306,503,319,497,323,498,319,506,325,504,327,507,323,514,339,519,343,516,354,520,358,518,361,520,362,508,369,501,368,478,362,463,366,460,356,441,344,433,339,436,340,441,331,452,314,450,312,444,300,434,262,428,253,422,234,416,222,393,222,385,227,383,226,375,231,364,225,363,232,356,225,355,205,348,193,351,180,350,163,357,153,354,145,360,127,351,113,348,104,355,80,345,71,336,67,333"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=026")%>" alt="西藏">
            <area shape="polygon" coords="241,316,242,328,257,335,251,343,246,345,249,352,250,355,239,359,230,355,228,361,231,366,227,371,226,381,222,384,222,397,233,417,255,423,265,431,302,436,311,446,315,450,331,453,339,440,340,435,344,432,348,424,367,422,378,427,385,424,393,436,401,438,404,426,412,426,422,427,426,419,422,416,413,409,405,408,403,402,409,404,415,405,416,402,416,394,425,386,422,381,432,375,434,365,428,360,428,355,417,336,411,340,393,326,388,313,382,317,363,308,357,312,346,311,335,317,333,317,318,309,291,303,250,312"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=029")%>" alt="青海">
            <area shape="polygon" coords="434,405,421,412,422,417,425,419,423,427,419,426,412,429,411,426,411,424,402,427,402,431,402,433,395,437,388,431,386,428,385,424,378,426,365,423,349,425,345,431,349,436,357,443,366,460,362,462,369,480,368,493,368,503,372,520,380,520,383,514,388,519,385,524,390,527,397,531,412,562,419,565,428,558,430,562,435,556,434,540,443,529,443,522,448,520,448,516,452,513,458,517,456,522,461,527,469,525,475,529,487,532,491,528,490,524,482,518,485,513,489,513,488,501,480,496,483,480,509,468,516,451,510,448,514,442,504,438,500,431,485,435,484,430,475,431,474,434,472,438,460,434,456,431,457,426,451,425,437,417"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=023")%>" alt="四川">
            <area shape="polygon" coords="513,442,507,446,515,452,509,468,487,479,480,496,489,503,488,512,501,516,502,507,509,507,511,500,523,502,527,510,535,517,539,514,541,500,532,488,529,487,528,479,524,478,529,473,541,470,547,466,550,464,550,450,545,447,538,448,531,445,523,440"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=022")%>" alt="重庆">
            <area shape="polygon" coords="354,522,355,533,359,534,362,540,360,565,345,579,343,585,339,590,343,599,341,603,362,602,359,608,363,618,373,621,371,628,368,638,381,643,381,647,387,655,394,652,402,649,405,660,415,660,415,645,412,638,415,634,422,635,428,629,438,633,444,629,446,631,451,629,455,632,460,628,469,627,476,620,475,617,482,617,487,615,492,602,477,602,474,596,466,596,462,589,465,576,461,573,463,554,459,553,453,553,447,545,450,539,458,538,473,539,475,528,473,524,465,528,459,526,458,520,456,516,451,513,449,517,445,522,445,531,436,540,436,554,430,560,427,558,417,561,413,564,397,532,393,529,387,528,385,523,388,518,384,515,379,520,374,521,368,503,362,510"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=025")%>" alt="云南">
            <area shape="polygon" coords="476,530,471,538,457,538,452,538,448,543,450,552,463,553,463,558,458,571,465,578,463,590,470,590,473,584,491,592,494,585,511,572,520,577,529,571,539,570,549,560,544,552,548,541,545,538,538,538,545,528,539,515,535,517,526,506,524,502,518,503,512,500,509,507,502,507,498,515,491,511,485,510,481,519,492,524,492,530,484,530"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=024")%>" alt="贵州">
            <area shape="polygon" coords="474,585,470,590,464,591,464,595,474,597,476,601,492,602,493,610,488,613,484,616,486,622,491,626,494,621,500,624,505,627,503,634,505,641,518,647,534,647,536,643,546,647,561,647,568,639,570,639,569,633,577,633,577,626,588,618,588,605,595,596,593,592,597,588,593,581,587,584,584,574,578,577,585,563,582,561,578,559,581,555,576,552,567,552,565,559,561,560,558,555,552,560,542,566,536,573,531,570,524,578,512,572,493,585,491,591"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=020")%>" alt="广西">
            <area shape="polygon" coords="296,303,320,308,331,315,341,317,347,310,359,311,365,310,380,320,388,315,393,325,411,339,416,336,429,354,433,367,430,378,425,382,426,386,418,394,418,405,412,405,406,402,402,405,410,409,419,419,422,417,422,408,435,406,438,415,449,426,454,424,456,428,457,433,467,437,475,435,473,432,481,429,482,424,479,419,489,416,489,410,491,402,487,399,493,390,490,388,498,389,507,390,510,383,520,382,523,378,520,373,523,367,522,362,500,350,491,350,489,363,495,369,494,375,487,376,487,382,480,380,479,377,472,372,472,367,469,358,459,343,455,343,443,338,441,328,449,325,450,318,451,313,447,308,439,304,427,314,409,316,401,311,401,304,396,304,386,294,395,288,396,281,388,276,375,279,363,284,354,265,354,257,351,248,351,241,337,242,337,252,316,259,305,267,297,274,295,287"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=028")%>" alt="甘肃">
            <area shape="polygon" coords="458,344,469,356,473,370,470,374,478,378,480,383,489,385,488,376,494,374,496,369,490,363,490,351,499,348,502,340,503,333,490,325,492,316,491,304,482,308,474,334,466,340"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=030")%>" alt="宁夏">
            <area shape="polygon" coords="500,341,500,352,523,363,524,369,519,372,521,381,511,384,510,389,502,389,493,386,491,389,488,400,494,403,488,410,492,417,484,418,481,422,485,425,482,429,487,437,501,431,503,437,517,444,525,440,533,444,539,451,544,447,541,437,551,429,544,424,540,420,558,419,564,415,563,412,549,392,554,374,546,346,552,337,545,327,552,318,556,311,554,302,552,300,548,304,542,304,535,310,536,318,532,318,518,336"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=027")%>" alt="陕西">
            <area shape="polygon" coords="540,422,550,429,545,433,543,437,542,446,551,451,552,465,547,467,539,473,529,474,526,477,529,483,530,489,542,499,552,487,559,492,565,486,559,481,584,479,592,487,599,484,603,490,613,482,614,491,623,497,623,489,631,485,643,477,652,473,647,459,650,454,634,443,626,446,623,443,613,443,610,435,605,430,603,436,600,433,585,434,578,433,563,419,561,423"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=017")%>" alt="湖北">
            <area shape="polygon" coords="541,501,540,516,544,528,537,540,547,540,545,551,550,560,556,560,559,556,563,559,570,552,575,553,581,554,581,560,585,562,578,578,584,575,588,580,596,582,599,573,611,573,612,566,617,564,627,567,628,562,628,554,628,542,625,539,623,528,619,527,618,515,624,513,625,504,620,494,616,492,614,483,611,479,602,488,600,484,592,488,581,481,560,480,565,488,559,490,552,488"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=018")%>" alt="湖南">
            <area shape="polygon" coords="640,563,631,566,626,564,621,566,616,563,610,569,610,575,602,572,599,573,597,577,594,581,597,590,594,593,593,597,586,605,586,616,577,625,578,630,572,634,568,637,559,642,561,650,559,660,566,671,573,666,569,657,582,646,597,643,600,636,613,637,621,631,628,626,627,615,635,619,647,615,653,614,660,612,664,608,670,608,677,605,680,597,688,590,690,588,680,574,662,568,663,576,655,575,636,579,636,577"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=019")%>" alt="广东">
            <area shape="polygon" coords="553,301,555,309,553,313,553,318,546,327,553,337,548,347,552,370,550,387,553,393,564,389,578,379,594,375,597,369,600,359,597,351,600,344,601,333,603,330,595,317,596,306,603,300,605,293,601,286,604,277,598,275,589,280,581,280,575,281,566,293,562,297"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=004")%>" alt="山西">
            <area shape="polygon" coords="599,355,599,371,590,378,582,377,565,391,550,391,563,414,563,419,574,428,581,434,591,434,600,432,605,434,607,431,612,440,623,442,631,445,636,445,640,440,645,437,645,430,643,424,639,428,627,416,631,413,632,408,635,402,637,396,641,398,651,394,649,391,645,386,641,384,633,384,623,377,624,372,636,358,630,359,625,355,620,358"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=016")%>" alt="河南">
            <area shape="polygon" coords="646,384,643,385,652,391,651,396,645,398,637,394,636,399,636,407,633,409,633,414,629,414,626,416,637,427,642,424,645,436,640,442,638,445,647,452,648,464,654,472,665,470,667,474,664,477,671,477,674,471,680,477,689,480,698,467,698,459,706,456,705,452,708,445,708,440,696,439,693,435,685,424,689,422,689,418,695,417,694,411,691,409,687,412,681,411,674,406,676,398,666,395,661,392,655,387"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=012")%>" alt="安徽">
            <area shape="polygon" coords="665,468,651,474,641,476,630,486,618,492,626,501,626,510,619,517,618,526,624,530,622,540,628,542,628,555,625,563,635,567,645,565,637,580,656,574,663,576,664,564,665,554,669,538,672,529,676,521,680,510,684,506,687,510,697,500,688,480,691,479,677,476,675,471,666,477,664,478"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=014")%>" alt="江西">
            <area shape="polygon" coords="696,500,684,510,683,510,676,518,679,525,671,531,672,540,662,558,663,571,671,570,679,575,689,592,694,586,703,575,699,571,708,567,712,568,710,563,716,562,717,556,721,551,719,548,724,548,725,530,722,523,727,522,728,524,734,511,728,514,719,507,713,512,709,513,704,499"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=013")%>" alt="福建">
            <area shape="polygon" coords="658,10,653,8,645,15,640,25,646,27,648,27,651,38,646,44,639,73,641,77,623,93,609,89,602,121,599,122,603,132,611,129,622,129,626,123,634,121,645,127,659,141,658,146,638,147,635,150,630,151,626,156,618,158,614,165,610,172,600,179,595,179,586,189,578,193,564,191,560,188,553,196,552,203,558,216,548,226,537,239,520,245,497,246,470,257,460,265,458,263,454,258,438,258,421,252,417,247,391,243,385,247,353,243,351,249,354,254,354,268,364,283,368,283,375,278,394,279,396,285,394,287,386,295,386,297,395,304,402,305,402,310,407,314,423,317,429,315,437,305,448,308,452,314,450,318,451,322,442,329,442,334,445,340,455,343,464,342,473,335,479,312,489,304,492,316,489,324,489,328,504,333,503,336,516,336,516,338,531,318,536,314,537,307,541,303,548,302,554,299,555,300,561,296,564,296,573,282,577,282,585,278,585,280,597,274,590,264,597,245,603,243,605,246,604,251,608,254,618,246,620,246,625,244,633,243,633,241,631,237,638,230,644,229,651,239,652,242,657,251,668,250,669,245,667,230,669,227,673,231,679,237,687,226,690,226,697,220,699,220,704,215,707,215,709,212,716,212,726,202,724,198,722,196,721,189,711,180,703,186,700,186,699,179,696,175,696,161,688,156,688,151,700,155,701,149,704,144,703,139,705,137,710,133,710,131,704,134,693,124,710,97,715,103,714,85,721,81,718,62,723,42,709,34,700,44,694,44,691,47,682,46,676,35,676,28,670,25,666,30,656,25,660,14"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=005")%>" alt="内蒙古">
            <area shape="polygon" coords="630,260,626,267,625,272,620,282,618,290,626,289,636,288,645,286,646,275,643,266"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=001")%>" alt="北京">
            <area shape="polygon" coords="648,276,645,280,639,287,641,302,650,306,654,303,654,292,657,286"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=002")%>" alt="天津">
            <area shape="polygon" coords="600,245,592,259,591,266,598,275,602,280,602,291,607,294,602,299,597,305,594,316,601,328,602,334,600,341,597,349,601,358,612,359,624,355,628,354,625,349,641,324,647,321,655,317,656,311,654,305,642,306,638,288,634,291,625,290,618,291,618,283,624,273,631,261,640,265,646,267,645,278,650,277,651,287,666,290,671,287,676,278,679,271,678,264,670,262,666,257,668,247,656,248,650,244,653,238,646,230,634,235,634,244,623,244,618,247,607,253"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=003")%>" alt="河北">
            <area shape="polygon" coords="658,312,650,320,642,321,621,350,627,356,637,358,620,376,630,384,645,383,648,378,651,377,661,384,671,379,676,383,682,377,683,369,688,369,701,349,698,344,703,343,719,329,730,323,730,314,713,315,707,309,699,312,685,328,675,326,674,314,668,314"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=015")%>" alt="山东">
            <area shape="polygon" coords="689,368,683,370,683,375,679,377,677,384,671,379,666,382,660,381,651,377,648,378,653,384,658,389,671,394,676,397,676,403,681,413,687,411,692,409,696,411,694,416,688,417,690,421,685,427,693,436,707,442,709,438,725,445,732,437,735,429,717,421,733,422,739,422,738,418,734,416,731,410,721,405,707,379"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=010")%>" alt="江苏">
            <area shape="polygon" coords="734,430,730,439,733,444,744,437,741,432" href="<%= GetPageName.RetUrlMore("shoparea","areacode=009")%>"
                alt="上海">
            <area shape="polygon" coords="707,442,706,449,705,453,706,459,699,459,700,466,696,475,689,482,694,491,699,499,703,499,709,510,716,510,719,508,722,511,734,510,742,491,747,490,748,486,747,481,749,477,748,472,750,468,750,458,735,453,728,454,724,452,730,451,734,444,731,441,727,440,724,445,715,441"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=011")%>" alt="浙江">
            <area shape="polygon" coords="658,9,662,16,656,25,665,30,670,24,676,29,675,36,682,44,696,46,696,41,710,34,723,44,718,66,720,79,714,86,715,104,710,98,692,123,699,132,709,132,704,139,703,146,716,143,722,154,727,158,736,152,742,150,747,155,759,152,764,157,767,163,772,162,778,169,780,165,783,158,785,169,792,173,797,175,807,163,809,165,813,163,816,168,827,168,825,161,818,143,825,130,841,131,843,128,842,121,845,114,844,82,848,75,845,69,844,62,840,63,830,73,825,74,818,83,803,89,795,83,796,80,790,69,771,62,767,65,762,61,753,62,746,59,741,50,741,47,731,35,724,24,716,13,713,5,703,1,694,5,676,1"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=008")%>" alt="黑龙江">
            <area shape="polygon" coords="713,144,706,145,703,151,702,156,689,153,689,158,693,164,696,174,702,185,711,178,722,191,721,196,726,199,730,196,734,201,739,205,744,200,753,218,755,225,760,232,762,239,768,234,776,217,782,222,798,219,793,208,803,203,806,194,813,196,814,180,820,187,828,170,815,166,810,160,808,167,804,166,795,173,789,167,784,166,781,159,777,165,779,170,770,162,761,162,764,159,759,153,749,155,741,150,735,153,728,154,727,156,721,149"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=007")%>" alt="吉林">
            <area shape="polygon" coords="724,198,724,206,714,213,709,212,707,215,703,217,698,222,694,223,688,227,681,236,675,230,671,228,669,231,670,244,667,258,674,264,680,266,680,273,695,258,699,251,709,249,713,255,704,276,710,280,708,288,710,287,723,273,747,260,763,237,761,233,756,223,754,216,743,200,738,205,732,197"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=006")%>" alt="辽宁">
            <area shape="polygon" coords="579,673,574,676,556,679,544,689,542,697,546,707,562,713,577,700,577,694,585,680"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=021")%>" alt="海南">
            <area shape="polygon" coords="761,545,768,549,767,566,762,600,761,602,760,610,758,610,753,604,748,600,743,588,743,577,751,554"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=032")%>" alt="台湾">
            <area shape="polygon" coords="644,617,640,622,633,621,632,624,634,627,643,629,647,626"
                href="<%= GetPageName.RetUrlMore("shoparea","areacode=033")%>" alt="香港">
            <area shape="rect" coords="613,634,645,653" href="<%= GetPageName.RetUrlMore("shoparea","areacode=034")%>"
                alt="澳门">
        </map>
        <div class="xj" areacode="031">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=031")%>" style="color: #ffffff;
                    text-decoration: none;">新疆</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="xz" areacode="026">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=026")%>" style="color: #ffffff;
                    text-decoration: none;">西藏</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="qh" areacode="029">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=029")%>" style="color: #ffffff;
                    text-decoration: none;">青海</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="sc" areacode="023">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=023")%>" style="color: #ffffff;
                    text-decoration: none;">四川</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="yn" areacode="025">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=025")%>" style="color: #ffffff;
                    text-decoration: none;">云南</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="gz" areacode="024">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=024")%>" style="color: #ffffff;
                    text-decoration: none;">贵州</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="gx" areacode="020">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=020")%>" style="color: #ffffff;
                    text-decoration: none;">广西</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="hn" areacode="018">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=018")%>" style="color: #ffffff;
                    text-decoration: none;">湖南</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="hb" areacode="017">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=017")%>" style="color: #ffffff;
                    text-decoration: none;">湖北</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="jl" areacode="007">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=007")%>" style="color: #ffffff;
                    text-decoration: none;">吉林</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="nl" areacode="006">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=006")%>" style="color: #ffffff;
                    text-decoration: none;">辽宁</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="jx" areacode="014">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=014")%>" style="color: #ffffff;
                    text-decoration: none;">江西</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="gd" areacode="019">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=019")%>" style="color: #ffffff;
                    text-decoration: none;">广东</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="fj" areacode="013">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=013")%>" style="color: #ffffff;
                    text-decoration: none;">福建</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="zj" areacode="011">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=011")%>" style="color: #ffffff;
                    text-decoration: none;">浙江</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="ah" areacode="012">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=012")%>" style="color: #ffffff;
                    text-decoration: none;">安徽</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="js" areacode="010">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=010")%>" style="color: #ffffff;
                    text-decoration: none;">江苏</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="sd" areacode="015">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=015")%>" style="color: #ffffff;
                    text-decoration: none;">山东</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="hen" areacode="016">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=016")%>" style="color: #ffffff;
                    text-decoration: none;">河南</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="cq" areacode="022">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=022")%>" style="color: #ffffff;
                    text-decoration: none;">重庆</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="sanx" areacode="027">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=027")%>" style="color: #ffffff;
                    text-decoration: none;">陕西</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="sx" areacode="004">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=004")%>" style="color: #ffffff;
                    text-decoration: none;">山西</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="gs" areacode="028">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=028")%>" style="color: #ffffff;
                    text-decoration: none;">甘肃</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="nxia" areacode="030">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=030")%>" style="color: #ffffff;
                    text-decoration: none;">宁夏</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="han" areacode="021">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=021")%>" style="color: #ffffff;
                    text-decoration: none;">海南</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="tw" areacode="032">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=032")%>" style="color: #ffffff;
                    text-decoration: none;">台湾</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="xg" areacode="033">
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=033")%>" style="color: #ffffff;
                    text-decoration: none;">香港</a></div>
        </div>
        <div class="aom" areacode="034">
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
            <div style="clear: both">
            </div>
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=034")%>" style="color: #ffffff;
                    text-decoration: none;">澳门</a></div>
        </div>
        <div class="shai" areacode="009">
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=009")%>" style="color: #ffffff;
                    text-decoration: none;">上海</a></div>
        </div>
        <div class="heb" areacode="003">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=003")%>" style="color: #ffffff;
                    text-decoration: none;">河北</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="bj" areacode="001">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=001")%>" style="color: #ffffff;
                    text-decoration: none;">北京</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="tj" areacode="002">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=002")%>" style="color: #ffffff;
                    text-decoration: none;">天津</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="nmg" areacode="005">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=005")%>" style="color: #ffffff;
                    text-decoration: none;">内蒙古</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="hlj" areacode="008">
            <div class="title">
                <a href="<%= GetPageName.RetUrlMore("shoparea","areacode=008")%>" style="color: #ffffff;
                    text-decoration: none;">黑龙江</a></div>
            <div class="img">
                <img src="Themes/Skin_Default/images/icon.jpg" /></div>
            <div class="shuliang">
                0个</div>
        </div>
        <div class="diqu">
            店铺地区分布图</div>
        </form>
    </div>
</div>
<div id="agentcountofarea" style="display: none;">
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <span areacode="<%#Eval("Level1code") %>">
                <%#Eval("agentcount") %>个</span>
        </ItemTemplate>
    </asp:Repeater>
</div>
<script src="../../../js/jquery-maphilight.js" type="text/javascript"></script>
<%--<script type="text/javascript" src="Themes/Skin_Default/Js/jquery-maphilight.js"></script>--%>
<script type="text/javascript">

    $(document).ready(

		function () {
		    $.fn.maphilight.defaults = {
		        fill: true,
		        fillColor: 'fbd9ac',
		        fillOpacity: 1,
		        stroke: true,
		        strokeColor: 'fbd9ac',
		        strokeOpacity: 1,
		        strokeWidth: 4,
		        fade: true,
		        alwaysOn: false,
		        neverOn: false,
		        groupBy: false
		    }
		    $("#MAP_IMAGE").maphilight();
		    //绑定区域分销商数量
		    $("#agentareacount .all div[areacode]").each(function () {
		        var bindareacode = $("#agentcountofarea span[areacode='" + $(this).attr("areacode") + "']");

		        if (bindareacode != null && bindareacode != undefined && bindareacode.length > 0) {
		            $(this).find(".shuliang:eq(0)").text(bindareacode.text());
		        }
		    })

		}
	);		
</script>
