using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpFramework.Presenters;
using UwpFramework.Presenters.Core;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UwpApp.Presenters
{
    public class WindowPresenter :WindowPresenterBase
    {

        public RootFramePresenter RootFramePresenter { get; set; }

        public WindowPresenter()
        {
            RootFramePresenter = new RootFramePresenter();
        }

        public override void Initialize()
        {
            base.Initialize();

            // ナビゲーション コンテキストとして動作するフレームを作成し、最初のページに移動します
            var root = new Frame();
            this.Window.Content = root;
            this.RootFramePresenter.View = root;
            this.RootFramePresenter.Initialize();
        }

        public bool Navigate(Type key)
        {
            return RootFramePresenter.Navigate(key);
        }

        public override void Cleanup()
        {
            base.Cleanup();
        }

        protected override void OnActivated(WindowActivatedEventArgs e)
        {
            base.OnActivated(e);
        }

        protected override void OnClosed(CoreWindowEventArgs e)
        {
            base.OnClosed(e);
        }

        protected override void OnSizeChanged(WindowSizeChangedEventArgs e)
        {
            base.OnSizeChanged(e);
        }

        protected override void OnVisibilityChanged(VisibilityChangedEventArgs e)
        {
            base.OnVisibilityChanged(e);
        }
    }
}
