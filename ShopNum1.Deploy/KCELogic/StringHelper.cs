using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Xml;

namespace ShopNum1.Deploy.KCELogic
{
    public static class StringHelper
    {

        #region 变量
        /// <summary>
        /// 英文字母
        /// </summary>
        public static readonly List<string> LetterEN = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        /// <summary>
        /// 天干地支
        /// </summary>
        public static readonly List<string> LetterZH = new List<string>() { "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸", "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };
        #endregion

        #region 字符串格式转换

        /// <summary>
        /// 把撇号(')替换成空
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReplaceApostrophe(this string s)
        {
            s = s.Replace("'", "").Trim();
            return s;
        }

        /// <summary>
        /// 将decimal转换整数或一位小数
        /// </summary>
        /// <param name="s">原字符串</param>
        /// <returns></returns>
        public static string ToDecimalString(this decimal s)
        {
            string Result = "";
            string str = s.ToString("f1");
            if (str.Substring(str.Length - 1, 1) == "0")
            {
                Result = str.Substring(0, str.Length - 2);
            }
            else
            {
                Result = str;
            }
            return Result;
        }

        /// <summary>
        /// 将Guid转换成用于控件绑定初始值字符串格式
        /// </summary>
        /// <param name="s">原字符串</param>
        /// <returns></returns>
        public static string ToControlString(this Guid? s)
        {
            string Result = "";
            if (s != null)
            {
                string str = s.ToString();
                Result = str.Insert(str.Length, "'").Insert(0, "'");
            }
            return Result;
        }

        /// <summary>
        /// 将字符串转换成Byte格式
        /// </summary>
        /// <param name="s">原字符串</param>
        /// <returns></returns>
        public static Byte ToByte(this string s)
        {
            Byte Result = new Byte();
            Byte.TryParse(s, out Result);
            return Result;
        }



        /// <summary>
        /// 将字符串转换成Decimal格式
        /// </summary>
        /// <param name="s">原字符串</param>
        /// <returns></returns>
        public static Decimal ToDecimal(this string s)
        {
            Decimal Result = new Decimal();
            Decimal.TryParse(s, out Result);
            return Result;
        }

        /// <summary>
        /// 将字符串转换成时间格式
        /// </summary>
        /// <param name="s">原字符串</param>
        /// <returns></returns>
        public static DateTime ToDate(this string s)
        {
            DateTime date;
            if (!DateTime.TryParse(s, out date))
            {
                date = DateTime.Parse("1900-01-01");
            }
            return date;
        }

        /// <summary>
        /// 将字符串转换成完整TXT
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToTxt(this string s)
        {
            return s.Replace("\r\n", "</br>").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
        }

        ///<summary>
        ///把一个字符串截取成数据返回
        ///</summary>
        ///<param name="s">目标字符串</param>
        ///<param name="sep">分割标示符</param>
        ///<returns>返回一个分割出来的数组</returns>
        public static string[] ToArray(this string s, string sep)
        {
            int sepLen = sep.Length;
            ArrayList arr = new ArrayList();
            string item;
            int pos;

            if (sep != "")
            {
                while (true)
                {
                    pos = s.IndexOf(sep);
                    if (pos > 0)
                    {
                        item = s.Substring(0, pos);
                        arr.Add(item);
                        if (sepLen + pos >= s.Length) break;
                        s = s.Substring(sepLen + pos, s.Length - sepLen - pos);
                    }
                    else if (pos == 0)
                    {
                        if (sepLen >= s.Length) break;
                        s = s.Substring(sepLen, s.Length - sepLen);
                    }
                    else
                    {
                        if (s.Length > 0) arr.Add(s);
                        break;
                    }
                }
            }
            else
            {
                char[] arr_str = s.ToCharArray();
                for (int i = 0; i < arr_str.GetLength(0); i++)
                {
                    arr.Add(arr_str[i].ToString());
                }
            }

            string[] result = new string[arr.Count];
            arr.CopyTo(result);
            return result;
        }

        /// <summary>
        /// 将字符串转化成Byte[]
        /// </summary>
        public static Byte[] ToByteArray(this string s)
        {
            return Convert.FromBase64String(Convert.ToBase64String(Encoding.UTF8.GetBytes(s)));
        }

        /// <summary>
        /// 将Byte[]转化成字符串
        /// </summary>
        public static string ToByteString(this byte[] s)
        {
            return BitConverter.ToString(s);
        }


        /// <summary>
        /// 将字符串转化成XML
        /// </summary>
        public static XmlDocument ToXml(this string s)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(new System.IO.MemoryStream(System.Text.Encoding.GetEncoding("GB2312").GetBytes(s)));
            return xmldoc;
        }


        ///<summary>
        ///把一个字符串截取成数据返回
        ///</summary>
        ///<param name="s">目标字符串</param>
        ///<param name="sep">分割标示符</param>
        ///<returns>返回一个分割出来的Arraylist</returns>
        public static ArrayList ToArrayList(this string s, string sep)
        {
            int sepLen = sep.Length;
            ArrayList arr = new ArrayList();
            string item;
            int pos;

            if (sep != "")
            {
                while (true)
                {
                    pos = s.IndexOf(sep);
                    if (pos > 0)
                    {
                        item = s.Substring(0, pos);
                        arr.Add(item);
                        if (sepLen + pos >= s.Length) break;
                        s = s.Substring(sepLen + pos, s.Length - sepLen - pos);
                    }
                    else if (pos == 0)
                    {
                        if (sepLen >= s.Length) break;
                        s = s.Substring(sepLen, s.Length - sepLen);
                    }
                    else
                    {
                        if (s.Length > 0) arr.Add(s);
                        break;
                    }
                }
            }
            else
            {
                char[] arr_str = s.ToCharArray();
                for (int i = 0; i < arr_str.GetLength(0); i++)
                {
                    arr.Add(arr_str[i].ToString());
                }
            }

            return arr;
        }

        /// <summary>
        /// 将字符串转换成Long
        /// </summary>
        public static long ToLong(this string s)
        {
            long i;
            long.TryParse(s, out i);
            return i;
        }

        /// <summary>
        /// 将字符串s转化成Int32
        /// </summary>
        /// <param name="s">字符串s</param>
        /// <returns>Int32型数字</returns>
        public static int ToInt32(this string s)
        {
            int i;
            Int32.TryParse(s, out i);
            return i;
        }
        /// <summary>
        /// 去掉小数点
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToIntFloat(this string s)
        {
            if (s.Contains("."))
            {
                s = s.Remove(s.Length - (s.Length - s.IndexOf(".")), s.Length - s.IndexOf("."));
            }
            return int.Parse(s);
        }

        /// <summary>
        /// 将字符串s转化成布尔型
        /// </summary>
        public static bool ToBool(this string s)
        {
            bool Result;
            bool.TryParse(s, out Result);
            return Result;
        }

