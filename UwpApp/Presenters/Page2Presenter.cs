using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpApp.Views;
using UwpFramework.Presenters;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace UwpApp.Presenters
{
    
    public class Page2Presenter : PagePresenterBase<Views.Page2, ViewModels.Page2ViewModel>
    {

        public override void Initialize()
        {
            base.Initialize();
            ViewModel.ClickEvent += Click;

            this.ViewModel.Text = "Page2";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        public void Click(object sender, RoutedEventArgs args)
        {
            //this.Parent.Navigate(typeof(Page1), null);
            this.Parent.GoBack();
        }


        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
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

        public override void Cleanup()
        {
            ViewModel.ClickEvent -= Click;
            base.Cleanup();
        }
    }
    
}
