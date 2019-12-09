using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using CoreWpfFramework.Presenters.Core;
using CoreWpfFramework.ViewModels;

namespace CoreWpfFramework.Presenters
{
    /// <summary>
    /// Frame を使用して一つのページを読み込むビュー持つページと一つのビューモデルを管理するプレゼンターの基本クラスです。
    /// </summary>
    /// <typeparam name="TView">管理するビューのクラスです。</typeparam>
    /// <typeparam name="TViewModel">管理するビューモデルのクラスです。</typeparam>
    public abstract class PagePresenterBase<TView, TViewModel> : ChildPagePresenterBaseCore
        where TView : Page, new()
        where TViewModel : ViewModelBase, new()
    {
        public PagePresenterBase()
        {
            this.ViewModel = new TViewModel();
        }

        /// <summary>
        /// Viewオブジェクト
        /// </summary>
        public TView View
        {
            get { return this.ViewBase as TView; }
            set { this.ViewBase = value; }
        }

        /// <summary>
        /// ViewModelオブジェクト
        /// </summary>
        public TViewModel ViewModel
        {
            get { return this.ViewModelBase as TViewModel; }
            set { this.ViewModelBase = value; }
        }

        public override void Initialize()
        {
            base.Initialize();

            View.Loaded += OnPageLoaded;
        }

        public override void Cleanup()
        {
            View.Loaded -= OnPageLoaded;
            base.Cleanup();
        }

        protected virtual void OnPageLoaded(object sender, RoutedEventArgs e)
        {

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {

        }

        protected override void OnNavigationProgress(NavigationProgressEventArgs e)
        {

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {

        }

        protected override void OnNavigationStopped(NavigationEventArgs e)
        {

        }

        protected override void OnNavigationFailed(NavigationFailedEventArgs e)
        {

        }

    }
}
