using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;
using System.Collections;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class BTCRecommend :  PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            Num1GridviewShow.DataBind();
        }

        //protected void ButtonAdd_Click(object sender, EventArgs e)
        //{
        //    CheckGuid.Value = "0";
        //    base.Response.Redirect("Brand_Operate.aspx?guid=" + CheckGuid.Value);
        //}

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
            

            string ddlaod = DropDownListAddOrDelete.SelectedValue;
            //ArrayList list = new ArrayList();
            //list.Add(CheckGuid.Value.Split(','));
            string[] list = CheckGuid.Value.Split(',');

            if (ddlaod=="1")
            {
                for (int i = 0; i < list.Length; i++)
                {
                    if (action.SelectBTCRecommend(list[i].ToString()).Rows.Count >0)
                    {
                        action.UpdateBTCRecommendIsSalesBTC(list[i].ToString());
                    }
                    else
                    {
                        action.AddBTCRecommend(list[i].ToString(), System.DateTime.Now.ToString(), 1, 0, 0);
                    }
                    
                }
            }
            if (ddlaod == "2")
            {
                for (int i = 0; i < list.Length; i++)
                {
                    if (action.SelectBTCRecommend(list[i].ToString()).Rows.Count > 0l)
                    {
                        action.UpdateBTCRecommendIsNewBTC(list[i].ToString());
                    }
                    else
                    {
                        action.AddBTCRecommend(list[i].ToString(), System.DateTime.Now.ToString(), 0, 1, 0);
                    }
                }
            }
            if (ddlaod == "3")
            {
                for (int i = 0; i < list.Length; i++)
                {
                    if (action.SelectBTCRecommend(list[i].ToString()).Rows.Count > 0)
                    {
                        action.UpdateBTCRecommendIsTercelBTC(list[i].ToString());
                    }
                    else
                    {
                        action.AddBTCRecommend(list[i].ToString(), System.DateTime.Now.ToString(), 0, 0, 1);
                    }
                }
            }
            if (ddlaod == "4")
            {
                for (int i = 0; i < list.Length; i++)
                {
                    action.DeleteBTCRecommend(list[i].ToString());
                }
            }
            if (ddlaod == "5")
            {
                for (int i = 0; i < list.Length; i++)
                {
                    action.DeleteBTCRecommend(list[i].ToString());
                }
            }
            if (ddlaod == "6")
            {
                for (int i = 0; i < list.Length; i++)
                {
                    action.DeleteBTCRecommend(list[i].ToString());
                }
            }
            
           
            
                MessageShow.ShowMessage("成功了");
                MessageShow.Visible = true;
            
        }

      

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        //public string GetListImageStatus(string string_4)
        //{
        //    if (string_4 == "0")
        //    {
        //        return "images/shopNum1Admin-wrong.gif";
        //    }
        //    else 
        //    {
                
        //        return "images/shopNum1Admin-right.gif";
        //    }
            
        //}

        
        }
    }
