﻿#pragma checksum "..\..\..\..\View\MasterArtistWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D3CE560ECAB6F386393AEFAA726286E83D6D3E23"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using EventBinder;
using SpotyClient.Components;
using SpotyClient.View;
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


namespace SpotyClient.View {
    
    
    /// <summary>
    /// MasterArtistWindow
    /// </summary>
    public partial class MasterArtistWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 135 "..\..\..\..\View\MasterArtistWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement media1;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\..\View\MasterArtistWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button playButton;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\..\View\MasterArtistWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slider2;
        
        #line default
        #line hidden
        
        
        #line 174 "..\..\..\..\View\MasterArtistWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider sliderback2;
        
        #line default
        #line hidden
        
        
        #line 175 "..\..\..\..\View\MasterArtistWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock time;
        
        #line default
        #line hidden
        
        
        #line 185 "..\..\..\..\View\MasterArtistWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slider1;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SpotyClient;component/view/masterartistwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\MasterArtistWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 13 "..\..\..\..\View\MasterArtistWindow.xaml"
            ((SpotyClient.View.MasterArtistWindow)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MouseDrag);
            
            #line default
            #line hidden
            return;
            case 2:
            this.media1 = ((System.Windows.Controls.MediaElement)(target));
            
            #line 135 "..\..\..\..\View\MasterArtistWindow.xaml"
            this.media1.MediaOpened += new System.Windows.RoutedEventHandler(this.media1_MediaOpened);
            
            #line default
            #line hidden
            return;
            case 3:
            this.playButton = ((System.Windows.Controls.Button)(target));
            
            #line 158 "..\..\..\..\View\MasterArtistWindow.xaml"
            this.playButton.Click += new System.Windows.RoutedEventHandler(this.playButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.slider2 = ((System.Windows.Controls.Slider)(target));
            
            #line 173 "..\..\..\..\View\MasterArtistWindow.xaml"
            this.slider2.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.slider2_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.sliderback2 = ((System.Windows.Controls.Slider)(target));
            return;
            case 6:
            this.time = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.slider1 = ((System.Windows.Controls.Slider)(target));
            
            #line 185 "..\..\..\..\View\MasterArtistWindow.xaml"
            this.slider1.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.slider1_ValueChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

