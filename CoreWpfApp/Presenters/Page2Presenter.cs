using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;
using CoreWpfApp.ViewModels;
using CoreWpfApp.Views;
using CoreWpfFramework.Commands;
using CoreWpfFramework.Presenters;

namespace CoreWpfApp.Presenters
{
    public class Page2Presenter : PagePresenterBase<Page2, Page2ViewModel>
    {
        public void NavigateToPage1(object p)
        {
            Parent.Navigate("/Views/Page1.xaml");
        }

        public override void Initialize()
        {
            base.Initialize();
            ViewModel.Text = "Page2";
            ViewModel.Command = new DelegateCommand(NavigateToPage1);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigationProgress(NavigationProgressEventArgs e)
        {
            base.OnNavigationProgress(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        public override void Cleanup()
        {
            ViewModel.Command = null;
            base.Cleanup();
        }
    }
}
