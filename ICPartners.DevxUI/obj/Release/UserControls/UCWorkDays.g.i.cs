﻿#pragma checksum "..\..\..\UserControls\UCWorkDays.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8E6BE91E79B2BEA7005D8EF1EBEB3DAACAA745FF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Core;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.ConditionalFormatting;
using DevExpress.Xpf.Core.DataSources;
using DevExpress.Xpf.Core.Serialization;
using DevExpress.Xpf.Core.ServerMode;
using DevExpress.Xpf.DXBinding;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.DataPager;
using DevExpress.Xpf.Editors.DateNavigator;
using DevExpress.Xpf.Editors.ExpressionEditor;
using DevExpress.Xpf.Editors.Filtering;
using DevExpress.Xpf.Editors.Flyout;
using DevExpress.Xpf.Editors.Popups;
using DevExpress.Xpf.Editors.Popups.Calendar;
using DevExpress.Xpf.Editors.RangeControl;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Editors.Settings.Extension;
using DevExpress.Xpf.Editors.Validation;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.ConditionalFormatting;
using DevExpress.Xpf.Grid.LookUp;
using DevExpress.Xpf.Grid.TreeList;
using ICPartners.DAL;
using ICPartners.DevxUI.UserControls;
using ICPartners.DevxUI.ViewModels;
using ICPartners.Domains;
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


namespace ICPartners.DevxUI.UserControls {
    
    
    /// <summary>
    /// UCWorkDays
    /// </summary>
    public partial class UCWorkDays : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 50 "..\..\..\UserControls\UCWorkDays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridControl gridworkdays;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\UserControls\UCWorkDays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.TableView tableview;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\UserControls\UCWorkDays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem deleteRowItem;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\UserControls\UCWorkDays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarButtonItem copyCellDataItem;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\UserControls\UCWorkDays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;
        
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
            System.Uri resourceLocater = new System.Uri("/ICPartners.DevxUI;component/usercontrols/ucworkdays.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\UCWorkDays.xaml"
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
            this.gridworkdays = ((DevExpress.Xpf.Grid.GridControl)(target));
            return;
            case 2:
            this.tableview = ((DevExpress.Xpf.Grid.TableView)(target));
            
            #line 52 "..\..\..\UserControls\UCWorkDays.xaml"
            this.tableview.CellValueChanged += new DevExpress.Xpf.Grid.CellValueChangedEventHandler(this.tableview_CellValueChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.deleteRowItem = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            
            #line 55 "..\..\..\UserControls\UCWorkDays.xaml"
            this.deleteRowItem.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(this.deleteRowItem_ItemClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.copyCellDataItem = ((DevExpress.Xpf.Bars.BarButtonItem)(target));
            
            #line 57 "..\..\..\UserControls\UCWorkDays.xaml"
            this.copyCellDataItem.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(this.copyCellDataItem_ItemClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SaveButton = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\..\UserControls\UCWorkDays.xaml"
            this.SaveButton.Click += new System.Windows.RoutedEventHandler(this.Save_Clicked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

