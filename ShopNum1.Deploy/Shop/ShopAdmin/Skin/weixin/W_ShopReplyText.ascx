<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="tjsp_mian">
    <p class="ptitle">
        <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">添加文字回复</span></p>
    <div class="box_content">
        <div class="control_group">
            <label class="control_label">
                关键词：</label>
            <div class="controls">
                <asp:TextBox ID="txt_keyword" title="多个关键词请用空格格开：例如: 美丽 漂亮 好看" class="textwb" value=""
                    MaxLength="30" data-rule-required="true" name="keyword" runat="server"></asp:TextBox>
                <br />
                <span class="maroon">*</span><span class="help_inline">必填, 多个关键词请用空格格开：例如: 美丽 漂亮 好看</span>
            </div>
        </div>
        <div class="control_group">
            <label class="control_label">
                关键词类型：</label>
            <div class="controls">
                <label class="radio">
                    <asp:RadioButton ID="rbtn_accurate" value="0" GroupName="match_type" runat="server"
                        Checked="true" />
                    <span>完全匹配，用户输入的和此关键词一样才会触发!</span>
                </label>
                <label class="radio">
                    <asp:RadioButton ID="rbtn_vague" value="1" GroupName="match_type" runat="server" />
                    <span>模糊匹配，只要用户输入的文字包含本关键词就触发!</span>
                </label>
            </div>
        </div>
        <div class="control_group" id="textreply">
            <label class="control_label" for="reply">
                自动回复内容：</label>
            <div class="controls">
                <div class="txtArea">
                    <div class="functionBar">
                        <div class="opt">
                            <a class="icon" href="javascript:;">表情</a>
                        </div>
                        <div class="tip">
                        </div>
                        <div class="emotions">
                            <table cellspacing="0" cellpadding="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <div class="eItem" style="background-position: 0px 0;" data-title="微笑" data-gifurl="/JS/emotion/Images/0.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -24px 0;" data-title="撇嘴" data-gifurl="/JS/emotion/Images/1.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -48px 0;" data-title="色" data-gifurl="/JS/emotion/Images/2.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -72px 0;" data-title="发呆" data-gifurl="/JS/emotion/Images/3.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -96px 0;" data-title="得意" data-gifurl="/JS/emotion/Images/4.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -120px 0;" data-title="流泪" data-gifurl="/JS/emotion/Images/5.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -144px 0;" data-title="害羞" data-gifurl="/JS/emotion/Images/6.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -168px 0;" data-title="闭嘴" data-gifurl="/JS/emotion/Images/7.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -192px 0;" data-title="睡" data-gifurl="/JS/emotion/Images/8.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -216px 0;" data-title="大哭" data-gifurl="/JS/emotion/Images/9.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -240px 0;" data-title="尴尬" data-gifurl="/JS/emotion/Images/10.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -264px 0;" data-title="发怒" data-gifurl="/JS/emotion/Images/11.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -288px 0;" data-title="调皮" data-gifurl="/JS/emotion/Images/12.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -312px 0;" data-title="呲牙" data-gifurl="/JS/emotion/Images/13.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -336px 0;" data-title="惊讶" data-gifurl="/JS/emotion/Images/14.gif">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="eItem" style="background-position: -360px 0;" data-title="难过" data-gifurl="/JS/emotion/Images/15.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -384px 0;" data-title="酷" data-gifurl="/JS/emotion/Images/16.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -408px 0;" data-title="冷汗" data-gifurl="/JS/emotion/Images/17.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -432px 0;" data-title="抓狂" data-gifurl="/JS/emotion/Images/18.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -456px 0;" data-title="吐" data-gifurl="/JS/emotion/Images/19.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -480px 0;" data-title="偷笑" data-gifurl="/JS/emotion/Images/20.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -504px 0;" data-title="可爱" data-gifurl="/JS/emotion/Images/21.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -528px 0;" data-title="白眼" data-gifurl="/JS/emotion/Images/22.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -552px 0;" data-title="傲慢" data-gifurl="/JS/emotion/Images/23.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -576px 0;" data-title="饥饿" data-gifurl="/JS/emotion/Images/24.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -600px 0;" data-title="困" data-gifurl="/JS/emotion/Images/25.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -624px 0;" data-title="惊恐" data-gifurl="/JS/emotion/Images/26.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -648px 0;" data-title="流汗" data-gifurl="/JS/emotion/Images/27.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -672px 0;" data-title="憨笑" data-gifurl="/JS/emotion/Images/28.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -696px 0;" data-title="大兵" data-gifurl="/JS/emotion/Images/29.gif">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="eItem" style="background-position: -720px 0;" data-title="奋斗" data-gifurl="/JS/emotion/Images/30.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -744px 0;" data-title="咒骂" data-gifurl="/JS/emotion/Images/31.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -768px 0;" data-title="疑问" data-gifurl="/JS/emotion/Images/32.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -792px 0;" data-title="嘘" data-gifurl="/JS/emotion/Images/33.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -816px 0;" data-title="晕" data-gifurl="/JS/emotion/Images/34.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -840px 0;" data-title="折磨" data-gifurl="/JS/emotion/Images/35.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -864px 0;" data-title="衰" data-gifurl="/JS/emotion/Images/36.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -888px 0;" data-title="骷髅" data-gifurl="/JS/emotion/Images/37.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -912px 0;" data-title="敲打" data-gifurl="/JS/emotion/Images/38.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -936px 0;" data-title="再见" data-gifurl="/JS/emotion/Images/39.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -960px 0;" data-title="擦汗" data-gifurl="/JS/emotion/Images/40.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -984px 0;" data-title="抠鼻" data-gifurl="/JS/emotion/Images/41.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1008px 0;" data-title="鼓掌" data-gifurl="/JS/emotion/Images/42.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1032px 0;" data-title="糗大了" data-gifurl="/JS/emotion/Images/43.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1056px 0;" data-title="坏笑" data-gifurl="/JS/emotion/Images/44.gif">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="eItem" style="background-position: -1080px 0;" data-title="左哼哼" data-gifurl="/JS/emotion/Images/45.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1104px 0;" data-title="右哼哼" data-gifurl="/JS/emotion/Images/46.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1128px 0;" data-title="哈欠" data-gifurl="/JS/emotion/Images/47.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1152px 0;" data-title="鄙视" data-gifurl="/JS/emotion/Images/48.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1176px 0;" data-title="委屈" data-gifurl="/JS/emotion/Images/49.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1200px 0;" data-title="快哭了" data-gifurl="/JS/emotion/Images/50.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1224px 0;" data-title="阴险" data-gifurl="/JS/emotion/Images/51.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1248px 0;" data-title="亲亲" data-gifurl="/JS/emotion/Images/52.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1272px 0;" data-title="吓" data-gifurl="/JS/emotion/Images/53.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1296px 0;" data-title="可怜" data-gifurl="/JS/emotion/Images/54.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1320px 0;" data-title="菜刀" data-gifurl="/JS/emotion/Images/55.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1344px 0;" data-title="西瓜" data-gifurl="/JS/emotion/Images/56.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1368px 0;" data-title="啤酒" data-gifurl="/JS/emotion/Images/57.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1392px 0;" data-title="篮球" data-gifurl="/JS/emotion/Images/58.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1416px 0;" data-title="乒乓" data-gifurl="/JS/emotion/Images/59.gif">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="eItem" style="background-position: -1440px 0;" data-title="咖啡" data-gifurl="/JS/emotion/Images/60.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1464px 0;" data-title="饭" data-gifurl="/JS/emotion/Images/61.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1488px 0;" data-title="猪头" data-gifurl="/JS/emotion/Images/62.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1512px 0;" data-title="玫瑰" data-gifurl="/JS/emotion/Images/63.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1536px 0;" data-title="凋谢" data-gifurl="/JS/emotion/Images/64.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1560px 0;" data-title="示爱" data-gifurl="/JS/emotion/Images/65.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1584px 0;" data-title="爱心" data-gifurl="/JS/emotion/Images/66.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1608px 0;" data-title="心碎" data-gifurl="/JS/emotion/Images/67.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1632px 0;" data-title="蛋糕" data-gifurl="/JS/emotion/Images/68.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1656px 0;" data-title="闪电" data-gifurl="/JS/emotion/Images/69.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1680px 0;" data-title="炸弹" data-gifurl="/JS/emotion/Images/70.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1704px 0;" data-title="刀" data-gifurl="/JS/emotion/Images/71.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1728px 0;" data-title="足球" data-gifurl="/JS/emotion/Images/72.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1752px 0;" data-title="瓢虫" data-gifurl="/JS/emotion/Images/73.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1776px 0;" data-title="便便" data-gifurl="/JS/emotion/Images/74.gif">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="eItem" style="background-position: -1800px 0;" data-title="月亮" data-gifurl="/JS/emotion/Images/75.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1824px 0;" data-title="太阳" data-gifurl="/JS/emotion/Images/76.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1848px 0;" data-title="礼物" data-gifurl="/JS/emotion/Images/77.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1872px 0;" data-title="拥抱" data-gifurl="/JS/emotion/Images/78.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1896px 0;" data-title="强" data-gifurl="/JS/emotion/Images/79.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1920px 0;" data-title="弱" data-gifurl="/JS/emotion/Images/80.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1944px 0;" data-title="握手" data-gifurl="/JS/emotion/Images/81.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1968px 0;" data-title="胜利" data-gifurl="/JS/emotion/Images/82.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -1992px 0;" data-title="抱拳" data-gifurl="/JS/emotion/Images/83.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -2016px 0;" data-title="勾引" data-gifurl="/JS/emotion/Images/84.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -2040px 0;" data-title="拳头" data-gifurl="/JS/emotion/Images/85.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -2064px 0;" data-title="差劲" data-gifurl="/JS/emotion/Images/86.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -2088px 0;" data-title="爱你" data-gifurl="/JS/emotion/Images/87.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -2112px 0;" data-title="NO" data-gifurl="/JS/emotion/Images/88.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -2136px 0;" data-title="OK" data-gifurl="/JS/emotion/Images/89.gif">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="eItem" style="background-position: -2160px 0;" data-title="爱情" data-gifurl="/JS/emotion/Images/90.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -2184px 0;" data-title="飞吻" data-gifurl="/JS/emotion/Images/91.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -2208px 0;" data-title="跳跳" data-gifurl="/JS/emotion/Images/92.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -2232px 0;" data-title="发抖" data-gifurl="/JS/emotion/Images/93.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -2256px 0;" data-title="怄火" data-gifurl="/JS/emotion/Images/94.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -2280px 0;" data-title="转圈" data-gifurl="/JS/emotion/Images/95.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -2304px 0;" data-title="磕头" data-gifurl="/JS/emotion/Images/96.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -2328px 0;" data-title="回头" data-gifurl="/JS/emotion/Images/97.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -2352px 0;" data-title="跳绳" data-gifurl="/JS/emotion/Images/98.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -2376px 0;" data-title="挥手" data-gifurl="/JS/emotion/Images/99.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -2400px 0;" data-title="激动" data-gifurl="/JS/emotion/Images/100.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -2424px 0;" data-title="街舞" data-gifurl="/JS/emotion/Images/101.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -2448px 0;" data-title="献吻" data-gifurl="/JS/emotion/Images/102.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -2472px 0;" data-title="右太极" data-gifurl="/JS/emotion/Images/103.gif">
                                            </div>
                                        </td>
                                        <td>
                                            <div class="eItem" style="background-position: -2496px 0;" data-title="左太极" data-gifurl="/JS/emotion/Images/104.gif">
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <div class="emotionsGif">
                            </div>
                        </div>
                        <div class="clr">
                        </div>
                    </div>
                    <div class="editArea">
                        <asp:TextBox ID="txt_content" name="txt_content" Style="display: none; word-break: break-all;"
                            title="first tooltip" runat="server" TextMode="MultiLine" MaxLength="300"></asp:TextBox>
                        <div id="div_content" contenteditable="true" style="height: 100px; overflow-x: hidden;
                            overflow-y: auto; width: 450px; word-break: break-all;">
                        </div>
                    </div>
                </div>
                <span class="maroon">*</span><span class="help_inline">必填, 用户提问时您的自动回复语;</span>
                <br />
                <span class="help_inline">&nbsp;&nbsp;链接添加形式，如：&lt;a href="http://www.baidu.com"&gt;百度&lt;/a&gt;</span>
                <br />
                <asp:Label class="help_inline" ID="lbl_waplink" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="form_actions">
            <button type="button" class="btn_primary" id="bsubmit">
                保存</button>
        </div>
        <asp:HiddenField ID="hid_ruleid" runat="server" Value="0" />
    </div>
