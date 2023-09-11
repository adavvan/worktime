﻿#pragma checksum "..\..\..\..\..\MVVM\Views\ExportView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "998736C0DCBEB38EC0B0BEA67E174095EB3552C5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using System.Windows.Controls.Ribbon;
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
using Worktime.MVVM.Views;


namespace Worktime.MVVM.Views {
    
    
    /// <summary>
    /// ExportView
    /// </summary>
    public partial class ExportView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\..\MVVM\Views\ExportView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker startDate;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\MVVM\Views\ExportView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker endDate;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\MVVM\Views\ExportView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExportTasksBtn;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\MVVM\Views\ExportView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox WorkerComboBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\MVVM\Views\ExportView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker startDateWorker;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\MVVM\Views\ExportView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker endDateWorker;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\MVVM\Views\ExportView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExportWorkerTasksBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Worktime;V1.0.0.0;component/mvvm/views/exportview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\MVVM\Views\ExportView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.startDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.endDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.ExportTasksBtn = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\..\MVVM\Views\ExportView.xaml"
            this.ExportTasksBtn.Click += new System.Windows.RoutedEventHandler(this.ExportTasksBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.WorkerComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.startDateWorker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.endDateWorker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.ExportWorkerTasksBtn = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\..\MVVM\Views\ExportView.xaml"
            this.ExportWorkerTasksBtn.Click += new System.Windows.RoutedEventHandler(this.ExportWorkerTasksBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

