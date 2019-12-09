using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CoreWpfFramework.ViewModels
{

    /// <summary>
    /// ViewModelの基底クラス
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region INotifyDataErrorInfo

        /// <summary>
        /// エンティティに検証エラーがあるかどうかを示す値を取得します。
        /// エンティティに現在検証エラーがある場合は true、それ以外の場合は false。
        /// </summary>
        public bool HasErrors { get { return _errors.Count > 0; } }

        /// <summary>
        ///  プロパティまたはエンティティ全体で検証エラーが変更されたときに発生します。
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        /// 指定したプロパティまたはエンティティ全体の検証エラーを取得します。
        /// </summary>
        /// <param name="propertyName">
        /// 検証エラーを取得するプロパティの名前。
        /// または、エンティティ レベルのエラーを取得するための null または System.String.Empty。</param>
        /// <returns>プロパティまたはエンティティの検証エラー。</returns>
        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) ||
                !_errors.ContainsKey(propertyName))
            {
                return null; // もしかしたらemptylistの方がいいかも？
            }
            else
            {
                return _errors[propertyName];
            }
        }

        private void OnErrorsChanged(string propertyName)
        {
            var h = this.ErrorsChanged;
            if (h != null)
            {
                h(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// エラー追加
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        /// <param name="message">エラーメッセージ</param>
        public void AddError(string propertyName, string message)
        {

            if (!_errors.ContainsKey(propertyName))
            {
                _errors.Add(propertyName, new List<string>());
            }

            _errors[propertyName].Add(message);
            OnErrorsChanged(propertyName);
        }

        /// <summary>
        /// 指定したプロパティの指定したエラーを解除する
        /// messageがnullの時はプロパティごとDictionaryから削除する
        /// そのプロパティのエラーがすべて解除された場合Dictionaryから除去する
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        /// <param name="message">エラーメッセージ</param>
        public void RemoveError(string propertyName, string message = null)
        {
            if (_errors.ContainsKey(propertyName))
            {
                if (message == null)
                {
                }
                else
                {
                    if (_errors[propertyName].Contains(message))
                    {
                        _errors[propertyName].Remove(message);
                        if (_errors[propertyName].Count == 0)
                        {
                            _errors.Remove(propertyName);
                        }
                    }
                }
            }

            OnErrorsChanged(propertyName);
        }

        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        /// <summary>
        /// 入力検証
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        protected virtual void ValidateProperty([CallerMemberName]string propertyName = null)
        {
            /*
            switch (propertyName)
            {
                case "InputString":
                    if (this.InputString.Count() > 10)
                        AddError("InputString", "string is larger than MaxLength");
                    else
                        RemoveError("InputString");
                    break;
                default:
                    break;
            }
            */
        }

        #endregion

        /// <summary>
        /// PropertyChangedイベントを発火する
        /// </summary>
        /// <param name="propertyname">プロパティ名</param>
        public void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        /// <summary>
        /// プロパティ値が変更するときに発生します。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティに値をセットします。
        /// </summary>
        /// <typeparam name="T">プロパティの型</typeparam>
        /// <param name="propertyReference">プロパティの内部変数の参照</param>
        /// <param name="value">新しい値</param>
        /// <param name="propertyName">プロパティ名</param>
        /// <returns>プロパティを変更したかどうか</returns>
        public bool SetProperty<T>(ref T propertyReference, T value, [CallerMemberName] String propertyName = null)
        {
            if (propertyReference == null)
            {
                if (value != null)
                {
                    propertyReference = value;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (!propertyReference.Equals(value))
                {
                    propertyReference = value;
                    OnPropertyChanged(propertyName);
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }
}
