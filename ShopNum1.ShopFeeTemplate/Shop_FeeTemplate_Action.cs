using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;
using ShopNum1.Cache;

namespace ShopNum1.ShopFeeTemplate
{
    public class Shop_FeeTemplate_Action
    {
        public bool AddFeeTemplates(List<Shop_FeeTemplate> feetemplates, string path, out string strerror)
        {
            strerror = string.Empty;
            if (!File.Exists(path))
            {
                strerror = "-1";
                return false;
            }
            var document = new XmlDocument();
            document.Load(path);
            XmlNode node = document.SelectSingleNode("template/postagetemplaes");
            int num = method_1(path);
            foreach (Shop_FeeTemplate template in feetemplates)
            {
                if (template.String_1 != "")
                {
                    XmlElement newChild = document.CreateElement("postagetemplae");
                    newChild.SetAttribute("id", num.ToString());
                    newChild.SetAttribute("templateid", template.templateid);
                    newChild.SetAttribute("templatename", template.templatename);
                    newChild.SetAttribute("fee", template.String_1);
                    newChild.SetAttribute("feetype", template.feetype);
                    newChild.SetAttribute("oneadd", template.oneadd);
                    newChild.SetAttribute("regioncode", template.regioncode);
                    newChild.SetAttribute("regionname", template.regionname);
                    newChild.SetAttribute("groupid", template.groupid);
                    newChild.SetAttribute("createtime", template.createtime);
                    newChild.SetAttribute("altertime", template.altertime);
                    newChild.SetAttribute("orderid", template.orderid);
                    newChild.SetAttribute("groupregionnames", template.groupregionnames);
                    newChild.SetAttribute("groupregioncodes", template.groupregioncodes);
                    node.AppendChild(newChild);
                    num++;
                }
            }
            try
            {
                document.Save(path);
                return true;
            }
            catch (Exception exception)
            {
                strerror = exception.Message;
                return false;
            }
        }

