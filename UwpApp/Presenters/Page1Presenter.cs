using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpFramework.Presenters;
using UwpApp.ViewModels;
using UwpApp.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;

namespace UwpApp.Presenters
{
    
    public class Page1Presenter : PagePresenterBase<Views.Page1, Page1ViewModel>
    {
        
        public Page1Presenter()
        {
            
        }

        public override void Initialize()
        {
            base.Initialize();
            ViewModel.ClickEvent += Click;
            this.ViewModel.Text = "Page1";
        }

        public void Click(object sender, RoutedEventArgs args)
        {
            this.Parent.Navigate(typeof(Page2), null);
        }

        public override void Cleanup()
        {
            ViewModel.ClickEvent -= Click;
            base.Cleanup();
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

        protected override void OnNavigationStopped(NavigationEventArgs e)
        {
            base.OnNavigationStopped(e);
        }


        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        protected override void OnNavigationFailed(NavigationFailedEventArgs e)
        {
            base.OnNavigationFailed(e);
        }

    }
    
}
