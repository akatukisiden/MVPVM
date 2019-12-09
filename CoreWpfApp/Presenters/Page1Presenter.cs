using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Navigation;
using CoreWpfApp.ViewModels;
using CoreWpfApp.Views;
using CoreWpfFramework.Commands;
using CoreWpfFramework.Presenters;

namespace CoreWpfApp.Presenters
{
    public class Page1Presenter : PagePresenterBase<Page1, Page1ViewModel>
    {

        public Page1Presenter()
        {

        }

        public void NavigateToPage2(object p)
        {
            Parent.Navigate("/Views/Page2.xaml");
        }

        public override void Initialize()
        {
            base.Initialize();
            ViewModel.Text = "Page1";
            ViewModel.Command = new DelegateCommand(NavigateToPage2);       
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        protected override void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            base.OnPageLoaded(sender, e);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            // e.Cancel = true;
            base.OnNavigatingFrom(e);
        }
        
        protected override void OnNavigationProgress(NavigationProgressEventArgs e)
        {
            base.OnNavigationProgress(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        protected override void OnNavigationStopped(NavigationEventArgs e)
        {
            base.OnNavigationStopped(e);
        }

        protected override void OnNavigationFailed(NavigationFailedEventArgs e)
        {
            base.OnNavigationFailed(e);
        }

        public override void Cleanup()
        {
            ViewModel.Command = null;
            base.Cleanup();
        }


    }
}
