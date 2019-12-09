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
    /// Page1.xaml の相互作用ロジック
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            Debug.WriteLine("Page1.ctor()");
            this.Loaded += Page1_Loaded;
            this.Unloaded += Page1_Unloaded;
            
        }

       

        private void Page1_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Page1.Loaded()");
        }

        private void Page1_Unloaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Page1.UnLoaded()");
        }


    }
}
