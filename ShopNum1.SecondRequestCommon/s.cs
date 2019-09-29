using System;
using System.IO;
using System.Net;
using System.Text;

internal class s
{
    public string a(string A_0)
    {
        HttpWebRequest request = (HttpWebRequest) WebRequest.Create(A_0);
        request.Method = "GET";
        request.ContentType = "application/x-www-form-urlencoded";
        request.Accept = "*/*";
        request.Timeout = 0x3a98;
        request.AllowAutoRedirect = false;
        WebResponse response = null;
        string str = null;
        try
        {
            response = request.GetResponse();
            if (response != null)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                str = reader.ReadToEnd();
                reader.Close();
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            request = null;
            response = null;
        }
        return str;
    }

    public string a(string A_0, string A_1)
    {
        HttpWebRequest request = (HttpWebRequest) WebRequest.Create(A_0);
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.Accept = "*/*";
        request.Timeout = 0x3a98;
        request.AllowAutoRedirect = false;
        StreamWriter writer = null;
        WebResponse response = null;
        string str = null;
        try
        {
            writer = new StreamWriter(request.GetRequestStream());
            writer.Write(A_1);
            writer.Close();
            response = request.GetResponse();
            if (response != null)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                str = reader.ReadToEnd();
                reader.Close();
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            request = null;
            writer = null;
            response = null;
        }
        return str;
    }
}

