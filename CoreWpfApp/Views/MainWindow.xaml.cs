using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            InitializeComponent();


            this.Navigating += MainWindow_Navigating;
            this.Navigated += MainWindow_Navigated;
            this.LoadCompleted += MainWindow_LoadCompleted;
          
        }

        private void MainWindow_LoadCompleted(object sender, NavigationEventArgs e)
        {
            Debug.WriteLine("Window.LoadCompleted()");
        }

        private void MainWindow_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            Debug.WriteLine("Window.Navigating()");
        }

        private void MainWindow_Navigated(object sender, NavigationEventArgs e)
        {
            Debug.WriteLine("Window.Navigated()");
        }


    }
}