        public bool CheckTemplateName(string templatename, string path)
        {
            var set = new DataSet();
            set.ReadXml(path);
            if ((set != null) && (set.Tables.Count > 1))
            {
                DataTable table = set.Tables[1];
                foreach (DataRow row in table.Rows)
                {
                    if (row["templatename"].ToString() == templatename)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool DelByTemplateID(string templateID, string path)
        {
            if (!File.Exists(path))
            {
                return false;
            }
            var set = new DataSet();
            set.ReadXml(path);
            if ((set == null) || (set.Tables.Count <= 1))
            {
                return false;
            }
            string format = "1=1 and templateid='{0}'";
            format = string.Format(format, templateID);
            foreach (DataRow row in set.Tables[1].Select(format))
            {
                row.Delete();
            }
            try
            {
                set.AcceptChanges();
                set.WriteXml(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable GetFeesByFrontCache(string path, string memlogid, string templateid, string regioncode,
            string feetype, bool ishavcache)
        {
            if (!File.Exists(path))
            {
                return null;
            }
            var set = new DataSet();
            if (ishavcache)
            {
                if (CacheHelper.Get(memlogid) == null)
                {
                    set.ReadXml(path);
                }
            }
            else
            {
                set.ReadXml(path);
            }
            if ((set == null) || (set.Tables.Count <= 1))
            {
                return null;
            }
            string filterExpression = "1=1 ";
            if (templateid != "-1")
            {
                filterExpression = filterExpression + " and templateid=" + templateid + " ";
            }
            if (feetype != "-1")
            {
                filterExpression = filterExpression + " and feetype=" + feetype + " ";
            }
            if (regioncode == "000")
            {
                filterExpression = filterExpression + " and groupregioncodes='" + regioncode + "'";
                DataRow[] source = set.Tables[1].Select(filterExpression);
                if ((source == null) || (source.Length == 0))
                {
                    return null;
                }
                return source.CopyToDataTable();
            }
            try
            {
                DataTable table2 = set.Tables[1].Select(filterExpression).CopyToDataTable();
                DataTable table3 = BindData();
                bool flag = false;
                bool flag2 = false;
                bool flag3 = false;
                DataRow row = null;
                DataRow row2 = null;
                DataRow row3 = null;
                foreach (DataRow row5 in table2.Rows)
                {
                    DataRow row4;
                    if ((((row5["feetype"].ToString() != "1") || !flag2) &&
                         ((row5["feetype"].ToString() != "2") || !flag)) &&
                        ((row5["feetype"].ToString() != "2") || !flag3))
                    {
                        string str3 = row5["groupregioncodes"].ToString();
                        if (str3 == "000")
                        {
                            if (row5["feetype"].ToString() == "1")
                            {
                                row2 = table3.NewRow();
                                row2["feetype"] = row5["feetype"].ToString();
                                row2["fee"] = row5["fee"].ToString();
                                row2["oneadd"] = row5["oneadd"].ToString();
                            }
                            else if (row5["feetype"].ToString() == "2")
                            {
                                row = table3.NewRow();
                                row["feetype"] = row5["feetype"].ToString();
                                row["fee"] = row5["fee"].ToString();
                                row["oneadd"] = row5["oneadd"].ToString();
                            }
                            else
                            {
                                row3 = table3.NewRow();
                                row3["feetype"] = row5["feetype"].ToString();
                                row3["fee"] = row5["fee"].ToString();
                                row3["oneadd"] = row5["oneadd"].ToString();
                            }
                        }
                        foreach (string str2 in str3.Split(new[] {','}))
                        {
                            if (str2 == regioncode)
                            {
                                goto Label_03B1;
                            }
                        }
                    }
                    continue;
                    Label_03B1:
                    row4 = table3.NewRow();
                    row4["feetype"] = row5["feetype"].ToString();
                    row4["fee"] = row5["fee"].ToString();
                    row4["oneadd"] = row5["oneadd"].ToString();
                    if (row5["feetype"].ToString() == "1")
                    {
                        flag2 = true;
                    }
                    else if (row5["feetype"].ToString() == "2")
                    {
                        flag = true;
                    }
                    else
                    {
                        flag3 = true;
                    }
                    table3.Rows.Add(row4);
                }
                if (!(flag3 || (row3 == null)))
                {
                    table3.Rows.Add(row3);
                }
                if (!(flag2 || (row2 == null)))
                {
                    table3.Rows.Add(row2);
                }
                if (!(flag || (row == null)))
                {
                    table3.Rows.Add(row);
                }
                return table3;
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetFeesByIDRegion(string path, string templateid, string regioncode, string feetype,
            out string strerror)
        {
            strerror = string.Empty;
            if (!File.Exists(path))
            {
                strerror = "-1";
                return null;
            }
            var set = new DataSet();
            set.ReadXml(path);
            if ((set == null) || (set.Tables.Count <= 1))
            {
                strerror = "0";
                return null;
            }
            string filterExpression = "1=1 ";
            if (templateid != "-1")
            {
                filterExpression = filterExpression + " and templateid='" + templateid + "'";
            }
            if (regioncode == "000")
            {
                filterExpression = filterExpression + " and groupregioncodes='" + regioncode + "'";
            }
            if (feetype != "-1")
            {
                filterExpression = filterExpression + " and feetype='" + feetype + "' ";
            }
            try
            {
                return set.Tables[1].Select(filterExpression, "altertime desc").CopyToDataTable();
            }
            catch (Exception exception)
            {
                strerror = exception.Message;
                return null;
            }
        }

        public int GetMaxFeeTemplateId(string path)
        {
            var set = new DataSet();
            set.ReadXml(path);
            int num = 0;
            if ((set == null) || (set.Tables.Count <= 1))
            {
                return 1;
            }
            DataTable table = set.Tables[1];
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["templateid"]) > num)
                {
                    num = Convert.ToInt32(row["templateid"]);
                }
            }
            return (num + 1);
        }

        private DataTable BindData()
        {
            var table = new DataTable();
            table.Columns.Add("feetype", typeof (string));
            table.Columns.Add("fee", typeof (string));
            table.Columns.Add("oneadd", typeof (string));
            return table;
        }

        private int method_1(string string_0)
        {
            var set = new DataSet();
            set.ReadXml(string_0);
            int num = 0;
            if ((set == null) || (set.Tables.Count <= 1))
            {
                return 1;
            }
            DataTable table = set.Tables[1];
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["id"]) > num)
                {
                    num = Convert.ToInt32(row["id"]);
                }
            }
            return (num + 1);
        }
    }
}