using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;

namespace UwpFramework.Presenters.Core
{

    /// <summary>
    /// Frameによる子コントロール入れ替えナビゲーション用クラス
    /// </summary>
    public abstract class ParentPresenterBaseCore
        : PresenterBaseCore
    {
        /// <summary>
        /// 現在のページ
        /// </summary>
        public ChildPagePresenterBaseCore CurrentChild { get; internal set; } = null;

        /// <summary>
        /// 子プレゼンター 
        /// </summary>
        protected Dictionary<Type, ChildPagePresenterBaseCore> Children { get; private set; }

        /// <summary>
        /// 子Presenterを追加
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="child">子Presenter</param>
        public void AddChild(Type key, ChildPagePresenterBaseCore child)
        {
            Children.Add(key, child);
        }

        /// <summary>
        /// 子Presenterを解除
        /// </summary>
        /// <param name="key">キー</param>
        public void RemoveChild(Type key)
        {
            Children.Remove(key);
        }

        public ParentPresenterBaseCore()
        {
            Children = new Dictionary<Type, ChildPagePresenterBaseCore>();
        }

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
            if (CurrentChild != null)
            {
                CurrentChild.Cleanup();
                CurrentChild = null;
            }

            base.Cleanup();
        }

        public abstract bool Navigate(Type key, object extraData = null, NavigationTransitionInfo infoOrverride = null);


        public bool EntranceNavigate(Type key, object extraData = null)
        {
            return Navigate(key, extraData, new EntranceNavigationTransitionInfo());
        }

        public bool DrillInNavigate(Type key, object extraData = null)
        {
            return Navigate(key, extraData, new DrillInNavigationTransitionInfo());
        }

        public bool SuppressNavigate(Type key, object extraData = null)
        {
            return Navigate(key, extraData, new SuppressNavigationTransitionInfo());
        }

        public abstract void GoForward();

        public abstract void GoBack(NavigationTransitionInfo infoOrverride = null);

        protected void View_NavigationStopped(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            CurrentChild.InvokeOnNavigationStopped(e);
        }

        protected void View_NavigationFailed(object sender, Windows.UI.Xaml.Navigation.NavigationFailedEventArgs e)
        {
            CurrentChild.InvokeOnNavigationFailed(e);
        }

        protected void View_Navigating(object sender, Windows.UI.Xaml.Navigation.NavigatingCancelEventArgs e)
        {
            if (CurrentChild != null)
            {
                CurrentChild.InvokeOnNavigatingFrom(e);
            }
        }

        protected internal void View_NavigatedCore(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            if (e != null)
            {
                if (CurrentChild != null)
                {
                    CurrentChild.InvokeOnNavigatedFrom(e);
                    CurrentChild.Cleanup();
                    CurrentChild = null;
                }

                MemoryCheck();

                Type key = e.Content.GetType();
                var child = Children[key];

                var element = e.Content as FrameworkElement;

                child.Parent = this;
                child.ViewBase = element;

                CurrentChild = child;

                child.Initialize();

                child.InvokeOnNavigatedTo(e);
            }
        }

        private long prevtotalMemory = 0;

        private void MemoryCheck()
        {
#if DEBUG
            GC.Collect();
            GC.WaitForFullGCComplete();
            GC.Collect();
            long totalMemory = GC.GetTotalMemory(false);

            System.Diagnostics.Debug.WriteLine("memory : {0}", totalMemory);
            System.Diagnostics.Debug.WriteLine("diff   : {0}", totalMemory - prevtotalMemory);
            prevtotalMemory = totalMemory;
#endif
        }

    }
}
