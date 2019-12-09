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

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace UwpApp.Views
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class Page1 : Page
    {
        public Page1ViewModel ViewModel {
            set { this.DataContext = value; }
            get { return this.DataContext as Page1ViewModel; }
        }
        
      
        public Page1()
        {
            // Debug.WriteLine("Page1.ctor()");
            this.InitializeComponent();

            // this.Loaded += Page1_Loaded;
            // this.Unloaded += Page1_Unloaded;
        }
        

      private void Page1_Unloaded(object sender, RoutedEventArgs e)
      {
          Debug.WriteLine("Page1.Page1_Unloaded()");
      }

      private void Page1_Loaded(object sender, RoutedEventArgs e)
      {
          Debug.WriteLine("Page1.Page1_Loaded()");
      }

      protected override void OnNavigatedTo(NavigationEventArgs e)
      {
          Debug.WriteLine("Page1.OnNavigatedTo()");
          base.OnNavigatedTo(e);
      }

      protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
      {
          Debug.WriteLine("Page1.OnNavigatingFrom()");
          base.OnNavigatingFrom(e);
      }

      protected override void OnNavigatedFrom(NavigationEventArgs e)
      {
          Debug.WriteLine("Page1.OnNavigatedFrom()");
          base.OnNavigatedFrom(e);
      }
      

        
    }


}
