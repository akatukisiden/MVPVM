using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace CoreWpfFramework.Presenters.Core
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
        protected Dictionary<Type, ChildPagePresenterBaseCore> Children { get; private set; } = new Dictionary<Type, ChildPagePresenterBaseCore>();

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

            // Children.Clear();
            
            base.Cleanup();
        }

        public abstract bool Navigate(Uri uri, object extraData = null);
        public abstract bool Navigate(string uri, object extraData = null);

        public abstract void GoForward();

        public abstract void GoBack();

        protected void View_NavigationStopped(object sender, NavigationEventArgs e)
        {
            CurrentChild.InvokeOnNavigationStopped(e);   
        }

        protected void View_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            CurrentChild.InvokeOnNavigationFailed(e);
        }

        protected void View_NavigatingCore(object sender, NavigatingCancelEventArgs e)
        {
            if (CurrentChild != null)
            {
                CurrentChild.InvokeOnNavigatingFrom(e);
            }
        }


        protected void View_NavigationProgress(object sender, NavigationProgressEventArgs e)
        {
            if (CurrentChild != null)
            {
                CurrentChild.InvokeOnNavigatingProgress(e);
            }
        }

        protected internal void View_NavigatedCore(object sender, NavigationEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                throw new IOException(null, ex);
            }

        }

        // private long prevtotalMemory = 0;

        private void MemoryCheck()
        {
#if DEBUG
            GC.Collect();
            GC.WaitForFullGCComplete();
            GC.Collect();
            long totalMemory = GC.GetTotalMemory(false);

            System.Diagnostics.Debug.WriteLine("memory : {0}", totalMemory);
            // System.Diagnostics.Debug.WriteLine("diff   : {0}", totalMemory - prevtotalMemory);
            // prevtotalMemory = totalMemory;
#endif
        }
    }
}
