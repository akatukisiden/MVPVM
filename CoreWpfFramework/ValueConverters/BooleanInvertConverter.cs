using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfFramework.ValueConverters
{
    /// <summary>
    /// Bool値を逆転します。
    /// </summary>
    public class BooleanInvertConverter : IValueConverter
    {
        /// <summary>
        /// bool値を逆転します
        /// </summary>
        /// <param name="value">バインディング ソースによって生成された値。</param>
        /// <param name="targetType">バインディング ターゲット プロパティの型。</param>
        /// <param name="parameter">使用するコンバーター パラメーター。</param>
        /// <param name="culture">コンバーターで使用するカルチャ。</param>
        /// <returns>valueがtrueならfalse,falseならtrueを返します</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (!(bool)value);
        }

        /// <summary>
        /// bool値を逆転します
        /// </summary>
        /// <param name="value">バインディング ターゲットによって生成された値。</param>
        /// <param name="targetType">変換後の型。</param>
        /// <param name="parameter">使用するコンバーター パラメーター。</param>
        /// <param name="culture">コンバーターで使用するカルチャ。</param>
        /// <returns>valueがtrueならfalse,falseならtrueを返します</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (!(bool)value);
        }
    }
}
