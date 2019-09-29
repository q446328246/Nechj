(function($) {
    $.extend($.browser, {
        client: function() {
            return {
                width: document.documentElement.clientWidth,
                height: document.documentElement.clientHeight,
                bodyWidth: document.body.clientWidth,
                bodyHeight: document.body.clientHeight
            };
        },
        scroll: function() {
            return {
                width: document.documentElement.scrollWidth,
                height: document.documentElement.scrollHeight,
                bodyWidth: document.body.scrollWidth,
                bodyHeight: document.body.scrollHeight,
                left: document.documentElement.scrollLeft,
                top: document.documentElement.scrollTop
            };
        },
        screen: function() {
            return {
                width: window.screen.width,
                height: window.screen.height
            };
        },
        isIE6: $.browser.msie && $.browser.version == 6,
        isMinW: function(val) {
            return Math.min($.browser.client().bodyWidth, $.browser.client().width) <= val;
        },
        isMinH: function(val) {
            return $.browser.client().height <= val;
        }
    })
})(jQuery); (function($) {
    $.widthForIE6 = function(option) {
        var s = $.extend({
            max: null,
            min: null,
            padding: 0
        },
        option || {});
        var init = function() {
            var w = $(document.body);
            if ($.browser.client().width >= s.max + s.padding) {
                w.width(s.max + "px");
            } else if ($.browser.client().width <= s.min + s.padding) {
                w.width(s.min + "px");
            } else {
                w.width("auto");
            }
        };
        init();
        $(window).resize(init);
    }
})(jQuery); (function($) {
    $.fn.hoverForIE6 = function(option) {
        var s = $.extend({
            current: "hover",
            delay: 10
        },
        option || {});
        $.each(this,
        function() {
            var timer1 = null,
            timer2 = null,
            flag = false;
            $(this).bind("mouseover",
            function() {
                if (flag) {
                    clearTimeout(timer2);
                } else {
                    var _this = $(this);
                    timer1 = setTimeout(function() {
                        _this.addClass(s.current);
                        flag = true;
                    },
                    s.delay);
                }
            }).bind("mouseout",
            function() {
                if (flag) {
                    var _this = $(this);
                    timer2 = setTimeout(function() {
                        _this.removeClass(s.current);
                        flag = false;
                    },
                    s.delay);
                } else {
                    clearTimeout(timer1);
                }
            })
        })
    }
})(jQuery); (function($) {
    $.extend({
        _jsonp: {
            scripts: {},
            counter: 1,
            head: document.getElementsByTagName("head")[0],
            name: function(callback) {
                var name = '_jsonp_' + (new Date).getTime() + '_' + this.counter;
                this.counter++;
                var cb = function(json) {
                    eval('delete ' + name);
                    callback(json);
                    $._jsonp.head.removeChild($._jsonp.scripts[name]);
                    delete $._jsonp.scripts[name];
                };
                eval(name + ' = cb');
                return name;
            },
            load: function(url, name) {
                var script = document.createElement('script');
                script.type = 'text/javascript';
                script.charset = this.charset;
                script.src = url;
                this.head.appendChild(script);
                this.scripts[name] = script;
            }
        },
        getJSONP: function(url, callback) {
            var name = $._jsonp.name(callback);
            var url = url.replace(/{callback};/, name);
            $._jsonp.load(url, name);
            return this;
        }
    });
})(jQuery); (function($) {
    $.fn.jdTab = function(option, callback) {
        if (typeof option == "function") {
            callback = option;
            option = {};
        };
        var s = $.extend({
            type: "static",
            auto: false,
            source: "data",
            event: "mouseover",
            currClass: "curr",
            tab: ".tab",
            content: ".tabcon",
            itemTag: "li",
            stay: 5000,
            delay: 100,
            mainTimer: null,
            subTimer: null,
            index: 0
        },
        option || {});
        var tabItem = $(this).find(s.tab).eq(0).find(s.itemTag),
        contentItem = $(this).find(s.content);
        if (tabItem.length != contentItem.length) return false;
        var reg = s.source.toLowerCase().match(/http:\/\/|\d|\.aspx|\.ascx|\.asp|\.php|\.html\.htm|.shtml|.js|\W/g);
        var init = function(n, tag) {
            s.subTimer = setTimeout(function() {
                hide();
                if (tag) {
                    s.index++;
                    if (s.index == tabItem.length) s.index = 0;
                } else {
                    s.index = n;
                };
                s.type = (tabItem.eq(s.index).attr(s.source) != null) ? "dynamic": "static";
                show();
            },
            s.delay);
        };
        var autoSwitch = function() {
            s.mainTimer = setInterval(function() {
                init(s.index, true);
            },
            s.stay);
        };
        var show = function() {
            tabItem.eq(s.index).addClass(s.currClass);
            switch (s.type) {
            default:
            case "static":
                var source = "";
                break;
            case "dynamic":
                var source = (reg == null) ? tabItem.eq(s.index).attr(s.source) : s.source;
                tabItem.eq(s.index).removeAttr(s.source);
                break;
            };
            if (callback) {
                callback(source, contentItem.eq(s.index), s.index);
            };
            contentItem.eq(s.index).show();
        };
        var hide = function() {
            tabItem.eq(s.index).removeClass(s.currClass);
            contentItem.eq(s.index).hide();
        };
        tabItem.each(function(n) {
            $(this).bind(s.event,
            function() {
                clearTimeout(s.subTimer);
                clearInterval(s.mainTimer);
                init(n, false);
                return false;
            }).bind("mouseleave",
            function() {
                if (s.auto) {
                    autoSwitch();
                } else {
                    return;
                }
            })
        });
        if (s.type == "dynamic") {
            init(s.index, false);
        };
        if (s.auto) {
            autoSwitch();
        }
    }
})(jQuery); (function($) {
    $.fn.jdSlide = function(option) {
        var settings = $.extend({
            width: null,
            height: null,
            pics: [],
            index: 0,
            type: "num",
            current: "curr",
            delay1: 200,
            delay2: 8000
        },
        option || {});
        var element = this;
        var timer1, timer2, timer3, flag = true;
        var total = settings.pics.length;
        var init = function() {
            var img = "<ul style='position:absolute;top:0;left:0;'><li><a href='" + settings.pics[0].href + "' target='_blank'><img src='" + settings.pics[0].src + "' width='" + settings.width + "' height='" + settings.height + "' /></a></li></ul>";
            element.css({
                "position": "relative"
            }).html(img);
            $(function() {
                delayLoad();
            })
        };
        init();
        var initIndex = function() {
            var indexs = "<div>";
            var current;
            var x;
            for (var i = 0; i < total; i++) {
                current = (i == settings.index) ? settings.current: "";
                switch (settings.type) {
                case "num":
                    x = i + 1;
                    break;
                case "string":
                    x = settings.pics[i].alt;
                    break;
                case "image":
                    x = "<img src='" + settings.pics[i].breviary + "' />";
                default:
                    break;
                };
                indexs += "<span class='" + current + "'><a href='" + settings.pics[i].href + "' target='_blank'>" + x + "</a></span>";
            };
            indexs += "</div>";
            element.append(indexs);
            element.find("span").bind("mouseover",
            function(e) {
                clearInterval(timer1);
                clearInterval(timer3);
                var index = element.find("span").index(this);
                if (index == settings.index) {
                    return;
                } else {
                    timer3 = setInterval(function() {
                        if (flag) running(parseInt(index));
                    },
                    settings.delay1);
                }
            }).bind("mouseleave",
            function(e) {
                clearInterval(timer3);
                timer1 = setInterval(function() {
                    running(settings.index + 1, true);
                },
                settings.delay2);
            })
        };
        var running = function(index, tag) {
            if (index == total) {
                index = 0;
            };
            element.find("span").eq(settings.index).removeClass(settings.current);
            element.find("span").eq(index).addClass(settings.current);
            timer2 = setInterval(function() {
                var pos_y = parseInt(element.find("ul").get(0).style.top);
                var pos_a = Math.abs(pos_y + settings.index * settings.height);
                var pos_b = Math.abs(index - settings.index) * settings.height;
                var pos_c = Math.ceil((pos_b - pos_a) / 4);
                if (pos_a == pos_b) {
                    clearInterval(timer2);
                    if (tag) {
                        settings.index++;
                        if (settings.index == total) {
                            settings.index = 0;
                        }
                    } else {
                        settings.index = index;
                    };
                    flag = true;
                } else {
                    if (settings.index < index) {
                        element.find("ul").css({
                            top: pos_y - pos_c + "px"
                        });
                    } else {
                        element.find("ul").css({
                            top: pos_y + pos_c + "px"
                        });
                    };
                    flag = false;
                }
            },
            10);
        };
        var delayLoad = function() {
            var img = "";
            for (var i = 1; i < total; i++) {
                img += "<li><a href='" + settings.pics[i].href + "' target='_blank'><img src='" + settings.pics[i].src + "' width='" + settings.width + "' height='" + settings.height + "' /></a></li>";
            };
            element.find("ul").append(img);
            timer1 = setInterval(function() {
                running(settings.index + 1, true);
            },
            settings.delay2);
            if (settings.type) initIndex();
        };
    }
})(jQuery);
function ResumeError() {
    return true;
}
window.onerror = ResumeError;
if ($.browser.isIE6) {
    try {
        document.execCommand("BackgroundImageCache", false, true);
    } catch(err) {}
};
var calluri = "http://fairyservice.360buy.com/WebService.asmx/MarkEx?callback=?";
var loguri = "http://csc.360buy.com/log.ashx?type1=$type1$&type2=$type2$&data=$data$&callback=?";
callback1 = function(data) {;
};
log = function(type1, type2, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10) {
    var data = '';
    for (i = 2; i < arguments.length; i++) {
        data = data + arguments[i] + '|||';
    }
    var url = loguri.replace(/\$type1\$/, escape(type1));
    url = url.replace(/\$type2\$/, escape(type2));
    url = url.replace(/\$data\$/, escape(data));
    $.getJSON(url, callback1);
};
mark = function(sku, type) {
    $.getJSON(calluri, {
        sku: sku,
        type: type
    },
    callback1);
    log(1, type, sku);
};
function search(id) {
    var selKey = document.getElementById(id).value;
    window.location = 'http://search.360buy.com/Search?keyword=' + selKey;
}
function login() {
    location.href = "https://passport.360buy.com/new/login.aspx?ReturnUrl=" + escape(location.href);
    return false;
}
function regist() {
    location.href = "https://passport.360buy.com/new/registpersonal.aspx?ReturnUrl=" + escape(location.href);
    return false;
}
function setWebBILinkCount(sType) {
    try {
        if (sType.length > 0) {
            var js = document.createElement('script');
            js.type = 'text/javascript';
            js.src = 'http://counter.360buy.com/aclk.aspx?key=' + sType;
            document.getElementsByTagName('head')[0].appendChild(js);
        }
    } catch(e) {}
};
function gi_ga(s, name) {
    if (typeof(s) == "undefined") {
        return "";
    };
    s = "^" + s + "^";
    var b = s.indexOf("^" + name + "=");
    if ( - 1 == b) {
        return "";
    } else {
        b += name.length + 2;
    };
    var e = s.indexOf("^", b);
    return s.substring(b, e);
};
function gi_get_monitor_code(k, p) {
    return '<object classid="clsid:D27CDB6E-AE6D-11CF-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0" border="0" width="0" height="0"><param name="movie" value="http://js.miaozhen.com/a.swf"><param name="allowScriptAccess" value="always"><param name="FlashVars" value="caId=' + k + '&SPID=' + p + '&loc=' + document.location.href + '&ref=' + document.referrer + '"><embed src="http://js.miaozhen.com/a.swf" pluginspage="http://www.macromedia.com/go/getflashplayer" allowScriptAccess="always" type="application/x-shockwave-flash" width="0" height="0" FlashVars="caId=' + k + '&SPID=' + p + '&loc=' + document.location.href + '&ref=' + document.referrer + '"></embed></object>';
};
var gi_normal__ = new Object();
gi_normal__.deliver = function(arg) {
    if (arg.gi_automatchscreen && screen.width >= 1280) {
        arg.gi_width = arg.gi_width_w;
    };
    var ad = "";
    if (arg.gi_isautomonitorclick) {
        ad = '<div style="position: absolute; width: ' + arg.gi_width + 'px; height: ' + arg.gi_height + 'px; cursor: pointer; background-color: rgb(255, 255, 255); opacity: 0; filter:alpha(opacity=0);" onclick="window.open(\'' + arg.gi_ldp + '\',\'_blank\')"></div>';
    };
    if (arg.gi_type == "img") {
        ad += "<a target=\"_blank\" href=\"" + arg.gi_ldp + "\"><img height=\"" + arg.gi_height + "\" width=\"" + arg.gi_width + "\" border=\"0\" src=\"" + ((arg.gi_width == arg.gi_width_w) ? (arg.gi_src_w) : (arg.gi_src)) + "\"/></a>";
    } else if (arg.gi_type == "flash") {
        ad += '<embed src="' + ((arg.gi_width == arg.gi_width_w) ? (arg.gi_src_w) : (arg.gi_src)) + '" width="' + arg.gi_width + '" height="' + arg.gi_height + '" type="application/x-shockwave-flash" play="true" loop="true" menu="true" wmode="transparent"></embed>';
    };
    var gi_k = gi_ga(arg.gi_ldp, "k");
    var gi_p = gi_ga(arg.gi_ldp, "p");
    document.getElementById("miaozhen" + arg.gi_pid).innerHTML += ad + gi_get_monitor_code(gi_k, gi_p);
};
gi_focus__ = new Object();
gi_focus__.next = function() {
    var arg = gi_focus__.arg;
    if (arg.gi_automatchscreen && screen.width >= 1280) {
        arg.gi_width = arg.gi_width_w;
    };
    var ad_arr = arg.gi_ad_arr;
    gi_focus__.now %= ad_arr.length;
    var html = '<div onmouseover="clearInterval(gi_focus__.timer);" onmouseout="gi_focus__.timer=setInterval(gi_focus__.next,gi_focus__.arg.gi_interval);" style="width: ' + arg.gi_width + 'px; height: ' + arg.gi_height + 'px; cursor: pointer; background-color: rgb(255, 255, 255); position: relative; " onclick="javascript:window.open(\'' + ad_arr[gi_focus__.now].gi_ldp + '\',\'_blank\')">';
    var i;
    var ad = '';
    if (ad_arr[gi_focus__.now].gi_type == "img") {
        var ad = '<img style="display: block" src="' + ((arg.gi_width == arg.gi_width_w) ? (ad_arr[gi_focus__.now].gi_src_w) : (ad_arr[gi_focus__.now].gi_src)) + '" width="' + arg.gi_width + 'px" height="' + arg.gi_height + 'px" />';
    } else if (ad_arr[gi_focus__.now].gi_type == "flash") {
        var ad = '<embed src="' + ((arg.gi_width == arg.gi_width_w) ? (ad_arr[gi_focus__.now].gi_src_w) : (ad_arr[gi_focus__.now].gi_src)) + '" width="' + arg.gi_width + '" height="' + arg.gi_height + '" type="application/x-shockwave-flash" play="true" loop="true" menu="true" wmode="transparent"></embed>';
    };
    html = html + ad;
    for (i = 0; i < ad_arr.length; i++) {
        if (i == gi_focus__.now) {
            html += '<div onmouseover="gi_focus__.now=' + i + ';gi_focus__.next();" style="border: 1px solid #3b81cd; right:' + (18 * (ad_arr.length - i) - 18) + 'px; bottom: 0px; position: absolute; z-index: 10; width:15px;height:16px; cursor: pointer; background-color: #3b81cd; opacity: 1; filter:alpha(opacity=100); color:white; font-family:Arial; font-size:11px; text-align: center; vertical-align:middle; ">' + (i + 1) + '</div>';
        } else {
            html += '<div onmouseover="gi_focus__.now=' + i + ';gi_focus__.next();" style="border: 1px solid #3b81cd; right:' + (18 * (ad_arr.length - i) - 18) + 'px; bottom: 0px; position: absolute; z-index: 10; width:15px;height:16px; cursor: pointer; background-color: rgb(255, 255, 255); opacity: 1; filter:alpha(opacity=100); font-family:Arial; font-size:11px; text-align: center; vertical-align:middle; " >' + (i + 1) + '</div>';
        }
    };
    html += '</div>';
    document.getElementById("miaozhen" + arg.gi_pid).innerHTML = html;
    gi_focus__.now++;
};
gi_focus__.deliver = function(arg) {
    gi_focus__.arg = arg;
    var ad_arr = arg.gi_ad_arr;
    var newElement = document.createElement("div");
    newElement.innerHTML = gi_get_monitor_code(gi_ga(ad_arr[0].gi_ldp, "k"), gi_ga(ad_arr[0].gi_ldp, "p"));
    document.getElementById("miaozhen" + arg.gi_pid).parentNode.appendChild(newElement);
    gi_focus__.now = 0;
    gi_focus__.timer = setInterval(gi_focus__.next, arg.gi_interval);
    gi_focus__.next();
};
var gi_rotate__ = new Object();
gi_rotate__.deliver = function(arg) {
    var ad_arr = arg.gi_ad_arr;
    var i = ad_arr[0][Math.floor(Math.random() * ad_arr[0].l)];
    if (arg.gi_automatchscreen && screen.width >= 1280) {
        arg.gi_width = arg.gi_width_w;
    };
    var click = '<div style="position: absolute; width: ' + arg.gi_width + 'px; height: ' + arg.gi_height + 'px; cursor: ';
    click += 'pointer; background-color: rgb(255, 255, 255); opacity: 0; filter:alpha(opacity=0);" ';
    click += 'onclick="javascript:window.open(\'' + ad_arr[i].gi_ldp + '\',\'_blank\')"></div>';
    if (ad_arr[i].gi_type == "img") {
        var ad = '<img src="' + ((arg.gi_width == arg.gi_width_w) ? (ad_arr[i].gi_src_w) : (ad_arr[i].gi_src)) + '" width="' + arg.gi_width + '" height="' + arg.gi_height + '" />';
    } else if (ad_arr[i].gi_type == "flash") {
        var ad = '<embed src="' + ((arg.gi_width == arg.gi_width_w) ? (ad_arr[i].gi_src_w) : (ad_arr[i].gi_src)) + '" width="' + arg.gi_width + '" height="' + arg.gi_height + '" type="application/x-shockwave-flash" play="true" loop="true" menu="true" wmode="transparent"></embed>';
    };
    ad = click + ad;
    var gi_k = gi_ga(ad_arr[i].gi_ldp, "k");
    var gi_p = gi_ga(ad_arr[i].gi_ldp, "p");
    document.getElementById("miaozhen" + arg.gi_pid).innerHTML += ad + gi_get_monitor_code(gi_k, gi_p);;
};
var initScrollY = 0;
var proIDs = new Array();

