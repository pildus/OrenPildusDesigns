#pragma checksum "..\..\..\..\..\UserControls\ProductDisplay.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5497499FE445B22B9B600DDBBE08B39356076124"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using OPD_GUI.UserControls;
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


namespace OPD_GUI.UserControls {
    
    
    /// <summary>
    /// ProductDisplay
    /// </summary>
    public partial class ProductDisplay : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\..\UserControls\ProductDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ProductTitle;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\..\UserControls\ProductDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Availability;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\UserControls\ProductDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ProductImage;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\UserControls\ProductDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ProductDescription;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\..\UserControls\ProductDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ProductPrice;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\UserControls\ProductDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddToSC;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\UserControls\ProductDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ProductProductID;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/OPD_GUI;component/usercontrols/productdisplay.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\UserControls\ProductDisplay.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ProductTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Availability = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.ProductImage = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.ProductDescription = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.ProductPrice = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.AddToSC = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\..\UserControls\ProductDisplay.xaml"
            this.AddToSC.Click += new System.Windows.RoutedEventHandler(this.AddToSC_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ProductProductID = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

