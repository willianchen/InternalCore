using System;
using System.Collections.Generic;
using System.Text;

namespace PcbHunt.Core
{
    /// <summary>
    /// Json拓展
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 将对象转换为Json字符串
        /// </summary>
        /// <param name="obj">目标对象</param>
        /// <param name="isConvertToSingleQuotes">是否将双引号转成单引号</param>
        public static string ToJson(this object obj, bool isConvertToSingleQuotes = false)
        {
            if (obj == null)
                return string.Empty;
            return Helpers.Json.ToJson(obj, isConvertToSingleQuotes);
        }

        /// <summary>
        /// 将Json字符串转换为对象
        /// </summary>
        /// <param name="json">Json字符串</param>
        public static T JsonToObject<T>(this string obj)
        {
            if (string.IsNullOrWhiteSpace(obj))
                return default(T);
            return Helpers.Json.ToObject<T>(obj);
        }
    }
}