/*jqueryzoom&&jcarousel*/
(function($) {
    $.fn.jqueryzoom = function(options) {
        var settings = {
            xzoom: 200,
            yzoom: 200,
            offset: 10,
            position: "right",
            lens: 1,
            preload: 1
        };
        if (options) {
            $.extend(settings, options);
        }
        var noalt = '';
        $(this).hover(function() {
            var imageLeft = $(this).offset().left;
            var imageTop = $(this).offset().top;
            var imageWidth = $(this).children('img').get(0).offsetWidth;
            var imageHeight = $(this).children('img').get(0).offsetHeight;
            noalt = $(this).children("img").attr("alt");
            var bigimage = $(this).children("img").attr("jqimg");
            $(this).children("img").attr("alt", '');
            if ($("div.zoomdiv").get().length == 0) {
                $(this).after("<div class='zoomdiv'><img class='bigimg' src='" + bigimage + "'/></div>");
                $(this).append("<div class='jqZoomPup'>&nbsp;</div>");
            }
            if (settings.position == "right") {
                if (imageLeft + imageWidth + settings.offset + settings.xzoom > screen.width) {
                    leftpos = imageLeft - settings.offset - settings.xzoom;
                } else {
                    leftpos = imageLeft + imageWidth + settings.offset;
                }
            } else {
                leftpos = imageLeft - settings.xzoom - settings.offset;
                if (leftpos < 0) {
                    leftpos = imageLeft + imageWidth + settings.offset;
                }
            }
            $("div.zoomdiv").css({
                top: imageTop,
                left: leftpos
            });
            $("div.zoomdiv").width(settings.xzoom);
            $("div.zoomdiv").height(settings.yzoom);
            $("div.zoomdiv").show();
            if (!settings.lens) {
                $(this).css('cursor', 'crosshair');
            }
            $(document.body).mousemove(function(e) {
                mouse = new MouseEvent(e);
                var bigwidth = $(".bigimg").get(0).offsetWidth;
                var bigheight = $(".bigimg").get(0).offsetHeight;
                var scaley = 'x';
                var scalex = 'y';
                if (isNaN(scalex) | isNaN(scaley)) {
                    var scalex = (bigwidth / imageWidth);
                    var scaley = (bigheight / imageHeight);
                    $("div.jqZoomPup").width((settings.xzoom) / (scalex * 1));
                    $("div.jqZoomPup").height((settings.yzoom) / (scaley * 1));
                    if (settings.lens) {
                        $("div.jqZoomPup").css('visibility', 'visible');
                    }
                }
                xpos = mouse.x - $("div.jqZoomPup").width() / 2 - imageLeft;
                ypos = mouse.y - $("div.jqZoomPup").height() / 2 - imageTop;
                if (settings.lens) {
                    xpos = (mouse.x - $("div.jqZoomPup").width() / 2 < imageLeft) ? 0 : (mouse.x + $("div.jqZoomPup").width() / 2 > imageWidth + imageLeft) ? (imageWidth - $("div.jqZoomPup").width() - 2) : xpos;
                    ypos = (mouse.y - $("div.jqZoomPup").height() / 2 < imageTop) ? 0 : (mouse.y + $("div.jqZoomPup").height() / 2 > imageHeight + imageTop) ? (imageHeight - $("div.jqZoomPup").height() - 2) : ypos;
                }
                if (settings.lens) {
                    $("div.jqZoomPup").css({
                        top: ypos,
                        left: xpos
                    });
                }
                scrolly = ypos;
                $("div.zoomdiv").get(0).scrollTop = scrolly * scaley;
                scrollx = xpos;
                $("div.zoomdiv").get(0).scrollLeft = (scrollx) * scalex;
            });
        },
        function() {
            $(this).children("img").attr("alt", noalt);
            $(document.body).unbind("mousemove");
            if (settings.lens) {
                $("div.jqZoomPup").remove();
            }
            $("div.zoomdiv").remove();
        });
        count = 0;
        if (settings.preload) {
            $('body').append("<div style='display:none;' class='jqPreload" + count + "'></div>");
            $(this).each(function() {
                var imagetopreload = $(this).children("img").attr("jqimg");
                var content = jQuery('div.jqPreload' + count + '').html();
                jQuery('div.jqPreload' + count + '').html(content + '<img src=\"' + imagetopreload + '\">');
            });
        }
    }
})(jQuery);
function MouseEvent(e) {
    this.x = e.pageX;
    this.y = e.pageY;
}

