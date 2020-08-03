﻿#pragma checksum "..\..\..\Views\CreateNewOrder.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BBE03862404F0A13C7C541CB06D005A5ED9C522C"
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
    /// CreateNewOrder
    /// </summary>
    public partial class CreateNewOrder : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\Views\CreateNewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exit;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Views\CreateNewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddItem;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\Views\CreateNewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridAllMenu;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\Views\CreateNewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid msgNoItems;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\..\Views\CreateNewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridOrderItem;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\..\Views\CreateNewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddReport;
        
        #line default
        #line hidden
        
        
        #line 192 "..\..\..\Views\CreateNewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridOrder;
        
        #line default
        #line hidden
        
        
        #line 290 "..\..\..\Views\CreateNewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTotalSum;
        
        #line default
        #line hidden
        
        
        #line 303 "..\..\..\Views\CreateNewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPlaceOrderNow;
        
        #line default
        #line hidden
        
        
        #line 329 "..\..\..\Views\CreateNewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Badged CountingBadge;
        
        #line default
        #line hidden
        
        
        #line 352 "..\..\..\Views\CreateNewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTotalSumBottom;
        
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
            System.Uri resourceLocater = new System.Uri("/PizzaRestaurant;component/views/createneworder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\CreateNewOrder.xaml"
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
            this.Exit = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.btnAddItem = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\Views\CreateNewOrder.xaml"
            this.btnAddItem.Click += new System.Windows.RoutedEventHandler(this.BtnAddItem_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DataGridAllMenu = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.msgNoItems = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.gridOrderItem = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.btnAddReport = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.DataGridOrder = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.txtTotalSum = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.btnPlaceOrderNow = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.CountingBadge = ((MaterialDesignThemes.Wpf.Badged)(target));
            return;
            case 11:
            this.txtTotalSumBottom = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
