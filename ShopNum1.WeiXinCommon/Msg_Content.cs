using System;
using System.Collections.Generic;
using System.Xml;

namespace ShopNum1.WeiXinCommon
{
    public class Msg_Content
    {
        private static string ReplyMsg(RequestModel requestXML)
        {
            var replyinfomodels = new List<ReplyInfoModel>();
            var item = new ReplyInfoModel
            {
                Title = "微信测试",
                Description = "描述，图片展示",
                ImgSrc =
                    "http://d.hiphotos.baidu.com/pic/w%3D230/sign=761745944610b912bfc1f1fdf3fdfcb5/5bafa40f4bfbfbed1062345079f0f736afc31fe1.jpg",
                Url = "http://www.baidu.com"
            };
            for (int i = 0; i < 5; i++)
            {
                replyinfomodels.Add(item);
            }
            string str = string.Empty;
            var xml = new MsgXml(requestXML);
            try
            {
                string msgType = requestXML.MsgType;
                switch (msgType)
                {
                    case null:
                        return str;

                    case "text":
                        break;

                    case "location":
                        return xml.ReplyTxt("你发过来的是地理消息");

                    case "image":
                        return xml.ReplyTxt("你发过来的是图片消息");

                    default:
                        if (msgType != "link")
                        {
                            if (!(msgType == "event"))
                            {
                                return str;
                            }
                            msgType = requestXML.Wxevent;
                            if (msgType == null)
                            {
                                return str;
                            }
                            if (!(msgType == "subscribe"))
                            {
                                if ((msgType == "unsubscribe") || (msgType == "CLICK"))
                                {
                                }
                                return str;
                            }
                            return xml.ReplyTxt("感谢关注...");
                        }
                        return xml.ReplyTxt("你发过来的是链接消息");
                }
                if (requestXML.Content.Trim() == "单图")
                {
                    return xml.ReplyImg(item);
                }
                if (requestXML.Content.Trim() == "多图")
                {
                    return xml.ReplyImg(replyinfomodels);
                }
                str = xml.ReplyTxt("你发过来的是文字消息");
            }
            catch (Exception)
            {
            }
            return str;
        }

        public static string RepMsg_Content(string postStr)
        {
            var document = new XmlDocument();
            document.LoadXml(postStr);
            XmlElement documentElement = document.DocumentElement;
            var requestXML = new RequestModel
            {
                ToUserName = documentElement.SelectSingleNode("ToUserName").InnerText,
                FromUserName = documentElement.SelectSingleNode("FromUserName").InnerText,
                CreateTime = documentElement.SelectSingleNode("CreateTime").InnerText,
                MsgType = documentElement.SelectSingleNode("MsgType").InnerText
            };
            string msgType = requestXML.MsgType;
            switch (msgType)
            {
                case null:
                    break;

                case "text":
                    requestXML.Content = documentElement.SelectSingleNode("Content").InnerText;
                    requestXML.MsgId = documentElement.SelectSingleNode("MsgId").InnerText;
                    break;

                case "location":
                    requestXML.Location_X = documentElement.SelectSingleNode("Location_X").InnerText;
                    requestXML.Location_Y = documentElement.SelectSingleNode("Location_Y").InnerText;
                    requestXML.Scale = documentElement.SelectSingleNode("Scale").InnerText;
                    requestXML.Label = documentElement.SelectSingleNode("Label").InnerText;
                    requestXML.MsgId = documentElement.SelectSingleNode("MsgId").InnerText;
                    break;

                case "image":
                    requestXML.PicUrl = documentElement.SelectSingleNode("PicUrl").InnerText;
                    requestXML.MsgId = documentElement.SelectSingleNode("MsgId").InnerText;
                    break;

                default:
                    if (!(msgType == "link"))
                    {
                        if (msgType == "event")
                        {
                            requestXML.Wxevent = documentElement.SelectSingleNode("Event").InnerText;
                            requestXML.EventKey = documentElement.SelectSingleNode("EventKey").InnerText;
                        }
                    }
                    else
                    {
                        requestXML.Title = documentElement.SelectSingleNode("Title").InnerText;
                        requestXML.Description = documentElement.SelectSingleNode("Description").InnerText;
                        requestXML.Url = documentElement.SelectSingleNode("Url").InnerText;
                        requestXML.MsgId = documentElement.SelectSingleNode("MsgId").InnerText;
                    }
                    break;
            }
            return ReplyMsg(requestXML);
        }
    }
}