/*pagination*/
jQuery.fn.pagination = function(maxentries, opts) {
    opts = jQuery.extend({
        items_per_page: 10,
        num_display_entries: 10,
        current_page: 0,
        num_edge_entries: 0,
        link_to: "#",
        prev_text: "Prev",
        next_text: "Next",
        ellipse_text: "...",
        prev_show_always: true,
        next_show_always: true,
        callback: function() {
            return false;
        }
    },
    opts || {});
    return this.each(function() {
        function numPages() {
            return Math.ceil(maxentries / opts.items_per_page);
        }
        function getInterval() {
            var ne_half = Math.ceil(opts.num_display_entries / 2);
            var np = numPages();
            var upper_limit = np - opts.num_display_entries;
            var start = current_page > ne_half ? Math.max(Math.min(current_page - ne_half, upper_limit), 0) : 0;
            var end = current_page > ne_half ? Math.min(current_page + ne_half, np) : Math.min(opts.num_display_entries, np);
            return [start, end];
        }
        function pageSelected(page_id, evt) {
            current_page = page_id;
            drawLinks();
            var continuePropagation = opts.callback(page_id, panel);
            if (!continuePropagation) {
                if (evt.stopPropagation) {
                    evt.stopPropagation();
                } else {
                    evt.cancelBubble = true;
                }
            }
            return continuePropagation;
        }
        function drawLinks() {
            panel.empty();
            var interval = getInterval();
            var np = numPages();
            if (np == 1) {
                $(".Pagination").css({
                    display: "none"
                });
            }
            var getClickHandler = function(page_id) {
                return function(evt) {
                    return pageSelected(page_id, evt);
                }
            }
            var appendItem = function(page_id, appendopts) {
                page_id = page_id < 0 ? 0 : (page_id < np ? page_id: np - 1);
                appendopts = jQuery.extend({
                    text: page_id + 1,
                    classes: ""
                },
                appendopts || {});
                if (page_id == current_page) {
                    var lnk = $("<a href='javascript:void(0)' class='current'>" + (appendopts.text) + "</a>");
                } else {
                    var lnk = $("<a>" + (appendopts.text) + "</a>").bind("click", getClickHandler(page_id)).attr('href', opts.link_to.replace(/__id__/, page_id));
                }
                if (appendopts.classes) {
                    lnk.addClass(appendopts.classes);
                }
                panel.append(lnk);
            }
            if (opts.prev_text && (current_page > 0 || opts.prev_show_always)) {
                appendItem(current_page - 1, {
                    text: opts.prev_text,
                    classes: "prev"
                });
            }
            if (interval[0] > 0 && opts.num_edge_entries > 0) {
                var end = Math.min(opts.num_edge_entries, interval[0]);
                for (var i = 0; i < end; i++) {
                    appendItem(i);
                }
                if (opts.num_edge_entries < interval[0] && opts.ellipse_text) {
                    jQuery("<span>" + opts.ellipse_text + "</span>").appendTo(panel);
                }
            }
            for (var i = interval[0]; i < interval[1]; i++) {
                appendItem(i);
            }
            if (interval[1] < np && opts.num_edge_entries > 0) {
                if (np - opts.num_edge_entries > interval[1] && opts.ellipse_text) {
                    jQuery("<span>" + opts.ellipse_text + "</span>").appendTo(panel);
                }
                var begin = Math.max(np - opts.num_edge_entries, interval[1]);
                for (var i = begin; i < np; i++) {
                    appendItem(i);
                }
            }
            if (opts.next_text && (current_page < np - 1 || opts.next_show_always)) {
                appendItem(current_page + 1, {
                    text: opts.next_text,
                    classes: "next"
                });
            }
        }
        var current_page = opts.current_page;
        maxentries = (!maxentries || maxentries < 0) ? 1 : maxentries;
        opts.items_per_page = (!opts.items_per_page || opts.items_per_page < 0) ? 1 : opts.items_per_page;
        var panel = jQuery(this);
        this.selectPage = function(page_id) {
            pageSelected(page_id);
        }
        this.prevPage = function() {
            if (current_page > 0) {
                pageSelected(current_page - 1);
                return true;
            } else {
                return false;
            }
        }
        this.nextPage = function() {
            if (current_page < numPages() - 1) {
                pageSelected(current_page + 1);
                return true;
            } else {
                return false;
            }
        }
        drawLinks();
    });
};

