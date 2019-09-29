using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System.Text.RegularExpressions;

namespace ShopNum1.Deploy.Main.Themes.Skin_Default.skins
{
    public partial class ShoppingCart1 : BaseMemberControl
    {
        private readonly IShopNum1_Cart_Action ishopNum1_Cart_Action_0 = LogicFactory.CreateShopNum1_Cart_Action();

        private string string_1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                string text = string.Empty;
                if (Page.Request.Cookies["Visitor_LoginCookie"] != null)
                {
                    HttpCookie cookie = Page.Request.Cookies["Visitor_LoginCookie"];
                    HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
                    text = httpCookie.Values["MemLoginID"];
                }
                else
                {
                    var order = new Order();
                    string text2 = "visitor_" + order.CreateOrderNumber();
                    HttpCookie httpCookie2 = HttpSecureCookie.Encode(new HttpCookie("Visitor_LoginCookie")
                        {
                            Values =
                                {
                                    {
                                        "MemLoginID",
                                        text2
                                    }
                                }
                        });
                    httpCookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                    Page.Response.AppendCookie(httpCookie2);
                    text = text2;
                }
                string_1 = text;
            }
            else
            {
                HttpCookie cookie2 = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie httpCookie3 = HttpSecureCookie.Decode(cookie2);
                string_1 = httpCookie3.Values["MemLoginID"];
            }

           
            
            if (!Page.IsPostBack && Page.Request.UrlReferrer != null)
            {
                BindData();
                HiddenFieldURLReferrer.Value = Page.Request.UrlReferrer.ToString();
            }
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButtonDelete_Click(object sender, EventArgs e)
        {
            string text = string.Empty;
            foreach (RepeaterItem repeaterItem in RepeaterShopCart1.Items)
            {
                var repeater = (Repeater) repeaterItem.FindControl("RepeaterShopProduct");
                foreach (RepeaterItem repeaterItem2 in repeater.Items)
                {
                    var checkBox = repeaterItem2.FindControl("checkboxAll") as CheckBox;
                    if (checkBox.Checked)
                    {
                        var hiddenField = repeaterItem2.FindControl("HiddenFieldGuid") as HiddenField;
                        if (text != string.Empty)
                        {
                            text = text + ",'" + hiddenField.Value + "'";
                        }
                        else
                        {
                            text = text + "'" + hiddenField.Value + "'";
                        }
                    }
                }
            }
            if (text == string.Empty)
            {
                MessageBox.Show("请选择您要删除的记录!");
            }
            else
            {
                int num = ishopNum1_Cart_Action_0.Delete(text.Trim().Replace("\n", "").Replace("\t", ""));
                if (num > 0)
                {
                    MessageBox.Show("删除成功!");
                    BindData();
                }
                else
                {
                    MessageBox.Show("删除失败!");
                }
            }
        }

