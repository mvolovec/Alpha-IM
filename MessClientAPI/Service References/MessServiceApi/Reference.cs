﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MessClientAPI.MessServiceApi {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ImUser", Namespace="http://schemas.datacontract.org/2004/07/MyService1")]
    [System.SerializableAttribute()]
    public partial class ImUser : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ID_USRField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string USR_FIRSTNAMEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string USR_LASTNAMEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string USR_NICKField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int USR_STATUSField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID_USR {
            get {
                return this.ID_USRField;
            }
            set {
                if ((this.ID_USRField.Equals(value) != true)) {
                    this.ID_USRField = value;
                    this.RaisePropertyChanged("ID_USR");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string USR_FIRSTNAME {
            get {
                return this.USR_FIRSTNAMEField;
            }
            set {
                if ((object.ReferenceEquals(this.USR_FIRSTNAMEField, value) != true)) {
                    this.USR_FIRSTNAMEField = value;
                    this.RaisePropertyChanged("USR_FIRSTNAME");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string USR_LASTNAME {
            get {
                return this.USR_LASTNAMEField;
            }
            set {
                if ((object.ReferenceEquals(this.USR_LASTNAMEField, value) != true)) {
                    this.USR_LASTNAMEField = value;
                    this.RaisePropertyChanged("USR_LASTNAME");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string USR_NICK {
            get {
                return this.USR_NICKField;
            }
            set {
                if ((object.ReferenceEquals(this.USR_NICKField, value) != true)) {
                    this.USR_NICKField = value;
                    this.RaisePropertyChanged("USR_NICK");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int USR_STATUS {
            get {
                return this.USR_STATUSField;
            }
            set {
                if ((this.USR_STATUSField.Equals(value) != true)) {
                    this.USR_STATUSField = value;
                    this.RaisePropertyChanged("USR_STATUS");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ImMessage", Namespace="http://schemas.datacontract.org/2004/07/MyService1")]
    [System.SerializableAttribute()]
    public partial class ImMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime C_DATEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long ID_MESSAGEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ID_SENDERField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ID_USRField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MSG_BODYField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MSG_TYPEField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime C_DATE {
            get {
                return this.C_DATEField;
            }
            set {
                if ((this.C_DATEField.Equals(value) != true)) {
                    this.C_DATEField = value;
                    this.RaisePropertyChanged("C_DATE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long ID_MESSAGE {
            get {
                return this.ID_MESSAGEField;
            }
            set {
                if ((this.ID_MESSAGEField.Equals(value) != true)) {
                    this.ID_MESSAGEField = value;
                    this.RaisePropertyChanged("ID_MESSAGE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID_SENDER {
            get {
                return this.ID_SENDERField;
            }
            set {
                if ((this.ID_SENDERField.Equals(value) != true)) {
                    this.ID_SENDERField = value;
                    this.RaisePropertyChanged("ID_SENDER");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID_USR {
            get {
                return this.ID_USRField;
            }
            set {
                if ((this.ID_USRField.Equals(value) != true)) {
                    this.ID_USRField = value;
                    this.RaisePropertyChanged("ID_USR");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MSG_BODY {
            get {
                return this.MSG_BODYField;
            }
            set {
                if ((object.ReferenceEquals(this.MSG_BODYField, value) != true)) {
                    this.MSG_BODYField = value;
                    this.RaisePropertyChanged("MSG_BODY");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MSG_TYPE {
            get {
                return this.MSG_TYPEField;
            }
            set {
                if ((this.MSG_TYPEField.Equals(value) != true)) {
                    this.MSG_TYPEField = value;
                    this.RaisePropertyChanged("MSG_TYPE");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MessServiceApi.IMessagingService")]
    public interface IMessagingService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessagingService/User_RegisterNewContact", ReplyAction="http://tempuri.org/IMessagingService/User_RegisterNewContactResponse")]
        int User_RegisterNewContact(string nick, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessagingService/User_Validate", ReplyAction="http://tempuri.org/IMessagingService/User_ValidateResponse")]
        bool User_Validate(int id_usr, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessagingService/User_Login", ReplyAction="http://tempuri.org/IMessagingService/User_LoginResponse")]
        bool User_Login(int id_usr, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessagingService/User_Logout", ReplyAction="http://tempuri.org/IMessagingService/User_LogoutResponse")]
        bool User_Logout(int id_usr, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessagingService/Contact_GetMyContacts", ReplyAction="http://tempuri.org/IMessagingService/Contact_GetMyContactsResponse")]
        MessClientAPI.MessServiceApi.ImUser[] Contact_GetMyContacts(int id_usr, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessagingService/Contact_GetAllContacts", ReplyAction="http://tempuri.org/IMessagingService/Contact_GetAllContactsResponse")]
        MessClientAPI.MessServiceApi.ImUser[] Contact_GetAllContacts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessagingService/Message_GetMyMessages", ReplyAction="http://tempuri.org/IMessagingService/Message_GetMyMessagesResponse")]
        MessClientAPI.MessServiceApi.ImMessage[] Message_GetMyMessages(int id_usr, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessagingService/Message_GetMyNewMessages", ReplyAction="http://tempuri.org/IMessagingService/Message_GetMyNewMessagesResponse")]
        MessClientAPI.MessServiceApi.ImMessage[] Message_GetMyNewMessages(int id_usr, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessagingService/Message_InsertMessageForUser", ReplyAction="http://tempuri.org/IMessagingService/Message_InsertMessageForUserResponse")]
        bool Message_InsertMessageForUser(int id_usr, string password, string msg_body, int msg_type, int[] dest_user);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IMessagingServiceChannel : MessClientAPI.MessServiceApi.IMessagingService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class MessagingServiceClient : System.ServiceModel.ClientBase<MessClientAPI.MessServiceApi.IMessagingService>, MessClientAPI.MessServiceApi.IMessagingService {
        
        public MessagingServiceClient() {
        }
        
        public MessagingServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MessagingServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MessagingServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MessagingServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int User_RegisterNewContact(string nick, string password) {
            return base.Channel.User_RegisterNewContact(nick, password);
        }
        
        public bool User_Validate(int id_usr, string password) {
            return base.Channel.User_Validate(id_usr, password);
        }
        
        public bool User_Login(int id_usr, string password) {
            return base.Channel.User_Login(id_usr, password);
        }
        
        public bool User_Logout(int id_usr, string password) {
            return base.Channel.User_Logout(id_usr, password);
        }
        
        public MessClientAPI.MessServiceApi.ImUser[] Contact_GetMyContacts(int id_usr, string password) {
            return base.Channel.Contact_GetMyContacts(id_usr, password);
        }
        
        public MessClientAPI.MessServiceApi.ImUser[] Contact_GetAllContacts() {
            return base.Channel.Contact_GetAllContacts();
        }
        
        public MessClientAPI.MessServiceApi.ImMessage[] Message_GetMyMessages(int id_usr, string password) {
            return base.Channel.Message_GetMyMessages(id_usr, password);
        }
        
        public MessClientAPI.MessServiceApi.ImMessage[] Message_GetMyNewMessages(int id_usr, string password) {
            return base.Channel.Message_GetMyNewMessages(id_usr, password);
        }
        
        public bool Message_InsertMessageForUser(int id_usr, string password, string msg_body, int msg_type, int[] dest_user) {
            return base.Channel.Message_InsertMessageForUser(id_usr, password, msg_body, msg_type, dest_user);
        }
    }
}
