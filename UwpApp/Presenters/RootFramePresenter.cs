using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpApp.Views;
using UwpFramework.Presenters;
using UwpFramework.ViewModels;
using Windows.UI.Xaml.Controls;

namespace UwpApp.Presenters
{
    
    public class RootFramePresenter : FramePresenterBase<Frame, EmptyViewModel>
    {
        public RootFramePresenter()
        {
            AddChild(typeof(Page1), new Page1Presenter());
            AddChild(typeof(Page2), new Page2Presenter());
        }

        public override void Initialize()
        {
            base.Initialize();
            this.IsNavigationStackEnabled = true;
        }

        public override void Cleanup()
        {
            base.Cleanup();
        }
    }
}
