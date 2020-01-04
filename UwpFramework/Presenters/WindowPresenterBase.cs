using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace UwpFramework.Presenters
{
    public abstract class WindowPresenterBase
    {
        protected WindowPresenterBase()
        { }

        public Window Window { set; get; }


        public virtual void Initialize()
        {
            if (Window == null)
            {
                Window = Window.Current;
                Window.Activated += Window_Activated;
                Window.Closed += Window_Closed;
                Window.SizeChanged += Window_SizeChanged;
                Window.VisibilityChanged += Window_VisibilityChanged;
            }
        }

        public virtual void Cleanup()
        {
            Window.Activated -= Window_Activated;
            Window.Closed -= Window_Closed;
            Window.SizeChanged -= Window_SizeChanged;
            Window.VisibilityChanged -= Window_VisibilityChanged;
            Window = null;
        }

        public  void Activate()
        {
            Window.Activate();
        }

        public void Close()
        {
            Window.Close();
        }

        public void SetTitleBar(UIElement value)
        {
            Window.SetTitleBar(value);
        }

        private void Window_VisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            OnVisibilityChanged(e);
        }

        protected virtual void OnVisibilityChanged(VisibilityChangedEventArgs e)
        {

        }

        private void Window_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            OnSizeChanged(e);
        }

        protected virtual void OnSizeChanged(WindowSizeChangedEventArgs e)
        {

        }

        private void Window_Closed(object sender, CoreWindowEventArgs e)
        {
            OnClosed(e);
        }

        protected virtual void OnClosed(CoreWindowEventArgs e)
        {

        }

        private void Window_Activated(object sender, WindowActivatedEventArgs e)
        {
            OnActivated(e);
        }

        protected virtual void OnActivated(WindowActivatedEventArgs e)
        {

        }
    }
}