        /// <summary>
        /// 批量移入收藏夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButtonRemove_Click(object sender, EventArgs e)
        {
            int Category = 1;
            if (Page.Request.QueryString["category"] != null)
            {
                Category = Convert.ToInt32(Page.Request.QueryString["category"]);
            }
            else if (Page.Request.Cookies["category"]!=null)
            {
                Category = Convert.ToInt32(Page.Request.Cookies["category"].Value);
            }
            int num = 0;
            string text = string.Empty;
            foreach (RepeaterItem repeaterItem in RepeaterShopCart1.Items)
            {
                var repeater = (Repeater) repeaterItem.FindControl("RepeaterShopProduct");
                foreach (RepeaterItem repeaterItem2 in repeater.Items)
                {
                    var checkBox = repeaterItem2.FindControl("checkboxAll") as CheckBox;
                    if (checkBox.Checked)
                    {
                        var hiddenField = repeaterItem2.FindControl("HiddenFieldGuid") as HiddenField;
                        var hiddenField2 = repeaterItem2.FindControl("HiddenFieldProductGuid") as HiddenField;
                        if (text != string.Empty)
                        {
                            text = text + ",'" + hiddenField.Value + "'";
                        }
                        else
                        {
                            text = text + "'" + hiddenField.Value + "'";
                        }
                        if (text == string.Empty)
                        {
                            MessageBox.Show("请选择您要操作的记录!");
                            return;
                        }
                        DataTable infoByGuid = ishopNum1_Cart_Action_0.GetInfoByGuid(hiddenField.Value);
                        if (infoByGuid != null && infoByGuid.Rows.Count > 0)
                        {
                            string shopID = infoByGuid.Rows[0]["SellName"].ToString();
                            string shopPrice = infoByGuid.Rows[0]["ShopPrice"].ToString();
                            string productName = infoByGuid.Rows[0]["Name"].ToString();
                            string sellLoginID = infoByGuid.Rows[0]["ShopID"].ToString();
                            var shop_Collect_Action =
                                (Shop_Collect_Action) ShopFactory.LogicFactory.CreateShop_Collect_Action();
                            if (
                                shop_Collect_Action.AddProductCollect(string_1, hiddenField2.Value, shopID, "0",
                                                                      shopPrice, productName, sellLoginID, Category) > 0)
                            {
                                num++;
                                shop_Collect_Action.ProductCollectNum(hiddenField2.Value);
                            }
                        }
                    }
                }
            }
            if (text == string.Empty)
            {
                MessageBox.Show("请选择您要操作的记录!");
            }
            else
            {
                int num2 = ishopNum1_Cart_Action_0.Delete(text.Trim().Replace("\n", "").Replace("\t", ""));
                if (num2 > 0 && num > 0)
                {
                    MessageBox.Show("批量移入收藏夹成功!");
                    BindData();
                }
                else
                {
                    MessageBox.Show("批量移入收藏夹失败!");
                }
            }
        }

