using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Navigation;
using CoreWpfApp.Views;
using CoreWpfFramework.Presenters;
using CoreWpfFramework.ViewModels;


namespace CoreWpfApp.Presenters
{
    public class MainWindowPresenter : NavigationWindowPresenterBase<MainWindow, EmptyViewModel>
    {
        public override void Initialize()
        {
            Debug.WriteLine("WindowPresenter.Initialize()");
            base.Initialize();

            AddChild(typeof(Page1), new Page1Presenter());
            AddChild(typeof(Page2), new Page2Presenter());
            this.IsNavigationStackEnabled = true;
        }

        public override bool Navigate(Uri uri, object extraData = null)
        {
            return base.Navigate(uri, extraData);
        }

        public override bool Navigate(string uri, object extraData = null)
        {
            return base.Navigate(uri, extraData);
        }

        public override void Cleanup()
        {
            Debug.WriteLine("WindowPresenter.Cleanup()");
            base.Cleanup();
        }
    }
}
