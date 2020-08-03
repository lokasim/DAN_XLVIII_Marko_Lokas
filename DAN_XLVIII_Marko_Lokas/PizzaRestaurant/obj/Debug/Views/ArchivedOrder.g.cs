﻿#pragma checksum "..\..\..\Views\ArchivedOrder.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1151DD1F2C16CE9FE5CA1A9A2974DCA22D5D5BCD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using PizzaRestaurant.Views;
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
using System.Windows.Shell;


namespace PizzaRestaurant.Views {
    
    
    /// <summary>
    /// ArchivedOrder
    /// </summary>
    public partial class ArchivedOrder : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\Views\ArchivedOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCreateOrder;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Views\ArchivedOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock msgDelete;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Views\ArchivedOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox OrderNumber;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Views\ArchivedOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddReport;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Views\ArchivedOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridOrderList;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Views\ArchivedOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock msgNoOrder;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\Views\ArchivedOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvOrder;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\Views\ArchivedOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridViewOrderItem;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PizzaRestaurant;component/views/archivedorder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ArchivedOrder.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lblCreateOrder = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.msgDelete = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.OrderNumber = ((System.Windows.Controls.TextBox)(target));
            
            #line 49 "..\..\..\Views\ArchivedOrder.xaml"
            this.OrderNumber.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PreviewNumberInputHandler);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnAddReport = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.GridOrderList = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.msgNoOrder = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.lvOrder = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            this.GridViewOrderItem = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

