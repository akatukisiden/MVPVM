using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UwpApp.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace UwpApp.Views
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class Page2 : Page
    {
        public Page2ViewModel ViewModel
        {
            set { this.DataContext = value; }
            get { return this.DataContext as Page2ViewModel; }
        }
      
        public Page2()
        {
            // Debug.WriteLine("Page2.ctor()");
            this.InitializeComponent();
            // this.Loaded += Page2_Loaded;
            // this.Unloaded += Page2_Unloaded;
        }
        
        private void Page2_Unloaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Page2.Page2_Unloaded()");
        }

        private void Page2_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Page2.Page2_Loaded()");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Debug.WriteLine("Page2.OnNavigatedTo()");
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            Debug.WriteLine("Page2.OnNavigatingFrom()");
            base.OnNavigatingFrom(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Debug.WriteLine("Page2.OnNavigatedFrom()");
            base.OnNavigatedFrom(e);
        }
        
    }
}
