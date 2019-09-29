namespace ShopNum1.Second
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Xml;

    public class XmlOperate
    {
        protected void XmlToObject(object oPut, string name, string value)
        {
            PropertyDescriptor descriptor = TypeDescriptor.GetProperties(oPut).Find(name, true);
            if ((descriptor != null) && ((((((descriptor.PropertyType == typeof(int)) || (descriptor.PropertyType == typeof(int?))) || ((descriptor.PropertyType == typeof(long)) || (descriptor.PropertyType == typeof(long?)))) || (((descriptor.PropertyType == typeof(string)) || (descriptor.PropertyType == typeof(DateTime))) || ((descriptor.PropertyType == typeof(DateTime?)) || (descriptor.PropertyType == typeof(bool))))) || (((descriptor.PropertyType == typeof(bool?)) || (descriptor.PropertyType == typeof(decimal))) || ((descriptor.PropertyType == typeof(decimal?)) || (descriptor.PropertyType == typeof(DateTime))))) || (descriptor.PropertyType == typeof(DateTime?))))
            {
                if (descriptor.PropertyType == typeof(int))
                {
                    descriptor.SetValue(oPut, Convert.ToInt32(value));
                }
                else if (descriptor.PropertyType == typeof(int?))
                {
                    descriptor.SetValue(oPut, Convert.ToInt32(value));
                }
                else if (descriptor.PropertyType == typeof(long))
                {
                    descriptor.SetValue(oPut, Convert.ToInt64(value));
                }
                else if (descriptor.PropertyType == typeof(long?))
                {
                    descriptor.SetValue(oPut, Convert.ToInt64(value));
                }
                else if (descriptor.PropertyType == typeof(double))
                {
                    descriptor.SetValue(oPut, Convert.ToDouble(value));
                }
                else if (descriptor.PropertyType == typeof(double?))
                {
                    descriptor.SetValue(oPut, Convert.ToDouble(value));
                }
                else if (descriptor.PropertyType == typeof(bool))
                {
                    descriptor.SetValue(oPut, Convert.ToBoolean(value));
                }
                else if (descriptor.PropertyType == typeof(bool?))
                {
                    descriptor.SetValue(oPut, Convert.ToBoolean(value));
                }
                else if (descriptor.PropertyType == typeof(decimal))
                {
                    descriptor.SetValue(oPut, Convert.ToDecimal(value));
                }
                else if (descriptor.PropertyType == typeof(decimal?))
                {
                    descriptor.SetValue(oPut, Convert.ToDecimal(value));
                }
                else if (descriptor.PropertyType == typeof(DateTime))
                {
                    descriptor.SetValue(oPut, Convert.ToDateTime(value));
                }
                else if (descriptor.PropertyType == typeof(DateTime?))
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
                PropertyDescriptor descriptor2 = TypeDescriptor.GetProperties(descriptor.GetValue(oPut)).Find(name, true);
                if ((descriptor2 != null) && ((((((descriptor2.PropertyType == typeof(int)) || (descriptor2.PropertyType == typeof(int?))) || ((descriptor2.PropertyType == typeof(long)) || (descriptor2.PropertyType == typeof(long?)))) || (((descriptor2.PropertyType == typeof(string)) || (descriptor2.PropertyType == typeof(DateTime))) || ((descriptor2.PropertyType == typeof(DateTime?)) || (descriptor2.PropertyType == typeof(bool))))) || (((descriptor2.PropertyType == typeof(bool?)) || (descriptor2.PropertyType == typeof(decimal))) || ((descriptor2.PropertyType == typeof(decimal?)) || (descriptor2.PropertyType == typeof(DateTime))))) || (descriptor2.PropertyType == typeof(DateTime?))))
                {
                    if (descriptor2.PropertyType == typeof(int))
                    {
                        descriptor2.SetValue(descriptor.GetValue(oPut), Convert.ToInt32(value));
                    }
                    else if (descriptor2.PropertyType == typeof(int?))
                    {
                        descriptor2.SetValue(descriptor.GetValue(oPut), value);
                    }
                    else if (descriptor2.PropertyType == typeof(long))
                    {
                        descriptor2.SetValue(descriptor.GetValue(oPut), Convert.ToInt64(value));
                    }
                    else if (descriptor2.PropertyType == typeof(long?))
                    {
                        descriptor2.SetValue(descriptor.GetValue(oPut), Convert.ToInt64(value));
                    }
                    else if (descriptor2.PropertyType == typeof(bool))
                    {
                        descriptor2.SetValue(descriptor.GetValue(oPut), Convert.ToBoolean(value));
                    }
                    else if (descriptor2.PropertyType == typeof(bool?))
                    {
                        descriptor2.SetValue(descriptor.GetValue(oPut), Convert.ToBoolean(value));
                    }
                    else if (descriptor2.PropertyType == typeof(decimal))
                    {
                        descriptor2.SetValue(descriptor.GetValue(oPut), Convert.ToDecimal(value));
                    }
                    else if (descriptor2.PropertyType == typeof(decimal?))
                    {
                        descriptor2.SetValue(descriptor.GetValue(oPut), Convert.ToDecimal(value));
                    }
                    else if (descriptor2.PropertyType == typeof(DateTime?))
                    {
                        descriptor2.SetValue(descriptor.GetValue(oPut), Convert.ToDateTime(value));
                    }
                    else if (descriptor2.PropertyType == typeof(DateTime?))
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

        public bool XmlToObject2<T>(string strXml, string rootName, string childName, List<T> objs)
        {
            return this.XmlToObject2<T>(strXml, rootName, childName, objs, new ErrorRsp());
        }

        public bool XmlToObject2<T>(string strXml, string rootName, string childName, List<T> objs, ErrorRsp rsp)
        {
            try
            {
                if (strXml.Trim() != "")
                {
                    XmlDocument document = new XmlDocument();
                    document.LoadXml(strXml);
                    if (document.SelectNodes(rootName + "_response").Count != 0)
                    {
                        foreach (XmlNode node2 in document.SelectNodes((childName.Trim() != "") ? (rootName + "_response/" + childName) : (rootName + "_response")))
                        {
                            T oPut = (T) Activator.CreateInstance(typeof(T));
                            foreach (XmlNode node in node2)
                            {
                                if (node.ChildNodes.Count == 1)
                                {
                                    this.XmlToObject(oPut, node.Name, node.InnerText);
                                }
                                else
                                {
                                    for (int i = 0; i < node.ChildNodes.Count; i++)
                                    {
                                        this.XmlToObject(node.Name, oPut, node.ChildNodes[i].Name, node.ChildNodes[i].InnerText);
                                    }
                                }
                            }
                            objs.Add(oPut);
                        }
                        return true;
                    }
                }
                return false;
            }
            catch (Exception exception)
            {
                rsp.args = strXml;
                rsp.IsError = true;
                rsp.code = "8008";
                rsp.msg = "连接服务器发生错误！" + exception.Message;
                return false;
            }
        }

        public void XmlToObject2<T>(string strXml, string rootName, string childName, T ojb, ErrorRsp rsp)
        {
            try
            {
                if (strXml.Trim() != "")
                {
                    XmlDocument document = new XmlDocument();
                    document.LoadXml(strXml);
                    if (document.SelectNodes(rootName + "_response").Count != 0)
                    {
                        foreach (XmlNode node2 in document.SelectNodes((childName.Trim() != "") ? (rootName + "_response/" + childName) : (rootName + "_response")))
                        {
                            T oPut = (T) Activator.CreateInstance(typeof(T));
                            foreach (XmlNode node in node2)
                            {
                                if (node.ChildNodes.Count == 1)
                                {
                                    this.XmlToObject(oPut, node.Name, node.InnerText);
                                }
                                else
                                {
                                    for (int i = 0; i < node.ChildNodes.Count; i++)
                                    {
                                        this.XmlToObject(node.Name, oPut, node.ChildNodes[i].Name, node.ChildNodes[i].InnerText);
                                    }
                                }
                            }
                            ojb = oPut;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                rsp.args = strXml;
                rsp.IsError = true;
                rsp.code = "8008";
                rsp.msg = "连接服务器发生错误！" + exception.Message;
            }
        }

        public bool XmlToObject2<T>(string strXml, string rootName, string childName, string childKeyValue, string grandChildName, List<T> objs)
        {
            return this.XmlToObject2<T>(strXml, rootName, childName, childKeyValue, grandChildName, objs, new ErrorRsp());
        }

        public bool XmlToObject2<T>(string strXml, string rootName, string childName, string childKeyValue, string grandChildName, List<T> objs, ErrorRsp rsp)
        {
            try
            {
                if (strXml.Trim() != "")
                {
                    XmlDocument document = new XmlDocument();
                    document.LoadXml(strXml);
                    if (document.SelectNodes(rootName + "_response").Count != 0)
                    {
                        foreach (XmlNode node in document.SelectNodes((childName.Trim() != "") ? (rootName + "_response/" + childName) : (rootName + "_response")))
                        {
                            if (node.InnerText.Contains(childKeyValue))
                            {
                                XmlNodeList list = node.SelectNodes(grandChildName);
                                if (list.Count > 0)
                                {
                                    foreach (XmlNode node3 in list)
                                    {
                                        if (node3.ParentNode.ParentNode.InnerText.Contains(childKeyValue))
                                        {
                                            T oPut = (T) Activator.CreateInstance(typeof(T));
                                            foreach (XmlNode node2 in node3)
                                            {
                                                if (node2.ChildNodes.Count == 1)
                                                {
                                                    this.XmlToObject(oPut, node2.Name, node2.InnerText);
                                                }
                                                else
                                                {
                                                    for (int i = 0; i < node2.ChildNodes.Count; i++)
                                                    {
                                                        this.XmlToObject(node2.Name, oPut, node2.ChildNodes[i].Name, node2.ChildNodes[i].InnerText);
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
                    rsp.code = "-1";
                }
                return false;
            }
            catch (Exception exception)
            {
                rsp.args = strXml;
                rsp.IsError = true;
                rsp.code = "8008";
                rsp.msg = "连接服务器发生错误！" + exception.Message;
                return false;
            }
        }
    }
}

