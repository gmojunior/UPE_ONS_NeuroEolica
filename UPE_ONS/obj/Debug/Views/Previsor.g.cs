﻿#pragma checksum "..\..\..\Views\Previsor.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "613344777AF1348DC11DF8F2939F53AF"
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
    /// Previsor
    /// </summary>
    public partial class Previsor : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\Views\Previsor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.BusyIndicator BusyIndicatorCarregando;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Views\Previsor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTitulo;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Views\Previsor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridContent;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Views\Previsor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock feedbackMessage;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Views\Previsor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbBoxTipo;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Views\Previsor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstViewParquesEolicos;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Views\Previsor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstViewParquesEolicosSelecionados;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Views\Previsor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn1;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\Views\Previsor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridPaternProgressBar;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\Views\Previsor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridProgressBar;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\Views\Previsor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtProgressValue;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\Views\Previsor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar processBar;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\Views\Previsor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridMessage;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\Views\Previsor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtMessage;
        
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
            System.Uri resourceLocater = new System.Uri("/UPE_ONS;component/views/previsor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\Previsor.xaml"
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
            this.BusyIndicatorCarregando = ((Xceed.Wpf.Toolkit.BusyIndicator)(target));
            return;
            case 2:
            this.txtTitulo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.gridContent = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.feedbackMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.cmbBoxTipo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.lstViewParquesEolicos = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.lstViewParquesEolicosSelecionados = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            
            #line 51 "..\..\..\Views\Previsor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoverParqueEolico_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 52 "..\..\..\Views\Previsor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoverTodosParquesEolicos_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 54 "..\..\..\Views\Previsor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AdicionarParqueEolico_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 55 "..\..\..\Views\Previsor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AdicionarTodosParquesEolicos_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 59 "..\..\..\Views\Previsor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnExecutarPrevisor_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.btn1 = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\Views\Previsor.xaml"
            this.btn1.Click += new System.Windows.RoutedEventHandler(this.btnExibirGraficos_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.gridPaternProgressBar = ((System.Windows.Controls.Grid)(target));
            return;
            case 15:
            this.GridProgressBar = ((System.Windows.Controls.Grid)(target));
            return;
            case 16:
            this.txtProgressValue = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 17:
            this.processBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 18:
            this.gridMessage = ((System.Windows.Controls.Grid)(target));
            return;
            case 19:
            this.txtMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

