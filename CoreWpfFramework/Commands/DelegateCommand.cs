using System;
using System.Windows.Input;

namespace CoreWpfFramework.Commands
{
    /// <summary>
    /// DelegateCommandのインターフェース
    /// </summary>
    public interface IDelegateCommand : ICommand
    {
        /// <summary>
        /// CanExecuteChangedを発火する
        /// </summary>
        void CallCanExecuteChanged();
    }

    /// <summary>
    /// DelegateCommand パラメータの型指定版
    /// </summary>
    /// <typeparam name="T">コマンドに渡すパラメータの型</typeparam>
    public class DelegateCommand<T> : IDelegateCommand
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="execute">コマンドが起動される際に呼び出すメソッド</param>
        /// <param name="canExecute">現在の状態でコマンドが実行可能かどうかを決定するメソッド</param>
        public DelegateCommand(Action<T> execute = null, Func<T, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// コマンドを実行するかどうかに影響するような変更があった場合に発生します。
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// CanExecuteChangedを発生させます。
        /// </summary>
        public void CallCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, null);
            }
        }

        private Func<T, bool> _canExecute;

        /// <summary>
        /// 現在の状態でコマンドが実行可能かどうかを決定するメソッドを定義します。
        /// </summary>
        /// <param name="parameter">
        /// コマンドにより使用されるデータです。
        /// コマンドにデータを渡す必要がない場合は、このオブジェクトを null に設定できます。</param>
        /// <returns>このコマンドを実行できる場合は、true。それ以外の場合は、false。</returns>
        public bool CanExecute(object parameter)
        {
            bool result = (_canExecute == null) ? (true) : _canExecute((T)parameter);
            return result;
        }

        private Action<T> _execute;

        /// <summary>
        /// コマンドが起動される際に呼び出すメソッドを定義します。
        /// </summary>
        /// <param name="parameter">
        /// コマンドにより使用されるデータです。 
        /// コマンドにデータを渡す必要がない場合は、このオブジェクトを null に設定できます。
        /// </param>
        public void Execute(object parameter)
        {
            if (_execute != null)
            {
                _execute((T)parameter);
            }
            else
            {
            }
        }
    }

    /// <summary>
    /// DelegateCommand
    /// </summary>
    public class DelegateCommand : IDelegateCommand
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="execute">コマンドが起動される際に呼び出すメソッド</param>
        /// <param name="canExecute">現在の状態でコマンドが実行可能かどうかを決定するメソッド</param>
        public DelegateCommand(Action<object> execute = null, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        private Func<object, bool> _canExecute;

        /// <summary>
        /// 現在の状態でコマンドが実行可能かどうかを決定するメソッドを定義します。
        /// </summary>
        /// <param name="parameter">
        /// コマンドにより使用されるデータです。
        /// コマンドにデータを渡す必要がない場合は、このオブジェクトを null に設定できます。</param>
        /// <returns>このコマンドを実行できる場合は、true。それ以外の場合は、false。</returns>
        public bool CanExecute(object parameter)
        {
            bool result = (_canExecute == null) ? (true) : _canExecute(parameter);
            return result;
        }

        private Action<object> _execute;

        /// <summary>
        /// コマンドが起動される際に呼び出すメソッドを定義します。
        /// </summary>
        /// <param name="parameter">
        /// コマンドにより使用されるデータです。 
        /// コマンドにデータを渡す必要がない場合は、このオブジェクトを null に設定できます。
        /// </param>
        public void Execute(object parameter)
        {
            if (_execute != null)
            {
                _execute(parameter);
            }
        }

        /// <summary>
        /// コマンドを実行するかどうかに影響するような変更があった場合に発生します。
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// CanExecuteChanged呼び出します。
        /// </summary>
        public void CallCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, null);
            }
        }
    }
}
