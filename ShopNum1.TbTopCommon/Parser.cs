using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Xml;

namespace ShopNum1.TbTopCommon
{
    public class Parser
    {
        public string Base64ToString(string string_0)
        {
            return Encoding.Default.GetString(Convert.FromBase64String(string_0));
        }

        public SqlParameter[] ConvertToParams(object object_0)
        {
            return ConvertToParams(object_0, null);
        }

        public SqlParameter[] ConvertToParams(object object_0, params SqlParameter[] commandParameters)
        {
            IDictionary<string, string> dictionary = new SortedDictionary<string, string>();
            foreach (PropertyInfo info2 in object_0.GetType().GetProperties())
            {
                string str2;
                string name = info2.Name;
                if (((((info2.PropertyType == typeof (int)) || (info2.PropertyType == typeof (long))) ||
                      ((info2.PropertyType == typeof (string)) || (info2.PropertyType == typeof (DateTime)))) ||
                     (info2.PropertyType == typeof (bool))) || (info2.PropertyType == typeof (double)))
                {
                    str2 = Convert.ToString(info2.GetValue(object_0, null));
                    if (info2.PropertyType == typeof (int))
                    {
                        dictionary.Add(name, str2);
                    }
                    else if (info2.PropertyType == typeof (long))
                    {
                        dictionary.Add(name, str2);
                    }
                    else
                    {
                        dictionary.Add(name, str2);
                    }
                }
                else if (!info2.PropertyType.IsGenericType)
                {
                    foreach (PropertyInfo info in info2.GetValue(object_0, null).GetType().GetProperties())
                    {
                        string str = info.Name;
                        if (((((info.PropertyType == typeof (int)) || (info.PropertyType == typeof (long))) ||
                              ((info.PropertyType == typeof (string)) || (info.PropertyType == typeof (DateTime)))) ||
                             (info.PropertyType == typeof (bool))) || (info.PropertyType == typeof (double)))
                        {
                            str2 = Convert.ToString(info.GetValue(info2.GetValue(object_0, null), null));
                            dictionary.Add(name + str, str2);
                        }
                    }
                }
            }
            var parameterArray2 =
                new SqlParameter[dictionary.Count + ((commandParameters != null) ? commandParameters.Length : 0)];
            int index = 0;
            foreach (var pair in dictionary)
            {
                if ((pair.Key.Contains("price") || pair.Key.Contains("_fee")) || pair.Key.Contains("payment"))
                {
                    parameterArray2[index] = new SqlParameter("@" + pair.Key.Replace("_", ""), SqlDbType.Money);
                    parameterArray2[index].Value = pair.Value;
                }
                else if (pair.Key.Contains("time") || pair.Key.Contains("modified"))
                {
                    parameterArray2[index] = new SqlParameter("@" + pair.Key.Replace("_", ""), SqlDbType.DateTime);
                    parameterArray2[index].Value = pair.Value;
                }
                else if (pair.Key.Contains("desc"))
                {
                    parameterArray2[index] = new SqlParameter("@" + pair.Key.Replace("_", ""), SqlDbType.NText);
                    parameterArray2[index].Value = pair.Value;
                }
                else
                {
                    string parameterName = "@" + pair.Key.Replace("_", "");
                    parameterArray2[index] = new SqlParameter(parameterName, pair.Value);
                }
                index++;
            }
            if (commandParameters != null)
            {
                foreach (SqlParameter parameter in commandParameters)
                {
                    parameterArray2[index] = parameter;
                    index++;
                }
            }
            return parameterArray2;
        }

        public string GetParameters(string parameters, string string_0)
        {
            string str = string.Empty;
            try
            {
                string[] strArray2;
                string[] strArray = Base64ToString(parameters).Split(new[] {'&'});
                for (int i = 0; i < strArray.Length; i++)
                {
                    strArray2 = strArray[i].Split(new[] {'='});
                    if (strArray2[0].ToLower() == string_0.ToLower())
                    {
                        goto Label_006C;
                    }
                }
                return str;
                Label_006C:
                str = strArray2[1];
            }
            catch (Exception)
            {
            }
            return str;
        }