        /// <summary>
        /// 将字符串转换成Double
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns></returns>
        public static double ToDouble(this string s)
        {
            double Result;
            double.TryParse(s, out Result);
            return Result;
        }

        /// <summary>
        /// 将字符串转换成Float
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns></returns>
        public static float ToFloat(this string s)
        {
            float Result;
            float.TryParse(s, out Result);
            return Result;

        }

        ///// <summary>
        ///// 将简体中文转化成繁体中文
        ///// </summary>
        ///// <param name="str">简体中文字符串</param>
        ///// <returns>string</returns>
        //public static string ConvertToTraditionalChinese(this string str)
        //{
        //    return Microsoft.VisualBasic.Strings.StrConv(str, VbStrConv.TraditionalChinese, System.Globalization.CultureInfo.CurrentUICulture.LCID);
        //}

        ///// <summary>
        ///// 将繁体中文转化成简体中文
        ///// </summary>
        ///// <param name="str">繁体中文字符串</param>
        ///// <returns>string</returns>
        //public static string ConvertToSimplifiedChinese(this string str)
        //{
        //    return Microsoft.VisualBasic.Strings.StrConv(str, VbStrConv.SimplifiedChinese, System.Globalization.CultureInfo.CurrentUICulture.LCID);
        //}

        /// <summary>
        /// 将指定字符串中的汉字转换为拼音首字母的缩写，其中非汉字保留为原字符
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ConvertSpellFirst(this string text)
        {
            char pinyin;
            byte[] array;
            StringBuilder sb = new StringBuilder(text.Length);
            foreach (char c in text)
            {
                pinyin = c;
                array = Encoding.Default.GetBytes(new char[] { c });

                if (array.Length == 2)
                {
                    int i = array[0] * 0x100 + array[1];

                    if (i < 0xB0A1) pinyin = c;
                    else
                        if (i < 0xB0C5) pinyin = 'a';
                    else
                            if (i < 0xB2C1) pinyin = 'b';
                    else
                                if (i < 0xB4EE) pinyin = 'c';
                    else
                                    if (i < 0xB6EA) pinyin = 'd';
                    else
                                        if (i < 0xB7A2) pinyin = 'e';
                    else
                                            if (i < 0xB8C1) pinyin = 'f';
                    else
                                                if (i < 0xB9FE) pinyin = 'g';
                    else
                                                    if (i < 0xBBF7) pinyin = 'h';
                    else
                                                        if (i < 0xBFA6) pinyin = 'g';
                    else
                                                            if (i < 0xC0AC) pinyin = 'k';
                    else
                                                                if (i < 0xC2E8) pinyin = 'l';
                    else
                                                                    if (i < 0xC4C3) pinyin = 'm';
                    else
                                                                        if (i < 0xC5B6) pinyin = 'n';
                    else
                                                                            if (i < 0xC5BE) pinyin = 'o';
                    else
                                                                                if (i < 0xC6DA) pinyin = 'p';
                    else
                                                                                    if (i < 0xC8BB) pinyin = 'q';
                    else
                                                                                        if (i < 0xC8F6) pinyin = 'r';
                    else
                                                                                            if (i < 0xCBFA) pinyin = 's';
                    else
                                                                                                if (i < 0xCDDA) pinyin = 't';
                    else
                                                                                                    if (i < 0xCEF4) pinyin = 'w';
                    else
                                                                                                        if (i < 0xD1B9) pinyin = 'x';
                    else
                                                                                                            if (i < 0xD4D1) pinyin = 'y';
                    else
                                                                                                                if (i < 0xD7FA) pinyin = 'z';
                }

                sb.Append(pinyin);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 将指定字符串中的汉字转换为拼音字母，其中非汉字保留为原字符
        /// </summary>
        /// <param name="text">要转换的文本内容</param>
        /// <returns>string</returns>
        public static string ConvertSpellFull(this string text)
        {
            #region 初始化定义
            int[] pyvalue = new int[]{-20319,-20317,-20304,-20295,-20292,-20283,-20265,-20257,-20242,-20230,-20051,-20036,-20032,-20026,
                                                   -20002,-19990,-19986,-19982,-19976,-19805,-19784,-19775,-19774,-19763,-19756,-19751,-19746,-19741,-19739,-19728,
                                                   -19725,-19715,-19540,-19531,-19525,-19515,-19500,-19484,-19479,-19467,-19289,-19288,-19281,-19275,-19270,-19263,
                                                   -19261,-19249,-19243,-19242,-19238,-19235,-19227,-19224,-19218,-19212,-19038,-19023,-19018,-19006,-19003,-18996,
                                                   -18977,-18961,-18952,-18783,-18774,-18773,-18763,-18756,-18741,-18735,-18731,-18722,-18710,-18697,-18696,-18526,
                                                   -18518,-18501,-18490,-18478,-18463,-18448,-18447,-18446,-18239,-18237,-18231,-18220,-18211,-18201,-18184,-18183,
                                                   -18181,-18012,-17997,-17988,-17970,-17964,-17961,-17950,-17947,-17931,-17928,-17922,-17759,-17752,-17733,-17730,
                                                   -17721,-17703,-17701,-17697,-17692,-17683,-17676,-17496,-17487,-17482,-17468,-17454,-17433,-17427,-17417,-17202,
                                                   -17185,-16983,-16970,-16942,-16915,-16733,-16708,-16706,-16689,-16664,-16657,-16647,-16474,-16470,-16465,-16459,
                                                   -16452,-16448,-16433,-16429,-16427,-16423,-16419,-16412,-16407,-16403,-16401,-16393,-16220,-16216,-16212,-16205,
                                                   -16202,-16187,-16180,-16171,-16169,-16158,-16155,-15959,-15958,-15944,-15933,-15920,-15915,-15903,-15889,-15878,
                                                   -15707,-15701,-15681,-15667,-15661,-15659,-15652,-15640,-15631,-15625,-15454,-15448,-15436,-15435,-15419,-15416,
                                                   -15408,-15394,-15385,-15377,-15375,-15369,-15363,-15362,-15183,-15180,-15165,-15158,-15153,-15150,-15149,-15144,
                                                   -15143,-15141,-15140,-15139,-15128,-15121,-15119,-15117,-15110,-15109,-14941,-14937,-14933,-14930,-14929,-14928,
                                                   -14926,-14922,-14921,-14914,-14908,-14902,-14894,-14889,-14882,-14873,-14871,-14857,-14678,-14674,-14670,-14668,
                                                   -14663,-14654,-14645,-14630,-14594,-14429,-14407,-14399,-14384,-14379,-14368,-14355,-14353,-14345,-14170,-14159,
                                                   -14151,-14149,-14145,-14140,-14137,-14135,-14125,-14123,-14122,-14112,-14109,-14099,-14097,-14094,-14092,-14090,
                                                   -14087,-14083,-13917,-13914,-13910,-13907,-13906,-13905,-13896,-13894,-13878,-13870,-13859,-13847,-13831,-13658,
                                                   -13611,-13601,-13406,-13404,-13400,-13398,-13395,-13391,-13387,-13383,-13367,-13359,-13356,-13343,-13340,-13329,
                                                   -13326,-13318,-13147,-13138,-13120,-13107,-13096,-13095,-13091,-13076,-13068,-13063,-13060,-12888,-12875,-12871,
                                                   -12860,-12858,-12852,-12849,-12838,-12831,-12829,-12812,-12802,-12607,-12597,-12594,-12585,-12556,-12359,-12346,
                                                   -12320,-12300,-12120,-12099,-12089,-12074,-12067,-12058,-12039,-11867,-11861,-11847,-11831,-11798,-11781,-11604,
                                                   -11589,-11536,-11358,-11340,-11339,-11324,-11303,-11097,-11077,-11067,-11055,-11052,-11045,-11041,-11038,-11024,
                                                   -11020,-11019,-11018,-11014,-10838,-10832,-10815,-10800,-10790,-10780,-10764,-10587,-10544,-10533,-10519,-10331,
                                                   -10329,-10328,-10322,-10315,-10309,-10307,-10296,-10281,-10274,-10270,-10262,-10260,-10256,-10254};

            string[] pystr = new string[]{"a","ai","an","ang","ao","ba","bai","ban","bang","bao","bei","ben","beng","bi","bian","biao",
                                                   "bie","bin","bing","bo","bu","ca","cai","can","cang","cao","ce","ceng","cha","chai","chan","chang","chao","che","chen",
                                                   "cheng","chi","chong","chou","chu","chuai","chuan","chuang","chui","chun","chuo","ci","cong","cou","cu","cuan","cui",
                                                   "cun","cuo","da","dai","dan","dang","dao","de","deng","di","dian","diao","die","ding","diu","dong","dou","du","duan",
                                                   "dui","dun","duo","e","en","er","fa","fan","fang","fei","fen","feng","fo","fou","fu","ga","gai","gan","gang","gao",
                                                   "ge","gei","gen","geng","gong","gou","gu","gua","guai","guan","guang","gui","gun","guo","ha","hai","han","hang",
                                                   "hao","he","hei","hen","heng","hong","hou","hu","hua","huai","huan","huang","hui","hun","huo","ji","jia","jian",
                                                   "jiang","jiao","jie","jin","jing","jiong","jiu","ju","juan","jue","jun","ka","kai","kan","kang","kao","ke","ken",
                                                   "keng","kong","kou","ku","kua","kuai","kuan","kuang","kui","kun","kuo","la","lai","lan","lang","lao","le","lei",
                                                   "leng","li","lia","lian","liang","liao","lie","lin","ling","liu","long","lou","lu","lv","luan","lue","lun","luo",
                                                   "ma","mai","man","mang","mao","me","mei","men","meng","mi","mian","miao","mie","min","ming","miu","mo","mou","mu",
                                                   "na","nai","nan","nang","nao","ne","nei","nen","neng","ni","nian","niang","niao","nie","nin","ning","niu","nong",
                                                   "nu","nv","nuan","nue","nuo","o","ou","pa","pai","pan","pang","pao","pei","pen","peng","pi","pian","piao","pie",
                                                   "pin","ping","po","pu","qi","qia","qian","qiang","qiao","qie","qin","qing","qiong","qiu","qu","quan","que","qun",
                                                   "ran","rang","rao","re","ren","reng","ri","rong","rou","ru","ruan","rui","run","ruo","sa","sai","san","sang",
                                                   "sao","se","sen","seng","sha","shai","shan","shang","shao","she","shen","sheng","shi","shou","shu","shua",
                                                   "shuai","shuan","shuang","shui","shun","shuo","si","song","sou","su","suan","sui","sun","suo","ta","tai",
                                                   "tan","tang","tao","te","teng","ti","tian","tiao","tie","ting","tong","tou","tu","tuan","tui","tun","tuo",
                                                   "wa","wai","wan","wang","wei","wen","weng","wo","wu","xi","xia","xian","xiang","xiao","xie","xin","xing",
                                                   "xiong","xiu","xu","xuan","xue","xun","ya","yan","yang","yao","ye","yi","yin","ying","yo","yong","you",
                                                   "yu","yuan","yue","yun","za","zai","zan","zang","zao","ze","zei","zen","zeng","zha","zhai","zhan","zhang",
                                                   "zhao","zhe","zhen","zheng","zhi","zhong","zhou","zhu","zhua","zhuai","zhuan","zhuang","zhui","zhun","zhuo",
                                                   "zi","zong","zou","zu","zuan","zui","zun","zuo"};
            #endregion

            byte[] array = new byte[2];
            string returnstr = "";
            int chrasc = 0;
            int i1 = 0;
            int i2 = 0;
            char[] nowchar = text.ToCharArray();
            for (int j = 0; j < nowchar.Length; j++)
            {
                array = Encoding.Default.GetBytes(nowchar[j].ToString());

                if (array.Length > 1)
                {
                    i1 = (short)(array[0]);
                    i2 = (short)(array[1]);
                }
                else
                {
                    i1 = (short)(array[0]);
                }



                chrasc = i1 * 256 + i2 - 65536;
                if (chrasc > 0 && chrasc < 160)
                {
                    returnstr += nowchar[j];
                }
                else
                {
                    for (int i = (pyvalue.Length - 1); i >= 0; i--)
                    {
                        if (pyvalue[i] < chrasc)
                        {
                            returnstr += pystr[i];
                            break;
                        }
                    }
                }
            }

            return returnstr;
        }
        #endregion

        #region 字符串自定义操作
        /// <summary>
        /// 返回字符串的真实长度，一个汉字字符相当于两个单位长度
        /// </summary>
        /// <param name="str">指定字符串</param>
        /// <returns></returns>
        public static int TrueLenght(this string str)
        {
            int intResult = 0;

            foreach (char Char in str)
            {
                if ((int)Char > 127)
                    intResult += 2;
                else
                    intResult++;
            }
            return intResult;
        }

        /// <summary>
        /// 用Byte方式截取字符串长度
        /// </summary>
        /// <param name="s">原始字符串</param>
        /// <param name="Length">截取长度</param>
        /// <param name="isShowSuspensionPoints">是否显示省略号</param>
        public static string CutTrueString(this string s, int Length, bool isShowSuspensionPoints)
        {
            s = s.Trim();
            byte[] myByte = System.Text.Encoding.Default.GetBytes(s);
            //Response.Write("cutString Function is::" + myByte.Length.ToString());
            if (myByte.Length > Length)
            {
                //截取操作
                string resultStr = "";
                for (int i = 0; i < s.Length; i++)
                {
                    byte[] tempByte = System.Text.Encoding.Default.GetBytes(resultStr);
                    if (tempByte.Length < Length)
                    {

                        resultStr += s.Substring(i, 1);
                    }
                    else
                    {
                        break;
                    }
                }
                if (isShowSuspensionPoints)
                {
                    return resultStr + "...";
                }
                else
                {
                    return resultStr;
                }
            }
            else
            {
                return s;
            }
        }

        /// <summary>
        /// 字符串截取
        /// </summary>
        /// <remarks>字符串截取</remarks>
        /// <param name="Length">截取长度</param>
        /// <param name="s">原字符串</param>
        /// <returns>string</returns>
        public static string CutString(this string s, int Length)
        {
            int len = s.Length;
            int i = 0;
            for (; i < Length && i < len; ++i)
            {
                if ((int)(s[i]) > 0xFF)
                    --Length;
            }
            if (Length < i)
                Length = i;
            else if (Length > len)
                Length = len;
            return s.Substring(0, Length);
        }

        /// <summary>
        /// 字符串截取
        /// </summary>
        /// <remarks>字符串截取</remarks>
        /// <param name="Length">截取长度</param>
        /// <param name="isShowSuspensionPoints">是否限制省略号</param>
        /// <param name="s">原字符串</param>
        /// <returns>string</returns>
        public static string CutString(this string s, int Length, bool isShowSuspensionPoints)
        {
            s = s.CutString(Length);
            if (isShowSuspensionPoints)
            {
                s = s + "…";
            }
            return s;
        }

        /// <summary>
        /// 获取一个由数字和26个小写字母组成的指定长度的随即字符串
        /// </summary>
        /// <param name="intLong">指定长度</param>
        /// <returns></returns>
        public static string GetRamdonNumLower(int intLong)
        {
            string strResult = "";
            string[] array = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            Random r = new Random();

            for (int i = 0; i < intLong; i++)
            {
                strResult += array[r.Next(36)];
            }

            return strResult;
        }

        /// <summary>
        /// 获取一个由26个小写字母组成的指定长度的随即字符串
        /// </summary>
        /// <param name="lenght">指定长度</param>
        /// <returns></returns>
        public static string GetRamdonLower(int lenght)
        {
            string strResult = "";
            string[] array = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            Random r = new Random();

            for (int i = 0; i < lenght; i++)
            {
                strResult += array[r.Next(26)];
            }

            return strResult;
        }

        /// <summary>
        /// 替换字符串
        /// </summary>
        /// <param name="oldValue">要替换的字符串</param>
        /// <param name="newValue">目标字符串</param>
        /// <param name="s">原字符串</param>
        public static string Replace(this string s, string oldValue, string newValue)
        {
            if (s.Exist(oldValue))
            {
                return s.Replace(oldValue, newValue);
            }
            else
            {
                return s;
            }
        }

        /// <summary>
        /// 取字符串右侧的几个字符
        /// </summary>
        /// <param name="oldString">字符串</param>
        /// <param name="length">右侧的几个字符</param>
        /// <returns></returns>
        public static string GetStringRight(this string oldString, int length)
        {
            string Rev = "";

            if (oldString.Length < length)
            {
                Rev = oldString;

            }
            else
            {
                Rev = oldString.Substring(oldString.Length - length, length);
            }
            return Rev;

        }

        /// <summary>
        /// 字符串如果操过指定长度则将超出的部分用指定字符串代替
        /// </summary>
        /// <param name="p_SrcString">要检查的字符串</param>
        /// <param name="p_Length">指定长度</param>
        /// <param name="p_TailString">用于替换的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string GetSubString(this string p_SrcString, int p_Length, string p_TailString)
        {
            return GetSubString(p_SrcString, 0, p_Length, p_TailString);
        }

        /// <summary>
        /// 取指定长度的字符串
        /// </summary>
        /// <param name="p_SrcString">要检查的字符串</param>
        /// <param name="p_StartIndex">起始位置</param>
        /// <param name="p_Length">指定长度</param>
        /// <param name="p_TailString">用于替换的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string GetSubString(this string p_SrcString, int p_StartIndex, int p_Length, string p_TailString)
        {


            string myResult = p_SrcString;

            //当是日文或韩文时(注:中文的范围:\u4e00 - \u9fa5, 日文在\u0800 - \u4e00, 韩文为\xAC00-\xD7A3)
            if (System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\u0800-\u4e00]+") ||
                System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\xAC00-\xD7A3]+"))
            {
                //当截取的起始位置超出字段串长度时
                if (p_StartIndex >= p_SrcString.Length)
                {
                    return "";
                }
                else
                {
                    return p_SrcString.Substring(p_StartIndex,
                                                   ((p_Length + p_StartIndex) > p_SrcString.Length) ? (p_SrcString.Length - p_StartIndex) : p_Length);
                }
            }


            if (p_Length >= 0)
            {
                byte[] bsSrcString = Encoding.Default.GetBytes(p_SrcString);

                //当字符串长度大于起始位置
                if (bsSrcString.Length > p_StartIndex)
                {
                    int p_EndIndex = bsSrcString.Length;

                    //当要截取的长度在字符串的有效长度范围内
                    if (bsSrcString.Length > (p_StartIndex + p_Length))
                    {
                        p_EndIndex = p_Length + p_StartIndex;
                    }
                    else
                    {   //当不在有效范围内时,只取到字符串的结尾

                        p_Length = bsSrcString.Length - p_StartIndex;
                        p_TailString = "";
                    }



                    int nRealLength = p_Length;
                    int[] anResultFlag = new int[p_Length];
                    byte[] bsResult = null;

                    int nFlag = 0;
                    for (int i = p_StartIndex; i < p_EndIndex; i++)
                    {

                        if (bsSrcString[i] > 127)
                        {
                            nFlag++;
                            if (nFlag == 3)
                            {
                                nFlag = 1;
                            }
                        }
                        else
                        {
                            nFlag = 0;
                        }

                        anResultFlag[i] = nFlag;
                    }

                    if ((bsSrcString[p_EndIndex - 1] > 127) && (anResultFlag[p_Length - 1] == 1))
                    {
                        nRealLength = p_Length + 1;
                    }

                    bsResult = new byte[nRealLength];

                    Array.Copy(bsSrcString, p_StartIndex, bsResult, 0, nRealLength);

                    myResult = Encoding.Default.GetString(bsResult);

                    myResult = myResult + p_TailString;
                }
            }

            return myResult;
        }
        #endregion

        #region 字符串验证操作
        ///<summary>
        ///检测当前字符串是否在另一个字符中
        ///</summary>
        ///<param name="oldString">原始字符串</param>
        ///<param name="aimString">检查的字符串</param>
        ///<returns>存在返回true,否则返回false</returns>
        public static bool Exist(this string oldString, string aimString)
        {
            bool Rev = true;
            string chr;
            if (string.IsNullOrEmpty(aimString))
                return false;
            for (int i = 0; i < aimString.Length; i++)
            {
                chr = aimString.Substring(i, 1);
                if (oldString.IndexOf(chr, StringComparison.InvariantCulture) < 0)
                {
                    return false;
                }
            }
            if (oldString.IndexOf(aimString, StringComparison.InvariantCulture) < 0)
            {
                return false;
            }
            return Rev;
        }

        /// <summary>
        /// 判断输入的字符串是否完全匹配正则
        /// </summary>
        /// <param name="RegexExpression">正则表达式</param>
        /// <param name="str">待判断的字符串</param>
        /// <returns></returns>
        public static bool IsValiable(this string str, string RegexExpression)
        {
            bool blResult = false;

            Regex rep = new Regex(RegexExpression, RegexOptions.IgnoreCase);

            //blResult = rep.IsMatch(str);
            Match mc = rep.Match(str);

            if (mc.Success)
            {
                if (mc.Value == str) blResult = true;
            }

            return blResult;
        }

        /// <summary>
        /// 是否存在于一个string[]数组中
        /// </summary>
        /// <param name="CheckArray">要检查的数据</param>
        /// <param name="s">字符串</param>
        public static bool InArray(this string s, string[] CheckArray)
        {
            int Result = (from m in CheckArray where m == s select m).Count();
            return Result >= 1;
        }

        /// <summary>
        /// 判断字符串是否为有效的邮件地址
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmail(this string email)
        {
            return Regex.IsMatch(email, @"^.+\@(\[?)[a-zA-Z0-9\-\.]+\.([a-zA-Z]{2,3}|[0-9]{1,3})(\]?)$");
        }

        /// <summary>
        /// 判断字符串是否为有效的URL地址
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsValidURL(this string url)
        {
            return Regex.IsMatch(url, @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&%\$#\=~])*[^\.\,\)\(\s]$");
        }

        /// <summary>
        /// 判断字符串是否为Int类型的
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsValidInt(this string val)
        {
            return Regex.IsMatch(val, @"^[1-9]\d*\.?[0]*$");
        }

        /// <summary>
        /// 检测字符串是否全为正整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNum(this string str)
        {
            bool blResult = true;//默认状态下是数字

            if (str == "")
                blResult = false;
            else
            {
                foreach (char Char in str)
                {
                    if (!char.IsNumber(Char))
                    {
                        blResult = false;
                        break;
                    }
                }
                if (blResult)
                {
                    if (int.Parse(str) == 0)
                        blResult = false;
                }
            }
            return blResult;
        }

        /// <summary>
        /// 检测字符串是否全为数字型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDouble(this string str)
        {
            bool blResult = true;//默认状态下是数字

            if (str == "")
                blResult = false;
            else
            {
                foreach (char Char in str)
                {
                    if (!char.IsNumber(Char) && Char.ToString() != "-")
                    {
                        blResult = false;
                        break;
                    }
                }
            }
            return blResult;
        }
        #endregion

        #region 对HTML字符串的操作
        /// <summary>
        /// 获取HTML中的图片路径
        /// </summary>
        public static ArrayList GetImages(this string Html)
        {
            ArrayList arr = new ArrayList();
            StringBuilder sbImg = new StringBuilder();
            MatchCollection mc = Regex.Matches(Html, @"<img.*?src=""(?<img>[^""]*)""[^>]*>", RegexOptions.IgnoreCase);
            foreach (Match m in mc)
            {
                arr.Add(m.Groups["img"].Value);
            }
            return arr;
        }


        /// <summary>
        /// 去掉所有HTML代码
        /// </summary>
        public static string StripHtml(this string s)
        {
            Regex regex = new Regex("<.+?>", RegexOptions.IgnoreCase);
            string strOutput = regex.Replace(s, "");
            return strOutput;
        }

        /// <summary>
        /// HTML编码
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static string HtmlEncode(this string s)
        {
            string str;
            try
            {
                str = HttpContext.Current.Server.HtmlEncode(s).Replace("\"", "[&quot;]").Replace("'", "[&#39;]");
            }
            catch
            {
                str = "error";
            }
            return str;
        }

        /// <summary>
        /// HTML解码
        /// </summary>
        /// <remarks>HTML解码</remarks>
        /// <param name="s">字符串</param>
        /// <returns>string</returns>
        public static string HtmlDecode(this string s)
        {
            string str;
            try
            {
                str = HttpContext.Current.Server.HtmlDecode(s).Replace("[&quot;]", "\"").Replace("[&#39;]", "'");
            }
            catch
            {
                str = "";
            }
            return str;
        }

        /// <summary>
        /// URL编码
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static string UrlEncoding(this string s)
        {
            return System.Web.HttpUtility.UrlEncode(s);
        }

        /// <summary>
        /// URL解码
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static string UrlDecoding(this string s)
        {
            return System.Web.HttpUtility.UrlDecode(s);
        }


        /// <summary>
        /// 返回FLash代码
        /// </summary>
        /// <param name="FileUrl">FLASH文件地址</param>
        /// <param name="width">高度</param>
        /// <param name="height">宽度</param>
        public static string GetFlashString(this string FileUrl, int width, int height)
        {
            string tmp = "";
            tmp = tmp + "<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9.0.28' width='" + width + "' height='" + height + "'>";
            tmp = tmp + "<param name='movie' value='" + FileUrl + "' />";
            tmp = tmp + "<param name='quality' value='high' />";
            tmp = tmp + "<param name='allowScriptAccess' value='sameDomain' />";
            tmp = tmp + "<param name='allowFullScreen' value='true' />";
            tmp = tmp + "<embed src='" + FileUrl + "' quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' width='" + width + "' height='" + height + "'>";
            tmp = tmp + "</embed></object>";

            return tmp;
        }

        /// <summary>
        /// 返回MediaPaly文件代码
        /// </summary>
        /// <param name="FileUrl">文件地址</param>
        /// <param name="width">高度</param>
        /// <param name="height">宽度</param>
        public static string GetMediaString(this string FileUrl, int width, int height)
        {
            string tmp = "";
            tmp = tmp + "<object classid='clsid:22D6F312-B0F6-11D0-94AB-0080C74C7E95' id='MediaPlayer1' width='" + width + "' height='" + height + "'>";
            tmp = tmp + "<param name='AudioStream' value='-1'>";
            tmp = tmp + "<param name='AutoSize' value='-1'>";
            //是否自动调整播放大小
            tmp = tmp + "<param name='AutoStart' value='-1'>";
            //是否自动播放
            tmp = tmp + "<param name='AnimationAtStart' value='-1'>";
            tmp = tmp + "<param name='AllowScan' value='-1'>";
            tmp = tmp + "<param name='AllowChangeDisplaySize' value='-1'>";
            tmp = tmp + "<param name='AutoRewind' value='0'>";
            tmp = tmp + "<param name='Balance' value='0'>";
            //左右声道平衡,最左-9640,最右9640
            tmp = tmp + "<param name='BaseURL' value>";
            tmp = tmp + "<param name='BufferingTime' value='15'>";
            //缓冲时间
            tmp = tmp + "<param name='CaptioningID' value>";
            tmp = tmp + "<param name='ClickToPlay' value='-1'>";
            tmp = tmp + "<param name='CursorType' value='0'>";
            tmp = tmp + "<param name='CurrentPosition' value='0'>";
            //当前播放进度 -1 表示不变,0表示开头 单位是秒,比如10表示从第10秒处开始播放,值必须是-1.0或大于等于0
            tmp = tmp + "<param name='CurrentMarker' value='0'>";
            tmp = tmp + "<param name='DefaultFrame' value>";
            tmp = tmp + "<param name='DisplayBackColor' value='0'>";
            tmp = tmp + "<param name='DisplayForeColor' value='16777215'>";
            tmp = tmp + "<param name='DisplayMode' value='0'>";
            tmp = tmp + "<param name='DisplaySize' value='0'>";
            //视频1-50%, 0-100%, 2-200%,3-全屏 其它的值作0处理,小数则采用四舍五入然后按前的处理
            tmp = tmp + "<param name='Enabled' value='-1'>";
            tmp = tmp + "<param name='EnableContextMenu' value='-1'>";
            //是否用右键弹出菜单控制
            tmp = tmp + "<param name='EnablePositionControls' value='-1'>";
            tmp = tmp + "<param name='EnableFullScreenControls' value='-1'>";
            tmp = tmp + "<param name='EnableTracker' value='-1'>";
            //是否允许拉动播放进度条到任意地方播放
            tmp = tmp + "<param name='Filename' value='" + FileUrl + "' valuetype='ref'>";
            //播放的文件地址
            tmp = tmp + "<param name='InvokeURLs' value='-1'>";
            tmp = tmp + "<param name='Language' value='-1'>";
            tmp = tmp + "<param name='Mute' value='0'>";
            //是否静音
            tmp = tmp + "<param name='PlayCount' value='10'>";
            //重复播放次数,0为始终重复
            tmp = tmp + "<param name='PreviewMode' value='-1'>";
            tmp = tmp + "<param name='Rate' value='1'>";
            //播放速率控制,1为正常,允许小数
            tmp = tmp + "<param name='SAMIStyle' value>";
            //SAMI样式
            tmp = tmp + "<param name='SAMILang' value>";
            tmp = tmp + "<param name='SAMIFilename' value>";
            //字幕ID
            tmp = tmp + "<param name='SelectionStart' value='-1'>";
            tmp = tmp + "<param name='SelectionEnd' value='-1'>";
            tmp = tmp + "<param name='SendOpenStateChangeEvents' value='-1'>";
            tmp = tmp + "<param name='SendWarningEvents' value='-1'>";
            tmp = tmp + "<param name='SendErrorEvents' value='-1'>";
            tmp = tmp + "<param name='SendKeyboardEvents' value='0'>";
            tmp = tmp + "<param name='SendMouseClickEvents' value='0'>";
            tmp = tmp + "<param name='SendMouseMoveEvents' value='0'>";
            tmp = tmp + "<param name='SendPlayStateChangeEvents' value='-1'>";
            tmp = tmp + "<param name='ShowCaptioning' value='0'>";
            //是否显示字幕,为一块黑色,下面会有一大块黑色,一般不显示
            tmp = tmp + "<param name='ShowControls' value='-1'>";
            //是否显示控制,比如播放,停止,暂停
            tmp = tmp + "<param name='ShowAudioControls' value='-1'>";
            //是否显示音量控制
            tmp = tmp + "<param name='ShowDisplay' value='0'>";
            //显示节目信息,比如版权等
            tmp = tmp + "<param name='ShowGotoBar' value='0'>";
            //是否启用上下文菜单
            tmp = tmp + "<param name='ShowPositionControls' value='-1'>";
            //是否显示往前往后及列表,如果显示一般也都是灰色不可控制
            tmp = tmp + "<param name='ShowStatusBar' value='-1'>";
            //当前播放信息,显示是否正在播放,及总播放时间和当前播放到的时间
            tmp = tmp + "<param name='ShowTracker' value='-1'>";
            //是否显示当前播放跟踪条,即当前的播放进度条
            tmp = tmp + "<param name='TransparentAtStart' value='-1'>";
            tmp = tmp + "<param name='VideoBorderWidth' value='0'>";
            //显示部的宽部,如果小于视频宽,则最小为视频宽,或者加大到指定值,并自动加大高度.此改变只改变四周的黑框大小,不改变视频大小
            tmp = tmp + "<param name='VideoBorderColor' value='0'>";
            //显示黑色框的颜色, 为RGB值,比如ffff00为黄色
            tmp = tmp + "<param name='VideoBorder3D' value='0'>";
            tmp = tmp + "<param name='Volume' value='0'>";
            //音量大小,负值表示是当前音量的减值,值自动会取绝对值,最大为0,最小为-9640
            tmp = tmp + "<param name='WindowlessVideo' value='0'>";
            //如果是0可以允许全屏,否则只能在窗口中查看
            tmp = tmp + "</object>";

            return tmp;
        }

        #endregion

        #region 对字符串的加密/解密
        /// <summary>
        /// 对字符串进行适应 ServU 的 MD5 加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string strServUPWD(this string str)
        {
            string strResult = "";
            strResult = GetRamdonLower(2);
            str = strResult + str;
            str = str.MD5Hash();
            str = strResult + str;

            return str;
        }

        /// <summary>
        /// 对字符串进行MD5加密
        /// </summary>
        public static string MD5Hash(this string s)
        {
            byte[] data;
            MD5CryptoServiceProvider md5Hasher;
            using (md5Hasher = new MD5CryptoServiceProvider())
            {
                data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(s));
            }
            var sBuilder = new StringBuilder();
            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// 对字符串进行SHA1加密
        /// </summary>
        public static string SHA1Hash(this string s)
        {
            byte[] data;
            SHA1CryptoServiceProvider sha1Hasher;
            using (sha1Hasher = new SHA1CryptoServiceProvider())
            {
                data = sha1Hasher.ComputeHash(Encoding.Default.GetBytes(s));
            }
            var sBuilder = new StringBuilder();
            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// 对字符串进行加密
        /// </summary>
        /// <param name="Passowrd">待加密的字符串</param>
        /// <returns>string</returns>
        public static string Encrypt(this string Passowrd)
        {
            var ticket = new FormsAuthenticationTicket(Passowrd, true, 2);
            return FormsAuthentication.Encrypt(ticket);
        }


        /// <summary>
        /// 对字符串进行解密
        /// </summary>
        /// <param name="Passowrd">已加密的字符串</param>
        /// <returns></returns>
        public static string Decrypt(this string Passowrd)
        {
            var formsAuthenticationTicket = FormsAuthentication.Decrypt(Passowrd);
            return formsAuthenticationTicket != null ? formsAuthenticationTicket.Name : Passowrd;
        }

        //默认密钥向量
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };



        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(this string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }




        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(this string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }


        #endregion

        #region Unix时间戳与C# DateTime时间类型互换
        /// <summary>
        /// 将Unix时间戳转换为DateTime类型时间
        /// </summary>
        /// <param name="d">double 型数字</param>
        /// <returns>DateTime</returns>
        public static DateTime ConvertIntDateTime(this double d)
        {
            System.DateTime time = System.DateTime.MinValue;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddSeconds(d);
            return time;
        }

        /// <summary>
        /// 将c# DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>double</returns>
        public static double ConvertDateTimeInt(this DateTime time)
        {
            double intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = (time - startTime).TotalSeconds;
            return intResult;
        }
        #endregion

        #region 人民币大小写转换
        public static string RMB(decimal Num)
        {
            string str1 = "零壹贰叁肆伍陆柒捌玖 ";                         //0-9所对应的汉字   
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分 ";   //数字位所对应的汉字   
            string str3 = " ";         //从原num值中取出的值   
            string str4 = " ";         //数字的字符串形式   
            string str5 = " ";     //人民币大写金额形式   
            int i;         //循环变量   
            int j;         //num的值乘以100的字符串长度   
            string ch1 = " ";         //数字的汉语读法   
            string ch2 = " ";         //数字位的汉字读法   
            int nzero = 0;     //用来计算连续的零值是几个   
            int temp;                         //从原num值中取出的值   

            Num = Math.Round(Math.Abs(Num), 2);         //将num取绝对值并四舍五入取2位小数   
            str4 = ((long)(Num * 100)).ToString();                 //将num乘100并转换成字符串形式   
            j = str4.Length;             //找出最高位   
            if (j > 15) { return "溢出"; }
            str2 = str2.Substring(15 - j);       //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分   

            //循环取出每一位需要转换的值   
            for (i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1);                     //取出需转换的某一位的值   
                temp = Convert.ToInt32(str3);             //转换为数字   
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //当所取位数不为元、万、亿、万亿上的数字时   
                    if (str3 == "0 ")
                    {
                        ch1 = " ";
                        ch2 = " ";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //该位是万亿，亿，万，元位等关键位   
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0 " && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = " ";
                                ch2 = " ";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = " ";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = " ";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //如果该位是亿位或元位，则必须写上   
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;

                if (i == j - 1 && str3 == "0 ")
                {
                    //最后一位（分）为0时，加上“整”   
                    str5 = str5 + "整";
                }
            }
            if (Num == 0)
            {
                str5 = "";
            }
            return str5;
        }

        /// <summary>
        /// 将人民币小写转换成大写
        /// </summary>
        /// <param name="x">要转换的数字</param>
        /// <returns></returns>
        public static string ConvertToChinese(double x)
        {
            string s = x.ToString("#L#E#D#C#K#E#D#C#J#E#D#C#I#E#D#C#H#E#D#C#G#E#D#C#F#E#D#C#.0B0A");
            string d = Regex.Replace(s, @"((?<=-|^)[^1-9]*)|((?'z'0)[0A-E]*((?=[1-9])|(?'-z'(?=[F-L\.]|$))))|((?'b'[F-L])(?'z'0)[0A-L]*((?=[1-9])|(?'-z'(?=[\.]|$))))", "${b}${z}");
            return Regex.Replace(d, ".", delegate (Match m) { return "负元空零壹贰叁肆伍陆柒捌玖空空空空空空空分角拾佰仟萬億兆京垓秭穰"[m.Value[0] - '-'].ToString(); });
        }

        #endregion

        #region JSON转换

        /// <summary>
        /// 将指定的字符串转换成指定的T对象 
        /// </summary>
        /// <typeparam name="T">所生成对象的类型。</typeparam>
        /// <param name="input">要进行反序列化的 JSON 字符串。</param>
        /// <returns>反序列化的对象。</returns>
        public static T Deserialize<T>(this string input)
            where T : new()
        {
            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Deserialize<T>(input);
        }

        /// <summary>
        /// 将对象转换为 JSON 字符串。
        /// </summary>
        /// <param name="obj"> 要序列化的对象。</param>
        /// <returns>序列化的 JSON 字符串。</returns>
        public static string Serialize(this object obj)
        {
            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Serialize(obj);
        }

        #endregion

        #region 去除字符串HTML代码

        public static string NoHtml(this string Htmlstring)  //替换HTML标记
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<img[^>]*>;", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }

        #endregion

        #region 获取周的开始和结束 分别以星期一 和 星期天 为开始
        /// <summary>
        /// 得到本周第一天(以星期天为第一天)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime GetWeekFirstDaySun(DateTime datetime)
        {
            //星期天为第一天
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            int daydiff = (-1) * weeknow;

            //本周第一天
            string FirstDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(FirstDay);
        }

        /// <summary>
        /// 得到本周第一天(以星期一为第一天)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime GetWeekFirstDayMon(DateTime datetime)
        {
            //星期一为第一天
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);

            //因为是以星期一为第一天，所以要判断weeknow等于0时，要向前推6天。
            weeknow = (weeknow == 0 ? (7 - 1) : (weeknow - 1));
            int daydiff = (-1) * weeknow;

            //本周第一天
            string FirstDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(FirstDay);
        }

        /// <summary>
        /// 得到本周最后一天(以星期六为最后一天)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime GetWeekLastDaySat(DateTime datetime)
        {
            //星期六为最后一天
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            int daydiff = (7 - weeknow) - 1;

            //本周最后一天
            string LastDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(LastDay);
        }

        /// <summary>
        /// 得到本周最后一天(以星期天为最后一天)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime GetWeekLastDaySun(DateTime datetime)
        {
            //星期天为最后一天
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            weeknow = (weeknow == 0 ? 7 : weeknow);
            int daydiff = (7 - weeknow);

            //本周最后一天
            string LastDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(LastDay);
        }
        #endregion

        //密钥
        public static readonly string sKey = "qc=O6X+a";
        //矢量，矢量可以为空
        private const string sIV = "qciO6X+aPLw=";

        /// <summary>
        /// 替换字符串关键字
        /// </summary>
        /// <param name="pToEncrypt">字符串</param>
        /// <returns>替换后文字</returns>
        public static string ReplaceKeywords(this string TextString)
        {
            if (!string.IsNullOrEmpty(TextString))
            {
                return TextString.Replace("'", "’").Replace("!", "！").Replace("--", "－－");
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 去掉小数点后的0
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private static string ToRemoveZero(this string param)
        {
            if (param.Split('.').Length == 2)
            {
                string result = param.Split('.')[0];
                string strChar = param.Split('.')[1];
                strChar.ToArray();
                for (int i = strChar.Length - 1; i >= 0; i--)
                {
                    if (strChar[i] == 0 || strChar[i] == '0')
                    {
                        strChar = strChar.Remove(i);
                    }
                    else
                    {
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(strChar.ToString()))
                {
                    return result + "." + strChar.ToString();
                }
                else
                {
                    return result;
                }
            }
            return param;
        }

        #region 图片加小图地址
        /// <summary>
        /// 图片加小图地址
        /// </summary>
        /// <param name="path">源地址</param>
        /// <param name="small">需要插入的内容</param>
        /// <returns>新的地址</returns>
        /// <remarks>
        /// 在文件的后缀名前加入指定内容
        /// </remarks>
        /// <history>
        /// [ice]   2008.4.15   Created
        /// </history>
        public static string ImgPathInsertSmall(string path, string small)
        {
            string re = "";

            try
            {
                re = path.Insert(path.LastIndexOf("."), small);
            }
            catch { }
            return re;
        }
        #endregion

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="pToEncrypt">明文</param>
        /// <returns>密文 base64转码</returns>
        public static string EncryptString(this string pToEncrypt)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Value">base64转码密文</param>
        /// <returns>明文</returns>
        public static string DecryptString(this string pToDecrypt)
        {
            if (pToDecrypt.Length > 0)
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
                for (int x = 0; x < pToDecrypt.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }

                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                StringBuilder ret = new StringBuilder();

                return System.Text.Encoding.Default.GetString(ms.ToArray());
            }
            else
            {
                return pToDecrypt;
            }
        }

        #region 处理字符为特殊形式（当字符长度大于指定长度时,截取此长度字符并加上"..."）
        /// <summary>
        /// 处理字符为特殊形式（当字符长度大于指定长度时,截取此长度字符并加上"..."）
        /// </summary>
        /// <param name="str">处理的字符串</param>
        /// <param name="len">获取的长度，汉字算两个</param>
        /// <returns>处理后的结果</returns>
        /// <remarks>
        /// 处理字符为特殊形式（当字符长度大于指定长度时,截取此长度字符并加上"..."）
        /// 汉字算两个占位符
        /// </remarks>
        /// <history>
        /// [ice]   2008.4.15   Created
        /// </history>
        public static string DealStr(string str, int len)
        {
            if (str.Length < 1)
                str = "暂无";
            string dealStr = "";
            if (GetWordStatistical(str) > len)
            {
                dealStr = CutString(str, len) + "...";
            }
            else
            {
                dealStr = str;
            }
            return dealStr;
        }
        #endregion

        #region 获取字符串的占位数
        /// <summary>
        /// 获取字符串的占位数
        /// </summary>
        /// <param name="CString">源字符串</param>
        /// <returns>返回占位数</returns>
        /// <remarks>获取字符串的占位数，中文字符算两个占位</remarks>
        /// <example>
        /// <code>
        /// Console.Write("请输出字符：");
        /// string str = Console.ReadLine().ToString();
        /// Console.WriteLine(WordHandle.CutWord.GetWordStatistical(str).ToString());
        /// Console.Read();
        /// </code>
        /// </example>
        /// <history>
        /// [ice]   2008.4.10   Created
        /// </history>
        public static int GetWordStatistical(string CString)
        {
            int digit = 0;
            try
            {
                for (int i = 0; i < CString.Length; i++)
                {
                    if (Convert.ToInt32(Convert.ToChar(CString.Substring(i, 1))) < Convert.ToInt32(Convert.ToChar(128)))
                    {
                        digit += 1;
                    }
                    else
                    {
                        digit += 2;
                    }
                }
            }
            catch { }
            return digit;
        }
        #endregion

        #region 获取图片路径，将图片改为缩略图。
        /// <summary>
        /// 获取图片路径，将图片改为缩略图。
        /// </summary>
        /// <param name="imgUrl">图片url</param>
        /// <param name="norms">规格，指定大小</param>
        /// <returns>图片缩略图</returns>
        public static string GetImageUrl(this string imgUrl, string norms = "")
        {
            string src = "/Images/nopic120-150.gif";
            if (!string.IsNullOrEmpty(imgUrl))
            {
                if (!string.IsNullOrEmpty(norms))
                {
                    string[] srcArr = imgUrl.Split('.');

                    if (srcArr.Length > 1)
                    {
                        src = ConfigurationManager.AppSettings["ImageSiteUrl"] + srcArr[0] + norms + "." + srcArr[1];
                    }
                }
                else
                {
                    src = ConfigurationManager.AppSettings["ImageSiteUrl"] + imgUrl;
                }
            }


            return src;
        }
        #endregion

        #region 判断是否匹配中文英文数字
        /// <summary>
        /// 判断是否匹配中文英文数字
        /// </summary>
        /// <param name="inputstr"></param>
        /// <returns></returns>
        public static bool IsMatchChineseEnglishFigure(string inputstr)
        {
            if (string.IsNullOrEmpty(inputstr))
            {
                return false;
            }
            else
            {
                Regex r = new Regex("^[a-zA-Z0-9_\u4e00-\u9fa5]+$");
                return r.IsMatch(inputstr);
            }
        }
        #endregion

        #region 获取枚举描述信息转换为Dictionary
        /// <summary>
        /// 获取枚举描述信息
        /// </summary>
        /// <param name="en">枚举</param>
        /// <returns></returns>
        public static string GetEnumDescription(this Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }
        /// <summary>
        /// 把枚举转换为键值对集合(英文+描述)
        /// StringHelper.EnumToDictionary(typeof(RentPaymentEnum));
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <param name="getText">获得值得文本</param>
        /// <returns>以枚举值为key，枚举文本为value的键值对集合</returns>
        public static Dictionary<string, string> EnumToDictionary(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("传入的参数必须是枚举类型！", "enumType");
            }
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();
            Array enumValues = Enum.GetValues(enumType);
            foreach (Enum enumValue in enumValues)
            {
                string key = (enumValue).ToString();
                string value = GetEnumDescription(enumValue);
                Dictionary.Add(key, value);
            }
            return Dictionary;
        }
        /// <summary>
        /// 把枚举转换为键值对集合(数字+描述)
        /// StringHelper.EnumToDictionary(typeof(RentPaymentEnum));
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <param name="getText">获得值得文本</param>
        /// <returns>以枚举值为key，枚举文本为value的键值对集合</returns>
        public static Dictionary<string, string> EnumToDictionaryTwo(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("传入的参数必须是枚举类型！", "enumType");
            }
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();
            Array enumValues = Enum.GetValues(enumType);
            foreach (Enum enumValue in enumValues)
            {
                int key = Convert.ToInt32(enumValue);
                string value = GetEnumDescription(enumValue);
                Dictionary.Add(key.ToString(), value);
            }
            return Dictionary;
        }
        #endregion

        public static string SplitStringPlusSpecialString(string originalValue, int splitLength, string splitSpecialString)
        {
            var originalLength = originalValue.Length;
            var splitCount = originalLength / splitLength;
            var targetValue = originalValue;
            var splitSpecialStringLength = splitSpecialString.Length;
            for (var i = 0; i < splitCount; i++)
            {
                targetValue = targetValue.Insert((i + 1) * splitLength + (i * splitSpecialStringLength), splitSpecialString);
            }
            return targetValue.TrimEnd(splitSpecialString.ToCharArray());
        }
    }
  

}