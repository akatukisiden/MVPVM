using System;
using System.Diagnostics;
using UwpFramework.Presenters.Core;
using UwpFramework.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace UwpFramework.Presenters
{
    /// <summary>
    /// Frameによる子コントロール入れ替えナビゲーション用クラス
    /// </summary>
    /// <typeparam name="TView">Viewの型</typeparam>
    /// <typeparam name="TViewModel">ViewModelの型</typeparam>
    public abstract class FramePresenterBase<TView, TViewModel>
        : ParentPresenterBaseCore
        where TView : Windows.UI.Xaml.Controls.Frame, new()
        where TViewModel : ViewModelBase, new()
    {
        /// <summary>
        /// 履歴を使うかどうか
        /// Initializeで設定
        /// </summary>
        public bool IsNavigationStackEnabled { get { return View.IsNavigationStackEnabled; } set { View.IsNavigationStackEnabled = value; } }

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
            ViewModel = new TViewModel();
        }

        public override void Initialize()
        {
            base.Initialize();
            IsNavigationStackEnabled = false;

            View.Navigating += View_Navigating;
            View.Navigated += View_Navigated;
            View.NavigationFailed += View_NavigationFailed;
            View.NavigationStopped += View_NavigationStopped;
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

            // Children.Clear();
            base.Cleanup();
        }

        /// <summary>
        /// キーを指定して登録された子Presenterへ遷移
        /// </summary>
        /// <param name="key">子Presenterのキー</param>
        /// <param name="extraData">パラメータ</param>
        /// <returns>true:キャンセルしていない、false:キャンセルした</returns>
        public override bool Navigate(Type key, object extraData = null, NavigationTransitionInfo infoOrverride =null)
        {
            return View.Navigate(key, extraData, infoOrverride);
        }

        public override void GoForward()
        {
            View.GoForward();
        }

        public override void GoBack(NavigationTransitionInfo infoOrverride = null)
        {
            View.GoBack(infoOrverride);
        }

        private void View_Navigated(object sender, NavigationEventArgs e)
        {
            View_NavigatedCore(sender, e);
        }

    }
}
