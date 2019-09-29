using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.TbBusinessEntity;
using ShopNum1.TbTopCommon;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class TbCIDSpecification : PageBase, IRequiresSessionState
    {
        private string string_4 = string.Empty;

        protected void Button1_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Spec_Action) LogicFactory.CreateShopNum1_Spec_Action();
            if (ViewState["cid"] == null)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof (Page), "msg", "alert(\"还没选择分类\")", true);
            }
            else
            {
                string str2 = string.Empty;
                str2 = ViewState["cid"].ToString();
                action.GetTbCid(str2);
                string name = string.Empty;
                if (ViewState["cName1"] != null)
                {
                    name = ViewState["cName1"].ToString();
                }
                if (ViewState["cName2"] != null)
                {
                    name = name + ViewState["cName2"];
                }
                if (ViewState["cName3"] != null)
                {
                    name = name + ViewState["cName3"];
                }
                if (ViewState["cName4"] != null)
                {
                    name = name + ViewState["cName4"];
                }
                if (ViewState["cName5"] != null)
                {
                    name = name + ViewState["cName5"];
                }
                ChangeCname(name);
                method_5(str2, string_4.Trim());
            }
        }

        protected void ButtonCatetory_Click(object sender, EventArgs e)
        {
            if (ViewState["cid"] == null)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof (Page), "msg", "alert(\"还没选择分类\")", true);
            }
            else
            {
                int num = 0;
                var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
                var action2 = new ShopNum1_CategoryType_Action();
                if ((!string.IsNullOrEmpty(ListBoxTop.SelectedValue) && string.IsNullOrEmpty(lbox1.SelectedValue)) &&
                    string.IsNullOrEmpty(lbox2.SelectedValue))
                {
                    var type = new ShopNum1_CategoryType
                        {
                            Name = Operator.FilterString(ListBoxTop.SelectedItem.Text.Replace("->", "").Trim()),
                            OrderID = 0,
                            CreateUser = "admin",
                            ModifyUser = "admin",
                            Description = Operator.FilterString(ListBoxTop.SelectedItem.Text.Replace("->", "").Trim()),
                            IsShow = 1
                        };
                    int num2 = action2.Add_CategoryTypeInto(type);
                    var category3 = new ShopNum1_ProductCategory
                        {
                            Name = ListBoxTop.SelectedItem.Text.Replace("->", "").Trim(),
                            Keywords = ListBoxTop.SelectedItem.Text.Replace("->", "").Trim(),
                            Description = ListBoxTop.SelectedItem.Text.Replace("->", "").Trim(),
                            OrderID = 0,
                            logoimg = "",
                            IsShow = 1,
                            CategoryLevel = 1,
                            FatherID = 0,
                            CreateUser = "admin",
                            CreateTime = DateTime.Now,
                            ModifyUser = "admin",
                            ModifyTime = DateTime.Now,
                            IsDeleted = 0,
                            CategoryType = num2,
                            CategoryTypeName = ListBoxTop.SelectedItem.Text.Replace("->", "").Trim()
                        };
                    object obj3 = action.Add1(category3);
                    num++;
                    string str = string.Empty;
                    if (ListBoxTop.SelectedValue == "1")
                    {
                        str = "40,50011665,50008907,99";
                    }
                    if (ListBoxTop.SelectedValue == "2")
                    {
                        str = "30,16,50011740,50006843,50006842,1625,50010404";
                    }
                    if (ListBoxTop.SelectedValue == "3")
                    {
                        str =
                            "50023904,1512,14,1201,1101,50019780,50018222,11,50018264,50008090,50012164,50007218,50018004,20";
                    }
                    if (ListBoxTop.SelectedValue == "4")
                    {
                        str = "50022703,50011972,50012100,50012082,50002768";
                    }
                    if (ListBoxTop.SelectedValue == "5")
                    {
                        str = "50010788,1801,50023282,50011397,28,50013864,50468001";
                    }
                    if (ListBoxTop.SelectedValue == "6")
                    {
                        str = "35,50014812,50022517,50008165,25";
                    }
                    if (ListBoxTop.SelectedValue == "7")
                    {
                        str = "50020808,50020857,50008164,50020611,27,50020332,50020485,50020579,50008163,50023804";
                    }
                    if (ListBoxTop.SelectedValue == "8")
                    {
                        str = "21,50016349,50016348,50020275,50002766,50016422,2813,50025705,50026316,50026800,50050359";
                    }
                    if (ListBoxTop.SelectedValue == "9")
                    {
                        str = "50010728,50013886,50011699,50012029,50510002";
                    }
                    if (ListBoxTop.SelectedValue == "10")
                    {
                        str = "50025707,50011949,23,33,34,50017300,29,50014442,50454031";
                    }
                    if (ListBoxTop.SelectedValue == "11")
                    {
                        str =
                            "120950001,50026555,50026523,50008075,50019095,50014927,26,50050471,50007216,50018252,50014811,50023575,50024451,50024971,50025004,50025110,50074001,50158001,50025111";
                    }
                    if (ListBoxTop.SelectedValue == "12")
                    {
                        str = "121266001,50488001,120894001,50016350,50023724,50230002,50690010";
                    }
                    List<ShopNum1_TbSysItemCat> list3 = method_7("0", str);
                    if ((list3 != null) && (list3.Count != 0))
                    {
                        foreach (ShopNum1_TbSysItemCat cat2 in list3)
                        {
                            var category2 = new ShopNum1_ProductCategory
                                {
                                    Name = cat2.name,
                                    Keywords = cat2.name,
                                    Description = cat2.name,
                                    OrderID = 0,
                                    logoimg = "",
                                    IsShow = 1,
                                    CategoryLevel = 2,
                                    FatherID = Convert.ToInt32(obj3),
                                    CreateUser = "admin",
                                    CreateTime = DateTime.Now,
                                    ModifyUser = "admin",
                                    ModifyTime = DateTime.Now,
                                    IsDeleted = 0,
                                    CategoryType = num2,
                                    CategoryTypeName = ListBoxTop.SelectedItem.Text.Replace("->", "").Trim()
                                };
                            object obj2 = action.Add1(category2);
                            num++;
                            List<ShopNum1_TbSysItemCat> list2 = method_6(cat2.cid);
                            if ((list2 != null) && (list2.Count != 0))
                            {
                                var list = new List<ShopNum1_ProductCategory>();
                                foreach (ShopNum1_TbSysItemCat cat in list2)
                                {
                                    var category = new ShopNum1_ProductCategory
                                        {
                                            Name = cat.name,
                                            Keywords = cat.name,
                                            Description = cat.name,
                                            OrderID = 0,
                                            logoimg = "",
                                            IsShow = 1,
                                            CategoryLevel = 3,
                                            FatherID = Convert.ToInt32(obj2),
                                            CreateUser = "admin",
                                            CreateTime = DateTime.Now,
                                            ModifyUser = "admin",
                                            ModifyTime = DateTime.Now,
                                            IsDeleted = 0,
                                            CategoryType = num2,
                                            CategoryTypeName = ListBoxTop.SelectedItem.Text.Replace("->", "").Trim()
                                        };
                                    action.Add1(category);
                                }
                                action.AddList(list);
                                num++;
                            }
                        }
                    }
                    if (num > 0)
                    {
                          HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                        var operateLog = new ShopNum1_OperateLog
                            {
                                Record = "导入淘宝分类规格",
                                OperatorID = cookie2.Values["LoginID"].ToString(),
                                IP = Globals.IPAddress,
                                PageName = "TbCIDSpecification.aspx",
                                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            };
                        base.OperateLog(operateLog);
                        MessageBox.Show("分类导入成功！");
                    }
                    else
                    {
                        MessageBox.Show("分类导入失败！");
                    }
                }
            }
        }

        public void ChangeCname(string name)
        {
            string source = string.Empty;
            source = name.Replace(" ", "");
            if (source.Contains(' '))
            {
                ChangeCname(source);
            }
            string_4 = source;
        }

        public bool CheckSpecDetailExist(string tbPropvalue)
        {
            DataTable table =
                ((ShopNum1_Spec_Action) LogicFactory.CreateShopNum1_Spec_Action()).SpecificationDetailsGetByTbPropValue(
                    tbPropvalue);
            if ((table == null) || (table.Rows.Count == 0))
            {
                return false;
            }
            return true;
        }

        protected int GetOrderID(string filed, string table)
        {
            return (1 + ShopNum1_Common_Action.ReturnMaxID(filed, table));
        }

        protected void lbox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["cid"] = lbox1.SelectedValue;
            ViewState["cName1"] = lbox1.SelectedItem.Text;
            List<ShopNum1_TbSysItemCat> list = method_6(lbox1.SelectedValue);
            if ((list != null) && (list.Count != 0))
            {
                foreach (ShopNum1_TbSysItemCat cat in list)
                {
                    if (cat.is_parent)
                    {
                        cat.name = cat.name + "           ->";
                    }
                }
                lbox2.Visible = true;
                lbox3.Visible = false;
                lbox4.Visible = false;
                lbox5.Visible = false;
                lbox2.DataSource = list;
                lbox2.DataTextField = "name";
                lbox2.DataValueField = "cid";
                lbox2.DataBind();
                lbox2.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
            else
            {
                lbox2.Visible = false;
                lbox3.Visible = false;
                lbox4.Visible = false;
                lbox5.Visible = false;
                ViewState["cid"] = lbox1.SelectedValue;
                ViewState["cName1"] = lbox1.SelectedItem.Text;
            }
        }

        protected void lbox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["cid"] = lbox2.SelectedValue;
            ViewState["cName2"] = lbox2.SelectedItem.Text;
            List<ShopNum1_TbSysItemCat> list = method_6(lbox2.SelectedValue);
            if ((list != null) && (list.Count != 0))
            {
                foreach (ShopNum1_TbSysItemCat cat in list)
                {
                    if (cat.is_parent)
                    {
                        cat.name = cat.name + "           ->";
                    }
                }
                lbox3.Visible = true;
                lbox4.Visible = false;
                lbox5.Visible = false;
                lbox3.DataSource = list;
                lbox3.DataTextField = "name";
                lbox3.DataValueField = "cid";
                lbox3.DataBind();
                lbox2.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
            else
            {
                lbox3.Visible = false;
                lbox4.Visible = false;
                lbox5.Visible = false;
                ViewState["cid"] = lbox2.SelectedValue;
                ViewState["cName2"] = lbox2.SelectedItem.Text;
            }
        }

        protected void lbox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["cid"] = lbox3.SelectedValue;
            ViewState["cName3"] = lbox3.SelectedItem.Text;
            List<ShopNum1_TbSysItemCat> list = method_6(lbox3.SelectedValue);
            if ((list != null) && (list.Count != 0))
            {
                foreach (ShopNum1_TbSysItemCat cat in list)
                {
                    if (cat.is_parent)
                    {
                        cat.name = cat.name + "           ->";
                    }
                }
                lbox4.Visible = true;
                lbox5.Visible = false;
                lbox4.DataSource = list;
                lbox4.DataTextField = "name";
                lbox4.DataValueField = "cid";
                lbox4.DataBind();
                lbox2.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
            else
            {
                lbox4.Visible = false;
                lbox5.Visible = false;
                ViewState["cid"] = lbox3.SelectedValue;
                ViewState["cName3"] = lbox3.SelectedItem.Text;
            }
        }

        protected void lbox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["cid"] = lbox4.SelectedValue;
            ViewState["cName4"] = lbox4.SelectedItem.Text;
            List<ShopNum1_TbSysItemCat> list = method_6(lbox4.SelectedValue);
            if ((list != null) && (list.Count != 0))
            {
                foreach (ShopNum1_TbSysItemCat cat in list)
                {
                    if (cat.is_parent)
                    {
                        cat.name = cat.name + "           ->";
                    }
                }
                lbox5.Visible = true;
                lbox5.DataSource = list;
                lbox5.DataTextField = "name";
                lbox5.DataValueField = "cid";
                lbox5.DataBind();
                lbox2.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
            else
            {
                lbox5.Visible = false;
                ViewState["cid"] = lbox4.SelectedValue;
                ViewState["cName4"] = lbox4.SelectedItem.Text;
            }
        }

        protected void lbox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["cid"] = lbox5.SelectedValue;
            ViewState["cName5"] = lbox5.SelectedItem.Text;
        }

        protected void ListBoxTop_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["cid"] = ListBoxTop.SelectedValue;
            ViewState["cName1"] = ListBoxTop.SelectedItem.Text;
            string str = string.Empty;
            if (ListBoxTop.SelectedValue == "1")
            {
                str = "40,50011665,50008907,99";
            }
            if (ListBoxTop.SelectedValue == "2")
            {
                str = "30,16,50011740,50006843,50006842,1625,50010404";
            }
            if (ListBoxTop.SelectedValue == "3")
            {
                str = "50023904,1512,14,1201,1101,50019780,50018222,11,50018264,50008090,50012164,50007218,50018004,20";
            }
            if (ListBoxTop.SelectedValue == "4")
            {
                str = "50022703,50011972,50012100,50012082,50002768";
            }
            if (ListBoxTop.SelectedValue == "5")
            {
                str = "50010788,1801,50023282,50011397,28,50013864,50468001";
            }
            if (ListBoxTop.SelectedValue == "6")
            {
                str = "35,50014812,50022517,50008165,25";
            }
            if (ListBoxTop.SelectedValue == "7")
            {
                str = "50020808,50020857,50008164,50020611,27,50020332,50020485,50020579,50008163,50023804";
            }
            if (ListBoxTop.SelectedValue == "8")
            {
                str = "21,50016349,50016348,50020275,50002766,50016422,2813,50025705,50026316,50026800,50050359";
            }
            if (ListBoxTop.SelectedValue == "9")
            {
                str = "50010728,50013886,50011699,50012029,50510002";
            }
            if (ListBoxTop.SelectedValue == "10")
            {
                str = "50025707,50011949,23,33,34,50017300,29,50014442,50454031";
            }
            if (ListBoxTop.SelectedValue == "11")
            {
                str =
                    "120950001,50026555,50026523,50008075,50019095,50014927,26,50050471,50007216,50018252,50014811,50023575,50024451,50024971,50025004,50025110,50074001,50158001,50025111";
            }
            if (ListBoxTop.SelectedValue == "12")
            {
                str = "121266001,50488001,120894001,50016350,50023724,50230002,50690010";
            }
            List<ShopNum1_TbSysItemCat> list = method_7("0", str);
            try
            {
                foreach (ShopNum1_TbSysItemCat cat in list)
                {
                    if (cat.is_parent)
                    {
                        cat.name = cat.name + "           ->";
                    }
                }
            }
            catch
            {
                MessageBox.Show("淘宝系统参数设置不正确！");
            }
            lbox1.Visible = true;
            lbox2.Visible = false;
            lbox3.Visible = false;
            lbox4.Visible = false;
            lbox5.Visible = false;
            lbox1.DataSource = list;
            lbox1.DataTextField = "name";
            lbox1.DataValueField = "cid";
            lbox1.DataBind();
        }

        private void method_5(string string_5, string string_6)
        {
            var param = new Dictionary<string, string>();
            param.Add("fields", "pid,name,must,multi,prop_values,is_sale_prop,is_enum_prop");
            param.Add("cid", string_5);
            string strXml = TopAPI.GetItemcatsPost(TopConfig.AdminAppkey, TopConfig.AdminSecret, "taobao.itemprops.get",
                                                   param);
            var objs = new List<ShopNum1_TbPropValue>();
            var rsp = new ErrorRsp();
            new Parser().XmlToObject2(strXml, "itemprops_get", "item_props/item_prop", objs, rsp);
            if (!rsp.IsError)
            {
                var action = (ShopNum1_Spec_Action) LogicFactory.CreateShopNum1_Spec_Action();
                var action2 = (ShopNum1_ShopProductProp_Action) LogicFactory.CreateShopNum1_ShopProductProp_Action();
                var spec = new ShopNum1_Spec();
                int num2 = 0;
                if (objs.Count == 0)
                {
                    MessageBox.Show("该分类下没有规格属性!");
                }
                else
                {
                    foreach (ShopNum1_TbPropValue value2 in objs)
                    {
                        int num;
                        string str2;
                        if (value2.is_sale_prop)
                        {
                            spec.SpecName = value2.name;
                            spec.Memo = string_6;
                            spec.ShowType = 0;
                            int maxGuid = action.GetMaxGuid();
                            spec.ID = maxGuid;
                            spec.OrderID = maxGuid;
                            spec.tbProp = value2.pid.ToString();
                            var list4 = new List<ShopNum1_TbPropValue>();
                            new Parser().NewXmlToObject2(strXml, "itemprops_get",
                                                         "item_props/item_prop/prop_values/prop_value", list4, rsp,
                                                         value2.pid.ToString(), "pid");
                            var listSpecValue = new List<ShopNum1_SpecValue>();
                            foreach (ShopNum1_TbPropValue value3 in list4)
                            {
                                str2 = value2.pid.ToString() + ":" + value3.vid.ToString();
                                if (!CheckSpecDetailExist(str2))
                                {
                                    ShopNum1_SpecValue value4;
                                    value4 = new ShopNum1_SpecValue
                                        {
                                            Name = value3.name,
                                            Imagepath = "",
                                            tbPropValue = value3.vid.ToString(),
                                            OrderId = 0//value4.ID
                                        };
                                    listSpecValue.Add(value4);
                                }
                            }
                            num = action.Add(spec, listSpecValue);
                            num2 += num;
                        }
                        else if (!value2.is_sale_prop)
                        {
                            var model = new ShopNum1_ShopProductProp
                                {
                                    ID = GetOrderID("ID", "ShopNum1_ShopProductProp"),
                                    OrderID = GetOrderID("ID", "ShopNum1_ShopProductProp"),
                                    PropName = value2.name
                                };
                            if (value2.is_enum_prop)
                            {
                                model.ShowType = Convert.ToByte("2");
                            }
                            else if (value2.multi)
                            {
                                model.ShowType = Convert.ToByte("3");
                            }
                            else if (!value2.multi)
                            {
                                model.ShowType = Convert.ToByte("1");
                            }
                            else if (!value2.is_enum_prop)
                            {
                                model.ShowType = Convert.ToByte("0");
                            }
                            model.Content = string_6;
                            model.IsImport = false;
                            var list5 = new List<ShopNum1_TbPropValue>();
                            new Parser().NewXmlToObject2(strXml, "itemprops_get",
                                                         "item_props/item_prop/prop_values/prop_value", list5, rsp,
                                                         value2.pid.ToString(), "pid");
                            var shopProductPropValues = new List<ShopNum1_ShopProductPropValue>();
                            foreach (ShopNum1_TbPropValue value3 in list5)
                            {
                                str2 = value2.pid.ToString() + ":" + value3.vid.ToString();
                                if (!CheckSpecDetailExist(str2))
                                {
                                    ShopNum1_ShopProductPropValue value5;
                                    value5 = new ShopNum1_ShopProductPropValue
                                        {
                                            PropId = model.ID,
                                            OrderID = model.ID,
                                            //value5.ID,
                                            Name = value3.name
                                        };
                                    shopProductPropValues.Add(value5);
                                }
                            }
                            num = action2.Add(model, shopProductPropValues);
                            num2 += num;
                        }
                    }
                    if (num2 > 0)
                    {
                          HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                        var operateLog = new ShopNum1_OperateLog
                            {
                                Record = "导入淘宝分类规格",
                                OperatorID = cookie2.Values["LoginID"].ToString(),
                                IP = Globals.IPAddress,
                                PageName = "TbCIDSpecification.aspx",
                                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            };
                        base.OperateLog(operateLog);
                        MessageBox.Show("导入成功!");
                    }
                }
            }
        }

        private List<ShopNum1_TbSysItemCat> method_6(string string_5)
        {
            var param = new Dictionary<string, string>();
            param.Add("fields", "cid,parent_cid,name,parent_name,is_parent,status,sort_order");
            param.Add("parent_cid", string_5);
            string strXml = TopAPI.GetItemcatsPost(TopConfig.AdminAppkey, TopConfig.AdminSecret, "taobao.itemcats.get",
                                                   param);
            var objs = new List<ShopNum1_TbSysItemCat>();
            var parser = new Parser();
            var rsp = new ErrorRsp();
            parser.XmlToObject2(strXml, "itemcats_get", "item_cats/item_cat", objs, rsp);
            if (rsp.IsError)
            {
                return null;
            }
            return objs;
        }

        private List<ShopNum1_TbSysItemCat> method_7(string string_5, string string_6)
        {
            var param = new Dictionary<string, string>();
            param.Add("fields", "cid,parent_cid,name,parent_name,is_parent,status,sort_order");
            param.Add("parent_cid", string_5);
            param.Add("cids", string_6);
            string strXml = TopAPI.GetItemcatsPost(TopConfig.AdminAppkey, TopConfig.AdminSecret, "taobao.itemcats.get",
                                                   param);
            var objs = new List<ShopNum1_TbSysItemCat>();
            var parser = new Parser();
            var rsp = new ErrorRsp();
            parser.XmlToObject2(strXml, "itemcats_get", "item_cats/item_cat", objs, rsp);
            if (rsp.IsError)
            {
                return null;
            }
            return objs;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                lbox1.Visible = false;
            }
        }
    }
}