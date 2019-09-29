using System;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.UI;

namespace ShopNum1.Common
{
    public static class MessageBox
    {
        private static readonly Hashtable m_executingPages = new Hashtable();

        private static void ExecutingPage_Unload(object sender, EventArgs e)
        {
            var queue = (Queue) m_executingPages[HttpContext.Current.Handler];
            if (queue != null)
            {
                var builder = new StringBuilder();
                int count = queue.Count;
                builder.Append("<script language='javascript'>");
                while (count-- > 0)
                {
                    var str = (string) queue.Dequeue();
                    builder.Append("alert( \"" + str.Replace("\n", @"\n").Replace("\"", "'") + "\" );");
                }
                builder.Append("</script>");
                m_executingPages.Remove(HttpContext.Current.Handler);
                HttpContext.Current.Response.Write(builder.ToString());
            }
        }

        public static void Show(string sMessage)
        {
            if (!m_executingPages.Contains(HttpContext.Current.Handler))
            {
                var handler = HttpContext.Current.Handler as Page;
                if (handler != null)
                {
                    var queue = new Queue();
                    queue.Enqueue(sMessage);
                    m_executingPages.Add(HttpContext.Current.Handler, queue);
                    handler.Unload += ExecutingPage_Unload;
                }
            }
            else
            {
                ((Queue) m_executingPages[HttpContext.Current.Handler]).Enqueue(sMessage);
            }
        }
    }
}