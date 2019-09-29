using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.SessionState;
using ShopNum1.Common;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Robots_List : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                try
                {
                    string path = HttpContext.Current.Server.MapPath("~/robots.txt");
                    if (File.Exists(path))
                    {
                        var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        var reader = new StreamReader(stream, Encoding.Default);
                        ckeditormark.Value = reader.ReadToEnd();
                        reader.Close();
                        stream.Close();
                    }
                }
                catch
                {
                    ckeditormark.Value = "Robots页面拒绝访问，请联系售后增加页面访问权限！";
                }
            }
        }

        protected void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                string path = HttpContext.Current.Server.MapPath("~/robots.txt");
                if (File.Exists(path))
                {
                    Stream stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                    var writer = new StreamWriter(stream, Encoding.GetEncoding("gb2312"));
                    writer.Write(ckeditormark.Value);
                    writer.Close();
                    stream.Close();
                }
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "编辑Robots",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Robots_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('修改成功！');</script>", false);
            }
            catch
            {
                ckeditormark.Value = "Robots页面拒绝访问，请联系售后增加页面访问权限！";
            }
        }


    }
}