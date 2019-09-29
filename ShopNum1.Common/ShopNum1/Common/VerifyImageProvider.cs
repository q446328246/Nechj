using System;
using System.Collections;

namespace ShopNum1.Common
{
    public class VerifyImageProvider
    {
        private static readonly Hashtable _instance = new Hashtable();
        private static readonly object lockHelper = new object();

        public static IVerifyImage GetInstance(string assemlyName)
        {
            if (!_instance.ContainsKey(assemlyName))
            {
                lock (lockHelper)
                {
                    if (!_instance.ContainsKey(assemlyName))
                    {
                        IVerifyImage image = null;
                        try
                        {
                            image =
                                (IVerifyImage)
                                Activator.CreateInstance(
                                    Type.GetType(
                                        string.Format("ShopNum1.Common.{0}.VerifyImage, ShopNum1.Common.{0}",
                                                      assemlyName), false, true));
                        }
                        catch
                        {
                            image = new VerifyImage();
                        }
                        _instance.Add(assemlyName, image);
                    }
                }
            }
            return (IVerifyImage) _instance[assemlyName];
        }
    }
}