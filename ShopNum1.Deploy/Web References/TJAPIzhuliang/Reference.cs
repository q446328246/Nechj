﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.1026
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.1026 版自动生成。
// 
#pragma warning disable 1591

namespace ShopNum1.Deploy.TJAPIzhuliang {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="MemberServiceSoap", Namespace="http://membersystem.com/")]
    public partial class MemberService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback MemberInfoOperationCompleted;
        
        private System.Threading.SendOrPostCallback MemberOrderOperationCompleted;
        
        private System.Threading.SendOrPostCallback MemberOrderBackOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public MemberService() {
            this.Url = global::ShopNum1.Deploy.Properties.Settings.Default.ShopNum1_Deploy_TJAPIzhuliang_MemberService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event MemberInfoCompletedEventHandler MemberInfoCompleted;
        
        /// <remarks/>
        public event MemberOrderCompletedEventHandler MemberOrderCompleted;
        
        /// <remarks/>
        public event MemberOrderBackCompletedEventHandler MemberOrderBackCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://membersystem.com/MemberInfo", RequestNamespace="http://membersystem.com/", ResponseNamespace="http://membersystem.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string MemberInfo(string Number, string Placement, string Direct, string LevelInt, string Name, string Sex, string MobileTele, string PaperNumber, string BankAddress, string BankCard, string BankBook, string RegisterDate, string MemberOrders, string md5) {
            object[] results = this.Invoke("MemberInfo", new object[] {
                        Number,
                        Placement,
                        Direct,
                        LevelInt,
                        Name,
                        Sex,
                        MobileTele,
                        PaperNumber,
                        BankAddress,
                        BankCard,
                        BankBook,
                        RegisterDate,
                        MemberOrders,
                        md5});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void MemberInfoAsync(string Number, string Placement, string Direct, string LevelInt, string Name, string Sex, string MobileTele, string PaperNumber, string BankAddress, string BankCard, string BankBook, string RegisterDate, string MemberOrders, string md5) {
            this.MemberInfoAsync(Number, Placement, Direct, LevelInt, Name, Sex, MobileTele, PaperNumber, BankAddress, BankCard, BankBook, RegisterDate, MemberOrders, md5, null);
        }
        
        /// <remarks/>
        public void MemberInfoAsync(string Number, string Placement, string Direct, string LevelInt, string Name, string Sex, string MobileTele, string PaperNumber, string BankAddress, string BankCard, string BankBook, string RegisterDate, string MemberOrders, string md5, object userState) {
            if ((this.MemberInfoOperationCompleted == null)) {
                this.MemberInfoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMemberInfoOperationCompleted);
            }
            this.InvokeAsync("MemberInfo", new object[] {
                        Number,
                        Placement,
                        Direct,
                        LevelInt,
                        Name,
                        Sex,
                        MobileTele,
                        PaperNumber,
                        BankAddress,
                        BankCard,
                        BankBook,
                        RegisterDate,
                        MemberOrders,
                        md5}, this.MemberInfoOperationCompleted, userState);
        }
        
        private void OnMemberInfoOperationCompleted(object arg) {
            if ((this.MemberInfoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MemberInfoCompleted(this, new MemberInfoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://membersystem.com/MemberOrder", RequestNamespace="http://membersystem.com/", ResponseNamespace="http://membersystem.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string MemberOrder(string Number, string Name, string OrderID, string TotalMoney, string TotalPv, string IsAgain, string OrderType, string OrderDate, string md5) {
            object[] results = this.Invoke("MemberOrder", new object[] {
                        Number,
                        Name,
                        OrderID,
                        TotalMoney,
                        TotalPv,
                        IsAgain,
                        OrderType,
                        OrderDate,
                        md5});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void MemberOrderAsync(string Number, string Name, string OrderID, string TotalMoney, string TotalPv, string IsAgain, string OrderType, string OrderDate, string md5) {
            this.MemberOrderAsync(Number, Name, OrderID, TotalMoney, TotalPv, IsAgain, OrderType, OrderDate, md5, null);
        }
        
        /// <remarks/>
        public void MemberOrderAsync(string Number, string Name, string OrderID, string TotalMoney, string TotalPv, string IsAgain, string OrderType, string OrderDate, string md5, object userState) {
            if ((this.MemberOrderOperationCompleted == null)) {
                this.MemberOrderOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMemberOrderOperationCompleted);
            }
            this.InvokeAsync("MemberOrder", new object[] {
                        Number,
                        Name,
                        OrderID,
                        TotalMoney,
                        TotalPv,
                        IsAgain,
                        OrderType,
                        OrderDate,
                        md5}, this.MemberOrderOperationCompleted, userState);
        }
        
        private void OnMemberOrderOperationCompleted(object arg) {
            if ((this.MemberOrderCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MemberOrderCompleted(this, new MemberOrderCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://membersystem.com/MemberOrderBack", RequestNamespace="http://membersystem.com/", ResponseNamespace="http://membersystem.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string MemberOrderBack(string Number, string OrderID, string md5) {
            object[] results = this.Invoke("MemberOrderBack", new object[] {
                        Number,
                        OrderID,
                        md5});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void MemberOrderBackAsync(string Number, string OrderID, string md5) {
            this.MemberOrderBackAsync(Number, OrderID, md5, null);
        }
        
        /// <remarks/>
        public void MemberOrderBackAsync(string Number, string OrderID, string md5, object userState) {
            if ((this.MemberOrderBackOperationCompleted == null)) {
                this.MemberOrderBackOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMemberOrderBackOperationCompleted);
            }
            this.InvokeAsync("MemberOrderBack", new object[] {
                        Number,
                        OrderID,
                        md5}, this.MemberOrderBackOperationCompleted, userState);
        }
        
        private void OnMemberOrderBackOperationCompleted(object arg) {
            if ((this.MemberOrderBackCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MemberOrderBackCompleted(this, new MemberOrderBackCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void MemberInfoCompletedEventHandler(object sender, MemberInfoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MemberInfoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal MemberInfoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void MemberOrderCompletedEventHandler(object sender, MemberOrderCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MemberOrderCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal MemberOrderCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void MemberOrderBackCompletedEventHandler(object sender, MemberOrderBackCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MemberOrderBackCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal MemberOrderBackCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591