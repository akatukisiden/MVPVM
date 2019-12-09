using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfFramework.ValueConverters
{

    /// <summary>
    /// ブール値をSystem.Windows.VisibilityのVisible/Hiddenに変換します
    /// </summary>
    public class BooleanToVisibleHiddenConverter : IValueConverter
    {
        /// <summary>
        /// ブール値をSystem.Windows.VisibilityのVisible/Hiddenに変換します
        /// </summary>
        /// <param name="value">変換するブール値。</param>
        /// <param name="targetType">バインディング ターゲット プロパティの型。</param>
        /// <param name="parameter">使用するコンバーター パラメーター。</param>
        /// <param name="culture">コンバーターで使用するカルチャ。</param>
        /// <returns>valueがtrueの時Visibility.Visible,valueがfalseの時Visibility.Hidden</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool b = (bool)value;

            return (b) ? (Visibility.Visible) : (Visibility.Hidden);
        }

        /// <summary>
        /// System.Windows.Visibilityをboolに変換します
        /// </summary>
        /// <param name="value">System.Windows.Visibility 列挙値</param>
        /// <param name="targetType">変換後の型。</param>
        /// <param name="parameter">使用するコンバーター パラメーター。</param>
        /// <param name="culture">コンバーターで使用するカルチャ。</param>
        /// <returns>Visibility.Visibleであればtrue,それ以外ならfalse</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((Visibility)value == Visibility.Visible);
        }
    }
}
