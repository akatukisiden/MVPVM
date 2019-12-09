using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using CoreWpfFramework.Presenters.Core;
using CoreWpfFramework.ViewModels;

namespace CoreWpfFramework.Presenters
{

    /// <summary>
    /// プレゼンター基底クラス
    /// </summary>
    /// <typeparam name="TView">Viewオブジェクトの型</typeparam>
    /// <typeparam name="TViewModel">ViewModelオブジェクトの型</typeparam>
    public abstract class PresenterBase<TView, TViewModel> : PresenterBaseCore
        where TView : FrameworkElement, new()
        where TViewModel : ViewModelBase, new()
    {

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

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PresenterBase() 
            : base()
        {
            ViewModel = new TViewModel();
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
            base.Cleanup();
        }
    }
}
