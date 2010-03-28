﻿#pragma checksum "..\..\ChatWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7E25294C156079E9AE734FC39FE06623"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_IM_CLIENT;


namespace WPF_IM_CLIENT {
    
    
    /// <summary>
    /// ChatWindow
    /// </summary>
    public partial class ChatWindow : WPF_IM_CLIENT.WindowTemplate, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\ChatWindow.xaml"
        internal System.Windows.Controls.FlowDocumentScrollViewer fdsvConversation;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\ChatWindow.xaml"
        internal System.Windows.Documents.FlowDocument fdConversation;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\ChatWindow.xaml"
        internal System.Windows.Documents.Paragraph pConversation;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\ChatWindow.xaml"
        internal System.Windows.Controls.Button btnSendMessage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPF_IM_CLIENT;component/chatwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ChatWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.fdsvConversation = ((System.Windows.Controls.FlowDocumentScrollViewer)(target));
            return;
            case 2:
            this.fdConversation = ((System.Windows.Documents.FlowDocument)(target));
            return;
            case 3:
            this.pConversation = ((System.Windows.Documents.Paragraph)(target));
            return;
            case 4:
            this.btnSendMessage = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\ChatWindow.xaml"
            this.btnSendMessage.Click += new System.Windows.RoutedEventHandler(this.btnSendMessage_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