        /// <summary>
        /// 更新购物车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButtonUpdate_Click(object sender, EventArgs e)
        {
            var shop_Product_Action = (Shop_Product_Action) ShopFactory.LogicFactory.CreateShop_Product_Action();
            int num = 0;
            ishopNum1_Cart_Action_0.SearchByMemLoginID(string_1);
            var list = new List<ShopNum1_Shop_Cart>();
            int i = 0;
            while (i < RepeaterShopCart1.Items.Count)
            {
                var repeater = (Repeater) RepeaterShopCart1.Items[i].FindControl("RepeaterShopProduct");
                int j = 0;
                while (j < repeater.Items.Count)
                {
                    var shopNum1_Shop_Cart = new ShopNum1_Shop_Cart();
                    shopNum1_Shop_Cart.Guid =
                        new Guid(((HiddenField) repeater.Items[j].FindControl("HiddenFieldGuid")).Value);
                    shopNum1_Shop_Cart.BuyPrice =
                        Convert.ToDecimal(((Label) repeater.Items[j].FindControl("labelBuyPrice")).Text);
                    int num2 = 1;
                    try
                    {
                        shopNum1_Shop_Cart.BuyNumber =
                            Convert.ToInt32(((TextBox) repeater.Items[j].FindControl("TextBoxBuyNumber")).Text);
                        goto IL_194;
                    }
                    catch (Exception)
                    {
                        num2 = 0;
                        goto IL_194;
                    }
                    IL_118:
                    string value = ((HiddenField) repeater.Items[j].FindControl("HiddenFieldProductGuid")).Value;
                    int limitBuyCount = shop_Product_Action.GetLimitBuyCount(value);
                    if (limitBuyCount >= shopNum1_Shop_Cart.BuyNumber || limitBuyCount == 0)
                    {
                        list.Add(shopNum1_Shop_Cart);
                        j++;
                        continue;
                    }
                    shopNum1_Shop_Cart.BuyNumber = limitBuyCount;
                    MessageBox.Show("库存不足!");
                    DataBind();
                    return;
                    IL_194:
                    if (num2 == 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "alert(\"购买数量格式不对！\");", true);
                        return;
                    }
                    goto IL_118;
                }
                if (list.Count > 0)
                {
                    num = ishopNum1_Cart_Action_0.Update(list);
                    i++;
                    continue;
                }
                MessageBox.Show("当前购物车没有添加商品！");
                return;
            }
            if (num > 0)
            {
                BindData();
                MessageBox.Show("更新购物车成功!");
                return;
            }
            MessageBox.Show("更新购物车失败！");
        }

        protected void method_0(object sender, EventArgs e)
        {
            string commandArgument = ((LinkButton) sender).CommandArgument;
            int num = ishopNum1_Cart_Action_0.Delete("'" + commandArgument.Trim() + "'");
            if (num > 0)
            {
                MessageBox.Show("删除成功!");
                BindData();
            }
            else
            {
                MessageBox.Show("删除失败!");
            }
        }

        protected void LinkButtonIDelete_Click(object sender, EventArgs e)
        {
            string commandArgument = ((LinkButton)sender).CommandArgument;
            int num = ishopNum1_Cart_Action_0.Delete("'" + commandArgument.Trim() + "'");
            if (num > 0)
            {
                MessageBox.Show("删除成功!");
                BindData();
            }
            else
            {
                MessageBox.Show("删除失败!");
            }
        }
        protected void method_1(object sender, EventArgs e)
        {
            int Category = 1;
            if (Page.Request.QueryString["category"] != null)
            {
                Category = Convert.ToInt32(Page.Request.QueryString["category"]);
            }
            else
            {
                Category = Convert.ToInt32(Page.Request.Cookies["category"].Value);
            }
            string commandArgument = ((LinkButton) sender).CommandArgument;
            string[] array = commandArgument.Split(new[]
                {
                    ','
                });
            int num = ishopNum1_Cart_Action_0.Delete("'" + array[0] + "'");
            var shop_Collect_Action = (Shop_Collect_Action) ShopFactory.LogicFactory.CreateShop_Collect_Action();
            int num2 = shop_Collect_Action.AddProductCollect(string_1, array[1], array[2], "0", array[3], array[4],
                                                             array[5], Category);
            if (num > 0 && num2 > 0)
            {
                MessageBox.Show("收藏成功!");
                shop_Collect_Action.ProductCollectNum(array[1]);
                BindData();
            }
            else
            {
                MessageBox.Show("已收藏过该商品!");
            }
        }

        /// <summary>
        /// 继续购物
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImageButtonContinue_Click(object sender, ImageClickEventArgs e)
        {
            Page.Response.Redirect(GetPageName.RetDomainUrl("Default"));
        }

        protected void ImageButtonRemove_Click(object sender, ImageClickEventArgs e)
        {
            int num = ishopNum1_Cart_Action_0.DeleteByMemLoginID(string_1);
            if (num > 0)
            {
                BindData();
            }
        }

        /// <summary>
        /// 去结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImageButtonPay_Click(object sender, ImageClickEventArgs e)
        {

            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                string text = Page.Request.Url.ToString()
                                  .Replace("%3a%2f%2f", "://")
                                  .Replace("/", "%2f")
                                  .Replace("&", "%26");
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "script", string.Concat(new[]
                    {
                        "<script>$(function(){ $('#loginbox').show();$('#mylogingo').attr('src','http://",
                        ShopSettings.siteDomain,
                        "/poplogin.aspx?vj=shopcar&backurl=",
                        text,
                        "'); });</script>"
                    }));
            }
            else
            {
                if (RepeaterShopCart1.Items.Count <= 0)
                {
                    MessageBox.Show("当前购物车商品可能被商家删除,请重新商品后去结算！");
                }
                else
                {
                    int num = 0;
                    string text2 = string.Empty;
                    string text211 = string.Empty;
                    decimal shop_category_id22 = 0;
                    decimal count = 0;
                    
                    foreach (RepeaterItem repeaterItem in RepeaterShopCart1.Items)
                    {
                      
                        var repeater = (Repeater) repeaterItem.FindControl("RepeaterShopProduct");
                        foreach (RepeaterItem repeaterItem2 in repeater.Items)
                        {
                            
                            var checkBox = repeaterItem2.FindControl("checkboxAll") as CheckBox;
                            if (checkBox.Checked)
                            {
                                count = count + 1;
                                var hiddenField = repeaterItem2.FindControl("HiddenFieldGuid") as HiddenField;
                                var ProductGuid = repeaterItem2.FindControl("HiddenFieldProductGuid") as HiddenField;
                                var shop_Collect_Action = (Shop_Collect_Action)ShopFactory.LogicFactory.CreateShop_Collect_Action();


                                DataTable table1 = shop_Collect_Action.SelectBuyNumber(hiddenField.Value);
                                DataTable table2 = shop_Collect_Action.MaxNumber(ProductGuid.Value);
                                int BuyNumber = 0;
                                int MaxNumber = 0;
                                int shop_category_id = 0;
                                int RepertoryCount = 0;
                                string Name = "";
                                if (table1 !=null && table1.Rows.Count > 0)
                                {
                                     BuyNumber =Convert.ToInt32(table1.Rows[0]["BuyNumber"]);
                                     shop_category_id = Convert.ToInt32(table1.Rows[0]["shop_category_id"]);
                                     Name = table1.Rows[0]["Name"].ToString();
                                     shop_category_id22 = shop_category_id22 + shop_category_id;
                                     if (shop_category_id ==shop_category_id22/count)
                                     {
                                         
                                     }
                                     else
                                     {
                                         MessageBox.Show(" 不能购买不同专区的！");
                                         return;
                                     }
                                }
                                if (BuyNumber <= 0)
                                {
                                    MessageBox.Show("商品" + Name + " 数量不正确，请重新修改！");
                                    return;
                                }
                                if (table2 != null && table2.Rows.Count > 0)
                                {
                                    RepertoryCount = Convert.ToInt32(table2.Rows[0]["RepertoryCount"]);
                                }
                                if (BuyNumber>RepertoryCount)
                                {
                                    MessageBox.Show(" 库存不足！");
                                    return;
                                }
                                if (table2 != null && table2.Rows.Count > 0)
                                {
                                     MaxNumber =Convert.ToInt32(table2.Rows[0]["MaxNumber"]);
                                }

                                if (BuyNumber > MaxNumber && shop_category_id == 4 )
                                {
                                    MessageBox.Show("“"+Name + "”的购买数量超过了最大数量“" + MaxNumber+"”件");
                                     return;
                                }
                                else if (BuyNumber > MaxNumber && shop_category_id == 6)
                                {
                                    MessageBox.Show("“" + Name + "”的购买数量超过了最大数量“" + MaxNumber + "”件");
                                    return;
                                }
                                if (text2 != string.Empty)
                                {

                                    int count1 = Regex.Matches(text2, ",").Count;
                                    if (count1 <= 78)
                                    {
                                        text2 = text2 + ",'" + hiddenField.Value + "'";
                                    }
                                    else
                                    {
                                        MessageBox.Show("购买数量超过了最大数量为78，超过将无法购买！");
                                        return;
                                        //if (text211 != string.Empty)
                                        //{
                                        //    text211 = text211 + ",'" + hiddenField.Value + "'";
                                        //}
                                        //else
                                        //{
                                        //    text211 = text211 + "'" + hiddenField.Value + "'";
                                        //}
                                    }

                                }
                                else
                                {
                                    text2 = text2 + "'" + hiddenField.Value + "'";
                                }
                            }
                        }
                    }

                    if (num == 0)
                    {
                        if (text2 == string.Empty)
                        {
                            Page.Response.Redirect(GetPageName.RetDomainUrl("ShoppingCart2"));
                        }
                        else
                        {
                            HttpCookie httpCookie = HttpSecureCookie.Encode(new HttpCookie("VjProductGuId")
                                {
                                    Values =
                                        {
                                            {
                                                "parry",
                                                text2.Replace("'", "")
                                            }
                                        }
                                });
                            httpCookie.Expires =
                                Convert.ToDateTime(DateTime.Now.AddHours(1.0).ToString("yyyy-MM-dd HH:mm:ss"));
                            httpCookie.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                            Page.Response.AppendCookie(httpCookie);
                            Page.Response.Redirect(GetPageName.RetDomainUrlMore("ShoppingCart2", "checkedguid=0"));

                            httpCookie.Expires =
                                Convert.ToDateTime(DateTime.Now.AddHours(1.0).ToString("yyyy-MM-dd HH:mm:ss"));
                            httpCookie.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                            Page.Response.AppendCookie(httpCookie);
                            Page.Response.Redirect(GetPageName.RetDomainUrlMore("ShoppingCart2", "checkedguid=0"));

                            HttpCookie httpCookie2 = HttpSecureCookie.Encode(new HttpCookie("VjProductGuId2")
                            {
                                Values =
                                        {
                                            {
                                                "parry",
                                                text2.Replace("'", "")
                                            }
                                        }
                            });
                            httpCookie2.Expires =
                                Convert.ToDateTime(DateTime.Now.AddHours(1.0).ToString("yyyy-MM-dd HH:mm:ss"));
                            httpCookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                            Page.Response.AppendCookie(httpCookie2);
                            Page.Response.Redirect(GetPageName.RetDomainUrlMore("ShoppingCart2", "checkedguid=0"));
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// 购物车绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RepeaterShopCart1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var repeater = (Repeater) e.Item.FindControl("RepeaterShopProduct");
                repeater.ItemDataBound += RepeaterShopProduct_ItemDataBound;
                var label = (Label) e.Item.FindControl("LabelShopName");
                var label2 = (Label) e.Item.FindControl("LabelSellName");
                int categoryId = Convert.ToInt32((e.Item.DataItem as System.Data.DataRowView)[5]);
               
                DataTable dataTable = ishopNum1_Cart_Action_0.SearchByShopMemID_two(string_1, label.Text, categoryId);
                
                if (dataTable != null)
                {
                    repeater.DataSource = dataTable.DefaultView;
                    repeater.DataBind();
                    for (int i = 0; i < repeater.Items.Count; i++)
                    {
                        IShop_Ensure_Action shop_Ensure_Action = ShopFactory.LogicFactory.CreateShop_Ensure_Action();
                        DataTable dataTable2 = shop_Ensure_Action.SearchEnsureApply(label2.Text);
                        var label3 = (Label) repeater.Items[i].FindControl("LabelProductService");
                        if (dataTable2 != null && dataTable2.Rows.Count > 0)
                        {
                            for (int j = 0; j < dataTable2.Rows.Count; j++)
                            {
                                var image = new Image();
                                image.ImageUrl = dataTable2.Rows[j]["ImagePath"].ToString();
                                label3.Controls.Add(image);
                            }
                        }
                        else
                        {
                            label3.Text = "";
                        }
                    }
                }
            }
        }

        protected void RepeaterShopProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var label = (Label) e.Item.FindControl("LabelIsPresent");
                var hiddenField = (HiddenField) e.Item.FindControl("HiddenFieldIsPresent");
                var linkButton = (LinkButton) e.Item.FindControl("LinkButtonIRemove");
                var linkButton2 = (LinkButton) e.Item.FindControl("LinkButtonIDelete");
                linkButton.Click += method_1;
                linkButton2.Click += method_0;
                if (hiddenField.Value == "1")
                {
                    label.Text = "赠品";
                }
                var label2 = (Label) e.Item.FindControl("LabelBuyPrice");
                var Label22= (Label) e.Item.FindControl("Label2");

                var Label11 = (Label)e.Item.FindControl("Label1");
                string value = label2.Text.Trim();
                var textBox = (TextBox) e.Item.FindControl("TextBoxBuyNumber");
                string text = textBox.Text.Trim();
                var label3 = (Label) e.Item.FindControl("LabelAll");

                var labelpv = (Label)e.Item.FindControl("Labelpv");
                var Labelpvb = (Label)e.Item.FindControl("Labelpvb");
                label3.Text = text;
                labelpv.Text = text;
                Labelpvb.Text = text;
                try
                {
                    Convert.ToDecimal(value);
                }
                catch
                {
                    MessageBox.Show("购买价格有误！");
                    return;
                }
                try
                {
                    Convert.ToInt32(text);
                }
                catch
                {
                    MessageBox.Show("购买数量有误！");
                    return;
                }
                label3.Text = (Convert.ToDecimal(value)*Convert.ToInt32(text)).ToString();
                labelpv.Text = (Convert.ToDecimal(Label11.Text) * Convert.ToInt32(text) ).ToString();
                Labelpvb.Text = (Convert.ToDecimal(Label22.Text) * Convert.ToInt32(text)).ToString();
            }
        }

        protected void BindData()
        {
            DataTable dataTable = ishopNum1_Cart_Action_0.SearchShopByMemLoginID(string_1);
            RepeaterShopCart1.DataSource = dataTable.DefaultView;
            RepeaterShopCart1.DataBind();
            GetAllMoney();
            GetAllMarketMoney();
            GetSaveMoney();
        }

        protected void GetAllMoney()
        {
            labelAllPrice.Text = "0";
            labelALLpv.Text = "0";
            labelALLpvb.Text = "0";
            for (int i = 0; i < RepeaterShopCart1.Items.Count; i++)
            {
                var repeater = (Repeater) RepeaterShopCart1.Items[i].FindControl("RepeaterShopProduct");
                foreach (RepeaterItem repeaterItem in repeater.Items)
                {
                    var label = (Label) repeaterItem.FindControl("LabelAll");
                    var Labelpv = (Label)repeaterItem.FindControl("Labelpv");
                    var Labelpvb = (Label)repeaterItem.FindControl("Labelpvb");
                    labelAllPrice.Text =
                        Convert.ToString(Convert.ToDecimal(labelAllPrice.Text) + Convert.ToDecimal(label.Text));
                    labelALLpv.Text =
                      Convert.ToString(Convert.ToDecimal(labelALLpv.Text) + Convert.ToDecimal(Labelpv.Text));
                    labelALLpvb.Text =
                      Convert.ToString(Convert.ToDecimal(labelALLpvb.Text) + Convert.ToDecimal(Labelpvb.Text));
                }
            }
        }

        protected void GetAllMarketMoney()
        {
            labelMaretPrice.Text = "0";
            for (int i = 0; i < RepeaterShopCart1.Items.Count; i++)
            {
                var repeater = (Repeater) RepeaterShopCart1.Items[i].FindControl("RepeaterShopProduct");
                foreach (RepeaterItem repeaterItem in repeater.Items)
                {
                    var label = (Label) repeaterItem.FindControl("labelMarketPrice");
                    var textBox = (TextBox) repeaterItem.FindControl("TextBoxBuyNumber");
                    labelMaretPrice.Text =
                        Convert.ToString(Convert.ToDecimal(labelMaretPrice.Text) +
                                         Convert.ToDecimal(label.Text)*Convert.ToInt32(textBox.Text));
                }
            }
        }

        protected void GetSaveMoney()
        {
            labelLower.Text =
                Convert.ToString(Convert.ToDecimal(labelMaretPrice.Text) - Convert.ToDecimal(labelAllPrice.Text));
        }
    }
}