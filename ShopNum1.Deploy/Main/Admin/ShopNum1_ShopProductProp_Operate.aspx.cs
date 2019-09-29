using System;
using System.Collections.Generic;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopNum1_ShopProductProp_Operate : PageBase, IRequiresSessionState
    {
        public DataTable dt_Prop = null;

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
              HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                   
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员新增或更改商品属性",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "ShopNum1_ShopProductProp_Operate.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            base.OperateLog(operateLog);
            Operate();
        }

        protected int GetOrderID(string filed, string table)
        {
            return (1 + ShopNum1_Common_Action.ReturnMaxID(filed, table));
        }

        private void method_5()
        {
            ShopNum1_ShopProductProp propModelByID =
                new ShopNum1_ShopProductProp_Action().GetPropModelByID(int.Parse(HiddenFieldGuid.Value));
            if (propModelByID != null)
            {
                TextBoxProductPropName.Text = propModelByID.PropName;
                TextBoxContent.Text = propModelByID.Content;
                RadioButtonListShowType.SelectedValue = propModelByID.ShowType.ToString();
                if (propModelByID.ShowType.ToString() == "4")
                {
                    ButtonValueAdd.Visible = false;
                    trProp.Visible = false;
                }
                TextBoxOrderID.Text = propModelByID.OrderID.ToString();
                dt_Prop = new ShopNum1_ShopProductPropValue_Action().GetPropValuesByPropID(HiddenFieldGuid.Value);
                if (dt_Prop.Rows.Count == 0)
                {
                    dt_Prop = null;
                }
            }
        }

        protected void Operate()
        {
            var propModel = new ShopNum1_ShopProductProp();
            if (base.Request.QueryString["guid"] == null)
            {
                propModel.ID = GetOrderID("ID", "ShopNum1_ShopProductProp");
            }
            else
            {
                propModel.ID = Convert.ToInt32(HiddenFieldGuid.Value);
            }
            propModel.OrderID = int.Parse(TextBoxOrderID.Text);
            propModel.PropName = TextBoxProductPropName.Text.Trim();
            propModel.ShowType = Convert.ToByte(RadioButtonListShowType.SelectedValue);
            propModel.Content = TextBoxContent.Text.Trim();
            propModel.IsImport = false;
            var shopProductPropValues = new List<ShopNum1_ShopProductPropValue>();
            if (RadioButtonListShowType.SelectedValue == "4")
            {
                var item = new ShopNum1_ShopProductPropValue
                    {
                        PropId = propModel.ID,
                        Name = string.Empty,
                        OrderID = GetOrderID("OrderID", "ShopNum1_ShopProductPropValue")
                    };
                shopProductPropValues.Add(item);
            }
            else if (HiddenFieldValues.Value != "0")
            {
                string[] strArray = HiddenFieldValues.Value.Split(new[] {'|'});
                for (int i = 0; i < strArray.Length; i++)
                {
                    if ((strArray[i] != "") && (strArray[i] != "-1"))
                    {
                        var value3 = new ShopNum1_ShopProductPropValue
                            {
                                ID = Convert.ToInt32(strArray[i].Split(new[] {','})[2]),
                                PropId = propModel.ID,
                                OrderID = Convert.ToInt32(strArray[i].Split(new[] {','})[0]),
                                Name = strArray[i].Split(new[] {','})[1]
                            };
                        shopProductPropValues.Add(value3);
                    }
                }
            }
            var action = (ShopNum1_ShopProductProp_Action) LogicFactory.CreateShopNum1_ShopProductProp_Action();
            int num2 = 0;
            if (HiddenFieldGuid.Value != "-1")
            {
                num2 = action.Update(propModel, shopProductPropValues);
            }
            else
            {
                num2 = action.Add(propModel, shopProductPropValues);
            }
            if (num2 > 0)
            {
                Page.Response.Redirect("ShopNum1_ShopProductProp_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("AddNo");
                MessageShow.Visible = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            HiddenFieldGuid.Value = (Page.Request.QueryString["guid"] == null) ? "-1" : Page.Request.QueryString["guid"];
            if (!base.IsPostBack)
            {
                if ((Common.Common.ReqStr("id") != "0") && (Common.Common.ReqStr("sign") == "del"))
                {
                    ((ShopNum1_ShopProductPropValue_Action) LogicFactory.CreateShopNum1_ShopProductPropValue_Action())
                        .DeleteShopPropValue(Common.Common.ReqStr("id"));
                }
                if (HiddenFieldGuid.Value != "-1")
                {
                    method_5();
                    ButtonAdd.Text = "确认修改";
                    LabelTitle.Text = "编辑商品属性";
                }
                else
                {
                    TextBoxOrderID.Text = Convert.ToString(GetOrderID("OrderID", "ShopNum1_ShopProductProp"));
                }
            }
        }

        protected void Update()
        {
            var propModel = new ShopNum1_ShopProductProp
                {
                    ID = int.Parse(HiddenFieldGuid.Value),
                    PropName = TextBoxProductPropName.Text.Trim(),
                    ShowType = Convert.ToByte(RadioButtonListShowType.SelectedValue),
                    Content = TextBoxContent.Text.Trim(),
                    OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim())
                };
            var shopProductPropValues = new List<ShopNum1_ShopProductPropValue>();
            int orderID = GetOrderID("OrderID", "ShopNum1_ShopProductPropValue");
            if (RadioButtonListShowType.SelectedValue == "4")
            {
                var item = new ShopNum1_ShopProductPropValue
                    {
                        PropId = propModel.ID,
                        Name = string.Empty,
                        OrderID = orderID
                    };
                shopProductPropValues.Add(item);
            }
            var action = (ShopNum1_ShopProductProp_Action) LogicFactory.CreateShopNum1_ShopProductProp_Action();
            if (action.Update(propModel, shopProductPropValues) > 0)
            {
                Page.Response.Redirect("ShopNum1_ShopProductProp_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }
    }
}