</div>
<script type="text/javascript">

    $(function () {

        if ($("#<%= hid_ruleid.ClientID %>").val() != "0") {
            $(".breadcrume_text").text("编辑关键字回复");
        }

        var $textarea = $(".editArea textarea");
        var $contentDiv = $(".editArea div");
        $(".functionBar .icon").click(function () {
            //Emotion.saveRange();
            $(".emotions").show();
        });
        $(".emotions").hover(function () {
        }, function () {
            $(".emotions").fadeOut();
        });
        $(".emotions .eItem").mouseenter(function () {
            $(".emotionsGif").html('<img src="' + $(this).attr("data-gifurl") + '">');
        }).click(function () {
            Emotion.insertHTML('<img src="' + $(this).attr("data-gifurl") + '"' + 'alt="mo-' + $(this).attr("data-title") + '"' + "/>");
            $(".emotions").fadeOut();
            $textarea.trigger("contentValueChange");
        });
        $contentDiv.bind("keyup", function () {
            $textarea.trigger("contentValueChange");
            Emotion.saveRange();
        }).bind("keydown", function (e) {
            switch (e.keyCode) {
                case 8:
                    var t = Emotion.getSelection();
                    t.type && t.type.toLowerCase() === "control" && (e.preventDefault(), t.clear());
                    break;
                case 13:
                    e.preventDefault(),
                Emotion.insertHTML("<br/>");
                    Emotion.saveRange();
            }
        }).bind("mouseup", function (e) {
            Emotion.saveRange();
            if ($.browser.msie && />$/.test($contentDiv.html())) {
                var n = Emotion.getSelection();
                n.extend && (n.extend(cursorNode, cursorNode.length), n.collapseToEnd()),
                Emotion.saveRange();
                Emotion.insertHTML(" ");
            }
        });
        $textarea.bind("contentValueChange", function () {
            $(this).val(Emotion.replaceInput($contentDiv.html()));
        });
        $contentDiv.html(Emotion.replaceEmoji($contentDiv.html()));
        var data_content = $("#<%= txt_content.ClientID %>").val();
        if (data_content.length > 0) {
            $("#<%= txt_content.ClientID %>").val(data_content);
            $contentDiv.html(Emotion.replaceEmoji(data_content));
        }


        $("#bsubmit").click(function () {

            //关键字
            var keys = $.trim($("#<%= txt_keyword.ClientID %>").val());
            //匹配类型
            var msgtype = $("input[type=radio]:checked").val(); //回复内容
            var content = $.trim($("#<%= txt_content.ClientID %>").val());
            //规则ID
            var ruleid = $("#<%= hid_ruleid.ClientID %>").val();

            if (keys.length == 0) {
                alert("关键字不能为空！");
                return false;
            }

            if (content.length == 0) {
                alert("回复内容不能为空！");
                return false;
            }

            if (content.length > 300) {
                alert("回复内容不能超过300个字符！");
                return false;
            }
            $.ajax({
                cache: false,
                url: "/api/ShopAdmin/api_reply.ashx",
                data: {
                    keys: keys,
                    msgtype: msgtype,
                    content: content,
                    ruleid: ruleid,
                    type: "op_replytxt"
                },
                dataType: "json",
                success: function (result) {
                    alert(result.errmsg);

                    if (result.errcode == "0") {
                        setTimeout(function () {
                            window.location.href = "W_ShopReplyTextList.aspx";
                        }, 1000);
                    }
                }
            });
        });
    });
</script>
