using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    public class ProductAttribute : BaseWebControl
    {
        private readonly ShopNum1_Brand_Action shopNum1_Brand_Action =
            ((ShopNum1_Brand_Action) LogicFactory.CreateShopNum1_Brand_Action());

        private readonly ShopNum1_ShopProductPropValue_Action shopNum1_ShopProductPropValue_Action =
            ((ShopNum1_ShopProductPropValue_Action) LogicFactory.CreateShopNum1_ShopProductPropValue_Action());

        private readonly ShopNum1_ShopProductProp_Action shopNum1_ShopProductProp_Action =
            ((ShopNum1_ShopProductProp_Action) LogicFactory.CreateShopNum1_ShopProductProp_Action());

        private HtmlGenericControl BrandBorder;
        private HtmlGenericControl PropBorder;
        private Repeater RepeaterPtoudctBrand;
        private Repeater RepeaterShopProductProp;

        private bool bool_0;
        private bool bool_1;
        private Dictionary<string, string> dictionary_0;
        private HiddenField hiddenField_0;

        private string skinFilename = "ProductAttribute.ascx";
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;

        public ProductAttribute()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        private string strProductName { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterShopProductProp = (Repeater) skin.FindControl("RepeaterShopProductProp");
            RepeaterShopProductProp.ItemDataBound += RepeaterShopProductProp_ItemDataBound;
            RepeaterPtoudctBrand = (Repeater) skin.FindControl("RepeaterPtoudctBrand");
            RepeaterPtoudctBrand.ItemDataBound += RepeaterPtoudctBrand_ItemDataBound;
            string_1 = (Page.Request.QueryString["Code"] == null) ? "0" : Page.Request.QueryString["Code"];
            string_2 = (Page.Request.QueryString["brandguid"] == null) ? "-1" : Page.Request.QueryString["brandguid"];
            BrandBorder = (HtmlGenericControl) skin.FindControl("BrandBorder");
            PropBorder = (HtmlGenericControl) skin.FindControl("PropBorder");
            string_3 = (Page.Request.QueryString["pvalue"] == null) ? "-1" : Page.Request.QueryString["pvalue"];
            Func<string, bool> func = method_5;
            if (string_3 != "-1")
            {
                func(string_3);
            }
            bool flag = method_2();
            bool flag2 = BindData();
            if (!flag)
            {
                BrandBorder.Visible = false;
            }
            if (!flag2)
            {
                PropBorder.Visible = false;
            }
            if (!(!flag2 || flag))
            {
                PropBorder.Style.Add("border-top", "1px solid #674E40;");
            }
            strProductName = Page.Request.QueryString["productName"];
            if (strProductName != null)
            {
                BrandBorder.Visible = false;
                PropBorder.Visible = false;
            }
        }

        private bool BindData()
        {
            if ((string_1 != "0") && (string_1.Length > 5))
            {
                DataTable searchListPropByCode = shopNum1_ShopProductProp_Action.GetSearchListPropByCode(string_1);
                if ((searchListPropByCode != null) && (searchListPropByCode.Rows.Count > 0))
                {
                    DataTable table = searchListPropByCode;
                    table.Columns.Add("linkurl", typeof (string));
                    string_4 = string.Empty;
                    foreach (DataRow row in table.Rows)
                    {
                        string_4 = string_4 + row["ID"] + "m0-";
                    }
                    if (string_4 != string.Empty)
                    {
                        string_4 = string_4.Substring(0, string_4.Length - 1);
                    }
                    foreach (DataRow row in table.Rows)
                    {
                        string str = string_4;
                        if (dictionary_0 != null)
                        {
                            foreach (var pair in dictionary_0)
                            {
                                if (((pair.Key != null) && (pair.Value != null)) && (pair.Key != row["ID"].ToString()))
                                {
                                    string oldValue = pair.Key + "m0";
                                    str = str.Replace(oldValue, pair.Key + "m" + pair.Value);
                                }
                            }
                        }
                        row["linkurl"] = method_4(string_1, string_2, str);
                    }
                    RepeaterShopProductProp.DataSource = table;
                    RepeaterShopProductProp.DataBind();
                    return true;
                }
                return false;
            }
            return false;
        }

        protected void method_1(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var field = (HiddenField) e.Item.FindControl("HiddenFieldPropValueID");
                var control = (HtmlGenericControl) e.Item.FindControl("SpanPropValue");
                if (dictionary_0 != null)
                {
                    foreach (var pair in dictionary_0)
                    {
                        if (((pair.Key != null) && (pair.Value != null)) &&
                            ((pair.Key == hiddenField_0.Value) && (pair.Value == field.Value)))
                        {
                            bool_1 = true;
                            control.Attributes.Add("class", "buxian");
                        }
                    }
                }
            }
        }

        private bool method_2()
        {
            if (string_1.Length > 3)
            {
                DataTable table = shopNum1_Brand_Action.BindProductBrand(string_1);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    DataTable table2 = table;
                    table2.Columns.Add("linkurl", typeof (string));
                    DataRow row3 = table2.NewRow();
                    row3["name"] = "不限";
                    row3["Guid"] = Guid.Empty.ToString();
                    row3["linkurl"] = "";
                    table2.Rows.InsertAt(row3, 0);
                    DataRow row2 = table2.NewRow();
                    foreach (DataRow row in table2.Rows)
                    {
                        if (string_3 != "-1")
                        {
                            if (row["Guid"].ToString() != "00000000-0000-0000-0000-000000000000")
                            {
                                row["linkurl"] = method_4(string_1, row[0].ToString(), string_3);
                            }
                            else
                            {
                                row["linkurl"] = method_4(string_1, "-1", string_3);
                            }
                        }
                        else if (row["Guid"].ToString() != "00000000-0000-0000-0000-000000000000")
                        {
                            row["linkurl"] = method_3(string_1, row[0].ToString());
                        }
                        else
                        {
                            row["linkurl"] = method_3(string_1, "-1");
                        }
                        if (((row["Guid"].ToString() == string_2) && (string_2 != Guid.Empty.ToString())) &&
                            (string_2 != "-1"))
                        {
                            row2["name"] = row[1];
                            row2["Guid"] = row[0];
                            row2["linkurl"] = row[3];
                            row.Delete();
                        }
                    }
                    if (((row2["Guid"].ToString() == string_2) && (string_2 != Guid.Empty.ToString())) &&
                        (string_2 != "-1"))
                    {
                        table2.Rows.InsertAt(row2, 1);
                    }
                    RepeaterPtoudctBrand.DataSource = table2;
                    RepeaterPtoudctBrand.DataBind();
                    if (!bool_0)
                    {
                        var control = (HtmlContainerControl) RepeaterPtoudctBrand.Items[0].FindControl("SpanBrand");
                        control.Attributes.Add("class", "buxian");
                    }
                    return true;
                }
                return false;
            }
            BrandBorder.Visible = false;
            return false;
        }

        private string method_3(string string_6, string string_7)
        {
            string format = "code={0}&brandguid={1}";
            return string.Format(format, string_6, string_7);
        }

        private string method_4(string string_6, string string_7, string string_8)
        {
            string format = "code={0}&brandguid={1}&Pvalue={2}";
            return string.Format(format, string_6, string_7, string_8);
        }


        private bool method_5(string string_6)
        {
            string[] strArray = string_6.Split(new[] {'-'});
            if (strArray.Length != 0)
            {
                dictionary_0 = new Dictionary<string, string>();
                foreach (string str in strArray)
                {
                    string[] strArray3 = str.Split(new[] {'m'});
                    if (strArray3.Length == 2)
                    {
                        dictionary_0.Add(strArray3[0], strArray3[1]);
                    }
                }
            }
            return true;
        }

        protected void RepeaterShopProductProp_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var repeater = (Repeater) e.Item.FindControl("RepeaterShopProductPropValue");
            repeater.ItemDataBound += method_1;
            hiddenField_0 = (HiddenField) e.Item.FindControl("HiddenFieldPropID");
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                bool_1 = false;
                string str = string.Empty;
                int index = -1;
                DataTable table = shopNum1_ShopProductPropValue_Action.BindProductPropValue(hiddenField_0.Value);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    if (dictionary_0 != null)
                    {
                        foreach (var pair in dictionary_0)
                        {
                            if (pair.Key == hiddenField_0.Value)
                            {
                                str = pair.Value;
                            }
                        }
                    }
                    DataTable table2 = table;
                    table2.Columns.Add("linkurl", typeof (string));
                    DataRow row3 = table2.NewRow();
                    row3["name"] = "不限";
                    row3["id"] = "0";
                    row3["linkurl"] = "";
                    row3["PropID"] = hiddenField_0.Value;
                    table2.Rows.InsertAt(row3, 0);
                    DataRow row2 = table2.NewRow();
                    table2.AcceptChanges();
                    foreach (DataRow row in table2.Rows)
                    {
                        string str2 = string_4;
                        if (dictionary_0 != null)
                        {
                            foreach (var pair2 in dictionary_0)
                            {
                                if (pair2.Key != row["PropID"].ToString())
                                {
                                    string oldValue = pair2.Key + "m0";
                                    str2 = str2.Replace(oldValue, pair2.Key + "m" + pair2.Value);
                                }
                                else
                                {
                                    string introduced16 = pair2.Key + "m0";
                                    str2 = str2.Replace(introduced16, pair2.Key + "m" + row["id"]);
                                }
                            }
                        }
                        else
                        {
                            str2 = str2.Replace(row["PropID"] + "m0", row["PropID"] + "m" + row["id"]);
                        }
                        row["linkurl"] = method_4(string_1, string_2, str2);
                        if ((str == row["id"].ToString()) && (str != "0"))
                        {
                            row2["name"] = row["name"];
                            row2["PropID"] = row["PropID"];
                            row2["id"] = row["id"];
                            row2["linkurl"] = row["linkurl"];
                            index = table2.Rows.IndexOf(row);
                        }
                    }
                    if ((index != -1) && (index != 0))
                    {
                        table2.Rows.RemoveAt(index);
                        table2.AcceptChanges();
                    }
                    if ((str != string.Empty) && (str != "0"))
                    {
                        table2.Rows.InsertAt(row2, 1);
                    }
                    repeater.DataSource = table2;
                    repeater.DataBind();
                    if (!bool_1)
                    {
                        var control = (HtmlGenericControl) repeater.Items[0].FindControl("SpanPropValue");
                        control.Attributes.Add("class", "buxian");
                    }
                }
            }
        }

        protected void RepeaterPtoudctBrand_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.AlternatingItem) || (e.Item.ItemType == ListItemType.Item))
            {
                var field = (HiddenField) e.Item.FindControl("HiddenFieldGuid");
                var control = (HtmlContainerControl) e.Item.FindControl("SpanBrand");
                if (string_2 == field.Value)
                {
                    bool_0 = true;
                    control.Attributes.Add("class", "buxian");
                }
            }
        }
    }
}