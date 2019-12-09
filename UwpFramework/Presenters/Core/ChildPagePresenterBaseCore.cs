using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace UwpFramework.Presenters.Core
{

    /// <summary>
    /// Frame を使用して一つのページを読み込むビュー持つページと一つのビューモデルを管理するプレゼンターの基本クラスです。
    /// </summary>
    public abstract class ChildPagePresenterBaseCore : PresenterBaseCore
    {
        /// <summary>
        /// 親Presenter Frame
        /// </summary>
        public ParentPresenterBaseCore Parent { get; set; }

        /// <summary>
        /// 初期化処理
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// クリーンアップ
        /// </summary>
        public override void Cleanup()
        {
            Parent = null;
            base.Cleanup();
        }

        internal void InvokeOnNavigatedTo(NavigationEventArgs e)
        {
            OnNavigatedTo(e);
        }

        internal void InvokeOnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            OnNavigatingFrom(e);
        }

        internal void InvokeOnNavigatedFrom(NavigationEventArgs e)
        {
            OnNavigatedFrom(e);
        }

        internal void InvokeOnNavigationStopped(NavigationEventArgs e)
        {
            OnNavigationStopped(e);
        }

        internal void InvokeOnNavigationFailed(NavigationFailedEventArgs e)
        {
            OnNavigationFailed(e);
        }

        protected abstract void OnNavigatedTo(NavigationEventArgs e);

        protected abstract void OnNavigatingFrom(NavigatingCancelEventArgs e);

        protected abstract void OnNavigatedFrom(NavigationEventArgs e);

        protected abstract void OnNavigationStopped(NavigationEventArgs e);

        protected abstract void OnNavigationFailed(NavigationFailedEventArgs e);

    }
}
