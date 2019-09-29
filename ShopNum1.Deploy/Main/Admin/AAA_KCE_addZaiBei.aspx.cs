using ShopNum1.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AAA_KCE_addZaiBei : PageBase, IRequiresSessionState
    {
        ShopNum1_Member_Action memberaction = new ShopNum1_Member_Action();
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string memloginid = TextBox4.Text.Trim();
                decimal bili = Convert.ToDecimal(TextBox5.Text.Trim());
                decimal pva = Convert.ToDecimal(TextBox3.Text.Trim());
                decimal ZB = bili / 100;
                DataTable memtable = memberaction.SearchMembertwo(memloginid);
                if (memtable.Rows.Count > 0)
                {
                    if (pva > 0)
                    {
                        if (ZB > 0 & ZB < 1)
                        {
                            memberaction.INsertAdvancePaymentModifyLog_Gz_ADDZB(memloginid, pva, "增加债贝");
                            memberaction.AdminBili(memloginid, ZB);
                            Response.Write("<script>alert('操作成功！');</script>");
                            msg.InnerText = "操作成功";
                        }
                        else
                        {
                            Response.Write("<script>alert('比例错误！');</script>");
                        }
                    }
                    else 
                    {
                        Response.Write("<script>alert('债贝数量错误！');</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert('工号错误或不存在！');</script>");
                }
            }
            catch
            {
                Response.Write("<script>alert('系统错误！');</script>");
            }

        }
    }
}