using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ShopNum1.Standard.VjWebservice
{
    [WebServiceBinding(Name = "SDKServiceBinding", Namespace = "http://sdkhttp.eucp.b2m.cn/"), DebuggerStepThrough,
     DesignerCategory("code"), GeneratedCode("System.Web.Services", "2.0.50727.1433")]
    public class SDKService : SoapHttpClientProtocol
    {
        private bool bool_0;
        private SendOrPostCallback sendOrPostCallback_0;
        private SendOrPostCallback sendOrPostCallback_1;
        private SendOrPostCallback sendOrPostCallback_10;
        private SendOrPostCallback sendOrPostCallback_11;
        private SendOrPostCallback sendOrPostCallback_12;
        private SendOrPostCallback sendOrPostCallback_13;
        private SendOrPostCallback sendOrPostCallback_2;
        private SendOrPostCallback sendOrPostCallback_3;
        private SendOrPostCallback sendOrPostCallback_4;
        private SendOrPostCallback sendOrPostCallback_5;
        private SendOrPostCallback sendOrPostCallback_6;
        private SendOrPostCallback sendOrPostCallback_7;
        private SendOrPostCallback sendOrPostCallback_8;
        private SendOrPostCallback sendOrPostCallback_9;

        public SDKService()
        {
            Url = Class0.sBindData().method_1();
            if (method_14(Url))
            {
                UseDefaultCredentials = true;
                bool_0 = false;
            }
            else
            {
                bool_0 = true;
            }
        }

        public string Url
        {
            get { return base.Url; }
            set
            {
                if (!((!method_14(base.Url) || bool_0) || method_14(value)))
                {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }

        public bool UseDefaultCredentials
        {
            get { return base.UseDefaultCredentials; }
            set
            {
                base.UseDefaultCredentials = value;
                bool_0 = true;
            }
        }

        public event cancelMOForwardCompletedEventHandler cancelMOForwardCompleted;

        public event chargeUpCompletedEventHandler chargeUpCompleted;

        public event getBalanceCompletedEventHandler getBalanceCompleted;

        public event getEachFeeCompletedEventHandler getEachFeeCompleted;

        public event getMOCompletedEventHandler getMOCompleted;

        public event getReportCompletedEventHandler getReportCompleted;

        public event getVersionCompletedEventHandler getVersionCompleted;

        public event logoutCompletedEventHandler logoutCompleted;

        public event registDetailInfoCompletedEventHandler registDetailInfoCompleted;

        public event registExCompletedEventHandler registExCompleted;

        public event sendSMSCompletedEventHandler sendSMSCompleted;

        public event serialPwdUpdCompletedEventHandler serialPwdUpdCompleted;

        public event setMOForwardCompletedEventHandler setMOForwardCompleted;

        public event setMOForwardExCompletedEventHandler setMOForwardExCompleted;

        public void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }

        [return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
        [SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/",
            ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public int cancelMOForward([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0,
                                   [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1)
        {
            return (int) base.Invoke("cancelMOForward", new object[] {arg0, arg1})[0];
        }

        public void cancelMOForwardAsync(string arg0, string arg1)
        {
            cancelMOForwardAsync(arg0, arg1, null);
        }

        public void cancelMOForwardAsync(string arg0, string arg1, object userState)
        {
            if (sendOrPostCallback_2 == null)
            {
                sendOrPostCallback_2 = method_2;
            }
            base.InvokeAsync("cancelMOForward", new object[] {arg0, arg1}, sendOrPostCallback_2, userState);
        }

        [return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
        [SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/",
            ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public int chargeUp([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0,
                            [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1,
                            [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg2,
                            [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg3)
        {
            return (int) base.Invoke("chargeUp", new object[] {arg0, arg1, arg2, arg3})[0];
        }

        public void chargeUpAsync(string arg0, string arg1, string arg2, string arg3)
        {
            chargeUpAsync(arg0, arg1, arg2, arg3, null);
        }

        public void chargeUpAsync(string arg0, string arg1, string arg2, string arg3, object userState)
        {
            if (sendOrPostCallback_3 == null)
            {
                sendOrPostCallback_3 = method_3;
            }
            base.InvokeAsync("chargeUp", new object[] {arg0, arg1, arg2, arg3}, sendOrPostCallback_3, userState);
        }

        [return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
        [SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/",
            ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public double getBalance([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0,
                                 [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1)
        {
            return (double) base.Invoke("getBalance", new object[] {arg0, arg1})[0];
        }

        public void getBalanceAsync(string arg0, string arg1)
        {
            getBalanceAsync(arg0, arg1, null);
        }

        public void getBalanceAsync(string arg0, string arg1, object userState)
        {
            if (sendOrPostCallback_4 == null)
            {
                sendOrPostCallback_4 = method_4;
            }
            base.InvokeAsync("getBalance", new object[] {arg0, arg1}, sendOrPostCallback_4, userState);
        }

        [return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
        [SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/",
            ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public double getEachFee([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0,
                                 [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1)
        {
            return (double) base.Invoke("getEachFee", new object[] {arg0, arg1})[0];
        }

        public void getEachFeeAsync(string arg0, string arg1)
        {
            getEachFeeAsync(arg0, arg1, null);
        }

        public void getEachFeeAsync(string arg0, string arg1, object userState)
        {
            if (sendOrPostCallback_5 == null)
            {
                sendOrPostCallback_5 = method_5;
            }
            base.InvokeAsync("getEachFee", new object[] {arg0, arg1}, sendOrPostCallback_5, userState);
        }

        [return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
        [SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/",
            ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public GClass0[] getMO([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0,
                               [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1)
        {
            return (GClass0[]) base.Invoke("getMO", new object[] {arg0, arg1})[0];
        }

        public void getMOAsync(string arg0, string arg1)
        {
            getMOAsync(arg0, arg1, null);
        }

        public void getMOAsync(string arg0, string arg1, object userState)
        {
            if (sendOrPostCallback_6 == null)
            {
                sendOrPostCallback_6 = method_6;
            }
            base.InvokeAsync("getMO", new object[] {arg0, arg1}, sendOrPostCallback_6, userState);
        }

        [return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
        [SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/",
            ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public statusReport[] getReport([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0,
                                        [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1)
        {
            return (statusReport[]) base.Invoke("getReport", new object[] {arg0, arg1})[0];
        }

        public void getReportAsync(string arg0, string arg1)
        {
            getReportAsync(arg0, arg1, null);
        }

        public void getReportAsync(string arg0, string arg1, object userState)
        {
            if (sendOrPostCallback_1 == null)
            {
                sendOrPostCallback_1 = method_1;
            }
            base.InvokeAsync("getReport", new object[] {arg0, arg1}, sendOrPostCallback_1, userState);
        }

        [return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
        [SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/",
            ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public string getVersion()
        {
            return (string) base.Invoke("getVersion", new object[0])[0];
        }

        public void getVersionAsync()
        {
            getVersionAsync(null);
        }

        public void getVersionAsync(object userState)
        {
            if (sendOrPostCallback_0 == null)
            {
                sendOrPostCallback_0 = method_0;
            }
            base.InvokeAsync("getVersion", new object[0], sendOrPostCallback_0, userState);
        }

        [return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
        [SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/",
            ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public int logout([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0,
                          [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1)
        {
            return (int) base.Invoke("logout", new object[] {arg0, arg1})[0];
        }

        public void logoutAsync(string arg0, string arg1)
        {
            logoutAsync(arg0, arg1, null);
        }

        public void logoutAsync(string arg0, string arg1, object userState)
        {
            if (sendOrPostCallback_7 == null)
            {
                sendOrPostCallback_7 = method_7;
            }
            base.InvokeAsync("logout", new object[] {arg0, arg1}, sendOrPostCallback_7, userState);
        }

        private void method_0(object object_0)
        {
            if (getVersionCompleted != null)
            {
                var args = (InvokeCompletedEventArgs) object_0;
                getVersionCompleted(this,
                                    new getVersionCompletedEventArgs(args.Results, args.Error, args.Cancelled,
                                                                     args.UserState));
            }
        }

        private void method_1(object object_0)
        {
            if (getReportCompleted != null)
            {
                var args = (InvokeCompletedEventArgs) object_0;
                getReportCompleted(this,
                                   new getReportCompletedEventArgs(args.Results, args.Error, args.Cancelled,
                                                                   args.UserState));
            }
        }

        private void method_10(object object_0)
        {
            if (sendSMSCompleted != null)
            {
                var args = (InvokeCompletedEventArgs) object_0;
                sendSMSCompleted(this,
                                 new sendSMSCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void method_11(object object_0)
        {
            if (serialPwdUpdCompleted != null)
            {
                var args = (InvokeCompletedEventArgs) object_0;
                serialPwdUpdCompleted(this,
                                      new serialPwdUpdCompletedEventArgs(args.Results, args.Error, args.Cancelled,
                                                                         args.UserState));
            }
        }

        private void method_12(object object_0)
        {
            if (setMOForwardCompleted != null)
            {
                var args = (InvokeCompletedEventArgs) object_0;
                setMOForwardCompleted(this,
                                      new setMOForwardCompletedEventArgs(args.Results, args.Error, args.Cancelled,
                                                                         args.UserState));
            }
        }

        private void method_13(object object_0)
        {
            if (setMOForwardExCompleted != null)
            {
                var args = (InvokeCompletedEventArgs) object_0;
                setMOForwardExCompleted(this,
                                        new setMOForwardExCompletedEventArgs(args.Results, args.Error, args.Cancelled,
                                                                             args.UserState));
            }
        }

        private bool method_14(string string_0)
        {
            if ((string_0 == null) || (string_0 == string.Empty))
            {
                return false;
            }
            var uri = new Uri(string_0);
            return ((uri.Port >= 0x400) &&
                    (string.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0));
        }

        private void method_2(object object_0)
        {
            if (cancelMOForwardCompleted != null)
            {
                var args = (InvokeCompletedEventArgs) object_0;
                cancelMOForwardCompleted(this,
                                         new cancelMOForwardCompletedEventArgs(args.Results, args.Error, args.Cancelled,
                                                                               args.UserState));
            }
        }

        private void method_3(object object_0)
        {
            if (chargeUpCompleted != null)
            {
                var args = (InvokeCompletedEventArgs) object_0;
                chargeUpCompleted(this,
                                  new chargeUpCompletedEventArgs(args.Results, args.Error, args.Cancelled,
                                                                 args.UserState));
            }
        }

        private void method_4(object object_0)
        {
            if (getBalanceCompleted != null)
            {
                var args = (InvokeCompletedEventArgs) object_0;
                getBalanceCompleted(this,
                                    new getBalanceCompletedEventArgs(args.Results, args.Error, args.Cancelled,
                                                                     args.UserState));
            }
        }

        private void method_5(object object_0)
        {
            if (getEachFeeCompleted != null)
            {
                var args = (InvokeCompletedEventArgs) object_0;
                getEachFeeCompleted(this,
                                    new getEachFeeCompletedEventArgs(args.Results, args.Error, args.Cancelled,
                                                                     args.UserState));
            }
        }

        private void method_6(object object_0)
        {
            if (getMOCompleted != null)
            {
                var args = (InvokeCompletedEventArgs) object_0;
                getMOCompleted(this,
                               new getMOCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void method_7(object object_0)
        {
            if (logoutCompleted != null)
            {
                var args = (InvokeCompletedEventArgs) object_0;
                logoutCompleted(this,
                                new logoutCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void method_8(object object_0)
        {
            if (registDetailInfoCompleted != null)
            {
                var args = (InvokeCompletedEventArgs) object_0;
                registDetailInfoCompleted(this,
                                          new registDetailInfoCompletedEventArgs(args.Results, args.Error,
                                                                                 args.Cancelled, args.UserState));
            }
        }

        private void method_9(object object_0)
        {
            if (registExCompleted != null)
            {
                var args = (InvokeCompletedEventArgs) object_0;
                registExCompleted(this,
                                  new registExCompletedEventArgs(args.Results, args.Error, args.Cancelled,
                                                                 args.UserState));
            }
        }

        [return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
        [SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/",
            ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public int registDetailInfo([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0,
                                    [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1,
                                    [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg2,
                                    [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg3,
                                    [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg4,
                                    [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg5,
                                    [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg6,
                                    [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg7,
                                    [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg8,
                                    [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg9)
        {
            return
                (int)
                base.Invoke("registDetailInfo",
                            new object[] {arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9})[0];
        }

        public void registDetailInfoAsync(string arg0, string arg1, string arg2, string arg3, string arg4, string arg5,
                                          string arg6, string arg7, string arg8, string arg9)
        {
            registDetailInfoAsync(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, null);
        }

        public void registDetailInfoAsync(string arg0, string arg1, string arg2, string arg3, string arg4, string arg5,
                                          string arg6, string arg7, string arg8, string arg9, object userState)
        {
            if (sendOrPostCallback_8 == null)
            {
                sendOrPostCallback_8 = method_8;
            }
            base.InvokeAsync("registDetailInfo",
                             new object[] {arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9},
                             sendOrPostCallback_8, userState);
        }

        [return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
        [SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/",
            ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public int registEx([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0,
                            [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1,
                            [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg2)
        {
            return (int) base.Invoke("registEx", new object[] {arg0, arg1, arg2})[0];
        }

        public void registExAsync(string arg0, string arg1, string arg2)
        {
            registExAsync(arg0, arg1, arg2, null);
        }

        public void registExAsync(string arg0, string arg1, string arg2, object userState)
        {
            if (sendOrPostCallback_9 == null)
            {
                sendOrPostCallback_9 = method_9;
            }
            base.InvokeAsync("registEx", new object[] {arg0, arg1, arg2}, sendOrPostCallback_9, userState);
        }

        [return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
        [SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/",
            ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public int sendSMS([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0,
                           [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1,
                           [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg2,
                           [XmlElement("arg3", Form = XmlSchemaForm.Unqualified, IsNullable = true)] string[] arg3,
                           [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg4,
                           [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg5,
                           [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg6,
                           [XmlElement(Form = XmlSchemaForm.Unqualified)] int arg7,
                           [XmlElement(Form = XmlSchemaForm.Unqualified)] long arg8)
        {
            return (int) base.Invoke("sendSMS", new object[] {arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8})[0];
        }

        public void sendSMSAsync(string arg0, string arg1, string arg2, string[] arg3, string arg4, string arg5,
                                 string arg6, int arg7, long arg8)
        {
            sendSMSAsync(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, null);
        }

        public void sendSMSAsync(string arg0, string arg1, string arg2, string[] arg3, string arg4, string arg5,
                                 string arg6, int arg7, long arg8, object userState)
        {
            if (sendOrPostCallback_10 == null)
            {
                sendOrPostCallback_10 = method_10;
            }
            base.InvokeAsync("sendSMS", new object[] {arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8},
                             sendOrPostCallback_10, userState);
        }

        [return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
        [SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/",
            ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public int serialPwdUpd([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0,
                                [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1,
                                [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg2,
                                [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg3)
        {
            return (int) base.Invoke("serialPwdUpd", new object[] {arg0, arg1, arg2, arg3})[0];
        }

        public void serialPwdUpdAsync(string arg0, string arg1, string arg2, string arg3)
        {
            serialPwdUpdAsync(arg0, arg1, arg2, arg3, null);
        }

        public void serialPwdUpdAsync(string arg0, string arg1, string arg2, string arg3, object userState)
        {
            if (sendOrPostCallback_11 == null)
            {
                sendOrPostCallback_11 = method_11;
            }
            base.InvokeAsync("serialPwdUpd", new object[] {arg0, arg1, arg2, arg3}, sendOrPostCallback_11, userState);
        }

        [return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
        [SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/",
            ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public int setMOForward([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0,
                                [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1,
                                [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg2)
        {
            return (int) base.Invoke("setMOForward", new object[] {arg0, arg1, arg2})[0];
        }

        public void setMOForwardAsync(string arg0, string arg1, string arg2)
        {
            setMOForwardAsync(arg0, arg1, arg2, null);
        }

        public void setMOForwardAsync(string arg0, string arg1, string arg2, object userState)
        {
            if (sendOrPostCallback_12 == null)
            {
                sendOrPostCallback_12 = method_12;
            }
            base.InvokeAsync("setMOForward", new object[] {arg0, arg1, arg2}, sendOrPostCallback_12, userState);
        }

        [return: XmlElement("return", Form = XmlSchemaForm.Unqualified)]
        [SoapDocumentMethod("", RequestNamespace = "http://sdkhttp.eucp.b2m.cn/",
            ResponseNamespace = "http://sdkhttp.eucp.b2m.cn/", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public int setMOForwardEx([XmlElement(Form = XmlSchemaForm.Unqualified)] string arg0,
                                  [XmlElement(Form = XmlSchemaForm.Unqualified)] string arg1,
                                  [XmlElement("arg2", Form = XmlSchemaForm.Unqualified, IsNullable = true)] string[]
                                      arg2)
        {
            return (int) base.Invoke("setMOForwardEx", new object[] {arg0, arg1, arg2})[0];
        }

        public void setMOForwardExAsync(string arg0, string arg1, string[] arg2)
        {
            setMOForwardExAsync(arg0, arg1, arg2, null);
        }

        public void setMOForwardExAsync(string arg0, string arg1, string[] arg2, object userState)
        {
            if (sendOrPostCallback_13 == null)
            {
                sendOrPostCallback_13 = method_13;
            }
            base.InvokeAsync("setMOForwardEx", new object[] {arg0, arg1, arg2}, sendOrPostCallback_13, userState);
        }
    }
}