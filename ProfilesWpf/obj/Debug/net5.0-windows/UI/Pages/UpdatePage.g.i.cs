﻿#pragma checksum "..\..\..\..\..\UI\Pages\UpdatePage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9C1D9C3D6E6B8AA3D88A787A4EF26E248537C36D"
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
using ProfilesWpf.UI.Pages;
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


namespace ProfilesWpf.UI.Pages {
    
    
    /// <summary>
    /// UpdatePage
    /// </summary>
    public partial class UpdatePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\..\UI\Pages\UpdatePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ImageBrush PassportImg;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\UI\Pages\UpdatePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PassportBtn;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\UI\Pages\UpdatePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ImageBrush PortraitImg;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\UI\Pages\UpdatePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PortraitBtn;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\..\UI\Pages\UpdatePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SaveIdTextInp;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\..\UI\Pages\UpdatePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SaveFirstNameInp;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\..\UI\Pages\UpdatePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SaveLastNameInp;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\..\UI\Pages\UpdatePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SaveFacultyInp;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\..\..\UI\Pages\UpdatePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditBtn;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\..\UI\Pages\UpdatePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SaveBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProfilesWpf;V1.0.0.0;component/ui/pages/updatepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\UI\Pages\UpdatePage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.PassportImg = ((System.Windows.Media.ImageBrush)(target));
            return;
            case 2:
            this.PassportBtn = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\..\UI\Pages\UpdatePage.xaml"
            this.PassportBtn.Click += new System.Windows.RoutedEventHandler(this.PassportBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PortraitImg = ((System.Windows.Media.ImageBrush)(target));
            return;
            case 4:
            this.PortraitBtn = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\..\UI\Pages\UpdatePage.xaml"
            this.PortraitBtn.Click += new System.Windows.RoutedEventHandler(this.PortraitBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SaveIdTextInp = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.SaveFirstNameInp = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.SaveLastNameInp = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.SaveFacultyInp = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.EditBtn = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\..\..\..\UI\Pages\UpdatePage.xaml"
            this.EditBtn.Click += new System.Windows.RoutedEventHandler(this.EditBtn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.SaveBtn = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

