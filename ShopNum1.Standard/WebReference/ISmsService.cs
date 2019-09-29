using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace ShopNum1.Standard.WebReference
{
    [WebServiceBinding(Name = "ISmsServiceHttpBinding", Namespace = "http://service.ewing.com"), DebuggerStepThrough,
     DesignerCategory("code"), GeneratedCode("System.Web.Services", "2.0.50727.3053")]
    public class ISmsService : SoapHttpClientProtocol
    {
        private bool bool_0;
        private SendOrPostCallback sendOrPostCallback_0;
        private SendOrPostCallback sendOrPostCallback_1;
        private SendOrPostCallback sendOrPostCallback_2;
        private SendOrPostCallback sendOrPostCallback_3;
        private SendOrPostCallback sendOrPostCallback_4;
        private SendOrPostCallback sendOrPostCallback_5;
        private SendOrPostCallback sendOrPostCallback_6;

        public ISmsService()
        {
            Url = Class0.sBindData().BindData();
            if (method_8(Url))
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
                if (!((!method_8(base.Url) || bool_0) || method_8(value)))
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

        public event accountCompletedEventHandler accountCompleted;

        public event excelSendCompletedEventHandler excelSendCompleted;

        public event moCompletedEventHandler moCompleted;

        public event reportCompletedEventHandler reportCompleted;

        public event sendLSActionCompletedEventHandler sendLSActionCompleted;

        public event smsSendCompletedEventHandler smsSendCompleted;

        public event updatePasswordCompletedEventHandler updatePasswordCompleted;

        [return: XmlElement("out", IsNullable = true)]
        [SoapDocumentMethod("", RequestNamespace = "http://service.ewing.com",
            ResponseNamespace = "http://service.ewing.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public string account([XmlElement(IsNullable = true)] string string_0,
                              [XmlElement(IsNullable = true)] string string_1,
                              [XmlElement(IsNullable = true)] string string_2)
        {
            return (string) base.Invoke("account", new object[] {string_0, string_1, string_2})[0];
        }

        public void accountAsync(string string_0, string string_1, string string_2)
        {
            accountAsync(string_0, string_1, string_2, null);
        }

        public void accountAsync(string string_0, string string_1, string string_2, object userState)
        {
            if (sendOrPostCallback_5 == null)
            {
                sendOrPostCallback_5 = method_6;
            }
            base.InvokeAsync("account", new object[] {string_0, string_1, string_2}, sendOrPostCallback_5, userState);
        }

        public void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }

        [return: XmlElement("out", IsNullable = true)]
        [SoapDocumentMethod("", RequestNamespace = "http://service.ewing.com",
            ResponseNamespace = "http://service.ewing.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public string excelSend([XmlElement(IsNullable = true)] string string_0,
                                [XmlElement(IsNullable = true)] string string_1,
                                [XmlElement(IsNullable = true)] string string_2,
                                [XmlElement(IsNullable = true)] string string_3,
                                [XmlElement(IsNullable = true)] string string_4,
                                [XmlElement(IsNullable = true)] string string_5,
                                [XmlElement(IsNullable = true)] string string_6,
                                [XmlElement(IsNullable = true)] string string_7,
                                [XmlElement(IsNullable = true)] string string_8)
        {
            return
                (string)
                base.Invoke("excelSend",
                            new object[]
                                {
                                    string_0, string_1, string_2, string_3, string_4, string_5, string_6, string_7,
                                    string_8
                                })[0];
        }

        public void excelSendAsync(string string_0, string string_1, string string_2, string string_3, string string_4,
                                   string string_5, string string_6, string string_7, string string_8)
        {
            excelSendAsync(string_0, string_1, string_2, string_3, string_4, string_5, string_6, string_7, string_8,
                           null);
        }

        public void excelSendAsync(string string_0, string string_1, string string_2, string string_3, string string_4,
                                   string string_5, string string_6, string string_7, string string_8, object userState)
        {
            if (sendOrPostCallback_6 == null)
            {
                sendOrPostCallback_6 = method_7;
            }
            base.InvokeAsync("excelSend",
                             new object[]
                                 {
                                     string_0, string_1, string_2, string_3, string_4, string_5, string_6, string_7,
                                     string_8
                                 }, sendOrPostCallback_6, userState);
        }

        private void method_0(object object_0)
        {
            if (sendLSActionCompleted != null)
            {
                var args = (InvokeCompletedEventArgs) object_0;
                sendLSActionCompleted(this,
                                      new sendLSActionCompletedEventArgs(args.Results, args.Error, args.Cancelled,
                                                                         args.UserState));
            }
        }

        private void method_1(object object_0)
        {
            if (smsSendCompleted != null)
            {
                var args = (InvokeCompletedEventArgs) object_0;
                smsSendCompleted(this,
                                 new smsSendCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        [return: XmlElement("out", IsNullable = true)]
        [SoapDocumentMethod("", RequestNamespace = "http://service.ewing.com",
            ResponseNamespace = "http://service.ewing.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public string method_2([XmlElement(IsNullable = true)] string string_0,
                               [XmlElement(IsNullable = true)] string string_1,
                               [XmlElement(IsNullable = true)] string string_2)
        {
            return (string) base.Invoke("mo", new object[] {string_0, string_1, string_2})[0];
        }

        private void method_3(object object_0)
        {
            if (moCompleted != null)
            {
                var args = (InvokeCompletedEventArgs) object_0;
                moCompleted(this, new moCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void method_4(object object_0)
        {
            if (updatePasswordCompleted != null)
            {
                var args = (InvokeCompletedEventArgs) object_0;
                updatePasswordCompleted(this,
                                        new updatePasswordCompletedEventArgs(args.Results, args.Error, args.Cancelled,
                                                                             args.UserState));
            }
        }

        private void method_5(object object_0)
        {
            if (reportCompleted != null)
            {
                var args = (InvokeCompletedEventArgs) object_0;
                reportCompleted(this,
                                new reportCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void method_6(object object_0)
        {
            if (accountCompleted != null)
            {
                var args = (InvokeCompletedEventArgs) object_0;
                accountCompleted(this,
                                 new accountCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void method_7(object object_0)
        {
            if (excelSendCompleted != null)
            {
                var args = (InvokeCompletedEventArgs) object_0;
                excelSendCompleted(this,
                                   new excelSendCompletedEventArgs(args.Results, args.Error, args.Cancelled,
                                                                   args.UserState));
            }
        }

        private bool method_8(string string_0)
        {
            if ((string_0 == null) || (string_0 == string.Empty))
            {
                return false;
            }
            var uri = new Uri(string_0);
            return ((uri.Port >= 0x400) &&
                    (string.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0));
        }

        public void moAsync(string string_0, string string_1, string string_2)
        {
            moAsync(string_0, string_1, string_2, null);
        }

        public void moAsync(string string_0, string string_1, string string_2, object userState)
        {
            if (sendOrPostCallback_2 == null)
            {
                sendOrPostCallback_2 = method_3;
            }
            base.InvokeAsync("mo", new object[] {string_0, string_1, string_2}, sendOrPostCallback_2, userState);
        }

        [return: XmlElement("out", IsNullable = true)]
        [SoapDocumentMethod("", RequestNamespace = "http://service.ewing.com",
            ResponseNamespace = "http://service.ewing.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public string report([XmlElement(IsNullable = true)] string string_0,
                             [XmlElement(IsNullable = true)] string string_1,
                             [XmlElement(IsNullable = true)] string string_2)
        {
            return (string) base.Invoke("report", new object[] {string_0, string_1, string_2})[0];
        }

        public void reportAsync(string string_0, string string_1, string string_2)
        {
            reportAsync(string_0, string_1, string_2, null);
        }

        public void reportAsync(string string_0, string string_1, string string_2, object userState)
        {
            if (sendOrPostCallback_4 == null)
            {
                sendOrPostCallback_4 = method_5;
            }
            base.InvokeAsync("report", new object[] {string_0, string_1, string_2}, sendOrPostCallback_4, userState);
        }

        [return: XmlElement("out", IsNullable = true)]
        [SoapDocumentMethod("", RequestNamespace = "http://service.ewing.com",
            ResponseNamespace = "http://service.ewing.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public string sendLSAction([XmlElement(IsNullable = true)] string string_0,
                                   [XmlElement(IsNullable = true)] string string_1)
        {
            return (string) base.Invoke("sendLSAction", new object[] {string_0, string_1})[0];
        }

        public void sendLSActionAsync(string string_0, string string_1)
        {
            sendLSActionAsync(string_0, string_1, null);
        }

        public void sendLSActionAsync(string string_0, string string_1, object userState)
        {
            if (sendOrPostCallback_0 == null)
            {
                sendOrPostCallback_0 = method_0;
            }
            base.InvokeAsync("sendLSAction", new object[] {string_0, string_1}, sendOrPostCallback_0, userState);
        }

        [return: XmlElement("out", IsNullable = true)]
        [SoapDocumentMethod("", RequestNamespace = "http://service.ewing.com",
            ResponseNamespace = "http://service.ewing.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public string smsSend([XmlElement(IsNullable = true)] string string_0,
                              [XmlElement(IsNullable = true)] string string_1,
                              [XmlElement(IsNullable = true)] string string_2,
                              [XmlElement(IsNullable = true)] string string_3,
                              [XmlElement(IsNullable = true)] string string_4,
                              [XmlElement(IsNullable = true)] string string_5,
                              [XmlElement(IsNullable = true)] string string_6,
                              [XmlElement(IsNullable = true)] string string_7,
                              [XmlElement(IsNullable = true)] string string_8)
        {
            return
                (string)
                base.Invoke("smsSend",
                            new object[]
                                {
                                    string_0, string_1, string_2, string_3, string_4, string_5, string_6, string_7,
                                    string_8
                                })[0];
        }

        public void smsSendAsync(string string_0, string string_1, string string_2, string string_3, string string_4,
                                 string string_5, string string_6, string string_7, string string_8)
        {
            smsSendAsync(string_0, string_1, string_2, string_3, string_4, string_5, string_6, string_7, string_8, null);
        }

        public void smsSendAsync(string string_0, string string_1, string string_2, string string_3, string string_4,
                                 string string_5, string string_6, string string_7, string string_8, object userState)
        {
            if (sendOrPostCallback_1 == null)
            {
                sendOrPostCallback_1 = method_1;
            }
            base.InvokeAsync("smsSend",
                             new object[]
                                 {
                                     string_0, string_1, string_2, string_3, string_4, string_5, string_6, string_7,
                                     string_8
                                 }, sendOrPostCallback_1, userState);
        }

        [return: XmlElement("out", IsNullable = true)]
        [SoapDocumentMethod("", RequestNamespace = "http://service.ewing.com",
            ResponseNamespace = "http://service.ewing.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public string updatePassword([XmlElement(IsNullable = true)] string string_0,
                                     [XmlElement(IsNullable = true)] string string_1,
                                     [XmlElement(IsNullable = true)] string string_2,
                                     [XmlElement(IsNullable = true)] string string_3)
        {
            return (string) base.Invoke("updatePassword", new object[] {string_0, string_1, string_2, string_3})[0];
        }

        public void updatePasswordAsync(string string_0, string string_1, string string_2, string string_3)
        {
            updatePasswordAsync(string_0, string_1, string_2, string_3, null);
        }

        public void updatePasswordAsync(string string_0, string string_1, string string_2, string string_3,
                                        object userState)
        {
            if (sendOrPostCallback_3 == null)
            {
                sendOrPostCallback_3 = method_4;
            }
            base.InvokeAsync("updatePassword", new object[] {string_0, string_1, string_2, string_3},
                             sendOrPostCallback_3, userState);
        }
    }
}