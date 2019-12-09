using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoreWpfApp.Views
{
    /// <summary>
    /// Page2.xaml の相互作用ロジック
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            Debug.WriteLine("Page2.ctor()");

            this.Loaded += Page2_Loaded;
            this.Unloaded += Page2_Unloaded;
           
           
        }


        private void Page2_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Page2.Loaded()");
        }

        private void Page2_Unloaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Page2.Unloaded()");
        }


      
    }
}
