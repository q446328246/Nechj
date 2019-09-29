using System;
using System.Collections.Generic;
using System.Text;

namespace ShopNum1.WeiXinCommon
{
    public class MsgXml
    {
        private readonly StringBuilder resxml = new StringBuilder();

        public MsgXml(RequestModel requestXML)
        {
            resxml.AppendFormat(
                "<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>\r\n                                  {2}</CreateTime>",
                requestXML.FromUserName, requestXML.ToUserName, DateHepler.ConvertDateTimeInt(DateTime.Now));
        }

        public string ReplyImg(ReplyInfoModel replyinfomodel)
        {
            resxml.AppendFormat("<MsgType><![CDATA[news]]></MsgType><ArticleCount>1</ArticleCount><Articles>",
                new object[0]);
            resxml.AppendFormat(
                "<item><Title><![CDATA[{0}]]></Title><Description><![CDATA[{1}]]>\r\n                                  </Description><PicUrl><![CDATA[{2}]]>\r\n                                  </PicUrl><Url><![CDATA[{3}]]></Url></item>",
                new object[]
                {replyinfomodel.Title, replyinfomodel.Description, replyinfomodel.ImgSrc, replyinfomodel.Url});
            resxml.AppendFormat("</Articles></xml>", new object[0]);
            return resxml.ToString();
        }

        public string ReplyImg(List<ReplyInfoModel> replyinfomodels)
        {
            int num = 1;
            resxml.AppendFormat("<MsgType><![CDATA[news]]></MsgType><ArticleCount>{0}</ArticleCount><Articles>",
                replyinfomodels.Count);
            foreach (ReplyInfoModel model in replyinfomodels)
            {
                resxml.AppendFormat(
                    "<item><Title><![CDATA[{0}]]></Title><Description><![CDATA[{1}]]>\r\n                                   </Description><PicUrl><![CDATA[{2}]]>\r\n                                   </PicUrl><Url><![CDATA[{3}]]></Url></item>",
                    new object[] {model.Title, model.Description, model.ImgSrc, model.Url});
                num++;
                if (num >= 10)
                {
                    break;
                }
            }
            resxml.AppendFormat("</Articles></xml>", new object[0]);
            return resxml.ToString();
        }

        public string ReplyMusic(ReplyInfoModel replyinfomodel)
        {
            resxml.AppendFormat(
                "<MsgType><![CDATA[music]]></MsgType><Music><Title><![CDATA[{0}]]></Title><Description><![CDATA[{1}]]></Description>\r\n                                  <MusicUrl><![CDATA[{2}]]></MusicUrl><HQMusicUrl><![CDATA[{3}]]></HQMusicUrl></Music></xml>",
                new object[]
                {
                    replyinfomodel.Title, replyinfomodel.Description, replyinfomodel.Music_Url,
                    replyinfomodel.HQ_Music_Url
                });
            return resxml.ToString();
        }

        public string ReplyTxt(ReplyInfoModel replyinfomodel)
        {
            resxml.AppendFormat("<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{0}]]></Content></xml>",
                replyinfomodel.RepMsgContent);
            return resxml.ToString();
        }

        public string ReplyTxt(string Msg)
        {
            resxml.AppendFormat("<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{0}]]></Content></xml>", Msg);
            return resxml.ToString();
        }
    }
}