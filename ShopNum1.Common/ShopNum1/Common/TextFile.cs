using System;
using System.IO;

namespace ShopNum1.Common
{
    public static class TextFile
    {
        public static void ReadFile(string filePath)
        {
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        while (reader.Peek() >= 0)
                        {
                            Console.WriteLine(reader.ReadLine());
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static void WriteFile(string filePath, string strMessage)
        {
            try
            {
                using (var writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(strMessage);
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}