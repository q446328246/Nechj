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
    public partial class AAA_KCE_addKT : PageBase, IRequiresSessionState
    {
        ShopNum1_Member_Action memberaction = new ShopNum1_Member_Action();
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
            }
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string memloginid = TextBox1.Text.Trim();
        //        decimal pva = Convert.ToDecimal(TextBox3.Text.Trim());
        //        DataTable memtable = memberaction.SearchMembertwo(memloginid);
        //        if (memtable!=null&&memtable.Rows.Count > 0)
        //        {
        //            if (pva > 0)
        //            {
        //                //------------------------------Score_dv----------NEC-----------------
        //                    string aa = DropdownListSOperateType.SelectedValue;
        //                    if (aa == "0")
        //                    {
        //                        memberaction.ZhuanZhangNECJia(memloginid, pva, "充值NEC");
        //                        Response.Write("<script>alert('充值NEC操作成功！');</script>");
        //                        msg.InnerText = "充值NEC操作成功";
        //                    }
        //                    else if (aa == "1")
        //                    {
        //                        decimal AdvancePayment = Convert.ToDecimal(memtable.Rows[0]["Score_dv"]);
        //                        if (AdvancePayment >= pva)
        //                        {
        //                            memberaction.ZhuanZhangNECKou(memloginid, pva, "减少NEC");
        //                            Response.Write("<script>alert('减少NEC操作成功！');</script>");
        //                            msg.InnerText = "减少NEC操作成功";
        //                        }
        //                        else
        //                        {
        //                            Response.Write("<script>alert('操作失败！账户余额不足');</script>");
        //                            msg.InnerText = "操作失败！账户余额不足";
        //                        }
        //                    }


        //                    //-----------------------------------------AdvancePayment-------------usdt--------------------
        //                    //else if (aa == "2")
        //                    //{
        //                    //    memberaction.ADDKT(memloginid, pva, "充值usdt");
        //                    //    Response.Write("<script>alert('充值usdt操作成功！');</script>");
        //                    //    msg.InnerText = "充值usdt操作成功";
        //                    //}
        //                    //else if (aa == "3")
        //                    //{
        //                    //    decimal AdvancePayment = Convert.ToDecimal(memtable.Rows[0]["AdvancePayment"]);
        //                    //    if (AdvancePayment >= pva)
        //                    //    {
        //                    //        memberaction.ReduceKT(memloginid, pva, "减少usdt");
        //                    //        Response.Write("<script>alert('减少usdt操作成功！');</script>");
        //                    //        msg.InnerText = "减少usdt操作成功";
        //                    //    }
        //                    //    else
        //                    //    {
        //                    //        Response.Write("<script>alert('操作失败！账户余额不足');</script>");
        //                    //        msg.InnerText = "操作失败！账户余额不足";
        //                    //    }
        //                    //}




        //                    //-------------------------------------Score_hv------ETH---------------------
        //                    //else if (aa == "4")
        //                    //{
        //                    //    memberaction.InsertAdvancePaymentModifyLog_Gz_XSY_hv(memloginid, pva, "充值ETH");
        //                    //    Response.Write("<script>alert('充值ETH操作成功！');</script>");
        //                    //    msg.InnerText = "充值ETH操作成功";
        //                    //}
        //                    //else if (aa == "5")
        //                    //{
        //                    //    decimal AdvancePayment = Convert.ToDecimal(memtable.Rows[0]["Score_hv"]);
        //                    //    if (AdvancePayment >= pva)
        //                    //    {
        //                    //        memberaction.InsertAdvancePaymentModifyLog_Gz_XSY_hvXiaoFei(memloginid, pva, "减少ETH");
        //                    //        Response.Write("<script>alert('减少ETH操作成功！');</script>");
        //                    //        msg.InnerText = "减少ETH操作成功";
        //                    //    }
        //                    //    else
        //                    //    {
        //                    //        Response.Write("<script>alert('操作失败！账户余额不足');</script>");
        //                    //        msg.InnerText = "操作失败！账户余额不足";
        //                    //    }
        //                    //}
        //                    else
        //                    {
        //                        Response.Write("<script>alert('操作失败');</script>");
        //                        msg.InnerText = "操作失败!";
        //                    }
        //            }
        //            else 
        //            {
        //                Response.Write("<script>alert('数量错误！');</script>");
        //            }

        //        }
        //        else
        //        {
        //            Response.Write("<script>alert('工号错误或不存在！');</script>");
        //        }
        //    }
        //    catch
        //    {
        //        Response.Write("<script>alert('系统错误！');</script>");
        //    }

        //}
    }
}