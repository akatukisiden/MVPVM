﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using CoreWpfFramework.ViewModels;

namespace CoreWpfFramework.Presenters.Core
{

    public abstract class PresenterBaseCore// : IPresenterBaseCore
    {
        /// <summary>
        /// UIスレッドのタスクスケジューラー
        /// </summary>
        protected TaskScheduler UIThreadTaskScheduler { get; private set; }

        /// <summary>
        /// Presenterが有効かどうか
        /// Initializeが呼び出されてからCleanupが呼び出されるまでの間=true
        /// </summary>
        public bool IsEnable { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        protected PresenterBaseCore()
        {
            this.IsEnable = false;
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        public virtual void Initialize()
        {
            this.UIThreadTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            
            ViewBase.DataContext = ViewModelBase;

            IsEnable = true;
        }

        /// <summary>
        /// クリーンアップ
        /// </summary>
        public virtual void Cleanup()
        {
            if (ViewBase != null)
            {
                ViewBase.DataContext = null;
                ViewBase = null;
            }

            IsEnable = false;
        }

        /// <summary>
        /// Viewオブジェクトのアクセサ
        /// ジェネリックなしインターフェース用
        /// </summary>
        internal FrameworkElement ViewBase { get; set; }

        /// <summary>
        /// ViewModelオブジェクトのアクセサ
        /// ジェネリックなしインターフェース用
        /// </summary>
        internal ViewModelBase ViewModelBase { get; set; }

    }
}