/*jdMarquee*/
(function($) {
    $.fn.jdMarquee = function(option, callback) {
        if (typeof option == "function") {
            callback = option;
            option = {};
        };
        var s = $.extend({
            deriction: "up",
            speed: 10,
            auto: false,
            width: null,
            height: null,
            step: 1,
            control: false,
            _front: null,
            _back: null,
            _stop: null,
            _continue: null,
            wrapstyle: "",
            stay: 5000,
            delay: 20,
            dom: "div>ul>li".split(">"),
            mainTimer: null,
            subTimer: null,
            tag: false,
            convert: false,
            btn: null,
            disabled: "disabled",
            pos: {
                ojbect: null,
                clone: null
            }
        },
        option || {});
        var object = this.find(s.dom[1]);
        var subObject = this.find(s.dom[2]);
        var clone;
        if (s.deriction == "up" || s.deriction == "down") {
            var height = object.eq(0).outerHeight();
            var step = s.step * subObject.eq(0).outerHeight();
            object.css({
                width: s.width + "px",
                overflow: "hidden"
            });
        };
        if (s.deriction == "left" || s.deriction == "right") {
//            var width = subObject.length * subObject.eq(0).outerWidth();
              var width = 350;//ul ¿í¶È
            object.css({
                width: width + "px",
                overflow: "hidden"
            });
//            var step = s.step * subObject.eq(0).outerWidth();
            var step=70;
         
        };
        var init = function() {
            var wrap = "<div style='position:relative;overflow:hidden;z-index:1;width:" + s.width + "px;height:" + s.height + "px;" + s.wrapstyle + "'></div>";
            object.css({
                position: "absolute",
                left: 0,
                top: 0
            }).wrap(wrap);
            s.pos.object = 0;
            clone = object.clone();
            object.after(clone);
            switch (s.deriction) {
            default:
            case "up":
                object.css({
                    marginLeft:
                    0,
                    marginTop: 0
                });
                clone.css({
                    marginLeft: 0,
                    marginTop: height + "px"
                });
                s.pos.clone = height;
                break;
            case "down":
                object.css({
                    marginLeft:
                    0,
                    marginTop: 0
                });
                clone.css({
                    marginLeft: 0,
                    marginTop: -height + "px"
                });
                s.pos.clone = -height;
                break;
            case "left":
                object.css({
                    marginTop:
                    0,
                    marginLeft: 0
                });
                clone.css({
                    marginTop: 0,
                    marginLeft: width + "px"
                });
                s.pos.clone = width;
                
                break;
            case "right":
                object.css({
                    marginTop:
                    0,
                    marginLeft: 0
                });
                clone.css({
                    marginTop: 0,
                    marginLeft: -width + "px"
                });
                s.pos.clone = -width;
                break;
            };
            if (s.auto) {
                initMainTimer();
                object.hover(function() {
                    clear(s.mainTimer);
                },
                function() {
                    initMainTimer();
                });
                clone.hover(function() {
                    clear(s.mainTimer);
                },
                function() {
                    initMainTimer();
                });
            };
            if (callback) {
                callback();
            };
            if (s.control) {
                initControls();
            }
        };
        var initMainTimer = function(delay) {
            clear(s.mainTimer);
            s.stay = delay ? delay: s.stay;
            s.mainTimer = setInterval(function() {
                initSubTimer()
            },
            s.stay);
        };
        var initSubTimer = function() {
            clear(s.subTimer);
            s.subTimer = setInterval(function() {
                roll()
            },
            s.delay);
        };
        var clear = function(timer) {
            if (timer != null) {
                clearInterval(timer);
            }
        };
        var disControl = function(A) {
            if (A) {
                $(s._front).unbind("click");
                $(s._back).unbind("click");
                $(s._stop).unbind("click");
                $(s._continue).unbind("click");
            } else {
                initControls();
            }
        };
        var initControls = function() {
            if (s._front != null) {
                $(s._front).click(function() {
                    $(s._front).addClass(s.disabled);
                    disControl(true);
                    clear(s.mainTimer);
                    s.convert = true;
                    s.btn = "front";
                    if (!s.auto) {
                        s.tag = true;
                    };
                    convert();
                });
            };
            if (s._back != null) {
                $(s._back).click(function() {
                    $(s._back).addClass(s.disabled);
                    disControl(true);
                    clear(s.mainTimer);
                    s.convert = true;
                    s.btn = "back";
                    if (!s.auto) {
                        s.tag = true;
                    };
                    convert();
                });
            };
            if (s._stop != null) {
                $(s._stop).click(function() {
                    clear(s.mainTimer);
                });
            };
            if (s._continue != null) {
                $(s._continue).click(function() {
                    initMainTimer();
                });
            }
        };
        var convert = function() {
            if (s.tag && s.convert) {
                s.convert = false;
                if (s.btn == "front") {
                    if (s.deriction == "down") {
                        s.deriction = "up";
                    };
                    if (s.deriction == "right") {
                        s.deriction = "left";
                    }
                };
                if (s.btn == "back") {
                    if (s.deriction == "up") {
                        s.deriction = "down";
                    };
                    if (s.deriction == "left") {
                        s.deriction = "right";
                    }
                };
                if (s.auto) {
                    initMainTimer();
                } else {
                    initMainTimer(4 * s.delay);
                }
            }
        };
        var setPos = function(y1, y2, x) {
            if (x) {
                clear(s.subTimer);
                s.pos.object = y1;
                s.pos.clone = y2;
                s.tag = true;
            } else {
                s.tag = false;
            };
            if (s.tag) {
                if (s.convert) {
                    convert();
                } else {
                    if (!s.auto) {
                        clear(s.mainTimer);
                    }
                }
            };
            if (s.deriction == "up" || s.deriction == "down") {
                object.css({
                    marginTop: y1 + "px"
                });
                clone.css({
                    marginTop: y2 + "px"
                });
            };
            if (s.deriction == "left" || s.deriction == "right") {
                object.css({
                    marginLeft: y1 + "px"
                });
                clone.css({
                    marginLeft: y2 + "px"
                });
            }
        };
        var roll = function() {
            var y_object = (s.deriction == "up" || s.deriction == "down") ? parseInt(object.get(0).style.marginTop) : parseInt(object.get(0).style.marginLeft);
            var y_clone = (s.deriction == "up" || s.deriction == "down") ? parseInt(clone.get(0).style.marginTop) : parseInt(clone.get(0).style.marginLeft);
            var y_add = Math.max(Math.abs(y_object - s.pos.object), Math.abs(y_clone - s.pos.clone));
            var y_ceil = Math.ceil((step - y_add) / s.speed);
            switch (s.deriction) {
            case "up":
                if (y_add == step) {
                    setPos(y_object, y_clone, true);
                    $(s._front).removeClass(s.disabled);
                    disControl(false);
                } else {
                    if (y_object <= -height) {
                        y_object = y_clone + height;
                        s.pos.object = y_object;
                    };
                    if (y_clone <= -height) {
                        y_clone = y_object + height;
                        s.pos.clone = y_clone;
                    };
                    setPos((y_object - y_ceil), (y_clone - y_ceil));
                };
                break;
            case "down":
                if (y_add == step) {
                    setPos(y_object, y_clone, true);
                    $(s._back).removeClass(s.disabled);
                    disControl(false);
                } else {
                    if (y_object >= height) {
                        y_object = y_clone - height;
                        s.pos.object = y_object;
                    };
                    if (y_clone >= height) {
                        y_clone = y_object - height;
                        s.pos.clone = y_clone;
                    };
                    setPos((y_object + y_ceil), (y_clone + y_ceil));
                };
                break;
            case "left":
                if (y_add == step) {
                    setPos(y_object, y_clone, true);
                    $(s._front).removeClass(s.disabled);
                    disControl(false);
                } else {
                    if (y_object <= -width) {
                        y_object = y_clone + width;
                        s.pos.object = y_object;
                    };
                    if (y_clone <= -width) {
                        y_clone = y_object + width;
                        s.pos.clone = y_clone;
                    };
                    setPos((y_object - y_ceil), (y_clone - y_ceil));
                };
                break;
            case "right":
                if (y_add == step) {
                    setPos(y_object, y_clone, true);
                    $(s._back).removeClass(s.disabled);
                    disControl(false);
                } else {
                    if (y_object >= width) {
                        y_object = y_clone - width;
                        s.pos.object = y_object;
                    };
                    if (y_clone >= width) {
                        y_clone = y_object - width;
                        s.pos.clone = y_clone;
                    };
                    setPos((y_object + y_ceil), (y_clone + y_ceil));
                };
                break;
            }
        };
        if (s.deriction == "up" || s.deriction == "down") {
            if (height >= s.height && height >= s.step) {
                init();
            }
        };
        if (s.deriction == "left" || s.deriction == "right") {
            if (width >= s.width && width >= s.step) {
                init();
            }
        }
    }
})(jQuery);