        public bool IsXmlError2(XmlDocument xmlDocument_0, ErrorRsp errorRsp_0)
        {
            if (xmlDocument_0.SelectNodes("error_response").Count != 0)
            {
                XmlErrorToObject2(xmlDocument_0, errorRsp_0);
                return true;
            }
            return false;
        }

        public bool NewXmlToObject2<T>(string strXml, string rootName, string childName, List<T> objs,
            ErrorRsp errorRsp_0, string string_0, string name)
        {
            try
            {
                if (strXml.Trim() != "")
                {
                    var document = new XmlDocument();
                    document.LoadXml(strXml);
                    if (document.SelectNodes(rootName + "_response").Count != 0)
                    {
                        foreach (
                            XmlNode node in
                                document.SelectNodes((childName.Trim() != "")
                                    ? (rootName + "_response/" + childName)
                                    : (rootName + "_response")))
                        {
                            if ((node.ParentNode.PreviousSibling.Name == name) &&
                                (node.ParentNode.PreviousSibling.InnerText == string_0))
                            {
                                var oPut = (T) Activator.CreateInstance(typeof (T));
                                foreach (XmlNode node2 in node)
                                {
                                    if (node2.ChildNodes.Count == 1)
                                    {
                                        XmlToObject(oPut, node2.Name, node2.InnerText);
                                    }
                                    else
                                    {
                                        for (int i = 0; i < node2.ChildNodes.Count; i++)
                                        {
                                            XmlToObject(node2.Name, oPut, node2.ChildNodes[i].Name,
                                                node2.ChildNodes[i].InnerText);
                                        }
                                    }
                                }
                                objs.Add(oPut);
                            }
                        }
                        return true;
                    }
                    if (IsXmlError2(document, errorRsp_0))
                    {
                        return false;
                    }
                    errorRsp_0.code = "-1";
                }
                return false;
            }
            catch (Exception exception)
            {
                errorRsp_0.args = strXml;
                errorRsp_0.IsError = true;
                errorRsp_0.code = "8008";
                errorRsp_0.msg = "连接服务器发生错误！" + exception.Message;
                return false;
            }
        }

        public string StringToBase64(string string_0)
        {
            return Convert.ToBase64String(Encoding.Default.GetBytes(string_0));
        }

        public void XmlErrorToObject2(XmlDocument xmlDocument_0, ErrorRsp errorRsp_0)
        {
            var builder = new StringBuilder();
            foreach (XmlNode node in xmlDocument_0.SelectNodes("error_response/args/arg"))
            {
                if (node.Name == "arg")
                {
                    builder.Append(node.SelectNodes("key").Item(0).InnerText + "=" +
                                   node.SelectNodes("value").Item(0).InnerText + "|");
                }
            }
            errorRsp_0.args = builder.ToString();
            errorRsp_0.IsError = true;
            errorRsp_0.code = xmlDocument_0.SelectSingleNode("error_response/code").InnerText;
            errorRsp_0.msg = xmlDocument_0.SelectSingleNode("error_response/msg").InnerText;
            errorRsp_0.sub_code = (xmlDocument_0.SelectSingleNode("error_response/sub_code") != null)
                ? xmlDocument_0.SelectSingleNode("error_response/sub_code").InnerText
                : "";
            errorRsp_0.sub_msg = (xmlDocument_0.SelectSingleNode("error_response/sub_msg") != null)
                ? xmlDocument_0.SelectSingleNode("error_response/sub_msg").InnerText
                : "";
        }

