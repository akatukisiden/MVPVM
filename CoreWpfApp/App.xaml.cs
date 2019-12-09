using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CoreWpfApp.Presenters;

namespace CoreWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindowPresenter _presenter = new MainWindowPresenter();

        public App()
        {
            this.ShutdownMode = ShutdownMode.OnLastWindowClose;
            this.Activated += App_Activated;
            this.Deactivated += App_Deactivated;
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
            this.Exit += App_Exit;
            /*
            this.LoadCompleted += App_LoadCompleted;
            this.Navigated += App_Navigated;
            this.Navigating += App_Navigating;
            this.NavigationFailed += App_NavigationFailed;
            this.NavigationProgress += App_NavigationProgress;
            this.NavigationStopped += App_NavigationStopped;
            this.SessionEnding += App_SessionEnding;
            */
            
            this.Startup += App_Startup;
        }

        private void App_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            Debug.WriteLine("App.SessionEnding()");
        }

        private void App_NavigationStopped(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            Debug.WriteLine("App.NavigationStopped()");
        }

        private void App_NavigationProgress(object sender, System.Windows.Navigation.NavigationProgressEventArgs e)
        {
            // Debug.WriteLine("App.NavigationProgress()");
        }

        private void App_NavigationFailed(object sender, System.Windows.Navigation.NavigationFailedEventArgs e)
        {
            Debug.WriteLine("App.NavigationFailed()");
        }

        private void App_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            Debug.WriteLine("App.Navigating()");
        }

        private void App_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            Debug.WriteLine("App.Navigated()");
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Debug.WriteLine("App.DispatcherUnhandledException()");
        }

        private void App_Deactivated(object sender, EventArgs e)
        {
            Debug.WriteLine("App.Deactivated()");
        }

        private void App_Activated(object sender, EventArgs e)
        {
            Debug.WriteLine("App.Activated()");
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            Debug.WriteLine("App.Exit()");
        }

        private void App_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            Debug.WriteLine("App.LoadCompleted()");
        }
        
        private void App_Startup(object sender, StartupEventArgs e)
        {
            Debug.WriteLine("App.Startup()");

            _presenter.View = new Views.MainWindow();
            _presenter.Initialize();
            _presenter.Navigate("/Views/Page1.xaml");
            _presenter.Show();
        }
    }
}
