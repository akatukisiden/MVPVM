using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using CoreWpfFramework.Presenters.Core;
using CoreWpfFramework.ViewModels;

namespace CoreWpfFramework.Presenters
{
    /// <summary>
    /// Frameによる子コントロール入れ替えナビゲーション用クラス
    /// </summary>
    /// <typeparam name="TView">Viewの型</typeparam>
    /// <typeparam name="TViewModel">ViewModelの型</typeparam>
    public abstract class FramePresenterBase<TView, TViewModel>
        : ParentPresenterBaseCore
        where TView : Frame, new()
        where TViewModel : ViewModelBase, new()
    {

        /// <summary>
        /// 履歴を使うかどうか
        /// </summary>
        public bool IsNavigationStackEnabled { get; set; } = false;

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

        public FramePresenterBase()
        {
            this.ViewModel = new TViewModel();
        }

        public override void Initialize()
        {
            base.Initialize();

            View.Navigating += View_Navigating;
            View.Navigated += View_Navigated;
            View.NavigationFailed += View_NavigationFailed;
            View.NavigationStopped += View_NavigationStopped;
            View.NavigationProgress += View_NavigationProgress;
        }

        /// <summary>
        /// クリーンアップ
        /// </summary>
        public override void Cleanup()
        {
            View.Navigating -= View_Navigating;
            View.Navigated -= View_Navigated;
            View.NavigationFailed -= View_NavigationFailed;
            View.NavigationStopped -= View_NavigationStopped;
            View.NavigationProgress -= View_NavigationProgress;

            base.Cleanup();
        }

        /// <summary>
        /// キーを指定して登録された子Presenterへ遷移
        /// </summary>
        /// <param name="uri">子Presenterのキー</param>
        /// <param name="extraData">パラメータ</param>
        /// <returns>true:キャンセルしていない、false:キャンセルした</returns>
        public override bool Navigate(Uri uri, object extraData = null)
        {
            return View.Navigate(uri, extraData);
        }

        public override bool Navigate(string uri, object extraData = null)
        {
            return Navigate(new Uri(uri, UriKind.RelativeOrAbsolute), extraData);
        }

        public override void GoForward()
        {
            View.GoForward();
        }

        public override void GoBack()
        {
            View.GoBack();
        }

        protected void View_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e != null)
            {
                View_NavigatingCore(sender, e);
                if (e.Cancel)
                {
                    View.StopLoading();
                }
            }
        }

        protected void View_Navigated(object sender, NavigationEventArgs e)
        {
            if (!IsNavigationStackEnabled)
            {
                View.NavigationService.RemoveBackEntry();
            }
            
            View_NavigatedCore(sender, e);
        }
    }
}