        public string XmlToNodeText(string strXml, string nodePath)
        {
            if (strXml.Trim() == "")
            {
                return "";
            }
            try
            {
                var document = new XmlDocument();
                document.LoadXml(strXml);
                if (document.SelectSingleNode(nodePath) != null)
                {
                    return document.SelectSingleNode(nodePath).InnerText;
                }
                return "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        protected void XmlToObject(object oPut, string name, string value)
        {
            PropertyDescriptor descriptor = TypeDescriptor.GetProperties(oPut).Find(name, true);
            if ((descriptor != null) &&
                ((((((descriptor.PropertyType == typeof (int)) || (descriptor.PropertyType == typeof (int?))) ||
                    ((descriptor.PropertyType == typeof (long)) || (descriptor.PropertyType == typeof (long?)))) ||
                   (((descriptor.PropertyType == typeof (string)) || (descriptor.PropertyType == typeof (DateTime))) ||
                    ((descriptor.PropertyType == typeof (DateTime?)) || (descriptor.PropertyType == typeof (bool))))) ||
                  (((descriptor.PropertyType == typeof (bool?)) || (descriptor.PropertyType == typeof (decimal))) ||
                   ((descriptor.PropertyType == typeof (decimal?)) || (descriptor.PropertyType == typeof (DateTime))))) ||
                 (descriptor.PropertyType == typeof (DateTime?))))
            {
                if (descriptor.PropertyType == typeof (int))
                {
                    descriptor.SetValue(oPut, Convert.ToInt32(value));
                }
                else if (descriptor.PropertyType == typeof (int?))
                {
                    descriptor.SetValue(oPut, Convert.ToInt32(value));
                }
                else if (descriptor.PropertyType == typeof (long))
                {
                    descriptor.SetValue(oPut, Convert.ToInt64(value));
                }
                else if (descriptor.PropertyType == typeof (long?))
                {
                    descriptor.SetValue(oPut, Convert.ToInt64(value));
                }
                else if (descriptor.PropertyType == typeof (double))
                {
                    descriptor.SetValue(oPut, Convert.ToDouble(value));
                }
                else if (descriptor.PropertyType == typeof (double?))
                {
                    descriptor.SetValue(oPut, Convert.ToDouble(value));
                }
                else if (descriptor.PropertyType == typeof (bool))
                {
                    descriptor.SetValue(oPut, Convert.ToBoolean(value));
                }
                else if (descriptor.PropertyType == typeof (bool?))
                {
                    descriptor.SetValue(oPut, Convert.ToBoolean(value));
                }
                else if (descriptor.PropertyType == typeof (decimal))
                {
                    descriptor.SetValue(oPut, Convert.ToDecimal(value));
                }
                else if (descriptor.PropertyType == typeof (decimal?))
                {
                    descriptor.SetValue(oPut, Convert.ToDecimal(value));
                }
                else if (descriptor.PropertyType == typeof (DateTime))
                {
                    descriptor.SetValue(oPut, Convert.ToDateTime(value));
                }
                else if (descriptor.PropertyType == typeof (DateTime?))
                {
                    descriptor.SetValue(oPut, Convert.ToDateTime(value));
                }
                else
                {
                    descriptor.SetValue(oPut, value);
                }
            }
        }

        protected void XmlToObject(string parentName, object oPut, string name, string value)
        {
            PropertyDescriptor descriptor = TypeDescriptor.GetProperties(oPut).Find(parentName, true);
            if (descriptor != null)
            {
                PropertyDescriptor descriptor2 = TypeDescriptor.GetProperties(descriptor.GetValue(oPut))
                    .Find(name, true);
                if ((descriptor2 != null) &&
                    ((((((descriptor2.PropertyType == typeof (int)) || (descriptor2.PropertyType == typeof (int?))) ||
                        ((descriptor2.PropertyType == typeof (long)) || (descriptor2.PropertyType == typeof (long?)))) ||
                       (((descriptor2.PropertyType == typeof (string)) ||
                         (descriptor2.PropertyType == typeof (DateTime))) ||
                        ((descriptor2.PropertyType == typeof (DateTime?)) || (descriptor2.PropertyType == typeof (bool))))) ||
                      (((descriptor2.PropertyType == typeof (bool?)) || (descriptor2.PropertyType == typeof (decimal))) ||
                       ((descriptor2.PropertyType == typeof (decimal?)) ||
                        (descriptor2.PropertyType == typeof (DateTime))))) ||
                     (descriptor2.PropertyType == typeof (DateTime?))))
                {
                    if (descriptor2.PropertyType == typeof (int))
                    {
                        descriptor2.SetValue(descriptor.GetValue(oPut), Convert.ToInt32(value));
                    }
                    else if (descriptor2.PropertyType == typeof (int?))
                    {
                        descriptor2.SetValue(descriptor.GetValue(oPut), value);
                    }
                    else if (descriptor2.PropertyType == typeof (long))
                    {
                        descriptor2.SetValue(descriptor.GetValue(oPut), Convert.ToInt64(value));
                    }
                    else if (descriptor2.PropertyType == typeof (long?))
                    {
                        descriptor2.SetValue(descriptor.GetValue(oPut), Convert.ToInt64(value));
                    }
                    else if (descriptor2.PropertyType == typeof (bool))
                    {
                        descriptor2.SetValue(descriptor.GetValue(oPut), Convert.ToBoolean(value));
                    }
                    else if (descriptor2.PropertyType == typeof (bool?))
                    {
                        descriptor2.SetValue(descriptor.GetValue(oPut), Convert.ToBoolean(value));
                    }
                    else if (descriptor2.PropertyType == typeof (decimal))
                    {
                        descriptor2.SetValue(descriptor.GetValue(oPut), Convert.ToDecimal(value));
                    }
                    else if (descriptor2.PropertyType == typeof (decimal?))
                    {
                        descriptor2.SetValue(descriptor.GetValue(oPut), Convert.ToDecimal(value));
                    }
                    else if (descriptor2.PropertyType == typeof (DateTime?))
                    {
                        descriptor2.SetValue(descriptor.GetValue(oPut), Convert.ToDateTime(value));
                    }
                    else if (descriptor2.PropertyType == typeof (DateTime?))
                    {
                        descriptor2.SetValue(descriptor.GetValue(oPut), Convert.ToDateTime(value));
                    }
                    else
                    {
                        descriptor2.SetValue(descriptor.GetValue(oPut), value);
                    }
                }
            }
        }

        public bool XmlToObject2(string strXml, string rootName, object object_0, ErrorRsp errorRsp_0)
        {
            return XmlToObject2(strXml, rootName, "", object_0, errorRsp_0);
        }

        public bool XmlToObject2<T>(string strXml, string rootName, string childName, List<T> objs)
        {
            return XmlToObject2(strXml, rootName, childName, objs, new ErrorRsp());
        }

        public bool XmlToObject2(string strXml, string rootName, string childName, object object_0, ErrorRsp errorRsp_0)
        {
            try
            {
                if (strXml.Trim() != "")
                {
                    string xpath = (childName.Trim() != "")
                        ? (rootName + "_response/" + childName)
                        : (rootName + "_response");
                    var document = new XmlDocument();
                    document.LoadXml(strXml);
                    if (document.SelectNodes(xpath).Count != 0)
                    {
                        foreach (XmlNode node in document.SelectNodes(xpath))
                        {
                            foreach (XmlNode node2 in node)
                            {
                                if (node2.ChildNodes.Count == 1)
                                {
                                    XmlToObject(object_0, node2.Name, node2.InnerText);
                                }
                                else
                                {
                                    for (int i = 0; i < node2.ChildNodes.Count; i++)
                                    {
                                        XmlToObject(node2.Name, object_0, node2.ChildNodes[i].Name,
                                            node2.ChildNodes[i].InnerText);
                                    }
                                }
                            }
                        }
                        return true;
                    }
                    if (IsXmlError2(document, errorRsp_0))
                    {
                        return false;
                    }
                    errorRsp_0.code = "-1";
                }
                return false;
            }
            catch (Exception exception)
            {
                errorRsp_0.args = strXml;
                errorRsp_0.IsError = true;
                errorRsp_0.code = "8008";
                errorRsp_0.msg = "连接服务器发生错误！" + exception.Message;
                return false;
            }
        }

        public bool XmlToObject2<T>(string strXml, string rootName, string childName, List<T> objs, ErrorRsp errorRsp_0)
        {
            try
            {
                if (strXml.Trim() != "")
                {
                    var document = new XmlDocument();
                    document.LoadXml(strXml);
                    if (document.SelectNodes(rootName + "_response").Count != 0)
                    {
                        foreach (
                            XmlNode node2 in
                                document.SelectNodes((childName.Trim() != "")
                                    ? (rootName + "_response/" + childName)
                                    : (rootName + "_response")))
                        {
                            var oPut = (T) Activator.CreateInstance(typeof (T));
                            foreach (XmlNode node in node2)
                            {
                                if (node.ChildNodes.Count == 1)
                                {
                                    XmlToObject(oPut, node.Name, node.InnerText);
                                }
                                else
                                {
                                    for (int i = 0; i < node.ChildNodes.Count; i++)
                                    {
                                        XmlToObject(node.Name, oPut, node.ChildNodes[i].Name,
                                            node.ChildNodes[i].InnerText);
                                    }
                                }
                            }
                            objs.Add(oPut);
                        }
                        return true;
                    }
                    if (IsXmlError2(document, errorRsp_0))
                    {
                        return false;
                    }
                    errorRsp_0.code = "-1";
                }
                return false;
            }
            catch (Exception exception)
            {
                errorRsp_0.args = strXml;
                errorRsp_0.IsError = true;
                errorRsp_0.code = "8008";
                errorRsp_0.msg = "连接服务器发生错误！" + exception.Message;
                return false;
            }
        }

        public bool XmlToObject2<T>(string strXml, string rootName, string childName, string childKeyValue,
            string grandChildName, List<T> objs)
        {
            return XmlToObject2(strXml, rootName, childName, childKeyValue, grandChildName, objs, new ErrorRsp());
        }

        public bool XmlToObject2<T>(string strXml, string rootName, string childName, string childKeyValue,
            string grandChildName, List<T> objs, ErrorRsp errorRsp_0)
        {
            try
            {
                if (strXml.Trim() != "")
                {
                    var document = new XmlDocument();
                    document.LoadXml(strXml);
                    if (document.SelectNodes(rootName + "_response").Count != 0)
                    {
                        foreach (
                            XmlNode node3 in
                                document.SelectNodes((childName.Trim() != "")
                                    ? (rootName + "_response/" + childName)
                                    : (rootName + "_response")))
                        {
                            if (node3.InnerText.Contains(childKeyValue))
                            {
                                XmlNodeList list2 = node3.SelectNodes(grandChildName);
                                if (list2.Count > 0)
                                {
                                    foreach (XmlNode node in list2)
                                    {
                                        if (node.ParentNode.ParentNode.InnerText.Contains(childKeyValue))
                                        {
                                            var oPut = (T) Activator.CreateInstance(typeof (T));
                                            foreach (XmlNode node2 in node)
                                            {
                                                if (node2.ChildNodes.Count == 1)
                                                {
                                                    XmlToObject(oPut, node2.Name, node2.InnerText);
                                                }
                                                else
                                                {
                                                    for (int i = 0; i < node2.ChildNodes.Count; i++)
                                                    {
                                                        XmlToObject(node2.Name, oPut, node2.ChildNodes[i].Name,
                                                            node2.ChildNodes[i].InnerText);
                                                    }
                                                }
                                            }
                                            objs.Add(oPut);
                                        }
                                    }
                                }
                            }
                        }
                        return true;
                    }
                    if (IsXmlError2(document, errorRsp_0))
                    {
                        return false;
                    }
                    errorRsp_0.code = "-1";
                }
                return false;
            }
            catch (Exception exception)
            {
                errorRsp_0.args = strXml;
                errorRsp_0.IsError = true;
                errorRsp_0.code = "8008";
                errorRsp_0.msg = "连接服务器发生错误！" + exception.Message;
                return false;
            }
        }

        public int XmlToTotalResults(string strXml, string rootName)
        {
            int num = 0;
            try
            {
                if (strXml.Trim() == "")
                {
                    return 0;
                }
                var document = new XmlDocument();
                document.LoadXml(strXml);
                if (document.SelectNodes(rootName + "_response/total_results").Count != 0)
                {
                    num = Convert.ToInt32(document.SelectSingleNode(rootName + "_response/total_results").InnerText);
                }
            }
            catch (Exception)
            {
            }
            return num;
        }
    }
}