﻿#pragma checksum "..\..\..\Views\VisualizarDados.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FAF734C8CFC53AF2C4FEF5410F55D3BF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
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
using System.Windows.Shell;
using UPE_ONS.Util;
using UPE_ONS.Views;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace UPE_ONS.Views {
    
    
    /// <summary>
    /// VisualizarDados
    /// </summary>
    public partial class VisualizarDados : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\Views\VisualizarDados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.BusyIndicator BusyIndicatorCarregando;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Views\VisualizarDados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbBoxParquesEolicos;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Views\VisualizarDados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbBoxIntervalo;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Views\VisualizarDados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridVisualizarDados;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\Views\VisualizarDados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView TreeViewDadosCPTEC;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\Views\VisualizarDados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtMessage;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\Views\VisualizarDados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkBoxAllFields;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\..\Views\VisualizarDados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridFiltrar;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\Views\VisualizarDados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLimit;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\Views\VisualizarDados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFiltrar;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\Views\VisualizarDados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioCPTEC;
        
        #line default
        #line hidden
        
        
        #line 175 "..\..\..\Views\VisualizarDados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioPrevEOL;
        
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
            System.Uri resourceLocater = new System.Uri("/UPE_ONS;component/views/visualizardados.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\VisualizarDados.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.BusyIndicatorCarregando = ((Xceed.Wpf.Toolkit.BusyIndicator)(target));
            return;
            case 2:
            
            #line 20 "..\..\..\Views\VisualizarDados.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.CanExecute);
            
            #line default
            #line hidden
            
            #line 20 "..\..\..\Views\VisualizarDados.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Executed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cmbBoxParquesEolicos = ((System.Windows.Controls.ComboBox)(target));
            
            #line 34 "..\..\..\Views\VisualizarDados.xaml"
            this.cmbBoxParquesEolicos.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbBoxParquesEolicos_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cmbBoxIntervalo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 37 "..\..\..\Views\VisualizarDados.xaml"
            this.cmbBoxIntervalo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbBoxIntervalo_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dataGridVisualizarDados = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.TreeViewDadosCPTEC = ((System.Windows.Controls.TreeView)(target));
            return;
            case 7:
            this.txtMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.chkBoxAllFields = ((System.Windows.Controls.CheckBox)(target));
            
            #line 153 "..\..\..\Views\VisualizarDados.xaml"
            this.chkBoxAllFields.Checked += new System.Windows.RoutedEventHandler(this.chkBoxAllFields_Checked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.gridFiltrar = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            this.txtLimit = ((System.Windows.Controls.TextBox)(target));
            
            #line 158 "..\..\..\Views\VisualizarDados.xaml"
            this.txtLimit.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnFiltrar = ((System.Windows.Controls.Button)(target));
            return;
            case 12:
            this.radioCPTEC = ((System.Windows.Controls.RadioButton)(target));
            
            #line 173 "..\..\..\Views\VisualizarDados.xaml"
            this.radioCPTEC.Checked += new System.Windows.RoutedEventHandler(this.radioCPTEC_Checked);
            
            #line default
            #line hidden
            return;
            case 13:
            this.radioPrevEOL = ((System.Windows.Controls.RadioButton)(target));
            
            #line 175 "..\..\..\Views\VisualizarDados.xaml"
            this.radioPrevEOL.Checked += new System.Windows.RoutedEventHandler(this.radioPrevEOL_Checked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

