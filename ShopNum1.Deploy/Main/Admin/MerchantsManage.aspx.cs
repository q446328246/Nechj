using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class MerchantsManage : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                try
                {
                    string path = HttpContext.Current.Server.MapPath("~/main/Themes/Skin_Default/MerchantsIn.html");
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
                    ckeditormark.Value = "招商页面拒绝访问，请联系售后增加页面访问权限！";
                }
            }
        }

        protected void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                string path = HttpContext.Current.Server.MapPath("~/main/Themes/Skin_Default/MerchantsIn.html");
                if (File.Exists(path))
                {
                    Stream stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                    var writer = new StreamWriter(stream, Encoding.GetEncoding("gb2312"));
                    writer.Write(ckeditormark.Value);
                    writer.Close();
                    stream.Close();
                }
                Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('修改成功！');</script>", false);
            }
            catch
            {
                ckeditormark.Value = "招商页面拒绝访问，请联系售后增加页面访问权限！";
            }
        }
    }
}